using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public class FA_InventoryItemInvoice
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtItemInventory;

    #region Private Fields

    int _AutoId;
    string _SalesWayBillNo;
    int _SalesTypeId;
    string _Year;
    int _InvoiceId;
    string _Date;
    string _DueDate;
    int _CustomerId;
    int _SalesOrderId;
    string _SalesOrderDate;
    int _CurrencyId;
    double _ExchangeRate;
    double _FixedAmount;
    double _BaseAmount;
    double _VatAmount;
    double _NetInvoiceAmount;
    bool _ActiveStatus;
    int _CreatedBy;
    int _ModifiedBy;

    int _AutoIdLineNo;
    int _AutoIdHeader;
    string _MaterialDescription;
    double _Quantity;
    string _UOM;
    double _MaterialCost;
    double _SaleRate;

    #endregion

    #region Properties

    public int AutoId
    {
        get { return _AutoId; }
        set { _AutoId = value; }
    }
    public string SalesWayBillNo
    {
        get { return _SalesWayBillNo; }
        set { _SalesWayBillNo = value; }
    }
    public int SalesTypeId
    {
        get { return _SalesTypeId; }
        set { _SalesTypeId = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public int InvoiceId
    {
        get { return _InvoiceId; }
        set { _InvoiceId = value; }
    }
    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public string DueDate
    {
        get { return _DueDate; }
        set { _DueDate = value; }
    }
    public int CustomerId
    {
        get { return _CustomerId; }
        set { _CustomerId = value; }
    }
    public int SalesOrderId
    {
        get { return _SalesOrderId; }
        set { _SalesOrderId = value; }
    }
    public string SalesOrderDate
    {
        get { return _SalesOrderDate; }
        set { _SalesOrderDate = value; }
    }
    public int CurrencyId
    {
        get { return _CurrencyId; }
        set { _CurrencyId = value; }
    }
    public double ExchangeRate
    {
        get { return _ExchangeRate; }
        set { _ExchangeRate = value; }
    }
    public double FixedAmount
    {
        get { return _FixedAmount; }
        set { _FixedAmount = value; }
    }
    public double BaseAmount
    {
        get { return _BaseAmount; }
        set { _BaseAmount = value; }
    }
    public double VatAmount
    {
        get { return _VatAmount; }
        set { _VatAmount = value; }
    }
    public double NetInvoiceAmount
    {
        get { return _NetInvoiceAmount; }
        set { _NetInvoiceAmount = value; }
    }
    public bool ActiveStatus
    {
        get { return _ActiveStatus; }
        set { _ActiveStatus = value; }
    }
    public int CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    public int ModifiedBy
    {
        get { return _ModifiedBy; }
        set { _ModifiedBy = value; }
    }

    public int AutoIdLineNo
    {
        get { return _AutoIdLineNo; }
        set { _AutoIdLineNo = value; }
    }
    public int AutoIdHeader
    {
        get { return _AutoIdHeader; }
        set { _AutoIdHeader = value; }
    }
    public string MaterialDescription
    {
        get { return _MaterialDescription; }
        set { _MaterialDescription = value; }
    }
    public double  Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string UOM
    {
        get { return _UOM; }
        set { _UOM = value; }
    }
    public double MaterialCost
    {
        get { return _MaterialCost; }
        set { _MaterialCost = value; }
    }
    public double SaleRate
    {
        get { return _SaleRate; }
        set { _SaleRate = value; }
    }  

    #endregion

    #region Public Methods

    public FA_InventoryItemInvoice()
    {}

    public DataTable Get_AllInvoice(string SearchValue)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllInvoices";
        objSqlCommand.Parameters.AddWithValue("@SearchValue", SearchValue);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_ItemInventoryDetail(int AutoIdHeader)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_ItemInventoryDetail";
        objSqlCommand.Parameters.AddWithValue("@AutoIdHeader", AutoIdHeader);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_AllItemInventoryInvoice(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllItemInventoryInvoice";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    } 

    public string InsertUpdate_In_FA_Glb_ItemInventoryInvoice_Tran()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_FA_Glb_ItemInventoryInvoice_Tran(this);
    }

    #endregion

    
}