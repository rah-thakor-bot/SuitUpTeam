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

        DataTable _dtGridFields;
        DataTable _dtStudyLevelMas;
        string[] strStudyLevelChkBxColName;
        string[] strStudyLevelCmbColName;
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
                LoadGrid();
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
            if (_strBtnActionType != "SEARCH")
            {
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrement = true;
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrementSeed = -1;
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrementStep = -1;
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
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);

                    grdStudyLevelMas.ReadOnly = false;
                    grdStudyLevelMas.AllowUserToAddRows = true;
                    
                    grdStudyLevelMas.Focus();
                    grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[grdStudyLevelMas.Rows.Count - 1].Cells["STD_ID"];
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
                            uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                            grdStudyLevelMas.ReadOnly = true;
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
                    grdStudyLevelMas.AllowUserToAddRows = true;
                    grdStudyLevelMas.ReadOnly = false;
                    _strBtnActionType = "EDIT";
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdStudyLevelMas.Focus();
                }
                else
                {
                    grdStudyLevelMas.AllowUserToAddRows = true;
                    grdStudyLevelMas.ReadOnly = true;
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, "LOAD");
                    btnMainPanel1.Focus();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMainPanel1_btnRefreshClick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnMainPanel1_btnSearchClick(object sender, EventArgs e)
        {
            SearchData();
        }
        #endregion

        #region Private Methods

        private void LoadGrid()
        {
            try
            {
                if (_libStudyLevelMas == null)
                    _libStudyLevelMas = new StudyLevelMas();

                _dtGridFields = _libStudyLevelMas.FetchGridFields(this.Tag.ToString(), "grdStudyLevelMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                _dtStudyLevelMas = _libStudyLevelMas.FetchData("1=2", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    throw new Exception(ErrorMsg.ToString());
                
                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strStudyLevelChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strStudyLevelCmbColName, out dgvcm_StudyLevel);
                Global.GridBindingSource(ref grdStudyLevelMas, _dtGridFields, strStudyLevelCmbColName, dgvcm_StudyLevel, strStudyLevelChkBxColName, _dtStudyLevelMas);
                uti.SetPanelStatus(btnMainPanel1, "LOAD");
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrement = true;
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrementSeed = -1;
                _dtStudyLevelMas.Columns["STD_ID"].AutoIncrementStep = -1;
                grdStudyLevelMas.AllowUserToAddRows = false;
                grdStudyLevelMas.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName)
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
                getLibraryInstance("STUDY_LEVEL");
                if (_dtStudyLevelMas.GetChanges() != null)
                {
                    _htSave = _libStudyLevelMas.SaveData("NULL", "", "RLT", Environment.MachineName, ref _dtStudyLevelMas, out ErrorMsg);
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

        private void SearchData()
        {
            try
            {
                

                _strBtnActionType= "SEARCH";
                if (_dtStudyLevelMas != null)
                {
                    _dtStudyLevelMas.Rows.Clear();
                    _dtStudyLevelMas.AcceptChanges();
                }
                getLibraryInstance("UTILITY");
                grdStudyLevelMas.AllowUserToAddRows = true;
                uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[0].Cells["STD_ID"];
                grdStudyLevelMas.Rows[0].Cells["STD_ID"].Value = DBNull.Value;
                grdStudyLevelMas.Focus();
                grdStudyLevelMas.ReadOnly = false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
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
                getLibraryInstance("UTILITY");
                string criteria = uti.GetGridCriteria(this.grdStudyLevelMas);

                getLibraryInstance("STUDY_LEVEL");
                if (!(string.IsNullOrEmpty(criteria)))
                {
                    _dtStudyLevelMas = _libStudyLevelMas.FetchData(criteria, out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                else
                {
                    _dtStudyLevelMas = _libStudyLevelMas.FetchData("1=1", out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                if (_dtStudyLevelMas.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdStudyLevelMas.DataSource = _dtStudyLevelMas;
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdStudyLevelMas.ReadOnly = true;
                    grdStudyLevelMas.AllowUserToAddRows = false;
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
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

                MessageBox.Show(e.ToString());
            }
            finally
            {
                //Dispose or Nullify Objects
            }
        }
        
        #endregion
    }
}
