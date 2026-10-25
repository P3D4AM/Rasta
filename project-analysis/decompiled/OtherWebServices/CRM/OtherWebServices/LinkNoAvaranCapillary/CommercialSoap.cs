using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "LinkNoAvaranCapillary.CommercialSoap")]
public interface CommercialSoap
{
	[OperationContract(Action = "http://tempuri.org/ReadFromComany", ReplyAction = "*")]
	ReadFromComanyResponse ReadFromComany(ReadFromComanyRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromComany", ReplyAction = "*")]
	Task<ReadFromComanyResponse> ReadFromComanyAsync(ReadFromComanyRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromContry", ReplyAction = "*")]
	ReadFromContryResponse ReadFromContry(ReadFromContryRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromContry", ReplyAction = "*")]
	Task<ReadFromContryResponse> ReadFromContryAsync(ReadFromContryRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromProvince", ReplyAction = "*")]
	ReadFromProvinceResponse ReadFromProvince(ReadFromProvinceRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromProvince", ReplyAction = "*")]
	Task<ReadFromProvinceResponse> ReadFromProvinceAsync(ReadFromProvinceRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromCity", ReplyAction = "*")]
	ReadFromCityResponse ReadFromCity(ReadFromCityRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromCity", ReplyAction = "*")]
	Task<ReadFromCityResponse> ReadFromCityAsync(ReadFromCityRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromAction", ReplyAction = "*")]
	ReadFromActionResponse ReadFromAction(ReadFromActionRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromAction", ReplyAction = "*")]
	Task<ReadFromActionResponse> ReadFromActionAsync(ReadFromActionRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromCustomer", ReplyAction = "*")]
	ReadFromCustomerResponse ReadFromCustomer(ReadFromCustomerRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromCustomer", ReplyAction = "*")]
	Task<ReadFromCustomerResponse> ReadFromCustomerAsync(ReadFromCustomerRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromGorooh", ReplyAction = "*")]
	ReadFromGoroohResponse ReadFromGorooh(ReadFromGoroohRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromGorooh", ReplyAction = "*")]
	Task<ReadFromGoroohResponse> ReadFromGoroohAsync(ReadFromGoroohRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromCode", ReplyAction = "*")]
	ReadFromCodeResponse ReadFromCode(ReadFromCodeRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromCode", ReplyAction = "*")]
	Task<ReadFromCodeResponse> ReadFromCodeAsync(ReadFromCodeRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromUnit", ReplyAction = "*")]
	ReadFromUnitResponse ReadFromUnit(ReadFromUnitRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromUnit", ReplyAction = "*")]
	Task<ReadFromUnitResponse> ReadFromUnitAsync(ReadFromUnitRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromSalesmanGroup", ReplyAction = "*")]
	ReadFromSalesmanGroupResponse ReadFromSalesmanGroup(ReadFromSalesmanGroupRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromSalesmanGroup", ReplyAction = "*")]
	Task<ReadFromSalesmanGroupResponse> ReadFromSalesmanGroupAsync(ReadFromSalesmanGroupRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromSalesManKind", ReplyAction = "*")]
	ReadFromSalesManKindResponse ReadFromSalesManKind(ReadFromSalesManKindRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromSalesManKind", ReplyAction = "*")]
	Task<ReadFromSalesManKindResponse> ReadFromSalesManKindAsync(ReadFromSalesManKindRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromStore", ReplyAction = "*")]
	ReadFromStoreResponse ReadFromStore(ReadFromStoreRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromStore", ReplyAction = "*")]
	Task<ReadFromStoreResponse> ReadFromStoreAsync(ReadFromStoreRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromKindSale", ReplyAction = "*")]
	ReadFromKindSaleResponse ReadFromKindSale(ReadFromKindSaleRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromKindSale", ReplyAction = "*")]
	Task<ReadFromKindSaleResponse> ReadFromKindSaleAsync(ReadFromKindSaleRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromPishFactor", ReplyAction = "*")]
	ReadFromPishFactorResponse ReadFromPishFactor(ReadFromPishFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromPishFactor", ReplyAction = "*")]
	Task<ReadFromPishFactorResponse> ReadFromPishFactorAsync(ReadFromPishFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromFactor", ReplyAction = "*")]
	ReadFromFactorResponse ReadFromFactor(ReadFromFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/ReadFromFactor", ReplyAction = "*")]
	Task<ReadFromFactorResponse> ReadFromFactorAsync(ReadFromFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/InsertIntoCustomer", ReplyAction = "*")]
	InsertIntoCustomerResponse InsertIntoCustomer(InsertIntoCustomerRequest request);

	[OperationContract(Action = "http://tempuri.org/InsertIntoCustomer", ReplyAction = "*")]
	Task<InsertIntoCustomerResponse> InsertIntoCustomerAsync(InsertIntoCustomerRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_UpdateAmount123", ReplyAction = "*")]
	Idealsp_UpdateAmount123Response Idealsp_UpdateAmount123(Idealsp_UpdateAmount123Request request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_UpdateAmount123", ReplyAction = "*")]
	Task<Idealsp_UpdateAmount123Response> Idealsp_UpdateAmount123Async(Idealsp_UpdateAmount123Request request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertSalesMan", ReplyAction = "*")]
	Idealsp_InsertSalesManResponse Idealsp_InsertSalesMan(Idealsp_InsertSalesManRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertSalesMan", ReplyAction = "*")]
	Task<Idealsp_InsertSalesManResponse> Idealsp_InsertSalesManAsync(Idealsp_InsertSalesManRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertPishFactor", ReplyAction = "*")]
	Idealsp_InsertPishFactorResponse Idealsp_InsertPishFactor(Idealsp_InsertPishFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertPishFactor", ReplyAction = "*")]
	Task<Idealsp_InsertPishFactorResponse> Idealsp_InsertPishFactorAsync(Idealsp_InsertPishFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertPishFactorDetail", ReplyAction = "*")]
	Idealsp_InsertPishFactorDetailResponse Idealsp_InsertPishFactorDetail(Idealsp_InsertPishFactorDetailRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertPishFactorDetail", ReplyAction = "*")]
	Task<Idealsp_InsertPishFactorDetailResponse> Idealsp_InsertPishFactorDetailAsync(Idealsp_InsertPishFactorDetailRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertDaryaft", ReplyAction = "*")]
	Idealsp_InsertDaryaftResponse Idealsp_InsertDaryaft(Idealsp_InsertDaryaftRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertDaryaft", ReplyAction = "*")]
	Task<Idealsp_InsertDaryaftResponse> Idealsp_InsertDaryaftAsync(Idealsp_InsertDaryaftRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertDaryaftDetail", ReplyAction = "*")]
	Idealsp_InsertDaryaftDetailResponse Idealsp_InsertDaryaftDetail(Idealsp_InsertDaryaftDetailRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_InsertDaryaftDetail", ReplyAction = "*")]
	Task<Idealsp_InsertDaryaftDetailResponse> Idealsp_InsertDaryaftDetailAsync(Idealsp_InsertDaryaftDetailRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_Insertoutput", ReplyAction = "*")]
	Idealsp_InsertoutputResponse Idealsp_Insertoutput(Idealsp_InsertoutputRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_Insertoutput", ReplyAction = "*")]
	Task<Idealsp_InsertoutputResponse> Idealsp_InsertoutputAsync(Idealsp_InsertoutputRequest request);

	[OperationContract(Action = "http://tempuri.org/GetRouteList", ReplyAction = "*")]
	GetRouteListResponse GetRouteList(GetRouteListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetRouteList", ReplyAction = "*")]
	Task<GetRouteListResponse> GetRouteListAsync(GetRouteListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetZoneList", ReplyAction = "*")]
	GetZoneListResponse GetZoneList(GetZoneListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetZoneList", ReplyAction = "*")]
	Task<GetZoneListResponse> GetZoneListAsync(GetZoneListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetSalesmanList", ReplyAction = "*")]
	GetSalesmanListResponse GetSalesmanList(GetSalesmanListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetSalesmanList", ReplyAction = "*")]
	Task<GetSalesmanListResponse> GetSalesmanListAsync(GetSalesmanListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetPartList", ReplyAction = "*")]
	GetPartListResponse GetPartList(GetPartListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetPartList", ReplyAction = "*")]
	Task<GetPartListResponse> GetPartListAsync(GetPartListRequest request);

	[OperationContract(Action = "http://tempuri.org/GetQuanKala", ReplyAction = "*")]
	GetQuanKalaResponse GetQuanKala(GetQuanKalaRequest request);

	[OperationContract(Action = "http://tempuri.org/GetQuanKala", ReplyAction = "*")]
	Task<GetQuanKalaResponse> GetQuanKalaAsync(GetQuanKalaRequest request);

	[OperationContract(Action = "http://tempuri.org/ViewOutput", ReplyAction = "*")]
	ViewOutputResponse ViewOutput(ViewOutputRequest request);

	[OperationContract(Action = "http://tempuri.org/ViewOutput", ReplyAction = "*")]
	Task<ViewOutputResponse> ViewOutputAsync(ViewOutputRequest request);

	[OperationContract(Action = "http://tempuri.org/GetDaryaft", ReplyAction = "*")]
	GetDaryaftResponse GetDaryaft(GetDaryaftRequest request);

	[OperationContract(Action = "http://tempuri.org/GetDaryaft", ReplyAction = "*")]
	Task<GetDaryaftResponse> GetDaryaftAsync(GetDaryaftRequest request);

	[OperationContract(Action = "http://tempuri.org/GetLastCodeCustomer", ReplyAction = "*")]
	GetLastCodeCustomerResponse GetLastCodeCustomer(GetLastCodeCustomerRequest request);

	[OperationContract(Action = "http://tempuri.org/GetLastCodeCustomer", ReplyAction = "*")]
	Task<GetLastCodeCustomerResponse> GetLastCodeCustomerAsync(GetLastCodeCustomerRequest request);

	[OperationContract(Action = "http://tempuri.org/GetLastidPishFactor", ReplyAction = "*")]
	GetLastidPishFactorResponse GetLastidPishFactor(GetLastidPishFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/GetLastidPishFactor", ReplyAction = "*")]
	Task<GetLastidPishFactorResponse> GetLastidPishFactorAsync(GetLastidPishFactorRequest request);

	[OperationContract(Action = "http://tempuri.org/GetLastDocNoOutPut", ReplyAction = "*")]
	GetLastDocNoOutPutResponse GetLastDocNoOutPut(GetLastDocNoOutPutRequest request);

	[OperationContract(Action = "http://tempuri.org/GetLastDocNoOutPut", ReplyAction = "*")]
	Task<GetLastDocNoOutPutResponse> GetLastDocNoOutPutAsync(GetLastDocNoOutPutRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_LastResidno", ReplyAction = "*")]
	Idealsp_LastResidnoResponse Idealsp_LastResidno(Idealsp_LastResidnoRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_LastResidno", ReplyAction = "*")]
	Task<Idealsp_LastResidnoResponse> Idealsp_LastResidnoAsync(Idealsp_LastResidnoRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_MandeHesab", ReplyAction = "*")]
	Idealsp_MandeHesabResponse Idealsp_MandeHesab(Idealsp_MandeHesabRequest request);

	[OperationContract(Action = "http://tempuri.org/Idealsp_MandeHesab", ReplyAction = "*")]
	Task<Idealsp_MandeHesabResponse> Idealsp_MandeHesabAsync(Idealsp_MandeHesabRequest request);
}
