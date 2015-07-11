using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using PeculiarTuitionBase;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;


namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmEntityTypeMas : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private EntityTypeMas _libEntityTypeMas;
        private Utility _clsUtility;

        string _strFormType = string.Empty;
        string ErrorMsg;
        string _strCurrentActionType = string.Empty;
        string[] _strReadonly, _strHideCol, _strRequiredCol;

        DataTable _dtMas;
        DataTable _dtGridFields;
        bool _canInsert, _canDelete, _canSelect, _isSuperUser;

        #endregion

        #region Constructors
        public frmEntityTypeMas()
        {
            InitializeComponent();
            _clsUtility = new Utility();
            _dtGridFields = new DataTable();
        }
        #endregion

        #region Form Events

        private void frmEntityTypeMas_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void buttonPanelControl1_btnAddClick(object sender, EventArgs e)
        {
            if (btnPnl1.ButtonAddText == "&Add")
            {
                _strCurrentActionType = "ADD";
                _clsUtility.SetPanelStatus(btnPnl1, _strCurrentActionType);
                btnPnl1.ButtonAddText = "&Save";
                btnPnl1.ButtonEditText = "&Cancel";
            }
            else
            {
                _strCurrentActionType = "SAVE";
            }
        }

        private void buttonPanelControl1_btnEditClick(object sender, EventArgs e)
        {
            if (btnPnl1.ButtonEditText == "&Edit")
            {
                _strCurrentActionType = "EDIT";
                _clsUtility.SetPanelStatus(btnPnl1, _strCurrentActionType);
                btnPnl1.ButtonAddText = "&Save";
                btnPnl1.ButtonEditText = "&Cancel";
            }
            else
            {
                _strCurrentActionType = "SAVE";
            }

        }

        private void buttonPanelControl1_btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPanelControl1_btnDeleteClick(object sender, EventArgs e)
        {

        }

        private void buttonPanelControl1_btnRefreshClick(object sender, EventArgs e)
        {
            _strCurrentActionType = "REFRESH";
        }

        private void buttonPanelControl1_btnSearchClick(object sender, EventArgs e)
        {
            _strCurrentActionType = "SEARCH";
        }
        #endregion

        #region Private Methods

        private void FillGridView()
        {
            //if (_libEntityTypeMas == null)
            //    _libEntityTypeMas = new EntityTypeMas();
            
            //_dtGridFields = _libEntityTypeMas.FetchGridFields(this.Tag.ToString(),"grdMas", out ErrorMsg);
            //if (!string.IsNullOrEmpty(ErrorMsg))
            //    MessageBox.Show(ErrorMsg);

            //_dtMas = _libEntityTypeMas.FetchData(out ErrorMsg);
            //if (!string.IsNullOrEmpty(ErrorMsg))
            //    MessageBox.Show(ErrorMsg);
            //grdMas.DataSource = _dtMas;


        }
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
