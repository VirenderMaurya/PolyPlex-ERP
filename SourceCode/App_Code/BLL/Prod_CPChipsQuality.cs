using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Prod_CPChipsQuality
/// </summary>
public class Prod_CPChipsQuality
{
    Connection con = new Connection();
    Common com = new Common();
    SqlCommand objSqlCommand = new SqlCommand();
 
	public Prod_CPChipsQuality()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public decimal GetLastVoucherNumber()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.GetLastVoucherNumber();
    }

    public bool saveRecordsCpChipsQuality(string VoucherYear, string VoucherNo, string voucherDate, string Time, int Type, decimal LAB, decimal TOV, decimal COOH, decimal ASH, decimal DEG, decimal Chips, string ColorVisual, decimal L, decimal a, decimal b, string Remarks, int Createdby)
    {
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("Sp_Prod_Insert_CPChipsQuality", con.PolypexSqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VoucherYear", VoucherYear);
            cmd.Parameters.AddWithValue("@VoucherNo", VoucherNo);
            cmd.Parameters.AddWithValue("@voucherDate", Convert.ToDateTime(voucherDate));
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Type", Convert.ToInt32(Type));

            cmd.Parameters.AddWithValue("@LAB", Convert.ToDouble(LAB));
            cmd.Parameters.AddWithValue("@TOV", Convert.ToDouble(TOV));

            cmd.Parameters.AddWithValue("@COOH", Convert.ToDouble(COOH));


            cmd.Parameters.AddWithValue("@ASH", Convert.ToDouble(ASH));
            cmd.Parameters.AddWithValue("@DEG", Convert.ToDouble(DEG));
            cmd.Parameters.AddWithValue("@Chips", Convert.ToDouble(Chips));
            cmd.Parameters.AddWithValue("@ColorVisual", ColorVisual);
            cmd.Parameters.AddWithValue("@L", Convert.ToDouble(L));
            cmd.Parameters.AddWithValue("@a", Convert.ToDouble(a));
            cmd.Parameters.AddWithValue("@b", Convert.ToDouble(b));
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Createdby", Convert.ToInt32(Createdby));

            //
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public int UpdateCpChipsQuality(int Autoid, string VoucherYear, string VoucherNo, string voucherDate, string Time, int Type, decimal LAB, decimal TOV, decimal COOH, decimal ASH, decimal DEG, decimal Chips, string ColorVisual, decimal L, decimal a, decimal b, string Remarks, int Createdby)
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.UpdateCpChipsQuality(Autoid,  VoucherYear,  VoucherNo, voucherDate, Time,  Type,  LAB,  TOV, COOH, ASH,  DEG,  Chips,  ColorVisual,  L,  a,  b,  Remarks,  Createdby);
    }

}