/*
 * Autor Damian Zacheja
 * 
 * Klasa odpowiedzalna za wstawianie pobranych obiektów na rysunek
 * oraz przypisywanie odpowienich atrybutów do bloku 
 * 
 */

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCadULDK {
    public static class ObjectInsert {
        private static readonly string ParcelLayer = "DziałkaULDK";
        private static readonly string RegionLayer = "ObrębULDK";
        private static readonly string CommuneLayer = "GminaULDK";
        private static readonly string CountyLayer = "PowiatULDK";
        private static readonly string VoivodeshipLayer = "WojewództwoULDK";


        /// <summary>
        /// Wstawienie pobranego elementu do rysunku
        /// </summary>
        /// <param name="ULDK_obj"></param>
        public static void AddElement(ObjectULDK ULDK_obj) {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor edt = doc.Editor;
            Database db = doc.Database;
            using (DocumentLock dLock = doc.LockDocument()) {
                using (Transaction tr = doc.TransactionManager.StartTransaction()) {
                    BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Polyline pl = new Polyline();
                    string[] resText = ULDK_obj.resultsElements;

                    string[] cord;
                    int i = 0;
                    Point3d insPT = new Point3d(0, 0, 0);
                    //Wstawienie działki na model w odpowiednim układzie
                    foreach (int key in ULDK_obj.points.Keys) {
                        if (key == -2) {
                            cord = ULDK_obj.points[key].Split(';');
                            double X = Convert.ToDouble(cord[0]);
                            double Y = Convert.ToDouble(cord[1]);
                            insPT = new Point3d(X, Y, 0);
                        } else {
                            cord = ULDK_obj.points[key].Split(';');

                            double X = Convert.ToDouble(cord[0]);
                            double Y = Convert.ToDouble(cord[1]);
                            pl.AddVertexAt(i, new Point2d(X, Y), 0, 0, 0);
                            i++;
                        }
                        pl.Closed = true;
                    }
                    string Type = ULDK_obj.Type.Replace("Get", "");
                    Type = Type.Substring(0, Type.IndexOf("By"));
                    switch (Type) {
                        case "Parcel":
                            DrawingUtilities.AddLayer(ParcelLayer);
                            pl.Layer = ParcelLayer;
                            AddParcelTextBlock(bt, tr, insPT, btr, resText);
                            break;
                        case "Region":
                            DrawingUtilities.AddLayer(RegionLayer);
                            pl.Layer = RegionLayer;
                            AddRegionTextBlock(bt, tr, insPT, btr, resText);
                            break;
                        case "Commune":
                            DrawingUtilities.AddLayer(CommuneLayer);
                            pl.Layer = CommuneLayer;
                            AddCommuneTextBlock(bt, tr, insPT, btr, resText);
                            break;
                        case "County":
                            DrawingUtilities.AddLayer(CountyLayer);
                            pl.Layer = CountyLayer;
                            AddCountyTextBlock(bt, tr, insPT, btr, resText);
                            break;
                        case "Voivodeship":
                            DrawingUtilities.AddLayer(VoivodeshipLayer);
                            pl.Layer = VoivodeshipLayer;
                            AddVoivodeshipTextBlock(bt, tr, insPT, btr, resText);
                            break;

                    }

                    btr.AppendEntity(pl);
                    tr.AddNewlyCreatedDBObject(pl, true);
                    db.TransactionManager.QueueForGraphicsFlush();
                    tr.Commit();
                }
            }
        }

        /// <summary>
        /// Wstawienie działki
        /// </summary>
        /// <param name="bt">Nowo utworzony blok</param>
        /// <param name="tr">Objekt transakcji</param>
        /// <param name="insPT"Punkt wstawienia tekstu</param>
        /// <param name="btr">Referencja do bloku</param>
        /// <param name="resText">Tekst</param>
        public static void AddParcelTextBlock(BlockTable bt, Transaction tr, Point3d insPT, BlockTableRecord btr, string[] resText) {
            string BlockName = "OpisDzialkiULDK";
            BlockTableRecord blockDef = bt[BlockName].GetObject(OpenMode.ForRead) as BlockTableRecord;
            BlockReference block = new BlockReference(insPT, blockDef.ObjectId);
            block.Layer = ParcelLayer;
            btr.AppendEntity(block);
            tr.AddNewlyCreatedDBObject(block, true);

            foreach (ObjectId obID in blockDef) {
                DBObject obj = obID.GetObject(OpenMode.ForRead);
                AttributeDefinition attDef = obj as AttributeDefinition;
                if ((attDef != null) && (!attDef.Constant)) {
                    using (AttributeReference attRef = new AttributeReference()) {
                        attRef.SetAttributeFromBlock(attDef, block.BlockTransform);
                        switch (attRef.Tag) {
                            case "NUMER":
                                attRef.TextString = resText[0].Substring(resText[0].LastIndexOf('.') + 1);
                                break;
                            case "OBRĘB":
                                attRef.TextString = resText[1];
                                break;
                            case "GMINA":
                                attRef.TextString = resText[2];
                                break;
                            case "POWIAT":
                                attRef.TextString = resText[3];
                                break;
                            case "WOJEWÓDZTWO":
                                attRef.TextString = resText[4];
                                break;
                            case "TERYT":
                                attRef.TextString = resText[0];
                                break;
                        }
                        block.AttributeCollection.AppendAttribute(attRef);
                        tr.AddNewlyCreatedDBObject(attRef, true);
                    }
                }
            }
        }

        /// <summary>
        /// Obrębu
        /// </summary>
        /// <param name="bt">Nowo utworzony blok</param>
        /// <param name="tr">Objekt transakcji</param>
        /// <param name="insPT"Punkt wstawienia tekstu</param>
        public static void AddRegionTextBlock(BlockTable bt, Transaction tr, Point3d insPT, BlockTableRecord btr, string[] resText) {
            string BlockName = "OpisObrebuULDK";
            BlockTableRecord blockDef = bt[BlockName].GetObject(OpenMode.ForRead) as BlockTableRecord;
            BlockReference block = new BlockReference(insPT, blockDef.ObjectId);
            block.Layer = RegionLayer;
            btr.AppendEntity(block);
            tr.AddNewlyCreatedDBObject(block, true);
            foreach (ObjectId obID in blockDef) {
                DBObject obj = obID.GetObject(OpenMode.ForRead);
                AttributeDefinition attDef = obj as AttributeDefinition;
                if ((attDef != null) && (!attDef.Constant)) {
                    using (AttributeReference attRef = new AttributeReference()) {
                        attRef.SetAttributeFromBlock(attDef, block.BlockTransform);
                        switch (attRef.Tag) {
                            case "OBRĘB":
                                attRef.TextString = resText[0];
                                break;
                            case "GMINA":
                                attRef.TextString = resText[1];
                                break;
                            case "POWIAT":
                                attRef.TextString = resText[2];
                                break;
                            case "WOJEWÓDZTWO":
                                attRef.TextString = resText[3];
                                break;
                            case "TERYT":
                                attRef.TextString = resText[4];
                                break;
                        }
                        block.AttributeCollection.AppendAttribute(attRef);
                        tr.AddNewlyCreatedDBObject(attRef, true);
                    }
                }
            }
        }

        /// <summary>
        /// Wstawienie gminy
        /// </summary>
        /// <param name="bt">Nowo utworzony blok</param>
        /// <param name="tr">Objekt transakcji</param>
        /// <param name="insPT"Punkt wstawienia tekstu</param>
        public static void AddCommuneTextBlock(BlockTable bt, Transaction tr, Point3d insPT, BlockTableRecord btr, string[] resText) {
            string BlockName = "OpisGminyULDK";
            BlockTableRecord blockDef = bt[BlockName].GetObject(OpenMode.ForRead) as BlockTableRecord;
            BlockReference block = new BlockReference(insPT, blockDef.ObjectId);
            block.Layer = CommuneLayer;
            btr.AppendEntity(block);
            tr.AddNewlyCreatedDBObject(block, true);
            foreach (ObjectId obID in blockDef) {
                DBObject obj = obID.GetObject(OpenMode.ForRead);
                AttributeDefinition attDef = obj as AttributeDefinition;
                if ((attDef != null) && (!attDef.Constant)) {
                    using (AttributeReference attRef = new AttributeReference()) {
                        attRef.SetAttributeFromBlock(attDef, block.BlockTransform);
                        switch (attRef.Tag) {
                            case "GMINA":
                                attRef.TextString = resText[0];
                                break;
                            case "POWIAT":
                                attRef.TextString = resText[1];
                                break;
                            case "WOJEWÓDZTWO":
                                attRef.TextString = resText[2];
                                break;
                            case "TERYT":
                                attRef.TextString = resText[3];
                                break;
                        }
                        block.AttributeCollection.AppendAttribute(attRef);
                        tr.AddNewlyCreatedDBObject(attRef, true);
                    }
                }
            }
        }

        /// <summary>
        /// Wstawienie powiatu
        /// </summary>
        /// <param name="bt">Nowo utworzony blok</param>
        /// <param name="tr">Objekt transakcji</param>
        /// <param name="insPT"Punkt wstawienia tekstu</param>
        public static void AddCountyTextBlock(BlockTable bt, Transaction tr, Point3d insPT, BlockTableRecord btr, string[] resText) {
            string BlockName = "OpisPowiatuULDK";
            BlockTableRecord blockDef = bt[BlockName].GetObject(OpenMode.ForRead) as BlockTableRecord;
            BlockReference block = new BlockReference(insPT, blockDef.ObjectId);
            block.Layer = CountyLayer;
            btr.AppendEntity(block);
            tr.AddNewlyCreatedDBObject(block, true);
            foreach (ObjectId obID in blockDef) {
                DBObject obj = obID.GetObject(OpenMode.ForRead);
                AttributeDefinition attDef = obj as AttributeDefinition;
                if ((attDef != null) && (!attDef.Constant)) {
                    using (AttributeReference attRef = new AttributeReference()) {
                        attRef.SetAttributeFromBlock(attDef, block.BlockTransform);
                        switch (attRef.Tag) {
                            case "POWIAT":
                                attRef.TextString = resText[0];
                                break;
                            case "WOJEWÓDZTWO":
                                attRef.TextString = resText[1];
                                break;
                            case "TERYT":
                                attRef.TextString = resText[2];
                                break;
                        }
                        block.AttributeCollection.AppendAttribute(attRef);
                        tr.AddNewlyCreatedDBObject(attRef, true);
                    }
                }
            }
        }

        /// <summary>
        /// Wstawienie województwa
        /// </summary>
        /// <param name="bt">Nowo utworzony blok</param>
        /// <param name="tr">Objekt transakcji</param>
        /// <param name="insPT"Punkt wstawienia tekstu</param>
        public static void AddVoivodeshipTextBlock(BlockTable bt, Transaction tr, Point3d insPT, BlockTableRecord btr, string[] resText) {
            string BlockName = "OpisWojewodztwaULDK";
            BlockTableRecord blockDef = bt[BlockName].GetObject(OpenMode.ForRead) as BlockTableRecord;
            BlockReference block = new BlockReference(insPT, blockDef.ObjectId);
            block.Layer = VoivodeshipLayer;
            btr.AppendEntity(block);
            tr.AddNewlyCreatedDBObject(block, true);
            foreach (ObjectId obID in blockDef) {
                DBObject obj = obID.GetObject(OpenMode.ForRead);
                AttributeDefinition attDef = obj as AttributeDefinition;
                if ((attDef != null) && (!attDef.Constant)) {
                    using (AttributeReference attRef = new AttributeReference()) {
                        attRef.SetAttributeFromBlock(attDef, block.BlockTransform);
                        switch (attRef.Tag) {
                            case "WOJEWÓDZTWO":
                                attRef.TextString = resText[0];
                                break;
                            case "TERYT":
                                attRef.TextString = resText[1];
                                break;
                        }
                        block.AttributeCollection.AppendAttribute(attRef);
                        tr.AddNewlyCreatedDBObject(attRef, true);
                    }
                }
            }
        }
    }
}
