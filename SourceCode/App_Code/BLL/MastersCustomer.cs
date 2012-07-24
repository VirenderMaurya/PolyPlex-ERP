using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MastersCommon
/// </summary>
public class MastersCustomer
{
    Common cs = new Common();
    Connection con = new Connection();
    static DataTable dtCustomerDetails = new DataTable();
    

    public MastersCustomer()
    {

    }



    public void refreshCustomerDetails()
    {
        dtCustomerDetails = cs.executeProcedure("Sp_SelectCustomerDetails");

    }

    public DataTable getCustomerDetailsTable()
    {
        return dtCustomerDetails;
    }

    public int getPositionID(int iFlag)
    {
        try
        {
            int cid = int.Parse(dtCustomerDetails.Rows[iFlag]["CustomerID"].ToString());
            return cid;
        }
        catch (Exception ex) { return 0; }
    }

    public DataTable getCustomerAccounting(string Cid)
    {
        string sql = "Select * from Sal_Glb_Customer_Mst_Accounting where CustomerID='" + Cid + "'";
        return cs.executeSqlQry(sql);
    }

    public DataTable getCustomerSales(string Cid)
    {
        string sql = "Select * from View_CustomerMasterSales where CustomerId='" + Cid + "'";
        return cs.executeSqlQry(sql);
    }

    public string getCustomerCode()
    {
        int cid = 1;
        string cCode = "";
        try
        {
            string sql = "select MAX(customerid) as customerid from Sal_Glb_Customer_Mst";
            DataTable dt = cs.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                cid = int.Parse(dt.Rows[0]["customerid"].ToString())+1;
                cCode = "C" + cid.ToString().PadLeft(4, '0');
                return cCode;


            }
            else
            {
                return "C0001";
            }
        }
        catch (Exception ex)
        {
            return "C0001";
        }
    }

    public DataTable searchResults(string searchCriteria, string keywords)
    {
        string sql = "select * from  Sal_Glb_Customer_Mst where " + searchCriteria + " like '%" + keywords + "%'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public bool saveCustomerMaster(string Name, string Address, string Country, string Region, string Telephone, string Fax, string Email, string CustomerType, string Application,
                                    string ContactPerson, string Designation, string Department, string CTelephone, string CFax, string CEmail, string DOB, string Anniversary,
                                    string AccountDeptCont, string AccountDeptEmail, string CreditLimit, string EXIMLimit, string CreatedBy, string CreatedOn, string ModifiedBy,
                                    string ModifiedOn, string ActiveStatus, string LocationID, DataTable dtAccounting, DataTable dtsales)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Mast_InsertCustMaster", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtAccountingItems", dtAccounting);
            cmd.Parameters.AddWithValue("@dtSalesItems", dtsales);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Region", Region);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CustomerType", CustomerType);
            cmd.Parameters.AddWithValue("@Application", Application);
            cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Department", Department);
            cmd.Parameters.AddWithValue("@CTelephone", CTelephone);
            cmd.Parameters.AddWithValue("@CFax", CFax);
            cmd.Parameters.AddWithValue("@CEmail", CEmail);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Anniversary", Anniversary);
            cmd.Parameters.AddWithValue("@AccountDeptCont", AccountDeptCont);

            cmd.Parameters.AddWithValue("@AccountDeptEmail", AccountDeptEmail);
            cmd.Parameters.AddWithValue("@CreditLimit", CreditLimit);
            cmd.Parameters.AddWithValue("@EXIMLimit", EXIMLimit);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
            cmd.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);
            cmd.Parameters.AddWithValue("@ActiveStatus", ActiveStatus);
            cmd.Parameters.AddWithValue("@LocationID", LocationID);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public bool updateCustomerMaster(string cid, string cCode, string Name, string Address, string Country, string Region, string Telephone, string Fax, string Email, string CustomerType, string Application,
                                    string ContactPerson, string Designation, string Department, string CTelephone, string CFax, string CEmail, string DOB, string Anniversary,
                                    string AccountDeptCont, string AccountDeptEmail, string CreditLimit, string EXIMLimit, string CreatedBy, string CreatedOn, string ModifiedBy,
                                    string ModifiedOn, string ActiveStatus, string LocationID, DataTable dtAccounting, DataTable dtsales)
    {
        try
        {

            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Mast_UpdateCustMaster", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.AddWithValue("@dtAccountingItems", dtAccounting);
            cmd.Parameters.AddWithValue("@dtSalesItems", dtsales);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@ccode", cCode);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Region", Region);
            cmd.Parameters.AddWithValue("@Telephone", Telephone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CustomerType", CustomerType);
            cmd.Parameters.AddWithValue("@Application", Application);
            cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@Department", Department);
            cmd.Parameters.AddWithValue("@CTelephone", CTelephone);
            cmd.Parameters.AddWithValue("@CFax", CFax);
            cmd.Parameters.AddWithValue("@CEmail", CEmail);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Anniversary", Anniversary);
            cmd.Parameters.AddWithValue("@AccountDeptCont", AccountDeptCont);

            cmd.Parameters.AddWithValue("@AccountDeptEmail", AccountDeptEmail);
            cmd.Parameters.AddWithValue("@CreditLimit", CreditLimit);
            cmd.Parameters.AddWithValue("@EXIMLimit", EXIMLimit);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy);
            cmd.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);
            cmd.Parameters.AddWithValue("@ActiveStatus", ActiveStatus);
            cmd.Parameters.AddWithValue("@LocationID", LocationID);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public DataTable getCustType()
    {
        string sql = "SELECT Id,TypeCode,TypeDesc FROM Com_CustomerTypeMst";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;

    }
    public DataTable getSalesArea()
    {
        string sql = "SELECT AutoId,SalesAreaCode,SalesAreaDesc FROM Com_SalesArea_Mst";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }
    public DataTable getSalesType()
    {
        string sql = "SELECT [SalesTypeId],[Name] FROM [Com_SalesType_Mst]";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }
    public DataTable getPaymentTerms()
    {
        string sql = "SELECT [PaymentsTermsID],[PaymentTermDesc] FROM [Sal_Glb_PaymentTerms_Mst]";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }
    public DataTable getFinalDestination()
    {
        string sql = "SELECT [FinalDestinationID],[FinalDestCode] FROM [Sal_Glb_FinalDestination_Mst]";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

}