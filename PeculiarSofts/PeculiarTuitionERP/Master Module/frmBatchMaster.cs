using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmBatchMaster : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private BatchMaster libBatchMaster;
        private Utility uti;
        DataTable _dtGridFields;
        DataTable _dtBatchMaster;
        DataGridViewComboBoxColumn[] dgvcm_BatchMaster;

        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        string[] arrBatchMasChkBxName;
        string[] arrBatchMasCmbColName;
        
        #endregion

        #region Constructor
        public frmBatchMaster()
        {
            InitializeComponent();
            uti = new Utility();
        }
        #endregion

        #region Form private Events
        private void frmBatchMaster_Load(object sender, EventArgs e)
        {
            try
            {
                _strBtnActionType = "LOAD";
                LoadGrid();
                UpdateControlBehaviour();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdBatchMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdBatchMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void grdBatchMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetAutoIncrement();
        }
        #endregion

        #region Button Panel Events
        private void btnMainPanel1_btnAddClick(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonAddText == "&Add")
                {
                    _strBtnActionType = "ADD";
                    UpdateControlBehaviour();
                }
                else
                {
                    Hashtable ValGrid = new Hashtable();
                    ValGrid = Global.ValidateGrid(grdBatchMaster, _dtGridFields);
                    if (ValGrid["RESULT"].ToString() == "true")
                    {
                        Hashtable _htResult = new Hashtable();
                        _htResult = SaveData();

                        if (_htResult["RESULT"].ToString().Trim() == "true")
                        {
                            MessageBox.Show("Saved Succesfully.");
                            getLibraryInstance("UTILITY");
                            _strBtnActionType = "SAVE";


                            btnMainPanel1.Select();
                        }
                        else
                        {
                            //Global.Information(string.Format(Resources.EmptyOrNullException, "RPT_ID"), Resources.DialogText);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Some fields are required");
                        if (grdBatchMaster != null && grdBatchMaster.CurrentCell != null && grdBatchMaster.CurrentCell.RowIndex != 0)
                        {
                            grdBatchMaster.Select();
                            grdBatchMaster.CurrentCell = grdBatchMaster.Rows[grdBatchMaster.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdBatchMaster.Focus();
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
                grdBatchMaster.Select();
                grdBatchMaster.Focus();
                if (grdBatchMaster.Focused && grdBatchMaster.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdBatchMaster.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdBatchMaster.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdBatchMaster.Rows.Remove(_drMasRow);
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
                    _strBtnActionType = "EDIT";
                    UpdateControlBehaviour();

                }
                else
                {
                    _strBtnActionType = "CANCEL";
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
                string criteria = uti.GetGridCriteria(grdBatchMaster);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtBatchMaster.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdBatchMaster.DataSource = _dtBatchMaster;
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
                _strBtnActionType = "SEARCH";
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
            switch (_strBtnActionType.ToUpper())
            {
                case "LOAD":
                    grdBatchMaster.AllowUserToAddRows = false;
                    grdBatchMaster.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdBatchMaster.ReadOnly = false;
                    grdBatchMaster.AllowUserToAddRows = true;

                    grdBatchMaster.Focus();
                    grdBatchMaster.CurrentCell = grdBatchMaster.Rows[grdBatchMaster.Rows.Count - 1].Cells["BATCH_ID"];
                    SetAutoIncrement();
                    break;
                case "EDIT":
                    grdBatchMaster.AllowUserToAddRows = true;
                    grdBatchMaster.ReadOnly = false;
                    grdBatchMaster.Focus();
                    break;
                case "SAVE":
                    grdBatchMaster.ReadOnly = true;
                    grdBatchMaster.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtBatchMaster != null)
                    {
                        _dtBatchMaster.Rows.Clear();
                        _dtBatchMaster.AcceptChanges();
                    }
                    grdBatchMaster.AllowUserToAddRows = true;
                    grdBatchMaster.CurrentCell = grdBatchMaster.Rows[0].Cells["BATCH_ID"];
                    grdBatchMaster.Rows[0].Cells["BATCH_ID"].Value = DBNull.Value;
                    grdBatchMaster.Focus();
                    grdBatchMaster.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdBatchMaster.ReadOnly = true;
                    grdBatchMaster.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdBatchMaster.AllowUserToAddRows = true;
                    grdBatchMaster.ReadOnly = true;
                    break;
                default:
                    MessageBox.Show("Form behavious is not set for following behaviuor" + _strBtnActionType);
                    break;
            }
            UpdatePanelBehaviour(_strBtnActionType);
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
                    MessageBox.Show("Panel behaviour is not set \"{0}\" current action", _strBtnActionType);
                    break;
            }
        }

        private void SetAutoIncrement()
        {
            if (_strBtnActionType != "SEARCH")
            {
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrement = true;
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrementSeed = -1;
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrementStep = -1;
            }
        }
        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtBatchMaster = libBatchMaster.FetchData(criteria, out ErrorMsg);
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
                getLibraryInstance("BATCHMAS");
                _dtGridFields = libBatchMaster.FetchGridFields(this.Tag.ToString(), "grdBatchMaster", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                _dtBatchMaster = libBatchMaster.FetchData("1=2", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    throw new Exception(ErrorMsg.ToString());

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out arrBatchMasChkBxName);
                Global.AcquireComboListWithSource(_dtGridFields, out arrBatchMasCmbColName, out dgvcm_BatchMaster);
                Global.GridBindingSource(ref grdBatchMaster, _dtGridFields, arrBatchMasCmbColName, dgvcm_BatchMaster, arrBatchMasChkBxName, _dtBatchMaster);
                uti.SetPanelStatus(btnMainPanel1, "LOAD");
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrement = true;
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrementSeed = -1;
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrementStep = -1;
                grdBatchMaster.AllowUserToAddRows = false;
                grdBatchMaster.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName ="BATCHMAS")
        {
            if (libName.ToUpper() == "BATCHMAS")
            {
                if (libBatchMaster == null)
                    libBatchMaster = new BatchMaster();
            }
            else if (libName.ToUpper() == "UTILITY")
            {
                if (uti == null)
                    uti = new Utility();
            }
        }

        private Hashtable SaveData()
        {
            Hashtable _htSave = null;
            try
            {
                getLibraryInstance("BATCHMAS");
                if (_dtBatchMaster.GetChanges() != null)
                {
                    _htSave = libBatchMaster.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtBatchMaster, out ErrorMsg);
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
