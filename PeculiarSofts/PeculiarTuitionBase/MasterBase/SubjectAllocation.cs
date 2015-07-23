using System;
using System.Data;
using System.Linq;
using System.Collections;

namespace PeculiarTuitionBase.MasterBase
{
    public class SubjectAllocation : TuitionBase
    {
        public Hashtable SaveData(string p_brid, string p_coid, string p_user, string p_terminal, ref DataTable p_dt, out string p_err)
        {
            #region variable Declaration
            int _intNumRecords = 0,seqno = 0;
            string _strErrMsg = "";
            string _strTimeStampErrMsg = "Timestamp  Error : \n";
            string _strInsertErrMsg = "Problem in inserting record : \n";
            string _strUpdateErrMsg = "Problem in updating record : \n";
            string _strDeleteErrMsg = "Problem in deleting record : \n";

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
                                _strInsertErrMsg += "Allocation Id " + _drRow["allocation_id"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                seqno = int.Parse(_htSave["allocation_id"].ToString());
                            }
                            break;
                        case DataRowState.Modified:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Update(p_brid, p_user, p_terminal, _drRow);

                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Allocation Id. = " + _drRow["allocation_id"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strUpdateErrMsg += "Allocation Id. = " + _drRow["allocation_id"].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "Y")
                            {
                                seqno = int.Parse(_drRow["allocation_id"].ToString());
                            }
                            break;
                        case DataRowState.Deleted:
                            _base.BeginTransaction(IsolationLevel.ReadCommitted);
                            _htSave = Delete(p_brid, p_user, p_terminal, _drRow);
                            if (_htSave["p_flg"].ToString().ToUpper() == "T")
                            {
                                _strTimeStampErrMsg += "Allocation Id. = " + _drRow["allocation_id", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            else if (_htSave["p_flg"].ToString().ToUpper() == "N")
                            {
                                _strTimeStampErrMsg += "Allocation Id. = " + _drRow["allocation_id", DataRowVersion.Original].ToString() + "";
                                _base.Rollback();
                                continue;
                            }
                            break;
                    }

                    DataRow[] _drRows = null;
                    if (_drRow.RowState != DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("allocation_id = " + _drRow["allocation_id"]);
                        if (_drRow.RowState == DataRowState.Added)
                        {
                            p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["allocation_id"] = seqno;
                        }
                        p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])]["TIME_STAMP"] = _htSave["P_TIME_STAMP"].ToString();
                    }
                    if (_drRow.RowState == DataRowState.Deleted)
                    {
                        _drRows = p_dt.Select("allocation_id =" + _drRow["allocation_id", DataRowVersion.Original], "", DataViewRowState.Deleted);
                    }
                    p_dt.Rows[p_dt.Rows.IndexOf(_drRows[0])].AcceptChanges();
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

        private Hashtable Add(string p_branch_id, string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htAdd = new Hashtable();
            try
            {
                _base.AddInParam("p_branch", DbType.String, p_branch_id);
                _base.AddInParam("p_batch_id", DbType.String, p_dr["BATCH_ID"]);
                _base.AddInParam("p_entity_id", DbType.String, p_dr["ENTITY_ID"]);
                _base.AddInParam("p_entity_type_id", DbType.Int32, p_dr["ENTITY_TYPE_ID"]);
                _base.AddInParam("p_ref_sub_id", DbType.Int32, p_dr["REF_SUB_ID"]);
                _base.AddInParam("p_is_active", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());
                _base.AddInParam("p_remark", DbType.Int32, p_dr["REMARK"]);
                _base.AddInParam("p_ent_user", DbType.String, p_user);
                _base.AddInParam("p_ent_term", DbType.String, p_term);
                _base.AddOutParam("p_time_stamp", DbType.String, 50);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_allocation_id", DbType.Int32, 5);
                _base.ExecSPWithTransaction("PKG_SUB_ALLOCATION.prc_mas_ins");

                _htAdd.Add("p_flg", _base.GetParameterValue("p_flg"));
                _htAdd.Add("p_msg", _base.GetParameterValue("p_msg"));
                _htAdd.Add("allocation_id", _base.GetParameterValue("p_allocation_id"));
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
                _base.AddInParam("p_branch", DbType.String, p_branch_id);
                _base.AddInParam("p_allocation_id", DbType.Int32, p_dr["ALLOCATION_ID"]);
                _base.AddInParam("p_batch_id", DbType.String, p_dr["BATCH_ID"]);
                _base.AddInParam("p_entity_id", DbType.String, p_dr["ENTITY_ID"]);
                _base.AddInParam("p_entity_type_id", DbType.String, p_dr["ENTITY_TYPE_ID"]);
                _base.AddInParam("p_ref_sub_id", DbType.Int32, p_dr["STD_NAME"]);
                _base.AddInParam("p_is_active", DbType.String, p_dr["IS_ACTIVE"].ToString() == "" ? "N" : p_dr["IS_ACTIVE"].ToString());
                _base.AddInParam("p_remark", DbType.Int32, p_dr["REMARK"]);
                _base.AddInParam("p_upd_term", DbType.String, p_user);
                _base.AddInParam("p_upd_user", DbType.String, p_term);
                _base.AddParameter("p_time_stamp", DbType.String, 50, ParameterDirection.InputOutput, p_dr["TIME_STAMP"].ToString());
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.ExecSPWithTransaction("pkg_sub_allocation.prc_mas_upd");

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

        private Hashtable Delete(string p_brid,string p_user, string p_term, DataRow p_dr)
        {
            Hashtable _htDel = new Hashtable();
            try
            {
                _base.Connect();

                _base.AddInParam("p_allocation_id", DbType.String, p_dr["ALLOCATION_ID", DataRowVersion.Original]);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.AddOutParam("p_msg", DbType.String, 50);

                _base.ExecSPWithTransaction("pkg_sub_allocation.prc_mas_del");

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
