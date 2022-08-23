/*
 * Autor Damian Zacheja
 * 
 * Klasa opdowiada za przechowywanie parametrów wyszukiwania w ULDK
 * oraz za przechowywanie rezultatów do późniejszego przetworzenia
 * 
 */
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;

namespace AutoCadULDK {

    public class ObjectULDK {
        [CommandMethod("ULDK")]
        public static void PokazOkno() {
            GC.Collect();
            FormULDK frm = FormULDK.GetInstance();
            frm.Show();
        }

        [Autodesk.AutoCAD.Runtime.CommandMethod("INFORMACJEULDK")]
        public void InformationFromCommandLine() {
            FormULDK frm = FormULDK.GetInstance();
            frm.DonwloadInformationAbioutPoint_Click(this, new EventArgs());
        }

        [Autodesk.AutoCAD.Runtime.CommandMethod("POBIERZULDK")]
        public void DonwloadFromCommandLine() {
            FormULDK frm = FormULDK.GetInstance();
            frm.SelectPoint_Click(this, new EventArgs());
        }

        public Dictionary<int, string> points; // -> Punkty obiektu
        public string resultsName; 
        public string EPSG; //-> Układ współrzędnych
        public bool errorOccured; //-> Czy wystąpił błąd podczas pobierania
        public string errorMessage; //-> Komunikat błędu pobierania
        public string coordinates; //-> współrzędne
        public string[] resultsElements; //->Zwracane elementy
        public string Type; //-> Typ pobieranych danych
        public string ResultsArgs; //->Argumenty zapytania
        public string SearchID; //->Identyfikator pobierania
        public string PolishName; //->Polska nazwa
        public ObjectULDK(string Wsp, string epsg) {
            coordinates = Wsp;
            EPSG = epsg;
        }

        public ObjectULDK() {
        }

        public ObjectULDK(string name, Dictionary<int, string> Points) {
            resultsName = name;
            points = Points;
        }

        public ObjectULDK(string type, string resArgs, string polishName) {
            Type = type;
            ResultsArgs = resArgs;
            PolishName = polishName;
        }
    }
}