using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;

namespace PeculiarTuitionBase.MasterBase
{
    public class ChapterMas : TuitionBase
    {
        #region Code Moved to SubjectMas Class
        /*
        public DataTable FetchData(out string Error)
        {
            try
            {
                Error = string.Empty;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_chp_mas.prc_mas_get_data", _ds, "ChpMas", new string[] { "1 = 1", null });
                return _ds.Tables["ChpMas"];
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

        public Hashtable SaveData(string p_brid, string p_user, string p_terminal, ref DataSet p_ds, out string p_err)
        {
            #region variable Declaration
            int _intNumRecords = 0, _intSeqno = 0;
            string _strCriteria = string.Empty;
            string _strErrMsg = "";
            string _strTimeStampErrMsg = "Timestamp  Error : \n";
            string _strInsertErrMsg = "Problem In Inserting Record : \n";
            string _strUpdateErrMsg = "Problem In Updating Record : \n";
            string _strDeleteErrMsg = "Record can't deleted due to child record exist : \n";

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
                            _htSave = Add(p_brid, p_user, p_terminal, _drRow);

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
                            _htSave = Update(p_brid,  p_user, p_terminal, _drRow);

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

                            _htSave = Delete(p_brid, p_user, p_terminal, _drRow);
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
                    _base.Commit();
                }

                if (_strTimeStampErrMsg != CONST_TIMESTAMP)
                    _strErrMsg = _strTimeStampErrMsg + "\n \n";

                if (_strInsertErrMsg != CONST_INS_MSG)
                    _strErrMsg = _strInsertErrMsg + "\n \n";

                if (_strUpdateErrMsg != CONST_UPD_MSG)
                    _strErrMsg = _strUpdateErrMsg + "\n \n";

                if (_strDeleteErrMsg != CONST_DEL_MSG)
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
                _base.Disconnect();
            }
            return _htSave;
        }

        private Hashtable Add(string p_brid, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htAdd = new Hashtable();
            try
            {
                _base.AddInParam("P_BRID", DbType.String, p_brid);
                
                _base.AddInParam("P_ENT_USER", DbType.String, p_user);
                _base.AddInParam("P_ENT_TERM", DbType.String, p_term);
                _base.AddInParam("p_comma_sp_flg", DbType.String, p_dr["COMMA_SP_FLG"].ToString() == "" ? null : p_dr["COMMA_SP_FLG"].ToString());
                _base.AddOutParam("P_TIME_STAMP", DbType.String, 50);
                _base.AddOutParam("P_MSG", DbType.String, 50);
                _base.AddOutParam("P_FLG", DbType.String, 1);
                _base.AddOutParam("P_seqno", DbType.Int64, 6);


                _base.ExecSPWithTransaction("PKG_ChpMas.PRC_MAS_INS");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("p_seqno", _base.GetParameterValue("p_seqno"));
                _htAdd.Add("P_TIME_STAMP", _base.GetParameterValue("p_time_stamp"));
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
                _base.AddInParam("P_BRID", DbType.String, p_brid);
                
                _base.AddInParam("P_UPD_USER", DbType.String, p_user);
                _base.AddInParam("P_UPD_TERM", DbType.String, p_term);
                _base.AddInParam("p_comma_sp_flg", DbType.String, p_dr["COMMA_SP_FLG"].ToString() == "" ? null : p_dr["COMMA_SP_FLG"].ToString());

                //_base.AddOutParam("P_TIME_STAMP", DbType.String, 50);
                _base.AddParameter("P_TIME_STAMP", DbType.String, 50, ParameterDirection.InputOutput, p_dr["time_stamp"].ToString());
                _base.AddOutParam("P_MSG", DbType.String, 50);
                _base.AddOutParam("P_FLG", DbType.String, 1);


                _base.ExecSPWithTransaction("PKG_ChpMas.PRC_MAS_UPD");

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

        private Hashtable Delete(string p_brid, string p_user, string p_term, DataRow p_dr)
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

                _base.ExecSPWithTransaction("PKG_ChpMas.PRC_MAS_DEL");

                _htDel.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htDel.Add("p_msg", _base.GetParameterValue("p_msg"));

                return _htDel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        #endregion
    }

}
