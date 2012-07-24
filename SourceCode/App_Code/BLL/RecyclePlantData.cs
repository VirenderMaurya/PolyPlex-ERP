using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for RecyclePlantData
/// </summary>
public class RecyclePlantData
{
    Connection con = new Connection();
    Common cmn = new Common();
    public RecyclePlantData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool saveRecord(string date,
        string cp1, string cc1, string lp1, string ouc1, string lc1, string tdt1, string Iv1, string cpg1, string eg1, string ac1,
        string cp2, string cc2, string lp2, string ouc2, string lc2, string tdt2, string Iv2, string cpg2, string eg2, string ac2,
        string cp3, string cc3, string lp3, string ouc3, string lc3, string tdt3, string Iv3, string cpg3, string eg3, string ac3,
        string activestatus, string createdby, string createdon, string modifiedby, string modifiedon)
    {
        try
        {
            con.OpenConnection();

            SqlCommand cmd = new SqlCommand("SP_Insert_RecyclePlantData", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Line1_Chips_Prod_MT", lc1);
            cmd.Parameters.AddWithValue("@Line1_Chips_Consump_MT", cc1);
            cmd.Parameters.AddWithValue("@Line1_Lumps_Prod_MT", lp1);
            cmd.Parameters.AddWithValue("@Line1_OverSize_UnderSize_Chips_MT", ouc1);
            cmd.Parameters.AddWithValue("@Line1_Lumps_Consmp_MT", lc1);
            cmd.Parameters.AddWithValue("@Line1_Total_Down_Time_HH_Min", tdt1);
            cmd.Parameters.AddWithValue("@Line1_IV", Iv1);
            cmd.Parameters.AddWithValue("@Line1_CPG", cpg1);
            cmd.Parameters.AddWithValue("@Line1_End_Group", eg1);
            cmd.Parameters.AddWithValue("@Line1_Ash_Content", ac1);
            cmd.Parameters.AddWithValue("@Line2_Chips_Prod_MT", cp2);
            cmd.Parameters.AddWithValue("@Line2_Chips_Consump_MT", cc2);
            cmd.Parameters.AddWithValue("@Line2_Lumps_Prod_MT", lp2);
            cmd.Parameters.AddWithValue("@Line2_OverSize_UnderSize_Chips_MT", ouc2);
            cmd.Parameters.AddWithValue("@Line2_Lumps_Consmp_MT", lc2);
            cmd.Parameters.AddWithValue("@Line2_Total_Down_Time_HH_Min", tdt2);
            cmd.Parameters.AddWithValue("@Line2_IV", Iv2);
            cmd.Parameters.AddWithValue("@Line2_CPG", cpg2);
            cmd.Parameters.AddWithValue("@Line2_End_Group", eg2);
            cmd.Parameters.AddWithValue("@Line2_Ash_Content", ac2);
            cmd.Parameters.AddWithValue("@Line3_Chips_Prod_MT", cp3);
            cmd.Parameters.AddWithValue("@Line3_Chips_Consump_MT", cc3);
            cmd.Parameters.AddWithValue("@Line3_Lumps_Prod_MT", lp3);
            cmd.Parameters.AddWithValue("@Line3_OverSize_UnderSize_Chips_MT", ouc3);
            cmd.Parameters.AddWithValue("@Line3_Lumps_Consmp_MT", lc3);
            cmd.Parameters.AddWithValue("@Line3_Total_Down_Time_HH_Min", tdt3);
            cmd.Parameters.AddWithValue("@Line3_IV", Iv3);
            cmd.Parameters.AddWithValue("@Line3_CPG", cpg3);
            cmd.Parameters.AddWithValue("@Line3_End_Group", eg3);
            cmd.Parameters.AddWithValue("@Line3_Ash_Content", ac3);
            cmd.Parameters.AddWithValue("@ActiveStatus", activestatus);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.Parameters.AddWithValue("@CreatedOn", createdon);
            cmd.Parameters.AddWithValue("@LastModifiedBy", modifiedby);
            cmd.Parameters.AddWithValue("@LastModifiedOn", modifiedon);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool updateRecord(string autoid, string date,
        string cp1, string cc1, string lp1, string ouc1, string lc1, string tdt1, string Iv1, string cpg1, string eg1, string ac1,
        string cp2, string cc2, string lp2, string ouc2, string lc2, string tdt2, string Iv2, string cpg2, string eg2, string ac2,
        string cp3, string cc3, string lp3, string ouc3, string lc3, string tdt3, string Iv3, string cpg3, string eg3, string ac3,
        string activestatus, string createdby, string createdon, string modifiedby, string modifiedon)
    {
        try
        {
            con.OpenConnection();

            SqlCommand cmd = new SqlCommand("SP_Update_RecyclePlantData", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@AutoId", autoid);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@Line1_Chips_Prod_MT", lc1);
            cmd.Parameters.AddWithValue("@Line1_Chips_Consump_MT", cc1);
            cmd.Parameters.AddWithValue("@Line1_Lumps_Prod_MT", lp1);
            cmd.Parameters.AddWithValue("@Line1_OverSize_UnderSize_Chips_MT", ouc1);
            cmd.Parameters.AddWithValue("@Line1_Lumps_Consmp_MT", lc1);
            cmd.Parameters.AddWithValue("@Line1_Total_Down_Time_HH_Min", tdt1);
            cmd.Parameters.AddWithValue("@Line1_IV", Iv1);
            cmd.Parameters.AddWithValue("@Line1_CPG", cpg1);
            cmd.Parameters.AddWithValue("@Line1_End_Group", eg1);
            cmd.Parameters.AddWithValue("@Line1_Ash_Content", ac1);
            cmd.Parameters.AddWithValue("@Line2_Chips_Prod_MT", cp2);
            cmd.Parameters.AddWithValue("@Line2_Chips_Consump_MT", cc2);
            cmd.Parameters.AddWithValue("@Line2_Lumps_Prod_MT", lp2);
            cmd.Parameters.AddWithValue("@Line2_OverSize_UnderSize_Chips_MT", ouc2);
            cmd.Parameters.AddWithValue("@Line2_Lumps_Consmp_MT", lc2);
            cmd.Parameters.AddWithValue("@Line2_Total_Down_Time_HH_Min", tdt2);
            cmd.Parameters.AddWithValue("@Line2_IV", Iv2);
            cmd.Parameters.AddWithValue("@Line2_CPG", cpg2);
            cmd.Parameters.AddWithValue("@Line2_End_Group", eg2);
            cmd.Parameters.AddWithValue("@Line2_Ash_Content", ac2);
            cmd.Parameters.AddWithValue("@Line3_Chips_Prod_MT", cp3);
            cmd.Parameters.AddWithValue("@Line3_Chips_Consump_MT", cc3);
            cmd.Parameters.AddWithValue("@Line3_Lumps_Prod_MT", lp3);
            cmd.Parameters.AddWithValue("@Line3_OverSize_UnderSize_Chips_MT", ouc3);
            cmd.Parameters.AddWithValue("@Line3_Lumps_Consmp_MT", lc3);
            cmd.Parameters.AddWithValue("@Line3_Total_Down_Time_HH_Min", tdt3);
            cmd.Parameters.AddWithValue("@Line3_IV", Iv3);
            cmd.Parameters.AddWithValue("@Line3_CPG", cpg3);
            cmd.Parameters.AddWithValue("@Line3_End_Group", eg3);
            cmd.Parameters.AddWithValue("@Line3_Ash_Content", ac3);
            cmd.Parameters.AddWithValue("@ActiveStatus", activestatus);
            cmd.Parameters.AddWithValue("@CreatedBy", createdby);
            cmd.Parameters.AddWithValue("@CreatedOn", createdon);
            cmd.Parameters.AddWithValue("@LastModifiedBy", modifiedby);
            cmd.Parameters.AddWithValue("@LastModifiedOn", modifiedon);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public DataTable getData(string time)
    {
        DataTable dt= new DataTable();
         try
        {
            string sql = "Select * from Prod_Recycle_Plant_Data_EREMA where Date='" + time + "'";
            dt = cmn.executeSqlQry(sql);
            return dt;

        }
        catch(Exception ex)
         {
            return dt;
        }
    }

    public DataTable getRecord(string autoid)
    {
        DataTable dt = new DataTable();
        try
        {
            string sql = "Select * from Prod_Recycle_Plant_Data_EREMA where AutoId='" + autoid + "'";
            dt = cmn.executeSqlQry(sql);
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
        }
    }


    public DataTable getMachineRecord(string autoid)
    {
        DataTable dt = new DataTable();
        try
        {
            string sql = "Select * from Prod_Recycle_Plant_Data_EREMA_Intermediate where AutoId='" + autoid + "'";
            dt = cmn.executeSqlQry(sql);
            return dt;

        }
        catch (Exception ex)
        {
            return dt;
        }
    }
}