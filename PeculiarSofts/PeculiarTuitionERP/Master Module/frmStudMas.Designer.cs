﻿namespace PeculiarTuitionERP
{
    partial class frmStudMas
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
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonPanelControl1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.dataGridView1);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetail.Location = new System.Drawing.Point(0, 0);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDetail.Size = new System.Drawing.Size(1294, 629);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Student Data";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1288, 603);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonPanelControl1
            // 
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
            this.buttonPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanelControl1.Location = new System.Drawing.Point(0, 629);
            this.buttonPanelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonPanelControl1.MessageText = "";
            this.buttonPanelControl1.Name = "buttonPanelControl1";
            this.buttonPanelControl1.SetColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.SetDuration = 0;
            this.buttonPanelControl1.SetLightColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.Size = new System.Drawing.Size(1294, 81);
            this.buttonPanelControl1.StartTime = new System.DateTime(((long)(0)));
            this.buttonPanelControl1.TabIndex = 1;
            this.buttonPanelControl1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnAddClick);
            this.buttonPanelControl1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnEditClick);
            this.buttonPanelControl1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnDeleteClick);
            this.buttonPanelControl1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnSearchClick);
            this.buttonPanelControl1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnRefreshClick);
            this.buttonPanelControl1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnCloseClick);
            // 
            // frmStudMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 713);
            this.Controls.Add(this.buttonPanelControl1);
            this.Controls.Add(this.grpDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmStudMas";
            this.Tag = "Student Master";
            this.Text = "Student Master";
            this.Load += new System.EventHandler(this.frmStudMas_Load);
            this.Resize += new System.EventHandler(this.frmStudMas_Resize);
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Private.MyUserControls.ButtonPanelControl buttonPanelControl1;



    }
}

