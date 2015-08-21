using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;
using PeculiarTuitionBase.Super;

namespace PeculiarTuitionERP.Super
{
    public partial class frmGridFields : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private GridFields libGridMaster;
        private Utility uti;
        DataTable _dtGridFields;
        DataTable _dtGridMaster;
        DataGridViewComboBoxColumn[] dgvcm_Mas;

        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        string[] arrChkBxName;
        string[] arrMasCmbColName;

        #endregion

        public frmGridFields()
        {
            InitializeComponent();
            this.Tag = "GridFields";
        }

        private void frmGridFields_Load(object sender, EventArgs e)
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

        #region Button Panel Events

        private void btnMainPanel1_btnAddClick(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonAddText == "&Add")
                {
                    _strBtnActionType = "ADD";
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);

                    grdGridMas.ReadOnly = false;
                    grdGridMas.AllowUserToAddRows = true;

                    grdGridMas.Focus();
                    grdGridMas.CurrentCell = grdGridMas.Rows[grdGridMas.Rows.Count - 1].Cells["SEQNO"];
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
                            
                            MessageBox.Show("Saved Succesfully.");
                            getLibraryInstance("UTILITY");
                            _strBtnActionType = "SAVE";
                            uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                            grdGridMas.ReadOnly = true;
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
                grdGridMas.Select();
                grdGridMas.Focus();
                if (grdGridMas.Focused && grdGridMas.SelectedRows.Count > 0)
                {
                    _strBtnActionType = "DELETE";
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdGridMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdGridMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdGridMas.Rows.Remove(_drMasRow);
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
                    grdGridMas.AllowUserToAddRows = true;
                    grdGridMas.ReadOnly = false;
                    _strBtnActionType = "EDIT";
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdGridMas.Focus();
                }
                else
                {
                    grdGridMas.AllowUserToAddRows = true;
                    grdGridMas.ReadOnly = true;
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
                getLibraryInstance("GRIDMAS");
                _dtGridFields = libGridMaster.FetchGridFields(this.Tag.ToString(), "grdGridMas", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    MessageBox.Show(ErrorMsg);

                _dtGridMaster = libGridMaster.FetchData("1=2", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    throw new Exception(ErrorMsg.ToString());

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out arrChkBxName);
                Global.AcquireComboListWithSource(_dtGridFields, out arrMasCmbColName, out dgvcm_Mas);
                Global.GridBindingSource(ref grdGridMas, _dtGridFields, arrMasCmbColName == null ? null : arrMasCmbColName, dgvcm_Mas == null ? null : dgvcm_Mas, arrChkBxName == null ? null : arrChkBxName, _dtGridMaster);
                getLibraryInstance("Utility");
                uti.SetPanelStatus(btnMainPanel1, "LOAD");
                _dtGridMaster.Columns["SEQNO"].AutoIncrement = true;
                _dtGridMaster.Columns["SEQNO"].AutoIncrementSeed = -1;
                _dtGridMaster.Columns["SEQNO"].AutoIncrementStep = -1;
                grdGridMas.AllowUserToAddRows = false;
                grdGridMas.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void getLibraryInstance(string libName)
        {
            if (libName.ToUpper() == "GRIDMAS")
            {
                if (libGridMaster == null)
                    libGridMaster = new GridFields();
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
                getLibraryInstance("GRIDMAS");
                if (_dtGridMaster.GetChanges() != null)
                {
                    _htSave = libGridMaster.SaveData(Global.LoginBranch, Global.LoginUser, Environment.MachineName, ref _dtGridMaster, out ErrorMsg);
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
                grdGridMas.AllowUserToAddRows = true;

                _strBtnActionType = "SEARCH";
                if (_dtGridMaster != null)
                {
                    _dtGridMaster.Rows.Clear();
                    _dtGridMaster.AcceptChanges();
                }
                getLibraryInstance("UTILITY");
                uti.SetPanelStatus(btnMainPanel1, "SEARCH");
                grdGridMas.CurrentCell = grdGridMas.Rows[0].Cells["SEQNO"];
                grdGridMas.Rows[0].Cells["SEQNO"].Value = DBNull.Value;
                grdGridMas.Focus();
                grdGridMas.ReadOnly = false;

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
                string criteria = uti.GetGridCriteria(this.grdGridMas);

                getLibraryInstance("GRIDMAS");
                if (!(string.IsNullOrEmpty(criteria)))
                {
                    _dtGridMaster = libGridMaster.FetchData(criteria, out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                else
                {
                    _dtGridMaster = libGridMaster.FetchData("1=1", out ErrorMsg);
                    if (ErrorMsg == null) throw new Exception(ErrorMsg);
                }
                if (_dtGridMaster.Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    grdGridMas.DataSource = _dtGridMaster;
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grdGridMas.ReadOnly = true;
                    grdGridMas.AllowUserToAddRows = false;
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
