using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PeculiarTuitionBase;
using PeculiarTuitionERP.Properties;

namespace PeculiarTuitionERP.Utility_Module
{
    
    /* Form Developer : Rahul Thakor
     * Start Date     : 16-06-2015 12:13 AM
     * Middle Layer   : TuitionBase.cs
     * Usage          : Maintain certain task with globaly declared variables
     */

    public static class Global
    {
        #region Class variable and declaration
        public static string LoginBranch;
        public static string DefaultUser;
        public static string LoginUser;
        private static TuitionBase _base;
        private static string ErrorMsg;
        private static string DateFormat = "dd/MM/yyyy";
        //Roboto font
        private static Font ROBOTO_MEDIUM_12;
        private static Font ROBOTO_REGULAR_11;
        private static Font ROBOTO_MEDIUM_11;
        private static Font ROBOTO_MEDIUM_10;
        #endregion

        #region Get Instances
        /// <summary>
        /// Get Base Instance
        /// </summary>
        private static void GetLibInstance()
        {
            if (_base == null)
                _base = new TuitionBase();
        }
        #endregion

        #region GetAllControls of Form
        public static List<Control> GetAllControls(IList ctrls)
        {
            List<Control> RetCtrls = new List<Control>();
            foreach (Control ctl in ctrls)
            {
                RetCtrls.Add(ctl);
                List<Control> SubCtrls = GetAllControls(ctl.Controls);
                RetCtrls.AddRange(SubCtrls);
            }
            return RetCtrls;
        }
        #endregion

        #region Disable all Controls
        public static void DisableControls(Control ctrl)
        {
            try
            {
                //List<Control> lstControls = Global.GetAllControls(((Form)ctrl).Controls);
                //Control lstButtonPanelControl = new Control();
                //lstButtonPanelControl = lstControls.Find(x => x.Parent.Name.Contains());
                //foreach (Control singleControl in lstButtonPanelControl.Controls)
                //{
                //    if ((singleControl.GetType() == typeof(Button)))
                //    {
                //        singleControl.Enabled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Grid Binding 

        #region Font Import Methods
        public static int FORM_PADDING = 14;
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);
        private static readonly PrivateFontCollection privateFontCollection = new PrivateFontCollection();
        private static FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }
        #endregion

        public static void GridBindingSource(ref DataGridView p_dgv,DataTable p_gridFields, string[] p_comboColName, DataGridViewComboBoxColumn[] p_comboBox, string[] p_checkBoxColName, DataTable p_dataSource)
        {
            try
            {
                #region Vaiable declaration and assignment
                string[] _strReadonlyCol, _strHideCol, _strVisibleCol, _strDecimalCol;
                int p_columnIndex = 0;
                _strReadonlyCol = _strHideCol = _strVisibleCol = _strDecimalCol = null;
                #endregion

                #region Initialize Grid
                p_dgv.Columns.Clear();
                p_dgv.AutoGenerateColumns = false;
                p_dgv.DataSource = (object)null;
                p_dgv.DataSource = (object)p_dataSource;
                #endregion

                #region Get Column Behaviour
                /*Get Column Behaviour------------>*/
                List<Object> getDCType = (from row in p_gridFields.AsEnumerable()
                                       select row["COL_TYPE"]).Distinct().ToList();
                Hashtable htPropertyMapping = new Hashtable();
                foreach (object type in getDCType)
                {
                    foreach (string typ in type.ToString().Split(','))
                    {
                        if (!(string.IsNullOrEmpty(typ)))
                        {
                            if (typ.ToString().Contains("READONLY") && (!(htPropertyMapping.Contains("READONLY"))))
                            {
                                htPropertyMapping.Add("READONLY", true);
                                _strReadonlyCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                            }

                            if (typ.ToString().Contains("HIDECOL") && (!(htPropertyMapping.Contains("HIDECOL"))))
                            {
                                htPropertyMapping.Add("HIDECOL", true);
                                _strHideCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                            }

                            if (typ.ToString().Contains("VISIBLECOL") && (!(htPropertyMapping.Contains("VISIBLECOL"))))
                            {
                                htPropertyMapping.Add("VISIBLECOL", true);
                                _strVisibleCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                            }

                            if (typ.ToString().Contains("DECIMALCOL") && (!(htPropertyMapping.Contains("DECIMALCOL"))))
                            {
                                htPropertyMapping.Add("DECIMALCOL", true);
                                _strDecimalCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                            }
                        }
                    }
                }
                /*Get Column Behaviour<------------*/
                #endregion

                #region Add columns to grid
                /*Add column to grid */
                foreach (DataColumn dataColumn in p_dataSource.Columns)
                {
                    bool flag1 = false;
                    DataGridViewTextBoxColumn viewTextBoxColumn = new DataGridViewTextBoxColumn();
                    bool flag2 = false;
                    if (_strHideCol != null)
                    {
                        if (FindElement(p_columnIndex.ToString(new NumberFormatInfo()), _strHideCol) != -1)
                            flag1 = true;
                        else if (FindElement(dataColumn.ColumnName.ToString(), _strHideCol) != -1)
                            flag1 = true;
                    }
                    if (p_comboColName != null)
                    {
                        int element = FindElement(dataColumn.ColumnName.ToString(), p_comboColName);
                        if (element != -1)
                        {
                            p_comboBox[element].DataPropertyName = dataColumn.ColumnName.ToString();
                            p_comboBox[element].HeaderText = dataColumn.ColumnName.ToString();
                            p_comboBox[element].Name = dataColumn.ColumnName.ToString();
                            p_comboBox[element].ReadOnly = false;
                            p_comboBox[element].DropDownWidth = 60;
                            p_comboBox[element].DefaultCellStyle.BackColor = Color.White;
                            p_comboBox[element].DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                            if (_strReadonlyCol != null)
                            {
                                if (FindElement(p_columnIndex.ToString(), _strReadonlyCol) != -1)
                                {
                                    p_comboBox[element].ReadOnly = true;
                                    //p_comboBox[element].DefaultCellStyle.BackColor = this.SetReadOnlyColBgColor;
                                }
                                else if (FindElement(dataColumn.ColumnName.ToString(), _strReadonlyCol) != -1)
                                {
                                    //p_comboBox[element].DefaultCellStyle.BackColor = this.SetReadOnlyColBgColor;
                                    p_comboBox[element].ReadOnly = true;
                                }
                            }
                            if (flag1)
                                p_comboBox[element].Visible = false;
                            p_dgv.Columns.Add(p_comboBox[element]);
                            p_comboBox[element].SortMode = DataGridViewColumnSortMode.Programmatic;
                            flag2 = true;
                        }
                    }

                    if (p_checkBoxColName != null)
                    {
                        int element = FindElement(dataColumn.ColumnName.ToString(), p_checkBoxColName);
                        if (element != -1)
                        {
                            DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
                            viewCheckBoxColumn.TrueValue = (object)"Y";
                            viewCheckBoxColumn.FalseValue = (object)"N";
                            viewCheckBoxColumn.DataPropertyName = p_checkBoxColName[element].ToString();
                            viewCheckBoxColumn.Name = p_checkBoxColName[element].ToString();
                            viewCheckBoxColumn.ReadOnly = false;
                            viewCheckBoxColumn.DefaultCellStyle.BackColor = Color.White;
                            viewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                            if (flag1)
                                viewCheckBoxColumn.Visible = false;
                            if (_strReadonlyCol != null)
                            {
                                if (FindElement(p_columnIndex.ToString(), _strReadonlyCol) != -1)
                                {
                                    viewCheckBoxColumn.ReadOnly = true;
                                }
                                else if (FindElement(dataColumn.ColumnName.ToString(), _strReadonlyCol) != -1)
                                {
                                    viewCheckBoxColumn.ReadOnly = true;
                                }
                            }
                            p_dgv.Columns.Add(viewCheckBoxColumn);
                            flag2 = true;
                        }
                    }

                    if (!flag2)
                    {
                        //bool flag3 = false;
                        viewTextBoxColumn.ReadOnly = false;
                        viewTextBoxColumn.DefaultCellStyle.BackColor = Color.White;
                        viewTextBoxColumn.DataPropertyName = dataColumn.ColumnName.ToString();
                        viewTextBoxColumn.HeaderText = dataColumn.ColumnName.ToString();
                        if (_strReadonlyCol != null)
                        {
                            if (FindElement(p_columnIndex.ToString(), _strReadonlyCol) != -1)
                            {
                                //viewTextBoxColumn.DefaultCellStyle.BackColor = this.SetReadOnlyColBgColor;
                                viewTextBoxColumn.ReadOnly = true;
                                //flag3 = true;
                            }
                            else if (FindElement(dataColumn.ColumnName.ToString(), _strReadonlyCol) != -1)
                            {
                                //viewTextBoxColumn.DefaultCellStyle.BackColor = this.SetReadOnlyColBgColor;
                                viewTextBoxColumn.ReadOnly = true;
                                //flag3 = true;
                            }
                        }
                        //bool flag4 = false;
                        //bool flag5 = false;
                        //bool flag6 = false;
                        
                        if (dataColumn.DataType.ToString() == "System.DateTime")
                        {
                            //DataGridViewColumn dgvc = new DataGridViewColumn();
                            viewTextBoxColumn.DataPropertyName = dataColumn.ColumnName.ToString();
                            viewTextBoxColumn.DefaultCellStyle.BackColor = Color.White;
                            viewTextBoxColumn.Name = dataColumn.ColumnName.ToString();
                            viewTextBoxColumn.HeaderText = dataColumn.ColumnName.ToString();
                            viewTextBoxColumn.ValueType = typeof(DateTime);
                            //p_dgv.Columns.Add(viewTextBoxColumn);
                            //++p_columnIndex;
                            //continue;
                            #region Commented by Rahul Thakor
                            //DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
                            ////DataGridViewColumn dataGridViewColumn2 = this._dateColumnStyle != LTPLGridView.DateColumnStyle.Mask ? (DataGridViewColumn)new LTPLDateTimePickerColumn() : (DataGridViewColumn)new LTPLMaskedTextBoxColumn();
                            //if (FindElement(p_columnIndex.ToString(), this._strTimeCol) != -1)
                            //    flag5 = true;
                            //else if (FindElement(dataColumn.ColumnName.ToString(), this._strTimeCol) != -1)
                            //    flag5 = true;
                            //else if (FindElement(p_columnIndex.ToString(), this._strDateTimeCol) != -1)
                            //    flag4 = true;
                            //else if (FindElement(dataColumn.ColumnName.ToString(), this._strDateTimeCol) != -1)
                            //    flag4 = true;
                            //else
                            //    flag6 = true;
                            //if (flag6)
                            //{
                            //    dataGridViewColumn2.DataPropertyName = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.Name = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.HeaderText = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.ValueType = typeof(DateTime);
                            //    if (this._dateColumnStyle == LTPLGridView.DateColumnStyle.Mask)
                            //    {
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).TimeCol = false;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).DateTimeCol = false;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).Mask = dateMask;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).DateFormat = this._strDateFormat;
                            //    }
                            //    else
                            //        ((LTPLDateTimePickerColumn)dataGridViewColumn2).CustomFormat = this._strDateFormat;
                            //    if (this._htColValidation.ContainsKey((object)dataColumn.ColumnName.ToString().ToUpper()))
                            //        this._htColValidation.Remove((object)dataColumn.ColumnName.ToString().ToUpper());
                            //    this._htColValidation.Add((object)dataColumn.ColumnName.ToString().ToUpper(), (object)"Date");
                            //}
                            //else if (flag5)
                            //{
                            //    dataGridViewColumn2.DataPropertyName = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.Name = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.HeaderText = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.ValueType = typeof(DateTime);
                            //    if (this._dateColumnStyle == LTPLGridView.DateColumnStyle.Mask)
                            //    {
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).DateTimeCol = false;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).TimeCol = true;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).DateTimeCol = false;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).Mask = timeMask;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).TimeFormat = this._strTimeFormat;
                            //    }
                            //    else
                            //        ((LTPLDateTimePickerColumn)dataGridViewColumn2).CustomFormat = this._strTimeFormat;
                            //}
                            //else if (flag4)
                            //{
                            //    dataGridViewColumn2.DataPropertyName = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.Name = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.HeaderText = dataColumn.ColumnName.ToString();
                            //    dataGridViewColumn2.ValueType = typeof(DateTime);
                            //    if (this._dateColumnStyle == LTPLGridView.DateColumnStyle.Mask)
                            //    {
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).DateTimeCol = true;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).TimeCol = false;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).Mask = dateMask + " " + timeMask;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).DateFormat = this._strDateFormat;
                            //        ((LTPLMaskedTextBoxColumn)dataGridViewColumn2).TimeFormat = this._strTimeFormat;
                            //    }
                            //    else
                            //        ((LTPLDateTimePickerColumn)dataGridViewColumn2).CustomFormat = this._strDateFormat + " " + this._strTimeFormat;
                            //}
                            //dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
                            //if (flag3)
                            //{
                            //    dataGridViewColumn2.ReadOnly = true;
                            //    dataGridViewColumn2.DefaultCellStyle.BackColor = this.SetReadOnlyColBgColor;
                            //}
                            //this.Columns.Add(dataGridViewColumn2);
                            //if (flag1)
                            //    dataGridViewColumn2.Visible = false;
                            //if (this._htColWidth.Contains((object)dataColumn.ColumnName.ToString().ToUpper()))
                            //    this.Columns[dataColumn.ColumnName].Width = int.Parse(this._htColWidth[(object)dataColumn.ColumnName.ToUpper()].ToString(), (IFormatProvider)NumberFormatInfo.CurrentInfo);
                            //else if (this._htColWidth.Contains((object)p_columnIndex))
                            //    this.Columns[p_columnIndex].Width = int.Parse(this._htColWidth[(object)p_columnIndex].ToString(), (IFormatProvider)NumberFormatInfo.CurrentInfo);
                            //++p_columnIndex;
                            //continue;
                            #endregion
                        }
                        viewTextBoxColumn.Name = p_dataSource.Columns[p_columnIndex].ColumnName;
                        p_dgv.Columns.Add(viewTextBoxColumn);
                    }
                    ++p_columnIndex;
                }
                #endregion

                #region Assign Column Behaviour
                /*Assign Column Behaviour------------>*/
                List<object> assignDCType = (from row in p_gridFields.AsEnumerable()
                              select row["COL_TYPE"]).Distinct().ToList();
                foreach (object type in assignDCType)
                {
                    foreach (string typ in type.ToString().Split(','))
                    {
                        if (!(string.IsNullOrEmpty(typ)))
                        {
                            if (typ.ToString().Contains("READONLY"))
                            {
                                //_strReadonlyCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                                //Set Readonly 
                                if (_strReadonlyCol != null)
                                {
                                    foreach (string ColName in _strReadonlyCol)
                                    {
                                        p_dgv.Columns[ColName].ReadOnly = true;
                                    }
                                }
                            }
                            if (typ.ToString().Contains("HIDECOL"))
                            {
                                //_strHideCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                                //Set Hide Columns
                                if (_strHideCol != null)
                                {
                                    foreach (string ColName in _strHideCol)
                                    {
                                        p_dgv.Columns[ColName].Visible = false;
                                    }
                                }
                            }
                            if (typ.ToString().Contains("VISIBLECOL"))
                            {
                                //_strVisibleCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                                //Set Visible Columns
                                if (_strVisibleCol != null)
                                {
                                    foreach (string ColName in _strVisibleCol)
                                    {
                                        p_dgv.Columns[ColName].Visible = true;
                                    }
                                }
                            }
                            if (typ.ToString().Contains("DECIMALCOL"))
                            {
                                //_strDecimalCol = GetColumnBehaviour(p_gridFields, typ.ToString().ToUpper());
                                //Set Decimal Columns
                                if (_strDecimalCol != null)
                                {
                                    foreach (string ColName in _strDecimalCol)
                                    {
                                        p_dgv.Columns[ColName].ReadOnly = true;
                                    }
                                }
                            }
                        }
                    }
                }
                /*Assign Column Behaviour<------------*/
                #endregion

                #region Manange Row&Column style
                foreach (DataRow rowValues in p_gridFields.Rows)
                {
                    p_dgv.Columns[rowValues["DATA_FIELD_NAME"].ToString().Trim()].HeaderText = rowValues["DISP_NAME"].ToString();
                    p_dgv.Columns[rowValues["DATA_FIELD_NAME"].ToString().Trim()].Width = Int32.Parse(rowValues["FIELD_SIZE"].ToString());
                }

                foreach (DataGridViewColumn dgvc in p_dgv.Columns)
                {
                    dgvc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvc.HeaderCell.Style.Font = new Font("Arial", 10F,FontStyle.Bold, GraphicsUnit.Point);
                }
                #endregion

                #region Set grid properties

                p_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                p_dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                p_dgv.BackgroundColor = Color.BlanchedAlmond;
                DataGridViewCellStyle dgv_cellStyle = new DataGridViewCellStyle();
                
                dgv_cellStyle.BackColor = Color.Azure;
                ROBOTO_MEDIUM_12 = new Font(LoadFont(Resources.Roboto_Medium), 12f);
                ROBOTO_MEDIUM_10 = new Font(LoadFont(Resources.Roboto_Medium), 10f);
                ROBOTO_REGULAR_11 = new Font(LoadFont(Resources.Roboto_Regular), 11f);
                ROBOTO_MEDIUM_11 = new Font(LoadFont(Resources.Roboto_Medium), 11f);
                dgv_cellStyle.Font = ROBOTO_MEDIUM_10;

                p_dgv.DefaultCellStyle = dgv_cellStyle;
                p_dgv.RowTemplate.Height = 28;

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "[Assign DataSource]");
            }
            finally
            {
            }
        }
        #endregion

        #region Check for Required Col in Grid
        public static Hashtable ValidateGrid(DataGridView CtrlGrid,DataTable gridProperty)
        {
            try
            {
                Hashtable hashtable = new Hashtable();
                if (CtrlGrid != null)
                {
                    DataTable changes = ((DataTable)CtrlGrid.DataSource).GetChanges();
                    string[] requiredCol = GetColumnBehaviour(gridProperty, "REQUIRED");
                    if (changes != null && requiredCol != null)
                    {
                        foreach (DataRow row in (InternalDataCollectionBase)changes.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                for (int index = 0; index < requiredCol.Length; ++index)
                                {
                                    if (changes.Columns.Contains(requiredCol[index].ToString().Trim()) && string.IsNullOrEmpty(row[requiredCol[index].ToString().Trim()].ToString().Trim()))
                                    {
                                        hashtable.Add((object)"RESULT", (object)"false");
                                        hashtable.Add((object)"COLUMN", (object)CtrlGrid.Columns[requiredCol[index].Trim()].Name);
                                        int num = ((DataTable)CtrlGrid.DataSource).Rows.IndexOf(row);
                                        hashtable.Add((object)"ROW", (object)num);
                                        return hashtable;
                                    }
                                }
                            }
                        }
                    }
                }
                if (hashtable.Count == 0 || CtrlGrid == null)
                    hashtable.Add((object)"RESULT", (object)"true");
                return hashtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Hashtable ValidateGrid(DataGridView CtrlGrid, string DataTableName, DataTable gridProperty)
        {
            try
            {
                Hashtable hashtable = new Hashtable();
                if (CtrlGrid != null)
                {
                    DataTable changes = ((DataSet)CtrlGrid.DataSource).Tables[DataTableName].GetChanges();
                    string[] requiredCol = GetColumnBehaviour(gridProperty, "REQUIRED");
                    if (changes != null && requiredCol != null)
                    {
                        for (int index1 = 0; index1 < changes.Rows.Count; ++index1)
                        {
                            if (changes.Rows[index1].RowState != DataRowState.Deleted)
                            {
                                for (int index2 = 0; index2 < requiredCol.Length; ++index2)
                                {
                                    if (changes.Columns.Contains(requiredCol[index2].ToString().Trim()) && string.IsNullOrEmpty(changes.Rows[index1][requiredCol[index2].ToString().Trim()].ToString().Trim()))
                                    {
                                        hashtable.Add((object)"RESULT", (object)"false");
                                        hashtable.Add((object)"COLUMN", (object)CtrlGrid.Columns[requiredCol[index2].ToString().Trim()].Name);
                                        return hashtable;
                                    }
                                }
                            }
                        }
                    }
                }
                if (hashtable.Count == 0 || CtrlGrid == null)
                    hashtable.Add((object)"RESULT", (object)"true");
                return hashtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get column behaviour method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dt"></param>
        /// <param name="p_getBehaviourType"></param>
        /// <returns></returns>
        private static string[] GetColumnBehaviour(DataTable p_dt,string p_getBehaviourType)
        {
            int index = p_dt.Select("COL_TYPE LIKE '%" + p_getBehaviourType + "%'").Length;
            string[] strList = null;
            if (index > 0)
            {
                strList = new string[index];
                try
                {
                    int i = 0;
                    foreach (DataRow dr in p_dt.Select("COL_TYPE LIKE '%" + p_getBehaviourType + "%'"))
                    {
                        if (dr["COL_TYPE"].ToString().Contains(p_getBehaviourType))
                        {
                            strList[i] = dr["DATA_FIELD_NAME"].ToString();
                            ++i;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
            }
            return strList;
        }
        #endregion

        #region Acquire Grid Columns with Type
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridFields">Table Data from Grid_fields</param>
        /// <param name="colType">Readonly,Hidecol,Required</param>
        /// <param name="outputColList">Output String Array</param>
        public static void AcquireGridColListWithType(DataTable gridFields,string colType, out string[] outputColList)
        {
            outputColList = null;
            try
            {
                int index = 0;
                string[] getColList = new string[gridFields.Select("COL_TYPE = '" + colType + "'").Length];
                foreach (DataRow dr in gridFields.Select("COL_TYPE = '" + colType + "'"))
                {
                    getColList[index] = dr["DATA_FIELD_NAME"].ToString();
                    index++;
                }
                outputColList = getColList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Acquire Combolist with source for grid
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridFields"></param>
        /// <param name="CmbColName"></param>
        /// <param name="CmbCol"></param>
        public static void AcquireComboListWithSource(DataTable gridFields,out string[] CmbColName, out DataGridViewComboBoxColumn[] CmbCol)
        {

            CmbCol = null;
            CmbColName = null;
            int arrLength = gridFields.Select("COL_TYPE = 'CMBBX'").Length;
            if (arrLength > 0)
            {
                DataGridViewComboBoxColumn[] localCmbCol = new DataGridViewComboBoxColumn[arrLength];
                string[] localCmbColName = new string[arrLength];
                
                try
                {
                    int index = 0;
                    DataTable _dtBindingSource;
                    foreach (DataRow dr in gridFields.Select("COL_TYPE = 'CMBBX'"))
                    {
                        switch (dr["COMBO_FLG"].ToString())
                        {
                            case "ACTSTD"://Get Active Std List for Combo Fill up
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.GetStdList(out ErrorMsg, p_branch_id: LoginBranch);//Called With Default Parameters
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "STD_NAME";
                                    temp.ValueMember = "STD_ID";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "ACTSUB":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.GetSubjectList(null, out ErrorMsg, p_active_flg: string.Empty);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "SUB_NAME";
                                    temp.ValueMember = "SUB_ID";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "STDTYPE":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.GetStdType(out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "DISP_OPTION";
                                    temp.ValueMember = "VALUE_MEMBER";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "STDMED":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.GetStdMedium(out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "DISP_OPTION";
                                    temp.ValueMember = "VALUE_MEMBER";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "TEACHER":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.GetTeacherList(p_active_flg: string.Empty, Error: out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "DISP_OPTION";
                                    temp.ValueMember = "VALUE_MEMBER";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "STATIC":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.FetchStaticCombo(dr["REMARK"].ToString(), out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "DISP_MEM";
                                    temp.ValueMember = "VALUE_MEM";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "BATCH":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.FetchBatchList(p_active_flg: string.Empty, Error: out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "DISP_MEM";
                                    temp.ValueMember = "VALUE_MEM";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "EXAM":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.GetExamList(p_exam_flg: string.Empty, Error: out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "EXAM_ID";
                                    temp.ValueMember = "EXAM_ID";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "EMPTYPE":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.FetchEntityType(p_flg: string.Empty, Error: out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "DISP_MEM";
                                    temp.ValueMember = "VALUE_MEM";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            case "ACTEMP":
                                GetLibInstance();
                                using (_dtBindingSource = new DataTable())
                                {
                                    _dtBindingSource = _base.GetEmpList(p_entity_type:null, p_is_active: string.Empty, Error: out ErrorMsg);
                                    if (!(string.IsNullOrWhiteSpace(ErrorMsg))) throw new Exception(ErrorMsg);
                                    DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
                                    temp.DataSource = _dtBindingSource.Copy();
                                    temp.DisplayMember = "ENTITY_NAME";
                                    temp.ValueMember = "ENTITY_ID";
                                    localCmbColName[index] = dr["DATA_FIELD_NAME"].ToString();
                                    localCmbCol[index] = temp;
                                    ++index;
                                }
                                break;
                            default:
                                throw new Exception("Combo flag not set. [Combobind Method]");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    CmbCol = localCmbCol;
                    CmbColName = localCmbColName;
                }
            }
        }
        #endregion

        #region Acquire grid Checkbox Col list
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grdFields"></param>
        /// <param name="ChkBxName"></param>
        /// <param name="ChkBx"></param>
        public static void AcquireGridCheckBoxColumn(DataTable grdFields,out string[] ChkBxName)
        {
            ChkBxName = null;
            int arrLength = grdFields.Select("COL_TYPE = 'CHKBX'").Length;
            if (arrLength > 0)
            {
                string[] localChkbxName = new string[arrLength];
                int index = 0;
                try
                {
                    foreach (DataRow dr in grdFields.Select("COL_TYPE = 'CHKBX'"))
                    {
                        localChkbxName[index] = dr["DATA_FIELD_NAME"].ToString();
                        ++index;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    ChkBxName = localChkbxName;
                }
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_element"></param>
        /// <param name="p_col"></param>
        /// <returns></returns>

        #endregion

        #region Find element in string
        ///
        private static int FindElement(string p_element, string[] p_col)
        {
            try
            {
                if (p_col == null)
                    return -1;
                for (int index = 0; index < p_col.Length; ++index)
                {
                    if (p_col[index].Trim().Equals(p_element.Trim(), StringComparison.OrdinalIgnoreCase))
                        return index;
                }
                return -1;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message + "[FindElement Method]");
                return -1;
            }
        }
        #endregion
    }
}
