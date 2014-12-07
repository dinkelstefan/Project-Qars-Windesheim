namespace Qars.Views
{
    partial class searchWizard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchWizardTabControl = new System.Windows.Forms.TabControl();
            this.searchTabpage1 = new System.Windows.Forms.TabPage();
            this.searchButton1 = new System.Windows.Forms.Button();
            this.sportRadioButton = new System.Windows.Forms.RadioButton();
            this.sedanRadioButton = new System.Windows.Forms.RadioButton();
            this.bedrijfswagenRadioButton = new System.Windows.Forms.RadioButton();
            this.suvRadioButton = new System.Windows.Forms.RadioButton();
            this.hatchbackRadioButton = new System.Windows.Forms.RadioButton();
            this.stationwagenRadioButton = new System.Windows.Forms.RadioButton();
            this.question1Label = new System.Windows.Forms.Label();
            this.searchTabpage2 = new System.Windows.Forms.TabPage();
            this.searchButton2 = new System.Windows.Forms.Button();
            this.handgeschakeldRadioButton = new System.Windows.Forms.RadioButton();
            this.automaatRadioButton = new System.Windows.Forms.RadioButton();
            this.question2Label = new System.Windows.Forms.Label();
            this.searchTabpage3 = new System.Windows.Forms.TabPage();
            this.searchButton3 = new System.Windows.Forms.Button();
            this.veryHighCheckBox = new System.Windows.Forms.CheckBox();
            this.highCheckBox = new System.Windows.Forms.CheckBox();
            this.mediumCheckBox = new System.Windows.Forms.CheckBox();
            this.lowCheckBox = new System.Windows.Forms.CheckBox();
            this.question3Label = new System.Windows.Forms.Label();
            this.searchTabpage4 = new System.Windows.Forms.TabPage();
            this.searchButton4 = new System.Windows.Forms.Button();
            this.leeuwardenCheckBox = new System.Windows.Forms.CheckBox();
            this.groningenCheckBox = new System.Windows.Forms.CheckBox();
            this.amsterdamCheckBox = new System.Windows.Forms.CheckBox();
            this.arnhemCheckBox = new System.Windows.Forms.CheckBox();
            this.zwolleCheckBox = new System.Windows.Forms.CheckBox();
            this.question4label = new System.Windows.Forms.Label();
            this.searchTabpage5 = new System.Windows.Forms.TabPage();
            this.searchButton5 = new System.Windows.Forms.Button();
            this.aircoCheckbox = new System.Windows.Forms.CheckBox();
            this.radioCheckBox = new System.Windows.Forms.CheckBox();
            this.navigationCheckBox = new System.Windows.Forms.CheckBox();
            this.cruisControlCheckBox = new System.Windows.Forms.CheckBox();
            this.bluetoothCheckBox = new System.Windows.Forms.CheckBox();
            this.question5Label = new System.Windows.Forms.Label();
            this.searchWizardTabControl.SuspendLayout();
            this.searchTabpage1.SuspendLayout();
            this.searchTabpage2.SuspendLayout();
            this.searchTabpage3.SuspendLayout();
            this.searchTabpage4.SuspendLayout();
            this.searchTabpage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchWizardTabControl
            // 
            this.searchWizardTabControl.Controls.Add(this.searchTabpage1);
            this.searchWizardTabControl.Controls.Add(this.searchTabpage2);
            this.searchWizardTabControl.Controls.Add(this.searchTabpage3);
            this.searchWizardTabControl.Controls.Add(this.searchTabpage4);
            this.searchWizardTabControl.Controls.Add(this.searchTabpage5);
            this.searchWizardTabControl.Location = new System.Drawing.Point(3, 3);
            this.searchWizardTabControl.Name = "searchWizardTabControl";
            this.searchWizardTabControl.SelectedIndex = 0;
            this.searchWizardTabControl.Size = new System.Drawing.Size(1559, 867);
            this.searchWizardTabControl.TabIndex = 0;
            // 
            // searchTabpage1
            // 
            this.searchTabpage1.BackColor = System.Drawing.Color.Transparent;
            this.searchTabpage1.Controls.Add(this.searchButton1);
            this.searchTabpage1.Controls.Add(this.sportRadioButton);
            this.searchTabpage1.Controls.Add(this.sedanRadioButton);
            this.searchTabpage1.Controls.Add(this.bedrijfswagenRadioButton);
            this.searchTabpage1.Controls.Add(this.suvRadioButton);
            this.searchTabpage1.Controls.Add(this.hatchbackRadioButton);
            this.searchTabpage1.Controls.Add(this.stationwagenRadioButton);
            this.searchTabpage1.Controls.Add(this.question1Label);
            this.searchTabpage1.Location = new System.Drawing.Point(4, 29);
            this.searchTabpage1.Name = "searchTabpage1";
            this.searchTabpage1.Padding = new System.Windows.Forms.Padding(3);
            this.searchTabpage1.Size = new System.Drawing.Size(1551, 834);
            this.searchTabpage1.TabIndex = 0;
            this.searchTabpage1.Text = "Vraag 1";
            // 
            // searchButton1
            // 
            this.searchButton1.Location = new System.Drawing.Point(1418, 776);
            this.searchButton1.Name = "searchButton1";
            this.searchButton1.Size = new System.Drawing.Size(104, 34);
            this.searchButton1.TabIndex = 1;
            this.searchButton1.Text = "Zoeken";
            this.searchButton1.UseVisualStyleBackColor = true;
            this.searchButton1.Click += new System.EventHandler(this.searchClick);
            // 
            // sportRadioButton
            // 
            this.sportRadioButton.AutoSize = true;
            this.sportRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.sportRadioButton.Location = new System.Drawing.Point(44, 459);
            this.sportRadioButton.Name = "sportRadioButton";
            this.sportRadioButton.Size = new System.Drawing.Size(108, 36);
            this.sportRadioButton.TabIndex = 7;
            this.sportRadioButton.Text = "Sport";
            this.sportRadioButton.UseVisualStyleBackColor = true;
            this.sportRadioButton.CheckedChanged += new System.EventHandler(this.selectCarType);
            // 
            // sedanRadioButton
            // 
            this.sedanRadioButton.AutoSize = true;
            this.sedanRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.sedanRadioButton.Location = new System.Drawing.Point(44, 396);
            this.sedanRadioButton.Name = "sedanRadioButton";
            this.sedanRadioButton.Size = new System.Drawing.Size(123, 36);
            this.sedanRadioButton.TabIndex = 6;
            this.sedanRadioButton.Text = "Sedan";
            this.sedanRadioButton.UseVisualStyleBackColor = true;
            this.sedanRadioButton.CheckedChanged += new System.EventHandler(this.selectCarType);
            // 
            // bedrijfswagenRadioButton
            // 
            this.bedrijfswagenRadioButton.AutoSize = true;
            this.bedrijfswagenRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.bedrijfswagenRadioButton.Location = new System.Drawing.Point(44, 330);
            this.bedrijfswagenRadioButton.Name = "bedrijfswagenRadioButton";
            this.bedrijfswagenRadioButton.Size = new System.Drawing.Size(220, 36);
            this.bedrijfswagenRadioButton.TabIndex = 5;
            this.bedrijfswagenRadioButton.Text = "Bedrijfswagen";
            this.bedrijfswagenRadioButton.UseVisualStyleBackColor = true;
            this.bedrijfswagenRadioButton.CheckedChanged += new System.EventHandler(this.selectCarType);
            // 
            // suvRadioButton
            // 
            this.suvRadioButton.AutoSize = true;
            this.suvRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.suvRadioButton.Location = new System.Drawing.Point(44, 269);
            this.suvRadioButton.Name = "suvRadioButton";
            this.suvRadioButton.Size = new System.Drawing.Size(98, 36);
            this.suvRadioButton.TabIndex = 4;
            this.suvRadioButton.Text = "SUV";
            this.suvRadioButton.UseVisualStyleBackColor = true;
            this.suvRadioButton.CheckedChanged += new System.EventHandler(this.selectCarType);
            // 
            // hatchbackRadioButton
            // 
            this.hatchbackRadioButton.AutoSize = true;
            this.hatchbackRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.hatchbackRadioButton.Location = new System.Drawing.Point(44, 206);
            this.hatchbackRadioButton.Name = "hatchbackRadioButton";
            this.hatchbackRadioButton.Size = new System.Drawing.Size(174, 36);
            this.hatchbackRadioButton.TabIndex = 3;
            this.hatchbackRadioButton.Text = "Hatchback";
            this.hatchbackRadioButton.UseVisualStyleBackColor = true;
            this.hatchbackRadioButton.CheckedChanged += new System.EventHandler(this.selectCarType);
            // 
            // stationwagenRadioButton
            // 
            this.stationwagenRadioButton.AutoSize = true;
            this.stationwagenRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.stationwagenRadioButton.Location = new System.Drawing.Point(44, 146);
            this.stationwagenRadioButton.Name = "stationwagenRadioButton";
            this.stationwagenRadioButton.Size = new System.Drawing.Size(214, 36);
            this.stationwagenRadioButton.TabIndex = 2;
            this.stationwagenRadioButton.Text = "Stationwagen";
            this.stationwagenRadioButton.UseVisualStyleBackColor = true;
            this.stationwagenRadioButton.CheckedChanged += new System.EventHandler(this.selectCarType);
            // 
            // question1Label
            // 
            this.question1Label.AutoSize = true;
            this.question1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.question1Label.Location = new System.Drawing.Point(36, 58);
            this.question1Label.Name = "question1Label";
            this.question1Label.Size = new System.Drawing.Size(520, 46);
            this.question1Label.TabIndex = 1;
            this.question1Label.Text = "Welk type auto wilt u huren?";
            // 
            // searchTabpage2
            // 
            this.searchTabpage2.BackColor = System.Drawing.Color.Transparent;
            this.searchTabpage2.Controls.Add(this.searchButton2);
            this.searchTabpage2.Controls.Add(this.handgeschakeldRadioButton);
            this.searchTabpage2.Controls.Add(this.automaatRadioButton);
            this.searchTabpage2.Controls.Add(this.question2Label);
            this.searchTabpage2.Location = new System.Drawing.Point(4, 29);
            this.searchTabpage2.Name = "searchTabpage2";
            this.searchTabpage2.Padding = new System.Windows.Forms.Padding(3);
            this.searchTabpage2.Size = new System.Drawing.Size(1551, 834);
            this.searchTabpage2.TabIndex = 1;
            this.searchTabpage2.Text = "Vraag 2";
            // 
            // searchButton2
            // 
            this.searchButton2.Location = new System.Drawing.Point(1420, 777);
            this.searchButton2.Name = "searchButton2";
            this.searchButton2.Size = new System.Drawing.Size(104, 34);
            this.searchButton2.TabIndex = 3;
            this.searchButton2.Text = "Zoeken";
            this.searchButton2.UseVisualStyleBackColor = true;
            this.searchButton2.Click += new System.EventHandler(this.searchClick);
            // 
            // handgeschakeldRadioButton
            // 
            this.handgeschakeldRadioButton.AutoSize = true;
            this.handgeschakeldRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.handgeschakeldRadioButton.Location = new System.Drawing.Point(44, 217);
            this.handgeschakeldRadioButton.Name = "handgeschakeldRadioButton";
            this.handgeschakeldRadioButton.Size = new System.Drawing.Size(253, 36);
            this.handgeschakeldRadioButton.TabIndex = 2;
            this.handgeschakeldRadioButton.TabStop = true;
            this.handgeschakeldRadioButton.Text = "Handgeschakeld";
            this.handgeschakeldRadioButton.UseVisualStyleBackColor = true;
            this.handgeschakeldRadioButton.CheckedChanged += new System.EventHandler(this.transissionType);
            // 
            // automaatRadioButton
            // 
            this.automaatRadioButton.AutoSize = true;
            this.automaatRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.automaatRadioButton.Location = new System.Drawing.Point(44, 153);
            this.automaatRadioButton.Name = "automaatRadioButton";
            this.automaatRadioButton.Size = new System.Drawing.Size(162, 36);
            this.automaatRadioButton.TabIndex = 1;
            this.automaatRadioButton.TabStop = true;
            this.automaatRadioButton.Text = "Automaat";
            this.automaatRadioButton.UseVisualStyleBackColor = true;
            this.automaatRadioButton.CheckedChanged += new System.EventHandler(this.transissionType);
            // 
            // question2Label
            // 
            this.question2Label.AutoSize = true;
            this.question2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.question2Label.Location = new System.Drawing.Point(36, 56);
            this.question2Label.Name = "question2Label";
            this.question2Label.Size = new System.Drawing.Size(930, 46);
            this.question2Label.TabIndex = 0;
            this.question2Label.Text = "Wilt u een automaat of een handgeschakelde auto?";
            // 
            // searchTabpage3
            // 
            this.searchTabpage3.BackColor = System.Drawing.Color.Transparent;
            this.searchTabpage3.Controls.Add(this.searchButton3);
            this.searchTabpage3.Controls.Add(this.veryHighCheckBox);
            this.searchTabpage3.Controls.Add(this.highCheckBox);
            this.searchTabpage3.Controls.Add(this.mediumCheckBox);
            this.searchTabpage3.Controls.Add(this.lowCheckBox);
            this.searchTabpage3.Controls.Add(this.question3Label);
            this.searchTabpage3.Location = new System.Drawing.Point(4, 29);
            this.searchTabpage3.Name = "searchTabpage3";
            this.searchTabpage3.Size = new System.Drawing.Size(1551, 834);
            this.searchTabpage3.TabIndex = 2;
            this.searchTabpage3.Text = "Vraag 3";
            // 
            // searchButton3
            // 
            this.searchButton3.Location = new System.Drawing.Point(1417, 777);
            this.searchButton3.Name = "searchButton3";
            this.searchButton3.Size = new System.Drawing.Size(104, 34);
            this.searchButton3.TabIndex = 6;
            this.searchButton3.Text = "Zoeken";
            this.searchButton3.UseVisualStyleBackColor = true;
            this.searchButton3.Click += new System.EventHandler(this.searchClick);
            // 
            // veryHighCheckBox
            // 
            this.veryHighCheckBox.AutoSize = true;
            this.veryHighCheckBox.Checked = true;
            this.veryHighCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.veryHighCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.veryHighCheckBox.Location = new System.Drawing.Point(48, 409);
            this.veryHighCheckBox.Name = "veryHighCheckBox";
            this.veryHighCheckBox.Size = new System.Drawing.Size(215, 36);
            this.veryHighCheckBox.TabIndex = 5;
            this.veryHighCheckBox.Tag = "200-*";
            this.veryHighCheckBox.Text = "€200 en meer";
            this.veryHighCheckBox.UseVisualStyleBackColor = true;
            // 
            // highCheckBox
            // 
            this.highCheckBox.AutoSize = true;
            this.highCheckBox.Checked = true;
            this.highCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.highCheckBox.Location = new System.Drawing.Point(48, 326);
            this.highCheckBox.Name = "highCheckBox";
            this.highCheckBox.Size = new System.Drawing.Size(192, 36);
            this.highCheckBox.TabIndex = 4;
            this.highCheckBox.Tag = "100-200";
            this.highCheckBox.Text = "€100 - €200";
            this.highCheckBox.UseVisualStyleBackColor = true;
            // 
            // mediumCheckBox
            // 
            this.mediumCheckBox.AutoSize = true;
            this.mediumCheckBox.Checked = true;
            this.mediumCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mediumCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.mediumCheckBox.Location = new System.Drawing.Point(48, 244);
            this.mediumCheckBox.Name = "mediumCheckBox";
            this.mediumCheckBox.Size = new System.Drawing.Size(176, 36);
            this.mediumCheckBox.TabIndex = 3;
            this.mediumCheckBox.Tag = "50-100";
            this.mediumCheckBox.Text = "€50 - €100";
            this.mediumCheckBox.UseVisualStyleBackColor = true;
            // 
            // lowCheckBox
            // 
            this.lowCheckBox.AutoSize = true;
            this.lowCheckBox.Checked = true;
            this.lowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lowCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lowCheckBox.Location = new System.Drawing.Point(48, 165);
            this.lowCheckBox.Name = "lowCheckBox";
            this.lowCheckBox.Size = new System.Drawing.Size(160, 36);
            this.lowCheckBox.TabIndex = 2;
            this.lowCheckBox.Tag = "15-50";
            this.lowCheckBox.Text = "€15 - €50";
            this.lowCheckBox.UseVisualStyleBackColor = true;
            // 
            // question3Label
            // 
            this.question3Label.AutoSize = true;
            this.question3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.question3Label.Location = new System.Drawing.Point(40, 55);
            this.question3Label.Name = "question3Label";
            this.question3Label.Size = new System.Drawing.Size(782, 46);
            this.question3Label.TabIndex = 1;
            this.question3Label.Text = "Uit welke prijsklasse wilt u een auto huren?";
            // 
            // searchTabpage4
            // 
            this.searchTabpage4.BackColor = System.Drawing.Color.Transparent;
            this.searchTabpage4.Controls.Add(this.searchButton4);
            this.searchTabpage4.Controls.Add(this.leeuwardenCheckBox);
            this.searchTabpage4.Controls.Add(this.groningenCheckBox);
            this.searchTabpage4.Controls.Add(this.amsterdamCheckBox);
            this.searchTabpage4.Controls.Add(this.arnhemCheckBox);
            this.searchTabpage4.Controls.Add(this.zwolleCheckBox);
            this.searchTabpage4.Controls.Add(this.question4label);
            this.searchTabpage4.Location = new System.Drawing.Point(4, 29);
            this.searchTabpage4.Name = "searchTabpage4";
            this.searchTabpage4.Size = new System.Drawing.Size(1551, 834);
            this.searchTabpage4.TabIndex = 3;
            this.searchTabpage4.Text = "Vraag 4";
            // 
            // searchButton4
            // 
            this.searchButton4.Location = new System.Drawing.Point(1411, 775);
            this.searchButton4.Name = "searchButton4";
            this.searchButton4.Size = new System.Drawing.Size(104, 34);
            this.searchButton4.TabIndex = 8;
            this.searchButton4.Text = "Zoeken";
            this.searchButton4.UseVisualStyleBackColor = true;
            this.searchButton4.Click += new System.EventHandler(this.searchClick);
            // 
            // leeuwardenCheckBox
            // 
            this.leeuwardenCheckBox.AutoSize = true;
            this.leeuwardenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.leeuwardenCheckBox.Location = new System.Drawing.Point(48, 448);
            this.leeuwardenCheckBox.Name = "leeuwardenCheckBox";
            this.leeuwardenCheckBox.Size = new System.Drawing.Size(198, 36);
            this.leeuwardenCheckBox.TabIndex = 7;
            this.leeuwardenCheckBox.Text = "Leeuwarden";
            this.leeuwardenCheckBox.UseVisualStyleBackColor = true;
            // 
            // groningenCheckBox
            // 
            this.groningenCheckBox.AutoSize = true;
            this.groningenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groningenCheckBox.Location = new System.Drawing.Point(48, 380);
            this.groningenCheckBox.Name = "groningenCheckBox";
            this.groningenCheckBox.Size = new System.Drawing.Size(175, 36);
            this.groningenCheckBox.TabIndex = 6;
            this.groningenCheckBox.Text = "Groningen";
            this.groningenCheckBox.UseVisualStyleBackColor = true;
            // 
            // amsterdamCheckBox
            // 
            this.amsterdamCheckBox.AutoSize = true;
            this.amsterdamCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.amsterdamCheckBox.Location = new System.Drawing.Point(48, 305);
            this.amsterdamCheckBox.Name = "amsterdamCheckBox";
            this.amsterdamCheckBox.Size = new System.Drawing.Size(185, 36);
            this.amsterdamCheckBox.TabIndex = 5;
            this.amsterdamCheckBox.Text = "Amsterdam";
            this.amsterdamCheckBox.UseVisualStyleBackColor = true;
            // 
            // arnhemCheckBox
            // 
            this.arnhemCheckBox.AutoSize = true;
            this.arnhemCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.arnhemCheckBox.Location = new System.Drawing.Point(48, 234);
            this.arnhemCheckBox.Name = "arnhemCheckBox";
            this.arnhemCheckBox.Size = new System.Drawing.Size(140, 36);
            this.arnhemCheckBox.TabIndex = 4;
            this.arnhemCheckBox.Text = "Arnhem";
            this.arnhemCheckBox.UseVisualStyleBackColor = true;
            // 
            // zwolleCheckBox
            // 
            this.zwolleCheckBox.AutoSize = true;
            this.zwolleCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.zwolleCheckBox.Location = new System.Drawing.Point(48, 164);
            this.zwolleCheckBox.Name = "zwolleCheckBox";
            this.zwolleCheckBox.Size = new System.Drawing.Size(124, 36);
            this.zwolleCheckBox.TabIndex = 3;
            this.zwolleCheckBox.Text = "Zwolle";
            this.zwolleCheckBox.UseVisualStyleBackColor = true;
            // 
            // question4label
            // 
            this.question4label.AutoSize = true;
            this.question4label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.question4label.Location = new System.Drawing.Point(40, 55);
            this.question4label.Name = "question4label";
            this.question4label.Size = new System.Drawing.Size(553, 46);
            this.question4label.TabIndex = 2;
            this.question4label.Text = "Waar kunt u de auto ophalen?";
            // 
            // searchTabpage5
            // 
            this.searchTabpage5.BackColor = System.Drawing.Color.Transparent;
            this.searchTabpage5.Controls.Add(this.searchButton5);
            this.searchTabpage5.Controls.Add(this.aircoCheckbox);
            this.searchTabpage5.Controls.Add(this.radioCheckBox);
            this.searchTabpage5.Controls.Add(this.navigationCheckBox);
            this.searchTabpage5.Controls.Add(this.cruisControlCheckBox);
            this.searchTabpage5.Controls.Add(this.bluetoothCheckBox);
            this.searchTabpage5.Controls.Add(this.question5Label);
            this.searchTabpage5.Location = new System.Drawing.Point(4, 29);
            this.searchTabpage5.Name = "searchTabpage5";
            this.searchTabpage5.Size = new System.Drawing.Size(1551, 834);
            this.searchTabpage5.TabIndex = 4;
            this.searchTabpage5.Text = "Vraag 5";
            // 
            // searchButton5
            // 
            this.searchButton5.Location = new System.Drawing.Point(1405, 769);
            this.searchButton5.Name = "searchButton5";
            this.searchButton5.Size = new System.Drawing.Size(104, 34);
            this.searchButton5.TabIndex = 9;
            this.searchButton5.Text = "Zoeken";
            this.searchButton5.UseVisualStyleBackColor = true;
            this.searchButton5.Click += new System.EventHandler(this.searchClick);
            // 
            // aircoCheckbox
            // 
            this.aircoCheckbox.AutoSize = true;
            this.aircoCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.aircoCheckbox.Location = new System.Drawing.Point(58, 376);
            this.aircoCheckbox.Name = "aircoCheckbox";
            this.aircoCheckbox.Size = new System.Drawing.Size(106, 36);
            this.aircoCheckbox.TabIndex = 8;
            this.aircoCheckbox.Text = "Airco";
            this.aircoCheckbox.UseVisualStyleBackColor = true;
            // 
            // radioCheckBox
            // 
            this.radioCheckBox.AutoSize = true;
            this.radioCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.radioCheckBox.Location = new System.Drawing.Point(58, 329);
            this.radioCheckBox.Name = "radioCheckBox";
            this.radioCheckBox.Size = new System.Drawing.Size(116, 36);
            this.radioCheckBox.TabIndex = 7;
            this.radioCheckBox.Text = "Radio";
            this.radioCheckBox.UseVisualStyleBackColor = true;
            // 
            // navigationCheckBox
            // 
            this.navigationCheckBox.AutoSize = true;
            this.navigationCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.navigationCheckBox.Location = new System.Drawing.Point(58, 282);
            this.navigationCheckBox.Name = "navigationCheckBox";
            this.navigationCheckBox.Size = new System.Drawing.Size(161, 36);
            this.navigationCheckBox.TabIndex = 6;
            this.navigationCheckBox.Text = "Navigatie";
            this.navigationCheckBox.UseVisualStyleBackColor = true;
            // 
            // cruisControlCheckBox
            // 
            this.cruisControlCheckBox.AutoSize = true;
            this.cruisControlCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cruisControlCheckBox.Location = new System.Drawing.Point(58, 236);
            this.cruisControlCheckBox.Name = "cruisControlCheckBox";
            this.cruisControlCheckBox.Size = new System.Drawing.Size(216, 36);
            this.cruisControlCheckBox.TabIndex = 5;
            this.cruisControlCheckBox.Text = "Cruise control";
            this.cruisControlCheckBox.UseVisualStyleBackColor = true;
            // 
            // bluetoothCheckBox
            // 
            this.bluetoothCheckBox.AutoSize = true;
            this.bluetoothCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.bluetoothCheckBox.Location = new System.Drawing.Point(58, 191);
            this.bluetoothCheckBox.Name = "bluetoothCheckBox";
            this.bluetoothCheckBox.Size = new System.Drawing.Size(163, 36);
            this.bluetoothCheckBox.TabIndex = 4;
            this.bluetoothCheckBox.Text = "Bluetooth";
            this.bluetoothCheckBox.UseVisualStyleBackColor = true;
            // 
            // question5Label
            // 
            this.question5Label.AutoSize = true;
            this.question5Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.question5Label.Location = new System.Drawing.Point(50, 87);
            this.question5Label.Name = "question5Label";
            this.question5Label.Size = new System.Drawing.Size(553, 46);
            this.question5Label.TabIndex = 3;
            this.question5Label.Text = "Waar kunt u de auto ophalen?";
            // 
            // searchWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchWizardTabControl);
            this.Name = "searchWizard";
            this.Size = new System.Drawing.Size(1565, 873);
            this.searchWizardTabControl.ResumeLayout(false);
            this.searchTabpage1.ResumeLayout(false);
            this.searchTabpage1.PerformLayout();
            this.searchTabpage2.ResumeLayout(false);
            this.searchTabpage2.PerformLayout();
            this.searchTabpage3.ResumeLayout(false);
            this.searchTabpage3.PerformLayout();
            this.searchTabpage4.ResumeLayout(false);
            this.searchTabpage4.PerformLayout();
            this.searchTabpage5.ResumeLayout(false);
            this.searchTabpage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl searchWizardTabControl;
        private System.Windows.Forms.TabPage searchTabpage1;
        private System.Windows.Forms.TabPage searchTabpage2;
        private System.Windows.Forms.Label question1Label;
        private System.Windows.Forms.RadioButton sportRadioButton;
        private System.Windows.Forms.RadioButton sedanRadioButton;
        private System.Windows.Forms.RadioButton bedrijfswagenRadioButton;
        private System.Windows.Forms.RadioButton suvRadioButton;
        private System.Windows.Forms.RadioButton hatchbackRadioButton;
        private System.Windows.Forms.RadioButton stationwagenRadioButton;
        private System.Windows.Forms.TabPage searchTabpage3;
        private System.Windows.Forms.TabPage searchTabpage4;
        private System.Windows.Forms.TabPage searchTabpage5;
        private System.Windows.Forms.RadioButton handgeschakeldRadioButton;
        private System.Windows.Forms.RadioButton automaatRadioButton;
        private System.Windows.Forms.Label question2Label;
        private System.Windows.Forms.CheckBox veryHighCheckBox;
        private System.Windows.Forms.CheckBox highCheckBox;
        private System.Windows.Forms.CheckBox mediumCheckBox;
        private System.Windows.Forms.CheckBox lowCheckBox;
        private System.Windows.Forms.Label question3Label;
        private System.Windows.Forms.Label question4label;
        private System.Windows.Forms.CheckBox zwolleCheckBox;
        private System.Windows.Forms.CheckBox leeuwardenCheckBox;
        private System.Windows.Forms.CheckBox groningenCheckBox;
        private System.Windows.Forms.CheckBox amsterdamCheckBox;
        private System.Windows.Forms.CheckBox arnhemCheckBox;
        private System.Windows.Forms.CheckBox aircoCheckbox;
        private System.Windows.Forms.CheckBox radioCheckBox;
        private System.Windows.Forms.CheckBox navigationCheckBox;
        private System.Windows.Forms.CheckBox cruisControlCheckBox;
        private System.Windows.Forms.CheckBox bluetoothCheckBox;
        private System.Windows.Forms.Label question5Label;
        private System.Windows.Forms.Button searchButton1;
        private System.Windows.Forms.Button searchButton2;
        private System.Windows.Forms.Button searchButton3;
        private System.Windows.Forms.Button searchButton4;
        private System.Windows.Forms.Button searchButton5;
    }
}
