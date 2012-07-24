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


public class SalesOrderClosing
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    private int _SOClosingID;
    private int _OrderTypeId;
    private int _SearchTypeId;
    private string _PISONo;
    private string _OrderDate;
    private string _PIOrderNo;
    private bool _Confirmed;
    private string _CustomerOrderNo;
    private int _CustomerId;
    private string _Reason;   
    private bool _ActiveStatus;
    private int _CreatedBy;   
    private int _ModifiedBy;   

    #endregion

    #region Properties

    public int SOClosingID
    {
        get { return _SOClosingID; }
        set { _SOClosingID = value; }
    }
    public int OrderTypeId
    {
        get { return _OrderTypeId; }
        set { _OrderTypeId = value; }
    }
    public int SearchTypeId
    {
        get { return _SearchTypeId; }
        set { _SearchTypeId = value; }
    }
    public string PISONo
    {
        get { return _PISONo; }
        set { _PISONo = value; }
    }
    public string OrderDate
    {
        get { return _OrderDate; }
        set { _OrderDate = value; }
    }
    public string PIOrderNo
    {
        get { return _PIOrderNo; }
        set { _PIOrderNo = value; }
    }
    public bool Confirmed
    {
        get { return _Confirmed; }
        set { _Confirmed = value; }
    }
    public string CustomerOrderNo
    {
        get { return _CustomerOrderNo; }
        set { _CustomerOrderNo = value; }
    }
    public int CustomerId
    {
        get { return _CustomerId; }
        set { _CustomerId = value; }
    }
    public string Reason
    {
        get { return _Reason; }
        set { _Reason = value; }
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

    public SalesOrderClosing()
	{ }

    public DataTable Get_SalesOrderLineItemDetailForOrderClosing(int OrderType, int SearchType, string PISONo, bool ActiveStatus)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_SalesOrderLineItemDetailForOrderClosing";
        objSqlCommand.Parameters.AddWithValue("@OrderType", OrderType);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@PISONo", PISONo);
        objSqlCommand.Parameters.AddWithValue("@ActiveStatus", ActiveStatus);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public int InsertInSalesOrderClosing()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertInSalesOrderClosing(this);
    }

    public DataTable CheckAllocatedRollsToOrderNo(int OrderNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_CheckAllocatedRollsToOrderNoForSalesOrderClose";
        objSqlCommand.Parameters.AddWithValue("@OrderNo", OrderNo);        

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_AllClosedPIAndSO(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetAllClosedPIAndSO";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}