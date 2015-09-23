using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.ExamBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Exam_Module
{
    public partial class frmExamMas : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private ExamMaster libExamMas;
        private Utility uti;
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        const string DefaultLoadCriteria = "1 = 2";
        const string DefaultRefreshCriteria = "1 = 1";
        string[] strExamMasChkBxColName;
        string[] strExamMasCmbColName;

        DataTable _dtGridFields;
        DataTable _dtExamMas;
        DataGridViewComboBoxColumn[] dgvcm_ExamMas;
        #endregion

        #region Constructor
        public frmExamMas()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events
        private void frmExamMas_Load(object sender, EventArgs e)
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

        private void grdExamMas_RowEnter(object sender, DataGridViewCellEventArgs e)
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
                    ValGrid = Global.ValidateGrid(grdExamMas, _dtGridFields);
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
                        if (grdExamMas != null && grdExamMas.CurrentCell != null && grdExamMas.CurrentCell.RowIndex != 0)
                        {
                            grdExamMas.Select();
                            grdExamMas.CurrentCell = grdExamMas.Rows[grdExamMas.CurrentCell.RowIndex].Cells[ValGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdExamMas.Focus();
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
                grdExamMas.Select();
                grdExamMas.Focus();
                if (grdExamMas.Focused && grdExamMas.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdExamMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdExamMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdExamMas.Rows.Remove(_drMasRow);
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
                string criteria = uti.GetGridCriteria(grdExamMas);
                criteria = (string.IsNullOrWhiteSpace(criteria) == true ? DefaultRefreshCriteria : criteria);
                GetDataSet(criteria);
                if (_dtExamMas.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdExamMas.DataSource = _dtExamMas;
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
                    grdExamMas.AllowUserToAddRows = false;
                    grdExamMas.ReadOnly = true;
                    SetAutoIncrement();
                    break;
                case "ADD":
                    grdExamMas.ReadOnly = false;
                    grdExamMas.AllowUserToAddRows = true;

                    grdExamMas.Focus();
                    grdExamMas.CurrentCell = grdExamMas.Rows[grdExamMas.Rows.Count - 1].Cells["EXAM_ID"];
                    SetAutoIncrement();
                    break;
                case "EDIT":
                    grdExamMas.AllowUserToAddRows = true;
                    grdExamMas.ReadOnly = false;
                    grdExamMas.Focus();
                    break;
                case "SAVE":
                    grdExamMas.ReadOnly = true;
                    grdExamMas.AllowUserToAddRows = false;
                    break;
                case "SEARCH":
                    if (_dtExamMas != null)
                    {
                        _dtExamMas.Rows.Clear();
                        _dtExamMas.AcceptChanges();
                    }
                    grdExamMas.AllowUserToAddRows = true;
                    grdExamMas.CurrentCell = grdExamMas.Rows[0].Cells["EXAM_ID"];
                    grdExamMas.Rows[0].Cells["EXAM_ID"].Value = DBNull.Value;
                    grdExamMas.Focus();
                    grdExamMas.ReadOnly = false;
                    break;
                case "REFRESH":
                    grdExamMas.ReadOnly = true;
                    grdExamMas.AllowUserToAddRows = false;
                    break;
                case "CANCEL":
                    grdExamMas.AllowUserToAddRows = true;
                    grdExamMas.ReadOnly = true;
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
                _dtExamMas.Columns["EXAM_ID"].AutoIncrement = true;
                _dtExamMas.Columns["EXAM_ID"].AutoIncrementSeed = -1;
                _dtExamMas.Columns["EXAM_ID"].AutoIncrementStep = -1;
            }
        }

        private void GetDataSet(string criteria = DefaultLoadCriteria)
        {
            try
            {
                getLibraryInstance();
                _dtExamMas = libExamMas.FetchData(criteria, out ErrorMsg);
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
                _dtGridFields = libExamMas.FetchGridFields(this.Tag.ToString(), "grdExamMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                GetDataSet();

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strExamMasChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strExamMasCmbColName, out dgvcm_ExamMas);
                Global.GridBindingSource(ref grdExamMas, _dtGridFields, strExamMasCmbColName, dgvcm_ExamMas, strExamMasChkBxColName, _dtExamMas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName = "EXAM")
        {
            if (libName.ToUpper() == "EXAM")
            {
                if (libExamMas == null)
                    libExamMas = new ExamMaster();
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
                if (_dtExamMas.GetChanges() != null)
                {
                    _htSave = libExamMas.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtExamMas, out ErrorMsg);
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
