using System;
using System.Data;
using System.Windows.Forms;
using Private.MyUserControls;

namespace PeculiarTuitionERP.Utility_Module
{
    public class Utility
    {
        public void SetPanelStatus(ButtonPanelControl  _ctrl,bool _add,bool _edit,bool _delete,bool _search,bool _refresh,bool _close )
        {
            _ctrl.ButtonAddEnable = _add;
            _ctrl.ButtonEditEnable = _edit;
            _ctrl.ButtonDeleteEnable = _delete;
            _ctrl.ButtonSearchEnable = _search;
            _ctrl.ButtonRefreshEnable = _refresh;
            _ctrl.ButtonCloseEnable = _close;
        }

        public void SetPanelStatus(ButtonPanelControl _ctrl, string _btnAction)
        {
            switch (_btnAction.ToUpper())
            {
                case "LOAD":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = false;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    SetButtonPanelText(_ctrl, _btnAction);
                    break;
                case "ADD":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = true;
                    _ctrl.ButtonDeleteEnable = true;
                    _ctrl.ButtonSearchEnable = false;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    SetButtonPanelText(_ctrl, _btnAction);
                    
                    break;
                case "EDIT":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = true;
                    _ctrl.ButtonDeleteEnable = true;
                    _ctrl.ButtonSearchEnable = false;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    SetButtonPanelText(_ctrl, _btnAction);
                    break;
                case "CANCEL":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = false;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = false;
                    SetButtonPanelText(_ctrl, _btnAction);
                    break;
                case "SAVE":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = false;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    SetButtonPanelText(_ctrl, _btnAction);
                    break;
                case "SEARCH":
                    _ctrl.ButtonAddEnable = false;
                    _ctrl.ButtonEditEnable = true;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = false;
                    _ctrl.ButtonRefreshEnable = true;
                    _ctrl.ButtonCloseEnable = true;
                    SetButtonPanelText(_ctrl, _btnAction);
                    break;
                case "REFRESH":
                    _ctrl.ButtonAddEnable = false;
                    _ctrl.ButtonEditEnable = true;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    SetButtonPanelText(_ctrl, _btnAction);
                    break;
            }
        }

        public void SetButtonPanelText(ButtonPanelControl Ctrl, string ActionMode)
        {
            switch (ActionMode.ToUpper())
            {
                case "LOAD":
                    Ctrl.ButtonAddText = "&Add";
                    Ctrl.ButtonEditText = "&Edit";
                    Ctrl.ButtonSearchText = "Sea&rch";
                    break;
                case "ADD":
                case "EDIT":
                    Ctrl.ButtonAddText = "&Save";
                    Ctrl.ButtonEditText = "&Cancel";
                    break;
                case "SAVE":
                    Ctrl.ButtonAddText = "&Add";
                    Ctrl.ButtonEditText = "&Edit";
                    break;
                case "DELETE":
                    break;
                case "SEARCH":
                    Ctrl.ButtonEditText = "&Cancel";
                    break;
                case "REFRESH":
                    Ctrl.ButtonAddText = "&Add";
                    Ctrl.ButtonEditText = "&Edit";
                    Ctrl.ButtonSearchText = "Sea&rch";
                    break;
            }
            }

        public string GetGridCriteria(Control Ctrl)
        {
            string criteria = string.Empty;
            bool andFlag = false;
            if (Ctrl.GetType() == typeof(DataGridView))
            {
                DataTable gridSource = new DataTable();
                gridSource = (DataTable)((DataGridView)Ctrl).DataSource;
                if (gridSource.Rows.Count > 0)
                {
                    foreach (DataGridViewColumn dc in ((DataGridView)Ctrl).Columns)
                    {
                        if (dc.GetType() == typeof(DataGridViewTextBoxColumn))
                        {
                            if (!(string.IsNullOrEmpty(((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString())))
                            {
                                if (!andFlag)
                                {
                                    criteria += dc.DataPropertyName + " = '" + ((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString() + "'";
                                    andFlag = true;
                                }
                                else
                                    criteria += " and " + dc.DataPropertyName + " = '" + ((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString() + "'";
                            }
                        }
                        if (dc.GetType() == typeof(DataGridViewComboBoxColumn))
                        {
                            if (!(string.IsNullOrEmpty(((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString())))
                            {
                                if (!andFlag)
                                {
                                    criteria += dc.DataPropertyName + " = " + ((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString() + "";
                                    andFlag = true;
                                }
                                else
                                {
                                    criteria += "and " + dc.DataPropertyName + " = " + ((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString() + "";
                                }
                            }
                        }
                        if (dc.GetType() == typeof(DataGridViewCheckBoxColumn))
                        {
                            if (!(string.IsNullOrEmpty(((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString())))
                            {
                                if (!andFlag)
                                {
                                    criteria += dc.DataPropertyName + " = '" + ((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString() + "'";
                                    andFlag = true;
                                }
                                else
                                {
                                    criteria += "and " + dc.DataPropertyName + " = '" + ((DataGridView)Ctrl).Rows[0].Cells[dc.DataPropertyName].Value.ToString() + "'";
                                }
                            }
                        }
                    }
                }
                else
                {

                }
            }
            return criteria;
        }
    }
}
