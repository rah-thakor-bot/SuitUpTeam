using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Private.MyUserControls;
using PeculiarTuitionBase.MasterBase;
using PeculiarTuitionERP.Utility_Module;

namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmSubjectMas : frmBaseChild
    {
        #region Global Objects and Variable Declaration for Form

        private SubjectMas _libSubjectMas;
        private ChapterMas _libChpMas;
        private Utility uti;
        string _strFormType = string.Empty;
        string _strBtnActionType = string.Empty;
        string ErrorMsg = string.Empty;
        string[] strSubChkBxColName;
        string[] strSubCmbColName, strChpCmbColName;

        DataSet dsMain;
        DataTable _dtGridDescriptor;
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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonPanelControl1_btnAddClick(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonAddText == "&Add")
                {
                    _strBtnActionType = "ADD";
                    UpdateControlBehaviour();
                }
                else//Save Data 
                {
                    Hashtable ValChpGrid = new Hashtable();
                    bool saveFlg = true;
                    ValChpGrid = Global.ValidateGrid(this.grdChapterDetail, _dtGridDescriptor.Select("CTRL_NAME = '" + this.grdChapterDetail.Name + "'").CopyToDataTable());
                    if (ValChpGrid["RESULT"].ToString() == "false")
                    {
                        saveFlg = false;
                        MessageBox.Show(string.Format("Following fields are Required" + grdChapterDetail.Columns[ValChpGrid["COLUMN"].ToString()].HeaderText));

                        if (grdChapterDetail != null && grdChapterDetail.CurrentCell != null && grdChapterDetail.CurrentCell.RowIndex != 0)
                        {
                            grdChapterDetail.CurrentCell = grdChapterDetail.Rows[grdChapterDetail.CurrentCell.RowIndex].Cells[ValChpGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdChapterDetail.Focus();
                            //grdChapterDetail.SetCurrentCell("PROC_ID", true);
                        }
                        return;
                    }
                    Hashtable ValSubGrid = new Hashtable();
                    ValSubGrid = Global.ValidateGrid(this.grdSubjectMaster, _dtGridDescriptor.Select("CTRL_NAME = '" + this.grdSubjectMaster.Name + "'").CopyToDataTable());
                    if (ValSubGrid["RESULT"].ToString() == "false")
                    {
                        saveFlg = false;
                        MessageBox.Show(string.Format("Following fields are Required" + grdSubjectMaster.Columns[ValSubGrid["COLUMN"].ToString()].HeaderText));

                        if (grdSubjectMaster != null && grdSubjectMaster.CurrentCell != null && grdSubjectMaster.CurrentCell.RowIndex != 0)
                        {
                            grdSubjectMaster.CurrentCell = grdSubjectMaster.Rows[grdSubjectMaster.CurrentCell.RowIndex].Cells[ValSubGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdSubjectMaster.Focus();
                            //grdSubjectMaster.SetCurrentCell("PROC_ID", true);
                        }
                        return;
                    }
                    if (saveFlg)
                    {
                        Hashtable _htResult = new Hashtable();
                        _htResult = SaveData();
                        if (_htResult["RESULT"].ToString().Trim() == "true")
                        {
                            MessageBox.Show("Saved Succesfully.");
                            _strBtnActionType = "SAVE";
                            UpdateControlBehaviour();
                        }
                        else
                        {
                            //Global.Information(string.Format(Resources.EmptyOrNullException, "RPT_ID"), Resources.DialogText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonPanelControl1_btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPanelControl1_btnDeleteClick(object sender, EventArgs e)
        {
            _strBtnActionType = "DELETE";
            try
            {
                grdSubjectMaster.Select();
                grdSubjectMaster.Focus();
                if (grdSubjectMaster.Focused && grdSubjectMaster.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdSubjectMaster.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdSubjectMaster.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdSubjectMaster.Rows.Remove(_drMasRow);
                            else
                                _drMasRow.Selected = false;
                        }
                    }
                }
                else if (grdChapterDetail.Focused && grdChapterDetail.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdChapterDetail.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdChapterDetail.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdChapterDetail.Rows.Remove(_drMasRow);
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

        private void buttonPanelControl1_btnEditClick(object sender, EventArgs e)
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

        private void buttonPanelControl1_btnRefreshClick(object sender, EventArgs e)
        {
            _strBtnActionType = "REFRESH";
            //Build SearchCriteria and Get Data
            UpdateControlBehaviour();
            MapRelOverGrids();
        }

        private void buttonPanelControl1_btnSearchClick(object sender, EventArgs e)
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
        /// <summary>
        /// Update Control Behaviour for current button action
        /// </summary>
        private void UpdateControlBehaviour()
        {
            getLibraryInstance("UTILITY");
            switch (_strBtnActionType.ToUpper())
            {
                case "LOAD":
                    grdSubjectMaster.ReadOnly = true;
                    grdChapterDetail.ReadOnly = false;
                    grdSubjectMaster.AllowUserToAddRows = false;
                    grdChapterDetail.AllowUserToAddRows = false;
                    btnMainPanel1.Select();
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                case "ADD":
                    grdSubjectMaster.ReadOnly = false;
                    grdChapterDetail.ReadOnly = false;
                    grdSubjectMaster.AllowUserToAddRows = true;
                    grdChapterDetail.AllowUserToAddRows = true;
                    grdSubjectMaster.Focus();
                    grdSubjectMaster.CurrentCell = grdSubjectMaster.Rows[grdSubjectMaster.Rows.Count - 1].Cells["SUB_ID"];
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    break;
                case "EDIT":
                    grdSubjectMaster.AllowUserToAddRows = true;
                    grdChapterDetail.AllowUserToAddRows = true;
                    grdSubjectMaster.ReadOnly = false;
                    grdChapterDetail.ReadOnly = false;
                    grdSubjectMaster.Focus();
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    break;
                case "SAVE":
                    grdSubjectMaster.ReadOnly = true;
                    grdChapterDetail.ReadOnly = true;
                    grdSubjectMaster.AllowUserToAddRows = false;
                    grdChapterDetail.AllowUserToAddRows = false;
                    uti.SetPanelStatus(btnMainPanel1, "LOAD");
                    btnMainPanel1.Select();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                case "SEARCH":
                    if (dsMain != null)
                    {
                        dsMain.Tables.Clear();
                        dsMain.AcceptChanges();
                    }
                    grdSubjectMaster.ReadOnly = false;
                    grdSubjectMaster.AllowUserToAddRows = true;
                    grdChapterDetail.ReadOnly = false;
                    grdChapterDetail.AllowUserToAddRows = true;
                    grdSubjectMaster.Focus();
                    grdSubjectMaster.CurrentCell = grdSubjectMaster.Rows[0].Cells["SUB_ID"];
                    grdSubjectMaster.Rows[0].Cells["SUB_ID"].Value = DBNull.Value;
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    break;
                case "REFRESH":
                    grdSubjectMaster.ReadOnly = true;
                    grdSubjectMaster.AllowUserToAddRows = false;
                    grdChapterDetail.ReadOnly = true;
                    grdChapterDetail.AllowUserToAddRows = false;
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    btnMainPanel1.Select();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Edit);
                    break;
                case "CANCEL":
                    grdSubjectMaster.AllowUserToAddRows = true;
                    grdChapterDetail.AllowUserToAddRows = true;
                    grdSubjectMaster.ReadOnly = true;
                    grdSubjectMaster.ReadOnly = true;
                    uti.SetPanelStatus(btnMainPanel1, "LOAD");
                    btnMainPanel1.Focus();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                default:
                    MessageBox.Show("Form behavious is not set for following behaviuor" + _strBtnActionType);
                    break;
            }
        }

        private void getLibraryInstance(string objName)
        {
            if (objName.ToUpper() == "SUBJECT")
            {
                if (_libSubjectMas == null)
                    _libSubjectMas = new SubjectMas();
            }
            else if (objName.ToUpper() == "CHAPTER")
            {
                if (_libChpMas == null)
                    _libChpMas = new ChapterMas();
            }
            else if (objName.ToUpper() == "UTILITY")
            {
                if (uti == null)
                {
                    uti = new Utility();
                }
            }

        }
        private void LoadGrid()
        {

            getLibraryInstance("Subject");
            _dtGridDescriptor = _libSubjectMas.FetchGridFields(this.Tag.ToString(), null, out ErrorMsg);
            if (!string.IsNullOrEmpty(ErrorMsg))
            {
                MessageBox.Show(ErrorMsg);
                return;
            }

            dsMain = _libSubjectMas.FetchData("1=1", out ErrorMsg);
            if (!string.IsNullOrEmpty(ErrorMsg))
            {
                MessageBox.Show(ErrorMsg);
                return;
            }

            Global.AcquireGridCheckBoxColumn(_dtGridDescriptor.Select("CTRL_NAME = '" + grdSubjectMaster.Name + "'").CopyToDataTable(), out strSubChkBxColName);
            Global.AcquireComboListWithSource(_dtGridDescriptor.Select("CTRL_NAME = '" + grdSubjectMaster.Name + "'").CopyToDataTable(), out strSubCmbColName, out grdSubCmbCol);
            Global.GridBindingSource(ref grdSubjectMaster, _dtGridDescriptor.Select("CTRL_NAME = '" + grdSubjectMaster.Name + "'").CopyToDataTable(), null, null, strSubChkBxColName, dsMain.Tables["SubMas"]);

            //Global.AcquireGridCheckBoxColumn(_dtGridChapter, out strChpChkBxColName);
            Global.AcquireComboListWithSource(_dtGridDescriptor.Select("CTRL_NAME = '" + this.grpChapterDetail.Name + "'").CopyToDataTable(), out strChpCmbColName, out grdChpCmbCol);
            Global.GridBindingSource(ref this.grdChapterDetail, _dtGridDescriptor.Select("CTRL_NAME = '" + this.grpChapterDetail.Name + "'").CopyToDataTable(), strChpCmbColName, grdChpCmbCol, null, dsMain.Tables["ChpDet"]);
            MapRelOverGrids();
        }

        private void MapRelOverGrids()
        {
            dsMain.Relations.Add("RelationDet", new DataColumn[] { dsMain.Tables["SubMas"].Columns["SUB_ID"] }, new DataColumn[] { dsMain.Tables["ChpDet"].Columns["REF_SUB_ID"] });

            grdSubjectMaster.DataSource = dsMain;
            grdSubjectMaster.DataMember = "SubMas";

            grdChapterDetail.DataSource = dsMain;
            grdChapterDetail.DataMember = "SubMas.RelationDet";

            dsMain.Tables["SubMas"].Columns["SUB_ID"].AutoIncrement = true;
            dsMain.Tables["SubMas"].Columns["SUB_ID"].AutoIncrementSeed = -1;
            dsMain.Tables["SubMas"].Columns["SUB_ID"].AutoIncrementStep = -1;

            dsMain.Tables["ChpDet"].Columns["SEQNO"].AutoIncrement = true;
            dsMain.Tables["ChpDet"].Columns["SEQNO"].AutoIncrementSeed = -1;
            dsMain.Tables["ChpDet"].Columns["SEQNO"].AutoIncrementStep = -1;

        }
        private Hashtable SaveData()
        {
            try
            {
                Hashtable _htSave = new Hashtable();
                getLibraryInstance("Subject");

                return _htSave;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                //_objReportMaster = null;
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
    }
}
