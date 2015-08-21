using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;


namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmStudyLevelMas : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private StudyLevelMas _libStudyLevelMas;
        private Utility uti;
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string[] strStudyLevelChkBxColName;
        string[] strStudyLevelCmbColName;

        DataTable _dtGridFields;
        DataTable _dtStudyLevelMas;
        DataGridViewComboBoxColumn[] dgvcm_StudyLevel;
        #endregion

        #region Constructor
        public frmStudyLevelMas()
        {
            InitializeComponent();
            uti = new Utility();
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

        private void grdStudyLevelMas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdStudyLevelMas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void grdStudyLevelMas_RowEnter(object sender, DataGridViewCellEventArgs e)
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
                    ValGrid = Global.ValidateGrid(grdStudyLevelMas,_dtGridFields);
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
                        if (grdStudyLevelMas != null && grdStudyLevelMas.CurrentCell != null && grdStudyLevelMas.CurrentCell.RowIndex != 0)
                        {
                            grdStudyLevelMas.Select();
                            grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[grdStudyLevelMas.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdStudyLevelMas.Focus();
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
                grdStudyLevelMas.Select();
                grdStudyLevelMas.Focus();
                if (grdStudyLevelMas.Focused && grdStudyLevelMas.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdStudyLevelMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdStudyLevelMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdStudyLevelMas.Rows.Remove(_drMasRow);
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
                string criteria = uti.GetGridCriteria(grdStudyLevelMas);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtStudyLevelMas.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdStudyLevelMas.DataSource = _dtStudyLevelMas;
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
                    grdStudyLevelMas.AllowUserToAddRows = false;
                    grdStudyLevelMas.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdStudyLevelMas.ReadOnly = false;
                    grdStudyLevelMas.AllowUserToAddRows = true;

                    grdStudyLevelMas.Focus();
                    grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[grdStudyLevelMas.Rows.Count - 1].Cells["STD_ID"];
                    SetAutoIncrement();
                    break;
                case "EDIT":
                    grdStudyLevelMas.AllowUserToAddRows = true;
                    grdStudyLevelMas.ReadOnly = false;
                    grdStudyLevelMas.Focus();
                    break;
                case "SAVE":
                    grdStudyLevelMas.ReadOnly = true;
                    grdStudyLevelMas.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtStudyLevelMas != null)
                    {
                        _dtStudyLevelMas.Rows.Clear();
                        _dtStudyLevelMas.AcceptChanges();
                    }
                    grdStudyLevelMas.AllowUserToAddRows = true;
                    grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[0].Cells["STD_ID"];
                    grdStudyLevelMas.Rows[0].Cells["STD_ID"].Value = DBNull.Value;
                    grdStudyLevelMas.Focus();
                    grdStudyLevelMas.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdStudyLevelMas.ReadOnly = true;
                    grdStudyLevelMas.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdStudyLevelMas.AllowUserToAddRows = true;
                    grdStudyLevelMas.ReadOnly = true;
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
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrement = true;
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrementSeed = -1;
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrementStep = -1;
            }
        }
        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtStudyLevelMas = _libStudyLevelMas.FetchData(criteria, out ErrorMsg);
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
                _dtGridFields = _libStudyLevelMas.FetchGridFields(this.Tag.ToString(), "grdStudyLevelMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strStudyLevelChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strStudyLevelCmbColName, out dgvcm_StudyLevel);
                Global.GridBindingSource(ref grdStudyLevelMas, _dtGridFields, strStudyLevelCmbColName, dgvcm_StudyLevel, strStudyLevelChkBxColName, _dtStudyLevelMas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName= "STUDY_LEVEL")
        {
            if (libName.ToUpper() == "STUDY_LEVEL")
            {
                if (_libStudyLevelMas == null)
                    _libStudyLevelMas = new StudyLevelMas();
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
                if (_dtStudyLevelMas.GetChanges() != null)
                {
                    _htSave = _libStudyLevelMas.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtStudyLevelMas, out ErrorMsg);
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
