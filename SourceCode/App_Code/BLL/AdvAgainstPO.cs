using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AdvAgainstPO
/// </summary>
public class AdvAgainstPO
{
    Common rp = new Common();
    Connection con = new Connection();
	public AdvAgainstPO()
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

            string sql = "select MAX(vchrSeries) from FA_Glb_AdvanceAgainstPOHdr where fyear='" + fin_yr + "'";
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

    public DataTable makelookupgridBank()
    {
        string sql = "SELECT GeneralLedgerCode,GLDescription FROM View_GLMaster where GroupGLCode='2600' ";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }

    public DataTable makelookupgridBankwithSearch(string keyword)
    {
        string sql = "SELECT GeneralLedgerCode,GLDescription FROM [dbo].[View_GLMaster] where GroupGLCode='2600' and ([GeneralLedgerCode] like '%" + keyword + "%' OR [GLDescription] like '%" + keyword + "%')";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }
    public DataTable makelookupgridPO()
    {
        string sql = "SELECT Autoid,PONumber,PODate,VendorCode,PaymentTerms,ExchangeRate FROM Inv_Glb_POHeader ";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }

    public DataTable makelookupgridPOwithSearch(string keyword)
    {
        string sql = "SELECT Autoid,PONumber,PODate,VendorCode,PaymentTerms,ExchangeRate FROM Inv_Glb_POHeader where [PONumber] like '%" + keyword + "%' OR [VendorCode] like '%" + keyword + "%'";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }

    public DataTable getPOValues(string autoid)
    {
        string sql = "Select * from Inv_Glb_POHeader where Autoid='"+autoid+"'";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }

    public bool saveRecords(DataTable dt, DateTime vchrDate, string fyear, string bankGLCode, string currency, string exchangeRate, string localbankcharges, string foreignBankCharges, string FxBankChargesLC, string chequeNo, DateTime ChequeDate, string CreatedBy, string CreatedOn,string Modifiedby, string ModifiedOn)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Sal_AdvAgainstPO", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dt);
            cmd.Parameters.AddWithValue("@vchrDate", vchrDate);
            cmd.Parameters.AddWithValue("@fyear", fyear);
            cmd.Parameters.AddWithValue("@bankGlCode", bankGLCode);
            cmd.Parameters.AddWithValue("@currency", currency);

            cmd.Parameters.AddWithValue("@ExchangeRate", exchangeRate);
            cmd.Parameters.AddWithValue("@localbankCharges", localbankcharges);
            cmd.Parameters.AddWithValue("@ForeignBankCharges", foreignBankCharges);
            cmd.Parameters.AddWithValue("@FxBankChargesLC", FxBankChargesLC);
            cmd.Parameters.AddWithValue("@ChequeNo", chequeNo);
            cmd.Parameters.AddWithValue("@ChequeDate", ChequeDate);
           

            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@ModifiedBy", Modifiedby);
            cmd.Parameters.AddWithValue("@ModifiedOn", ModifiedOn);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


}