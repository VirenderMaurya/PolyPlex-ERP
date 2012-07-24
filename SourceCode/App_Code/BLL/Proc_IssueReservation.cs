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


public class Proc_IssueReservation
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtLineItems;

    #region Private Fields    

    private int _AutoId;
    private string _ReservationYear;
    private string _IssueReservationDate;
    private int _CostCenterId;
    private string _GoodRecipient;
    private string _Remarks;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _ModifiedBy;

    private int _IssueReservationId;
    private int _LineNo;
    private string _BatchNo;
    private int _MaterialId;
    private int _UOMId;
    private int _PlantID;
    private int _StorageLocationId;
    private int _ValuationTypeId;
    private int _ProjectId;
    private int _SubProjectId;
    private int _PurposeId;
    private double _Quantity;

    #endregion

    #region Properties

    #region Header 

    public int AutoId
    {
        get { return _AutoId; }
        set { _AutoId = value; }
    }
    public string ReservationYear
    {
        get { return _ReservationYear; }
        set { _ReservationYear = value; }
    }
    public string IssueReservationDate
    {
        get { return _IssueReservationDate; }
        set { _IssueReservationDate = value; }
    }
    public int CostCenterId
    {
        get { return _CostCenterId; }
        set { _CostCenterId = value; }
    }
    public string GoodRecipient
    {
        get { return _GoodRecipient; }
        set { _GoodRecipient = value; }
    }
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
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

    #region LineItems

    public int IssueReservationId
    {
        get { return _IssueReservationId; }
        set { _IssueReservationId = value; }
    }
    public int LineNo
    {
        get { return _LineNo; }
        set { _LineNo = value; }
    }
    public string BatchNo
    {
        get { return _BatchNo; }
        set { _BatchNo = value; }
    }
    public int MaterialId
    {
        get { return _MaterialId; }
        set { _MaterialId = value; }
    }
    public int UOMId
    {
        get { return _UOMId; }
        set { _UOMId = value; }
    }
    public int PlantID
    {
        get { return _PlantID; }
        set { _PlantID = value; }
    }
    public int StorageLocationId
    {
        get { return _StorageLocationId; }
        set { _StorageLocationId = value; }
    }
    public int ValuationTypeId
    {
        get { return _ValuationTypeId; }
        set { _ValuationTypeId = value; }
    }
    public int ProjectId
    {
        get { return _ProjectId; }
        set { _ProjectId = value; }
    }
    public int SubProjectId
    {
        get { return _SubProjectId; }
        set { _SubProjectId = value; }
    }
    public int PurposeId
    {
        get { return _PurposeId; }
        set { _PurposeId = value; }
    }
    public double Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }    

    #endregion

    #endregion

    #region Public Methods

    public Proc_IssueReservation()
    { }

    public DataTable GetProc_IssueReservation_LineItems_Trans(int AutoId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_IssueReservation_LineItems_Trans";
        objSqlCommand.Parameters.AddWithValue("@IssueReservationId", AutoId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_IssueReservation_LineItems_Trans_Structure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_IssueReservation_LineItems_Trans_Structure";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Proc_IssueReservation_Header_Trans(int AutoId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_IssueReservation_Header_Trans";
        objSqlCommand.Parameters.AddWithValue("@AutoId", AutoId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable BindAllIssueReservationList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_IssueReservation_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public string InsertUpdate_In_Proc_IssueReservation()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Proc_IssueReservation(this);
    }

    #endregion
	
}