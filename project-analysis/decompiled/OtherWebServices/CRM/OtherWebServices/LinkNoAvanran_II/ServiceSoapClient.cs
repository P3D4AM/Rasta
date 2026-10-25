using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class ServiceSoapClient : ClientBase<ServiceSoap>, ServiceSoap
{
	public ServiceSoapClient()
	{
	}

	public ServiceSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public ServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	InputResponse ServiceSoap.Input(InputRequest request)
	{
		return base.Channel.Input(request);
	}

	public string Input(string Store, string Shop_Code, string Quan, string Code, string Cost, string Price, string Doc_No, string Doc_Date, string Sharh, string Source, string UserId)
	{
		InputRequest inputRequest = new InputRequest();
		inputRequest.Body = new InputRequestBody();
		inputRequest.Body.Store = Store;
		inputRequest.Body.Shop_Code = Shop_Code;
		inputRequest.Body.Quan = Quan;
		inputRequest.Body.Code = Code;
		inputRequest.Body.Cost = Cost;
		inputRequest.Body.Price = Price;
		inputRequest.Body.Doc_No = Doc_No;
		inputRequest.Body.Doc_Date = Doc_Date;
		inputRequest.Body.Sharh = Sharh;
		inputRequest.Body.Source = Source;
		inputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).Input(inputRequest).Body.InputResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<InputResponse> ServiceSoap.InputAsync(InputRequest request)
	{
		return base.Channel.InputAsync(request);
	}

	public Task<InputResponse> InputAsync(string Store, string Shop_Code, string Quan, string Code, string Cost, string Price, string Doc_No, string Doc_Date, string Sharh, string Source, string UserId)
	{
		InputRequest inputRequest = new InputRequest();
		inputRequest.Body = new InputRequestBody();
		inputRequest.Body.Store = Store;
		inputRequest.Body.Shop_Code = Shop_Code;
		inputRequest.Body.Quan = Quan;
		inputRequest.Body.Code = Code;
		inputRequest.Body.Cost = Cost;
		inputRequest.Body.Price = Price;
		inputRequest.Body.Doc_No = Doc_No;
		inputRequest.Body.Doc_Date = Doc_Date;
		inputRequest.Body.Sharh = Sharh;
		inputRequest.Body.Source = Source;
		inputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).InputAsync(inputRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromInputResponse ServiceSoap.ReadFromInput(ReadFromInputRequest request)
	{
		return base.Channel.ReadFromInput(request);
	}

	public string ReadFromInput(string Doc_No, string Store, string UserId)
	{
		ReadFromInputRequest readFromInputRequest = new ReadFromInputRequest();
		readFromInputRequest.Body = new ReadFromInputRequestBody();
		readFromInputRequest.Body.Doc_No = Doc_No;
		readFromInputRequest.Body.Store = Store;
		readFromInputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromInput(readFromInputRequest).Body.ReadFromInputResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromInputResponse> ServiceSoap.ReadFromInputAsync(ReadFromInputRequest request)
	{
		return base.Channel.ReadFromInputAsync(request);
	}

	public Task<ReadFromInputResponse> ReadFromInputAsync(string Doc_No, string Store, string UserId)
	{
		ReadFromInputRequest readFromInputRequest = new ReadFromInputRequest();
		readFromInputRequest.Body = new ReadFromInputRequestBody();
		readFromInputRequest.Body.Doc_No = Doc_No;
		readFromInputRequest.Body.Store = Store;
		readFromInputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromInputAsync(readFromInputRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromInputDateRangeResponse ServiceSoap.ReadFromInputDateRange(ReadFromInputDateRangeRequest request)
	{
		return base.Channel.ReadFromInputDateRange(request);
	}

	public string ReadFromInputDateRange(string FromDate, string ToDate, string Store, string UserId)
	{
		ReadFromInputDateRangeRequest readFromInputDateRangeRequest = new ReadFromInputDateRangeRequest();
		readFromInputDateRangeRequest.Body = new ReadFromInputDateRangeRequestBody();
		readFromInputDateRangeRequest.Body.FromDate = FromDate;
		readFromInputDateRangeRequest.Body.ToDate = ToDate;
		readFromInputDateRangeRequest.Body.Store = Store;
		readFromInputDateRangeRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromInputDateRange(readFromInputDateRangeRequest).Body.ReadFromInputDateRangeResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromInputDateRangeResponse> ServiceSoap.ReadFromInputDateRangeAsync(ReadFromInputDateRangeRequest request)
	{
		return base.Channel.ReadFromInputDateRangeAsync(request);
	}

	public Task<ReadFromInputDateRangeResponse> ReadFromInputDateRangeAsync(string FromDate, string ToDate, string Store, string UserId)
	{
		ReadFromInputDateRangeRequest readFromInputDateRangeRequest = new ReadFromInputDateRangeRequest();
		readFromInputDateRangeRequest.Body = new ReadFromInputDateRangeRequestBody();
		readFromInputDateRangeRequest.Body.FromDate = FromDate;
		readFromInputDateRangeRequest.Body.ToDate = ToDate;
		readFromInputDateRangeRequest.Body.Store = Store;
		readFromInputDateRangeRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromInputDateRangeAsync(readFromInputDateRangeRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	OutputResponse ServiceSoap.Output(OutputRequest request)
	{
		return base.Channel.Output(request);
	}

	public string Output(string Store, string Shop_Code, string Quan, string Code, string Cost, string Price, string Doc_No, string Doc_Date, string Sharh, string Discount, string Discount2, string UserId)
	{
		OutputRequest outputRequest = new OutputRequest();
		outputRequest.Body = new OutputRequestBody();
		outputRequest.Body.Store = Store;
		outputRequest.Body.Shop_Code = Shop_Code;
		outputRequest.Body.Quan = Quan;
		outputRequest.Body.Code = Code;
		outputRequest.Body.Cost = Cost;
		outputRequest.Body.Price = Price;
		outputRequest.Body.Doc_No = Doc_No;
		outputRequest.Body.Doc_Date = Doc_Date;
		outputRequest.Body.Sharh = Sharh;
		outputRequest.Body.Discount = Discount;
		outputRequest.Body.Discount2 = Discount2;
		outputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).Output(outputRequest).Body.OutputResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<OutputResponse> ServiceSoap.OutputAsync(OutputRequest request)
	{
		return base.Channel.OutputAsync(request);
	}

	public Task<OutputResponse> OutputAsync(string Store, string Shop_Code, string Quan, string Code, string Cost, string Price, string Doc_No, string Doc_Date, string Sharh, string Discount, string Discount2, string UserId)
	{
		OutputRequest outputRequest = new OutputRequest();
		outputRequest.Body = new OutputRequestBody();
		outputRequest.Body.Store = Store;
		outputRequest.Body.Shop_Code = Shop_Code;
		outputRequest.Body.Quan = Quan;
		outputRequest.Body.Code = Code;
		outputRequest.Body.Cost = Cost;
		outputRequest.Body.Price = Price;
		outputRequest.Body.Doc_No = Doc_No;
		outputRequest.Body.Doc_Date = Doc_Date;
		outputRequest.Body.Sharh = Sharh;
		outputRequest.Body.Discount = Discount;
		outputRequest.Body.Discount2 = Discount2;
		outputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).OutputAsync(outputRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromOutputResponse ServiceSoap.ReadFromOutput(ReadFromOutputRequest request)
	{
		return base.Channel.ReadFromOutput(request);
	}

	public string ReadFromOutput(string FromDate, string ToDate, string Store, string UserId)
	{
		ReadFromOutputRequest readFromOutputRequest = new ReadFromOutputRequest();
		readFromOutputRequest.Body = new ReadFromOutputRequestBody();
		readFromOutputRequest.Body.FromDate = FromDate;
		readFromOutputRequest.Body.ToDate = ToDate;
		readFromOutputRequest.Body.Store = Store;
		readFromOutputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromOutput(readFromOutputRequest).Body.ReadFromOutputResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromOutputResponse> ServiceSoap.ReadFromOutputAsync(ReadFromOutputRequest request)
	{
		return base.Channel.ReadFromOutputAsync(request);
	}

	public Task<ReadFromOutputResponse> ReadFromOutputAsync(string FromDate, string ToDate, string Store, string UserId)
	{
		ReadFromOutputRequest readFromOutputRequest = new ReadFromOutputRequest();
		readFromOutputRequest.Body = new ReadFromOutputRequestBody();
		readFromOutputRequest.Body.FromDate = FromDate;
		readFromOutputRequest.Body.ToDate = ToDate;
		readFromOutputRequest.Body.Store = Store;
		readFromOutputRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromOutputAsync(readFromOutputRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	InsertIntoPish_FactorResponse ServiceSoap.InsertIntoPish_Factor(InsertIntoPish_FactorRequest request)
	{
		return base.Channel.InsertIntoPish_Factor(request);
	}

	public string InsertIntoPish_Factor(string Store, string Shop_Code, string Quan, string Code, string Cost, string Price, string Doc_No, string Doc_Date, string Sharh, string Serial, string Discount, string Shahr, string Training, string Seq, string Karbar, string Part, string UserId)
	{
		InsertIntoPish_FactorRequest insertIntoPish_FactorRequest = new InsertIntoPish_FactorRequest();
		insertIntoPish_FactorRequest.Body = new InsertIntoPish_FactorRequestBody();
		insertIntoPish_FactorRequest.Body.Store = Store;
		insertIntoPish_FactorRequest.Body.Shop_Code = Shop_Code;
		insertIntoPish_FactorRequest.Body.Quan = Quan;
		insertIntoPish_FactorRequest.Body.Code = Code;
		insertIntoPish_FactorRequest.Body.Cost = Cost;
		insertIntoPish_FactorRequest.Body.Price = Price;
		insertIntoPish_FactorRequest.Body.Doc_No = Doc_No;
		insertIntoPish_FactorRequest.Body.Doc_Date = Doc_Date;
		insertIntoPish_FactorRequest.Body.Sharh = Sharh;
		insertIntoPish_FactorRequest.Body.Serial = Serial;
		insertIntoPish_FactorRequest.Body.Discount = Discount;
		insertIntoPish_FactorRequest.Body.Shahr = Shahr;
		insertIntoPish_FactorRequest.Body.Training = Training;
		insertIntoPish_FactorRequest.Body.Seq = Seq;
		insertIntoPish_FactorRequest.Body.Karbar = Karbar;
		insertIntoPish_FactorRequest.Body.Part = Part;
		insertIntoPish_FactorRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).InsertIntoPish_Factor(insertIntoPish_FactorRequest).Body.InsertIntoPish_FactorResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<InsertIntoPish_FactorResponse> ServiceSoap.InsertIntoPish_FactorAsync(InsertIntoPish_FactorRequest request)
	{
		return base.Channel.InsertIntoPish_FactorAsync(request);
	}

	public Task<InsertIntoPish_FactorResponse> InsertIntoPish_FactorAsync(string Store, string Shop_Code, string Quan, string Code, string Cost, string Price, string Doc_No, string Doc_Date, string Sharh, string Serial, string Discount, string Shahr, string Training, string Seq, string Karbar, string Part, string UserId)
	{
		InsertIntoPish_FactorRequest insertIntoPish_FactorRequest = new InsertIntoPish_FactorRequest();
		insertIntoPish_FactorRequest.Body = new InsertIntoPish_FactorRequestBody();
		insertIntoPish_FactorRequest.Body.Store = Store;
		insertIntoPish_FactorRequest.Body.Shop_Code = Shop_Code;
		insertIntoPish_FactorRequest.Body.Quan = Quan;
		insertIntoPish_FactorRequest.Body.Code = Code;
		insertIntoPish_FactorRequest.Body.Cost = Cost;
		insertIntoPish_FactorRequest.Body.Price = Price;
		insertIntoPish_FactorRequest.Body.Doc_No = Doc_No;
		insertIntoPish_FactorRequest.Body.Doc_Date = Doc_Date;
		insertIntoPish_FactorRequest.Body.Sharh = Sharh;
		insertIntoPish_FactorRequest.Body.Serial = Serial;
		insertIntoPish_FactorRequest.Body.Discount = Discount;
		insertIntoPish_FactorRequest.Body.Shahr = Shahr;
		insertIntoPish_FactorRequest.Body.Training = Training;
		insertIntoPish_FactorRequest.Body.Seq = Seq;
		insertIntoPish_FactorRequest.Body.Karbar = Karbar;
		insertIntoPish_FactorRequest.Body.Part = Part;
		insertIntoPish_FactorRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).InsertIntoPish_FactorAsync(insertIntoPish_FactorRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromPish_FactorResponse ServiceSoap.ReadFromPish_Factor(ReadFromPish_FactorRequest request)
	{
		return base.Channel.ReadFromPish_Factor(request);
	}

	public string ReadFromPish_Factor(string Store, string Doc_No, string UserId)
	{
		ReadFromPish_FactorRequest readFromPish_FactorRequest = new ReadFromPish_FactorRequest();
		readFromPish_FactorRequest.Body = new ReadFromPish_FactorRequestBody();
		readFromPish_FactorRequest.Body.Store = Store;
		readFromPish_FactorRequest.Body.Doc_No = Doc_No;
		readFromPish_FactorRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromPish_Factor(readFromPish_FactorRequest).Body.ReadFromPish_FactorResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromPish_FactorResponse> ServiceSoap.ReadFromPish_FactorAsync(ReadFromPish_FactorRequest request)
	{
		return base.Channel.ReadFromPish_FactorAsync(request);
	}

	public Task<ReadFromPish_FactorResponse> ReadFromPish_FactorAsync(string Store, string Doc_No, string UserId)
	{
		ReadFromPish_FactorRequest readFromPish_FactorRequest = new ReadFromPish_FactorRequest();
		readFromPish_FactorRequest.Body = new ReadFromPish_FactorRequestBody();
		readFromPish_FactorRequest.Body.Store = Store;
		readFromPish_FactorRequest.Body.Doc_No = Doc_No;
		readFromPish_FactorRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromPish_FactorAsync(readFromPish_FactorRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromBazaryabanResponse ServiceSoap.ReadFromBazaryaban(ReadFromBazaryabanRequest request)
	{
		return base.Channel.ReadFromBazaryaban(request);
	}

	public string ReadFromBazaryaban(string Part, string UserId)
	{
		ReadFromBazaryabanRequest readFromBazaryabanRequest = new ReadFromBazaryabanRequest();
		readFromBazaryabanRequest.Body = new ReadFromBazaryabanRequestBody();
		readFromBazaryabanRequest.Body.Part = Part;
		readFromBazaryabanRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromBazaryaban(readFromBazaryabanRequest).Body.ReadFromBazaryabanResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromBazaryabanResponse> ServiceSoap.ReadFromBazaryabanAsync(ReadFromBazaryabanRequest request)
	{
		return base.Channel.ReadFromBazaryabanAsync(request);
	}

	public Task<ReadFromBazaryabanResponse> ReadFromBazaryabanAsync(string Part, string UserId)
	{
		ReadFromBazaryabanRequest readFromBazaryabanRequest = new ReadFromBazaryabanRequest();
		readFromBazaryabanRequest.Body = new ReadFromBazaryabanRequestBody();
		readFromBazaryabanRequest.Body.Part = Part;
		readFromBazaryabanRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromBazaryabanAsync(readFromBazaryabanRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromAvalDorehResponse ServiceSoap.ReadFromAvalDoreh(ReadFromAvalDorehRequest request)
	{
		return base.Channel.ReadFromAvalDoreh(request);
	}

	public string ReadFromAvalDoreh(string Store, string Code, string UserId)
	{
		ReadFromAvalDorehRequest readFromAvalDorehRequest = new ReadFromAvalDorehRequest();
		readFromAvalDorehRequest.Body = new ReadFromAvalDorehRequestBody();
		readFromAvalDorehRequest.Body.Store = Store;
		readFromAvalDorehRequest.Body.Code = Code;
		readFromAvalDorehRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromAvalDoreh(readFromAvalDorehRequest).Body.ReadFromAvalDorehResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromAvalDorehResponse> ServiceSoap.ReadFromAvalDorehAsync(ReadFromAvalDorehRequest request)
	{
		return base.Channel.ReadFromAvalDorehAsync(request);
	}

	public Task<ReadFromAvalDorehResponse> ReadFromAvalDorehAsync(string Store, string Code, string UserId)
	{
		ReadFromAvalDorehRequest readFromAvalDorehRequest = new ReadFromAvalDorehRequest();
		readFromAvalDorehRequest.Body = new ReadFromAvalDorehRequestBody();
		readFromAvalDorehRequest.Body.Store = Store;
		readFromAvalDorehRequest.Body.Code = Code;
		readFromAvalDorehRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromAvalDorehAsync(readFromAvalDorehRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromPish_FactorDateRangeResponse ServiceSoap.ReadFromPish_FactorDateRange(ReadFromPish_FactorDateRangeRequest request)
	{
		return base.Channel.ReadFromPish_FactorDateRange(request);
	}

	public string ReadFromPish_FactorDateRange(string FromDate, string ToDate, string Store, string UserId)
	{
		ReadFromPish_FactorDateRangeRequest readFromPish_FactorDateRangeRequest = new ReadFromPish_FactorDateRangeRequest();
		readFromPish_FactorDateRangeRequest.Body = new ReadFromPish_FactorDateRangeRequestBody();
		readFromPish_FactorDateRangeRequest.Body.FromDate = FromDate;
		readFromPish_FactorDateRangeRequest.Body.ToDate = ToDate;
		readFromPish_FactorDateRangeRequest.Body.Store = Store;
		readFromPish_FactorDateRangeRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromPish_FactorDateRange(readFromPish_FactorDateRangeRequest).Body.ReadFromPish_FactorDateRangeResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromPish_FactorDateRangeResponse> ServiceSoap.ReadFromPish_FactorDateRangeAsync(ReadFromPish_FactorDateRangeRequest request)
	{
		return base.Channel.ReadFromPish_FactorDateRangeAsync(request);
	}

	public Task<ReadFromPish_FactorDateRangeResponse> ReadFromPish_FactorDateRangeAsync(string FromDate, string ToDate, string Store, string UserId)
	{
		ReadFromPish_FactorDateRangeRequest readFromPish_FactorDateRangeRequest = new ReadFromPish_FactorDateRangeRequest();
		readFromPish_FactorDateRangeRequest.Body = new ReadFromPish_FactorDateRangeRequestBody();
		readFromPish_FactorDateRangeRequest.Body.FromDate = FromDate;
		readFromPish_FactorDateRangeRequest.Body.ToDate = ToDate;
		readFromPish_FactorDateRangeRequest.Body.Store = Store;
		readFromPish_FactorDateRangeRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromPish_FactorDateRangeAsync(readFromPish_FactorDateRangeRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromRequestKalaResponse ServiceSoap.ReadFromRequestKala(ReadFromRequestKalaRequest request)
	{
		return base.Channel.ReadFromRequestKala(request);
	}

	public string ReadFromRequestKala(string FromDate, string ToDate, string DocNumber, string StoreID, string UserId)
	{
		ReadFromRequestKalaRequest readFromRequestKalaRequest = new ReadFromRequestKalaRequest();
		readFromRequestKalaRequest.Body = new ReadFromRequestKalaRequestBody();
		readFromRequestKalaRequest.Body.FromDate = FromDate;
		readFromRequestKalaRequest.Body.ToDate = ToDate;
		readFromRequestKalaRequest.Body.DocNumber = DocNumber;
		readFromRequestKalaRequest.Body.StoreID = StoreID;
		readFromRequestKalaRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromRequestKala(readFromRequestKalaRequest).Body.ReadFromRequestKalaResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromRequestKalaResponse> ServiceSoap.ReadFromRequestKalaAsync(ReadFromRequestKalaRequest request)
	{
		return base.Channel.ReadFromRequestKalaAsync(request);
	}

	public Task<ReadFromRequestKalaResponse> ReadFromRequestKalaAsync(string FromDate, string ToDate, string DocNumber, string StoreID, string UserId)
	{
		ReadFromRequestKalaRequest readFromRequestKalaRequest = new ReadFromRequestKalaRequest();
		readFromRequestKalaRequest.Body = new ReadFromRequestKalaRequestBody();
		readFromRequestKalaRequest.Body.FromDate = FromDate;
		readFromRequestKalaRequest.Body.ToDate = ToDate;
		readFromRequestKalaRequest.Body.DocNumber = DocNumber;
		readFromRequestKalaRequest.Body.StoreID = StoreID;
		readFromRequestKalaRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromRequestKalaAsync(readFromRequestKalaRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	RequestKalaResponse ServiceSoap.RequestKala(RequestKalaRequest request)
	{
		return base.Channel.RequestKala(request);
	}

	public string RequestKala(string Store, string Quan, string Code, string Doc_No, string Doc_Date, string Sharh, string UserId)
	{
		RequestKalaRequest requestKalaRequest = new RequestKalaRequest();
		requestKalaRequest.Body = new RequestKalaRequestBody();
		requestKalaRequest.Body.Store = Store;
		requestKalaRequest.Body.Quan = Quan;
		requestKalaRequest.Body.Code = Code;
		requestKalaRequest.Body.Doc_No = Doc_No;
		requestKalaRequest.Body.Doc_Date = Doc_Date;
		requestKalaRequest.Body.Sharh = Sharh;
		requestKalaRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).RequestKala(requestKalaRequest).Body.RequestKalaResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<RequestKalaResponse> ServiceSoap.RequestKalaAsync(RequestKalaRequest request)
	{
		return base.Channel.RequestKalaAsync(request);
	}

	public Task<RequestKalaResponse> RequestKalaAsync(string Store, string Quan, string Code, string Doc_No, string Doc_Date, string Sharh, string UserId)
	{
		RequestKalaRequest requestKalaRequest = new RequestKalaRequest();
		requestKalaRequest.Body = new RequestKalaRequestBody();
		requestKalaRequest.Body.Store = Store;
		requestKalaRequest.Body.Quan = Quan;
		requestKalaRequest.Body.Code = Code;
		requestKalaRequest.Body.Doc_No = Doc_No;
		requestKalaRequest.Body.Doc_Date = Doc_Date;
		requestKalaRequest.Body.Sharh = Sharh;
		requestKalaRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).RequestKalaAsync(requestKalaRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromRequestResponse ServiceSoap.ReadFromRequest(ReadFromRequestRequest request)
	{
		return base.Channel.ReadFromRequest(request);
	}

	public string ReadFromRequest(string FromDate, string ToDate, string DocNumber, string StoreID, string UserId)
	{
		ReadFromRequestRequest readFromRequestRequest = new ReadFromRequestRequest();
		readFromRequestRequest.Body = new ReadFromRequestRequestBody();
		readFromRequestRequest.Body.FromDate = FromDate;
		readFromRequestRequest.Body.ToDate = ToDate;
		readFromRequestRequest.Body.DocNumber = DocNumber;
		readFromRequestRequest.Body.StoreID = StoreID;
		readFromRequestRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromRequest(readFromRequestRequest).Body.ReadFromRequestResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromRequestResponse> ServiceSoap.ReadFromRequestAsync(ReadFromRequestRequest request)
	{
		return base.Channel.ReadFromRequestAsync(request);
	}

	public Task<ReadFromRequestResponse> ReadFromRequestAsync(string FromDate, string ToDate, string DocNumber, string StoreID, string UserId)
	{
		ReadFromRequestRequest readFromRequestRequest = new ReadFromRequestRequest();
		readFromRequestRequest.Body = new ReadFromRequestRequestBody();
		readFromRequestRequest.Body.FromDate = FromDate;
		readFromRequestRequest.Body.ToDate = ToDate;
		readFromRequestRequest.Body.DocNumber = DocNumber;
		readFromRequestRequest.Body.StoreID = StoreID;
		readFromRequestRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromRequestAsync(readFromRequestRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadfromPayPastResponse ServiceSoap.ReadfromPayPast(ReadfromPayPastRequest request)
	{
		return base.Channel.ReadfromPayPast(request);
	}

	public string ReadfromPayPast(string Sal, string Mah, string PersonelyNo, string CodeMeli)
	{
		ReadfromPayPastRequest readfromPayPastRequest = new ReadfromPayPastRequest();
		readfromPayPastRequest.Body = new ReadfromPayPastRequestBody();
		readfromPayPastRequest.Body.Sal = Sal;
		readfromPayPastRequest.Body.Mah = Mah;
		readfromPayPastRequest.Body.PersonelyNo = PersonelyNo;
		readfromPayPastRequest.Body.CodeMeli = CodeMeli;
		return ((ServiceSoap)this).ReadfromPayPast(readfromPayPastRequest).Body.ReadfromPayPastResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadfromPayPastResponse> ServiceSoap.ReadfromPayPastAsync(ReadfromPayPastRequest request)
	{
		return base.Channel.ReadfromPayPastAsync(request);
	}

	public Task<ReadfromPayPastResponse> ReadfromPayPastAsync(string Sal, string Mah, string PersonelyNo, string CodeMeli)
	{
		ReadfromPayPastRequest readfromPayPastRequest = new ReadfromPayPastRequest();
		readfromPayPastRequest.Body = new ReadfromPayPastRequestBody();
		readfromPayPastRequest.Body.Sal = Sal;
		readfromPayPastRequest.Body.Mah = Mah;
		readfromPayPastRequest.Body.PersonelyNo = PersonelyNo;
		readfromPayPastRequest.Body.CodeMeli = CodeMeli;
		return ((ServiceSoap)this).ReadfromPayPastAsync(readfromPayPastRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	HistoryOfRequestResponse ServiceSoap.HistoryOfRequest(HistoryOfRequestRequest request)
	{
		return base.Channel.HistoryOfRequest(request);
	}

	public string HistoryOfRequest(string Store, string Doc_No)
	{
		HistoryOfRequestRequest historyOfRequestRequest = new HistoryOfRequestRequest();
		historyOfRequestRequest.Body = new HistoryOfRequestRequestBody();
		historyOfRequestRequest.Body.Store = Store;
		historyOfRequestRequest.Body.Doc_No = Doc_No;
		return ((ServiceSoap)this).HistoryOfRequest(historyOfRequestRequest).Body.HistoryOfRequestResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<HistoryOfRequestResponse> ServiceSoap.HistoryOfRequestAsync(HistoryOfRequestRequest request)
	{
		return base.Channel.HistoryOfRequestAsync(request);
	}

	public Task<HistoryOfRequestResponse> HistoryOfRequestAsync(string Store, string Doc_No)
	{
		HistoryOfRequestRequest historyOfRequestRequest = new HistoryOfRequestRequest();
		historyOfRequestRequest.Body = new HistoryOfRequestRequestBody();
		historyOfRequestRequest.Body.Store = Store;
		historyOfRequestRequest.Body.Doc_No = Doc_No;
		return ((ServiceSoap)this).HistoryOfRequestAsync(historyOfRequestRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	RequestResponse ServiceSoap.Request(RequestRequest request)
	{
		return base.Channel.Request(request);
	}

	public string Request(string Store, string Quan, string Code, string Doc_No, string Doc_Date, string Sharh, string Automatic, string UserId)
	{
		RequestRequest requestRequest = new RequestRequest();
		requestRequest.Body = new RequestRequestBody();
		requestRequest.Body.Store = Store;
		requestRequest.Body.Quan = Quan;
		requestRequest.Body.Code = Code;
		requestRequest.Body.Doc_No = Doc_No;
		requestRequest.Body.Doc_Date = Doc_Date;
		requestRequest.Body.Sharh = Sharh;
		requestRequest.Body.Automatic = Automatic;
		requestRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).Request(requestRequest).Body.RequestResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<RequestResponse> ServiceSoap.RequestAsync(RequestRequest request)
	{
		return base.Channel.RequestAsync(request);
	}

	public Task<RequestResponse> RequestAsync(string Store, string Quan, string Code, string Doc_No, string Doc_Date, string Sharh, string Automatic, string UserId)
	{
		RequestRequest requestRequest = new RequestRequest();
		requestRequest.Body = new RequestRequestBody();
		requestRequest.Body.Store = Store;
		requestRequest.Body.Quan = Quan;
		requestRequest.Body.Code = Code;
		requestRequest.Body.Doc_No = Doc_No;
		requestRequest.Body.Doc_Date = Doc_Date;
		requestRequest.Body.Sharh = Sharh;
		requestRequest.Body.Automatic = Automatic;
		requestRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).RequestAsync(requestRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	InsertEditIntoShopKharidResponse ServiceSoap.InsertEditIntoShopKharid(InsertEditIntoShopKharidRequest request)
	{
		return base.Channel.InsertEditIntoShopKharid(request);
	}

	public string InsertEditIntoShopKharid(string Shop_Code, string Shop_Name, string Name, string Family, string Address, string Comm_No, string Tel, string Mobile, string ProvinceID, string CityID, string Kol, string Moeen, string Tafsili1, string Tafsili2, string CodeMeli, string UserId)
	{
		InsertEditIntoShopKharidRequest insertEditIntoShopKharidRequest = new InsertEditIntoShopKharidRequest();
		insertEditIntoShopKharidRequest.Body = new InsertEditIntoShopKharidRequestBody();
		insertEditIntoShopKharidRequest.Body.Shop_Code = Shop_Code;
		insertEditIntoShopKharidRequest.Body.Shop_Name = Shop_Name;
		insertEditIntoShopKharidRequest.Body.Name = Name;
		insertEditIntoShopKharidRequest.Body.Family = Family;
		insertEditIntoShopKharidRequest.Body.Address = Address;
		insertEditIntoShopKharidRequest.Body.Comm_No = Comm_No;
		insertEditIntoShopKharidRequest.Body.Tel = Tel;
		insertEditIntoShopKharidRequest.Body.Mobile = Mobile;
		insertEditIntoShopKharidRequest.Body.ProvinceID = ProvinceID;
		insertEditIntoShopKharidRequest.Body.CityID = CityID;
		insertEditIntoShopKharidRequest.Body.Kol = Kol;
		insertEditIntoShopKharidRequest.Body.Moeen = Moeen;
		insertEditIntoShopKharidRequest.Body.Tafsili1 = Tafsili1;
		insertEditIntoShopKharidRequest.Body.Tafsili2 = Tafsili2;
		insertEditIntoShopKharidRequest.Body.CodeMeli = CodeMeli;
		insertEditIntoShopKharidRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).InsertEditIntoShopKharid(insertEditIntoShopKharidRequest).Body.InsertEditIntoShopKharidResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<InsertEditIntoShopKharidResponse> ServiceSoap.InsertEditIntoShopKharidAsync(InsertEditIntoShopKharidRequest request)
	{
		return base.Channel.InsertEditIntoShopKharidAsync(request);
	}

	public Task<InsertEditIntoShopKharidResponse> InsertEditIntoShopKharidAsync(string Shop_Code, string Shop_Name, string Name, string Family, string Address, string Comm_No, string Tel, string Mobile, string ProvinceID, string CityID, string Kol, string Moeen, string Tafsili1, string Tafsili2, string CodeMeli, string UserId)
	{
		InsertEditIntoShopKharidRequest insertEditIntoShopKharidRequest = new InsertEditIntoShopKharidRequest();
		insertEditIntoShopKharidRequest.Body = new InsertEditIntoShopKharidRequestBody();
		insertEditIntoShopKharidRequest.Body.Shop_Code = Shop_Code;
		insertEditIntoShopKharidRequest.Body.Shop_Name = Shop_Name;
		insertEditIntoShopKharidRequest.Body.Name = Name;
		insertEditIntoShopKharidRequest.Body.Family = Family;
		insertEditIntoShopKharidRequest.Body.Address = Address;
		insertEditIntoShopKharidRequest.Body.Comm_No = Comm_No;
		insertEditIntoShopKharidRequest.Body.Tel = Tel;
		insertEditIntoShopKharidRequest.Body.Mobile = Mobile;
		insertEditIntoShopKharidRequest.Body.ProvinceID = ProvinceID;
		insertEditIntoShopKharidRequest.Body.CityID = CityID;
		insertEditIntoShopKharidRequest.Body.Kol = Kol;
		insertEditIntoShopKharidRequest.Body.Moeen = Moeen;
		insertEditIntoShopKharidRequest.Body.Tafsili1 = Tafsili1;
		insertEditIntoShopKharidRequest.Body.Tafsili2 = Tafsili2;
		insertEditIntoShopKharidRequest.Body.CodeMeli = CodeMeli;
		insertEditIntoShopKharidRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).InsertEditIntoShopKharidAsync(insertEditIntoShopKharidRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromShopKharidResponse ServiceSoap.ReadFromShopKharid(ReadFromShopKharidRequest request)
	{
		return base.Channel.ReadFromShopKharid(request);
	}

	public string ReadFromShopKharid(string Shop_Code, string UserId)
	{
		ReadFromShopKharidRequest readFromShopKharidRequest = new ReadFromShopKharidRequest();
		readFromShopKharidRequest.Body = new ReadFromShopKharidRequestBody();
		readFromShopKharidRequest.Body.Shop_Code = Shop_Code;
		readFromShopKharidRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromShopKharid(readFromShopKharidRequest).Body.ReadFromShopKharidResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromShopKharidResponse> ServiceSoap.ReadFromShopKharidAsync(ReadFromShopKharidRequest request)
	{
		return base.Channel.ReadFromShopKharidAsync(request);
	}

	public Task<ReadFromShopKharidResponse> ReadFromShopKharidAsync(string Shop_Code, string UserId)
	{
		ReadFromShopKharidRequest readFromShopKharidRequest = new ReadFromShopKharidRequest();
		readFromShopKharidRequest.Body = new ReadFromShopKharidRequestBody();
		readFromShopKharidRequest.Body.Shop_Code = Shop_Code;
		readFromShopKharidRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromShopKharidAsync(readFromShopKharidRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	EditMaterialResponse ServiceSoap.EditMaterial(EditMaterialRequest request)
	{
		return base.Channel.EditMaterial(request);
	}

	public string EditMaterial(string Price, string Code, string Store, string UserId)
	{
		EditMaterialRequest editMaterialRequest = new EditMaterialRequest();
		editMaterialRequest.Body = new EditMaterialRequestBody();
		editMaterialRequest.Body.Price = Price;
		editMaterialRequest.Body.Code = Code;
		editMaterialRequest.Body.Store = Store;
		editMaterialRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).EditMaterial(editMaterialRequest).Body.EditMaterialResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<EditMaterialResponse> ServiceSoap.EditMaterialAsync(EditMaterialRequest request)
	{
		return base.Channel.EditMaterialAsync(request);
	}

	public Task<EditMaterialResponse> EditMaterialAsync(string Price, string Code, string Store, string UserId)
	{
		EditMaterialRequest editMaterialRequest = new EditMaterialRequest();
		editMaterialRequest.Body = new EditMaterialRequestBody();
		editMaterialRequest.Body.Price = Price;
		editMaterialRequest.Body.Code = Code;
		editMaterialRequest.Body.Store = Store;
		editMaterialRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).EditMaterialAsync(editMaterialRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromMaterialResponse ServiceSoap.ReadFromMaterial(ReadFromMaterialRequest request)
	{
		return base.Channel.ReadFromMaterial(request);
	}

	public string ReadFromMaterial(string KalaName, string Code, string Store, string UserId)
	{
		ReadFromMaterialRequest readFromMaterialRequest = new ReadFromMaterialRequest();
		readFromMaterialRequest.Body = new ReadFromMaterialRequestBody();
		readFromMaterialRequest.Body.KalaName = KalaName;
		readFromMaterialRequest.Body.Code = Code;
		readFromMaterialRequest.Body.Store = Store;
		readFromMaterialRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromMaterial(readFromMaterialRequest).Body.ReadFromMaterialResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromMaterialResponse> ServiceSoap.ReadFromMaterialAsync(ReadFromMaterialRequest request)
	{
		return base.Channel.ReadFromMaterialAsync(request);
	}

	public Task<ReadFromMaterialResponse> ReadFromMaterialAsync(string KalaName, string Code, string Store, string UserId)
	{
		ReadFromMaterialRequest readFromMaterialRequest = new ReadFromMaterialRequest();
		readFromMaterialRequest.Body = new ReadFromMaterialRequestBody();
		readFromMaterialRequest.Body.KalaName = KalaName;
		readFromMaterialRequest.Body.Code = Code;
		readFromMaterialRequest.Body.Store = Store;
		readFromMaterialRequest.Body.UserId = UserId;
		return ((ServiceSoap)this).ReadFromMaterialAsync(readFromMaterialRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromStoreResponse ServiceSoap.ReadFromStore(ReadFromStoreRequest request)
	{
		return base.Channel.ReadFromStore(request);
	}

	public string ReadFromStore()
	{
		ReadFromStoreRequest readFromStoreRequest = new ReadFromStoreRequest();
		readFromStoreRequest.Body = new ReadFromStoreRequestBody();
		return ((ServiceSoap)this).ReadFromStore(readFromStoreRequest).Body.ReadFromStoreResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromStoreResponse> ServiceSoap.ReadFromStoreAsync(ReadFromStoreRequest request)
	{
		return base.Channel.ReadFromStoreAsync(request);
	}

	public Task<ReadFromStoreResponse> ReadFromStoreAsync()
	{
		ReadFromStoreRequest readFromStoreRequest = new ReadFromStoreRequest();
		readFromStoreRequest.Body = new ReadFromStoreRequestBody();
		return ((ServiceSoap)this).ReadFromStoreAsync(readFromStoreRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadRemainFromAccountResponse ServiceSoap.ReadRemainFromAccount(ReadRemainFromAccountRequest request)
	{
		return base.Channel.ReadRemainFromAccount(request);
	}

	public string ReadRemainFromAccount(string Shop_Code, string Kol, string Moeen, string Tafsili1, string Tafsili2)
	{
		ReadRemainFromAccountRequest readRemainFromAccountRequest = new ReadRemainFromAccountRequest();
		readRemainFromAccountRequest.Body = new ReadRemainFromAccountRequestBody();
		readRemainFromAccountRequest.Body.Shop_Code = Shop_Code;
		readRemainFromAccountRequest.Body.Kol = Kol;
		readRemainFromAccountRequest.Body.Moeen = Moeen;
		readRemainFromAccountRequest.Body.Tafsili1 = Tafsili1;
		readRemainFromAccountRequest.Body.Tafsili2 = Tafsili2;
		return ((ServiceSoap)this).ReadRemainFromAccount(readRemainFromAccountRequest).Body.ReadRemainFromAccountResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadRemainFromAccountResponse> ServiceSoap.ReadRemainFromAccountAsync(ReadRemainFromAccountRequest request)
	{
		return base.Channel.ReadRemainFromAccountAsync(request);
	}

	public Task<ReadRemainFromAccountResponse> ReadRemainFromAccountAsync(string Shop_Code, string Kol, string Moeen, string Tafsili1, string Tafsili2)
	{
		ReadRemainFromAccountRequest readRemainFromAccountRequest = new ReadRemainFromAccountRequest();
		readRemainFromAccountRequest.Body = new ReadRemainFromAccountRequestBody();
		readRemainFromAccountRequest.Body.Shop_Code = Shop_Code;
		readRemainFromAccountRequest.Body.Kol = Kol;
		readRemainFromAccountRequest.Body.Moeen = Moeen;
		readRemainFromAccountRequest.Body.Tafsili1 = Tafsili1;
		readRemainFromAccountRequest.Body.Tafsili2 = Tafsili2;
		return ((ServiceSoap)this).ReadRemainFromAccountAsync(readRemainFromAccountRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadAmvalResponse ServiceSoap.ReadAmval(ReadAmvalRequest request)
	{
		return base.Channel.ReadAmval(request);
	}

	public string ReadAmval(string Tabagheh, string Univ, string Auxi, string Part, string Empno, string Name, string Code_Part, string Code_Vahed)
	{
		ReadAmvalRequest readAmvalRequest = new ReadAmvalRequest();
		readAmvalRequest.Body = new ReadAmvalRequestBody();
		readAmvalRequest.Body.Tabagheh = Tabagheh;
		readAmvalRequest.Body.Univ = Univ;
		readAmvalRequest.Body.Auxi = Auxi;
		readAmvalRequest.Body.Part = Part;
		readAmvalRequest.Body.Empno = Empno;
		readAmvalRequest.Body.Name = Name;
		readAmvalRequest.Body.Code_Part = Code_Part;
		readAmvalRequest.Body.Code_Vahed = Code_Vahed;
		return ((ServiceSoap)this).ReadAmval(readAmvalRequest).Body.ReadAmvalResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadAmvalResponse> ServiceSoap.ReadAmvalAsync(ReadAmvalRequest request)
	{
		return base.Channel.ReadAmvalAsync(request);
	}

	public Task<ReadAmvalResponse> ReadAmvalAsync(string Tabagheh, string Univ, string Auxi, string Part, string Empno, string Name, string Code_Part, string Code_Vahed)
	{
		ReadAmvalRequest readAmvalRequest = new ReadAmvalRequest();
		readAmvalRequest.Body = new ReadAmvalRequestBody();
		readAmvalRequest.Body.Tabagheh = Tabagheh;
		readAmvalRequest.Body.Univ = Univ;
		readAmvalRequest.Body.Auxi = Auxi;
		readAmvalRequest.Body.Part = Part;
		readAmvalRequest.Body.Empno = Empno;
		readAmvalRequest.Body.Name = Name;
		readAmvalRequest.Body.Code_Part = Code_Part;
		readAmvalRequest.Body.Code_Vahed = Code_Vahed;
		return ((ServiceSoap)this).ReadAmvalAsync(readAmvalRequest);
	}
}
