using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmSubAlloc : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

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

        }

        private void buttonPanelControl1_btnAddClick(object sender, EventArgs e)
        {
            if (btnMainPanel1.ButtonAddText == "&Add")
            {
                _strBtnActionType = "ADD";
            }
            else
            {
                _strBtnActionType = "SAVE";
            }
        }

        private void buttonPanelControl1_btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPanelControl1_btnDeleteClick(object sender, EventArgs e)
        {

        }

        private void buttonPanelControl1_btnEditClick(object sender, EventArgs e)
        {
            if (btnMainPanel1.ButtonAddText == "&Edit")
            {
                _strBtnActionType = "EDIT";
            }
            else
            {
                _strBtnActionType = "SAVE";
            }

        }

        private void buttonPanelControl1_btnRefreshClick(object sender, EventArgs e)
        {
            if (btnMainPanel1.ButtonAddText == "Re&fresh")
            {
                _strBtnActionType = "REFRESH";
            }
            else
            {
                _strBtnActionType = string.Empty;
            }
        }

        private void buttonPanelControl1_btnSearchClick(object sender, EventArgs e)
        {
            if (btnMainPanel1.ButtonAddText == "Sea&rch")
            {
                _strBtnActionType = "SEARCH";
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

                    grdSubAlloc.ReadOnly = false;
                    grdSubAlloc.AllowUserToAddRows = true;

                    grdSubAlloc.Focus();
                    grdSubAlloc.CurrentCell = grdSubAlloc.Rows[grdSubAlloc.Rows.Count - 1].Cells["ALLOCATION_ID"];
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
                            grdSubAlloc.ReadOnly = true;
                            btnMainPanel1.Select();
                        }

                        else if (_htResult.Contains("ROW"))
                        {
                            //
                            //
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
                    grdSubAlloc.AllowUserToAddRows = true;
                    grdSubAlloc.ReadOnly = false;
                    _strBtnActionType = "EDIT";
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdSubAlloc.Focus();
                }
                else
                {
                    grdSubAlloc.AllowUserToAddRows = true;
                    grdSubAlloc.ReadOnly = true;
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
                _dtGridFields = libSubAlloc.FetchGridFields(this.Tag.ToString(), "grdSubAlloc", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                _dtSubAlloc = libSubAlloc.FetchData("1=2", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    throw new Exception(ErrorMsg.ToString());

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out arrSubAllocChkBxName);
                Global.AcquireComboListWithSource(_dtGridFields, out arrSubAllocCmbColName, out dgvcm_SubAlloc);
                Global.GridBindingSource(ref grdSubAlloc, _dtGridFields, arrSubAllocCmbColName, dgvcm_SubAlloc, arrSubAllocChkBxName, _dtSubAlloc);
                uti.SetPanelStatus(btnMainPanel1, "LOAD");
                _dtSubAlloc.Columns["ALLOCATION_ID"].AutoIncrement = true;
                _dtSubAlloc.Columns["ALLOCATION_ID"].AutoIncrementSeed = -1;
                _dtSubAlloc.Columns["ALLOCATION_ID"].AutoIncrementStep = -1;
                grdSubAlloc.AllowUserToAddRows = false;
                grdSubAlloc.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void getLibraryInstance(string libName)
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

        private Hashtable SaveData()
        {
            Hashtable _htSave = null;
            try
            {
                getLibraryInstance("STUDY_LEVEL");
                if (_dtSubAlloc.GetChanges() != null)
                {
                    _htSave = libSubAlloc.SaveData("NULL", "", "RLT", Environment.MachineName, ref _dtSubAlloc, out ErrorMsg);
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
                grdSubAlloc.AllowUserToAddRows = true;

                _strBtnActionType = "SEARCH";
                if (_dtSubAlloc != null)
                {
                    _dtSubAlloc.Rows.Clear();
                    _dtSubAlloc.AcceptChanges();
                }
                getLibraryInstance("UTILITY");
                uti.SetPanelStatus(btnMainPanel1, "SEARCH");
                grdSubAlloc.CurrentCell = grdSubAlloc.Rows[0].Cells["ALLOCATION_ID"];
                grdSubAlloc.Rows[0].Cells["ALLOCATION_ID"].Value = DBNull.Value;
                grdSubAlloc.Focus();
                grdSubAlloc.ReadOnly = false;

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
                string criteria = uti.GetGridCriteria(this.grdSubAlloc);

                getLibraryInstance("STUDY_LEVEL");
                if (!(string.IsNullOrEmpty(criteria)))
                {
                    _dtSubAlloc = libSubAlloc.FetchData(criteria, out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                else
                {
                    _dtSubAlloc = libSubAlloc.FetchData("1=1", out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                if (_dtSubAlloc.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdSubAlloc.DataSource = _dtSubAlloc;
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdSubAlloc.ReadOnly = true;
                    grdSubAlloc.AllowUserToAddRows = false;
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
