using System.Windows.Forms;
using System.Data;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmSubjectMas : MaterialForm
    {
        #region Global Objects and Variable Declaration for Form

        private readonly MaterialSkinManager materialSkinManager;

        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string[] _strReadonly, _strHideCol, _strRequiredCol;

        DataTable _dtMas;
        bool _canInsert, _canDelete, _canSelect, _isSuperUser;
        #endregion

        public frmSubjectMas()
        {
            InitializeComponent();
        }
        public frmSubjectMas(string _p_form_type)
        {
            InitializeComponent();

            _strFormType = _p_form_type;

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            if (_strFormType == "SUBJECT")
            {
                this.Text = "Subject Master";
                grpDetail.Text = "Subject Master";
            }
            else // For Chapter Master
            {
                this.Text = "Subject wise chapter master";
                grpDetail.Text = "Subject wise chapter master";
            }
        }
    }
}
