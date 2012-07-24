using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Prod_RollIssueToRecycle_Tran
/// </summary>
public class Prod_RollIssueToRecycle_Tran
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields
    private int _BatchNo;
    private string _Issue_Date;
    private double _Original_Weight_Kg;
    private double _Balance_Weight_Kg;
    private string _Production_Date;
    private double _Original_Length_Mtr;
    private double _Balance_Length_Mtr;
    private double _Issue_Length_Mtr;
    private double _Issue_Qty_Kg;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _LastModifiedBy;
    private int _AutoID;
    private int _IntermediateAutoID;
    #endregion

    #region Properties

    public int BatchNo
    {
        get { return _BatchNo; }
        set { _BatchNo = value; }
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
    public double Issue_Length_Mtr
    {
        get { return _Issue_Length_Mtr; }
        set { _Issue_Length_Mtr = value; }
    }
    public double Issue_Qty_Kg
    {
        get { return _Issue_Qty_Kg; }
        set { _Issue_Qty_Kg = value; }
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

    public string InsertAndUpdate_InProd_Roll_Issue_To_Recycle_Scrap_Wrapping()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertAndUpdate_In_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping(this);
    }

    public DataTable Get_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Roll_Issue_To_Recycle_Scrap_Wrapping_Intermediate_AllRecords";

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
    public DataTable Get_AllDATAFrom_Intermediatetable_ByAutoId(string id)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Roll_IssueFromIntermediate_By_AutoId";
        objSqlCommand.Parameters.AddWithValue("@id", id);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Update_Intermediatetable_ByAutoId(string id)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Update_Roll_IssueFromIntermediate_By_AutoId";
        objSqlCommand.Parameters.AddWithValue("@id", id);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_Glb_PetJumbo_MainDetails_BothTable(int PetJumboId, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_Glb_PetJumbo_MainDetails_BothTable";
        objSqlCommand.Parameters.AddWithValue("@PetJumboId", PetJumboId);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }
	public Prod_RollIssueToRecycle_Tran()
	{
	
	}
}