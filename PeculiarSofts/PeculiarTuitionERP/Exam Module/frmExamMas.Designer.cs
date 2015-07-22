using System;
using System.Data;
using System.Windows.Forms;

namespace PeculiarTuitionERP.Exam_Module
{
    partial class frmExamMas : frmBaseChild
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
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpExamMas = new System.Windows.Forms.GroupBox();
            this.grdExamMas = new System.Windows.Forms.DataGridView();
            this.grpExamMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExamMas)).BeginInit();
            this.SuspendLayout();
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 681);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1295, 106);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 7;
            // 
            // grpExamMas
            // 
            this.grpExamMas.Controls.Add(this.grdExamMas);
            this.grpExamMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpExamMas.Location = new System.Drawing.Point(0, 0);
            this.grpExamMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpExamMas.Name = "grpExamMas";
            this.grpExamMas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpExamMas.Size = new System.Drawing.Size(1295, 629);
            this.grpExamMas.TabIndex = 6;
            this.grpExamMas.TabStop = false;
            this.grpExamMas.Tag = "ExamMas";
            this.grpExamMas.Text = "Exam Master";
            // 
            // grdExamMas
            // 
            this.grdExamMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExamMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExamMas.Location = new System.Drawing.Point(3, 22);
            this.grdExamMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdExamMas.Name = "grdExamMas";
            this.grdExamMas.Size = new System.Drawing.Size(1289, 603);
            this.grdExamMas.TabIndex = 0;
            // 
            // frmExamMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 787);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpExamMas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmExamMas";
            this.Text = "Exam Master";
            this.grpExamMas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExamMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private GroupBox grpExamMas;
        private DataGridView grdExamMas;
    }
}