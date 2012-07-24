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


public class Prod_MetPlantFeeding
{
    SqlCommand objSqlCommand = new SqlCommand();

    #region Private Fields

    private string _Date;
    private int _Line;
    private double _Aluminimum_Wire_Consump_KG;
    private int _Boats_Consump;
    private string _Remarks;

    private int _PetJumboId;
    private bool _ActiveStatus;
    private int _CreatedBy;
    private int _LastModifiedBy;
    private int _AutoID;
    private int _IntermediateAutoID;

    #endregion

    #region Properties

    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public int Line
    {
        get { return _Line; }
        set { _Line = value; }
    }
    public double Aluminimum_Wire_Consump_KG
    {
        get { return _Aluminimum_Wire_Consump_KG; }
        set { _Aluminimum_Wire_Consump_KG = value; }
    }
    public int Boats_Consump
    {
        get { return _Boats_Consump; }
        set { _Boats_Consump = value; }
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

    public Prod_MetPlantFeeding()
    { }

    public string InsertAndUpdate_In_Prod_MET_Plant_Feeding()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.InsertAndUpdate_In_Prod_MET_Plant_Feeding(this);
    }

    public DataTable Get_Prod_MET_Plant_Feeding_Intermediate_AllRecords()
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_MET_Plant_Feeding_Intermediate_AllRecords";

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_MET_Plant_Feeding_AllRecords(string SearchType, string SearchText)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_MET_Plant_Feeding_AllRecords";
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);
        objSqlCommand.Parameters.AddWithValue("@SearchText", SearchText);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    public DataTable Get_Prod_MET_Plant_Feeding_BothTable(int AutoID, string SearchType)
    {
        objSqlCommand = new SqlCommand();
        objSqlCommand.CommandText = "Sp_Get_Prod_MET_Plant_Feeding_BothTable";
        objSqlCommand.Parameters.AddWithValue("@AutoID", AutoID);
        objSqlCommand.Parameters.AddWithValue("@SearchType", SearchType);

        SqlDataProvider db = new SqlDataProvider();
        return db.GetDataTableWithProc(objSqlCommand);
    }

    #endregion
   
    
}