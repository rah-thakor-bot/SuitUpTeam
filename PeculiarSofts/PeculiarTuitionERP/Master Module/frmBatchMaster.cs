using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
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
                LoadGrid();
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
            if (_strBtnActionType != "SEARCH")
            {
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrement = true;
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrementSeed = -1;
                _dtBatchMaster.Columns["BATCH_ID"].AutoIncrementStep = -1;
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

                    grdBatchMaster.ReadOnly = false;
                    grdBatchMaster.AllowUserToAddRows = true;

                    grdBatchMaster.Focus();
                    grdBatchMaster.CurrentCell = grdBatchMaster.Rows[grdBatchMaster.Rows.Count - 1].Cells["BATCH_ID"];
                }
                else
                {
                    Hashtable _htmas = new Hashtable();
                    //_htmas= _objUtil.CheckGridRequriedCol(grdRptMas, "OP_RPT_MAS");
                    _htmas.Add("RESULT", "true");
                    if (_htmas["RESULT"].ToString() == "true")
                    {
                        Hashtable _htResult = new Hashtable();
                        _htResult = SaveData();

                        if (_htResult["RESULT"].ToString().Trim() == "true")
                        {
                            //if (_htResult["TIMESTAMP"].ToString() != "")
                            //{
                            //    string _strMessage = _htResult["TIMESTAMP"].ToString();
                            //    //_strMessage = _strMessage.Replace("Timestamp  Error : ", "Following " + Resources.TimeStampMessage);
                            //    _strMessage += "Rest of Records ";

                            //    //if (_strActionType == "Add")
                            //    //    _strMessage += Resources.InsertMessage;
                            //    //else
                            //    //    _strMessage += Resources.UpdateMessage;

                            //    //Global.Information(_strMessage, Resources.DialogText);
                            //}
                            //else
                            //{
                            //    //if (_strActionType == "Add")
                            //    //    Global.Information(Resources.InsertMessage, Resources.DialogText);
                            //    //else
                            //    //    Global.Information(Resources.UpdateMessage, Resources.DialogText);

                            //    //grdMas.RequiredCol = null;



                            //    //_dtMas.AcceptChanges();
                            //    //grdSubjectMaster.DataSource = _dtMas;


                            //    //grdRptMas.RequiredCol = _strReqColMas;


                            //}
                            //if (_dtMas != null && _dtMas.Rows.Count > 0)
                            //{
                            //    btnMainPanel.ButtonEditEnable = true;
                            //}
                            //else
                            //{
                            //    btnMainPanel.ButtonEditEnable = false;
                            //}

                            MessageBox.Show("Saved Succesfully.");
                            getLibraryInstance("UTILITY");
                            _strBtnActionType = "SAVE";
                            uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                            grdBatchMaster.ReadOnly = true;
                            btnMainPanel1.Select();
                        }

                        else if (_htResult.Contains("ROW"))
                        {
                            //Code for Required Column
                        }
                        else
                        {
                            //Global.Information(string.Format(Resources.EmptyOrNullException, "RPT_ID"), Resources.DialogText);
                        }
                    }

                    else
                    {
                        uti.SetPanelStatus(btnMainPanel1, "LOAD");
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
                    grdBatchMaster.AllowUserToAddRows = true;
                    grdBatchMaster.ReadOnly = false;
                    _strBtnActionType = "EDIT";
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdBatchMaster.Focus();
                }
                else
                {
                    grdBatchMaster.AllowUserToAddRows = true;
                    grdBatchMaster.ReadOnly = true;
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, "LOAD");
                    btnMainPanel1.Focus();
                    btnMainPanel1.SetFocus(Private.MyUserControls.ButtonPanelControl.Action.Add);
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

        private void getLibraryInstance(string libName)
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
                    _htSave = libBatchMaster.SaveData("NULL", "", "RLT", Environment.MachineName, ref _dtBatchMaster, out ErrorMsg);
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
                grdBatchMaster.AllowUserToAddRows = true;

                _strBtnActionType = "SEARCH";
                if (_dtBatchMaster != null)
                {
                    _dtBatchMaster.Rows.Clear();
                    _dtBatchMaster.AcceptChanges();
                }
                getLibraryInstance("UTILITY");
                uti.SetPanelStatus(btnMainPanel1, "SEARCH");
                grdBatchMaster.CurrentCell = grdBatchMaster.Rows[0].Cells["BATCH_ID"];
                grdBatchMaster.Rows[0].Cells["BATCH_ID"].Value = DBNull.Value;
                grdBatchMaster.Focus();
                grdBatchMaster.ReadOnly = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
                string criteria = uti.GetGridCriteria(this.grdBatchMaster);

                getLibraryInstance("BATCHMAS");
                if (!(string.IsNullOrEmpty(criteria)))
                {
                    _dtBatchMaster = libBatchMaster.FetchData(criteria, out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                else
                {
                    _dtBatchMaster = libBatchMaster.FetchData("1=1", out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                if (_dtBatchMaster.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdBatchMaster.DataSource = _dtBatchMaster;
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdBatchMaster.ReadOnly = true;
                    grdBatchMaster.AllowUserToAddRows = false;
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                //Dispose or Nullify Objects
            }
        }


        #endregion
        
    }
}
