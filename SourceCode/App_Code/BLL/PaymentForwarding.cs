using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PaymentForwarding
/// </summary>
public class PaymentForwarding
{
    Common rp = new Common();
    Connection con = new Connection();
	public PaymentForwarding()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int getVoucherSeries(string fin_yr)
    {
        int vchrseries = 1;
        try
        {

            string sql = "select MAX(vchrSeries) from Sal_Glb_PaymentFrdHeader where fyear='" + fin_yr + "'";
            DataTable dt = rp.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                vchrseries = int.Parse(dt.Rows[0][0].ToString()) + 1;
            }
            else
            {
                vchrseries = 1;
            }
        }
        catch (Exception ex)
        {

        }

        return vchrseries;
    }
    public DataTable makelookupgridVendor()
    {
        string sql = "SELECT [VendorId],[VendorCode], [VendorGroup],[VendorName],[City],[ContactPersonOne] FROM [dbo].[FA_Glb_VendorMaster_Mst]";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }

    public DataTable makelookupgridVendorwithSearch(string keyword)
    {
        string sql = "SELECT [VendorId],[VendorCode], [VendorGroup],[VendorName],[City],[ContactPersonOne] FROM [dbo].[FA_Glb_VendorMaster_Mst] where [VendorCode] like '%" + keyword + "%' OR [VendorName] like '%" + keyword + "%' OR [City] like '%" + keyword + "%' OR [ContactPersonOne] like '%" + keyword + "%' OR [VendorGroup] like '%" + keyword + "%'";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }
    public DataTable gridInvoiceAvailable(string fromdate, string todate)
    {
        
        DataTable dt = rp.ExecuteSpWith2parameters("Sp_Sal_PaymentFrdInvoiceAvailable", fromdate.ToString(), todate.ToString());
        return dt;

    }

    public DataTable createColumnLineItems()
    {
        string sql = "select * from View_PaymntFrwrdLinItm where [PaymtFrdLineID]=0";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;
    }

    public bool saveRecords(DataTable dt, DateTime vchrDate, string fyear, int VendorCode, string Remarks, string CreatedBy, string CreatedOn, string ModifiedOn)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Sal_InsertPaymentFrd", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dt);
            cmd.Parameters.AddWithValue("@vchrDate", vchrDate);
            cmd.Parameters.AddWithValue("@fyear", fyear);
            cmd.Parameters.AddWithValue("@VendorCode", VendorCode);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public string makeGrid(string ddsearch, string txtsearch)
    {
        string sql = "SELECT [vchrId],[vchrDate],[VendorId],[vchrNo],[VendorCode],[VendorGroup],[VendorName] FROM [View_PaymentFrdHeader] where " + ddsearch + " like '%" + txtsearch + "%'";
        return sql;
    }

    public DataTable getHeaderInfo(string vchrid)
    {
        string sql="Select * from View_PaymentFrdHeader where vchrId='"+vchrid+"'";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;
    }

    public DataTable getLineInfo(string vchrid)
    {
        string sql = "Select * from View_PaymntFrwrdLinItm where vchrId='" + vchrid + "'";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;
    }
}