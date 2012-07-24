using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SAL_CustomerCallService
/// </summary>
public class SAL_CustomerCallService
{
    #region define private
           string _CSCRType;
           string _Year;
           string _CSCRDate ;
           string _ComplaintObservation;
           string _CustomerCode;
           string _FinalCustomer;
           string _ContactPerson;
           string _HeaderWeight;
           string _Value;
           string _Currency;
           bool _SampleRecieved;
           string _NatureOfComplaint;
           string _CustomerClaim;
           bool   _PhotoReceived;
           string _AreaOfComplaint;
           string _DANo;
           string _NoOfRolls;
           string _CreditNotes;
           string _TSObservation;
           string _FirstResponseDate;
           string _FirstDelyBy;
           string _SecondResponseDate;
           string _SecondDelyBy;
           string _ThirdResponseDate;
           string _ThirdDelyBy;
           string _OPLS;
           string _ActionPlan;
           string _ActionTaken;
           string _ReturnQuality;
           string _ReturnValue;
           string _CreatedOn;
           string _CreatedBy;


           string _CSCRNumber;
           int _CSCRLineNo;
           string _InvoiceNo;
           string _FullInvoice;
           string _BatchNo;
           string _SubType;
           string _Micron;
           string _Length;
           string _Width;
           string _Weight;
           string _ComplaintDescription;
           string _ExpDateOfCompletion;
           string _ResponsiblePerson;
           string _CompletionDate;
           string _Remarks;
           string _CallStatus;
    #endregion
    #region properties

           public string CSCRType
           {
               get { return _CSCRType; }
               set { _CSCRType = value; }
           }
           public string Year
           {
               get { return _Year; }
               set { _Year = value; }
           }
           public string CSCRDate
           {
               get { return _CSCRDate; }
               set { _CSCRDate = value; }
           }
           public string ComplaintObservation
           {
               get { return _ComplaintObservation; }
               set { _ComplaintObservation = value; }
           }
           public string CustomerCode
           {
               get { return _CustomerCode; }
               set { _CustomerCode = value; }
           }
           public string FinalCustomer
           {
               get { return _FinalCustomer; }
               set { _FinalCustomer = value; }
           }
           public string ContactPerson
          {
              get { return _ContactPerson; }
              set { _ContactPerson = value; }
          }
           public string HeaderWeight
          {
              get { return _HeaderWeight; }
              set { _HeaderWeight = value; }
          }
           public string Value
          {
              get { return _Value; }
              set { _Value = value; }
          }
           public string Currency
           {
               get { return _Currency; }
               set { _Currency = value; }
           }
           public bool SampleRecieved
           {
               get { return _SampleRecieved; }
               set { _SampleRecieved = value; }
           }
           public string NatureOfComplaint
           {
               get { return _NatureOfComplaint; }
               set { _NatureOfComplaint = value; }
           }
           public string CustomerClaim
           {
               get { return _CustomerClaim; }
               set { _CustomerClaim = value; }
           }
           public bool PhotoReceived
           {
               get { return _PhotoReceived; }
               set { _PhotoReceived = value; }
           }
           public string AreaOfComplaint
           {
               get { return _AreaOfComplaint; }
               set { _AreaOfComplaint = value; }
           }
           public string DANo
           {
               get { return _DANo; }
               set { _DANo = value; }
           }
           public string NoOfRolls
           {
               get { return _NoOfRolls; }
               set { _NoOfRolls = value; }
           }
           public string CreditNotes
           {
               get { return _CreditNotes; }
               set { _CreditNotes = value; }
           }
           public string TSObservation
           {
               get { return _TSObservation; }
               set { _TSObservation = value; }
           }
           public string FirstResponseDate
           {
               get { return _FirstResponseDate; }
               set { _FirstResponseDate = value; }
           }
           public string FirstDelyBy
           {
               get { return _FirstDelyBy; }
               set { _FirstDelyBy = value; }
           }
           public string SecondResponseDate
           {
               get { return _SecondResponseDate; }
               set { _SecondResponseDate = value; }
           }
           public string SecondDelyBy
           {
               get { return _SecondDelyBy; }
               set { _SecondDelyBy = value; }
           }
           public string ThirdResponseDate
           {
               get { return _ThirdResponseDate; }
               set { _ThirdResponseDate = value; }
           }
           public string ThirdDelyBy
           {
               get { return _ThirdDelyBy; }
               set { _ThirdDelyBy = value; }
           }
           public string OPLS
           {
               get { return _OPLS; }
               set { _OPLS = value; }
           }
           public string ActionPlan
           {
               get { return _ActionPlan; }
               set { _ActionPlan = value; }
           }
           public string ActionTaken
           {
               get { return _ActionTaken; }
               set { _ActionTaken = value; }
           }
           public string ReturnQuality
           {
               get { return _ReturnQuality; }
               set { _ReturnQuality = value; }
           }
           public string ReturnValue
           {
               get { return _ReturnValue; }
               set { _ReturnValue = value; }
           }
           public string CreatedOn
           {
               get { return _CreatedOn; }
               set { _CreatedOn = value; }
           }
           public string CreatedBy
           {
               get { return _CreatedBy; }
               set { _CreatedBy = value; }
           }
           public string CSCRNumber
           {
               get { return _CSCRNumber; }
               set { _CSCRNumber = value; }
           }
           public int CSCRLineNo
           {
               get { return _CSCRLineNo; }
               set { _CSCRLineNo = value; }
           }
           public string InvoiceNo
           {
               get { return _InvoiceNo; }
               set { _InvoiceNo = value; }
           }
           public string FullInvoice
           {
               get { return _FullInvoice; }
               set { _FullInvoice = value; }
           }
           public string BatchNo
           {
               get { return _BatchNo; }
               set { _BatchNo = value; }
           }
           public string SubType
           {
               get { return _SubType; }
               set { _SubType = value; }
           }
           public string Micron
           {
               get { return _Micron; }
               set { _Micron = value; }
           }
           public string Length
           {
               get { return _Length; }
               set { _Length = value; }
           }
           public string Width
           {
               get { return _Width; }
               set { _Width = value; }
           }
           public string Weight
           {
               get { return _Weight; }
               set { _Weight = value; }
           }
           public string ComplaintDescription
           {
               get { return _ComplaintDescription; }
               set { _ComplaintDescription = value; }
           }
           public string ExpDateOfCompletion
           {
               get { return _ExpDateOfCompletion; }
               set { _ExpDateOfCompletion = value; }
           }
           public string ResponsiblePerson
           {
               get { return _ResponsiblePerson; }
               set { _ResponsiblePerson = value; }
           }
           public string CompletionDate
           {
               get { return _CompletionDate; }
               set { _CompletionDate = value; }
           }
           public string Remarks
           {
               get { return _Remarks; }
               set { _Remarks = value; }
           }
           public string CallStatus
           {
               get { return _CallStatus; }
               set { _CallStatus = value; }
           }
    
         
           #endregion


    public SAL_CustomerCallService()
	{
		
	}
    public SAL_CustomerCallService( string CSCRType,string Year, string CSCRDate,string ComplaintObservation,string CustomerCode,
           string FinalCustomer,string ContactPerson,string HeaderWeight,string Value,string Currency,bool SampleRecieved,
           string NatureOfComplaint,string CustomerClaim,bool PhotoReceived,string AreaOfComplaint,
           string DANo,string NoOfRolls,string CreditNotes, string TSObservation,string FirstResponseDate,string FirstDelyBy,
           string SecondResponseDate,string SecondDelyBy,string ThirdResponseDate,string ThirdDelyBy,string OPLS,string ActionPlan,
           string ActionTaken,string ReturnQuality,string ReturnValue,string CreatedOn,string CreatedBy,
           int CSCRLineNo, string InvoiceNo,string FullInvoice,string BatchNo,string SubType,
           string Micron,string Length,string Width,string Weight,string ComplaintDescription,string ExpDateOfCompletion,
           string ResponsiblePerson,string CompletionDate,string Remarks,string Callstatus)
    {
        _CSCRType = CSCRType;
        _Year = Year;
        _CSCRDate = CSCRDate;
        _ComplaintObservation = ComplaintObservation;
        _CustomerCode = CustomerCode;
        _FinalCustomer = FinalCustomer;
        _ContactPerson = ContactPerson;
        _HeaderWeight = HeaderWeight;
        _Value = Value;
        _Currency = Currency;
        _SampleRecieved = SampleRecieved;
        _NatureOfComplaint = NatureOfComplaint;
        _CustomerClaim = CustomerClaim;
        _PhotoReceived = PhotoReceived;
        _AreaOfComplaint = AreaOfComplaint;
        _DANo = DANo;
        _NoOfRolls = NoOfRolls;
        _CreditNotes = CreditNotes;
        _TSObservation = TSObservation;
        _FirstResponseDate = FirstResponseDate;
        _FirstDelyBy = FirstDelyBy;
        _SecondResponseDate = SecondResponseDate;
        _SecondDelyBy = SecondDelyBy;
        _ThirdResponseDate = ThirdResponseDate;
        _ThirdDelyBy = ThirdDelyBy;
        _OPLS = OPLS;
        _ActionPlan = ActionPlan;
        _ActionTaken = ActionTaken;
        _ReturnQuality = ReturnQuality;
        _ReturnValue = ReturnValue;
        _CreatedOn = CreatedOn;
        _CreatedBy = CreatedBy;
        _CSCRLineNo = CSCRLineNo;
        _InvoiceNo = InvoiceNo;
        _FullInvoice = FullInvoice;
        _BatchNo = BatchNo;
        _SubType = SubType;
        _Micron = Micron;
        _Length = Length;
        _Width = Width;
        _Weight = Weight;
        _ComplaintDescription = ComplaintDescription;
        _ExpDateOfCompletion = ExpDateOfCompletion;
        _ResponsiblePerson = ResponsiblePerson;
        _CompletionDate = CompletionDate;
        _Remarks = Remarks;
        _CallStatus = Callstatus;
      }

    public int insertcustomercallservice()
    {
        SqlDataProvider sda = new SqlDataProvider();
        return sda.insertcustomercallservice(this);
    }
}