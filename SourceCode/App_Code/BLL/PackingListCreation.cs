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


public class PackingListCreation
{

    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtLineItems;
    public DataTable dtToUpdateRADForPacking;

    #region Private Fields    

    string _PalletNo;
    int _SalesOrderId;
    int _NoOfItems;
    double _GrossWeight;
    string _PalletType;
    int _CreatedBy;
    int _ModifiedBy;
    int _InventoryId;
    bool _ActiveStatus;

    #endregion

    #region Properties

    public string PalletNo
    {
        get { return _PalletNo; }
        set { _PalletNo = value; }
    }
    public int SalesOrderId
    {
        get { return _SalesOrderId; }
        set { _SalesOrderId = value; }
    }
    public int NoOfItems
    {
        get { return _NoOfItems; }
        set { _NoOfItems = value; }
    }
    public double GrossWeight
    {
        get { return _GrossWeight; }
        set { _GrossWeight = value; }
    }
    public string PalletType
    {
        get { return _PalletType; }
        set { _PalletType = value; }
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
    public int InventoryId
    {
        get { return _InventoryId; }
        set { _InventoryId = value; }
    }
    public bool ActiveStatus
    {
        get { return _ActiveStatus; }
        set { _ActiveStatus = value; }
    }

    #endregion

    #region Public Methods

    public PackingListCreation()
	{}

    public string InsertUpdate_In_Sal_PackingCreation_Tran()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Sal_PackingCreation_Tran(this);
    }

    public DataTable Get_PackingCreationGridStructure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSal_PackingCreation_Tran_Structure";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_InventoryIdStructure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_InventoryIdStructure";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_GetSalesOrderByInvoiceId(string SearchType,string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetSalesOrderByInvoiceId";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_SODeatilsBySOId(int SalesOrderId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_SODeatilsBySoId";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollsAvailableForSOInGrid(int SalesOrderId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_RollsAvailableForSOId";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_AllotedLineItemsForPacking(string PalletNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllotedLineItemsForPacking";
        objSqlCommand.Parameters.AddWithValue("@PalletNo", PalletNo);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }   

    public DataTable Get_PackingCreation_Tran_For_OrderId(int SalesOrderId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Sal_PackingCreation_Tran_For_OrderId";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }      

    #endregion
}