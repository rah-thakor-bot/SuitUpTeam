using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmTimetable : frmBaseChild
    {
        

        #region Global Objects and Variable Declaration for Form

        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        string[] arrTimetableChkBxName;
        string[] arrTimetableCmbColName;

        private Utility uti;
        private DataTable _dtGridFields;
        private DataTable _dtTimetable; 
        private SubjectAllocation libTimetable; 
        private DataGridViewComboBoxColumn[] dgvcm_SubAlloc;
        #endregion

        #region Constructor
        public frmTimetable()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events

        private void frmTimetable_Load(object sender, EventArgs e)
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
                    ValGrid = Global.ValidateGrid(grdTimetable, _dtGridFields);
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
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some fields are required");
                        if (grdTimetable != null && grdTimetable.CurrentCell != null && grdTimetable.CurrentCell.RowIndex != 0)
                        {
                            grdTimetable.Select();
                            grdTimetable.CurrentCell = grdTimetable.Rows[grdTimetable.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdTimetable.Focus();
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
                grdTimetable.Select();
                grdTimetable.Focus();
                if (grdTimetable.Focused && grdTimetable.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdTimetable.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdTimetable.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdTimetable.Rows.Remove(_drMasRow);
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
                string criteria = uti.GetGridCriteria(grdTimetable);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtTimetable.Rows.Count > 0)
                {
                    grdTimetable.DataSource = _dtTimetable;
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
                    grdTimetable.AllowUserToAddRows = false;
                    grdTimetable.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdTimetable.ReadOnly = false;
                    grdTimetable.AllowUserToAddRows = true;
                    grdTimetable.Focus();
                    grdTimetable.CurrentCell = grdTimetable.Rows[grdTimetable.Rows.Count - 1].Cells["ALLOCATION_ID"];
                    SetAutoIncrement();
                    break;
                case "EDIT":
                    grdTimetable.AllowUserToAddRows = true;
                    grdTimetable.ReadOnly = false;
                    grdTimetable.Focus();
                    break;
                case "SAVE":
                    grdTimetable.ReadOnly = true;
                    grdTimetable.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtTimetable != null)
                    {
                        _dtTimetable.Rows.Clear();
                        _dtTimetable.AcceptChanges();
                    }
                    grdTimetable.AllowUserToAddRows = true;
                    grdTimetable.CurrentCell = grdTimetable.Rows[0].Cells["ALLOCATION_ID"];
                    grdTimetable.Rows[0].Cells["ALLOCATION_ID"].Value = DBNull.Value;
                    grdTimetable.Focus();
                    grdTimetable.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdTimetable.ReadOnly = true;
                    grdTimetable.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdTimetable.AllowUserToAddRows = false;
                    grdTimetable.ReadOnly = true;
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
                    MessageBox.Show(string.Format("Panel behaviour is not set \"{0}\" current action", _strBtnActionType));
                    break;
            }
        }

        private void SetAutoIncrement()
        {
            if (_strBtnActionType != "SEARCH")
            {
                _dtTimetable.Columns["ALLOCATION_ID"].AutoIncrement = true;
                _dtTimetable.Columns["ALLOCATION_ID"].AutoIncrementSeed = -1;
                _dtTimetable.Columns["ALLOCATION_ID"].AutoIncrementStep = -1;
            }
        }
        private void LoadGrid()
        {
            try
            {
                getLibraryInstance();
                _dtGridFields = libTimetable.FetchGridFields(this.Tag.ToString(), grdTimetable.Name, out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out arrTimetableChkBxName);
                Global.AcquireComboListWithSource(_dtGridFields, out arrTimetableCmbColName, out dgvcm_SubAlloc);
                Global.GridBindingSource(ref grdTimetable, _dtGridFields, arrTimetableCmbColName, dgvcm_SubAlloc, arrTimetableChkBxName, _dtTimetable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName = "TIMETABLE")
        {
            if (libName.ToUpper() == "TIMETABLE")
            {
                if (libTimetable == null)
                    libTimetable = new SubjectAllocation();
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
                _dtTimetable = libTimetable.FetchData(criteria, out ErrorMsg);
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
                if (_dtTimetable.GetChanges() != null)
                {
                    _htSave = libTimetable.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtTimetable, out ErrorMsg);
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
