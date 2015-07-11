using System;
using System.Data;
using System.Configuration;
using Peculiar.DataProvider;


namespace PeculiarTuitionBase
{
    public class TuitionBase
    {

        public OracleEntLibDataProvider.LibraryBase _base;

        public TuitionBase()
        {
            try
            {
                _base = new OracleEntLibDataProvider.LibraryBase(ConfigurationManager.AppSettings["TuitionBase"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string connect_Database()
        {
            string _out = "Fail";
            //try
            //{
            //    OracleConnection con = new OracleConnection();
            //    string _oraConnectionStr = "User Id=hr;Password=oracle;Data Source=orcl";
            //    con.ConnectionString = _oraConnectionStr;
            //    con.Open();
            //    _out = "Successful";
            //    con.Close();
            //    con.Dispose();

            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
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
