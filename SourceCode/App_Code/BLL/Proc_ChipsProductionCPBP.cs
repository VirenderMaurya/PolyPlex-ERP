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


public class Proc_ChipsProductionCPBP
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields    

    private int _AutoId;
    private int _ProcessId;
    private string _Year;    
    private string _Date;
    private string _DateFrom;
    private string _TimeFrom;
    private string _DateTo;
    private string _TimeTo;
    private string _PTA;
    private string _Quantity;
    private string _MEG;
    private string _VirginQuantity;
    private string _BatchEG;
    private string _HotWellQuantity;
    private string _ATAATO;
    private string _QuantityATA;
    private string _ItemCode1;
    private string _QuantityItemCode1;
    private string _ItemCode2;
    private string _QuantityItemCode2;
    private string _ItemCode3;
    private string _QuantityItemCode3;
    private string _ItemCode4;
    private string _QuantityItemCode4;
    private string _ItemCode5;
    private string _QuantityItemCode5;
    private string _ItemCode6;
    private string _QuantityItemCode6;
    private string _ItemCode7;
    private string _QuantityItemCode7;
    private string _ItemCode8;
    private string _QuantityItemCode8;
    private string _OutputCode1;
    private string _QuantityOutputCode1;
    private string _OutputCode2;
    private string _QuantityOutputCode2;
    private string _OutputCode3;
    private string _QuantityOutputCode3;
    private string _OutputCode4;
    private string _QuantityOutputCode4;
    private string _CrudeMEGQuantity;
    private string _Water;
    private string _Lumps;
    private string _OverSize;
    private string _Residue;
    private string _PTAWaste;
    private string _NonUsableChips;
    private string _WasteMEG;
    private string _Silica;
    private string _Catalyst;
    private int _DepartmentId;
    private int _MachineId;
    private int _SubMachineId;
    private int _KKTypeId;
    private int _ProblemCodeId;
    private string _StartDate;
    private string _EndDate;
    private string _StartTime;
    private string _EndTime;
    private bool _ProcessAffected;
    private string _DetailsOfObservation;
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
    public int ProcessId
    {
        get { return _ProcessId; }
        set { _ProcessId = value; }
    }    
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public string DateFrom
    {
        get { return _DateFrom; }
        set { _DateFrom = value; }
    }
    public string TimeFrom
    {
        get { return _TimeFrom; }
        set { _TimeFrom = value; }
    }
    public string DateTo
    {
        get { return _DateTo; }
        set { _DateTo = value; }
    }
    public string TimeTo
    {
        get { return _TimeTo; }
        set { _TimeTo = value; }
    }
    public string PTA
    {
        get { return _PTA; }
        set { _PTA = value; }
    }
    public string Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string MEG
    {
        get { return _MEG; }
        set { _MEG = value; }
    }
    public string VirginQuantity
    {
        get { return _VirginQuantity; }
        set { _VirginQuantity = value; }
    }
    public string BatchEG
    {
        get { return _BatchEG; }
        set { _BatchEG = value; }
    }
    public string HotWellQuantity
    {
        get { return _HotWellQuantity; }
        set { _HotWellQuantity = value; }
    }
    public string ATAATO
    {
        get { return _ATAATO; }
        set { _ATAATO = value; }
    }
    public string QuantityATA
    {
        get { return _QuantityATA; }
        set { _QuantityATA = value; }
    }
    public string ItemCode1
    {
        get { return _ItemCode1; }
        set { _ItemCode1 = value; }
    }    
    public string ItemCode2
    {
        get { return _ItemCode2; }
        set { _ItemCode2 = value; }
    }
    public string ItemCode3
    {
        get { return _ItemCode3; }
        set { _ItemCode3 = value; }
    }
    public string ItemCode4
    {
        get { return _ItemCode4; }
        set { _ItemCode4 = value; }
    }
    public string ItemCode5
    {
        get { return _ItemCode5; }
        set { _ItemCode5 = value; }
    }
    public string ItemCode6
    {
        get { return _ItemCode6; }
        set { _ItemCode6 = value; }
    }
    public string ItemCode7
    {
        get { return _ItemCode7; }
        set { _ItemCode7 = value; }
    }
    public string ItemCode8
    {
        get { return _ItemCode8; }
        set { _ItemCode8 = value; }
    }
    public string QuantityItemCode1
    {
        get { return _QuantityItemCode1; }
        set { _QuantityItemCode1 = value; }
    }
    public string QuantityItemCode2
    {
        get { return _QuantityItemCode2; }
        set { _QuantityItemCode2 = value; }
    }
    public string QuantityItemCode3
    {
        get { return _QuantityItemCode3; }
        set { _QuantityItemCode3 = value; }
    }
    public string QuantityItemCode4
    {
        get { return _QuantityItemCode4; }
        set { _QuantityItemCode4 = value; }
    }
    public string QuantityItemCode5
    {
        get { return _QuantityItemCode5; }
        set { _QuantityItemCode5 = value; }
    }
    public string QuantityItemCode6
    {
        get { return _QuantityItemCode6; }
        set { _QuantityItemCode6 = value; }
    }
    public string QuantityItemCode7
    {
        get { return _QuantityItemCode7; }
        set { _QuantityItemCode7 = value; }
    }
    public string QuantityItemCode8
    {
        get { return _QuantityItemCode8; }
        set { _QuantityItemCode8 = value; }
    }
    public string OutputCode1
    {
        get { return _OutputCode1; }
        set { _OutputCode1 = value; }
    }
    public string OutputCode2
    {
        get { return _OutputCode2; }
        set { _OutputCode2 = value; }
    }
    public string OutputCode3
    {
        get { return _OutputCode3; }
        set { _OutputCode3 = value; }
    }
    public string OutputCode4
    {
        get { return _OutputCode4; }
        set { _OutputCode4 = value; }
    }
    public string QuantityOutputCode1
    {
        get { return _QuantityOutputCode1; }
        set { _QuantityOutputCode1 = value; }
    }
    public string QuantityOutputCode2
    {
        get { return _QuantityOutputCode2; }
        set { _QuantityOutputCode2 = value; }
    }
    public string QuantityOutputCode3
    {
        get { return _QuantityOutputCode3; }
        set { _QuantityOutputCode3 = value; }
    }
    public string QuantityOutputCode4
    {
        get { return _QuantityOutputCode4; }
        set { _QuantityOutputCode4 = value; }
    }
    public string CrudeMEGQuantity
    {
        get { return _CrudeMEGQuantity; }
        set { _CrudeMEGQuantity = value; }
    }
    public string Water
    {
        get { return _Water; }
        set { _Water = value; }
    }
    public string Lumps
    {
        get { return _Lumps; }
        set { _Lumps = value; }
    }
    public string OverSize
    {
        get { return _OverSize; }
        set { _OverSize = value; }
    }
    public string Residue
    {
        get { return _Residue; }
        set { _Residue = value; }
    }
    public string PTAWaste
    {
        get { return _PTAWaste; }
        set { _PTAWaste = value; }
    }
    public string NonUsableChips
    {
        get { return _NonUsableChips; }
        set { _NonUsableChips = value; }
    }
    public string WasteMEG
    {
        get { return _WasteMEG; }
        set { _WasteMEG = value; }
    }
    public string Silica
    {
        get { return _Silica; }
        set { _Silica = value; }
    }
    public string Catalyst
    {
        get { return _Catalyst; }
        set { _Catalyst = value; }
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
    public int ProblemCodeId
    {
        get { return _ProblemCodeId; }
        set { _ProblemCodeId = value; }
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

    public Proc_ChipsProductionCPBP()
    { }

    public string InsertUpdate_In_Proc_ChipsProductionCPBP_Trans()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertUpdate_In_Proc_ChipsProductionCPBP_Trans(this);
    }

    public DataTable BindAllChipsProductionCPBP(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_ChipsProductionCPBP_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable FillFormChipsProductionCPBP(int AutoId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Proc_ChipsProductionCPBP_ByAutoId";
        objSqlCommand.Parameters.AddWithValue("@AutoID", AutoId);       

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion

	
}