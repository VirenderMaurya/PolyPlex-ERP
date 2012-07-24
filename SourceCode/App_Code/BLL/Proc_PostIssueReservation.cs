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

public class Proc_PostIssueReservation
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtLineItems;

    #region Private Fields    

    private int _AutoId;
    private string _IssueYear;
    private string _IssueDate;
    private int _ReservationId;
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
    public string IssueYear
    {
        get { return _IssueYear; }
        set { _IssueYear = value; }
    }
    public string IssueDate
    {
        get { return _IssueDate; }
        set { _IssueDate = value; }
    }
    public int ReservationId
    {
        get { return _ReservationId; }
        set { _ReservationId = value; }
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

    public Proc_PostIssueReservation()
    { }

    public DataTable BindAllIssueReservationList()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_IssueReservation_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", "ReservationNo");
        objSqlCommand.Parameters.AddWithValue("@SearchText", "");

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_IssueReservation_LineItems_Trans(int AutoId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_IssueReservation_LineItems_Trans_ForPostIssue";
        objSqlCommand.Parameters.AddWithValue("@IssueReservationId", AutoId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable GetProc_PostIssueReservation_LineItems_Trans_Structure()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_GetProc_Proc_PostIssueReservation_LineItems_Trans_Structure";

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

    public DataTable BindAllPostIssueReservationList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_PostIssueReservation_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public string InsertUpdate_In_Proc_PostIssueReservation()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Proc_PostIssueReservation(this);
    }

    #endregion
	
}