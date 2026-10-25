using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.LinkPayvast;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "LinkPayvast.AccountingServiceSoap")]
public interface AccountingServiceSoap
{
	[OperationContract(Action = "http://tempuri.org/AddLegalCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddLegalCustomer(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/AddLegalCustomer", ReplyAction = "*")]
	Task<int> AddLegalCustomerAsync(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/AddRealCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddRealCustomer(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/AddRealCustomer", ReplyAction = "*")]
	Task<int> AddRealCustomerAsync(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountId, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/AddLegalCustomerWithSpecificFloatingAccountCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddLegalCustomerWithSpecificFloatingAccountCode(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/AddLegalCustomerWithSpecificFloatingAccountCode", ReplyAction = "*")]
	Task<int> AddLegalCustomerWithSpecificFloatingAccountCodeAsync(int fiscalPeriod, string name, string title, string nationalIdentiry, string phone, string fax, string cellPhone, string management, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int owningType, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/AddRealCustomerWithSpecificFloatingAccountCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddRealCustomerWithSpecificFloatingAccountCode(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/AddRealCustomerWithSpecificFloatingAccountCode", ReplyAction = "*")]
	Task<int> AddRealCustomerWithSpecificFloatingAccountCodeAsync(int fiscalPeriod, string firstName, string lastName, string title, string nationalCode, string phone, string fax, string cellPhone, string fatherName, string registerationNumber, int registrationLocation, DateTime registrationDate, string subscriptionCode, string zipCode, string econumicCode, double credit, string email, string address, string description, string parentAccountId, string parentFloatingAccountCode, string floatingAccountCode, int type, string floatingAccountId2, string floatingAccountId3, string floatingAccountId4, string floatingAccountId5, string userName, string password, int group, bool foreignNational, string countryCode, string provinceCode, string cityCode, int taxCategory);

	[OperationContract(Action = "http://tempuri.org/EditCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	bool EditCustomer(int customerId, string userName, string password, string address, string zipCode, string phoneNo, string cellPhone, string faxNo, string eMail);

	[OperationContract(Action = "http://tempuri.org/EditCustomer", ReplyAction = "*")]
	Task<bool> EditCustomerAsync(int customerId, string userName, string password, string address, string zipCode, string phoneNo, string cellPhone, string faxNo, string eMail);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByAccountId", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetCustomerIdByAccountId(string AccountId, int FPId);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByAccountId", ReplyAction = "*")]
	Task<int> GetCustomerIdByAccountIdAsync(string AccountId, int FPId);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByTCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetCustomerIdByTCode(string TCode, int FPId);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByTCode", ReplyAction = "*")]
	Task<int> GetCustomerIdByTCodeAsync(string TCode, int FPId);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByNationalCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetCustomerIdByNationalCode(string NationalCode);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByNationalCode", ReplyAction = "*")]
	Task<int> GetCustomerIdByNationalCodeAsync(string NationalCode);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByCellPhone", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int GetCustomerIdByCellPhone(string CellPhone);

	[OperationContract(Action = "http://tempuri.org/GetCustomerIdByCellPhone", ReplyAction = "*")]
	Task<int> GetCustomerIdByCellPhoneAsync(string CellPhone);

	[OperationContract(Action = "http://tempuri.org/GetCustomerInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Customer GetCustomerInfo(int customerId, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetCustomerInfo", ReplyAction = "*")]
	Task<Customer> GetCustomerInfoAsync(int customerId, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetCustomersInfoByMainType", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Customer[] GetCustomersInfoByMainType(int mainType, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetCustomersInfoByMainType", ReplyAction = "*")]
	Task<Customer[]> GetCustomersInfoByMainTypeAsync(int mainType, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetAllCustomersInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Customer[] GetAllCustomersInfo(string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetAllCustomersInfo", ReplyAction = "*")]
	Task<Customer[]> GetAllCustomersInfoAsync(string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetCustomerTypes", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	CustomerType[] GetCustomerTypes();

	[OperationContract(Action = "http://tempuri.org/GetCustomerTypes", ReplyAction = "*")]
	Task<CustomerType[]> GetCustomerTypesAsync();

	[OperationContract(Action = "http://tempuri.org/GetCustomerCreditInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	CustomerCredit GetCustomerCreditInfo(int customerId, DateTime date, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetCustomerCreditInfo", ReplyAction = "*")]
	Task<CustomerCredit> GetCustomerCreditInfoAsync(int customerId, DateTime date, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreateFactor", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int CreateFactor(DateTime date, int customerId, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string description, string customString1, int SC, int BrokerId, decimal Discount, string userName, string password, int factorType, string referenceNo, DateTime payRcvDate, int creatorUserId);

	[OperationContract(Action = "http://tempuri.org/CreateFactor", ReplyAction = "*")]
	Task<int> CreateFactorAsync(DateTime date, int customerId, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string description, string customString1, int SC, int BrokerId, decimal Discount, string userName, string password, int factorType, string referenceNo, DateTime payRcvDate, int creatorUserId);

	[OperationContract(Action = "http://tempuri.org/AddArticle", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddArticle(int factorId, int merchandiseId, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddArticle", ReplyAction = "*")]
	Task<int> AddArticleAsync(int factorId, int merchandiseId, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddArticleByCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddArticleByCode(int factorId, string merchandiseCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddArticleByCode", ReplyAction = "*")]
	Task<int> AddArticleByCodeAsync(int factorId, string merchandiseCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddArticleByBarCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddArticleByBarCode(int factorId, string merchandiseBarCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddArticleByBarCode", ReplyAction = "*")]
	Task<int> AddArticleByBarCodeAsync(int factorId, string merchandiseBarCode, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddArticleByTechNum", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddArticleByTechNum(int factorId, string merchandiseTechNum, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddArticleByTechNum", ReplyAction = "*")]
	Task<int> AddArticleByTechNumAsync(int factorId, string merchandiseTechNum, decimal amount, int unitId, decimal unitPrice, decimal auxAmount, decimal vTax, decimal discount, int stockRoomId, string description, string ACC);

	[OperationContract(Action = "http://tempuri.org/AddCost", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	bool AddCost(int factorId, decimal amount, bool isIncremental, string description, int EKTypeCode);

	[OperationContract(Action = "http://tempuri.org/AddCost", ReplyAction = "*")]
	Task<bool> AddCostAsync(int factorId, decimal amount, bool isIncremental, string description, int EKTypeCode);

	[OperationContract(Action = "http://tempuri.org/AddFactorSerial", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	bool AddFactorSerial(int factorId, int factorArticleId, string serial, DateTime expiryDate);

	[OperationContract(Action = "http://tempuri.org/AddFactorSerial", ReplyAction = "*")]
	Task<bool> AddFactorSerialAsync(int factorId, int factorArticleId, string serial, DateTime expiryDate);

	[OperationContract(Action = "http://tempuri.org/AddFactorOtherInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	bool AddFactorOtherInfo(int factorId, string customString1, string customString2, string customString3, string customString4, string customString5, decimal customValue1, decimal customValue2, decimal customValue3, int customValue4, decimal customValue5, DateTime customDate1, DateTime customDate2, int sharingMethod);

	[OperationContract(Action = "http://tempuri.org/AddFactorOtherInfo", ReplyAction = "*")]
	Task<bool> AddFactorOtherInfoAsync(int factorId, string customString1, string customString2, string customString3, string customString4, string customString5, decimal customValue1, decimal customValue2, decimal customValue3, int customValue4, decimal customValue5, DateTime customDate1, DateTime customDate2, int sharingMethod);

	[OperationContract(Action = "http://tempuri.org/CommitFactor", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResult CommitFactor(int factorId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/CommitFactor", ReplyAction = "*")]
	Task<AddMethodsResult> CommitFactorAsync(int factorId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/CommitFactorWithAutoReceiptOrder", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResultExtended CommitFactorWithAutoReceiptOrder(int factorId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/CommitFactorWithAutoReceiptOrder", ReplyAction = "*")]
	Task<AddMethodsResultExtended> CommitFactorWithAutoReceiptOrderAsync(int factorId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetFactorsList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	SPFactor[] GetFactorsList(string userName, string password, DateTime fromDate, DateTime toDate, int factorType);

	[OperationContract(Action = "http://tempuri.org/GetFactorsList", ReplyAction = "*")]
	Task<SPFactor[]> GetFactorsListAsync(string userName, string password, DateTime fromDate, DateTime toDate, int factorType);

	[OperationContract(Action = "http://tempuri.org/GetFactorsListByCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	SPFactor[] GetFactorsListByCustomer(string userName, string password, DateTime fromDate, DateTime toDate, int customerId, int factorType);

	[OperationContract(Action = "http://tempuri.org/GetFactorsListByCustomer", ReplyAction = "*")]
	Task<SPFactor[]> GetFactorsListByCustomerAsync(string userName, string password, DateTime fromDate, DateTime toDate, int customerId, int factorType);

	[OperationContract(Action = "http://tempuri.org/CreateReceiptOrder", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int CreateReceiptOrder(int type, DateTime date, int reference, int stockRoom, string description, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, int customerId, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreateReceiptOrder", ReplyAction = "*")]
	Task<int> CreateReceiptOrderAsync(int type, DateTime date, int reference, int stockRoom, string description, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, int customerId, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddReceiptOrderArticle", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddReceiptOrderArticle(int receiptOrderId, int merchandiseId, decimal amount, int unitId, int unitPrice, decimal auxAmount, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description);

	[OperationContract(Action = "http://tempuri.org/AddReceiptOrderArticle", ReplyAction = "*")]
	Task<int> AddReceiptOrderArticleAsync(int receiptOrderId, int merchandiseId, decimal amount, int unitId, int unitPrice, decimal auxAmount, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description);

	[OperationContract(Action = "http://tempuri.org/AddReceiptOrderSerial", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	bool AddReceiptOrderSerial(int receiptOrderId, int receiptOrderArticleId, string serial, DateTime expiryDate);

	[OperationContract(Action = "http://tempuri.org/AddReceiptOrderSerial", ReplyAction = "*")]
	Task<bool> AddReceiptOrderSerialAsync(int receiptOrderId, int receiptOrderArticleId, string serial, DateTime expiryDate);

	[OperationContract(Action = "http://tempuri.org/CommitReceiptOrder", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResult CommitReceiptOrder(int receiptOrderId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/CommitReceiptOrder", ReplyAction = "*")]
	Task<AddMethodsResult> CommitReceiptOrderAsync(int receiptOrderId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/AddMerchandise", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddMerchandise(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId);

	[OperationContract(Action = "http://tempuri.org/AddMerchandise", ReplyAction = "*")]
	Task<int> AddMerchandiseAsync(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId);

	[OperationContract(Action = "http://tempuri.org/AddMerchandiseReturnsCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string AddMerchandiseReturnsCode(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId);

	[OperationContract(Action = "http://tempuri.org/AddMerchandiseReturnsCode", ReplyAction = "*")]
	Task<string> AddMerchandiseReturnsCodeAsync(string parentCode, string name, string technicalNumber, int unitId, int fiscalPeriod, string userName, string password, int valuationId);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseRemainForAllStockRooms", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetMerchandiseRemainForAllStockRooms(string merchandiseCode, DateTime date, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseRemainForAllStockRooms", ReplyAction = "*")]
	Task<double> GetMerchandiseRemainForAllStockRoomsAsync(string merchandiseCode, DateTime date, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseRemain", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetMerchandiseRemain(string merchandiseCode, DateTime date, int fiscalPeriod, int stockRoomId);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseRemain", ReplyAction = "*")]
	Task<double> GetMerchandiseRemainAsync(string merchandiseCode, DateTime date, int fiscalPeriod, int stockRoomId);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseLastPriceForSale", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetMerchandiseLastPriceForSale(string merchandiseCode, int priceType, DateTime date, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseLastPriceForSale", ReplyAction = "*")]
	Task<double> GetMerchandiseLastPriceForSaleAsync(string merchandiseCode, int priceType, DateTime date, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseLastPriceForSaleByCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetMerchandiseLastPriceForSaleByCustomer(string merchandiseCode, int customerId, DateTime date, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseLastPriceForSaleByCustomer", ReplyAction = "*")]
	Task<double> GetMerchandiseLastPriceForSaleByCustomerAsync(string merchandiseCode, int customerId, DateTime date, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseLastBuyRate", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetMerchandiseLastBuyRate(string merchandiseCode);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseLastBuyRate", ReplyAction = "*")]
	Task<double> GetMerchandiseLastBuyRateAsync(string merchandiseCode);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseIdByBarCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetMerchandiseIdByBarCode(string barCode, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseIdByBarCode", ReplyAction = "*")]
	Task<double> GetMerchandiseIdByBarCodeAsync(string barCode, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseIdByTechNum", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetMerchandiseIdByTechNum(string techNum, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseIdByTechNum", ReplyAction = "*")]
	Task<double> GetMerchandiseIdByTechNumAsync(string techNum, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/AddMerchandiseUnit", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int AddMerchandiseUnit(string name, int fiscalPeriod, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddMerchandiseUnit", ReplyAction = "*")]
	Task<int> AddMerchandiseUnitAsync(string name, int fiscalPeriod, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Merchandise[] GetMerchandiseList(string userName, string password, int fiscalPeriod, int merchandiseId);

	[OperationContract(Action = "http://tempuri.org/GetMerchandiseList", ReplyAction = "*")]
	Task<Merchandise[]> GetMerchandiseListAsync(string userName, string password, int fiscalPeriod, int merchandiseId);

	[OperationContract(Action = "http://tempuri.org/GetMerchandisePriceList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	MerchandisePrice[] GetMerchandisePriceList(int operationType, int fiscalPeriod, DateTime date, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetMerchandisePriceList", ReplyAction = "*")]
	Task<MerchandisePrice[]> GetMerchandisePriceListAsync(int operationType, int fiscalPeriod, DateTime date, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetStockList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Stock[] GetStockList(int fiscalPeriod, DateTime date, string userName, string password, bool includeProforma);

	[OperationContract(Action = "http://tempuri.org/GetStockList", ReplyAction = "*")]
	Task<Stock[]> GetStockListAsync(int fiscalPeriod, DateTime date, string userName, string password, bool includeProforma);

	[OperationContract(Action = "http://tempuri.org/GetStockRoomsInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	StockRoom[] GetStockRoomsInfo(string userName, string password, int stockRoomId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetStockRoomsInfo", ReplyAction = "*")]
	Task<StockRoom[]> GetStockRoomsInfoAsync(string userName, string password, int stockRoomId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/CreateAccountingTransaction", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int CreateAccountingTransaction(DateTime date, string description, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreateAccountingTransaction", ReplyAction = "*")]
	Task<int> CreateAccountingTransactionAsync(DateTime date, string description, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddAccountingArticle", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	bool AddAccountingArticle(int transactionId, double debit, double credit, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description);

	[OperationContract(Action = "http://tempuri.org/AddAccountingArticle", ReplyAction = "*")]
	Task<bool> AddAccountingArticleAsync(int transactionId, double debit, double credit, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5, string description);

	[OperationContract(Action = "http://tempuri.org/CommitAccountingTransaction", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResult CommitAccountingTransaction(int transactionId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/CommitAccountingTransaction", ReplyAction = "*")]
	Task<AddMethodsResult> CommitAccountingTransactionAsync(int transactionId, int fiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetAccountBalance", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double GetAccountBalance(int fiscalPeriod, int departmentCode, DateTime date, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5);

	[OperationContract(Action = "http://tempuri.org/GetAccountBalance", ReplyAction = "*")]
	Task<double> GetAccountBalanceAsync(int fiscalPeriod, int departmentCode, DateTime date, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5);

	[OperationContract(Action = "http://tempuri.org/GetAccountTransactions", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AccountTransaction[] GetAccountTransactions(int fiscalPeriod, DateTime startDate, DateTime endDate, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5);

	[OperationContract(Action = "http://tempuri.org/GetAccountTransactions", ReplyAction = "*")]
	Task<AccountTransaction[]> GetAccountTransactionsAsync(int fiscalPeriod, DateTime startDate, DateTime endDate, string account, string floatingAccount1, string floatingAccount2, string floatingAccount3, string floatingAccount4, string floatingAccount5);

	[OperationContract(Action = "http://tempuri.org/AddAccount", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResultWithCode AddAccount(string parentCode, int fiscalPeriod, string name, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddAccount", ReplyAction = "*")]
	Task<AddMethodsResultWithCode> AddAccountAsync(string parentCode, int fiscalPeriod, string name, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddFloatingAccountHead", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResultWithCode AddFloatingAccountHead(string parentCode, int fiscalPeriod, string name, int codeLength, int accountLevel, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddFloatingAccountHead", ReplyAction = "*")]
	Task<AddMethodsResultWithCode> AddFloatingAccountHeadAsync(string parentCode, int fiscalPeriod, string name, int codeLength, int accountLevel, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddFloatingAccount", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResultWithCode AddFloatingAccount(string parentCode, int fiscalPeriod, string name, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddFloatingAccount", ReplyAction = "*")]
	Task<AddMethodsResultWithCode> AddFloatingAccountAsync(string parentCode, int fiscalPeriod, string name, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddFloatingAccountWithSpecifiedCode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResultWithCode AddFloatingAccountWithSpecifiedCode(string parentCode, string code, int fiscalPeriod, string name, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddFloatingAccountWithSpecifiedCode", ReplyAction = "*")]
	Task<AddMethodsResultWithCode> AddFloatingAccountWithSpecifiedCodeAsync(string parentCode, string code, int fiscalPeriod, string name, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetFiscalPeriodId", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetFiscalPeriodIdResponse GetFiscalPeriodId(GetFiscalPeriodIdRequest request);

	[OperationContract(Action = "http://tempuri.org/GetFiscalPeriodId", ReplyAction = "*")]
	Task<GetFiscalPeriodIdResponse> GetFiscalPeriodIdAsync(GetFiscalPeriodIdRequest request);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforPay", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int CreatePayRCVforPay(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforPay", ReplyAction = "*")]
	Task<int> CreatePayRCVforPayAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforReceive", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int CreatePayRCVforReceive(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforReceive", ReplyAction = "*")]
	Task<int> CreatePayRCVforReceiveAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforCurrencyPurchase", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int CreatePayRCVforCurrencyPurchase(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforCurrencyPurchase", ReplyAction = "*")]
	Task<int> CreatePayRCVforCurrencyPurchaseAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforCurrencySales", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	int CreatePayRCVforCurrencySales(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/CreatePayRCVforCurrencySales", ReplyAction = "*")]
	Task<int> CreatePayRCVforCurrencySalesAsync(int PayType, DateTime PDate, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, string PDesc, int RefNo, int FPId, int Cash, int CustomerId, decimal PCValue, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/AddCheck", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	bool AddCheck(int PayRCVId, string CheckNo, decimal CValue, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, DateTime CDate, DateTime RcptDate, int SType, string CDesc, decimal CurrencyVal, int CurrencyId);

	[OperationContract(Action = "http://tempuri.org/AddCheck", ReplyAction = "*")]
	Task<bool> AddCheckAsync(int PayRCVId, string CheckNo, decimal CValue, string RcvrAcc, string RcvrAB0, string RcvrAB1, string RcvrAB2, string RcvrAB3, string RcvrAB4, DateTime CDate, DateTime RcptDate, int SType, string CDesc, decimal CurrencyVal, int CurrencyId);

	[OperationContract(Action = "http://tempuri.org/CommitPayRCV", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddMethodsResult CommitPayRCV(int PayRCVId, int FiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/CommitPayRCV", ReplyAction = "*")]
	Task<AddMethodsResult> CommitPayRCVAsync(int PayRCVId, int FiscalPeriod);

	[OperationContract(Action = "http://tempuri.org/GetRCVChecksInfoByStatus", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Check[] GetRCVChecksInfoByStatus(int checkStatus, int fiscalPeriod, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetRCVChecksInfoByStatus", ReplyAction = "*")]
	Task<Check[]> GetRCVChecksInfoByStatusAsync(int checkStatus, int fiscalPeriod, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetRCVChecksInfoByCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Check[] GetRCVChecksInfoByCustomer(int customer, int fiscalPeriod, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetRCVChecksInfoByCustomer", ReplyAction = "*")]
	Task<Check[]> GetRCVChecksInfoByCustomerAsync(int customer, int fiscalPeriod, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetPAYChecksInfoByCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	Check[] GetPAYChecksInfoByCustomer(int customer, int fiscalPeriod, string userName, string password);

	[OperationContract(Action = "http://tempuri.org/GetPAYChecksInfoByCustomer", ReplyAction = "*")]
	Task<Check[]> GetPAYChecksInfoByCustomerAsync(int customer, int fiscalPeriod, string userName, string password);
}
