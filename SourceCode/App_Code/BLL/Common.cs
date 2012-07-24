 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Polyplex"].ConnectionString);

    Connection con = new Connection();
    private string _DateFormat = "MM/dd/yyyy";
    private IFormatProvider _FormatProvider = new System.Globalization.CultureInfo("en-US", true);
    public Common()
    {
    }

    public void cnOpen()
    {
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["Polyplex"].ConnectionString;
            cn.Open();
        }
        catch (SqlException)
        {
        }

    }


    public DataTable executeSqlQry(string sql)
    {
        DataTable dt = new DataTable();
        try
        {

            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Polyplex"].ConnectionString);
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            cn.Dispose();
            cn.Close();
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public bool executeSPmastrCommon(string tablename, string fieldname, string fieldvalue)
    {
        try
        {
            //cnOpen();
            string sql = "Insert into " + tablename + "(" + fieldname + ") values (" + fieldvalue + ")";
            executeSimpleQry(sql);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool updatemastrCommon(string tablename, string update, string condition)
    {
        try
        {
            cnOpen();
            string sql = "Update " + tablename + " set " + update + " where " + condition;
            executeSimpleQry(sql);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public string LoginUser(string sql)
    {

        DataTable dt = new DataTable();
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            cn.Dispose();
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["userID"].ToString();
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable getEnvironment(string sql)
    {

        DataTable dt = new DataTable();
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            cn.Dispose();
            cn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable getLocation(string sql)
    {

        DataTable dt = new DataTable();
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            cn.Dispose();
            cn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public string getUserLocation(string sql)
    {
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            string LocationID = ((Guid)cmd.ExecuteScalar()).ToString();
            //Guid LocationID = (Guid)cmd.ExecuteScalar();
            //string location = LocationID.ToString(); 

            cn.Dispose();
            cn.Close();
            return LocationID;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public string getUserName(string userId)
    {
        string sql = "select UserName from View_UserMaster where UserID='" + userId + "'";
        return executeSqlQry(sql).Rows[0]["UserName"].ToString();
    }

    public void executeSimpleQry(string sql)
    {
        try
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Polyplex"].ConnectionString);
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
    }
    public DataTable executeProcedure(string storedprocedurename)
    {
        DataTable dt = new DataTable();
        try
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Polyplex"].ConnectionString);
            if (cn.State == ConnectionState.Open)
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedprocedurename;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Dispose();
            cn.Close();
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
        }
    }

   public DataTable GetVal(string key,string value,string procedure)
    {
        SqlCommand objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = procedure;
        objSqlCommand.Parameters.AddWithValue(key, value);
        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    } 
    public DataTable ExecuteSpWithOne(string sp, string tablename, string fieldname, string fieldvalue)
    {
        DataTable dt = new DataTable();
        try
        {
            cnOpen();
            SqlDataAdapter da;
            da = new SqlDataAdapter(sp, cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandText = sp;
            da.SelectCommand.Parameters.Add("@tablename", tablename);
            da.SelectCommand.Parameters.Add("@colname",fieldname);
            da.SelectCommand.Parameters.Add("@colvalue", fieldvalue);
            da.Fill(dt);
            cn.Dispose();
            cn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable ExecuteSpWith2parameters(string sp, string option1, string option2)
    {
        DataTable dt = new DataTable();
        try
        {
            cnOpen();
            SqlDataAdapter da;
            da = new SqlDataAdapter(sp, cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandText = sp;
            da.SelectCommand.Parameters.Add("@parm1", option1);
            da.SelectCommand.Parameters.Add("@parm2", option2);
            da.Fill(dt);
            cn.Dispose();
            cn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return dt;
        }
    }

    public DataTable fillSearch(string moduleid)
    {
        string sql = "Select Options, Value from View_SearchCriteria where moduleFormID='" + moduleid + "'";
        DataTable dt = executeSqlQry(sql);
        return dt;
   }

    public DataTable getCurrency()
    {
        string sql = "Select CurrencyID, CurrencyCode from Com_Currency_Mst";
        DataTable dt = executeSqlQry(sql);
        return dt;
    }

    public DataTable getCountry()
    {
        string sql = "SELECT Id,CountryCode,Description from FA_CountryClassmst";
        DataTable dt = executeSqlQry(sql);
        return dt;

    }

    public DataTable getExpenses()
    {
        string sql = "Select expid, expname from Com_Glb_ExpensesList";
        DataTable dt = executeSqlQry(sql);
        return dt;
    }

   public string[] getUserRights(string Userid,string moduleformID)
    {
        try
        {
            string[] rights = {"1","0","0"};
            string sql = "SELECT [Read],[Write],[Modify] FROM Com_Role_Mst where UserId='" + Userid + "' and ModuleFormID='"+moduleformID+"'";
            DataTable dt = executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                rights[0] = dt.Rows[0]["Read"].ToString();
                rights[1] = dt.Rows[0]["Write"].ToString();
                rights[2] = dt.Rows[0]["Modify"].ToString();
                return rights;
            }
            else
            {
                return rights;

            }
        }
        catch (Exception ex)
        {
            string[] err={"1","0","0"};
            return err;
        }
    }

   public IFormatProvider FormatProvider
   {
       get { return _FormatProvider; }
   }

   public string DateFormat
   {
       get { return _DateFormat; }
   }
}