using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmAttendanceMaster : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form
        private AttendanceMas _libAttendanceMas;
        private Utility uti;
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string[] strAttendanceChkBxColName;
        string[] strAttendanceCmbColName;

        DataTable _dtGridFields;
        DataTable _dtAttendanceMas;
        DataGridViewComboBoxColumn[] dgvcm_StudyLevel;
        #endregion

        #region Constructor
        public frmAttendanceMaster()
        {
            InitializeComponent();
        }
        #endregion

        #region Form private Events
        private void frmStudyLevelMas_Load(object sender, EventArgs e)
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

        private void grdAttendanceMas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdAttendanceMas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void grdAttendanceMas_RowEnter(object sender, DataGridViewCellEventArgs e)
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
                    ValGrid = Global.ValidateGrid(grdAttendanceMas, _dtGridFields);
                    if (ValGrid["RESULT"].ToString() == "true")
                    {
                        Hashtable _htResult = new Hashtable();
                        _htResult = SaveData();

                        if (_htResult["RESULT"].ToString().Trim() == "true")
                        {
                            MessageBox.Show("Saved Succesfully.");
                            getLibraryInstance("UTILITY");
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
                        if (grdAttendanceMas != null && grdAttendanceMas.CurrentCell != null && grdAttendanceMas.CurrentCell.RowIndex != 0)
                        {
                            grdAttendanceMas.Select();
                            grdAttendanceMas.CurrentCell = grdAttendanceMas.Rows[grdAttendanceMas.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdAttendanceMas.Focus();
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
                grdAttendanceMas.Select();
                grdAttendanceMas.Focus();
                if (grdAttendanceMas.Focused && grdAttendanceMas.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdAttendanceMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdAttendanceMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdAttendanceMas.Rows.Remove(_drMasRow);
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
                string criteria = uti.GetGridCriteria(grdAttendanceMas);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtAttendanceMas.Rows.Count > 0)
                {
                    grdAttendanceMas.DataSource = _dtAttendanceMas;
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
        #endregion

        #region Private Methods
        private void UpdateControlBehaviour()
        {
            getLibraryInstance("UTILITY");
            switch (_strBtnActionType.ToUpper())
            {
                case "LOAD":
                    grdAttendanceMas.AllowUserToAddRows = false;
                    grdAttendanceMas.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdAttendanceMas.ReadOnly = false;
                    grdAttendanceMas.AllowUserToAddRows = true;

                    grdAttendanceMas.Focus();
                    grdAttendanceMas.CurrentCell = grdAttendanceMas.Rows[grdAttendanceMas.Rows.Count - 1].Cells["SEQNO"];
                    SetAutoIncrement();
                    break;
                case "EDIT":
                    grdAttendanceMas.AllowUserToAddRows = true;
                    grdAttendanceMas.ReadOnly = false;
                    grdAttendanceMas.Focus();
                    break;
                case "SAVE":
                    grdAttendanceMas.ReadOnly = true;
                    grdAttendanceMas.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtAttendanceMas != null)
                    {
                        _dtAttendanceMas.Rows.Clear();
                        _dtAttendanceMas.AcceptChanges();
                    }
                    grdAttendanceMas.AllowUserToAddRows = true;
                    grdAttendanceMas.CurrentCell = grdAttendanceMas.Rows[0].Cells["SEQNO"];
                    grdAttendanceMas.Rows[0].Cells["SEQNO"].Value = DBNull.Value;
                    grdAttendanceMas.Focus();
                    grdAttendanceMas.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdAttendanceMas.ReadOnly = true;
                    grdAttendanceMas.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdAttendanceMas.AllowUserToAddRows = true;
                    grdAttendanceMas.ReadOnly = true;
                    break;
                default:
                    MessageBox.Show("Form behavious is not set for following behaviuor" + _strBtnActionType);
                    break;
            }
            UpdatePanelBehaviour(_strBtnActionType);
        }

        private void UpdatePanelBehaviour(string ActionType)//Do not call directly
        {
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
                _dtAttendanceMas.Columns["SEQNO"].AutoIncrement = true;
                _dtAttendanceMas.Columns["SEQNO"].AutoIncrementSeed = -1;
                _dtAttendanceMas.Columns["SEQNO"].AutoIncrementStep = -1;
            }
        }
        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtAttendanceMas = _libAttendanceMas.FetchData(criteria, out ErrorMsg);
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
                _dtGridFields = _libAttendanceMas.FetchGridFields(this.Tag.ToString(), "grdAttendanceMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strAttendanceChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strAttendanceCmbColName, out dgvcm_StudyLevel);
                Global.GridBindingSource(ref grdAttendanceMas, _dtGridFields, strAttendanceCmbColName, dgvcm_StudyLevel, strAttendanceChkBxColName, _dtAttendanceMas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void getLibraryInstance(string libName = "ATTENDANCE")
        {
            if (libName.ToUpper() == "ATTENDANCE")
            {
                if (_libAttendanceMas == null)
                    _libAttendanceMas = new AttendanceMas();
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
                if (_dtAttendanceMas.GetChanges() != null)
                {
                    _htSave = _libAttendanceMas.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtAttendanceMas, out ErrorMsg);
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
