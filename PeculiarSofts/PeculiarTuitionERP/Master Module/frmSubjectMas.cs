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
        string[] strSubChkBxColName, strChpChkBxColName;
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
                    ValChpGrid = Global.ValidateGrid(this.grdChpDet, "ChpMas", _dtGridDescriptor.Select("CTRL_NAME = '" + this.grdChpDet.Name + "'").CopyToDataTable());
                    if (ValChpGrid["RESULT"].ToString() == "false")
                    {
                        saveFlg = false;
                        MessageBox.Show(string.Format("Following fields are Required" + grdChpDet.Columns[ValChpGrid["COLUMN"].ToString()].HeaderText));

                        if (grdChpDet != null && grdChpDet.CurrentCell != null && grdChpDet.CurrentCell.RowIndex != 0)
                        {
                            grdChpDet.CurrentCell = grdChpDet.Rows[grdChpDet.CurrentCell.RowIndex].Cells[ValChpGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdChpDet.Focus();
                            //grdChapterDetail.SetCurrentCell("PROC_ID", true);
                        }
                        return;
                    }
                    Hashtable ValSubGrid = new Hashtable();
                    ValSubGrid = Global.ValidateGrid(this.grdSubMas, "SubMas", _dtGridDescriptor.Select("CTRL_NAME = '" + this.grdSubMas.Name + "'").CopyToDataTable());
                    if (ValSubGrid["RESULT"].ToString() == "false")
                    {
                        saveFlg = false;
                        MessageBox.Show(string.Format("Following fields are Required" + grdSubMas.Columns[ValSubGrid["COLUMN"].ToString()].HeaderText));

                        if (grdSubMas != null && grdSubMas.CurrentCell != null && grdSubMas.CurrentCell.RowIndex != 0)
                        {
                            grdSubMas.CurrentCell = grdSubMas.Rows[grdSubMas.CurrentCell.RowIndex].Cells[ValSubGrid["COLUMN"].ToString()];
                        }
                        else
                        {
                            grdSubMas.Focus();
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
                grdSubMas.Select();
                grdSubMas.Focus();
                if (grdSubMas.Focused && grdSubMas.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdSubMas.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdSubMas.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdSubMas.Rows.Remove(_drMasRow);
                            else
                                _drMasRow.Selected = false;
                        }
                    }
                }
                else if (grdChpDet.Focused && grdChpDet.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Do you want to delete Record(s)?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        grdChpDet.AllowUserToDeleteRows = true;
                        foreach (DataGridViewRow _drMasRow in grdChpDet.SelectedRows)
                        {
                            if (_drMasRow.IsNewRow == false)
                                grdChpDet.Rows.Remove(_drMasRow);
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
                    grdSubMas.ReadOnly = true;
                    grdChpDet.ReadOnly = false;
                    grdSubMas.AllowUserToAddRows = false;
                    grdChpDet.AllowUserToAddRows = false;
                    btnMainPanel1.Select();
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                case "ADD":
                    grdSubMas.ReadOnly = false;
                    grdChpDet.ReadOnly = false;
                    grdSubMas.AllowUserToAddRows = true;
                    grdChpDet.AllowUserToAddRows = true;
                    grdSubMas.Focus();
                    grdSubMas.CurrentCell = grdSubMas.Rows[grdSubMas.Rows.Count - 1].Cells["SUB_ID"];
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    break;
                case "EDIT":
                    grdSubMas.AllowUserToAddRows = true;
                    grdChpDet.AllowUserToAddRows = true;
                    grdSubMas.ReadOnly = false;
                    grdChpDet.ReadOnly = false;
                    grdSubMas.Focus();
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    break;
                case "SAVE":
                    grdSubMas.ReadOnly = true;
                    grdChpDet.ReadOnly = true;
                    grdSubMas.AllowUserToAddRows = false;
                    grdChpDet.AllowUserToAddRows = false;
                    uti.SetPanelStatus(btnMainPanel1, "LOAD");
                    btnMainPanel1.Select();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Add);
                    break;
                case "SEARCH":
                    if (dsMain != null)
                    {
                        dsMain.Tables["SubMas"].Rows.Clear();
                        dsMain.Tables["ChpMas"].Rows.Clear();
                        dsMain.AcceptChanges();
                    }
                    grdSubMas.ReadOnly = false;
                    grdSubMas.AllowUserToAddRows = true;
                    grdChpDet.ReadOnly = false;
                    grdChpDet.AllowUserToAddRows = true;
                    grdSubMas.Focus();
                    grdSubMas.CurrentCell = grdSubMas.Rows[0].Cells["SUB_ID"];
                    grdSubMas.Rows[0].Cells["SUB_ID"].Value = DBNull.Value;
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    break;
                case "REFRESH":
                    grdSubMas.ReadOnly = true;
                    grdSubMas.AllowUserToAddRows = false;
                    grdChpDet.ReadOnly = true;
                    grdChpDet.AllowUserToAddRows = false;
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    btnMainPanel1.Select();
                    btnMainPanel1.SetFocus(ButtonPanelControl.Action.Edit);
                    break;
                case "CANCEL":
                    grdSubMas.AllowUserToAddRows = true;
                    grdChpDet.AllowUserToAddRows = true;
                    grdSubMas.ReadOnly = true;
                    grdSubMas.ReadOnly = true;
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

            dsMain = _libSubjectMas.FetchData("1=2", out ErrorMsg);
            if (!string.IsNullOrEmpty(ErrorMsg))
            {
                MessageBox.Show(ErrorMsg);
                return;
            }

            Global.AcquireGridCheckBoxColumn(_dtGridDescriptor.Select("CTRL_NAME = '" + grdSubMas.Name + "'").CopyToDataTable(), out strSubChkBxColName);
            Global.AcquireComboListWithSource(_dtGridDescriptor.Select("CTRL_NAME = '" + grdSubMas.Name + "'").CopyToDataTable(), out strSubCmbColName, out grdSubCmbCol);
            Global.GridBindingSource(ref grdSubMas, _dtGridDescriptor.Select("CTRL_NAME = '" + grdSubMas.Name + "'").CopyToDataTable(), strSubCmbColName == null ? null : strSubCmbColName, grdSubCmbCol == null ? null : grdSubCmbCol, strSubChkBxColName, dsMain.Tables["SubMas"]);

            Global.AcquireGridCheckBoxColumn(_dtGridDescriptor.Select("CTRL_NAME = '" + this.grdChpDet.Name + "'").CopyToDataTable(), out strChpChkBxColName);
            Global.AcquireComboListWithSource(_dtGridDescriptor.Select("CTRL_NAME = '" + this.grdChpDet.Name + "'").CopyToDataTable(), out strChpCmbColName, out grdChpCmbCol);
            Global.GridBindingSource(ref grdChpDet, _dtGridDescriptor.Select("CTRL_NAME = '" + this.grdChpDet.Name + "'").CopyToDataTable(), strChpCmbColName == null ? null : strChpCmbColName, grdChpCmbCol == null ? null : grdChpCmbCol, strChpChkBxColName == null ? null : strChpChkBxColName, dsMain.Tables["ChpMas"]);
            MapRelOverGrids();
            _strBtnActionType = "LOAD";
            getLibraryInstance("UTILITY");
            uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
            UpdateControlBehaviour();
        }

        private void MapRelOverGrids()
        {
            dsMain.Relations.Add("RelationDet", new DataColumn[] { dsMain.Tables["SubMas"].Columns["SUB_ID"] }, new DataColumn[] { dsMain.Tables["ChpMas"].Columns["REF_SUB_ID"] });

            grdSubMas.DataSource = dsMain;
            grdSubMas.DataMember = "SubMas";

            grdChpDet.DataSource = dsMain;
            grdChpDet.DataMember = "SubMas.RelationDet";

            dsMain.Tables["SubMas"].Columns["SUB_ID"].AutoIncrement = true;
            dsMain.Tables["SubMas"].Columns["SUB_ID"].AutoIncrementSeed = -1;
            dsMain.Tables["SubMas"].Columns["SUB_ID"].AutoIncrementStep = -1;

            dsMain.Tables["ChpMas"].Columns["SEQNO"].AutoIncrement = true;
            dsMain.Tables["ChpMas"].Columns["SEQNO"].AutoIncrementSeed = -1;
            dsMain.Tables["ChpMas"].Columns["SEQNO"].AutoIncrementStep = -1;

        }
        private Hashtable SaveData()
        {
            try
            {
                Hashtable _htSave = new Hashtable();
                if (dsMain.GetChanges() != null)
                {
                    getLibraryInstance("Subject");
                    _htSave = _libSubjectMas.SaveData(Global.LoginBranch, "RLT", Environment.MachineName.ToString(), ref dsMain, out ErrorMsg);
                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
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
