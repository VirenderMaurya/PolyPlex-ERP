using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Proc_ScarpReceived
/// </summary>
public class Proc_ScarpReceived
{
    Connection con = new Connection();
    Common com = new Common();

    #region PrivateFiles
    private int _autoid;
    private string _MaterialCode;
    private string _LineCode;
    private string _Code;
    private string _Desc;
    private string _PlantCode;
    private string _PlantName;

    private string _CreatedBy;
    private string _CreatedOn;
    private string _LastModifiedBy;
    private string _LastModifiedOn;
    private string _ValueType;
    private string _Location;
    private string _StorageLocCode;

    private string _Year;
    private int _Entry;
    private DateTime _EntryDate;
    private int _Scrapid;


    
    #endregion

    #region Public Properties
    public int autoId
    {
        get { return _autoid; }
        set { _autoid = value; }
    }

    public string MaterialCode
    {
        get { return _MaterialCode; }
        set { _MaterialCode = value; }
    }

    public string LineCode
    {
        get { return _LineCode; }
        set { _LineCode = value; }
    }

  
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }

    public string CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }

    public string LastModifiedBy
    {
        get { return _LastModifiedBy; }
        set { _LastModifiedBy = value; }
    }

    public string LastModifiedOn
    {
        get { return _LastModifiedOn; }
        set { _LastModifiedOn = value; }
    }

    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }

    public string Desc
    {
        get { return _Desc; }
        set { _Desc = value; }
    }


    public string PlantCode
    {
        get { return _PlantCode; }
        set { _PlantCode = value; }
    }


    public string PlantName
    {
        get { return _PlantName; }
        set { _PlantName = value; }
    }

    public string Valuetype
    {
        get { return _ValueType; }
        set { _ValueType = value; }
    }

    public string Location
    {
        get { return _Location; }
        set { _Location = value; }
    }


    public string StorageLocCode
    {
        get { return _StorageLocCode; }
        set { _StorageLocCode = value; }
    }


    public string Year
    {
        get { return _Year; }
        set { _Year = value; }
    }

    public int Entry
    {
        get { return _Entry; }
        set { _Entry = value; }
    }

    public DateTime EntryDate
    {
        get { return _EntryDate; }
        set { _EntryDate = value; }
    }

    public int ScarpID
    {
        get { return _Scrapid; }
        set { _Scrapid = value; }
    }

    #endregion
	public Proc_ScarpReceived()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public BLLCollection<Proc_ScarpReceived> Get_MaterialCode()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_MaterialCode();
    }


    public BLLCollection<Proc_ScarpReceived> Get_Plant()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Plant();
    }

    public BLLCollection<Proc_ScarpReceived> Get_Valuatory()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Valuatory();
    }

    public BLLCollection<Proc_ScarpReceived> Get_StorageLocation()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_StorageLocation();
    }

    public decimal GetScarpTopEntryNo()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetScarpTopEntryNo();
    }



    public BLLCollection<Proc_ScarpReceived> Get_AllDataScarpReceived()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_AllDataScarpReceived();
    }

    public string Insert_In_Scarp_Received_Header(string Year, string Entry, string EntreyDate, string CreatedBy)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_In_Scarp_Received_Header(Year,Entry,EntreyDate, CreatedBy);
    }


    public bool saveRecordsinScrapReceived(int ScarpID, string Line, string MaterialCode, string PlantCode, string Valuetype, string StorageLocCode, string Quantity, string StockOUM, string Status,string CreatedBy)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_Scrap_Received", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ScrapId", ScarpID);
            cmd.Parameters.AddWithValue("@LineNo", Convert.ToInt32(Line));
            cmd.Parameters.AddWithValue("@MaterialCode", Convert.ToInt32(MaterialCode));
            cmd.Parameters.AddWithValue("@Plant", Convert.ToInt32(PlantCode));
            cmd.Parameters.AddWithValue("@ValuationType", Convert.ToInt32(Valuetype));
            cmd.Parameters.AddWithValue("@StorageLocation", Convert.ToInt32(StorageLocCode));
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToDouble(Quantity));
            cmd.Parameters.AddWithValue("@StockOUM", StockOUM);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(CreatedBy));


            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public decimal GetScarpTopLineNo()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetScarpTopLineNumber();
    }



    public int UpdateScrapReceived(int autoid, int MaterialCode, int PlantCode, int Valuetype, int StorageLocCode, string Quantity, string StockOUM, string LastModifiedBy)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateScrapReceived(autoid, MaterialCode, PlantCode, Valuetype, StorageLocCode, Quantity, StockOUM, LastModifiedBy);
    }

  
}