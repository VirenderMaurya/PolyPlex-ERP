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


public class Prod_DownTime
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    private int _AutoID;
    private int _IntermediateAutoID;
    private string _Year;
    private string _ProcessType;
    private int _PlantId ;
   
    private string _VoucherDate;
    private int _LineId ;
    private int _AreaId ;
    private int _DepartmentId ;

    private int _MachineId ;
    private int _SubMachineId ;
    private int _KKTypeId ;
    private int _ProblemCodeDescId ;
    private string _StartDate;
    private string _StartTime;
    private string _EndDate;
    private string _EndTime;
    private bool _ProcessAffected ;
    private string _DetailsOfObservation;
    private bool _ActiveStatus ;
    private int _CreatedBy ;
    private int _ModifiedBy;

    #endregion

    #region Properties

    public int AutoID
    {
        get { return _AutoID; }
        set { _AutoID = value; }
    }
    public int IntermediateAutoID
    {
        get { return _IntermediateAutoID; }
        set { _IntermediateAutoID = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public string ProcessType
    {
        get { return _ProcessType; }
        set { _ProcessType = value; }
    }
    public int PlantId
    {
        get { return _PlantId; }
        set { _PlantId = value; }
    }
   
    public string VoucherDate
    {
        get { return _VoucherDate; }
        set { _VoucherDate = value; }
    }
    public int LineId
    {
        get { return _LineId; }
        set { _LineId = value; }
    }
    public int AreaId
    {
        get { return _AreaId; }
        set { _AreaId = value; }
    }
    public int DepartmentId
    {
        get { return _DepartmentId; }
        set { _DepartmentId = value; }
    }

    public int MachineId
    {
        get { return _MachineId; }
        set { _MachineId = value; }
    }
    public int SubMachineId
    {
        get { return _SubMachineId; }
        set { _SubMachineId = value; }
    }
    public int KKTypeId
    {
        get { return _KKTypeId; }
        set { _KKTypeId = value; }
    }
    public int ProblemCodeDescId
    {
        get { return _ProblemCodeDescId; }
        set { _ProblemCodeDescId = value; }
    }
    public string StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }
    public string StartTime
    {
        get { return _StartTime; }
        set { _StartTime = value; }
    }
    public string EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }
    public string EndTime
    {
        get { return _EndTime; }
        set { _EndTime = value; }
    }
    public bool ProcessAffected
    {
        get { return _ProcessAffected; }
        set { _ProcessAffected = value; }
    }
    public string DetailsOfObservation
    {
        get { return _DetailsOfObservation; }
        set { _DetailsOfObservation = value; }
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

    public Prod_DownTime()
	{ }

    public string InsertAndUpdate_In_Prod_PET_MET_Downtime()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertAndUpdate_In_Prod_PET_MET_Downtime(this);
    }

    public DataTable Get_Prod_PET_MET_Downtime_Intermediate_AllRecords()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_PET_MET_Downtime_Intermediate_AllRecords";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_PET_MET_Downtime_AllRecords(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_PET_MET_Downtime_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_PET_MET_Downtime_BothTable(int DownTimeId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_PET_MET_Downtime_BothTable_BothTable";
        objSqlCommand.Parameters.AddWithValue("@DownTimeId", DownTimeId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}