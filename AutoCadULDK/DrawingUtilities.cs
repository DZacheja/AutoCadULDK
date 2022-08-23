/*
 * Autor Damian Zacheja
 * 
 * Klasa pomoznicza do AutoCAD, umożliwia wstawianie bloków lub pobieranie listy warstw itp.
 */
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System.Collections.Generic;

namespace AutoCadULDK {

    public static class DrawingUtilities {
        /*
         * Metoda zwraca listę warstw w otwartym pliku...
         */

        public static List<string> LayerLists() {
            //Utwórz obiekt listy do zwrócenia...
            List<string> warstwy = new List<string>();
            //Przypisz Dokument, Database i rozpocznij Transaction
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Transaction tr = db.TransactionManager.StartTransaction();
            using (tr) {
                //Pobierz listę ID Warstw...
                LayerTable lrTb = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                foreach (ObjectId Obj in lrTb) {
                    //Pobierz poszczególną warstwę...
                    LayerTableRecord lrTbRec = tr.GetObject(Obj, OpenMode.ForRead) as LayerTableRecord;
                    warstwy.Add(lrTbRec.Name);
                }
            }
            return warstwy;
        }

        internal static void AddLayer(string Layer) {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (DocumentLock dLoc = doc.LockDocument()) {
                using (Transaction tr = db.TransactionManager.StartTransaction()) {
                    LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);
                    if (!lt.Has(Layer)) {
                        LayerTableRecord ltr = new LayerTableRecord();
                        ltr.Name = Layer;
                        lt.UpgradeOpen();
                        ObjectId ltID = lt.Add(ltr);
                        tr.AddNewlyCreatedDBObject(ltr, true);
                    }
                    tr.Commit();
                }
            }
        }

        public static double[] GetPointCoordinates(string info = null) {
            double[] crd = new double[2];
            Document doc = Application.DocumentManager.MdiActiveDocument;
            using (doc.LockDocument()) {
                Editor edt = doc.Editor;
                PromptPointResult ppr;
                if (info == null) {
                    PromptPointOptions ppo = new PromptPointOptions("\nWybierz lokalizację działki:");
                    ppr = edt.GetPoint(ppo);
                } else {
                    ppr = edt.GetPoint('\n'+info);
                }
                Point3d pt3D = ppr.Value;
                if (ppr.Status == PromptStatus.Cancel) return crd;
                crd[0] = pt3D.X;
                crd[1] = pt3D.Y;
            }
            return crd;
        }

        public static double[] GetRectangle() {
            double[] crd = new double[4];
            Document doc = Application.DocumentManager.MdiActiveDocument;
            using (doc.LockDocument()) {
                Editor edt = doc.Editor;
                PromptPointResult ppr;
                PromptPointOptions ppo = new PromptPointOptions("\nWybierz pierwszy narożnik:");

                ppr = edt.GetPoint(ppo);
                Point3d pt3D = ppr.Value;
                if (ppr.Status == PromptStatus.Cancel) return crd;
                crd[0] = pt3D.X;
                crd[1] = pt3D.Y;
                ppr = edt.GetCorner("\nWybierz drugi narożnik", pt3D);
                Point3d SecPt3D = ppr.Value;
                crd[2] = SecPt3D.X;
                crd[3] = SecPt3D.Y;
            }
            return crd;
        }

        public static double[] GetCenterOfCurrentView() {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            var view = ed.GetCurrentView();
            return new double[] { view.CenterPoint.X, view.CenterPoint.Y };
        }

        public static List<string> GetLayoutsList() {
            List<string> resulits = new List<string>();
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor edt = doc.Editor;
            Database db = doc.Database;
     
            using (Transaction tr = db.TransactionManager.StartTransaction()) {
                DBDictionary layoutDic = tr.GetObject(db.LayoutDictionaryId, OpenMode.ForRead) as DBDictionary;
                foreach (DBDictionaryEntry entry in layoutDic) {
                    Layout lay = tr.GetObject(entry.Value, OpenMode.ForRead) as Layout;
                    if (lay.LayoutName == "Model") continue;
                    resulits.Add(lay.LayoutName);
                }
                tr.Commit();
            }
            return resulits;
        }

        public static void InsertBlockToCurrentDrawing(string filename) {
                //System.Windows.Forms.MessageBox.Show(filename);
                Document ThisDoc = Application.DocumentManager.MdiActiveDocument;
                DocumentCollection dm = Application.DocumentManager;
                Database thisDb = dm.MdiActiveDocument.Database;
                Database sourceDb = new Database(false, true);
            
                //Odczytywanie innego pliku DWG....
                sourceDb.ReadDwgFile(filename, System.IO.FileShare.Read, true, "");

                //Lista bloków  w pliku...
                ObjectIdCollection blocksIds = new ObjectIdCollection();
                Autodesk.AutoCAD.DatabaseServices.TransactionManager tm = sourceDb.TransactionManager;
                using (Transaction tr = tm.StartTransaction()) {
                    //Open BlockTable
                    BlockTable bt = (BlockTable)tm.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, false);
                    foreach (ObjectId obj in bt) {
                        BlockTableRecord btr = (BlockTableRecord)tm.GetObject(obj, OpenMode.ForRead, false);

                        //Wybierz tylko nazwane oraz nie-warstwy...
                        if (!btr.IsAnonymous && !btr.IsLayout) {
                            blocksIds.Add(obj);
                            btr.Dispose();
                        }
                    }
                }

                //Przepisanie znalezionych bloków do innego pliku...
                IdMapping mapping = new IdMapping();
                sourceDb.WblockCloneObjects(blocksIds, thisDb.BlockTableId, mapping, DuplicateRecordCloning.Ignore, false);
                sourceDb.Dispose();

        }

        public static List<string> GetBlockReferenceList() {
            List<string> res = new List<string>();
            Document ThisDoc = Application.DocumentManager.MdiActiveDocument;
            Database thisDb = ThisDoc.Database;

            //Lista bloków  w pliku...
            ObjectIdCollection blocksIds = new ObjectIdCollection();
            Autodesk.AutoCAD.DatabaseServices.TransactionManager tm = ThisDoc.TransactionManager;
            using (Transaction tr = tm.StartTransaction()) {
                //Open BlockTable
                BlockTable bt = (BlockTable)tm.GetObject(thisDb.BlockTableId, OpenMode.ForRead, false);
                foreach (ObjectId obj in bt) {
                    BlockTableRecord btr = (BlockTableRecord)tm.GetObject(obj, OpenMode.ForRead, false);

                    //Wybierz tylko nazwane oraz nie-warstwy...
                    if (!btr.IsAnonymous && !btr.IsLayout) {
                        res.Add(btr.Name);
                    }
                }
            }
            return res;
        }
    }
}