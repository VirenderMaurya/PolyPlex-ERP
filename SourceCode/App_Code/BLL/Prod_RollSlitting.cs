using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Prod_RollSlitting
/// </summary>
public class Prod_RollSlitting
{
    Connection con = new Connection();
    Common com = new Common();
    string logmessage="";
    bool val = false;
	public Prod_RollSlitting()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool saveRecords(DataTable dtrolldetails,DataTable dtprimaryinput,DataTable dtsecondaryinput,
                            string Machine,string Date, string Shift,string SetNo, string Type, string Micron,
                            string Width,string Length,string quantity, string CreatedBy)
    {
        try
        {
           
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_RollSlitting", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtOrderLineitems", dtrolldetails);
            cmd.Parameters.AddWithValue("@dtprimaryinputs", dtprimaryinput);
            cmd.Parameters.AddWithValue("@dtsecondaryinputs", dtsecondaryinput);
            cmd.Parameters.AddWithValue("@Machine", Machine);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Shift", Shift);
            cmd.Parameters.AddWithValue("@SetNo", SetNo);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Micron", Micron);
            cmd.Parameters.AddWithValue("@Width", Width);
            cmd.Parameters.AddWithValue("@Length", Length);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.ExecuteNonQuery();
            val=true;
        }
        catch (Exception ex)
        {
            val = false;
            logmessage = "Prod_RollSlitting- saveRecords -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return val;
    }


    public DataTable GetAllBatchNo(string searchwhat)
    {
        DataTable dt = null;
        try
        {
            dt = com.GetVal("@batchcode", searchwhat, "Sp_Prod_GetBatchcode");
        }
        catch (Exception ex)
        {
            logmessage = "Prod_RollSlitting- GetAllBatchNo -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return dt;
    }
    public DataTable Roll_Slitting_Secondary(string id)
    {
        DataTable dt=null;
        try
        {
          dt = com.GetVal("@id", id, "Sp_Get_Roll_Slitting_Secondary_By_AutoId");
           
        }
        catch (Exception ex)
        {
            logmessage = "Prod_RollSlitting-Roll_Slitting_Secondary -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return dt;
    }


    public bool UpdateRecords(string batchcode,string Micron,string Type,string Core, string Width,string Length,
                           string Actual_Length,string Actual_Micron, string PCakesNos,string QtyInKg, string ActualQtyInKg,
                 string SalesOrdNo,string SalesOrdLineItemNo,string NoOfJoints,string Joint1,string Joint2,
                 string Joint3,string ODMin,string ODAvg,string ODMax,string Grade,string RollCode,string Remarks,
                 string MachineArmCode,string modifiedby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_UpdateRollslittingDetails", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@batchcode", batchcode);
            cmd.Parameters.AddWithValue("@Micron", Micron);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Core", Core);
            cmd.Parameters.AddWithValue("@Width", Width);
            cmd.Parameters.AddWithValue("@Length", Length);
            cmd.Parameters.AddWithValue("@Actual_Length", Actual_Length);
            cmd.Parameters.AddWithValue("@Actual_Micron", Actual_Micron);
            cmd.Parameters.AddWithValue("@PCakesNos", PCakesNos);
            cmd.Parameters.AddWithValue("@QtyInKg", QtyInKg);
            cmd.Parameters.AddWithValue("@ActualQtyInKg", ActualQtyInKg);
            cmd.Parameters.AddWithValue("@SalesOrdNo", SalesOrdNo);
            cmd.Parameters.AddWithValue("@SalesOrdLineItemNo", SalesOrdLineItemNo);
            cmd.Parameters.AddWithValue("@NoOfJoints", NoOfJoints);
            cmd.Parameters.AddWithValue("@Joint1", Joint1);
            cmd.Parameters.AddWithValue("@Joint2", Joint2);
            cmd.Parameters.AddWithValue("@Joint3", Joint3);
            cmd.Parameters.AddWithValue("@ODMin", ODMin);
            cmd.Parameters.AddWithValue("@ODAvg", ODAvg);
            cmd.Parameters.AddWithValue("@ODMax", ODMax);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@RollCode", RollCode);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@MachineArmCode", MachineArmCode);
            cmd.Parameters.AddWithValue("@modifiedby",modifiedby);
            cmd.ExecuteNonQuery();
    
        }
        catch (Exception ex)
        {
            logmessage = "BLL/Prod_RollSlitting- UpdateRecords -Error-" + ex.ToString();
            Log.GetLog().LogInformation(logmessage);
        }
        return true;
        }
    

}