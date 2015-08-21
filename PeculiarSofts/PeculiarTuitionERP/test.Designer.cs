namespace PeculiarTuitionERP
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            this.picBOx1 = new Private.MyUserControls.PicBOx();
            this.SuspendLayout();
            // 
            // picBOx1
            // 
            this.picBOx1.ButtonAddEnable = true;
            this.picBOx1.ButtonAddImage = ((System.Drawing.Image)(resources.GetObject("picBOx1.ButtonAddImage")));
            this.picBOx1.ButtonAddText = "";
            this.picBOx1.ButtonAddVisible = true;
            this.picBOx1.ButtonCloseEnable = true;
            this.picBOx1.ButtonCloseImage = null;
            this.picBOx1.ButtonCloseVisible = true;
            this.picBOx1.ButtonDeleteEnable = true;
            this.picBOx1.ButtonDeleteImage = null;
            this.picBOx1.ButtonDeleteVisible = true;
            this.picBOx1.ButtonEditEnable = true;
            this.picBOx1.ButtonEditImage = null;
            this.picBOx1.ButtonEditText = "Edit";
            this.picBOx1.ButtonEditVisible = true;
            this.picBOx1.ButtonRefreshEnable = true;
            this.picBOx1.ButtonRefreshImage = null;
            this.picBOx1.ButtonRefreshVisible = true;
            this.picBOx1.ButtonSearchEnable = true;
            this.picBOx1.ButtonSearchImage = null;
            this.picBOx1.ButtonSearchText = "Search";
            this.picBOx1.ButtonSearchVisible = true;
            this.picBOx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBOx1.Location = new System.Drawing.Point(0, 513);
            this.picBOx1.MessageText = "";
            this.picBOx1.Name = "picBOx1";
            this.picBOx1.SetColor = System.Drawing.Color.Empty;
            this.picBOx1.SetDuration = 0;
            this.picBOx1.SetLightColor = System.Drawing.Color.Empty;
            this.picBOx1.Size = new System.Drawing.Size(1201, 71);
            this.picBOx1.StartTime = new System.DateTime(((long)(0)));
            this.picBOx1.TabIndex = 0;
            this.picBOx1.btnAddClick += new Private.MyUserControls.PicBOx.Button_Click(this.picBOx1_btnAddClick);
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 584);
            this.Controls.Add(this.picBOx1);
            this.Name = "test";
            this.Text = "test";
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.PicBOx picBOx1;
    }
}