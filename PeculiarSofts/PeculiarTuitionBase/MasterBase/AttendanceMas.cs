using System;
using System.Collections;
using System.Data;

namespace PeculiarTuitionBase.MasterBase
{
    public class AttendanceMas : TuitionBase
    {
        public DataTable FetchData(string p_criteria, out string Error)
        {
            try
            {
                Error = string.Empty;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_study_level_mas.prc_get_data", _ds, "AttendanceMas", new string[] { p_criteria, null });
                return _ds.Tables["AttendanceMas"];
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
                                _strInsertErrMsg += "Std Id " + _drRow["SEQNO"].ToString() + "";
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
                                _strTimeStampErrMsg += "Std Id. = " + _drRow["SEQNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strUpdateErrMsg += "Std Id. = " + _drRow["SEQNO"].ToString() + "";
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
                                _strTimeStampErrMsg += "Std Id. = " + _drRow["SEQNO", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strTimeStampErrMsg += "Std Id. = " + _drRow["SEQNO", DataRowVersion.Original].ToString() + "";
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
                        //p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["P_TIME_STAMP"].ToString();
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
                _base.AddInParam("p_branch_id", DbType.String, p_branch_id);
                _base.AddInParam("p_std_level", DbType.Int32, Convert.ToInt32(p_dr["STD_LEVEL"].ToString()));
                _base.AddInParam("p_std_med", DbType.String, p_dr["STD_MEDIUM"]);
                _base.AddInParam("p_std_type", DbType.String, p_dr["STD_TYPE"]);
                _base.AddInParam("p_std_name", DbType.String, p_dr["STD_NAME"]);
                _base.AddInParam("p_is_active", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());
                _base.AddInParam("p_ent_user", DbType.String, p_user);
                _base.AddInParam("p_ent_term", DbType.String, p_term);
                _base.AddOutParam("p_time_stamp", DbType.String, 50);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_std_id", DbType.Int32, 5);
                _base.ExecSPWithTransaction("pkg_study_level_mas.prc_mas_ins");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("SEQNO", _base.GetParameterValue("p_std_id"));
                _htAdd.Add("p_time_stamp", _base.GetParameterValue("p_time_stamp"));
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
                _base.AddInParam("p_branch_id", DbType.String, p_branch_id);
                _base.AddInParam("p_std_id", DbType.Int32, p_dr["SEQNO"]);
                _base.AddInParam("p_std_level", DbType.Int32, Convert.ToInt32(p_dr["STD_LEVEL"].ToString()));
                _base.AddInParam("p_std_med", DbType.String, p_dr["STD_MEDIUM"]);
                _base.AddInParam("p_std_type", DbType.String, p_dr["STD_TYPE"]);
                _base.AddInParam("p_std_name", DbType.String, p_dr["STD_NAME"]);
                _base.AddInParam("p_is_active", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());
                _base.AddInParam("p_upd_user", DbType.String, p_user);
                _base.AddInParam("p_upd_term", DbType.String, p_term);
                _base.AddOutParam("p_time_stamp", DbType.String, 50);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);

                _base.ExecSPWithTransaction("pkg_study_level_mas.prc_mas_upd");

                _htUpd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htUpd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htUpd.Add("p_time_stamp", _base.GetParameterValue("p_time_stamp"));

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
                _base.AddInParam("p_std_id", DbType.String, p_dr["SEQNO", DataRowVersion.Original]);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("pkg_study_level_mas.prc_mas_del");

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
