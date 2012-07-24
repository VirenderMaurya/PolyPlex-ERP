using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Prodprivate string _MetJumboprivate string _header
/// </summary>
public class Prod_MetJumbo_header
{
    Connection con = new Connection();
    Common com = new Common();
    #region Private
    private string _METJumboNo;
    private string _Metalizer;
    private string _Date;
    private string _Shift;
    private string _Micron;
    private string _Type;
    private string _Core;
    private string _Width;
    private string _Length;
    private string _ActMic;
    private string _Quantity;
    private string _NoOfJoints;
    private string _Joint1;
    private string _Joint2;
    private string _Joint3;
    private string _ODMin;
    private string _ODAverage;
    private string _ODMax;
    private string _Grade;
    private string _Remarks;
    private string _VaccumStart;
    private string _HeatingStart;
    private string _AccelerationTime;
    private string _MetStartTime;
    private string _Deaccelaration;
    private string _MetStopTime;
    private string _VentTime;
    private string _Speed;
    private string _OTR;
    private string _WVTR;
    private string _BendStrength;
    private string _SealStrengthMin;
    private string _SealStrengthAverage;
    private string _SealStrengthMax;
    private string _COFSealToSeal;
    private string _COFSealToMetal;
    private string _TapeTest;
    private string _TreatmentBackSide;
    private string _TreatmentMaterlizedSide;
    private string _CreatedBy;
    #endregion
    #region Properties
    public string METJumboNo
    {
        get { return _METJumboNo; }
        set { _METJumboNo = value; }
    }
    public string Metalizer
    {
        get { return _Metalizer; }
        set { _Metalizer = value; }
    }
    public string Date
    {
        get { return _Date; }
        set { _Date = value; }
    }
    public string Shift
    {
        get { return _Shift; }
        set { _Shift = value; }
    }
    public string Micron
    {
        get { return _Micron; }
        set { _Micron = value; }
    }
    public string Type
    {
        get { return _Type; }
        set { _Type = value; }
    }
    public string Core
    {
        get { return _Core; }
        set { _Core = value; }
    }
    public string Width
    {
        get { return _Width; }
        set { _Width = value; }
    }
    public string Length
    {
        get { return _Length; }
        set { _Length = value; }
    }
    public string ActMic
    {
        get { return _ActMic; }
        set { _ActMic = value; }
    }
    public string Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string NoOfJoints
    {
        get { return _NoOfJoints; }
        set { _NoOfJoints = value; }
    }
    public string Joint1
    {
        get { return _Joint1; }
        set { _Joint1 = value; }
    }
    public string Joint2
    {
        get { return _Joint2; }
        set { _Joint2 = value; }
    }
    public string Joint3
    {
        get { return _Joint3; }
        set { _Joint3 = value; }
    }
    public string ODMin
    {
        get { return _ODMin; }
        set { _ODMin = value; }
    }
    public string ODAverage
    {
        get { return _ODAverage; }
        set { _ODAverage = value; }
    }
    public string ODMax
    {
        get { return _ODMax; }
        set { _ODMax = value; }
    }

    public string Grade
    {
        get { return _Grade; }
        set { _Grade = value; }
    }
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    public string VaccumStart
    {
        get { return _VaccumStart; }
        set { _VaccumStart = value; }
    }
    public string HeatingStart
    {
        get { return _HeatingStart; }
        set { _HeatingStart = value; }
    }
    public string AccelerationTime
    {
        get { return _AccelerationTime; }
        set { _AccelerationTime = value; }
    }
    public string MetStartTime
    {
        get { return _MetStartTime; }
        set { _MetStartTime = value; }
    }
    public string Deaccelaration
    {
        get { return _Deaccelaration; }
        set { _Deaccelaration = value; }
    }
    public string MetStopTime
    {
        get { return _MetStopTime; }
        set { _MetStopTime = value; }
    }
    public string VentTime
    {
        get { return _VentTime; }
        set { _VentTime = value; }
    }
    public string Speed
    {
        get { return _Speed; }
        set { _Speed = value; }
    }
    public string OTR
    {
        get { return _OTR; }
        set { _OTR = value; }
    }
    public string WVTR
    {
        get { return _WVTR; }
        set { _WVTR = value; }
    }
    public string BendStrength
    {
        get { return _BendStrength; }
        set { _BendStrength = value; }
    }
    public string SealStrengthMin
    {
       get { return _SealStrengthMin; }
       set { _SealStrengthMin = value; }
    }
    public string SealStrengthAverage
    {
       get { return _SealStrengthAverage; }
       set { _SealStrengthAverage = value; }
    }
    public string SealStrengthMax
    {
        get { return _SealStrengthMax; }
        set { _SealStrengthMax = value; }
    }
    public string COFSealToSeal
    {
       get { return _COFSealToSeal; }
       set { _COFSealToSeal = value; }
    }
    public string COFSealToMetal
    {
       get { return _COFSealToMetal; }
       set { _COFSealToMetal = value; }
    }
    public string TapeTest
    {
        get { return _TapeTest; }
        set { _TapeTest = value; }
    }
    public string TreatmentBackSide
    {
       get { return _TreatmentBackSide; }
       set { _TreatmentBackSide = value; }
    }
    public string TreatmentMaterlizedSide
    {
       get { return _TreatmentMaterlizedSide; }
       set { _TreatmentMaterlizedSide = value; }
    }
    public string CreatedBy
    {
      get { return _CreatedBy; }
      set { _CreatedBy = value; }
    }


    #endregion\

    public Prod_MetJumbo_header()
    {
    }

    public bool saveRecords(DataTable dt,string Metalizer,string Date,string Shift,string Micron,string Type,string Core,
                            string Width,string Length,string ActMic,string Quantity,string NoOfJoints,
                           string Joint1,string Joint2,string Joint3,string ODMin,string ODAverage,string ODMax,
                           string Grade,string Remarks,string VaccumStart,string HeatingStart,string AccelerationTime,
                           string MetStartTime,string Deaccelaration,string MetStopTime,string VentTime,string Speed,
                           string OTR,string WVTR,string BendStrength,string SealStrengthMin,string SealStrengthAverage,
                           string SealStrengthMax,string COFSealToSeal,string COFSealToMetal,string TapeTest,
                           string TreatmentBackSide,string TreatmentMaterlizedSide,string CreatedBy)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_MetJumbo", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dtLineitems", dt);
            cmd.Parameters.AddWithValue("@Metalizer", Metalizer);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Shift", Shift);
            cmd.Parameters.AddWithValue("@Micron", Micron);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Core", Core);
            cmd.Parameters.AddWithValue("@Width", Width);
            cmd.Parameters.AddWithValue("@Length", Length);
            cmd.Parameters.AddWithValue("@ActMic", ActMic);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);

            cmd.Parameters.AddWithValue("@NoOfJoints", NoOfJoints);
            cmd.Parameters.AddWithValue("@Joint1", Joint1);
            cmd.Parameters.AddWithValue("@Joint2", Joint2);
            cmd.Parameters.AddWithValue("@Joint3", Joint3);
            cmd.Parameters.AddWithValue("@ODMin", ODMin);
            cmd.Parameters.AddWithValue("@ODAverage", ODAverage);
            cmd.Parameters.AddWithValue("@ODMax", ODMax);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@VaccumStart", VaccumStart);
            cmd.Parameters.AddWithValue("@HeatingStart", HeatingStart);
            cmd.Parameters.AddWithValue("@AccelerationTime", AccelerationTime);
            cmd.Parameters.AddWithValue("@MetStartTime", MetStartTime);
            cmd.Parameters.AddWithValue("@Deaccelaration", Deaccelaration);
            cmd.Parameters.AddWithValue("@MetStopTime", MetStopTime);
            cmd.Parameters.AddWithValue("@VentTime", VentTime);
            cmd.Parameters.AddWithValue("@Speed", Speed);
            cmd.Parameters.AddWithValue("@OTR", OTR);
            cmd.Parameters.AddWithValue("@WVTR", WVTR);
            cmd.Parameters.AddWithValue("@BendStrength", BendStrength);
            cmd.Parameters.AddWithValue("@SealStrengthMin", SealStrengthMin);
            cmd.Parameters.AddWithValue("@SealStrengthAverage", SealStrengthAverage);
            cmd.Parameters.AddWithValue("@SealStrengthMax", SealStrengthMax);
            cmd.Parameters.AddWithValue("@COFSealToSeal", COFSealToSeal);
            cmd.Parameters.AddWithValue("@COFSealToMetal", COFSealToMetal);
            cmd.Parameters.AddWithValue("@TapeTest", TapeTest);
            cmd.Parameters.AddWithValue("@TreatmentBackSide", TreatmentBackSide);
            cmd.Parameters.AddWithValue("@TreatmentMaterlizedSide", TreatmentMaterlizedSide);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public DataTable GetMachineData()
    {
        DataTable dt = com.executeProcedure("Sp_Prod_GetJumboHeader_DataFromMachine");
       return dt;
    }
    public DataTable UpdateMachineData(string id)
    {
        DataTable dt = com.GetVal("@id", id, "Sp_Prod_UpdateJumboHeader_DataFromMachine_ByJumboId");
        return dt;
    }
}