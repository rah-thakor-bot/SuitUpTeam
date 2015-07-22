namespace PeculiarTuitionERP.Master_Module
{
    partial class frmEntityTypeMas
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
            this.btnPnl1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpEntityTypeMas = new System.Windows.Forms.GroupBox();
            this.grdMas = new System.Windows.Forms.DataGridView();
            this.grpEntityTypeMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPnl1
            // 
            this.btnPnl1.ButtonAddEnable = true;
            this.btnPnl1.ButtonAddImage = null;
            this.btnPnl1.ButtonAddText = "&Add";
            this.btnPnl1.ButtonAddVisible = true;
            this.btnPnl1.ButtonCloseEnable = true;
            this.btnPnl1.ButtonCloseImage = null;
            this.btnPnl1.ButtonCloseVisible = true;
            this.btnPnl1.ButtonDeleteEnable = true;
            this.btnPnl1.ButtonDeleteImage = null;
            this.btnPnl1.ButtonDeleteVisible = true;
            this.btnPnl1.ButtonEditEnable = true;
            this.btnPnl1.ButtonEditImage = null;
            this.btnPnl1.ButtonEditText = "&Edit";
            this.btnPnl1.ButtonEditVisible = true;
            this.btnPnl1.ButtonRefreshEnable = true;
            this.btnPnl1.ButtonRefreshImage = null;
            this.btnPnl1.ButtonRefreshVisible = true;
            this.btnPnl1.ButtonSearchEnable = true;
            this.btnPnl1.ButtonSearchImage = null;
            this.btnPnl1.ButtonSearchText = "Sea&rch";
            this.btnPnl1.ButtonSearchVisible = true;
            this.btnPnl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPnl1.Location = new System.Drawing.Point(0, 722);
            this.btnPnl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPnl1.MessageText = "";
            this.btnPnl1.Name = "btnPnl1";
            this.btnPnl1.SetColor = System.Drawing.Color.Empty;
            this.btnPnl1.SetDuration = 0;
            this.btnPnl1.SetLightColor = System.Drawing.Color.Empty;
            this.btnPnl1.Size = new System.Drawing.Size(1301, 81);
            this.btnPnl1.StartTime = new System.DateTime(((long)(0)));
            this.btnPnl1.TabIndex = 3;
            this.btnPnl1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnAddClick);
            this.btnPnl1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnEditClick);
            this.btnPnl1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnDeleteClick);
            this.btnPnl1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnSearchClick);
            this.btnPnl1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnRefreshClick);
            this.btnPnl1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnCloseClick);
            // 
            // grpEntityTypeMas
            // 
            this.grpEntityTypeMas.Controls.Add(this.grdMas);
            this.grpEntityTypeMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEntityTypeMas.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEntityTypeMas.Location = new System.Drawing.Point(0, 0);
            this.grpEntityTypeMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpEntityTypeMas.Name = "grpEntityTypeMas";
            this.grpEntityTypeMas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpEntityTypeMas.Size = new System.Drawing.Size(1301, 752);
            this.grpEntityTypeMas.TabIndex = 2;
            this.grpEntityTypeMas.TabStop = false;
            this.grpEntityTypeMas.Text = "Entity Type Master";
            // 
            // grdMas
            // 
            this.grdMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMas.Location = new System.Drawing.Point(3, 20);
            this.grdMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdMas.Name = "grdMas";
            this.grdMas.Size = new System.Drawing.Size(1295, 728);
            this.grdMas.TabIndex = 0;
            // 
            // frmEntityTypeMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 803);
            this.Controls.Add(this.btnPnl1);
            this.Controls.Add(this.grpEntityTypeMas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmEntityTypeMas";
            this.Tag = "EntityTypeMas";
            this.Text = "Entity Type Master";
            this.Load += new System.EventHandler(this.frmEntityTypeMas_Load);
            this.grpEntityTypeMas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl btnPnl1;
        private System.Windows.Forms.GroupBox grpEntityTypeMas;
        private System.Windows.Forms.DataGridView grdMas;
    }
}