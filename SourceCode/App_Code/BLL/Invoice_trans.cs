using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Invoice_trans
/// </summary>
public class Invoice_trans
{
    Connection con = new Connection();
    Common rp = new Common();
    public Invoice_trans()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public void InsertInv(string InvType, string invyear, string invdate, string QSrInvoiceNo, string SalesOrderId, string ProformaInvoiceId, string ExporterCode, string CountryFinalDestination, string CustomerId, string ConsigneeId, string DeliveryCode, string CustomerOderNo,string CustOrderDate, string Currency, string ETD, string ETA, string PrintInGuageInch, string PrintWidth, string PrintBuyer, string ToOrdInConsignee, string BillOfLoadingNo, string BillOfLoadingDate, string ContainerNo, string ShippingLine, string ExportEntryNo, string ExportEntryDate, string FOBCIF, string InlandTransport, string Freight, string Insurance, string VesselFlightNo, string PreCarriageBy, string PreCarriageRectPlace, string PortofLoading, string PortOfDischarge, string FinalDestination, string MarkNo1, string MarkNo2, string MarkNo3, string KindOfPackages, string TermsOfDelivery, string TermsOfPayment, string GoodsDescription, string FooterDescription, string SpecialInstructions, string FooterPacking, string CreatedBy)
    {
        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("Sp_InsertInvoice", con.PolypexSqlConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InvoiceType", InvType);
        cmd.Parameters.AddWithValue("@InvoiceYear", invyear);
        cmd.Parameters.AddWithValue("@InvoiceDate", invdate);
        cmd.Parameters.AddWithValue("@QSrInvoiceNo", QSrInvoiceNo);
        cmd.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);
        cmd.Parameters.AddWithValue("@ProformaInvoiceId", ProformaInvoiceId);
        cmd.Parameters.AddWithValue("@ExporterCode", ExporterCode);
        cmd.Parameters.AddWithValue("@CountryFinalDestination", CountryFinalDestination);
        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
        cmd.Parameters.AddWithValue("@ConsigneeId", ConsigneeId);
        cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode);
        cmd.Parameters.AddWithValue("@CustomerOderNo", CustomerOderNo);
        cmd.Parameters.AddWithValue("@CustOrderDate", CustOrderDate);
        cmd.Parameters.AddWithValue("@Currency", Currency);
        cmd.Parameters.AddWithValue("@ETD", ETD);
        cmd.Parameters.AddWithValue("@ETA", ETA);
        cmd.Parameters.AddWithValue("@PrintInGuageInch", PrintInGuageInch);
        cmd.Parameters.AddWithValue("@PrintWidth", PrintWidth);
        cmd.Parameters.AddWithValue("@PrintBuyer", PrintBuyer);
        cmd.Parameters.AddWithValue("@ToOrdInConsignee", ToOrdInConsignee);
        cmd.Parameters.AddWithValue("@BillOfLoadingNo", BillOfLoadingNo);
        cmd.Parameters.AddWithValue("@BillOfLoadingDate", BillOfLoadingDate);
        cmd.Parameters.AddWithValue("@ContainerNo", ContainerNo);
        cmd.Parameters.AddWithValue("@ShippingLine", ShippingLine);
        cmd.Parameters.AddWithValue("@ExportEntryNo", ExportEntryNo);
        cmd.Parameters.AddWithValue("@ExportEntryDate", ExportEntryDate);
        cmd.Parameters.AddWithValue("@FOBCIF", FOBCIF);
        cmd.Parameters.AddWithValue("@InlandTransport", InlandTransport);
        cmd.Parameters.AddWithValue("@Freight", Freight);
        cmd.Parameters.AddWithValue("@Insurance", Insurance);
        cmd.Parameters.AddWithValue("@VesselFlightNo", VesselFlightNo);
        cmd.Parameters.AddWithValue("@PreCarriageBy", PreCarriageBy);
        cmd.Parameters.AddWithValue("@PreCarriageRectPlace", PreCarriageRectPlace);
        cmd.Parameters.AddWithValue("@PortofLoading", PortofLoading);
        cmd.Parameters.AddWithValue("@PortOfDischarge", PortOfDischarge);
        cmd.Parameters.AddWithValue("@FinalDestination", FinalDestination);
        cmd.Parameters.AddWithValue("@MarkNo1", MarkNo1);
        cmd.Parameters.AddWithValue("@MarkNo2", MarkNo2);
        cmd.Parameters.AddWithValue("@MarkNo3", MarkNo3);
        cmd.Parameters.AddWithValue("@KindOfPackages", KindOfPackages);
        cmd.Parameters.AddWithValue("@TermsOfDelivery", TermsOfDelivery);
        cmd.Parameters.AddWithValue("@TermsOfPayment", TermsOfPayment);
        cmd.Parameters.AddWithValue("@GoodsDescription", GoodsDescription);
        cmd.Parameters.AddWithValue("@FooterDescription", FooterDescription);
        cmd.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);
        cmd.Parameters.AddWithValue("@FooterPacking", FooterPacking);
        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
        cmd.ExecuteNonQuery();

    }

    public void UpdateInv(string InvoiceNo, string InvType, string invyear, string invdate,string QSrInvoiceNo, string SalesOrderId, string ProformaInvoiceId, string ExporterCode, string CountryFinalDestination, string CustomerId, string ConsigneeId, string DeliveryCode, string CustomerOderNo, string CustOrderDate, string Currency, string ETD, string ETA, string PrintInGuageInch, string PrintWidth, string PrintBuyer, string ToOrdInConsignee, string BillOfLoadingNo, string BillOfLoadingDate, string ContainerNo, string ShippingLine, string ExportEntryNo, string ExportEntryDate, string FOBCIF, string InlandTransport, string Freight, string Insurance, string VesselFlightNo, string PreCarriageBy, string PreCarriageRectPlace, string PortofLoading, string PortOfDischarge, string FinalDestination, string MarkNo1, string MarkNo2, string MarkNo3, string KindOfPackages, string TermsOfDelivery, string TermsOfPayment, string GoodsDescription, string FooterDescription, string SpecialInstructions, string FooterPacking, string CreatedBy)
    {
        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("Sp_UpdateInvoice", con.PolypexSqlConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
        cmd.Parameters.AddWithValue("@InvoiceType", InvType);
        cmd.Parameters.AddWithValue("@InvoiceYear", invyear);
        cmd.Parameters.AddWithValue("@InvoiceDate", invdate);
        cmd.Parameters.AddWithValue("@QSrInvoiceNo", QSrInvoiceNo);
        cmd.Parameters.AddWithValue("@SalesOrderId", SalesOrderId);
        cmd.Parameters.AddWithValue("@ProformaInvoiceId", ProformaInvoiceId);
        cmd.Parameters.AddWithValue("@ExporterCode", ExporterCode);
        cmd.Parameters.AddWithValue("@CountryFinalDestination", CountryFinalDestination);
        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
        cmd.Parameters.AddWithValue("@ConsigneeId", ConsigneeId);
        cmd.Parameters.AddWithValue("@DeliveryCode", DeliveryCode);
        cmd.Parameters.AddWithValue("@CustomerOderNo", CustomerOderNo);
        cmd.Parameters.AddWithValue("@CustOrderDate", CustOrderDate);
        cmd.Parameters.AddWithValue("@Currency", Currency);
        cmd.Parameters.AddWithValue("@ETD", ETD);
        cmd.Parameters.AddWithValue("@ETA", ETA);
        cmd.Parameters.AddWithValue("@PrintInGuageInch", PrintInGuageInch);
        cmd.Parameters.AddWithValue("@PrintWidth", PrintWidth);
        cmd.Parameters.AddWithValue("@PrintBuyer", PrintBuyer);
        cmd.Parameters.AddWithValue("@ToOrdInConsignee", ToOrdInConsignee);
        cmd.Parameters.AddWithValue("@BillOfLoadingNo", BillOfLoadingNo);
        cmd.Parameters.AddWithValue("@BillOfLoadingDate", BillOfLoadingDate);
        cmd.Parameters.AddWithValue("@ContainerNo", ContainerNo);
        cmd.Parameters.AddWithValue("@ShippingLine", ShippingLine);
        cmd.Parameters.AddWithValue("@ExportEntryNo", ExportEntryNo);
        cmd.Parameters.AddWithValue("@ExportEntryDate", ExportEntryDate);
        cmd.Parameters.AddWithValue("@FOBCIF", FOBCIF);
        cmd.Parameters.AddWithValue("@InlandTransport", InlandTransport);
        cmd.Parameters.AddWithValue("@Freight", Freight);
        cmd.Parameters.AddWithValue("@Insurance", Insurance);
        cmd.Parameters.AddWithValue("@VesselFlightNo", VesselFlightNo);
        cmd.Parameters.AddWithValue("@PreCarriageBy", PreCarriageBy);
        cmd.Parameters.AddWithValue("@PreCarriageRectPlace", PreCarriageRectPlace);
        cmd.Parameters.AddWithValue("@PortofLoading", PortofLoading);
        cmd.Parameters.AddWithValue("@PortOfDischarge", PortOfDischarge);
        cmd.Parameters.AddWithValue("@FinalDestination", FinalDestination);
        cmd.Parameters.AddWithValue("@MarkNo1", MarkNo1);
        cmd.Parameters.AddWithValue("@MarkNo2", MarkNo2);
        cmd.Parameters.AddWithValue("@MarkNo3", MarkNo3);
        cmd.Parameters.AddWithValue("@KindOfPackages", KindOfPackages);
        cmd.Parameters.AddWithValue("@TermsOfDelivery", TermsOfDelivery);
        cmd.Parameters.AddWithValue("@TermsOfPayment", TermsOfPayment);
        cmd.Parameters.AddWithValue("@GoodsDescription", GoodsDescription);
        cmd.Parameters.AddWithValue("@FooterDescription", FooterDescription);
        cmd.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);
        cmd.Parameters.AddWithValue("@FooterPacking", FooterPacking);
        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
        cmd.ExecuteNonQuery();

    }

    public string makeGrid(string ddsearch, string txtsearch)
    {
        string sql = "SELECT Invoiceid, InvoiceNo, InvoiceType, InvoiceYear, InvoiceDate, SONo, CustomerID,CustomerCode, CustomerOderNo FROM View_InvoiceTran where " + ddsearch + " like '%" + txtsearch + "%'";
        return sql;
    }

    public DataTable fillRecords(string autoid)
    {
        string sql = "Select * from View_InvoiceTran where Invoiceid='" + autoid + "'";
        DataTable dt= rp.executeSqlQry(sql);
        return dt;
    }

    public DataTable fillSalesOrderRecords(string autoid)
    {
        string sql = "Select * from View_SalesOrder where SalesOrderId='" + autoid + "'";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;
    }

    public DataTable makelookupgridSalesOrder()
    {
        string sql = "Select [SalesOrderId], [SONo],[SOFYear],[SODate],[PICode],[CustomerCode],[ConsigneeCode],[SODeliveryTo] from [View_SalesOrder]";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }

    public DataTable makelookupgridSalesOrderwithSearch(string keyword)
    {
        string sql = "Select [SalesOrderId], [SONo],[SOFYear],[SODate],[PICode],[CustomerCode],[ConsigneeCode],[SODeliveryTo] from [View_SalesOrder] where [SONo] like '%" + keyword + "%' OR [SOFYear] like '%" + keyword + "%' OR [SODate] like '%" + keyword + "%' OR [PICode] like '%" + keyword + "%' OR [CustomerCode] like '%" + keyword + "%' OR [ConsigneeCode] like '%" + keyword + "%' OR [SODeliveryTo] like '%"+keyword+"%'";
        DataTable dt = rp.executeSqlQry(sql);
        return dt;

    }


    public int getInvoiceSeries(string fin_yr)
    {
        int invseries=1;
        try
        {
            
            string sql = "select MAX(InvSeries) from Sal_Glb_Invoice_Tran where InvoiceYear='"+fin_yr+"'";
            DataTable dt = rp.executeSqlQry(sql);
            if (dt.Rows.Count > 0)
            {
                invseries = int.Parse(dt.Rows[0][0].ToString())+1;
            }
            else
            {
                invseries = 1;
            }
        }
        catch (Exception ex)
        {
           
        }

        return invseries;
    }

   

}