using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;
using System.Windows.Forms;

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

        #region Button Panel Events
        private void btnMainPanel1_btnAddClick(object sender, EventArgs e)
        {
            try
            {


                if (btnMainPanel1.ButtonAddText == "&Add")
                {
                    _strBtnActionType = "ADD";
                    
                    grdStudyLevelMas.ReadOnly = false;

                    grdStudyLevelMas.AllowUserToAddRows = true;
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    //_objUtil.ButtonStatus(btnPanel, Utility.ButtonStat.Active);

                    grdStudyLevelMas.Focus();
                    grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[grdStudyLevelMas.Rows.Count - 1].Cells["STD_ID"];
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

                            MessageBox.Show("Saved Succesful");
                            getLibraryInstance("UTILITY");
                            uti.SetPanelStatus(btnMainPanel1, "SAVE");
                            //_objUtil.EnableAllControls(this, false);
                            grdStudyLevelMas.ReadOnly = true;

                            btnMainPanel1.Select();
                            //btnMainPanel.SetFocus(LTPLControl.LTPLButtonControl.Action.Add);
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
                        btnMainPanel1.ButtonAddText = "&Add";
                        btnMainPanel1.ButtonEditText = "&Edit";
                        btnMainPanel1.ButtonRefreshEnable = true;
                        btnMainPanel1.ButtonSearchEnable = true;
                        btnMainPanel1.ButtonDeleteEnable = false;
                        grdStudyLevelMas.Enabled = true;


                        grdStudyLevelMas.ReadOnly = true;

                    }
                }
            }

            catch (Exception ex)
            {
                //Global.Error(ex, Resources.DialogText);
            }

        }

        private void btnMainPanel1_btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMainPanel1_btnDeleteClick(object sender, EventArgs e)
        {

        }

        private void btnMainPanel1_btnEditClick(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonEditText == "&Edit")
                {
                    grdStudyLevelMas.AllowUserToAddRows = true;

                    grdStudyLevelMas.ReadOnly = false;

                    if (grdStudyLevelMas != null && grdStudyLevelMas.Rows.Count > 1)
                    {
                        btnMainPanel1.ButtonDeleteEnable = true;
                    }
                    else
                    {
                        btnMainPanel1.ButtonDeleteEnable = false;
                    }
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, "EDIT");
                    grdStudyLevelMas.Focus();
                }
                else
                {
                    grdStudyLevelMas.AllowUserToAddRows = true;
                    grdStudyLevelMas.ReadOnly = true;
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
            Hashtable _htSave = null;
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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
                grdStudyLevelMas.AllowUserToAddRows = true;

                _strBtnActionType= "SEARCH";
                if (_dtStudyLevelMas != null)
                {
                    _dtStudyLevelMas.Rows.Clear();
                    _dtStudyLevelMas.AcceptChanges();
                }

                getLibraryInstance("UTILITY");
                uti.SetPanelStatus(btnMainPanel1, "SEARCH");
                
                grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[0].Cells["STD_ID"];
                grdStudyLevelMas.Rows[0].Cells["STD_ID"].Value = DBNull.Value;
                grdStudyLevelMas.Focus();
                grdStudyLevelMas.ReadOnly = false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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
                _dtStudyLevelMas = _libStudyLevelMas.FetchData(criteria, out ErrorMsg);
                if(ErrorMsg == null) throw new Exception(ErrorMsg);

                if (_dtStudyLevelMas.Rows.Count > 0)
                {
                    grdStudyLevelMas.DataSource = _dtStudyLevelMas;
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, "REFRESH");
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

        #region Form private Events
        private void frmStudyLevelMas_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void grdStudyLevelMas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdStudyLevelMas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }


}
