using System;
using System.Data;
using System.Collections;

namespace PeculiarTuitionBase.ExamBase
{
    public class ResultMaster : TuitionBase
    {
        public DataTable FetchData(string p_criteria, out string Error)
        {
            try
            {
                Error = string.Empty;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_result_mas.prc_mas_get_data", _ds, "ResultMas", new string[] { p_criteria, null });
                return _ds.Tables["ResultMas"];
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
            int _intNumRecords = 0, tempSrno = 0;
            string _strErrMsg = string.Empty;
            string _strTimeStampErrMsg = TimestampMsg;
            string _strInsertErrMsg = InsertMessage; ;
            string _strUpdateErrMsg = UpdateMessage;
            string _strDeleteErrMsg = DeleteMessage;
            
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
                                _strInsertErrMsg += "Exam Id " + _drRow["SRNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                tempSrno = int.Parse(_htSave["SRNO"].ToString());
                            }
                            break;
                        case DataRowState.Modified:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Update(p_brid, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Srno. = " + _drRow["SRNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strUpdateErrMsg += "Srno. = " + _drRow["SRNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                tempSrno = int.Parse(_drRow["SRNO"].ToString());
                            }
                            break;
                        case DataRowState.Deleted:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Delete(p_brid, p_user, p_terminal, _drRow);
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Srno. = " + _drRow["SRNO", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strTimeStampErrMsg += "Srno. = " + _drRow["SRNO", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            break;
                    }

                    DataRow[] _drRows = null;
                    if (_drRow.RowState != DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("SRNO = " + _drRow["SRNO"]);
                        if (_drRow.RowState == DataRowState.Added)
                        {
                            p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["SRNO"] = tempSrno;
                        }
                        //p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["P_TIME_STAMP"].ToString();
                    }
                    if (_drRow.RowState == DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("SRNO =" + _drRow["SRNO", DataRowVersion.Original], "", DataViewRowState.Deleted);
                    }
                    p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])].AcceptChanges();
                    _intNumRecords++;
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
                _base.AddInParam("p_exam_id", DbType.Int32, Convert.ToInt32(p_dr["EXAM_ID"] == null ? 0 : p_dr["EXAM_ID"]));
                _base.AddInParam("p_entity_id", DbType.Int32, Convert.ToInt32(p_dr["ENTITY_ID"] == null ? 0 : p_dr["ENTITY_ID"]));
                _base.AddInParam("p_entity_type_id", DbType.Int32, Convert.ToInt32(p_dr["ENTITY_TYPE_ID"] == null ? 0 : p_dr["ENTITY_TYPE_ID"]));
                _base.AddInParam("p_score", DbType.String, p_dr["SCORE"]);
                _base.AddInParam("p_remark", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("p_ent_user", DbType.String, p_user);
                _base.AddInParam("p_ent_term", DbType.String, p_term);
                //_base.AddOutParam("p_time_stamp", DbType.String, 50);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_srno", DbType.Int32, 5);
                _base.ExecSPWithTransaction("pkg_result_mas.prc_mas_ins");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("SRNO", _base.GetParameterValue("p_srno"));
                //_htAdd.Add("p_time_stamp", _base.GetParameterValue("p_time_stamp"));
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
                _base.AddInParam("p_srno", DbType.String, p_dr["SRNO"]);
                _base.AddInParam("p_exam_id", DbType.Int32, Convert.ToInt32(p_dr["EXAM_ID"] == null ? 0 : p_dr["EXAM_ID"]));
                _base.AddInParam("p_entity_id", DbType.Int32, Convert.ToInt32(p_dr["ENTITY_ID"] == null ? 0 : p_dr["ENTITY_ID"]));
                _base.AddInParam("p_entity_type_id", DbType.Int32, Convert.ToInt32(p_dr["ENTITY_TYPE_ID"] == null ? 0 : p_dr["ENTITY_TYPE_ID"]));
                _base.AddInParam("p_score", DbType.String, p_dr["SCORE"]);
                _base.AddInParam("p_remark", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("p_upd_user", DbType.String, p_user);
                _base.AddInParam("p_upd_term", DbType.String, p_term);
                //_base.AddParameter("p_time_stamp", DbType.String, 50, ParameterDirection.InputOutput, p_dr["time_stamp"].ToString());
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.ExecSPWithTransaction("pkg_result_mas.prc_mas_upd");

                _htUpd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htUpd.Add("p_msg", _base.GetParameterValue("p_msg"));
                //_htUpd.Add("p_time_stamp", _base.GetParameterValue("p_time_stamp"));

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
                _base.AddInParam("p_srno", DbType.Int32, Convert.ToInt32(p_dr["SRNO", DataRowVersion.Original] == null ? 0 : p_dr["SRNO", DataRowVersion.Original]));
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("pkg_result_mas.prc_mas_del");

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
