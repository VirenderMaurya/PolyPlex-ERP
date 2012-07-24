using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Prod_RawMaterialFeeding
/// </summary>
public class Prod_RawMaterialFeeding
{
    Connection con = new Connection();
    Common com = new Common();
    #region PrivateFiles
    private int _autoid;
    private string _LineCode;

    private string _ExtruderCode;

    private string _RMCode;
    private string _RMDesc;


    private int _VoucherNo;
    private string _Date;

    private string _quantity;

    private string _CreatedBy;
    private string _CreatedOn;
    private string _LastModifiedBy;
    private string _LastModifiedOn;
    private string _Remarks;

    private string _Thickness;
    private int _Thicknessid;
    #endregion

    #region Public Properties
    public int autoId
    {
        get { return _autoid; }
        set { _autoid = value; }
    }
    public string LineCode
    {
        get { return _LineCode; }
        set { _LineCode = value; }
    }

    public string ExtruderCode
    {
        get { return _ExtruderCode; }
        set { _ExtruderCode = value; }
    }

    public string RMCode
    {
        get { return _RMCode; }
        set { _RMCode = value; }
    }

    public string RMDesc
    {
        get { return _RMDesc; }
        set { _RMDesc = value; }
    }


    /// <summary>
    /// 
    /// </summary>

    public int VoucherNo
    {
        get { return _VoucherNo; }
        set { _VoucherNo = value; }
    }


    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }

    public string quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
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

    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }

    public string Thickness
    {
        get { return _Thickness; }
        set { _Thickness = value; }
    }

    public int Thicknessid
    {
        get { return _Thicknessid; }
        set { _Thicknessid = value; }
    }


    #endregion
    public Prod_RawMaterialFeeding()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public BLLCollection<Prod_RawMaterialFeeding> Get_LineCode()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_LineCode();
    }

    public BLLCollection<Prod_RawMaterialFeeding> Get_ExtruderCode()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_ExtruderCode();
    }

    public BLLCollection<Prod_RawMaterialFeeding> Get_RawMaterialVoucherNumber()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_RawMaterialVoucherNumber();
    }

    public BLLCollection<Prod_RawMaterialFeeding> Get_RMCode()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_RawMatCode();
    }

    public BLLCollection<Prod_RawMaterialFeeding> Get_AllDataRawMat()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_AllDataRawMat();
    }

    

    public bool saveRecords(int VoucherNo, string Date, string Line, string Extruder, string Raw_Mat_Code, string Qty_In_KG, string Remarks, string CreatedBy, string CreatedOn)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_RawMaterial", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VoucherNo", VoucherNo);
            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(Date));
            cmd.Parameters.AddWithValue("@Line",  Convert.ToInt32(Line));
            cmd.Parameters.AddWithValue("@Extruder",  Convert.ToInt32(Extruder));
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Raw_Mat_Code",  Convert.ToInt32(Raw_Mat_Code));
            cmd.Parameters.AddWithValue("@Qty_In_KG",  Qty_In_KG);
            cmd.Parameters.AddWithValue("@CreatedBy",  Convert.ToInt32(CreatedBy));
            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@LastModifiedBy", Convert.ToInt32(LastModifiedBy));
            cmd.Parameters.AddWithValue("@LastModifiedOn", LastModifiedOn);

       
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public decimal GetRawMaterialTopVoucherNo()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetRawMaterialTopVoucherNo();
    }


    public BLLCollection<Prod_RawMaterialFeeding>  Get_RawMaterialVoucherDetails_ByVoucherId(int voucherno)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_RawMaterialVoucherDetails_ByVoucherId(voucherno);
    
    }
    public int UpdateRawMaterialHeaderandList(int autoid, string VoucherNo, int Line, string Remarks, string Extruder, string Raw_Mat_Code, string Qty_In_KG, string LastModifiedBy)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateRawMaterialHeaderandList(autoid, VoucherNo, Line, Remarks, Extruder, Raw_Mat_Code, Qty_In_KG, LastModifiedBy);
    }
      


    //////// PET Plant Feeding

    public BLLCollection<Prod_RawMaterialFeeding> Get_Thickness()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_Thickness();
    }

    public bool savePlantRecords(string Date, string Line, string Run, string Thickness, string Lumps, string Cast, string Mono, string Break, string Remarks, string CreatedBy, string CreatedOn)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_PETPlantFeeding", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(Date));
            cmd.Parameters.AddWithValue("@Line", Convert.ToInt32(Line));
            cmd.Parameters.AddWithValue("@Run", Run);
            cmd.Parameters.AddWithValue("@Thickness", Convert.ToInt32(Thickness));
            cmd.Parameters.AddWithValue("@Lumps", Convert.ToDouble(Lumps));
            cmd.Parameters.AddWithValue("@Cast", Convert.ToDouble(Cast));

            cmd.Parameters.AddWithValue("@Mono",Convert.ToDouble(Mono));
            cmd.Parameters.AddWithValue("@Break", Break);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(CreatedBy));
            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
        //    cmd.Parameters.AddWithValue("@LastModifiedBy", Convert.ToInt32(LastModifiedBy));
         //   cmd.Parameters.AddWithValue("@LastModifiedOn", LastModifiedOn);


            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public int UpdatePETPlantFeeding(int Autoid,int Line,int Thickness, string Run, string Lumps, string Cast, string Mono, string Break, string Remarks,  string LastModifiedBy, string LastModifiedOn)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdatePETPlantFeeding(Autoid,Line,Thickness,Run, Lumps, Cast, Mono, Break, Remarks, LastModifiedBy, LastModifiedOn);
    }

    ////MET PlANt feeding
    //autoid, txtAluminium.Text, txtBoats.Text,txtRemarks.Text, "", DateTime.Now.ToString(Log.GetLog().DateFormat)
    public bool saveMETPlantRecords(string Date, string Line, string Aluminium, string Boats, string Remarks, string CreatedBy, string CreatedOn, string LastModifiedBy, string LastModifiedOn)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_METPlantFeeding", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(Date));
            cmd.Parameters.AddWithValue("@Line", Convert.ToInt32(Line));
            cmd.Parameters.AddWithValue("@Aluminium", Aluminium);
            cmd.Parameters.AddWithValue("@Boats", Boats);
          
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(CreatedBy));
            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@LastModifiedBy", Convert.ToInt32(LastModifiedBy));
            cmd.Parameters.AddWithValue("@LastModifiedOn", LastModifiedOn);


            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public int UpdateMETPlantFeeding(int autoid,int line, string Aluminium, string Boats, string Remarks, string LastModifiedBy, string LastModifiedOn)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateMETPlantFeeding(autoid,line, Aluminium, Boats, Remarks, LastModifiedBy, LastModifiedOn);
    }

    public BLLCollection<Prod_RawMaterialFeeding> Get_AllDataRawMatMachinData()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_AllDataRawMatMachinData();
    }



    public string Insert_In_Raw_Material_Header(string VoucherNumber, string Date, string Line, string Remarks, string CreatedBy)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_In_Raw_Material_Header( VoucherNumber,  Date, Line, Remarks, CreatedBy);
    }



    public bool Insert_In_RawMaterial_ListItem(int RawMaterialid, int Extruder, int Raw_Mat_Code,  string Qty_In_KG,  string CreatedBy)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_RawMaterial_ListItem", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RawMaterialid", RawMaterialid);
            cmd.Parameters.AddWithValue("@Extruder", Extruder);
            cmd.Parameters.AddWithValue("@Raw_Mat_Code", Raw_Mat_Code);
            cmd.Parameters.AddWithValue("@Qty_In_KG", Convert.ToDecimal(Qty_In_KG));
            cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToInt32(CreatedBy));
           

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

}