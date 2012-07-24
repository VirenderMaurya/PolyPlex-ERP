using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_NonReturnableGatePass
/// </summary>
public class Proc_NonReturnableGatePass
{
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand cmd = null;
    string logmessage = "";
    SqlDataProvider db = new SqlDataProvider();

	public Proc_NonReturnableGatePass()
	{
	}
    public bool saveRecords(DataTable dt, string year, string nrgpdate, string nrgptype, string vendor, string gateentry, string gateentrydate,
                         string vechileno,string goodreceipt,string goodreceiptno,string creditnotes,string createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_NonReturnableGatePass", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dt);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@nrgpdate", nrgpdate);
            cmd.Parameters.AddWithValue("@nrgptype", nrgptype);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@gateentry", gateentry);
            cmd.Parameters.AddWithValue("@gateentrydate", gateentrydate);
            cmd.Parameters.AddWithValue("@vechileno", vechileno);
            cmd.Parameters.AddWithValue("@goodreceipt", goodreceipt);
            cmd.Parameters.AddWithValue("@goodreceiptno", goodreceiptno);
            cmd.Parameters.AddWithValue("@creditnotes", creditnotes);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_NonReturnableGatePass.cs - saveRecords Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }


    public bool update_header_lineitem(string NonRgpno, string lineno,
         string materialcode, string plant,string valuationtype, string storagelocation, string batchno,
         string quantity, string value, string nonrgpdate, string nonrgptype, string vendor,
         string gateentry, string gateentrydate, string vechileno, string goodreceipt,
        string goodreceiptno,string creditnotes,string modifiedby, string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_NonRGP_UpdateLineItems_ByLineId", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRgpno", NonRgpno);
            cmd.Parameters.AddWithValue("@lineno", lineno);
            cmd.Parameters.AddWithValue("@materialcode", materialcode);
            cmd.Parameters.AddWithValue("@plant", plant);
            cmd.Parameters.AddWithValue("@valuationtype", valuationtype);
            cmd.Parameters.AddWithValue("@storagelocation", storagelocation);
            cmd.Parameters.AddWithValue("@batchno", batchno);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@nonrgpdate", nonrgpdate);
            cmd.Parameters.AddWithValue("@nonrgptype", nonrgptype);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@gateentry", gateentry);
            cmd.Parameters.AddWithValue("@gateentrydate", gateentrydate);

            cmd.Parameters.AddWithValue("@vechileno", vechileno);
            cmd.Parameters.AddWithValue("@goodreceipt", goodreceipt);
            cmd.Parameters.AddWithValue("@goodreceiptno", goodreceiptno);
            cmd.Parameters.AddWithValue("@creditnotes", creditnotes);
            cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_NonReturnableGatePass.cs - update_header_lineitem Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }

    public bool updateheader(string NonRgpno, string Nonrgpdate, string Nonrgptype, string vendor, string gateentry,
                             string gateentrydate, string vechileno, string goodreceipt,string goodreceiptno,
                             string creditnotes,string modifiedby, string year)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_NonRGP_UpdateHeader", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NonRgpno", NonRgpno);
            cmd.Parameters.AddWithValue("@Nonrgpdate", Nonrgpdate);
            cmd.Parameters.AddWithValue("@Nonrgptype", Nonrgptype);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@gateentry", gateentry);
            cmd.Parameters.AddWithValue("@gateentrydate", gateentrydate);
            cmd.Parameters.AddWithValue("@vechileno", vechileno);
            cmd.Parameters.AddWithValue("@goodreceipt", goodreceipt);
            cmd.Parameters.AddWithValue("@goodreceiptno", goodreceiptno);
            cmd.Parameters.AddWithValue("@creditnotes", creditnotes);
            cmd.Parameters.AddWithValue("@modifiedby", modifiedby);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_NonReturnableGatePass.cs - updateheader Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }
    public DataTable SearchNRGP(string SearchType, string SearchText)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_NRGP";
            cmd.Parameters.AddWithValue("@SearchType", SearchType);
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_NonReturnableGatePass.cs - SearchNRGP Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);  
        }
        return db.GetDataTableWithProc(cmd);
    }

    public DataTable NonRGP_GetLineItems_ByLineId(string NonRGPNo, string lineno)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_NonRGP_GetLineItems_ByLineId";
            cmd.Parameters.AddWithValue("@NonRGPno", NonRGPNo);
            cmd.Parameters.AddWithValue("@lineno", lineno);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_NonReturnableGatePass.cs - NonRGP_GetLineItems_ByLineId Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
       return db.GetDataTableWithProc(cmd);
    }
}