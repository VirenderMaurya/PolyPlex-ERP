using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_ChipsQuality_PTAAnalysis
/// </summary>
public class Proc_ChipsQuality_PTAAnalysis
{
    #region Define global variable here
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand cmd = null;
    SqlDataProvider db = new SqlDataProvider();
    string logmessage = "";
    #endregion

    public Proc_ChipsQuality_PTAAnalysis()
    { }
    public bool saveRecords(string voucheryear, string voucherdate, string vendor, string truckno, string giano, 
                            string invoiceno,string baglotno,string apperance,string particlesize,string solubility,
                            string alph,string ash,string acidno,string moisture,string remark, string createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_ChipsQuality_PTAAnalysis", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@voucheryear", voucheryear);
            cmd.Parameters.AddWithValue("@voucherdate", voucherdate);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@truckno", truckno);
            cmd.Parameters.AddWithValue("@giano", giano);
            cmd.Parameters.AddWithValue("@invoiceno", invoiceno);
            cmd.Parameters.AddWithValue("@baglotno", baglotno);
            cmd.Parameters.AddWithValue("@apperance", apperance);
            cmd.Parameters.AddWithValue("@particlesize",particlesize);
            cmd.Parameters.AddWithValue("@solubility",solubility);
            cmd.Parameters.AddWithValue("@alph", alph);
            cmd.Parameters.AddWithValue("@ash",ash);
            cmd.Parameters.AddWithValue("@acidno",acidno);
            cmd.Parameters.AddWithValue("@moisture",moisture);
            cmd.Parameters.AddWithValue("@remarks",remark);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ChipsQuality_PTAAnalysis.cs - saveRecords Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }

    public DataTable SearchPTA(string SearchType, string SearchText)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Sp_Proc_PTAAnalysis";
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

    public bool updateheader(string voucherno,string voucheryear, string voucherdate, string vendor, string truckno, string giano,
                            string invoiceno, string baglotno, string apperance, string particlesize, string solubility,
                            string alph, string ash, string acidno, string moisture, string remark, string updatedby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Update_ChipsQuality_PTAAnalysis", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@voucherno", voucherno);
            cmd.Parameters.AddWithValue("@voucheryear", voucheryear);
            cmd.Parameters.AddWithValue("@voucherdate", voucherdate);
            cmd.Parameters.AddWithValue("@vendor", vendor);
            cmd.Parameters.AddWithValue("@truckno", truckno);
            cmd.Parameters.AddWithValue("@giano", giano);
            cmd.Parameters.AddWithValue("@invoiceno", invoiceno);
            cmd.Parameters.AddWithValue("@baglotno", baglotno);
            cmd.Parameters.AddWithValue("@apperance", apperance);
            cmd.Parameters.AddWithValue("@particlesize", particlesize);
            cmd.Parameters.AddWithValue("@solubility", solubility);
            cmd.Parameters.AddWithValue("@alph", alph);
            cmd.Parameters.AddWithValue("@ash", ash);
            cmd.Parameters.AddWithValue("@acidno", acidno);
            cmd.Parameters.AddWithValue("@moisture", moisture);
            cmd.Parameters.AddWithValue("@remarks", remark);
            cmd.Parameters.AddWithValue("@ModifiedBy", updatedby);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            logmessage = "App_Code/Proc_ChipsQuality_PTAAnalysis.cs - updateheader Method -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
            return false;
        }
    }

}