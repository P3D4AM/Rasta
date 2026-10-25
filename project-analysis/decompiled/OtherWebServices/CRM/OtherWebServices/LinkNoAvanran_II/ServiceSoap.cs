using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "LinkNoAvanran_II.ServiceSoap")]
public interface ServiceSoap
{
	[OperationContract(Action = "http://tempuri.org/Input", ReplyAction = "*")]
	InputResponse Input(InputRequest request);

	[OperationContract(Action = "http://tempuri.org/Input", ReplyAction = "*")]
	Task<InputResponse> InputAsync(InputRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromInput", ReplyAction = "*")]
	ReadFromInputResponse ReadFromInput(ReadFromInputRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromInput", ReplyAction = "*")]
	Task<ReadFromInputResponse> ReadFromInputAsync(ReadFromInputRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromInputDateRange", ReplyAction = "*")]
	ReadFromInputDateRangeResponse ReadFromInputDateRange(ReadFromInputDateRangeRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromInputDateRange", ReplyAction = "*")]
	Task<ReadFromInputDateRangeResponse> ReadFromInputDateRangeAsync(ReadFromInputDateRangeRequest request);

	[OperationContract(Action = "http://tempuri.org/Output", ReplyAction = "*")]
	OutputResponse Output(OutputRequest request);

	[OperationContract(Action = "http://tempuri.org/Output", ReplyAction = "*")]
	Task<OutputResponse> OutputAsync(OutputRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromOutput", ReplyAction = "*")]
	ReadFromOutputResponse ReadFromOutput(ReadFromOutputRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromOutput", ReplyAction = "*")]
	Task<ReadFromOutputResponse> ReadFromOutputAsync(ReadFromOutputRequest request);

	[OperationContract(Action = "http://tempuri.org/InsertIntoPish_Factor", ReplyAction = "*")]
	InsertIntoPish_FactorResponse InsertIntoPish_Factor(InsertIntoPish_FactorRequest request);

	[OperationContract(Action = "http://tempuri.org/InsertIntoPish_Factor", ReplyAction = "*")]
	Task<InsertIntoPish_FactorResponse> InsertIntoPish_FactorAsync(InsertIntoPish_FactorRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromPish_Factor", ReplyAction = "*")]
	ReadFromPish_FactorResponse ReadFromPish_Factor(ReadFromPish_FactorRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromPish_Factor", ReplyAction = "*")]
	Task<ReadFromPish_FactorResponse> ReadFromPish_FactorAsync(ReadFromPish_FactorRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromBazaryaban", ReplyAction = "*")]
	ReadFromBazaryabanResponse ReadFromBazaryaban(ReadFromBazaryabanRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromBazaryaban", ReplyAction = "*")]
	Task<ReadFromBazaryabanResponse> ReadFromBazaryabanAsync(ReadFromBazaryabanRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromAvalDoreh", ReplyAction = "*")]
	ReadFromAvalDorehResponse ReadFromAvalDoreh(ReadFromAvalDorehRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromAvalDoreh", ReplyAction = "*")]
	Task<ReadFromAvalDorehResponse> ReadFromAvalDorehAsync(ReadFromAvalDorehRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromPish_FactorDateRange", ReplyAction = "*")]
	ReadFromPish_FactorDateRangeResponse ReadFromPish_FactorDateRange(ReadFromPish_FactorDateRangeRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromPish_FactorDateRange", ReplyAction = "*")]
	Task<ReadFromPish_FactorDateRangeResponse> ReadFromPish_FactorDateRangeAsync(ReadFromPish_FactorDateRangeRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromRequestKala", ReplyAction = "*")]
	ReadFromRequestKalaResponse ReadFromRequestKala(ReadFromRequestKalaRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromRequestKala", ReplyAction = "*")]
	Task<ReadFromRequestKalaResponse> ReadFromRequestKalaAsync(ReadFromRequestKalaRequest request);

	[OperationContract(Action = "http://tempuri.org/RequestKala", ReplyAction = "*")]
	RequestKalaResponse RequestKala(RequestKalaRequest request);

	[OperationContract(Action = "http://tempuri.org/RequestKala", ReplyAction = "*")]
	Task<RequestKalaResponse> RequestKalaAsync(RequestKalaRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromRequest", ReplyAction = "*")]
	ReadFromRequestResponse ReadFromRequest(ReadFromRequestRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromRequest", ReplyAction = "*")]
	Task<ReadFromRequestResponse> ReadFromRequestAsync(ReadFromRequestRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadfromPayPast", ReplyAction = "*")]
	ReadfromPayPastResponse ReadfromPayPast(ReadfromPayPastRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadfromPayPast", ReplyAction = "*")]
	Task<ReadfromPayPastResponse> ReadfromPayPastAsync(ReadfromPayPastRequest request);

	[OperationContract(Action = "http://tempuri.org/HistoryOfRequest", ReplyAction = "*")]
	HistoryOfRequestResponse HistoryOfRequest(HistoryOfRequestRequest request);

	[OperationContract(Action = "http://tempuri.org/HistoryOfRequest", ReplyAction = "*")]
	Task<HistoryOfRequestResponse> HistoryOfRequestAsync(HistoryOfRequestRequest request);

	[OperationContract(Action = "http://tempuri.org/Request", ReplyAction = "*")]
	RequestResponse Request(RequestRequest request);

	[OperationContract(Action = "http://tempuri.org/Request", ReplyAction = "*")]
	Task<RequestResponse> RequestAsync(RequestRequest request);

	[OperationContract(Action = "http://tempuri.org/InsertEditIntoShopKharid", ReplyAction = "*")]
	InsertEditIntoShopKharidResponse InsertEditIntoShopKharid(InsertEditIntoShopKharidRequest request);

	[OperationContract(Action = "http://tempuri.org/InsertEditIntoShopKharid", ReplyAction = "*")]
	Task<InsertEditIntoShopKharidResponse> InsertEditIntoShopKharidAsync(InsertEditIntoShopKharidRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromShopKharid", ReplyAction = "*")]
	ReadFromShopKharidResponse ReadFromShopKharid(ReadFromShopKharidRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromShopKharid", ReplyAction = "*")]
	Task<ReadFromShopKharidResponse> ReadFromShopKharidAsync(ReadFromShopKharidRequest request);

	[OperationContract(Action = "http://tempuri.org/EditMaterial", ReplyAction = "*")]
	EditMaterialResponse EditMaterial(EditMaterialRequest request);

	[OperationContract(Action = "http://tempuri.org/EditMaterial", ReplyAction = "*")]
	Task<EditMaterialResponse> EditMaterialAsync(EditMaterialRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromMaterial", ReplyAction = "*")]
	ReadFromMaterialResponse ReadFromMaterial(ReadFromMaterialRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromMaterial", ReplyAction = "*")]
	Task<ReadFromMaterialResponse> ReadFromMaterialAsync(ReadFromMaterialRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromStore", ReplyAction = "*")]
	ReadFromStoreResponse ReadFromStore(ReadFromStoreRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromStore", ReplyAction = "*")]
	Task<ReadFromStoreResponse> ReadFromStoreAsync(ReadFromStoreRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadRemainFromAccount", ReplyAction = "*")]
	ReadRemainFromAccountResponse ReadRemainFromAccount(ReadRemainFromAccountRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadRemainFromAccount", ReplyAction = "*")]
	Task<ReadRemainFromAccountResponse> ReadRemainFromAccountAsync(ReadRemainFromAccountRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadAmval", ReplyAction = "*")]
	ReadAmvalResponse ReadAmval(ReadAmvalRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadAmval", ReplyAction = "*")]
	Task<ReadAmvalResponse> ReadAmvalAsync(ReadAmvalRequest request);
}
