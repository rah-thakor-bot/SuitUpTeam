using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmSubAlloc : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        string[] arrSubAllocChkBxName;
        string[] arrSubAllocCmbColName;

        private Utility uti;
        private DataTable _dtGridFields;
        private DataTable _dtSubAlloc;
        private SubjectAllocation libSubAlloc;
        private DataGridViewComboBoxColumn[] dgvcm_SubAlloc;
        #endregion

        #region Constructor

        public frmSubAlloc()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events

        private void frmSubAlloc_Load(object sender, EventArgs e)
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
                    ValGrid = Global.ValidateGrid(grdSubAlloc, _dtGridFields);
                    if (ValGrid["RESULT"].ToString() == "true")
                    {
                        Hashtable _htResult = new Hashtable();
                        _htResult = SaveData();

                        if (_htResult["RESULT"].ToString().Trim() == "true")
                        {
                            MessageBox.Show("Saved Succesfully.");
                            _strBtnActionType = "SAVE";
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
                        if (grdSubAlloc != null && grdSubAlloc.CurrentCell != null && grdSubAlloc.CurrentCell.RowIndex != 0)
                        {
                            grdSubAlloc.Select();
                            grdSubAlloc.CurrentCell = grdSubAlloc.Rows[grdSubAlloc.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdSubAlloc.Focus();
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
                grdSubAlloc.Select();
                grdSubAlloc.Focus();
                if (grdSubAlloc.Focused && grdSubAlloc.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdSubAlloc.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdSubAlloc.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdSubAlloc.Rows.Remove(_drMasRow);
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
                string criteria = uti.GetGridCriteria(grdSubAlloc);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtSubAlloc.Rows.Count > 0)
                {
                    grdSubAlloc.DataSource = _dtSubAlloc;
                    _strBtnActionType = "REFRESH";
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

        private void grdSubAlloc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetAutoIncrement();
        }
        #endregion

        #region Private Methods
        private void UpdateControlBehaviour()
        {
            getLibraryInstance("UTILITY");
            UpdatePanelBehaviour(_strBtnActionType);
            switch (_strBtnActionType.ToUpper())
            {
                case "LOAD":
                    grdSubAlloc.AllowUserToAddRows = false;
                    grdSubAlloc.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdSubAlloc.ReadOnly = false;
                    grdSubAlloc.AllowUserToAddRows = true;
                    grdSubAlloc.Focus();
                    grdSubAlloc.CurrentCell = grdSubAlloc.Rows[grdSubAlloc.Rows.Count - 1].Cells["ALLOCATION_ID"];
                    SetAutoIncrement();
                    break;
                case "EDIT":
                    grdSubAlloc.AllowUserToAddRows = true;
                    grdSubAlloc.ReadOnly = false;
                    grdSubAlloc.Focus();
                    break;
                case "SAVE":
                    grdSubAlloc.ReadOnly = true;
                    grdSubAlloc.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtSubAlloc != null)
                    {
                        _dtSubAlloc.Rows.Clear();
                        _dtSubAlloc.AcceptChanges();
                    }
                    grdSubAlloc.AllowUserToAddRows = true;
                    grdSubAlloc.CurrentCell = grdSubAlloc.Rows[0].Cells["ALLOCATION_ID"];
                    grdSubAlloc.Rows[0].Cells["ALLOCATION_ID"].Value = DBNull.Value;
                    grdSubAlloc.Focus();
                    grdSubAlloc.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdSubAlloc.ReadOnly = true;
                    grdSubAlloc.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdSubAlloc.AllowUserToAddRows = false;
                    grdSubAlloc.ReadOnly = true;
                    break;
                default:
                    MessageBox.Show("Form behavious is not set for following behaviuor" + _strBtnActionType);
                    break;
            }
            
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
                _dtSubAlloc.Columns["ALLOCATION_ID"].AutoIncrement = true;
                _dtSubAlloc.Columns["ALLOCATION_ID"].AutoIncrementSeed = -1;
                _dtSubAlloc.Columns["ALLOCATION_ID"].AutoIncrementStep = -1;
            }
        }
        private void LoadGrid()
        {
            try
            {
                getLibraryInstance();
                _dtGridFields = libSubAlloc.FetchGridFields(this.Tag.ToString(), "grdSubAlloc", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out arrSubAllocChkBxName);
                Global.AcquireComboListWithSource(_dtGridFields, out arrSubAllocCmbColName, out dgvcm_SubAlloc);
                Global.GridBindingSource(ref grdSubAlloc, _dtGridFields, arrSubAllocCmbColName, dgvcm_SubAlloc, arrSubAllocChkBxName, _dtSubAlloc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName = "SUBALLOC")
        {
            if (libName.ToUpper() == "SUBALLOC")
            {
                if (libSubAlloc == null)
                    libSubAlloc = new SubjectAllocation();
            }
            else if (libName.ToUpper() == "UTILITY")
            {
                if (uti == null)
                    uti = new Utility();
            }
        }

        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtSubAlloc = libSubAlloc.FetchData(criteria, out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    throw new Exception(ErrorMsg.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        private Hashtable SaveData()
        {
            Hashtable _htSave = null;
            try
            {
                getLibraryInstance("STUDY_LEVEL");
                if (_dtSubAlloc.GetChanges() != null)
                {
                    _htSave = libSubAlloc.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtSubAlloc, out ErrorMsg);
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
