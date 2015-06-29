
using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Globalization;

/*http://stackoverflow.com/questions/7952142/how-to-resolve-system-type-to-system-data-dbtype
 * 
 */

namespace PeculiarTuitionBase.Database
{
    #region Commented by Rahul
    /*[CLSCompliant(true)]
    class DataMain : IDisposable
    {
        private Database db;
        private DbConnection connection;
        private DbCommand command;
        private DbTransaction transaction;
        private IsolationLevel isolationLevel;
        private DataTable dtParams;


        public IsolationLevel IsolationLevel
        {
            get
            {
                return this.isolationLevel;
            }
            set
            {
                this.isolationLevel = value;
            }
        }


        public DataMain()
        {
            try
            {
                this.db = DatabaseFactory.CreateDatabase(DBase.DataBaseName());
                this.connection = this.db.CreateConnection();
                this.dtParams = new DataTable();
                this.dtParams.Columns.Add("Name", typeof(string));
                this.dtParams.Columns.Add("Type", typeof(DbType));
                this.dtParams.Columns.Add("Size", typeof(int));
                this.dtParams.Columns.Add("Direction", typeof(ParameterDirection));
                this.dtParams.Columns.Add("Nullable", typeof(bool));
                this.dtParams.Columns.Add("Precision", typeof(byte));
                this.dtParams.Columns.Add("Scale", typeof(byte));
                this.dtParams.Columns.Add("SourceColumn", typeof(string));
                this.dtParams.Columns.Add("SourceVersion", typeof(DataRowVersion));
                this.dtParams.Columns.Add("Value", typeof(object));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataMain(string databaseName)
        {
            try
            {
                this.db = DatabaseFactory.CreateDatabase(databaseName);
                this.connection = this.db.CreateConnection();
                this.dtParams = new DataTable();
                this.dtParams.Columns.Add("Name", typeof(string));
                this.dtParams.Columns.Add("Type", typeof(DbType));
                this.dtParams.Columns.Add("Size", typeof(int));
                this.dtParams.Columns.Add("Direction", typeof(ParameterDirection));
                this.dtParams.Columns.Add("Nullable", typeof(bool));
                this.dtParams.Columns.Add("Precision", typeof(byte));
                this.dtParams.Columns.Add("Scale", typeof(byte));
                this.dtParams.Columns.Add("SourceColumn", typeof(string));
                this.dtParams.Columns.Add("SourceVersion", typeof(DataRowVersion));
                this.dtParams.Columns.Add("Value", typeof(object));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Connect()
        {
            switch (this.connection.State)
            {
                case ConnectionState.Closed:
                    this.connection.Open();
                    break;
                case ConnectionState.Broken:
                    this.connection.Close();
                    this.connection.Open();
                    break;
            }
        }
        public void Disconnect()
        {
            if (this.command != null)
            {
                this.command.Connection.Close();
                this.command.Dispose();
                if (this.connection != null)
                    this.connection.Close();
            }
            this.transaction = (DbTransaction)null;
            //this.dtParams.Rows.Clear();
        }
        public DbTransaction BeginTransaction()
        {
            if (this.transaction == null)
                this.transaction = this.connection.BeginTransaction();
            return this.transaction;
        }

        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            if (this.transaction == null)
            {
                this.IsolationLevel = isolationLevel;
                this.transaction = this.connection.BeginTransaction(isolationLevel);
            }
            return this.transaction;
        }

        public IsolationLevel IsolationLevel
        {
            get
            {
                return this.isolationLevel;
            }
            set
            {
                this.isolationLevel = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.db.ConnectionStringWithoutCredentials;
            }
        }

        public void Commit()
        {
            if (this.transaction == null)
                return;
            this.transaction.Commit();
            this.transaction = (DbTransaction)null;
        }
        public void Rollback()
        {
            if (this.transaction == null)
                return;
            this.transaction.Rollback();
            this.transaction = (DbTransaction)null;
        }
        public string GetParameterValue(string p_parameterName)
        { return null; }

        /*public void AddInParameter(string p_para_name, Type p_datatype, string p_value)
        { }
        public void AddOutParameter(string p_para_name, Type p_datatype, string p_value)
        { }
        */
    #endregion
    [CLSCompliant(true)]
    public class DataMain : IDisposable
    {
        private Microsoft.Practices.EnterpriseLibrary.Data.Database db;
        private DbConnection connection;
        private DbCommand command;
        private DbTransaction transaction;
        private IsolationLevel isolationLevel;
        private DataTable dtParams;

        public IsolationLevel IsolationLevel
        {
            get
            {
                return this.isolationLevel;
            }
            set
            {
                this.isolationLevel = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.db.ConnectionStringWithoutCredentials;
            }
        }

        public DataMain()
        {
            try
            {
                this.db = DatabaseFactory.CreateDatabase(DBase.DataBaseName());
                this.connection = this.db.CreateConnection();
                this.dtParams = new DataTable();
                this.dtParams.Columns.Add("Name", typeof(string));
                this.dtParams.Columns.Add("Type", typeof(DbType));
                this.dtParams.Columns.Add("Size", typeof(int));
                this.dtParams.Columns.Add("Direction", typeof(ParameterDirection));
                this.dtParams.Columns.Add("Nullable", typeof(bool));
                this.dtParams.Columns.Add("Precision", typeof(byte));
                this.dtParams.Columns.Add("Scale", typeof(byte));
                this.dtParams.Columns.Add("SourceColumn", typeof(string));
                this.dtParams.Columns.Add("SourceVersion", typeof(DataRowVersion));
                this.dtParams.Columns.Add("Value", typeof(object));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataMain(string databaseName)
        {
            try
            {
                this.db = DatabaseFactory.CreateDatabase(databaseName);
                this.connection = this.db.CreateConnection();
                this.dtParams = new DataTable();
                this.dtParams.Columns.Add("Name", typeof(string));
                this.dtParams.Columns.Add("Type", typeof(DbType));
                this.dtParams.Columns.Add("Size", typeof(int));
                this.dtParams.Columns.Add("Direction", typeof(ParameterDirection));
                this.dtParams.Columns.Add("Nullable", typeof(bool));
                this.dtParams.Columns.Add("Precision", typeof(byte));
                this.dtParams.Columns.Add("Scale", typeof(byte));
                this.dtParams.Columns.Add("SourceColumn", typeof(string));
                this.dtParams.Columns.Add("SourceVersion", typeof(DataRowVersion));
                this.dtParams.Columns.Add("Value", typeof(object));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        ~DataMain()
        {
            try
            {
                this.Dispose();
            }
            catch
            {
            }
            finally
            {
            }
        }

        public void LoadDataSetWithCommand(string sqlQuery, DataSet ds)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.db.LoadDataSet(this.command, ds, Convert.ToString(ds.Tables.Count - 1));
        }

        public void LoadDataSetWithCommand(string sqlQuery, DataSet ds, string[] tablenames)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(this.command, ds, tablenames);
        }

        public void LoadDataSetWithCommand(string sqlQuery, DataSet ds, string tablename)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(this.command, ds, tablename);
        }

        public void LoadDataSetWithTransaction(string sqlQuery, DataSet ds)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.db.LoadDataSet(this.command, ds, Convert.ToString(ds.Tables.Count - 1), this.BeginTransaction(this.isolationLevel));
        }

        public void LoadDataSetWithTransaction(string sqlQuery, DataSet ds, string[] tablenames)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(this.command, ds, tablenames, this.BeginTransaction(this.isolationLevel));
        }

        public void LoadDataSetWithTransaction(string sqlQuery, DataSet ds, string tablename)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(this.command, ds, tablename, this.BeginTransaction(this.isolationLevel));
        }

        public void LoadDataSetSPWithCommand(string storeProcedure, DataSet ds)
        {
            this.command = this.PrepareProcedureCommand(storeProcedure);
            this.db.LoadDataSet(this.command, ds, Convert.ToString(ds.Tables.Count - 1));
        }

        public void LoadDataSetSPWithCommand(string storeProcedure, DataSet ds, string[] tablenames)
        {
            this.command = this.PrepareProcedureCommand(storeProcedure);
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(this.command, ds, tablenames);
        }

        public void LoadDataSetSPWithCommand(string storeProcedure, DataSet ds, string tablename)
        {
            this.command = this.PrepareProcedureCommand(storeProcedure);
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(this.command, ds, tablename);
        }

        public void LoadDataSetSPWithTransaction(string storeProcedure, DataSet ds)
        {
            this.command = this.PrepareProcedureCommand(storeProcedure);
            this.db.LoadDataSet(this.command, ds, Convert.ToString(ds.Tables.Count - 1), this.BeginTransaction(this.isolationLevel));
        }

        public void LoadDataSetSPWithTransaction(string storeProcedure, DataSet ds, string[] tablenames)
        {
            this.command = this.PrepareProcedureCommand(storeProcedure);
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(this.command, ds, tablenames, this.BeginTransaction(this.isolationLevel));
        }

        public void LoadDataSetSPWithTransaction(string storeProcedure, DataSet ds, string tablename)
        {
            this.command = this.PrepareProcedureCommand(storeProcedure);
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(this.command, ds, tablename, this.BeginTransaction(this.isolationLevel));
        }

        public void LoadDataSetWithCommand(string storeProcedure, DataSet ds, string[] tablenames, params object[] paramValues)
        {
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(storeProcedure, ds, tablenames, paramValues);
        }

        public void LoadDataSetWithCommand(string storeProcedure, DataSet ds, string tablename, params object[] paramValues)
        {
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(storeProcedure, ds, new string[1]
            {
        tablename
            }, paramValues);
        }

        public void LoadDataSetWithTransaction(string storeProcedure, DataSet ds, string[] tablenames, params object[] paramValues)
        {
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(this.BeginTransaction(this.isolationLevel), storeProcedure, ds, tablenames, paramValues);
        }

        public void LoadDataSetWithTransaction(string storeProcedure, DataSet ds, string tablename, params object[] paramValues)
        {
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(this.BeginTransaction(this.isolationLevel), storeProcedure, ds, new string[1]
            {
        tablename
            }, paramValues);
        }

        public void LoadDataSetWithCommand(CommandType commandType, string commandText, DataSet ds, string[] tablenames)
        {
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(commandType, commandText, ds, tablenames);
        }

        public void LoadDataSetWithCommand(CommandType commandType, string commandText, DataSet ds, string tablename)
        {
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(commandType, commandText, ds, new string[1]
            {
        tablename
            });
        }

        public void LoadDataSetWithTransaction(CommandType commandType, string commandText, DataSet ds, string[] tablenames)
        {
            this.Refresh(ds, tablenames);
            this.db.LoadDataSet(this.BeginTransaction(this.isolationLevel), commandType, commandText, ds, tablenames);
        }

        public void LoadDataSetWithTransaction(CommandType commandType, string commandText, DataSet ds, string tablename)
        {
            this.Refresh(ds, tablename);
            this.db.LoadDataSet(this.BeginTransaction(this.isolationLevel), commandType, commandText, ds, new string[1]
            {
        tablename
            });
        }

        public void AddParameter(string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            DataRow row = this.dtParams.NewRow();
            row.ItemArray = new object[10]
            {
        (object) name,
        (object) dbType,
        (object) size,
        (object) direction,
        (object) (int) (nullable ? 1 : 0),
        (object) precision,
        (object) scale,
        (object) sourceColumn,
        (object) sourceVersion,
        value
            };
            this.dtParams.Rows.Add(row);
        }

        public void AddParameter(string name, DbType dbType, ParameterDirection direction, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            this.AddParameter(name, dbType, 0, direction, false, (byte)0, (byte)0, sourceColumn, sourceVersion, value);
        }

        public void AddParameter(string name, DbType dbType, int size, ParameterDirection direction, object value)
        {
            this.AddParameter(name, dbType, size, direction, true, (byte)0, (byte)0, "", DataRowVersion.Default, value);
        }

        public void AddInParameter(string name, DbType dbType)
        {
            this.AddParameter(name, dbType, ParameterDirection.Input, string.Empty, DataRowVersion.Default, (object)null);
        }

        public void AddInParameter(string name, DbType dbType, object value)
        {
            this.AddParameter(name, dbType, ParameterDirection.Input, string.Empty, DataRowVersion.Default, value);
        }

        public void AddInParameter(string name, DbType dbType, int size, byte scale, object value)
        {
            this.AddParameter(name, dbType, size, ParameterDirection.Input, true, (byte)0, scale, string.Empty, DataRowVersion.Default, value);
        }

        public void AddInParameter(string name, DbType dbType, int size, object value)
        {
            this.AddParameter(name, dbType, size, ParameterDirection.Input, true, (byte)0, (byte)0, string.Empty, DataRowVersion.Default, value);
        }

        public void AddInParameter(string name, DbType dbType, string sourceColumn, DataRowVersion sourceVersion)
        {
            this.AddParameter(name, dbType, 0, ParameterDirection.Input, true, (byte)0, (byte)0, sourceColumn, sourceVersion, (object)null);
        }

        public void AddOutParameter(string name, DbType dbType, int size)
        {
            this.AddParameter(name, dbType, size, ParameterDirection.Output, true, (byte)0, (byte)0, string.Empty, DataRowVersion.Default, (object)DBNull.Value);
        }

        public void SetParameterValue(DbCommand command, string parameterName, object value)
        {
            this.db.SetParameterValue(command, parameterName, value);
        }

        public object GetParameterValue(string name)
        {
            return this.db.GetParameterValue(this.command, name);
        }

        public void Connect()
        {
            switch (this.connection.State)
            {
                case ConnectionState.Closed:
                    this.connection.Open();
                    break;
                case ConnectionState.Broken:
                    this.connection.Close();
                    this.connection.Open();
                    break;
            }
        }

        public void Disconnect()
        {
            if (this.command != null)
            {
                this.command.Connection.Close();
                this.command.Dispose();
                if (this.connection != null)
                    this.connection.Close();
            }
            this.transaction = (DbTransaction)null;
            this.dtParams.Rows.Clear();
        }

        public DbTransaction BeginTransaction()
        {
            if (this.transaction == null)
                this.transaction = this.connection.BeginTransaction();
            return this.transaction;
        }

        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            if (this.transaction == null)
            {
                this.IsolationLevel = isolationLevel;
                this.transaction = this.connection.BeginTransaction(isolationLevel);
            }
            return this.transaction;
        }

        public void Commit()
        {
            if (this.transaction == null)
                return;
            this.transaction.Commit();
            this.transaction = (DbTransaction)null;
        }

        public void Rollback()
        {
            if (this.transaction == null)
                return;
            this.transaction.Rollback();
            this.transaction = (DbTransaction)null;
        }

        public DataSet ExecStringReturnDataSetWithCommand(CommandType commandType, string commandText)
        {
            return this.db.ExecuteDataSet(commandType, commandText);
        }

        public DataSet ExecSPReturnDataSetWithCommand(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            return this.db.ExecuteDataSet(this.command);
        }

        public DataSet ExecSPReturnDataSetWithCommand(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            return this.db.ExecuteDataSet(this.command);
        }

        public DataSet ExecStringReturnDataSetWithTransaction(CommandType commandType, string commandText)
        {
            return this.db.ExecuteDataSet(this.BeginTransaction(this.isolationLevel), commandType, commandText);
        }

        public DataSet ExecSPReturnDataSetWithTransaction(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteDataSet(this.command, this.command.Transaction);
        }

        public DataSet ExecSPReturnDataSetWithTransaction(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteDataSet(this.command, this.command.Transaction);
        }

        public IDataReader ExecStringReturnDataReaderWithCommand(CommandType commandType, string commandText)
        {
            return this.db.ExecuteReader(commandType, commandText);
        }

        public IDataReader ExecSPReturnDataReaderWithCommand(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            return this.db.ExecuteReader(this.command);
        }

        public IDataReader ExecSPReturnDataReaderWithCommand(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            return this.db.ExecuteReader(this.command);
        }

        public IDataReader ExecSPReturnDataReaderWithTransaction(CommandType commandType, string commandText)
        {
            return this.db.ExecuteReader(this.BeginTransaction(this.isolationLevel), commandType, commandText);
        }

        public IDataReader ExecSPReturnDataReaderWithTransaction(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteReader(this.command, this.command.Transaction);
        }

        public IDataReader ExecSPReturnDataReaderWithTransaction(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteReader(this.command, this.command.Transaction);
        }

        public object ExecStringReturnScalarWithCommand(CommandType commandType, string commandText)
        {
            return this.db.ExecuteScalar(commandType, commandText);
        }

        public object ExecSPReturnScalarWithCommand(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            return this.db.ExecuteScalar(this.command);
        }

        public object ExecSPReturnScalarWithCommand(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            return this.db.ExecuteScalar(this.command);
        }

        public object ExecStringReturnScalarWithTransaction(CommandType commandType, string commandText)
        {
            return this.db.ExecuteScalar(this.BeginTransaction(this.isolationLevel), commandType, commandText);
        }

        public object ExecSPReturnScalarWithTransaction(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteScalar(this.command, this.command.Transaction);
        }

        public object ExecSPReturnScalarWithTransaction(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteScalar(this.command, this.command.Transaction);
        }

        public int ExecStringWithCommand(CommandType commandType, string commandText)
        {
            return this.db.ExecuteNonQuery(commandType, commandText);
        }

        public int ExecSPWithCommand(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            return this.db.ExecuteNonQuery(this.command);
        }

        public int ExecSPWithCommand(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            return this.db.ExecuteNonQuery(this.command);
        }

        public int ExecStringWithTransaction(CommandType commandType, string commandText)
        {
            return this.db.ExecuteNonQuery(this.BeginTransaction(this.isolationLevel), commandType, commandText);
        }

        public int ExecSPWithTransaction(string spName)
        {
            this.command = this.PrepareProcedureCommand(spName);
            this.ClearParams();
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteNonQuery(this.command, this.command.Transaction);
        }

        public int ExecSPWithTransaction(string spName, params object[] paramValues)
        {
            this.command = this.PrepareProcedureCommand(spName, paramValues);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteNonQuery(this.command, this.command.Transaction);
        }

        public DataSet ExecQueryReturnDataSetWithCommand(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            return this.db.ExecuteDataSet(this.command);
        }

        public DataSet ExecQueryReturnDataSetWithTransaction(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteDataSet(this.command, this.command.Transaction);
        }

        public IDataReader ExecQueryReturnDataReaderWithCommand(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            return this.db.ExecuteReader(this.command);
        }

        public IDataReader ExecQueryReturnDataReaderWithTransaction(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteReader(this.command, this.command.Transaction);
        }

        public object ExecQueryReturnScalarWithCommand(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            return this.db.ExecuteScalar(this.command);
        }

        public object ExecQueryReturnScalarWithTransaction(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteScalar(this.command, this.command.Transaction);
        }

        public int ExecQueryWithCommand(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            return this.db.ExecuteNonQuery(this.command);
        }

        public int ExecQueryWithTransaction(string sqlQuery)
        {
            this.command = this.PrepareQueryCommand(sqlQuery);
            this.command.Transaction = this.BeginTransaction(this.isolationLevel);
            return this.db.ExecuteNonQuery(this.command, this.command.Transaction);
        }

        public DataTable GetSchemaTable(string tableName)
        {
            return this.connection.GetSchema();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        private DbCommand PrepareQueryCommand(string sqlQuery)
        {
            this.command = this.db.GetSqlStringCommand(sqlQuery);
            this.command.Connection = this.connection;
            return this.command;
        }

        private DbCommand PrepareProcedureCommand(string storeProcedure)
        {
            this.command = this.db.GetStoredProcCommand(storeProcedure);
            this.command.Connection = this.connection;
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            if (this.dtParams.Rows.Count != 0 && this.command.Parameters.Count == 0)
            {
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.dtParams.Rows)
                    this.db.AddParameter(this.command, dataRow["Name"].ToString(), (DbType)dataRow["Type"], int.Parse(dataRow["Size"].ToString(), (IFormatProvider)numberFormatInfo), (ParameterDirection)dataRow["Direction"], bool.Parse(dataRow["Nullable"].ToString()), byte.Parse(dataRow["Precision"].ToString(), (IFormatProvider)numberFormatInfo), byte.Parse(dataRow["Scale"].ToString(), (IFormatProvider)numberFormatInfo), dataRow["SourceColumn"].ToString(), (DataRowVersion)dataRow["SourceVersion"], dataRow["Value"]);
            }
            return this.command;
        }

        private DbCommand PrepareProcedureCommand(string storeProcedure, params object[] paramValues)
        {
            this.command = this.db.GetStoredProcCommand(storeProcedure, paramValues);
            return this.command;
        }

        private void AssignParameterValues(DbCommand command, object[] values)
        {
            int num = this.UserParametersStartIndex();
            for (int index = 0; index < values.Length; ++index)
            {
                IDataParameter dataParameter = (IDataParameter)command.Parameters[index + num];
                this.SetParameterValue(command, dataParameter.ParameterName, values[index]);
            }
        }

        protected virtual int UserParametersStartIndex()
        {
            return 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            this.Disconnect();
            this.connection.Dispose();
            this.db = (Microsoft.Practices.EnterpriseLibrary.Data.Database)null;
        }

        private void Refresh(DataSet ds, string tablename)
        {
            if (string.IsNullOrEmpty(tablename))
                throw new ArgumentNullException("Table name cannot have null value");
            if (!ds.Tables.Contains(tablename))
                return;
            ds.Tables.Remove(tablename);
        }

        private void Refresh(DataSet ds, string[] tablenames)
        {
            for (int index = 0; index < tablenames.Length; ++index)
                this.Refresh(ds, tablenames[index]);
        }

        private void ClearParams()
        {
            if (this.dtParams.Rows.Count <= 0)
                return;
            this.dtParams.Rows.Clear();
        }
    }
} 

