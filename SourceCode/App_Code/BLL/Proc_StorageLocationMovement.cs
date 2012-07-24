using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_StorageLocationMovement
/// </summary>
public class Proc_StorageLocationMovement
{
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand cmd = null;
    SqlDataProvider db = new SqlDataProvider();
    string logmessage = ""; 

    public Proc_StorageLocationMovement()
	{
	
	}
    public bool saveRecords(DataTable dt,string year,string transferdate,string fromstoragelocationid,string fromstoragelocationname,
                            string tostoragelocationid,string tostoragelocationame,string requestedby,string approvedby,
                             string createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_StorageLocationMovement", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dt);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@transferdate", transferdate);
            cmd.Parameters.AddWithValue("@fromstoragelocationid", fromstoragelocationid);
            cmd.Parameters.AddWithValue("@fromstoragelocationname",fromstoragelocationname);
            cmd.Parameters.AddWithValue("@tostoragelocationid", tostoragelocationid);
            cmd.Parameters.AddWithValue("@tostoragelocationname",tostoragelocationame);
            cmd.Parameters.AddWithValue("@requestedby",requestedby);
            cmd.Parameters.AddWithValue("@approvedby", approvedby);
            cmd.Parameters.AddWithValue("@CreatedBy",createdby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_StorageLocationMovement.cs - saveRecords Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }
    
    public bool update_header_lineitem(string transferno,string lineno,string materialcode, string uom, string valuationtype, 
        string batchno, string quantity, string value,string transferdate,string fromlocationid,string fromlocationname,
        string tolocationid,string tolocationname,string requestedby,string approvedby,string modifiedby,string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_StorageLocationMovement_UpdateLineItems_ByLineId", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transferno", transferno);
            cmd.Parameters.AddWithValue("@lineno", lineno);
            cmd.Parameters.AddWithValue("@materialcode",materialcode);
            cmd.Parameters.AddWithValue("@uom", uom);
            cmd.Parameters.AddWithValue("@valuationtype", valuationtype);
            cmd.Parameters.AddWithValue("@batchno", batchno);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@transferdate", transferdate);
            cmd.Parameters.AddWithValue("@fromlocationid", fromlocationid);
            cmd.Parameters.AddWithValue("@fromlocationname", fromlocationname);
            cmd.Parameters.AddWithValue("@tolocationid", tolocationid);
            cmd.Parameters.AddWithValue("@tolocationname",tolocationname);
            cmd.Parameters.AddWithValue("@requestedby", requestedby);
            cmd.Parameters.AddWithValue("@approvedby",approvedby);
            cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_StorageLocationMovement.cs - update_header_lineitem Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }

            
    public bool updateheader(string transferno,string transferdate,string fromlocationid,string fromlocationname,
        string tolocationid,string tolocationname,string requestedby,string approvedby,string modifiedby,string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_StorageLocationMovement_UpdateHeader", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Transferno", transferno);
            cmd.Parameters.AddWithValue("@transferdate", transferdate);
            cmd.Parameters.AddWithValue("@fromlocationid", fromlocationid);
            cmd.Parameters.AddWithValue("@fromlocationname", fromlocationname);
            cmd.Parameters.AddWithValue("@tolocationid", tolocationid);
            cmd.Parameters.AddWithValue("@tolocationname",tolocationname);
            cmd.Parameters.AddWithValue("@requestedby", requestedby);
            cmd.Parameters.AddWithValue("@approvedby",approvedby);
            cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_StorageLocationMovement.cs - updateheader Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }

    public DataTable SearchStorageLocationMovement(string SearchType, string SearchText)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_SearchStorageLocation";
            cmd.Parameters.AddWithValue("@SearchType", SearchType);
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_StorageLocationMovement.cs - SearchStorageLocationMovement Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return db.GetDataTableWithProc(cmd);
    }

    public DataTable StorageLocationMovement_GetLineItems_ByLineId(string transferno, string lineno)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_StorageLocationMovement_GetLineItems_ByLineId";
            cmd.Parameters.AddWithValue("@Transferno", transferno);
            cmd.Parameters.AddWithValue("@lineno", lineno);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_StorageLocationMovement.cs - StorageLocationMovement_GetLineItems_ByLineId Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return db.GetDataTableWithProc(cmd);
    }
}