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


public class Prod_JumboIssueToRecycle_Tran
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    private int _JumboNo;
    private string _Issue_Date;
    private double _Original_Weight_Kg;
    private double _Balance_Weight_Kg;
    private string _Production_Date;
    private double _Original_Length_Mtr;
    private double _Balance_Length_Mtr;
    private double _Recycle_Length_Mtr;
    private double _Recycle_Qty_Kg;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _LastModifiedBy;
    private int _AutoID;
    private int _IntermediateAutoID;         


    #endregion

    #region Properties

    public int JumboNo
    {
        get { return _JumboNo; }
        set { _JumboNo = value; }
    }
    public string Issue_Date
    {
        get { return _Issue_Date; }
        set { _Issue_Date = value; }
    }
    public double Original_Weight_Kg
    {
        get { return _Original_Weight_Kg; }
        set { _Original_Weight_Kg = value; }
    }
    public double Balance_Weight_Kg
    {
        get { return _Balance_Weight_Kg; }
        set { _Balance_Weight_Kg = value; }
    }
    public string Production_Date
    {
        get { return _Production_Date; }
        set { _Production_Date = value; }
    }
    public double Original_Length_Mtr
    {
        get { return _Original_Length_Mtr; }
        set { _Original_Length_Mtr = value; }
    }
    public double Balance_Length_Mtr
    {
        get { return _Balance_Length_Mtr; }
        set { _Balance_Length_Mtr = value; }
    }
    public double Recycle_Length_Mtr
    {
        get { return _Recycle_Length_Mtr; }
        set { _Recycle_Length_Mtr = value; }
    }
    public double Recycle_Qty_Kg
    {
        get { return _Recycle_Qty_Kg; }
        set { _Recycle_Qty_Kg = value; }
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
    public int LastModifiedBy
    {
        get { return _LastModifiedBy; }
        set { _LastModifiedBy = value; }
    }
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

    #endregion

    #region Public Methods

    public Prod_JumboIssueToRecycle_Tran()
    { }

    public string InsertAndUpdate_In_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertAndUpdate_In_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping(this);
    }

    public DataTable Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_AllRecords(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_AllJumboNo(string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_AllJumboNo";
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_JumboIssueToRecycle_BothTable(int JumboIssueId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Jumbo_Issue_To_Recycle_Scrap_Wrapping_BothTable";
        objSqlCommand.Parameters.AddWithValue("@JumboIssueId", JumboIssueId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }


    #endregion

    
}