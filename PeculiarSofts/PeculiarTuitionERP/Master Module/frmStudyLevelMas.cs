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
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;

        DataTable _dtGridFields;
        DataTable _dtSubjectLevelMas;
        string[] strStudyLevelChkBxColName;
        string[] strStudyLevelCmbColName;
        DataGridViewComboBoxColumn[] dgvcm_StudyLevel;
        #endregion

        #region Constructor
        public frmStudyLevelMas()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Panel Events
        private void btnMainPanel1_btnAddClick(object sender, EventArgs e)
        {
            try
            {


                if (btnMainPanel1.ButtonAddText == "&Add")
                {
                    grdStudyLevelMas.ReadOnly = false;

                    //grdMas.ReadOnlyCol = new string[] { "RPT_ID" };

                    grdStudyLevelMas.AllowUserToAddRows = true;

                    btnMainPanel1.ButtonAddText = "&Save";
                    btnMainPanel1.ButtonEditText = "&Cancel";
                    //_objUtil.ButtonStatus(btnPanel, Utility.ButtonStat.Active);

                    grdStudyLevelMas.Focus();
                    grdStudyLevelMas.CurrentCell = grdStudyLevelMas.Rows[grdStudyLevelMas.Rows.Count - 1].Cells["STD_ID"];

                    _strBtnActionType = "Add";
                }
                else
                {
                    Hashtable _htmas = new Hashtable();//= _objUtil.CheckGridRequriedCol(grdRptMas, "OP_RPT_MAS");

                    if (_htmas["RESULT"].ToString() == "true")
                    {
                        Hashtable _htResult = new Hashtable();
                        _htResult = SaveData();

                        if (_htResult["RESULT"].ToString().Trim() == "true")
                        {
                            if (_htResult["TIMESTAMP"].ToString() != "")
                            {
                                string _strMessage = _htResult["TIMESTAMP"].ToString();
                                //_strMessage = _strMessage.Replace("Timestamp  Error : ", "Following " + Resources.TimeStampMessage);
                                _strMessage += "Rest of Records ";

                                //if (_strActionType == "Add")
                                //    _strMessage += Resources.InsertMessage;
                                //else
                                //    _strMessage += Resources.UpdateMessage;

                                //Global.Information(_strMessage, Resources.DialogText);
                            }
                            else
                            {
                                //if (_strActionType == "Add")
                                //    Global.Information(Resources.InsertMessage, Resources.DialogText);
                                //else
                                //    Global.Information(Resources.UpdateMessage, Resources.DialogText);

                                //grdMas.RequiredCol = null;



                                //_dtMas.AcceptChanges();
                                //grdSubjectMaster.DataSource = _dtMas;


                                //grdRptMas.RequiredCol = _strReqColMas;


                            }
                            //if (_dtMas != null && _dtMas.Rows.Count > 0)
                            //{
                            //    btnMainPanel.ButtonEditEnable = true;
                            //}
                            //else
                            //{
                            //    btnMainPanel.ButtonEditEnable = false;
                            //}

                            btnMainPanel1.ButtonAddText = "&Add";
                            btnMainPanel1.ButtonEditText = "&Edit";
                            btnMainPanel1.ButtonDeleteEnable = false;
                            btnMainPanel1.ButtonSearchEnable = true;
                            btnMainPanel1.ButtonRefreshEnable = true;

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
            if (btnMainPanel1.ButtonAddText == "&Edit")
            {
                _strBtnActionType = "EDIT";
            }
            else
            {
                _strBtnActionType = "SAVE";
            }
        }

        private void btnMainPanel1_btnRefreshClick(object sender, EventArgs e)
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

        private void btnMainPanel1_btnSearchClick(object sender, EventArgs e)
        {
            if (btnMainPanel1.ButtonAddText == "Sea&rch")
            {
                _strBtnActionType = "SEARCH";
            }
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

                _dtSubjectLevelMas = _libStudyLevelMas.FetchData("1=2", out ErrorMsg);
                if (!string.IsNullOrEmpty(ErrorMsg))
                    throw new Exception(ErrorMsg.ToString());

                Global.AcquireGridCheckBoxColumn(_dtGridFields, out strStudyLevelChkBxColName);
                Global.AcquireComboListWithSource(_dtGridFields, out strStudyLevelCmbColName, out dgvcm_StudyLevel);
                Global.GridBindingSource(ref grdStudyLevelMas, _dtGridFields, strStudyLevelCmbColName, dgvcm_StudyLevel, strStudyLevelCmbColName, _dtSubjectLevelMas);
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private Hashtable SaveData()
        {
            Hashtable _htSave = null;
            try
            {
                //Save Data method call to middle Layer
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
    }


}
