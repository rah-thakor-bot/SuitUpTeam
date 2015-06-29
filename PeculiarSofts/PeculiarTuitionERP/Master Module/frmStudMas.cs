using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data;
using System.Collections;
using PeculiarTuitionBase;
namespace PeculiarTuitionERP
{
    #region Form Behaviour and Description
    /* Form Developer : Rahul Thakor 
     * Start Date     : 15-06-2015 11:34 PM
     * Middle Layer   : 
     * Usage          : To Insert , Update , Delete Data for Student and Teacher Detail
     */
    #endregion

    public partial class frmStudMas : MaterialForm
    {
        #region Global Objects and Variable Declaration for Form

        private readonly MaterialSkinManager materialSkinManager;
        
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string[] _strReadonly, _strHideCol, _strRequiredCol;
        
        DataTable _dtMas;
        bool _canInsert, _canDelete, _canSelect, _isSuperUser;

        TuitionBase _objData;
        #endregion

        #region Constructors

        public frmStudMas()
        {
            #region Check User Rights for the Forms

            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            #endregion
        }

        public frmStudMas(string _p_form_type)
        {
            InitializeComponent();

            _strFormType = _p_form_type;
            
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            if (_strFormType == "STUDENT")
            {
                this.Text = "Student Master";
                grpDetail.Text = "Student Master";
            }
            else // For Teachaer mas
            {
                this.Text = "Teacher Master";
                grpDetail.Text = "Teacher Master";
            }
        }

        #endregion

        #region Form Events
        
        private void frmStudMas_Load(object sender, EventArgs e)
        {

        }

        private void buttonPanelControl1_btnAddClick(object sender, EventArgs e)
        {
            if (buttonPanelControl1.ButtonAddText == "&Add")
            {
                _strBtnActionType = "ADD";

                _objData = new TuitionBase();
                string _ans = _objData.connect_Database();
                MessageBox.Show(_ans.ToString());

            }
            else
            {
                _strBtnActionType = "SAVE";
            }
        }

        private void buttonPanelControl1_btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPanelControl1_btnDeleteClick(object sender, EventArgs e)
        {
            
        }

        private void buttonPanelControl1_btnEditClick(object sender, EventArgs e)
        {
            if (buttonPanelControl1.ButtonAddText == "&Edit")
            {
                _strBtnActionType = "EDIT";
            }
            else
            {
                _strBtnActionType = "SAVE";
            }

        }

        private void buttonPanelControl1_btnRefreshClick(object sender, EventArgs e)
        {
            if (buttonPanelControl1.ButtonAddText == "Re&fresh")
            {
                _strBtnActionType = "REFRESH";
            }
            else
            {
                _strBtnActionType = string.Empty;
            }
        }

        private void buttonPanelControl1_btnSearchClick(object sender, EventArgs e)
        {
            if (buttonPanelControl1.ButtonAddText == "Sea&rch")
            {
                _strBtnActionType = "SEARCH";
            }
        }
        #endregion

        #region Private Events

        private Hashtable SaveData()
        {
            Hashtable _htSave = null;
            try
            {
                //Save Data method call to middle Layer
                return _htSave;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Nullify Object
            }
        }

        private void SearchData()
        {
            try
            {

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //Nullify Objects
            }
        }

        private void RefreshData()
        {
            try
            {

            }
            catch (Exception e)
            {

                throw e;
            }
            finally { 
                //Dispose or Nullify Objects
            }
        }

        private void DeteleData()
        {
            try
            {

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //Dispose or Nullify Objects
            }
        }

        #endregion

        #region Form Validation

        #endregion
    }

}
