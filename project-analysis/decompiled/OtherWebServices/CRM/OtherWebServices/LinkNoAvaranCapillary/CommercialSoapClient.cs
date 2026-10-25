using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class CommercialSoapClient : ClientBase<CommercialSoap>, CommercialSoap
{
	public CommercialSoapClient()
	{
	}

	public CommercialSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public CommercialSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CommercialSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CommercialSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromComanyResponse CommercialSoap.ReadFromComany(ReadFromComanyRequest request)
	{
		return base.Channel.ReadFromComany(request);
	}

	public string ReadFromComany(string Code, string NameCmp, string UserId)
	{
		ReadFromComanyRequest readFromComanyRequest = new ReadFromComanyRequest();
		readFromComanyRequest.Body = new ReadFromComanyRequestBody();
		readFromComanyRequest.Body.Code = Code;
		readFromComanyRequest.Body.NameCmp = NameCmp;
		readFromComanyRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromComany(readFromComanyRequest).Body.ReadFromComanyResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromComanyResponse> CommercialSoap.ReadFromComanyAsync(ReadFromComanyRequest request)
	{
		return base.Channel.ReadFromComanyAsync(request);
	}

	public Task<ReadFromComanyResponse> ReadFromComanyAsync(string Code, string NameCmp, string UserId)
	{
		ReadFromComanyRequest readFromComanyRequest = new ReadFromComanyRequest();
		readFromComanyRequest.Body = new ReadFromComanyRequestBody();
		readFromComanyRequest.Body.Code = Code;
		readFromComanyRequest.Body.NameCmp = NameCmp;
		readFromComanyRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromComanyAsync(readFromComanyRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromContryResponse CommercialSoap.ReadFromContry(ReadFromContryRequest request)
	{
		return base.Channel.ReadFromContry(request);
	}

	public string ReadFromContry(string Code, string UserId)
	{
		ReadFromContryRequest readFromContryRequest = new ReadFromContryRequest();
		readFromContryRequest.Body = new ReadFromContryRequestBody();
		readFromContryRequest.Body.Code = Code;
		readFromContryRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromContry(readFromContryRequest).Body.ReadFromContryResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromContryResponse> CommercialSoap.ReadFromContryAsync(ReadFromContryRequest request)
	{
		return base.Channel.ReadFromContryAsync(request);
	}

	public Task<ReadFromContryResponse> ReadFromContryAsync(string Code, string UserId)
	{
		ReadFromContryRequest readFromContryRequest = new ReadFromContryRequest();
		readFromContryRequest.Body = new ReadFromContryRequestBody();
		readFromContryRequest.Body.Code = Code;
		readFromContryRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromContryAsync(readFromContryRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromProvinceResponse CommercialSoap.ReadFromProvince(ReadFromProvinceRequest request)
	{
		return base.Channel.ReadFromProvince(request);
	}

	public string ReadFromProvince(string Code, string UserId)
	{
		ReadFromProvinceRequest readFromProvinceRequest = new ReadFromProvinceRequest();
		readFromProvinceRequest.Body = new ReadFromProvinceRequestBody();
		readFromProvinceRequest.Body.Code = Code;
		readFromProvinceRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromProvince(readFromProvinceRequest).Body.ReadFromProvinceResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromProvinceResponse> CommercialSoap.ReadFromProvinceAsync(ReadFromProvinceRequest request)
	{
		return base.Channel.ReadFromProvinceAsync(request);
	}

	public Task<ReadFromProvinceResponse> ReadFromProvinceAsync(string Code, string UserId)
	{
		ReadFromProvinceRequest readFromProvinceRequest = new ReadFromProvinceRequest();
		readFromProvinceRequest.Body = new ReadFromProvinceRequestBody();
		readFromProvinceRequest.Body.Code = Code;
		readFromProvinceRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromProvinceAsync(readFromProvinceRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromCityResponse CommercialSoap.ReadFromCity(ReadFromCityRequest request)
	{
		return base.Channel.ReadFromCity(request);
	}

	public string ReadFromCity(string Code, string UserId, string IdProvince)
	{
		ReadFromCityRequest readFromCityRequest = new ReadFromCityRequest();
		readFromCityRequest.Body = new ReadFromCityRequestBody();
		readFromCityRequest.Body.Code = Code;
		readFromCityRequest.Body.UserId = UserId;
		readFromCityRequest.Body.IdProvince = IdProvince;
		return ((CommercialSoap)this).ReadFromCity(readFromCityRequest).Body.ReadFromCityResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromCityResponse> CommercialSoap.ReadFromCityAsync(ReadFromCityRequest request)
	{
		return base.Channel.ReadFromCityAsync(request);
	}

	public Task<ReadFromCityResponse> ReadFromCityAsync(string Code, string UserId, string IdProvince)
	{
		ReadFromCityRequest readFromCityRequest = new ReadFromCityRequest();
		readFromCityRequest.Body = new ReadFromCityRequestBody();
		readFromCityRequest.Body.Code = Code;
		readFromCityRequest.Body.UserId = UserId;
		readFromCityRequest.Body.IdProvince = IdProvince;
		return ((CommercialSoap)this).ReadFromCityAsync(readFromCityRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromActionResponse CommercialSoap.ReadFromAction(ReadFromActionRequest request)
	{
		return base.Channel.ReadFromAction(request);
	}

	public string ReadFromAction(string Code, string UserId)
	{
		ReadFromActionRequest readFromActionRequest = new ReadFromActionRequest();
		readFromActionRequest.Body = new ReadFromActionRequestBody();
		readFromActionRequest.Body.Code = Code;
		readFromActionRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromAction(readFromActionRequest).Body.ReadFromActionResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromActionResponse> CommercialSoap.ReadFromActionAsync(ReadFromActionRequest request)
	{
		return base.Channel.ReadFromActionAsync(request);
	}

	public Task<ReadFromActionResponse> ReadFromActionAsync(string Code, string UserId)
	{
		ReadFromActionRequest readFromActionRequest = new ReadFromActionRequest();
		readFromActionRequest.Body = new ReadFromActionRequestBody();
		readFromActionRequest.Body.Code = Code;
		readFromActionRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromActionAsync(readFromActionRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromCustomerResponse CommercialSoap.ReadFromCustomer(ReadFromCustomerRequest request)
	{
		return base.Channel.ReadFromCustomer(request);
	}

	public string ReadFromCustomer(string Code, string UserId, string Name, string CodeMeli, string SabtDate, string SabtDate2)
	{
		ReadFromCustomerRequest readFromCustomerRequest = new ReadFromCustomerRequest();
		readFromCustomerRequest.Body = new ReadFromCustomerRequestBody();
		readFromCustomerRequest.Body.Code = Code;
		readFromCustomerRequest.Body.UserId = UserId;
		readFromCustomerRequest.Body.Name = Name;
		readFromCustomerRequest.Body.CodeMeli = CodeMeli;
		readFromCustomerRequest.Body.SabtDate = SabtDate;
		readFromCustomerRequest.Body.SabtDate2 = SabtDate2;
		return ((CommercialSoap)this).ReadFromCustomer(readFromCustomerRequest).Body.ReadFromCustomerResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromCustomerResponse> CommercialSoap.ReadFromCustomerAsync(ReadFromCustomerRequest request)
	{
		return base.Channel.ReadFromCustomerAsync(request);
	}

	public Task<ReadFromCustomerResponse> ReadFromCustomerAsync(string Code, string UserId, string Name, string CodeMeli, string SabtDate, string SabtDate2)
	{
		ReadFromCustomerRequest readFromCustomerRequest = new ReadFromCustomerRequest();
		readFromCustomerRequest.Body = new ReadFromCustomerRequestBody();
		readFromCustomerRequest.Body.Code = Code;
		readFromCustomerRequest.Body.UserId = UserId;
		readFromCustomerRequest.Body.Name = Name;
		readFromCustomerRequest.Body.CodeMeli = CodeMeli;
		readFromCustomerRequest.Body.SabtDate = SabtDate;
		readFromCustomerRequest.Body.SabtDate2 = SabtDate2;
		return ((CommercialSoap)this).ReadFromCustomerAsync(readFromCustomerRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromGoroohResponse CommercialSoap.ReadFromGorooh(ReadFromGoroohRequest request)
	{
		return base.Channel.ReadFromGorooh(request);
	}

	public string ReadFromGorooh(string UserId)
	{
		ReadFromGoroohRequest readFromGoroohRequest = new ReadFromGoroohRequest();
		readFromGoroohRequest.Body = new ReadFromGoroohRequestBody();
		readFromGoroohRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromGorooh(readFromGoroohRequest).Body.ReadFromGoroohResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromGoroohResponse> CommercialSoap.ReadFromGoroohAsync(ReadFromGoroohRequest request)
	{
		return base.Channel.ReadFromGoroohAsync(request);
	}

	public Task<ReadFromGoroohResponse> ReadFromGoroohAsync(string UserId)
	{
		ReadFromGoroohRequest readFromGoroohRequest = new ReadFromGoroohRequest();
		readFromGoroohRequest.Body = new ReadFromGoroohRequestBody();
		readFromGoroohRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).ReadFromGoroohAsync(readFromGoroohRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromCodeResponse CommercialSoap.ReadFromCode(ReadFromCodeRequest request)
	{
		return base.Channel.ReadFromCode(request);
	}

	public string ReadFromCode(string UserId, string KindKala, string UDate, string UDate2)
	{
		ReadFromCodeRequest readFromCodeRequest = new ReadFromCodeRequest();
		readFromCodeRequest.Body = new ReadFromCodeRequestBody();
		readFromCodeRequest.Body.UserId = UserId;
		readFromCodeRequest.Body.KindKala = KindKala;
		readFromCodeRequest.Body.UDate = UDate;
		readFromCodeRequest.Body.UDate2 = UDate2;
		return ((CommercialSoap)this).ReadFromCode(readFromCodeRequest).Body.ReadFromCodeResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromCodeResponse> CommercialSoap.ReadFromCodeAsync(ReadFromCodeRequest request)
	{
		return base.Channel.ReadFromCodeAsync(request);
	}

	public Task<ReadFromCodeResponse> ReadFromCodeAsync(string UserId, string KindKala, string UDate, string UDate2)
	{
		ReadFromCodeRequest readFromCodeRequest = new ReadFromCodeRequest();
		readFromCodeRequest.Body = new ReadFromCodeRequestBody();
		readFromCodeRequest.Body.UserId = UserId;
		readFromCodeRequest.Body.KindKala = KindKala;
		readFromCodeRequest.Body.UDate = UDate;
		readFromCodeRequest.Body.UDate2 = UDate2;
		return ((CommercialSoap)this).ReadFromCodeAsync(readFromCodeRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromUnitResponse CommercialSoap.ReadFromUnit(ReadFromUnitRequest request)
	{
		return base.Channel.ReadFromUnit(request);
	}

	public string ReadFromUnit()
	{
		ReadFromUnitRequest readFromUnitRequest = new ReadFromUnitRequest();
		readFromUnitRequest.Body = new ReadFromUnitRequestBody();
		return ((CommercialSoap)this).ReadFromUnit(readFromUnitRequest).Body.ReadFromUnitResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromUnitResponse> CommercialSoap.ReadFromUnitAsync(ReadFromUnitRequest request)
	{
		return base.Channel.ReadFromUnitAsync(request);
	}

	public Task<ReadFromUnitResponse> ReadFromUnitAsync()
	{
		ReadFromUnitRequest readFromUnitRequest = new ReadFromUnitRequest();
		readFromUnitRequest.Body = new ReadFromUnitRequestBody();
		return ((CommercialSoap)this).ReadFromUnitAsync(readFromUnitRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromSalesmanGroupResponse CommercialSoap.ReadFromSalesmanGroup(ReadFromSalesmanGroupRequest request)
	{
		return base.Channel.ReadFromSalesmanGroup(request);
	}

	public string ReadFromSalesmanGroup()
	{
		ReadFromSalesmanGroupRequest readFromSalesmanGroupRequest = new ReadFromSalesmanGroupRequest();
		readFromSalesmanGroupRequest.Body = new ReadFromSalesmanGroupRequestBody();
		return ((CommercialSoap)this).ReadFromSalesmanGroup(readFromSalesmanGroupRequest).Body.ReadFromSalesmanGroupResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromSalesmanGroupResponse> CommercialSoap.ReadFromSalesmanGroupAsync(ReadFromSalesmanGroupRequest request)
	{
		return base.Channel.ReadFromSalesmanGroupAsync(request);
	}

	public Task<ReadFromSalesmanGroupResponse> ReadFromSalesmanGroupAsync()
	{
		ReadFromSalesmanGroupRequest readFromSalesmanGroupRequest = new ReadFromSalesmanGroupRequest();
		readFromSalesmanGroupRequest.Body = new ReadFromSalesmanGroupRequestBody();
		return ((CommercialSoap)this).ReadFromSalesmanGroupAsync(readFromSalesmanGroupRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromSalesManKindResponse CommercialSoap.ReadFromSalesManKind(ReadFromSalesManKindRequest request)
	{
		return base.Channel.ReadFromSalesManKind(request);
	}

	public string ReadFromSalesManKind()
	{
		ReadFromSalesManKindRequest readFromSalesManKindRequest = new ReadFromSalesManKindRequest();
		readFromSalesManKindRequest.Body = new ReadFromSalesManKindRequestBody();
		return ((CommercialSoap)this).ReadFromSalesManKind(readFromSalesManKindRequest).Body.ReadFromSalesManKindResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromSalesManKindResponse> CommercialSoap.ReadFromSalesManKindAsync(ReadFromSalesManKindRequest request)
	{
		return base.Channel.ReadFromSalesManKindAsync(request);
	}

	public Task<ReadFromSalesManKindResponse> ReadFromSalesManKindAsync()
	{
		ReadFromSalesManKindRequest readFromSalesManKindRequest = new ReadFromSalesManKindRequest();
		readFromSalesManKindRequest.Body = new ReadFromSalesManKindRequestBody();
		return ((CommercialSoap)this).ReadFromSalesManKindAsync(readFromSalesManKindRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromStoreResponse CommercialSoap.ReadFromStore(ReadFromStoreRequest request)
	{
		return base.Channel.ReadFromStore(request);
	}

	public string ReadFromStore()
	{
		ReadFromStoreRequest readFromStoreRequest = new ReadFromStoreRequest();
		readFromStoreRequest.Body = new ReadFromStoreRequestBody();
		return ((CommercialSoap)this).ReadFromStore(readFromStoreRequest).Body.ReadFromStoreResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromStoreResponse> CommercialSoap.ReadFromStoreAsync(ReadFromStoreRequest request)
	{
		return base.Channel.ReadFromStoreAsync(request);
	}

	public Task<ReadFromStoreResponse> ReadFromStoreAsync()
	{
		ReadFromStoreRequest readFromStoreRequest = new ReadFromStoreRequest();
		readFromStoreRequest.Body = new ReadFromStoreRequestBody();
		return ((CommercialSoap)this).ReadFromStoreAsync(readFromStoreRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromKindSaleResponse CommercialSoap.ReadFromKindSale(ReadFromKindSaleRequest request)
	{
		return base.Channel.ReadFromKindSale(request);
	}

	public string ReadFromKindSale()
	{
		ReadFromKindSaleRequest readFromKindSaleRequest = new ReadFromKindSaleRequest();
		readFromKindSaleRequest.Body = new ReadFromKindSaleRequestBody();
		return ((CommercialSoap)this).ReadFromKindSale(readFromKindSaleRequest).Body.ReadFromKindSaleResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromKindSaleResponse> CommercialSoap.ReadFromKindSaleAsync(ReadFromKindSaleRequest request)
	{
		return base.Channel.ReadFromKindSaleAsync(request);
	}

	public Task<ReadFromKindSaleResponse> ReadFromKindSaleAsync()
	{
		ReadFromKindSaleRequest readFromKindSaleRequest = new ReadFromKindSaleRequest();
		readFromKindSaleRequest.Body = new ReadFromKindSaleRequestBody();
		return ((CommercialSoap)this).ReadFromKindSaleAsync(readFromKindSaleRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromPishFactorResponse CommercialSoap.ReadFromPishFactor(ReadFromPishFactorRequest request)
	{
		return base.Channel.ReadFromPishFactor(request);
	}

	public string ReadFromPishFactor(string UserId, string FromDate, string ToDate, string PishFactorNo)
	{
		ReadFromPishFactorRequest readFromPishFactorRequest = new ReadFromPishFactorRequest();
		readFromPishFactorRequest.Body = new ReadFromPishFactorRequestBody();
		readFromPishFactorRequest.Body.UserId = UserId;
		readFromPishFactorRequest.Body.FromDate = FromDate;
		readFromPishFactorRequest.Body.ToDate = ToDate;
		readFromPishFactorRequest.Body.PishFactorNo = PishFactorNo;
		return ((CommercialSoap)this).ReadFromPishFactor(readFromPishFactorRequest).Body.ReadFromPishFactorResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromPishFactorResponse> CommercialSoap.ReadFromPishFactorAsync(ReadFromPishFactorRequest request)
	{
		return base.Channel.ReadFromPishFactorAsync(request);
	}

	public Task<ReadFromPishFactorResponse> ReadFromPishFactorAsync(string UserId, string FromDate, string ToDate, string PishFactorNo)
	{
		ReadFromPishFactorRequest readFromPishFactorRequest = new ReadFromPishFactorRequest();
		readFromPishFactorRequest.Body = new ReadFromPishFactorRequestBody();
		readFromPishFactorRequest.Body.UserId = UserId;
		readFromPishFactorRequest.Body.FromDate = FromDate;
		readFromPishFactorRequest.Body.ToDate = ToDate;
		readFromPishFactorRequest.Body.PishFactorNo = PishFactorNo;
		return ((CommercialSoap)this).ReadFromPishFactorAsync(readFromPishFactorRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReadFromFactorResponse CommercialSoap.ReadFromFactor(ReadFromFactorRequest request)
	{
		return base.Channel.ReadFromFactor(request);
	}

	public string ReadFromFactor(string UserId, string FromDate, string ToDate, string FactorNo)
	{
		ReadFromFactorRequest readFromFactorRequest = new ReadFromFactorRequest();
		readFromFactorRequest.Body = new ReadFromFactorRequestBody();
		readFromFactorRequest.Body.UserId = UserId;
		readFromFactorRequest.Body.FromDate = FromDate;
		readFromFactorRequest.Body.ToDate = ToDate;
		readFromFactorRequest.Body.FactorNo = FactorNo;
		return ((CommercialSoap)this).ReadFromFactor(readFromFactorRequest).Body.ReadFromFactorResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReadFromFactorResponse> CommercialSoap.ReadFromFactorAsync(ReadFromFactorRequest request)
	{
		return base.Channel.ReadFromFactorAsync(request);
	}

	public Task<ReadFromFactorResponse> ReadFromFactorAsync(string UserId, string FromDate, string ToDate, string FactorNo)
	{
		ReadFromFactorRequest readFromFactorRequest = new ReadFromFactorRequest();
		readFromFactorRequest.Body = new ReadFromFactorRequestBody();
		readFromFactorRequest.Body.UserId = UserId;
		readFromFactorRequest.Body.FromDate = FromDate;
		readFromFactorRequest.Body.ToDate = ToDate;
		readFromFactorRequest.Body.FactorNo = FactorNo;
		return ((CommercialSoap)this).ReadFromFactorAsync(readFromFactorRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	InsertIntoCustomerResponse CommercialSoap.InsertIntoCustomer(InsertIntoCustomerRequest request)
	{
		return base.Channel.InsertIntoCustomer(request);
	}

	public string InsertIntoCustomer(string Code, string Name, string KindCustomer, string FirstName, string LastName, string CodeMeli, string Sh_Sabt, string Code_E, string CodePosti, string AddressDaftar, string AddressTahvil, string UserId, string IdCountry, string IdProvince, string IdCity, string Zone, string Tel, string Fax, string WebSayt, string Email, string Mobile, string KolBed, string MoeenBed, string Taf1Bed, string Taf2Bed, string KindAct, string PeriodActiveYear, string PeriodActiveMonth, string KindBuyer, string DateSabt, string MandeHesab, string MandeCheck, string UserName, string uDate, string uTime, string TejariName, string PishCode, string darsadtakhfif, string KindFactor, string personCode, string ShenaseMeli, string ModatPardakht, string EtebarMazad, string Password, string MEnterToCmp, string IdZone, string IdRoute, string Longitude, string Latitude, string TypeCustomer, string IdCompany, string DescCustomer)
	{
		InsertIntoCustomerRequest insertIntoCustomerRequest = new InsertIntoCustomerRequest();
		insertIntoCustomerRequest.Body = new InsertIntoCustomerRequestBody();
		insertIntoCustomerRequest.Body.Code = Code;
		insertIntoCustomerRequest.Body.Name = Name;
		insertIntoCustomerRequest.Body.KindCustomer = KindCustomer;
		insertIntoCustomerRequest.Body.FirstName = FirstName;
		insertIntoCustomerRequest.Body.LastName = LastName;
		insertIntoCustomerRequest.Body.CodeMeli = CodeMeli;
		insertIntoCustomerRequest.Body.Sh_Sabt = Sh_Sabt;
		insertIntoCustomerRequest.Body.Code_E = Code_E;
		insertIntoCustomerRequest.Body.CodePosti = CodePosti;
		insertIntoCustomerRequest.Body.AddressDaftar = AddressDaftar;
		insertIntoCustomerRequest.Body.AddressTahvil = AddressTahvil;
		insertIntoCustomerRequest.Body.UserId = UserId;
		insertIntoCustomerRequest.Body.IdCountry = IdCountry;
		insertIntoCustomerRequest.Body.IdProvince = IdProvince;
		insertIntoCustomerRequest.Body.IdCity = IdCity;
		insertIntoCustomerRequest.Body.Zone = Zone;
		insertIntoCustomerRequest.Body.Tel = Tel;
		insertIntoCustomerRequest.Body.Fax = Fax;
		insertIntoCustomerRequest.Body.WebSayt = WebSayt;
		insertIntoCustomerRequest.Body.Email = Email;
		insertIntoCustomerRequest.Body.Mobile = Mobile;
		insertIntoCustomerRequest.Body.KolBed = KolBed;
		insertIntoCustomerRequest.Body.MoeenBed = MoeenBed;
		insertIntoCustomerRequest.Body.Taf1Bed = Taf1Bed;
		insertIntoCustomerRequest.Body.Taf2Bed = Taf2Bed;
		insertIntoCustomerRequest.Body.KindAct = KindAct;
		insertIntoCustomerRequest.Body.PeriodActiveYear = PeriodActiveYear;
		insertIntoCustomerRequest.Body.PeriodActiveMonth = PeriodActiveMonth;
		insertIntoCustomerRequest.Body.KindBuyer = KindBuyer;
		insertIntoCustomerRequest.Body.DateSabt = DateSabt;
		insertIntoCustomerRequest.Body.MandeHesab = MandeHesab;
		insertIntoCustomerRequest.Body.MandeCheck = MandeCheck;
		insertIntoCustomerRequest.Body.UserName = UserName;
		insertIntoCustomerRequest.Body.uDate = uDate;
		insertIntoCustomerRequest.Body.uTime = uTime;
		insertIntoCustomerRequest.Body.TejariName = TejariName;
		insertIntoCustomerRequest.Body.PishCode = PishCode;
		insertIntoCustomerRequest.Body.darsadtakhfif = darsadtakhfif;
		insertIntoCustomerRequest.Body.KindFactor = KindFactor;
		insertIntoCustomerRequest.Body.personCode = personCode;
		insertIntoCustomerRequest.Body.ShenaseMeli = ShenaseMeli;
		insertIntoCustomerRequest.Body.ModatPardakht = ModatPardakht;
		insertIntoCustomerRequest.Body.EtebarMazad = EtebarMazad;
		insertIntoCustomerRequest.Body.Password = Password;
		insertIntoCustomerRequest.Body.MEnterToCmp = MEnterToCmp;
		insertIntoCustomerRequest.Body.IdZone = IdZone;
		insertIntoCustomerRequest.Body.IdRoute = IdRoute;
		insertIntoCustomerRequest.Body.Longitude = Longitude;
		insertIntoCustomerRequest.Body.Latitude = Latitude;
		insertIntoCustomerRequest.Body.TypeCustomer = TypeCustomer;
		insertIntoCustomerRequest.Body.IdCompany = IdCompany;
		insertIntoCustomerRequest.Body.DescCustomer = DescCustomer;
		return ((CommercialSoap)this).InsertIntoCustomer(insertIntoCustomerRequest).Body.InsertIntoCustomerResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<InsertIntoCustomerResponse> CommercialSoap.InsertIntoCustomerAsync(InsertIntoCustomerRequest request)
	{
		return base.Channel.InsertIntoCustomerAsync(request);
	}

	public Task<InsertIntoCustomerResponse> InsertIntoCustomerAsync(string Code, string Name, string KindCustomer, string FirstName, string LastName, string CodeMeli, string Sh_Sabt, string Code_E, string CodePosti, string AddressDaftar, string AddressTahvil, string UserId, string IdCountry, string IdProvince, string IdCity, string Zone, string Tel, string Fax, string WebSayt, string Email, string Mobile, string KolBed, string MoeenBed, string Taf1Bed, string Taf2Bed, string KindAct, string PeriodActiveYear, string PeriodActiveMonth, string KindBuyer, string DateSabt, string MandeHesab, string MandeCheck, string UserName, string uDate, string uTime, string TejariName, string PishCode, string darsadtakhfif, string KindFactor, string personCode, string ShenaseMeli, string ModatPardakht, string EtebarMazad, string Password, string MEnterToCmp, string IdZone, string IdRoute, string Longitude, string Latitude, string TypeCustomer, string IdCompany, string DescCustomer)
	{
		InsertIntoCustomerRequest insertIntoCustomerRequest = new InsertIntoCustomerRequest();
		insertIntoCustomerRequest.Body = new InsertIntoCustomerRequestBody();
		insertIntoCustomerRequest.Body.Code = Code;
		insertIntoCustomerRequest.Body.Name = Name;
		insertIntoCustomerRequest.Body.KindCustomer = KindCustomer;
		insertIntoCustomerRequest.Body.FirstName = FirstName;
		insertIntoCustomerRequest.Body.LastName = LastName;
		insertIntoCustomerRequest.Body.CodeMeli = CodeMeli;
		insertIntoCustomerRequest.Body.Sh_Sabt = Sh_Sabt;
		insertIntoCustomerRequest.Body.Code_E = Code_E;
		insertIntoCustomerRequest.Body.CodePosti = CodePosti;
		insertIntoCustomerRequest.Body.AddressDaftar = AddressDaftar;
		insertIntoCustomerRequest.Body.AddressTahvil = AddressTahvil;
		insertIntoCustomerRequest.Body.UserId = UserId;
		insertIntoCustomerRequest.Body.IdCountry = IdCountry;
		insertIntoCustomerRequest.Body.IdProvince = IdProvince;
		insertIntoCustomerRequest.Body.IdCity = IdCity;
		insertIntoCustomerRequest.Body.Zone = Zone;
		insertIntoCustomerRequest.Body.Tel = Tel;
		insertIntoCustomerRequest.Body.Fax = Fax;
		insertIntoCustomerRequest.Body.WebSayt = WebSayt;
		insertIntoCustomerRequest.Body.Email = Email;
		insertIntoCustomerRequest.Body.Mobile = Mobile;
		insertIntoCustomerRequest.Body.KolBed = KolBed;
		insertIntoCustomerRequest.Body.MoeenBed = MoeenBed;
		insertIntoCustomerRequest.Body.Taf1Bed = Taf1Bed;
		insertIntoCustomerRequest.Body.Taf2Bed = Taf2Bed;
		insertIntoCustomerRequest.Body.KindAct = KindAct;
		insertIntoCustomerRequest.Body.PeriodActiveYear = PeriodActiveYear;
		insertIntoCustomerRequest.Body.PeriodActiveMonth = PeriodActiveMonth;
		insertIntoCustomerRequest.Body.KindBuyer = KindBuyer;
		insertIntoCustomerRequest.Body.DateSabt = DateSabt;
		insertIntoCustomerRequest.Body.MandeHesab = MandeHesab;
		insertIntoCustomerRequest.Body.MandeCheck = MandeCheck;
		insertIntoCustomerRequest.Body.UserName = UserName;
		insertIntoCustomerRequest.Body.uDate = uDate;
		insertIntoCustomerRequest.Body.uTime = uTime;
		insertIntoCustomerRequest.Body.TejariName = TejariName;
		insertIntoCustomerRequest.Body.PishCode = PishCode;
		insertIntoCustomerRequest.Body.darsadtakhfif = darsadtakhfif;
		insertIntoCustomerRequest.Body.KindFactor = KindFactor;
		insertIntoCustomerRequest.Body.personCode = personCode;
		insertIntoCustomerRequest.Body.ShenaseMeli = ShenaseMeli;
		insertIntoCustomerRequest.Body.ModatPardakht = ModatPardakht;
		insertIntoCustomerRequest.Body.EtebarMazad = EtebarMazad;
		insertIntoCustomerRequest.Body.Password = Password;
		insertIntoCustomerRequest.Body.MEnterToCmp = MEnterToCmp;
		insertIntoCustomerRequest.Body.IdZone = IdZone;
		insertIntoCustomerRequest.Body.IdRoute = IdRoute;
		insertIntoCustomerRequest.Body.Longitude = Longitude;
		insertIntoCustomerRequest.Body.Latitude = Latitude;
		insertIntoCustomerRequest.Body.TypeCustomer = TypeCustomer;
		insertIntoCustomerRequest.Body.IdCompany = IdCompany;
		insertIntoCustomerRequest.Body.DescCustomer = DescCustomer;
		return ((CommercialSoap)this).InsertIntoCustomerAsync(insertIntoCustomerRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_UpdateAmount123Response CommercialSoap.Idealsp_UpdateAmount123(Idealsp_UpdateAmount123Request request)
	{
		return base.Channel.Idealsp_UpdateAmount123(request);
	}

	public string Idealsp_UpdateAmount123(string CodeKala, string Store, string KindAmount, string Price, string UserId)
	{
		Idealsp_UpdateAmount123Request idealsp_UpdateAmount123Request = new Idealsp_UpdateAmount123Request();
		idealsp_UpdateAmount123Request.Body = new Idealsp_UpdateAmount123RequestBody();
		idealsp_UpdateAmount123Request.Body.CodeKala = CodeKala;
		idealsp_UpdateAmount123Request.Body.Store = Store;
		idealsp_UpdateAmount123Request.Body.KindAmount = KindAmount;
		idealsp_UpdateAmount123Request.Body.Price = Price;
		idealsp_UpdateAmount123Request.Body.UserId = UserId;
		return ((CommercialSoap)this).Idealsp_UpdateAmount123(idealsp_UpdateAmount123Request).Body.Idealsp_UpdateAmount123Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_UpdateAmount123Response> CommercialSoap.Idealsp_UpdateAmount123Async(Idealsp_UpdateAmount123Request request)
	{
		return base.Channel.Idealsp_UpdateAmount123Async(request);
	}

	public Task<Idealsp_UpdateAmount123Response> Idealsp_UpdateAmount123Async(string CodeKala, string Store, string KindAmount, string Price, string UserId)
	{
		Idealsp_UpdateAmount123Request idealsp_UpdateAmount123Request = new Idealsp_UpdateAmount123Request();
		idealsp_UpdateAmount123Request.Body = new Idealsp_UpdateAmount123RequestBody();
		idealsp_UpdateAmount123Request.Body.CodeKala = CodeKala;
		idealsp_UpdateAmount123Request.Body.Store = Store;
		idealsp_UpdateAmount123Request.Body.KindAmount = KindAmount;
		idealsp_UpdateAmount123Request.Body.Price = Price;
		idealsp_UpdateAmount123Request.Body.UserId = UserId;
		return ((CommercialSoap)this).Idealsp_UpdateAmount123Async(idealsp_UpdateAmount123Request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_InsertSalesManResponse CommercialSoap.Idealsp_InsertSalesMan(Idealsp_InsertSalesManRequest request)
	{
		return base.Channel.Idealsp_InsertSalesMan(request);
	}

	public string Idealsp_InsertSalesMan(string Code, string FirstName, string LastName, string Address, string Code_e, string CodePosti, string CodeMeli, string Tel, string Mobile, string UserName, string uDate, string uTime, string Email, string WebSayt, string Fax, string idGroupSalesMan, string idKindSalesMan, string idCompany, string supervisor, string mahiat, string personCode, string UserId)
	{
		Idealsp_InsertSalesManRequest idealsp_InsertSalesManRequest = new Idealsp_InsertSalesManRequest();
		idealsp_InsertSalesManRequest.Body = new Idealsp_InsertSalesManRequestBody();
		idealsp_InsertSalesManRequest.Body.Code = Code;
		idealsp_InsertSalesManRequest.Body.FirstName = FirstName;
		idealsp_InsertSalesManRequest.Body.LastName = LastName;
		idealsp_InsertSalesManRequest.Body.Address = Address;
		idealsp_InsertSalesManRequest.Body.Code_e = Code_e;
		idealsp_InsertSalesManRequest.Body.CodePosti = CodePosti;
		idealsp_InsertSalesManRequest.Body.CodeMeli = CodeMeli;
		idealsp_InsertSalesManRequest.Body.Tel = Tel;
		idealsp_InsertSalesManRequest.Body.Mobile = Mobile;
		idealsp_InsertSalesManRequest.Body.UserName = UserName;
		idealsp_InsertSalesManRequest.Body.uDate = uDate;
		idealsp_InsertSalesManRequest.Body.uTime = uTime;
		idealsp_InsertSalesManRequest.Body.Email = Email;
		idealsp_InsertSalesManRequest.Body.WebSayt = WebSayt;
		idealsp_InsertSalesManRequest.Body.Fax = Fax;
		idealsp_InsertSalesManRequest.Body.idGroupSalesMan = idGroupSalesMan;
		idealsp_InsertSalesManRequest.Body.idKindSalesMan = idKindSalesMan;
		idealsp_InsertSalesManRequest.Body.idCompany = idCompany;
		idealsp_InsertSalesManRequest.Body.supervisor = supervisor;
		idealsp_InsertSalesManRequest.Body.mahiat = mahiat;
		idealsp_InsertSalesManRequest.Body.personCode = personCode;
		idealsp_InsertSalesManRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).Idealsp_InsertSalesMan(idealsp_InsertSalesManRequest).Body.Idealsp_InsertSalesManResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_InsertSalesManResponse> CommercialSoap.Idealsp_InsertSalesManAsync(Idealsp_InsertSalesManRequest request)
	{
		return base.Channel.Idealsp_InsertSalesManAsync(request);
	}

	public Task<Idealsp_InsertSalesManResponse> Idealsp_InsertSalesManAsync(string Code, string FirstName, string LastName, string Address, string Code_e, string CodePosti, string CodeMeli, string Tel, string Mobile, string UserName, string uDate, string uTime, string Email, string WebSayt, string Fax, string idGroupSalesMan, string idKindSalesMan, string idCompany, string supervisor, string mahiat, string personCode, string UserId)
	{
		Idealsp_InsertSalesManRequest idealsp_InsertSalesManRequest = new Idealsp_InsertSalesManRequest();
		idealsp_InsertSalesManRequest.Body = new Idealsp_InsertSalesManRequestBody();
		idealsp_InsertSalesManRequest.Body.Code = Code;
		idealsp_InsertSalesManRequest.Body.FirstName = FirstName;
		idealsp_InsertSalesManRequest.Body.LastName = LastName;
		idealsp_InsertSalesManRequest.Body.Address = Address;
		idealsp_InsertSalesManRequest.Body.Code_e = Code_e;
		idealsp_InsertSalesManRequest.Body.CodePosti = CodePosti;
		idealsp_InsertSalesManRequest.Body.CodeMeli = CodeMeli;
		idealsp_InsertSalesManRequest.Body.Tel = Tel;
		idealsp_InsertSalesManRequest.Body.Mobile = Mobile;
		idealsp_InsertSalesManRequest.Body.UserName = UserName;
		idealsp_InsertSalesManRequest.Body.uDate = uDate;
		idealsp_InsertSalesManRequest.Body.uTime = uTime;
		idealsp_InsertSalesManRequest.Body.Email = Email;
		idealsp_InsertSalesManRequest.Body.WebSayt = WebSayt;
		idealsp_InsertSalesManRequest.Body.Fax = Fax;
		idealsp_InsertSalesManRequest.Body.idGroupSalesMan = idGroupSalesMan;
		idealsp_InsertSalesManRequest.Body.idKindSalesMan = idKindSalesMan;
		idealsp_InsertSalesManRequest.Body.idCompany = idCompany;
		idealsp_InsertSalesManRequest.Body.supervisor = supervisor;
		idealsp_InsertSalesManRequest.Body.mahiat = mahiat;
		idealsp_InsertSalesManRequest.Body.personCode = personCode;
		idealsp_InsertSalesManRequest.Body.UserId = UserId;
		return ((CommercialSoap)this).Idealsp_InsertSalesManAsync(idealsp_InsertSalesManRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_InsertPishFactorResponse CommercialSoap.Idealsp_InsertPishFactor(Idealsp_InsertPishFactorRequest request)
	{
		return base.Channel.Idealsp_InsertPishFactor(request);
	}

	public string Idealsp_InsertPishFactor(string PishFactorNo, string PishFactorDate, string DateEtebar, string IdSalesMan, string IdCustomer, string AddressDaftar, string AddressTahvil, string IdKindSale, string IdCompany, string IdKindMaterial, string Olaviat, string KindFactor, string Desc, string UserName, string UDate, string UTime, string Store, string IdSalesMan2, string IdSalesMan3, string MablaghPish, string UserID, string IdPart, string DateTasvie, string IDpishfactor)
	{
		Idealsp_InsertPishFactorRequest idealsp_InsertPishFactorRequest = new Idealsp_InsertPishFactorRequest();
		idealsp_InsertPishFactorRequest.Body = new Idealsp_InsertPishFactorRequestBody();
		idealsp_InsertPishFactorRequest.Body.PishFactorNo = PishFactorNo;
		idealsp_InsertPishFactorRequest.Body.PishFactorDate = PishFactorDate;
		idealsp_InsertPishFactorRequest.Body.DateEtebar = DateEtebar;
		idealsp_InsertPishFactorRequest.Body.IdSalesMan = IdSalesMan;
		idealsp_InsertPishFactorRequest.Body.IdCustomer = IdCustomer;
		idealsp_InsertPishFactorRequest.Body.AddressDaftar = AddressDaftar;
		idealsp_InsertPishFactorRequest.Body.AddressTahvil = AddressTahvil;
		idealsp_InsertPishFactorRequest.Body.IdKindSale = IdKindSale;
		idealsp_InsertPishFactorRequest.Body.IdCompany = IdCompany;
		idealsp_InsertPishFactorRequest.Body.IdKindMaterial = IdKindMaterial;
		idealsp_InsertPishFactorRequest.Body.Olaviat = Olaviat;
		idealsp_InsertPishFactorRequest.Body.KindFactor = KindFactor;
		idealsp_InsertPishFactorRequest.Body.Desc = Desc;
		idealsp_InsertPishFactorRequest.Body.UserName = UserName;
		idealsp_InsertPishFactorRequest.Body.UDate = UDate;
		idealsp_InsertPishFactorRequest.Body.UTime = UTime;
		idealsp_InsertPishFactorRequest.Body.Store = Store;
		idealsp_InsertPishFactorRequest.Body.IdSalesMan2 = IdSalesMan2;
		idealsp_InsertPishFactorRequest.Body.IdSalesMan3 = IdSalesMan3;
		idealsp_InsertPishFactorRequest.Body.MablaghPish = MablaghPish;
		idealsp_InsertPishFactorRequest.Body.UserID = UserID;
		idealsp_InsertPishFactorRequest.Body.IdPart = IdPart;
		idealsp_InsertPishFactorRequest.Body.DateTasvie = DateTasvie;
		idealsp_InsertPishFactorRequest.Body.IDpishfactor = IDpishfactor;
		return ((CommercialSoap)this).Idealsp_InsertPishFactor(idealsp_InsertPishFactorRequest).Body.Idealsp_InsertPishFactorResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_InsertPishFactorResponse> CommercialSoap.Idealsp_InsertPishFactorAsync(Idealsp_InsertPishFactorRequest request)
	{
		return base.Channel.Idealsp_InsertPishFactorAsync(request);
	}

	public Task<Idealsp_InsertPishFactorResponse> Idealsp_InsertPishFactorAsync(string PishFactorNo, string PishFactorDate, string DateEtebar, string IdSalesMan, string IdCustomer, string AddressDaftar, string AddressTahvil, string IdKindSale, string IdCompany, string IdKindMaterial, string Olaviat, string KindFactor, string Desc, string UserName, string UDate, string UTime, string Store, string IdSalesMan2, string IdSalesMan3, string MablaghPish, string UserID, string IdPart, string DateTasvie, string IDpishfactor)
	{
		Idealsp_InsertPishFactorRequest idealsp_InsertPishFactorRequest = new Idealsp_InsertPishFactorRequest();
		idealsp_InsertPishFactorRequest.Body = new Idealsp_InsertPishFactorRequestBody();
		idealsp_InsertPishFactorRequest.Body.PishFactorNo = PishFactorNo;
		idealsp_InsertPishFactorRequest.Body.PishFactorDate = PishFactorDate;
		idealsp_InsertPishFactorRequest.Body.DateEtebar = DateEtebar;
		idealsp_InsertPishFactorRequest.Body.IdSalesMan = IdSalesMan;
		idealsp_InsertPishFactorRequest.Body.IdCustomer = IdCustomer;
		idealsp_InsertPishFactorRequest.Body.AddressDaftar = AddressDaftar;
		idealsp_InsertPishFactorRequest.Body.AddressTahvil = AddressTahvil;
		idealsp_InsertPishFactorRequest.Body.IdKindSale = IdKindSale;
		idealsp_InsertPishFactorRequest.Body.IdCompany = IdCompany;
		idealsp_InsertPishFactorRequest.Body.IdKindMaterial = IdKindMaterial;
		idealsp_InsertPishFactorRequest.Body.Olaviat = Olaviat;
		idealsp_InsertPishFactorRequest.Body.KindFactor = KindFactor;
		idealsp_InsertPishFactorRequest.Body.Desc = Desc;
		idealsp_InsertPishFactorRequest.Body.UserName = UserName;
		idealsp_InsertPishFactorRequest.Body.UDate = UDate;
		idealsp_InsertPishFactorRequest.Body.UTime = UTime;
		idealsp_InsertPishFactorRequest.Body.Store = Store;
		idealsp_InsertPishFactorRequest.Body.IdSalesMan2 = IdSalesMan2;
		idealsp_InsertPishFactorRequest.Body.IdSalesMan3 = IdSalesMan3;
		idealsp_InsertPishFactorRequest.Body.MablaghPish = MablaghPish;
		idealsp_InsertPishFactorRequest.Body.UserID = UserID;
		idealsp_InsertPishFactorRequest.Body.IdPart = IdPart;
		idealsp_InsertPishFactorRequest.Body.DateTasvie = DateTasvie;
		idealsp_InsertPishFactorRequest.Body.IDpishfactor = IDpishfactor;
		return ((CommercialSoap)this).Idealsp_InsertPishFactorAsync(idealsp_InsertPishFactorRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_InsertPishFactorDetailResponse CommercialSoap.Idealsp_InsertPishFactorDetail(Idealsp_InsertPishFactorDetailRequest request)
	{
		return base.Channel.Idealsp_InsertPishFactorDetail(request);
	}

	public string Idealsp_InsertPishFactorDetail(string IdMaterial, string Amount, string AmountKindBag, string Olaviat, string Desc, string Price, string Cost, string DarsadKasr, string AmountKasr, string DarsadEzaf, string AmountEzaf, string CostPardakht, string Weight, string Avarez, string Malyat, string Haml, string Store, string ModatPardakht, string SerialKala, string DateEngheza, string Dategaranti, string IdpishFactor, string CodeKala)
	{
		Idealsp_InsertPishFactorDetailRequest idealsp_InsertPishFactorDetailRequest = new Idealsp_InsertPishFactorDetailRequest();
		idealsp_InsertPishFactorDetailRequest.Body = new Idealsp_InsertPishFactorDetailRequestBody();
		idealsp_InsertPishFactorDetailRequest.Body.IdMaterial = IdMaterial;
		idealsp_InsertPishFactorDetailRequest.Body.Amount = Amount;
		idealsp_InsertPishFactorDetailRequest.Body.AmountKindBag = AmountKindBag;
		idealsp_InsertPishFactorDetailRequest.Body.Olaviat = Olaviat;
		idealsp_InsertPishFactorDetailRequest.Body.Desc = Desc;
		idealsp_InsertPishFactorDetailRequest.Body.Price = Price;
		idealsp_InsertPishFactorDetailRequest.Body.Cost = Cost;
		idealsp_InsertPishFactorDetailRequest.Body.DarsadKasr = DarsadKasr;
		idealsp_InsertPishFactorDetailRequest.Body.AmountKasr = AmountKasr;
		idealsp_InsertPishFactorDetailRequest.Body.DarsadEzaf = DarsadEzaf;
		idealsp_InsertPishFactorDetailRequest.Body.AmountEzaf = AmountEzaf;
		idealsp_InsertPishFactorDetailRequest.Body.CostPardakht = CostPardakht;
		idealsp_InsertPishFactorDetailRequest.Body.Weight = Weight;
		idealsp_InsertPishFactorDetailRequest.Body.Avarez = Avarez;
		idealsp_InsertPishFactorDetailRequest.Body.Malyat = Malyat;
		idealsp_InsertPishFactorDetailRequest.Body.Haml = Haml;
		idealsp_InsertPishFactorDetailRequest.Body.Store = Store;
		idealsp_InsertPishFactorDetailRequest.Body.ModatPardakht = ModatPardakht;
		idealsp_InsertPishFactorDetailRequest.Body.SerialKala = SerialKala;
		idealsp_InsertPishFactorDetailRequest.Body.DateEngheza = DateEngheza;
		idealsp_InsertPishFactorDetailRequest.Body.Dategaranti = Dategaranti;
		idealsp_InsertPishFactorDetailRequest.Body.IdpishFactor = IdpishFactor;
		idealsp_InsertPishFactorDetailRequest.Body.CodeKala = CodeKala;
		return ((CommercialSoap)this).Idealsp_InsertPishFactorDetail(idealsp_InsertPishFactorDetailRequest).Body.Idealsp_InsertPishFactorDetailResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_InsertPishFactorDetailResponse> CommercialSoap.Idealsp_InsertPishFactorDetailAsync(Idealsp_InsertPishFactorDetailRequest request)
	{
		return base.Channel.Idealsp_InsertPishFactorDetailAsync(request);
	}

	public Task<Idealsp_InsertPishFactorDetailResponse> Idealsp_InsertPishFactorDetailAsync(string IdMaterial, string Amount, string AmountKindBag, string Olaviat, string Desc, string Price, string Cost, string DarsadKasr, string AmountKasr, string DarsadEzaf, string AmountEzaf, string CostPardakht, string Weight, string Avarez, string Malyat, string Haml, string Store, string ModatPardakht, string SerialKala, string DateEngheza, string Dategaranti, string IdpishFactor, string CodeKala)
	{
		Idealsp_InsertPishFactorDetailRequest idealsp_InsertPishFactorDetailRequest = new Idealsp_InsertPishFactorDetailRequest();
		idealsp_InsertPishFactorDetailRequest.Body = new Idealsp_InsertPishFactorDetailRequestBody();
		idealsp_InsertPishFactorDetailRequest.Body.IdMaterial = IdMaterial;
		idealsp_InsertPishFactorDetailRequest.Body.Amount = Amount;
		idealsp_InsertPishFactorDetailRequest.Body.AmountKindBag = AmountKindBag;
		idealsp_InsertPishFactorDetailRequest.Body.Olaviat = Olaviat;
		idealsp_InsertPishFactorDetailRequest.Body.Desc = Desc;
		idealsp_InsertPishFactorDetailRequest.Body.Price = Price;
		idealsp_InsertPishFactorDetailRequest.Body.Cost = Cost;
		idealsp_InsertPishFactorDetailRequest.Body.DarsadKasr = DarsadKasr;
		idealsp_InsertPishFactorDetailRequest.Body.AmountKasr = AmountKasr;
		idealsp_InsertPishFactorDetailRequest.Body.DarsadEzaf = DarsadEzaf;
		idealsp_InsertPishFactorDetailRequest.Body.AmountEzaf = AmountEzaf;
		idealsp_InsertPishFactorDetailRequest.Body.CostPardakht = CostPardakht;
		idealsp_InsertPishFactorDetailRequest.Body.Weight = Weight;
		idealsp_InsertPishFactorDetailRequest.Body.Avarez = Avarez;
		idealsp_InsertPishFactorDetailRequest.Body.Malyat = Malyat;
		idealsp_InsertPishFactorDetailRequest.Body.Haml = Haml;
		idealsp_InsertPishFactorDetailRequest.Body.Store = Store;
		idealsp_InsertPishFactorDetailRequest.Body.ModatPardakht = ModatPardakht;
		idealsp_InsertPishFactorDetailRequest.Body.SerialKala = SerialKala;
		idealsp_InsertPishFactorDetailRequest.Body.DateEngheza = DateEngheza;
		idealsp_InsertPishFactorDetailRequest.Body.Dategaranti = Dategaranti;
		idealsp_InsertPishFactorDetailRequest.Body.IdpishFactor = IdpishFactor;
		idealsp_InsertPishFactorDetailRequest.Body.CodeKala = CodeKala;
		return ((CommercialSoap)this).Idealsp_InsertPishFactorDetailAsync(idealsp_InsertPishFactorDetailRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_InsertDaryaftResponse CommercialSoap.Idealsp_InsertDaryaft(Idealsp_InsertDaryaftRequest request)
	{
		return base.Channel.Idealsp_InsertDaryaft(request);
	}

	public string Idealsp_InsertDaryaft(string Code, string IdCustomer, string Date, string DateFirst, string DateRas, string IdCompany, string UserName, string UDate, string Time, string Babat, string IdFactorTasvie, string IdSalesMan1, string IdSalesMan2, string IdSalesMan3)
	{
		Idealsp_InsertDaryaftRequest idealsp_InsertDaryaftRequest = new Idealsp_InsertDaryaftRequest();
		idealsp_InsertDaryaftRequest.Body = new Idealsp_InsertDaryaftRequestBody();
		idealsp_InsertDaryaftRequest.Body.Code = Code;
		idealsp_InsertDaryaftRequest.Body.IdCustomer = IdCustomer;
		idealsp_InsertDaryaftRequest.Body.Date = Date;
		idealsp_InsertDaryaftRequest.Body.DateFirst = DateFirst;
		idealsp_InsertDaryaftRequest.Body.DateRas = DateRas;
		idealsp_InsertDaryaftRequest.Body.IdCompany = IdCompany;
		idealsp_InsertDaryaftRequest.Body.UserName = UserName;
		idealsp_InsertDaryaftRequest.Body.UDate = UDate;
		idealsp_InsertDaryaftRequest.Body.Time = Time;
		idealsp_InsertDaryaftRequest.Body.Babat = Babat;
		idealsp_InsertDaryaftRequest.Body.IdFactorTasvie = IdFactorTasvie;
		idealsp_InsertDaryaftRequest.Body.IdSalesMan1 = IdSalesMan1;
		idealsp_InsertDaryaftRequest.Body.IdSalesMan2 = IdSalesMan2;
		idealsp_InsertDaryaftRequest.Body.IdSalesMan3 = IdSalesMan3;
		return ((CommercialSoap)this).Idealsp_InsertDaryaft(idealsp_InsertDaryaftRequest).Body.Idealsp_InsertDaryaftResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_InsertDaryaftResponse> CommercialSoap.Idealsp_InsertDaryaftAsync(Idealsp_InsertDaryaftRequest request)
	{
		return base.Channel.Idealsp_InsertDaryaftAsync(request);
	}

	public Task<Idealsp_InsertDaryaftResponse> Idealsp_InsertDaryaftAsync(string Code, string IdCustomer, string Date, string DateFirst, string DateRas, string IdCompany, string UserName, string UDate, string Time, string Babat, string IdFactorTasvie, string IdSalesMan1, string IdSalesMan2, string IdSalesMan3)
	{
		Idealsp_InsertDaryaftRequest idealsp_InsertDaryaftRequest = new Idealsp_InsertDaryaftRequest();
		idealsp_InsertDaryaftRequest.Body = new Idealsp_InsertDaryaftRequestBody();
		idealsp_InsertDaryaftRequest.Body.Code = Code;
		idealsp_InsertDaryaftRequest.Body.IdCustomer = IdCustomer;
		idealsp_InsertDaryaftRequest.Body.Date = Date;
		idealsp_InsertDaryaftRequest.Body.DateFirst = DateFirst;
		idealsp_InsertDaryaftRequest.Body.DateRas = DateRas;
		idealsp_InsertDaryaftRequest.Body.IdCompany = IdCompany;
		idealsp_InsertDaryaftRequest.Body.UserName = UserName;
		idealsp_InsertDaryaftRequest.Body.UDate = UDate;
		idealsp_InsertDaryaftRequest.Body.Time = Time;
		idealsp_InsertDaryaftRequest.Body.Babat = Babat;
		idealsp_InsertDaryaftRequest.Body.IdFactorTasvie = IdFactorTasvie;
		idealsp_InsertDaryaftRequest.Body.IdSalesMan1 = IdSalesMan1;
		idealsp_InsertDaryaftRequest.Body.IdSalesMan2 = IdSalesMan2;
		idealsp_InsertDaryaftRequest.Body.IdSalesMan3 = IdSalesMan3;
		return ((CommercialSoap)this).Idealsp_InsertDaryaftAsync(idealsp_InsertDaryaftRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_InsertDaryaftDetailResponse CommercialSoap.Idealsp_InsertDaryaftDetail(Idealsp_InsertDaryaftDetailRequest request)
	{
		return base.Channel.Idealsp_InsertDaryaftDetail(request);
	}

	public string Idealsp_InsertDaryaftDetail(string ResidNo, string IdCustomer, string CheckNo, string CheckDate, string Mablagh, string Bank, string CodeShobeh, string Jari, string Modat, string NameShobeh, string Radif, string SahebCheck, string FactorNo, string NDaftar, string KindSabt, string IdFactorTasvie, string KindSabtDis, string CheckNoKamel, string ShSayadi, string KindDis, string CodeRahgiri)
	{
		Idealsp_InsertDaryaftDetailRequest idealsp_InsertDaryaftDetailRequest = new Idealsp_InsertDaryaftDetailRequest();
		idealsp_InsertDaryaftDetailRequest.Body = new Idealsp_InsertDaryaftDetailRequestBody();
		idealsp_InsertDaryaftDetailRequest.Body.ResidNo = ResidNo;
		idealsp_InsertDaryaftDetailRequest.Body.IdCustomer = IdCustomer;
		idealsp_InsertDaryaftDetailRequest.Body.CheckNo = CheckNo;
		idealsp_InsertDaryaftDetailRequest.Body.CheckDate = CheckDate;
		idealsp_InsertDaryaftDetailRequest.Body.Mablagh = Mablagh;
		idealsp_InsertDaryaftDetailRequest.Body.Bank = Bank;
		idealsp_InsertDaryaftDetailRequest.Body.CodeShobeh = CodeShobeh;
		idealsp_InsertDaryaftDetailRequest.Body.Jari = Jari;
		idealsp_InsertDaryaftDetailRequest.Body.Modat = Modat;
		idealsp_InsertDaryaftDetailRequest.Body.NameShobeh = NameShobeh;
		idealsp_InsertDaryaftDetailRequest.Body.Radif = Radif;
		idealsp_InsertDaryaftDetailRequest.Body.SahebCheck = SahebCheck;
		idealsp_InsertDaryaftDetailRequest.Body.FactorNo = FactorNo;
		idealsp_InsertDaryaftDetailRequest.Body.NDaftar = NDaftar;
		idealsp_InsertDaryaftDetailRequest.Body.KindSabt = KindSabt;
		idealsp_InsertDaryaftDetailRequest.Body.IdFactorTasvie = IdFactorTasvie;
		idealsp_InsertDaryaftDetailRequest.Body.KindSabtDis = KindSabtDis;
		idealsp_InsertDaryaftDetailRequest.Body.CheckNoKamel = CheckNoKamel;
		idealsp_InsertDaryaftDetailRequest.Body.ShSayadi = ShSayadi;
		idealsp_InsertDaryaftDetailRequest.Body.KindDis = KindDis;
		idealsp_InsertDaryaftDetailRequest.Body.CodeRahgiri = CodeRahgiri;
		return ((CommercialSoap)this).Idealsp_InsertDaryaftDetail(idealsp_InsertDaryaftDetailRequest).Body.Idealsp_InsertDaryaftDetailResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_InsertDaryaftDetailResponse> CommercialSoap.Idealsp_InsertDaryaftDetailAsync(Idealsp_InsertDaryaftDetailRequest request)
	{
		return base.Channel.Idealsp_InsertDaryaftDetailAsync(request);
	}

	public Task<Idealsp_InsertDaryaftDetailResponse> Idealsp_InsertDaryaftDetailAsync(string ResidNo, string IdCustomer, string CheckNo, string CheckDate, string Mablagh, string Bank, string CodeShobeh, string Jari, string Modat, string NameShobeh, string Radif, string SahebCheck, string FactorNo, string NDaftar, string KindSabt, string IdFactorTasvie, string KindSabtDis, string CheckNoKamel, string ShSayadi, string KindDis, string CodeRahgiri)
	{
		Idealsp_InsertDaryaftDetailRequest idealsp_InsertDaryaftDetailRequest = new Idealsp_InsertDaryaftDetailRequest();
		idealsp_InsertDaryaftDetailRequest.Body = new Idealsp_InsertDaryaftDetailRequestBody();
		idealsp_InsertDaryaftDetailRequest.Body.ResidNo = ResidNo;
		idealsp_InsertDaryaftDetailRequest.Body.IdCustomer = IdCustomer;
		idealsp_InsertDaryaftDetailRequest.Body.CheckNo = CheckNo;
		idealsp_InsertDaryaftDetailRequest.Body.CheckDate = CheckDate;
		idealsp_InsertDaryaftDetailRequest.Body.Mablagh = Mablagh;
		idealsp_InsertDaryaftDetailRequest.Body.Bank = Bank;
		idealsp_InsertDaryaftDetailRequest.Body.CodeShobeh = CodeShobeh;
		idealsp_InsertDaryaftDetailRequest.Body.Jari = Jari;
		idealsp_InsertDaryaftDetailRequest.Body.Modat = Modat;
		idealsp_InsertDaryaftDetailRequest.Body.NameShobeh = NameShobeh;
		idealsp_InsertDaryaftDetailRequest.Body.Radif = Radif;
		idealsp_InsertDaryaftDetailRequest.Body.SahebCheck = SahebCheck;
		idealsp_InsertDaryaftDetailRequest.Body.FactorNo = FactorNo;
		idealsp_InsertDaryaftDetailRequest.Body.NDaftar = NDaftar;
		idealsp_InsertDaryaftDetailRequest.Body.KindSabt = KindSabt;
		idealsp_InsertDaryaftDetailRequest.Body.IdFactorTasvie = IdFactorTasvie;
		idealsp_InsertDaryaftDetailRequest.Body.KindSabtDis = KindSabtDis;
		idealsp_InsertDaryaftDetailRequest.Body.CheckNoKamel = CheckNoKamel;
		idealsp_InsertDaryaftDetailRequest.Body.ShSayadi = ShSayadi;
		idealsp_InsertDaryaftDetailRequest.Body.KindDis = KindDis;
		idealsp_InsertDaryaftDetailRequest.Body.CodeRahgiri = CodeRahgiri;
		return ((CommercialSoap)this).Idealsp_InsertDaryaftDetailAsync(idealsp_InsertDaryaftDetailRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_InsertoutputResponse CommercialSoap.Idealsp_Insertoutput(Idealsp_InsertoutputRequest request)
	{
		return base.Channel.Idealsp_Insertoutput(request);
	}

	public string Idealsp_Insertoutput(string Doc_No, string Seq, string Doc_Date, string Code, string Store, string Part, string Out_Quan, string Quan2, string Shop_Code, string Training, string Shahr, string Discount, string Factor_No, string Factor_Dat, string Transport, string Sayer, string Sharh, string Serial, string Factor_C, string Factor_P, string OutCodeVahed, string CodeBarBari, string UserId, string Kind)
	{
		Idealsp_InsertoutputRequest idealsp_InsertoutputRequest = new Idealsp_InsertoutputRequest();
		idealsp_InsertoutputRequest.Body = new Idealsp_InsertoutputRequestBody();
		idealsp_InsertoutputRequest.Body.Doc_No = Doc_No;
		idealsp_InsertoutputRequest.Body.Seq = Seq;
		idealsp_InsertoutputRequest.Body.Doc_Date = Doc_Date;
		idealsp_InsertoutputRequest.Body.Code = Code;
		idealsp_InsertoutputRequest.Body.Store = Store;
		idealsp_InsertoutputRequest.Body.Part = Part;
		idealsp_InsertoutputRequest.Body.Out_Quan = Out_Quan;
		idealsp_InsertoutputRequest.Body.Quan2 = Quan2;
		idealsp_InsertoutputRequest.Body.Shop_Code = Shop_Code;
		idealsp_InsertoutputRequest.Body.Training = Training;
		idealsp_InsertoutputRequest.Body.Shahr = Shahr;
		idealsp_InsertoutputRequest.Body.Discount = Discount;
		idealsp_InsertoutputRequest.Body.Factor_No = Factor_No;
		idealsp_InsertoutputRequest.Body.Factor_Dat = Factor_Dat;
		idealsp_InsertoutputRequest.Body.Transport = Transport;
		idealsp_InsertoutputRequest.Body.Sayer = Sayer;
		idealsp_InsertoutputRequest.Body.Sharh = Sharh;
		idealsp_InsertoutputRequest.Body.Serial = Serial;
		idealsp_InsertoutputRequest.Body.Factor_C = Factor_C;
		idealsp_InsertoutputRequest.Body.Factor_P = Factor_P;
		idealsp_InsertoutputRequest.Body.OutCodeVahed = OutCodeVahed;
		idealsp_InsertoutputRequest.Body.CodeBarBari = CodeBarBari;
		idealsp_InsertoutputRequest.Body.UserId = UserId;
		idealsp_InsertoutputRequest.Body.Kind = Kind;
		return ((CommercialSoap)this).Idealsp_Insertoutput(idealsp_InsertoutputRequest).Body.Idealsp_InsertoutputResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_InsertoutputResponse> CommercialSoap.Idealsp_InsertoutputAsync(Idealsp_InsertoutputRequest request)
	{
		return base.Channel.Idealsp_InsertoutputAsync(request);
	}

	public Task<Idealsp_InsertoutputResponse> Idealsp_InsertoutputAsync(string Doc_No, string Seq, string Doc_Date, string Code, string Store, string Part, string Out_Quan, string Quan2, string Shop_Code, string Training, string Shahr, string Discount, string Factor_No, string Factor_Dat, string Transport, string Sayer, string Sharh, string Serial, string Factor_C, string Factor_P, string OutCodeVahed, string CodeBarBari, string UserId, string Kind)
	{
		Idealsp_InsertoutputRequest idealsp_InsertoutputRequest = new Idealsp_InsertoutputRequest();
		idealsp_InsertoutputRequest.Body = new Idealsp_InsertoutputRequestBody();
		idealsp_InsertoutputRequest.Body.Doc_No = Doc_No;
		idealsp_InsertoutputRequest.Body.Seq = Seq;
		idealsp_InsertoutputRequest.Body.Doc_Date = Doc_Date;
		idealsp_InsertoutputRequest.Body.Code = Code;
		idealsp_InsertoutputRequest.Body.Store = Store;
		idealsp_InsertoutputRequest.Body.Part = Part;
		idealsp_InsertoutputRequest.Body.Out_Quan = Out_Quan;
		idealsp_InsertoutputRequest.Body.Quan2 = Quan2;
		idealsp_InsertoutputRequest.Body.Shop_Code = Shop_Code;
		idealsp_InsertoutputRequest.Body.Training = Training;
		idealsp_InsertoutputRequest.Body.Shahr = Shahr;
		idealsp_InsertoutputRequest.Body.Discount = Discount;
		idealsp_InsertoutputRequest.Body.Factor_No = Factor_No;
		idealsp_InsertoutputRequest.Body.Factor_Dat = Factor_Dat;
		idealsp_InsertoutputRequest.Body.Transport = Transport;
		idealsp_InsertoutputRequest.Body.Sayer = Sayer;
		idealsp_InsertoutputRequest.Body.Sharh = Sharh;
		idealsp_InsertoutputRequest.Body.Serial = Serial;
		idealsp_InsertoutputRequest.Body.Factor_C = Factor_C;
		idealsp_InsertoutputRequest.Body.Factor_P = Factor_P;
		idealsp_InsertoutputRequest.Body.OutCodeVahed = OutCodeVahed;
		idealsp_InsertoutputRequest.Body.CodeBarBari = CodeBarBari;
		idealsp_InsertoutputRequest.Body.UserId = UserId;
		idealsp_InsertoutputRequest.Body.Kind = Kind;
		return ((CommercialSoap)this).Idealsp_InsertoutputAsync(idealsp_InsertoutputRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetRouteListResponse CommercialSoap.GetRouteList(GetRouteListRequest request)
	{
		return base.Channel.GetRouteList(request);
	}

	public string GetRouteList()
	{
		GetRouteListRequest getRouteListRequest = new GetRouteListRequest();
		getRouteListRequest.Body = new GetRouteListRequestBody();
		return ((CommercialSoap)this).GetRouteList(getRouteListRequest).Body.GetRouteListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetRouteListResponse> CommercialSoap.GetRouteListAsync(GetRouteListRequest request)
	{
		return base.Channel.GetRouteListAsync(request);
	}

	public Task<GetRouteListResponse> GetRouteListAsync()
	{
		GetRouteListRequest getRouteListRequest = new GetRouteListRequest();
		getRouteListRequest.Body = new GetRouteListRequestBody();
		return ((CommercialSoap)this).GetRouteListAsync(getRouteListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetZoneListResponse CommercialSoap.GetZoneList(GetZoneListRequest request)
	{
		return base.Channel.GetZoneList(request);
	}

	public string GetZoneList()
	{
		GetZoneListRequest getZoneListRequest = new GetZoneListRequest();
		getZoneListRequest.Body = new GetZoneListRequestBody();
		return ((CommercialSoap)this).GetZoneList(getZoneListRequest).Body.GetZoneListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetZoneListResponse> CommercialSoap.GetZoneListAsync(GetZoneListRequest request)
	{
		return base.Channel.GetZoneListAsync(request);
	}

	public Task<GetZoneListResponse> GetZoneListAsync()
	{
		GetZoneListRequest getZoneListRequest = new GetZoneListRequest();
		getZoneListRequest.Body = new GetZoneListRequestBody();
		return ((CommercialSoap)this).GetZoneListAsync(getZoneListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetSalesmanListResponse CommercialSoap.GetSalesmanList(GetSalesmanListRequest request)
	{
		return base.Channel.GetSalesmanList(request);
	}

	public string GetSalesmanList()
	{
		GetSalesmanListRequest getSalesmanListRequest = new GetSalesmanListRequest();
		getSalesmanListRequest.Body = new GetSalesmanListRequestBody();
		return ((CommercialSoap)this).GetSalesmanList(getSalesmanListRequest).Body.GetSalesmanListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetSalesmanListResponse> CommercialSoap.GetSalesmanListAsync(GetSalesmanListRequest request)
	{
		return base.Channel.GetSalesmanListAsync(request);
	}

	public Task<GetSalesmanListResponse> GetSalesmanListAsync()
	{
		GetSalesmanListRequest getSalesmanListRequest = new GetSalesmanListRequest();
		getSalesmanListRequest.Body = new GetSalesmanListRequestBody();
		return ((CommercialSoap)this).GetSalesmanListAsync(getSalesmanListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetPartListResponse CommercialSoap.GetPartList(GetPartListRequest request)
	{
		return base.Channel.GetPartList(request);
	}

	public string GetPartList()
	{
		GetPartListRequest getPartListRequest = new GetPartListRequest();
		getPartListRequest.Body = new GetPartListRequestBody();
		return ((CommercialSoap)this).GetPartList(getPartListRequest).Body.GetPartListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetPartListResponse> CommercialSoap.GetPartListAsync(GetPartListRequest request)
	{
		return base.Channel.GetPartListAsync(request);
	}

	public Task<GetPartListResponse> GetPartListAsync()
	{
		GetPartListRequest getPartListRequest = new GetPartListRequest();
		getPartListRequest.Body = new GetPartListRequestBody();
		return ((CommercialSoap)this).GetPartListAsync(getPartListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetQuanKalaResponse CommercialSoap.GetQuanKala(GetQuanKalaRequest request)
	{
		return base.Channel.GetQuanKala(request);
	}

	public string GetQuanKala(string Date1, string Date2, string CodeKala, string Store)
	{
		GetQuanKalaRequest getQuanKalaRequest = new GetQuanKalaRequest();
		getQuanKalaRequest.Body = new GetQuanKalaRequestBody();
		getQuanKalaRequest.Body.Date1 = Date1;
		getQuanKalaRequest.Body.Date2 = Date2;
		getQuanKalaRequest.Body.CodeKala = CodeKala;
		getQuanKalaRequest.Body.Store = Store;
		return ((CommercialSoap)this).GetQuanKala(getQuanKalaRequest).Body.GetQuanKalaResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetQuanKalaResponse> CommercialSoap.GetQuanKalaAsync(GetQuanKalaRequest request)
	{
		return base.Channel.GetQuanKalaAsync(request);
	}

	public Task<GetQuanKalaResponse> GetQuanKalaAsync(string Date1, string Date2, string CodeKala, string Store)
	{
		GetQuanKalaRequest getQuanKalaRequest = new GetQuanKalaRequest();
		getQuanKalaRequest.Body = new GetQuanKalaRequestBody();
		getQuanKalaRequest.Body.Date1 = Date1;
		getQuanKalaRequest.Body.Date2 = Date2;
		getQuanKalaRequest.Body.CodeKala = CodeKala;
		getQuanKalaRequest.Body.Store = Store;
		return ((CommercialSoap)this).GetQuanKalaAsync(getQuanKalaRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ViewOutputResponse CommercialSoap.ViewOutput(ViewOutputRequest request)
	{
		return base.Channel.ViewOutput(request);
	}

	public string ViewOutput(string Date1, string Date2)
	{
		ViewOutputRequest viewOutputRequest = new ViewOutputRequest();
		viewOutputRequest.Body = new ViewOutputRequestBody();
		viewOutputRequest.Body.Date1 = Date1;
		viewOutputRequest.Body.Date2 = Date2;
		return ((CommercialSoap)this).ViewOutput(viewOutputRequest).Body.ViewOutputResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ViewOutputResponse> CommercialSoap.ViewOutputAsync(ViewOutputRequest request)
	{
		return base.Channel.ViewOutputAsync(request);
	}

	public Task<ViewOutputResponse> ViewOutputAsync(string Date1, string Date2)
	{
		ViewOutputRequest viewOutputRequest = new ViewOutputRequest();
		viewOutputRequest.Body = new ViewOutputRequestBody();
		viewOutputRequest.Body.Date1 = Date1;
		viewOutputRequest.Body.Date2 = Date2;
		return ((CommercialSoap)this).ViewOutputAsync(viewOutputRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetDaryaftResponse CommercialSoap.GetDaryaft(GetDaryaftRequest request)
	{
		return base.Channel.GetDaryaft(request);
	}

	public string GetDaryaft(string Date1, string Date2)
	{
		GetDaryaftRequest getDaryaftRequest = new GetDaryaftRequest();
		getDaryaftRequest.Body = new GetDaryaftRequestBody();
		getDaryaftRequest.Body.Date1 = Date1;
		getDaryaftRequest.Body.Date2 = Date2;
		return ((CommercialSoap)this).GetDaryaft(getDaryaftRequest).Body.GetDaryaftResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetDaryaftResponse> CommercialSoap.GetDaryaftAsync(GetDaryaftRequest request)
	{
		return base.Channel.GetDaryaftAsync(request);
	}

	public Task<GetDaryaftResponse> GetDaryaftAsync(string Date1, string Date2)
	{
		GetDaryaftRequest getDaryaftRequest = new GetDaryaftRequest();
		getDaryaftRequest.Body = new GetDaryaftRequestBody();
		getDaryaftRequest.Body.Date1 = Date1;
		getDaryaftRequest.Body.Date2 = Date2;
		return ((CommercialSoap)this).GetDaryaftAsync(getDaryaftRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetLastCodeCustomerResponse CommercialSoap.GetLastCodeCustomer(GetLastCodeCustomerRequest request)
	{
		return base.Channel.GetLastCodeCustomer(request);
	}

	public string GetLastCodeCustomer()
	{
		GetLastCodeCustomerRequest getLastCodeCustomerRequest = new GetLastCodeCustomerRequest();
		getLastCodeCustomerRequest.Body = new GetLastCodeCustomerRequestBody();
		return ((CommercialSoap)this).GetLastCodeCustomer(getLastCodeCustomerRequest).Body.GetLastCodeCustomerResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetLastCodeCustomerResponse> CommercialSoap.GetLastCodeCustomerAsync(GetLastCodeCustomerRequest request)
	{
		return base.Channel.GetLastCodeCustomerAsync(request);
	}

	public Task<GetLastCodeCustomerResponse> GetLastCodeCustomerAsync()
	{
		GetLastCodeCustomerRequest getLastCodeCustomerRequest = new GetLastCodeCustomerRequest();
		getLastCodeCustomerRequest.Body = new GetLastCodeCustomerRequestBody();
		return ((CommercialSoap)this).GetLastCodeCustomerAsync(getLastCodeCustomerRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetLastidPishFactorResponse CommercialSoap.GetLastidPishFactor(GetLastidPishFactorRequest request)
	{
		return base.Channel.GetLastidPishFactor(request);
	}

	public string GetLastidPishFactor()
	{
		GetLastidPishFactorRequest getLastidPishFactorRequest = new GetLastidPishFactorRequest();
		getLastidPishFactorRequest.Body = new GetLastidPishFactorRequestBody();
		return ((CommercialSoap)this).GetLastidPishFactor(getLastidPishFactorRequest).Body.GetLastidPishFactorResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetLastidPishFactorResponse> CommercialSoap.GetLastidPishFactorAsync(GetLastidPishFactorRequest request)
	{
		return base.Channel.GetLastidPishFactorAsync(request);
	}

	public Task<GetLastidPishFactorResponse> GetLastidPishFactorAsync()
	{
		GetLastidPishFactorRequest getLastidPishFactorRequest = new GetLastidPishFactorRequest();
		getLastidPishFactorRequest.Body = new GetLastidPishFactorRequestBody();
		return ((CommercialSoap)this).GetLastidPishFactorAsync(getLastidPishFactorRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetLastDocNoOutPutResponse CommercialSoap.GetLastDocNoOutPut(GetLastDocNoOutPutRequest request)
	{
		return base.Channel.GetLastDocNoOutPut(request);
	}

	public string GetLastDocNoOutPut(string Store)
	{
		GetLastDocNoOutPutRequest getLastDocNoOutPutRequest = new GetLastDocNoOutPutRequest();
		getLastDocNoOutPutRequest.Body = new GetLastDocNoOutPutRequestBody();
		getLastDocNoOutPutRequest.Body.Store = Store;
		return ((CommercialSoap)this).GetLastDocNoOutPut(getLastDocNoOutPutRequest).Body.GetLastDocNoOutPutResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetLastDocNoOutPutResponse> CommercialSoap.GetLastDocNoOutPutAsync(GetLastDocNoOutPutRequest request)
	{
		return base.Channel.GetLastDocNoOutPutAsync(request);
	}

	public Task<GetLastDocNoOutPutResponse> GetLastDocNoOutPutAsync(string Store)
	{
		GetLastDocNoOutPutRequest getLastDocNoOutPutRequest = new GetLastDocNoOutPutRequest();
		getLastDocNoOutPutRequest.Body = new GetLastDocNoOutPutRequestBody();
		getLastDocNoOutPutRequest.Body.Store = Store;
		return ((CommercialSoap)this).GetLastDocNoOutPutAsync(getLastDocNoOutPutRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_LastResidnoResponse CommercialSoap.Idealsp_LastResidno(Idealsp_LastResidnoRequest request)
	{
		return base.Channel.Idealsp_LastResidno(request);
	}

	public string Idealsp_LastResidno()
	{
		Idealsp_LastResidnoRequest idealsp_LastResidnoRequest = new Idealsp_LastResidnoRequest();
		idealsp_LastResidnoRequest.Body = new Idealsp_LastResidnoRequestBody();
		return ((CommercialSoap)this).Idealsp_LastResidno(idealsp_LastResidnoRequest).Body.Idealsp_LastResidnoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_LastResidnoResponse> CommercialSoap.Idealsp_LastResidnoAsync(Idealsp_LastResidnoRequest request)
	{
		return base.Channel.Idealsp_LastResidnoAsync(request);
	}

	public Task<Idealsp_LastResidnoResponse> Idealsp_LastResidnoAsync()
	{
		Idealsp_LastResidnoRequest idealsp_LastResidnoRequest = new Idealsp_LastResidnoRequest();
		idealsp_LastResidnoRequest.Body = new Idealsp_LastResidnoRequestBody();
		return ((CommercialSoap)this).Idealsp_LastResidnoAsync(idealsp_LastResidnoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Idealsp_MandeHesabResponse CommercialSoap.Idealsp_MandeHesab(Idealsp_MandeHesabRequest request)
	{
		return base.Channel.Idealsp_MandeHesab(request);
	}

	public string Idealsp_MandeHesab(string IdCustomer)
	{
		Idealsp_MandeHesabRequest idealsp_MandeHesabRequest = new Idealsp_MandeHesabRequest();
		idealsp_MandeHesabRequest.Body = new Idealsp_MandeHesabRequestBody();
		idealsp_MandeHesabRequest.Body.IdCustomer = IdCustomer;
		return ((CommercialSoap)this).Idealsp_MandeHesab(idealsp_MandeHesabRequest).Body.Idealsp_MandeHesabResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<Idealsp_MandeHesabResponse> CommercialSoap.Idealsp_MandeHesabAsync(Idealsp_MandeHesabRequest request)
	{
		return base.Channel.Idealsp_MandeHesabAsync(request);
	}

	public Task<Idealsp_MandeHesabResponse> Idealsp_MandeHesabAsync(string IdCustomer)
	{
		Idealsp_MandeHesabRequest idealsp_MandeHesabRequest = new Idealsp_MandeHesabRequest();
		idealsp_MandeHesabRequest.Body = new Idealsp_MandeHesabRequestBody();
		idealsp_MandeHesabRequest.Body.IdCustomer = IdCustomer;
		return ((CommercialSoap)this).Idealsp_MandeHesabAsync(idealsp_MandeHesabRequest);
	}
}
