using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.LinkPayvast;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class AccountingServiceSoapClient : ClientBase<AccountingServiceSoap>, AccountingServiceSoap
{
	public AccountingServiceSoapClient()
	{
	}

	public AccountingServiceSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public AccountingServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public AccountingServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public AccountingServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public int AddLegalCustomer(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory)
	{
		return base.Channel.AddLegalCustomer(fiscalPeriod, name, title, nationalIdentiry, phone, fax, cellPhone, management, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountId, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, owningType, taxCategory);
	}

	public Task<int> AddLegalCustomerAsync(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory)
	{
		return base.Channel.AddLegalCustomerAsync(fiscalPeriod, name, title, nationalIdentiry, phone, fax, cellPhone, management, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountId, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, owningType, taxCategory);
	}

	public int AddRealCustomer(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory)
	{
		return base.Channel.AddRealCustomer(fiscalPeriod, firstName, lastName, title, nationalCode, phone, fax, cellPhone, fatherName, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountId, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, taxCategory);
	}

	public Task<int> AddRealCustomerAsync(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory)
	{
		return base.Channel.AddRealCustomerAsync(fiscalPeriod, firstName, lastName, title, nationalCode, phone, fax, cellPhone, fatherName, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountId, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, taxCategory);
	}

	public int AddLegalCustomerWithSpecificFloatingAccountCode(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory)
	{
		return base.Channel.AddLegalCustomerWithSpecificFloatingAccountCode(fiscalPeriod, name, title, nationalIdentiry, phone, fax, cellPhone, management, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountCode, floatingAccountCode, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, owningType, taxCategory);
	}

	public Task<int> AddLegalCustomerWithSpecificFloatingAccountCodeAsync(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory)
	{
		return base.Channel.AddLegalCustomerWithSpecificFloatingAccountCodeAsync(fiscalPeriod, name, title, nationalIdentiry, phone, fax, cellPhone, management, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountCode, floatingAccountCode, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, owningType, taxCategory);
	}

	public int AddRealCustomerWithSpecificFloatingAccountCode(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory)
	{
		return base.Channel.AddRealCustomerWithSpecificFloatingAccountCode(fiscalPeriod, firstName, lastName, title, nationalCode, phone, fax, cellPhone, fatherName, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountCode, floatingAccountCode, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, taxCategory);
	}

	public Task<int> AddRealCustomerWithSpecificFloatingAccountCodeAsync(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory)
	{
		return base.Channel.AddRealCustomerWithSpecificFloatingAccountCodeAsync(fiscalPeriod, firstName, lastName, title, nationalCode, phone, fax, cellPhone, fatherName, registerationNumber, registrationLocation, registrationDate, subscriptionCode, zipCode, econumicCode, credit, email, address, description, parentAccountId, parentFloatingAccountCode, floatingAccountCode, type, floatingAccountId2, floatingAccountId3, floatingAccountId4, floatingAccountId5, userName, password, group, foreignNational, countryCode, provinceCode, cityCode, taxCategory);
	}

	public bool EditCustomer(int customerId, string userName, string password, string address, string zipCode, string phoneNo, string cellPhone, string faxNo, string eMail)
	{
		return base.Channel.EditCustomer(customerId, userName, password, address, zipCode, phoneNo, cellPhone, faxNo, eMail);
	}

	public Task<bool> EditCustomerAsync(int customerId, string userName, string password, string address, string zipCode, string phoneNo, string cellPhone, string faxNo, string eMail)
	{
		return base.Channel.EditCustomerAsync(customerId, userName, password, address, zipCode, phoneNo, cellPhone, faxNo, eMail);
	}

	public int GetCustomerIdByAccountId(string AccountId, int FPId)
	{
		return base.Channel.GetCustomerIdByAccountId(AccountId, FPId);
	}

	public Task<int> GetCustomerIdByAccountIdAsync(string AccountId, int FPId)
	{
		return base.Channel.GetCustomerIdByAccountIdAsync(AccountId, FPId);
	}

	public int GetCustomerIdByTCode(string TCode, int FPId)
	{
		return base.Channel.GetCustomerIdByTCode(TCode, FPId);
	}

	public Task<int> GetCustomerIdByTCodeAsync(string TCode, int FPId)
	{
		return base.Channel.GetCustomerIdByTCodeAsync(TCode, FPId);
	}

	public int GetCustomerIdByNationalCode(string NationalCode)
	{
		return base.Channel.GetCustomerIdByNationalCode(NationalCode);
	}

	public Task<int> GetCustomerIdByNationalCodeAsync(string NationalCode)
	{
		return base.Channel.GetCustomerIdByNationalCodeAsync(NationalCode);
	}

	public int GetCustomerIdByCellPhone(string CellPhone)
	{
		return base.Channel.GetCustomerIdByCellPhone(CellPhone);
	}

	public Task<int> GetCustomerIdByCellPhoneAsync(string CellPhone)
	{
		return base.Channel.GetCustomerIdByCellPhoneAsync(CellPhone);
	}

	public Customer GetCustomerInfo(int customerId, string userName, string password)
	{
		return base.Channel.GetCustomerInfo(customerId, userName, password);
	}

	public Task<Customer> GetCustomerInfoAsync(int customerId, string userName, string password)
	{
		return base.Channel.GetCustomerInfoAsync(customerId, userName, password);
	}

	public Customer[] GetCustomersInfoByMainType(int mainType, string userName, string password)
	{
		return base.Channel.GetCustomersInfoByMainType(mainType, userName, password);
	}

	public Task<Customer[]> GetCustomersInfoByMainTypeAsync(int mainType, string userName, string password)
	{
		return base.Channel.GetCustomersInfoByMainTypeAsync(mainType, userName, password);
	}

	public Customer[] GetAllCustomersInfo(string userName, string password)
	{
		return base.Channel.GetAllCustomersInfo(userName, password);
	}

	public Task<Customer[]> GetAllCustomersInfoAsync(string userName, string password)
	{
		return base.Channel.GetAllCustomersInfoAsync(userName, password);
	}

	public CustomerType[] GetCustomerTypes()
	{
		return base.Channel.GetCustomerTypes();
	}

	public Task<CustomerType[]> GetCustomerTypesAsync()
	{
		return base.Channel.GetCustomerTypesAsync();
	}

	public CustomerCredit GetCustomerCreditInfo(int customerId, DateTime date, string userName, string password)
	{
		return base.Channel.GetCustomerCreditInfo(customerId, date, userName, password);
	}

	public Task<CustomerCredit> GetCustomerCreditInfoAsync(int customerId, DateTime date, string userName, string password)
	{
		return base.Channel.GetCustomerCreditInfoAsync(customerId, date, userName, password);
	}

	public int CreateFactor(DateTime date, int customerId, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string description, string customString1, int SC, int BrokerId, decimal Discount, string userName, string password, int factorType, string referenceNo, DateTime payRcvDate, int creatorUserId)
	{
		return base.Channel.CreateFactor(date, customerId, account, floatingAccount1, floatingAccount2, floatingAccount3, description, customString1, SC, BrokerId, Discount, userName, password, factorType, referenceNo, payRcvDate, creatorUserId);
	}

	public Task<int> CreateFactorAsync(DateTime date, int customerId, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string description, string customString1, int SC, int BrokerId, decimal Discount, string userName, string password, int factorType, string referenceNo, DateTime payRcvDate, int creatorUserId)
	{
		return base.Channel.CreateFactorAsync(date, customerId, account, floatingAccount1, floatingAccount2, floatingAccount3, description, customString1, SC, BrokerId, Discount, userName, password, factorType, referenceNo, payRcvDate, creatorUserId);
	}

	public int AddArticle(int factorId, int merchandiseId, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticle(factorId, merchandiseId, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public Task<int> AddArticleAsync(int factorId, int merchandiseId, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticleAsync(factorId, merchandiseId, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public int AddArticleByCode(int factorId, string merchandiseCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticleByCode(factorId, merchandiseCode, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public Task<int> AddArticleByCodeAsync(int factorId, string merchandiseCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticleByCodeAsync(factorId, merchandiseCode, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public int AddArticleByBarCode(int factorId, string merchandiseBarCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticleByBarCode(factorId, merchandiseBarCode, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public Task<int> AddArticleByBarCodeAsync(int factorId, string merchandiseBarCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticleByBarCodeAsync(factorId, merchandiseBarCode, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public int AddArticleByTechNum(int factorId, string merchandiseTechNum, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticleByTechNum(factorId, merchandiseTechNum, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public Task<int> AddArticleByTechNumAsync(int factorId, string merchandiseTechNum, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC)
	{
		return base.Channel.AddArticleByTechNumAsync(factorId, merchandiseTechNum, amount, unitId, unitPrice, auxAmount, vTax, discount, stockRoomId, description, ACC);
	}

	public bool AddCost(int factorId, decimal amount, bool isIncremental, string description, int EKTypeCode)
	{
		return base.Channel.AddCost(factorId, amount, isIncremental, description, EKTypeCode);
	}

	public Task<bool> AddCostAsync(int factorId, decimal amount, bool isIncremental, string description, int EKTypeCode)
	{
		return base.Channel.AddCostAsync(factorId, amount, isIncremental, description, EKTypeCode);
	}

	public bool AddFactorSerial(int factorId, int factorArticleId, string serial, DateTime expiryDate)
	{
		return base.Channel.AddFactorSerial(factorId, factorArticleId, serial, expiryDate);
	}

	public Task<bool> AddFactorSerialAsync(int factorId, int factorArticleId, string serial, DateTime expiryDate)
	{
		return base.Channel.AddFactorSerialAsync(factorId, factorArticleId, serial, expiryDate);
	}

	public bool AddFactorOtherInfo(int factorId, string customString1, string customString2, string customString3, string customString4, string customString5, decimal customValue1, decimal customValue2, decimal customValue3, int customValue4, decimal customValue5, DateTime customDate1, DateTime customDate2, int sharingMethod)
	{
		return base.Channel.AddFactorOtherInfo(factorId, customString1, customString2, customString3, customString4, customString5, customValue1, customValue2, customValue3, customValue4, customValue5, customDate1, customDate2, sharingMethod);
	}

	public Task<bool> AddFactorOtherInfoAsync(int factorId, string customString1, string customString2, string customString3, string customString4, string customString5, decimal customValue1, decimal customValue2, decimal customValue3, int customValue4, decimal customValue5, DateTime customDate1, DateTime customDate2, int sharingMethod)
	{
		return base.Channel.AddFactorOtherInfoAsync(factorId, customString1, customString2, customString3, customString4, customString5, customValue1, customValue2, customValue3, customValue4, customValue5, customDate1, customDate2, sharingMethod);
	}

	public AddMethodsResult CommitFactor(int factorId, int fiscalPeriod)
	{
		return base.Channel.CommitFactor(factorId, fiscalPeriod);
	}

	public Task<AddMethodsResult> CommitFactorAsync(int factorId, int fiscalPeriod)
	{
		return base.Channel.CommitFactorAsync(factorId, fiscalPeriod);
	}

	public AddMethodsResultExtended CommitFactorWithAutoReceiptOrder(int factorId, int fiscalPeriod)
	{
		return base.Channel.CommitFactorWithAutoReceiptOrder(factorId, fiscalPeriod);
	}

	public Task<AddMethodsResultExtended> CommitFactorWithAutoReceiptOrderAsync(int factorId, int fiscalPeriod)
	{
		return base.Channel.CommitFactorWithAutoReceiptOrderAsync(factorId, fiscalPeriod);
	}

	public SPFactor[] GetFactorsList(string userName, string password, DateTime fromDate, DateTime toDate, int factorType)
	{
		return base.Channel.GetFactorsList(userName, password, fromDate, toDate, factorType);
	}

	public Task<SPFactor[]> GetFactorsListAsync(string userName, string password, DateTime fromDate, DateTime toDate, int factorType)
	{
		return base.Channel.GetFactorsListAsync(userName, password, fromDate, toDate, factorType);
	}

	public SPFactor[] GetFactorsListByCustomer(string userName, string password, DateTime fromDate, DateTime toDate, int customerId, int factorType)
	{
		return base.Channel.GetFactorsListByCustomer(userName, password, fromDate, toDate, customerId, factorType);
	}

	public Task<SPFactor[]> GetFactorsListByCustomerAsync(string userName, string password, DateTime fromDate, DateTime toDate, int customerId, int factorType)
	{
		return base.Channel.GetFactorsListByCustomerAsync(userName, password, fromDate, toDate, customerId, factorType);
	}

	public int CreateReceiptOrder(int type, DateTime date, int reference, int stockRoom, string description, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, int customerId, string userName, string password)
	{
		return base.Channel.CreateReceiptOrder(type, date, reference, stockRoom, description, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5, customerId, userName, password);
	}

	public Task<int> CreateReceiptOrderAsync(int type, DateTime date, int reference, int stockRoom, string description, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, int customerId, string userName, string password)
	{
		return base.Channel.CreateReceiptOrderAsync(type, date, reference, stockRoom, description, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5, customerId, userName, password);
	}

	public int AddReceiptOrderArticle(int receiptOrderId, int merchandiseId, decimal amount, int unitId, int unitPrice, decimal auxAmount, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description)
	{
		return base.Channel.AddReceiptOrderArticle(receiptOrderId, merchandiseId, amount, unitId, unitPrice, auxAmount, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5, description);
	}

	public Task<int> AddReceiptOrderArticleAsync(int receiptOrderId, int merchandiseId, decimal amount, int unitId, int unitPrice, decimal auxAmount, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description)
	{
		return base.Channel.AddReceiptOrderArticleAsync(receiptOrderId, merchandiseId, amount, unitId, unitPrice, auxAmount, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5, description);
	}

	public bool AddReceiptOrderSerial(int receiptOrderId, int receiptOrderArticleId, string serial, DateTime expiryDate)
	{
		return base.Channel.AddReceiptOrderSerial(receiptOrderId, receiptOrderArticleId, serial, expiryDate);
	}

	public Task<bool> AddReceiptOrderSerialAsync(int receiptOrderId, int receiptOrderArticleId, string serial, DateTime expiryDate)
	{
		return base.Channel.AddReceiptOrderSerialAsync(receiptOrderId, receiptOrderArticleId, serial, expiryDate);
	}

	public AddMethodsResult CommitReceiptOrder(int receiptOrderId, int fiscalPeriod)
	{
		return base.Channel.CommitReceiptOrder(receiptOrderId, fiscalPeriod);
	}

	public Task<AddMethodsResult> CommitReceiptOrderAsync(int receiptOrderId, int fiscalPeriod)
	{
		return base.Channel.CommitReceiptOrderAsync(receiptOrderId, fiscalPeriod);
	}

	public int AddMerchandise(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId)
	{
		return base.Channel.AddMerchandise(parentCode, name, technicalNumber, unitId, fiscalPeriod, userName, password, valuationId);
	}

	public Task<int> AddMerchandiseAsync(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId)
	{
		return base.Channel.AddMerchandiseAsync(parentCode, name, technicalNumber, unitId, fiscalPeriod, userName, password, valuationId);
	}

	public string AddMerchandiseReturnsCode(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId)
	{
		return base.Channel.AddMerchandiseReturnsCode(parentCode, name, technicalNumber, unitId, fiscalPeriod, userName, password, valuationId);
	}

	public Task<string> AddMerchandiseReturnsCodeAsync(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId)
	{
		return base.Channel.AddMerchandiseReturnsCodeAsync(parentCode, name, technicalNumber, unitId, fiscalPeriod, userName, password, valuationId);
	}

	public double GetMerchandiseRemainForAllStockRooms(string merchandiseCode, DateTime date, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseRemainForAllStockRooms(merchandiseCode, date, fiscalPeriod);
	}

	public Task<double> GetMerchandiseRemainForAllStockRoomsAsync(string merchandiseCode, DateTime date, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseRemainForAllStockRoomsAsync(merchandiseCode, date, fiscalPeriod);
	}

	public double GetMerchandiseRemain(string merchandiseCode, DateTime date, int fiscalPeriod, int stockRoomId)
	{
		return base.Channel.GetMerchandiseRemain(merchandiseCode, date, fiscalPeriod, stockRoomId);
	}

	public Task<double> GetMerchandiseRemainAsync(string merchandiseCode, DateTime date, int fiscalPeriod, int stockRoomId)
	{
		return base.Channel.GetMerchandiseRemainAsync(merchandiseCode, date, fiscalPeriod, stockRoomId);
	}

	public double GetMerchandiseLastPriceForSale(string merchandiseCode, int priceType, DateTime date, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseLastPriceForSale(merchandiseCode, priceType, date, fiscalPeriod);
	}

	public Task<double> GetMerchandiseLastPriceForSaleAsync(string merchandiseCode, int priceType, DateTime date, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseLastPriceForSaleAsync(merchandiseCode, priceType, date, fiscalPeriod);
	}

	public double GetMerchandiseLastPriceForSaleByCustomer(string merchandiseCode, int customerId, DateTime date, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseLastPriceForSaleByCustomer(merchandiseCode, customerId, date, fiscalPeriod);
	}

	public Task<double> GetMerchandiseLastPriceForSaleByCustomerAsync(string merchandiseCode, int customerId, DateTime date, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseLastPriceForSaleByCustomerAsync(merchandiseCode, customerId, date, fiscalPeriod);
	}

	public double GetMerchandiseLastBuyRate(string merchandiseCode)
	{
		return base.Channel.GetMerchandiseLastBuyRate(merchandiseCode);
	}

	public Task<double> GetMerchandiseLastBuyRateAsync(string merchandiseCode)
	{
		return base.Channel.GetMerchandiseLastBuyRateAsync(merchandiseCode);
	}

	public double GetMerchandiseIdByBarCode(string barCode, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseIdByBarCode(barCode, fiscalPeriod);
	}

	public Task<double> GetMerchandiseIdByBarCodeAsync(string barCode, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseIdByBarCodeAsync(barCode, fiscalPeriod);
	}

	public double GetMerchandiseIdByTechNum(string techNum, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseIdByTechNum(techNum, fiscalPeriod);
	}

	public Task<double> GetMerchandiseIdByTechNumAsync(string techNum, int fiscalPeriod)
	{
		return base.Channel.GetMerchandiseIdByTechNumAsync(techNum, fiscalPeriod);
	}

	public int AddMerchandiseUnit(string name, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.AddMerchandiseUnit(name, fiscalPeriod, userName, password);
	}

	public Task<int> AddMerchandiseUnitAsync(string name, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.AddMerchandiseUnitAsync(name, fiscalPeriod, userName, password);
	}

	public Merchandise[] GetMerchandiseList(string userName, string password, int fiscalPeriod, int merchandiseId)
	{
		return base.Channel.GetMerchandiseList(userName, password, fiscalPeriod, merchandiseId);
	}

	public Task<Merchandise[]> GetMerchandiseListAsync(string userName, string password, int fiscalPeriod, int merchandiseId)
	{
		return base.Channel.GetMerchandiseListAsync(userName, password, fiscalPeriod, merchandiseId);
	}

	public MerchandisePrice[] GetMerchandisePriceList(int operationType, int fiscalPeriod, DateTime date, string userName, string password)
	{
		return base.Channel.GetMerchandisePriceList(operationType, fiscalPeriod, date, userName, password);
	}

	public Task<MerchandisePrice[]> GetMerchandisePriceListAsync(int operationType, int fiscalPeriod, DateTime date, string userName, string password)
	{
		return base.Channel.GetMerchandisePriceListAsync(operationType, fiscalPeriod, date, userName, password);
	}

	public Stock[] GetStockList(int fiscalPeriod, DateTime date, string userName, string password, bool includeProforma)
	{
		return base.Channel.GetStockList(fiscalPeriod, date, userName, password, includeProforma);
	}

	public Task<Stock[]> GetStockListAsync(int fiscalPeriod, DateTime date, string userName, string password, bool includeProforma)
	{
		return base.Channel.GetStockListAsync(fiscalPeriod, date, userName, password, includeProforma);
	}

	public StockRoom[] GetStockRoomsInfo(string userName, string password, int stockRoomId, int fiscalPeriod)
	{
		return base.Channel.GetStockRoomsInfo(userName, password, stockRoomId, fiscalPeriod);
	}

	public Task<StockRoom[]> GetStockRoomsInfoAsync(string userName, string password, int stockRoomId, int fiscalPeriod)
	{
		return base.Channel.GetStockRoomsInfoAsync(userName, password, stockRoomId, fiscalPeriod);
	}

	public int CreateAccountingTransaction(DateTime date, string description, string userName, string password)
	{
		return base.Channel.CreateAccountingTransaction(date, description, userName, password);
	}

	public Task<int> CreateAccountingTransactionAsync(DateTime date, string description, string userName, string password)
	{
		return base.Channel.CreateAccountingTransactionAsync(date, description, userName, password);
	}

	public bool AddAccountingArticle(int transactionId, double debit, double credit, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description)
	{
		return base.Channel.AddAccountingArticle(transactionId, debit, credit, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5, description);
	}

	public Task<bool> AddAccountingArticleAsync(int transactionId, double debit, double credit, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description)
	{
		return base.Channel.AddAccountingArticleAsync(transactionId, debit, credit, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5, description);
	}

	public AddMethodsResult CommitAccountingTransaction(int transactionId, int fiscalPeriod)
	{
		return base.Channel.CommitAccountingTransaction(transactionId, fiscalPeriod);
	}

	public Task<AddMethodsResult> CommitAccountingTransactionAsync(int transactionId, int fiscalPeriod)
	{
		return base.Channel.CommitAccountingTransactionAsync(transactionId, fiscalPeriod);
	}

	public double GetAccountBalance(int fiscalPeriod, int departmentCode, DateTime date, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5)
	{
		return base.Channel.GetAccountBalance(fiscalPeriod, departmentCode, date, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5);
	}

	public Task<double> GetAccountBalanceAsync(int fiscalPeriod, int departmentCode, DateTime date, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5)
	{
		return base.Channel.GetAccountBalanceAsync(fiscalPeriod, departmentCode, date, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5);
	}

	public AccountTransaction[] GetAccountTransactions(int fiscalPeriod, DateTime startDate, DateTime endDate, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5)
	{
		return base.Channel.GetAccountTransactions(fiscalPeriod, startDate, endDate, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5);
	}

	public Task<AccountTransaction[]> GetAccountTransactionsAsync(int fiscalPeriod, DateTime startDate, DateTime endDate, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5)
	{
		return base.Channel.GetAccountTransactionsAsync(fiscalPeriod, startDate, endDate, account, floatingAccount1, floatingAccount2, floatingAccount3, floatingAccount4, floatingAccount5);
	}

	public AddMethodsResultWithCode AddAccount(string parentCode, int fiscalPeriod, string name, string userName, string password)
	{
		return base.Channel.AddAccount(parentCode, fiscalPeriod, name, userName, password);
	}

	public Task<AddMethodsResultWithCode> AddAccountAsync(string parentCode, int fiscalPeriod, string name, string userName, string password)
	{
		return base.Channel.AddAccountAsync(parentCode, fiscalPeriod, name, userName, password);
	}

	public AddMethodsResultWithCode AddFloatingAccountHead(string parentCode, int fiscalPeriod, string name, int codeLength, int accountLevel, string userName, string password)
	{
		return base.Channel.AddFloatingAccountHead(parentCode, fiscalPeriod, name, codeLength, accountLevel, userName, password);
	}

	public Task<AddMethodsResultWithCode> AddFloatingAccountHeadAsync(string parentCode, int fiscalPeriod, string name, int codeLength, int accountLevel, string userName, string password)
	{
		return base.Channel.AddFloatingAccountHeadAsync(parentCode, fiscalPeriod, name, codeLength, accountLevel, userName, password);
	}

	public AddMethodsResultWithCode AddFloatingAccount(string parentCode, int fiscalPeriod, string name, string userName, string password)
	{
		return base.Channel.AddFloatingAccount(parentCode, fiscalPeriod, name, userName, password);
	}

	public Task<AddMethodsResultWithCode> AddFloatingAccountAsync(string parentCode, int fiscalPeriod, string name, string userName, string password)
	{
		return base.Channel.AddFloatingAccountAsync(parentCode, fiscalPeriod, name, userName, password);
	}

	public AddMethodsResultWithCode AddFloatingAccountWithSpecifiedCode(string parentCode, string code, int fiscalPeriod, string name, string userName, string password)
	{
		return base.Channel.AddFloatingAccountWithSpecifiedCode(parentCode, code, fiscalPeriod, name, userName, password);
	}

	public Task<AddMethodsResultWithCode> AddFloatingAccountWithSpecifiedCodeAsync(string parentCode, string code, int fiscalPeriod, string name, string userName, string password)
	{
		return base.Channel.AddFloatingAccountWithSpecifiedCodeAsync(parentCode, code, fiscalPeriod, name, userName, password);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetFiscalPeriodIdResponse AccountingServiceSoap.GetFiscalPeriodId(GetFiscalPeriodIdRequest request)
	{
		return base.Channel.GetFiscalPeriodId(request);
	}

	public int? GetFiscalPeriodId(DateTime? date)
	{
		GetFiscalPeriodIdRequest getFiscalPeriodIdRequest = new GetFiscalPeriodIdRequest();
		getFiscalPeriodIdRequest.date = date;
		return ((AccountingServiceSoap)this).GetFiscalPeriodId(getFiscalPeriodIdRequest).GetFiscalPeriodIdResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetFiscalPeriodIdResponse> AccountingServiceSoap.GetFiscalPeriodIdAsync(GetFiscalPeriodIdRequest request)
	{
		return base.Channel.GetFiscalPeriodIdAsync(request);
	}

	public Task<GetFiscalPeriodIdResponse> GetFiscalPeriodIdAsync(DateTime? date)
	{
		GetFiscalPeriodIdRequest getFiscalPeriodIdRequest = new GetFiscalPeriodIdRequest();
		getFiscalPeriodIdRequest.date = date;
		return ((AccountingServiceSoap)this).GetFiscalPeriodIdAsync(getFiscalPeriodIdRequest);
	}

	public int CreatePayRCVforPay(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforPay(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public Task<int> CreatePayRCVforPayAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforPayAsync(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public int CreatePayRCVforReceive(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforReceive(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public Task<int> CreatePayRCVforReceiveAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforReceiveAsync(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public int CreatePayRCVforCurrencyPurchase(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforCurrencyPurchase(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public Task<int> CreatePayRCVforCurrencyPurchaseAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforCurrencyPurchaseAsync(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public int CreatePayRCVforCurrencySales(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforCurrencySales(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public Task<int> CreatePayRCVforCurrencySalesAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password)
	{
		return base.Channel.CreatePayRCVforCurrencySalesAsync(PayType, PDate, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, PDesc, RefNo, FPId, Cash, CustomerId, PCValue, userName, password);
	}

	public bool AddCheck(int PayRCVId, string CheckNo, decimal CValue, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, DateTime CDate, DateTime RcptDate, int SType, string CDesc, decimal CurrencyVal, int CurrencyId)
	{
		return base.Channel.AddCheck(PayRCVId, CheckNo, CValue, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, CDate, RcptDate, SType, CDesc, CurrencyVal, CurrencyId);
	}

	public Task<bool> AddCheckAsync(int PayRCVId, string CheckNo, decimal CValue, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, DateTime CDate, DateTime RcptDate, int SType, string CDesc, decimal CurrencyVal, int CurrencyId)
	{
		return base.Channel.AddCheckAsync(PayRCVId, CheckNo, CValue, RcvrAcc, RcvrAB0, RcvrAB1, RcvrAB2, RcvrAB3, RcvrAB4, CDate, RcptDate, SType, CDesc, CurrencyVal, CurrencyId);
	}

	public AddMethodsResult CommitPayRCV(int PayRCVId, int FiscalPeriod)
	{
		return base.Channel.CommitPayRCV(PayRCVId, FiscalPeriod);
	}

	public Task<AddMethodsResult> CommitPayRCVAsync(int PayRCVId, int FiscalPeriod)
	{
		return base.Channel.CommitPayRCVAsync(PayRCVId, FiscalPeriod);
	}

	public Check[] GetRCVChecksInfoByStatus(int checkStatus, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.GetRCVChecksInfoByStatus(checkStatus, fiscalPeriod, userName, password);
	}

	public Task<Check[]> GetRCVChecksInfoByStatusAsync(int checkStatus, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.GetRCVChecksInfoByStatusAsync(checkStatus, fiscalPeriod, userName, password);
	}

	public Check[] GetRCVChecksInfoByCustomer(int customer, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.GetRCVChecksInfoByCustomer(customer, fiscalPeriod, userName, password);
	}

	public Task<Check[]> GetRCVChecksInfoByCustomerAsync(int customer, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.GetRCVChecksInfoByCustomerAsync(customer, fiscalPeriod, userName, password);
	}

	public Check[] GetPAYChecksInfoByCustomer(int customer, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.GetPAYChecksInfoByCustomer(customer, fiscalPeriod, userName, password);
	}

	public Task<Check[]> GetPAYChecksInfoByCustomerAsync(int customer, int fiscalPeriod, string userName, string password)
	{
		return base.Channel.GetPAYChecksInfoByCustomerAsync(customer, fiscalPeriod, userName, password);
	}
}
