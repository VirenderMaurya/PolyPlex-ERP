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

public class SAL_StockLotReservation
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    private int _StockLotRollReservationId;
    private int _InventoryId;
    private int _SalesOrderId;
    private int _LineNo;
    private int _Invoiceid;
    private int _CustomerId;
    private int _RollNo;
    private int _SubFilmTypeId;
    private string _Micron;
    private double _Width;
    private double _Length;
    private string _Core;
    private double _Weight;
    private bool _IS_Pac;
    private bool _Is_Date;
    private bool _Is_Allocate;
    private string _ftype;
    private bool _IsPackingCreation;
    private int _CreatedBy;
    private int _ModifiedBy;
    private bool _ActiveStatus;
    private bool _IsValueExistInRAD;


    #endregion

    #region Properties

    public int StockLotRollReservationId
    {
        get { return _StockLotRollReservationId; }
        set { _StockLotRollReservationId = value; }
    }
    public int InventoryId
    {
        get { return _InventoryId; }
        set { _InventoryId = value; }
    }
    public int SalesOrderId
    {
        get { return _SalesOrderId; }
        set { _SalesOrderId = value; }
    }
    public int LineNo
    {
        get { return _LineNo; }
        set { _LineNo = value; }
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
    public int RollNo
    {
        get { return _RollNo; }
        set { _RollNo = value; }
    }
    public int SubFilmTypeId
    {
        get { return _SubFilmTypeId; }
        set { _SubFilmTypeId = value; }
    }
    public string Micron
    {
        get { return _Micron; }
        set { _Micron = value; }
    }
    public double Width
    {
        get { return _Width; }
        set { _Width = value; }
    }
    public double Length
    {
        get { return _Length; }
        set { _Length = value; }
    }
    public string Core
    {
        get { return _Core; }
        set { _Core = value; }
    }
    public double Weight
    {
        get { return _Weight; }
        set { _Weight = value; }
    }
    public bool IS_Pac
    {
        get { return _IS_Pac; }
        set { _IS_Pac = value; }
    }
    public bool Is_Date
    {
        get { return _Is_Date; }
        set { _Is_Date = value; }
    }
    public bool Is_Allocate
    {
        get { return _Is_Allocate; }
        set { _Is_Allocate = value; }
    }
    public string ftype
    {
        get { return _ftype; }
        set { _ftype = value; }
    }
    public bool IsPackingCreation
    {
        get { return _IsPackingCreation; }
        set { _IsPackingCreation = value; }
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
    public bool ActiveStatus
    {
        get { return _ActiveStatus; }
        set { _ActiveStatus = value; }
    }
    public bool IsValueExistInRAD
    {
        get { return _IsValueExistInRAD; }
        set { _IsValueExistInRAD = value; }
    }

    #endregion

    #region Public Methods

    public SAL_StockLotReservation(){ }

    public int InsertRollIssuedForStockLotReservation()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertRollIssuedForStockLotReservation(this);
    }

    public DataTable Get_SalesOrderForStockLotreservation(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_SalesOrderForStockLotreservation";
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

    public DataTable Get_AllRollAvailableForStockLotReservation()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Get_AllRollAvailableForStockLotReservation";       

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollIssuedBySOIdForStockLotRollReserv(int SalesOrderId, int LineNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Get_RollIssuedBySOIdForStockLotRollReserv";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);
        objSqlCommand.Parameters.AddWithValue("@LineNo", LineNo); 

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Check_RollsIssuesForLineItem(int SalesOrderId, int LineNo)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Get_RollIssuedBySOIdForStockLotRollReserv";
        objSqlCommand.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);
        objSqlCommand.Parameters.AddWithValue("@LineNo", LineNo);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}