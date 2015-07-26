using System;
using System.Data;
using System.Collections;

namespace PeculiarTuitionBase.MasterBase
{
    public class EmpMas : TuitionBase
    {
        public Hashtable insertData(string branch,char flg, string empType, string fName, string mName, string lName, DateTime dob , DateTime doj, string sex,string bldGrp, string ph1, string ph2, string adr1, string adr2, string city, string state, string pincode, string email,string user,string terminal, out string errMsg)
        {
            errMsg = string.Empty;
            Hashtable insertHash = new Hashtable();
            try
            {
                _base.Connect();
                _base.AddInParam("p_branch", DbType.String, branch);
                _base.AddInParam("p_f_name", DbType.String, fName);
                _base.AddInParam("p_m_name", DbType.String, mName);
                _base.AddInParam("p_l_name", DbType.String, lName);
                _base.AddInParam("p_dob", DbType.Date, null);
                _base.AddInParam("p_doj", DbType.Date, null);
                _base.AddInParam("p_leave_date", DbType.Date, null);
                _base.AddInParam("p_sex", DbType.String, sex);
                _base.AddInParam("p_blood_grp", DbType.String, bldGrp);
                _base.AddInParam("p_phone1", DbType.Int64, ph1);
                _base.AddInParam("p_phone2", DbType.Int64, ph2);
                _base.AddInParam("p_photo", DbType.Object, null);
                _base.AddInParam("p_add1", DbType.String, adr1);
                _base.AddInParam("p_add2", DbType.String, adr2);
                _base.AddInParam("p_city", DbType.String, city);
                _base.AddInParam("p_state", DbType.String, state);
                _base.AddInParam("p_pincode", DbType.String, pincode);
                _base.AddInParam("p_email_id", DbType.String, email);
                _base.AddInParam("p_ent_user", DbType.String, user);
                _base.AddInParam("p_ent_term", DbType.String, terminal);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.ExecSPWithTransaction("pkg_emp_mas.prc_mas_ins");
                insertHash.Add("p_flg", _base.GetParameterValue("p_flg"));
                insertHash.Add("p_msg", _base.GetParameterValue("p_msg"));
                return insertHash;
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
            }
            finally
            {

            }
            return insertHash;
        }

        public Hashtable updateData(string branch, char flg, string empType, string entity_id ,string fName, string mName, string lName, DateTime dob, DateTime doj, string sex, string bldGrp, string ph1, string ph2, string adr1, string adr2, string city, string state, string pincode, string email, string user, string terminal,string p_time_stamp, out string errMsg)
        {
            errMsg = string.Empty;
            Hashtable updateHash = new Hashtable();
            try
            {
                _base.Connect();
                _base.AddInParam("p_branch", DbType.String, branch);
                _base.AddInParam("p_entity_id", DbType.Int32, Int32.Parse(entity_id.ToString()));
                _base.AddInParam("p_f_name", DbType.String, fName);
                _base.AddInParam("p_f_name", DbType.String, fName);
                _base.AddInParam("p_m_name", DbType.String, mName);
                _base.AddInParam("p_l_name", DbType.String, lName);
                _base.AddInParam("p_dob", DbType.Date, null);
                _base.AddInParam("p_doj", DbType.Date, null);
                _base.AddInParam("p_leave_date", DbType.Date, null);
                _base.AddInParam("p_sex", DbType.String, sex);
                _base.AddInParam("p_blood_grp", DbType.String, bldGrp);
                _base.AddInParam("p_phone1", DbType.Int64, ph1);
                _base.AddInParam("p_phone2", DbType.Int64, ph2);
                _base.AddInParam("p_photo", DbType.Object, null);
                _base.AddInParam("p_add1", DbType.String, adr1);
                _base.AddInParam("p_add2", DbType.String, adr2);
                _base.AddInParam("p_city", DbType.String, city);
                _base.AddInParam("p_state", DbType.String, state);
                _base.AddParameter("p_time_stamp", DbType.String, 50, ParameterDirection.InputOutput, p_time_stamp);
                _base.AddInParam("p_pincode", DbType.String, pincode);
                _base.AddInParam("p_email_id", DbType.String, email);
                _base.AddInParam("p_ent_user", DbType.String, user);
                _base.AddInParam("p_ent_term", DbType.String, terminal);
                _base.AddOutParam("p_msg", DbType.String, 50);
                _base.AddOutParam("p_flg", DbType.String, 1);
                _base.ExecSPWithTransaction("pkg_emp_mas.prc_mas_upd");
                updateHash.Add("p_flg", _base.GetParameterValue("p_flg"));
                updateHash.Add("p_msg", _base.GetParameterValue("p_msg"));
                return updateHash;
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
            }
            finally
            {

            }
            return updateHash;
        }
    }
}

