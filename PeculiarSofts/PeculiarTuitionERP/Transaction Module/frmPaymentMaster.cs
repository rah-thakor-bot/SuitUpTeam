using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.PaymentBase;
using PeculiarTuitionERP.Utility_Module;


namespace PeculiarTuitionERP.Transaction_Module
{
    public partial class frmPaymentMaster : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form
        private PaymentMas libPaymentMas;
        private Utility uti;
        string _strFormType = string.Empty;
        string strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string[] strPayMasChkBxColName;
        string[] strPayMasCmbColName;

        DataTable _dtGridFields;
        DataTable _dtPaymentMas;
        DataGridViewComboBoxColumn[] dgvcm_PaymentMas;
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
                    ValGrid = Global.ValidateGrid(grdPaymentMas, _dtGridFields);
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
                            //Unsuccessful attempt to save
                        }
                    }

                    else
                    {
                        MessageBox.Show("Some fields are required");
                        if (grdPaymentMas != null && grdPaymentMas.CurrentCell != null && grdPaymentMas.CurrentCell.RowIndex != 0)
                        {
                            grdPaymentMas.Select();
                            grdPaymentMas.CurrentCell = grdPaymentMas.Rows[grdPaymentMas.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdPaymentMas.Focus();
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
                grdPaymentMas.Select();
                grdPaymentMas.Focus();
                if (grdPaymentMas.Focused && grdPaymentMas.SelectedRows.Count > 0)
                {
                    strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdPaymentMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdPaymentMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdPaymentMas.Rows.Remove(_drMasRow);
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
                string criteria = uti.GetGridCriteria(grdPaymentMas);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtPaymentMas.Rows.Count > 0)
                {
                    strBtnActionType = "REFRESH";
                    grdPaymentMas.DataSource = _dtPaymentMas;
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
                    grdPaymentMas.AllowUserToAddRows = false;
                    grdPaymentMas.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdPaymentMas.ReadOnly = false;
                    grdPaymentMas.AllowUserToAddRows = true;
                    SetAutoIncrement();
                    grdPaymentMas.Focus();
                    grdPaymentMas.CurrentCell = grdPaymentMas.Rows[grdPaymentMas.Rows.Count - 1].Cells["TRN_ID"];
                    break;
                case "EDIT":
                    grdPaymentMas.AllowUserToAddRows = true;
                    grdPaymentMas.ReadOnly = false;
                    SetAutoIncrement();
                    grdPaymentMas.Focus();
                    break;
                case "SAVE":
                    grdPaymentMas.ReadOnly = true;
                    grdPaymentMas.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtPaymentMas != null)
                    {
                        _dtPaymentMas.Rows.Clear();
                        _dtPaymentMas.AcceptChanges();
                    }
                    grdPaymentMas.AllowUserToAddRows = true;
                    grdPaymentMas.CurrentCell = grdPaymentMas.Rows[0].Cells["TRN_ID"];
                    grdPaymentMas.Rows[0].Cells["TRN_ID"].Value = DBNull.Value;
                    grdPaymentMas.Focus();
                    grdPaymentMas.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdPaymentMas.ReadOnly = true;
                    grdPaymentMas.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdPaymentMas.AllowUserToAddRows = true;
                    grdPaymentMas.ReadOnly = true;
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
                _dtPaymentMas.Columns["TRN_ID"].AutoIncrement = true;
                _dtPaymentMas.Columns["TRN_ID"].AutoIncrementSeed = -1;
                _dtPaymentMas.Columns["TRN_ID"].AutoIncrementStep = -1;
            }
        }
        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtPaymentMas = libPaymentMas.FetchData(criteria, out ErrorMsg);
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
                _dtGridFields = libPaymentMas.FetchGridFields(this.Tag.ToString(), "grdPaymentMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strPayMasChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strPayMasCmbColName, out dgvcm_PaymentMas);
                Global.GridBindingSource(ref grdPaymentMas, _dtGridFields, strPayMasCmbColName, dgvcm_PaymentMas, strPayMasChkBxColName, _dtPaymentMas);
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
                if (libPaymentMas == null)
                    libPaymentMas = new PaymentMas();
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
                if (_dtPaymentMas.GetChanges() != null)
                {
                    _htSave = libPaymentMas.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtPaymentMas, out ErrorMsg);
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

        private void grdPaymentMas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (strBtnActionType != "SEARCH")
            {
                SetAutoIncrement();
            }
        }

        private void grdPaymentMas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                int? intEntityType = 0;
                DataGridViewComboBoxCell dgvtc = new DataGridViewComboBoxCell();
                switch (grdPaymentMas.Columns[e.ColumnIndex].Name)
                {
                    case "FROM_ENTITY_ID":
                        getLibraryInstance();
                        dgvtc = (DataGridViewComboBoxCell)grdPaymentMas.CurrentRow.Cells[e.ColumnIndex];
                        intEntityType = int.Parse(grdPaymentMas.CurrentRow.Cells["FROM_TYPE"].Value.ToString());
                        if (intEntityType != null)
                        {
                            DataTable dt = new DataTable();
                            dt = libPaymentMas.GetEmpList(p_entity_type: intEntityType.ToString(), p_is_active: string.Empty, Error: out ErrorMsg);
                            if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                            dgvtc.DataSource = dt.Copy();
                            dgvtc.DisplayMember = "ENTITY_NAME";
                            dgvtc.ValueMember = "ENTITY_ID";
                        }
                        else
                        {
                            grdPaymentMas.CurrentCell = grdPaymentMas.CurrentRow.Cells[e.ColumnIndex];
                            return;
                        }
                        break;
                    case "TO_ENTITY_ID":
                        getLibraryInstance();
                        dgvtc = (DataGridViewComboBoxCell)grdPaymentMas.CurrentRow.Cells[e.ColumnIndex];
                        intEntityType = int.Parse(grdPaymentMas.CurrentRow.Cells["TO_TYPE"].Value.ToString());
                        if (intEntityType != null)
                        {
                            DataTable dt = new DataTable();
                            dt = libPaymentMas.GetEmpList(p_entity_type: intEntityType.ToString(), p_is_active: string.Empty, Error: out ErrorMsg);
                            if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                            dgvtc.DataSource = dt.Copy();
                            dgvtc.DisplayMember = "ENTITY_NAME";
                            dgvtc.ValueMember = "ENTITY_ID";
                        }
                        else
                        {
                            grdPaymentMas.CurrentCell = grdPaymentMas.CurrentRow.Cells[e.ColumnIndex];
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
