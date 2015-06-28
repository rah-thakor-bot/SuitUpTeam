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
            this.buttonPanelControl1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpEntityTypeMas = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpEntityTypeMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanelControl1
            // 
            this.buttonPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanelControl1.ButtonAddEnable = true;
            this.buttonPanelControl1.ButtonAddImage = null;
            this.buttonPanelControl1.ButtonAddText = "Add";
            this.buttonPanelControl1.ButtonAddVisible = true;
            this.buttonPanelControl1.ButtonCloseEnable = true;
            this.buttonPanelControl1.ButtonCloseImage = null;
            this.buttonPanelControl1.ButtonCloseVisible = true;
            this.buttonPanelControl1.ButtonDeleteEnable = true;
            this.buttonPanelControl1.ButtonDeleteImage = null;
            this.buttonPanelControl1.ButtonDeleteVisible = true;
            this.buttonPanelControl1.ButtonEditEnable = true;
            this.buttonPanelControl1.ButtonEditImage = null;
            this.buttonPanelControl1.ButtonEditText = "Edit";
            this.buttonPanelControl1.ButtonEditVisible = true;
            this.buttonPanelControl1.ButtonRefreshEnable = true;
            this.buttonPanelControl1.ButtonRefreshImage = null;
            this.buttonPanelControl1.ButtonRefreshVisible = true;
            this.buttonPanelControl1.ButtonSearchEnable = true;
            this.buttonPanelControl1.ButtonSearchImage = null;
            this.buttonPanelControl1.ButtonSearchText = "Search";
            this.buttonPanelControl1.ButtonSearchVisible = true;
            this.buttonPanelControl1.Location = new System.Drawing.Point(296, 606);
            this.buttonPanelControl1.MessageText = "";
            this.buttonPanelControl1.Name = "buttonPanelControl1";
            this.buttonPanelControl1.SetColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.SetDuration = 0;
            this.buttonPanelControl1.SetLightColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.Size = new System.Drawing.Size(498, 62);
            this.buttonPanelControl1.StartTime = new System.DateTime(((long)(0)));
            this.buttonPanelControl1.TabIndex = 3;
            // 
            // grpEntityTypeMas
            // 
            this.grpEntityTypeMas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEntityTypeMas.Controls.Add(this.dataGridView1);
            this.grpEntityTypeMas.Location = new System.Drawing.Point(96, 71);
            this.grpEntityTypeMas.Name = "grpEntityTypeMas";
            this.grpEntityTypeMas.Size = new System.Drawing.Size(974, 481);
            this.grpEntityTypeMas.TabIndex = 2;
            this.grpEntityTypeMas.TabStop = false;
            this.grpEntityTypeMas.Text = "Entity Type Master";
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
            // frmEntityMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 739);
            this.Controls.Add(this.buttonPanelControl1);
            this.Controls.Add(this.grpEntityTypeMas);
            this.Name = "frmEntityMas";
            this.Text = "Entity Master";
            this.grpEntityTypeMas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl buttonPanelControl1;
        private System.Windows.Forms.GroupBox grpEntityTypeMas;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}