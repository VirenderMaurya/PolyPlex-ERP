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


public class MaterialReturnNote
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    private string _Year;
    private string _MRNNo;
    private string _MRNDate;
    private int _InvoiceId;
    private int _SalesOrderId;
    private int _Customer;
    private int _InventoryId;
    private int _RollNo;
    private int _SubFilmTypeId;
    private string _Micron;
    private int _Width;
    private double _Length;
    private string _Core;
    private double _Weight;
    private int _CreatedBy;
    private int _ModifiedBy;
    
    #endregion

    #region Properties

    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }
    public string MRNNo
    {
        get { return _MRNNo; }
        set { _MRNNo = value; }
    }
    public string MRNDate
    {
        get { return _MRNDate; }
        set { _MRNDate = value; }
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
    public int Customer
    {
        get { return _Customer; }
        set { _Customer = value; }
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

    public MaterialReturnNote()
	{ }

    public DataTable Get_AllocatedRollsByInvoiceId(int InvoiceId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllocatedRollsByInvoiceId";
        objSqlCommand.Parameters.AddWithValue("@InvoiceId", InvoiceId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }
    public DataTable Get_ReturnedRollsByInvoiceId(int InvoiceId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_RollsReturnedByInvoiceId";
        objSqlCommand.Parameters.AddWithValue("@InvoiceId", InvoiceId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_MaterialReturnNoteHeaderInfByInvoiceId(int InvoiceId)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_MaterialReturnNoteHeaderInfByInvoiceId";
        objSqlCommand.Parameters.AddWithValue("@InvoiceId", InvoiceId);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_MaterialReturnNoteList(string SearchType,string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_MaterialReturnNoteList";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public int Insert_In_Sal_Glb_MaterialReturnNote_Tran()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_In_Sal_Glb_MaterialReturnNote_Tran(this);
    }

    #endregion
}