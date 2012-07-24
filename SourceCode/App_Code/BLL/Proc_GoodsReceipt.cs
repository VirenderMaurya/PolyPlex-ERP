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


public class Proc_GoodsReceipt
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtLineItems;
    public DataTable dtDetailsLineItems;

    #region Private Fields    

    private int _AutoId;
    private string _GRYear;
    private string _GRDate;
    private int _POId;
    private int _VendorId;
    private string _GateEntryNo;
    private string _GateEntryDate;
    private string _TaxInvoiceNo;
    private string _TaxInvoiceDate;
    private string _SalesOrder;
    private string _VehicleNo;
    private string _DueDate;
    private string _BillofEntryNo;
    private string _BillofEntryDate;
    private double _ExchangeRate;
    private double _MaterialCost;
    private double _VATTotal;
    private double _GIATotalValue;
    private double _TotalStockUOM;
    private double _BalanceQuantity;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _ModifiedBy;    

    #endregion

    #region Properties

    public int AutoId
    {
        get { return _AutoId; }
        set { _AutoId = value; }
    }
    public string GRYear
    {
        get { return _GRYear; }
        set { _GRYear = value; }
    }
    public string GRDate
    {
        get { return _GRDate; }
        set { _GRDate = value; }
    }
    public int POId
    {
        get { return _POId; }
        set { _POId = value; }
    }
    public int VendorId
    {
        get { return _VendorId; }
        set { _VendorId = value; }
    }
    public string GateEntryNo
    {
        get { return _GateEntryNo; }
        set { _GateEntryNo = value; }
    }
    public string GateEntryDate
    {
        get { return _GateEntryDate; }
        set { _GateEntryDate = value; }
    }
    public string TaxInvoiceNo
    {
        get { return _TaxInvoiceNo; }
        set { _TaxInvoiceNo = value; }
    }
    public string TaxInvoiceDate
    {
        get { return _TaxInvoiceDate; }
        set { _TaxInvoiceDate = value; }
    }
    public string SalesOrder
    {
        get { return _SalesOrder; }
        set { _SalesOrder = value; }
    }
    public string VehicleNo
    {
        get { return _VehicleNo; }
        set { _VehicleNo = value; }
    }
    public string DueDate
    {
        get { return _DueDate; }
        set { _DueDate = value; }
    }
    public string BillofEntryNo
    {
        get { return _BillofEntryNo; }
        set { _BillofEntryNo = value; }
    }
    public string BillofEntryDate
    {
        get { return _BillofEntryDate; }
        set { _BillofEntryDate = value; }
    }
    public double ExchangeRate
    {
        get { return _ExchangeRate; }
        set { _ExchangeRate = value; }
    }
    public double MaterialCost
    {
        get { return _MaterialCost; }
        set { _MaterialCost = value; }
    }    
    public double VATTotal
    {
        get { return _VATTotal; }
        set { _VATTotal = value; }
    }
    public double GIATotalValue
    {
        get { return _GIATotalValue; }
        set { _GIATotalValue = value; }
    }
    public double TotalStockUOM
    {
        get { return _TotalStockUOM; }
        set { _TotalStockUOM = value; }
    }
    public double BalanceQuantity
    {
        get { return _BalanceQuantity; }
        set { _BalanceQuantity = value; }
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

    #endregion

    #region Public Methods

    public Proc_GoodsReceipt()
    { }

    public DataTable FillAllPONo(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllPODetails";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }   

    public DataTable BindAllGoodsReceiptList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_GoodsReceipt_Header_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_GoodsReceipt_OtherDetails_Trans(int AutoId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_GoodsReceipt_OtherDetails_LineItems_Trans";
        objSqlCommand.Parameters.AddWithValue("@GoodsReceiptId", AutoId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable BindDetailsTabGrid(int PONo, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetPOLineItemsFor_GoodsReceipt";
        objSqlCommand.Parameters.AddWithValue("@PONo", PONo);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_GoodsReceipt_DetailsLineItems_Trans_Structure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_GoodsReceipt_DetailsLineItems_Trans_Structure";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_GoodsReceipt_OtherDetails_LineItems_Structure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_GoodsReceipt_OtherDetails_LineItems_Structure";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_GoodsReceipt_Header_Trans(int AutoId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_GoodsReceipt_Header_Trans";
        objSqlCommand.Parameters.AddWithValue("@AutoId", AutoId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public string InsertUpdate_In_Proc_GoodsReceipt()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Proc_GoodsReceipt(this);
    }

    public DataTable FillAllGRNo(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllGRNoForTaxInvoiceUpdate";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
	
}