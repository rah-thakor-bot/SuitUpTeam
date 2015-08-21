﻿using System;
using System.Data;
using System.Collections;

namespace PeculiarTuitionBase.ExamBase
{
    public class ExamMaster : TuitionBase
    {
        public DataTable FetchData(string p_criteria, out string Error)
        {
            try
            {
                Error = string.Empty;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_exam_mas.prc_mas_get_data", _ds, "ExamMas", new string[] { p_criteria, null });
                return _ds.Tables["ExamMas"];
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
            int _intNumRecords = 0, tempExamID = 0;
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
                                _strInsertErrMsg += "Exam Id " + _drRow["EXAM_ID"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                tempExamID = int.Parse(_htSave["EXAM_ID"].ToString());
                            }
                            break;
                        case DataRowState.Modified:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Update(p_brid, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Exam Id. = " + _drRow["EXAM_ID"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strUpdateErrMsg += "Exam Id. = " + _drRow["EXAM_ID"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                tempExamID = int.Parse(_drRow["EXAM_ID"].ToString());
                            }
                            break;
                        case DataRowState.Deleted:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Delete(p_brid, p_user, p_terminal, _drRow);
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Exam Id. = " + _drRow["EXAM_ID", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strTimeStampErrMsg += "Exam Id. = " + _drRow["EXAM_ID", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            break;
                    }

                    DataRow[] _drRows = null;
                    if (_drRow.RowState != DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("EXAM_ID = " + _drRow["EXAM_ID"]);
                        if (_drRow.RowState == DataRowState.Added)
                        {
                            p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["EXAM_ID"] = tempExamID;
                        }
                        //p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["P_TIME_STAMP"].ToString();
                    }
                    if (_drRow.RowState == DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("EXAM_ID =" + _drRow["EXAM_ID", DataRowVersion.Original], "", DataViewRowState.Deleted);
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
                _base.AddInParam("p_branch", DbType.String, p_branch_id);
                _base.AddInParam("p_batch_id", DbType.Int32, Convert.ToInt32(p_dr["BATCH_ID"] == null ? 0 : p_dr["BATCH_ID"]));
                _base.AddInParam("p_ref_sub_id", DbType.Int32, Convert.ToInt32(p_dr["REF_SUB_ID"] == null ? 0 : p_dr["REF_SUB_ID"]));
                _base.AddInParam("p_total_mark", DbType.Int32, Convert.ToInt32(p_dr["TOTAL_MARK"] == null ? 0 : p_dr["TOTAL_MARK"]));
                _base.AddInParam("p_exam_type", DbType.Int32, Convert.ToInt32(p_dr["EXAM_TYPE"] == null ? 0 : p_dr["EXAM_TYPE"]));
                _base.AddInParam("p_type_det", DbType.String, p_dr["TYPE_DET"]);
                _base.AddInParam("p_paper_set_by", DbType.String, p_dr["PAPER_SET_BY"]);
                _base.AddInParam("p_exam_date", DbType.Date, p_dr["EXAM_DATE"]);
                _base.AddInParam("p_exam_time", DbType.String, p_dr["EXAM_TIME"]);
                _base.AddInParam("p_duration", DbType.String, p_dr["DURATION"]);
                _base.AddInParam("p_supervisor", DbType.String, p_dr["SUPERVISOR"]);
                _base.AddInParam("p_ent_user", DbType.String, p_user);
                _base.AddInParam("p_ent_term", DbType.String, p_term);
                //_base.AddOutParam("p_time_stamp", DbType.String, 50);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_exam_id", DbType.Int32, 5);
                _base.ExecSPWithTransaction("pkg_exam_mas.prc_mas_ins");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("EXAM_ID", _base.GetParameterValue("p_exam_id"));
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
                _base.AddInParam("p_branch", DbType.String, p_branch_id);
                _base.AddInParam("p_exam_id", DbType.String, p_dr["EXAM_ID"]);
                _base.AddInParam("p_batch_id", DbType.Int32, Convert.ToInt32(p_dr["BATCH_ID"] == null ? 0 : p_dr["BATCH_ID"]));
                _base.AddInParam("p_ref_sub_id", DbType.Int32, Convert.ToInt32(p_dr["REF_SUB_ID"] == null ? 0 : p_dr["REF_SUB_ID"]));
                _base.AddInParam("p_total_mark", DbType.Int32, Convert.ToInt32(p_dr["TOTAL_MARK"] == null ? 0 : p_dr["TOTAL_MARK"]));
                _base.AddInParam("p_exam_type", DbType.Int32, Convert.ToInt32(p_dr["EXAM_TYPE"] == null ? 0 : p_dr["EXAM_TYPE"]));
                _base.AddInParam("p_type_det", DbType.String, p_dr["TYPE_DET"]);
                _base.AddInParam("p_paper_set_by", DbType.String, p_dr["PAPER_SET_BY"]);
                _base.AddInParam("p_exam_date", DbType.Date, p_dr["EXAM_DATE"]);
                _base.AddInParam("p_exam_time", DbType.String, p_dr["EXAM_TIME"]);
                _base.AddInParam("p_duration", DbType.String, p_dr["DURATION"]);
                _base.AddInParam("p_supervisor", DbType.String, p_dr["SUPERVISOR"]);
                _base.AddInParam("p_upd_user", DbType.String, p_user);
                _base.AddInParam("p_upd_term", DbType.String, p_term);
                //_base.AddParameter("p_time_stamp", DbType.String, 50, ParameterDirection.InputOutput, p_dr["time_stamp"].ToString());
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.ExecSPWithTransaction("pkg_exam_mas.prc_mas_upd");

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
                _base.AddInParam("p_exam_id", DbType.Int32, Convert.ToInt32(p_dr["EXAM_ID", DataRowVersion.Original] == null ? 0 : p_dr["EXAM_ID", DataRowVersion.Original]));
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("pkg_exam_mas.prc_mas_del");

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
