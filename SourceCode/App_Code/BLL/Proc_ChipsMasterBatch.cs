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


public class Proc_ChipsMasterBatch
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtLineItems;

    #region Private Fields    

    #region Header Fields

    private int _ChipsMasterBatchId;   
    private string _Year;
    private int _ProcessCodeId;    
    private int _MasterBatchId;
    private string _Date;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _ModifiedBy;

    #endregion

    #region Line Item Fields

    private int _LineItemID;    
    private int _MaterialCodeId;
    private int _VendorBatchId;
    private int _ValuationTypeId;
    private int _StorageLocationId;
    private double _Quantity;
    private string _PreparationDilution;
    private double _CurrentStock;

    #endregion

    #endregion

    #region Properties

    #region Header Properties

    public int ChipsMasterBatchId
    {
        get { return _ChipsMasterBatchId; }
        set { _ChipsMasterBatchId = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public int ProcessCodeId
    {
        get { return _ProcessCodeId; }
        set { _ProcessCodeId = value; }
    }
    public int MasterBatchId
    {
        get { return _MasterBatchId; }
        set { _MasterBatchId = value; }
    }
    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
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

    #region Line Item Properties

    public int LineItemID
    {
        get { return _LineItemID; }
        set { _LineItemID = value; }
    }
    public int MaterialCodeId
    {
        get { return _MaterialCodeId; }
        set { _MaterialCodeId = value; }
    }
    public int VendorBatchId
    {
        get { return _VendorBatchId; }
        set { _VendorBatchId = value; }
    }
    public int ValuationTypeId
    {
        get { return _ValuationTypeId; }
        set { _ValuationTypeId = value; }
    }
    public int StorageLocationId
    {
        get { return _StorageLocationId; }
        set { _StorageLocationId = value; }
    }
    public double Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string PreparationDilution
    {
        get { return _PreparationDilution; }
        set { _PreparationDilution = value; }
    }
    public double CurrentStock
    {
        get { return _CurrentStock; }
        set { _CurrentStock = value; }
    } 

    #endregion

    #endregion

    #region Public Methods

    public Proc_ChipsMasterBatch()
	{ }

    public string InsertUpdate_In_Proc_ChipsMasterBatch()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Proc_ChipsMasterBatch(this);
    }

    public DataTable GetProc_ChipsMasterBatch_LineItems_Trans(int ChipsMasterBatchId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_ChipsMasterBatch_LineItems_Trans";
        objSqlCommand.Parameters.AddWithValue("@ChipsMasterBatchId", ChipsMasterBatchId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_ChipsMasterBatch_LineItems_Structure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_ChipsMasterBatch_LineItems_Structure";        

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable BindAllChipsMasterBatch(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_ChipsMasterBatch_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}