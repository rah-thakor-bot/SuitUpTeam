using System;
using System.Data;
using System.Collections;

namespace PeculiarTuitionBase.MasterBase
{
    public class SubjectMas : TuitionBase
    {
        public DataSet FetchData(string p_criteria,out string Error)
        {
            try
            {
                Error = string.Empty;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_sub_mas.prc_mas_get_data", _ds, new string[] { "SubMas", "ChpMas" }, new string[] { p_criteria, null, null });
                return _ds;
            }
            catch (Exception ex)
            {
                Error = ex.HelpLink.ToString();
            }
            finally
            {
                _base.Disconnect();
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_brid"></param>
        /// <param name="p_coid"></param>
        /// <param name="p_user"></param>
        /// <param name="p_terminal"></param>
        /// <param name="p_ds"></param>
        /// <param name="p_err"></param>
        /// <returns></returns>
        
        public Hashtable SaveData(string p_brid, string p_user, string p_terminal, ref DataSet p_ds, out string p_err)
        {
            #region variable Declaration
            
            int _intNumRecords = 0, _intSubID = 0;
            string _strCriteria = string.Empty;
            string _strErrMsg = "";
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
                DataTable _dtMas = p_ds.Tables["SubMas"].GetChanges();
                //DataTable _dtDet = p_ds.Tables["ChpMas"].GetChanges();
                if (_dtMas != null)
                {
                    foreach (DataRow _drRow in _dtMas.Rows)
                    {
                        switch (_drRow.RowState)
                        {
                            case DataRowState.Added:
                                _base.BeginTransaction(IsolationLevel.ReadCommitted);
                                _htSave = Add(p_brid, p_user, p_terminal, _drRow);

                                if (_htSave["p_flg"].ToString().ToUpper() == "N")
                                {
                                    _strInsertErrMsg += "Subject Id " + _drRow["SUB_ID"].ToString() + "";
                                    _base.Rollback();
                                    continue;
                                }
                                else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                                {
                                    _intSubID = int.Parse(_htSave["p_sub_id"].ToString());
                                    //Inset Update Detele for Child Records
                                    SaveChapterData(p_brid, _intSubID, int.Parse(_drRow["SUB_ID"].ToString()), p_user, p_terminal, ref p_ds, out p_err);

                                }
                                break;
                            case DataRowState.Modified:
                                _base.BeginTransaction(IsolationLevel.ReadCommitted);
                                _htSave = Update(p_brid, p_user, p_terminal, _drRow);

                                if (_htSave["p_flg"].ToString().ToUpper() == "T")
                                {
                                    _strTimeStampErrMsg += "Subject Id. = " + _drRow["SUB_ID"].ToString() + "";
                                    _base.Rollback();
                                    continue;
                                }
                                else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                                {
                                    _strUpdateErrMsg += "Subject Id. = " + _drRow["SUB_ID"].ToString() + "";
                                    _base.Rollback();
                                    continue;
                                }
                                else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                                {
                                    _intSubID = int.Parse(_drRow["SUB_ID"].ToString());
                                    //Inset Update Detele for Child Records
                                    SaveChapterData(p_brid, _intSubID, int.Parse(_drRow["SUB_ID"].ToString()), p_user, p_terminal, ref p_ds, out p_err);
                                }
                                break;
                            case DataRowState.Deleted:
                                _base.BeginTransaction(IsolationLevel.ReadCommitted);

                                _htSave = Delete(p_brid, p_user, p_terminal, _drRow);
                                if (_htSave["p_flg"].ToString().ToUpper() == "T")
                                {
                                    _strTimeStampErrMsg += "Subject Id. = " + _drRow["SUB_ID", DataRowVersion.Original].ToString() + "";
                                    _base.Rollback();
                                    continue;
                                }
                                else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                                {
                                    _strTimeStampErrMsg += "Subject Id. = " + _drRow["SUB_ID", DataRowVersion.Original].ToString() + "";
                                    _base.Rollback();
                                    continue;
                                }
                                break;
                        }
                        _strCriteria = "";
                        DataRow[] _drRows = null;
                        if (_drRow.RowState != DataRowState.Deleted)
                        {
                            _drRows = p_ds.Tables["SubMas"].Select("SUB_ID = " + _drRow["SUB_ID"]);
                            if (_drRow.RowState == DataRowState.Added)
                            {
                                p_ds.Tables["SubMas"].Rows[p_ds.Tables["SubMas"].Rows.IndexOf(_drRows[0])]["SUB_ID"] = _intSubID;
                            }
                            //p_ds.Tables["SubMas"].Rows[p_ds.Tables["SubMas"].Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["P_TIME_STAMP"].ToString();
                        }
                        if (_drRow.RowState == DataRowState.Deleted)
                        {
                            _drRows = p_ds.Tables["SubMas"].Select("SUB_ID =" + _drRow["SUB_ID", DataRowVersion.Original], "", DataViewRowState.Deleted);
                        }
                        p_ds.Tables["SubMas"].Rows[p_ds.Tables["SubMas"].Rows.IndexOf(_drRows[0])].AcceptChanges();
                        _intNumRecords += 1;
                        _base.Commit();
                    }
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

        private Hashtable SaveChapterData(string p_brid, int p_sub_id, int p_seq_no, string p_user, string p_terminal, ref DataSet p_ds, out string p_err)
        {
            #region variable Declaration
            int _intNumRecords = 0, _intSeqno = 0;
            string _strCriteria = string.Empty;
            string _strErrMsg = "";
            string _strTimeStampErrMsg = TimestampMsg;
            string _strInsertErrMsg = InsertMessage; ;
            string _strUpdateErrMsg = UpdateMessage;
            string _strDeleteErrMsg = DeleteMessage;
            //string _strDeleteErrMsg = "Record can't deleted due to child record exist : \n";

            p_err = null;
            Hashtable _htSave = new Hashtable();
            _htSave.Add("TIMESTAMP", _strErrMsg);
            #endregion
            try
            {
                _base.Connect();
                DataTable _dtMas = p_ds.Tables["ChpMas"].GetChanges();
                foreach (DataRow _drRow in _dtMas.Rows)
                {
                    switch (_drRow.RowState)
                    {
                        case DataRowState.Added:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = AddChpDet(p_brid, p_user, p_sub_id, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strInsertErrMsg += "Seqno " + _drRow["SEQNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                _intSeqno = int.Parse(_htSave["p_seqno"].ToString());
                            }
                            break;
                        case DataRowState.Modified:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = UpdateDet(p_brid, p_sub_id, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Seqno. = " + _drRow["SEQNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strUpdateErrMsg += "Seqno. = " + _drRow["SEQNO"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                _intSeqno = int.Parse(_drRow["SEQNO"].ToString());
                            }
                            break;
                        case DataRowState.Deleted:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);

                            _htSave = DeleteDet(p_brid, p_user, p_terminal, _drRow);
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Seqno. = " + _drRow["SEQNO", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strTimeStampErrMsg += "Seqno. = " + _drRow["SEQNO", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            break;
                    }
                    _strCriteria = "";
                    DataRow[] _drRows = null;
                    if (_drRow.RowState != DataRowState.Deleted)
                    {
                        _drRows = p_ds.Tables["ChpMas"].Select("seqno = " + _drRow["SEQNO"]);
                        if (_drRow.RowState == DataRowState.Added)
                        {
                            p_ds.Tables["ChpMas"].Rows[p_ds.Tables["ChpMas"].Rows.IndexOf(_drRows[0])]["SEQNO"] = _intSeqno;
                        }
                        //p_ds.Tables["ChpMas"].Rows[p_ds.Tables["ChpMas"].Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["P_TIME_STAMP"].ToString();
                    }
                    if (_drRow.RowState == DataRowState.Deleted)
                    {
                        _drRows = p_ds.Tables["ChpMas"].Select("seqno =" + _drRow["SEQNO", DataRowVersion.Original], "", DataViewRowState.Deleted);
                    }
                    p_ds.Tables["ChpMas"].Rows[p_ds.Tables["ChpMas"].Rows.IndexOf(_drRows[0])].AcceptChanges();
                    _intNumRecords += 1;
                    //_base.Commit();
                }

                if (_strTimeStampErrMsg != "Timestamp  Error : \n")
                    _strErrMsg = _strTimeStampErrMsg + "\n \n";

                if (_strInsertErrMsg != "Problem In Inserting Record : \n")
                    _strErrMsg = _strInsertErrMsg + "\n \n";

                if (_strUpdateErrMsg != "Problem In Updating Record : \n")
                    _strErrMsg = _strUpdateErrMsg + "\n \n";

                if (_strDeleteErrMsg != "Record can't deleted due to child record exist : \n")
                    _strErrMsg = _strDeleteErrMsg + "\n \n";


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
                //Do not disconnect..
            }
            return _htSave;
        }

        private Hashtable Add(string p_brid, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htAdd = new Hashtable();
            try
            {
                _base.AddInParam("p_branch", DbType.String, p_brid);
                _base.AddInParam("p_ref_std_id", DbType.String, p_dr["REF_STD_ID"]);
                _base.AddInParam("p_sub_name", DbType.String, p_dr["SUB_NAME"]);
                _base.AddInParam("p_have_exam", DbType.String, p_dr["HAVE_EXAM"].ToString() == "" ? "N" : p_dr["HAVE_EXAM"].ToString());
                _base.AddInParam("p_is_active", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());
                _base.AddInParam("p_ent_user", DbType.String, p_user);
                _base.AddInParam("p_ent_term", DbType.String, p_term);
                //_base.AddOutParam("p_time_stamp", DbType.String, 50);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_sub_id", DbType.Int64, 6);

                _base.ExecSPWithTransaction("pkg_sub_mas.prc_mas_ins");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("p_sub_id", _base.GetParameterValue("p_sub_id"));
                //_htAdd.Add("P_TIME_STAMP", _base.GetParameterValue("p_time_stamp"));
                return _htAdd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Hashtable Update(string p_brid,  string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htUpd = new Hashtable();
            try
            {
                _base.AddInParam("p_branch", DbType.String, p_brid);
                _base.AddInParam("p_ref_std_id", DbType.Int32, p_dr["REF_STD_ID"]);
                _base.AddInParam("p_sub_id", DbType.Int32, p_dr["SUB_ID"]);
                _base.AddInParam("p_sub_name", DbType.String, p_dr["SUB_NAME"]);
                _base.AddInParam("p_have_exam", DbType.String, p_dr["HAVE_EXAM"].ToString() == "" ? "N" : p_dr["HAVE_EXAM"].ToString());
                _base.AddInParam("p_is_active", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());

                _base.AddInParam("p_upd_user", DbType.String, p_user);
                _base.AddInParam("p_upd_term", DbType.String, p_term);
                //_base.AddParameter("p_time_stamp", DbType.String, 50, ParameterDirection.InputOutput, p_dr["time_stamp"].ToString());
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);


                _base.ExecSPWithTransaction("pkg_sub_mas.prc_mas_upd");

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
                _base.AddInParam("p_branch", DbType.String, p_brid);
                _base.AddInParam("p_sub_id", DbType.Int32, p_dr["SUB_ID", DataRowVersion.Original]);
                //_base.AddInParam("p_time_stamp", DbType.String, p_dr["time_stamp", DataRowVersion.Original]);

                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("pkg_sub_mas.prc_mas_del");

                _htDel.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htDel.Add("p_msg", _base.GetParameterValue("p_msg"));

                return _htDel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Hashtable AddChpDet(string p_brid, string p_user,int p_sub_id, string p_term, DataRow p_dr)
        {
            Hashtable _htAdd = new Hashtable();
            try
            {
                _base.AddInParam("p_ref_sub_id", DbType.String, p_sub_id);
                _base.AddInParam("p_chp_id", DbType.Int32, p_dr["CHP_ID"]);
                _base.AddInParam("p_chp_name", DbType.String, p_dr["CHP_NAME"]);
                _base.AddInParam("p_description", DbType.String, p_dr["DESCRIPTION"]);
                _base.AddInParam("p_remark", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("p_ent_user", DbType.String, p_user);
                _base.AddInParam("p_ent_term", DbType.String, p_term);
                //_base.AddOutParam("p_time_stamp", DbType.String, 50);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_seqno", DbType.Int64, 6);

                _base.ExecSPWithTransaction("PKG_CHP_DET.PRC_MAS_INS");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("p_seqno", _base.GetParameterValue("p_seqno"));
                ///_htAdd.Add("p_time_stamp", _base.GetParameterValue("p_time_stamp"));
                return _htAdd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Hashtable UpdateDet(string p_brid,int p_ref_sub_id, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htUpd = new Hashtable();
            try
            {
                _base.AddInParam("p_ref_sub_id", DbType.Int32, p_ref_sub_id);
                _base.AddInParam("p_seqno", DbType.Int32, p_dr["SEQNO"]);
                _base.AddInParam("p_chp_id", DbType.Int32, p_dr["CHP_ID"]);
                _base.AddInParam("p_chp_name", DbType.String, p_dr["CHP_NAME"]);
                _base.AddInParam("p_description", DbType.String, p_dr["DESCRIPTION"]);
                _base.AddInParam("p_remark", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("p_upd_user", DbType.String, p_user);
                _base.AddInParam("p_upd_term", DbType.String, p_term);
                //_base.AddParameter("P_TIME_STAMP", DbType.String, 50, ParameterDirection.InputOutput, p_dr["time_stamp"].ToString());
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);

                _base.ExecSPWithTransaction("pkg_chp_det.prc_mas_upd");

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

        private Hashtable DeleteDet(string p_brid, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htDel = new Hashtable();
            try
            {
                _base.Connect();
                _base.AddInParam("p_brid", DbType.String, p_brid);
                _base.AddInParam("p_seqno", DbType.Int32, p_dr["SEQNO", DataRowVersion.Original]);
                //_base.AddInParam("p_time_stamp", DbType.String, p_dr["time_stamp", DataRowVersion.Original]);

                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("pkg_chp_det.prc_mas_del");

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
