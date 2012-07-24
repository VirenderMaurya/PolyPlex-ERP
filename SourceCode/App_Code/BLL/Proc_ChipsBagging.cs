using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Proc_ChipsBagging
/// </summary>
public class Proc_ChipsBagging
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
    public Proc_ChipsBagging()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public decimal GetLastSeriesNumber()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetLastSeriesNumber();
    }


    public decimal GetChipsTopLineNo()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetChipsTopLineNo();
    }

    public string Insert_In_Chip_Bagging_Header(int Series, string Year, string VoucherNumber, string BaggingDate, string CreatedBy)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_In_Chip_Bagging_Header(Series, Year, VoucherNumber, BaggingDate, CreatedBy);
    }


    public bool saveRecordsinChipsBagging(int ChipsID, string Line, string MaterialCode, string StockOUM, string StorageLocCode, string ChipsBags, string Quantity, string Status, string CreatedBy)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Proc_Insert_Chips_Bagging_LineItems", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ChipsID", ChipsID);
            cmd.Parameters.AddWithValue("@Line", Line);
            cmd.Parameters.AddWithValue("@MaterialCode", Convert.ToInt32(MaterialCode));
            cmd.Parameters.AddWithValue("@StockOUM", StockOUM);
            cmd.Parameters.AddWithValue("@StorageLocation", Convert.ToInt32(StorageLocCode));
            cmd.Parameters.AddWithValue("@ChipsBags", ChipsBags);
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToDouble(Quantity));
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


    public int UpdateChipsBagging(string VoucherNumber, int MaterialCode, string StockOUM, int StorageLocCode, string chipsBag, string Quantity, string LastModifiedBy)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateChipsBagging(VoucherNumber, MaterialCode, StockOUM, StorageLocCode, chipsBag, Quantity, LastModifiedBy);
    }


}