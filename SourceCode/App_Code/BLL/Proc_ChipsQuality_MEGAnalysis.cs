using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_ChipsQuality_MEGAnalysis
/// </summary>
public class Proc_ChipsQuality_MEGAnalysis
{
    #region Define global variable here
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand cmd = null;
    SqlDataProvider db = new SqlDataProvider();
    string logmessage = "";
    #endregion

	public Proc_ChipsQuality_MEGAnalysis()
	{}

    public bool saveRecords(string voucheryear, string voucherdate, string vendor, string tankerno, string giano,
                            string invoiceno, string apperance, string alph, string moisture,
                            string acidity,string nm1,string  nm2,string nm3,string aldehyde,string specificgravity,
                            string remark, string createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_ChipsQuality_MGAAnalysis", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@voucheryear", voucheryear);
            cmd.Parameters.AddWithValue("@voucherdate", voucherdate);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@tankerno", tankerno);
            cmd.Parameters.AddWithValue("@giano", giano);
            cmd.Parameters.AddWithValue("@invoiceno", invoiceno);
            cmd.Parameters.AddWithValue("@apperance", apperance);
            cmd.Parameters.AddWithValue("@alph", alph);
            cmd.Parameters.AddWithValue("@moisture", moisture);
            cmd.Parameters.AddWithValue("@acidity", acidity);
            cmd.Parameters.AddWithValue("@nm1", nm1);
            cmd.Parameters.AddWithValue("@nm2", nm2);
            cmd.Parameters.AddWithValue("@nm3", nm3);
            cmd.Parameters.AddWithValue("@aldehyde",aldehyde);
            cmd.Parameters.AddWithValue("@specificgravity", specificgravity);
            cmd.Parameters.AddWithValue("@remarks", remark);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ChipsQuality_MEGAnalysis.cs - saveRecords Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }

    public DataTable SearchMEG(string SearchType, string SearchText)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_MEGAnalysis";
            cmd.Parameters.AddWithValue("@SearchType", SearchType);
            cmd.Parameters.AddWithValue("@SearchText", SearchText);
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ChipsQuality_MEGAnalysis.cs - SearchRGP Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return db.GetDataTableWithProc(cmd);
    }



    public bool updateheader(string voucherno,string voucheryear, string voucherdate, string vendor, string tankerno, string giano,
                            string invoiceno, string apperance, string alph, string moisture,
                            string acidity,string nm1,string  nm2,string nm3,string aldehyde,string specificgravity,
                            string remark, string updatedby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Update_ChipsQuality_MEGAnalysis", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@voucherno", voucherno);
            cmd.Parameters.AddWithValue("@voucheryear", voucheryear);
            cmd.Parameters.AddWithValue("@voucherdate", voucherdate);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@tankerno", tankerno);
            cmd.Parameters.AddWithValue("@giano", giano);
            cmd.Parameters.AddWithValue("@invoiceno", invoiceno);
            cmd.Parameters.AddWithValue("@apperance", apperance);
            cmd.Parameters.AddWithValue("@alph", alph);
            cmd.Parameters.AddWithValue("@moisture", moisture);
            cmd.Parameters.AddWithValue("@acidity", acidity);
            cmd.Parameters.AddWithValue("@nm1", nm1);
            cmd.Parameters.AddWithValue("@nm2", nm2);
            cmd.Parameters.AddWithValue("@nm3", nm3);
            cmd.Parameters.AddWithValue("@aldehyde", aldehyde);
            cmd.Parameters.AddWithValue("@specificgravity", specificgravity);
            cmd.Parameters.AddWithValue("@remarks", remark);
            cmd.Parameters.AddWithValue("@ModifiedBy", updatedby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ChipsQuality_MEGAnalysis.cs - updateheader Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }
}