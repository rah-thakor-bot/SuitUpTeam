using System;
using System.Data;
using System.Collections;

namespace PeculiarTuitionBase.Super
{
    public class GridFields : TuitionBase
    {
        public GridFields() : base()
        {

        }
        public DataTable FetchData(string p_criteria, out string Error)
        {
            try
            {
                Error = string.Empty;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("PKG_GRIDFIELD_MAS.prc_mas_get_data", _ds, "GridFieldsMas", new string[] { p_criteria, null });
                return _ds.Tables["GridFieldsMas"];
            }
            catch (Exception ex)
            {
                Error = ex.Message.ToString();
            }
            finally
            {
                _base.Disconnect();
            }
            return null;
        }

        public Hashtable SaveData(string p_brid, string p_user, string p_terminal, ref DataTable p_dt, out string p_err)
        {
            #region variable Declaration
            int _intNumRecords = 0, _intStdID = 0;
            

            p_err = null;
            Hashtable _htSave = new Hashtable();
            _htSave.Add("TIMESTAMP", _strErrMsg);

            #endregion
            try
            {
                _base.Connect();
                DataTable _dtMas = p_dt.GetChanges();

                foreach (DataRow _drRow in _dtMas.Rows)
                {
                    switch (_drRow.RowState)
                    {
                        case DataRowState.Added:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Add(p_brid, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strInsertErrMsg += "Seqno Id " + _drRow["SEQNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                _intStdID = int.Parse(_htSave["SEQNO"].ToString());
                            }
                            break;
                        case DataRowState.Modified:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Update(p_brid, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Seqno  = " + _drRow["SEQNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strUpdateErrMsg += "Seqno  = " + _drRow["SEQNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                _intStdID = int.Parse(_drRow["SEQNO"].ToString());
                            }
                            break;
                        case DataRowState.Deleted:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);

                            _htSave = Delete(p_brid, p_user, p_terminal, _drRow);
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Seqno  = " + _drRow["SEQNO", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strTimeStampErrMsg += "Seqno  = " + _drRow["SEQNO", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            break;
                    }

                    DataRow[] _drRows = null;
                    if (_drRow.RowState != DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("SEQNO = " + _drRow["SEQNO"]);
                        if (_drRow.RowState == DataRowState.Added)
                        {
                            p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["SEQNO"] = _intStdID;
                        }
                        //Set TimeStamp
                    }
                    if (_drRow.RowState == DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("SEQNO =" + _drRow["SEQNO", DataRowVersion.Original], "", DataViewRowState.Deleted);
                    }
                    p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])].AcceptChanges();
                    _intNumRecords += 1;
                    _base.Commit();
                }

                GetTransactionSummary(_strInsertErrMsg, _strUpdateErrMsg, _strDeleteErrMsg, _strTimeStampErrMsg, out _strErrMsg);

                _htSave.Add("RESULT", "true");
                _htSave["TIMESTAMP"] = _strErrMsg;
                _htSave["SAVERECORD"] = _intNumRecords;

            }
            catch (Exception ex)
            {
                _base.Rollback();
                p_err = ex.Message.ToString();
                //Throws(ex, out p_err);
            }
            finally
            {
                _base.Disconnect();
            }
            return _htSave;
        }

        private Hashtable Add(string p_branch_id, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htAdd = new Hashtable();
            try
            {
                _base.AddInParam("p_menu_name", DbType.String, p_dr["MENU_NAME"]);
                _base.AddInParam("p_ctrl_name", DbType.String, p_dr["CTRL_NAME"]);
                _base.AddInParam("p_data_field_name", DbType.String, p_dr["DATA_FIELD_NAME"].ToString().ToUpper());
                _base.AddInParam("p_field_size", DbType.Int32, Convert.ToInt32(p_dr["FIELD_SIZE"].ToString()));
                _base.AddInParam("p_disp_name", DbType.String, p_dr["DISP_NAME"].ToString());
                _base.AddInParam("p_col_type", DbType.String, p_dr["COL_TYPE"]);
                _base.AddInParam("p_combo_flg", DbType.String, p_dr["COMBO_FLG"]);
                _base.AddInParam("p_combo_bind_id", DbType.String, Convert.ToInt32(p_dr["COMBO_BIND_ID"].ToString()));
                _base.AddInParam("p_excel_field_name", DbType.String, p_dr["EXCEL_FIELD_NAME"]);
                _base.AddInParam("p_remark", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("p_extra_remark", DbType.String, p_dr["EXTRA_REMARK"]);
                _base.AddInParam("p_ord", DbType.Int32, Convert.ToInt32(p_dr["ORD"].ToString()));
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_seqno", DbType.Int32, 5);
                _base.ExecSPWithTransaction("pkg_gridfield_mas.prc_mas_ins");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("SEQNO", _base.GetParameterValue("P_SEQNO"));
                return _htAdd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Hashtable Update(string p_branch_id, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htUpd = new Hashtable();
            try
            {
                _base.AddInParam("p_seqno", DbType.Int32, Convert.ToInt32(p_dr["SEQNO"].ToString()));
                _base.AddInParam("p_menu_name", DbType.String, p_dr["MENU_NAME"]);
                _base.AddInParam("p_ctrl_name", DbType.String, p_dr["CTRL_NAME"]);
                _base.AddInParam("p_data_field_name", DbType.String, p_dr["DATA_FIELD_NAME"].ToString().ToUpper());
                _base.AddInParam("p_field_size", DbType.Int32, Convert.ToInt32(p_dr["FIELD_SIZE"].ToString()));
                _base.AddInParam("p_disp_name", DbType.String, p_dr["DISP_NAME"].ToString());
                _base.AddInParam("p_col_type", DbType.String, p_dr["COL_TYPE"]);
                _base.AddInParam("p_combo_flg", DbType.String, p_dr["COMBO_FLG"]);
                _base.AddInParam("p_combo_bind_id", DbType.String, Convert.ToInt32(p_dr["COMBO_BIND_ID"].ToString()));
                _base.AddInParam("p_excel_field_name", DbType.String, p_dr["EXCEL_FIELD_NAME"]);
                _base.AddInParam("p_remark", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("p_extra_remark", DbType.String, p_dr["EXTRA_REMARK"]);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);

                _base.ExecSPWithTransaction("pkg_gridfield_mas.prc_mas_upd");

                _htUpd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htUpd.Add("p_msg", _base.GetParameterValue("p_msg"));
                return _htUpd;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private Hashtable Delete(string p_brid, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htDel = new Hashtable();
            try
            {
                _base.Connect();
                _base.AddInParam("p_branch_id", DbType.String, p_brid);
                _base.AddInParam("p_seqno", DbType.String, p_dr["SEQNO", DataRowVersion.Original]);

                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("pkg_gridfield_mas.prc_mas_del");

                _htDel.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htDel.Add("p_msg", _base.GetParameterValue("p_msg"));

                return _htDel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
