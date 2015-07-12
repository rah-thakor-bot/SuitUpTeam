using System;
using System.Windows.Forms;
using PeculiarTuitionERP.Controls;
using PeculiarTuitionERP;
using PeculiarTuitionERP.Master_Module;

namespace PeculiarTuitionERP
{
    public partial class frmDashboard : frmBaseChild
    {
        private readonly MaterialSkinManager materialSkinManager;
        
        public frmDashboard()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.Dock = DockStyle.Fill;
        }

        private void btnNewAdmission_Click(object sender, EventArgs e)
        {
            
        }
    }
}
