using System;
using System.Data;
using System.Collections;
using PeculiarTuitionBase;
using MaterialSkin;
using MaterialSkin.Controls;


namespace PeculiarTuitionERP.Transaction_Module
{
    public partial class frmPaymentMaster : MaterialForm
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

        public frmPaymentMaster()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events

        private void frmPaymentMaster_Load(object sender, EventArgs e)
        {

        }

        private void buttonPanelControl1_btnAddClick(object sender, EventArgs e)
        {
            if (buttonPanelControl1.ButtonAddText == "&Add")
            {
                _strBtnActionType = "ADD";
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
            finally
            {
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
