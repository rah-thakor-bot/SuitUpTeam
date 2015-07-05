using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
using Peculiar.DAL.Oracle;


namespace PeculiarTuitionBase
{
    public class TuitionBase
    {
        public oraBase.DataMain _base;
        public string _oraConnectionStr = "User Id=hr;Password=oracle;Data Source=orcl";

        public TuitionBase()
        {
            try
            {
                _base = new oraBase.DataMain();
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


        public DataTable FetchGridFields(string p_menu_name, string p_ctl_name, out string Error)
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tutiion_base.prc_fetch_grid_fields", _ds, "GRID_FIEDLS", new string[] { p_menu_name,p_ctl_name,null});
                return _ds.Tables["GRID_FIEDLS"];
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
    }
}
