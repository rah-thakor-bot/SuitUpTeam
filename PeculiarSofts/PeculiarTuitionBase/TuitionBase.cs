using System;
using System.Data;
using System.Configuration;
using Peculiar.DataProvider;

namespace PeculiarTuitionBase
{
    public class TuitionBase
    {

        public OracleEntLibDataProvider.LibraryBase _base;
        public static readonly string InsertMessage = ConfigurationManager.AppSettings["InsertErr"].ToString();
        public static readonly string UpdateMessage = ConfigurationManager.AppSettings["UpdateErr"].ToString();
        public static readonly string DeleteMessage = ConfigurationManager.AppSettings["DeleteErr"].ToString();
        public static readonly string TimestampMsg = ConfigurationManager.AppSettings["TimeStampErr"].ToString();

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="insertMsg"></param>
        /// <param name="updateMsg"></param>
        /// <param name="DelMsg"></param>
        /// <param name="timestampMsg"></param>
        /// <param name="ErrorMsg"></param>
        public void GetTransactionSummary(string insertMsg, string updateMsg, string DelMsg, string timestampMsg, out string ErrorMsg)
        {
            ErrorMsg = string.Empty;
            if (timestampMsg != TimestampMsg)
                ErrorMsg = timestampMsg + "\n\n";

            if (insertMsg != InsertMessage)
                ErrorMsg = insertMsg + "\n\n";

            if (updateMsg != UpdateMessage)
                ErrorMsg = updateMsg + "\n\n";

            if (DelMsg != DeleteMessage)
                ErrorMsg = DelMsg + "\n\n";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_combo_flg"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public DataTable FetchStaticCombo(string p_combo_flg, out string Error)
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_static_combo", _ds, "StaticCombo", new string[] { p_combo_flg, null });
                return _ds.Tables["StaticCombo"];
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
        /// <param name="Error"></param>
        /// <param name="p_active_flg"></param>
        /// <returns></returns>
        public DataTable FetchBatchList(out string Error, string p_active_flg = "Y")
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_batch_list", _ds, "BatchList", new string[] { p_active_flg, null });
                return _ds.Tables["BatchList"];
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
        /// <param name="Error"></param>
        /// <param name="p_flg"></param>
        /// <returns></returns>
        public DataTable FetchEntityType(out string Error, string p_flg = "Y")
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_entity_type", _ds, "EntityType", new string[] { p_flg, null });
                return _ds.Tables["EntityType"];
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
        /// <param name="p_menu_name"></param>
        /// <param name="p_ctl_name"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
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
        public DataTable GetStdList(out string Error,string p_branch_id ,string p_std_status = "Y" )
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_std_list", _ds, "StdList", new string[] { p_branch_id, p_std_status, null });
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
        public DataTable GetSubjectList(string ref_std_id, out string Error, string p_active_flg = "A")
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_sub_list", _ds, "SubLst", new string[] { ref_std_id, p_active_flg, null });
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Error"></param>
        /// <returns></returns>
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

        public DataTable GetTeacherList(out string Error,string p_active_flg = "Y")
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_teacher_list", _ds, "Teacher", new string[] { p_active_flg, null });
                return _ds.Tables["Teacher"];
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

        public DataTable GetExamList(out string Error, string p_exam_flg = "Y")
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_exam_list", _ds, "Exam", new string[] { p_exam_flg, null });
                return _ds.Tables["Exam"];
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

        public DataTable GetEmpList(out string Error, string p_entity_type = null, string p_is_active = "Y")
        {
            try
            {
                Error = null;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("pkg_tuition_base.prc_get_emp_list", _ds, "EmpList", new string[] { p_entity_type, p_is_active, null });
                return _ds.Tables["EmpList"];
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
