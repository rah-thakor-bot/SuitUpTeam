using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace PeculiarTuitionBase.MasterBase
{
    public class EmpMas : TuitionBase
    {
        public Hashtable Savedata(string branch,char flg, string empType, string fName, string mName, string lName, DateTime dob , DateTime doj, string sex,string bldGrp, string ph1, string ph2, string adr1, string adr2, string city, string state, string pincode, string email,string user,string terminal, out string errMsg)
        {
            errMsg = string.Empty;
            Hashtable ht = new Hashtable();
            try
            {
                _base.Connect();
                if (flg == 'I')
                {
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
                    _base.AddInParam("p_phone2", DbType.Int64, sex);
                    _base.AddInParam("p_photo", DbType.Object, null);
                    _base.AddInParam("p_add1", DbType.String, sex);
                    _base.AddInParam("p_add2", DbType.String, sex);
                    _base.AddInParam("p_city", DbType.String, sex);
                    _base.AddInParam("p_state", DbType.String, sex);
                    _base.AddInParam("p_pincode", DbType.String, sex);
                    _base.AddInParam("p_email_id", DbType.String, sex);
                    _base.AddInParam("p_ent_user", DbType.String, sex);
                    _base.AddInParam("p_ent_term", DbType.String, sex);

                }
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
            }
            finally
            {

            }
            return ht;
        }
    }
}
/*  

p_dob date    in null
p_doj date    in null
p_leave_date date    in null
p_sex varchar2(1) in null
p_blood_grp varchar2(10)    in null
p_phone1 number  in	1
p_phone2 number  in	1
p_photo clob    in null
p_add1 varchar2(100)   in null
p_add2 varchar2(100)   in null
p_city varchar2(20)    in null
p_state varchar2(20)    in null
p_pincode number  in	1
p_email_id varchar2(50)    in null
p_ent_user varchar2(30)    in null
p_ent_term varchar2(30)    in null
p_time_stamp timestamp   in/out null
p_entity_id number  out n/a
p_flg   varchar2(200)   out n/a
p_msg   varchar2(200)   out n/a
*/
