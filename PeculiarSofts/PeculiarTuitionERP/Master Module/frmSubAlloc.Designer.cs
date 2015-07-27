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
            this.grpDet = new System.Windows.Forms.GroupBox();
            this.grdSubAlloc = new System.Windows.Forms.DataGridView();
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubAlloc)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDet
            // 
            this.grpDet.Controls.Add(this.grdSubAlloc);
            this.grpDet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDet.Location = new System.Drawing.Point(0, 0);
            this.grpDet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDet.Name = "grpDet";
            this.grpDet.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDet.Size = new System.Drawing.Size(1248, 629);
            this.grpDet.TabIndex = 2;
            this.grpDet.TabStop = false;
            this.grpDet.Text = "Subject  Allocation";
            // 
            // grdSubAlloc
            // 
            this.grdSubAlloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSubAlloc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSubAlloc.Location = new System.Drawing.Point(3, 22);
            this.grdSubAlloc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdSubAlloc.Name = "grdSubAlloc";
            this.grdSubAlloc.Size = new System.Drawing.Size(1242, 603);
            this.grdSubAlloc.TabIndex = 0;
            this.grdSubAlloc.Tag = "grdSubAlloc";
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 641);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1248, 106);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 8;
            // 
            // frmSubAlloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 747);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpDet);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSubAlloc";
            this.Tag = "SubjAlloc";
            this.Text = "Subject Allocation";
            this.grpDet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubAlloc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpDet;
        private System.Windows.Forms.DataGridView grdSubAlloc;
        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
    }
}