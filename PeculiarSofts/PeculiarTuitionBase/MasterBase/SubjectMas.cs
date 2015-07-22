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
                _base.PopulateDataWithCmd("PKG_SUB_MAS.prc_mas_get_data", _ds, new string[] { "SubMas", "ChpDet" }, new string[] { p_criteria, null, null });
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
        public Hashtable SaveData(string p_brid, string p_coid, string p_user, string p_terminal, ref DataSet p_ds, out string p_err)
        {
            #region variable Declaration
            int _intNumRecords = 0, _intRptId = 0;
            string _strCriteria = "", _strItem = "";
            string _strErrMsg = "";
            string _strTimeStampErrMsg = "Timestamp  Error : \n";
            string _strInsertErrMsg = "Problem In Inserting Record : \n";
            string _strUpdateErrMsg = "Problem In Updating Record : \n";
            string _strDeleteErrMsg = "Record can't deleted due to child record exist : \n";

            p_err = null;
            string p_flg = null;
            Hashtable _htSave = new Hashtable();
            _htSave.Add("TIMESTAMP", _strErrMsg);
            DataRow[] _drArr = null;
            #endregion
            try
            {
                _base.Connect();
                DataTable _dtMas = p_ds.Tables["OP_RPT_MAS"].GetChanges();
                DataTable _dtDet = p_ds.Tables["OP_RPT_DET"].GetChanges();
                DataTable _dtParaDet = p_ds.Tables["OP_RPT_PARA_DET"].GetChanges();

                foreach (DataRow _drRow in _dtMas.Rows)
                {
                    switch (_drRow.RowState)
                    {
                        case DataRowState.Added:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Add(p_brid, p_coid, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strInsertErrMsg += "Report Id " + _drRow["RPT_ID"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                _intRptId = int.Parse(_htSave["p_rpt_id"].ToString());
                            }
                            break;
                        case DataRowState.Modified:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Update(p_brid, p_coid, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Report Id. = " + _drRow["RPT_ID"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strUpdateErrMsg += "Report Id. = " + _drRow["RPT_ID"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                _intRptId = int.Parse(_drRow["RPT_ID"].ToString());
                            }
                            break;
                        case DataRowState.Deleted:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);

                            _htSave = Delete(p_brid, p_coid, p_user, p_terminal, _drRow);
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Report Id. = " + _drRow["RPT_ID", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strTimeStampErrMsg += "Report Id. = " + _drRow["RPT_ID", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            break;
                    }
                    _strCriteria = "";
                    DataRow[] _drRows = null;
                    if (_drRow.RowState != DataRowState.Deleted)
                    {
                        _drRows = p_ds.Tables["OP_RPT_MAS"].Select("RPT_ID = " + _drRow["RPT_ID"]);
                        if (_drRow.RowState == DataRowState.Added)
                        {
                            p_ds.Tables["OP_RPT_MAS"].Rows[p_ds.Tables["OP_RPT_MAS"].Rows.IndexOf(_drRows[0])]["RPT_ID"] = _intRptId;
                        }
                        p_ds.Tables["OP_RPT_MAS"].Rows[p_ds.Tables["OP_RPT_MAS"].Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["P_TIME_STAMP"].ToString();
                    }
                    if (_drRow.RowState == DataRowState.Deleted)
                    {
                        _drRows = p_ds.Tables["OP_RPT_MAS"].Select("RPT_ID =" + _drRow["RPT_ID", DataRowVersion.Original], "", DataViewRowState.Deleted);
                    }
                    p_ds.Tables["OP_RPT_MAS"].Rows[p_ds.Tables["OP_RPT_MAS"].Rows.IndexOf(_drRows[0])].AcceptChanges();
                    _intNumRecords += 1;
                    _base.Commit();
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
                //Throws(ex, out p_err);
            }
            finally
            {
                _base.Disconnect();
            }
            return _htSave;
        }

        private Hashtable Add(string p_brid, string p_coid, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htAdd = new Hashtable();
            try
            {
                _base.AddInParam("P_BRID", DbType.String, p_brid);
                _base.AddInParam("P_COID", DbType.String, p_coid);
                _base.AddInParam("P_RPT_NAME", DbType.String, p_dr["RPT_NAME"]);
                _base.AddInParam("P_RPT_SHORT_NAME", DbType.String, p_dr["RPT_SHORT_NAME"]);
                _base.AddInParam("P_MFG_CODE", DbType.String, p_dr["MFG_CODE"]);
                _base.AddInParam("P_NO_OF_TIME", DbType.Int32, p_dr["NO_OF_TIME"]);
                _base.AddInParam("P_PROC_FLG", DbType.String, p_dr["PROC_FLG"].ToString() == "" ? "N" : p_dr["PROC_FLG"].ToString());
                _base.AddInParam("P_PARA_FLG", DbType.String, p_dr["PARA_FLG"].ToString() == "" ? "N" : p_dr["PARA_FLG"].ToString());
                _base.AddInParam("P_RPT_GRP", DbType.String, p_dr["RPT_GRP"].ToString() == "" ? "N" : p_dr["RPT_GRP"].ToString());
                _base.AddInParam("P_EXP_POL_FLG", DbType.String, p_dr["EXP_POL_FLG"].ToString() == "" ? "N" : p_dr["EXP_POL_FLG"].ToString());
                _base.AddInParam("P_REP_FLG", DbType.String, p_dr["REP_FLG"].ToString() == "" ? "N" : p_dr["REP_FLG"].ToString());
                _base.AddInParam("P_SELF_OP_FLG", DbType.String, p_dr["SELF_OP_FLG"].ToString() == "" ? "N" : p_dr["SELF_OP_FLG"].ToString());
                _base.AddInParam("P_PROC_TYPE", DbType.String, p_dr["PROC_TYPE"]);
                _base.AddInParam("P_PROC_ID", DbType.Int32, p_dr["PROC_ID"]);
                _base.AddInParam("P_IS_ACTIVE", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());
                //_base.AddInParam("P_EXP_POL_FLG", DbType.String, p_dr["EXP_POL_FLG"]);
                _base.AddInParam("P_COMP_AT", DbType.String, p_dr["COMP_AT"]);
                _base.AddInParam("P_OP_TYPE", DbType.String, p_dr["OP_TYPE"].ToString() == "" ? "N" : p_dr["OP_TYPE"].ToString());
                _base.AddInParam("P_EXP_POL_FLG1", DbType.String, p_dr["EXP_POL_FLG1"].ToString() == "" ? "N" : p_dr["EXP_POL_FLG1"].ToString());
                _base.AddInParam("P_IS_THIRD_OP", DbType.String, p_dr["IS_THIRD_OP"].ToString() == "" ? "N" : p_dr["IS_THIRD_OP"].ToString());
                _base.AddInParam("P_MUL_PLN_FLG", DbType.String, p_dr["MUL_PLN_FLG"].ToString() == "" ? "N" : p_dr["IS_THIRD_OP"].ToString());
                _base.AddInParam("P_ALLOW_TO", DbType.String, p_dr["ALLOW_TO"].ToString() == "" ? "N" : p_dr["IS_THIRD_OP"].ToString());
                _base.AddInParam("P_GRP", DbType.String, p_dr["GRP"]);
                _base.AddInParam("P_ORD", DbType.Int32, p_dr["ORD"]);
                _base.AddInParam("P_FLG1", DbType.String, p_dr["FLG1"]);
                _base.AddInParam("P_REMARK", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("P_ENT_USER", DbType.String, p_user);
                _base.AddInParam("P_ENT_TERM", DbType.String, p_term);
                _base.AddInParam("p_comma_sp_flg", DbType.String, p_dr["COMMA_SP_FLG"].ToString() == "" ? null : p_dr["COMMA_SP_FLG"].ToString());
                _base.AddOutParam("P_TIME_STAMP", DbType.String, 50);
                _base.AddOutParam("P_MSG", DbType.String, 50);
                _base.AddOutParam("P_FLG", DbType.String, 1);
                _base.AddOutParam("P_RPT_ID", DbType.Int64, 6);


                _base.ExecSPWithTransaction("PKG_OP_RPT_MAS.PRC_MAS_INS");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("p_rpt_id", _base.GetParameterValue("p_rpt_id"));
                _htAdd.Add("P_TIME_STAMP", _base.GetParameterValue("p_time_stamp"));
                return _htAdd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Hashtable Update(string p_brid, string p_coid, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htUpd = new Hashtable();
            try
            {
                _base.AddInParam("P_BRID", DbType.String, p_brid);
                _base.AddInParam("P_COID", DbType.String, p_coid);
                _base.AddInParam("P_RPT_ID", DbType.Int32, p_dr["RPT_ID"]);
                _base.AddInParam("P_RPT_NAME", DbType.String, p_dr["RPT_NAME"]);
                _base.AddInParam("P_RPT_SHORT_NAME", DbType.String, p_dr["RPT_SHORT_NAME"]);
                _base.AddInParam("P_MFG_CODE", DbType.String, p_dr["MFG_CODE"]);
                _base.AddInParam("P_NO_OF_TIME", DbType.Int32, p_dr["NO_OF_TIME"]);
                _base.AddInParam("P_PROC_FLG", DbType.String, p_dr["PROC_FLG"].ToString() == "" ? "N" : p_dr["PROC_FLG"].ToString());
                _base.AddInParam("P_PARA_FLG", DbType.String, p_dr["PARA_FLG"].ToString() == "" ? "N" : p_dr["PARA_FLG"].ToString());
                _base.AddInParam("P_RPT_GRP", DbType.String, p_dr["RPT_GRP"].ToString() == "" ? "N" : p_dr["RPT_GRP"].ToString());
                _base.AddInParam("P_EXP_POL_FLG", DbType.String, p_dr["EXP_POL_FLG"].ToString() == "" ? "N" : p_dr["EXP_POL_FLG"].ToString());
                _base.AddInParam("P_REP_FLG", DbType.String, p_dr["REP_FLG"].ToString() == "" ? "N" : p_dr["REP_FLG"].ToString());
                _base.AddInParam("P_SELF_OP_FLG", DbType.String, p_dr["SELF_OP_FLG"].ToString() == "" ? "N" : p_dr["SELF_OP_FLG"].ToString());
                _base.AddInParam("P_PROC_TYPE", DbType.String, p_dr["PROC_TYPE"]);
                _base.AddInParam("P_PROC_ID", DbType.Int32, p_dr["PROC_ID"]);
                _base.AddInParam("P_IS_ACTIVE", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());
                //_base.AddInParam("P_EXP_POL_FLG", DbType.String, p_dr["EXP_POL_FLG"]);
                _base.AddInParam("P_COMP_AT", DbType.String, p_dr["COMP_AT"]);
                _base.AddInParam("P_OP_TYPE", DbType.String, p_dr["OP_TYPE"].ToString() == "" ? "N" : p_dr["OP_TYPE"].ToString());
                _base.AddInParam("P_EXP_POL_FLG1", DbType.String, p_dr["EXP_POL_FLG1"].ToString() == "" ? "N" : p_dr["EXP_POL_FLG1"].ToString());
                _base.AddInParam("P_IS_THIRD_OP", DbType.String, p_dr["IS_THIRD_OP"].ToString() == "" ? "N" : p_dr["IS_THIRD_OP"].ToString());
                _base.AddInParam("P_MUL_PLN_FLG", DbType.String, p_dr["MUL_PLN_FLG"].ToString() == "" ? "N" : p_dr["MUL_PLN_FLG"].ToString());
                _base.AddInParam("P_ALLOW_TO", DbType.String, p_dr["ALLOW_TO"].ToString() == "" ? "N" : p_dr["ALLOW_TO"].ToString());
                _base.AddInParam("P_GRP", DbType.String, p_dr["GRP"]);
                _base.AddInParam("P_ORD", DbType.Int32, p_dr["ORD"]);
                _base.AddInParam("P_FLG1", DbType.String, p_dr["FLG1"]);
                _base.AddInParam("P_REMARK", DbType.String, p_dr["REMARK"]);
                _base.AddInParam("P_UPD_USER", DbType.String, p_user);
                _base.AddInParam("P_UPD_TERM", DbType.String, p_term);
                _base.AddInParam("p_comma_sp_flg", DbType.String, p_dr["COMMA_SP_FLG"].ToString() == "" ? null : p_dr["COMMA_SP_FLG"].ToString());

                //_base.AddOutParam("P_TIME_STAMP", DbType.String, 50);
                _base.AddParameter("P_TIME_STAMP", DbType.String, 50, ParameterDirection.InputOutput, p_dr["time_stamp"].ToString());
                _base.AddOutParam("P_MSG", DbType.String, 50);
                _base.AddOutParam("P_FLG", DbType.String, 1);


                _base.ExecSPWithTransaction("PKG_OP_RPT_MAS.PRC_MAS_UPD");

                _htUpd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htUpd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htUpd.Add("P_TIME_STAMP", _base.GetParameterValue("p_time_stamp"));

                return _htUpd;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private Hashtable Delete(string p_brid, string p_coid, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htDel = new Hashtable();
            try
            {
                _base.Connect();
                _base.AddInParam("p_brid", DbType.String, p_brid);
                _base.AddInParam("p_coid", DbType.String, p_coid);
                _base.AddInParam("p_rpt_id", DbType.Int32, p_dr["RPT_ID", DataRowVersion.Original]);
                _base.AddInParam("p_del_user", DbType.String, p_user);
                _base.AddInParam("p_del_term", DbType.String, p_term);
                _base.AddInParam("p_time_stamp", DbType.String, p_dr["time_stamp", DataRowVersion.Original]);

                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("PKG_OP_RPT_MAS.PRC_MAS_DEL");

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
