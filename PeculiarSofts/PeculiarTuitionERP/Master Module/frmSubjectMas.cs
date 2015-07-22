using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmSubjectMas : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private SubjectMas _libSubjectMas;
        private ChapterMas _libChpMas;
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;

        DataSet dsMain;
        DataTable _dtGridSubject;
        DataTable _dtGridChapter;
        string[] strSubChkBxColName;
        string[] strSubCmbColName,strChpCmbColName;
        DataGridViewCheckBoxColumn[] grdSubChkCol;
        DataGridViewComboBoxColumn[] grdSubCmbCol,grdChpCmbCol;
        #endregion

        #region Constructor

        public frmSubjectMas()
        {
            InitializeComponent();
        }

        public frmSubjectMas(string _p_form_type)
        {
            InitializeComponent();
            this.Text = "Subject Master";
            this.Tag = "SubjectMas";
            grpSubjectMaster.Text = "Subject Master";

        }

        #endregion

        #region Form Events

        private void frmSubjectMas_Load(object sender, EventArgs e)
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

        private void buttonPanelControl1_btnAddClick(object sender, EventArgs e)
        {
            try
            {


                if (btnMainPanel.ButtonAddText == "&Add")
                {
                    grdSubjectMaster.ReadOnly = false;

                    //grdMas.ReadOnlyCol = new string[] { "RPT_ID" };

                    grdSubjectMaster.AllowUserToAddRows = true;

                    btnMainPanel.ButtonAddText = "&Save";
                    btnMainPanel.ButtonEditText = "&Cancel";
                    //_objUtil.ButtonStatus(btnPanel, Utility.ButtonStat.Active);

                    grdSubjectMaster.Focus();
                    grdSubjectMaster.CurrentCell = grdSubjectMaster.Rows[grdSubjectMaster.Rows.Count - 1].Cells["STD_ID"];

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

                            btnMainPanel.ButtonAddText = "&Add";
                            btnMainPanel.ButtonEditText = "&Edit";
                            btnMainPanel.ButtonDeleteEnable = false;
                            btnMainPanel.ButtonSearchEnable = true;
                            btnMainPanel.ButtonRefreshEnable = true;

                            //_objUtil.EnableAllControls(this, false);
                            grdSubjectMaster.ReadOnly = true;

                            btnMainPanel.Select();
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
                        btnMainPanel.ButtonAddText = "&Add";
                        btnMainPanel.ButtonEditText = "&Edit";
                        btnMainPanel.ButtonRefreshEnable = true;
                        btnMainPanel.ButtonSearchEnable = true;
                        btnMainPanel.ButtonDeleteEnable = false;
                        grdSubjectMaster.Enabled = true;


                        grdSubjectMaster.ReadOnly = true;

                    }
                }
            }

            catch (Exception ex)
            {
                //Global.Error(ex, Resources.DialogText);
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
            if (btnMainPanel.ButtonAddText == "&Edit")
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
            if (btnMainPanel.ButtonAddText == "Re&fresh")
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
            if (btnMainPanel.ButtonAddText == "Sea&rch")
            {
                _strBtnActionType = "SEARCH";
            }
        }
        #endregion

        #region Private Methodssss

        private void SearchData()
        {
            try
            {

            }
            catch (Exception e)
            {

                throw e;
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

                throw e;
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

                throw e;
            }
            finally
            {
                //Dispose or Nullify Objects
            }
        }

        #endregion

        #region Form Validation

        #endregion

        #region Methods

        private void GetLibInstance()
        {
            if (_libSubjectMas == null)
            {
                _libSubjectMas = new SubjectMas();
            }

        }

        private void GetLibInstance(string objName)
        {
            if (objName == "Subject")
            {
                if (_libSubjectMas == null)
                    _libSubjectMas = new SubjectMas();
            }
            else if (objName == "Chapter")
            {
                if (_libChpMas == null)
                    _libChpMas = new ChapterMas();
            }

        }
        private void LoadGrid()
        {

            GetLibInstance("Subject");
            _dtGridSubject = _libSubjectMas.FetchGridFields(this.Tag.ToString(), "grdMas", out ErrorMsg);
            if (!string.IsNullOrEmpty(ErrorMsg))
                MessageBox.Show(ErrorMsg);

            GetLibInstance("Chapter");
            _dtGridChapter = _libChpMas.FetchGridFields(this.Tag.ToString(), "grdDet", out ErrorMsg);
            if (!string.IsNullOrEmpty(ErrorMsg))
                MessageBox.Show(ErrorMsg);

            dsMain = _libSubjectMas.FetchData("1=1", out ErrorMsg);
            if (!string.IsNullOrEmpty(ErrorMsg))
                MessageBox.Show(ErrorMsg);

            Global.AcquireGridCheckBoxColumn(_dtGridSubject,out strSubChkBxColName);
            Global.AcquireComboListWithSource(_dtGridSubject, out strSubCmbColName, out grdSubCmbCol);
            Global.GridBindingSource(ref grdSubjectMaster, _dtGridSubject, null, null, strSubChkBxColName, dsMain.Tables["SubMas"]);

            //Global.AcquireGridCheckBoxColumn(_dtGridChapter, out strChpCmbColName);
            Global.AcquireComboListWithSource(_dtGridChapter, out strChpCmbColName, out grdChpCmbCol);
            Global.GridBindingSource(ref grdChapterDetail, _dtGridChapter, strChpCmbColName, grdChpCmbCol, null, dsMain.Tables["ChpDet"]);

        }

        private Hashtable SaveData()
        {
            try
            {
                Hashtable _htSave = new Hashtable();

                GetLibInstance("Subject");

                //if (_dtMas != null && _dtMas.Rows.Count > 0 && _dtMas.GetChanges() != null)
                //{
                //    //_htSave = _libSubjectMas.SaveData(Global.BranchID, Global.CompanyID, Global.UserName, Environment.MachineName, ref _dtMas, out ErrorMsg);
                //    if (ErrorMsg != null)
                //    {
                //        throw new Exception(ErrorMsg.ToString());
                //    }
                //}
                //else
                //{
                //    _htSave.Add("RESULT", "false");
                //}

                //if (_htSave["RESULT"].ToString().Trim() == "false")
                //{
                //    if (ErrorMsg != null)
                //    {
                //        throw new Exception(ErrorMsg.ToString());
                //    }
                //}
                return _htSave;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //_objReportMaster = null;
            }
        }
        #endregion
    }
}
