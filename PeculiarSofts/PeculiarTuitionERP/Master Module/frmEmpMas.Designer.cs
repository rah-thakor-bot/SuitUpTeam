namespace PeculiarTuitionERP.Master_Module
{
    partial class frmEmpMas
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpEmpMas = new System.Windows.Forms.GroupBox();
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpSearchBox = new System.Windows.Forms.GroupBox();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.flMainData = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpEmpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.txtbxPhotoPath = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtbxPincode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbxState = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbxCity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbxAdr2 = new System.Windows.Forms.TextBox();
            this.txtbxAdr1 = new System.Windows.Forms.TextBox();
            this.txtbxPh2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbxPh1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbxMname = new System.Windows.Forms.TextBox();
            this.txtbxLname = new System.Windows.Forms.TextBox();
            this.txtbxBldGrp = new System.Windows.Forms.TextBox();
            this.txtbxFname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mtxtbxDOB = new System.Windows.Forms.MaskedTextBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.grdAdditionalDet = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpEmpType = new System.Windows.Forms.GroupBox();
            this.rdbtnOther = new System.Windows.Forms.RadioButton();
            this.rdbtnTeacher = new System.Windows.Forms.RadioButton();
            this.rdbtnStd = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpEmpMas.SuspendLayout();
            this.grpSearchBox.SuspendLayout();
            this.flMainData.SuspendLayout();
            this.tlpEmpDetails.SuspendLayout();
            this.grdAdditionalDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpEmpType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEmpMas
            // 
            this.grpEmpMas.Controls.Add(this.btnMainPanel1);
            this.grpEmpMas.Controls.Add(this.grpSearchBox);
            this.grpEmpMas.Controls.Add(this.flMainData);
            this.grpEmpMas.Controls.Add(this.grpEmpType);
            this.grpEmpMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEmpMas.Location = new System.Drawing.Point(0, 0);
            this.grpEmpMas.Margin = new System.Windows.Forms.Padding(5);
            this.grpEmpMas.Name = "grpEmpMas";
            this.grpEmpMas.Padding = new System.Windows.Forms.Padding(15, 10, 0, 0);
            this.grpEmpMas.Size = new System.Drawing.Size(1215, 795);
            this.grpEmpMas.TabIndex = 0;
            this.grpEmpMas.TabStop = false;
            this.grpEmpMas.Text = "Employee Master";
            // 
            // btnMainPanel1
            // 
            this.btnMainPanel1.ButtonAddEnable = true;
            this.btnMainPanel1.ButtonAddImage = null;
            this.btnMainPanel1.ButtonAddText = "Add";
            this.btnMainPanel1.ButtonAddVisible = true;
            this.btnMainPanel1.ButtonCloseEnable = true;
            this.btnMainPanel1.ButtonCloseImage = null;
            this.btnMainPanel1.ButtonCloseVisible = true;
            this.btnMainPanel1.ButtonDeleteEnable = true;
            this.btnMainPanel1.ButtonDeleteImage = null;
            this.btnMainPanel1.ButtonDeleteVisible = true;
            this.btnMainPanel1.ButtonEditEnable = true;
            this.btnMainPanel1.ButtonEditImage = null;
            this.btnMainPanel1.ButtonEditText = "Edit";
            this.btnMainPanel1.ButtonEditVisible = true;
            this.btnMainPanel1.ButtonRefreshEnable = true;
            this.btnMainPanel1.ButtonRefreshImage = null;
            this.btnMainPanel1.ButtonRefreshVisible = true;
            this.btnMainPanel1.ButtonSearchEnable = true;
            this.btnMainPanel1.ButtonSearchImage = null;
            this.btnMainPanel1.ButtonSearchText = "Search";
            this.btnMainPanel1.ButtonSearchVisible = true;
            this.btnMainPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMainPanel1.Location = new System.Drawing.Point(15, 713);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1200, 82);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 6;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnAdd_Click);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnSearch_Click);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel_btnCloseClick);
            // 
            // grpSearchBox
            // 
            this.grpSearchBox.Controls.Add(this.txtSearchBox);
            this.grpSearchBox.Controls.Add(this.label16);
            this.grpSearchBox.Location = new System.Drawing.Point(618, 21);
            this.grpSearchBox.Name = "grpSearchBox";
            this.grpSearchBox.Size = new System.Drawing.Size(291, 54);
            this.grpSearchBox.TabIndex = 5;
            this.grpSearchBox.TabStop = false;
            this.grpSearchBox.Text = "Search";
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Location = new System.Drawing.Point(115, 23);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(170, 25);
            this.txtSearchBox.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Person Name";
            // 
            // flMainData
            // 
            this.flMainData.Controls.Add(this.tlpEmpDetails);
            this.flMainData.Controls.Add(this.grdAdditionalDet);
            this.flMainData.Location = new System.Drawing.Point(18, 113);
            this.flMainData.Name = "flMainData";
            this.flMainData.Size = new System.Drawing.Size(1139, 592);
            this.flMainData.TabIndex = 4;
            // 
            // tlpEmpDetails
            // 
            this.tlpEmpDetails.ColumnCount = 3;
            this.tlpEmpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.94494F));
            this.tlpEmpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.05506F));
            this.tlpEmpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpEmpDetails.Controls.Add(this.txtbxPhotoPath, 1, 14);
            this.tlpEmpDetails.Controls.Add(this.label15, 0, 14);
            this.tlpEmpDetails.Controls.Add(this.txtbxEmail, 1, 13);
            this.tlpEmpDetails.Controls.Add(this.label14, 0, 13);
            this.tlpEmpDetails.Controls.Add(this.txtbxPincode, 1, 12);
            this.tlpEmpDetails.Controls.Add(this.label13, 0, 12);
            this.tlpEmpDetails.Controls.Add(this.txtbxState, 1, 11);
            this.tlpEmpDetails.Controls.Add(this.label12, 0, 11);
            this.tlpEmpDetails.Controls.Add(this.txtbxCity, 1, 10);
            this.tlpEmpDetails.Controls.Add(this.label11, 0, 10);
            this.tlpEmpDetails.Controls.Add(this.txtbxAdr2, 1, 9);
            this.tlpEmpDetails.Controls.Add(this.txtbxAdr1, 1, 8);
            this.tlpEmpDetails.Controls.Add(this.txtbxPh2, 1, 7);
            this.tlpEmpDetails.Controls.Add(this.label8, 0, 7);
            this.tlpEmpDetails.Controls.Add(this.txtbxPh1, 1, 6);
            this.tlpEmpDetails.Controls.Add(this.label7, 0, 6);
            this.tlpEmpDetails.Controls.Add(this.label6, 0, 5);
            this.tlpEmpDetails.Controls.Add(this.label1, 0, 0);
            this.tlpEmpDetails.Controls.Add(this.label2, 0, 1);
            this.tlpEmpDetails.Controls.Add(this.label3, 0, 2);
            this.tlpEmpDetails.Controls.Add(this.label4, 0, 3);
            this.tlpEmpDetails.Controls.Add(this.label5, 0, 4);
            this.tlpEmpDetails.Controls.Add(this.txtbxMname, 1, 1);
            this.tlpEmpDetails.Controls.Add(this.txtbxLname, 1, 2);
            this.tlpEmpDetails.Controls.Add(this.txtbxBldGrp, 1, 5);
            this.tlpEmpDetails.Controls.Add(this.txtbxFname, 1, 0);
            this.tlpEmpDetails.Controls.Add(this.label9, 0, 8);
            this.tlpEmpDetails.Controls.Add(this.label10, 0, 9);
            this.tlpEmpDetails.Controls.Add(this.mtxtbxDOB, 1, 3);
            this.tlpEmpDetails.Controls.Add(this.cmbSex, 1, 4);
            this.tlpEmpDetails.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpEmpDetails.Location = new System.Drawing.Point(25, 25);
            this.tlpEmpDetails.Margin = new System.Windows.Forms.Padding(25);
            this.tlpEmpDetails.Name = "tlpEmpDetails";
            this.tlpEmpDetails.Padding = new System.Windows.Forms.Padding(5);
            this.tlpEmpDetails.RowCount = 15;
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tlpEmpDetails.Size = new System.Drawing.Size(594, 510);
            this.tlpEmpDetails.TabIndex = 4;
            // 
            // txtbxPhotoPath
            // 
            this.txtbxPhotoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxPhotoPath.Location = new System.Drawing.Point(164, 470);
            this.txtbxPhotoPath.Name = "txtbxPhotoPath";
            this.txtbxPhotoPath.Size = new System.Drawing.Size(261, 25);
            this.txtbxPhotoPath.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(8, 467);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 38);
            this.label15.TabIndex = 28;
            this.label15.Text = "Photo";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxEmail.Location = new System.Drawing.Point(164, 437);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(261, 25);
            this.txtbxEmail.TabIndex = 27;
            this.txtbxEmail.Tag = "";
            this.txtbxEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(8, 434);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 33);
            this.label14.TabIndex = 26;
            this.label14.Text = "Email ID";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxPincode
            // 
            this.txtbxPincode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxPincode.Location = new System.Drawing.Point(164, 404);
            this.txtbxPincode.Name = "txtbxPincode";
            this.txtbxPincode.Size = new System.Drawing.Size(261, 25);
            this.txtbxPincode.TabIndex = 25;
            this.txtbxPincode.Tag = "REQUIRED";
            this.txtbxPincode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(8, 401);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 33);
            this.label13.TabIndex = 24;
            this.label13.Text = "Pincode";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxState
            // 
            this.txtbxState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxState.Location = new System.Drawing.Point(164, 371);
            this.txtbxState.Name = "txtbxState";
            this.txtbxState.Size = new System.Drawing.Size(261, 25);
            this.txtbxState.TabIndex = 23;
            this.txtbxState.Tag = "REQUIRED";
            this.txtbxState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(8, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 33);
            this.label12.TabIndex = 22;
            this.label12.Text = "State";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxCity
            // 
            this.txtbxCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxCity.Location = new System.Drawing.Point(164, 338);
            this.txtbxCity.Name = "txtbxCity";
            this.txtbxCity.Size = new System.Drawing.Size(261, 25);
            this.txtbxCity.TabIndex = 21;
            this.txtbxCity.Tag = "REQUIRED";
            this.txtbxCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(8, 335);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 33);
            this.label11.TabIndex = 20;
            this.label11.Text = "City";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxAdr2
            // 
            this.txtbxAdr2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxAdr2.Location = new System.Drawing.Point(164, 305);
            this.txtbxAdr2.Name = "txtbxAdr2";
            this.txtbxAdr2.Size = new System.Drawing.Size(261, 25);
            this.txtbxAdr2.TabIndex = 19;
            this.txtbxAdr2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // txtbxAdr1
            // 
            this.txtbxAdr1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxAdr1.Location = new System.Drawing.Point(164, 272);
            this.txtbxAdr1.Name = "txtbxAdr1";
            this.txtbxAdr1.Size = new System.Drawing.Size(261, 25);
            this.txtbxAdr1.TabIndex = 18;
            this.txtbxAdr1.Tag = "REQUIRED";
            this.txtbxAdr1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // txtbxPh2
            // 
            this.txtbxPh2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxPh2.Location = new System.Drawing.Point(164, 239);
            this.txtbxPh2.Name = "txtbxPh2";
            this.txtbxPh2.Size = new System.Drawing.Size(261, 25);
            this.txtbxPh2.TabIndex = 15;
            this.txtbxPh2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(8, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 33);
            this.label8.TabIndex = 14;
            this.label8.Text = "Secondary Phone";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxPh1
            // 
            this.txtbxPh1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxPh1.Location = new System.Drawing.Point(164, 206);
            this.txtbxPh1.Name = "txtbxPh1";
            this.txtbxPh1.Size = new System.Drawing.Size(261, 25);
            this.txtbxPh1.TabIndex = 13;
            this.txtbxPh1.Tag = "REQUIRED";
            this.txtbxPh1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(8, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 33);
            this.label7.TabIndex = 12;
            this.label7.Text = "Primary Phone";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(8, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 33);
            this.label6.TabIndex = 11;
            this.label6.Text = "Blood Group";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Middle Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date of Birth";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gender";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxMname
            // 
            this.txtbxMname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxMname.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbxMname.Location = new System.Drawing.Point(164, 41);
            this.txtbxMname.Name = "txtbxMname";
            this.txtbxMname.Size = new System.Drawing.Size(261, 25);
            this.txtbxMname.TabIndex = 6;
            this.txtbxMname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // txtbxLname
            // 
            this.txtbxLname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxLname.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbxLname.Location = new System.Drawing.Point(164, 74);
            this.txtbxLname.Name = "txtbxLname";
            this.txtbxLname.Size = new System.Drawing.Size(261, 25);
            this.txtbxLname.TabIndex = 7;
            this.txtbxLname.Tag = "REQUIRED";
            this.txtbxLname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // txtbxBldGrp
            // 
            this.txtbxBldGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxBldGrp.Location = new System.Drawing.Point(164, 173);
            this.txtbxBldGrp.Name = "txtbxBldGrp";
            this.txtbxBldGrp.Size = new System.Drawing.Size(261, 25);
            this.txtbxBldGrp.TabIndex = 10;
            this.txtbxBldGrp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // txtbxFname
            // 
            this.txtbxFname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxFname.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbxFname.Location = new System.Drawing.Point(164, 8);
            this.txtbxFname.Name = "txtbxFname";
            this.txtbxFname.Size = new System.Drawing.Size(261, 25);
            this.txtbxFname.TabIndex = 5;
            this.txtbxFname.Tag = "REQUIRED";
            this.txtbxFname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(8, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 33);
            this.label9.TabIndex = 16;
            this.label9.Text = "Address 1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(8, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 33);
            this.label10.TabIndex = 17;
            this.label10.Text = "Address 2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtxtbxDOB
            // 
            this.mtxtbxDOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtxtbxDOB.Location = new System.Drawing.Point(164, 107);
            this.mtxtbxDOB.Mask = "00/00/0000";
            this.mtxtbxDOB.Name = "mtxtbxDOB";
            this.mtxtbxDOB.Size = new System.Drawing.Size(261, 25);
            this.mtxtbxDOB.TabIndex = 30;
            this.mtxtbxDOB.Tag = "";
            this.mtxtbxDOB.ValidatingType = typeof(System.DateTime);
            this.mtxtbxDOB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // cmbSex
            // 
            this.cmbSex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "",
            "Male",
            "Female"});
            this.cmbSex.Location = new System.Drawing.Point(164, 140);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(261, 25);
            this.cmbSex.TabIndex = 31;
            this.cmbSex.Tag = "REQUIRED";
            this.cmbSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxFname_KeyDown);
            // 
            // grdAdditionalDet
            // 
            this.grdAdditionalDet.Controls.Add(this.dataGridView1);
            this.grdAdditionalDet.Location = new System.Drawing.Point(647, 3);
            this.grdAdditionalDet.Name = "grdAdditionalDet";
            this.grdAdditionalDet.Size = new System.Drawing.Size(473, 532);
            this.grdAdditionalDet.TabIndex = 2;
            this.grdAdditionalDet.TabStop = false;
            this.grdAdditionalDet.Text = "Additional Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(467, 508);
            this.dataGridView1.TabIndex = 0;
            // 
            // grpEmpType
            // 
            this.grpEmpType.Controls.Add(this.rdbtnOther);
            this.grpEmpType.Controls.Add(this.rdbtnTeacher);
            this.grpEmpType.Controls.Add(this.rdbtnStd);
            this.grpEmpType.Location = new System.Drawing.Point(18, 21);
            this.grpEmpType.Name = "grpEmpType";
            this.grpEmpType.Size = new System.Drawing.Size(594, 54);
            this.grpEmpType.TabIndex = 2;
            this.grpEmpType.TabStop = false;
            this.grpEmpType.Text = "Employee Type";
            // 
            // rdbtnOther
            // 
            this.rdbtnOther.AutoSize = true;
            this.rdbtnOther.Location = new System.Drawing.Point(165, 24);
            this.rdbtnOther.Name = "rdbtnOther";
            this.rdbtnOther.Size = new System.Drawing.Size(59, 21);
            this.rdbtnOther.TabIndex = 2;
            this.rdbtnOther.TabStop = true;
            this.rdbtnOther.Text = "Other";
            this.rdbtnOther.UseVisualStyleBackColor = true;
            // 
            // rdbtnTeacher
            // 
            this.rdbtnTeacher.AutoSize = true;
            this.rdbtnTeacher.Location = new System.Drawing.Point(87, 24);
            this.rdbtnTeacher.Name = "rdbtnTeacher";
            this.rdbtnTeacher.Size = new System.Drawing.Size(72, 21);
            this.rdbtnTeacher.TabIndex = 1;
            this.rdbtnTeacher.TabStop = true;
            this.rdbtnTeacher.Text = "Teacher";
            this.rdbtnTeacher.UseVisualStyleBackColor = true;
            // 
            // rdbtnStd
            // 
            this.rdbtnStd.AutoSize = true;
            this.rdbtnStd.Checked = true;
            this.rdbtnStd.Location = new System.Drawing.Point(11, 24);
            this.rdbtnStd.Name = "rdbtnStd";
            this.rdbtnStd.Size = new System.Drawing.Size(70, 21);
            this.rdbtnStd.TabIndex = 0;
            this.rdbtnStd.TabStop = true;
            this.rdbtnStd.Text = "Student";
            this.rdbtnStd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpEmpMas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1215, 795);
            this.panel1.TabIndex = 1;
            // 
            // frmEmpMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 795);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmEmpMas";
            this.Text = "frmEmpMas";
            this.Load += new System.EventHandler(this.frmEmpMas_Load);
            this.grpEmpMas.ResumeLayout(false);
            this.grpSearchBox.ResumeLayout(false);
            this.grpSearchBox.PerformLayout();
            this.flMainData.ResumeLayout(false);
            this.tlpEmpDetails.ResumeLayout(false);
            this.tlpEmpDetails.PerformLayout();
            this.grdAdditionalDet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpEmpType.ResumeLayout(false);
            this.grpEmpType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEmpMas;
        private System.Windows.Forms.TableLayoutPanel tlpEmpDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbxFname;
        private System.Windows.Forms.TextBox txtbxMname;
        private System.Windows.Forms.TextBox txtbxLname;
        private System.Windows.Forms.GroupBox grpEmpType;
        private System.Windows.Forms.RadioButton rdbtnTeacher;
        private System.Windows.Forms.RadioButton rdbtnStd;
        private System.Windows.Forms.RadioButton rdbtnOther;
        private System.Windows.Forms.TextBox txtbxBldGrp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbxPh1;
        private System.Windows.Forms.TextBox txtbxPh2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtbxAdr2;
        private System.Windows.Forms.TextBox txtbxAdr1;
        private System.Windows.Forms.TextBox txtbxPincode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtbxState;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtbxCity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtbxPhotoPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox mtxtbxDOB;
        private System.Windows.Forms.FlowLayoutPanel flMainData;
        private System.Windows.Forms.GroupBox grdAdditionalDet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.GroupBox grpSearchBox;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Label label16;
        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
    }
}