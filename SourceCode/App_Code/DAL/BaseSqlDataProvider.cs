using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.CSharp;
using System.Collections;

/// <summary>
/// Summary description for BaseSqlDataProvider
/// </summary>



//public class BaseSqlDataProvider
public partial class SqlDataProvider
{
    Connection objConnectionClass = new Connection();
    public SqlDataAdapter objSqlDa;
    public DataTable objDt;
    public DataSet objDs;
    public SqlDataReader objSqlDr;

    public string _ProvideName = ConfigurationManager.AppSettings["ProviderName"];
    protected delegate CollectionBase GenerateCollectionFromReader( ref IDataReader returnData);
    protected delegate object GenerateObjectFromReader(ref IDataReader returnData);
    
    //public BaseSqlDataProvider()
    //{
		
    //}
   public int ExecuteNonQuery(string storedProcedure, object[] @params)
    {
        Database db = default(Database);
        int i = 0;
        try
        {
            db = DatabaseFactory.CreateDatabase(_ProvideName);
            i = db.ExecuteNonQuery(storedProcedure, @params);
        }
        catch (Exception ex)
        {

            logmessage = "App_Code-DAL-BaseSqlDataProvider- Procedure Name"+ storedProcedure+ "-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            i = -1;
        }
        finally
        {
            db = null;
        }
        return i;
      }

    public IDataReader ExecuteReader(string storedProcedure, object[] @params)
    {
        Database db = default(Database);
        try
        {
            db = DatabaseFactory.CreateDatabase(_ProvideName);
            return db.ExecuteReader(storedProcedure, @params);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-BaseSqlDataProvider- Procedure Name" + storedProcedure + "-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        finally
        {
            //log to db 
            db = null;
        }
        return null;
    }

    public int ExecuteScalar(string storedProcedure, object[] @params)
    {
        Database db = default(Database);
        int  i = 0;
        try
        {
            db = DatabaseFactory.CreateDatabase(_ProvideName);
            i = (int)db.ExecuteScalar(storedProcedure, @params);
        }
         catch (Exception ex)
        {
            logmessage = "App_Code-DAL-BaseSqlDataProvider- Procedure Name" + storedProcedure + "-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        finally
        {
            
            db = null;
        }

        return i;
    }

    public string ExecuteScalarString(string storedProcedure, object[] @params)
    {
        Database db = default(Database);
        string i = "";
        try
        {
            db = DatabaseFactory.CreateDatabase(_ProvideName);
            i = (string)db.ExecuteScalar(storedProcedure, @params);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-BaseSqlDataProvider- Procedure Name" + storedProcedure + "-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        finally
        {
            db = null;
        }

        return i;
    }


    public decimal ExecuteScalarDecimal(string storedProcedure, object[] @params)
    {
        Database db = default(Database);
        decimal i=0;
        try
        {
            db = DatabaseFactory.CreateDatabase(_ProvideName);
            i = (decimal)db.ExecuteScalar(storedProcedure, @params);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-BaseSqlDataProvider- Procedure Name" + storedProcedure + "-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        finally
        {
            db = null;
        }
        return i;
    }
   protected  object ExecuteReader(string storedProcedure, object[] @params, GenerateCollectionFromReader fofr)
    {
        Database db = default(Database);
        try
        {
            db = DatabaseFactory.CreateDatabase(_ProvideName);
            IDataReader Idata = (IDataReader)(db.ExecuteReader(storedProcedure, @params));
            return fofr(ref Idata);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code-DAL-BaseSqlDataProvider- Procedure Name" + storedProcedure + "-Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        finally
        {
            //log to db 
            db = null;
        }
        return null;
    }

   protected object ExecuteReader(string storedProcedure, object[] @params, GenerateObjectFromReader fofr)
   {
       Database db = default(Database);
       try
       {
           db = DatabaseFactory.CreateDatabase(_ProvideName);
           IDataReader Idata = (IDataReader)(db.ExecuteReader(storedProcedure, @params));
           return fofr(ref Idata);
       }
       catch (Exception ex)
       {
           logmessage = "App_Code-DAL-BaseSqlDataProvider- Procedure Name" + storedProcedure + "-Error-" + ex.ToString();
           Log.GetLog().LogInformation(logmessage);
       }
       finally
       {
           //log to db 
           db = null;
       }
       return null;
   }
   /// <summary>
   /// This Method is used to retrive data from database in a DataTable with help of StoredProcedure.
   /// </summary>   
   public DataTable GetDataTableWithProc(SqlCommand command)
   {
       try
       {
           objConnectionClass.OpenConnection();
           command.Connection = objConnectionClass.PolypexSqlConnection;
           command.CommandTimeout = 60;
           command.CommandType = CommandType.StoredProcedure;
           objSqlDa = new SqlDataAdapter();
           objDt = new DataTable();
           objSqlDa.SelectCommand = command;
           objSqlDa.Fill(objDt);
           objConnectionClass.CloseConnection();
           objConnectionClass.DisposeConnection();
           return objDt;
       }
       catch (Exception ex)
       {
           return null;
       }

   }

   /// <summary>
   /// This Method is used to retrive data from database in a DataTable with help of Query.
   /// </summary>

   public DataTable GetDataTableWithQuery(SqlCommand command)
   {
       try
       {
           objConnectionClass.OpenConnection();
           command.Connection = objConnectionClass.PolypexSqlConnection; ;
           command.CommandTimeout = 60;
           command.CommandType = CommandType.Text;
           objSqlDa = new SqlDataAdapter();
           objDt = new DataTable();
           objSqlDa.SelectCommand = command;
           objSqlDa.Fill(objDt);
           objConnectionClass.CloseConnection();
           objConnectionClass.DisposeConnection();
           return objDt;
       }
       catch (Exception ex)
       {
           return null;
       }

   }

   public SqlCommand ExecuteSqlProcedure(SqlCommand command)
   {
       try
       {
           objConnectionClass.OpenConnection();
           command.Connection = objConnectionClass.PolypexSqlConnection;
           command.CommandTimeout = 60;
           command.CommandType = CommandType.StoredProcedure;
           command.ExecuteNonQuery();
           objConnectionClass.CloseConnection();
           objConnectionClass.DisposeConnection();
           return command;
       }
       catch (Exception ex)
       {
           return command;
       }
   }


}
