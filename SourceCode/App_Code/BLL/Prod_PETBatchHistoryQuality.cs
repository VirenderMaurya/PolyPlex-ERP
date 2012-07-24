using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Prod_PETBatchHistoryQuality
/// </summary>
public class Prod_PETBatchHistoryQuality
{
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand objSqlCommand = new SqlCommand();
 
	public Prod_PETBatchHistoryQuality()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public decimal GetLastPETBatchVoucherNumber()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetLastPETBatchVoucherNumber();
    }

    public bool saveRecordsPETBatchQuality(string VoucherYear,string VoucherNo,string VoucherDate,string Time,int Type,decimal silica,string EICycleTime,decimal EIFinalTemp,decimal BHTFilter,string BATransTime,decimal FINProdTemp,string PCReacTime
      ,decimal BACustoffRPM,decimal BACutoffKW,string CastingTime,decimal IV,decimal COOH,decimal ASH,decimal DEG,decimal MP,decimal Numberofchipps,string ColourVisual,decimal L,decimal a,decimal b,string Grade,decimal Moisture
      ,decimal Oligomer,string Remarks,int Createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_PETBatchHistoryQuality", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VoucherYear", VoucherYear);
            cmd.Parameters.AddWithValue("@VoucherNo", VoucherNo);
            cmd.Parameters.AddWithValue("@voucherDate", Convert.ToDateTime(VoucherDate));
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Type", Convert.ToInt32(Type));

            cmd.Parameters.AddWithValue("@silica", Convert.ToDouble(silica));
            cmd.Parameters.AddWithValue("@EICycleTime", EICycleTime);

            cmd.Parameters.AddWithValue("@EIFinalTemp", Convert.ToDouble(EIFinalTemp));


            cmd.Parameters.AddWithValue("@BHTFilter", Convert.ToDouble(BHTFilter));
            cmd.Parameters.AddWithValue("@BATransTime", BATransTime);
            cmd.Parameters.AddWithValue("@FINProdTemp", Convert.ToDouble(FINProdTemp));
            cmd.Parameters.AddWithValue("@PCReacTime", PCReacTime);
            cmd.Parameters.AddWithValue("@BACustoffRPM", Convert.ToDouble(BACustoffRPM));
            cmd.Parameters.AddWithValue("@BACutoffKW", Convert.ToDouble(BACutoffKW));
            cmd.Parameters.AddWithValue("@CastingTime", CastingTime);
            cmd.Parameters.AddWithValue("@IV", Convert.ToDouble(IV));



            cmd.Parameters.AddWithValue("@COOH", Convert.ToDouble(COOH));
            cmd.Parameters.AddWithValue("@ASH", Convert.ToDouble(ASH));
            cmd.Parameters.AddWithValue("@DEG", Convert.ToDouble(DEG));
            cmd.Parameters.AddWithValue("@MP", Convert.ToDouble(MP));
            cmd.Parameters.AddWithValue("@Numberofchipps", Convert.ToDouble(Numberofchipps));
            cmd.Parameters.AddWithValue("@ColourVisual", ColourVisual);
            cmd.Parameters.AddWithValue("@L", Convert.ToDouble(L));
            cmd.Parameters.AddWithValue("@a", Convert.ToDouble(a));
            cmd.Parameters.AddWithValue("@b", Convert.ToDouble(b));
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@Moisture", Convert.ToDouble(Moisture));
            cmd.Parameters.AddWithValue("@Oligomer", Convert.ToDouble(Oligomer));

            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Createdby", Convert.ToInt32(Createdby));

            //string VoucherYear,string VoucherNo,string VoucherDate,string Time,int Type,decimal silica,string EICycleTime,decimal EIFinalTemp,decimal BHTFilter,string BATransTime,decimal FINProdTemp,string PCReacTime
      //,decimal BACustoffRPM,decimal BACutoffKW,string CastingTime,decimal IV,decimal COOH,decimal ASH,deciaml DEG,decimal MP,decimal Numberofchipps,string ColourVisual,decimal L,decimal a,decimal b,string Grade,decimal Moisture
      //,decimal Oligomer,string Remarks,int Createdby
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public int UpdatePETBatchQuality(int Autoid, string VoucherYear, string VoucherNo, string VoucherDate, string Time, int Type, decimal silica, string EICycleTime, decimal EIFinalTemp, decimal BHTFilter, string BATransTime, decimal FINProdTemp, string PCReacTime
      , decimal BACustoffRPM, decimal BACutoffKW, string CastingTime, decimal IV, decimal COOH, decimal ASH, decimal DEG, decimal MP, decimal Numberofchipps, string ColourVisual, decimal L, decimal a, decimal b, string Grade, decimal Moisture
      , decimal Oligomer, string Remarks, int Createdby)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdatePETBatchQuality(Autoid, VoucherYear, VoucherNo, VoucherDate, Time, Type, silica, EICycleTime, EIFinalTemp, BHTFilter, BATransTime, FINProdTemp, PCReacTime
      , BACustoffRPM, BACutoffKW, CastingTime, IV, COOH, ASH, DEG, MP, Numberofchipps, ColourVisual, L, a, b, Grade, Moisture
      , Oligomer, Remarks, Createdby);
    }


}