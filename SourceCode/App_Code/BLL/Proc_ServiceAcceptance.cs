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

public class Proc_ServiceAcceptance
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtLineItems;

    #region Private Fields    

    private int _AutoId;
    private string _VoucherYear;
    private string _VoucherDate;
    private int _POId;
    private int _VendorId;
    private string _TaxInvoiceNo;
    private string _TaxInvoiceDate;
    private string _DueDate;
    private double _TotalPOValue;
    private double _TotalPOFXValue;
    private double _VATTotal;
    private double _GIATotalValue;
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
    public string VoucherYear
    {
        get { return _VoucherYear; }
        set { _VoucherYear = value; }
    }
    public string VoucherDate
    {
        get { return _VoucherDate; }
        set { _VoucherDate = value; }
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
    public string DueDate
    {
        get { return _DueDate; }
        set { _DueDate = value; }
    }
    public double TotalPOValue
    {
        get { return _TotalPOValue; }
        set { _TotalPOValue = value; }
    }
    public double TotalPOFXValue
    {
        get { return _TotalPOFXValue; }
        set { _TotalPOFXValue = value; }
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

    public Proc_ServiceAcceptance()
    { }

    public DataTable FillAllPONo(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllPODetails";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable BindAllServiceAcceptanceList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_ServiceAcceptance_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable BindServiceAcceptanceHeader(int AutoId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_ServiceAcceptanceHeaderByAutoId";
        objSqlCommand.Parameters.AddWithValue("@AutoId", AutoId);        

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_ServiceAcceptance_LineItems_Trans_Structure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_ServiceAcceptance_LineItems_Trans_Structure";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable BindServiceAcceptanceGrid(int PONo, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetPOLineItemsFor_ServiceAcceptance";
        objSqlCommand.Parameters.AddWithValue("@PONo", PONo);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public string InsertUpdate_In_Proc_ServiceAcceptance()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Proc_ServiceAcceptance(this);
    }

    #endregion
	
}