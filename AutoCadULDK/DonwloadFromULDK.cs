/*
 * Autor: Damian Zacheja
 * 
 * Klasa odpowiedzalna za logikę podczas pobierania działek,
 * sprawdza popraność geometrii i przekształca otrzymane n
 * 
 */
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Exception = Autodesk.AutoCAD.Runtime.Exception;

namespace AutoCadULDK {

    public class DonwloadFromULDK {
        public bool resultat;
        public string informacja;
        public int iloscPobranych;
        private List<Task> DonwloadingItems;
        private List<Polygon> DonwloadingPolygons;
        private FormULDK form;
        private double RectangleArea;

        /// <summary>
        /// Wstawianie obiektu we wskazanym punkcie
        /// </summary>
        /// <param name="obj">Obiekt z informacjami do pobrania</param>
        /// <returns>Nowo pobrany obiekt zostanie wstawiony do rysunku</returns>
        public async Task InsertByXY(ObjectULDK obj) {
            ULDKRequest.ByXY(obj);

            if (obj.errorOccured) {
                resultat = false;
                informacja = "Wystąpił błąd: " + obj.errorMessage;
                return;
            } else {
                ObjectInsert.AddElement(obj);
                resultat = true;
                informacja = $"Pomyślnie pobrano obiekt: {obj.resultsName}!";
            }
        }
        ///<summary>
        ///Fuckcja na podstawie identyfikatora działki oraz układu współrzędnych
        ///wysyła zapytanie do ULDK i otrzymuje z metody w klasie ULDKRequest kontener
        ///zawierający współrzędne działki
        ///</summary>
        public async Task InsertByParcelID(ObjectULDK obj) {

            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor edt = doc.Editor;
            ULDKRequest.ByIdentifier(obj);
            if (obj.errorOccured) {
                resultat = false;
                informacja = "Wystąpił błąd: " + obj.errorMessage;
                return;
            } else {
                ObjectInsert.AddElement(obj);
                resultat = true;
                informacja = $"Pomyślnie pobrano {obj.PolishName}!";
            }
        }

        /// <summary>
        /// Pobranie działek ze wskazanego zakresu 
        /// </summary>
        /// <param name="XY">Tablica współrzędnych prostokąta</param>
        /// <param name="EPSG">Układ współrzędnych</param>
        /// <param name="f">Okno formularza do aktualizacji ...</param>
        /// <returns>Pobranie obiekty w zakresie</returns>
        public async Task InsertByRange(double[] XY, string EPSG, FormULDK f) {
            form = f;
            //Wyszukiwanie działek z podanego zakresu...
            double MinX, MaxX, MinY, MaxY;
            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(Convert.ToInt32(EPSG));
            List<Polyline> polylines = new List<Polyline>();
            DonwloadingPolygons = new List<Polygon>();
            //Określenie max X i max Y...
            if (XY[0] > XY[2]) {
                MaxX = XY[0];
                MinX = XY[2];
            } else {
                MaxX = XY[2];
                MinX = XY[0];
            }

            if (XY[1] > XY[3]) {
                MaxY = XY[1];
                MinY = XY[3];
            } else {
                MaxY = XY[3];
                MinY = XY[1];
            }
            var RectPolygon = gf.CreatePolygon(new[] {
                new NetTopologySuite.Geometries.Coordinate(MinX,MinY),
                new NetTopologySuite.Geometries.Coordinate(MaxX,MinY),
                new NetTopologySuite.Geometries.Coordinate(MaxX,MaxY),
                new NetTopologySuite.Geometries.Coordinate(MinX,MaxY),
                new NetTopologySuite.Geometries.Coordinate(MinX,MinY)
            });
            DonwloadingItems = new List<Task>();
            DonwloadingPolygons.Add(RectPolygon);
            RectangleArea = RectPolygon.Area;
            var Tasks = Task.Run(async () => {
                form.SetUpVisibilityForProgresBar = true;
                DonwloadAllParcelsFromPolygon(DonwloadingPolygons, EPSG);
                await Task.Delay(1000);
                form.SetUpVisibilityForProgresBar = false;

            });
            DonwloadingItems.Add(Tasks);

            Task.WaitAll(DonwloadingItems.ToArray());
        }

        /// <summary>
        /// Pobieranie działek z zakresu poligonu
        /// </summary>
        /// <param name="polygons">Poligon do analizy</param>
        /// <param name="EPSG">KOD</param>
        /// <exception cref="System.Exception"></exception>
        private async void DonwloadAllParcelsFromPolygon(List<Polygon> polygons, string EPSG) {
            while (polygons.Count > 0) {
                while (polygons.Count > 0 && polygons[0].Area > 0) {
                    double X, Y;
                    var pos = polygons[0].Coordinates;
                    X = pos[0].X;
                    Y = pos[0].Y;
                    string strCurPos = X.ToString("F3").Replace(',', '.') + "," + Y.ToString("F3").Replace(',', '.');

                    ObjectULDK objUl = new ObjectULDK(strCurPos, EPSG);
                    objUl.Type = "GetParcelByXY";
                    objUl.ResultsArgs = "id,voivodeship,county,commune,region";
                    List<Polyline> polylines = new List<Polyline>();
                    GetAndInsertByXY(objUl, ref polylines);
                    if (!resultat) {
                        X = X + 1;
                        strCurPos = X.ToString("F3").Replace(',', '.') + "," + Y.ToString("F3").Replace(',', '.');
                        objUl.coordinates = strCurPos;
                        GetAndInsertByXY(objUl, ref polylines);
                        if (!resultat) {
                            form.ChangeLblInfo("Błąd pobierania działki");
                            throw new System.Exception("Błąd pobierania");
                        }
                        break;
                    }
                    try {
                        polygons[0] = await ClipRectangle(polygons[0], objUl);
                        double summaryArea = 0;
                        foreach(var poly in polygons) {
                            summaryArea += poly.Area;
                        }
                        summaryArea = RectangleArea - summaryArea;
                        iloscPobranych++;
                        form.ChangeMultilblInfo(RectangleArea, summaryArea, iloscPobranych, polygons[0].Area, objUl.resultsName);
                        
                        System.Windows.Forms.Application.DoEvents();
                        if (polygons[0].Area <= 0) {
                            DonwloadingPolygons.Remove(polygons[0]);
                        }
                    } catch (System.Exception ex) {
                        DonwloadingPolygons.Remove(polygons[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Przytnij obecny obszar wyszukiwania o obecną działkę i rozdziel poligony w razie konieczności
        /// </summary>
        /// <param name="rect"> Obecny poligon</param>
        /// <param name="obj">Nowo pobrana działka</param>
        /// <returns>Nowy obszar do obliczeń</returns>
        public async Task<Polygon> ClipRectangle(Polygon rect, ObjectULDK obj) {
            List<Coordinate> cords = new List<Coordinate>();
            foreach (int key in obj.points.Keys) {
                if (key == -2) {
                    continue;
                } else {
                    string[] cord = obj.points[key].Split(';');
                    double X = Convert.ToDouble(cord[0]);
                    double Y = Convert.ToDouble(cord[1]);
                    cords.Add(new NetTopologySuite.Geometries.Coordinate(X, Y));
                }
            }
            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(Convert.ToInt32(obj.EPSG));
            if ((cords[0].X != cords[cords.Count - 1].X) || (cords[0].Y != cords[cords.Count - 1].Y))
                cords.Add(cords[0]);

            var netPoly = gf.CreatePolygon(cords.ToArray());
            netPoly = gf.CreatePolygon(netPoly.Coordinates);
            var bufPolyGeom = netPoly.Buffer(2);
            var bufCrd = new List<Coordinate>(bufPolyGeom.Coordinates);
            
            if ((bufCrd[0].X != bufCrd[bufCrd.Count - 1].X) || (bufCrd[0].Y != bufCrd[bufCrd.Count - 1].Y))
                bufCrd.Add(bufCrd[0]);
            
            var bufPolyPolygon = gf.CreatePolygon(bufCrd.ToArray());
            var diff = rect.Difference(bufPolyGeom);
            Polygon newRect;
            if (diff.GeometryType == "MultiPolygon") {
                List<Polygon> polys = new List<Polygon>();
                for (int i = 0; i < diff.NumGeometries; i++) {
                    var newGeom = diff.GetGeometryN(i);
                    if (newGeom.Boundary.NumGeometries > 1) {
                        LinearRing mainLin = default;
                        List<LinearRing> Holes = new List<LinearRing>();
                        for (int j = 0; j < newGeom.Boundary.NumGeometries; ++j) {
                            if (j == 0)
                                mainLin = gf.CreateLinearRing(diff.Boundary.GetGeometryN(j).Coordinates);
                            else
                                Holes.Add(gf.CreateLinearRing(diff.Boundary.GetGeometryN(j).Coordinates));
                        }
                        polys.Add(gf.CreatePolygon(mainLin, Holes.ToArray()));
                    } else {
                        polys.Add(gf.CreatePolygon(diff.GetGeometryN(i).Coordinates));
                    }
                }

                for (int i = 1; i < polys.Count; i++) {
                    DonwloadingPolygons.Add(polys[i]);
                }
                return polys[0];
            } else {
                if (diff.Boundary.NumGeometries > 1) {
                    LinearRing mainLin = default;
                    List<LinearRing> Holes = new List<LinearRing>();
                    for (int i = 0; i < diff.Boundary.NumGeometries; ++i) {
                        if (i == 0)
                            mainLin = gf.CreateLinearRing(diff.Boundary.GetGeometryN(i).Coordinates);
                        else
                            Holes.Add(gf.CreateLinearRing(diff.Boundary.GetGeometryN(i).Coordinates));
                    }
                    newRect = gf.CreatePolygon(mainLin, Holes.ToArray());
                    return newRect;
                } else {
                    newRect = gf.CreatePolygon(diff.Coordinates);
                    return newRect;
                }
            }
        }
        private void GetAndInsertByXY(ObjectULDK obj, ref List<Polyline> polys) {
            ULDKRequest.ByXY(obj);
            try {
                ObjectInsert.AddElement(obj);
                resultat = true;
            } catch (Exception e) {
                throw new System.Exception("Błąd podczas dodawnia działki");
            }
            
        }

    }
}