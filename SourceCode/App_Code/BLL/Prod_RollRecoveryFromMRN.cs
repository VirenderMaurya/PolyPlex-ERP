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


public class Prod_RollRecoveryFromMRN
{
    SqlCommand objSqlCommand = new SqlCommand();
    public DataTable dtRollsRecoveryMRN;

    #region Private Fields

    private int _RollRecoveryId;
    private string _Year;
    private int _MaterialReturnId;
    private string _MRNDate;
    private string _RecoverDate;
    private int _InvoiceId;
    private int _SalesOrderId;
    private int _CustomerId;
    private int _InventoryId;
    private int _RollNo;
    private int _SubFilmTypeId;
    private string _Micron;
    private int _Width;
    private double _Length;
    private string _Core;
    private double _Weight;
    private bool _IsActive;
    private int _CreatedBy;
    private int _ModifiedBy;

    #endregion

    #region Properties

    public int RollRecoveryId
    {
        get { return _RollRecoveryId; }
        set { _RollRecoveryId = value; }
    }
    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public int MaterialReturnId
    {
        get { return _MaterialReturnId; }
        set { _MaterialReturnId = value; }
    } 
    public string MRNDate
    {
        get { return _MRNDate; }
        set { _MRNDate = value; }
    }
    public string RecoverDate
    {
        get { return _RecoverDate; }
        set { _RecoverDate = value; }
    }
    public int InvoiceId
    {
        get { return _InvoiceId; }
        set { _InvoiceId = value; }
    }
    public int SalesOrderId
    {
        get { return _SalesOrderId; }
        set { _SalesOrderId = value; }
    }
    public int CustomerId
    {
        get { return _CustomerId; }
        set { _CustomerId = value; }
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
    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
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
    
    public Prod_RollRecoveryFromMRN()
	{ }

    public string Insert_In_Prod_Glb_RollRecoveryFromMRN_Tran()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_In_Prod_Glb_RollRecoveryFromMRN_Tran(this);
    }  

    public DataTable Get_AllMRNForRollsRecovery(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllMRNForRollsRecovery";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollsAvailableInMRN(int MaterialReturnId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_RollsAvailableInMRN";
        objSqlCommand.Parameters.AddWithValue("@MaterialReturnId", MaterialReturnId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollsRecoveredByMRNId(int MaterialReturnId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_RollsRecoveredByMRNId";
        objSqlCommand.Parameters.AddWithValue("@MaterialReturnId", MaterialReturnId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_RollsRecoveredList(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_RollsRecoveredList";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
}