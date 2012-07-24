using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_ReturnableGatePass
/// </summary>
public class Proc_ReturnableGatePass
{
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand cmd = null;
    SqlDataProvider db = new SqlDataProvider();
    string logmessage = "";

	public Proc_ReturnableGatePass()
	{
	}
    public bool saveRecords(DataTable dt, string year, string rgpdate, string rgptype, string vendor,string gateentry, string gateentrydate, 
                            string vechileno, string goodreceiptno,string createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_ReturnableGatePass", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dt);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@rgpdate", rgpdate);
            cmd.Parameters.AddWithValue("@rgptype", rgptype);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@gateentry", gateentry);
            cmd.Parameters.AddWithValue("@gateentrydate",gateentrydate);
            cmd.Parameters.AddWithValue("@vechileno", vechileno);
            cmd.Parameters.AddWithValue("@goodreceiptno",goodreceiptno);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ReturnableGatePass.cs - saveRecords Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }


     public bool update_header_lineitem(string Rgpno,string lineno,
          string purchaseno,string materialcode,string plant,string storagelocation,string batchno,
          string estimateddateofreturn,string quantity,string approxvalue,string packed,string grossweight,
          string netweight,string serialno,string rgpdate,string rgptype,string vendor,
          string gateentry,string gateentrydate,string vechileno,string goodreceiptno,string modifiedby,string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_RGP_UpdateLineItems_ByLineId", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rgpno",Rgpno);
            cmd.Parameters.AddWithValue("@lineno", lineno);
            cmd.Parameters.AddWithValue("@purchaseno", purchaseno);
            cmd.Parameters.AddWithValue("@materialcode", materialcode);
            cmd.Parameters.AddWithValue("@plant", plant);
            cmd.Parameters.AddWithValue("@storagelocation",storagelocation);
            cmd.Parameters.AddWithValue("@batchno", quantity);
            cmd.Parameters.AddWithValue("@estimateddateofreturn",estimateddateofreturn);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@approxvalue",approxvalue);
            cmd.Parameters.AddWithValue("@packed", packed);
            cmd.Parameters.AddWithValue("@grossweight",grossweight);
            cmd.Parameters.AddWithValue("@netweight", netweight);
            cmd.Parameters.AddWithValue("@serialno",serialno);
            cmd.Parameters.AddWithValue("@rgpdate", rgpdate);
            cmd.Parameters.AddWithValue("@rgptype", rgptype);
            cmd.Parameters.AddWithValue("@vendor",vendor);
            cmd.Parameters.AddWithValue("@gateentry",gateentry);
            cmd.Parameters.AddWithValue("@gateentrydate",gateentrydate);
            cmd.Parameters.AddWithValue("@vechileno", vechileno);
            cmd.Parameters.AddWithValue("@goodreceiptno", goodreceiptno);
            cmd.Parameters.AddWithValue("@modifiedby",modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ReturnableGatePass.cs - update_header_lineitem Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }

    public bool updateheader(string Rgpno,string rgpdate,string rgptype,string vendor,string gateentry,
                             string gateentrydate,string vechileno,string goodreceiptno,string modifiedby,string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_RGP_UpdateHeader", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rgpno", Rgpno);
            cmd.Parameters.AddWithValue("@rgpdate", rgpdate);
            cmd.Parameters.AddWithValue("@rgptype", rgptype);
            cmd.Parameters.AddWithValue("@vendor",vendor);
            cmd.Parameters.AddWithValue("@gateentry",gateentry);
            cmd.Parameters.AddWithValue("@gateentrydate",gateentrydate);
            cmd.Parameters.AddWithValue("@vechileno", vechileno);
            cmd.Parameters.AddWithValue("@goodreceiptno", goodreceiptno);
            cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ReturnableGatePass.cs - updateheader Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }
    public DataTable SearchRGP(string SearchType, string SearchText)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_RGP";
            cmd.Parameters.AddWithValue("@SearchType", SearchType);
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ReturnableGatePass.cs - SearchRGP Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return db.GetDataTableWithProc(cmd);
    }

    public DataTable RGP_GetLineItems_ByLineId(string transferno, string lineno)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_RGP_GetLineItems_ByLineId";
            cmd.Parameters.AddWithValue("@Transferno", transferno);
            cmd.Parameters.AddWithValue("@lineno", lineno);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ReturnableGatePass.cs - RGP_GetLineItems_ByLineId Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
      return db.GetDataTableWithProc(cmd);
    }

}