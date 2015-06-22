namespace PeculiarTuitionERP.Master_Module
{
    partial class frmSubMas
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonPanelControl1 = new Private.MyUserControls.ButtonPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonPanelControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1034, 603);
            this.splitContainer1.SplitterDistance = 488;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 482);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subject Master";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1022, 463);
            this.dataGridView1.TabIndex = 0;
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
            this.buttonPanelControl1.Location = new System.Drawing.Point(268, 20);
            this.buttonPanelControl1.MessageText = "";
            this.buttonPanelControl1.Name = "buttonPanelControl1";
            this.buttonPanelControl1.SetColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.SetDuration = 0;
            this.buttonPanelControl1.SetLightColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.Size = new System.Drawing.Size(498, 70);
            this.buttonPanelControl1.StartTime = new System.DateTime(((long)(0)));
            this.buttonPanelControl1.TabIndex = 2;
            // 
            // frmSubMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 603);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSubMas";
            this.Text = "frmSubMas";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Private.MyUserControls.ButtonPanelControl buttonPanelControl1;
    }
}