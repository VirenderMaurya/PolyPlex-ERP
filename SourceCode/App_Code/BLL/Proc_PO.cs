using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class Proc_PO
{
    Common cs = new Common();
    Connection con = new Connection();
    public Proc_PO()
    {

    }

    public DataTable getPOType()
    {
        string sql = "SELECT AutoId,POTypeDesc FROM Inv_Glb_POTypeMaster where Status='True'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;

    }
    public DataTable getPOCategory()
    {
        string sql = "SELECT AutoId,POCategory FROM Inv_POCategoryMaster where Status='True'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public DataTable getUOM()
    {
        string sql = "SP_Prod_GetUOM_mst";
        DataTable dt = cs.executeProcedure(sql);
        return dt;
    }

    public DataTable getValuation()
    {
        string sql = "SP_Prod_GetValuation_mst";
        DataTable dt = cs.executeProcedure(sql);
        return dt;
    }

    public DataTable getProject()
    {
        string sql = "Sp_FA_GetProjectCode";
        DataTable dt = cs.executeProcedure(sql);
        return dt;
    }
    public DataTable getSubProject()
    {
        string sql = "Sp_FA_GetSubProjectCode";
        DataTable dt = cs.executeProcedure(sql);
        return dt;
    }

    public int getPOSeries(string fin_yr)
    {
        int poseries = 1;
        try
        {

            string sql = "select MAX(POSeries) from Inv_Glb_POHeader where VoucherYear='" + fin_yr + "'";
            DataTable dt = cs.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                poseries = int.Parse(dt.Rows[0][0].ToString()) + 1;
            }
            else
            {
                poseries = 1;
            }
        }
        catch (Exception ex)
        {

        }

        return poseries;
    }

    public DataTable makelookupgridVendor()
    {
        string sql = "SELECT [VendorId],[VendorCode], [VendorGroup],[VendorName],[City],[ContactPersonOne] FROM [dbo].[FA_Glb_VendorMaster_Mst]";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;

    }

    public DataTable makelookupgridVendorwithSearch(string keyword)
    {
        string sql = "SELECT [VendorId],[VendorCode], [VendorGroup],[VendorName],[City],[ContactPersonOne] FROM [dbo].[FA_Glb_VendorMaster_Mst] where [VendorCode] like '%" + keyword + "%' OR [VendorName] like '%" + keyword + "%' OR [City] like '%" + keyword + "%' OR [ContactPersonOne] like '%" + keyword + "%' OR [VendorGroup] like '%" + keyword + "%'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;

    }

    public bool savePO(string POType, string POCategory, string VoucherYear, DateTime PODate, string Vendor, string PaymentTerms, string IncoCode, string Currency, double ExchangeRate,
                                    bool FixedExchRate, string VendorReference, string OurReference, string QuotationNo, DateTime QuotationDate, double Freight, double Insurance, double Packing,
                                    double Discount, string HeaderText, double VATAmount, double OtherCost, string DeliveryPlant, string PurchasingGroup, string CreatedBy, DateTime CreatedOn, string ModifiedBy,
                                    DateTime ModifiedOn, bool ActiveStatus, DataTable dtLineitems, DataTable dtPrices, DataTable dtDeliveryDays)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_PO", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dtLineitems);
            cmd.Parameters.AddWithValue("@dtPrices", dtPrices);
            cmd.Parameters.AddWithValue("@dtDeliveryDays", dtDeliveryDays);
            cmd.Parameters.AddWithValue("@POType", POType);
            cmd.Parameters.AddWithValue("@POCategory", POCategory);
            cmd.Parameters.AddWithValue("@VoucherYear", VoucherYear);
            cmd.Parameters.AddWithValue("@PODate", PODate);
            cmd.Parameters.AddWithValue("@Vendor", Vendor);
            cmd.Parameters.AddWithValue("@PaymentTerms", PaymentTerms);
            cmd.Parameters.AddWithValue("@IncoCode", IncoCode);
            cmd.Parameters.AddWithValue("@Currency ", Currency);
            cmd.Parameters.AddWithValue("@ExchangeRate", ExchangeRate);
            cmd.Parameters.AddWithValue("@FixedExchRate", FixedExchRate);
            cmd.Parameters.AddWithValue("@VendorReference", VendorReference);
            cmd.Parameters.AddWithValue("@OurReference", OurReference);
            cmd.Parameters.AddWithValue("@QuotationNo", QuotationNo);
            cmd.Parameters.AddWithValue("@QuotationDate", QuotationDate);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Insurance", Insurance);
            cmd.Parameters.AddWithValue("@Packing", Packing);
            cmd.Parameters.AddWithValue("@Discount", Discount);
            cmd.Parameters.AddWithValue("@HeaderText", HeaderText);
            cmd.Parameters.AddWithValue("@VATAmount", VATAmount);
            cmd.Parameters.AddWithValue("@OtherCost", OtherCost);
            cmd.Parameters.AddWithValue("@DeliveryPlant", DeliveryPlant);
            cmd.Parameters.AddWithValue("@PurchasingGroup", PurchasingGroup);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedOn);
            cmd.Parameters.AddWithValue("@LastChange", ModifiedBy);
            cmd.Parameters.AddWithValue("@LastChangeDate", ModifiedOn);
            cmd.Parameters.AddWithValue("@Active", ActiveStatus);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public bool updatePO(int poid, string POType, string POCategory, string VoucherYear, DateTime PODate, string Vendor, string PaymentTerms, string IncoCode, string Currency, double ExchangeRate,
                                    bool FixedExchRate, string VendorReference, string OurReference, string QuotationNo, DateTime QuotationDate, double Freight, double Insurance, double Packing,
                                    double Discount, string HeaderText, double VATAmount, double OtherCost, string DeliveryPlant, string PurchasingGroup, string CreatedBy, DateTime CreatedOn, string ModifiedBy,
                                    DateTime ModifiedOn, bool ActiveStatus, DataTable dtLineitems, DataTable dtPrices, DataTable dtDeliveryDays)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Update_PO", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@POid", poid);
            cmd.Parameters.AddWithValue("@dtLineitems", dtLineitems);
            cmd.Parameters.AddWithValue("@dtPrices", dtPrices);
            cmd.Parameters.AddWithValue("@dtDeliveryDays", dtDeliveryDays);
            cmd.Parameters.AddWithValue("@POType", POType);
            cmd.Parameters.AddWithValue("@POCategory", POCategory);
            cmd.Parameters.AddWithValue("@VoucherYear", VoucherYear);
            cmd.Parameters.AddWithValue("@PODate", PODate);
            cmd.Parameters.AddWithValue("@Vendor", Vendor);
            cmd.Parameters.AddWithValue("@PaymentTerms", PaymentTerms);
            cmd.Parameters.AddWithValue("@IncoCode", IncoCode);
            cmd.Parameters.AddWithValue("@Currency ", Currency);
            cmd.Parameters.AddWithValue("@ExchangeRate", ExchangeRate);
            cmd.Parameters.AddWithValue("@FixedExchRate", FixedExchRate);
            cmd.Parameters.AddWithValue("@VendorReference", VendorReference);
            cmd.Parameters.AddWithValue("@OurReference", OurReference);
            cmd.Parameters.AddWithValue("@QuotationNo", QuotationNo);
            cmd.Parameters.AddWithValue("@QuotationDate", QuotationDate);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Insurance", Insurance);
            cmd.Parameters.AddWithValue("@Packing", Packing);
            cmd.Parameters.AddWithValue("@Discount", Discount);
            cmd.Parameters.AddWithValue("@HeaderText", HeaderText);
            cmd.Parameters.AddWithValue("@VATAmount", VATAmount);
            cmd.Parameters.AddWithValue("@OtherCost", OtherCost);
            cmd.Parameters.AddWithValue("@DeliveryPlant", DeliveryPlant);
            cmd.Parameters.AddWithValue("@PurchasingGroup", PurchasingGroup);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedOn);
            cmd.Parameters.AddWithValue("@LastChange", ModifiedBy);
            cmd.Parameters.AddWithValue("@LastChangeDate", ModifiedOn);
            cmd.Parameters.AddWithValue("@Active", ActiveStatus);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public DataTable searchResults(string searchCriteria, string keywords)
    {
        string sql = "select * from  Inv_Glb_POHeader where " + searchCriteria + " like '%" + keywords + "%'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public DataTable getMainData(int poid)
    {
     
        string sql = "Select * from Inv_Glb_POHeader where Autoid='" + poid + "'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }

    public DataTable getDetailData(int poid)
    {

        string sql = @"Select [LineItem]
      ,[PRNumber]
      ,[MaterialCode]
      ,[POQuantity]
      ,[UOM]
      ,[Price]
      ,[Amount]
      ,[Plant]
      ,[CostCenter]
      ,[PRPrice]
      ,[PRDLVDate]
      ,[ValuationType]
      ,[ProjectCode]
      ,[SubProjectCode]
      ,[BudgetCode]
      ,[SubBudgetCode]
      ,[MaterialDescription]
      ,[Discount]
      ,[AbsPercent]
      ,[OtherCost]
      ,[PackLine]
      ,[POItemText]
      ,[LeadTime]
      ,[DelivryQuantity]
      ,[MaterialCodeName] from View_PODetails where PONumber='" + poid + "'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }
    public DataTable getPricesData(int poid)
    {

        string sql = "Select POLNNo,ConditionCode,ConditionCurrency,ConditionValue,VendorCode,Amount,AmountLC from Inv_Glb_PO_Price where PONO='" + poid + "'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }
    public DataTable getDeliveryDaysData(int poid)
    {

        string sql = "Select POLineNo,DeliveryDays,Quantity from Inv_Glb_PO_DeliveryDays where PONo='" + poid + "'";
        DataTable dt = cs.executeSqlQry(sql);
        return dt;
    }


}