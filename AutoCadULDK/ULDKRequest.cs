/* 
 * Autor Damian Zacheja
 * Klasa odpowiada za wykonanie zapytania do serwera ULDK
 */

using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AutoCadULDK {

    public static class ULDKRequest {

        /// <summary>
        /// Pobierz informacje o wskazanym punkcie
        /// </summary>
        /// <param name="wsp">Położenie X,Y jako tekst</param>
        /// <param name="EPSG">Kod strefy</param>
        /// <param name="frm">Obiekt formularza do zapisania danych</param>
        /// <returns>Uzupełnia informacje o wskazanym punkcie</returns>
        public static async Task PointInfomation(string wsp, string EPSG, FormULDK frm) {
            // Create a request for the URL.
            string zapytanie = "https://uldk.gugik.gov.pl/?request=GetParcelByXY&xy=";
            zapytanie += wsp + "," + EPSG + "&srid=" + EPSG;
            zapytanie += "&result=id,voivodeship,county,commune,region";
            string reqs = ULDKRequest.ReqResults(zapytanie);
            string[] resultsArray = reqs.Split('\n');

            string[] elements = resultsArray[1].Split('|');
            if (elements.Length != 5) {
                throw new System.Exception("Nieprawidołowa ilośc infomacji");
            }
            frm.FillInformationAboutSelectedPoint("id", elements[0]);
            frm.FillInformationAboutSelectedPoint("voivodeship", elements[1]);
            frm.FillInformationAboutSelectedPoint("county", elements[2]);
            frm.FillInformationAboutSelectedPoint("commune", elements[3]);
            frm.FillInformationAboutSelectedPoint("region", elements[4]);
            frm.ChangeLblInfo("Wyszukano pomyślnie");

        }

        /// <summary>
        /// Utwórz zapytanie o obiekt na podstawie współrzędnych punktu
        /// </summary>
        /// <param name="objUL"></param>
        public static void ByXY(ObjectULDK objUL) {
            ///Tablica współrzednych
            Dictionary<int, string> res = new Dictionary<int, string>();

            // Create a request for the URL.
            string zapytanie = "";
            if (!string.IsNullOrEmpty(objUL.Type))
                zapytanie = $"https://uldk.gugik.gov.pl/?request={objUL.Type}&xy=";
            else
                zapytanie = "https://uldk.gugik.gov.pl/?request=GetParcelByXY&xy=";

            zapytanie += objUL.coordinates + "," + objUL.EPSG + "&srid=" + objUL.EPSG;
            zapytanie += "&result=geom_wkb";

            if (!string.IsNullOrEmpty(objUL.Type))
                zapytanie += $",{objUL.ResultsArgs}";
            else
                zapytanie += ",id";

            string responseFromServer = ULDKRequest.ReqResults(zapytanie);
            //Get object name
            string[] Elements = responseFromServer.Split('\n');
            Elements = Elements[1].Split('|');
            List<string> resText = new List<string>();
            for (int i = 1; i < Elements.Length; i++) {
                resText.Add(Elements[i]);
            }
            objUL.resultsElements = resText.ToArray();
            objUL.resultsName = Elements[1];
            objUL.points = GetGeometry(responseFromServer);
        }

        /// <summary>
        /// Utwórz zapytanie na podstawie identyfikatora TERYT
        /// </summary>
        /// <param name="objULDK">Zapisane informacje o wyszukiwaniu</param>
        public static void ByIdentifier(ObjectULDK objULDK) {
            ///Tablica współrzednych
            Dictionary<int, string> res = new Dictionary<int, string>();
            // Create a request for the URL.
            string zapytanie = "https://uldk.gugik.gov.pl/?request=";
            zapytanie += $"{objULDK.Type}&id={objULDK.SearchID}&srid={objULDK.EPSG}";
            zapytanie += $"&result=geom_wkb,{objULDK.ResultsArgs}";

            string responseFromServer = ULDKRequest.ReqResults(zapytanie);
            string[] Elements = responseFromServer.Split('\n');
            Elements = Elements[1].Split('|');

            List<string> resText = new List<string>();
            for (int i = 1; i < Elements.Length; i++) {
                resText.Add(Elements[i]);
            }
            objULDK.resultsElements = resText.ToArray();
            objULDK.resultsName = Elements[1];
            objULDK.points = GetGeometry(responseFromServer);
        }

        private static Dictionary<int, string> GetGeometry(string resp) {
            //Zapisanie współrzędnych punktu oraz numeru działki do kontenera...
            Dictionary<int, string> res = new Dictionary<int, string>();

            //Za pomocą NetTopologySuite odczytaj współrzędne punktów granicznych
            GeometryFactory factory = GeometryFactory.Default;
            WKBReader wkb = new WKBReader();
            string[] ArResponse = resp.Split('\n');
            string[] Elements = ArResponse[1].Split('|');
            byte[] byteResponse;
            if (Elements.Length > 1) {
                byteResponse = WKBReader.HexToBytes(Elements[0]);
            } else {
                byteResponse = WKBReader.HexToBytes(ArResponse[1]);
            }
            Geometry geometry = wkb.Read(byteResponse);
            int i = 0;

            foreach (var cord in geometry.Coordinates) {
                res.Add(i, cord.X.ToString("F2") + ";" + cord.Y.ToString("F2"));
                i++;
            }
            res.Add(-2, geometry.PointOnSurface.X.ToString("F2") + ";" + geometry.PointOnSurface.Y.ToString("F2"));

            return res;
        }

        /// <summary>
        /// Wykonaj zapytanie do serwera WWW ULDK
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ReqResults(string req) {
            string wynik = "";
            WebRequest request = WebRequest.Create(req);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Check the status.
            if (response.StatusDescription == "OK") {
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                wynik = reader.ReadToEnd();

                //Sprawdzenie czy uzyskano prawidłowe dane...
                string[] resultaty = wynik.Split('\n');
                if (resultaty[0] == "-1 brak wyników") {
                    throw new Exception("Nie odnaleziono wyników!");
                }
                reader.Close();
                dataStream.Close();
                return wynik;
                response.Close();
            }
            //Nie uzyskano prawidłowej odpowiedzi z serwera...
            else {
                throw new Exception("Nie uzyskano prawidłowej odpowiedzi z serwera");
            }
            throw new Exception("Wystąpił nieznany błąd!");
        }
    }
}