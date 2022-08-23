/*
 * Autor: Damian Zacheja 
 * 
 * Okno główne rozszerzenia ULDK
 * 
 */
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCadULDK {
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class FormULDK : Form {
        private string EPSG = "2176";
        private bool _setUpVisibilityForProgresBar;

        private static FormULDK _instance;

        public bool SetUpVisibilityForProgresBar {
            get { return _setUpVisibilityForProgresBar; }
            set {
                this.Invoke(new Action(() => {
                    this.grpMultiDonwloadProgress.Visible = value;
                    this.prgBarr.Value = 0;
                    this.btnZakres.Enabled = !value;
                }));
                _setUpVisibilityForProgresBar = value;
            }
        }


        /// <summary>
        /// Instancja
        /// </summary>
        /// <returns></returns>
        public static FormULDK GetInstance() {
            if (_instance == null) 
                _instance = new FormULDK();

            return _instance;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        private FormULDK() {
            //string sFile = @"DonwloadULDK\BlokiULDK.dwg";
            string sFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            sFile = Path.Combine(sFile, "BlokiULDK.dwg");
            if (File.Exists(sFile)) {
                DrawingUtilities.InsertBlockToCurrentDrawing(sFile);
                InitializeComponent();
            } else {
                MessageBox.Show("Nie znaleziono pliku DWG. \nWczytaj plik do folderu z rozszerzeniem.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Załadowanie formularza i określenie układu wspólrzędnych w jakim jest rysunek
        /// </summary>
        private void FormULDK_Load(object sender, EventArgs e) {
            double[] coords = DrawingUtilities.GetCenterOfCurrentView();
            if (coords[0] < 1_000_000) {
                rbEPSG2180.Checked = true;
            } else if (coords[0] > 8_000_000) {
                rbEPSG2179.Checked = true;
            } else if (coords[0] > 7_000_000) {
                rbEPSG2178.Checked = true;
            } else if (coords[0] > 6_000_000) {
                rbEPSG2177.Checked = true;
            } else if (coords[0] > 5_000_000) {
                rbEPSG2176.Checked = true;
            }
        }


        /// <summary>
        /// Pobranie obiektu na podstawie wpisanego ID lub nazy obrębu
        /// </summary>
        private async void btnById_Click(object sender, EventArgs e) {
            //Wczytywanie obiektu poprzez podanie jej pełnego identyfikatora
            ObjectULDK objULDK = GetSelectionObjectType();
            if (rbnRegion.Checked)
                objULDK.Type = objULDK.Type.Replace("By", "ByNameOrId");
            else
                objULDK.Type = objULDK.Type.Replace("By", "ById");

            objULDK.EPSG = this.EPSG;
            objULDK.SearchID = this.txtByID.Text;
            lblInfo.ForeColor = Color.Black;
            System.Windows.Forms.Application.DoEvents();
            DonwloadFromULDK obj = new DonwloadFromULDK();
            try {
                await obj.InsertByParcelID(objULDK);

                if (obj.resultat) {
                    lblInfo.Text = obj.informacja;
                    lblInfo.ForeColor = Color.Green;
                } else {
                    lblInfo.Text = obj.informacja;
                    lblInfo.ForeColor = Color.Red;
                }
            } catch (Exception ex) {
                lblInfo.Text = ex.Message;
                lblInfo.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Pobranie pojedynczeho obiektu na podstawie wskazania
        /// </summary>
        /// <returns></returns>
        private async Task AddByXY() {
            ObjectULDK objULDK = GetSelectionObjectType();
            objULDK.Type = objULDK.Type.Replace("By", "ByXY");
            lblInfo.ForeColor = Color.Black;
            lblInfo.Text = "informacje...";

            //Sprawdzenie czy label zawiera współrzędne
            if (string.IsNullOrWhiteSpace(txtXCoords.Text) || string.IsNullOrWhiteSpace(txtYCoords.Text)) {
                lblInfo.Text = "Nie wskazano współrzędnych działki!";
                lblInfo.ForeColor = Color.Red;
                return;
            }

            objULDK.coordinates = txtXCoords.Text + "," + txtYCoords.Text;
            objULDK.EPSG = EPSG;
            DonwloadFromULDK obj = new DonwloadFromULDK();
            try {
                await obj.InsertByXY(objULDK);
                if (obj.resultat) {
                    lblInfo.Text = obj.informacja;
                    lblInfo.ForeColor = Color.Green;
                } else {
                    lblInfo.Text = obj.informacja;
                    lblInfo.ForeColor = Color.Red;
                }
            } catch (Exception ex) {
                lblInfo.Text = ex.Message;
                lblInfo.ForeColor = Color.Red;
            }

        }

        /// <summary>
        /// Pobieranie ciągłe obiektów
        /// </summary>
        private async void btnLoopDonwload_Click(object sender, EventArgs e) {
            lblInfo.ForeColor = Color.Black;
            lblInfo.Text = "informacje...";
            this.Hide();
            double[] cords;
            Editor edt = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            while (true) {
                cords = DrawingUtilities.GetPointCoordinates("\nWskaż kolejną działkę do pobrania:");
                if (cords[0] == 0 && cords[1] == 0)
                    break;

                txtXCoords.Text = cords[0].ToString("F2");
                txtYCoords.Text = cords[1].ToString("F2");
                System.Windows.Forms.Application.DoEvents();
                await AddByXY();
                edt.WriteMessage('\n' + lblInfo.Text);
            }
            this.Show();
        }

        /// <summary>
        /// Wskazanie punktu na rysunku
        /// </summary>
        public async void SelectPoint_Click(object sender, EventArgs e) {
            lblInfo.ForeColor = Color.Black;
            lblInfo.Text = "informacje...";
            this.Hide();
            double[] cords = DrawingUtilities.GetPointCoordinates();
            this.Show();
            txtXCoords.Text = cords[0].ToString("F2");
            txtYCoords.Text = cords[1].ToString("F2");
            System.Windows.Forms.Application.DoEvents();
            await AddByXY();
        }


        /// <summary>
        /// Pobranie informacji o wskazanym punkcie
        /// </summary>
        public async void DonwloadInformationAbioutPoint_Click(object sender, EventArgs e) {
            lblInfo.ForeColor = Color.Black;
            lblInfo.Text = "informacje...";
            txtID.Text = "";
            txtWoj.Text = "";
            txtPow.Text = "";
            txtGmi.Text = "";
            txtObr.Text = "";

            this.Hide();
            double[] cords = DrawingUtilities.GetPointCoordinates();
            try {
                this.Show();
            } catch (Exception) {
                GetInstance();
                this.Show();
            }
            System.Windows.Forms.Application.DoEvents();
            lblInfo.Text = "Wyszukiwanie informacji....";
            string wsp = Convert.ToString(cords[0]) + "," + Convert.ToString(cords[1]);
            Dictionary<string, string> info = new Dictionary<string, string>();
            try {
                btnGeoportal.Visible = false;
                await ULDKRequest.PointInfomation(wsp, EPSG, this);
                btnGeoportal.Visible = true;
                tabMenu.SelectedTab = tabMenu.TabPages[3];
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                btnGeoportal.Visible = false;
                lblInfo.Text = "Błąd podczas wyszukowania informacji!";
                lblInfo.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Pokazanie wyszukanego punktu w geoportalu
        /// </summary>
        private void btnGeoportal_Click(object sender, EventArgs e) {
            var url = @"https://mapy.geoportal.gov.pl/imap/Imgp_2.html?identifyParcel=" + txtID.Text;
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// Pobieranie działek z zaznaczonego zakresu
        /// </summary>
        private async void btnZakres_Click(object sender, EventArgs e) {
            lblInfo.ForeColor = Color.Black;
            lblInfo.Text = "informacje...";

            this.Hide();
            double[] coords = DrawingUtilities.GetRectangle();
            this.Show();
            if (coords[0] != 0) {
                DonwloadFromULDK obj = new DonwloadFromULDK();
                try {
                    await Task.Run(() => {
                        obj.InsertByRange(coords, EPSG, this);
                    });
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                if (obj.resultat) {
                    lblInfo.Text = "Pomyślnie pobrano " + obj.iloscPobranych.ToString() + " działek!";
                    lblInfo.ForeColor = Color.Green;
                } else {
                    lblInfo.Text = obj.informacja + " Pobrano : " + obj.ToString() + " działek.";
                    lblInfo.ForeColor = Color.Red;
                }
                grpMultiDonwloadProgress.Visible = false;
            }
        }


        /// <summary>
        /// Określenie angielskiej nazy na wyszukiwany obiekt
        /// </summary>
        /// <returns>Wartość parametru do wyszukiwania obiektów</returns>
        private ObjectULDK GetSelectionObjectType() {
            foreach (RadioButton rbn in grpSelectionType.Controls) {
                if (rbn.Checked) {
                    string type, p;
                    string args = "";
                    type = "Get" + rbn.Name.Replace("rbn", "") + "By";
                    switch (rbn.Name) {
                        case "rbnParcel": //Działka
                            args = "id,region,commune,county,voivodeship";
                            p = "Działka";
                            break;
                        case "rbnRegion": //Obręb 
                            args = "region,commune,county,voivodeship,teryt";
                            p = "Obręb";
                            break;

                        case "rbnCommune": //Gmina
                            args = "commune,county,voivodeship,teryt";
                            p = "Gmina";
                            break;
                        case "rbnCounty": //Powiat
                            args = "county,voivodeship,teryt";
                            p = "Powiat";
                            break;
                        case "rbnVoivodeship": //Województwo
                            args = "voivodeship,teryt";
                            p = "Województwo";
                            break;
                    }
                    p = rbn.Text;
                    return new ObjectULDK(type, args, p);
                }
            }
            return null;
        }


        /// <summary>
        /// Przypisanie prawidłowego układu współrzędnych do zmiennej
        /// </summary>
        private void OnCoordinatesChange(object sender, EventArgs e) {
            RadioButton rbn = sender as RadioButton;
            EPSG = rbn.Name.Replace("rbEPSG", "");
        }


        /// <summary>
        /// Uzupełnienie pól z informacjami o wyszukanym miejscu
        /// </summary>
        /// <param name="el">Rodzaj wyszukanego obiektu</param>
        /// <param name="v">Wyszukana nazwa</param>
        public void FillInformationAboutSelectedPoint(string el, string v) {
            switch (el) {
                case "id":
                    this.Invoke(new Action(() => txtID.Text = v));
                    break;

                case "voivodeship":
                    this.Invoke(new Action(() => txtWoj.Text = v));
                    break;

                case "county":
                    this.Invoke(new Action(() => txtPow.Text = v));
                    break;

                case "commune":
                    this.Invoke(new Action(() => txtGmi.Text = v));
                    break;

                case "region":
                    this.Invoke(new Action(() => txtObr.Text = v));
                    break;

                default:
                    this.Invoke(new Action(() => lblInfo.Text = "Uwaga! Błąd przy wpisywaniu identyfikatora rezultatów"));
                    break;
            }
        }

        /// <summary>
        /// Prosta zmiana tekstu etykiety z informacjami
        /// </summary>
        /// <param name="text">Treść informacji</param>
        public void ChangeLblInfo(string text) {
            this.Invoke(new Action(() => lblInfo.Text = text));
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// Aktualizacja informacji o pobieranym zakresie
        /// </summary>
        /// <param name="rectArea">Powierzchnia całego prostokąta</param>
        /// <param name="currentArea">Obecnie pobrana powierzchnia</param>
        /// <param name="ParcelsCount">Ilość pobranych działek</param>
        /// <param name="fragments">Ilość fragmentów</param>
        /// <param name="currentDonwloadedArea">Powierzchnia obecnego fragmentu</param>
        /// <param name="lastParecel">Ostatnio pobrana działka</param>
        public void ChangeMultilblInfo(double rectArea, double currentArea, int ParcelsCount,
             double currentDonwloadedArea, string lastParecel) {
            currentArea /= 10000;
            rectArea /= 10000;
            currentDonwloadedArea /= 10000;
            int prc = Convert.ToInt32((currentArea / rectArea) * 100);
            this.Invoke(new Action(() => {
                prgBarr.Value = prc;
                lblMultiInfo.Text = $"Pobrano {currentArea.ToString("F2")} ha z {rectArea.ToString("F2")} ha";
                lblMultiParcelCount.Text = ParcelsCount.ToString();
                lblMultiLastParcel.Text = lastParecel;
            }));
            System.Windows.Forms.Application.DoEvents();


        }
    }
}