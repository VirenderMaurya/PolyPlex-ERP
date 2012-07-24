using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MasterVendor
/// </summary>
public class MasterVendor
{
    Common cs = new Common();
    Connection con = new Connection();
    static DataTable dtVendorDetails = new DataTable();
	public MasterVendor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int getPositionID(int iFlag)
    {
        try
        {
            int cid = int.Parse(dtVendorDetails.Rows[iFlag]["VendorId"].ToString());
            return cid;
        }
        catch (Exception ex) { return 0; }
    }
    public DataTable getVendorDetailsTable()
    {
        return dtVendorDetails;
    }

    public void refreshVendorDetails()
    {
        dtVendorDetails = cs.executeProcedure("Sp_SelectVendorDetails");

    }

    public DataTable searchResults(string searchCriteria, string keywords)
    {
        string sql = "select * from  View_VendorMstDetails where " + searchCriteria + " like '%" + keywords + "%'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public string getVendorCode()
    {
        int cid = 1;
        string cCode = "";
        try
        {
            string sql = "select MAX(VendorId) as VendorId from FA_Glb_VendorMaster_Mst";
            DataTable dt = cs.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                cid = int.Parse(dt.Rows[0]["VendorId"].ToString()) + 1;
                cCode = "V" + cid.ToString().PadLeft(4, '0');
                return cCode;


            }
            else
            {
                return "V0001";
            }
        }
        catch (Exception ex)
        {
            return "V0001";
        }
    }


    public bool saveVendorMaster(string VendorGroup,string VendorName, string VendorAddress, string PostalCode, string City, string Country, string Region, string TelephoneNo, string TelephoneExtn, string FAXNo,
                                    string FAXExtn, string CompanyEmailAddress1, string CompanyEmailAddress2, string ContactPersonOne, string ContactPersonOneContactNo, string ContactPersonTwo, string ContactPersonTwoContactNo, 
                                    string OldFIVendorCode,string TypeCompany, string CreatedBy, string CreatedOn, string ModifiedBy,
                                    string ModifiedOn, string ActiveStatus, DataTable dtAccountingItems, DataTable dtPurItems)
    {

      try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Mast_InsertVendorMaster", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtAccountingItems", dtAccountingItems);
            cmd.Parameters.AddWithValue("@dtPurItems", dtPurItems);
            cmd.Parameters.AddWithValue("@VendorGroup", VendorGroup);
            cmd.Parameters.AddWithValue("@VendorName", VendorName);
            cmd.Parameters.AddWithValue("@VendorAddress", VendorAddress);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Region", Region);
            cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo);
            cmd.Parameters.AddWithValue("@TelephoneExtn", TelephoneExtn);
            cmd.Parameters.AddWithValue("@FAXNo", FAXNo);
            cmd.Parameters.AddWithValue("@FAXExtn", FAXExtn);
            cmd.Parameters.AddWithValue("@CompanyEmailAddress1", CompanyEmailAddress1);
            cmd.Parameters.AddWithValue("@CompanyEmailAddress2", CompanyEmailAddress2);
            cmd.Parameters.AddWithValue("@ContactPersonOne", ContactPersonOne);
            cmd.Parameters.AddWithValue("@ContactPersonOneContactNo", ContactPersonOneContactNo);
            cmd.Parameters.AddWithValue("@ContactPersonTwo", ContactPersonTwo);
            cmd.Parameters.AddWithValue("@ContactPersonTwoContactNo", ContactPersonTwoContactNo);
            cmd.Parameters.AddWithValue("@OldFIVendorCode", OldFIVendorCode);
            cmd.Parameters.AddWithValue("@TypeCompany", TypeCompany);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
            cmd.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);
            cmd.Parameters.AddWithValue("@ActiveStatus", ActiveStatus);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public bool updateVendorMaster(string vid, string vCode,string VendorGroup,string VendorName, string VendorAddress, string PostalCode, string City, string Country, string Region, string TelephoneNo, string TelephoneExtn, string FAXNo,
                                    string FAXExtn, string CompanyEmailAddress1, string CompanyEmailAddress2, string ContactPersonOne, string ContactPersonOneContactNo, string ContactPersonTwo, string ContactPersonTwoContactNo, 
                                    string OldFIVendorCode,string TypeCompany, string CreatedBy, string CreatedOn, string ModifiedBy,
                                    string ModifiedOn, string ActiveStatus, DataTable dtAccountingItems, DataTable dtPurItems)
    {
        try
        {

            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Mast_UpdateVendorMaster", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vid", vid);
            cmd.Parameters.AddWithValue("@vcode", vCode);
            cmd.Parameters.AddWithValue("@dtAccountingItems", dtAccountingItems);
            cmd.Parameters.AddWithValue("@dtPurItems", dtPurItems);
            cmd.Parameters.AddWithValue("@VendorGroup", VendorGroup);
            cmd.Parameters.AddWithValue("@VendorName", VendorName);
            cmd.Parameters.AddWithValue("@VendorAddress", VendorAddress);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Region", Region);
            cmd.Parameters.AddWithValue("@TelephoneNo", TelephoneNo);
            cmd.Parameters.AddWithValue("@TelephoneExtn", TelephoneExtn);
            cmd.Parameters.AddWithValue("@FAXNo", FAXNo);
            cmd.Parameters.AddWithValue("@FAXExtn", FAXExtn);
            cmd.Parameters.AddWithValue("@CompanyEmailAddress1", CompanyEmailAddress1);
            cmd.Parameters.AddWithValue("@CompanyEmailAddress2", CompanyEmailAddress2);
            cmd.Parameters.AddWithValue("@ContactPersonOne", ContactPersonOne);
            cmd.Parameters.AddWithValue("@ContactPersonOneContactNo", ContactPersonOneContactNo);
            cmd.Parameters.AddWithValue("@ContactPersonTwo", ContactPersonTwo);
            cmd.Parameters.AddWithValue("@ContactPersonTwoContactNo", ContactPersonTwoContactNo);
            cmd.Parameters.AddWithValue("@OldFIVendorCode", OldFIVendorCode);
            cmd.Parameters.AddWithValue("@TypeCompany", TypeCompany);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
            cmd.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);
            cmd.Parameters.AddWithValue("@ActiveStatus", ActiveStatus);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public DataTable getVendorGroup()
    {
        string sql = "SELECT [Id],[GroupCode],[GroupDesc] FROM [Com_VendorGrpMst]";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;

    }
    public DataTable getPaymentTerms()
    {
        string sql = "SELECT [PaymentsTermsID],[PaymentTermDesc] FROM [Sal_Glb_PaymentTerms_Mst]";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public DataTable getPurchaseArea()
    {
        string sql = "SELECT [AutoId],[PurchaseAreaDesc] FROM [Com_PurchaseArea_Mst]";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public DataTable getVendorAccounting(string Cid)
    {
        string sql = "Select * from FA_Glb_VendorMaster_Accounting where VendorId='" + Cid + "'";
        return cs.executeSqlQry(sql);
    }

    public DataTable getVendorPurchase(string Cid)
    {
        string sql = "Select * from View_VendorMstPurchase where VendorId='" + Cid + "'";
        return cs.executeSqlQry(sql);
    }
}