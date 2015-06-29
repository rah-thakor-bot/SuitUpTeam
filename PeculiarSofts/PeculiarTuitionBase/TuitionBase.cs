using System;
using System.Data.OracleClient;



namespace PeculiarTuitionBase
{
    public class TuitionBase
    {
        public TuitionBase()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string connect_Database()
        {
            string _out = "Fail";
            try
            {
                OracleConnection con = new OracleConnection();
                string _oraConnectionStr = "User Id=hr;Password=oracle;Data Source=orcl";
                con.ConnectionString = _oraConnectionStr;
                con.Open();
                _out = "Successful";
                con.Close();
                con.Dispose();

            }
            catch (Exception ex)
            {

                throw;
            }
            return _out;
        }
    }
}
