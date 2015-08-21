using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.PaymentBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Transaction_Module
{
    public partial class frmTransactionSetting : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form
        private TransactionSetting libTranSetting;
        private Utility uti;
        string _strFormType = string.Empty;
        string strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string[] strTranChkBxColName;
        string[] strTranCmbColName;

        DataTable _dtGridFields;
        DataTable _dtTranSetting;
        DataGridViewComboBoxColumn[] dgvcm_TranSetting;
        #endregion

        #region Constructor
        public frmTransactionSetting()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events

        private void frmTransactionSetting_Load(object sender, EventArgs e)
        {
            try
            {
                strBtnActionType = "LOAD";
                LoadGrid();
                UpdateControlBehaviour();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Panel Events
        private void btnMainPanel1_btnAddClick(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonAddText == "&Add")
                {
                    strBtnActionType = "ADD";
                    UpdateControlBehaviour();
                }
                else
                {
                    Hashtable ValGrid = new Hashtable();
                    ValGrid = Global.ValidateGrid(grdTrnMas, _dtGridFields);
                    if (ValGrid["RESULT"].ToString() == "true")
                    {
                        Hashtable _htResult = new Hashtable();
                        _htResult = SaveData();

                        if (_htResult["RESULT"].ToString().Trim() == "true")
                        {
                            MessageBox.Show("Saved Succesfully.");
                            getLibraryInstance("UTILITY");
                            strBtnActionType = "SAVE";
                            UpdateControlBehaviour();
                        }
                        else
                        {
                            //Global.Information(string.Format(Resources.EmptyOrNullException, "RPT_ID"), Resources.DialogText);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Some fields are required");
                        if (grdTrnMas != null && grdTrnMas.CurrentCell != null && grdTrnMas.CurrentCell.RowIndex != 0)
                        {
                            grdTrnMas.Select();
                            grdTrnMas.CurrentCell = grdTrnMas.Rows[grdTrnMas.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdTrnMas.Focus();
                        }

                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMainPanel1_btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMainPanel1_btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                grdTrnMas.Select();
                grdTrnMas.Focus();
                if (grdTrnMas.Focused && grdTrnMas.SelectedRows.Count > 0)
                {
                    strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdTrnMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdTrnMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdTrnMas.Rows.Remove(_drMasRow);
                            else
                                _drMasRow.Selected = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMainPanel1_btnEditClick(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonEditText == "&Edit")
                {
                    strBtnActionType = "EDIT";
                    UpdateControlBehaviour();

                }
                else
                {
                    strBtnActionType = "CANCEL";
                    UpdateControlBehaviour();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMainPanel1_btnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                getLibraryInstance("UTILITY");
                string criteria = uti.GetGridCriteria(grdTrnMas);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtTranSetting.Rows.Count > 0)
                {
                    strBtnActionType = "REFRESH";
                    grdTrnMas.DataSource = _dtTranSetting;
                    UpdateControlBehaviour();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMainPanel1_btnSearchClick(object sender, EventArgs e)
        {
            try
            {
                strBtnActionType = "SEARCH";
                UpdateControlBehaviour();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }
        #endregion

        #region Private Methods
        private void UpdateControlBehaviour()
        {
            getLibraryInstance("UTILITY");
            switch (strBtnActionType.ToUpper())
            {
                case "LOAD":
                    grdTrnMas.AllowUserToAddRows = false;
                    grdTrnMas.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdTrnMas.ReadOnly = false;
                    grdTrnMas.AllowUserToAddRows = true;

                    grdTrnMas.Focus();
                    grdTrnMas.CurrentCell = grdTrnMas.Rows[grdTrnMas.Rows.Count - 1].Cells["STD_ID"];
                    SetAutoIncrement();
                    break;
                case "EDIT":
                    grdTrnMas.AllowUserToAddRows = true;
                    grdTrnMas.ReadOnly = false;
                    grdTrnMas.Focus();
                    break;
                case "SAVE":
                    grdTrnMas.ReadOnly = true;
                    grdTrnMas.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtTranSetting != null)
                    {
                        _dtTranSetting.Rows.Clear();
                        _dtTranSetting.AcceptChanges();
                    }
                    grdTrnMas.AllowUserToAddRows = true;
                    grdTrnMas.CurrentCell = grdTrnMas.Rows[0].Cells["STD_ID"];
                    grdTrnMas.Rows[0].Cells["STD_ID"].Value = DBNull.Value;
                    grdTrnMas.Focus();
                    grdTrnMas.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdTrnMas.ReadOnly = true;
                    grdTrnMas.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdTrnMas.AllowUserToAddRows = true;
                    grdTrnMas.ReadOnly = true;
                    break;
                default:
                    MessageBox.Show("Form behavious is not set for following behaviuor" + strBtnActionType);
                    break;
            }
            UpdatePanelBehaviour(strBtnActionType);
        }

        private void UpdatePanelBehaviour(string ActionType)//Do not call directly
        {
            //string BehaviourType = ActionType == null ? strBtnActionType.ToUpper() : ActionType.ToUpper();
            string BehaviourType = ActionType.ToUpper();
            getLibraryInstance("UTILITY");
            switch (BehaviourType)
            {
                case "LOAD":
                    btnMainPanel1.Select();
                    uti.SetPanelStatus(btnMainPanel1, BehaviourType);
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                case "ADD":
                    uti.SetPanelStatus(btnMainPanel1, BehaviourType);
                    break;
                case "EDIT":
                    uti.SetPanelStatus(btnMainPanel1, BehaviourType);
                    break;
                case "SAVE":
                    uti.SetPanelStatus(btnMainPanel1, "LOAD");
                    btnMainPanel1.Select();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                case "SEARCH":
                    uti.SetPanelStatus(btnMainPanel1, BehaviourType);
                    break;
                case "REFRESH":
                    uti.SetPanelStatus(btnMainPanel1, BehaviourType);
                    btnMainPanel1.Select();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Edit);
                    break;
                case "CANCEL":
                    uti.SetPanelStatus(btnMainPanel1, "LOAD");
                    btnMainPanel1.Focus();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                default:
                    MessageBox.Show("Panel behaviour is not set \"{0}\" current action", strBtnActionType);
                    break;
            }
        }

        private void SetAutoIncrement()
        {
            if (strBtnActionType != "SEARCH")
            {
                _dtTranSetting.Columns["STD_ID"].AutoIncrement = true;
                _dtTranSetting.Columns["STD_ID"].AutoIncrementSeed = -1;
                _dtTranSetting.Columns["STD_ID"].AutoIncrementStep = -1;
            }
        }
        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtTranSetting = libTranSetting.FetchData(criteria, out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    throw new Exception(ErrorMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void LoadGrid()
        {
            try
            {
                getLibraryInstance();
                _dtGridFields = libTranSetting.FetchGridFields(this.Tag.ToString(), "grdTrnMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strTranChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strTranCmbColName, out dgvcm_TranSetting);
                Global.GridBindingSource(ref grdTrnMas, _dtGridFields, strTranCmbColName, dgvcm_TranSetting, strTranChkBxColName, _dtTranSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName = "PAYMENT")
        {
            if (libName.ToUpper() == "PAYMENT")
            {
                if (libTranSetting == null)
                    libTranSetting = new TransactionSetting();
            }
            else if (libName.ToUpper() == "UTILITY")
            {
                if (uti == null)
                    uti = new Utility();
            }
        }

        private Hashtable SaveData()
        {
            Hashtable _htSave = new Hashtable();
            try
            {
                getLibraryInstance();
                if (_dtTranSetting.GetChanges() != null)
                {
                    _htSave = libTranSetting.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtTranSetting, out ErrorMsg);
                    if (ErrorMsg != null) throw new Exception(ErrorMsg);
                }
                else
                {
                    _htSave.Add("RESULT", "false");
                }

                if (_htSave["RESULT"].ToString().Trim() == "false")
                {
                    if (ErrorMsg != null)
                    {
                        throw new Exception(ErrorMsg.ToString());
                    }
                }
                return _htSave;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                //Nullify Object
            }
            return null;
        }

        #endregion

        
    }
}
