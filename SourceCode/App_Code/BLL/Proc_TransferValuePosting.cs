using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_TransferValuePosting
/// </summary>
public class Proc_TransferValuePosting
{
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand cmd = null;
    SqlDataProvider db = new SqlDataProvider();
    string logmessage = "";

	public Proc_TransferValuePosting()
	{}

    public bool saveRecords(DataTable dt, string transferdate, string year, string type,
                            string requestedby, string approvedby,string createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_TransferValuePosting", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dt);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@transferdate", transferdate);
            cmd.Parameters.AddWithValue("@requestedby", requestedby);
            cmd.Parameters.AddWithValue("@approvedby", approvedby);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_TransferValuePosting.cs - saveRecords Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }
    
    public bool updatelineitem(string transferno, string lineno, string materialcode, string uom, string valuationtype,
        string batchno, string quantity, string value, string transferdate, string type, string storagelocation,
        string plant,  string requestedby, string approvedby, string modifiedby, string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_TransferValuePosting_UpdateLineItems_ByLineId", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transferno", transferno);
            cmd.Parameters.AddWithValue("@lineno", lineno);
            cmd.Parameters.AddWithValue("@materialcode", materialcode);
            cmd.Parameters.AddWithValue("@uom", uom);
            cmd.Parameters.AddWithValue("@valuationtype", valuationtype);
            cmd.Parameters.AddWithValue("@batchno", batchno);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@transferdate", transferdate);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@storagelocation", storagelocation);
            cmd.Parameters.AddWithValue("@plant", plant);
            cmd.Parameters.AddWithValue("@requestedby", requestedby);
            cmd.Parameters.AddWithValue("@approvedby", approvedby);
            cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_TransferValuePosting.cs - updatelineitem Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }



    public bool updateheader(string transferno, string transferdate, string type, string requestedby, 
                             string approvedby, string modifiedby, string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_TransferValuePosting_UpdateHeader", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transferno", transferno);
            cmd.Parameters.AddWithValue("@transferdate", transferdate);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@requestedby", requestedby);
            cmd.Parameters.AddWithValue("@approvedby", approvedby);
            cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_TransferValuePosting.cs - updateheader Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }
    public DataTable SearchTransferValuePosting(string SearchType, string SearchText)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_SearchTransferValuePosting";
            cmd.Parameters.AddWithValue("@SearchType", SearchType);
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_TransferValuePosting.cs - SearchTransferValuePosting Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return db.GetDataTableWithProc(cmd);
    }

    public DataTable TransferValuePosting_GetLineItems_ByLineId(string transferno, string lineno)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_TransferValuePosting_GetLineItems_ByLineId";
            cmd.Parameters.AddWithValue("@Transferno", transferno);
            cmd.Parameters.AddWithValue("@lineno", lineno);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_TransferValuePosting.cs - TransferValuePosting_GetLineItems_ByLineId Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return db.GetDataTableWithProc(cmd);
    }
}