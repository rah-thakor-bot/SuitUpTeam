namespace PeculiarTuitionERP.Master_Module
{
    partial class frmSubAlloc
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
            this.btnPanelCtrl1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpDet = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPanelCtrl1
            // 
            this.btnPanelCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPanelCtrl1.ButtonAddEnable = true;
            this.btnPanelCtrl1.ButtonAddImage = null;
            this.btnPanelCtrl1.ButtonAddText = "Add";
            this.btnPanelCtrl1.ButtonAddVisible = true;
            this.btnPanelCtrl1.ButtonCloseEnable = true;
            this.btnPanelCtrl1.ButtonCloseImage = null;
            this.btnPanelCtrl1.ButtonCloseVisible = true;
            this.btnPanelCtrl1.ButtonDeleteEnable = true;
            this.btnPanelCtrl1.ButtonDeleteImage = null;
            this.btnPanelCtrl1.ButtonDeleteVisible = true;
            this.btnPanelCtrl1.ButtonEditEnable = true;
            this.btnPanelCtrl1.ButtonEditImage = null;
            this.btnPanelCtrl1.ButtonEditText = "Edit";
            this.btnPanelCtrl1.ButtonEditVisible = true;
            this.btnPanelCtrl1.ButtonRefreshEnable = true;
            this.btnPanelCtrl1.ButtonRefreshImage = null;
            this.btnPanelCtrl1.ButtonRefreshVisible = true;
            this.btnPanelCtrl1.ButtonSearchEnable = true;
            this.btnPanelCtrl1.ButtonSearchImage = null;
            this.btnPanelCtrl1.ButtonSearchText = "Search";
            this.btnPanelCtrl1.ButtonSearchVisible = true;
            this.btnPanelCtrl1.Location = new System.Drawing.Point(212, 604);
            this.btnPanelCtrl1.MessageText = "";
            this.btnPanelCtrl1.Name = "btnPanelCtrl1";
            this.btnPanelCtrl1.SetColor = System.Drawing.Color.Empty;
            this.btnPanelCtrl1.SetDuration = 0;
            this.btnPanelCtrl1.SetLightColor = System.Drawing.Color.Empty;
            this.btnPanelCtrl1.Size = new System.Drawing.Size(498, 62);
            this.btnPanelCtrl1.StartTime = new System.DateTime(((long)(0)));
            this.btnPanelCtrl1.TabIndex = 3;
            this.btnPanelCtrl1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnAddClick);
            this.btnPanelCtrl1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnEditClick);
            this.btnPanelCtrl1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnDeleteClick);
            this.btnPanelCtrl1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnSearchClick);
            this.btnPanelCtrl1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnRefreshClick);
            this.btnPanelCtrl1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnCloseClick);
            // 
            // grpDet
            // 
            this.grpDet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDet.Controls.Add(this.dataGridView1);
            this.grpDet.Location = new System.Drawing.Point(12, 69);
            this.grpDet.Name = "grpDet";
            this.grpDet.Size = new System.Drawing.Size(974, 481);
            this.grpDet.TabIndex = 2;
            this.grpDet.TabStop = false;
            this.grpDet.Text = "Subject  Allocation";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(968, 462);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmSubAlloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 716);
            this.Controls.Add(this.btnPanelCtrl1);
            this.Controls.Add(this.grpDet);
            this.Name = "frmSubAlloc";
            this.Text = "Subject Allocation";
            this.grpDet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl btnPanelCtrl1;
        private System.Windows.Forms.GroupBox grpDet;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}