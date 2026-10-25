using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace Mobile.Models;

public class CRMSpEntities : DbContext
{
	public CRMSpEntities()
		: base(DbConnectionI.ConString)
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}

	public virtual int MobspDeleteUserPushNotifTankById(int? userPushNotifTankId)
	{
		ObjectParameter objectParameter = (userPushNotifTankId.HasValue ? new ObjectParameter("UserPushNotifTankId", userPushNotifTankId) : new ObjectParameter("UserPushNotifTankId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDeleteUserPushNotifTankById", objectParameter);
	}

	public virtual int MobspDeleteUserPushNotifTank()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDeleteUserPushNotifTank");
	}

	public virtual ObjectResult<MobspReturnSumCompanyScores_Result> MobspReturnSumCompanyScores(int? companyID, int? centerId)
	{
		ObjectParameter objectParameter = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnSumCompanyScores_Result>("MobspReturnSumCompanyScores", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int HRMMobspUpdatedUserMobBaseInfo(int? userId, string imeiCode, string appName, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspUpdatedUserMobBaseInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual int HRMMobspUpdateUserAppDeviceLastUsed(int? userAppDeviceInfoId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspUpdateUserAppDeviceLastUsed", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual int MobspUpdateUserAppDeviceLastUsed(int? userAppDeviceInfoId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateUserAppDeviceLastUsed", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual ObjectResult<MobspSelectCompanyConversationFirstCnvsUser_Result> MobspSelectCompanyConversationFirstCnvsUser(int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyConversationFirstCnvsUser_Result>("MobspSelectCompanyConversationFirstCnvsUser", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectPreOrderPaymentsWithId_Result> MobspSelectPreOrderPaymentsWithId(int? preOrderPaymentId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderPaymentsWithId_Result>("MobspSelectPreOrderPaymentsWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectOrderPaymentTypesInLangsById_Result> MobspSelectOrderPaymentTypesInLangsById(int? orderPaymentTypeId)
	{
		ObjectParameter objectParameter = (orderPaymentTypeId.HasValue ? new ObjectParameter("OrderPaymentTypeId", orderPaymentTypeId) : new ObjectParameter("OrderPaymentTypeId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderPaymentTypesInLangsById_Result>("MobspSelectOrderPaymentTypesInLangsById", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspInsertCompanyMoneyBag(int? cmpMnBgCompanyId, int? cmpMnBgSystemPartId, int? cmpMnBgSystemPartObjectId, DateTime? cmpMnBgDate, string cmpMnBgDatePersian, decimal? cmpMnBgAmount, string cmpMnBgDesc, string cmpMnBgDesc_Lang, string cmpMnBgBankTransactionCode, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter insertedCompanyMoneyBagId, int? centerId)
	{
		ObjectParameter objectParameter = (cmpMnBgCompanyId.HasValue ? new ObjectParameter("CmpMnBgCompanyId", cmpMnBgCompanyId) : new ObjectParameter("CmpMnBgCompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (cmpMnBgSystemPartId.HasValue ? new ObjectParameter("CmpMnBgSystemPartId", cmpMnBgSystemPartId) : new ObjectParameter("CmpMnBgSystemPartId", typeof(int)));
		ObjectParameter objectParameter3 = (cmpMnBgSystemPartObjectId.HasValue ? new ObjectParameter("CmpMnBgSystemPartObjectId", cmpMnBgSystemPartObjectId) : new ObjectParameter("CmpMnBgSystemPartObjectId", typeof(int)));
		ObjectParameter objectParameter4 = (cmpMnBgDate.HasValue ? new ObjectParameter("CmpMnBgDate", cmpMnBgDate) : new ObjectParameter("CmpMnBgDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((cmpMnBgDatePersian != null) ? new ObjectParameter("CmpMnBgDatePersian", cmpMnBgDatePersian) : new ObjectParameter("CmpMnBgDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (cmpMnBgAmount.HasValue ? new ObjectParameter("CmpMnBgAmount", cmpMnBgAmount) : new ObjectParameter("CmpMnBgAmount", typeof(decimal)));
		ObjectParameter objectParameter7 = ((cmpMnBgDesc != null) ? new ObjectParameter("CmpMnBgDesc", cmpMnBgDesc) : new ObjectParameter("CmpMnBgDesc", typeof(string)));
		ObjectParameter objectParameter8 = ((cmpMnBgDesc_Lang != null) ? new ObjectParameter("CmpMnBgDesc_Lang", cmpMnBgDesc_Lang) : new ObjectParameter("CmpMnBgDesc_Lang", typeof(string)));
		ObjectParameter objectParameter9 = ((cmpMnBgBankTransactionCode != null) ? new ObjectParameter("CmpMnBgBankTransactionCode", cmpMnBgBankTransactionCode) : new ObjectParameter("CmpMnBgBankTransactionCode", typeof(string)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter12 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter17 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertCompanyMoneyBag", new ObjectParameter[18]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, insertedCompanyMoneyBagId, objectParameter17
		});
	}

	public virtual ObjectResult<int?> MobspDeleteCompanyMoneyBagFromPayment(int? companyMoneyBagId, int? mode, int? paymentId)
	{
		ObjectParameter objectParameter = (companyMoneyBagId.HasValue ? new ObjectParameter("CompanyMoneyBagId", companyMoneyBagId) : new ObjectParameter("CompanyMoneyBagId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (paymentId.HasValue ? new ObjectParameter("PaymentId", paymentId) : new ObjectParameter("PaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCompanyMoneyBagFromPayment", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateCompanyMoneyBagFromPayment(int? companyMoneyBagId, int? mode, int? paymentId)
	{
		ObjectParameter objectParameter = (companyMoneyBagId.HasValue ? new ObjectParameter("CompanyMoneyBagId", companyMoneyBagId) : new ObjectParameter("CompanyMoneyBagId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (paymentId.HasValue ? new ObjectParameter("PaymentId", paymentId) : new ObjectParameter("PaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateCompanyMoneyBagFromPayment", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual ObjectResult<int?> MobspUpdateCompanyMoneyBag(int? companyMoneyBagId, DateTime? cmpMnBgDate, string cmpMnBgDatePersian, decimal? cmpMnBgAmount, string cmpMnBgDesc, string cmpMnBgDesc_Lang, string cmpMnBgBankTransactionCode, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyMoneyBagId.HasValue ? new ObjectParameter("CompanyMoneyBagId", companyMoneyBagId) : new ObjectParameter("CompanyMoneyBagId", typeof(int)));
		ObjectParameter objectParameter2 = (cmpMnBgDate.HasValue ? new ObjectParameter("CmpMnBgDate", cmpMnBgDate) : new ObjectParameter("CmpMnBgDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((cmpMnBgDatePersian != null) ? new ObjectParameter("CmpMnBgDatePersian", cmpMnBgDatePersian) : new ObjectParameter("CmpMnBgDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (cmpMnBgAmount.HasValue ? new ObjectParameter("CmpMnBgAmount", cmpMnBgAmount) : new ObjectParameter("CmpMnBgAmount", typeof(decimal)));
		ObjectParameter objectParameter5 = ((cmpMnBgDesc != null) ? new ObjectParameter("CmpMnBgDesc", cmpMnBgDesc) : new ObjectParameter("CmpMnBgDesc", typeof(string)));
		ObjectParameter objectParameter6 = ((cmpMnBgDesc_Lang != null) ? new ObjectParameter("CmpMnBgDesc_Lang", cmpMnBgDesc_Lang) : new ObjectParameter("CmpMnBgDesc_Lang", typeof(string)));
		ObjectParameter objectParameter7 = ((cmpMnBgBankTransactionCode != null) ? new ObjectParameter("CmpMnBgBankTransactionCode", cmpMnBgBankTransactionCode) : new ObjectParameter("CmpMnBgBankTransactionCode", typeof(string)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter10 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter11 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCompanyMoneyBag", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual int MobspUpdateUserAppDeviceInfoById(int? userAppDeviceInfoId, string deviceId, string deviceProperty, DateTime? registerDate, string registerDatePersian, string appType, string aESKey)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter3 = ((deviceProperty != null) ? new ObjectParameter("DeviceProperty", deviceProperty) : new ObjectParameter("DeviceProperty", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = ((aESKey != null) ? new ObjectParameter("AESKey", aESKey) : new ObjectParameter("AESKey", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateUserAppDeviceInfoById", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual int HRMMobspUpdateUserAppDeviceInfoById(int? userAppDeviceInfoId, string deviceId, string deviceProperty, DateTime? registerDate, string registerDatePersian, string appType, string aESKey)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter3 = ((deviceProperty != null) ? new ObjectParameter("DeviceProperty", deviceProperty) : new ObjectParameter("DeviceProperty", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = ((aESKey != null) ? new ObjectParameter("AESKey", aESKey) : new ObjectParameter("AESKey", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspUpdateUserAppDeviceInfoById", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual int HRMMobspInsertUserAppDeviceInfo(int? userId, string deviceId, int? deviceType, string appName, DateTime? firstRegisterDate, string firstRegisterDatePersian, string appType, string imeiCode, string deviceProperty, string aESKey)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter3 = (deviceType.HasValue ? new ObjectParameter("DeviceType", deviceType) : new ObjectParameter("DeviceType", typeof(int)));
		ObjectParameter objectParameter4 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		ObjectParameter objectParameter5 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter9 = ((deviceProperty != null) ? new ObjectParameter("DeviceProperty", deviceProperty) : new ObjectParameter("DeviceProperty", typeof(string)));
		ObjectParameter objectParameter10 = ((aESKey != null) ? new ObjectParameter("AESKey", aESKey) : new ObjectParameter("AESKey", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspInsertUserAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual ObjectResult<MobspSelectUserAppDeviceInfoByImeiCode_Result> MobspSelectUserAppDeviceInfoByImeiCode(string imeiCode, string appName)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserAppDeviceInfoByImeiCode_Result>("MobspSelectUserAppDeviceInfoByImeiCode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectUserAppDeviceInfoByUserId_Result> MobspSelectUserAppDeviceInfoByUserId(int? userId, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserAppDeviceInfoByUserId_Result>("MobspSelectUserAppDeviceInfoByUserId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectUserAppDeviceInfoByUserId_Result> HRMMobspSelectUserAppDeviceInfoByUserId(int? userId, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectUserAppDeviceInfoByUserId_Result>("HRMMobspSelectUserAppDeviceInfoByUserId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectUserAppDeviceInfoByImeiCode_Result> HRMMobspSelectUserAppDeviceInfoByImeiCode(string imeiCode, string appName)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectUserAppDeviceInfoByImeiCode_Result>("HRMMobspSelectUserAppDeviceInfoByImeiCode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspControlOrderItemsStock_Result> MobspControlOrderItemsStock(int? orderId, int? languageID, int? defaultLanguageID, string ordItemList, int? centerID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = ((ordItemList != null) ? new ObjectParameter("OrdItemList", ordItemList) : new ObjectParameter("OrdItemList", typeof(string)));
		ObjectParameter objectParameter5 = (centerID.HasValue ? new ObjectParameter("CenterID", centerID) : new ObjectParameter("CenterID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspControlOrderItemsStock_Result>("MobspControlOrderItemsStock", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<mct_I_Result> MobspReferDocToOrdReferUser(string docIds, string intMsgBody, string intMsgSubject, string intMsgLang, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, string docTxt, string docTxtLang, string draftTxt, string draftTxtLang, string movementTxt, string movementTxtLang, int? centerId)
	{
		ObjectParameter objectParameter = ((docIds != null) ? new ObjectParameter("DocIds", docIds) : new ObjectParameter("DocIds", typeof(string)));
		ObjectParameter objectParameter2 = ((intMsgBody != null) ? new ObjectParameter("IntMsgBody", intMsgBody) : new ObjectParameter("IntMsgBody", typeof(string)));
		ObjectParameter objectParameter3 = ((intMsgSubject != null) ? new ObjectParameter("IntMsgSubject", intMsgSubject) : new ObjectParameter("IntMsgSubject", typeof(string)));
		ObjectParameter objectParameter4 = ((intMsgLang != null) ? new ObjectParameter("IntMsgLang", intMsgLang) : new ObjectParameter("IntMsgLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = ((docTxt != null) ? new ObjectParameter("DocTxt", docTxt) : new ObjectParameter("DocTxt", typeof(string)));
		ObjectParameter objectParameter13 = ((docTxtLang != null) ? new ObjectParameter("DocTxtLang", docTxtLang) : new ObjectParameter("DocTxtLang", typeof(string)));
		ObjectParameter objectParameter14 = ((draftTxt != null) ? new ObjectParameter("DraftTxt", draftTxt) : new ObjectParameter("DraftTxt", typeof(string)));
		ObjectParameter objectParameter15 = ((draftTxtLang != null) ? new ObjectParameter("DraftTxtLang", draftTxtLang) : new ObjectParameter("DraftTxtLang", typeof(string)));
		ObjectParameter objectParameter16 = ((movementTxt != null) ? new ObjectParameter("MovementTxt", movementTxt) : new ObjectParameter("MovementTxt", typeof(string)));
		ObjectParameter objectParameter17 = ((movementTxtLang != null) ? new ObjectParameter("MovementTxtLang", movementTxtLang) : new ObjectParameter("MovementTxtLang", typeof(string)));
		ObjectParameter objectParameter18 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspReferDocToOrdReferUser", new ObjectParameter[18]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18
		});
	}

	public virtual ObjectResult<MobspReturnDraftFromOrder_Result> MobspReturnDraftFromOrder(int? orderID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderID.HasValue ? new ObjectParameter("OrderID", orderID) : new ObjectParameter("OrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDraftFromOrder_Result>("MobspReturnDraftFromOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectDocOpr_Result> MobspSelectDocOpr(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDocOpr_Result>("MobspSelectDocOpr", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectDocVerifiers_Result> MobspSelectDocVerifiers(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDocVerifiers_Result>("MobspSelectDocVerifiers", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectOrdersByCmpIdAndDocOprId_Result> MobspSelectOrdersByCmpIdAndDocOprId(int? companyId, int? docOprId, int? userId, string val, int? languageID, int? defaultLanguageID, int? currDocId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (currDocId.HasValue ? new ObjectParameter("CurrDocId", currDocId) : new ObjectParameter("CurrDocId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrdersByCmpIdAndDocOprId_Result>("MobspSelectOrdersByCmpIdAndDocOprId", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspReturnOrdItemQuantityByDocItemId_Result> MobspReturnOrdItemQuantityByDocItemId(int? docId, int? docItemId, int? prdId, int? orderId, int? buyOrderId, int? wHId, int? preOrderId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		ObjectParameter objectParameter3 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter4 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter5 = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter6 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter7 = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnOrdItemQuantityByDocItemId_Result>("MobspReturnOrdItemQuantityByDocItemId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspCheckDuplicateDocItemTracing_Result> MobspCheckDuplicateDocItemTracing(int? prdId, int? currId, string tracing, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicateDocItemTracing_Result>("MobspCheckDuplicateDocItemTracing", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSearchTracingInDoc_Result> MobspSearchTracingInDoc(string tracing, int? prdId)
	{
		ObjectParameter objectParameter = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter2 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSearchTracingInDoc_Result>("MobspSearchTracingInDoc", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspReturnMobDocCnt(int? centerId)
	{
		ObjectParameter objectParameter = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnMobDocCnt", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspCheckDuplicatePrdSerial_Result> MobspCheckDuplicatePrdSerial(int? oprId, int? fPId, int? wHID, int? prdId, string serial, int? currId, int? languageID, int? defaultLanguageID, int? docItemSerialID)
	{
		ObjectParameter objectParameter = (oprId.HasValue ? new ObjectParameter("OprId", oprId) : new ObjectParameter("OprId", typeof(int)));
		ObjectParameter objectParameter2 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter3 = (wHID.HasValue ? new ObjectParameter("WHID", wHID) : new ObjectParameter("WHID", typeof(int)));
		ObjectParameter objectParameter4 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter5 = ((serial != null) ? new ObjectParameter("Serial", serial) : new ObjectParameter("Serial", typeof(string)));
		ObjectParameter objectParameter6 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (docItemSerialID.HasValue ? new ObjectParameter("DocItemSerialID", docItemSerialID) : new ObjectParameter("DocItemSerialID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicatePrdSerial_Result>("MobspCheckDuplicatePrdSerial", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int MobspGenerateDocItemSerial(int? count, int? itemId, string preFixSerial, string serial, bool? incSerial, string description, int? wHId, int? userId, int? month1, int? fPId, string registerDate, string registerDatePersian, DateTime? expDate, string expDatePersian, string appType, string preFixInfoI, string infoI, bool? incInfoI, string preFixInfoII, string infoII, bool? incInfoII, string preFixInfoIII, string infoIII, bool? incInfoIII, string preFixInfoIV, string infoIV, bool? incInfoIV, string preFixInfoV, string infoV, bool? incInfoV, string preFixInfoVI, string infoVI, bool? incInfoVI, int? languageID, string descriptionLang)
	{
		ObjectParameter objectParameter = (count.HasValue ? new ObjectParameter("Count", count) : new ObjectParameter("Count", typeof(int)));
		ObjectParameter objectParameter2 = (itemId.HasValue ? new ObjectParameter("ItemId", itemId) : new ObjectParameter("ItemId", typeof(int)));
		ObjectParameter objectParameter3 = ((preFixSerial != null) ? new ObjectParameter("PreFixSerial", preFixSerial) : new ObjectParameter("PreFixSerial", typeof(string)));
		ObjectParameter objectParameter4 = ((serial != null) ? new ObjectParameter("Serial", serial) : new ObjectParameter("Serial", typeof(string)));
		ObjectParameter objectParameter5 = (incSerial.HasValue ? new ObjectParameter("IncSerial", incSerial) : new ObjectParameter("IncSerial", typeof(bool)));
		ObjectParameter objectParameter6 = ((description != null) ? new ObjectParameter("Description", description) : new ObjectParameter("Description", typeof(string)));
		ObjectParameter objectParameter7 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter10 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter11 = ((registerDate != null) ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(string)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = (expDate.HasValue ? new ObjectParameter("ExpDate", expDate) : new ObjectParameter("ExpDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((expDatePersian != null) ? new ObjectParameter("ExpDatePersian", expDatePersian) : new ObjectParameter("ExpDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = ((preFixInfoI != null) ? new ObjectParameter("PreFixInfoI", preFixInfoI) : new ObjectParameter("PreFixInfoI", typeof(string)));
		ObjectParameter objectParameter17 = ((infoI != null) ? new ObjectParameter("InfoI", infoI) : new ObjectParameter("InfoI", typeof(string)));
		ObjectParameter objectParameter18 = (incInfoI.HasValue ? new ObjectParameter("IncInfoI", incInfoI) : new ObjectParameter("IncInfoI", typeof(bool)));
		ObjectParameter objectParameter19 = ((preFixInfoII != null) ? new ObjectParameter("PreFixInfoII", preFixInfoII) : new ObjectParameter("PreFixInfoII", typeof(string)));
		ObjectParameter objectParameter20 = ((infoII != null) ? new ObjectParameter("InfoII", infoII) : new ObjectParameter("InfoII", typeof(string)));
		ObjectParameter objectParameter21 = (incInfoII.HasValue ? new ObjectParameter("IncInfoII", incInfoII) : new ObjectParameter("IncInfoII", typeof(bool)));
		ObjectParameter objectParameter22 = ((preFixInfoIII != null) ? new ObjectParameter("PreFixInfoIII", preFixInfoIII) : new ObjectParameter("PreFixInfoIII", typeof(string)));
		ObjectParameter objectParameter23 = ((infoIII != null) ? new ObjectParameter("InfoIII", infoIII) : new ObjectParameter("InfoIII", typeof(string)));
		ObjectParameter objectParameter24 = (incInfoIII.HasValue ? new ObjectParameter("IncInfoIII", incInfoIII) : new ObjectParameter("IncInfoIII", typeof(bool)));
		ObjectParameter objectParameter25 = ((preFixInfoIV != null) ? new ObjectParameter("PreFixInfoIV", preFixInfoIV) : new ObjectParameter("PreFixInfoIV", typeof(string)));
		ObjectParameter objectParameter26 = ((infoIV != null) ? new ObjectParameter("InfoIV", infoIV) : new ObjectParameter("InfoIV", typeof(string)));
		ObjectParameter objectParameter27 = (incInfoIV.HasValue ? new ObjectParameter("IncInfoIV", incInfoIV) : new ObjectParameter("IncInfoIV", typeof(bool)));
		ObjectParameter objectParameter28 = ((preFixInfoV != null) ? new ObjectParameter("PreFixInfoV", preFixInfoV) : new ObjectParameter("PreFixInfoV", typeof(string)));
		ObjectParameter objectParameter29 = ((infoV != null) ? new ObjectParameter("InfoV", infoV) : new ObjectParameter("InfoV", typeof(string)));
		ObjectParameter objectParameter30 = (incInfoV.HasValue ? new ObjectParameter("IncInfoV", incInfoV) : new ObjectParameter("IncInfoV", typeof(bool)));
		ObjectParameter objectParameter31 = ((preFixInfoVI != null) ? new ObjectParameter("PreFixInfoVI", preFixInfoVI) : new ObjectParameter("PreFixInfoVI", typeof(string)));
		ObjectParameter objectParameter32 = ((infoVI != null) ? new ObjectParameter("InfoVI", infoVI) : new ObjectParameter("InfoVI", typeof(string)));
		ObjectParameter objectParameter33 = (incInfoVI.HasValue ? new ObjectParameter("IncInfoVI", incInfoVI) : new ObjectParameter("IncInfoVI", typeof(bool)));
		ObjectParameter objectParameter34 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter35 = ((descriptionLang != null) ? new ObjectParameter("DescriptionLang", descriptionLang) : new ObjectParameter("DescriptionLang", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspGenerateDocItemSerial", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35);
	}

	public virtual ObjectResult<MobspGenerateDocItemSerialAndSelect_Result> MobspGenerateDocItemSerialAndSelect(int? count, string preFixSerial, string serial, bool? incSerial, int? wHId, string preFixInfoI, string infoI, bool? incInfoI, string preFixInfoII, string infoII, bool? incInfoII, string preFixInfoIII, string infoIII, bool? incInfoIII, string preFixInfoIV, string infoIV, bool? incInfoIV, string preFixInfoV, string infoV, bool? incInfoV, string preFixInfoVI, string infoVI, bool? incInfoVI, int? prdId, int? oprId, int? itemCount, int? prdQuantity)
	{
		ObjectParameter objectParameter = (count.HasValue ? new ObjectParameter("Count", count) : new ObjectParameter("Count", typeof(int)));
		ObjectParameter objectParameter2 = ((preFixSerial != null) ? new ObjectParameter("PreFixSerial", preFixSerial) : new ObjectParameter("PreFixSerial", typeof(string)));
		ObjectParameter objectParameter3 = ((serial != null) ? new ObjectParameter("Serial", serial) : new ObjectParameter("Serial", typeof(string)));
		ObjectParameter objectParameter4 = (incSerial.HasValue ? new ObjectParameter("IncSerial", incSerial) : new ObjectParameter("IncSerial", typeof(bool)));
		ObjectParameter objectParameter5 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter6 = ((preFixInfoI != null) ? new ObjectParameter("PreFixInfoI", preFixInfoI) : new ObjectParameter("PreFixInfoI", typeof(string)));
		ObjectParameter objectParameter7 = ((infoI != null) ? new ObjectParameter("InfoI", infoI) : new ObjectParameter("InfoI", typeof(string)));
		ObjectParameter objectParameter8 = (incInfoI.HasValue ? new ObjectParameter("IncInfoI", incInfoI) : new ObjectParameter("IncInfoI", typeof(bool)));
		ObjectParameter objectParameter9 = ((preFixInfoII != null) ? new ObjectParameter("PreFixInfoII", preFixInfoII) : new ObjectParameter("PreFixInfoII", typeof(string)));
		ObjectParameter objectParameter10 = ((infoII != null) ? new ObjectParameter("InfoII", infoII) : new ObjectParameter("InfoII", typeof(string)));
		ObjectParameter objectParameter11 = (incInfoII.HasValue ? new ObjectParameter("IncInfoII", incInfoII) : new ObjectParameter("IncInfoII", typeof(bool)));
		ObjectParameter objectParameter12 = ((preFixInfoIII != null) ? new ObjectParameter("PreFixInfoIII", preFixInfoIII) : new ObjectParameter("PreFixInfoIII", typeof(string)));
		ObjectParameter objectParameter13 = ((infoIII != null) ? new ObjectParameter("InfoIII", infoIII) : new ObjectParameter("InfoIII", typeof(string)));
		ObjectParameter objectParameter14 = (incInfoIII.HasValue ? new ObjectParameter("IncInfoIII", incInfoIII) : new ObjectParameter("IncInfoIII", typeof(bool)));
		ObjectParameter objectParameter15 = ((preFixInfoIV != null) ? new ObjectParameter("PreFixInfoIV", preFixInfoIV) : new ObjectParameter("PreFixInfoIV", typeof(string)));
		ObjectParameter objectParameter16 = ((infoIV != null) ? new ObjectParameter("InfoIV", infoIV) : new ObjectParameter("InfoIV", typeof(string)));
		ObjectParameter objectParameter17 = (incInfoIV.HasValue ? new ObjectParameter("IncInfoIV", incInfoIV) : new ObjectParameter("IncInfoIV", typeof(bool)));
		ObjectParameter objectParameter18 = ((preFixInfoV != null) ? new ObjectParameter("PreFixInfoV", preFixInfoV) : new ObjectParameter("PreFixInfoV", typeof(string)));
		ObjectParameter objectParameter19 = ((infoV != null) ? new ObjectParameter("InfoV", infoV) : new ObjectParameter("InfoV", typeof(string)));
		ObjectParameter objectParameter20 = (incInfoV.HasValue ? new ObjectParameter("IncInfoV", incInfoV) : new ObjectParameter("IncInfoV", typeof(bool)));
		ObjectParameter objectParameter21 = ((preFixInfoVI != null) ? new ObjectParameter("PreFixInfoVI", preFixInfoVI) : new ObjectParameter("PreFixInfoVI", typeof(string)));
		ObjectParameter objectParameter22 = ((infoVI != null) ? new ObjectParameter("InfoVI", infoVI) : new ObjectParameter("InfoVI", typeof(string)));
		ObjectParameter objectParameter23 = (incInfoVI.HasValue ? new ObjectParameter("IncInfoVI", incInfoVI) : new ObjectParameter("IncInfoVI", typeof(bool)));
		ObjectParameter objectParameter24 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter25 = (oprId.HasValue ? new ObjectParameter("OprId", oprId) : new ObjectParameter("OprId", typeof(int)));
		ObjectParameter objectParameter26 = (itemCount.HasValue ? new ObjectParameter("ItemCount", itemCount) : new ObjectParameter("ItemCount", typeof(int)));
		ObjectParameter objectParameter27 = (prdQuantity.HasValue ? new ObjectParameter("PrdQuantity", prdQuantity) : new ObjectParameter("PrdQuantity", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspGenerateDocItemSerialAndSelect_Result>("MobspGenerateDocItemSerialAndSelect", new ObjectParameter[27]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27
		});
	}

	public virtual ObjectResult<MobspReturnPrdQuantity_Result> MobspReturnPrdQuantity(int? prdId, int? fPId, int? wHId, int? currId, int? languageID, int? defaultLanguageID, double? fCR, double? fCRI, string tracing, ObjectParameter quantityRemain, int? centerId)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter3 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter4 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (fCR.HasValue ? new ObjectParameter("FCR", fCR) : new ObjectParameter("FCR", typeof(double)));
		ObjectParameter objectParameter8 = (fCRI.HasValue ? new ObjectParameter("FCRI", fCRI) : new ObjectParameter("FCRI", typeof(double)));
		ObjectParameter objectParameter9 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnPrdQuantity_Result>("MobspReturnPrdQuantity", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, quantityRemain,
			objectParameter10
		});
	}

	public virtual int MobspDocVerify(int? docId, int? verifierUserId, DateTime? verifiedRegisterDate, string verifiedRegisterDatePersian)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = (verifiedRegisterDate.HasValue ? new ObjectParameter("VerifiedRegisterDate", verifiedRegisterDate) : new ObjectParameter("VerifiedRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((verifiedRegisterDatePersian != null) ? new ObjectParameter("VerifiedRegisterDatePersian", verifiedRegisterDatePersian) : new ObjectParameter("VerifiedRegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDocVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int MobspDocVerifyExit(int? docID)
	{
		ObjectParameter objectParameter = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDocVerifyExit", objectParameter);
	}

	public virtual ObjectResult<CRMspDyPrintCmpForm_Result> CRMspDyPrintCmpForm(int? companyId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintCmpForm_Result>("CRMspDyPrintCmpForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspDyPrintDocForm_Result> CRMspDyPrintDocForm(int? docId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintDocForm_Result>("CRMspDyPrintDocForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspDyPrintPrjForm_Result> CRMspDyPrintPrjForm(int? projectId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintPrjForm_Result>("CRMspDyPrintPrjForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspDyPrintPrsForm_Result> CRMspDyPrintPrsForm(int? companyPersonId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintPrsForm_Result>("CRMspDyPrintPrsForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspRpt_PrintDoc_Result> WSspRpt_PrintDoc(int? docID, int? languageID, int? defaultLanguageID, string manualIssuing, string systemIssuing, int? userId, string rptDate, string rptDay)
	{
		ObjectParameter objectParameter = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = ((manualIssuing != null) ? new ObjectParameter("ManualIssuing", manualIssuing) : new ObjectParameter("ManualIssuing", typeof(string)));
		ObjectParameter objectParameter5 = ((systemIssuing != null) ? new ObjectParameter("SystemIssuing", systemIssuing) : new ObjectParameter("SystemIssuing", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter8 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintDoc_Result>("WSspRpt_PrintDoc", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<WSspRpt_PrintDocItemPrdPicture_Result> WSspRpt_PrintDocItemPrdPicture(int? docId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintDocItemPrdPicture_Result>("WSspRpt_PrintDocItemPrdPicture", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintDocItemSerials_Result> WSspRpt_PrintDocItemSerials(int? docItemID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docItemID.HasValue ? new ObjectParameter("DocItemID", docItemID) : new ObjectParameter("DocItemID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintDocItemSerials_Result>("WSspRpt_PrintDocItemSerials", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintDocVerificationRequestDetails_Result> WSspRpt_PrintDocVerificationRequestDetails(int? objectId, int? objectType, int? verificationWorkFlowId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter3 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintDocVerificationRequestDetails_Result>("WSspRpt_PrintDocVerificationRequestDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int WSspDocSetToIsFix(int? docID)
	{
		ObjectParameter objectParameter = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspDocSetToIsFix", objectParameter);
	}

	public virtual ObjectResult<WSspSelectOrderById_Result> WSspSelectOrderById(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderById_Result>("WSspSelectOrderById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectDocItems_Result> MobspSelectDocItems(int? docId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDocItems_Result>("MobspSelectDocItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectDocItemSerials_Result> MobspSelectDocItemSerials(int? itemId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (itemId.HasValue ? new ObjectParameter("ItemId", itemId) : new ObjectParameter("ItemId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDocItemSerials_Result>("MobspSelectDocItemSerials", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnDocOprTypeFromDocId_Result> MobspReturnDocOprTypeFromDocId(int? docId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocOprTypeFromDocId_Result>("MobspReturnDocOprTypeFromDocId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteWSDoc(int? docID)
	{
		ObjectParameter objectParameter = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteWSDoc", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteWSDocItems(int? docItemID)
	{
		ObjectParameter objectParameter = (docItemID.HasValue ? new ObjectParameter("DocItemID", docItemID) : new ObjectParameter("DocItemID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteWSDocItems", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteWSDocItemSerials(int? docItemSerialID)
	{
		ObjectParameter objectParameter = (docItemSerialID.HasValue ? new ObjectParameter("DocItemSerialID", docItemSerialID) : new ObjectParameter("DocItemSerialID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteWSDocItemSerials", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectDocById_Result> MobspSelectDocById(int? docId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDocById_Result>("MobspSelectDocById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	[EdmFunction("CRMSpEntities", "MobfnCheckOrderBeforeDeleteResidSerial")]
	public virtual IQueryable<int?> MobfnCheckOrderBeforeDeleteResidSerial(int? docItemSerialID)
	{
		ObjectParameter objectParameter = (docItemSerialID.HasValue ? new ObjectParameter("DocItemSerialID", docItemSerialID) : new ObjectParameter("DocItemSerialID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<int?>("[CRMSpEntities].[MobfnCheckOrderBeforeDeleteResidSerial](@DocItemSerialID)", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteDocItemsAll(int? docId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteDocItemsAll", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteDocItemSerialsByDocItemId(int? docItemId)
	{
		ObjectParameter objectParameter = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteDocItemSerialsByDocItemId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteDocItemWithLinkedPrd(int? docId, int? docItemId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteDocItemWithLinkedPrd", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspInsertQuickDocItemSerial(string docItemSerialParams, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resInsertedDocItemSerialIds)
	{
		ObjectParameter objectParameter = ((docItemSerialParams != null) ? new ObjectParameter("DocItemSerialParams", docItemSerialParams) : new ObjectParameter("DocItemSerialParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickDocItemSerial", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, resErrorMessage,
			resInsertedDocItemSerialIds
		});
	}

	public virtual ObjectResult<int?> MobspUpdateDoc(string docParams, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resUpdatedDocId, int? centerId)
	{
		ObjectParameter objectParameter = ((docParams != null) ? new ObjectParameter("DocParams", docParams) : new ObjectParameter("DocParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateDoc", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, resErrorMessage, resUpdatedDocId,
			objectParameter9
		});
	}

	public virtual ObjectResult<MobspSelectProductsWithId_Result> MobspSelectProductsWithId(int? productId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductsWithId_Result>("MobspSelectProductsWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspUpdateDocItem(string docItemParams, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resUpdatedDocItemIds, int? centerId)
	{
		ObjectParameter objectParameter = ((docItemParams != null) ? new ObjectParameter("DocItemParams", docItemParams) : new ObjectParameter("DocItemParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateDocItem", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, resErrorMessage,
			resUpdatedDocItemIds, objectParameter10
		});
	}

	public virtual int CICMobspInsertUserAppDeviceInfo(int? userId, string deviceId, int? deviceType, string appName, DateTime? firstRegisterDate, string firstRegisterDatePersian, string appType, string imeiCode, string deviceProperty, string aESKey)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter3 = (deviceType.HasValue ? new ObjectParameter("DeviceType", deviceType) : new ObjectParameter("DeviceType", typeof(int)));
		ObjectParameter objectParameter4 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		ObjectParameter objectParameter5 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter9 = ((deviceProperty != null) ? new ObjectParameter("DeviceProperty", deviceProperty) : new ObjectParameter("DeviceProperty", typeof(string)));
		ObjectParameter objectParameter10 = ((aESKey != null) ? new ObjectParameter("AESKey", aESKey) : new ObjectParameter("AESKey", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CICMobspInsertUserAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual ObjectResult<CICMobspLoadUserLoginInfo_Result> CICMobspLoadUserLoginInfo(int? userId, string userName, string userPassword, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter3 = ((userPassword != null) ? new ObjectParameter("UserPassword", userPassword) : new ObjectParameter("UserPassword", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspLoadUserLoginInfo_Result>("CICMobspLoadUserLoginInfo", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CICMobspSelectUserAppDeviceInfoByImeiCode_Result> CICMobspSelectUserAppDeviceInfoByImeiCode(string imeiCode, string appName)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspSelectUserAppDeviceInfoByImeiCode_Result>("CICMobspSelectUserAppDeviceInfoByImeiCode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CICMobspSelectUserAppDeviceInfoByUserId_Result> CICMobspSelectUserAppDeviceInfoByUserId(int? userId, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspSelectUserAppDeviceInfoByUserId_Result>("CICMobspSelectUserAppDeviceInfoByUserId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int CICMobspUpdateUserAppDeviceInfoById(int? userAppDeviceInfoId, string deviceId, string deviceProperty, DateTime? registerDate, string registerDatePersian, string appType, string aESKey)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter3 = ((deviceProperty != null) ? new ObjectParameter("DeviceProperty", deviceProperty) : new ObjectParameter("DeviceProperty", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = ((aESKey != null) ? new ObjectParameter("AESKey", aESKey) : new ObjectParameter("AESKey", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CICMobspUpdateUserAppDeviceInfoById", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual ObjectResult<CICMobspSelectCrmsysSetting_Result> CICMobspSelectCrmsysSetting(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspSelectCrmsysSetting_Result>("CICMobspSelectCrmsysSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CICMobspSelectUserBaseInfoStatus_Result> CICMobspSelectUserBaseInfoStatus(int? userId, string imeiCode, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspSelectUserBaseInfoStatus_Result>("CICMobspSelectUserBaseInfoStatus", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CICMobspUpdatedUserMobBaseInfo(int? userId, string imeiCode, string appName, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CICMobspUpdatedUserMobBaseInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<CICMobspCallerIDSearch_Result> CICMobspCallerIDSearch(string phoneNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((phoneNumber != null) ? new ObjectParameter("PhoneNumber", phoneNumber) : new ObjectParameter("PhoneNumber", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspCallerIDSearch_Result>("CICMobspCallerIDSearch", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CICMobspCallerIDFormulaPopUpResult(string valueForLineNumber, string valueForCallTime, string valueForPhoneNumber, string valueForcmpName, string valueForcmpPrsName, string valueForPhoneName, string valueForLastcnvscmpPerson, string valueForLastProject, string valueForLastcnvsRefUser, string valueForLastcnvsStatus, string valueForcmpReferUser, string valueForcmpActivityType, string valueForcmpCountry, string valueForcmpProvince, string valueForcmpCity, string valueForcmpPresentation, string valueForcmpCompanyType, string valueForcmpCompanyGroup, string valueForcmpSubGroupName, string valueForcmpCompanyGroupII, string valueForcmpCompanyGroupIII, string valueForcmpCompanyGroupIV, string valueForcmpCIWord, ObjectParameter formulaPopUpResult, bool? forWeb)
	{
		ObjectParameter objectParameter = ((valueForLineNumber != null) ? new ObjectParameter("ValueForLineNumber", valueForLineNumber) : new ObjectParameter("ValueForLineNumber", typeof(string)));
		ObjectParameter objectParameter2 = ((valueForCallTime != null) ? new ObjectParameter("ValueForCallTime", valueForCallTime) : new ObjectParameter("ValueForCallTime", typeof(string)));
		ObjectParameter objectParameter3 = ((valueForPhoneNumber != null) ? new ObjectParameter("ValueForPhoneNumber", valueForPhoneNumber) : new ObjectParameter("ValueForPhoneNumber", typeof(string)));
		ObjectParameter objectParameter4 = ((valueForcmpName != null) ? new ObjectParameter("ValueForcmpName", valueForcmpName) : new ObjectParameter("ValueForcmpName", typeof(string)));
		ObjectParameter objectParameter5 = ((valueForcmpPrsName != null) ? new ObjectParameter("ValueForcmpPrsName", valueForcmpPrsName) : new ObjectParameter("ValueForcmpPrsName", typeof(string)));
		ObjectParameter objectParameter6 = ((valueForPhoneName != null) ? new ObjectParameter("ValueForPhoneName", valueForPhoneName) : new ObjectParameter("ValueForPhoneName", typeof(string)));
		ObjectParameter objectParameter7 = ((valueForLastcnvscmpPerson != null) ? new ObjectParameter("ValueForLastcnvscmpPerson", valueForLastcnvscmpPerson) : new ObjectParameter("ValueForLastcnvscmpPerson", typeof(string)));
		ObjectParameter objectParameter8 = ((valueForLastProject != null) ? new ObjectParameter("ValueForLastProject", valueForLastProject) : new ObjectParameter("ValueForLastProject", typeof(string)));
		ObjectParameter objectParameter9 = ((valueForLastcnvsRefUser != null) ? new ObjectParameter("ValueForLastcnvsRefUser", valueForLastcnvsRefUser) : new ObjectParameter("ValueForLastcnvsRefUser", typeof(string)));
		ObjectParameter objectParameter10 = ((valueForLastcnvsStatus != null) ? new ObjectParameter("ValueForLastcnvsStatus", valueForLastcnvsStatus) : new ObjectParameter("ValueForLastcnvsStatus", typeof(string)));
		ObjectParameter objectParameter11 = ((valueForcmpReferUser != null) ? new ObjectParameter("ValueForcmpReferUser", valueForcmpReferUser) : new ObjectParameter("ValueForcmpReferUser", typeof(string)));
		ObjectParameter objectParameter12 = ((valueForcmpActivityType != null) ? new ObjectParameter("ValueForcmpActivityType", valueForcmpActivityType) : new ObjectParameter("ValueForcmpActivityType", typeof(string)));
		ObjectParameter objectParameter13 = ((valueForcmpCountry != null) ? new ObjectParameter("ValueForcmpCountry", valueForcmpCountry) : new ObjectParameter("ValueForcmpCountry", typeof(string)));
		ObjectParameter objectParameter14 = ((valueForcmpProvince != null) ? new ObjectParameter("ValueForcmpProvince", valueForcmpProvince) : new ObjectParameter("ValueForcmpProvince", typeof(string)));
		ObjectParameter objectParameter15 = ((valueForcmpCity != null) ? new ObjectParameter("ValueForcmpCity", valueForcmpCity) : new ObjectParameter("ValueForcmpCity", typeof(string)));
		ObjectParameter objectParameter16 = ((valueForcmpPresentation != null) ? new ObjectParameter("ValueForcmpPresentation", valueForcmpPresentation) : new ObjectParameter("ValueForcmpPresentation", typeof(string)));
		ObjectParameter objectParameter17 = ((valueForcmpCompanyType != null) ? new ObjectParameter("ValueForcmpCompanyType", valueForcmpCompanyType) : new ObjectParameter("ValueForcmpCompanyType", typeof(string)));
		ObjectParameter objectParameter18 = ((valueForcmpCompanyGroup != null) ? new ObjectParameter("ValueForcmpCompanyGroup", valueForcmpCompanyGroup) : new ObjectParameter("ValueForcmpCompanyGroup", typeof(string)));
		ObjectParameter objectParameter19 = ((valueForcmpSubGroupName != null) ? new ObjectParameter("ValueForcmpSubGroupName", valueForcmpSubGroupName) : new ObjectParameter("ValueForcmpSubGroupName", typeof(string)));
		ObjectParameter objectParameter20 = ((valueForcmpCompanyGroupII != null) ? new ObjectParameter("ValueForcmpCompanyGroupII", valueForcmpCompanyGroupII) : new ObjectParameter("ValueForcmpCompanyGroupII", typeof(string)));
		ObjectParameter objectParameter21 = ((valueForcmpCompanyGroupIII != null) ? new ObjectParameter("ValueForcmpCompanyGroupIII", valueForcmpCompanyGroupIII) : new ObjectParameter("ValueForcmpCompanyGroupIII", typeof(string)));
		ObjectParameter objectParameter22 = ((valueForcmpCompanyGroupIV != null) ? new ObjectParameter("ValueForcmpCompanyGroupIV", valueForcmpCompanyGroupIV) : new ObjectParameter("ValueForcmpCompanyGroupIV", typeof(string)));
		ObjectParameter objectParameter23 = ((valueForcmpCIWord != null) ? new ObjectParameter("ValueForcmpCIWord", valueForcmpCIWord) : new ObjectParameter("ValueForcmpCIWord", typeof(string)));
		ObjectParameter objectParameter24 = (forWeb.HasValue ? new ObjectParameter("ForWeb", forWeb) : new ObjectParameter("ForWeb", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CICMobspCallerIDFormulaPopUpResult", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, formulaPopUpResult, objectParameter24);
	}

	public virtual ObjectResult<int?> CICMobspCallerIDSelectRejectPopUpUsers(int? mode, int? referUserID, int? telLine)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = (referUserID.HasValue ? new ObjectParameter("ReferUserID", referUserID) : new ObjectParameter("ReferUserID", typeof(int)));
		ObjectParameter objectParameter3 = (telLine.HasValue ? new ObjectParameter("TelLine", telLine) : new ObjectParameter("TelLine", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("CICMobspCallerIDSelectRejectPopUpUsers", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CICMobspCallerIDSelectPopUpSetting_Result> CICMobspCallerIDSelectPopUpSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspCallerIDSelectPopUpSetting_Result>("CICMobspCallerIDSelectPopUpSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<int?> CICMobspInsertCallHistory(int? callTypeId, int? lineNumber, string phoneNumber, int? companyID, DateTime? callDateTime, string callTime, string callDate, string callDay, int? userID, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string startTime, string endTime, string duration, int? companyPersonID, string recFileName, string data, string appType, int? defaultLanguageID, string trunkCallId, string trunkName, string trunkSource, string trunkDestination, string trunkFileLocation, string trunkDestinationCycle, string preRecFileName, int? devType, bool? isFinished, ObjectParameter insertedId)
	{
		ObjectParameter objectParameter = (callTypeId.HasValue ? new ObjectParameter("CallTypeId", callTypeId) : new ObjectParameter("CallTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (lineNumber.HasValue ? new ObjectParameter("LineNumber", lineNumber) : new ObjectParameter("LineNumber", typeof(int)));
		ObjectParameter objectParameter3 = ((phoneNumber != null) ? new ObjectParameter("PhoneNumber", phoneNumber) : new ObjectParameter("PhoneNumber", typeof(string)));
		ObjectParameter objectParameter4 = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter5 = (callDateTime.HasValue ? new ObjectParameter("CallDateTime", callDateTime) : new ObjectParameter("CallDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((callTime != null) ? new ObjectParameter("CallTime", callTime) : new ObjectParameter("CallTime", typeof(string)));
		ObjectParameter objectParameter7 = ((callDate != null) ? new ObjectParameter("CallDate", callDate) : new ObjectParameter("CallDate", typeof(string)));
		ObjectParameter objectParameter8 = ((callDay != null) ? new ObjectParameter("CallDay", callDay) : new ObjectParameter("CallDay", typeof(string)));
		ObjectParameter objectParameter9 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter10 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = ((startTime != null) ? new ObjectParameter("StartTime", startTime) : new ObjectParameter("StartTime", typeof(string)));
		ObjectParameter objectParameter15 = ((endTime != null) ? new ObjectParameter("EndTime", endTime) : new ObjectParameter("EndTime", typeof(string)));
		ObjectParameter objectParameter16 = ((duration != null) ? new ObjectParameter("Duration", duration) : new ObjectParameter("Duration", typeof(string)));
		ObjectParameter objectParameter17 = (companyPersonID.HasValue ? new ObjectParameter("CompanyPersonID", companyPersonID) : new ObjectParameter("CompanyPersonID", typeof(int)));
		ObjectParameter objectParameter18 = ((recFileName != null) ? new ObjectParameter("RecFileName", recFileName) : new ObjectParameter("RecFileName", typeof(string)));
		ObjectParameter objectParameter19 = ((data != null) ? new ObjectParameter("Data", data) : new ObjectParameter("Data", typeof(string)));
		ObjectParameter objectParameter20 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter21 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter22 = ((trunkCallId != null) ? new ObjectParameter("TrunkCallId", trunkCallId) : new ObjectParameter("TrunkCallId", typeof(string)));
		ObjectParameter objectParameter23 = ((trunkName != null) ? new ObjectParameter("TrunkName", trunkName) : new ObjectParameter("TrunkName", typeof(string)));
		ObjectParameter objectParameter24 = ((trunkSource != null) ? new ObjectParameter("TrunkSource", trunkSource) : new ObjectParameter("TrunkSource", typeof(string)));
		ObjectParameter objectParameter25 = ((trunkDestination != null) ? new ObjectParameter("TrunkDestination", trunkDestination) : new ObjectParameter("TrunkDestination", typeof(string)));
		ObjectParameter objectParameter26 = ((trunkFileLocation != null) ? new ObjectParameter("TrunkFileLocation", trunkFileLocation) : new ObjectParameter("TrunkFileLocation", typeof(string)));
		ObjectParameter objectParameter27 = ((trunkDestinationCycle != null) ? new ObjectParameter("TrunkDestinationCycle", trunkDestinationCycle) : new ObjectParameter("TrunkDestinationCycle", typeof(string)));
		ObjectParameter objectParameter28 = ((preRecFileName != null) ? new ObjectParameter("PreRecFileName", preRecFileName) : new ObjectParameter("PreRecFileName", typeof(string)));
		ObjectParameter objectParameter29 = (devType.HasValue ? new ObjectParameter("DevType", devType) : new ObjectParameter("DevType", typeof(int)));
		ObjectParameter objectParameter30 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("CICMobspInsertCallHistory", new ObjectParameter[31]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			insertedId
		});
	}

	public virtual int MobspDeactiveUserAppDeviceInfo(int? userAppDeviceInfoId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDeactiveUserAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int CICMobspDeactiveUserAppDeviceInfo(int? userAppDeviceInfoId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CICMobspDeactiveUserAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int HRMMobspDeactiveUserAppDeviceInfo(int? userAppDeviceInfoId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspDeactiveUserAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result> MobspSelectActiveUserAppDeviceInfoByImeiCode(string imeiCode, string appName)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>("MobspSelectActiveUserAppDeviceInfoByImeiCode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result> CICMobspSelectActiveUserAppDeviceInfoByImeiCode(string imeiCode, string appName)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>("CICMobspSelectActiveUserAppDeviceInfoByImeiCode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result> HRMMobspSelectActiveUserAppDeviceInfoByImeiCode(string imeiCode, string appName)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>("HRMMobspSelectActiveUserAppDeviceInfoByImeiCode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectActiveUserAppDeviceInfoByUserId_Result> MobspSelectActiveUserAppDeviceInfoByUserId(int? userId, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveUserAppDeviceInfoByUserId_Result>("MobspSelectActiveUserAppDeviceInfoByUserId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspInsertAutoDocItemSerial(int? docItemId, int? wHId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		ObjectParameter objectParameter2 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertAutoDocItemSerial", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<MobspInsertDocItemFromLinkedPrd_Result> MobspInsertDocItemFromLinkedPrd(int? productId, int? docId, int? wHId, int? userId, int? fPId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string prdStockTxt, int? centerId)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter3 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = ((prdStockTxt != null) ? new ObjectParameter("PrdStockTxt", prdStockTxt) : new ObjectParameter("PrdStockTxt", typeof(string)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspInsertDocItemFromLinkedPrd_Result>("MobspInsertDocItemFromLinkedPrd", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<mct_I_Result> MobspInsertDocItemFromLinkedPrdWithMinStock(int? docItemId, int? userId, int? fPId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspInsertDocItemFromLinkedPrdWithMinStock", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<int?> MobspInsertQuickDocItem(string docItemParams, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string prdStockTxt, ObjectParameter resErrorMessage, ObjectParameter resInsertedDocItemIds, ObjectParameter resLinkedErrorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((docItemParams != null) ? new ObjectParameter("DocItemParams", docItemParams) : new ObjectParameter("DocItemParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((prdStockTxt != null) ? new ObjectParameter("PrdStockTxt", prdStockTxt) : new ObjectParameter("PrdStockTxt", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickDocItem", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			resErrorMessage, resInsertedDocItemIds, resLinkedErrorMessage, objectParameter11
		});
	}

	public virtual ObjectResult<int?> MobspUpdateDocItemSerial(string docItemSerialParams, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resUpdatedDocItemSerialId)
	{
		ObjectParameter objectParameter = ((docItemSerialParams != null) ? new ObjectParameter("DocItemSerialParams", docItemSerialParams) : new ObjectParameter("DocItemSerialParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateDocItemSerial", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, resErrorMessage,
			resUpdatedDocItemSerialId
		});
	}

	public virtual ObjectResult<MobspSelectAutoDocItemSerial_Result> MobspSelectAutoDocItemSerial(int? prdId, double? quantity, int? wHId)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (quantity.HasValue ? new ObjectParameter("Quantity", quantity) : new ObjectParameter("Quantity", typeof(double)));
		ObjectParameter objectParameter3 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectAutoDocItemSerial_Result>("MobspSelectAutoDocItemSerial", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnPrdQuantityByIds_Result> MobspReturnPrdQuantityByIds(string prdIds, int? fPId, int? wHId, int? currId, int? languageID, int? defaultLanguageID, double? fCR, double? fCRI, string tracing, int? centerId)
	{
		ObjectParameter objectParameter = ((prdIds != null) ? new ObjectParameter("PrdIds", prdIds) : new ObjectParameter("PrdIds", typeof(string)));
		ObjectParameter objectParameter2 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter3 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter4 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (fCR.HasValue ? new ObjectParameter("FCR", fCR) : new ObjectParameter("FCR", typeof(double)));
		ObjectParameter objectParameter8 = (fCRI.HasValue ? new ObjectParameter("FCRI", fCRI) : new ObjectParameter("FCRI", typeof(double)));
		ObjectParameter objectParameter9 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnPrdQuantityByIds_Result>("MobspReturnPrdQuantityByIds", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual int MobspImportDocItemsFromExcelMultiRec(string docItemJson, int? docId, int? whId, int? whIdI, int? mode, int? userId, DateTime? registerDate, string registerDatePersian, int? fPId, short? month1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result, int? centerId)
	{
		ObjectParameter objectParameter = ((docItemJson != null) ? new ObjectParameter("DocItemJson", docItemJson) : new ObjectParameter("DocItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter3 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter4 = (whIdI.HasValue ? new ObjectParameter("WhIdI", whIdI) : new ObjectParameter("WhIdI", typeof(int)));
		ObjectParameter objectParameter5 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspImportDocItemsFromExcelMultiRec", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, result, objectParameter14);
	}

	public virtual ObjectResult<mct_I_Result> HRMMobspRegisterDailyTimeAttendance(string tmDatePersian, int? tmUserId, string registerIP, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((tmDatePersian != null) ? new ObjectParameter("tmDatePersian", tmDatePersian) : new ObjectParameter("tmDatePersian", typeof(string)));
		ObjectParameter objectParameter2 = (tmUserId.HasValue ? new ObjectParameter("tmUserId", tmUserId) : new ObjectParameter("tmUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerIP != null) ? new ObjectParameter("RegisterIP", registerIP) : new ObjectParameter("RegisterIP", typeof(string)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("HRMMobspRegisterDailyTimeAttendance", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int MobspCheckDocItemsBeforeImportExcel(string docItemJson, int? docId, int? whId, int? whIdI, int? mode, int? userId, ObjectParameter result, int? languageID, int? defaultLanguageID, int? orderId, int? buyOrderId, int? centerId)
	{
		ObjectParameter objectParameter = ((docItemJson != null) ? new ObjectParameter("DocItemJson", docItemJson) : new ObjectParameter("DocItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter3 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter4 = (whIdI.HasValue ? new ObjectParameter("WhIdI", whIdI) : new ObjectParameter("WhIdI", typeof(int)));
		ObjectParameter objectParameter5 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter10 = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCheckDocItemsBeforeImportExcel", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, result, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<MobspSelectVerificationRequestObjectInfo_Result> MobspSelectVerificationRequestObjectInfo(int? objectId, int? objectType, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationRequestObjectInfo_Result>("MobspSelectVerificationRequestObjectInfo", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int MobspUpdateProjectFromIssueOrderFromPreOrder(string projectParams, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage)
	{
		ObjectParameter objectParameter = ((projectParams != null) ? new ObjectParameter("ProjectParams", projectParams) : new ObjectParameter("ProjectParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateProjectFromIssueOrderFromPreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, resErrorMessage);
	}

	public virtual ObjectResult<MobspSelectProductIssueOrdFromIndexedByPordId_Result> MobspSelectProductIssueOrdFromIndexedByPordId(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductIssueOrdFromIndexedByPordId_Result>("MobspSelectProductIssueOrdFromIndexedByPordId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectProductOrdIssueByPordId_Result> MobspSelectProductOrdIssueByPordId(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductOrdIssueByPordId_Result>("MobspSelectProductOrdIssueByPordId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspIssueOrderFromPreOrder(int? preOrderID, string orderDate, int? orderOprId, int? orderPrintFormatID, int? orderReferUserId, int? userId, int? month1, int? fPId, string registerDatePersian, string appType, string ordNote, int? ordSettlementTypeId, int? orderDefaultSettingId, ObjectParameter insertedOrderID, ObjectParameter insertedOrderNumber, int? languageID, string ordNoteLang, int? ordProjectId, string pordItemList, bool? isTransferFreePay, bool? isTransferFreeComm, int? ordCompanyPersonId, int? ordIssueSettingByPrdId, int? ordIssueIndexedByPrdId, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderID.HasValue ? new ObjectParameter("PreOrderID", preOrderID) : new ObjectParameter("PreOrderID", typeof(int)));
		ObjectParameter objectParameter2 = ((orderDate != null) ? new ObjectParameter("OrderDate", orderDate) : new ObjectParameter("OrderDate", typeof(string)));
		ObjectParameter objectParameter3 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter4 = (orderPrintFormatID.HasValue ? new ObjectParameter("OrderPrintFormatID", orderPrintFormatID) : new ObjectParameter("OrderPrintFormatID", typeof(int)));
		ObjectParameter objectParameter5 = (orderReferUserId.HasValue ? new ObjectParameter("OrderReferUserId", orderReferUserId) : new ObjectParameter("OrderReferUserId", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = ((ordNote != null) ? new ObjectParameter("ordNote", ordNote) : new ObjectParameter("ordNote", typeof(string)));
		ObjectParameter objectParameter12 = (ordSettlementTypeId.HasValue ? new ObjectParameter("ordSettlementTypeId", ordSettlementTypeId) : new ObjectParameter("ordSettlementTypeId", typeof(int)));
		ObjectParameter objectParameter13 = (orderDefaultSettingId.HasValue ? new ObjectParameter("OrderDefaultSettingId", orderDefaultSettingId) : new ObjectParameter("OrderDefaultSettingId", typeof(int)));
		ObjectParameter objectParameter14 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter15 = ((ordNoteLang != null) ? new ObjectParameter("ordNoteLang", ordNoteLang) : new ObjectParameter("ordNoteLang", typeof(string)));
		ObjectParameter objectParameter16 = (ordProjectId.HasValue ? new ObjectParameter("OrdProjectId", ordProjectId) : new ObjectParameter("OrdProjectId", typeof(int)));
		ObjectParameter objectParameter17 = ((pordItemList != null) ? new ObjectParameter("PordItemList", pordItemList) : new ObjectParameter("PordItemList", typeof(string)));
		ObjectParameter objectParameter18 = (isTransferFreePay.HasValue ? new ObjectParameter("IsTransferFreePay", isTransferFreePay) : new ObjectParameter("IsTransferFreePay", typeof(bool)));
		ObjectParameter objectParameter19 = (isTransferFreeComm.HasValue ? new ObjectParameter("IsTransferFreeComm", isTransferFreeComm) : new ObjectParameter("IsTransferFreeComm", typeof(bool)));
		ObjectParameter objectParameter20 = (ordCompanyPersonId.HasValue ? new ObjectParameter("ordCompanyPersonId", ordCompanyPersonId) : new ObjectParameter("ordCompanyPersonId", typeof(int)));
		ObjectParameter objectParameter21 = (ordIssueSettingByPrdId.HasValue ? new ObjectParameter("ordIssueSettingByPrdId", ordIssueSettingByPrdId) : new ObjectParameter("ordIssueSettingByPrdId", typeof(int)));
		ObjectParameter objectParameter22 = (ordIssueIndexedByPrdId.HasValue ? new ObjectParameter("ordIssueIndexedByPrdId", ordIssueIndexedByPrdId) : new ObjectParameter("ordIssueIndexedByPrdId", typeof(int)));
		ObjectParameter objectParameter23 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspIssueOrderFromPreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, insertedOrderID, insertedOrderNumber, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23);
	}

	public virtual ObjectResult<MobspReturnOrderFromDoc_Result> MobspReturnOrderFromDoc(int? docId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnOrderFromDoc_Result>("MobspReturnOrderFromDoc", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectDocItemsWithPordIPrice_Result> MobspSelectDocItemsWithPordIPrice(int? docId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDocItemsWithPordIPrice_Result>("MobspSelectDocItemsWithPordIPrice", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result> MobspSelectDeliveryScheduleByDayNumberAndDateForPrd(int? dayNumber, DateTime? date, string prdIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (dayNumber.HasValue ? new ObjectParameter("DayNumber", dayNumber) : new ObjectParameter("DayNumber", typeof(int)));
		ObjectParameter objectParameter2 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((prdIds != null) ? new ObjectParameter("PrdIds", prdIds) : new ObjectParameter("PrdIds", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDeliveryScheduleByDayNumberAndDateForPrd_Result>("MobspSelectDeliveryScheduleByDayNumberAndDateForPrd", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspCheckLastCompanyOrderHaveTax_Result> MobspCheckLastCompanyOrderHaveTax(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckLastCompanyOrderHaveTax_Result>("MobspCheckLastCompanyOrderHaveTax", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspCheckOrderHaveTax_Result> MobspCheckOrderHaveTax(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckOrderHaveTax_Result>("MobspCheckOrderHaveTax", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspCheckPreOrderHaveTax_Result> MobspCheckPreOrderHaveTax(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckPreOrderHaveTax_Result>("MobspCheckPreOrderHaveTax", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspCheckHaveCmpProjectByOrdIssuePrdId_Result> MobspCheckHaveCmpProjectByOrdIssuePrdId(int? companyId, int? productId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckHaveCmpProjectByOrdIssuePrdId_Result>("MobspCheckHaveCmpProjectByOrdIssuePrdId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectOrderOprById_Result> MobspSelectOrderOprById(int? orderOprId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderOprById_Result>("MobspSelectOrderOprById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectProductPriceGroupByPrdId_Result> MobspSelectProductPriceGroupByPrdId(int? prdId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductPriceGroupByPrdId_Result>("MobspSelectProductPriceGroupByPrdId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectProjectValidityOrdItems_Result> MobspSelectProjectValidityOrdItems(int? companyId, int? productId, int? mode, DateTime? currentDate, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (currentDate.HasValue ? new ObjectParameter("CurrentDate", currentDate) : new ObjectParameter("CurrentDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectValidityOrdItems_Result>("MobspSelectProjectValidityOrdItems", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyProjectValidityPrd_Result> FOMobspSelectCompanyProjectValidityPrd(int? companyId, DateTime? currentDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (currentDate.HasValue ? new ObjectParameter("CurrentDate", currentDate) : new ObjectParameter("CurrentDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyProjectValidityPrd_Result>("FOMobspSelectCompanyProjectValidityPrd", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int FOMobspCheckPrjValidityOrdItem(int? companyId, int? projectTitleGroupId, string projectTitleGroup, int? prjValidityPrdId, int? prjValidityOrdItemId, DateTime? currentDate, ObjectParameter hasValidiy, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectTitleGroupId.HasValue ? new ObjectParameter("ProjectTitleGroupId", projectTitleGroupId) : new ObjectParameter("ProjectTitleGroupId", typeof(int)));
		ObjectParameter objectParameter3 = ((projectTitleGroup != null) ? new ObjectParameter("ProjectTitleGroup", projectTitleGroup) : new ObjectParameter("ProjectTitleGroup", typeof(string)));
		ObjectParameter objectParameter4 = (prjValidityPrdId.HasValue ? new ObjectParameter("prjValidityPrdId", prjValidityPrdId) : new ObjectParameter("prjValidityPrdId", typeof(int)));
		ObjectParameter objectParameter5 = (prjValidityOrdItemId.HasValue ? new ObjectParameter("prjValidityOrdItemId", prjValidityOrdItemId) : new ObjectParameter("prjValidityOrdItemId", typeof(int)));
		ObjectParameter objectParameter6 = (currentDate.HasValue ? new ObjectParameter("CurrentDate", currentDate) : new ObjectParameter("CurrentDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspCheckPrjValidityOrdItem", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, hasValidiy, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<FOMobspknlgSelectKnowledgeTankByIds_Result> FOMobspknlgSelectKnowledgeTankByIds(string knowledgeTankIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((knowledgeTankIds != null) ? new ObjectParameter("KnowledgeTankIds", knowledgeTankIds) : new ObjectParameter("KnowledgeTankIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspknlgSelectKnowledgeTankByIds_Result>("FOMobspknlgSelectKnowledgeTankByIds", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyProjectById_Result> FOMobspSelectCompanyProjectById(int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyProjectById_Result>("FOMobspSelectCompanyProjectById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyProjectsFoCanSee_Result> FOMobspSelectCompanyProjectsFoCanSee(int? companyId, int? isFinished, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyProjectsFoCanSee_Result>("FOMobspSelectCompanyProjectsFoCanSee", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<FOMobspSelectPrjConversationAndFiles_Result> FOMobspSelectPrjConversationAndFiles(int? projectId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? companyPersonId, int? centerID)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter7 = (centerID.HasValue ? new ObjectParameter("CenterID", centerID) : new ObjectParameter("CenterID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectPrjConversationAndFiles_Result>("FOMobspSelectPrjConversationAndFiles", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<FOMobspknlgSelectKnowledgeTankById_Result> FOMobspknlgSelectKnowledgeTankById(int? knowledgeTankId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (knowledgeTankId.HasValue ? new ObjectParameter("KnowledgeTankId", knowledgeTankId) : new ObjectParameter("KnowledgeTankId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspknlgSelectKnowledgeTankById_Result>("FOMobspknlgSelectKnowledgeTankById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyPersonsForCnvs_Result> FOMobspSelectCompanyPersonsForCnvs(int? companyId, int? languageID, int? defaultLanguageID, int? companyPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyPersonsForCnvs_Result>("FOMobspSelectCompanyPersonsForCnvs", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<FOMobspSelectUserForCnvsReferToMultiUser_Result> FOMobspSelectUserForCnvsReferToMultiUser(int? projectId, int? linkedType, int? companyId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectUserForCnvsReferToMultiUser_Result>("FOMobspSelectUserForCnvsReferToMultiUser", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyOrders_Result> FOMobspSelectCompanyOrders(int? companyId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, long? ordNumber, int? companyPersonId, int? centerID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (ordNumber.HasValue ? new ObjectParameter("ordNumber", ordNumber) : new ObjectParameter("ordNumber", typeof(long)));
		ObjectParameter objectParameter7 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter8 = (centerID.HasValue ? new ObjectParameter("CenterID", centerID) : new ObjectParameter("CenterID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyOrders_Result>("FOMobspSelectCompanyOrders", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyPreOrders_Result> FOMobspSelectCompanyPreOrders(int? companyId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, DateTime? pordExpireDateTime, int? companyPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (pordExpireDateTime.HasValue ? new ObjectParameter("pordExpireDateTime", pordExpireDateTime) : new ObjectParameter("pordExpireDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyPreOrders_Result>("FOMobspSelectCompanyPreOrders", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<FOMobspSelectOrderItems_Result> FOMobspSelectOrderItems(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectOrderItems_Result>("FOMobspSelectOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectOrderPayments_Result> FOMobspSelectOrderPayments(int? orderId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectOrderPayments_Result>("FOMobspSelectOrderPayments", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<FOMobspSelectOrderWithId_Result> FOMobspSelectOrderWithId(int? orderId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectOrderWithId_Result>("FOMobspSelectOrderWithId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<SHPMobspSelectPreOrderPayments_Result> SHPMobspSelectPreOrderPayments(int? preOrderId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectPreOrderPayments_Result>("SHPMobspSelectPreOrderPayments", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<SHPMobspSelectPreOrderWithId_Result> SHPMobspSelectPreOrderWithId(int? preOrderId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectPreOrderWithId_Result>("SHPMobspSelectPreOrderWithId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<SHPMobspSelectProductFirstGroup_Result> SHPMobspSelectProductFirstGroup(int? showMode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectProductFirstGroup_Result>("SHPMobspSelectProductFirstGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<SHPMobspSelectProductSecondGroup_Result> SHPMobspSelectProductSecondGroup(int? showMode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectProductSecondGroup_Result>("SHPMobspSelectProductSecondGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectFoSettingTabInfo_Result> FOMobspSelectFoSettingTabInfo(int? languageID, int? defaultLanguageID, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectFoSettingTabInfo_Result>("FOMobspSelectFoSettingTabInfo", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<FOMobspSelectOnlinePayBankInfo_Result> FOMobspSelectOnlinePayBankInfo(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectOnlinePayBankInfo_Result>("FOMobspSelectOnlinePayBankInfo", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int FOMobspUpdatePreOrderPayment(int? preOrderId, int? preOrderPaymentId, decimal? pordpayAmount, string pordpayDocNumber, string pordpayDescription, string pordpayDocDate, decimal? pordpayDocAmount, DateTime? pordpayDocDateTime, int? userId, DateTime? registerDate, string registerDatePersian, int? fPId, short? month1, string appType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter3 = (pordpayAmount.HasValue ? new ObjectParameter("PordpayAmount", pordpayAmount) : new ObjectParameter("PordpayAmount", typeof(decimal)));
		ObjectParameter objectParameter4 = ((pordpayDocNumber != null) ? new ObjectParameter("PordpayDocNumber", pordpayDocNumber) : new ObjectParameter("PordpayDocNumber", typeof(string)));
		ObjectParameter objectParameter5 = ((pordpayDescription != null) ? new ObjectParameter("PordpayDescription", pordpayDescription) : new ObjectParameter("PordpayDescription", typeof(string)));
		ObjectParameter objectParameter6 = ((pordpayDocDate != null) ? new ObjectParameter("pordpayDocDate", pordpayDocDate) : new ObjectParameter("pordpayDocDate", typeof(string)));
		ObjectParameter objectParameter7 = (pordpayDocAmount.HasValue ? new ObjectParameter("pordpayDocAmount", pordpayDocAmount) : new ObjectParameter("pordpayDocAmount", typeof(decimal)));
		ObjectParameter objectParameter8 = (pordpayDocDateTime.HasValue ? new ObjectParameter("pordpayDocDateTime", pordpayDocDateTime) : new ObjectParameter("pordpayDocDateTime", typeof(DateTime)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspUpdatePreOrderPayment", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual int FOMobspDistributeDiscountToOrderItems(int? orderId, string orderItemIds, decimal? discount, decimal? discountPercent, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result, bool? addToDiscount, int? discountCodeId, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((orderItemIds != null) ? new ObjectParameter("OrderItemIds", orderItemIds) : new ObjectParameter("OrderItemIds", typeof(string)));
		ObjectParameter objectParameter3 = (discount.HasValue ? new ObjectParameter("Discount", discount) : new ObjectParameter("Discount", typeof(decimal)));
		ObjectParameter objectParameter4 = (discountPercent.HasValue ? new ObjectParameter("DiscountPercent", discountPercent) : new ObjectParameter("DiscountPercent", typeof(decimal)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (addToDiscount.HasValue ? new ObjectParameter("AddToDiscount", addToDiscount) : new ObjectParameter("AddToDiscount", typeof(bool)));
		ObjectParameter objectParameter12 = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspDistributeDiscountToOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual int FOMobspDistributeDiscountToPreOrderItems(int? preOrderId, string preOrderItemIds, decimal? discount, decimal? discountPercent, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result, bool? addToDiscount, int? discountCodeId, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((preOrderItemIds != null) ? new ObjectParameter("PreOrderItemIds", preOrderItemIds) : new ObjectParameter("PreOrderItemIds", typeof(string)));
		ObjectParameter objectParameter3 = (discount.HasValue ? new ObjectParameter("Discount", discount) : new ObjectParameter("Discount", typeof(decimal)));
		ObjectParameter objectParameter4 = (discountPercent.HasValue ? new ObjectParameter("DiscountPercent", discountPercent) : new ObjectParameter("DiscountPercent", typeof(decimal)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (addToDiscount.HasValue ? new ObjectParameter("AddToDiscount", addToDiscount) : new ObjectParameter("AddToDiscount", typeof(bool)));
		ObjectParameter objectParameter12 = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspDistributeDiscountToPreOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual int FOMobspInsertDiscountCodeHistory(int? discountCodeId, string disCode, int? disCmpId, int? disPrdId, int? orderId, int? preOrderId, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter insertedId, int? sysPartId, int? objectId)
	{
		ObjectParameter objectParameter = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter2 = ((disCode != null) ? new ObjectParameter("DisCode", disCode) : new ObjectParameter("DisCode", typeof(string)));
		ObjectParameter objectParameter3 = (disCmpId.HasValue ? new ObjectParameter("DisCmpId", disCmpId) : new ObjectParameter("DisCmpId", typeof(int)));
		ObjectParameter objectParameter4 = (disPrdId.HasValue ? new ObjectParameter("DisPrdId", disPrdId) : new ObjectParameter("DisPrdId", typeof(int)));
		ObjectParameter objectParameter5 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter6 = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (sysPartId.HasValue ? new ObjectParameter("SysPartId", sysPartId) : new ObjectParameter("SysPartId", typeof(int)));
		ObjectParameter objectParameter15 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInsertDiscountCodeHistory", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, insertedId, objectParameter14, objectParameter15);
	}

	public virtual ObjectResult<FOMobspSelectDiscountCodeByDisCode_Result> FOMobspSelectDiscountCodeByDisCode(string disCode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((disCode != null) ? new ObjectParameter("DisCode", disCode) : new ObjectParameter("DisCode", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectDiscountCodeByDisCode_Result>("FOMobspSelectDiscountCodeByDisCode", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result> FOMobspSelectOrderItemsByNotInSumAndNoDis(int? orderId, bool? ordINotInSum, bool? prdNoDiscount, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (ordINotInSum.HasValue ? new ObjectParameter("OrdINotInSum", ordINotInSum) : new ObjectParameter("OrdINotInSum", typeof(bool)));
		ObjectParameter objectParameter3 = (prdNoDiscount.HasValue ? new ObjectParameter("PrdNoDiscount", prdNoDiscount) : new ObjectParameter("PrdNoDiscount", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectOrderItemsByNotInSumAndNoDis_Result>("FOMobspSelectOrderItemsByNotInSumAndNoDis", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result> FOMobspSelectPreOrderItemsByNotInSumAndNoDis(int? preOrderId, bool? pordINotInSum, bool? prdNoDiscount, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (pordINotInSum.HasValue ? new ObjectParameter("PordINotInSum", pordINotInSum) : new ObjectParameter("PordINotInSum", typeof(bool)));
		ObjectParameter objectParameter3 = (prdNoDiscount.HasValue ? new ObjectParameter("PrdNoDiscount", prdNoDiscount) : new ObjectParameter("PrdNoDiscount", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result>("FOMobspSelectPreOrderItemsByNotInSumAndNoDis", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int FOMobspUpdateOrderPayment(int? orderId, int? orderPaymentId, decimal? ordpayAmount, string ordpayDocNumber, string ordpayDescription, string ordpayDocDate, decimal? ordpayDocAmount, DateTime? ordpayDocDateTime, int? userId, DateTime? registerDate, string registerDatePersian, int? fPId, short? month1, string appType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter3 = (ordpayAmount.HasValue ? new ObjectParameter("OrdpayAmount", ordpayAmount) : new ObjectParameter("OrdpayAmount", typeof(decimal)));
		ObjectParameter objectParameter4 = ((ordpayDocNumber != null) ? new ObjectParameter("OrdpayDocNumber", ordpayDocNumber) : new ObjectParameter("OrdpayDocNumber", typeof(string)));
		ObjectParameter objectParameter5 = ((ordpayDescription != null) ? new ObjectParameter("OrdpayDescription", ordpayDescription) : new ObjectParameter("OrdpayDescription", typeof(string)));
		ObjectParameter objectParameter6 = ((ordpayDocDate != null) ? new ObjectParameter("OrdpayDocDate", ordpayDocDate) : new ObjectParameter("OrdpayDocDate", typeof(string)));
		ObjectParameter objectParameter7 = (ordpayDocAmount.HasValue ? new ObjectParameter("OrdpayDocAmount", ordpayDocAmount) : new ObjectParameter("OrdpayDocAmount", typeof(decimal)));
		ObjectParameter objectParameter8 = (ordpayDocDateTime.HasValue ? new ObjectParameter("OrdpayDocDateTime", ordpayDocDateTime) : new ObjectParameter("OrdpayDocDateTime", typeof(DateTime)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspUpdateOrderPayment", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual ObjectResult<FOMobspReturnSumCompanyScores_Result> FOMobspReturnSumCompanyScores(int? companyID, int? centerId)
	{
		ObjectParameter objectParameter = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspReturnSumCompanyScores_Result>("FOMobspReturnSumCompanyScores", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int FOMobspInsertInternalMessageLang(int? internalMessageId, string msgSubject, string msgBody, int? languageID)
	{
		ObjectParameter objectParameter = (internalMessageId.HasValue ? new ObjectParameter("InternalMessageId", internalMessageId) : new ObjectParameter("InternalMessageId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("msgSubject", msgSubject) : new ObjectParameter("msgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("msgBody", msgBody) : new ObjectParameter("msgBody", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInsertInternalMessageLang", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int FOMobspInsertInternalMessageLangByLangId(int? internalMessageId, string msgSubject, string msgBody, int? languageID)
	{
		ObjectParameter objectParameter = (internalMessageId.HasValue ? new ObjectParameter("InternalMessageId", internalMessageId) : new ObjectParameter("InternalMessageId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("msgSubject", msgSubject) : new ObjectParameter("msgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("msgBody", msgBody) : new ObjectParameter("msgBody", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInsertInternalMessageLangByLangId", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int FOMobspInternalMessageSendSingle(int? msgMasterId, string msgSubject, string msgBody, int? msgdTypeId, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? msgdPriorityId, string msgdAttachFile, int? msgdAttachRecId, string msgdAttachRecDesc, int? msgdGroupId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter insertedID, int? languageID, int? msgdAttachRecIdI, string msgdAttachRecDescI, int? centerId)
	{
		ObjectParameter objectParameter = (msgMasterId.HasValue ? new ObjectParameter("msgMasterId", msgMasterId) : new ObjectParameter("msgMasterId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("msgSubject", msgSubject) : new ObjectParameter("msgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("msgBody", msgBody) : new ObjectParameter("msgBody", typeof(string)));
		ObjectParameter objectParameter4 = (msgdTypeId.HasValue ? new ObjectParameter("msgdTypeId", msgdTypeId) : new ObjectParameter("msgdTypeId", typeof(int)));
		ObjectParameter objectParameter5 = (msgdFromUserId.HasValue ? new ObjectParameter("msgdFromUserId", msgdFromUserId) : new ObjectParameter("msgdFromUserId", typeof(int)));
		ObjectParameter objectParameter6 = (msgdToUserId.HasValue ? new ObjectParameter("msgdToUserId", msgdToUserId) : new ObjectParameter("msgdToUserId", typeof(int)));
		ObjectParameter objectParameter7 = ((msgdSendDate != null) ? new ObjectParameter("msgdSendDate", msgdSendDate) : new ObjectParameter("msgdSendDate", typeof(string)));
		ObjectParameter objectParameter8 = ((msgdSendTime != null) ? new ObjectParameter("msgdSendTime", msgdSendTime) : new ObjectParameter("msgdSendTime", typeof(string)));
		ObjectParameter objectParameter9 = (msgdSendDateTime.HasValue ? new ObjectParameter("msgdSendDateTime", msgdSendDateTime) : new ObjectParameter("msgdSendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter10 = (msgdPriorityId.HasValue ? new ObjectParameter("msgdPriorityId", msgdPriorityId) : new ObjectParameter("msgdPriorityId", typeof(int)));
		ObjectParameter objectParameter11 = ((msgdAttachFile != null) ? new ObjectParameter("msgdAttachFile", msgdAttachFile) : new ObjectParameter("msgdAttachFile", typeof(string)));
		ObjectParameter objectParameter12 = (msgdAttachRecId.HasValue ? new ObjectParameter("msgdAttachRecId", msgdAttachRecId) : new ObjectParameter("msgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter13 = ((msgdAttachRecDesc != null) ? new ObjectParameter("msgdAttachRecDesc", msgdAttachRecDesc) : new ObjectParameter("msgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter14 = (msgdGroupId.HasValue ? new ObjectParameter("msgdGroupId", msgdGroupId) : new ObjectParameter("msgdGroupId", typeof(int)));
		ObjectParameter objectParameter15 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter16 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter17 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter18 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter19 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter20 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter21 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter22 = (msgdAttachRecIdI.HasValue ? new ObjectParameter("msgdAttachRecIdI", msgdAttachRecIdI) : new ObjectParameter("msgdAttachRecIdI", typeof(int)));
		ObjectParameter objectParameter23 = ((msgdAttachRecDescI != null) ? new ObjectParameter("msgdAttachRecDescI", msgdAttachRecDescI) : new ObjectParameter("msgdAttachRecDescI", typeof(string)));
		ObjectParameter objectParameter24 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInternalMessageSendSingle", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, insertedID, objectParameter21, objectParameter22, objectParameter23, objectParameter24);
	}

	public virtual ObjectResult<ScorespSelectOrderScores_Result> ScorespSelectOrderScores(int? orderId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ScorespSelectOrderScores_Result>("ScorespSelectOrderScores", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectOrderPaymentsWithId_Result> MobspSelectOrderPaymentsWithId(int? orderPaymentId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderPaymentsWithId_Result>("MobspSelectOrderPaymentsWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateOrderLinkAccControl(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateOrderLinkAccControl", objectParameter);
	}

	public virtual int MobspSendSmsOrdFOLinkAfterVerify(int? orderId, string foLink, string foLinkWithLogin, string foLinkWithoutLogin, int? userId, int? year1, int? month1, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result, string crmLinkWithoutLogin, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((foLink != null) ? new ObjectParameter("FoLink", foLink) : new ObjectParameter("FoLink", typeof(string)));
		ObjectParameter objectParameter3 = ((foLinkWithLogin != null) ? new ObjectParameter("FoLinkWithLogin", foLinkWithLogin) : new ObjectParameter("FoLinkWithLogin", typeof(string)));
		ObjectParameter objectParameter4 = ((foLinkWithoutLogin != null) ? new ObjectParameter("FoLinkWithoutLogin", foLinkWithoutLogin) : new ObjectParameter("FoLinkWithoutLogin", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = ((crmLinkWithoutLogin != null) ? new ObjectParameter("CrmLinkWithoutLogin", crmLinkWithoutLogin) : new ObjectParameter("CrmLinkWithoutLogin", typeof(string)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSendSmsOrdFOLinkAfterVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, result, objectParameter12, objectParameter13);
	}

	public virtual ObjectResult<WSspRpt_PrintDocItemsFromQuantity_Result> WSspRpt_PrintDocItemsFromQuantity(int? docID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintDocItemsFromQuantity_Result>("WSspRpt_PrintDocItemsFromQuantity", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int FOMobspInsertPrintLog(int? printFormatTypeId, int? objectId, DateTime? printDateTime, int? printUserId, int? printCmpId, DateTime? seenDateTime, int? seenUserId, int? seenCmpId, DateTime? downloadDateTime, int? downloadUserId, int? downloadCmpId, string appType, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (printFormatTypeId.HasValue ? new ObjectParameter("PrintFormatTypeId", printFormatTypeId) : new ObjectParameter("PrintFormatTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = (printDateTime.HasValue ? new ObjectParameter("PrintDateTime", printDateTime) : new ObjectParameter("PrintDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (printUserId.HasValue ? new ObjectParameter("PrintUserId", printUserId) : new ObjectParameter("PrintUserId", typeof(int)));
		ObjectParameter objectParameter5 = (printCmpId.HasValue ? new ObjectParameter("PrintCmpId", printCmpId) : new ObjectParameter("PrintCmpId", typeof(int)));
		ObjectParameter objectParameter6 = (seenDateTime.HasValue ? new ObjectParameter("SeenDateTime", seenDateTime) : new ObjectParameter("SeenDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (seenUserId.HasValue ? new ObjectParameter("SeenUserId", seenUserId) : new ObjectParameter("SeenUserId", typeof(int)));
		ObjectParameter objectParameter8 = (seenCmpId.HasValue ? new ObjectParameter("SeenCmpId", seenCmpId) : new ObjectParameter("SeenCmpId", typeof(int)));
		ObjectParameter objectParameter9 = (downloadDateTime.HasValue ? new ObjectParameter("DownloadDateTime", downloadDateTime) : new ObjectParameter("DownloadDateTime", typeof(DateTime)));
		ObjectParameter objectParameter10 = (downloadUserId.HasValue ? new ObjectParameter("DownloadUserId", downloadUserId) : new ObjectParameter("DownloadUserId", typeof(int)));
		ObjectParameter objectParameter11 = (downloadCmpId.HasValue ? new ObjectParameter("DownloadCmpId", downloadCmpId) : new ObjectParameter("DownloadCmpId", typeof(int)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInsertPrintLog", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual ObjectResult<FOMobspSelectPrintLogWithPaging_Result> FOMobspSelectPrintLogWithPaging(int? companyId, int? printFormatTypeId, int? objectId, int? topValue, long? lastRowNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (printFormatTypeId.HasValue ? new ObjectParameter("PrintFormatTypeId", printFormatTypeId) : new ObjectParameter("PrintFormatTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter4 = (topValue.HasValue ? new ObjectParameter("TopValue", topValue) : new ObjectParameter("TopValue", typeof(int)));
		ObjectParameter objectParameter5 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(long)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectPrintLogWithPaging_Result>("FOMobspSelectPrintLogWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual int HRMMobspDeleteUserPicturesByUserId(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspDeleteUserPicturesByUserId", objectParameter);
	}

	public virtual int HRMMobspInsertUpdateUserPicture(byte[] userPicture, int? crmUserId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((userPicture != null) ? new ObjectParameter("UserPicture", userPicture) : new ObjectParameter("UserPicture", typeof(byte[])));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspInsertUpdateUserPicture", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int MobspInsertPrintLog(int? printFormatTypeId, int? objectId, DateTime? printDateTime, int? printUserId, int? printCmpId, DateTime? seenDateTime, int? seenUserId, int? seenCmpId, DateTime? downloadDateTime, int? downloadUserId, int? downloadCmpId, string appType, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (printFormatTypeId.HasValue ? new ObjectParameter("PrintFormatTypeId", printFormatTypeId) : new ObjectParameter("PrintFormatTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = (printDateTime.HasValue ? new ObjectParameter("PrintDateTime", printDateTime) : new ObjectParameter("PrintDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (printUserId.HasValue ? new ObjectParameter("PrintUserId", printUserId) : new ObjectParameter("PrintUserId", typeof(int)));
		ObjectParameter objectParameter5 = (printCmpId.HasValue ? new ObjectParameter("PrintCmpId", printCmpId) : new ObjectParameter("PrintCmpId", typeof(int)));
		ObjectParameter objectParameter6 = (seenDateTime.HasValue ? new ObjectParameter("SeenDateTime", seenDateTime) : new ObjectParameter("SeenDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (seenUserId.HasValue ? new ObjectParameter("SeenUserId", seenUserId) : new ObjectParameter("SeenUserId", typeof(int)));
		ObjectParameter objectParameter8 = (seenCmpId.HasValue ? new ObjectParameter("SeenCmpId", seenCmpId) : new ObjectParameter("SeenCmpId", typeof(int)));
		ObjectParameter objectParameter9 = (downloadDateTime.HasValue ? new ObjectParameter("DownloadDateTime", downloadDateTime) : new ObjectParameter("DownloadDateTime", typeof(DateTime)));
		ObjectParameter objectParameter10 = (downloadUserId.HasValue ? new ObjectParameter("DownloadUserId", downloadUserId) : new ObjectParameter("DownloadUserId", typeof(int)));
		ObjectParameter objectParameter11 = (downloadCmpId.HasValue ? new ObjectParameter("DownloadCmpId", downloadCmpId) : new ObjectParameter("DownloadCmpId", typeof(int)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertPrintLog", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual ObjectResult<MobspSelectPrintLogWithPaging_Result> MobspSelectPrintLogWithPaging(int? printFormatTypeId, int? objectId, int? topValue, long? lastRowNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (printFormatTypeId.HasValue ? new ObjectParameter("PrintFormatTypeId", printFormatTypeId) : new ObjectParameter("PrintFormatTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = (topValue.HasValue ? new ObjectParameter("TopValue", topValue) : new ObjectParameter("TopValue", typeof(int)));
		ObjectParameter objectParameter4 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(long)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPrintLogWithPaging_Result>("MobspSelectPrintLogWithPaging", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<HRMMobspSelectUsersById_Result> HRMMobspSelectUsersById(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectUsersById_Result>("HRMMobspSelectUsersById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<HRMMobspSelectBankingAccountsByUserId_Result> HRMMobspSelectBankingAccountsByUserId(int? crmUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectBankingAccountsByUserId_Result>("HRMMobspSelectBankingAccountsByUserId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<HRMMobspSelectEmailUsersInfoByUser_Result> HRMMobspSelectEmailUsersInfoByUser(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectEmailUsersInfoByUser_Result>("HRMMobspSelectEmailUsersInfoByUser", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> FOMobspDeleteCompanyAppDeviceInfo(string deviceId, int? deviceType)
	{
		ObjectParameter objectParameter = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter2 = (deviceType.HasValue ? new ObjectParameter("DeviceType", deviceType) : new ObjectParameter("DeviceType", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspDeleteCompanyAppDeviceInfo", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int FOMobspInsertCompanyAppDeviceInfo(int? companyId, string deviceId, int? deviceType, DateTime? firstRegisterDate, string firstRegisterDatePersian, string imeiCode, string appName, string aESKey)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter3 = (deviceType.HasValue ? new ObjectParameter("DeviceType", deviceType) : new ObjectParameter("DeviceType", typeof(int)));
		ObjectParameter objectParameter4 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter7 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		ObjectParameter objectParameter8 = ((aESKey != null) ? new ObjectParameter("AESKey", aESKey) : new ObjectParameter("AESKey", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInsertCompanyAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<FOMobspSelectCrmFilesDirectory_Result> FOMobspSelectCrmFilesDirectory(int? fileDirectoryId)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCrmFilesDirectory_Result>("FOMobspSelectCrmFilesDirectory", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<HRMMobspSelectCrmFilesDirectory_Result> HRMMobspSelectCrmFilesDirectory(int? fileDirectoryId)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectCrmFilesDirectory_Result>("HRMMobspSelectCrmFilesDirectory", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectLetterDefaultSettingsByUser_Result> MobspSelectLetterDefaultSettingsByUser(int? referUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLetterDefaultSettingsByUser_Result>("MobspSelectLetterDefaultSettingsByUser", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectLetterNumberCounterByTypeId_Result> MobspSelectLetterNumberCounterByTypeId(int? letterTypeId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (letterTypeId.HasValue ? new ObjectParameter("LetterTypeId", letterTypeId) : new ObjectParameter("LetterTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLetterNumberCounterByTypeId_Result>("MobspSelectLetterNumberCounterByTypeId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectDocs_Result> MobspSelectDocs(int? userId, int? oprType, int? docId, int? languageID, int? defaultLanguageID, DateTime? fDateTime, DateTime? tDateTime, string manualIssuing, string systemIssuing, int? pageNumber, int? pageSize, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (oprType.HasValue ? new ObjectParameter("OprType", oprType) : new ObjectParameter("OprType", typeof(int)));
		ObjectParameter objectParameter3 = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((manualIssuing != null) ? new ObjectParameter("ManualIssuing", manualIssuing) : new ObjectParameter("ManualIssuing", typeof(string)));
		ObjectParameter objectParameter9 = ((systemIssuing != null) ? new ObjectParameter("SystemIssuing", systemIssuing) : new ObjectParameter("SystemIssuing", typeof(string)));
		ObjectParameter objectParameter10 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter11 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDocs_Result>("MobspSelectDocs", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<int?> MobspInsertLetter(string letterParams, int? userId, int? fPId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resInsertedLetterId)
	{
		ObjectParameter objectParameter = ((letterParams != null) ? new ObjectParameter("LetterParams", letterParams) : new ObjectParameter("LetterParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertLetter", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			resErrorMessage, resInsertedLetterId
		});
	}

	public virtual ObjectResult<int?> MobspUpdateLetter(string letterParams, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resUpdatedLetterId)
	{
		ObjectParameter objectParameter = ((letterParams != null) ? new ObjectParameter("LetterParams", letterParams) : new ObjectParameter("LetterParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateLetter", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, resErrorMessage, resUpdatedLetterId });
	}

	public virtual ObjectResult<int?> MobspReturnMobLetterCnt(int? centerId)
	{
		ObjectParameter objectParameter = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnMobLetterCnt", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectLettersByType_Result> MobspSelectLettersByType(int? letterTypeId, int? userId, int? letterId, DateTime? fDateTime, DateTime? tDateTime, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (letterTypeId.HasValue ? new ObjectParameter("LetterTypeId", letterTypeId) : new ObjectParameter("LetterTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		ObjectParameter objectParameter4 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLettersByType_Result>("MobspSelectLettersByType", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspLetterIndicator_Result> MobspLetterIndicator(string letterTypeId, string letterPreNumber, string letterNumber, string letterNumberII, string letterAnnex, string letterAnnexLikely, string letterCompanyNameId, string letterSubject, string letterSubjectLikely, string letterHeader, string letterHeaderLikely, string letterContext, string letterContextLikely, string letterFooter, string letterFooterLikely, string letterRegUsersId, string letterVerifierId, string letterVerifyStatusId, string letterPrintStatusId, string rptUserId, string rptDate, string rptDay, DateTime? letterFDateTime, DateTime? letterTDateTime, DateTime? letterRegFDateTime, DateTime? letterRegTDateTime, DateTime? letterPrintFDateTime, DateTime? letterPrintTDateTime, string letterNumberCounterId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((letterTypeId != null) ? new ObjectParameter("LetterTypeId", letterTypeId) : new ObjectParameter("LetterTypeId", typeof(string)));
		ObjectParameter objectParameter2 = ((letterPreNumber != null) ? new ObjectParameter("LetterPreNumber", letterPreNumber) : new ObjectParameter("LetterPreNumber", typeof(string)));
		ObjectParameter objectParameter3 = ((letterNumber != null) ? new ObjectParameter("LetterNumber", letterNumber) : new ObjectParameter("LetterNumber", typeof(string)));
		ObjectParameter objectParameter4 = ((letterNumberII != null) ? new ObjectParameter("LetterNumberII", letterNumberII) : new ObjectParameter("LetterNumberII", typeof(string)));
		ObjectParameter objectParameter5 = ((letterAnnex != null) ? new ObjectParameter("LetterAnnex", letterAnnex) : new ObjectParameter("LetterAnnex", typeof(string)));
		ObjectParameter objectParameter6 = ((letterAnnexLikely != null) ? new ObjectParameter("LetterAnnexLikely", letterAnnexLikely) : new ObjectParameter("LetterAnnexLikely", typeof(string)));
		ObjectParameter objectParameter7 = ((letterCompanyNameId != null) ? new ObjectParameter("LetterCompanyNameId", letterCompanyNameId) : new ObjectParameter("LetterCompanyNameId", typeof(string)));
		ObjectParameter objectParameter8 = ((letterSubject != null) ? new ObjectParameter("LetterSubject", letterSubject) : new ObjectParameter("LetterSubject", typeof(string)));
		ObjectParameter objectParameter9 = ((letterSubjectLikely != null) ? new ObjectParameter("LetterSubjectLikely", letterSubjectLikely) : new ObjectParameter("LetterSubjectLikely", typeof(string)));
		ObjectParameter objectParameter10 = ((letterHeader != null) ? new ObjectParameter("LetterHeader", letterHeader) : new ObjectParameter("LetterHeader", typeof(string)));
		ObjectParameter objectParameter11 = ((letterHeaderLikely != null) ? new ObjectParameter("LetterHeaderLikely", letterHeaderLikely) : new ObjectParameter("LetterHeaderLikely", typeof(string)));
		ObjectParameter objectParameter12 = ((letterContext != null) ? new ObjectParameter("LetterContext", letterContext) : new ObjectParameter("LetterContext", typeof(string)));
		ObjectParameter objectParameter13 = ((letterContextLikely != null) ? new ObjectParameter("LetterContextLikely", letterContextLikely) : new ObjectParameter("LetterContextLikely", typeof(string)));
		ObjectParameter objectParameter14 = ((letterFooter != null) ? new ObjectParameter("LetterFooter", letterFooter) : new ObjectParameter("LetterFooter", typeof(string)));
		ObjectParameter objectParameter15 = ((letterFooterLikely != null) ? new ObjectParameter("LetterFooterLikely", letterFooterLikely) : new ObjectParameter("LetterFooterLikely", typeof(string)));
		ObjectParameter objectParameter16 = ((letterRegUsersId != null) ? new ObjectParameter("LetterRegUsersId", letterRegUsersId) : new ObjectParameter("LetterRegUsersId", typeof(string)));
		ObjectParameter objectParameter17 = ((letterVerifierId != null) ? new ObjectParameter("LetterVerifierId", letterVerifierId) : new ObjectParameter("LetterVerifierId", typeof(string)));
		ObjectParameter objectParameter18 = ((letterVerifyStatusId != null) ? new ObjectParameter("LetterVerifyStatusId", letterVerifyStatusId) : new ObjectParameter("LetterVerifyStatusId", typeof(string)));
		ObjectParameter objectParameter19 = ((letterPrintStatusId != null) ? new ObjectParameter("LetterPrintStatusId", letterPrintStatusId) : new ObjectParameter("LetterPrintStatusId", typeof(string)));
		ObjectParameter objectParameter20 = ((rptUserId != null) ? new ObjectParameter("rptUserId", rptUserId) : new ObjectParameter("rptUserId", typeof(string)));
		ObjectParameter objectParameter21 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter22 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter23 = (letterFDateTime.HasValue ? new ObjectParameter("LetterFDateTime", letterFDateTime) : new ObjectParameter("LetterFDateTime", typeof(DateTime)));
		ObjectParameter objectParameter24 = (letterTDateTime.HasValue ? new ObjectParameter("LetterTDateTime", letterTDateTime) : new ObjectParameter("LetterTDateTime", typeof(DateTime)));
		ObjectParameter objectParameter25 = (letterRegFDateTime.HasValue ? new ObjectParameter("LetterRegFDateTime", letterRegFDateTime) : new ObjectParameter("LetterRegFDateTime", typeof(DateTime)));
		ObjectParameter objectParameter26 = (letterRegTDateTime.HasValue ? new ObjectParameter("LetterRegTDateTime", letterRegTDateTime) : new ObjectParameter("LetterRegTDateTime", typeof(DateTime)));
		ObjectParameter objectParameter27 = (letterPrintFDateTime.HasValue ? new ObjectParameter("LetterPrintFDateTime", letterPrintFDateTime) : new ObjectParameter("LetterPrintFDateTime", typeof(DateTime)));
		ObjectParameter objectParameter28 = (letterPrintTDateTime.HasValue ? new ObjectParameter("LetterPrintTDateTime", letterPrintTDateTime) : new ObjectParameter("LetterPrintTDateTime", typeof(DateTime)));
		ObjectParameter objectParameter29 = ((letterNumberCounterId != null) ? new ObjectParameter("LetterNumberCounterId", letterNumberCounterId) : new ObjectParameter("LetterNumberCounterId", typeof(string)));
		ObjectParameter objectParameter30 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter31 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter32 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter33 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter34 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLetterIndicator_Result>("MobspLetterIndicator", new ObjectParameter[34]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			objectParameter31, objectParameter32, objectParameter33, objectParameter34
		});
	}

	public virtual ObjectResult<MobspSearchCompanyQuickI_Result> MobspSearchCompanyQuickI(string val, int? userID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSearchCompanyQuickI_Result>("MobspSearchCompanyQuickI", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteSecLetters(int? letterId)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteSecLetters", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectCompanyDocs_Result> MobspSelectCompanyDocs(int? userId, int? oprType, int? companyId, string manualIssuing, string systemIssuing, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (oprType.HasValue ? new ObjectParameter("OprType", oprType) : new ObjectParameter("OprType", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = ((manualIssuing != null) ? new ObjectParameter("ManualIssuing", manualIssuing) : new ObjectParameter("ManualIssuing", typeof(string)));
		ObjectParameter objectParameter5 = ((systemIssuing != null) ? new ObjectParameter("SystemIssuing", systemIssuing) : new ObjectParameter("SystemIssuing", typeof(string)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyDocs_Result>("MobspSelectCompanyDocs", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<int?> MobspReturnEmailCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnEmailCnt", Array.Empty<ObjectParameter>());
	}

	public virtual int MobspInsertEmailSendDetail(int? emailSendHeaderId, string emailAddress, int? emailCmpId, int? emailCmpPrsId, int? emailCmpPrjId, string emailCmpPrsName, string emailCmpName, string emailPrsJob, DateTime? sendDateTime, string sendDatePersian, DateTime? sendedDateTime, string sendedDatePersian, int? statusId, int? userId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, bool? isFromEmailUserTempTank, string emailAddressIds)
	{
		ObjectParameter objectParameter = (emailSendHeaderId.HasValue ? new ObjectParameter("EmailSendHeaderId", emailSendHeaderId) : new ObjectParameter("EmailSendHeaderId", typeof(int)));
		ObjectParameter objectParameter2 = ((emailAddress != null) ? new ObjectParameter("EmailAddress", emailAddress) : new ObjectParameter("EmailAddress", typeof(string)));
		ObjectParameter objectParameter3 = (emailCmpId.HasValue ? new ObjectParameter("EmailCmpId", emailCmpId) : new ObjectParameter("EmailCmpId", typeof(int)));
		ObjectParameter objectParameter4 = (emailCmpPrsId.HasValue ? new ObjectParameter("EmailCmpPrsId", emailCmpPrsId) : new ObjectParameter("EmailCmpPrsId", typeof(int)));
		ObjectParameter objectParameter5 = (emailCmpPrjId.HasValue ? new ObjectParameter("EmailCmpPrjId", emailCmpPrjId) : new ObjectParameter("EmailCmpPrjId", typeof(int)));
		ObjectParameter objectParameter6 = ((emailCmpPrsName != null) ? new ObjectParameter("EmailCmpPrsName", emailCmpPrsName) : new ObjectParameter("EmailCmpPrsName", typeof(string)));
		ObjectParameter objectParameter7 = ((emailCmpName != null) ? new ObjectParameter("EmailCmpName", emailCmpName) : new ObjectParameter("EmailCmpName", typeof(string)));
		ObjectParameter objectParameter8 = ((emailPrsJob != null) ? new ObjectParameter("EmailPrsJob", emailPrsJob) : new ObjectParameter("EmailPrsJob", typeof(string)));
		ObjectParameter objectParameter9 = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((sendDatePersian != null) ? new ObjectParameter("SendDatePersian", sendDatePersian) : new ObjectParameter("SendDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = (sendedDateTime.HasValue ? new ObjectParameter("SendedDateTime", sendedDateTime) : new ObjectParameter("SendedDateTime", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((sendedDatePersian != null) ? new ObjectParameter("SendedDatePersian", sendedDatePersian) : new ObjectParameter("SendedDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = (statusId.HasValue ? new ObjectParameter("StatusId", statusId) : new ObjectParameter("StatusId", typeof(int)));
		ObjectParameter objectParameter14 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter18 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (isFromEmailUserTempTank.HasValue ? new ObjectParameter("IsFromEmailUserTempTank", isFromEmailUserTempTank) : new ObjectParameter("IsFromEmailUserTempTank", typeof(bool)));
		ObjectParameter objectParameter20 = ((emailAddressIds != null) ? new ObjectParameter("EmailAddressIds", emailAddressIds) : new ObjectParameter("EmailAddressIds", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertEmailSendDetail", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20);
	}

	public virtual ObjectResult<decimal?> MobspInsertEmailSendHeader(int? userId, string subject, string body, DateTime? startDateTime, string startDatePersian, DateTime? endDateTime, string endDatePersian, int? priorityId, DateTime? registerDate, string registerDatePersian, int? emailUsersInfoId, int? emailSettingId, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((subject != null) ? new ObjectParameter("Subject", subject) : new ObjectParameter("Subject", typeof(string)));
		ObjectParameter objectParameter3 = ((body != null) ? new ObjectParameter("Body", body) : new ObjectParameter("Body", typeof(string)));
		ObjectParameter objectParameter4 = (startDateTime.HasValue ? new ObjectParameter("StartDateTime", startDateTime) : new ObjectParameter("StartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((startDatePersian != null) ? new ObjectParameter("StartDatePersian", startDatePersian) : new ObjectParameter("StartDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (endDateTime.HasValue ? new ObjectParameter("EndDateTime", endDateTime) : new ObjectParameter("EndDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((endDatePersian != null) ? new ObjectParameter("EndDatePersian", endDatePersian) : new ObjectParameter("EndDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = (priorityId.HasValue ? new ObjectParameter("PriorityId", priorityId) : new ObjectParameter("PriorityId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = (emailUsersInfoId.HasValue ? new ObjectParameter("EmailUsersInfoId", emailUsersInfoId) : new ObjectParameter("EmailUsersInfoId", typeof(int)));
		ObjectParameter objectParameter12 = (emailSettingId.HasValue ? new ObjectParameter("EmailSettingId", emailSettingId) : new ObjectParameter("EmailSettingId", typeof(int)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<decimal?>("MobspInsertEmailSendHeader", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual ObjectResult<decimal?> MobspInsertEmailSendAttachment(int? emailSendHeaderId, string fileName, string filePath, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? firstRegisterUserId)
	{
		ObjectParameter objectParameter = (emailSendHeaderId.HasValue ? new ObjectParameter("EmailSendHeaderId", emailSendHeaderId) : new ObjectParameter("EmailSendHeaderId", typeof(int)));
		ObjectParameter objectParameter2 = ((fileName != null) ? new ObjectParameter("FileName", fileName) : new ObjectParameter("FileName", typeof(string)));
		ObjectParameter objectParameter3 = ((filePath != null) ? new ObjectParameter("FilePath", filePath) : new ObjectParameter("FilePath", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<decimal?>("MobspInsertEmailSendAttachment", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspSelectCompanyAddresses_Result> MobspSelectCompanyAddresses(int? companyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyAddresses_Result>("MobspSelectCompanyAddresses", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectCompanyAddressType_Result> MobspSelectCompanyAddressType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyAddressType_Result>("MobspSelectCompanyAddressType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspInsertCompanyAddresses(string companyAdressParams, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resInsertedId)
	{
		ObjectParameter objectParameter = ((companyAdressParams != null) ? new ObjectParameter("CompanyAdressParams", companyAdressParams) : new ObjectParameter("CompanyAdressParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertCompanyAddresses", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, resErrorMessage,
			resInsertedId
		});
	}

	public virtual ObjectResult<int?> MobspUpdateCompanyAddresses(string companyAdressParams, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resUpdatedId)
	{
		ObjectParameter objectParameter = ((companyAdressParams != null) ? new ObjectParameter("CompanyAdressParams", companyAdressParams) : new ObjectParameter("CompanyAdressParams", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCompanyAddresses", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, resErrorMessage,
			resUpdatedId
		});
	}

	public virtual int MobspDocIsFixed(int? docId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDocIsFixed", objectParameter);
	}

	public virtual int MobspOrderIsFixed(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderIsFixed", objectParameter);
	}

	public virtual int MobspPreOrderIsFixed(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderIsFixed", objectParameter);
	}

	public virtual ObjectResult<mct_I_Result> MobspDeleteCompanyAddress(int? companyAddressId)
	{
		ObjectParameter objectParameter = (companyAddressId.HasValue ? new ObjectParameter("CompanyAddressId", companyAddressId) : new ObjectParameter("CompanyAddressId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_I_Result>("MobspDeleteCompanyAddress", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectTicketNotFinishedCount_Result> MobspSelectTicketNotFinishedCount(int? userId, string prjTitleGroup, int? prjTitleGroupId, int? cnvsStatusGroupId, int? cnvsStatusId, int? priorityId, int? crmUserId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((prjTitleGroup != null) ? new ObjectParameter("PrjTitleGroup", prjTitleGroup) : new ObjectParameter("PrjTitleGroup", typeof(string)));
		ObjectParameter objectParameter3 = (prjTitleGroupId.HasValue ? new ObjectParameter("PrjTitleGroupId", prjTitleGroupId) : new ObjectParameter("PrjTitleGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (cnvsStatusGroupId.HasValue ? new ObjectParameter("CnvsStatusGroupId", cnvsStatusGroupId) : new ObjectParameter("CnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (cnvsStatusId.HasValue ? new ObjectParameter("CnvsStatusId", cnvsStatusId) : new ObjectParameter("CnvsStatusId", typeof(int)));
		ObjectParameter objectParameter6 = (priorityId.HasValue ? new ObjectParameter("PriorityId", priorityId) : new ObjectParameter("PriorityId", typeof(int)));
		ObjectParameter objectParameter7 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTicketNotFinishedCount_Result>("MobspSelectTicketNotFinishedCount", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<HRMMobspSelectCompanyAddresses_Result> HRMMobspSelectCompanyAddresses(int? companyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectCompanyAddresses_Result>("HRMMobspSelectCompanyAddresses", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspUserTreeStatusCartableByStatus_Result> MobspUserTreeStatusCartableByStatus(int? userId, int? selectedUserId, int? linkedType, string allStatusText, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (selectedUserId.HasValue ? new ObjectParameter("SelectedUserId", selectedUserId) : new ObjectParameter("SelectedUserId", typeof(int)));
		ObjectParameter objectParameter3 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter4 = ((allStatusText != null) ? new ObjectParameter("AllStatusText", allStatusText) : new ObjectParameter("AllStatusText", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUserTreeStatusCartableByStatus_Result>("MobspUserTreeStatusCartableByStatus", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspChartConversationStatusSalesFunnelSteps_Result> MobspChartConversationStatusSalesFunnelSteps(int? userId, int? cmpReferUserId, int? cmpPresentationId, string cmpCampaignIds, int? cmpCountryId, int? cmpProvinceId, int? cmpCityId, string prjTitle, DateTime? cnvsFDateTime, DateTime? cnvsTDateTime, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (cmpReferUserId.HasValue ? new ObjectParameter("cmpReferUserId", cmpReferUserId) : new ObjectParameter("cmpReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (cmpPresentationId.HasValue ? new ObjectParameter("cmpPresentationId", cmpPresentationId) : new ObjectParameter("cmpPresentationId", typeof(int)));
		ObjectParameter objectParameter4 = ((cmpCampaignIds != null) ? new ObjectParameter("cmpCampaignIds", cmpCampaignIds) : new ObjectParameter("cmpCampaignIds", typeof(string)));
		ObjectParameter objectParameter5 = (cmpCountryId.HasValue ? new ObjectParameter("cmpCountryId", cmpCountryId) : new ObjectParameter("cmpCountryId", typeof(int)));
		ObjectParameter objectParameter6 = (cmpProvinceId.HasValue ? new ObjectParameter("cmpProvinceId", cmpProvinceId) : new ObjectParameter("cmpProvinceId", typeof(int)));
		ObjectParameter objectParameter7 = (cmpCityId.HasValue ? new ObjectParameter("cmpCityId", cmpCityId) : new ObjectParameter("cmpCityId", typeof(int)));
		ObjectParameter objectParameter8 = ((prjTitle != null) ? new ObjectParameter("prjTitle", prjTitle) : new ObjectParameter("prjTitle", typeof(string)));
		ObjectParameter objectParameter9 = (cnvsFDateTime.HasValue ? new ObjectParameter("cnvsFDateTime", cnvsFDateTime) : new ObjectParameter("cnvsFDateTime", typeof(DateTime)));
		ObjectParameter objectParameter10 = (cnvsTDateTime.HasValue ? new ObjectParameter("cnvsTDateTime", cnvsTDateTime) : new ObjectParameter("cnvsTDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspChartConversationStatusSalesFunnelSteps_Result>("MobspChartConversationStatusSalesFunnelSteps", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<string> MobspSelectCompanyProjectTitles(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MobspSelectCompanyProjectTitles", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspReturnCmpCRMShopIsActiveCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnCmpCRMShopIsActiveCnt", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectCompanyByCmpMobile_Result> MobspSelectCompanyByCmpMobile(string cmpMobile, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((cmpMobile != null) ? new ObjectParameter("CmpMobile", cmpMobile) : new ObjectParameter("CmpMobile", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyByCmpMobile_Result>("MobspSelectCompanyByCmpMobile", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateCompanyCRMShopActive(int? companyId, bool? cmpCRMShopIsActive, DateTime? cmpCRMShopActiveDate, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (cmpCRMShopIsActive.HasValue ? new ObjectParameter("cmpCRMShopIsActive", cmpCRMShopIsActive) : new ObjectParameter("cmpCRMShopIsActive", typeof(bool)));
		ObjectParameter objectParameter3 = (cmpCRMShopActiveDate.HasValue ? new ObjectParameter("cmpCRMShopActiveDate", cmpCRMShopActiveDate) : new ObjectParameter("cmpCRMShopActiveDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateCompanyCRMShopActive", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<WSspRpt_PrintPreOrderDiscounts_Result> WSspRpt_PrintPreOrderDiscounts(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintPreOrderDiscounts_Result>("WSspRpt_PrintPreOrderDiscounts", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnBuyOrderItemQuantityByOrdItemId_Result> MobspReturnBuyOrderItemQuantityByOrdItemId(int? orderItemId)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnBuyOrderItemQuantityByOrdItemId_Result>("MobspReturnBuyOrderItemQuantityByOrdItemId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnBuyOrderFromOrder_Result> MobspReturnBuyOrderFromOrder(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnBuyOrderFromOrder_Result>("MobspReturnBuyOrderFromOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspInsertDocItemWithBarcode(int? docId, string prdCode, string serial, int? wHId, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? docItemId, ObjectParameter result, int? centerId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = ((prdCode != null) ? new ObjectParameter("PrdCode", prdCode) : new ObjectParameter("PrdCode", typeof(string)));
		ObjectParameter objectParameter3 = ((serial != null) ? new ObjectParameter("Serial", serial) : new ObjectParameter("Serial", typeof(string)));
		ObjectParameter objectParameter4 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertDocItemWithBarcode", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, result, objectParameter13);
	}

	public virtual ObjectResult<WSspRpt_PrintOrder_Result> WSspRpt_PrintOrder(int? orderID, int? languageID, int? defaultLanguageID, int? userId, string rptDate, string rptDay, decimal? cmpLinkAccAllPayRemain)
	{
		ObjectParameter objectParameter = (orderID.HasValue ? new ObjectParameter("OrderID", orderID) : new ObjectParameter("OrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter6 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter7 = (cmpLinkAccAllPayRemain.HasValue ? new ObjectParameter("CmpLinkAccAllPayRemain", cmpLinkAccAllPayRemain) : new ObjectParameter("CmpLinkAccAllPayRemain", typeof(decimal)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintOrder_Result>("WSspRpt_PrintOrder", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspRpt_PrintOrderItems_Result> WSspRpt_PrintOrderItems(int? orderID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderID.HasValue ? new ObjectParameter("OrderID", orderID) : new ObjectParameter("OrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintOrderItems_Result>("WSspRpt_PrintOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintPreOrderById_Result> WSspRpt_PrintPreOrderById(int? preOrderID, int? languageID, int? defaultLanguageID, int? userId, string rptDate, string rptDay, decimal? cmpLinkAccAllPayRemain)
	{
		ObjectParameter objectParameter = (preOrderID.HasValue ? new ObjectParameter("PreOrderID", preOrderID) : new ObjectParameter("PreOrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter6 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter7 = (cmpLinkAccAllPayRemain.HasValue ? new ObjectParameter("CmpLinkAccAllPayRemain", cmpLinkAccAllPayRemain) : new ObjectParameter("CmpLinkAccAllPayRemain", typeof(decimal)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintPreOrderById_Result>("WSspRpt_PrintPreOrderById", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspCheckHaveOrderOprExceptTspCmp_Result> MobspCheckHaveOrderOprExceptTspCmp(int? companyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckHaveOrderOprExceptTspCmp_Result>("MobspCheckHaveOrderOprExceptTspCmp", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectUserDepartments_Result> FOMobspSelectUserDepartments(int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectUserDepartments_Result>("FOMobspSelectUserDepartments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccSettingDBIsActive_Result> CRMspSelectLinkAccSettingDBIsActive(int? linkAccSystemId)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccSettingDBIsActive_Result>("CRMspSelectLinkAccSettingDBIsActive", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspLkSepReturnCmpAccountingSummary_Result> CRMspLkSepReturnCmpAccountingSummary(int? companyId, ObjectParameter payRemain, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepReturnCmpAccountingSummary_Result>("CRMspLkSepReturnCmpAccountingSummary", new ObjectParameter[3] { objectParameter, payRemain, objectParameter2 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccSetting_Result> CRMspSelectLinkAccSetting(int? linkAccSettingId, string objectType, int? languageID, int? defaultLanguageID, int? linkAccSystemId, int? linkAccSettingDBId, string partTitle)
	{
		ObjectParameter objectParameter = (linkAccSettingId.HasValue ? new ObjectParameter("LinkAccSettingId", linkAccSettingId) : new ObjectParameter("LinkAccSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter6 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter7 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccSetting_Result>("CRMspSelectLinkAccSetting", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectOnlinePayBankInfo_Result> MobspSelectOnlinePayBankInfo(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOnlinePayBankInfo_Result>("MobspSelectOnlinePayBankInfo", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspReturnProductCostByPrdId_Result> MobspReturnProductCostByPrdId(int? productID, int? productCostGroupId, int? languageID, int? defaultLanguageID, int? destCurrencyUnitId)
	{
		ObjectParameter objectParameter = (productID.HasValue ? new ObjectParameter("ProductID", productID) : new ObjectParameter("ProductID", typeof(int)));
		ObjectParameter objectParameter2 = (productCostGroupId.HasValue ? new ObjectParameter("ProductCostGroupId", productCostGroupId) : new ObjectParameter("ProductCostGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (destCurrencyUnitId.HasValue ? new ObjectParameter("DestCurrencyUnitId", destCurrencyUnitId) : new ObjectParameter("DestCurrencyUnitId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnProductCostByPrdId_Result>("MobspReturnProductCostByPrdId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectShopOnlinePayBankInfo_Result> MobspSelectShopOnlinePayBankInfo(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectShopOnlinePayBankInfo_Result>("MobspSelectShopOnlinePayBankInfo", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<SHPMobspSelectExpiredPreOrders_Result> SHPMobspSelectExpiredPreOrders(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? cmpPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (cmpPersonId.HasValue ? new ObjectParameter("CmpPersonId", cmpPersonId) : new ObjectParameter("CmpPersonId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectExpiredPreOrders_Result>("SHPMobspSelectExpiredPreOrders", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<SHPMobspSelectOrdersByCmpId_Result> SHPMobspSelectOrdersByCmpId(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? cmpPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (cmpPersonId.HasValue ? new ObjectParameter("CmpPersonId", cmpPersonId) : new ObjectParameter("CmpPersonId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectOrdersByCmpId_Result>("SHPMobspSelectOrdersByCmpId", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspCheckOrderSaleCenterUnique_Result> MobspCheckOrderSaleCenterUnique(int? orderId, int? ordSaleCenterId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (ordSaleCenterId.HasValue ? new ObjectParameter("ordSaleCenterId", ordSaleCenterId) : new ObjectParameter("ordSaleCenterId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckOrderSaleCenterUnique_Result>("MobspCheckOrderSaleCenterUnique", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspCheckOrderItemSaleCenterUnique(int? orderId, int? ordISaleCenterId, ObjectParameter result)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (ordISaleCenterId.HasValue ? new ObjectParameter("ordISaleCenterId", ordISaleCenterId) : new ObjectParameter("ordISaleCenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCheckOrderItemSaleCenterUnique", objectParameter, objectParameter2, result);
	}

	public virtual ObjectResult<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result> SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate(int? companyId, DateTime? expireDate, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? cmpPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (expireDate.HasValue ? new ObjectParameter("ExpireDate", expireDate) : new ObjectParameter("ExpireDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (cmpPersonId.HasValue ? new ObjectParameter("CmpPersonId", cmpPersonId) : new ObjectParameter("CmpPersonId", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>("SHPMobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result> SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? cmpPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (cmpPersonId.HasValue ? new ObjectParameter("CmpPersonId", cmpPersonId) : new ObjectParameter("CmpPersonId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>("SHPMobspSelectVerifiedPreOrdersWithoutOrderByCmpId", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<SHPMobspSelectOrderWithID_Result> SHPMobspSelectOrderWithID(int? orderId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectOrderWithID_Result>("SHPMobspSelectOrderWithID", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspDeleteFilesDirectoryTemplate(int? fileDirectoryTemplateId)
	{
		ObjectParameter objectParameter = (fileDirectoryTemplateId.HasValue ? new ObjectParameter("FileDirectoryTemplateId", fileDirectoryTemplateId) : new ObjectParameter("FileDirectoryTemplateId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDeleteFilesDirectoryTemplate", objectParameter);
	}

	public virtual ObjectResult<MobspSelectDiscountCodeHistoryWithDisCodeId_Result> MobspSelectDiscountCodeHistoryWithDisCodeId(int? disCodeId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (disCodeId.HasValue ? new ObjectParameter("DisCodeId", disCodeId) : new ObjectParameter("DisCodeId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDiscountCodeHistoryWithDisCodeId_Result>("MobspSelectDiscountCodeHistoryWithDisCodeId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectOrderItemsByNotInSumAndNoDis_Result> MobspSelectOrderItemsByNotInSumAndNoDis(int? orderId, bool? ordINotInSum, bool? prdNoDiscount, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (ordINotInSum.HasValue ? new ObjectParameter("OrdINotInSum", ordINotInSum) : new ObjectParameter("OrdINotInSum", typeof(bool)));
		ObjectParameter objectParameter3 = (prdNoDiscount.HasValue ? new ObjectParameter("PrdNoDiscount", prdNoDiscount) : new ObjectParameter("PrdNoDiscount", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderItemsByNotInSumAndNoDis_Result>("MobspSelectOrderItemsByNotInSumAndNoDis", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result> MobspSelectPreOrderItemsByNotInSumAndNoDis(int? preOrderId, bool? pordINotInSum, bool? prdNoDiscount, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (pordINotInSum.HasValue ? new ObjectParameter("PordINotInSum", pordINotInSum) : new ObjectParameter("PordINotInSum", typeof(bool)));
		ObjectParameter objectParameter3 = (prdNoDiscount.HasValue ? new ObjectParameter("PrdNoDiscount", prdNoDiscount) : new ObjectParameter("PrdNoDiscount", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderItemsByNotInSumAndNoDis_Result>("MobspSelectPreOrderItemsByNotInSumAndNoDis", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<FOMobspSelectDiscountCodeRules_Result> FOMobspSelectDiscountCodeRules(DateTime? currDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectDiscountCodeRules_Result>("FOMobspSelectDiscountCodeRules", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspInsertDiscountCodeFromDisCodeRule_Result> FOMobspInsertDiscountCodeFromDisCodeRule(int? ruleId, string titleJs, decimal? disAmount, decimal? disAmountPercent, DateTime? disExpDate, string disExpDatePersian, int? disCmpId, int? disUseCnt, int? languageID, int? defaultLanguageID, double? scoreRate, bool? disCanChangeToScore, string disRPreCode, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? centerId)
	{
		ObjectParameter objectParameter = (ruleId.HasValue ? new ObjectParameter("RuleId", ruleId) : new ObjectParameter("RuleId", typeof(int)));
		ObjectParameter objectParameter2 = ((titleJs != null) ? new ObjectParameter("TitleJs", titleJs) : new ObjectParameter("TitleJs", typeof(string)));
		ObjectParameter objectParameter3 = (disAmount.HasValue ? new ObjectParameter("DisAmount", disAmount) : new ObjectParameter("DisAmount", typeof(decimal)));
		ObjectParameter objectParameter4 = (disAmountPercent.HasValue ? new ObjectParameter("DisAmountPercent", disAmountPercent) : new ObjectParameter("DisAmountPercent", typeof(decimal)));
		ObjectParameter objectParameter5 = (disExpDate.HasValue ? new ObjectParameter("DisExpDate", disExpDate) : new ObjectParameter("DisExpDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((disExpDatePersian != null) ? new ObjectParameter("DisExpDatePersian", disExpDatePersian) : new ObjectParameter("DisExpDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (disCmpId.HasValue ? new ObjectParameter("DisCmpId", disCmpId) : new ObjectParameter("DisCmpId", typeof(int)));
		ObjectParameter objectParameter8 = (disUseCnt.HasValue ? new ObjectParameter("DisUseCnt", disUseCnt) : new ObjectParameter("DisUseCnt", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (scoreRate.HasValue ? new ObjectParameter("ScoreRate", scoreRate) : new ObjectParameter("ScoreRate", typeof(double)));
		ObjectParameter objectParameter12 = (disCanChangeToScore.HasValue ? new ObjectParameter("DisCanChangeToScore", disCanChangeToScore) : new ObjectParameter("DisCanChangeToScore", typeof(bool)));
		ObjectParameter objectParameter13 = ((disRPreCode != null) ? new ObjectParameter("DisRPreCode", disRPreCode) : new ObjectParameter("DisRPreCode", typeof(string)));
		ObjectParameter objectParameter14 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter15 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter16 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter17 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter18 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter19 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter20 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter21 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspInsertDiscountCodeFromDisCodeRule_Result>("FOMobspInsertDiscountCodeFromDisCodeRule", new ObjectParameter[21]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21
		});
	}

	public virtual ObjectResult<FOMobspSelectDiscountCodeRuleWithId_Result> FOMobspSelectDiscountCodeRuleWithId(int? discountCodeRuleId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (discountCodeRuleId.HasValue ? new ObjectParameter("DiscountCodeRuleId", discountCodeRuleId) : new ObjectParameter("DiscountCodeRuleId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectDiscountCodeRuleWithId_Result>("FOMobspSelectDiscountCodeRuleWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyScores_Result> FOMobspSelectCompanyScores(int? companyId, DateTime? fDateTime, DateTime? tDateTime, string textRemaindScoreBefore, string textEarningScore, string textSpendScore, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((textRemaindScoreBefore != null) ? new ObjectParameter("TextRemaindScoreBefore", textRemaindScoreBefore) : new ObjectParameter("TextRemaindScoreBefore", typeof(string)));
		ObjectParameter objectParameter5 = ((textEarningScore != null) ? new ObjectParameter("TextEarningScore", textEarningScore) : new ObjectParameter("TextEarningScore", typeof(string)));
		ObjectParameter objectParameter6 = ((textSpendScore != null) ? new ObjectParameter("TextSpendScore", textSpendScore) : new ObjectParameter("TextSpendScore", typeof(string)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyScores_Result>("FOMobspSelectCompanyScores", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11
		});
	}

	public virtual ObjectResult<MobspResultsTimeAttendanceCartableFooter_Result> MobspResultsTimeAttendanceCartableFooter(DateTime? fDate, DateTime? tDate, DateTime? currDateTime, int? userID, int? currUserID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (currDateTime.HasValue ? new ObjectParameter("CurrDateTime", currDateTime) : new ObjectParameter("CurrDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter5 = (currUserID.HasValue ? new ObjectParameter("CurrUserID", currUserID) : new ObjectParameter("CurrUserID", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsTimeAttendanceCartableFooter_Result>("MobspResultsTimeAttendanceCartableFooter", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectVerificationWorkFlowWithId_Result> MobspSelectVerificationWorkFlowWithId(int? verificationWorkFlowId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationWorkFlowWithId_Result>("MobspSelectVerificationWorkFlowWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectVerificationRequestsByReqId_Result> MobspSelectVerificationRequestsByReqId(int? requestId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (requestId.HasValue ? new ObjectParameter("RequestId", requestId) : new ObjectParameter("RequestId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationRequestsByReqId_Result>("MobspSelectVerificationRequestsByReqId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectCompanyById_Result> MobspSelectCompanyById(int? companyId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyById_Result>("MobspSelectCompanyById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspRpt_PrintDocItems_Result> WSspRpt_PrintDocItems(int? docID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintDocItems_Result>("WSspRpt_PrintDocItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkSepReturnCmpAccountRemainingInAccCode(int? companyId, ObjectParameter payRemain, int? linkAccSettingDBId, ObjectParameter debitBalance, ObjectParameter creditBalance)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepReturnCmpAccountRemainingInAccCode", objectParameter, payRemain, objectParameter2, debitBalance, creditBalance);
	}

	public virtual ObjectResult<SHPMobspSelectActiveProducts_Result> SHPMobspSelectActiveProducts(int? prdKind, int? showMode, int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter2 = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectActiveProducts_Result>("SHPMobspSelectActiveProducts", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<SHPMobspReturnPrdQuantityByIds_Result> SHPMobspReturnPrdQuantityByIds(string productIds, string seperator, bool? getInvStockFromLink, double? prdSHPLinkAccStock, int? languageID, int? defaultLanguageID, int? centerId, int? foSettingId, bool? returnTotalPrdQtyFromAllCenter)
	{
		ObjectParameter objectParameter = ((productIds != null) ? new ObjectParameter("ProductIds", productIds) : new ObjectParameter("ProductIds", typeof(string)));
		ObjectParameter objectParameter2 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter3 = (getInvStockFromLink.HasValue ? new ObjectParameter("GetInvStockFromLink", getInvStockFromLink) : new ObjectParameter("GetInvStockFromLink", typeof(bool)));
		ObjectParameter objectParameter4 = (prdSHPLinkAccStock.HasValue ? new ObjectParameter("PrdSHPLinkAccStock", prdSHPLinkAccStock) : new ObjectParameter("PrdSHPLinkAccStock", typeof(double)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter9 = (returnTotalPrdQtyFromAllCenter.HasValue ? new ObjectParameter("ReturnTotalPrdQtyFromAllCenter", returnTotalPrdQtyFromAllCenter) : new ObjectParameter("ReturnTotalPrdQtyFromAllCenter", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspReturnPrdQuantityByIds_Result>("SHPMobspReturnPrdQuantityByIds", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<SHPMobspSelectProductsWithId_Result> SHPMobspSelectProductsWithId(int? productId, int? languageID, int? defaultLanguageID, int? companyId)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectProductsWithId_Result>("SHPMobspSelectProductsWithId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<FOMobspSelectWareHouseWithAccLinkField_Result> FOMobspSelectWareHouseWithAccLinkField(bool? withWrhsLinkAccWhId, bool? withWrhsLinkAccWhCode, bool? withWrhsLinkAccWhIdStr, bool? withWrhsLinkAccWareHouses, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withWrhsLinkAccWhId.HasValue ? new ObjectParameter("WithWrhsLinkAccWhId", withWrhsLinkAccWhId) : new ObjectParameter("WithWrhsLinkAccWhId", typeof(bool)));
		ObjectParameter objectParameter2 = (withWrhsLinkAccWhCode.HasValue ? new ObjectParameter("WithWrhsLinkAccWhCode", withWrhsLinkAccWhCode) : new ObjectParameter("WithWrhsLinkAccWhCode", typeof(bool)));
		ObjectParameter objectParameter3 = (withWrhsLinkAccWhIdStr.HasValue ? new ObjectParameter("WithWrhsLinkAccWhIdStr", withWrhsLinkAccWhIdStr) : new ObjectParameter("WithWrhsLinkAccWhIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (withWrhsLinkAccWareHouses.HasValue ? new ObjectParameter("WithWrhsLinkAccWareHouses", withWrhsLinkAccWareHouses) : new ObjectParameter("WithWrhsLinkAccWareHouses", typeof(bool)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectWareHouseWithAccLinkField_Result>("FOMobspSelectWareHouseWithAccLinkField", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result> FOMobspSelectLinkAccSettingByLinkAccSystemId(int? linkAccSystemId, int? linkAccSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingId.HasValue ? new ObjectParameter("LinkAccSettingId", linkAccSettingId) : new ObjectParameter("LinkAccSettingId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>("FOMobspSelectLinkAccSettingByLinkAccSystemId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspVerificationRequestBack_Result> MobspVerificationRequestBack(int? verificationRequestId, int? verificationWorkFlowId, int? objectId, int? objectType, string messageText, string messageTextLang, string msgSubject, int? backToStepId, string verifyText, int? verifyReqResultId, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter internalMessageId, int? centerId)
	{
		ObjectParameter objectParameter = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter2 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter3 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter4 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter5 = ((messageText != null) ? new ObjectParameter("MessageText", messageText) : new ObjectParameter("MessageText", typeof(string)));
		ObjectParameter objectParameter6 = ((messageTextLang != null) ? new ObjectParameter("MessageTextLang", messageTextLang) : new ObjectParameter("MessageTextLang", typeof(string)));
		ObjectParameter objectParameter7 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter8 = (backToStepId.HasValue ? new ObjectParameter("BackToStepId", backToStepId) : new ObjectParameter("BackToStepId", typeof(int)));
		ObjectParameter objectParameter9 = ((verifyText != null) ? new ObjectParameter("VerifyText", verifyText) : new ObjectParameter("VerifyText", typeof(string)));
		ObjectParameter objectParameter10 = (verifyReqResultId.HasValue ? new ObjectParameter("VerifyReqResultId", verifyReqResultId) : new ObjectParameter("VerifyReqResultId", typeof(int)));
		ObjectParameter objectParameter11 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter15 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter16 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter18 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter20 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspVerificationRequestBack_Result>("MobspVerificationRequestBack", new ObjectParameter[21]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, internalMessageId,
			objectParameter20
		});
	}

	public virtual int MobspUpdateDocEditAfterFixInfoJs(int? docId, string editAfterFixInfoJs)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = ((editAfterFixInfoJs != null) ? new ObjectParameter("EditAfterFixInfoJs", editAfterFixInfoJs) : new ObjectParameter("EditAfterFixInfoJs", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateDocEditAfterFixInfoJs", objectParameter, objectParameter2);
	}

	public virtual int MobspUpdateDyFormEditAfterFixInfoJs(int? masterValueId, string editAfterFixInfoJs)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = ((editAfterFixInfoJs != null) ? new ObjectParameter("EditAfterFixInfoJs", editAfterFixInfoJs) : new ObjectParameter("EditAfterFixInfoJs", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateDyFormEditAfterFixInfoJs", objectParameter, objectParameter2);
	}

	public virtual int MobspUpdateOrderEditAfterFixInfoJs(int? orderId, string ordEditAfterFixInfoJs)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((ordEditAfterFixInfoJs != null) ? new ObjectParameter("OrdEditAfterFixInfoJs", ordEditAfterFixInfoJs) : new ObjectParameter("OrdEditAfterFixInfoJs", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateOrderEditAfterFixInfoJs", objectParameter, objectParameter2);
	}

	public virtual int MobspUpdatePreOrderEditAfterFixInfoJs(int? preOrderId, string pordEditAfterFixInfoJs)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((pordEditAfterFixInfoJs != null) ? new ObjectParameter("PordEditAfterFixInfoJs", pordEditAfterFixInfoJs) : new ObjectParameter("PordEditAfterFixInfoJs", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdatePreOrderEditAfterFixInfoJs", objectParameter, objectParameter2);
	}

	public virtual int MobspUpdateBuyOrderEditAfterFixInfoJs(int? buyOrderId, string bordEditAfterFixInfoJs)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((bordEditAfterFixInfoJs != null) ? new ObjectParameter("bordEditAfterFixInfoJs", bordEditAfterFixInfoJs) : new ObjectParameter("bordEditAfterFixInfoJs", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateBuyOrderEditAfterFixInfoJs", objectParameter, objectParameter2);
	}

	public virtual ObjectResult<MobspVerificationRequestSendToAltUser_Result> MobspVerificationRequestSendToAltUser(int? verificationRequestId, int? verificationWorkFlowId, int? verificationWorkFlowStepId, int? objectId, int? objectType, string messageText, string messageTextLang, string msgSubject, string verifyText, string verifyTextLang, int? verifyReqResultId, int? altUserId, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter internalMessageId, int? centerId)
	{
		ObjectParameter objectParameter = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter2 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter3 = (verificationWorkFlowStepId.HasValue ? new ObjectParameter("VerificationWorkFlowStepId", verificationWorkFlowStepId) : new ObjectParameter("VerificationWorkFlowStepId", typeof(int)));
		ObjectParameter objectParameter4 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter5 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter6 = ((messageText != null) ? new ObjectParameter("MessageText", messageText) : new ObjectParameter("MessageText", typeof(string)));
		ObjectParameter objectParameter7 = ((messageTextLang != null) ? new ObjectParameter("MessageTextLang", messageTextLang) : new ObjectParameter("MessageTextLang", typeof(string)));
		ObjectParameter objectParameter8 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter9 = ((verifyText != null) ? new ObjectParameter("VerifyText", verifyText) : new ObjectParameter("VerifyText", typeof(string)));
		ObjectParameter objectParameter10 = ((verifyTextLang != null) ? new ObjectParameter("VerifyTextLang", verifyTextLang) : new ObjectParameter("VerifyTextLang", typeof(string)));
		ObjectParameter objectParameter11 = (verifyReqResultId.HasValue ? new ObjectParameter("VerifyReqResultId", verifyReqResultId) : new ObjectParameter("VerifyReqResultId", typeof(int)));
		ObjectParameter objectParameter12 = (altUserId.HasValue ? new ObjectParameter("AltUserId", altUserId) : new ObjectParameter("AltUserId", typeof(int)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter16 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter17 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter18 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter19 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter20 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter21 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter22 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspVerificationRequestSendToAltUser_Result>("MobspVerificationRequestSendToAltUser", new ObjectParameter[23]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, internalMessageId, objectParameter22
		});
	}

	public virtual int MobspSendSmsPordFOLinkAfterVerify(int? porderId, string foLink, string foLinkWithLogin, string foLinkWithoutLogin, string crmLinkWithoutLogin, int? userId, int? year1, int? month1, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result, int? centerId)
	{
		ObjectParameter objectParameter = (porderId.HasValue ? new ObjectParameter("PorderId", porderId) : new ObjectParameter("PorderId", typeof(int)));
		ObjectParameter objectParameter2 = ((foLink != null) ? new ObjectParameter("FoLink", foLink) : new ObjectParameter("FoLink", typeof(string)));
		ObjectParameter objectParameter3 = ((foLinkWithLogin != null) ? new ObjectParameter("FoLinkWithLogin", foLinkWithLogin) : new ObjectParameter("FoLinkWithLogin", typeof(string)));
		ObjectParameter objectParameter4 = ((foLinkWithoutLogin != null) ? new ObjectParameter("FoLinkWithoutLogin", foLinkWithoutLogin) : new ObjectParameter("FoLinkWithoutLogin", typeof(string)));
		ObjectParameter objectParameter5 = ((crmLinkWithoutLogin != null) ? new ObjectParameter("CrmLinkWithoutLogin", crmLinkWithoutLogin) : new ObjectParameter("CrmLinkWithoutLogin", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSendSmsPordFOLinkAfterVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, result, objectParameter13);
	}

	public virtual ObjectResult<MobspSelectOrderGroups_Result> MobspSelectOrderGroups(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderGroups_Result>("MobspSelectOrderGroups", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspCalcAndUpdateTimeAttendanceLeave(DateTime? leaveDateTime, int? leaveUserId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (leaveDateTime.HasValue ? new ObjectParameter("LeaveDateTime", leaveDateTime) : new ObjectParameter("LeaveDateTime", typeof(DateTime)));
		ObjectParameter objectParameter2 = (leaveUserId.HasValue ? new ObjectParameter("LeaveUserId", leaveUserId) : new ObjectParameter("LeaveUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCalcAndUpdateTimeAttendanceLeave", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual ObjectResult<MobspSelectLinkAccSettingDBIsActive_Result> MobspSelectLinkAccSettingDBIsActive(int? linkAccSystemId)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLinkAccSettingDBIsActive_Result>("MobspSelectLinkAccSettingDBIsActive", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectProductsWithIds_Result> MobspSelectProductsWithIds(string productIds, string seperator, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((productIds != null) ? new ObjectParameter("ProductIds", productIds) : new ObjectParameter("ProductIds", typeof(string)));
		ObjectParameter objectParameter2 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductsWithIds_Result>("MobspSelectProductsWithIds", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectSaleCentersWithIds_Result> MobspSelectSaleCentersWithIds(string saleCenterIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((saleCenterIds != null) ? new ObjectParameter("SaleCenterIds", saleCenterIds) : new ObjectParameter("SaleCenterIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSaleCentersWithIds_Result>("MobspSelectSaleCentersWithIds", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnOrderItemsDoneTimeSum_Result> MobspReturnOrderItemsDoneTimeSum(int? orderId, int? currOrderItemId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (currOrderItemId.HasValue ? new ObjectParameter("CurrOrderItemId", currOrderItemId) : new ObjectParameter("CurrOrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnOrderItemsDoneTimeSum_Result>("MobspReturnOrderItemsDoneTimeSum", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectOrderItemsSaleCenterDelivery_Result> MobspSelectOrderItemsSaleCenterDelivery(DateTime? ordDateTime, int? currentOrderId)
	{
		ObjectParameter objectParameter = (ordDateTime.HasValue ? new ObjectParameter("OrdDateTime", ordDateTime) : new ObjectParameter("OrdDateTime", typeof(DateTime)));
		ObjectParameter objectParameter2 = (currentOrderId.HasValue ? new ObjectParameter("CurrentOrderId", currentOrderId) : new ObjectParameter("CurrentOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderItemsSaleCenterDelivery_Result>("MobspSelectOrderItemsSaleCenterDelivery", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspUpdateOrderItemsDeliveryDates(int? orderId, DateTime? deliveryDate, string deliveryDatePersian, string deliveryDay, DateTime? deliveryEndDate, string deliveryEndDatePersian, string deliveryEndDay, string deliveryEndTime, string deliveryTime, int? saleCenterId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (deliveryDate.HasValue ? new ObjectParameter("DeliveryDate", deliveryDate) : new ObjectParameter("DeliveryDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((deliveryDatePersian != null) ? new ObjectParameter("DeliveryDatePersian", deliveryDatePersian) : new ObjectParameter("DeliveryDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = ((deliveryDay != null) ? new ObjectParameter("DeliveryDay", deliveryDay) : new ObjectParameter("DeliveryDay", typeof(string)));
		ObjectParameter objectParameter5 = (deliveryEndDate.HasValue ? new ObjectParameter("DeliveryEndDate", deliveryEndDate) : new ObjectParameter("DeliveryEndDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((deliveryEndDatePersian != null) ? new ObjectParameter("DeliveryEndDatePersian", deliveryEndDatePersian) : new ObjectParameter("DeliveryEndDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((deliveryEndDay != null) ? new ObjectParameter("DeliveryEndDay", deliveryEndDay) : new ObjectParameter("DeliveryEndDay", typeof(string)));
		ObjectParameter objectParameter8 = ((deliveryEndTime != null) ? new ObjectParameter("DeliveryEndTime", deliveryEndTime) : new ObjectParameter("DeliveryEndTime", typeof(string)));
		ObjectParameter objectParameter9 = ((deliveryTime != null) ? new ObjectParameter("DeliveryTime", deliveryTime) : new ObjectParameter("DeliveryTime", typeof(string)));
		ObjectParameter objectParameter10 = (saleCenterId.HasValue ? new ObjectParameter("SaleCenterId", saleCenterId) : new ObjectParameter("SaleCenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateOrderItemsDeliveryDates", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual ObjectResult<SHPMobspSelectProductsWithIds_Result> SHPMobspSelectProductsWithIds(string productIds, string seperator, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((productIds != null) ? new ObjectParameter("ProductIds", productIds) : new ObjectParameter("ProductIds", typeof(string)));
		ObjectParameter objectParameter2 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectProductsWithIds_Result>("SHPMobspSelectProductsWithIds", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<SHPMobspSelectSaleCentersWithIds_Result> SHPMobspSelectSaleCentersWithIds(string saleCenterIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((saleCenterIds != null) ? new ObjectParameter("SaleCenterIds", saleCenterIds) : new ObjectParameter("SaleCenterIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectSaleCentersWithIds_Result>("SHPMobspSelectSaleCentersWithIds", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<SHPMobspSelectOrderItemsSaleCenterDelivery_Result> SHPMobspSelectOrderItemsSaleCenterDelivery(DateTime? ordDateTime)
	{
		ObjectParameter objectParameter = (ordDateTime.HasValue ? new ObjectParameter("OrdDateTime", ordDateTime) : new ObjectParameter("OrdDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectOrderItemsSaleCenterDelivery_Result>("SHPMobspSelectOrderItemsSaleCenterDelivery", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<SHPMobspSelectProductPrice_Result> SHPMobspSelectProductPrice(string productPriceGroupId, string seperator, DateTime? registerDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((productPriceGroupId != null) ? new ObjectParameter("ProductPriceGroupId", productPriceGroupId) : new ObjectParameter("ProductPriceGroupId", typeof(string)));
		ObjectParameter objectParameter2 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectProductPrice_Result>("SHPMobspSelectProductPrice", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<SHPMobspCheckSelectedPrdDoneTime_Result> SHPMobspCheckSelectedPrdDoneTime(string prdsJs, ObjectParameter resultCheck, bool? returnResult, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((prdsJs != null) ? new ObjectParameter("PrdsJs", prdsJs) : new ObjectParameter("PrdsJs", typeof(string)));
		ObjectParameter objectParameter2 = (returnResult.HasValue ? new ObjectParameter("ReturnResult", returnResult) : new ObjectParameter("ReturnResult", typeof(bool)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspCheckSelectedPrdDoneTime_Result>("SHPMobspCheckSelectedPrdDoneTime", new ObjectParameter[6] { objectParameter, resultCheck, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int SHPMobspIssueOrder(int? companyId, string prjTitle, string products, decimal? transportation, int? personId, int? wHId, int? prjcnvsStatusGroupId, int? currencyUnitId, string ordDeliveryEndDate, DateTime? ordDeliveryEndDateTime, string ordDeliveryEndTime, string ordDeliveryDate, DateTime? ordDeliveryDateTime, string ordDeliveryTime, string productDiscountJson, int? discountCodeId, string disCode, decimal? disAmount, decimal? disAmountPercent, string ordDiscountTitle, DateTime? registerDate, string registerDatePersian, string registerTime, string registerDay, int? fPId, short? month1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter error, ObjectParameter ordNumber, ObjectParameter orderId, int? ordVerifierRequestId, string ordDescriptionI, int? ordDeliveryTermId, string prdSaleCenterDoneTimeJson, ObjectParameter ordIssuedJson, int? foSettingId, int? centerId, int? shpCartPayTypeId, int? ordSaleAreaId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((prjTitle != null) ? new ObjectParameter("PrjTitle", prjTitle) : new ObjectParameter("PrjTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((products != null) ? new ObjectParameter("Products", products) : new ObjectParameter("Products", typeof(string)));
		ObjectParameter objectParameter4 = (transportation.HasValue ? new ObjectParameter("Transportation", transportation) : new ObjectParameter("Transportation", typeof(decimal)));
		ObjectParameter objectParameter5 = (personId.HasValue ? new ObjectParameter("PersonId", personId) : new ObjectParameter("PersonId", typeof(int)));
		ObjectParameter objectParameter6 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter7 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter8 = (currencyUnitId.HasValue ? new ObjectParameter("CurrencyUnitId", currencyUnitId) : new ObjectParameter("CurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter9 = ((ordDeliveryEndDate != null) ? new ObjectParameter("ordDeliveryEndDate", ordDeliveryEndDate) : new ObjectParameter("ordDeliveryEndDate", typeof(string)));
		ObjectParameter objectParameter10 = (ordDeliveryEndDateTime.HasValue ? new ObjectParameter("ordDeliveryEndDateTime", ordDeliveryEndDateTime) : new ObjectParameter("ordDeliveryEndDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((ordDeliveryEndTime != null) ? new ObjectParameter("ordDeliveryEndTime", ordDeliveryEndTime) : new ObjectParameter("ordDeliveryEndTime", typeof(string)));
		ObjectParameter objectParameter12 = ((ordDeliveryDate != null) ? new ObjectParameter("ordDeliveryDate", ordDeliveryDate) : new ObjectParameter("ordDeliveryDate", typeof(string)));
		ObjectParameter objectParameter13 = (ordDeliveryDateTime.HasValue ? new ObjectParameter("ordDeliveryDateTime", ordDeliveryDateTime) : new ObjectParameter("ordDeliveryDateTime", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((ordDeliveryTime != null) ? new ObjectParameter("ordDeliveryTime", ordDeliveryTime) : new ObjectParameter("ordDeliveryTime", typeof(string)));
		ObjectParameter objectParameter15 = ((productDiscountJson != null) ? new ObjectParameter("ProductDiscountJson", productDiscountJson) : new ObjectParameter("ProductDiscountJson", typeof(string)));
		ObjectParameter objectParameter16 = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter17 = ((disCode != null) ? new ObjectParameter("DisCode", disCode) : new ObjectParameter("DisCode", typeof(string)));
		ObjectParameter objectParameter18 = (disAmount.HasValue ? new ObjectParameter("DisAmount", disAmount) : new ObjectParameter("DisAmount", typeof(decimal)));
		ObjectParameter objectParameter19 = (disAmountPercent.HasValue ? new ObjectParameter("DisAmountPercent", disAmountPercent) : new ObjectParameter("DisAmountPercent", typeof(decimal)));
		ObjectParameter objectParameter20 = ((ordDiscountTitle != null) ? new ObjectParameter("OrdDiscountTitle", ordDiscountTitle) : new ObjectParameter("OrdDiscountTitle", typeof(string)));
		ObjectParameter objectParameter21 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter22 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter23 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter24 = ((registerDay != null) ? new ObjectParameter("RegisterDay", registerDay) : new ObjectParameter("RegisterDay", typeof(string)));
		ObjectParameter objectParameter25 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter26 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter27 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter28 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter29 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter30 = (ordVerifierRequestId.HasValue ? new ObjectParameter("OrdVerifierRequestId", ordVerifierRequestId) : new ObjectParameter("OrdVerifierRequestId", typeof(int)));
		ObjectParameter objectParameter31 = ((ordDescriptionI != null) ? new ObjectParameter("OrdDescriptionI", ordDescriptionI) : new ObjectParameter("OrdDescriptionI", typeof(string)));
		ObjectParameter objectParameter32 = (ordDeliveryTermId.HasValue ? new ObjectParameter("ordDeliveryTermId", ordDeliveryTermId) : new ObjectParameter("ordDeliveryTermId", typeof(int)));
		ObjectParameter objectParameter33 = ((prdSaleCenterDoneTimeJson != null) ? new ObjectParameter("PrdSaleCenterDoneTimeJson", prdSaleCenterDoneTimeJson) : new ObjectParameter("PrdSaleCenterDoneTimeJson", typeof(string)));
		ObjectParameter objectParameter34 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter35 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter36 = (shpCartPayTypeId.HasValue ? new ObjectParameter("ShpCartPayTypeId", shpCartPayTypeId) : new ObjectParameter("ShpCartPayTypeId", typeof(int)));
		ObjectParameter objectParameter37 = (ordSaleAreaId.HasValue ? new ObjectParameter("ordSaleAreaId", ordSaleAreaId) : new ObjectParameter("ordSaleAreaId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SHPMobspIssueOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, error, ordNumber, orderId, objectParameter30, objectParameter31, objectParameter32, objectParameter33, ordIssuedJson, objectParameter34, objectParameter35, objectParameter36, objectParameter37);
	}

	public virtual int SHPMobspIssuePreOrder(int? companyId, string prjTitle, string products, decimal? transportation, int? personId, int? wHId, int? prjcnvsStatusGroupId, int? currencyUnitId, string pordDeliveryEndDate, DateTime? pordDeliveryEndDateTime, string pordDeliveryEndTime, string pordDeliveryDate, DateTime? pordDeliveryDateTime, string pordDeliveryTime, string productDiscountJson, int? discountCodeId, string disCode, decimal? disAmount, decimal? disAmountPercent, string pordDiscountTitle, DateTime? registerDate, string registerDatePersian, string registerTime, string registerDay, int? fPId, short? month1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter error, ObjectParameter pordNumber, ObjectParameter preOrderId, int? pordVerifierRequestId, string pordDescriptionI, int? pordExpireDay, int? pordDeliveryTermId, string prdSaleCenterDoneTimeJson, int? foSettingId, int? centerId, int? shpCartPayTypeId, string itemWeightToleranceJson, int? pordSaleAreaId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((prjTitle != null) ? new ObjectParameter("PrjTitle", prjTitle) : new ObjectParameter("PrjTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((products != null) ? new ObjectParameter("Products", products) : new ObjectParameter("Products", typeof(string)));
		ObjectParameter objectParameter4 = (transportation.HasValue ? new ObjectParameter("Transportation", transportation) : new ObjectParameter("Transportation", typeof(decimal)));
		ObjectParameter objectParameter5 = (personId.HasValue ? new ObjectParameter("PersonId", personId) : new ObjectParameter("PersonId", typeof(int)));
		ObjectParameter objectParameter6 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter7 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter8 = (currencyUnitId.HasValue ? new ObjectParameter("CurrencyUnitId", currencyUnitId) : new ObjectParameter("CurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter9 = ((pordDeliveryEndDate != null) ? new ObjectParameter("pordDeliveryEndDate", pordDeliveryEndDate) : new ObjectParameter("pordDeliveryEndDate", typeof(string)));
		ObjectParameter objectParameter10 = (pordDeliveryEndDateTime.HasValue ? new ObjectParameter("pordDeliveryEndDateTime", pordDeliveryEndDateTime) : new ObjectParameter("pordDeliveryEndDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((pordDeliveryEndTime != null) ? new ObjectParameter("pordDeliveryEndTime", pordDeliveryEndTime) : new ObjectParameter("pordDeliveryEndTime", typeof(string)));
		ObjectParameter objectParameter12 = ((pordDeliveryDate != null) ? new ObjectParameter("pordDeliveryDate", pordDeliveryDate) : new ObjectParameter("pordDeliveryDate", typeof(string)));
		ObjectParameter objectParameter13 = (pordDeliveryDateTime.HasValue ? new ObjectParameter("pordDeliveryDateTime", pordDeliveryDateTime) : new ObjectParameter("pordDeliveryDateTime", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((pordDeliveryTime != null) ? new ObjectParameter("pordDeliveryTime", pordDeliveryTime) : new ObjectParameter("pordDeliveryTime", typeof(string)));
		ObjectParameter objectParameter15 = ((productDiscountJson != null) ? new ObjectParameter("ProductDiscountJson", productDiscountJson) : new ObjectParameter("ProductDiscountJson", typeof(string)));
		ObjectParameter objectParameter16 = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter17 = ((disCode != null) ? new ObjectParameter("DisCode", disCode) : new ObjectParameter("DisCode", typeof(string)));
		ObjectParameter objectParameter18 = (disAmount.HasValue ? new ObjectParameter("DisAmount", disAmount) : new ObjectParameter("DisAmount", typeof(decimal)));
		ObjectParameter objectParameter19 = (disAmountPercent.HasValue ? new ObjectParameter("DisAmountPercent", disAmountPercent) : new ObjectParameter("DisAmountPercent", typeof(decimal)));
		ObjectParameter objectParameter20 = ((pordDiscountTitle != null) ? new ObjectParameter("PordDiscountTitle", pordDiscountTitle) : new ObjectParameter("PordDiscountTitle", typeof(string)));
		ObjectParameter objectParameter21 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter22 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter23 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter24 = ((registerDay != null) ? new ObjectParameter("RegisterDay", registerDay) : new ObjectParameter("RegisterDay", typeof(string)));
		ObjectParameter objectParameter25 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter26 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter27 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter28 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter29 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter30 = (pordVerifierRequestId.HasValue ? new ObjectParameter("PordVerifierRequestId", pordVerifierRequestId) : new ObjectParameter("PordVerifierRequestId", typeof(int)));
		ObjectParameter objectParameter31 = ((pordDescriptionI != null) ? new ObjectParameter("PordDescriptionI", pordDescriptionI) : new ObjectParameter("PordDescriptionI", typeof(string)));
		ObjectParameter objectParameter32 = (pordExpireDay.HasValue ? new ObjectParameter("PordExpireDay", pordExpireDay) : new ObjectParameter("PordExpireDay", typeof(int)));
		ObjectParameter objectParameter33 = (pordDeliveryTermId.HasValue ? new ObjectParameter("pordDeliveryTermId", pordDeliveryTermId) : new ObjectParameter("pordDeliveryTermId", typeof(int)));
		ObjectParameter objectParameter34 = ((prdSaleCenterDoneTimeJson != null) ? new ObjectParameter("PrdSaleCenterDoneTimeJson", prdSaleCenterDoneTimeJson) : new ObjectParameter("PrdSaleCenterDoneTimeJson", typeof(string)));
		ObjectParameter objectParameter35 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter36 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter37 = (shpCartPayTypeId.HasValue ? new ObjectParameter("ShpCartPayTypeId", shpCartPayTypeId) : new ObjectParameter("ShpCartPayTypeId", typeof(int)));
		ObjectParameter objectParameter38 = ((itemWeightToleranceJson != null) ? new ObjectParameter("ItemWeightToleranceJson", itemWeightToleranceJson) : new ObjectParameter("ItemWeightToleranceJson", typeof(string)));
		ObjectParameter objectParameter39 = (pordSaleAreaId.HasValue ? new ObjectParameter("pordSaleAreaId", pordSaleAreaId) : new ObjectParameter("pordSaleAreaId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SHPMobspIssuePreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, error, pordNumber, preOrderId, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39);
	}

	public virtual ObjectResult<MobspDySelectFormFieldMasterValueSysPartInfo_Result> MobspDySelectFormFieldMasterValueSysPartInfo(int? masterValueId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldMasterValueSysPartInfo_Result>("MobspDySelectFormFieldMasterValueSysPartInfo", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspSendSmsFoSettingPordAfterVerify(int? preOrderId, string foLink, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((foLink != null) ? new ObjectParameter("FoLink", foLink) : new ObjectParameter("FoLink", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSendSmsFoSettingPordAfterVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11);
	}

	public virtual int MobspSendSmsFoSettingOrdAfterVerify(int? orderId, string foLink, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((foLink != null) ? new ObjectParameter("FoLink", foLink) : new ObjectParameter("FoLink", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSendSmsFoSettingOrdAfterVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11);
	}

	public virtual ObjectResult<FOMobspSelectCrmFoSetting_Result> FOMobspSelectCrmFoSetting(int? languageID, int? defaultLanguageID, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCrmFoSetting_Result>("FOMobspSelectCrmFoSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<FOMobspSelectDiscountCodeByCmpId_Result> FOMobspSelectDiscountCodeByCmpId(int? cmpId, DateTime? currDate, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = (cmpId.HasValue ? new ObjectParameter("CmpId", cmpId) : new ObjectParameter("CmpId", typeof(int)));
		ObjectParameter objectParameter2 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectDiscountCodeByCmpId_Result>("FOMobspSelectDiscountCodeByCmpId", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectFund_Result> MobspSelectFund(int? crmUserId, int? fundId, int? userId, DateTime? fDateTime, DateTime? tDateTime, int? fundGroupId, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (fundId.HasValue ? new ObjectParameter("FundId", fundId) : new ObjectParameter("FundId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (fundGroupId.HasValue ? new ObjectParameter("FundGroupId", fundGroupId) : new ObjectParameter("FundGroupId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter10 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectFund_Result>("MobspSelectFund", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspSelectFundGroupsTree_Result> MobspSelectFundGroupsTree(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectFundGroupsTree_Result>("MobspSelectFundGroupsTree", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int FOMobspGetBodyPatternFormulaResult(string bodyPatternFormula, int? companyId, int? companyPersonId, string cmpPassword, string oTPCode, int? foSettingId, int? languageID, int? defaultLanguageID, ObjectParameter bodyPatternFormulaResult)
	{
		ObjectParameter objectParameter = ((bodyPatternFormula != null) ? new ObjectParameter("BodyPatternFormula", bodyPatternFormula) : new ObjectParameter("BodyPatternFormula", typeof(string)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter4 = ((cmpPassword != null) ? new ObjectParameter("CmpPassword", cmpPassword) : new ObjectParameter("CmpPassword", typeof(string)));
		ObjectParameter objectParameter5 = ((oTPCode != null) ? new ObjectParameter("OTPCode", oTPCode) : new ObjectParameter("OTPCode", typeof(string)));
		ObjectParameter objectParameter6 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspGetBodyPatternFormulaResult", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, bodyPatternFormulaResult);
	}

	public virtual int FOMobspGetSmsBodyPatternFormulaForgetPasswordResult(int? companyId, int? companyPersonId, string cmpPassword, int? foSettingId, int? languageID, int? defaultLanguageID, ObjectParameter smsBodyPatternFormulaForgetPasswordResult)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((cmpPassword != null) ? new ObjectParameter("CmpPassword", cmpPassword) : new ObjectParameter("CmpPassword", typeof(string)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspGetSmsBodyPatternFormulaForgetPasswordResult", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, smsBodyPatternFormulaForgetPasswordResult);
	}

	public virtual int FOMobspGetSmsBodyPatternFormulaResult(int? companyId, int? companyPersonId, string cmpPassWord, int? foSettingId, int? languageID, int? defaultLanguageID, ObjectParameter smsBodyPatternFormulaResult)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((cmpPassWord != null) ? new ObjectParameter("CmpPassWord", cmpPassWord) : new ObjectParameter("CmpPassWord", typeof(string)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspGetSmsBodyPatternFormulaResult", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, smsBodyPatternFormulaResult);
	}

	public virtual ObjectResult<FOMobspSelectCompanyOrPersonByMobile_Result> FOMobspSelectCompanyOrPersonByMobile(int? mode, string mobile, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = ((mobile != null) ? new ObjectParameter("Mobile", mobile) : new ObjectParameter("Mobile", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyOrPersonByMobile_Result>("FOMobspSelectCompanyOrPersonByMobile", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectSysPendingOperationsNoStart_Result> MobspSelectSysPendingOperationsNoStart()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSysPendingOperationsNoStart_Result>("MobspSelectSysPendingOperationsNoStart", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<decimal?> FOMobspReturnCompanyMoneyBagRemain(int? companyId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<decimal?>("FOMobspReturnCompanyMoneyBagRemain", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspReturnFundSumFooter_Result> MobspReturnFundSumFooter(int? crmUserId, int? fundGroupId, int? userId, DateTime? fDateTime, DateTime? tDateTime)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (fundGroupId.HasValue ? new ObjectParameter("FundGroupId", fundGroupId) : new ObjectParameter("FundGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnFundSumFooter_Result>("MobspReturnFundSumFooter", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<int?> MobSpInsertFund(int? fundGroupId, int? crmUserId, DateTime? fundDate, string fundDatePersian, decimal? fundCredit, decimal? fundDebit, decimal? fundRemain, string fundDesc, string fundDesc_Lang, int? fundOrderView, string appType, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? defaultLanguageID, ObjectParameter insertedFundId)
	{
		ObjectParameter objectParameter = (fundGroupId.HasValue ? new ObjectParameter("FundGroupId", fundGroupId) : new ObjectParameter("FundGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (fundDate.HasValue ? new ObjectParameter("FundDate", fundDate) : new ObjectParameter("FundDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((fundDatePersian != null) ? new ObjectParameter("FundDatePersian", fundDatePersian) : new ObjectParameter("FundDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (fundCredit.HasValue ? new ObjectParameter("FundCredit", fundCredit) : new ObjectParameter("FundCredit", typeof(decimal)));
		ObjectParameter objectParameter6 = (fundDebit.HasValue ? new ObjectParameter("FundDebit", fundDebit) : new ObjectParameter("FundDebit", typeof(decimal)));
		ObjectParameter objectParameter7 = (fundRemain.HasValue ? new ObjectParameter("FundRemain", fundRemain) : new ObjectParameter("FundRemain", typeof(decimal)));
		ObjectParameter objectParameter8 = ((fundDesc != null) ? new ObjectParameter("FundDesc", fundDesc) : new ObjectParameter("FundDesc", typeof(string)));
		ObjectParameter objectParameter9 = ((fundDesc_Lang != null) ? new ObjectParameter("FundDesc_Lang", fundDesc_Lang) : new ObjectParameter("FundDesc_Lang", typeof(string)));
		ObjectParameter objectParameter10 = (fundOrderView.HasValue ? new ObjectParameter("FundOrderView", fundOrderView) : new ObjectParameter("FundOrderView", typeof(int)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter13 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobSpInsertFund", new ObjectParameter[18]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, insertedFundId
		});
	}

	public virtual ObjectResult<int?> MobspUpdateFundWithId(int? fundId, int? fundGroupId, int? crmUserId, DateTime? fundDate, string fundDatePersian, long? fundNumber, decimal? fundCredit, decimal? fundDebit, decimal? fundRemain, string fundDesc, string fundDesc_Lang, int? fundOrderView, int? defaultLanguageID, string appType)
	{
		ObjectParameter objectParameter = (fundId.HasValue ? new ObjectParameter("FundId", fundId) : new ObjectParameter("FundId", typeof(int)));
		ObjectParameter objectParameter2 = (fundGroupId.HasValue ? new ObjectParameter("FundGroupId", fundGroupId) : new ObjectParameter("FundGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = (fundDate.HasValue ? new ObjectParameter("FundDate", fundDate) : new ObjectParameter("FundDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((fundDatePersian != null) ? new ObjectParameter("FundDatePersian", fundDatePersian) : new ObjectParameter("FundDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (fundNumber.HasValue ? new ObjectParameter("FundNumber", fundNumber) : new ObjectParameter("FundNumber", typeof(long)));
		ObjectParameter objectParameter7 = (fundCredit.HasValue ? new ObjectParameter("FundCredit", fundCredit) : new ObjectParameter("FundCredit", typeof(decimal)));
		ObjectParameter objectParameter8 = (fundDebit.HasValue ? new ObjectParameter("FundDebit", fundDebit) : new ObjectParameter("FundDebit", typeof(decimal)));
		ObjectParameter objectParameter9 = (fundRemain.HasValue ? new ObjectParameter("FundRemain", fundRemain) : new ObjectParameter("FundRemain", typeof(decimal)));
		ObjectParameter objectParameter10 = ((fundDesc != null) ? new ObjectParameter("FundDesc", fundDesc) : new ObjectParameter("FundDesc", typeof(string)));
		ObjectParameter objectParameter11 = ((fundDesc_Lang != null) ? new ObjectParameter("FundDesc_Lang", fundDesc_Lang) : new ObjectParameter("FundDesc_Lang", typeof(string)));
		ObjectParameter objectParameter12 = (fundOrderView.HasValue ? new ObjectParameter("FundOrderView", fundOrderView) : new ObjectParameter("FundOrderView", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateFundWithId", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual ObjectResult<MobspSelectPriorFund_Result> MobspSelectPriorFund(int? crmUserId, int? currFundId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (currFundId.HasValue ? new ObjectParameter("CurrFundId", currFundId) : new ObjectParameter("CurrFundId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPriorFund_Result>("MobspSelectPriorFund", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspDeleteFund(int? fundId)
	{
		ObjectParameter objectParameter = (fundId.HasValue ? new ObjectParameter("FundId", fundId) : new ObjectParameter("FundId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteFund", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspReUpdateFundRemain(int? crmUserId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspReUpdateFundRemain", objectParameter);
	}

	public virtual ObjectResult<int?> MobspSelectFundCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspSelectFundCnt", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectSmartTimeAttendanceMission_Result> MobspSelectSmartTimeAttendanceMission(int? requestUserId)
	{
		ObjectParameter objectParameter = (requestUserId.HasValue ? new ObjectParameter("RequestUserId", requestUserId) : new ObjectParameter("RequestUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmartTimeAttendanceMission_Result>("MobspSelectSmartTimeAttendanceMission", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspPrintFund_Result> CRMspPrintFund(int? crmUserId, DateTime? fDateTime, DateTime? tDateTime, int? rptUserId, string rptDate, string rptDay, int? fundGroupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (rptUserId.HasValue ? new ObjectParameter("RptUserId", rptUserId) : new ObjectParameter("RptUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((rptDate != null) ? new ObjectParameter("RptDate", rptDate) : new ObjectParameter("RptDate", typeof(string)));
		ObjectParameter objectParameter6 = ((rptDay != null) ? new ObjectParameter("RptDay", rptDay) : new ObjectParameter("RptDay", typeof(string)));
		ObjectParameter objectParameter7 = (fundGroupId.HasValue ? new ObjectParameter("FundGroupId", fundGroupId) : new ObjectParameter("FundGroupId", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspPrintFund_Result>("CRMspPrintFund", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result> MobHrmspInternalMessageLoadShortUserMessageByTypes(int? userID, int? isRead, string typeIDs, string seperator, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (isRead.HasValue ? new ObjectParameter("IsRead", isRead) : new ObjectParameter("IsRead", typeof(int)));
		ObjectParameter objectParameter3 = ((typeIDs != null) ? new ObjectParameter("TypeIDs", typeIDs) : new ObjectParameter("TypeIDs", typeof(string)));
		ObjectParameter objectParameter4 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>("MobHrmspInternalMessageLoadShortUserMessageByTypes", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspCheckDuplicatePrsNationalCode_Result> MobspCheckDuplicatePrsNationalCode(string prsNationalCode, int? currId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((prsNationalCode != null) ? new ObjectParameter("PrsNationalCode", prsNationalCode) : new ObjectParameter("PrsNationalCode", typeof(string)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicatePrsNationalCode_Result>("MobspCheckDuplicatePrsNationalCode", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspCheckDuplicateCmpNationalCode_Result> MobspCheckDuplicateCmpNationalCode(string cmpNationalCode, int? currId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((cmpNationalCode != null) ? new ObjectParameter("CmpNationalCode", cmpNationalCode) : new ObjectParameter("CmpNationalCode", typeof(string)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicateCmpNationalCode_Result>("MobspCheckDuplicateCmpNationalCode", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCenters_Result> MobspSelectCenters(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCenters_Result>("MobspSelectCenters", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCentersWithIds_Result> MobspSelectCentersWithIds(string ids, string seperator, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((ids != null) ? new ObjectParameter("Ids", ids) : new ObjectParameter("Ids", typeof(string)));
		ObjectParameter objectParameter2 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCentersWithIds_Result>("MobspSelectCentersWithIds", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspUpdateCompanyCIds(int? cId, int? companyId)
	{
		ObjectParameter objectParameter = (cId.HasValue ? new ObjectParameter("CId", cId) : new ObjectParameter("CId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateCompanyCIds", objectParameter, objectParameter2);
	}

	public virtual int MobspUpdateCompanyPersonCIds(int? cId, int? companyId, int? companyPersonId)
	{
		ObjectParameter objectParameter = (cId.HasValue ? new ObjectParameter("CId", cId) : new ObjectParameter("CId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateCompanyPersonCIds", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual ObjectResult<CRMspSelectCalendarEventWeekDates_Result> CRMspSelectCalendarEventWeekDates(DateTime? date, int? fistWeekDayNum, int? rangeNumbe)
	{
		ObjectParameter objectParameter = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter2 = (fistWeekDayNum.HasValue ? new ObjectParameter("FistWeekDayNum", fistWeekDayNum) : new ObjectParameter("FistWeekDayNum", typeof(int)));
		ObjectParameter objectParameter3 = (rangeNumbe.HasValue ? new ObjectParameter("RangeNumbe", rangeNumbe) : new ObjectParameter("RangeNumbe", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCalendarEventWeekDates_Result>("CRMspSelectCalendarEventWeekDates", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspControlPreOrderItemsFromShop_Result> MobspControlPreOrderItemsFromShop(int? preOrderId, string productJson, int? centerId, int? prdKind, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((productJson != null) ? new ObjectParameter("ProductJson", productJson) : new ObjectParameter("ProductJson", typeof(string)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspControlPreOrderItemsFromShop_Result>("MobspControlPreOrderItemsFromShop", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspControlPreOrderItemsFromWarehouse_Result> MobspControlPreOrderItemsFromWarehouse(int? preOrderId, int? centerId, int? prdKind, int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter3 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspControlPreOrderItemsFromWarehouse_Result>("MobspControlPreOrderItemsFromWarehouse", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspControlPreOrderItemsReserveStock_Result> MobspControlPreOrderItemsReserveStock(int? preOrderId, int? centerId, DateTime? currDate, int? prdKind, int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter3 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspControlPreOrderItemsReserveStock_Result>("MobspControlPreOrderItemsReserveStock", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspReturnPrdQuantityFromShop_Result> MobspReturnPrdQuantityFromShop(int? productId, double? prdSHPLinkAccStock, int? whId, string tracing, int? centerId, int? foSettingId, int? currPreOrderId, int? currOrderId, int? languageID, int? defaultLanguageID, int? currPreOrderItemId, int? currOrderItemId)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (prdSHPLinkAccStock.HasValue ? new ObjectParameter("PrdSHPLinkAccStock", prdSHPLinkAccStock) : new ObjectParameter("PrdSHPLinkAccStock", typeof(double)));
		ObjectParameter objectParameter3 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter4 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter6 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter7 = (currPreOrderId.HasValue ? new ObjectParameter("CurrPreOrderId", currPreOrderId) : new ObjectParameter("CurrPreOrderId", typeof(int)));
		ObjectParameter objectParameter8 = (currOrderId.HasValue ? new ObjectParameter("CurrOrderId", currOrderId) : new ObjectParameter("CurrOrderId", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (currPreOrderItemId.HasValue ? new ObjectParameter("CurrPreOrderItemId", currPreOrderItemId) : new ObjectParameter("CurrPreOrderItemId", typeof(int)));
		ObjectParameter objectParameter12 = (currOrderItemId.HasValue ? new ObjectParameter("CurrOrderItemId", currOrderItemId) : new ObjectParameter("CurrOrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnPrdQuantityFromShop_Result>("MobspReturnPrdQuantityFromShop", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<MobspSelectCompanyOperations_Result> MobspSelectCompanyOperations(int? companyId, int? projectId, int? smscnt, int? userId, int? languageID, int? defaultLanguageID, string buyOrderText, bool? isShowFreeSms, bool? isShowFreeEmail, string prjTitleGroup, bool? prjIsFinished, int? pageNumber, int? pageSize, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (smscnt.HasValue ? new ObjectParameter("Smscnt", smscnt) : new ObjectParameter("Smscnt", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = ((buyOrderText != null) ? new ObjectParameter("BuyOrderText", buyOrderText) : new ObjectParameter("BuyOrderText", typeof(string)));
		ObjectParameter objectParameter8 = (isShowFreeSms.HasValue ? new ObjectParameter("IsShowFreeSms", isShowFreeSms) : new ObjectParameter("IsShowFreeSms", typeof(bool)));
		ObjectParameter objectParameter9 = (isShowFreeEmail.HasValue ? new ObjectParameter("IsShowFreeEmail", isShowFreeEmail) : new ObjectParameter("IsShowFreeEmail", typeof(bool)));
		ObjectParameter objectParameter10 = ((prjTitleGroup != null) ? new ObjectParameter("PrjTitleGroup", prjTitleGroup) : new ObjectParameter("PrjTitleGroup", typeof(string)));
		ObjectParameter objectParameter11 = (prjIsFinished.HasValue ? new ObjectParameter("PrjIsFinished", prjIsFinished) : new ObjectParameter("PrjIsFinished", typeof(bool)));
		ObjectParameter objectParameter12 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter13 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyOperations_Result>("MobspSelectCompanyOperations", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual ObjectResult<MobspSelectSaleAreas_Result> MobspSelectSaleAreas(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSaleAreas_Result>("MobspSelectSaleAreas", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<WSspRpt_PrintPaymentByIdAndType_Result> WSspRpt_PrintPaymentByIdAndType(int? paymentId, int? paymentType, string buyOrderTitle, string preOrderTitle, string saleOrderTitle, int? languageID, int? defaultLanguageID, int? rptUserId, string rptDate, string rptDay)
	{
		ObjectParameter objectParameter = (paymentId.HasValue ? new ObjectParameter("PaymentId", paymentId) : new ObjectParameter("PaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (paymentType.HasValue ? new ObjectParameter("PaymentType", paymentType) : new ObjectParameter("PaymentType", typeof(int)));
		ObjectParameter objectParameter3 = ((buyOrderTitle != null) ? new ObjectParameter("BuyOrderTitle", buyOrderTitle) : new ObjectParameter("BuyOrderTitle", typeof(string)));
		ObjectParameter objectParameter4 = ((preOrderTitle != null) ? new ObjectParameter("PreOrderTitle", preOrderTitle) : new ObjectParameter("PreOrderTitle", typeof(string)));
		ObjectParameter objectParameter5 = ((saleOrderTitle != null) ? new ObjectParameter("SaleOrderTitle", saleOrderTitle) : new ObjectParameter("SaleOrderTitle", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (rptUserId.HasValue ? new ObjectParameter("rptUserId", rptUserId) : new ObjectParameter("rptUserId", typeof(int)));
		ObjectParameter objectParameter9 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter10 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintPaymentByIdAndType_Result>("WSspRpt_PrintPaymentByIdAndType", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspSelectCompanyMoneyBag_Result> CRMspSelectCompanyMoneyBag(int? companyId, DateTime? fDateTime, DateTime? tDateTime, string textRemainderBefore, string textManual, string textSystemic, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((textRemainderBefore != null) ? new ObjectParameter("TextRemainderBefore", textRemainderBefore) : new ObjectParameter("TextRemainderBefore", typeof(string)));
		ObjectParameter objectParameter5 = ((textManual != null) ? new ObjectParameter("TextManual", textManual) : new ObjectParameter("TextManual", typeof(string)));
		ObjectParameter objectParameter6 = ((textSystemic != null) ? new ObjectParameter("TextSystemic", textSystemic) : new ObjectParameter("TextSystemic", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyMoneyBag_Result>("CRMspSelectCompanyMoneyBag", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspRpt_PrintCompanyMoneyBagById_Result> CRMspRpt_PrintCompanyMoneyBagById(int? companyMoneyBagId, int? rptUserId, string rptDate, string rptDay, string textManual, string textSystemic, string paymentTitle, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyMoneyBagId.HasValue ? new ObjectParameter("CompanyMoneyBagId", companyMoneyBagId) : new ObjectParameter("CompanyMoneyBagId", typeof(int)));
		ObjectParameter objectParameter2 = (rptUserId.HasValue ? new ObjectParameter("rptUserId", rptUserId) : new ObjectParameter("rptUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter4 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter5 = ((textManual != null) ? new ObjectParameter("TextManual", textManual) : new ObjectParameter("TextManual", typeof(string)));
		ObjectParameter objectParameter6 = ((textSystemic != null) ? new ObjectParameter("TextSystemic", textSystemic) : new ObjectParameter("TextSystemic", typeof(string)));
		ObjectParameter objectParameter7 = ((paymentTitle != null) ? new ObjectParameter("PaymentTitle", paymentTitle) : new ObjectParameter("PaymentTitle", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspRpt_PrintCompanyMoneyBagById_Result>("CRMspRpt_PrintCompanyMoneyBagById", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<WSspRpt_PrintBuyOrder_Result> WSspRpt_PrintBuyOrder(int? buyOrderID, int? languageID, int? defaultLanguageID, int? userId, string rptDate, string rptDay)
	{
		ObjectParameter objectParameter = (buyOrderID.HasValue ? new ObjectParameter("BuyOrderID", buyOrderID) : new ObjectParameter("BuyOrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter6 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintBuyOrder_Result>("WSspRpt_PrintBuyOrder", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<CRMspDyPrintBordForm_Result> CRMspDyPrintBordForm(int? buyOrderId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintBordForm_Result>("CRMspDyPrintBordForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspRpt_PrintBuyOrderItems_Result> WSspRpt_PrintBuyOrderItems(int? buyOrderID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderID.HasValue ? new ObjectParameter("BuyOrderID", buyOrderID) : new ObjectParameter("BuyOrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintBuyOrderItems_Result>("WSspRpt_PrintBuyOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintBuyOrderItemSerials_Result> WSspRpt_PrintBuyOrderItemSerials(int? buyOrderItemID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderItemID.HasValue ? new ObjectParameter("BuyOrderItemID", buyOrderItemID) : new ObjectParameter("BuyOrderItemID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintBuyOrderItemSerials_Result>("WSspRpt_PrintBuyOrderItemSerials", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintBuyOrderPayments_Result> WSspRpt_PrintBuyOrderPayments(int? buyOrderID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderID.HasValue ? new ObjectParameter("BuyOrderID", buyOrderID) : new ObjectParameter("BuyOrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintBuyOrderPayments_Result>("WSspRpt_PrintBuyOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspReturnCmpAccountingDetails_Result> CRMspReturnCmpAccountingDetails(int? companyId, int? languageID, int? defaultLanguageID, string orderTitle, string paymentTitle, string wastedTitle, string buyOrderTitle, string preOrderTitle, string saleOrderTitle, DateTime? fDateTime, DateTime? tDateTime, int? rptUserId, string rptDate, string rptDay, string cmpMoneyBagTitle, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = ((orderTitle != null) ? new ObjectParameter("OrderTitle", orderTitle) : new ObjectParameter("OrderTitle", typeof(string)));
		ObjectParameter objectParameter5 = ((paymentTitle != null) ? new ObjectParameter("PaymentTitle", paymentTitle) : new ObjectParameter("PaymentTitle", typeof(string)));
		ObjectParameter objectParameter6 = ((wastedTitle != null) ? new ObjectParameter("WastedTitle", wastedTitle) : new ObjectParameter("WastedTitle", typeof(string)));
		ObjectParameter objectParameter7 = ((buyOrderTitle != null) ? new ObjectParameter("BuyOrderTitle", buyOrderTitle) : new ObjectParameter("BuyOrderTitle", typeof(string)));
		ObjectParameter objectParameter8 = ((preOrderTitle != null) ? new ObjectParameter("PreOrderTitle", preOrderTitle) : new ObjectParameter("PreOrderTitle", typeof(string)));
		ObjectParameter objectParameter9 = ((saleOrderTitle != null) ? new ObjectParameter("SaleOrderTitle", saleOrderTitle) : new ObjectParameter("SaleOrderTitle", typeof(string)));
		ObjectParameter objectParameter10 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter12 = (rptUserId.HasValue ? new ObjectParameter("rptUserId", rptUserId) : new ObjectParameter("rptUserId", typeof(int)));
		ObjectParameter objectParameter13 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter14 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter15 = ((cmpMoneyBagTitle != null) ? new ObjectParameter("CmpMoneyBagTitle", cmpMoneyBagTitle) : new ObjectParameter("CmpMoneyBagTitle", typeof(string)));
		ObjectParameter objectParameter16 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspReturnCmpAccountingDetails_Result>("CRMspReturnCmpAccountingDetails", new ObjectParameter[16]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16
		});
	}

	public virtual ObjectResult<SHPMobspSelectDeliveryTerms_Result> SHPMobspSelectDeliveryTerms(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectDeliveryTerms_Result>("SHPMobspSelectDeliveryTerms", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<SHPMobspSelectPreOrderItems_Result> SHPMobspSelectPreOrderItems(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectPreOrderItems_Result>("SHPMobspSelectPreOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspMainSearch_Result> MobspMainSearch(string val, int? userID, int? searchType, int? languageID, int? defaultLanguageID, string searchConditionMode, int? centerId, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (searchType.HasValue ? new ObjectParameter("SearchType", searchType) : new ObjectParameter("SearchType", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = ((searchConditionMode != null) ? new ObjectParameter("SearchConditionMode", searchConditionMode) : new ObjectParameter("SearchConditionMode", typeof(string)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspMainSearch_Result>("MobspMainSearch", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<SHPMobspSelectCompanyPersonAddress_Result> SHPMobspSelectCompanyPersonAddress(int? companyId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectCompanyPersonAddress_Result>("SHPMobspSelectCompanyPersonAddress", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int SHPMobspInsertCompanyPerson(int? companyId, string prsLName, string prsFName, string prsPreTel, string prsTel, string prsTelUpTo, string prsFax, string prsMobile, string prsWebSite, string prsEmail, string prsAddress, string prsZipCode, int? prsOrderView, int? prsCountryId, int? prsProvinceId, int? prsCityId, string prsCoordinateLatitude, string prsCoordinateLongitude, DateTime? prsCoordinateLastDate, string prsCoordinateLastDatePersian, int? prsCoordinateZoomLevel, int? prsCoordinateLastUserId, string prsNationalCode, string prsIdentityNumber, string prsDescription, int? year1, int? month1, int? userId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string prsBirthDate, DateTime? prsBirthDateTime, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((prsLName != null) ? new ObjectParameter("prsLName", prsLName) : new ObjectParameter("prsLName", typeof(string)));
		ObjectParameter objectParameter3 = ((prsFName != null) ? new ObjectParameter("prsFName", prsFName) : new ObjectParameter("prsFName", typeof(string)));
		ObjectParameter objectParameter4 = ((prsPreTel != null) ? new ObjectParameter("prsPreTel", prsPreTel) : new ObjectParameter("prsPreTel", typeof(string)));
		ObjectParameter objectParameter5 = ((prsTel != null) ? new ObjectParameter("prsTel", prsTel) : new ObjectParameter("prsTel", typeof(string)));
		ObjectParameter objectParameter6 = ((prsTelUpTo != null) ? new ObjectParameter("prsTelUpTo", prsTelUpTo) : new ObjectParameter("prsTelUpTo", typeof(string)));
		ObjectParameter objectParameter7 = ((prsFax != null) ? new ObjectParameter("prsFax", prsFax) : new ObjectParameter("prsFax", typeof(string)));
		ObjectParameter objectParameter8 = ((prsMobile != null) ? new ObjectParameter("prsMobile", prsMobile) : new ObjectParameter("prsMobile", typeof(string)));
		ObjectParameter objectParameter9 = ((prsWebSite != null) ? new ObjectParameter("prsWebSite", prsWebSite) : new ObjectParameter("prsWebSite", typeof(string)));
		ObjectParameter objectParameter10 = ((prsEmail != null) ? new ObjectParameter("prsEmail", prsEmail) : new ObjectParameter("prsEmail", typeof(string)));
		ObjectParameter objectParameter11 = ((prsAddress != null) ? new ObjectParameter("prsAddress", prsAddress) : new ObjectParameter("prsAddress", typeof(string)));
		ObjectParameter objectParameter12 = ((prsZipCode != null) ? new ObjectParameter("prsZipCode", prsZipCode) : new ObjectParameter("prsZipCode", typeof(string)));
		ObjectParameter objectParameter13 = (prsOrderView.HasValue ? new ObjectParameter("prsOrderView", prsOrderView) : new ObjectParameter("prsOrderView", typeof(int)));
		ObjectParameter objectParameter14 = (prsCountryId.HasValue ? new ObjectParameter("prsCountryId", prsCountryId) : new ObjectParameter("prsCountryId", typeof(int)));
		ObjectParameter objectParameter15 = (prsProvinceId.HasValue ? new ObjectParameter("prsProvinceId", prsProvinceId) : new ObjectParameter("prsProvinceId", typeof(int)));
		ObjectParameter objectParameter16 = (prsCityId.HasValue ? new ObjectParameter("prsCityId", prsCityId) : new ObjectParameter("prsCityId", typeof(int)));
		ObjectParameter objectParameter17 = ((prsCoordinateLatitude != null) ? new ObjectParameter("prsCoordinateLatitude", prsCoordinateLatitude) : new ObjectParameter("prsCoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter18 = ((prsCoordinateLongitude != null) ? new ObjectParameter("prsCoordinateLongitude", prsCoordinateLongitude) : new ObjectParameter("prsCoordinateLongitude", typeof(string)));
		ObjectParameter objectParameter19 = (prsCoordinateLastDate.HasValue ? new ObjectParameter("prsCoordinateLastDate", prsCoordinateLastDate) : new ObjectParameter("prsCoordinateLastDate", typeof(DateTime)));
		ObjectParameter objectParameter20 = ((prsCoordinateLastDatePersian != null) ? new ObjectParameter("prsCoordinateLastDatePersian", prsCoordinateLastDatePersian) : new ObjectParameter("prsCoordinateLastDatePersian", typeof(string)));
		ObjectParameter objectParameter21 = (prsCoordinateZoomLevel.HasValue ? new ObjectParameter("prsCoordinateZoomLevel", prsCoordinateZoomLevel) : new ObjectParameter("prsCoordinateZoomLevel", typeof(int)));
		ObjectParameter objectParameter22 = (prsCoordinateLastUserId.HasValue ? new ObjectParameter("prsCoordinateLastUserId", prsCoordinateLastUserId) : new ObjectParameter("prsCoordinateLastUserId", typeof(int)));
		ObjectParameter objectParameter23 = ((prsNationalCode != null) ? new ObjectParameter("prsNationalCode", prsNationalCode) : new ObjectParameter("prsNationalCode", typeof(string)));
		ObjectParameter objectParameter24 = ((prsIdentityNumber != null) ? new ObjectParameter("prsIdentityNumber", prsIdentityNumber) : new ObjectParameter("prsIdentityNumber", typeof(string)));
		ObjectParameter objectParameter25 = ((prsDescription != null) ? new ObjectParameter("prsDescription", prsDescription) : new ObjectParameter("prsDescription", typeof(string)));
		ObjectParameter objectParameter26 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter27 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter28 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter29 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter30 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter31 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter32 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter33 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter34 = ((prsBirthDate != null) ? new ObjectParameter("prsBirthDate", prsBirthDate) : new ObjectParameter("prsBirthDate", typeof(string)));
		ObjectParameter objectParameter35 = (prsBirthDateTime.HasValue ? new ObjectParameter("prsBirthDateTime", prsBirthDateTime) : new ObjectParameter("prsBirthDateTime", typeof(DateTime)));
		ObjectParameter objectParameter36 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SHPMobspInsertCompanyPerson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36);
	}

	public virtual int SHPMobspUpdateCompanyPerson(int? companyPersonID, string prsLName, string prsFName, string prsMobile, string prsEmail, string prsAddress, string prsZipCode, int? prsCountryId, int? prsProvinceId, int? prsCityId, string prsCoordinateLatitude, string prsCoordinateLongitude, DateTime? prsCoordinateLastDate, string prsCoordinateLastDatePersian, int? prsCoordinateZoomLevel, int? prsCoordinateLastUserId, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string prsBirthDate, DateTime? prsBirthDateTime)
	{
		ObjectParameter objectParameter = (companyPersonID.HasValue ? new ObjectParameter("CompanyPersonID", companyPersonID) : new ObjectParameter("CompanyPersonID", typeof(int)));
		ObjectParameter objectParameter2 = ((prsLName != null) ? new ObjectParameter("prsLName", prsLName) : new ObjectParameter("prsLName", typeof(string)));
		ObjectParameter objectParameter3 = ((prsFName != null) ? new ObjectParameter("prsFName", prsFName) : new ObjectParameter("prsFName", typeof(string)));
		ObjectParameter objectParameter4 = ((prsMobile != null) ? new ObjectParameter("prsMobile", prsMobile) : new ObjectParameter("prsMobile", typeof(string)));
		ObjectParameter objectParameter5 = ((prsEmail != null) ? new ObjectParameter("prsEmail", prsEmail) : new ObjectParameter("prsEmail", typeof(string)));
		ObjectParameter objectParameter6 = ((prsAddress != null) ? new ObjectParameter("prsAddress", prsAddress) : new ObjectParameter("prsAddress", typeof(string)));
		ObjectParameter objectParameter7 = ((prsZipCode != null) ? new ObjectParameter("prsZipCode", prsZipCode) : new ObjectParameter("prsZipCode", typeof(string)));
		ObjectParameter objectParameter8 = (prsCountryId.HasValue ? new ObjectParameter("prsCountryId", prsCountryId) : new ObjectParameter("prsCountryId", typeof(int)));
		ObjectParameter objectParameter9 = (prsProvinceId.HasValue ? new ObjectParameter("prsProvinceId", prsProvinceId) : new ObjectParameter("prsProvinceId", typeof(int)));
		ObjectParameter objectParameter10 = (prsCityId.HasValue ? new ObjectParameter("prsCityId", prsCityId) : new ObjectParameter("prsCityId", typeof(int)));
		ObjectParameter objectParameter11 = ((prsCoordinateLatitude != null) ? new ObjectParameter("prsCoordinateLatitude", prsCoordinateLatitude) : new ObjectParameter("prsCoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter12 = ((prsCoordinateLongitude != null) ? new ObjectParameter("prsCoordinateLongitude", prsCoordinateLongitude) : new ObjectParameter("prsCoordinateLongitude", typeof(string)));
		ObjectParameter objectParameter13 = (prsCoordinateLastDate.HasValue ? new ObjectParameter("prsCoordinateLastDate", prsCoordinateLastDate) : new ObjectParameter("prsCoordinateLastDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((prsCoordinateLastDatePersian != null) ? new ObjectParameter("prsCoordinateLastDatePersian", prsCoordinateLastDatePersian) : new ObjectParameter("prsCoordinateLastDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = (prsCoordinateZoomLevel.HasValue ? new ObjectParameter("prsCoordinateZoomLevel", prsCoordinateZoomLevel) : new ObjectParameter("prsCoordinateZoomLevel", typeof(int)));
		ObjectParameter objectParameter16 = (prsCoordinateLastUserId.HasValue ? new ObjectParameter("prsCoordinateLastUserId", prsCoordinateLastUserId) : new ObjectParameter("prsCoordinateLastUserId", typeof(int)));
		ObjectParameter objectParameter17 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter18 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter19 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter20 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter21 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter22 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter23 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter24 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter25 = ((prsBirthDate != null) ? new ObjectParameter("prsBirthDate", prsBirthDate) : new ObjectParameter("prsBirthDate", typeof(string)));
		ObjectParameter objectParameter26 = (prsBirthDateTime.HasValue ? new ObjectParameter("prsBirthDateTime", prsBirthDateTime) : new ObjectParameter("prsBirthDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SHPMobspUpdateCompanyPerson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26);
	}

	public virtual ObjectResult<int?> MobspInsertDocFull(string docParams, string docItemParams, string docItemSerialParams, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resErrorMessage, ObjectParameter resInsertedDocId, ObjectParameter resInsertedDocItemIds, ObjectParameter resInsertedDocItemSerialIds, int? centerId)
	{
		ObjectParameter objectParameter = ((docParams != null) ? new ObjectParameter("DocParams", docParams) : new ObjectParameter("DocParams", typeof(string)));
		ObjectParameter objectParameter2 = ((docItemParams != null) ? new ObjectParameter("DocItemParams", docItemParams) : new ObjectParameter("DocItemParams", typeof(string)));
		ObjectParameter objectParameter3 = ((docItemSerialParams != null) ? new ObjectParameter("DocItemSerialParams", docItemSerialParams) : new ObjectParameter("DocItemSerialParams", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertDocFull", new ObjectParameter[16]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, resErrorMessage, resInsertedDocId, resInsertedDocItemIds, resInsertedDocItemSerialIds, objectParameter12
		});
	}

	public virtual ObjectResult<MobspReturnDocPrdSerial_Result> MobspReturnDocPrdSerial(int? fPId, int? wHID, int? prdId, int? currId, int? languageID, int? defaultLanguageID, int? orderId, int? centerId, string orderIds)
	{
		ObjectParameter objectParameter = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter2 = (wHID.HasValue ? new ObjectParameter("WHID", wHID) : new ObjectParameter("WHID", typeof(int)));
		ObjectParameter objectParameter3 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter4 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter9 = ((orderIds != null) ? new ObjectParameter("OrderIds", orderIds) : new ObjectParameter("OrderIds", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocPrdSerial_Result>("MobspReturnDocPrdSerial", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspDocItemSerialSearch_Result> MobspDocItemSerialSearch(string val, int? userId, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId, int? lastRowNumber, int? stockMode, string objectJson)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(int)));
		ObjectParameter objectParameter8 = (stockMode.HasValue ? new ObjectParameter("StockMode", stockMode) : new ObjectParameter("StockMode", typeof(int)));
		ObjectParameter objectParameter9 = ((objectJson != null) ? new ObjectParameter("ObjectJson", objectJson) : new ObjectParameter("ObjectJson", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDocItemSerialSearch_Result>("MobspDocItemSerialSearch", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<int?> MobspReturnCmpFOIsActiveCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnCmpFOIsActiveCnt", Array.Empty<ObjectParameter>());
	}

	public virtual int MobspInsertShortLink(string originalUrl, int? systemPartId, int? objectId, int? objectIdI, bool? isExternal, string description, bool? inActive, DateTime? expireDate, long? maxViewCount, int? userId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, string domain, ObjectParameter shortKey)
	{
		ObjectParameter objectParameter = ((originalUrl != null) ? new ObjectParameter("OriginalUrl", originalUrl) : new ObjectParameter("OriginalUrl", typeof(string)));
		ObjectParameter objectParameter2 = (systemPartId.HasValue ? new ObjectParameter("SystemPartId", systemPartId) : new ObjectParameter("SystemPartId", typeof(int)));
		ObjectParameter objectParameter3 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter4 = (objectIdI.HasValue ? new ObjectParameter("ObjectIdI", objectIdI) : new ObjectParameter("ObjectIdI", typeof(int)));
		ObjectParameter objectParameter5 = (isExternal.HasValue ? new ObjectParameter("IsExternal", isExternal) : new ObjectParameter("IsExternal", typeof(bool)));
		ObjectParameter objectParameter6 = ((description != null) ? new ObjectParameter("Description", description) : new ObjectParameter("Description", typeof(string)));
		ObjectParameter objectParameter7 = (inActive.HasValue ? new ObjectParameter("InActive", inActive) : new ObjectParameter("InActive", typeof(bool)));
		ObjectParameter objectParameter8 = (expireDate.HasValue ? new ObjectParameter("ExpireDate", expireDate) : new ObjectParameter("ExpireDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = (maxViewCount.HasValue ? new ObjectParameter("MaxViewCount", maxViewCount) : new ObjectParameter("MaxViewCount", typeof(long)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter15 = ((domain != null) ? new ObjectParameter("Domain", domain) : new ObjectParameter("Domain", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertShortLink", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, shortKey);
	}

	public virtual int MobspAutoCalcOrderItemPrice(int? orderId, int? productId, ObjectParameter price)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspAutoCalcOrderItemPrice", objectParameter, objectParameter2, price);
	}

	public virtual int MobspAutoCalcPreOrderItemPrice(int? preOrderId, int? productId, ObjectParameter price)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspAutoCalcPreOrderItemPrice", objectParameter, objectParameter2, price);
	}

	public virtual ObjectResult<MobspSelectOrderPaymentGroupsI_Result> MobspSelectOrderPaymentGroupsI(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderPaymentGroupsI_Result>("MobspSelectOrderPaymentGroupsI", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectOrderPaymentGroupsII_Result> MobspSelectOrderPaymentGroupsII(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderPaymentGroupsII_Result>("MobspSelectOrderPaymentGroupsII", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectBankingBanks_Result> MobspSelectBankingBanks(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectBankingBanks_Result>("MobspSelectBankingBanks", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCashes_Result> MobspSelectCashes(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCashes_Result>("MobspSelectCashes", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectBankingAccountsByBranchAndUserId_Result> MobspSelectBankingAccountsByBranchAndUserId(int? branchId, int? crmUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (branchId.HasValue ? new ObjectParameter("BranchId", branchId) : new ObjectParameter("BranchId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectBankingAccountsByBranchAndUserId_Result>("MobspSelectBankingAccountsByBranchAndUserId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectBankingBranches_Result> MobspSelectBankingBranches(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectBankingBranches_Result>("MobspSelectBankingBranches", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<FOMobspInsertConversation_Result> FOMobspInsertConversation(int? companyId, int? projectId, string cnvsDesc, int? cnvsPersonId, int? cnvsPriorityId, int? defaultUserId, DateTime? registerDate, string registerDatePersian, string registerDay, string registerTime, DateTime? firstRegisterDateAddSecond, int? internalMessageYear, int? year1, int? month1, string appType, int? languageID, string needErjaRefmsgBody, string needErjaMultiIntmsgBody, string needSendErjaAllarmRefmsgBody, string conversationErjaShowText, int? linkedTypeId, int? centerId, int? foCountModule)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((cnvsDesc != null) ? new ObjectParameter("CnvsDesc", cnvsDesc) : new ObjectParameter("CnvsDesc", typeof(string)));
		ObjectParameter objectParameter4 = (cnvsPersonId.HasValue ? new ObjectParameter("CnvsPersonId", cnvsPersonId) : new ObjectParameter("CnvsPersonId", typeof(int)));
		ObjectParameter objectParameter5 = (cnvsPriorityId.HasValue ? new ObjectParameter("CnvsPriorityId", cnvsPriorityId) : new ObjectParameter("CnvsPriorityId", typeof(int)));
		ObjectParameter objectParameter6 = (defaultUserId.HasValue ? new ObjectParameter("DefaultUserId", defaultUserId) : new ObjectParameter("DefaultUserId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((registerDay != null) ? new ObjectParameter("RegisterDay", registerDay) : new ObjectParameter("RegisterDay", typeof(string)));
		ObjectParameter objectParameter10 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter11 = (firstRegisterDateAddSecond.HasValue ? new ObjectParameter("FirstRegisterDateAddSecond", firstRegisterDateAddSecond) : new ObjectParameter("FirstRegisterDateAddSecond", typeof(DateTime)));
		ObjectParameter objectParameter12 = (internalMessageYear.HasValue ? new ObjectParameter("InternalMessageYear", internalMessageYear) : new ObjectParameter("InternalMessageYear", typeof(int)));
		ObjectParameter objectParameter13 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter17 = ((needErjaRefmsgBody != null) ? new ObjectParameter("NeedErjaRefmsgBody", needErjaRefmsgBody) : new ObjectParameter("NeedErjaRefmsgBody", typeof(string)));
		ObjectParameter objectParameter18 = ((needErjaMultiIntmsgBody != null) ? new ObjectParameter("NeedErjaMultiIntmsgBody", needErjaMultiIntmsgBody) : new ObjectParameter("NeedErjaMultiIntmsgBody", typeof(string)));
		ObjectParameter objectParameter19 = ((needSendErjaAllarmRefmsgBody != null) ? new ObjectParameter("NeedSendErjaAllarmRefmsgBody", needSendErjaAllarmRefmsgBody) : new ObjectParameter("NeedSendErjaAllarmRefmsgBody", typeof(string)));
		ObjectParameter objectParameter20 = ((conversationErjaShowText != null) ? new ObjectParameter("ConversationErjaShowText", conversationErjaShowText) : new ObjectParameter("ConversationErjaShowText", typeof(string)));
		ObjectParameter objectParameter21 = (linkedTypeId.HasValue ? new ObjectParameter("LinkedTypeId", linkedTypeId) : new ObjectParameter("LinkedTypeId", typeof(int)));
		ObjectParameter objectParameter22 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter23 = (foCountModule.HasValue ? new ObjectParameter("FoCountModule", foCountModule) : new ObjectParameter("FoCountModule", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspInsertConversation_Result>("FOMobspInsertConversation", new ObjectParameter[23]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23
		});
	}

	public virtual ObjectResult<MobspSelectUserDepartments_Result> MobspSelectUserDepartments(int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserDepartments_Result>("MobspSelectUserDepartments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectOrderById_Result> MobspSelectOrderById(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderById_Result>("MobspSelectOrderById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateSerialInfoVI(string serials, string serialSpliter, string infoVI, int? centerId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((serials != null) ? new ObjectParameter("Serials", serials) : new ObjectParameter("Serials", typeof(string)));
		ObjectParameter objectParameter2 = ((serialSpliter != null) ? new ObjectParameter("SerialSpliter", serialSpliter) : new ObjectParameter("SerialSpliter", typeof(string)));
		ObjectParameter objectParameter3 = ((infoVI != null) ? new ObjectParameter("InfoVI", infoVI) : new ObjectParameter("InfoVI", typeof(string)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateSerialInfoVI", objectParameter, objectParameter2, objectParameter3, objectParameter4, errorMessage);
	}

	public virtual ObjectResult<MobspSearchProducts_Result> MobspSearchProducts(int? fGId, int? sGId, string barcode, string val, int? prdId, int? showMode, int? languageID, int? defaultLanguageID, int? prdKind, int? prdInActive, int? companyId, int? projectId, string sGName, string prdManufacturerName, string prdSpecificationsJs)
	{
		ObjectParameter objectParameter = (fGId.HasValue ? new ObjectParameter("FGId", fGId) : new ObjectParameter("FGId", typeof(int)));
		ObjectParameter objectParameter2 = (sGId.HasValue ? new ObjectParameter("SGId", sGId) : new ObjectParameter("SGId", typeof(int)));
		ObjectParameter objectParameter3 = ((barcode != null) ? new ObjectParameter("Barcode", barcode) : new ObjectParameter("Barcode", typeof(string)));
		ObjectParameter objectParameter4 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter5 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter6 = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter10 = (prdInActive.HasValue ? new ObjectParameter("PrdInActive", prdInActive) : new ObjectParameter("PrdInActive", typeof(int)));
		ObjectParameter objectParameter11 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter12 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter13 = ((sGName != null) ? new ObjectParameter("SGName", sGName) : new ObjectParameter("SGName", typeof(string)));
		ObjectParameter objectParameter14 = ((prdManufacturerName != null) ? new ObjectParameter("PrdManufacturerName", prdManufacturerName) : new ObjectParameter("PrdManufacturerName", typeof(string)));
		ObjectParameter objectParameter15 = ((prdSpecificationsJs != null) ? new ObjectParameter("PrdSpecificationsJs", prdSpecificationsJs) : new ObjectParameter("PrdSpecificationsJs", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSearchProducts_Result>("MobspSearchProducts", new ObjectParameter[15]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15
		});
	}

	public virtual ObjectResult<MobspReturnDocPrdSerialByPaging_Result> MobspReturnDocPrdSerialByPaging(string serialTitle, int? fPId, int? wHID, int? prdId, int? currId, int? languageID, int? defaultLanguageID, int? orderId, int? centerId, int? pageSize, int? lastRowNumber, string orderIds)
	{
		ObjectParameter objectParameter = ((serialTitle != null) ? new ObjectParameter("SerialTitle", serialTitle) : new ObjectParameter("SerialTitle", typeof(string)));
		ObjectParameter objectParameter2 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter3 = (wHID.HasValue ? new ObjectParameter("WHID", wHID) : new ObjectParameter("WHID", typeof(int)));
		ObjectParameter objectParameter4 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter5 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter10 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter11 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(int)));
		ObjectParameter objectParameter12 = ((orderIds != null) ? new ObjectParameter("OrderIds", orderIds) : new ObjectParameter("OrderIds", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocPrdSerialByPaging_Result>("MobspReturnDocPrdSerialByPaging", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<SHPMobspReturnPrdQuantity_Result> SHPMobspReturnPrdQuantity(int? productId, double? prdSHPLinkAccStock, int? languageID, int? defaultLanguageID, int? centerId, int? foSettingId, int? whId, string tracing)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (prdSHPLinkAccStock.HasValue ? new ObjectParameter("PrdSHPLinkAccStock", prdSHPLinkAccStock) : new ObjectParameter("PrdSHPLinkAccStock", typeof(double)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter6 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter7 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter8 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspReturnPrdQuantity_Result>("SHPMobspReturnPrdQuantity", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<int?> MobspDeleteOrderItemSerialsByOrderItemId(int? orderItemId)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteOrderItemSerialsByOrderItemId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteWSOrderItemSerials(int? orderItemSerialID)
	{
		ObjectParameter objectParameter = (orderItemSerialID.HasValue ? new ObjectParameter("OrderItemSerialID", orderItemSerialID) : new ObjectParameter("OrderItemSerialID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteWSOrderItemSerials", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspInsertAutoOrderItemSerial(int? orderItemId, int? userId, int? month1, int? fPId, string registerDatePersian, int? ordIWHId, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (ordIWHId.HasValue ? new ObjectParameter("ordIWHId", ordIWHId) : new ObjectParameter("ordIWHId", typeof(int)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertAutoOrderItemSerial", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<MobspReturnOrderItemSerial_Result> MobspReturnOrderItemSerial(int? orderItemId, int? productId, int? currId, int? wHID, int? languageID, int? defaultLanguageID, int? centerId, string searchedValue, int? pageSize, int? pageNumber)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter3 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter4 = (wHID.HasValue ? new ObjectParameter("WHID", wHID) : new ObjectParameter("WHID", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = ((searchedValue != null) ? new ObjectParameter("searchedValue", searchedValue) : new ObjectParameter("searchedValue", typeof(string)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter10 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnOrderItemSerial_Result>("MobspReturnOrderItemSerial", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	[EdmFunction("CRMSpEntities", "MobfnCheckDuplicateOrderSerial")]
	public virtual IQueryable<MobfnCheckDuplicateOrderSerial_Result> MobfnCheckDuplicateOrderSerial(int? orderItemId, int? serialId, int? fPId, int? currId)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (serialId.HasValue ? new ObjectParameter("SerialId", serialId) : new ObjectParameter("SerialId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<MobfnCheckDuplicateOrderSerial_Result>("[CRMSpEntities].[MobfnCheckDuplicateOrderSerial](@OrderItemId, @SerialId, @FPId, @CurrId)", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspInsertUpdateOrdItemSerial(int? orderItemSerialID, DateTime? registerDate, int? userId, string registerDatePersian, int? month1, string appType, int? wHId, int? orderItemId, int? serialId, string description, string descriptionLang, int? fPId, int? firstRegisterUserId, DateTime? firstRegisterDate, string firstRegisterDatePersian, int? languageID, int? defaultLanguageID, int? centerId, ObjectParameter result)
	{
		ObjectParameter objectParameter = (orderItemSerialID.HasValue ? new ObjectParameter("OrderItemSerialID", orderItemSerialID) : new ObjectParameter("OrderItemSerialID", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter8 = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter9 = (serialId.HasValue ? new ObjectParameter("SerialId", serialId) : new ObjectParameter("SerialId", typeof(int)));
		ObjectParameter objectParameter10 = ((description != null) ? new ObjectParameter("Description", description) : new ObjectParameter("Description", typeof(string)));
		ObjectParameter objectParameter11 = ((descriptionLang != null) ? new ObjectParameter("DescriptionLang", descriptionLang) : new ObjectParameter("DescriptionLang", typeof(string)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter14 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter17 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertUpdateOrdItemSerial", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, result);
	}

	public virtual int HRMMobspSendVerificationRequestToAlternateUser(int? verificationWorkFlowId, int? objectId, string verificationReqText, string verificationReqTextLang, string msgSubject, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, ObjectParameter result, int? verificationReqUserId, int? centerId)
	{
		ObjectParameter objectParameter = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((verificationReqText != null) ? new ObjectParameter("VerificationReqText", verificationReqText) : new ObjectParameter("VerificationReqText", typeof(string)));
		ObjectParameter objectParameter4 = ((verificationReqTextLang != null) ? new ObjectParameter("VerificationReqTextLang", verificationReqTextLang) : new ObjectParameter("VerificationReqTextLang", typeof(string)));
		ObjectParameter objectParameter5 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter10 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (verificationReqUserId.HasValue ? new ObjectParameter("VerificationReqUserId", verificationReqUserId) : new ObjectParameter("VerificationReqUserId", typeof(int)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspSendVerificationRequestToAlternateUser", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, result, objectParameter14, objectParameter15);
	}

	public virtual int MobspUpdateLeaveReplaceUserIntMsgId(int? leaveId, int? intMsgId)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter2 = (intMsgId.HasValue ? new ObjectParameter("IntMsgId", intMsgId) : new ObjectParameter("IntMsgId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateLeaveReplaceUserIntMsgId", objectParameter, objectParameter2);
	}

	public virtual int MobspDocIsFixedExit(int? docId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDocIsFixedExit", objectParameter);
	}

	public virtual int MobspPreOrderIsFixedExit(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderIsFixedExit", objectParameter);
	}

	public virtual int MobspOrderIsFixedExit(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderIsFixedExit", objectParameter);
	}

	public virtual int MobspLetterIsFixed(int? letterId)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLetterIsFixed", objectParameter);
	}

	public virtual int MobspLetterIsFixedExit(int? letterId)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLetterIsFixedExit", objectParameter);
	}

	public virtual ObjectResult<FOMobspSelectCentersWithIds_Result> FOMobspSelectCentersWithIds(string ids, string seperator, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((ids != null) ? new ObjectParameter("Ids", ids) : new ObjectParameter("Ids", typeof(string)));
		ObjectParameter objectParameter2 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCentersWithIds_Result>("FOMobspSelectCentersWithIds", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspRpt_PrintPreOrder_Result> WSspRpt_PrintPreOrder(int? preOrderID, int? languageID, int? defaultLanguageID, int? userId, string rptDate, string rptDay, decimal? cmpLinkAccAllPayRemain)
	{
		ObjectParameter objectParameter = (preOrderID.HasValue ? new ObjectParameter("PreOrderID", preOrderID) : new ObjectParameter("PreOrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter6 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter7 = (cmpLinkAccAllPayRemain.HasValue ? new ObjectParameter("CmpLinkAccAllPayRemain", cmpLinkAccAllPayRemain) : new ObjectParameter("CmpLinkAccAllPayRemain", typeof(decimal)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintPreOrder_Result>("WSspRpt_PrintPreOrder", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspRpt_PrintOrderPaymentById_Result> WSspRpt_PrintOrderPaymentById(int? orderPaymentId, int? userId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter4 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintOrderPaymentById_Result>("WSspRpt_PrintOrderPaymentById", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<WSspRpt_PrintPreOrderPaymentById_Result> WSspRpt_PrintPreOrderPaymentById(int? preOrderPaymentId, int? userId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter4 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintPreOrderPaymentById_Result>("WSspRpt_PrintPreOrderPaymentById", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectShiftWorkingTimeByDate_Result> MobspSelectShiftWorkingTimeByDate(int? userId, DateTime? date, int? userShiftWorkingId, int? timeAttendanceMode, int? languageId, int? defaultLanguageId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userShiftWorkingId.HasValue ? new ObjectParameter("UserShiftWorkingId", userShiftWorkingId) : new ObjectParameter("UserShiftWorkingId", typeof(int)));
		ObjectParameter objectParameter4 = (timeAttendanceMode.HasValue ? new ObjectParameter("TimeAttendanceMode", timeAttendanceMode) : new ObjectParameter("TimeAttendanceMode", typeof(int)));
		ObjectParameter objectParameter5 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectShiftWorkingTimeByDate_Result>("MobspSelectShiftWorkingTimeByDate", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectTimeAttendanceNoExit_Result> MobspSelectTimeAttendanceNoExit(int? userId, DateTime? date, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTimeAttendanceNoExit_Result>("MobspSelectTimeAttendanceNoExit", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspReturnProductTracingFromShop_Result> MobspReturnProductTracingFromShop(int? wHId, int? prdId, int? currPreOrderId, int? currPreOrderItemId, int? currOrderId, int? currOrderItemId, int? centerId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter2 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter3 = (currPreOrderId.HasValue ? new ObjectParameter("CurrPreOrderId", currPreOrderId) : new ObjectParameter("CurrPreOrderId", typeof(int)));
		ObjectParameter objectParameter4 = (currPreOrderItemId.HasValue ? new ObjectParameter("CurrPreOrderItemId", currPreOrderItemId) : new ObjectParameter("CurrPreOrderItemId", typeof(int)));
		ObjectParameter objectParameter5 = (currOrderId.HasValue ? new ObjectParameter("CurrOrderId", currOrderId) : new ObjectParameter("CurrOrderId", typeof(int)));
		ObjectParameter objectParameter6 = (currOrderItemId.HasValue ? new ObjectParameter("CurrOrderItemId", currOrderItemId) : new ObjectParameter("CurrOrderItemId", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnProductTracingFromShop_Result>("MobspReturnProductTracingFromShop", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspCheckDuplicatePreOrderItemTracingFromShop_Result> MobspCheckDuplicatePreOrderItemTracingFromShop(int? currPreOrderItemId, int? prdId, int? wHId, string tracing, double? prdSHPLinkAccStock, int? centerId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (currPreOrderItemId.HasValue ? new ObjectParameter("CurrPreOrderItemId", currPreOrderItemId) : new ObjectParameter("CurrPreOrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter3 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter4 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter5 = (prdSHPLinkAccStock.HasValue ? new ObjectParameter("PrdSHPLinkAccStock", prdSHPLinkAccStock) : new ObjectParameter("PrdSHPLinkAccStock", typeof(double)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicatePreOrderItemTracingFromShop_Result>("MobspCheckDuplicatePreOrderItemTracingFromShop", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspSelectLinkAccSettingDB_Result> MobspSelectLinkAccSettingDB(int? linkAccSystemId, int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLinkAccSettingDB_Result>("MobspSelectLinkAccSettingDB", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspMainSearchSmart_Result> MobspMainSearchSmart(string val, int? userID, int? searchType, int? languageID, int? defaultLanguageID, string searchConditionMode, int? centerId, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (searchType.HasValue ? new ObjectParameter("SearchType", searchType) : new ObjectParameter("SearchType", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = ((searchConditionMode != null) ? new ObjectParameter("SearchConditionMode", searchConditionMode) : new ObjectParameter("SearchConditionMode", typeof(string)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspMainSearchSmart_Result>("MobspMainSearchSmart", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<int?> MobspReturnPreOrderItemsWareHouseCnt(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnPreOrderItemsWareHouseCnt", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectPreOrderItemsWithDocItemQuantity_Result> MobspSelectPreOrderItemsWithDocItemQuantity(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderItemsWithDocItemQuantity_Result>("MobspSelectPreOrderItemsWithDocItemQuantity", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspCheckPreOrderHaveDraft(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspCheckPreOrderHaveDraft", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnDocFromPreOrder_Result> MobspReturnDocFromPreOrder(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocFromPreOrder_Result>("MobspReturnDocFromPreOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspReturnOrderItemsWareHouseCnt(int? orderID)
	{
		ObjectParameter objectParameter = (orderID.HasValue ? new ObjectParameter("OrderID", orderID) : new ObjectParameter("OrderID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnOrderItemsWareHouseCnt", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectOrderItemsWithDocItemQuantity_Result> MobspSelectOrderItemsWithDocItemQuantity(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderItemsWithDocItemQuantity_Result>("MobspSelectOrderItemsWithDocItemQuantity", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspCheckOrderHaveDraft(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspCheckOrderHaveDraft", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspIssueDraftFromOrder(int? orderID, string draftDate, int? userId, int? month1, int? fPId, int? wHId, string registerDatePersian, string appType, ObjectParameter insertedDraftID, ObjectParameter insertedDraftNumber, int? languageID, string ordItemList, int? centerId)
	{
		ObjectParameter objectParameter = (orderID.HasValue ? new ObjectParameter("OrderID", orderID) : new ObjectParameter("OrderID", typeof(int)));
		ObjectParameter objectParameter2 = ((draftDate != null) ? new ObjectParameter("DraftDate", draftDate) : new ObjectParameter("DraftDate", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((ordItemList != null) ? new ObjectParameter("OrdItemList", ordItemList) : new ObjectParameter("OrdItemList", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspIssueDraftFromOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, insertedDraftID, insertedDraftNumber, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<int?> MobspIssueDraftFromPreOrder(int? preOrderId, string docDate, DateTime? docDateTime, int? docOprId, string pordItemList, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter insertedDocId, ObjectParameter insertedDocNumber, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((docDate != null) ? new ObjectParameter("DocDate", docDate) : new ObjectParameter("DocDate", typeof(string)));
		ObjectParameter objectParameter3 = (docDateTime.HasValue ? new ObjectParameter("DocDateTime", docDateTime) : new ObjectParameter("DocDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter5 = ((pordItemList != null) ? new ObjectParameter("PordItemList", pordItemList) : new ObjectParameter("PordItemList", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspIssueDraftFromPreOrder", new ObjectParameter[15]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, insertedDocId, insertedDocNumber, objectParameter13
		});
	}

	public virtual ObjectResult<MobspReturnDocItemsForSaleOrderItems_Result> MobspReturnDocItemsForSaleOrderItems(int? orderID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderID.HasValue ? new ObjectParameter("OrderID", orderID) : new ObjectParameter("OrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocItemsForSaleOrderItems_Result>("MobspReturnDocItemsForSaleOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspCheckDocHaveOrder(int? docId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspCheckDocHaveOrder", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspIssueOrderFromDoc(int? docId, string orderDate, DateTime? orderDateTime, int? orderOprId, int? orderReferUserId, int? orderPrintFormatID, int? orderDefaultSettingId, int? orderSettlementTypeId, string orderNote, string orderNoteLang, int? orderProjectId, string docItemList, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter insertedOrderID, ObjectParameter insertedOrderNumber, int? centerID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = ((orderDate != null) ? new ObjectParameter("OrderDate", orderDate) : new ObjectParameter("OrderDate", typeof(string)));
		ObjectParameter objectParameter3 = (orderDateTime.HasValue ? new ObjectParameter("OrderDateTime", orderDateTime) : new ObjectParameter("OrderDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter5 = (orderReferUserId.HasValue ? new ObjectParameter("OrderReferUserId", orderReferUserId) : new ObjectParameter("OrderReferUserId", typeof(int)));
		ObjectParameter objectParameter6 = (orderPrintFormatID.HasValue ? new ObjectParameter("OrderPrintFormatID", orderPrintFormatID) : new ObjectParameter("OrderPrintFormatID", typeof(int)));
		ObjectParameter objectParameter7 = (orderDefaultSettingId.HasValue ? new ObjectParameter("OrderDefaultSettingId", orderDefaultSettingId) : new ObjectParameter("OrderDefaultSettingId", typeof(int)));
		ObjectParameter objectParameter8 = (orderSettlementTypeId.HasValue ? new ObjectParameter("OrderSettlementTypeId", orderSettlementTypeId) : new ObjectParameter("OrderSettlementTypeId", typeof(int)));
		ObjectParameter objectParameter9 = ((orderNote != null) ? new ObjectParameter("OrderNote", orderNote) : new ObjectParameter("OrderNote", typeof(string)));
		ObjectParameter objectParameter10 = ((orderNoteLang != null) ? new ObjectParameter("OrderNoteLang", orderNoteLang) : new ObjectParameter("OrderNoteLang", typeof(string)));
		ObjectParameter objectParameter11 = (orderProjectId.HasValue ? new ObjectParameter("OrderProjectId", orderProjectId) : new ObjectParameter("OrderProjectId", typeof(int)));
		ObjectParameter objectParameter12 = ((docItemList != null) ? new ObjectParameter("DocItemList", docItemList) : new ObjectParameter("DocItemList", typeof(string)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter15 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter16 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter17 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter18 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter19 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter20 = (centerID.HasValue ? new ObjectParameter("CenterID", centerID) : new ObjectParameter("CenterID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspIssueOrderFromDoc", new ObjectParameter[22]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, insertedOrderID,
			insertedOrderNumber, objectParameter20
		});
	}

	public virtual ObjectResult<int?> MobspAddUserMoneyBagFromPreOrderDiscounts(int? preOrderId, DateTime? uMnBgDate, string uMnBgDatePersian, string uMnBgDesc, string uMnBgDesc_Lang, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, string uMnBgDescForUsage, string uMnBgDescForUsage_Lang, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (uMnBgDate.HasValue ? new ObjectParameter("UMnBgDate", uMnBgDate) : new ObjectParameter("UMnBgDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((uMnBgDatePersian != null) ? new ObjectParameter("UMnBgDatePersian", uMnBgDatePersian) : new ObjectParameter("UMnBgDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = ((uMnBgDesc != null) ? new ObjectParameter("UMnBgDesc", uMnBgDesc) : new ObjectParameter("UMnBgDesc", typeof(string)));
		ObjectParameter objectParameter5 = ((uMnBgDesc_Lang != null) ? new ObjectParameter("UMnBgDesc_Lang", uMnBgDesc_Lang) : new ObjectParameter("UMnBgDesc_Lang", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = ((uMnBgDescForUsage != null) ? new ObjectParameter("UMnBgDescForUsage", uMnBgDescForUsage) : new ObjectParameter("UMnBgDescForUsage", typeof(string)));
		ObjectParameter objectParameter14 = ((uMnBgDescForUsage_Lang != null) ? new ObjectParameter("UMnBgDescForUsage_Lang", uMnBgDescForUsage_Lang) : new ObjectParameter("UMnBgDescForUsage_Lang", typeof(string)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspAddUserMoneyBagFromPreOrderDiscounts", new ObjectParameter[15]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15
		});
	}

	public virtual ObjectResult<int?> MobspDeleteDocItemLinkOrderItem(int? mode, int? orderItemId, int? docItemId, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter3 = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteDocItemLinkOrderItem", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<int?> MobspDeleteDocLinkOrder(int? mode, int? orderId, int? docId, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter3 = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteDocLinkOrder", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<int?> MobspInsertUpdateSysTempData(int? tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII, string tempDataValue, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter insertTempDataId)
	{
		ObjectParameter objectParameter = (tempDataId.HasValue ? new ObjectParameter("TempDataId", tempDataId) : new ObjectParameter("TempDataId", typeof(int)));
		ObjectParameter objectParameter2 = (tempDataUserId.HasValue ? new ObjectParameter("TempDataUserId", tempDataUserId) : new ObjectParameter("TempDataUserId", typeof(int)));
		ObjectParameter objectParameter3 = (tempDataSysPartIdI.HasValue ? new ObjectParameter("TempDataSysPartIdI", tempDataSysPartIdI) : new ObjectParameter("TempDataSysPartIdI", typeof(int)));
		ObjectParameter objectParameter4 = (tempDataSysPartObjIdI.HasValue ? new ObjectParameter("TempDataSysPartObjIdI", tempDataSysPartObjIdI) : new ObjectParameter("TempDataSysPartObjIdI", typeof(int)));
		ObjectParameter objectParameter5 = (tempDataSysPartIdII.HasValue ? new ObjectParameter("TempDataSysPartIdII", tempDataSysPartIdII) : new ObjectParameter("TempDataSysPartIdII", typeof(int)));
		ObjectParameter objectParameter6 = (tempDataSysPartObjIdII.HasValue ? new ObjectParameter("TempDataSysPartObjIdII", tempDataSysPartObjIdII) : new ObjectParameter("TempDataSysPartObjIdII", typeof(int)));
		ObjectParameter objectParameter7 = ((tempDataValue != null) ? new ObjectParameter("TempDataValue", tempDataValue) : new ObjectParameter("TempDataValue", typeof(string)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter11 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertUpdateSysTempData", new ObjectParameter[15]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, insertTempDataId
		});
	}

	public virtual ObjectResult<MobspSelectSysTempDataByIds_Result> MobspSelectSysTempDataByIds(string tempDataIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((tempDataIds != null) ? new ObjectParameter("TempDataIds", tempDataIds) : new ObjectParameter("TempDataIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSysTempDataByIds_Result>("MobspSelectSysTempDataByIds", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspDeleteSysTempData(int? tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII)
	{
		ObjectParameter objectParameter = (tempDataId.HasValue ? new ObjectParameter("TempDataId", tempDataId) : new ObjectParameter("TempDataId", typeof(int)));
		ObjectParameter objectParameter2 = (tempDataUserId.HasValue ? new ObjectParameter("TempDataUserId", tempDataUserId) : new ObjectParameter("TempDataUserId", typeof(int)));
		ObjectParameter objectParameter3 = (tempDataSysPartIdI.HasValue ? new ObjectParameter("TempDataSysPartIdI", tempDataSysPartIdI) : new ObjectParameter("TempDataSysPartIdI", typeof(int)));
		ObjectParameter objectParameter4 = (tempDataSysPartObjIdI.HasValue ? new ObjectParameter("TempDataSysPartObjIdI", tempDataSysPartObjIdI) : new ObjectParameter("TempDataSysPartObjIdI", typeof(int)));
		ObjectParameter objectParameter5 = (tempDataSysPartIdII.HasValue ? new ObjectParameter("TempDataSysPartIdII", tempDataSysPartIdII) : new ObjectParameter("TempDataSysPartIdII", typeof(int)));
		ObjectParameter objectParameter6 = (tempDataSysPartObjIdII.HasValue ? new ObjectParameter("TempDataSysPartObjIdII", tempDataSysPartObjIdII) : new ObjectParameter("TempDataSysPartObjIdII", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDeleteSysTempData", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual ObjectResult<MobspSelectSysTempData_Result> MobspSelectSysTempData(int? tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (tempDataId.HasValue ? new ObjectParameter("TempDataId", tempDataId) : new ObjectParameter("TempDataId", typeof(int)));
		ObjectParameter objectParameter2 = (tempDataUserId.HasValue ? new ObjectParameter("TempDataUserId", tempDataUserId) : new ObjectParameter("TempDataUserId", typeof(int)));
		ObjectParameter objectParameter3 = (tempDataSysPartIdI.HasValue ? new ObjectParameter("TempDataSysPartIdI", tempDataSysPartIdI) : new ObjectParameter("TempDataSysPartIdI", typeof(int)));
		ObjectParameter objectParameter4 = (tempDataSysPartObjIdI.HasValue ? new ObjectParameter("TempDataSysPartObjIdI", tempDataSysPartObjIdI) : new ObjectParameter("TempDataSysPartObjIdI", typeof(int)));
		ObjectParameter objectParameter5 = (tempDataSysPartIdII.HasValue ? new ObjectParameter("TempDataSysPartIdII", tempDataSysPartIdII) : new ObjectParameter("TempDataSysPartIdII", typeof(int)));
		ObjectParameter objectParameter6 = (tempDataSysPartObjIdII.HasValue ? new ObjectParameter("TempDataSysPartObjIdII", tempDataSysPartObjIdII) : new ObjectParameter("TempDataSysPartObjIdII", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSysTempData_Result>("MobspSelectSysTempData", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspSelectFilesDirectoryTemplateById_Result> MobspSelectFilesDirectoryTemplateById(int? fileDirectoryTemplateId)
	{
		ObjectParameter objectParameter = (fileDirectoryTemplateId.HasValue ? new ObjectParameter("FileDirectoryTemplateId", fileDirectoryTemplateId) : new ObjectParameter("FileDirectoryTemplateId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectFilesDirectoryTemplateById_Result>("MobspSelectFilesDirectoryTemplateById", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspDySubFormCheck(int? masterValueId, int? masterValueDetailId, int? workflowStepId, int? checkerUserId, string checkedDatePersian)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueDetailId.HasValue ? new ObjectParameter("MasterValueDetailId", masterValueDetailId) : new ObjectParameter("MasterValueDetailId", typeof(int)));
		ObjectParameter objectParameter3 = (workflowStepId.HasValue ? new ObjectParameter("WorkflowStepId", workflowStepId) : new ObjectParameter("WorkflowStepId", typeof(int)));
		ObjectParameter objectParameter4 = (checkerUserId.HasValue ? new ObjectParameter("CheckerUserId", checkerUserId) : new ObjectParameter("CheckerUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((checkedDatePersian != null) ? new ObjectParameter("CheckedDatePersian", checkedDatePersian) : new ObjectParameter("CheckedDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDySubFormCheck", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual int MobspDySubFormCheckExit(int? masterValueDetailId, string checkedDatePersian)
	{
		ObjectParameter objectParameter = (masterValueDetailId.HasValue ? new ObjectParameter("MasterValueDetailId", masterValueDetailId) : new ObjectParameter("MasterValueDetailId", typeof(int)));
		ObjectParameter objectParameter2 = ((checkedDatePersian != null) ? new ObjectParameter("CheckedDatePersian", checkedDatePersian) : new ObjectParameter("CheckedDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDySubFormCheckExit", objectParameter, objectParameter2);
	}

	public virtual int MobScorespInsertAndCalcDyFormScores(int? dyFormId, int? masterValueId, int? replyCompanyId, int? replyUserId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, bool? ruleCalcAutoScoreInVerify, bool? ruleCalcAutoScoreFODyFormInsertData, int? centerId, bool? returnResult)
	{
		ObjectParameter objectParameter = (dyFormId.HasValue ? new ObjectParameter("DyFormId", dyFormId) : new ObjectParameter("DyFormId", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter3 = (replyCompanyId.HasValue ? new ObjectParameter("ReplyCompanyId", replyCompanyId) : new ObjectParameter("ReplyCompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (replyUserId.HasValue ? new ObjectParameter("ReplyUserId", replyUserId) : new ObjectParameter("ReplyUserId", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (ruleCalcAutoScoreInVerify.HasValue ? new ObjectParameter("RuleCalcAutoScoreInVerify", ruleCalcAutoScoreInVerify) : new ObjectParameter("RuleCalcAutoScoreInVerify", typeof(bool)));
		ObjectParameter objectParameter14 = (ruleCalcAutoScoreFODyFormInsertData.HasValue ? new ObjectParameter("RuleCalcAutoScoreFODyFormInsertData", ruleCalcAutoScoreFODyFormInsertData) : new ObjectParameter("RuleCalcAutoScoreFODyFormInsertData", typeof(bool)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter16 = (returnResult.HasValue ? new ObjectParameter("ReturnResult", returnResult) : new ObjectParameter("ReturnResult", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobScorespInsertAndCalcDyFormScores", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual ObjectResult<MobspChartDailyOrdersExtra_Result> MobspChartDailyOrdersExtra(short? horizontalField, short? verticalMode, string selectedValues, DateTime? fDate, DateTime? tDate, int? userId, int? currUserId, int? centerId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (horizontalField.HasValue ? new ObjectParameter("HorizontalField", horizontalField) : new ObjectParameter("HorizontalField", typeof(short)));
		ObjectParameter objectParameter2 = (verticalMode.HasValue ? new ObjectParameter("VerticalMode", verticalMode) : new ObjectParameter("VerticalMode", typeof(short)));
		ObjectParameter objectParameter3 = ((selectedValues != null) ? new ObjectParameter("SelectedValues", selectedValues) : new ObjectParameter("SelectedValues", typeof(string)));
		ObjectParameter objectParameter4 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (currUserId.HasValue ? new ObjectParameter("CurrUserId", currUserId) : new ObjectParameter("CurrUserId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspChartDailyOrdersExtra_Result>("MobspChartDailyOrdersExtra", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspProductsTreeByLevel_Result> MobspProductsTreeByLevel(int? showMode, int? languageID, int? defaultLanguageID, int? prdKind, int? prdInActive, int? companyId, int? projectId, int? level, string textSearch, int? searchMode, int? parentId, int? productId, int? pageSize, int? pageNumber)
	{
		ObjectParameter objectParameter = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter5 = (prdInActive.HasValue ? new ObjectParameter("PrdInActive", prdInActive) : new ObjectParameter("PrdInActive", typeof(int)));
		ObjectParameter objectParameter6 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter7 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter8 = (level.HasValue ? new ObjectParameter("Level", level) : new ObjectParameter("Level", typeof(int)));
		ObjectParameter objectParameter9 = ((textSearch != null) ? new ObjectParameter("TextSearch", textSearch) : new ObjectParameter("TextSearch", typeof(string)));
		ObjectParameter objectParameter10 = (searchMode.HasValue ? new ObjectParameter("SearchMode", searchMode) : new ObjectParameter("SearchMode", typeof(int)));
		ObjectParameter objectParameter11 = (parentId.HasValue ? new ObjectParameter("ParentId", parentId) : new ObjectParameter("ParentId", typeof(int)));
		ObjectParameter objectParameter12 = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter13 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter14 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspProductsTreeByLevel_Result>("MobspProductsTreeByLevel", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual ObjectResult<MobspSelectPrintFormatByFileName_Result> MobspSelectPrintFormatByFileName(string fileNameWeb, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((fileNameWeb != null) ? new ObjectParameter("FileNameWeb", fileNameWeb) : new ObjectParameter("FileNameWeb", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPrintFormatByFileName_Result>("MobspSelectPrintFormatByFileName", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MObspSelectPrintFormatById_Result> MObspSelectPrintFormatById(int? printFormatId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (printFormatId.HasValue ? new ObjectParameter("PrintFormatId", printFormatId) : new ObjectParameter("PrintFormatId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MObspSelectPrintFormatById_Result>("MObspSelectPrintFormatById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectCrmsysCISetting_Result> MobspSelectCrmsysCISetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCrmsysCISetting_Result>("MobspSelectCrmsysCISetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectLetterDefaultSettingsByUserAndIsPublic_Result> MobspSelectLetterDefaultSettingsByUserAndIsPublic(int? referUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLetterDefaultSettingsByUserAndIsPublic_Result>("MobspSelectLetterDefaultSettingsByUserAndIsPublic", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobScorespInsertAndCalcOrderCancelledScores(int? orderId, DateTime? currDate, bool? updateCompanyGroups, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, int? centerId, ObjectParameter result)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (updateCompanyGroups.HasValue ? new ObjectParameter("UpdateCompanyGroups", updateCompanyGroups) : new ObjectParameter("UpdateCompanyGroups", typeof(bool)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobScorespInsertAndCalcOrderCancelledScores", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, result);
	}

	public virtual int MobspTmpUserItemCopy(string copyType, int? masterId, int? userId, string appType, int? languageID, string firstRegisterDatePersian)
	{
		ObjectParameter objectParameter = ((copyType != null) ? new ObjectParameter("CopyType", copyType) : new ObjectParameter("CopyType", typeof(string)));
		ObjectParameter objectParameter2 = (masterId.HasValue ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspTmpUserItemCopy", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual ObjectResult<MobspTmpUserItemPast_Result> MobspTmpUserItemPast(string copyType, int? masterId, int? userId, int? fPId, int? month1, string registerDatePersian, string appType, int? languageID, int? centerId, int? masterCurrencyunitId)
	{
		ObjectParameter objectParameter = ((copyType != null) ? new ObjectParameter("CopyType", copyType) : new ObjectParameter("CopyType", typeof(string)));
		ObjectParameter objectParameter2 = (masterId.HasValue ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter10 = (masterCurrencyunitId.HasValue ? new ObjectParameter("MasterCurrencyunitId", masterCurrencyunitId) : new ObjectParameter("MasterCurrencyunitId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspTmpUserItemPast_Result>("MobspTmpUserItemPast", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobSpSelectProductPriceByIds_Result> MobSpSelectProductPriceByIds(string productIds, string seperator, int? companyId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((productIds != null) ? new ObjectParameter("ProductIds", productIds) : new ObjectParameter("ProductIds", typeof(string)));
		ObjectParameter objectParameter2 = ((seperator != null) ? new ObjectParameter("Seperator", seperator) : new ObjectParameter("Seperator", typeof(string)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobSpSelectProductPriceByIds_Result>("MobSpSelectProductPriceByIds", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<SHPMobspSelectProductWithPriceByPrdId_Result> SHPMobspSelectProductWithPriceByPrdId(int? prdId, int? prdPriceGroupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SHPMobspSelectProductWithPriceByPrdId_Result>("SHPMobspSelectProductWithPriceByPrdId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<HRMMobspSelectFilesDirectory_Result> HRMMobspSelectFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, int? languageID, int? defaultLanguageID, bool? isShowAllCmpFile, string typeOprObjectIdI, string typeOprObjectIdII, int? centerId)
	{
		ObjectParameter objectParameter = ((masterId != null) ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(string)));
		ObjectParameter objectParameter2 = ((detailId != null) ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(string)));
		ObjectParameter objectParameter3 = ((subDetailId != null) ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(string)));
		ObjectParameter objectParameter4 = ((fileDirectoryTypeOprId != null) ? new ObjectParameter("FileDirectoryTypeOprId", fileDirectoryTypeOprId) : new ObjectParameter("FileDirectoryTypeOprId", typeof(string)));
		ObjectParameter objectParameter5 = ((typeOprObjectId != null) ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (isShowAllCmpFile.HasValue ? new ObjectParameter("IsShowAllCmpFile", isShowAllCmpFile) : new ObjectParameter("IsShowAllCmpFile", typeof(bool)));
		ObjectParameter objectParameter9 = ((typeOprObjectIdI != null) ? new ObjectParameter("TypeOprObjectIdI", typeOprObjectIdI) : new ObjectParameter("TypeOprObjectIdI", typeof(string)));
		ObjectParameter objectParameter10 = ((typeOprObjectIdII != null) ? new ObjectParameter("TypeOprObjectIdII", typeOprObjectIdII) : new ObjectParameter("TypeOprObjectIdII", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectFilesDirectory_Result>("HRMMobspSelectFilesDirectory", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11
		});
	}

	public virtual ObjectResult<ShpMobspLoadCompanyLoginInfo_Result> ShpMobspLoadCompanyLoginInfo(int? companyId, int? languageID, int? defaultLanguageID, string cmpUserName, string userName, string password, int? loginType, int? companyPersonId, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = ((cmpUserName != null) ? new ObjectParameter("CmpUserName", cmpUserName) : new ObjectParameter("CmpUserName", typeof(string)));
		ObjectParameter objectParameter5 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter6 = ((password != null) ? new ObjectParameter("Password", password) : new ObjectParameter("Password", typeof(string)));
		ObjectParameter objectParameter7 = (loginType.HasValue ? new ObjectParameter("LoginType", loginType) : new ObjectParameter("LoginType", typeof(int)));
		ObjectParameter objectParameter8 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter10 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ShpMobspLoadCompanyLoginInfo_Result>("ShpMobspLoadCompanyLoginInfo", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<FOMobspLoadCompanyLoginInfo_Result> FOMobspLoadCompanyLoginInfo(int? companyId, int? languageID, int? defaultLanguageID, string cmpUserName, string userName, string password, int? loginType, int? companyPersonId, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = ((cmpUserName != null) ? new ObjectParameter("CmpUserName", cmpUserName) : new ObjectParameter("CmpUserName", typeof(string)));
		ObjectParameter objectParameter5 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter6 = ((password != null) ? new ObjectParameter("Password", password) : new ObjectParameter("Password", typeof(string)));
		ObjectParameter objectParameter7 = (loginType.HasValue ? new ObjectParameter("LoginType", loginType) : new ObjectParameter("LoginType", typeof(int)));
		ObjectParameter objectParameter8 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter10 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspLoadCompanyLoginInfo_Result>("FOMobspLoadCompanyLoginInfo", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<int?> FOMobspReturnCmpFOIsActiveCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspReturnCmpFOIsActiveCnt", Array.Empty<ObjectParameter>());
	}

	public virtual int SHPMobspUpdateCompanyFOInfoAndCIds(int? cId, int? companyId, string fOAct, string shpAct)
	{
		ObjectParameter objectParameter = (cId.HasValue ? new ObjectParameter("CId", cId) : new ObjectParameter("CId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = ((fOAct != null) ? new ObjectParameter("FOAct", fOAct) : new ObjectParameter("FOAct", typeof(string)));
		ObjectParameter objectParameter4 = ((shpAct != null) ? new ObjectParameter("ShpAct", shpAct) : new ObjectParameter("ShpAct", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SHPMobspUpdateCompanyFOInfoAndCIds", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int SHPMobspUpdateCompanyPersonFOInfoAndCIds(int? cId, int? companyPersonId, string fOAct, string shpAct)
	{
		ObjectParameter objectParameter = (cId.HasValue ? new ObjectParameter("CId", cId) : new ObjectParameter("CId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((fOAct != null) ? new ObjectParameter("FOAct", fOAct) : new ObjectParameter("FOAct", typeof(string)));
		ObjectParameter objectParameter4 = ((shpAct != null) ? new ObjectParameter("ShpAct", shpAct) : new ObjectParameter("ShpAct", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SHPMobspUpdateCompanyPersonFOInfoAndCIds", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<decimal?> MobspReturnPreOrderDiscountSumDisAmount(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<decimal?>("MobspReturnPreOrderDiscountSumDisAmount", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnRollDiscountLimitation_Result> MobspReturnRollDiscountLimitation(int? rollId)
	{
		ObjectParameter objectParameter = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnRollDiscountLimitation_Result>("MobspReturnRollDiscountLimitation", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectPreOrderItemsByNotInSum_Result> MobspSelectPreOrderItemsByNotInSum(int? preOrderId, bool? pordINotInSum, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (pordINotInSum.HasValue ? new ObjectParameter("PordINotInSum", pordINotInSum) : new ObjectParameter("PordINotInSum", typeof(bool)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderItemsByNotInSum_Result>("MobspSelectPreOrderItemsByNotInSum", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectOrderItemsByNotInSum_Result> MobspSelectOrderItemsByNotInSum(int? orderId, bool? ordINotInSum, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (ordINotInSum.HasValue ? new ObjectParameter("OrdINotInSum", ordINotInSum) : new ObjectParameter("OrdINotInSum", typeof(bool)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderItemsByNotInSum_Result>("MobspSelectOrderItemsByNotInSum", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspReturnSoldOrdPrdCount_Result> MobspReturnSoldOrdPrdCount(int? prdId, int? currOrdItemId, double? fCR, double? fCRI, int? whId, string tracing, int? centerId)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (currOrdItemId.HasValue ? new ObjectParameter("CurrOrdItemId", currOrdItemId) : new ObjectParameter("CurrOrdItemId", typeof(int)));
		ObjectParameter objectParameter3 = (fCR.HasValue ? new ObjectParameter("FCR", fCR) : new ObjectParameter("FCR", typeof(double)));
		ObjectParameter objectParameter4 = (fCRI.HasValue ? new ObjectParameter("FCRI", fCRI) : new ObjectParameter("FCRI", typeof(double)));
		ObjectParameter objectParameter5 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter6 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnSoldOrdPrdCount_Result>("MobspReturnSoldOrdPrdCount", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspControlPreOrderItemsSoldStock_Result> MobspControlPreOrderItemsSoldStock(int? preOrderId, string pordItemJson, int? centerId, int? prdKind, int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((pordItemJson != null) ? new ObjectParameter("PordItemJson", pordItemJson) : new ObjectParameter("PordItemJson", typeof(string)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspControlPreOrderItemsSoldStock_Result>("MobspControlPreOrderItemsSoldStock", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspControlOrderItemsSoldStock_Result> MobspControlOrderItemsSoldStock(int? orderId, string ordItemJson, string ordItemListStr, int? centerId, int? prdKind, int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((ordItemJson != null) ? new ObjectParameter("OrdItemJson", ordItemJson) : new ObjectParameter("OrdItemJson", typeof(string)));
		ObjectParameter objectParameter3 = ((ordItemListStr != null) ? new ObjectParameter("OrdItemListStr", ordItemListStr) : new ObjectParameter("OrdItemListStr", typeof(string)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter5 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspControlOrderItemsSoldStock_Result>("MobspControlOrderItemsSoldStock", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual int MobspCheckActionForUser(string formName, string actionName, int? userId, ObjectParameter hasAction, int? centerId)
	{
		ObjectParameter objectParameter = ((formName != null) ? new ObjectParameter("FormName", formName) : new ObjectParameter("FormName", typeof(string)));
		ObjectParameter objectParameter2 = ((actionName != null) ? new ObjectParameter("ActionName", actionName) : new ObjectParameter("ActionName", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCheckActionForUser", objectParameter, objectParameter2, objectParameter3, hasAction, objectParameter4);
	}

	public virtual int MobspPreOrderPaymentDeActive(int? preOrderPaymentId, int? pordpayDeActiveUserId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (pordpayDeActiveUserId.HasValue ? new ObjectParameter("pordpayDeActiveUserId", pordpayDeActiveUserId) : new ObjectParameter("pordpayDeActiveUserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderPaymentDeActive", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int MobspPreOrderPaymentDeActiveExit(int? preOrderPaymentId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderPaymentDeActiveExit", objectParameter);
	}

	public virtual int MobspPreOrderPaymentVerify(int? preOrderPaymentId, int? pordpayVerifierId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (pordpayVerifierId.HasValue ? new ObjectParameter("pordpayVerifierId", pordpayVerifierId) : new ObjectParameter("pordpayVerifierId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderPaymentVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int MobspPreOrderPaymentVerifyExit(int? preOrderPaymentId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderPaymentVerifyExit", objectParameter);
	}

	public virtual ObjectResult<MobspSelectLinkAccByViewSetting_Result> MobspSelectLinkAccByViewSetting(int? linkAccSystemId, int? linkAccByViewSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccByViewSettingId.HasValue ? new ObjectParameter("LinkAccByViewSettingId", linkAccByViewSettingId) : new ObjectParameter("LinkAccByViewSettingId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLinkAccByViewSetting_Result>("MobspSelectLinkAccByViewSetting", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspLkSepSelectFiscalYear_Result> MobspLkSepSelectFiscalYear(int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLkSepSelectFiscalYear_Result>("MobspLkSepSelectFiscalYear", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<string> MobspLkShomaranReturnProductSefareshCode(int? prdId, int? whId, string linkAccWhCode)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter3 = ((linkAccWhCode != null) ? new ObjectParameter("LinkAccWhCode", linkAccWhCode) : new ObjectParameter("LinkAccWhCode", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MobspLkShomaranReturnProductSefareshCode", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<string> MobspLkShomaranReturnProductTracing(int? prdId, int? whId, string linkAccWhCode)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter3 = ((linkAccWhCode != null) ? new ObjectParameter("LinkAccWhCode", linkAccWhCode) : new ObjectParameter("LinkAccWhCode", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MobspLkShomaranReturnProductTracing", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspOrderPaymentDeActiveExit(int? orderPaymentId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderPaymentDeActiveExit", objectParameter);
	}

	public virtual int MobspOrderPaymentVerify(int? orderPaymentId, int? ordpayVerifierId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (ordpayVerifierId.HasValue ? new ObjectParameter("ordpayVerifierId", ordpayVerifierId) : new ObjectParameter("ordpayVerifierId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderPaymentVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int MobspOrderPaymentVerifyExit(int? orderPaymentId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderPaymentVerifyExit", objectParameter);
	}

	public virtual int MobspOrderPaymentDeActive(int? orderPaymentId, int? ordpayDeActiveUserId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (ordpayDeActiveUserId.HasValue ? new ObjectParameter("ordpayDeActiveUserId", ordpayDeActiveUserId) : new ObjectParameter("ordpayDeActiveUserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderPaymentDeActive", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<MobspLkSepWSSelectOrderPaymentsById_Result> MobspLkSepWSSelectOrderPaymentsById(int? orderPaymentId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLkSepWSSelectOrderPaymentsById_Result>("MobspLkSepWSSelectOrderPaymentsById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspLkSepWSSelectPreOrderPaymentsById_Result> MobspLkSepWSSelectPreOrderPaymentsById(int? preOrderPaymentId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLkSepWSSelectPreOrderPaymentsById_Result>("MobspLkSepWSSelectPreOrderPaymentsById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCalendarEventWeekDates_Result> MobspSelectCalendarEventWeekDates(DateTime? date, int? fistWeekDayNum, int? rangeNumbe)
	{
		ObjectParameter objectParameter = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter2 = (fistWeekDayNum.HasValue ? new ObjectParameter("FistWeekDayNum", fistWeekDayNum) : new ObjectParameter("FistWeekDayNum", typeof(int)));
		ObjectParameter objectParameter3 = (rangeNumbe.HasValue ? new ObjectParameter("RangeNumbe", rangeNumbe) : new ObjectParameter("RangeNumbe", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCalendarEventWeekDates_Result>("MobspSelectCalendarEventWeekDates", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLoadUserTasksWeb_Result> CRMspLoadUserTasksWeb(DateTime? date, int? userId, int? languageID, int? defaultLanguageID, bool? selectWithCnvs, int? crmUserId, int? centerId, int? userTaskGroupId, int? userTaskPriorityId, int? userTaskDidItStatus)
	{
		ObjectParameter objectParameter = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (selectWithCnvs.HasValue ? new ObjectParameter("SelectWithCnvs", selectWithCnvs) : new ObjectParameter("SelectWithCnvs", typeof(bool)));
		ObjectParameter objectParameter6 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (userTaskGroupId.HasValue ? new ObjectParameter("UserTaskGroupId", userTaskGroupId) : new ObjectParameter("UserTaskGroupId", typeof(int)));
		ObjectParameter objectParameter9 = (userTaskPriorityId.HasValue ? new ObjectParameter("UserTaskPriorityId", userTaskPriorityId) : new ObjectParameter("UserTaskPriorityId", typeof(int)));
		ObjectParameter objectParameter10 = (userTaskDidItStatus.HasValue ? new ObjectParameter("UserTaskDidItStatus", userTaskDidItStatus) : new ObjectParameter("UserTaskDidItStatus", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLoadUserTasksWeb_Result>("CRMspLoadUserTasksWeb", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspSelectCompanyProjectFromRemindDate_Result> CRMspSelectCompanyProjectFromRemindDate(string fDate, string tDate, DateTime? fDateTime, DateTime? tDateTime, bool? prjIsFinished, int? prjcnvsStatusGroupId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = ((fDate != null) ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(string)));
		ObjectParameter objectParameter2 = ((tDate != null) ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(string)));
		ObjectParameter objectParameter3 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (prjIsFinished.HasValue ? new ObjectParameter("prjIsFinished", prjIsFinished) : new ObjectParameter("prjIsFinished", typeof(bool)));
		ObjectParameter objectParameter6 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyProjectFromRemindDate_Result>("CRMspSelectCompanyProjectFromRemindDate", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual int MobspUserTaskAlarmDidIt(int? userTaskId, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, DateTime? userTaskRemindDateTime, string userTaskRemindDate)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (userTaskRemindDateTime.HasValue ? new ObjectParameter("UserTaskRemindDateTime", userTaskRemindDateTime) : new ObjectParameter("UserTaskRemindDateTime", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((userTaskRemindDate != null) ? new ObjectParameter("UserTaskRemindDate", userTaskRemindDate) : new ObjectParameter("UserTaskRemindDate", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUserTaskAlarmDidIt", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int MobspUserTaskDidIt(int? userTaskId, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, DateTime? targetDate, bool? isFinish)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (targetDate.HasValue ? new ObjectParameter("TargetDate", targetDate) : new ObjectParameter("TargetDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = (isFinish.HasValue ? new ObjectParameter("IsFinish", isFinish) : new ObjectParameter("IsFinish", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUserTaskDidIt", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<MobspSelectUserTaskById_Result> MobspSelectUserTaskById(int? languageID, int? defaultLanguageID, int? userTaskId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserTaskById_Result>("MobspSelectUserTaskById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspLoadRemindingTask_Result> MobspLoadRemindingTask(string date, int? userId, DateTime? dateTime, int? languageID, int? defaultLanguageID, int? centerID)
	{
		ObjectParameter objectParameter = ((date != null) ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (dateTime.HasValue ? new ObjectParameter("DateTime", dateTime) : new ObjectParameter("DateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerID.HasValue ? new ObjectParameter("CenterID", centerID) : new ObjectParameter("CenterID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLoadRemindingTask_Result>("MobspLoadRemindingTask", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<int?> MobspExecuteLeave(int? leaveId, int? userId, DateTime? registerDate, string registerDatePersian, short? month1, short? year1, string appType, int? languageId, int? defaultLanguageId, ObjectParameter result)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspExecuteLeave", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, result });
	}

	public virtual ObjectResult<MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic_Result> MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic(int? referUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic_Result>("MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic_Result> MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic(int? referUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic_Result>("MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSingleUsersForRepParam_Result> MobspSelectSingleUsersForRepParam(int? userId, int? linkedType, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSingleUsersForRepParam_Result>("MobspSelectSingleUsersForRepParam", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspChartDailyTelGroupByExtensionNumber_Result> MobspChartDailyTelGroupByExtensionNumber(DateTime? fDate, DateTime? tDate, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspChartDailyTelGroupByExtensionNumber_Result>("MobspChartDailyTelGroupByExtensionNumber", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<string> MobspSelectAllUsersExtensions(int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MobspSelectAllUsersExtensions", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductById_Result> MobspSelectProductById(int? productId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductById_Result>("MobspSelectProductById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateUserDeviceAESByImeiCode(string aESKey, string deviceImeiCode, string appName)
	{
		ObjectParameter objectParameter = ((aESKey != null) ? new ObjectParameter("AESKey", aESKey) : new ObjectParameter("AESKey", typeof(string)));
		ObjectParameter objectParameter2 = ((deviceImeiCode != null) ? new ObjectParameter("DeviceImeiCode", deviceImeiCode) : new ObjectParameter("DeviceImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateUserDeviceAESByImeiCode", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual int MobspRemoveTmpUserAppDeviceInfo(int? userAppDeviceInfoId)
	{
		ObjectParameter objectParameter = (userAppDeviceInfoId.HasValue ? new ObjectParameter("UserAppDeviceInfoId", userAppDeviceInfoId) : new ObjectParameter("UserAppDeviceInfoId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspRemoveTmpUserAppDeviceInfo", objectParameter);
	}

	public virtual int FoMobspRemoveTempCompanyAppDeviceInfo(int? companyAppDeviceInfoId)
	{
		ObjectParameter objectParameter = (companyAppDeviceInfoId.HasValue ? new ObjectParameter("CompanyAppDeviceInfoId", companyAppDeviceInfoId) : new ObjectParameter("CompanyAppDeviceInfoId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FoMobspRemoveTempCompanyAppDeviceInfo", objectParameter);
	}

	public virtual ObjectResult<FoMobspSelectCompanyAppDeviceInfoByImeiCode_Result> FoMobspSelectCompanyAppDeviceInfoByImeiCode(string imeiCode, string appName, int? deviceTypeId, int? companyId)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		ObjectParameter objectParameter3 = (deviceTypeId.HasValue ? new ObjectParameter("DeviceTypeId", deviceTypeId) : new ObjectParameter("DeviceTypeId", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FoMobspSelectCompanyAppDeviceInfoByImeiCode_Result>("FoMobspSelectCompanyAppDeviceInfoByImeiCode", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}
}
