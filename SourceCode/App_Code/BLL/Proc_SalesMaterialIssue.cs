using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SalesMaterialIssue
/// </summary>
public class SalesMaterialIssue
{
    Connection con = new Connection();
    SqlCommand objSqlCommand = new SqlCommand();

	public SalesMaterialIssue()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable FillAllSalesOrder(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_All_SalesOrder";
        objSqlCommand.Parameters.AddWithValue("@SalesOrder", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public decimal GetLastIssueNumber()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetLastIssueNumber();
    }

    public string Insert_In_MaterialIssue_Sales_Order_Header(int SaleType, string Year, string Date, int Truck, string SaleOrder, int SOCustomerID, string SOCustomerCode, string SOCustomerName, int Createdby)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_In_MaterialIssue_Sales_Order_Header(SaleType,Year, Date,Truck, SaleOrder,SOCustomerID, SOCustomerCode, SOCustomerName,Createdby);
    }


    public bool saveRecordsinMaterialIssueforSales(int IssueID, string Line, string SOLine, int MaterialCodeID, int PlantID, int ValuationTypeID, int StorageLocationID, string Batch, string Stock, string Quantity, string UOM, int value, int Createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_MaterialIssueforSales_ListItems", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IssueID", Convert.ToInt32(IssueID));
            cmd.Parameters.AddWithValue("@Line", Convert.ToInt32(Line));
            cmd.Parameters.AddWithValue("@SOLine", Convert.ToInt32(SOLine));
            cmd.Parameters.AddWithValue("@MaterialCodeID", Convert.ToInt32(MaterialCodeID));

            cmd.Parameters.AddWithValue("@PlantID", Convert.ToInt32(PlantID));
            cmd.Parameters.AddWithValue("@ValuationTypeID", Convert.ToInt32(ValuationTypeID));
            cmd.Parameters.AddWithValue("@StorageLocationID", Convert.ToInt32(StorageLocationID));
            cmd.Parameters.AddWithValue("@Batch", Convert.ToInt32(Batch));
            cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(Stock));
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToDouble(Quantity));

            cmd.Parameters.AddWithValue("@UOM", UOM);
            cmd.Parameters.AddWithValue("@value", Convert.ToInt32(value));
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(Createdby));


           

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public int UpdateMaterialSalesOrder(int Autoid, int IssueID, int SaleType, string Year, string Date, int Truck, string SaleOrder
    , int SOCustomerID, string SOCustomerCode, string SOCustomerName
    , int Line, int SOLine, int MaterialCodeID, int PlantID
    , int ValuationTypeID, int StorageLocationID, int Batch, int Stock
      , decimal Quantity, string UOM, int value, int LastModifyby)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateMaterialSalesOrder(Autoid, IssueID, SaleType, Year, Date, Truck, SaleOrder, SOCustomerID, SOCustomerCode, SOCustomerName, Line, SOLine, MaterialCodeID, PlantID, ValuationTypeID, StorageLocationID, Batch, Stock
      , Quantity, UOM, value, LastModifyby);
    }

}