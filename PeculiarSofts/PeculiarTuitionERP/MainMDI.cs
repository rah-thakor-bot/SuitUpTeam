using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PeculiarTuitionERP
{
    public partial class MainMDI : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;

        public MainMDI()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materialSkinTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudMas _child = new frmStudMas("STUDENT");
            _child.MdiParent = this;
            _child.Show();
        }

        private void teacherMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudMas _child = new frmStudMas("TEACHER");
            _child.MdiParent = this;
            _child.Show();
        }

        private void changeThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility_Module.frmChangeTheme _child = new Utility_Module.frmChangeTheme();
            _child.MdiParent = this;
            _child.Show();
        }

        private void subjectMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Master_Module.frmSubjectMas _child = new Master_Module.frmSubjectMas("SUBJECT");
            _child.MdiParent = this;
            _child.Show();
        }

        private void subjectDetailsChapterWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master_Module.frmSubjectMas _child = new Master_Module.frmSubjectMas("CHAPTER");
            _child.MdiParent = this;
            _child.Show();
        }

        private void subjectAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master_Module.frmSubAlloc _child = new Master_Module.frmSubAlloc();
            _child.MdiParent = this;
            _child.Show();
        }

        private void examMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Exam_Module.frmExamMas _child = new Exam_Module.frmExamMas();
            _child.MdiParent = this;
            _child.Show();
        }

        private void resultMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exam_Module.frmResultMas _child = new Exam_Module.frmResultMas();
            _child.MdiParent = this;
            _child.Show();
        }
    }
}
