using System;
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
            switch (_btnAction)
            {
                case "LOAD":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = false;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    break;
                case "ADD":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = true;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = false;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    break;
                case "EDIT":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = true;
                    _ctrl.ButtonDeleteEnable = true;
                    _ctrl.ButtonSearchEnable = false;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    break;
                case "CANCEL":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = false;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = false;
                    break;
                case "SAVE":
                    _ctrl.ButtonAddEnable = true;
                    _ctrl.ButtonEditEnable = false;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = true;
                    break;
                case "SEARCH":
                    _ctrl.ButtonAddEnable = false;
                    _ctrl.ButtonEditEnable = false;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = false;
                    _ctrl.ButtonRefreshEnable = true;
                    _ctrl.ButtonCloseEnable = true;
                    break;
                case "REFRESH":
                    _ctrl.ButtonAddEnable = false;
                    _ctrl.ButtonEditEnable = true;
                    _ctrl.ButtonDeleteEnable = false;
                    _ctrl.ButtonSearchEnable = true;
                    _ctrl.ButtonRefreshEnable = false;
                    _ctrl.ButtonCloseEnable = false;
                    break;
            }
        }
    }
}
