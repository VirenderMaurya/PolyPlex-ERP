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


public class RollAllocationDeallocation
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtLineItems;

    #region Private Fields

    private string _Year;
    private string _IssueDate;
    private int _SalesOrderId;
    private int _Invoiceid;
    private int _CustomerId;
    private int _CreatedBy;
    private int _ModifiedBy;
    private bool _IsValueExistInRAD;
    private string _AllocationType;


    #endregion

    #region Properties

    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public string IssueDate
    {
        get { return _IssueDate; }
        set { _IssueDate = value; }
    }
    public int SalesOrderId
    {
        get { return _SalesOrderId; }
        set { _SalesOrderId = value; }
    }
    public int Invoiceid
    {
        get { return _Invoiceid; }
        set { _Invoiceid = value; }
    }
    public int CustomerId
    {
        get { return _CustomerId; }
        set { _CustomerId = value; }
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
    public bool IsValueExistInRAD
    {
        get { return _IsValueExistInRAD; }
        set { _IsValueExistInRAD = value; }
    }
    public string AllocationType
    {
        get { return _AllocationType; }
        set { _AllocationType = value; }
    }

    #endregion

    #region Public Methods

    public string InsertUpdate_In_Sal_Glb_RollAllocationDeallocation_Tran()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Sal_Glb_RollAllocationDeallocation_Tran(this);
    }

    public DataTable Get_RollAllocateDeallocateGridStructure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSal_Glb_RollAllocationDeallocation_Tran_Structure";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollIssuedGridStructure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetRollIssuedGrid";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollAvailableGridBySalesOrderId(int SalesOrderId, int AllocationType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Get_RollAvailableGridBySalesOrderId";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);
        objSqlCommand.Parameters.AddWithValue("@AllocationType", AllocationType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollIssuedGridBySalesOrderId(int SalesOrderId, int AllocationType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Get_RollIssuedGridBySalesOrderId";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);
        objSqlCommand.Parameters.AddWithValue("@AllocationType", AllocationType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollAvailableExistingValueByInventoryId(int InventoryId, int SalesOrderId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Get_RollAvailableExistingValueByInventoryId";
        objSqlCommand.Parameters.AddWithValue("@InventoryId", InventoryId);
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_SearchRollGrid(string InvoiceNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_SearchGetRollGrid";
        objSqlCommand.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_InvoiceAllRecordForRoleAllocationDeallocation(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_InvoiceAllRecordForRoleAllocationDeallocation";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}