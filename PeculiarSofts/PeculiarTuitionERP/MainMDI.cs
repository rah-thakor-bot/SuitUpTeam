using System;
using System.Windows.Forms;
using PeculiarTuitionERP.Utility_Module;
using PeculiarTuitionERP.Exam_Module;
using PeculiarTuitionERP.Master_Module;
using System.Collections;



namespace PeculiarTuitionERP
{
    public partial class MainMDI : Form
    {
        private Hashtable _ActiveFormList;

        public MainMDI()
        {
            InitializeComponent();
            _ActiveFormList = new Hashtable();
            // Initialize MaterialSkinManager
            //materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            Global.LoginBranch = "TestBranch";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materialSkinTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudMas _child = new frmStudMas("STUDENT") { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void teacherMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudMas _child = new frmStudMas("TEACHER") { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void changeThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void subjectMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSubjectMas _child = new frmSubjectMas("SUBJECT") { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void subjectDetailsChapterWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubjectMas _child = new frmSubjectMas("CHAPTER"){ MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void subjectAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubAlloc _child = new frmSubAlloc { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void examMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmExamMas _child = new frmExamMas { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void resultMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResultMas _child = new frmResultMas { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void entityTypeMas_Click(object sender, EventArgs e)
        {
            frmEntityTypeMas _child = new frmEntityTypeMas { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
            frmDashboard _child = new frmDashboard{ MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void mnuEmpMas_Click(object sender, EventArgs e)
        {
            frmEmpMas _child = new frmEmpMas { MdiParent = this, Dock = DockStyle.Fill };
            //_child.MdiParent = this;
            _child.Show();
        }

        private void mnuStudyLevelMas_Click(object sender, EventArgs e)
        {
            frmStudyLevelMas _child = new frmStudyLevelMas { MdiParent = this, Dock = DockStyle.Fill };
            _child.Show();
        }

        private void mnuBatchMaster_Click(object sender, EventArgs e)
        {
            frmBatchMaster _child = new frmBatchMaster { MdiParent = this, Dock = DockStyle.Fill };
            _child.Show();
        }
    }
}
