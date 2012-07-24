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


public class RollsInternalTransfer
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    private int _RollsInternalTransferId;
    private string _Year;
    private string _IssueDate;
    private string _TransferNo;
    private int _TransferFromPlantId;
    private int _TransferToPlantId;
    private int _InventoryId;
    private int _RollNo;
    private int _SubFilmTypeId;
    private string _Micron;
    private string _Core;
    private int  _Width;
    private double _Length;
    private double _Weight;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _ModifiedBy;   
    
    #endregion

    #region Properties

    public int RollsInternalTransferId
    {
        get { return _RollsInternalTransferId; }
        set { _RollsInternalTransferId = value; }
    }
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
    public string TransferNo
    {
        get { return _TransferNo; }
        set { _TransferNo = value; }
    }
    public int TransferFromPlantId
    {
        get { return _TransferFromPlantId; }
        set { _TransferFromPlantId = value; }
    }
    public int TransferToPlantId
    {
        get { return _TransferToPlantId; }
        set { _TransferToPlantId = value; }
    }
    public int InventoryId
    {
        get { return _InventoryId; }
        set { _InventoryId = value; }
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
    public string Core
    {
        get { return _Core; }
        set { _Core = value; }
    }
    public int Width
    {
        get { return _Width; }
        set { _Width = value; }
    }
    public double Length
    {
        get { return _Length; }
        set { _Length = value; }
    }
    public double Weight
    {
        get { return _Weight; }
        set { _Weight = value; }
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

    public RollsInternalTransfer()
	{

    }

    public DataTable Get_RollAvailableGridBySearchText(int TransferFromPlantId, string RollType, string Micron, string Core, string Width, string Length)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_RollAvailableGridForRollsInternalTransfer";
        objSqlCommand.Parameters.AddWithValue("@TransferFromPlantId", TransferFromPlantId);
        objSqlCommand.Parameters.AddWithValue("@RollType", RollType);
        objSqlCommand.Parameters.AddWithValue("@Micron", Micron);
        objSqlCommand.Parameters.AddWithValue("@Core", Core);
        objSqlCommand.Parameters.AddWithValue("@Width", Width);
        objSqlCommand.Parameters.AddWithValue("@Length", Length);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollIssuedGridByTransferToPlantId(int TransferFromPlantId, int TransferToPlantId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Get_RollIssuedGridForRollsInternalTransfer";
        objSqlCommand.Parameters.AddWithValue("@TransferFromPlantId", TransferFromPlantId);
        objSqlCommand.Parameters.AddWithValue("@TransferToPlantId", TransferToPlantId);  

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public int InsertRollIssued()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertRollIssuedForRollsInternalTransfer(this);
    }

    #endregion
}