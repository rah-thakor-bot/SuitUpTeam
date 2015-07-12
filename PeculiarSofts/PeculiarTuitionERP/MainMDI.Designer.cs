namespace PeculiarTuitionERP
{
    partial class MainMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMDI));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.hirenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpMas = new System.Windows.Forms.ToolStripMenuItem();
            this.materialSkinTestingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectDetailsChapterWiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectAllocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resultMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityTypeMas = new System.Windows.Forms.ToolStripMenuItem();
            this.transactoinSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiren1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiren2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.Color.DimGray;
            this.mnuMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hirenToolStripMenuItem,
            this.hiren1ToolStripMenuItem,
            this.hiren2ToolStripMenuItem,
            this.utilityToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mnuMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(7, 4, 0, 4);
            this.mnuMain.Size = new System.Drawing.Size(1157, 42);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "mnuBar";
            // 
            // hirenToolStripMenuItem
            // 
            this.hirenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmpMas,
            this.materialSkinTestingToolStripMenuItem,
            this.teacherMasterToolStripMenuItem,
            this.subjectMasterToolStripMenuItem,
            this.examMasterToolStripMenuItem,
            this.entityTypeMas,
            this.transactoinSettingToolStripMenuItem});
            this.hirenToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hirenToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2);
            this.hirenToolStripMenuItem.Name = "hirenToolStripMenuItem";
            this.hirenToolStripMenuItem.Padding = new System.Windows.Forms.Padding(3);
            this.hirenToolStripMenuItem.Size = new System.Drawing.Size(64, 30);
            this.hirenToolStripMenuItem.Text = "Master";
            // 
            // mnuEmpMas
            // 
            this.mnuEmpMas.Name = "mnuEmpMas";
            this.mnuEmpMas.Size = new System.Drawing.Size(205, 24);
            this.mnuEmpMas.Text = "Emp Master";
            this.mnuEmpMas.Click += new System.EventHandler(this.mnuEmpMas_Click);
            // 
            // materialSkinTestingToolStripMenuItem
            // 
            this.materialSkinTestingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialSkinTestingToolStripMenuItem.Name = "materialSkinTestingToolStripMenuItem";
            this.materialSkinTestingToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.materialSkinTestingToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.materialSkinTestingToolStripMenuItem.Text = "Student Master";
            this.materialSkinTestingToolStripMenuItem.Click += new System.EventHandler(this.materialSkinTestingToolStripMenuItem_Click);
            // 
            // teacherMasterToolStripMenuItem
            // 
            this.teacherMasterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherMasterToolStripMenuItem.Name = "teacherMasterToolStripMenuItem";
            this.teacherMasterToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.teacherMasterToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.teacherMasterToolStripMenuItem.Text = "Teacher Master";
            this.teacherMasterToolStripMenuItem.Click += new System.EventHandler(this.teacherMasterToolStripMenuItem_Click);
            // 
            // subjectMasterToolStripMenuItem
            // 
            this.subjectMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectMasterToolStripMenuItem1,
            this.subjectDetailsChapterWiseToolStripMenuItem,
            this.subjectAllocationToolStripMenuItem});
            this.subjectMasterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectMasterToolStripMenuItem.Name = "subjectMasterToolStripMenuItem";
            this.subjectMasterToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.subjectMasterToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.subjectMasterToolStripMenuItem.Text = "Subject Master";
            // 
            // subjectMasterToolStripMenuItem1
            // 
            this.subjectMasterToolStripMenuItem1.Name = "subjectMasterToolStripMenuItem1";
            this.subjectMasterToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(2);
            this.subjectMasterToolStripMenuItem1.Size = new System.Drawing.Size(273, 26);
            this.subjectMasterToolStripMenuItem1.Text = "Subject Master";
            this.subjectMasterToolStripMenuItem1.Click += new System.EventHandler(this.subjectMasterToolStripMenuItem1_Click);
            // 
            // subjectDetailsChapterWiseToolStripMenuItem
            // 
            this.subjectDetailsChapterWiseToolStripMenuItem.Name = "subjectDetailsChapterWiseToolStripMenuItem";
            this.subjectDetailsChapterWiseToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.subjectDetailsChapterWiseToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.subjectDetailsChapterWiseToolStripMenuItem.Text = "Subject Details Chapter Wise";
            this.subjectDetailsChapterWiseToolStripMenuItem.Click += new System.EventHandler(this.subjectDetailsChapterWiseToolStripMenuItem_Click);
            // 
            // subjectAllocationToolStripMenuItem
            // 
            this.subjectAllocationToolStripMenuItem.Name = "subjectAllocationToolStripMenuItem";
            this.subjectAllocationToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.subjectAllocationToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.subjectAllocationToolStripMenuItem.Text = "Subject Allocation";
            this.subjectAllocationToolStripMenuItem.Click += new System.EventHandler(this.subjectAllocationToolStripMenuItem_Click);
            // 
            // examMasterToolStripMenuItem
            // 
            this.examMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examMasterToolStripMenuItem1,
            this.resultMasterToolStripMenuItem});
            this.examMasterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examMasterToolStripMenuItem.Name = "examMasterToolStripMenuItem";
            this.examMasterToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.examMasterToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.examMasterToolStripMenuItem.Text = "Exam Master";
            // 
            // examMasterToolStripMenuItem1
            // 
            this.examMasterToolStripMenuItem1.Name = "examMasterToolStripMenuItem1";
            this.examMasterToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(2);
            this.examMasterToolStripMenuItem1.Size = new System.Drawing.Size(171, 26);
            this.examMasterToolStripMenuItem1.Text = "Exam Master";
            this.examMasterToolStripMenuItem1.Click += new System.EventHandler(this.examMasterToolStripMenuItem1_Click);
            // 
            // resultMasterToolStripMenuItem
            // 
            this.resultMasterToolStripMenuItem.Name = "resultMasterToolStripMenuItem";
            this.resultMasterToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.resultMasterToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.resultMasterToolStripMenuItem.Text = "Result Master";
            this.resultMasterToolStripMenuItem.Click += new System.EventHandler(this.resultMasterToolStripMenuItem_Click);
            // 
            // entityTypeMas
            // 
            this.entityTypeMas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityTypeMas.Name = "entityTypeMas";
            this.entityTypeMas.Padding = new System.Windows.Forms.Padding(3);
            this.entityTypeMas.Size = new System.Drawing.Size(211, 28);
            this.entityTypeMas.Text = "Entity Type Master";
            this.entityTypeMas.Click += new System.EventHandler(this.entityTypeMas_Click);
            // 
            // transactoinSettingToolStripMenuItem
            // 
            this.transactoinSettingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactoinSettingToolStripMenuItem.Name = "transactoinSettingToolStripMenuItem";
            this.transactoinSettingToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.transactoinSettingToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.transactoinSettingToolStripMenuItem.Text = "Transaction Setting";
            // 
            // hiren1ToolStripMenuItem
            // 
            this.hiren1ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiren1ToolStripMenuItem.Name = "hiren1ToolStripMenuItem";
            this.hiren1ToolStripMenuItem.Size = new System.Drawing.Size(97, 34);
            this.hiren1ToolStripMenuItem.Text = "Transaction";
            // 
            // hiren2ToolStripMenuItem
            // 
            this.hiren2ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiren2ToolStripMenuItem.Name = "hiren2ToolStripMenuItem";
            this.hiren2ToolStripMenuItem.Size = new System.Drawing.Size(66, 34);
            this.hiren2ToolStripMenuItem.Text = "Report";
            // 
            // utilityToolStripMenuItem
            // 
            this.utilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeThemeToolStripMenuItem});
            this.utilityToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilityToolStripMenuItem.Name = "utilityToolStripMenuItem";
            this.utilityToolStripMenuItem.Size = new System.Drawing.Size(60, 34);
            this.utilityToolStripMenuItem.Text = "Utility";
            // 
            // changeThemeToolStripMenuItem
            // 
            this.changeThemeToolStripMenuItem.Name = "changeThemeToolStripMenuItem";
            this.changeThemeToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.changeThemeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.changeThemeToolStripMenuItem.Text = "Change Theme";
            this.changeThemeToolStripMenuItem.Click += new System.EventHandler(this.changeThemeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(45, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1157, 763);
            this.Controls.Add(this.mnuMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peculiar Tuition ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMDI_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem hirenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hiren1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hiren2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialSkinTestingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teacherMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectMasterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem subjectDetailsChapterWiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectAllocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examMasterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resultMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactoinSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entityTypeMas;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpMas;
    }
}