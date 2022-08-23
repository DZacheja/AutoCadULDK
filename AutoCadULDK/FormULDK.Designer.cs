
using System;

namespace AutoCadULDK {
    partial class FormULDK {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
            _instance = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabPage Pkt;
            this.btnLoopDonwload = new System.Windows.Forms.Button();
            this.SelectXY = new System.Windows.Forms.Button();
            this.txtYCoords = new System.Windows.Forms.TextBox();
            this.txtXCoords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSelectionType = new System.Windows.Forms.GroupBox();
            this.rbnVoivodeship = new System.Windows.Forms.RadioButton();
            this.rbnCounty = new System.Windows.Forms.RadioButton();
            this.rbnCommune = new System.Windows.Forms.RadioButton();
            this.rbnRegion = new System.Windows.Forms.RadioButton();
            this.rbnParcel = new System.Windows.Forms.RadioButton();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.ID = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.btnById = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtByID = new System.Windows.Forms.TextBox();
            this.Rng = new System.Windows.Forms.TabPage();
            this.grpMultiDonwloadProgress = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMultiLastParcel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMultiParcelCount = new System.Windows.Forms.Label();
            this.lblMultiInfo = new System.Windows.Forms.Label();
            this.prgBarr = new System.Windows.Forms.ProgressBar();
            this.btnZakres = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGeoportal = new System.Windows.Forms.Button();
            this.txtObr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGmi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWoj = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInformacjeULDK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEPSG2180 = new System.Windows.Forms.RadioButton();
            this.rbEPSG2179 = new System.Windows.Forms.RadioButton();
            this.rbEPSG2178 = new System.Windows.Forms.RadioButton();
            this.rbEPSG2177 = new System.Windows.Forms.RadioButton();
            this.rbEPSG2176 = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            Pkt = new System.Windows.Forms.TabPage();
            Pkt.SuspendLayout();
            this.grpSelectionType.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.ID.SuspendLayout();
            this.Rng.SuspendLayout();
            this.grpMultiDonwloadProgress.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pkt
            // 
            Pkt.Controls.Add(this.btnLoopDonwload);
            Pkt.Controls.Add(this.SelectXY);
            Pkt.Controls.Add(this.txtYCoords);
            Pkt.Controls.Add(this.txtXCoords);
            Pkt.Controls.Add(this.label4);
            Pkt.Controls.Add(this.label3);
            Pkt.Location = new System.Drawing.Point(4, 29);
            Pkt.Name = "Pkt";
            Pkt.Padding = new System.Windows.Forms.Padding(3);
            Pkt.Size = new System.Drawing.Size(487, 324);
            Pkt.TabIndex = 1;
            Pkt.Text = "Punkt";
            Pkt.UseVisualStyleBackColor = true;
            // 
            // btnLoopDonwload
            // 
            this.btnLoopDonwload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLoopDonwload.Location = new System.Drawing.Point(10, 170);
            this.btnLoopDonwload.Name = "btnLoopDonwload";
            this.btnLoopDonwload.Size = new System.Drawing.Size(457, 32);
            this.btnLoopDonwload.TabIndex = 7;
            this.btnLoopDonwload.Text = "Pobieranie ciągłe";
            this.btnLoopDonwload.UseVisualStyleBackColor = true;
            this.btnLoopDonwload.Click += new System.EventHandler(this.btnLoopDonwload_Click);
            // 
            // SelectXY
            // 
            this.SelectXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectXY.Location = new System.Drawing.Point(181, 88);
            this.SelectXY.Name = "SelectXY";
            this.SelectXY.Size = new System.Drawing.Size(286, 32);
            this.SelectXY.TabIndex = 4;
            this.SelectXY.Text = "Wskaż";
            this.SelectXY.UseVisualStyleBackColor = true;
            this.SelectXY.Click += new System.EventHandler(this.SelectPoint_Click);
            // 
            // txtYCoords
            // 
            this.txtYCoords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtYCoords.Location = new System.Drawing.Point(127, 48);
            this.txtYCoords.Name = "txtYCoords";
            this.txtYCoords.Size = new System.Drawing.Size(340, 24);
            this.txtYCoords.TabIndex = 3;
            // 
            // txtXCoords
            // 
            this.txtXCoords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtXCoords.Location = new System.Drawing.Point(127, 13);
            this.txtXCoords.Name = "txtXCoords";
            this.txtXCoords.Size = new System.Drawing.Size(340, 24);
            this.txtXCoords.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Współrzędna Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Współrzędna X:";
            // 
            // grpSelectionType
            // 
            this.grpSelectionType.Controls.Add(this.rbnVoivodeship);
            this.grpSelectionType.Controls.Add(this.rbnCounty);
            this.grpSelectionType.Controls.Add(this.rbnCommune);
            this.grpSelectionType.Controls.Add(this.rbnRegion);
            this.grpSelectionType.Controls.Add(this.rbnParcel);
            this.grpSelectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grpSelectionType.Location = new System.Drawing.Point(22, 131);
            this.grpSelectionType.Name = "grpSelectionType";
            this.grpSelectionType.Size = new System.Drawing.Size(490, 64);
            this.grpSelectionType.TabIndex = 6;
            this.grpSelectionType.TabStop = false;
            this.grpSelectionType.Text = "Rodzaj pobieranych danych";
            // 
            // rbnVoivodeship
            // 
            this.rbnVoivodeship.AutoSize = true;
            this.rbnVoivodeship.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbnVoivodeship.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbnVoivodeship.Location = new System.Drawing.Point(326, 23);
            this.rbnVoivodeship.Name = "rbnVoivodeship";
            this.rbnVoivodeship.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbnVoivodeship.Size = new System.Drawing.Size(131, 38);
            this.rbnVoivodeship.TabIndex = 4;
            this.rbnVoivodeship.Text = "Województwo";
            this.rbnVoivodeship.UseVisualStyleBackColor = true;
            // 
            // rbnCounty
            // 
            this.rbnCounty.AutoSize = true;
            this.rbnCounty.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbnCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbnCounty.Location = new System.Drawing.Point(245, 23);
            this.rbnCounty.Name = "rbnCounty";
            this.rbnCounty.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbnCounty.Size = new System.Drawing.Size(81, 38);
            this.rbnCounty.TabIndex = 3;
            this.rbnCounty.Text = "Powiat";
            this.rbnCounty.UseVisualStyleBackColor = true;
            // 
            // rbnCommune
            // 
            this.rbnCommune.AutoSize = true;
            this.rbnCommune.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbnCommune.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbnCommune.Location = new System.Drawing.Point(165, 23);
            this.rbnCommune.Name = "rbnCommune";
            this.rbnCommune.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbnCommune.Size = new System.Drawing.Size(80, 38);
            this.rbnCommune.TabIndex = 2;
            this.rbnCommune.Text = "Gmina";
            this.rbnCommune.UseVisualStyleBackColor = true;
            // 
            // rbnRegion
            // 
            this.rbnRegion.AutoSize = true;
            this.rbnRegion.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbnRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbnRegion.Location = new System.Drawing.Point(88, 23);
            this.rbnRegion.Name = "rbnRegion";
            this.rbnRegion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbnRegion.Size = new System.Drawing.Size(77, 38);
            this.rbnRegion.TabIndex = 1;
            this.rbnRegion.Text = "Obręb";
            this.rbnRegion.UseVisualStyleBackColor = true;
            // 
            // rbnParcel
            // 
            this.rbnParcel.AutoSize = true;
            this.rbnParcel.Checked = true;
            this.rbnParcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbnParcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbnParcel.Location = new System.Drawing.Point(3, 23);
            this.rbnParcel.Name = "rbnParcel";
            this.rbnParcel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbnParcel.Size = new System.Drawing.Size(85, 38);
            this.rbnParcel.TabIndex = 0;
            this.rbnParcel.TabStop = true;
            this.rbnParcel.Text = "Działka";
            this.rbnParcel.UseVisualStyleBackColor = true;
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.ID);
            this.tabMenu.Controls.Add(Pkt);
            this.tabMenu.Controls.Add(this.Rng);
            this.tabMenu.Controls.Add(this.tabPage1);
            this.tabMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabMenu.Location = new System.Drawing.Point(18, 215);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(495, 357);
            this.tabMenu.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.Controls.Add(this.label10);
            this.ID.Controls.Add(this.btnById);
            this.ID.Controls.Add(this.label2);
            this.ID.Controls.Add(this.txtByID);
            this.ID.Location = new System.Drawing.Point(4, 29);
            this.ID.Name = "ID";
            this.ID.Padding = new System.Windows.Forms.Padding(3);
            this.ID.Size = new System.Drawing.Size(487, 324);
            this.ID.TabIndex = 0;
            this.ID.Text = "Identyfikator";
            this.ID.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(115, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(211, 18);
            this.label10.TabIndex = 3;
            this.label10.Text = "lub nazwę w przypadku obrębu";
            // 
            // btnById
            // 
            this.btnById.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnById.Location = new System.Drawing.Point(138, 133);
            this.btnById.Name = "btnById";
            this.btnById.Size = new System.Drawing.Size(176, 33);
            this.btnById.TabIndex = 2;
            this.btnById.TabStop = false;
            this.btnById.Text = "Pobierz";
            this.btnById.Click += new System.EventHandler(this.btnById_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(76, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wpisz identyfikator poszukiwanego obiektu";
            // 
            // txtByID
            // 
            this.txtByID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtByID.Location = new System.Drawing.Point(19, 100);
            this.txtByID.Name = "txtByID";
            this.txtByID.Size = new System.Drawing.Size(448, 24);
            this.txtByID.TabIndex = 0;
            // 
            // Rng
            // 
            this.Rng.Controls.Add(this.grpMultiDonwloadProgress);
            this.Rng.Controls.Add(this.btnZakres);
            this.Rng.Location = new System.Drawing.Point(4, 29);
            this.Rng.Name = "Rng";
            this.Rng.Size = new System.Drawing.Size(487, 324);
            this.Rng.TabIndex = 2;
            this.Rng.Text = "Zakres";
            this.Rng.UseVisualStyleBackColor = true;
            // 
            // grpMultiDonwloadProgress
            // 
            this.grpMultiDonwloadProgress.Controls.Add(this.groupBox2);
            this.grpMultiDonwloadProgress.Controls.Add(this.lblMultiInfo);
            this.grpMultiDonwloadProgress.Controls.Add(this.prgBarr);
            this.grpMultiDonwloadProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grpMultiDonwloadProgress.Location = new System.Drawing.Point(3, 105);
            this.grpMultiDonwloadProgress.Name = "grpMultiDonwloadProgress";
            this.grpMultiDonwloadProgress.Size = new System.Drawing.Size(464, 200);
            this.grpMultiDonwloadProgress.TabIndex = 3;
            this.grpMultiDonwloadProgress.TabStop = false;
            this.grpMultiDonwloadProgress.Text = "Pobieranie";
            this.grpMultiDonwloadProgress.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMultiLastParcel);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblMultiParcelCount);
            this.groupBox2.Location = new System.Drawing.Point(16, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 69);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statystyki:";
            // 
            // lblMultiLastParcel
            // 
            this.lblMultiLastParcel.AutoSize = true;
            this.lblMultiLastParcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMultiLastParcel.Location = new System.Drawing.Point(200, 42);
            this.lblMultiLastParcel.Name = "lblMultiLastParcel";
            this.lblMultiLastParcel.Size = new System.Drawing.Size(14, 22);
            this.lblMultiLastParcel.TabIndex = 9;
            this.lblMultiLastParcel.Text = "0";
            this.lblMultiLastParcel.UseCompatibleTextRendering = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(7, 42);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(188, 22);
            this.label17.TabIndex = 8;
            this.label17.Text = "Ostatnio pobrana działka:";
            this.label17.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(7, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 22);
            this.label11.TabIndex = 2;
            this.label11.Text = "Pobrano działek:";
            this.label11.UseCompatibleTextRendering = true;
            // 
            // lblMultiParcelCount
            // 
            this.lblMultiParcelCount.AutoSize = true;
            this.lblMultiParcelCount.Location = new System.Drawing.Point(133, 20);
            this.lblMultiParcelCount.Name = "lblMultiParcelCount";
            this.lblMultiParcelCount.Size = new System.Drawing.Size(14, 22);
            this.lblMultiParcelCount.TabIndex = 3;
            this.lblMultiParcelCount.Text = "0";
            this.lblMultiParcelCount.UseCompatibleTextRendering = true;
            // 
            // lblMultiInfo
            // 
            this.lblMultiInfo.AutoSize = true;
            this.lblMultiInfo.Location = new System.Drawing.Point(16, 34);
            this.lblMultiInfo.Name = "lblMultiInfo";
            this.lblMultiInfo.Size = new System.Drawing.Size(43, 22);
            this.lblMultiInfo.TabIndex = 1;
            this.lblMultiInfo.Text = "info...";
            this.lblMultiInfo.UseCompatibleTextRendering = true;
            // 
            // prgBarr
            // 
            this.prgBarr.Location = new System.Drawing.Point(14, 59);
            this.prgBarr.Name = "prgBarr";
            this.prgBarr.Size = new System.Drawing.Size(415, 26);
            this.prgBarr.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBarr.TabIndex = 0;
            this.prgBarr.Value = 100;
            // 
            // btnZakres
            // 
            this.btnZakres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnZakres.Location = new System.Drawing.Point(109, 37);
            this.btnZakres.Name = "btnZakres";
            this.btnZakres.Size = new System.Drawing.Size(262, 35);
            this.btnZakres.TabIndex = 0;
            this.btnZakres.Text = "Wskaż i pobierz";
            this.btnZakres.UseVisualStyleBackColor = true;
            this.btnZakres.Click += new System.EventHandler(this.btnZakres_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGeoportal);
            this.tabPage1.Controls.Add(this.txtObr);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtGmi);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtPow);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtWoj);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnInformacjeULDK);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(487, 324);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Informacje";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGeoportal
            // 
            this.btnGeoportal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGeoportal.Location = new System.Drawing.Point(11, 283);
            this.btnGeoportal.Name = "btnGeoportal";
            this.btnGeoportal.Size = new System.Drawing.Size(115, 35);
            this.btnGeoportal.TabIndex = 16;
            this.btnGeoportal.Text = "Geoportal";
            this.toolTip1.SetToolTip(this.btnGeoportal, "Pokaż działkę w geoportalu");
            this.btnGeoportal.UseVisualStyleBackColor = true;
            this.btnGeoportal.Visible = false;
            this.btnGeoportal.Click += new System.EventHandler(this.btnGeoportal_Click);
            // 
            // txtObr
            // 
            this.txtObr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtObr.Location = new System.Drawing.Point(132, 147);
            this.txtObr.Name = "txtObr";
            this.txtObr.ReadOnly = true;
            this.txtObr.Size = new System.Drawing.Size(325, 24);
            this.txtObr.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(66, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Obręb:";
            // 
            // txtGmi
            // 
            this.txtGmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtGmi.Location = new System.Drawing.Point(132, 114);
            this.txtGmi.Name = "txtGmi";
            this.txtGmi.ReadOnly = true;
            this.txtGmi.Size = new System.Drawing.Size(325, 24);
            this.txtGmi.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(63, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Gmina:";
            // 
            // txtPow
            // 
            this.txtPow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPow.Location = new System.Drawing.Point(132, 81);
            this.txtPow.Name = "txtPow";
            this.txtPow.ReadOnly = true;
            this.txtPow.Size = new System.Drawing.Size(325, 24);
            this.txtPow.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(62, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Powiat:";
            // 
            // txtWoj
            // 
            this.txtWoj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtWoj.Location = new System.Drawing.Point(132, 48);
            this.txtWoj.Name = "txtWoj";
            this.txtWoj.ReadOnly = true;
            this.txtWoj.Size = new System.Drawing.Size(325, 24);
            this.txtWoj.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(9, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Województwo:";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtID.Location = new System.Drawing.Point(132, 10);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(325, 24);
            this.txtID.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(59, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "TERYT:";
            // 
            // btnInformacjeULDK
            // 
            this.btnInformacjeULDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnInformacjeULDK.Location = new System.Drawing.Point(132, 194);
            this.btnInformacjeULDK.Name = "btnInformacjeULDK";
            this.btnInformacjeULDK.Size = new System.Drawing.Size(311, 35);
            this.btnInformacjeULDK.TabIndex = 5;
            this.btnInformacjeULDK.Text = "Wskaż";
            this.btnInformacjeULDK.UseVisualStyleBackColor = true;
            this.btnInformacjeULDK.Click += new System.EventHandler(this.DonwloadInformationAbioutPoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pobieranie działek z ULDK";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 585);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(65, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Informacje...\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEPSG2180);
            this.groupBox1.Controls.Add(this.rbEPSG2179);
            this.groupBox1.Controls.Add(this.rbEPSG2178);
            this.groupBox1.Controls.Add(this.rbEPSG2177);
            this.groupBox1.Controls.Add(this.rbEPSG2176);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(24, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wybierz układ współrzędnych";
            // 
            // rbEPSG2180
            // 
            this.rbEPSG2180.AutoSize = true;
            this.rbEPSG2180.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbEPSG2180.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbEPSG2180.Location = new System.Drawing.Point(363, 23);
            this.rbEPSG2180.Name = "rbEPSG2180";
            this.rbEPSG2180.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbEPSG2180.Size = new System.Drawing.Size(78, 34);
            this.rbEPSG2180.TabIndex = 4;
            this.rbEPSG2180.TabStop = true;
            this.rbEPSG2180.Text = "1992";
            this.rbEPSG2180.UseVisualStyleBackColor = true;
            this.rbEPSG2180.CheckedChanged += new System.EventHandler(this.OnCoordinatesChange);
            // 
            // rbEPSG2179
            // 
            this.rbEPSG2179.AutoSize = true;
            this.rbEPSG2179.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbEPSG2179.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbEPSG2179.Location = new System.Drawing.Point(273, 23);
            this.rbEPSG2179.Name = "rbEPSG2179";
            this.rbEPSG2179.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbEPSG2179.Size = new System.Drawing.Size(90, 34);
            this.rbEPSG2179.TabIndex = 3;
            this.rbEPSG2179.TabStop = true;
            this.rbEPSG2179.Text = "2000/8";
            this.rbEPSG2179.UseVisualStyleBackColor = true;
            this.rbEPSG2179.CheckedChanged += new System.EventHandler(this.OnCoordinatesChange);
            // 
            // rbEPSG2178
            // 
            this.rbEPSG2178.AutoSize = true;
            this.rbEPSG2178.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbEPSG2178.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbEPSG2178.Location = new System.Drawing.Point(183, 23);
            this.rbEPSG2178.Name = "rbEPSG2178";
            this.rbEPSG2178.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbEPSG2178.Size = new System.Drawing.Size(90, 34);
            this.rbEPSG2178.TabIndex = 2;
            this.rbEPSG2178.TabStop = true;
            this.rbEPSG2178.Text = "2000/7";
            this.rbEPSG2178.UseVisualStyleBackColor = true;
            this.rbEPSG2178.CheckedChanged += new System.EventHandler(this.OnCoordinatesChange);
            // 
            // rbEPSG2177
            // 
            this.rbEPSG2177.AutoSize = true;
            this.rbEPSG2177.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbEPSG2177.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbEPSG2177.Location = new System.Drawing.Point(93, 23);
            this.rbEPSG2177.Name = "rbEPSG2177";
            this.rbEPSG2177.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbEPSG2177.Size = new System.Drawing.Size(90, 34);
            this.rbEPSG2177.TabIndex = 1;
            this.rbEPSG2177.TabStop = true;
            this.rbEPSG2177.Text = "2000/6";
            this.rbEPSG2177.UseVisualStyleBackColor = true;
            this.rbEPSG2177.CheckedChanged += new System.EventHandler(this.OnCoordinatesChange);
            // 
            // rbEPSG2176
            // 
            this.rbEPSG2176.AutoSize = true;
            this.rbEPSG2176.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbEPSG2176.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbEPSG2176.Location = new System.Drawing.Point(3, 23);
            this.rbEPSG2176.Name = "rbEPSG2176";
            this.rbEPSG2176.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.rbEPSG2176.Size = new System.Drawing.Size(90, 34);
            this.rbEPSG2176.TabIndex = 0;
            this.rbEPSG2176.TabStop = true;
            this.rbEPSG2176.Text = "2000/5";
            this.rbEPSG2176.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbEPSG2176.UseVisualStyleBackColor = true;
            this.rbEPSG2176.CheckedChanged += new System.EventHandler(this.OnCoordinatesChange);
            // 
            // FormULDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 607);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSelectionType);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabMenu);
            this.Name = "FormULDK";
            this.Text = "ULDK";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormULDK_Load);
            Pkt.ResumeLayout(false);
            Pkt.PerformLayout();
            this.grpSelectionType.ResumeLayout(false);
            this.grpSelectionType.PerformLayout();
            this.tabMenu.ResumeLayout(false);
            this.ID.ResumeLayout(false);
            this.ID.PerformLayout();
            this.Rng.ResumeLayout(false);
            this.grpMultiDonwloadProgress.ResumeLayout(false);
            this.grpMultiDonwloadProgress.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage ID;
        private System.Windows.Forms.Button btnById;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtByID;
        private System.Windows.Forms.TabPage Rng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SelectXY;
        private System.Windows.Forms.TextBox txtYCoords;
        private System.Windows.Forms.TextBox txtXCoords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtObr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGmi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWoj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInformacjeULDK;
        private System.Windows.Forms.Button btnZakres;
        private System.Windows.Forms.GroupBox grpMultiDonwloadProgress;
        private System.Windows.Forms.Label lblMultiInfo;
        private System.Windows.Forms.ProgressBar prgBarr;
        private System.Windows.Forms.GroupBox grpSelectionType;
        private System.Windows.Forms.RadioButton rbnVoivodeship;
        private System.Windows.Forms.RadioButton rbnCounty;
        private System.Windows.Forms.RadioButton rbnCommune;
        private System.Windows.Forms.RadioButton rbnRegion;
        private System.Windows.Forms.RadioButton rbnParcel;
        private System.Windows.Forms.RadioButton rbEPSG2180;
        private System.Windows.Forms.RadioButton rbEPSG2179;
        private System.Windows.Forms.RadioButton rbEPSG2178;
        private System.Windows.Forms.RadioButton rbEPSG2177;
        private System.Windows.Forms.RadioButton rbEPSG2176;
        private System.Windows.Forms.Button btnGeoportal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLoopDonwload;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMultiLastParcel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMultiParcelCount;
    }
}