using System;
using System.Data;
using System.Collections;
using PeculiarTuitionBase;

namespace PeculiarTuitionBase.MasterBase
{
    public class EntityTypeMas : TuitionBase
    {
        public DataTable FetchData(out string Error)
        {
            try
            {
                Error = string.Empty;
                _base.Connect();
                DataSet _ds = new DataSet();
                _base.PopulateDataWithCmd("PKG_ENTITY_TYPE_MAS.prc_fetch_data", _ds,"EntityTypeMas",new string[] {string.Empty,null});
                return _ds.Tables["EntityTypeMas"];
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
