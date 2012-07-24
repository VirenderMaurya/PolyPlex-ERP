using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_SalesOrderInventory
/// </summary>
public class Proc_SalesOrderInventory
{
    Connection con = new Connection();
    Common com = new Common();

    SqlCommand objSqlCommand = new SqlCommand();
    #region PrivateFiles
    private int _autoid;
    private string _MaterialCode;
    private string _LineCode;
    private string _Code;
    private string _Desc;
    private string _PlantCode;
    private string _PlantName;

    private string _CreatedBy;
    private string _CreatedOn;
    private string _LastModifiedBy;
    private string _LastModifiedOn;
    private string _ValueType;
    private string _Location;
    private string _StorageLocCode;

    private string _Year;
    private int _Entry;
    private DateTime _EntryDate;
    private int _Scrapid;


    
    #endregion

    #region Public Properties
    public int autoId
    {
        get { return _autoid; }
        set { _autoid = value; }
    }

    public string MaterialCode
    {
        get { return _MaterialCode; }
        set { _MaterialCode = value; }
    }

    public string LineCode
    {
        get { return _LineCode; }
        set { _LineCode = value; }
    }

  
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }

    public string CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }

    public string LastModifiedBy
    {
        get { return _LastModifiedBy; }
        set { _LastModifiedBy = value; }
    }

    public string LastModifiedOn
    {
        get { return _LastModifiedOn; }
        set { _LastModifiedOn = value; }
    }

    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }

    public string Desc
    {
        get { return _Desc; }
        set { _Desc = value; }
    }


    public string PlantCode
    {
        get { return _PlantCode; }
        set { _PlantCode = value; }
    }


    public string PlantName
    {
        get { return _PlantName; }
        set { _PlantName = value; }
    }

    public string Valuetype
    {
        get { return _ValueType; }
        set { _ValueType = value; }
    }

    public string Location
    {
        get { return _Location; }
        set { _Location = value; }
    }


    public string StorageLocCode
    {
        get { return _StorageLocCode; }
        set { _StorageLocCode = value; }
    }


    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }

    public int Entry
    {
        get { return _Entry; }
        set { _Entry = value; }
    }

    public DateTime EntryDate
    {
        get { return _EntryDate; }
        set { _EntryDate = value; }
    }

    public int ScarpID
    {
        get { return _Scrapid; }
        set { _Scrapid = value; }
    }

    #endregion
	public Proc_SalesOrderInventory()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public BLLCollection<Proc_SalesOrderInventory> Get_MaterialType()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_MaterialType();
    }

    public DataTable FillAllPaymentTerms(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "[Sp_Get_All_PaymentTerms]";
        objSqlCommand.Parameters.AddWithValue("@PaymentTerm", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }


    public string Insert_In_Inventory_Sales_Order_Header(int SalesType, string Year, string Date, int CustomerCode, int ConsigneeCode, int DeliveryTo, int MatType, int CustomerOrderNumber, string CustomerOrderDate, int CurrencyCode, int VatRate, int FinalDestination, int PaymentTerm, int DeliveryTerms, int PaymentMode,string special, int Createdby)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_In_Inventory_Sales_Order_Header(SalesType, Year, Date, CustomerCode, ConsigneeCode, DeliveryTo, MatType, CustomerOrderNumber, CustomerOrderDate, CurrencyCode, VatRate, FinalDestination, PaymentTerm, DeliveryTerms, PaymentMode, special,Createdby);
    }

    public bool saveRecordsinSalesOrderInventory(int OrderID, string Line, string MaterialCode, string StockOUM, string Rate,  string Quantity, string Status, string CreatedBy)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_InventorySalesOrder_ListItems", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", Convert.ToInt32(OrderID));
            cmd.Parameters.AddWithValue("@Line",  Convert.ToInt32(Line));
            cmd.Parameters.AddWithValue("@MaterialCode", Convert.ToInt32(MaterialCode));
            cmd.Parameters.AddWithValue("@UOM", StockOUM);
            cmd.Parameters.AddWithValue("@Rate",  Convert.ToInt32(Rate));
            
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToDouble(Quantity));
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(CreatedBy));


            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public decimal GetLastOrderNumber()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetLastOrderNumber();
    }

    public int UpdateSalesOrder(int Autoid, int SalesType, string Year, string Date, int CustomerCode, int ConsigneeCode, int DeliveryTo, int MatType, int CustomerOrderNumber, string CustomerOrderDate, int CurrencyCode, int VatRate, int FinalDestination, int PaymentTerm, int DeliveryTerms, int PaymentMode,string Special, int OrderID, int MaterialCode, string StockOUM, string Rate, decimal Quantity, int Createdby)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateSalesOrder(Autoid, SalesType, Year, Date, CustomerCode, ConsigneeCode, DeliveryTo, MatType, CustomerOrderNumber, CustomerOrderDate, CurrencyCode, VatRate, FinalDestination, PaymentTerm, DeliveryTerms, PaymentMode,Special, OrderID, MaterialCode, StockOUM, Rate, Quantity, Createdby);
    }

}