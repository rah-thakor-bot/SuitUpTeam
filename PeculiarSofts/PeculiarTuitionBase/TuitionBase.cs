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
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_fetch_grid_fields", _ds, "GRID_FIEDLS", new string[] { p_menu_name,p_ctl_name,null});
                return _ds.Tables["GRID_FIEDLS"];
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_std_type">Actice or InActive</param>
        /// <param name="Error">Out for Error</param>
        /// <returns></returns>
        public DataTable GetStdList(out string Error,string p_branch_id = "NULL",string p_std_status = "Y" )
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_std_list", _ds, "StdList", new string[] { (p_branch_id == "NULL") ? string.Empty : p_branch_id, p_std_status, null });
                return _ds.Tables["StdList"];
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

        /// <summary>
        /// Get Subject in Class
        /// </summary>
        /// <param name="ref_sub_id"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public DataTable GetSubjectList(string ref_std_id, out string Error, string p_subject_status = "A")
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_sub_list", _ds, "SubLst", new string[] { ref_std_id, p_subject_status, null });
                return _ds.Tables["SubLst"];
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


        public DataTable GetStdType(out string Error)
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_std_type", _ds, "StdType", new string[] { null });
                return _ds.Tables["StdType"];
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

        public DataTable GetStdMedium(out string Error)
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_std_medium", _ds, "StdMedium", new string[] { null });
                return _ds.Tables["StdMedium"];
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
    }
}
