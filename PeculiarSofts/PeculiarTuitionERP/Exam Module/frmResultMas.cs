using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.ExamBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Exam_Module
{
    public partial class frmResultMas : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private ResultMaster libResultMas;
        private Utility uti;
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string[] strResultMasChkBxColName;
        string[] strResultMasCmbColName;

        DataTable _dtGridFields;
        DataTable _dtResultMas;
        DataGridViewComboBoxColumn[] dgvcm_ResultMas;
        #endregion

        #region Constructor
        public frmResultMas()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events
        private void frmResultMas_Load(object sender, EventArgs e)
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
                    ValGrid = Global.ValidateGrid(grdResultMas, _dtGridFields);
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
                            //Global.Information(string.Format(Resources.EmptyOrNullException, "RPT_ID"), Resources.DialogText);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Some fields are required");
                        if (grdResultMas != null && grdResultMas.CurrentCell != null && grdResultMas.CurrentCell.RowIndex != 0)
                        {
                            grdResultMas.Select();
                            grdResultMas.CurrentCell = grdResultMas.Rows[grdResultMas.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdResultMas.Focus();
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
                grdResultMas.Select();
                grdResultMas.Focus();
                if (grdResultMas.Focused && grdResultMas.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdResultMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdResultMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdResultMas.Rows.Remove(_drMasRow);
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
                string criteria = uti.GetGridCriteria(grdResultMas);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtResultMas.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdResultMas.DataSource = _dtResultMas;
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
                    grdResultMas.AllowUserToAddRows = false;
                    grdResultMas.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdResultMas.ReadOnly = false;
                    grdResultMas.AllowUserToAddRows = true;
                    
                    grdResultMas.Focus();
                    grdResultMas.CurrentCell = grdResultMas.Rows[grdResultMas.Rows.Count - 1].Cells["EXAM_ID"];
                    break;
                case "EDIT":
                    grdResultMas.AllowUserToAddRows = true;
                    grdResultMas.ReadOnly = false;
                    SetAutoIncrement();
                    grdResultMas.Focus();
                    break;
                case "SAVE":
                    grdResultMas.ReadOnly = true;
                    grdResultMas.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtResultMas != null)
                    {
                        _dtResultMas.Rows.Clear();
                        _dtResultMas.AcceptChanges();
                    }
                    grdResultMas.AllowUserToAddRows = true;
                    grdResultMas.CurrentCell = grdResultMas.Rows[0].Cells["EXAM_ID"];
                    grdResultMas.Rows[0].Cells["EXAM_ID"].Value = DBNull.Value;
                    grdResultMas.Focus();
                    grdResultMas.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdResultMas.ReadOnly = true;
                    grdResultMas.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdResultMas.AllowUserToAddRows = true;
                    grdResultMas.ReadOnly = true;
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
                _dtResultMas.Columns["EXAM_ID"].AutoIncrement = true;
                _dtResultMas.Columns["EXAM_ID"].AutoIncrementSeed = -1;
                _dtResultMas.Columns["EXAM_ID"].AutoIncrementStep = -1;
            }
        }

        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtResultMas = libResultMas.FetchData(criteria, out ErrorMsg);
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
                _dtGridFields = libResultMas.FetchGridFields(this.Tag.ToString(), "grdResultMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strResultMasChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strResultMasCmbColName, out dgvcm_ResultMas);
                Global.GridBindingSource(ref grdResultMas, _dtGridFields, strResultMasCmbColName, dgvcm_ResultMas, strResultMasChkBxColName, _dtResultMas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName = "RESULT")
        {
            if (libName.ToUpper() == "RESULT")
            {
                if (libResultMas == null)
                    libResultMas = new ResultMaster();
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
                if (_dtResultMas.GetChanges() != null)
                {
                    _htSave = libResultMas.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtResultMas, out ErrorMsg);
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
