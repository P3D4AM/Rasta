using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using CRM.General.Security;

namespace CRM.Models;

public class CRMLinkSpEntities : DbContext
{
	public CRMLinkSpEntities()
		: base("name=CRMLinkSpEntities")
	{
		string connectionString = base.Database.Connection.ConnectionString;
		connectionString = connectionString.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		connectionString = connectionString.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		connectionString = connectionString.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		connectionString = connectionString.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		base.Database.Connection.ConnectionString = connectionString;
		((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}

	public virtual int CRMspInsertLinkAccErrorLogs(string scriptName, string partTitle, string errorMessage, int? userId, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = ((scriptName != null) ? new ObjectParameter("ScriptName", scriptName) : new ObjectParameter("ScriptName", typeof(string)));
		ObjectParameter objectParameter2 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((errorMessage != null) ? new ObjectParameter("ErrorMessage", errorMessage) : new ObjectParameter("ErrorMessage", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccErrorLogs", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual int CRMspInsertLinkAccHolooSettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccHolooSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspInsertLinkAccNoAvSettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccNoAvSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspInsertLinkAccSettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? linkAccSystemId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter11 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual int CRMspInsertLinkAccTarazSettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccTarazSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkHolooInsertLinkAccErrorLogs(string scriptName, string partTitle, string errorMessage, int? userId, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = ((scriptName != null) ? new ObjectParameter("ScriptName", scriptName) : new ObjectParameter("ScriptName", typeof(string)));
		ObjectParameter objectParameter2 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((errorMessage != null) ? new ObjectParameter("ErrorMessage", errorMessage) : new ObjectParameter("ErrorMessage", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkHolooInsertLinkAccErrorLogs", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual ObjectResult<CRMspLkHolooSelectCompany_Result> CRMspLkHolooSelectCompany(int? userId, DateTime? fDate, DateTime? tDATE, string value, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkHolooSelectCompany_Result>("CRMspLkHolooSelectCompany", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkHolooSelectCompanyByCmpIds_Result> CRMspLkHolooSelectCompanyByCmpIds(string companyIds, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((companyIds != null) ? new ObjectParameter("CompanyIds", companyIds) : new ObjectParameter("CompanyIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkHolooSelectCompanyByCmpIds_Result>("CRMspLkHolooSelectCompanyByCmpIds", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkHolooUpdateCompanyLinkAccFields(string linkAccFields, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((linkAccFields != null) ? new ObjectParameter("LinkAccFields", linkAccFields) : new ObjectParameter("LinkAccFields", typeof(string)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkHolooUpdateCompanyLinkAccFields", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int CRMspLkHolooWSInsertProductPriceFromHoloo(string prdPriceGroupName, int? productId, decimal? price, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((prdPriceGroupName != null) ? new ObjectParameter("PrdPriceGroupName", prdPriceGroupName) : new ObjectParameter("PrdPriceGroupName", typeof(string)));
		ObjectParameter objectParameter2 = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter3 = (price.HasValue ? new ObjectParameter("Price", price) : new ObjectParameter("Price", typeof(decimal)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkHolooWSInsertProductPriceFromHoloo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, insertedId, errorMessage, objectParameter11);
	}

	public virtual int CRMspLkHolooWSInsertUpdateOrderFromHoloo(string holooOrderJson, int? orderOprId, int? ordReferUserId, int? whId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? centerId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((holooOrderJson != null) ? new ObjectParameter("HolooOrderJson", holooOrderJson) : new ObjectParameter("HolooOrderJson", typeof(string)));
		ObjectParameter objectParameter2 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter4 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter13 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkHolooWSInsertUpdateOrderFromHoloo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, errorMessage, objectParameter12, objectParameter13);
	}

	public virtual int CRMspLkHolooWSInsertUpdateProductsFromHoloo(string holooProductJson, bool? isUseHolooPrdGroup, int? prdFirstGroupId, int? prdSecondGroupId, int? prdPriceGroupId, int? prdCostGroupId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, bool? isGetPrdCost, int? centerId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((holooProductJson != null) ? new ObjectParameter("HolooProductJson", holooProductJson) : new ObjectParameter("HolooProductJson", typeof(string)));
		ObjectParameter objectParameter2 = (isUseHolooPrdGroup.HasValue ? new ObjectParameter("IsUseHolooPrdGroup", isUseHolooPrdGroup) : new ObjectParameter("IsUseHolooPrdGroup", typeof(bool)));
		ObjectParameter objectParameter3 = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter6 = (prdCostGroupId.HasValue ? new ObjectParameter("PrdCostGroupId", prdCostGroupId) : new ObjectParameter("PrdCostGroupId", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter9 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (isGetPrdCost.HasValue ? new ObjectParameter("IsGetPrdCost", isGetPrdCost) : new ObjectParameter("IsGetPrdCost", typeof(bool)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter16 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkHolooWSInsertUpdateProductsFromHoloo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, errorMessage, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual int CRMspLkHolooWSInsertUpdateProductUnitsFromHoloo(string holooUnitJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((holooUnitJson != null) ? new ObjectParameter("HolooUnitJson", holooUnitJson) : new ObjectParameter("HolooUnitJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkHolooWSInsertUpdateProductUnitsFromHoloo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkHolooWSSelectOrder_Result> CRMspLkHolooWSSelectOrder(int? userId, int? orderOprId, DateTime? fDate, DateTime? tDATE, long? ordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? ordReferUserId, int? centerId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (ordReferUserId.HasValue ? new ObjectParameter("OrdReferUserId", ordReferUserId) : new ObjectParameter("OrdReferUserId", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkHolooWSSelectOrder_Result>("CRMspLkHolooWSSelectOrder", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<CRMspLkHolooWSSelectOrderByOrdIds_Result> CRMspLkHolooWSSelectOrderByOrdIds(string orderIds, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((orderIds != null) ? new ObjectParameter("OrderIds", orderIds) : new ObjectParameter("OrderIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkHolooWSSelectOrderByOrdIds_Result>("CRMspLkHolooWSSelectOrderByOrdIds", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkHolooWSUpdateOrderLinkAccFields(string linkAccFields, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((linkAccFields != null) ? new ObjectParameter("LinkAccFields", linkAccFields) : new ObjectParameter("LinkAccFields", typeof(string)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkHolooWSUpdateOrderLinkAccFields", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int CRMspLkInsertUpdateCompanyTypes(string json, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? languageId, string appType, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateCompanyTypes", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkKyanInsertUpdateCompany(string json, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? languageId, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkKyanInsertUpdateCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual int CRMspLkKyanInsertUpdateCompanyGroupsIIFromKyan(string json, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkKyanInsertUpdateCompanyGroupsIIFromKyan", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkKyanWSInsertOrderPaymentTypesFromKyan(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkKyanWSInsertOrderPaymentTypesFromKyan", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkKyanWSInsertUpdateOrdersFromKyan(string json, int? orderOprID, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (orderOprID.HasValue ? new ObjectParameter("OrderOprID", orderOprID) : new ObjectParameter("OrderOprID", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkKyanWSInsertUpdateOrdersFromKyan", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual int CRMspLkKyanWSInsertUpdateProductsFromKyan(string json, int? prdFirstGroupId, int? prdSecondGroupId, int? prdPriceGroupId, int? prdCostGroupId, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (prdCostGroupId.HasValue ? new ObjectParameter("PrdCostGroupId", prdCostGroupId) : new ObjectParameter("PrdCostGroupId", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter9 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkKyanWSInsertUpdateProductsFromKyan", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, errorMessage, objectParameter14);
	}

	public virtual int CRMspLkKyanWSInsertUpdateWareHouseFromKyan(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkKyanWSInsertUpdateWareHouseFromKyan", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage, objectParameter9);
	}

	public virtual int CRMspLkNoAvExportCompany(int? noAvIdCompany, string commercialDbName, string storeDbName, DateTime? fDate, DateTime? tDATE, string value, string selectedIds, int? pageNumber, int? pageSize, int? userId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (noAvIdCompany.HasValue ? new ObjectParameter("NoAvIdCompany", noAvIdCompany) : new ObjectParameter("NoAvIdCompany", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter7 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvExportCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, errorMessage, objectParameter14);
	}

	public virtual int CRMspLkNoAvIIInsertLinkAccErrorLogs(string scriptName, string partTitle, string errorMessage, int? userId, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = ((scriptName != null) ? new ObjectParameter("ScriptName", scriptName) : new ObjectParameter("ScriptName", typeof(string)));
		ObjectParameter objectParameter2 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((errorMessage != null) ? new ObjectParameter("ErrorMessage", errorMessage) : new ObjectParameter("ErrorMessage", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvIIInsertLinkAccErrorLogs", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual int CRMspLkNoAvIIInsertUpdateUsersFromNoAvII(string userJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((userJson != null) ? new ObjectParameter("UserJson", userJson) : new ObjectParameter("UserJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvIIInsertUpdateUsersFromNoAvII", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkNoAvIISelectCompany_Result> CRMspLkNoAvIISelectCompany(int? userId, DateTime? fDate, DateTime? tDATE, string value, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvIISelectCompany_Result>("CRMspLkNoAvIISelectCompany", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int CRMspLkNoAvIIWSInsertUpdateOrdersFromNoAvII(string noAvIIOrderJson, int? orderOprID, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((noAvIIOrderJson != null) ? new ObjectParameter("NoAvIIOrderJson", noAvIIOrderJson) : new ObjectParameter("NoAvIIOrderJson", typeof(string)));
		ObjectParameter objectParameter2 = (orderOprID.HasValue ? new ObjectParameter("OrderOprID", orderOprID) : new ObjectParameter("OrderOprID", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvIIWSInsertUpdateOrdersFromNoAvII", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual int CRMspLkNoAvIIWSInsertUpdateProductsFromNoAvII(string noAvIIProductJson, int? prdFirstGroupId, int? prdSecondGroupId, int? prdPriceGroupId, int? prdCostGroupId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((noAvIIProductJson != null) ? new ObjectParameter("NoAvIIProductJson", noAvIIProductJson) : new ObjectParameter("NoAvIIProductJson", typeof(string)));
		ObjectParameter objectParameter2 = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (prdCostGroupId.HasValue ? new ObjectParameter("PrdCostGroupId", prdCostGroupId) : new ObjectParameter("PrdCostGroupId", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvIIWSInsertUpdateProductsFromNoAvII", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, errorMessage, objectParameter13);
	}

	public virtual int CRMspLkNoAvIIWSInsertUpdateWareHouseFromNoAvII(string noAvIIWareHouseJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((noAvIIWareHouseJson != null) ? new ObjectParameter("NoAvIIWareHouseJson", noAvIIWareHouseJson) : new ObjectParameter("NoAvIIWareHouseJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvIIWSInsertUpdateWareHouseFromNoAvII", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage, objectParameter9);
	}

	public virtual int CRMspLkNoAvIIWSIssueDocFirstQtyPeriodFromNoAvII(string itemJson, int? docOprId, int? whId, int? companyId, int? companyPersonId, int? projectId, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter insertedDocId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter3 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter6 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvIIWSIssueDocFirstQtyPeriodFromNoAvII", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, insertedDocId, errorMessage, objectParameter14);
	}

	public virtual int CRMspLkNoAvIIWSIssueDocFromNoAvII(string json, int? docOprID, int? docType, int? userId, int? month1, int? fPId, short? yEAR1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (docOprID.HasValue ? new ObjectParameter("DocOprID", docOprID) : new ObjectParameter("DocOprID", typeof(int)));
		ObjectParameter objectParameter3 = (docType.HasValue ? new ObjectParameter("DocType", docType) : new ObjectParameter("DocType", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (yEAR1.HasValue ? new ObjectParameter("YEAR1", yEAR1) : new ObjectParameter("YEAR1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvIIWSIssueDocFromNoAvII", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, errorMessage, objectParameter12);
	}

	public virtual ObjectResult<CRMspLkNoAvIIWSSelectDocWithFilledAccCode_Result> CRMspLkNoAvIIWSSelectDocWithFilledAccCode(int? languageID, int? defaultLanguageId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvIIWSSelectDocWithFilledAccCode_Result>("CRMspLkNoAvIIWSSelectDocWithFilledAccCode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CRMspLkNoAvIIWSSelectPreOrder_Result> CRMspLkNoAvIIWSSelectPreOrder(int? userId, DateTime? fDate, DateTime? tDATE, long? pordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvIIWSSelectPreOrder_Result>("CRMspLkNoAvIIWSSelectPreOrder", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int CRMspLkNoAvInsertLinkAccErrorLogs(string scriptName, string partTitle, string errorMessage, int? userId, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = ((scriptName != null) ? new ObjectParameter("ScriptName", scriptName) : new ObjectParameter("ScriptName", typeof(string)));
		ObjectParameter objectParameter2 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((errorMessage != null) ? new ObjectParameter("ErrorMessage", errorMessage) : new ObjectParameter("ErrorMessage", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvInsertLinkAccErrorLogs", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual int CRMspLkNoAvInsertUpdateCompany(int? companyId, int? crmUserId, int? noAvIdCompany, string commercialDbName, string storeDbName, string appType, ObjectParameter insertedId, ObjectParameter insertedNumebr, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (noAvIdCompany.HasValue ? new ObjectParameter("NoAvIdCompany", noAvIdCompany) : new ObjectParameter("NoAvIdCompany", typeof(int)));
		ObjectParameter objectParameter4 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter5 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvInsertUpdateCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, insertedId, insertedNumebr, errorMessage);
	}

	public virtual int CRMspLkNoAvInsertUpdateCompanyFromNoAv(int? noAvCustomerId, string commercialDbName, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedCmpId, ObjectParameter insertedPrsId, ObjectParameter errorMessage, int? cmpReferUserId, int? centerId)
	{
		ObjectParameter objectParameter = (noAvCustomerId.HasValue ? new ObjectParameter("NoAvCustomerId", noAvCustomerId) : new ObjectParameter("NoAvCustomerId", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (cmpReferUserId.HasValue ? new ObjectParameter("cmpReferUserId", cmpReferUserId) : new ObjectParameter("cmpReferUserId", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvInsertUpdateCompanyFromNoAv", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, insertedCmpId, insertedPrsId, errorMessage, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<CRMspLkNoAvSelectCompany_Result> CRMspLkNoAvSelectCompany(int? userId, DateTime? fDate, DateTime? tDATE, string value, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvSelectCompany_Result>("CRMspLkNoAvSelectCompany", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspLkNoAvSelectDbNames_Result> CRMspLkNoAvSelectDbNames(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvSelectDbNames_Result>("CRMspLkNoAvSelectDbNames", new ObjectParameter[1] { objectParameter });
	}

	public virtual int CRMspLkNoAvSelectKindBuyOrSale(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvSelectKindBuyOrSale", objectParameter);
	}

	public virtual int CRMspLkNoAvSelectSalesMan(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvSelectSalesMan", objectParameter);
	}

	public virtual int CRMspLkNoAvSelectSelfCompany(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvSelectSelfCompany", objectParameter);
	}

	public virtual int CRMspLkNoAvSelectStore(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvSelectStore", objectParameter);
	}

	public virtual int CRMspLkNoAvWSCalcAndUpdateOrderAmounts(int? orderId, short? month1, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSCalcAndUpdateOrderAmounts", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int CRMspLkNoAvWSExportOrder(int? noAvIdCompany, int? noAvSalesManId, int? noAvKindFactor, int? noAvKindSaleId, int? noAvCodeStore, int? noAvOrdType, string commercialDbName, string storeDbName, DateTime? fDate, DateTime? tDATE, long? ordNumber, int? orderOprId, string selectedIds, bool? sendPreOrderToAcc, int? pageNumber, int? pageSize, int? userId, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (noAvIdCompany.HasValue ? new ObjectParameter("NoAvIdCompany", noAvIdCompany) : new ObjectParameter("NoAvIdCompany", typeof(int)));
		ObjectParameter objectParameter2 = (noAvSalesManId.HasValue ? new ObjectParameter("NoAvSalesManId", noAvSalesManId) : new ObjectParameter("NoAvSalesManId", typeof(int)));
		ObjectParameter objectParameter3 = (noAvKindFactor.HasValue ? new ObjectParameter("NoAvKindFactor", noAvKindFactor) : new ObjectParameter("NoAvKindFactor", typeof(int)));
		ObjectParameter objectParameter4 = (noAvKindSaleId.HasValue ? new ObjectParameter("NoAvKindSaleId", noAvKindSaleId) : new ObjectParameter("NoAvKindSaleId", typeof(int)));
		ObjectParameter objectParameter5 = (noAvCodeStore.HasValue ? new ObjectParameter("NoAvCodeStore", noAvCodeStore) : new ObjectParameter("NoAvCodeStore", typeof(int)));
		ObjectParameter objectParameter6 = (noAvOrdType.HasValue ? new ObjectParameter("NoAvOrdType", noAvOrdType) : new ObjectParameter("NoAvOrdType", typeof(int)));
		ObjectParameter objectParameter7 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter8 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter9 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter11 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter12 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter13 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter14 = (sendPreOrderToAcc.HasValue ? new ObjectParameter("SendPreOrderToAcc", sendPreOrderToAcc) : new ObjectParameter("SendPreOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter15 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter16 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter17 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter18 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter19 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSExportOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, errorMessage, objectParameter19);
	}

	public virtual int CRMspLkNoAvWSExportPreOrder(int? noAvIdCompany, int? noAvSalesManId, int? noAvKindFactor, int? noAvCodeStore, string commercialDbName, string storeDbName, DateTime? fDate, DateTime? tDATE, long? pordNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (noAvIdCompany.HasValue ? new ObjectParameter("NoAvIdCompany", noAvIdCompany) : new ObjectParameter("NoAvIdCompany", typeof(int)));
		ObjectParameter objectParameter2 = (noAvSalesManId.HasValue ? new ObjectParameter("NoAvSalesManId", noAvSalesManId) : new ObjectParameter("NoAvSalesManId", typeof(int)));
		ObjectParameter objectParameter3 = (noAvKindFactor.HasValue ? new ObjectParameter("NoAvKindFactor", noAvKindFactor) : new ObjectParameter("NoAvKindFactor", typeof(int)));
		ObjectParameter objectParameter4 = (noAvCodeStore.HasValue ? new ObjectParameter("NoAvCodeStore", noAvCodeStore) : new ObjectParameter("NoAvCodeStore", typeof(int)));
		ObjectParameter objectParameter5 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter6 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter7 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter9 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter10 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter11 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter12 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSExportPreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, errorMessage, objectParameter15);
	}

	public virtual int CRMspLkNoAvWSExportProduct(int? prdPriceGroupId, string commercialDbName, string storeDbName, int? noAvCodeStore, DateTime? fDate, DateTime? tDATE, string value, string selectedIds, int? firstGroupId, int? secondGroupId, int? pageNumber, int? pageSize, int? userId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (noAvCodeStore.HasValue ? new ObjectParameter("NoAvCodeStore", noAvCodeStore) : new ObjectParameter("NoAvCodeStore", typeof(int)));
		ObjectParameter objectParameter5 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter8 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter9 = (firstGroupId.HasValue ? new ObjectParameter("FirstGroupId", firstGroupId) : new ObjectParameter("FirstGroupId", typeof(int)));
		ObjectParameter objectParameter10 = (secondGroupId.HasValue ? new ObjectParameter("SecondGroupId", secondGroupId) : new ObjectParameter("SecondGroupId", typeof(int)));
		ObjectParameter objectParameter11 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter12 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSExportProduct", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, errorMessage);
	}

	public virtual int CRMspLkNoAvWSImportDoc(int? noAvDocType, string commercialDbName, string storeDbName, int? noAvKindDraft, int? docOprId, DateTime? fDate, DateTime? tDATE, int? docNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? noAvStoreId, int? centerId)
	{
		ObjectParameter objectParameter = (noAvDocType.HasValue ? new ObjectParameter("NoAvDocType", noAvDocType) : new ObjectParameter("NoAvDocType", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (noAvKindDraft.HasValue ? new ObjectParameter("NoAvKindDraft", noAvKindDraft) : new ObjectParameter("NoAvKindDraft", typeof(int)));
		ObjectParameter objectParameter5 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter6 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter8 = (docNumber.HasValue ? new ObjectParameter("DocNumber", docNumber) : new ObjectParameter("DocNumber", typeof(int)));
		ObjectParameter objectParameter9 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter10 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter11 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter12 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter14 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter18 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (noAvStoreId.HasValue ? new ObjectParameter("NoAvStoreId", noAvStoreId) : new ObjectParameter("NoAvStoreId", typeof(int)));
		ObjectParameter objectParameter20 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSImportDoc", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, errorMessage, objectParameter19, objectParameter20);
	}

	public virtual int CRMspLkNoAvWSImportOrder(int? noAvType, string commercialDbName, string storeDbName, int? orderOprId, bool? isGetPayment, DateTime? fDate, DateTime? tDATE, int? ordNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? ordReferUserId, int? centerId)
	{
		ObjectParameter objectParameter = (noAvType.HasValue ? new ObjectParameter("NoAvType", noAvType) : new ObjectParameter("NoAvType", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter5 = (isGetPayment.HasValue ? new ObjectParameter("IsGetPayment", isGetPayment) : new ObjectParameter("IsGetPayment", typeof(bool)));
		ObjectParameter objectParameter6 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter8 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(int)));
		ObjectParameter objectParameter9 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter10 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter11 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter12 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter14 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter18 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter20 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSImportOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, errorMessage, objectParameter19, objectParameter20);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateOrderPayment(int? orderId, int? orderPaymentId, int? noAvIdCompany, string commercialDbName, string storeDbName, int? noAvDaryaftCheckKindSabt, string noAvDaryaftCheckKindSabtDis, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter3 = (noAvIdCompany.HasValue ? new ObjectParameter("NoAvIdCompany", noAvIdCompany) : new ObjectParameter("NoAvIdCompany", typeof(int)));
		ObjectParameter objectParameter4 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter5 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter6 = (noAvDaryaftCheckKindSabt.HasValue ? new ObjectParameter("NoAvDaryaftCheckKindSabt", noAvDaryaftCheckKindSabt) : new ObjectParameter("NoAvDaryaftCheckKindSabt", typeof(int)));
		ObjectParameter objectParameter7 = ((noAvDaryaftCheckKindSabtDis != null) ? new ObjectParameter("NoAvDaryaftCheckKindSabtDis", noAvDaryaftCheckKindSabtDis) : new ObjectParameter("NoAvDaryaftCheckKindSabtDis", typeof(string)));
		ObjectParameter objectParameter8 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateOrderPayment", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, insertedId, insertedNumber, errorMessage);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateOrderPaymentFromNoAv(int? noAvFactorId, int? orderId, string commercialDbName, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (noAvFactorId.HasValue ? new ObjectParameter("NoAvFactorId", noAvFactorId) : new ObjectParameter("NoAvFactorId", typeof(int)));
		ObjectParameter objectParameter2 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter3 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateOrderPaymentFromNoAv", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateProduct(int? productId, int? prdPriceGroupId, int? noAvCodeStore, string commercialDbName, string storeDbName, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedCode, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (noAvCodeStore.HasValue ? new ObjectParameter("NoAvCodeStore", noAvCodeStore) : new ObjectParameter("NoAvCodeStore", typeof(int)));
		ObjectParameter objectParameter4 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter5 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter6 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateProduct", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, insertedId, insertedCode, errorMessage);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateProductFromNoAv(int? noAvMaterialId, int? prdGroupId, int? prdPriceGroupId, string commercialDbName, string storeDbName, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedPrdId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (noAvMaterialId.HasValue ? new ObjectParameter("NoAvMaterialId", noAvMaterialId) : new ObjectParameter("NoAvMaterialId", typeof(int)));
		ObjectParameter objectParameter2 = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter4 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter5 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateProductFromNoAv", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedPrdId, errorMessage);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateProductSecondGroup(int? prdSecondGroupId, string commercialDbName, string storeDbName, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateProductSecondGroup", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, insertedId, errorMessage);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateProductUnit(int? productUnitId, string commercialDbName, string storeDbName, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (productUnitId.HasValue ? new ObjectParameter("ProductUnitId", productUnitId) : new ObjectParameter("ProductUnitId", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateProductUnit", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, insertedId, errorMessage);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateWareHouse(int? whId, string commercialDbName, string storeDbName, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedCode, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateWareHouse", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, insertedId, insertedCode, errorMessage);
	}

	public virtual int CRMspLkNoAvWSInsertUpdateWareHouseFromNoAv(int? noAvStoreId, string commercialDbName, string storeDbName, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedWhId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (noAvStoreId.HasValue ? new ObjectParameter("NoAvStoreId", noAvStoreId) : new ObjectParameter("NoAvStoreId", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSInsertUpdateWareHouseFromNoAv", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, insertedWhId, errorMessage, objectParameter11);
	}

	public virtual int CRMspLkNoAvWSIssueDocFirstQtyPeriodFromNoAv(int? docOprId, int? whId, int? companyId, int? companyPersonId, int? projectId, string commercialDbName, string storeDbName, int? noAvStoreId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedDocId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter2 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter5 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter6 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter7 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter8 = (noAvStoreId.HasValue ? new ObjectParameter("NoAvStoreId", noAvStoreId) : new ObjectParameter("NoAvStoreId", typeof(int)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter11 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSIssueDocFirstQtyPeriodFromNoAv", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, insertedDocId, errorMessage, objectParameter16);
	}

	public virtual int CRMspLkNoAvWSIssueDocFromNoAv(int? noAvDocNO, int? noAvDraftId, int? noAvDocType, string commercialDbName, string storeDbName, int? docOprId, int? orderId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedDocId, ObjectParameter errorMessage, int? noAvStoreCode, int? centerId)
	{
		ObjectParameter objectParameter = (noAvDocNO.HasValue ? new ObjectParameter("NoAvDocNO", noAvDocNO) : new ObjectParameter("NoAvDocNO", typeof(int)));
		ObjectParameter objectParameter2 = (noAvDraftId.HasValue ? new ObjectParameter("NoAvDraftId", noAvDraftId) : new ObjectParameter("NoAvDraftId", typeof(int)));
		ObjectParameter objectParameter3 = (noAvDocType.HasValue ? new ObjectParameter("NoAvDocType", noAvDocType) : new ObjectParameter("NoAvDocType", typeof(int)));
		ObjectParameter objectParameter4 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter5 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter6 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter7 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter10 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter11 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter15 = (noAvStoreCode.HasValue ? new ObjectParameter("NoAvStoreCode", noAvStoreCode) : new ObjectParameter("NoAvStoreCode", typeof(int)));
		ObjectParameter objectParameter16 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSIssueDocFromNoAv", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, insertedDocId, errorMessage, objectParameter15, objectParameter16);
	}

	public virtual int CRMspLkNoAvWSIssueOrder(int? orderId, int? noAvIdCompany, int? noAvSalesManId, int? noAvKindFactor, int? noAvKindSaleId, int? noAvCodeStore, int? noAvOrdType, string commercialDbName, string storeDbName, bool? sendPreOrderToAcc, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (noAvIdCompany.HasValue ? new ObjectParameter("NoAvIdCompany", noAvIdCompany) : new ObjectParameter("NoAvIdCompany", typeof(int)));
		ObjectParameter objectParameter3 = (noAvSalesManId.HasValue ? new ObjectParameter("NoAvSalesManId", noAvSalesManId) : new ObjectParameter("NoAvSalesManId", typeof(int)));
		ObjectParameter objectParameter4 = (noAvKindFactor.HasValue ? new ObjectParameter("NoAvKindFactor", noAvKindFactor) : new ObjectParameter("NoAvKindFactor", typeof(int)));
		ObjectParameter objectParameter5 = (noAvKindSaleId.HasValue ? new ObjectParameter("NoAvKindSaleId", noAvKindSaleId) : new ObjectParameter("NoAvKindSaleId", typeof(int)));
		ObjectParameter objectParameter6 = (noAvCodeStore.HasValue ? new ObjectParameter("NoAvCodeStore", noAvCodeStore) : new ObjectParameter("NoAvCodeStore", typeof(int)));
		ObjectParameter objectParameter7 = (noAvOrdType.HasValue ? new ObjectParameter("NoAvOrdType", noAvOrdType) : new ObjectParameter("NoAvOrdType", typeof(int)));
		ObjectParameter objectParameter8 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter9 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter10 = (sendPreOrderToAcc.HasValue ? new ObjectParameter("SendPreOrderToAcc", sendPreOrderToAcc) : new ObjectParameter("SendPreOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter11 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSIssueOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedId, insertedNumber, errorMessage);
	}

	public virtual int CRMspLkNoAvWSIssueOrderFromNoAv(int? noAvFactorId, int? orderOprId, string commercialDbName, string storeDbName, bool? isGetPayment, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedOrdId, ObjectParameter errorMessage, int? ordReferUserId, int? centerId)
	{
		ObjectParameter objectParameter = (noAvFactorId.HasValue ? new ObjectParameter("NoAvFactorId", noAvFactorId) : new ObjectParameter("NoAvFactorId", typeof(int)));
		ObjectParameter objectParameter2 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter4 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter5 = (isGetPayment.HasValue ? new ObjectParameter("IsGetPayment", isGetPayment) : new ObjectParameter("IsGetPayment", typeof(bool)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSIssueOrderFromNoAv", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedOrdId, errorMessage, objectParameter13, objectParameter14);
	}

	public virtual int CRMspLkNoAvWSIssuePreOrder(int? preOrderId, int? noAvIdCompany, int? noAvSalesManId, int? noAvKindFactor, int? noAvCodeStore, string commercialDbName, string storeDbName, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (noAvIdCompany.HasValue ? new ObjectParameter("NoAvIdCompany", noAvIdCompany) : new ObjectParameter("NoAvIdCompany", typeof(int)));
		ObjectParameter objectParameter3 = (noAvSalesManId.HasValue ? new ObjectParameter("NoAvSalesManId", noAvSalesManId) : new ObjectParameter("NoAvSalesManId", typeof(int)));
		ObjectParameter objectParameter4 = (noAvKindFactor.HasValue ? new ObjectParameter("NoAvKindFactor", noAvKindFactor) : new ObjectParameter("NoAvKindFactor", typeof(int)));
		ObjectParameter objectParameter5 = (noAvCodeStore.HasValue ? new ObjectParameter("NoAvCodeStore", noAvCodeStore) : new ObjectParameter("NoAvCodeStore", typeof(int)));
		ObjectParameter objectParameter6 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter7 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter8 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkNoAvWSIssuePreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, insertedId, insertedNumber, errorMessage);
	}

	public virtual ObjectResult<CRMspLkNoAvWSSelectDocFromNoAv_Result> CRMspLkNoAvWSSelectDocFromNoAv(int? noAvDocType, string commercialDbName, string storeDbName, int? noAvKindDraft, DateTime? fDate, DateTime? tDATE, int? docNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? noAvStoreId)
	{
		ObjectParameter objectParameter = (noAvDocType.HasValue ? new ObjectParameter("NoAvDocType", noAvDocType) : new ObjectParameter("NoAvDocType", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (noAvKindDraft.HasValue ? new ObjectParameter("NoAvKindDraft", noAvKindDraft) : new ObjectParameter("NoAvKindDraft", typeof(int)));
		ObjectParameter objectParameter5 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter7 = (docNumber.HasValue ? new ObjectParameter("DocNumber", docNumber) : new ObjectParameter("DocNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (noAvStoreId.HasValue ? new ObjectParameter("NoAvStoreId", noAvStoreId) : new ObjectParameter("NoAvStoreId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvWSSelectDocFromNoAv_Result>("CRMspLkNoAvWSSelectDocFromNoAv", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<CRMspLkNoAvWSSelectOrder_Result> CRMspLkNoAvWSSelectOrder(int? userId, DateTime? fDate, DateTime? tDATE, long? ordNumber, int? orderOprId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter5 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvWSSelectOrder_Result>("CRMspLkNoAvWSSelectOrder", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkNoAvWSSelectOrderFromNoAv_Result> CRMspLkNoAvWSSelectOrderFromNoAv(int? noAvType, string commercialDbName, string storeDbName, DateTime? fDate, DateTime? tDATE, int? ordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (noAvType.HasValue ? new ObjectParameter("NoAvType", noAvType) : new ObjectParameter("NoAvType", typeof(int)));
		ObjectParameter objectParameter2 = ((commercialDbName != null) ? new ObjectParameter("CommercialDbName", commercialDbName) : new ObjectParameter("CommercialDbName", typeof(string)));
		ObjectParameter objectParameter3 = ((storeDbName != null) ? new ObjectParameter("StoreDbName", storeDbName) : new ObjectParameter("StoreDbName", typeof(string)));
		ObjectParameter objectParameter4 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter6 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvWSSelectOrderFromNoAv_Result>("CRMspLkNoAvWSSelectOrderFromNoAv", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkNoAvWSSelectPreOrder_Result> CRMspLkNoAvWSSelectPreOrder(int? userId, DateTime? fDate, DateTime? tDATE, long? pordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvWSSelectPreOrder_Result>("CRMspLkNoAvWSSelectPreOrder", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspLkNoAvWSSelectProduct_Result> CRMspLkNoAvWSSelectProduct(DateTime? fDate, DateTime? tDATE, string value, int? firstGroupId, int? secondGroupId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter4 = (firstGroupId.HasValue ? new ObjectParameter("FirstGroupId", firstGroupId) : new ObjectParameter("FirstGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (secondGroupId.HasValue ? new ObjectParameter("SecondGroupId", secondGroupId) : new ObjectParameter("SecondGroupId", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvWSSelectProduct_Result>("CRMspLkNoAvWSSelectProduct", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int CRMspLkPayvastWSInsertUpdateProductsFromPayvast(string json, int? prdFirstGroupId, int? prdSecondGroupId, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkPayvastWSInsertUpdateProductsFromPayvast", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, errorMessage, objectParameter12);
	}

	public virtual ObjectResult<CRMspLkSelectCompanyByCmpIds_Result> CRMspLkSelectCompanyByCmpIds(string companyIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((companyIds != null) ? new ObjectParameter("CompanyIds", companyIds) : new ObjectParameter("CompanyIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSelectCompanyByCmpIds_Result>("CRMspLkSelectCompanyByCmpIds", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkSepExportCompany(DateTime? fDate, DateTime? tDATE, string value, string selectedIds, int? pageNumber, int? pageSize, int? userId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage, int? sepUserId, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter4 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepExportCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual int CRMspLkSepImportCompany(DateTime? fDate, DateTime? tDATE, string value, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? cmpReferUserId, bool? updateCompnay, bool? insertFromReceipt, bool? insertFromPayment, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter4 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter9 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (cmpReferUserId.HasValue ? new ObjectParameter("cmpReferUserId", cmpReferUserId) : new ObjectParameter("cmpReferUserId", typeof(int)));
		ObjectParameter objectParameter15 = (updateCompnay.HasValue ? new ObjectParameter("UpdateCompnay", updateCompnay) : new ObjectParameter("UpdateCompnay", typeof(bool)));
		ObjectParameter objectParameter16 = (insertFromReceipt.HasValue ? new ObjectParameter("InsertFromReceipt", insertFromReceipt) : new ObjectParameter("InsertFromReceipt", typeof(bool)));
		ObjectParameter objectParameter17 = (insertFromPayment.HasValue ? new ObjectParameter("InsertFromPayment", insertFromPayment) : new ObjectParameter("InsertFromPayment", typeof(bool)));
		ObjectParameter objectParameter18 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepImportCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, errorMessage, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18);
	}

	public virtual int CRMspLkSepInsertLinkAccErrorLogs(string scriptName, string partTitle, string errorMessage, int? userId, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = ((scriptName != null) ? new ObjectParameter("ScriptName", scriptName) : new ObjectParameter("ScriptName", typeof(string)));
		ObjectParameter objectParameter2 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((errorMessage != null) ? new ObjectParameter("ErrorMessage", errorMessage) : new ObjectParameter("ErrorMessage", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepInsertLinkAccErrorLogs", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual int CRMspLkSepInsertUpdateCompany(int? companyId, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter accCode, ObjectParameter errorMessage, int? sepUserId, int? linkAccSettingDBId, bool? useCrmCmpCode)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter4 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter6 = (useCrmCmpCode.HasValue ? new ObjectParameter("UseCrmCmpCode", useCrmCmpCode) : new ObjectParameter("UseCrmCmpCode", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepInsertUpdateCompany", objectParameter, objectParameter2, objectParameter3, insertedId, accCode, errorMessage, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual int CRMspLkSepInsertUpdateCompanyFromSep(int? sepPartyId, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedCmpId, ObjectParameter insertedPrsId, ObjectParameter errorMessage, int? cmpReferUserId, bool? updateCompnay, bool? insertFromReceipt, bool? insertFromPayment, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (sepPartyId.HasValue ? new ObjectParameter("SepPartyId", sepPartyId) : new ObjectParameter("SepPartyId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (cmpReferUserId.HasValue ? new ObjectParameter("cmpReferUserId", cmpReferUserId) : new ObjectParameter("cmpReferUserId", typeof(int)));
		ObjectParameter objectParameter10 = (updateCompnay.HasValue ? new ObjectParameter("UpdateCompnay", updateCompnay) : new ObjectParameter("UpdateCompnay", typeof(bool)));
		ObjectParameter objectParameter11 = (insertFromReceipt.HasValue ? new ObjectParameter("InsertFromReceipt", insertFromReceipt) : new ObjectParameter("InsertFromReceipt", typeof(bool)));
		ObjectParameter objectParameter12 = (insertFromPayment.HasValue ? new ObjectParameter("InsertFromPayment", insertFromPayment) : new ObjectParameter("InsertFromPayment", typeof(bool)));
		ObjectParameter objectParameter13 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepInsertUpdateCompanyFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, insertedCmpId, insertedPrsId, errorMessage, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14);
	}

	public virtual int CRMspLkSepLockItemStockSummary(int? sepStockId, int? sepItemId, int? sepTracingId, int? sepFiscalYearId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepStockId.HasValue ? new ObjectParameter("SepStockId", sepStockId) : new ObjectParameter("SepStockId", typeof(int)));
		ObjectParameter objectParameter2 = (sepItemId.HasValue ? new ObjectParameter("SepItemId", sepItemId) : new ObjectParameter("SepItemId", typeof(int)));
		ObjectParameter objectParameter3 = (sepTracingId.HasValue ? new ObjectParameter("SepTracingId", sepTracingId) : new ObjectParameter("SepTracingId", typeof(int)));
		ObjectParameter objectParameter4 = (sepFiscalYearId.HasValue ? new ObjectParameter("SepFiscalYearId", sepFiscalYearId) : new ObjectParameter("SepFiscalYearId", typeof(int)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepLockItemStockSummary", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<CRMspLkSepSelectCash_Result> CRMspLkSepSelectCash(int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectCash_Result>("CRMspLkSepSelectCash", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkSepSelectCompany_Result> CRMspLkSepSelectCompany(int? userId, DateTime? fDate, DateTime? tDATE, string value, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectCompany_Result>("CRMspLkSepSelectCompany", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkSepSelectCompanyFromSep_Result> CRMspLkSepSelectCompanyFromSep(DateTime? fDate, DateTime? tDATE, string value, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter4 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectCompanyFromSep_Result>("CRMspLkSepSelectCompanyFromSep", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<CRMspLkSepSelectFiscalYear_Result> CRMspLkSepSelectFiscalYear(int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectFiscalYear_Result>("CRMspLkSepSelectFiscalYear", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkSepSelectSaleType_Result> CRMspLkSepSelectSaleType(int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectSaleType_Result>("CRMspLkSepSelectSaleType", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkSepSelectUser_Result> CRMspLkSepSelectUser(int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectUser_Result>("CRMspLkSepSelectUser", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkSepUpdateItemStockSummary(int? sepStockId, int? sepItemId, int? sepTracingId, int? sepFiscalYearId, bool? updateSaleWithReserve, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepStockId.HasValue ? new ObjectParameter("SepStockId", sepStockId) : new ObjectParameter("SepStockId", typeof(int)));
		ObjectParameter objectParameter2 = (sepItemId.HasValue ? new ObjectParameter("SepItemId", sepItemId) : new ObjectParameter("SepItemId", typeof(int)));
		ObjectParameter objectParameter3 = (sepTracingId.HasValue ? new ObjectParameter("SepTracingId", sepTracingId) : new ObjectParameter("SepTracingId", typeof(int)));
		ObjectParameter objectParameter4 = (sepFiscalYearId.HasValue ? new ObjectParameter("SepFiscalYearId", sepFiscalYearId) : new ObjectParameter("SepFiscalYearId", typeof(int)));
		ObjectParameter objectParameter5 = (updateSaleWithReserve.HasValue ? new ObjectParameter("UpdateSaleWithReserve", updateSaleWithReserve) : new ObjectParameter("UpdateSaleWithReserve", typeof(bool)));
		ObjectParameter objectParameter6 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepUpdateItemStockSummary", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual int CRMspLkSepWSExportBuyOrder(int? buyOrderOprId, int? sepCachId, int? sepFiscalYearRef, DateTime? fDate, DateTime? tDATE, long? bordNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, string appType, ObjectParameter errorMessage, int? sepUserId, bool? sendBordPayToAcc, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderOprId.HasValue ? new ObjectParameter("BuyOrderOprId", buyOrderOprId) : new ObjectParameter("BuyOrderOprId", typeof(int)));
		ObjectParameter objectParameter2 = (sepCachId.HasValue ? new ObjectParameter("SepCachId", sepCachId) : new ObjectParameter("SepCachId", typeof(int)));
		ObjectParameter objectParameter3 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter4 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter6 = (bordNumber.HasValue ? new ObjectParameter("BordNumber", bordNumber) : new ObjectParameter("BordNumber", typeof(long)));
		ObjectParameter objectParameter7 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter13 = (sendBordPayToAcc.HasValue ? new ObjectParameter("SendBordPayToAcc", sendBordPayToAcc) : new ObjectParameter("SendBordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter14 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSExportBuyOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, errorMessage, objectParameter12, objectParameter13, objectParameter14);
	}

	public virtual int CRMspLkSepWSExportDoc(int? docOprId, int? sepInventoryType, int? sepDocType, bool? sepInvIsReturn, int? sepCachId, int? sepFiscalYearRef, DateTime? fDate, DateTime? tDATE, int? docNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, bool? sendPreOrderToAcc, bool? sendOrderToAcc, string appType, ObjectParameter errorMessage, int? sepUserId, bool? sendPordPayToAcc, bool? sendOrdPayToAcc, int? wHId, int? wHIdI, int? sepStockId, int? sepDestinationStockId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter2 = (sepInventoryType.HasValue ? new ObjectParameter("SepInventoryType", sepInventoryType) : new ObjectParameter("SepInventoryType", typeof(int)));
		ObjectParameter objectParameter3 = (sepDocType.HasValue ? new ObjectParameter("SepDocType", sepDocType) : new ObjectParameter("SepDocType", typeof(int)));
		ObjectParameter objectParameter4 = (sepInvIsReturn.HasValue ? new ObjectParameter("SepInvIsReturn", sepInvIsReturn) : new ObjectParameter("SepInvIsReturn", typeof(bool)));
		ObjectParameter objectParameter5 = (sepCachId.HasValue ? new ObjectParameter("SepCachId", sepCachId) : new ObjectParameter("SepCachId", typeof(int)));
		ObjectParameter objectParameter6 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter7 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter9 = (docNumber.HasValue ? new ObjectParameter("DocNumber", docNumber) : new ObjectParameter("DocNumber", typeof(int)));
		ObjectParameter objectParameter10 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter11 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter12 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (sendPreOrderToAcc.HasValue ? new ObjectParameter("SendPreOrderToAcc", sendPreOrderToAcc) : new ObjectParameter("SendPreOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter15 = (sendOrderToAcc.HasValue ? new ObjectParameter("SendOrderToAcc", sendOrderToAcc) : new ObjectParameter("SendOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter18 = (sendPordPayToAcc.HasValue ? new ObjectParameter("SendPordPayToAcc", sendPordPayToAcc) : new ObjectParameter("SendPordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter19 = (sendOrdPayToAcc.HasValue ? new ObjectParameter("SendOrdPayToAcc", sendOrdPayToAcc) : new ObjectParameter("SendOrdPayToAcc", typeof(bool)));
		ObjectParameter objectParameter20 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter21 = (wHIdI.HasValue ? new ObjectParameter("WHIdI", wHIdI) : new ObjectParameter("WHIdI", typeof(int)));
		ObjectParameter objectParameter22 = (sepStockId.HasValue ? new ObjectParameter("SepStockId", sepStockId) : new ObjectParameter("SepStockId", typeof(int)));
		ObjectParameter objectParameter23 = (sepDestinationStockId.HasValue ? new ObjectParameter("SepDestinationStockId", sepDestinationStockId) : new ObjectParameter("SepDestinationStockId", typeof(int)));
		ObjectParameter objectParameter24 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSExportDoc", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, errorMessage, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24);
	}

	public virtual int CRMspLkSepWSExportPreOrder(DateTime? fDate, DateTime? tDATE, long? pordNumber, string selectedIds, int? sepFiscalYearRef, int? pageNumber, int? pageSize, int? userId, string appType, ObjectParameter errorMessage, int? sepUserId, bool? sendPordPayToAcc, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter4 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter5 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter11 = (sendPordPayToAcc.HasValue ? new ObjectParameter("SendPordPayToAcc", sendPordPayToAcc) : new ObjectParameter("SendPordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSExportPreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10, objectParameter11, objectParameter12);
	}

	public virtual int CRMspLkSepWSExportProduct(int? prdPriceGroupId, DateTime? fDate, DateTime? tDATE, string value, int? firstGroupId, int? secondGroupId, string selectedIds, int? pageNumber, int? pageSize, int? userId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage, int? linkAccSettingDBId, bool? sepCanChangeInvoiceFee, bool? sepCanChangeInvoiceDiscount)
	{
		ObjectParameter objectParameter = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter5 = (firstGroupId.HasValue ? new ObjectParameter("FirstGroupId", firstGroupId) : new ObjectParameter("FirstGroupId", typeof(int)));
		ObjectParameter objectParameter6 = (secondGroupId.HasValue ? new ObjectParameter("SecondGroupId", secondGroupId) : new ObjectParameter("SecondGroupId", typeof(int)));
		ObjectParameter objectParameter7 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter15 = (sepCanChangeInvoiceFee.HasValue ? new ObjectParameter("SepCanChangeInvoiceFee", sepCanChangeInvoiceFee) : new ObjectParameter("SepCanChangeInvoiceFee", typeof(bool)));
		ObjectParameter objectParameter16 = (sepCanChangeInvoiceDiscount.HasValue ? new ObjectParameter("SepCanChangeInvoiceDiscount", sepCanChangeInvoiceDiscount) : new ObjectParameter("SepCanChangeInvoiceDiscount", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSExportProduct", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, errorMessage, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual int CRMspLkSepWSImportBuyOrder(int? buyOrderOprId, int? bordpayTypeId, int? whId, DateTime? fDate, DateTime? tDATE, int? bordNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? bordReferUserId, bool? isUsedCmpReferUserId, int? crmFPId, bool? addBordPayment, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderOprId.HasValue ? new ObjectParameter("BuyOrderOprId", buyOrderOprId) : new ObjectParameter("BuyOrderOprId", typeof(int)));
		ObjectParameter objectParameter2 = (bordpayTypeId.HasValue ? new ObjectParameter("BordpayTypeId", bordpayTypeId) : new ObjectParameter("BordpayTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter4 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter6 = (bordNumber.HasValue ? new ObjectParameter("BordNumber", bordNumber) : new ObjectParameter("BordNumber", typeof(int)));
		ObjectParameter objectParameter7 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter17 = (bordReferUserId.HasValue ? new ObjectParameter("bordReferUserId", bordReferUserId) : new ObjectParameter("bordReferUserId", typeof(int)));
		ObjectParameter objectParameter18 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter19 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter20 = (addBordPayment.HasValue ? new ObjectParameter("AddBordPayment", addBordPayment) : new ObjectParameter("AddBordPayment", typeof(bool)));
		ObjectParameter objectParameter21 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSImportBuyOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, errorMessage, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21);
	}

	public virtual int CRMspLkSepWSImportDoc(int? sepDocType, int? sepInventoryType, bool? sepInvIsReturn, int? docOprId, DateTime? fDate, DateTime? tDATE, int? docNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? referUserId, bool? isUsedCmpReferUserId, int? crmFPId, bool? addOrderFromAcc, bool? addBordPayment, int? sepStockId, int? sepDestinationStockId, int? wHId, int? wHIdI, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepDocType.HasValue ? new ObjectParameter("SepDocType", sepDocType) : new ObjectParameter("SepDocType", typeof(int)));
		ObjectParameter objectParameter2 = (sepInventoryType.HasValue ? new ObjectParameter("SepInventoryType", sepInventoryType) : new ObjectParameter("SepInventoryType", typeof(int)));
		ObjectParameter objectParameter3 = (sepInvIsReturn.HasValue ? new ObjectParameter("SepInvIsReturn", sepInvIsReturn) : new ObjectParameter("SepInvIsReturn", typeof(bool)));
		ObjectParameter objectParameter4 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter5 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter7 = (docNumber.HasValue ? new ObjectParameter("DocNumber", docNumber) : new ObjectParameter("DocNumber", typeof(int)));
		ObjectParameter objectParameter8 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter9 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter10 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter13 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter19 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter20 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter21 = (addOrderFromAcc.HasValue ? new ObjectParameter("AddOrderFromAcc", addOrderFromAcc) : new ObjectParameter("AddOrderFromAcc", typeof(bool)));
		ObjectParameter objectParameter22 = (addBordPayment.HasValue ? new ObjectParameter("AddBordPayment", addBordPayment) : new ObjectParameter("AddBordPayment", typeof(bool)));
		ObjectParameter objectParameter23 = (sepStockId.HasValue ? new ObjectParameter("SepStockId", sepStockId) : new ObjectParameter("SepStockId", typeof(int)));
		ObjectParameter objectParameter24 = (sepDestinationStockId.HasValue ? new ObjectParameter("SepDestinationStockId", sepDestinationStockId) : new ObjectParameter("SepDestinationStockId", typeof(int)));
		ObjectParameter objectParameter25 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter26 = (wHIdI.HasValue ? new ObjectParameter("WHIdI", wHIdI) : new ObjectParameter("WHIdI", typeof(int)));
		ObjectParameter objectParameter27 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSImportDoc", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, errorMessage, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27);
	}

	public virtual int CRMspLkSepWSImportOrder(int? sepOrdType, int? sepSaleTypeId, int? orderOprId, DateTime? fDate, DateTime? tDATE, int? ordNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? ordReferUserId, bool? isInsertPayAccordingPayRemain, bool? getPreOrderFromAcc, bool? isUsedCmpReferUserId, int? crmFPId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepOrdType.HasValue ? new ObjectParameter("SepOrdType", sepOrdType) : new ObjectParameter("SepOrdType", typeof(int)));
		ObjectParameter objectParameter2 = (sepSaleTypeId.HasValue ? new ObjectParameter("SepSaleTypeId", sepSaleTypeId) : new ObjectParameter("SepSaleTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter4 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter6 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(int)));
		ObjectParameter objectParameter7 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter17 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter18 = (isInsertPayAccordingPayRemain.HasValue ? new ObjectParameter("IsInsertPayAccordingPayRemain", isInsertPayAccordingPayRemain) : new ObjectParameter("IsInsertPayAccordingPayRemain", typeof(bool)));
		ObjectParameter objectParameter19 = (getPreOrderFromAcc.HasValue ? new ObjectParameter("GetPreOrderFromAcc", getPreOrderFromAcc) : new ObjectParameter("GetPreOrderFromAcc", typeof(bool)));
		ObjectParameter objectParameter20 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter21 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter22 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSImportOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, errorMessage, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22);
	}

	public virtual int CRMspLkSepWSImportPreOrder(int? sepSaleTypeId, int? preOrderOprId, DateTime? fDate, DateTime? tDATE, int? pordNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? pordReferUserId, bool? isUsedCmpReferUserId, int? crmFPId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepSaleTypeId.HasValue ? new ObjectParameter("SepSaleTypeId", sepSaleTypeId) : new ObjectParameter("SepSaleTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (preOrderOprId.HasValue ? new ObjectParameter("PreOrderOprId", preOrderOprId) : new ObjectParameter("PreOrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(int)));
		ObjectParameter objectParameter6 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter11 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (pordReferUserId.HasValue ? new ObjectParameter("pordReferUserId", pordReferUserId) : new ObjectParameter("pordReferUserId", typeof(int)));
		ObjectParameter objectParameter17 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter18 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter19 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSImportPreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, errorMessage, objectParameter16, objectParameter17, objectParameter18, objectParameter19);
	}

	public virtual int CRMspLkSepWSImportProduct(int? prdGroupId, int? prdPriceGroupId, DateTime? fDate, DateTime? tDATE, string value, string selectedIds, int? pageNumber, int? pageSize, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, string sepSaleTypes, string fromPrdCode, string toPrdCode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter6 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter11 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter16 = ((sepSaleTypes != null) ? new ObjectParameter("SepSaleTypes", sepSaleTypes) : new ObjectParameter("SepSaleTypes", typeof(string)));
		ObjectParameter objectParameter17 = ((fromPrdCode != null) ? new ObjectParameter("FromPrdCode", fromPrdCode) : new ObjectParameter("FromPrdCode", typeof(string)));
		ObjectParameter objectParameter18 = ((toPrdCode != null) ? new ObjectParameter("ToPrdCode", toPrdCode) : new ObjectParameter("ToPrdCode", typeof(string)));
		ObjectParameter objectParameter19 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSImportProduct", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, errorMessage, objectParameter16, objectParameter17, objectParameter18, objectParameter19);
	}

	public virtual int CRMspLkSepWSInsertUpdateBuyOrderPayment(int? buyOrderPaymentId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderPaymentId.HasValue ? new ObjectParameter("BuyOrderPaymentId", buyOrderPaymentId) : new ObjectParameter("BuyOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateBuyOrderPayment", objectParameter, objectParameter2, objectParameter3, objectParameter4, insertedId, insertedNumber, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdateBuyOrderPaymentsAll(int? buyOrderId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateBuyOrderPaymentsAll", objectParameter, objectParameter2, objectParameter3, objectParameter4, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdateFinancialPeriodFromSep(int? sepFiscalYearId, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedFPId, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepFiscalYearId.HasValue ? new ObjectParameter("SepFiscalYearId", sepFiscalYearId) : new ObjectParameter("SepFiscalYearId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateFinancialPeriodFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, insertedFPId, errorMessage, objectParameter8);
	}

	public virtual int CRMspLkSepWSInsertUpdateOrderPayment(int? orderPaymentId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateOrderPayment", objectParameter, objectParameter2, objectParameter3, objectParameter4, insertedId, insertedNumber, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdateOrderPaymentsAll(int? orderId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateOrderPaymentsAll", objectParameter, objectParameter2, objectParameter3, objectParameter4, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdatePreOrderPayment(int? preOrderPaymentId, int? crmUserId, int? sepFiscalYearRef, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdatePreOrderPayment", objectParameter, objectParameter2, objectParameter3, objectParameter4, insertedId, insertedNumber, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdatePreOrderPaymentsAll(int? preOrderId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdatePreOrderPaymentsAll", objectParameter, objectParameter2, objectParameter3, objectParameter4, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdateProduct(int? productId, int? prdPriceGroupId, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter accPrdCode, ObjectParameter errorMessage, int? linkAccSettingDBId, bool? sepCanChangeInvoiceFee, bool? sepCanChangeInvoiceDiscount, bool? useCrmPrdCode, bool? useCrmPrdCodeInError)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter6 = (sepCanChangeInvoiceFee.HasValue ? new ObjectParameter("SepCanChangeInvoiceFee", sepCanChangeInvoiceFee) : new ObjectParameter("SepCanChangeInvoiceFee", typeof(bool)));
		ObjectParameter objectParameter7 = (sepCanChangeInvoiceDiscount.HasValue ? new ObjectParameter("SepCanChangeInvoiceDiscount", sepCanChangeInvoiceDiscount) : new ObjectParameter("SepCanChangeInvoiceDiscount", typeof(bool)));
		ObjectParameter objectParameter8 = (useCrmPrdCode.HasValue ? new ObjectParameter("UseCrmPrdCode", useCrmPrdCode) : new ObjectParameter("UseCrmPrdCode", typeof(bool)));
		ObjectParameter objectParameter9 = (useCrmPrdCodeInError.HasValue ? new ObjectParameter("UseCrmPrdCodeInError", useCrmPrdCodeInError) : new ObjectParameter("UseCrmPrdCodeInError", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateProduct", objectParameter, objectParameter2, objectParameter3, objectParameter4, insertedId, accPrdCode, errorMessage, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSInsertUpdateProductFromSep(int? sepItemId, int? prdGroupId, int? prdPriceGroupId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedPrdId, ObjectParameter errorMessage, string sepSaleTypes, int? linkAccSettingDBId, int? centerId, bool? canDupPrdCode, bool? useSepPrdCode, bool? useSepPrdCodeInError)
	{
		ObjectParameter objectParameter = (sepItemId.HasValue ? new ObjectParameter("SepItemId", sepItemId) : new ObjectParameter("SepItemId", typeof(int)));
		ObjectParameter objectParameter2 = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = ((sepSaleTypes != null) ? new ObjectParameter("SepSaleTypes", sepSaleTypes) : new ObjectParameter("SepSaleTypes", typeof(string)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter14 = (canDupPrdCode.HasValue ? new ObjectParameter("CanDupPrdCode", canDupPrdCode) : new ObjectParameter("CanDupPrdCode", typeof(bool)));
		ObjectParameter objectParameter15 = (useSepPrdCode.HasValue ? new ObjectParameter("UseSepPrdCode", useSepPrdCode) : new ObjectParameter("UseSepPrdCode", typeof(bool)));
		ObjectParameter objectParameter16 = (useSepPrdCodeInError.HasValue ? new ObjectParameter("UseSepPrdCodeInError", useSepPrdCodeInError) : new ObjectParameter("UseSepPrdCodeInError", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateProductFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, insertedPrdId, errorMessage, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual int CRMspLkSepWSInsertUpdateProductUnit(int? productUnitId, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (productUnitId.HasValue ? new ObjectParameter("ProductUnitId", productUnitId) : new ObjectParameter("ProductUnitId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateProductUnit", objectParameter, objectParameter2, objectParameter3, insertedId, errorMessage, objectParameter4);
	}

	public virtual int CRMspLkSepWSInsertUpdateProductUnitFromSep(int? sepUnitId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedUnitId, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepUnitId.HasValue ? new ObjectParameter("SepUnitId", sepUnitId) : new ObjectParameter("SepUnitId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateProductUnitFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, insertedUnitId, errorMessage, objectParameter9);
	}

	public virtual int CRMspLkSepWSInsertUpdateReturnedOrderPayment(int? orderPaymentId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateReturnedOrderPayment", objectParameter, objectParameter2, objectParameter3, objectParameter4, insertedId, insertedNumber, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdateReturnedOrderPaymentsAll(int? orderId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateReturnedOrderPaymentsAll", objectParameter, objectParameter2, objectParameter3, objectParameter4, errorMessage, objectParameter5);
	}

	public virtual int CRMspLkSepWSInsertUpdateWareHouse(int? whId, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter accWhCode, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateWareHouse", objectParameter, objectParameter2, objectParameter3, insertedId, accWhCode, errorMessage);
	}

	public virtual int CRMspLkSepWSInsertUpdateWareHouseFromSep(int? sepStockId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedWhId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (sepStockId.HasValue ? new ObjectParameter("SepStockId", sepStockId) : new ObjectParameter("SepStockId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateWareHouseFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, insertedWhId, errorMessage);
	}

	public virtual int CRMspLkSepWSIssueBuyOrder(int? buyOrderId, int? sepCachId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter buyOrderNumebr, ObjectParameter errorMessage, int? sepUserId, bool? sendBordPayToAcc, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepCachId.HasValue ? new ObjectParameter("SepCachId", sepCachId) : new ObjectParameter("SepCachId", typeof(int)));
		ObjectParameter objectParameter3 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter6 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter7 = (sendBordPayToAcc.HasValue ? new ObjectParameter("SendBordPayToAcc", sendBordPayToAcc) : new ObjectParameter("SendBordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter8 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueBuyOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, insertedId, buyOrderNumebr, errorMessage, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual int CRMspLkSepWSIssueBuyOrderFromSep(int? sepInvPuchInvoiceId, int? buyOrderOprId, int? bordpayTypeId, int? whId, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedBordId, ObjectParameter errorMessage, int? bordReferUserId, bool? isUsedCmpReferUserId, int? crmFPId, bool? addPayment, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (sepInvPuchInvoiceId.HasValue ? new ObjectParameter("SepInvPuchInvoiceId", sepInvPuchInvoiceId) : new ObjectParameter("SepInvPuchInvoiceId", typeof(int)));
		ObjectParameter objectParameter2 = (buyOrderOprId.HasValue ? new ObjectParameter("BuyOrderOprId", buyOrderOprId) : new ObjectParameter("BuyOrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (bordpayTypeId.HasValue ? new ObjectParameter("BordpayTypeId", bordpayTypeId) : new ObjectParameter("BordpayTypeId", typeof(int)));
		ObjectParameter objectParameter4 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (bordReferUserId.HasValue ? new ObjectParameter("bordReferUserId", bordReferUserId) : new ObjectParameter("bordReferUserId", typeof(int)));
		ObjectParameter objectParameter12 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter13 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter14 = (addPayment.HasValue ? new ObjectParameter("AddPayment", addPayment) : new ObjectParameter("AddPayment", typeof(bool)));
		ObjectParameter objectParameter15 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter16 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueBuyOrderFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, insertedBordId, errorMessage, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual int CRMspLkSepWSIssueDoc(int? docId, int? sepInventoryType, int? sepDocType, bool? sendPreOrderToAcc, bool? sendOrderToAcc, bool? sepInvIsReturn, int? sepCachId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter docNumebr, ObjectParameter errorMessage, int? sepUserId, bool? sendPordPayToAcc, bool? sendOrdPayToAcc, int? sepStockId, int? sepDestinationStockId, int? linkAccSettingDBId, bool? sendOrdCommToAcc)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (sepInventoryType.HasValue ? new ObjectParameter("SepInventoryType", sepInventoryType) : new ObjectParameter("SepInventoryType", typeof(int)));
		ObjectParameter objectParameter3 = (sepDocType.HasValue ? new ObjectParameter("SepDocType", sepDocType) : new ObjectParameter("SepDocType", typeof(int)));
		ObjectParameter objectParameter4 = (sendPreOrderToAcc.HasValue ? new ObjectParameter("SendPreOrderToAcc", sendPreOrderToAcc) : new ObjectParameter("SendPreOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter5 = (sendOrderToAcc.HasValue ? new ObjectParameter("SendOrderToAcc", sendOrderToAcc) : new ObjectParameter("SendOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter6 = (sepInvIsReturn.HasValue ? new ObjectParameter("SepInvIsReturn", sepInvIsReturn) : new ObjectParameter("SepInvIsReturn", typeof(bool)));
		ObjectParameter objectParameter7 = (sepCachId.HasValue ? new ObjectParameter("SepCachId", sepCachId) : new ObjectParameter("SepCachId", typeof(int)));
		ObjectParameter objectParameter8 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter9 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter12 = (sendPordPayToAcc.HasValue ? new ObjectParameter("SendPordPayToAcc", sendPordPayToAcc) : new ObjectParameter("SendPordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter13 = (sendOrdPayToAcc.HasValue ? new ObjectParameter("SendOrdPayToAcc", sendOrdPayToAcc) : new ObjectParameter("SendOrdPayToAcc", typeof(bool)));
		ObjectParameter objectParameter14 = (sepStockId.HasValue ? new ObjectParameter("SepStockId", sepStockId) : new ObjectParameter("SepStockId", typeof(int)));
		ObjectParameter objectParameter15 = (sepDestinationStockId.HasValue ? new ObjectParameter("SepDestinationStockId", sepDestinationStockId) : new ObjectParameter("SepDestinationStockId", typeof(int)));
		ObjectParameter objectParameter16 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter17 = (sendOrdCommToAcc.HasValue ? new ObjectParameter("SendOrdCommToAcc", sendOrdCommToAcc) : new ObjectParameter("SendOrdCommToAcc", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueDoc", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, insertedId, docNumebr, errorMessage, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17);
	}

	public virtual int CRMspLkSepWSIssueDocFromSep(int? sepInventoryId, int? sepDocType, int? docOprId, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedDocId, ObjectParameter errorMessage, int? referUserId, bool? isUsedCmpReferUserId, int? crmFPId, bool? addOrderFromAcc, bool? addBordPayment, int? wHId, int? wHIdI, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (sepInventoryId.HasValue ? new ObjectParameter("SepInventoryId", sepInventoryId) : new ObjectParameter("SepInventoryId", typeof(int)));
		ObjectParameter objectParameter2 = (sepDocType.HasValue ? new ObjectParameter("SepDocType", sepDocType) : new ObjectParameter("SepDocType", typeof(int)));
		ObjectParameter objectParameter3 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter11 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter12 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter13 = (addOrderFromAcc.HasValue ? new ObjectParameter("AddOrderFromAcc", addOrderFromAcc) : new ObjectParameter("AddOrderFromAcc", typeof(bool)));
		ObjectParameter objectParameter14 = (addBordPayment.HasValue ? new ObjectParameter("AddBordPayment", addBordPayment) : new ObjectParameter("AddBordPayment", typeof(bool)));
		ObjectParameter objectParameter15 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter16 = (wHIdI.HasValue ? new ObjectParameter("WHIdI", wHIdI) : new ObjectParameter("WHIdI", typeof(int)));
		ObjectParameter objectParameter17 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter18 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueDocFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, insertedDocId, errorMessage, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18);
	}

	public virtual int CRMspLkSepWSIssueOrder(int? orderId, int? sepOrdType, int? sepFiscalYearRef, int? crmUserId, string appType, bool? sendPreOrderToAcc, ObjectParameter insertedId, ObjectParameter orderNumebr, ObjectParameter errorMessage, int? sepUserId, bool? sendPordPayToAcc, bool? sendOrdPayToAcc, int? linkAccSettingDBId, bool? sendDocToAcc, int? sepInventoryType, int? sepDocType, bool? sepInvIsReturn, bool? sendOrdCommToAcc)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepOrdType.HasValue ? new ObjectParameter("SepOrdType", sepOrdType) : new ObjectParameter("SepOrdType", typeof(int)));
		ObjectParameter objectParameter3 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter6 = (sendPreOrderToAcc.HasValue ? new ObjectParameter("SendPreOrderToAcc", sendPreOrderToAcc) : new ObjectParameter("SendPreOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter7 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter8 = (sendPordPayToAcc.HasValue ? new ObjectParameter("SendPordPayToAcc", sendPordPayToAcc) : new ObjectParameter("SendPordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter9 = (sendOrdPayToAcc.HasValue ? new ObjectParameter("SendOrdPayToAcc", sendOrdPayToAcc) : new ObjectParameter("SendOrdPayToAcc", typeof(bool)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter11 = (sendDocToAcc.HasValue ? new ObjectParameter("SendDocToAcc", sendDocToAcc) : new ObjectParameter("SendDocToAcc", typeof(bool)));
		ObjectParameter objectParameter12 = (sepInventoryType.HasValue ? new ObjectParameter("SepInventoryType", sepInventoryType) : new ObjectParameter("SepInventoryType", typeof(int)));
		ObjectParameter objectParameter13 = (sepDocType.HasValue ? new ObjectParameter("SepDocType", sepDocType) : new ObjectParameter("SepDocType", typeof(int)));
		ObjectParameter objectParameter14 = (sepInvIsReturn.HasValue ? new ObjectParameter("SepInvIsReturn", sepInvIsReturn) : new ObjectParameter("SepInvIsReturn", typeof(bool)));
		ObjectParameter objectParameter15 = (sendOrdCommToAcc.HasValue ? new ObjectParameter("SendOrdCommToAcc", sendOrdCommToAcc) : new ObjectParameter("SendOrdCommToAcc", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, insertedId, orderNumebr, errorMessage, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15);
	}

	public virtual int CRMspLkSepWSIssueOrderFromSep(int? sepInvoiceId, int? orderOprId, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedOrdId, ObjectParameter errorMessage, int? ordReferUserId, bool? getPreOrderFromAcc, bool? isUsedCmpReferUserId, int? crmFPId, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (sepInvoiceId.HasValue ? new ObjectParameter("SepInvoiceId", sepInvoiceId) : new ObjectParameter("SepInvoiceId", typeof(int)));
		ObjectParameter objectParameter2 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter10 = (getPreOrderFromAcc.HasValue ? new ObjectParameter("GetPreOrderFromAcc", getPreOrderFromAcc) : new ObjectParameter("GetPreOrderFromAcc", typeof(bool)));
		ObjectParameter objectParameter11 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter12 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter13 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueOrderFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, insertedOrdId, errorMessage, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14);
	}

	public virtual int CRMspLkSepWSIssuePreOrder(int? preOrderId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter preOrderNumber, ObjectParameter errorMessage, int? sepUserId, bool? sendPordPayToAcc, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter6 = (sendPordPayToAcc.HasValue ? new ObjectParameter("SendPordPayToAcc", sendPordPayToAcc) : new ObjectParameter("SendPordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter7 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssuePreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, insertedId, preOrderNumber, errorMessage, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual int CRMspLkSepWSIssuePreOrderFromSep(int? sepQuotationId, int? preOrderOprId, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedPordId, ObjectParameter errorMessage, int? pordReferUserId, bool? isUsedCmpReferUserId, int? crmFPId, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (sepQuotationId.HasValue ? new ObjectParameter("SepQuotationId", sepQuotationId) : new ObjectParameter("SepQuotationId", typeof(int)));
		ObjectParameter objectParameter2 = (preOrderOprId.HasValue ? new ObjectParameter("PreOrderOprId", preOrderOprId) : new ObjectParameter("PreOrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (pordReferUserId.HasValue ? new ObjectParameter("pordReferUserId", pordReferUserId) : new ObjectParameter("pordReferUserId", typeof(int)));
		ObjectParameter objectParameter10 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter11 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssuePreOrderFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, insertedPordId, errorMessage, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual int CRMspLkSepWSIssueReturnedOrder(int? orderId, int? sepOrdType, int? sepFiscalYearRef, int? crmUserId, string appType, bool? sendPreOrderToAcc, ObjectParameter insertedId, ObjectParameter orderNumebr, ObjectParameter errorMessage, int? sepUserId, bool? sendPordPayToAcc, bool? sendOrdPayToAcc, int? linkAccSettingDBId, bool? sendDocToAcc, int? sepInventoryType, int? sepDocType, bool? sepInvIsReturn, bool? sendOrdCommToAcc)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepOrdType.HasValue ? new ObjectParameter("SepOrdType", sepOrdType) : new ObjectParameter("SepOrdType", typeof(int)));
		ObjectParameter objectParameter3 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter6 = (sendPreOrderToAcc.HasValue ? new ObjectParameter("SendPreOrderToAcc", sendPreOrderToAcc) : new ObjectParameter("SendPreOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter7 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter8 = (sendPordPayToAcc.HasValue ? new ObjectParameter("SendPordPayToAcc", sendPordPayToAcc) : new ObjectParameter("SendPordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter9 = (sendOrdPayToAcc.HasValue ? new ObjectParameter("SendOrdPayToAcc", sendOrdPayToAcc) : new ObjectParameter("SendOrdPayToAcc", typeof(bool)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter11 = (sendDocToAcc.HasValue ? new ObjectParameter("SendDocToAcc", sendDocToAcc) : new ObjectParameter("SendDocToAcc", typeof(bool)));
		ObjectParameter objectParameter12 = (sepInventoryType.HasValue ? new ObjectParameter("SepInventoryType", sepInventoryType) : new ObjectParameter("SepInventoryType", typeof(int)));
		ObjectParameter objectParameter13 = (sepDocType.HasValue ? new ObjectParameter("SepDocType", sepDocType) : new ObjectParameter("SepDocType", typeof(int)));
		ObjectParameter objectParameter14 = (sepInvIsReturn.HasValue ? new ObjectParameter("SepInvIsReturn", sepInvIsReturn) : new ObjectParameter("SepInvIsReturn", typeof(bool)));
		ObjectParameter objectParameter15 = (sendOrdCommToAcc.HasValue ? new ObjectParameter("SendOrdCommToAcc", sendOrdCommToAcc) : new ObjectParameter("SendOrdCommToAcc", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueReturnedOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, insertedId, orderNumebr, errorMessage, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15);
	}

	public virtual int CRMspLkSepWSIssueReturnedOrderFromSep(int? sepInvoiceId, int? orderOprId, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedOrdId, ObjectParameter errorMessage, int? ordReferUserId, bool? getPreOrderFromAcc, bool? isUsedCmpReferUserId, int? crmFPId, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (sepInvoiceId.HasValue ? new ObjectParameter("SepInvoiceId", sepInvoiceId) : new ObjectParameter("SepInvoiceId", typeof(int)));
		ObjectParameter objectParameter2 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter10 = (getPreOrderFromAcc.HasValue ? new ObjectParameter("GetPreOrderFromAcc", getPreOrderFromAcc) : new ObjectParameter("GetPreOrderFromAcc", typeof(bool)));
		ObjectParameter objectParameter11 = (isUsedCmpReferUserId.HasValue ? new ObjectParameter("IsUsedCmpReferUserId", isUsedCmpReferUserId) : new ObjectParameter("IsUsedCmpReferUserId", typeof(bool)));
		ObjectParameter objectParameter12 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter13 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSIssueReturnedOrderFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, insertedOrdId, errorMessage, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14);
	}

	public virtual ObjectResult<CRMspLkSepWSSelectBuyOrder_Result> CRMspLkSepWSSelectBuyOrder(int? userId, int? buyOrderOprId, DateTime? fDate, DateTime? tDATE, long? bordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (buyOrderOprId.HasValue ? new ObjectParameter("BuyOrderOprId", buyOrderOprId) : new ObjectParameter("BuyOrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (bordNumber.HasValue ? new ObjectParameter("BordNumber", bordNumber) : new ObjectParameter("BordNumber", typeof(long)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectBuyOrder_Result>("CRMspLkSepWSSelectBuyOrder", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11
		});
	}

	public virtual ObjectResult<CRMspLkSepWSSelectBuyOrderFromSep_Result> CRMspLkSepWSSelectBuyOrderFromSep(DateTime? fDate, DateTime? tDATE, int? bordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = (bordNumber.HasValue ? new ObjectParameter("BordNumber", bordNumber) : new ObjectParameter("BordNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectBuyOrderFromSep_Result>("CRMspLkSepWSSelectBuyOrderFromSep", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectDoc_Result> CRMspLkSepWSSelectDoc(int? userId, int? docOprId, DateTime? fDate, DateTime? tDATE, int? docNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? wHId, int? wHIdI, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (docNumber.HasValue ? new ObjectParameter("DocNumber", docNumber) : new ObjectParameter("DocNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter11 = (wHIdI.HasValue ? new ObjectParameter("WHIdI", wHIdI) : new ObjectParameter("WHIdI", typeof(int)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectDoc_Result>("CRMspLkSepWSSelectDoc", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<CRMspLkSepWSSelectDocFromSep_Result> CRMspLkSepWSSelectDocFromSep(int? sepDocType, int? sepInventoryType, bool? sepInvIsReturn, DateTime? fDate, DateTime? tDATE, int? docNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string sepStockId, string sepDestinationStockId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepDocType.HasValue ? new ObjectParameter("SepDocType", sepDocType) : new ObjectParameter("SepDocType", typeof(int)));
		ObjectParameter objectParameter2 = (sepInventoryType.HasValue ? new ObjectParameter("SepInventoryType", sepInventoryType) : new ObjectParameter("SepInventoryType", typeof(int)));
		ObjectParameter objectParameter3 = (sepInvIsReturn.HasValue ? new ObjectParameter("SepInvIsReturn", sepInvIsReturn) : new ObjectParameter("SepInvIsReturn", typeof(bool)));
		ObjectParameter objectParameter4 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter6 = (docNumber.HasValue ? new ObjectParameter("DocNumber", docNumber) : new ObjectParameter("DocNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = ((sepStockId != null) ? new ObjectParameter("SepStockId", sepStockId) : new ObjectParameter("SepStockId", typeof(string)));
		ObjectParameter objectParameter12 = ((sepDestinationStockId != null) ? new ObjectParameter("SepDestinationStockId", sepDestinationStockId) : new ObjectParameter("SepDestinationStockId", typeof(string)));
		ObjectParameter objectParameter13 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectDocFromSep_Result>("CRMspLkSepWSSelectDocFromSep", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<CRMspLkSepWSSelectOrder_Result> CRMspLkSepWSSelectOrder(int? userId, DateTime? fDate, DateTime? tDATE, long? ordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? orderOprId, int? mode, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter10 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter11 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectOrder_Result>("CRMspLkSepWSSelectOrder", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<CRMspLkSepWSSelectOrderFromSep_Result> CRMspLkSepWSSelectOrderFromSep(int? sepOrdType, int? sepSaleTypeId, DateTime? fDate, DateTime? tDATE, int? ordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepOrdType.HasValue ? new ObjectParameter("SepOrdType", sepOrdType) : new ObjectParameter("SepOrdType", typeof(int)));
		ObjectParameter objectParameter2 = (sepSaleTypeId.HasValue ? new ObjectParameter("SepSaleTypeId", sepSaleTypeId) : new ObjectParameter("SepSaleTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectOrderFromSep_Result>("CRMspLkSepWSSelectOrderFromSep", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectPreOrder_Result> CRMspLkSepWSSelectPreOrder(int? userId, DateTime? fDate, DateTime? tDATE, long? pordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectPreOrder_Result>("CRMspLkSepWSSelectPreOrder", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectPreOrderFromSep_Result> CRMspLkSepWSSelectPreOrderFromSep(int? sepSaleTypeId, DateTime? fDate, DateTime? tDATE, int? pordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepSaleTypeId.HasValue ? new ObjectParameter("SepSaleTypeId", sepSaleTypeId) : new ObjectParameter("SepSaleTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectPreOrderFromSep_Result>("CRMspLkSepWSSelectPreOrderFromSep", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectProduct_Result> CRMspLkSepWSSelectProduct(DateTime? fDate, DateTime? tDATE, string value, int? firstGroupId, int? secondGroupId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter4 = (firstGroupId.HasValue ? new ObjectParameter("FirstGroupId", firstGroupId) : new ObjectParameter("FirstGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (secondGroupId.HasValue ? new ObjectParameter("SecondGroupId", secondGroupId) : new ObjectParameter("SecondGroupId", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectProduct_Result>("CRMspLkSepWSSelectProduct", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectProductFromSep_Result> CRMspLkSepWSSelectProductFromSep(DateTime? fDate, DateTime? tDATE, string value, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string fromPrdCode, string toPrdCode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter4 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = ((fromPrdCode != null) ? new ObjectParameter("FromPrdCode", fromPrdCode) : new ObjectParameter("FromPrdCode", typeof(string)));
		ObjectParameter objectParameter9 = ((toPrdCode != null) ? new ObjectParameter("ToPrdCode", toPrdCode) : new ObjectParameter("ToPrdCode", typeof(string)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectProductFromSep_Result>("CRMspLkSepWSSelectProductFromSep", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual int CRMspLkTarazInsertLinkAccErrorLogs(string scriptName, string partTitle, string errorMessage, int? userId, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = ((scriptName != null) ? new ObjectParameter("ScriptName", scriptName) : new ObjectParameter("ScriptName", typeof(string)));
		ObjectParameter objectParameter2 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		ObjectParameter objectParameter3 = ((errorMessage != null) ? new ObjectParameter("ErrorMessage", errorMessage) : new ObjectParameter("ErrorMessage", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazInsertLinkAccErrorLogs", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual int CRMspLkTarazInsertUpdateUsersFromTaraz(string userJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((userJson != null) ? new ObjectParameter("UserJson", userJson) : new ObjectParameter("UserJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazInsertUpdateUsersFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage, objectParameter9);
	}

	public virtual int CRMspLkTarazWSInsertUpdateDeliveryTermFromTaraz(string deliveryTermJson, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((deliveryTermJson != null) ? new ObjectParameter("DeliveryTermJson", deliveryTermJson) : new ObjectParameter("DeliveryTermJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdateDeliveryTermFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkTarazWSInsertUpdateOrderOprFromTaraz(string orderOprJson, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((orderOprJson != null) ? new ObjectParameter("OrderOprJson", orderOprJson) : new ObjectParameter("OrderOprJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdateOrderOprFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkTarazWSInsertUpdateProductFromTaraz(long? tarazGoodsId, string tarazGoodsDesc, string tarazGoodsCode, string tarazBarCode, decimal? tarazPrice, long? tarazUnitId, string tarazUnitDesc, long? tarazStoreId, string tarazStoreName, string tarazStoreCode, DateTime? tarazGoodsCreateDate, string tarazGoodsCreateDatePersian, DateTime? tarazGoodsModifyDate, string tarazGoodsModifyDatePersian, string tarazGoodsLatinDesc, int? tarazGoodsMinQuantity, int? tarazGoodsMaxQuantity, DateTime? tarazUnitCreateDate, string tarazUnitCreateDatePersian, DateTime? tarazUnitModifyDate, string tarazUnitModifyDatePersian, int? prdFirstGroupId, int? prdSecondGroupId, int? prdPriceGroupId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedPrdId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (tarazGoodsId.HasValue ? new ObjectParameter("TarazGoodsId", tarazGoodsId) : new ObjectParameter("TarazGoodsId", typeof(long)));
		ObjectParameter objectParameter2 = ((tarazGoodsDesc != null) ? new ObjectParameter("TarazGoodsDesc", tarazGoodsDesc) : new ObjectParameter("TarazGoodsDesc", typeof(string)));
		ObjectParameter objectParameter3 = ((tarazGoodsCode != null) ? new ObjectParameter("TarazGoodsCode", tarazGoodsCode) : new ObjectParameter("TarazGoodsCode", typeof(string)));
		ObjectParameter objectParameter4 = ((tarazBarCode != null) ? new ObjectParameter("TarazBarCode", tarazBarCode) : new ObjectParameter("TarazBarCode", typeof(string)));
		ObjectParameter objectParameter5 = (tarazPrice.HasValue ? new ObjectParameter("TarazPrice", tarazPrice) : new ObjectParameter("TarazPrice", typeof(decimal)));
		ObjectParameter objectParameter6 = (tarazUnitId.HasValue ? new ObjectParameter("TarazUnitId", tarazUnitId) : new ObjectParameter("TarazUnitId", typeof(long)));
		ObjectParameter objectParameter7 = ((tarazUnitDesc != null) ? new ObjectParameter("TarazUnitDesc", tarazUnitDesc) : new ObjectParameter("TarazUnitDesc", typeof(string)));
		ObjectParameter objectParameter8 = (tarazStoreId.HasValue ? new ObjectParameter("TarazStoreId", tarazStoreId) : new ObjectParameter("TarazStoreId", typeof(long)));
		ObjectParameter objectParameter9 = ((tarazStoreName != null) ? new ObjectParameter("TarazStoreName", tarazStoreName) : new ObjectParameter("TarazStoreName", typeof(string)));
		ObjectParameter objectParameter10 = ((tarazStoreCode != null) ? new ObjectParameter("TarazStoreCode", tarazStoreCode) : new ObjectParameter("TarazStoreCode", typeof(string)));
		ObjectParameter objectParameter11 = (tarazGoodsCreateDate.HasValue ? new ObjectParameter("TarazGoodsCreateDate", tarazGoodsCreateDate) : new ObjectParameter("TarazGoodsCreateDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((tarazGoodsCreateDatePersian != null) ? new ObjectParameter("TarazGoodsCreateDatePersian", tarazGoodsCreateDatePersian) : new ObjectParameter("TarazGoodsCreateDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = (tarazGoodsModifyDate.HasValue ? new ObjectParameter("TarazGoodsModifyDate", tarazGoodsModifyDate) : new ObjectParameter("TarazGoodsModifyDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((tarazGoodsModifyDatePersian != null) ? new ObjectParameter("TarazGoodsModifyDatePersian", tarazGoodsModifyDatePersian) : new ObjectParameter("TarazGoodsModifyDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((tarazGoodsLatinDesc != null) ? new ObjectParameter("TarazGoodsLatinDesc", tarazGoodsLatinDesc) : new ObjectParameter("TarazGoodsLatinDesc", typeof(string)));
		ObjectParameter objectParameter16 = (tarazGoodsMinQuantity.HasValue ? new ObjectParameter("TarazGoodsMinQuantity", tarazGoodsMinQuantity) : new ObjectParameter("TarazGoodsMinQuantity", typeof(int)));
		ObjectParameter objectParameter17 = (tarazGoodsMaxQuantity.HasValue ? new ObjectParameter("TarazGoodsMaxQuantity", tarazGoodsMaxQuantity) : new ObjectParameter("TarazGoodsMaxQuantity", typeof(int)));
		ObjectParameter objectParameter18 = (tarazUnitCreateDate.HasValue ? new ObjectParameter("TarazUnitCreateDate", tarazUnitCreateDate) : new ObjectParameter("TarazUnitCreateDate", typeof(DateTime)));
		ObjectParameter objectParameter19 = ((tarazUnitCreateDatePersian != null) ? new ObjectParameter("TarazUnitCreateDatePersian", tarazUnitCreateDatePersian) : new ObjectParameter("TarazUnitCreateDatePersian", typeof(string)));
		ObjectParameter objectParameter20 = (tarazUnitModifyDate.HasValue ? new ObjectParameter("TarazUnitModifyDate", tarazUnitModifyDate) : new ObjectParameter("TarazUnitModifyDate", typeof(DateTime)));
		ObjectParameter objectParameter21 = ((tarazUnitModifyDatePersian != null) ? new ObjectParameter("TarazUnitModifyDatePersian", tarazUnitModifyDatePersian) : new ObjectParameter("TarazUnitModifyDatePersian", typeof(string)));
		ObjectParameter objectParameter22 = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter23 = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter24 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter25 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter26 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter27 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter28 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter29 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter30 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter31 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter32 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdateProductFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, insertedPrdId, errorMessage, objectParameter32);
	}

	public virtual int CRMspLkTarazWSInsertUpdateProductPriceGroupFromTaraz(string tarazPaymentWayJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((tarazPaymentWayJson != null) ? new ObjectParameter("TarazPaymentWayJson", tarazPaymentWayJson) : new ObjectParameter("TarazPaymentWayJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdateProductPriceGroupFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkTarazWSInsertUpdateProductUnitFromTaraz(long? tarazUnitId, string tarazUnitDesc, DateTime? tarazUnitCreateDate, string tarazUnitCreateDatePersian, DateTime? tarazUnitModifyDate, string tarazUnitModifyDatePersian, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedUnitId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (tarazUnitId.HasValue ? new ObjectParameter("TarazUnitId", tarazUnitId) : new ObjectParameter("TarazUnitId", typeof(long)));
		ObjectParameter objectParameter2 = ((tarazUnitDesc != null) ? new ObjectParameter("TarazUnitDesc", tarazUnitDesc) : new ObjectParameter("TarazUnitDesc", typeof(string)));
		ObjectParameter objectParameter3 = (tarazUnitCreateDate.HasValue ? new ObjectParameter("TarazUnitCreateDate", tarazUnitCreateDate) : new ObjectParameter("TarazUnitCreateDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((tarazUnitCreateDatePersian != null) ? new ObjectParameter("TarazUnitCreateDatePersian", tarazUnitCreateDatePersian) : new ObjectParameter("TarazUnitCreateDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (tarazUnitModifyDate.HasValue ? new ObjectParameter("TarazUnitModifyDate", tarazUnitModifyDate) : new ObjectParameter("TarazUnitModifyDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((tarazUnitModifyDatePersian != null) ? new ObjectParameter("TarazUnitModifyDatePersian", tarazUnitModifyDatePersian) : new ObjectParameter("TarazUnitModifyDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter9 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdateProductUnitFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, insertedUnitId, errorMessage);
	}

	public virtual int CRMspLkTarazWSInsertUpdateSaleCenterFromTaraz(string saleCenterJson, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((saleCenterJson != null) ? new ObjectParameter("SaleCenterJson", saleCenterJson) : new ObjectParameter("SaleCenterJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdateSaleCenterFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkTarazWSInsertUpdateWareHouseFromTaraz(long? tarazStoreId, string tarazStoreName, string tarazStoreCode, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedWhId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (tarazStoreId.HasValue ? new ObjectParameter("TarazStoreId", tarazStoreId) : new ObjectParameter("TarazStoreId", typeof(long)));
		ObjectParameter objectParameter2 = ((tarazStoreName != null) ? new ObjectParameter("TarazStoreName", tarazStoreName) : new ObjectParameter("TarazStoreName", typeof(string)));
		ObjectParameter objectParameter3 = ((tarazStoreCode != null) ? new ObjectParameter("TarazStoreCode", tarazStoreCode) : new ObjectParameter("TarazStoreCode", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdateWareHouseFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, insertedWhId, errorMessage, objectParameter11);
	}

	public virtual ObjectResult<CRMspLkTarazWSSelectOrder_Result> CRMspLkTarazWSSelectOrder(int? userId, DateTime? fDate, DateTime? tDATE, long? ordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkTarazWSSelectOrder_Result>("CRMspLkTarazWSSelectOrder", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspLkWSSelectOrder_Result> CRMspLkWSSelectOrder(int? userId, int? orderOprId, DateTime? fDate, DateTime? tDATE, long? ordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? mode, int? centerId, int? orderId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter12 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectOrder_Result>("CRMspLkWSSelectOrder", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<CRMspLkWSSelectPreOrder_Result> CRMspLkWSSelectPreOrder(int? oprId, int? userId, DateTime? fDate, DateTime? tDATE, long? pordNumber, int? languageID, int? defaultLanguageID, int? centerId, int? preOrderId)
	{
		ObjectParameter objectParameter = (oprId.HasValue ? new ObjectParameter("OprId", oprId) : new ObjectParameter("OprId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter9 = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectPreOrder_Result>("CRMspLkWSSelectPreOrder", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspSelectCompanyGroupsIIWithAccLinkField_Result> CRMspSelectCompanyGroupsIIWithAccLinkField(bool? withLinkAccCmpGroupIIIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccCmpGroupIIIdStr.HasValue ? new ObjectParameter("WithLinkAccCmpGroupIIIdStr", withLinkAccCmpGroupIIIdStr) : new ObjectParameter("WithLinkAccCmpGroupIIIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>("CRMspSelectCompanyGroupsIIWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectCompanyTypesWithAccLinkField_Result> CRMspSelectCompanyTypesWithAccLinkField(bool? withLinkAccCmpTypeIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccCmpTypeIdStr.HasValue ? new ObjectParameter("WithLinkAccCmpTypeIdStr", withLinkAccCmpTypeIdStr) : new ObjectParameter("WithLinkAccCmpTypeIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyTypesWithAccLinkField_Result>("CRMspSelectCompanyTypesWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectCompanyWithAccLinkField_Result> CRMspSelectCompanyWithAccLinkField(bool? withLinkAccCode, bool? withLinkAccCodeId, bool? withLinkCustomerId, bool? withLinkCustomerIdStr, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (withLinkAccCode.HasValue ? new ObjectParameter("WithLinkAccCode", withLinkAccCode) : new ObjectParameter("WithLinkAccCode", typeof(bool)));
		ObjectParameter objectParameter2 = (withLinkAccCodeId.HasValue ? new ObjectParameter("WithLinkAccCodeId", withLinkAccCodeId) : new ObjectParameter("WithLinkAccCodeId", typeof(bool)));
		ObjectParameter objectParameter3 = (withLinkCustomerId.HasValue ? new ObjectParameter("WithLinkCustomerId", withLinkCustomerId) : new ObjectParameter("WithLinkCustomerId", typeof(bool)));
		ObjectParameter objectParameter4 = (withLinkCustomerIdStr.HasValue ? new ObjectParameter("WithLinkCustomerIdStr", withLinkCustomerIdStr) : new ObjectParameter("WithLinkCustomerIdStr", typeof(bool)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyWithAccLinkField_Result>("CRMspSelectCompanyWithAccLinkField", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccHolooSetting_Result> CRMspSelectLinkAccHolooSetting(int? linkAccHolooSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccHolooSettingId.HasValue ? new ObjectParameter("LinkAccHolooSettingId", linkAccHolooSettingId) : new ObjectParameter("LinkAccHolooSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccHolooSetting_Result>("CRMspSelectLinkAccHolooSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccHolooSettingDetails_Result> CRMspSelectLinkAccHolooSettingDetails(int? linkAccHolooSettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccHolooSettingDetailId.HasValue ? new ObjectParameter("LinkAccHolooSettingDetailId", linkAccHolooSettingDetailId) : new ObjectParameter("LinkAccHolooSettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccHolooSettingDetails_Result>("CRMspSelectLinkAccHolooSettingDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccKyanSetting_Result> CRMspSelectLinkAccKyanSetting(int? linkAccKyanSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccKyanSettingId.HasValue ? new ObjectParameter("LinkAccKyanSettingId", linkAccKyanSettingId) : new ObjectParameter("LinkAccKyanSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccKyanSetting_Result>("CRMspSelectLinkAccKyanSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccNoAvSetting_Result> CRMspSelectLinkAccNoAvSetting(int? linkAccNoAvSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccNoAvSettingId.HasValue ? new ObjectParameter("LinkAccNoAvSettingId", linkAccNoAvSettingId) : new ObjectParameter("LinkAccNoAvSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccNoAvSetting_Result>("CRMspSelectLinkAccNoAvSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccNoAvSettingDetails_Result> CRMspSelectLinkAccNoAvSettingDetails(int? linkAccNoAvSettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccNoAvSettingDetailId.HasValue ? new ObjectParameter("LinkAccNoAvSettingDetailId", linkAccNoAvSettingDetailId) : new ObjectParameter("LinkAccNoAvSettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccNoAvSettingDetails_Result>("CRMspSelectLinkAccNoAvSettingDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccPayvastSetting_Result> CRMspSelectLinkAccPayvastSetting(int? linkAccPayvastSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccPayvastSettingId.HasValue ? new ObjectParameter("LinkAccPayvastSettingId", linkAccPayvastSettingId) : new ObjectParameter("LinkAccPayvastSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccPayvastSetting_Result>("CRMspSelectLinkAccPayvastSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
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

	public virtual ObjectResult<CRMspSelectLinkAccSettingDetails_Result> CRMspSelectLinkAccSettingDetails(int? linkAccSettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID, int? linkAccSystemId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (linkAccSettingDetailId.HasValue ? new ObjectParameter("LinkAccSettingDetailId", linkAccSettingDetailId) : new ObjectParameter("LinkAccSettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter7 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccSettingDetails_Result>("CRMspSelectLinkAccSettingDetails", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccShygunSetting_Result> CRMspSelectLinkAccShygunSetting(int? linkAccShygunSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccShygunSettingId.HasValue ? new ObjectParameter("LinkAccShygunSettingId", linkAccShygunSettingId) : new ObjectParameter("LinkAccShygunSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccShygunSetting_Result>("CRMspSelectLinkAccShygunSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccTarazSetting_Result> CRMspSelectLinkAccTarazSetting(int? linkAccTarazSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccTarazSettingId.HasValue ? new ObjectParameter("LinkAccTarazSettingId", linkAccTarazSettingId) : new ObjectParameter("LinkAccTarazSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccTarazSetting_Result>("CRMspSelectLinkAccTarazSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccTarazSettingDetails_Result> CRMspSelectLinkAccTarazSettingDetails(int? linkAccTarazSettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccTarazSettingDetailId.HasValue ? new ObjectParameter("LinkAccTarazSettingDetailId", linkAccTarazSettingDetailId) : new ObjectParameter("LinkAccTarazSettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccTarazSettingDetails_Result>("CRMspSelectLinkAccTarazSettingDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectUsersWithAccLinkField_Result> CRMspSelectUsersWithAccLinkField(bool? withLinkAccUserIdStr, bool? withLinkAccUserCode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccUserIdStr.HasValue ? new ObjectParameter("WithLinkAccUserIdStr", withLinkAccUserIdStr) : new ObjectParameter("WithLinkAccUserIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (withLinkAccUserCode.HasValue ? new ObjectParameter("WithLinkAccUserCode", withLinkAccUserCode) : new ObjectParameter("WithLinkAccUserCode", typeof(bool)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectUsersWithAccLinkField_Result>("CRMspSelectUsersWithAccLinkField", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspUpdateCompanyWithAccLinkField(int? companyId, int? cmpLinkAccCodeId, string cmpLinkAccCode, int? cmpLinkAccCustomerId, string cmpLinkAccCustomerIdStr, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, string cmpCode, string cmpLinkAccData)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (cmpLinkAccCodeId.HasValue ? new ObjectParameter("CmpLinkAccCodeId", cmpLinkAccCodeId) : new ObjectParameter("CmpLinkAccCodeId", typeof(int)));
		ObjectParameter objectParameter3 = ((cmpLinkAccCode != null) ? new ObjectParameter("CmpLinkAccCode", cmpLinkAccCode) : new ObjectParameter("CmpLinkAccCode", typeof(string)));
		ObjectParameter objectParameter4 = (cmpLinkAccCustomerId.HasValue ? new ObjectParameter("CmpLinkAccCustomerId", cmpLinkAccCustomerId) : new ObjectParameter("CmpLinkAccCustomerId", typeof(int)));
		ObjectParameter objectParameter5 = ((cmpLinkAccCustomerIdStr != null) ? new ObjectParameter("CmpLinkAccCustomerIdStr", cmpLinkAccCustomerIdStr) : new ObjectParameter("CmpLinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = ((cmpCode != null) ? new ObjectParameter("CmpCode", cmpCode) : new ObjectParameter("CmpCode", typeof(string)));
		ObjectParameter objectParameter13 = ((cmpLinkAccData != null) ? new ObjectParameter("cmpLinkAccData", cmpLinkAccData) : new ObjectParameter("cmpLinkAccData", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateCompanyWithAccLinkField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual int CRMspUpdateLinkAccHolooSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccHolooSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccHolooSettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccHolooSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual int CRMspUpdateLinkAccKyanSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccKyanSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccNoAvSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccNoAvSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccNoAvSettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccNoAvSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual int CRMspUpdateLinkAccPayvastSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccPayvastSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? mode)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual int CRMspUpdateLinkAccSettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual int CRMspUpdateLinkAccShygunSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccShygunSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccTarazSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccTarazSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccTarazSettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccTarazSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<WSspSelectDeliveryTermWithAccLinkField_Result> WSspSelectDeliveryTermWithAccLinkField(bool? withLinkAccDeliveryTermIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccDeliveryTermIdStr.HasValue ? new ObjectParameter("WithLinkAccDeliveryTermIdStr", withLinkAccDeliveryTermIdStr) : new ObjectParameter("WithLinkAccDeliveryTermIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectDeliveryTermWithAccLinkField_Result>("WSspSelectDeliveryTermWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectOrderOprWithAccLinkField_Result> WSspSelectOrderOprWithAccLinkField(bool? withLinkAccOrderOprIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccOrderOprIdStr.HasValue ? new ObjectParameter("WithLinkAccOrderOprIdStr", withLinkAccOrderOprIdStr) : new ObjectParameter("WithLinkAccOrderOprIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderOprWithAccLinkField_Result>("WSspSelectOrderOprWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectOrderPaymentTypeWithAccLinkField_Result> WSspSelectOrderPaymentTypeWithAccLinkField(bool? withLinkAccOrdPayTypeIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccOrdPayTypeIdStr.HasValue ? new ObjectParameter("WithLinkAccOrdPayTypeIdStr", withLinkAccOrdPayTypeIdStr) : new ObjectParameter("WithLinkAccOrdPayTypeIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderPaymentTypeWithAccLinkField_Result>("WSspSelectOrderPaymentTypeWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectOrderWithAccLinkField_Result> WSspSelectOrderWithAccLinkField(bool? withOrdLinkAccCodeId, bool? withOrdLinkAccCode, bool? withOrdLinkAccOrderId, bool? withOrdLinkAccOrderIdStr, bool? withOrdLinkAccOrderNumber, bool? withOrdLinkAccVoucherId, bool? withOrdLinkAccVoucherNumber, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (withOrdLinkAccCodeId.HasValue ? new ObjectParameter("WithOrdLinkAccCodeId", withOrdLinkAccCodeId) : new ObjectParameter("WithOrdLinkAccCodeId", typeof(bool)));
		ObjectParameter objectParameter2 = (withOrdLinkAccCode.HasValue ? new ObjectParameter("WithOrdLinkAccCode", withOrdLinkAccCode) : new ObjectParameter("WithOrdLinkAccCode", typeof(bool)));
		ObjectParameter objectParameter3 = (withOrdLinkAccOrderId.HasValue ? new ObjectParameter("WithOrdLinkAccOrderId", withOrdLinkAccOrderId) : new ObjectParameter("WithOrdLinkAccOrderId", typeof(bool)));
		ObjectParameter objectParameter4 = (withOrdLinkAccOrderIdStr.HasValue ? new ObjectParameter("WithOrdLinkAccOrderIdStr", withOrdLinkAccOrderIdStr) : new ObjectParameter("WithOrdLinkAccOrderIdStr", typeof(bool)));
		ObjectParameter objectParameter5 = (withOrdLinkAccOrderNumber.HasValue ? new ObjectParameter("WithOrdLinkAccOrderNumber", withOrdLinkAccOrderNumber) : new ObjectParameter("WithOrdLinkAccOrderNumber", typeof(bool)));
		ObjectParameter objectParameter6 = (withOrdLinkAccVoucherId.HasValue ? new ObjectParameter("WithOrdLinkAccVoucherId", withOrdLinkAccVoucherId) : new ObjectParameter("WithOrdLinkAccVoucherId", typeof(bool)));
		ObjectParameter objectParameter7 = (withOrdLinkAccVoucherNumber.HasValue ? new ObjectParameter("WithOrdLinkAccVoucherNumber", withOrdLinkAccVoucherNumber) : new ObjectParameter("WithOrdLinkAccVoucherNumber", typeof(bool)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderWithAccLinkField_Result>("WSspSelectOrderWithAccLinkField", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<WSspSelectOrderWithFilledLinkAccOrderNumber_Result> WSspSelectOrderWithFilledLinkAccOrderNumber(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderWithFilledLinkAccOrderNumber_Result>("WSspSelectOrderWithFilledLinkAccOrderNumber", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<WSspSelectProductPriceGroupWithAccLinkField_Result> WSspSelectProductPriceGroupWithAccLinkField(bool? withLinkAccPrdPriceGroupIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccPrdPriceGroupIdStr.HasValue ? new ObjectParameter("WithLinkAccPrdPriceGroupIdStr", withLinkAccPrdPriceGroupIdStr) : new ObjectParameter("WithLinkAccPrdPriceGroupIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductPriceGroupWithAccLinkField_Result>("WSspSelectProductPriceGroupWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectProductUnitWithAccLinkField_Result> WSspSelectProductUnitWithAccLinkField(bool? withUnitLinkAccUnitId, bool? withUnitLinkAccUnitIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withUnitLinkAccUnitId.HasValue ? new ObjectParameter("WithUnitLinkAccUnitId", withUnitLinkAccUnitId) : new ObjectParameter("WithUnitLinkAccUnitId", typeof(bool)));
		ObjectParameter objectParameter2 = (withUnitLinkAccUnitIdStr.HasValue ? new ObjectParameter("WithUnitLinkAccUnitIdStr", withUnitLinkAccUnitIdStr) : new ObjectParameter("WithUnitLinkAccUnitIdStr", typeof(bool)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductUnitWithAccLinkField_Result>("WSspSelectProductUnitWithAccLinkField", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspSelectProductWithAccLinkField_Result> WSspSelectProductWithAccLinkField(bool? withPrdLinkAccPrdCode, bool? withPrdLinkAccPrdId, bool? withPrdLinkAccPrdIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withPrdLinkAccPrdCode.HasValue ? new ObjectParameter("WithPrdLinkAccPrdCode", withPrdLinkAccPrdCode) : new ObjectParameter("WithPrdLinkAccPrdCode", typeof(bool)));
		ObjectParameter objectParameter2 = (withPrdLinkAccPrdId.HasValue ? new ObjectParameter("WithPrdLinkAccPrdId", withPrdLinkAccPrdId) : new ObjectParameter("WithPrdLinkAccPrdId", typeof(bool)));
		ObjectParameter objectParameter3 = (withPrdLinkAccPrdIdStr.HasValue ? new ObjectParameter("WithPrdLinkAccPrdIdStr", withPrdLinkAccPrdIdStr) : new ObjectParameter("WithPrdLinkAccPrdIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductWithAccLinkField_Result>("WSspSelectProductWithAccLinkField", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspSelectSaleCenterWithAccLinkField_Result> WSspSelectSaleCenterWithAccLinkField(bool? withLinkAccSaleCenterIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccSaleCenterIdStr.HasValue ? new ObjectParameter("WithLinkAccSaleCenterIdStr", withLinkAccSaleCenterIdStr) : new ObjectParameter("WithLinkAccSaleCenterIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectSaleCenterWithAccLinkField_Result>("WSspSelectSaleCenterWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectWareHouseWithAccLinkField_Result> WSspSelectWareHouseWithAccLinkField(bool? withWrhsLinkAccWhId, bool? withWrhsLinkAccWhCode, bool? withWrhsLinkAccWhIdStr, bool? withWrhsLinkAccWareHouses, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withWrhsLinkAccWhId.HasValue ? new ObjectParameter("WithWrhsLinkAccWhId", withWrhsLinkAccWhId) : new ObjectParameter("WithWrhsLinkAccWhId", typeof(bool)));
		ObjectParameter objectParameter2 = (withWrhsLinkAccWhCode.HasValue ? new ObjectParameter("WithWrhsLinkAccWhCode", withWrhsLinkAccWhCode) : new ObjectParameter("WithWrhsLinkAccWhCode", typeof(bool)));
		ObjectParameter objectParameter3 = (withWrhsLinkAccWhIdStr.HasValue ? new ObjectParameter("WithWrhsLinkAccWhIdStr", withWrhsLinkAccWhIdStr) : new ObjectParameter("WithWrhsLinkAccWhIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (withWrhsLinkAccWareHouses.HasValue ? new ObjectParameter("WithWrhsLinkAccWareHouses", withWrhsLinkAccWareHouses) : new ObjectParameter("WithWrhsLinkAccWareHouses", typeof(bool)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectWareHouseWithAccLinkField_Result>("WSspSelectWareHouseWithAccLinkField", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<mct_CRMspLkNoAvSelectSalesMan_Result> mfi_CRMspLkNoAvSelectSalesMan(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_CRMspLkNoAvSelectSalesMan_Result>("mfi_CRMspLkNoAvSelectSalesMan", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_CRMspLkNoAvSelectSelfCompany_Result> mfi_CRMspLkNoAvSelectSelfCompany(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_CRMspLkNoAvSelectSelfCompany_Result>("mfi_CRMspLkNoAvSelectSelfCompany", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_CRMspLkNoAvSelectStore_Result> mfi_CRMspLkNoAvSelectStore(string dbName)
	{
		ObjectParameter objectParameter = ((dbName != null) ? new ObjectParameter("DbName", dbName) : new ObjectParameter("DbName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_CRMspLkNoAvSelectStore_Result>("mfi_CRMspLkNoAvSelectStore", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspSelectCompanyLinkAccSetting_Result> CRMspSelectCompanyLinkAccSetting(string lblCmpType, string lblCmpGroup, string lblCmpGroupII, string lblCmpGroupIII, string lblCmpGroupIV, int? languageID, int? defaultLanguageID, int? linkAccSystemId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((lblCmpType != null) ? new ObjectParameter("LblCmpType", lblCmpType) : new ObjectParameter("LblCmpType", typeof(string)));
		ObjectParameter objectParameter2 = ((lblCmpGroup != null) ? new ObjectParameter("LblCmpGroup", lblCmpGroup) : new ObjectParameter("LblCmpGroup", typeof(string)));
		ObjectParameter objectParameter3 = ((lblCmpGroupII != null) ? new ObjectParameter("LblCmpGroupII", lblCmpGroupII) : new ObjectParameter("LblCmpGroupII", typeof(string)));
		ObjectParameter objectParameter4 = ((lblCmpGroupIII != null) ? new ObjectParameter("LblCmpGroupIII", lblCmpGroupIII) : new ObjectParameter("LblCmpGroupIII", typeof(string)));
		ObjectParameter objectParameter5 = ((lblCmpGroupIV != null) ? new ObjectParameter("LblCmpGroupIV", lblCmpGroupIV) : new ObjectParameter("LblCmpGroupIV", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyLinkAccSetting_Result>("CRMspSelectCompanyLinkAccSetting", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int CRMspLkShygunWSInsertUpdateDoc(string defProjectTitle, int? defprjcnvsStatusGroupId, string invNo, int? docID, int? oprId, int? senderId, string senderName, string factorNumber, string description, short? isFix, int? wHId, int? orderId, int? buyOrderId, string sendAddress, string driverName, string driverTel, string freightName, string bijakNumber, string carNumber, int? wHIdI, int? companyId, int? personId, int? projectId, string cmpTitle, int? docLinkAccCodeId, string docLinkAccCode, int? docLinkAccDocId, string docLinkAccDocIdStr, string docLinkAccDocNumber, int? docLinkAccVoucherId, string docLinkAccVoucherNumber, string docNumRef, string docDate, DateTime? docDateTime, int? userId, short? month1, int? fPId, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter insertedId, ObjectParameter errorMessage, string prjStartDate, string prjStartTime, DateTime? prjStartDateTime, int? prjStarterUserId, int? centerId)
	{
		ObjectParameter objectParameter = ((defProjectTitle != null) ? new ObjectParameter("DefProjectTitle", defProjectTitle) : new ObjectParameter("DefProjectTitle", typeof(string)));
		ObjectParameter objectParameter2 = (defprjcnvsStatusGroupId.HasValue ? new ObjectParameter("DefprjcnvsStatusGroupId", defprjcnvsStatusGroupId) : new ObjectParameter("DefprjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter3 = ((invNo != null) ? new ObjectParameter("InvNo", invNo) : new ObjectParameter("InvNo", typeof(string)));
		ObjectParameter objectParameter4 = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		ObjectParameter objectParameter5 = (oprId.HasValue ? new ObjectParameter("OprId", oprId) : new ObjectParameter("OprId", typeof(int)));
		ObjectParameter objectParameter6 = (senderId.HasValue ? new ObjectParameter("SenderId", senderId) : new ObjectParameter("SenderId", typeof(int)));
		ObjectParameter objectParameter7 = ((senderName != null) ? new ObjectParameter("SenderName", senderName) : new ObjectParameter("SenderName", typeof(string)));
		ObjectParameter objectParameter8 = ((factorNumber != null) ? new ObjectParameter("FactorNumber", factorNumber) : new ObjectParameter("FactorNumber", typeof(string)));
		ObjectParameter objectParameter9 = ((description != null) ? new ObjectParameter("Description", description) : new ObjectParameter("Description", typeof(string)));
		ObjectParameter objectParameter10 = (isFix.HasValue ? new ObjectParameter("IsFix", isFix) : new ObjectParameter("IsFix", typeof(short)));
		ObjectParameter objectParameter11 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter12 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter13 = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter14 = ((sendAddress != null) ? new ObjectParameter("SendAddress", sendAddress) : new ObjectParameter("SendAddress", typeof(string)));
		ObjectParameter objectParameter15 = ((driverName != null) ? new ObjectParameter("DriverName", driverName) : new ObjectParameter("DriverName", typeof(string)));
		ObjectParameter objectParameter16 = ((driverTel != null) ? new ObjectParameter("DriverTel", driverTel) : new ObjectParameter("DriverTel", typeof(string)));
		ObjectParameter objectParameter17 = ((freightName != null) ? new ObjectParameter("FreightName", freightName) : new ObjectParameter("FreightName", typeof(string)));
		ObjectParameter objectParameter18 = ((bijakNumber != null) ? new ObjectParameter("BijakNumber", bijakNumber) : new ObjectParameter("BijakNumber", typeof(string)));
		ObjectParameter objectParameter19 = ((carNumber != null) ? new ObjectParameter("CarNumber", carNumber) : new ObjectParameter("CarNumber", typeof(string)));
		ObjectParameter objectParameter20 = (wHIdI.HasValue ? new ObjectParameter("WHIdI", wHIdI) : new ObjectParameter("WHIdI", typeof(int)));
		ObjectParameter objectParameter21 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter22 = (personId.HasValue ? new ObjectParameter("PersonId", personId) : new ObjectParameter("PersonId", typeof(int)));
		ObjectParameter objectParameter23 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter24 = ((cmpTitle != null) ? new ObjectParameter("cmpTitle", cmpTitle) : new ObjectParameter("cmpTitle", typeof(string)));
		ObjectParameter objectParameter25 = (docLinkAccCodeId.HasValue ? new ObjectParameter("DocLinkAccCodeId", docLinkAccCodeId) : new ObjectParameter("DocLinkAccCodeId", typeof(int)));
		ObjectParameter objectParameter26 = ((docLinkAccCode != null) ? new ObjectParameter("DocLinkAccCode", docLinkAccCode) : new ObjectParameter("DocLinkAccCode", typeof(string)));
		ObjectParameter objectParameter27 = (docLinkAccDocId.HasValue ? new ObjectParameter("DocLinkAccDocId", docLinkAccDocId) : new ObjectParameter("DocLinkAccDocId", typeof(int)));
		ObjectParameter objectParameter28 = ((docLinkAccDocIdStr != null) ? new ObjectParameter("DocLinkAccDocIdStr", docLinkAccDocIdStr) : new ObjectParameter("DocLinkAccDocIdStr", typeof(string)));
		ObjectParameter objectParameter29 = ((docLinkAccDocNumber != null) ? new ObjectParameter("DocLinkAccDocNumber", docLinkAccDocNumber) : new ObjectParameter("DocLinkAccDocNumber", typeof(string)));
		ObjectParameter objectParameter30 = (docLinkAccVoucherId.HasValue ? new ObjectParameter("DocLinkAccVoucherId", docLinkAccVoucherId) : new ObjectParameter("DocLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter31 = ((docLinkAccVoucherNumber != null) ? new ObjectParameter("DocLinkAccVoucherNumber", docLinkAccVoucherNumber) : new ObjectParameter("DocLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter32 = ((docNumRef != null) ? new ObjectParameter("DocNumRef", docNumRef) : new ObjectParameter("DocNumRef", typeof(string)));
		ObjectParameter objectParameter33 = ((docDate != null) ? new ObjectParameter("DocDate", docDate) : new ObjectParameter("DocDate", typeof(string)));
		ObjectParameter objectParameter34 = (docDateTime.HasValue ? new ObjectParameter("DocDateTime", docDateTime) : new ObjectParameter("DocDateTime", typeof(DateTime)));
		ObjectParameter objectParameter35 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter36 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter37 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter38 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter39 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter40 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter41 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter42 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter43 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter44 = ((prjStartDate != null) ? new ObjectParameter("prjStartDate", prjStartDate) : new ObjectParameter("prjStartDate", typeof(string)));
		ObjectParameter objectParameter45 = ((prjStartTime != null) ? new ObjectParameter("prjStartTime", prjStartTime) : new ObjectParameter("prjStartTime", typeof(string)));
		ObjectParameter objectParameter46 = (prjStartDateTime.HasValue ? new ObjectParameter("prjStartDateTime", prjStartDateTime) : new ObjectParameter("prjStartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter47 = (prjStarterUserId.HasValue ? new ObjectParameter("prjStarterUserId", prjStarterUserId) : new ObjectParameter("prjStarterUserId", typeof(int)));
		ObjectParameter objectParameter48 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunWSInsertUpdateDoc", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, objectParameter42, objectParameter43, insertedId, errorMessage, objectParameter44, objectParameter45, objectParameter46, objectParameter47, objectParameter48);
	}

	public virtual int CRMspLkShygunWSInsertUpdateDocItems(string json, string defProjectTitle, int? defprjcnvsStatusGroupId, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = ((defProjectTitle != null) ? new ObjectParameter("DefProjectTitle", defProjectTitle) : new ObjectParameter("DefProjectTitle", typeof(string)));
		ObjectParameter objectParameter3 = (defprjcnvsStatusGroupId.HasValue ? new ObjectParameter("DefprjcnvsStatusGroupId", defprjcnvsStatusGroupId) : new ObjectParameter("DefprjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunWSInsertUpdateDocItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, errorMessage);
	}

	public virtual int CRMspLkShygunWSInsertUpdateOrder(int? orderOprID, string ordTitle, long? ordNumber, string ordDate, DateTime? ordDateTime, string cmpLinkAccCustomerIdStr, string cmpLinkAccCode, string companyName, string defPrjTitle, int? currencyUnitId, decimal? ordDiscount, decimal? ordTax, decimal? ordTaxIndex, bool? ordCalculateTax, string ordDay, string ordTime, decimal? ordTransportation, decimal? ordDiscountPercent, string ordDiscountTitle, decimal? ordRound, string ordNote, DateTime? ordImportDateTime, int? ordLinkAccCodeId, string ordLinkAccCode, int? ordLinkAccOrderId, string ordLinkAccOrderIdStr, string ordLinkAccOrderNumber, int? ordLinkAccVoucherId, string ordLinkAccVoucherNumber, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, int? defPrjCvnsStatusGroupId, string prjStartDate, string prjStartTime, DateTime? prjStartDateTime, int? prjStarterUserId, int? ordReferUserId, decimal? ordItemsAmount, decimal? ordInstallAmount, decimal? ordSumAmount, decimal? ordTotalAmount, ObjectParameter insertedId, ObjectParameter errorMessage, int? centerId, int? ordSaleCenterId, string ordNumRef)
	{
		ObjectParameter objectParameter = (orderOprID.HasValue ? new ObjectParameter("OrderOprID", orderOprID) : new ObjectParameter("OrderOprID", typeof(int)));
		ObjectParameter objectParameter2 = ((ordTitle != null) ? new ObjectParameter("ordTitle", ordTitle) : new ObjectParameter("ordTitle", typeof(string)));
		ObjectParameter objectParameter3 = (ordNumber.HasValue ? new ObjectParameter("ordNumber", ordNumber) : new ObjectParameter("ordNumber", typeof(long)));
		ObjectParameter objectParameter4 = ((ordDate != null) ? new ObjectParameter("ordDate", ordDate) : new ObjectParameter("ordDate", typeof(string)));
		ObjectParameter objectParameter5 = (ordDateTime.HasValue ? new ObjectParameter("ordDateTime", ordDateTime) : new ObjectParameter("ordDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((cmpLinkAccCustomerIdStr != null) ? new ObjectParameter("cmpLinkAccCustomerIdStr", cmpLinkAccCustomerIdStr) : new ObjectParameter("cmpLinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter7 = ((cmpLinkAccCode != null) ? new ObjectParameter("cmpLinkAccCode", cmpLinkAccCode) : new ObjectParameter("cmpLinkAccCode", typeof(string)));
		ObjectParameter objectParameter8 = ((companyName != null) ? new ObjectParameter("CompanyName", companyName) : new ObjectParameter("CompanyName", typeof(string)));
		ObjectParameter objectParameter9 = ((defPrjTitle != null) ? new ObjectParameter("DefPrjTitle", defPrjTitle) : new ObjectParameter("DefPrjTitle", typeof(string)));
		ObjectParameter objectParameter10 = (currencyUnitId.HasValue ? new ObjectParameter("CurrencyUnitId", currencyUnitId) : new ObjectParameter("CurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter11 = (ordDiscount.HasValue ? new ObjectParameter("ordDiscount", ordDiscount) : new ObjectParameter("ordDiscount", typeof(decimal)));
		ObjectParameter objectParameter12 = (ordTax.HasValue ? new ObjectParameter("ordTax", ordTax) : new ObjectParameter("ordTax", typeof(decimal)));
		ObjectParameter objectParameter13 = (ordTaxIndex.HasValue ? new ObjectParameter("ordTaxIndex", ordTaxIndex) : new ObjectParameter("ordTaxIndex", typeof(decimal)));
		ObjectParameter objectParameter14 = (ordCalculateTax.HasValue ? new ObjectParameter("ordCalculateTax", ordCalculateTax) : new ObjectParameter("ordCalculateTax", typeof(bool)));
		ObjectParameter objectParameter15 = ((ordDay != null) ? new ObjectParameter("ordDay", ordDay) : new ObjectParameter("ordDay", typeof(string)));
		ObjectParameter objectParameter16 = ((ordTime != null) ? new ObjectParameter("ordTime", ordTime) : new ObjectParameter("ordTime", typeof(string)));
		ObjectParameter objectParameter17 = (ordTransportation.HasValue ? new ObjectParameter("ordTransportation", ordTransportation) : new ObjectParameter("ordTransportation", typeof(decimal)));
		ObjectParameter objectParameter18 = (ordDiscountPercent.HasValue ? new ObjectParameter("ordDiscountPercent", ordDiscountPercent) : new ObjectParameter("ordDiscountPercent", typeof(decimal)));
		ObjectParameter objectParameter19 = ((ordDiscountTitle != null) ? new ObjectParameter("ordDiscountTitle", ordDiscountTitle) : new ObjectParameter("ordDiscountTitle", typeof(string)));
		ObjectParameter objectParameter20 = (ordRound.HasValue ? new ObjectParameter("ordRound", ordRound) : new ObjectParameter("ordRound", typeof(decimal)));
		ObjectParameter objectParameter21 = ((ordNote != null) ? new ObjectParameter("ordNote", ordNote) : new ObjectParameter("ordNote", typeof(string)));
		ObjectParameter objectParameter22 = (ordImportDateTime.HasValue ? new ObjectParameter("ordImportDateTime", ordImportDateTime) : new ObjectParameter("ordImportDateTime", typeof(DateTime)));
		ObjectParameter objectParameter23 = (ordLinkAccCodeId.HasValue ? new ObjectParameter("ordLinkAccCodeId", ordLinkAccCodeId) : new ObjectParameter("ordLinkAccCodeId", typeof(int)));
		ObjectParameter objectParameter24 = ((ordLinkAccCode != null) ? new ObjectParameter("ordLinkAccCode", ordLinkAccCode) : new ObjectParameter("ordLinkAccCode", typeof(string)));
		ObjectParameter objectParameter25 = (ordLinkAccOrderId.HasValue ? new ObjectParameter("ordLinkAccOrderId", ordLinkAccOrderId) : new ObjectParameter("ordLinkAccOrderId", typeof(int)));
		ObjectParameter objectParameter26 = ((ordLinkAccOrderIdStr != null) ? new ObjectParameter("ordLinkAccOrderIdStr", ordLinkAccOrderIdStr) : new ObjectParameter("ordLinkAccOrderIdStr", typeof(string)));
		ObjectParameter objectParameter27 = ((ordLinkAccOrderNumber != null) ? new ObjectParameter("ordLinkAccOrderNumber", ordLinkAccOrderNumber) : new ObjectParameter("ordLinkAccOrderNumber", typeof(string)));
		ObjectParameter objectParameter28 = (ordLinkAccVoucherId.HasValue ? new ObjectParameter("ordLinkAccVoucherId", ordLinkAccVoucherId) : new ObjectParameter("ordLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter29 = ((ordLinkAccVoucherNumber != null) ? new ObjectParameter("ordLinkAccVoucherNumber", ordLinkAccVoucherNumber) : new ObjectParameter("ordLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter30 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter31 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter32 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter33 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter34 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter35 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter36 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter37 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter38 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter39 = (defPrjCvnsStatusGroupId.HasValue ? new ObjectParameter("DefPrjCvnsStatusGroupId", defPrjCvnsStatusGroupId) : new ObjectParameter("DefPrjCvnsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter40 = ((prjStartDate != null) ? new ObjectParameter("prjStartDate", prjStartDate) : new ObjectParameter("prjStartDate", typeof(string)));
		ObjectParameter objectParameter41 = ((prjStartTime != null) ? new ObjectParameter("prjStartTime", prjStartTime) : new ObjectParameter("prjStartTime", typeof(string)));
		ObjectParameter objectParameter42 = (prjStartDateTime.HasValue ? new ObjectParameter("prjStartDateTime", prjStartDateTime) : new ObjectParameter("prjStartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter43 = (prjStarterUserId.HasValue ? new ObjectParameter("prjStarterUserId", prjStarterUserId) : new ObjectParameter("prjStarterUserId", typeof(int)));
		ObjectParameter objectParameter44 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter45 = (ordItemsAmount.HasValue ? new ObjectParameter("ordItemsAmount", ordItemsAmount) : new ObjectParameter("ordItemsAmount", typeof(decimal)));
		ObjectParameter objectParameter46 = (ordInstallAmount.HasValue ? new ObjectParameter("ordInstallAmount", ordInstallAmount) : new ObjectParameter("ordInstallAmount", typeof(decimal)));
		ObjectParameter objectParameter47 = (ordSumAmount.HasValue ? new ObjectParameter("ordSumAmount", ordSumAmount) : new ObjectParameter("ordSumAmount", typeof(decimal)));
		ObjectParameter objectParameter48 = (ordTotalAmount.HasValue ? new ObjectParameter("ordTotalAmount", ordTotalAmount) : new ObjectParameter("ordTotalAmount", typeof(decimal)));
		ObjectParameter objectParameter49 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter50 = (ordSaleCenterId.HasValue ? new ObjectParameter("ordSaleCenterId", ordSaleCenterId) : new ObjectParameter("ordSaleCenterId", typeof(int)));
		ObjectParameter objectParameter51 = ((ordNumRef != null) ? new ObjectParameter("ordNumRef", ordNumRef) : new ObjectParameter("ordNumRef", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunWSInsertUpdateOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, objectParameter42, objectParameter43, objectParameter44, objectParameter45, objectParameter46, objectParameter47, objectParameter48, insertedId, errorMessage, objectParameter49, objectParameter50, objectParameter51);
	}

	public virtual int CRMspLkShygunWSInsertUpdateOrderItems(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? wHId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunWSInsertUpdateOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkShygunWSInsertUpdatePreOrder(int? oprID, string pordTitle, long? pordNumber, string pordDate, DateTime? pordDateTime, string cmpLinkAccCustomerIdStr, string cmpLinkAccCode, string companyName, string defPrjTitle, int? currencyUnitId, decimal? pordDiscount, decimal? pordTax, decimal? pordTaxIndex, bool? pordCalculateTax, string pordDay, string pordTime, decimal? pordTransportation, decimal? pordDiscountPercent, string pordDiscountTitle, string pordDescriptionI, decimal? pordRound, string pordImportDate, DateTime? pordImportDateTime, int? pordLinkAccPreOrderId, string pordLinkAccPreOrderIdStr, string pordLinkAccPreOrderNumber, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string prjStartDate, string prjStartTime, DateTime? prjStartDateTime, int? prjStarterUserId, int? pordReferUserId, decimal? pordItemsAmount, decimal? pordInstallAmount, decimal? pordSumAmount, decimal? pordTotalAmount, int? defPrjCvnsStatusGroupId, ObjectParameter insertedId, ObjectParameter errorMessage, int? centerId, int? pordSaleCenterId)
	{
		ObjectParameter objectParameter = (oprID.HasValue ? new ObjectParameter("OprID", oprID) : new ObjectParameter("OprID", typeof(int)));
		ObjectParameter objectParameter2 = ((pordTitle != null) ? new ObjectParameter("pordTitle", pordTitle) : new ObjectParameter("pordTitle", typeof(string)));
		ObjectParameter objectParameter3 = (pordNumber.HasValue ? new ObjectParameter("pordNumber", pordNumber) : new ObjectParameter("pordNumber", typeof(long)));
		ObjectParameter objectParameter4 = ((pordDate != null) ? new ObjectParameter("pordDate", pordDate) : new ObjectParameter("pordDate", typeof(string)));
		ObjectParameter objectParameter5 = (pordDateTime.HasValue ? new ObjectParameter("pordDateTime", pordDateTime) : new ObjectParameter("pordDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((cmpLinkAccCustomerIdStr != null) ? new ObjectParameter("cmpLinkAccCustomerIdStr", cmpLinkAccCustomerIdStr) : new ObjectParameter("cmpLinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter7 = ((cmpLinkAccCode != null) ? new ObjectParameter("cmpLinkAccCode", cmpLinkAccCode) : new ObjectParameter("cmpLinkAccCode", typeof(string)));
		ObjectParameter objectParameter8 = ((companyName != null) ? new ObjectParameter("CompanyName", companyName) : new ObjectParameter("CompanyName", typeof(string)));
		ObjectParameter objectParameter9 = ((defPrjTitle != null) ? new ObjectParameter("DefPrjTitle", defPrjTitle) : new ObjectParameter("DefPrjTitle", typeof(string)));
		ObjectParameter objectParameter10 = (currencyUnitId.HasValue ? new ObjectParameter("CurrencyUnitId", currencyUnitId) : new ObjectParameter("CurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter11 = (pordDiscount.HasValue ? new ObjectParameter("pordDiscount", pordDiscount) : new ObjectParameter("pordDiscount", typeof(decimal)));
		ObjectParameter objectParameter12 = (pordTax.HasValue ? new ObjectParameter("pordTax", pordTax) : new ObjectParameter("pordTax", typeof(decimal)));
		ObjectParameter objectParameter13 = (pordTaxIndex.HasValue ? new ObjectParameter("pordTaxIndex", pordTaxIndex) : new ObjectParameter("pordTaxIndex", typeof(decimal)));
		ObjectParameter objectParameter14 = (pordCalculateTax.HasValue ? new ObjectParameter("pordCalculateTax", pordCalculateTax) : new ObjectParameter("pordCalculateTax", typeof(bool)));
		ObjectParameter objectParameter15 = ((pordDay != null) ? new ObjectParameter("pordDay", pordDay) : new ObjectParameter("pordDay", typeof(string)));
		ObjectParameter objectParameter16 = ((pordTime != null) ? new ObjectParameter("pordTime", pordTime) : new ObjectParameter("pordTime", typeof(string)));
		ObjectParameter objectParameter17 = (pordTransportation.HasValue ? new ObjectParameter("pordTransportation", pordTransportation) : new ObjectParameter("pordTransportation", typeof(decimal)));
		ObjectParameter objectParameter18 = (pordDiscountPercent.HasValue ? new ObjectParameter("pordDiscountPercent", pordDiscountPercent) : new ObjectParameter("pordDiscountPercent", typeof(decimal)));
		ObjectParameter objectParameter19 = ((pordDiscountTitle != null) ? new ObjectParameter("pordDiscountTitle", pordDiscountTitle) : new ObjectParameter("pordDiscountTitle", typeof(string)));
		ObjectParameter objectParameter20 = ((pordDescriptionI != null) ? new ObjectParameter("pordDescriptionI", pordDescriptionI) : new ObjectParameter("pordDescriptionI", typeof(string)));
		ObjectParameter objectParameter21 = (pordRound.HasValue ? new ObjectParameter("pordRound", pordRound) : new ObjectParameter("pordRound", typeof(decimal)));
		ObjectParameter objectParameter22 = ((pordImportDate != null) ? new ObjectParameter("pordImportDate", pordImportDate) : new ObjectParameter("pordImportDate", typeof(string)));
		ObjectParameter objectParameter23 = (pordImportDateTime.HasValue ? new ObjectParameter("pordImportDateTime", pordImportDateTime) : new ObjectParameter("pordImportDateTime", typeof(DateTime)));
		ObjectParameter objectParameter24 = (pordLinkAccPreOrderId.HasValue ? new ObjectParameter("pordLinkAccPreOrderId", pordLinkAccPreOrderId) : new ObjectParameter("pordLinkAccPreOrderId", typeof(int)));
		ObjectParameter objectParameter25 = ((pordLinkAccPreOrderIdStr != null) ? new ObjectParameter("pordLinkAccPreOrderIdStr", pordLinkAccPreOrderIdStr) : new ObjectParameter("pordLinkAccPreOrderIdStr", typeof(string)));
		ObjectParameter objectParameter26 = ((pordLinkAccPreOrderNumber != null) ? new ObjectParameter("pordLinkAccPreOrderNumber", pordLinkAccPreOrderNumber) : new ObjectParameter("pordLinkAccPreOrderNumber", typeof(string)));
		ObjectParameter objectParameter27 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter28 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter29 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter30 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter31 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter32 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter33 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter34 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter35 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter36 = ((prjStartDate != null) ? new ObjectParameter("prjStartDate", prjStartDate) : new ObjectParameter("prjStartDate", typeof(string)));
		ObjectParameter objectParameter37 = ((prjStartTime != null) ? new ObjectParameter("prjStartTime", prjStartTime) : new ObjectParameter("prjStartTime", typeof(string)));
		ObjectParameter objectParameter38 = (prjStartDateTime.HasValue ? new ObjectParameter("prjStartDateTime", prjStartDateTime) : new ObjectParameter("prjStartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter39 = (prjStarterUserId.HasValue ? new ObjectParameter("prjStarterUserId", prjStarterUserId) : new ObjectParameter("prjStarterUserId", typeof(int)));
		ObjectParameter objectParameter40 = (pordReferUserId.HasValue ? new ObjectParameter("pordReferUserId", pordReferUserId) : new ObjectParameter("pordReferUserId", typeof(int)));
		ObjectParameter objectParameter41 = (pordItemsAmount.HasValue ? new ObjectParameter("pordItemsAmount", pordItemsAmount) : new ObjectParameter("pordItemsAmount", typeof(decimal)));
		ObjectParameter objectParameter42 = (pordInstallAmount.HasValue ? new ObjectParameter("pordInstallAmount", pordInstallAmount) : new ObjectParameter("pordInstallAmount", typeof(decimal)));
		ObjectParameter objectParameter43 = (pordSumAmount.HasValue ? new ObjectParameter("pordSumAmount", pordSumAmount) : new ObjectParameter("pordSumAmount", typeof(decimal)));
		ObjectParameter objectParameter44 = (pordTotalAmount.HasValue ? new ObjectParameter("pordTotalAmount", pordTotalAmount) : new ObjectParameter("pordTotalAmount", typeof(decimal)));
		ObjectParameter objectParameter45 = (defPrjCvnsStatusGroupId.HasValue ? new ObjectParameter("DefPrjCvnsStatusGroupId", defPrjCvnsStatusGroupId) : new ObjectParameter("DefPrjCvnsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter46 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter47 = (pordSaleCenterId.HasValue ? new ObjectParameter("pordSaleCenterId", pordSaleCenterId) : new ObjectParameter("pordSaleCenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunWSInsertUpdatePreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, objectParameter42, objectParameter43, objectParameter44, objectParameter45, insertedId, errorMessage, objectParameter46, objectParameter47);
	}

	public virtual int CRMspLkShygunWSInsertUpdatePreOrderItems(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? wHId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunWSInsertUpdatePreOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkShygunWSInsertUpdateProductsFromShygun(string json, int? sGGroupType, int? fGroup, int? sGroup, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, bool? importWithPrice, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (sGGroupType.HasValue ? new ObjectParameter("SGGroupType", sGGroupType) : new ObjectParameter("SGGroupType", typeof(int)));
		ObjectParameter objectParameter3 = (fGroup.HasValue ? new ObjectParameter("FGroup", fGroup) : new ObjectParameter("FGroup", typeof(int)));
		ObjectParameter objectParameter4 = (sGroup.HasValue ? new ObjectParameter("SGroup", sGroup) : new ObjectParameter("SGroup", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (importWithPrice.HasValue ? new ObjectParameter("ImportWithPrice", importWithPrice) : new ObjectParameter("ImportWithPrice", typeof(bool)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunWSInsertUpdateProductsFromShygun", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, errorMessage, objectParameter13, objectParameter14);
	}

	public virtual int CRMspLkWSInsertUpdateProductsFirstGroup(string json, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateProductsFirstGroup", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateProductsSecondGroup(string json, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateProductsSecondGroup", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateWareHouse(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateWareHouse", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkWSSelectDoc_Result> CRMspLkWSSelectDoc(int? oprId, DateTime? fDate, DateTime? tDATE, int? docNumber, int? userId, int? languageID, int? defaultLanguageID, int? centerId, int? docId)
	{
		ObjectParameter objectParameter = (oprId.HasValue ? new ObjectParameter("OprId", oprId) : new ObjectParameter("OprId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (docNumber.HasValue ? new ObjectParameter("DocNumber", docNumber) : new ObjectParameter("DocNumber", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter9 = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectDoc_Result>("CRMspLkWSSelectDoc", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<WSspSelectDocWithAccLinkField_Result> WSspSelectDocWithAccLinkField(int? docOprType, bool? withDocLinkAccCodeId, bool? withDocLinkAccCode, bool? withDocLinkAccDocId, bool? withDocLinkAccDocIdStr, bool? withDocLinkAccDocNumber, bool? withDocLinkAccVoucherId, bool? withDocLinkAccVoucherNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docOprType.HasValue ? new ObjectParameter("DocOprType", docOprType) : new ObjectParameter("DocOprType", typeof(int)));
		ObjectParameter objectParameter2 = (withDocLinkAccCodeId.HasValue ? new ObjectParameter("WithDocLinkAccCodeId", withDocLinkAccCodeId) : new ObjectParameter("WithDocLinkAccCodeId", typeof(bool)));
		ObjectParameter objectParameter3 = (withDocLinkAccCode.HasValue ? new ObjectParameter("WithDocLinkAccCode", withDocLinkAccCode) : new ObjectParameter("WithDocLinkAccCode", typeof(bool)));
		ObjectParameter objectParameter4 = (withDocLinkAccDocId.HasValue ? new ObjectParameter("WithDocLinkAccDocId", withDocLinkAccDocId) : new ObjectParameter("WithDocLinkAccDocId", typeof(bool)));
		ObjectParameter objectParameter5 = (withDocLinkAccDocIdStr.HasValue ? new ObjectParameter("WithDocLinkAccDocIdStr", withDocLinkAccDocIdStr) : new ObjectParameter("WithDocLinkAccDocIdStr", typeof(bool)));
		ObjectParameter objectParameter6 = (withDocLinkAccDocNumber.HasValue ? new ObjectParameter("WithDocLinkAccDocNumber", withDocLinkAccDocNumber) : new ObjectParameter("WithDocLinkAccDocNumber", typeof(bool)));
		ObjectParameter objectParameter7 = (withDocLinkAccVoucherId.HasValue ? new ObjectParameter("WithDocLinkAccVoucherId", withDocLinkAccVoucherId) : new ObjectParameter("WithDocLinkAccVoucherId", typeof(bool)));
		ObjectParameter objectParameter8 = (withDocLinkAccVoucherNumber.HasValue ? new ObjectParameter("WithDocLinkAccVoucherNumber", withDocLinkAccVoucherNumber) : new ObjectParameter("WithDocLinkAccVoucherNumber", typeof(bool)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectDocWithAccLinkField_Result>("WSspSelectDocWithAccLinkField", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<WSspSelectPreOrderWithAccLinkField_Result> WSspSelectPreOrderWithAccLinkField(bool? withPordpordLinkAccPreOrderId, bool? withPordpordLinkAccPreOrderIdStr, bool? withPordLinkAccPreOrderNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withPordpordLinkAccPreOrderId.HasValue ? new ObjectParameter("WithPordpordLinkAccPreOrderId", withPordpordLinkAccPreOrderId) : new ObjectParameter("WithPordpordLinkAccPreOrderId", typeof(bool)));
		ObjectParameter objectParameter2 = (withPordpordLinkAccPreOrderIdStr.HasValue ? new ObjectParameter("WithPordpordLinkAccPreOrderIdStr", withPordpordLinkAccPreOrderIdStr) : new ObjectParameter("WithPordpordLinkAccPreOrderIdStr", typeof(bool)));
		ObjectParameter objectParameter3 = (withPordLinkAccPreOrderNumber.HasValue ? new ObjectParameter("WithPordLinkAccPreOrderNumber", withPordLinkAccPreOrderNumber) : new ObjectParameter("WithPordLinkAccPreOrderNumber", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectPreOrderWithAccLinkField_Result>("WSspSelectPreOrderWithAccLinkField", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspSelectProductsFirstGroupWithAccLinkField_Result> WSspSelectProductsFirstGroupWithAccLinkField(bool? withLinkAccGroupCode, bool? withLinkAccGroupId, bool? withLinkAccGroupIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccGroupCode.HasValue ? new ObjectParameter("WithLinkAccGroupCode", withLinkAccGroupCode) : new ObjectParameter("WithLinkAccGroupCode", typeof(bool)));
		ObjectParameter objectParameter2 = (withLinkAccGroupId.HasValue ? new ObjectParameter("WithLinkAccGroupId", withLinkAccGroupId) : new ObjectParameter("WithLinkAccGroupId", typeof(bool)));
		ObjectParameter objectParameter3 = (withLinkAccGroupIdStr.HasValue ? new ObjectParameter("WithLinkAccGroupIdStr", withLinkAccGroupIdStr) : new ObjectParameter("WithLinkAccGroupIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductsFirstGroupWithAccLinkField_Result>("WSspSelectProductsFirstGroupWithAccLinkField", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspSelectProductsSecondGroupWithAccLinkField_Result> WSspSelectProductsSecondGroupWithAccLinkField(bool? withLinkAccGroupCode, bool? withLinkAccGroupId, bool? withLinkAccGroupIdStr, bool? withLinkAccGroups, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccGroupCode.HasValue ? new ObjectParameter("WithLinkAccGroupCode", withLinkAccGroupCode) : new ObjectParameter("WithLinkAccGroupCode", typeof(bool)));
		ObjectParameter objectParameter2 = (withLinkAccGroupId.HasValue ? new ObjectParameter("WithLinkAccGroupId", withLinkAccGroupId) : new ObjectParameter("WithLinkAccGroupId", typeof(bool)));
		ObjectParameter objectParameter3 = (withLinkAccGroupIdStr.HasValue ? new ObjectParameter("WithLinkAccGroupIdStr", withLinkAccGroupIdStr) : new ObjectParameter("WithLinkAccGroupIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (withLinkAccGroups.HasValue ? new ObjectParameter("WithLinkAccGroups", withLinkAccGroups) : new ObjectParameter("WithLinkAccGroups", typeof(bool)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductsSecondGroupWithAccLinkField_Result>("WSspSelectProductsSecondGroupWithAccLinkField", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int CRMspInsertLinkAccShygunSettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccShygunSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspSelectLinkAccShygunSettingDetails_Result> CRMspSelectLinkAccShygunSettingDetails(int? linkAccShygunSettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccShygunSettingDetailId.HasValue ? new ObjectParameter("LinkAccShygunSettingDetailId", linkAccShygunSettingDetailId) : new ObjectParameter("LinkAccShygunSettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccShygunSettingDetails_Result>("CRMspSelectLinkAccShygunSettingDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int CRMspUpdateLinkAccShygunSettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccShygunSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual int CRMspLkShygunInsertUpdateCompany(string json, int? referUserId, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? languageId, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunInsertUpdateCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11);
	}

	public virtual int CRMspUpdateProductWithAccLinkField(int? productID, int? prdLinkAccPrdId, string prdLinkAccPrdCode, string prdLinkAccPrdIdStr, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (productID.HasValue ? new ObjectParameter("ProductID", productID) : new ObjectParameter("ProductID", typeof(int)));
		ObjectParameter objectParameter2 = (prdLinkAccPrdId.HasValue ? new ObjectParameter("PrdLinkAccPrdId", prdLinkAccPrdId) : new ObjectParameter("PrdLinkAccPrdId", typeof(int)));
		ObjectParameter objectParameter3 = ((prdLinkAccPrdCode != null) ? new ObjectParameter("PrdLinkAccPrdCode", prdLinkAccPrdCode) : new ObjectParameter("PrdLinkAccPrdCode", typeof(string)));
		ObjectParameter objectParameter4 = ((prdLinkAccPrdIdStr != null) ? new ObjectParameter("PrdLinkAccPrdIdStr", prdLinkAccPrdIdStr) : new ObjectParameter("PrdLinkAccPrdIdStr", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateProductWithAccLinkField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual int CRMspInsertLinkAccPayvastSettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccPayvastSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspSelectLinkAccPayvastSettingDetails_Result> CRMspSelectLinkAccPayvastSettingDetails(int? linkAccPayvastSettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccPayvastSettingDetailId.HasValue ? new ObjectParameter("LinkAccPayvastSettingDetailId", linkAccPayvastSettingDetailId) : new ObjectParameter("LinkAccPayvastSettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccPayvastSettingDetails_Result>("CRMspSelectLinkAccPayvastSettingDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int CRMspUpdateLinkAccPayvastSettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccPayvastSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual int CRMspLkWSUpdateWareHouseAccLinkFields(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSUpdateWareHouseAccLinkFields", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<CRMspLkTarazWSSelectPreOrder_Result> CRMspLkTarazWSSelectPreOrder(int? userId, DateTime? fDate, DateTime? tDATE, long? pordNumber, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkTarazWSSelectPreOrder_Result>("CRMspLkTarazWSSelectPreOrder", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int CRMspLkTarazWSInsertUpdatePreOrderTypesFromTaraz(string preOrderTypeJson, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((preOrderTypeJson != null) ? new ObjectParameter("PreOrderTypeJson", preOrderTypeJson) : new ObjectParameter("PreOrderTypeJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkTarazWSInsertUpdatePreOrderTypesFromTaraz", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<WSspSelectPreOrderTypesWithAccLinkField_Result> WSspSelectPreOrderTypesWithAccLinkField(bool? withLinkAccPreOrderTypeIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccPreOrderTypeIdStr.HasValue ? new ObjectParameter("WithLinkAccPreOrderTypeIdStr", withLinkAccPreOrderTypeIdStr) : new ObjectParameter("WithLinkAccPreOrderTypeIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectPreOrderTypesWithAccLinkField_Result>("WSspSelectPreOrderTypesWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccNoAvIISetting_Result> CRMspSelectLinkAccNoAvIISetting(int? linkAccNoAvIISettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccNoAvIISettingId.HasValue ? new ObjectParameter("LinkAccNoAvIISettingId", linkAccNoAvIISettingId) : new ObjectParameter("LinkAccNoAvIISettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccNoAvIISetting_Result>("CRMspSelectLinkAccNoAvIISetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspUpdateLinkAccNoAvIISetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccNoAvIISetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkWSSelectProductSecondGroup_Result> CRMspLkWSSelectProductSecondGroup(int? fGId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fGId.HasValue ? new ObjectParameter("FGId", fGId) : new ObjectParameter("FGId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectProductSecondGroup_Result>("CRMspLkWSSelectProductSecondGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectProductSecondGroupLinkAccGroups_Result> WSspSelectProductSecondGroupLinkAccGroups(int? prdSecondGroupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductSecondGroupLinkAccGroups_Result>("WSspSelectProductSecondGroupLinkAccGroups", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkWSInsertUpdateProductSGLinkAccGroups(int? prdSecondGroupId, string sGLinkAccGroups, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter2 = ((sGLinkAccGroups != null) ? new ObjectParameter("SGLinkAccGroups", sGLinkAccGroups) : new ObjectParameter("SGLinkAccGroups", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateProductSGLinkAccGroups", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage);
	}

	public virtual ObjectResult<CRMspLkShygunLinkedCompany_Result> CRMspLkShygunLinkedCompany(string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunLinkedCompany_Result>("CRMspLkShygunLinkedCompany", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspLkShygunWSLinkedProduct_Result> CRMspLkShygunWSLinkedProduct(string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunWSLinkedProduct_Result>("CRMspLkShygunWSLinkedProduct", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspLkSelectCompany_Result> CRMspLkSelectCompany(int? userId, DateTime? fDate, DateTime? tDATE, string value, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId, int? companyId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter10 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSelectCompany_Result>("CRMspLkSelectCompany", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<CRMspLkWSSelectProduct_Result> CRMspLkWSSelectProduct(DateTime? fDate, DateTime? tDATE, string value, int? firstGroupId, int? secondGroupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter4 = (firstGroupId.HasValue ? new ObjectParameter("FirstGroupId", firstGroupId) : new ObjectParameter("FirstGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (secondGroupId.HasValue ? new ObjectParameter("SecondGroupId", secondGroupId) : new ObjectParameter("SecondGroupId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectProduct_Result>("CRMspLkWSSelectProduct", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspLkShygunDeleteLinkedCompany_Result> CRMspLkShygunDeleteLinkedCompany(string linkAccCustomerIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccCustomerIdStr != null) ? new ObjectParameter("LinkAccCustomerIdStr", linkAccCustomerIdStr) : new ObjectParameter("LinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunDeleteLinkedCompany_Result>("CRMspLkShygunDeleteLinkedCompany", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkShygunDeleteLinkedProduct_Result> CRMspLkShygunDeleteLinkedProduct(string linkAccIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccIdStr != null) ? new ObjectParameter("LinkAccIdStr", linkAccIdStr) : new ObjectParameter("LinkAccIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunDeleteLinkedProduct_Result>("CRMspLkShygunDeleteLinkedProduct", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkShygunWSDeleteLinkedPreOrder_Result> CRMspLkShygunWSDeleteLinkedPreOrder(string linkAccPreOrderIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccPreOrderIdStr != null) ? new ObjectParameter("LinkAccPreOrderIdStr", linkAccPreOrderIdStr) : new ObjectParameter("LinkAccPreOrderIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunWSDeleteLinkedPreOrder_Result>("CRMspLkShygunWSDeleteLinkedPreOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkShygunWSDeleteLinkedOrder_Result> CRMspLkShygunWSDeleteLinkedOrder(string linkAccOrderIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccOrderIdStr != null) ? new ObjectParameter("LinkAccOrderIdStr", linkAccOrderIdStr) : new ObjectParameter("LinkAccOrderIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunWSDeleteLinkedOrder_Result>("CRMspLkShygunWSDeleteLinkedOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkWSInsertUpdateWhLinkAccWarehouses(int? whId, string linkAccWarehouses, int? userId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter2 = ((linkAccWarehouses != null) ? new ObjectParameter("LinkAccWarehouses", linkAccWarehouses) : new ObjectParameter("LinkAccWarehouses", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateWhLinkAccWarehouses", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage);
	}

	public virtual ObjectResult<CRMspLkShygunWSDeleteLinkedDoc_Result> CRMspLkShygunWSDeleteLinkedDoc(string linkAccDocIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccDocIdStr != null) ? new ObjectParameter("LinkAccDocIdStr", linkAccDocIdStr) : new ObjectParameter("LinkAccDocIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunWSDeleteLinkedDoc_Result>("CRMspLkShygunWSDeleteLinkedDoc", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkSepReturnCmpAccountingSummary_Result> CRMspLkSepReturnCmpAccountingSummary(int? companyId, ObjectParameter payRemain, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepReturnCmpAccountingSummary_Result>("CRMspLkSepReturnCmpAccountingSummary", new ObjectParameter[3] { objectParameter, payRemain, objectParameter2 });
	}

	public virtual int CRMspLkShygunIIInsertUpdateCompany(string json, int? cmpReferUserId, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? languageId, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (cmpReferUserId.HasValue ? new ObjectParameter("CmpReferUserId", cmpReferUserId) : new ObjectParameter("CmpReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIInsertUpdateCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11);
	}

	public virtual ObjectResult<CRMspLkShygunIIDeleteLinkedCompany_Result> CRMspLkShygunIIDeleteLinkedCompany(string linkAccCustomerIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccCustomerIdStr != null) ? new ObjectParameter("LinkAccCustomerIdStr", linkAccCustomerIdStr) : new ObjectParameter("LinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIIDeleteLinkedCompany_Result>("CRMspLkShygunIIDeleteLinkedCompany", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkShygunIILinkedCompany_Result> CRMspLkShygunIILinkedCompany(string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIILinkedCompany_Result>("CRMspLkShygunIILinkedCompany", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int CRMspInsertLinkAccShygunIISettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccShygunIISettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspSelectLinkAccShygunIISetting_Result> CRMspSelectLinkAccShygunIISetting(int? linkAccShygunIISettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccShygunIISettingId.HasValue ? new ObjectParameter("LinkAccShygunIISettingId", linkAccShygunIISettingId) : new ObjectParameter("LinkAccShygunIISettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccShygunIISetting_Result>("CRMspSelectLinkAccShygunIISetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccShygunIISettingDetails_Result> CRMspSelectLinkAccShygunIISettingDetails(int? linkAccShygunIISettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccShygunIISettingDetailId.HasValue ? new ObjectParameter("LinkAccShygunIISettingDetailId", linkAccShygunIISettingDetailId) : new ObjectParameter("LinkAccShygunIISettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccShygunIISettingDetails_Result>("CRMspSelectLinkAccShygunIISettingDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int CRMspUpdateLinkAccShygunIISetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccShygunIISetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccShygunIISettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccShygunIISettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<CRMspLkShygunIIDeleteLinkedProduct_Result> CRMspLkShygunIIDeleteLinkedProduct(string linkAccIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccIdStr != null) ? new ObjectParameter("LinkAccIdStr", linkAccIdStr) : new ObjectParameter("LinkAccIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIIDeleteLinkedProduct_Result>("CRMspLkShygunIIDeleteLinkedProduct", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkShygunIIWSInsertUpdateProductsFromShygunII(string json, int? sGGroupType, int? fGroup, int? sGroup, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter errorMessage, bool? importWithPrice, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (sGGroupType.HasValue ? new ObjectParameter("SGGroupType", sGGroupType) : new ObjectParameter("SGGroupType", typeof(int)));
		ObjectParameter objectParameter3 = (fGroup.HasValue ? new ObjectParameter("FGroup", fGroup) : new ObjectParameter("FGroup", typeof(int)));
		ObjectParameter objectParameter4 = (sGroup.HasValue ? new ObjectParameter("SGroup", sGroup) : new ObjectParameter("SGroup", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (importWithPrice.HasValue ? new ObjectParameter("ImportWithPrice", importWithPrice) : new ObjectParameter("ImportWithPrice", typeof(bool)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIWSInsertUpdateProductsFromShygunII", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, errorMessage, objectParameter13, objectParameter14);
	}

	public virtual ObjectResult<CRMspLkShygunIIWSLinkedProduct_Result> CRMspLkShygunIIWSLinkedProduct(string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIIWSLinkedProduct_Result>("CRMspLkShygunIIWSLinkedProduct", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result> CRMspLkShygunIIWSDeleteLinkedPreOrder(string linkAccPreOrderIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccPreOrderIdStr != null) ? new ObjectParameter("LinkAccPreOrderIdStr", linkAccPreOrderIdStr) : new ObjectParameter("LinkAccPreOrderIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result>("CRMspLkShygunIIWSDeleteLinkedPreOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkShygunIIWSInsertUpdatePreOrder(int? oprID, string pordTitle, long? pordNumber, string pordDate, DateTime? pordDateTime, string cmpLinkAccCustomerIdStr, string cmpLinkAccCode, string companyName, string defPrjTitle, int? currencyUnitId, decimal? pordDiscount, decimal? pordTax, decimal? pordTaxIndex, bool? pordCalculateTax, string pordDay, string pordTime, decimal? pordTransportation, decimal? pordDiscountPercent, string pordDiscountTitle, string pordDescriptionI, decimal? pordRound, string pordImportDate, DateTime? pordImportDateTime, int? pordLinkAccPreOrderId, string pordLinkAccPreOrderIdStr, string pordLinkAccPreOrderNumber, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string prjStartDate, string prjStartTime, DateTime? prjStartDateTime, int? prjStarterUserId, int? pordReferUserId, decimal? pordItemsAmount, decimal? pordInstallAmount, decimal? pordSumAmount, decimal? pordTotalAmount, int? defPrjCvnsStatusGroupId, ObjectParameter insertedId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (oprID.HasValue ? new ObjectParameter("OprID", oprID) : new ObjectParameter("OprID", typeof(int)));
		ObjectParameter objectParameter2 = ((pordTitle != null) ? new ObjectParameter("pordTitle", pordTitle) : new ObjectParameter("pordTitle", typeof(string)));
		ObjectParameter objectParameter3 = (pordNumber.HasValue ? new ObjectParameter("pordNumber", pordNumber) : new ObjectParameter("pordNumber", typeof(long)));
		ObjectParameter objectParameter4 = ((pordDate != null) ? new ObjectParameter("pordDate", pordDate) : new ObjectParameter("pordDate", typeof(string)));
		ObjectParameter objectParameter5 = (pordDateTime.HasValue ? new ObjectParameter("pordDateTime", pordDateTime) : new ObjectParameter("pordDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((cmpLinkAccCustomerIdStr != null) ? new ObjectParameter("cmpLinkAccCustomerIdStr", cmpLinkAccCustomerIdStr) : new ObjectParameter("cmpLinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter7 = ((cmpLinkAccCode != null) ? new ObjectParameter("cmpLinkAccCode", cmpLinkAccCode) : new ObjectParameter("cmpLinkAccCode", typeof(string)));
		ObjectParameter objectParameter8 = ((companyName != null) ? new ObjectParameter("CompanyName", companyName) : new ObjectParameter("CompanyName", typeof(string)));
		ObjectParameter objectParameter9 = ((defPrjTitle != null) ? new ObjectParameter("DefPrjTitle", defPrjTitle) : new ObjectParameter("DefPrjTitle", typeof(string)));
		ObjectParameter objectParameter10 = (currencyUnitId.HasValue ? new ObjectParameter("CurrencyUnitId", currencyUnitId) : new ObjectParameter("CurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter11 = (pordDiscount.HasValue ? new ObjectParameter("pordDiscount", pordDiscount) : new ObjectParameter("pordDiscount", typeof(decimal)));
		ObjectParameter objectParameter12 = (pordTax.HasValue ? new ObjectParameter("pordTax", pordTax) : new ObjectParameter("pordTax", typeof(decimal)));
		ObjectParameter objectParameter13 = (pordTaxIndex.HasValue ? new ObjectParameter("pordTaxIndex", pordTaxIndex) : new ObjectParameter("pordTaxIndex", typeof(decimal)));
		ObjectParameter objectParameter14 = (pordCalculateTax.HasValue ? new ObjectParameter("pordCalculateTax", pordCalculateTax) : new ObjectParameter("pordCalculateTax", typeof(bool)));
		ObjectParameter objectParameter15 = ((pordDay != null) ? new ObjectParameter("pordDay", pordDay) : new ObjectParameter("pordDay", typeof(string)));
		ObjectParameter objectParameter16 = ((pordTime != null) ? new ObjectParameter("pordTime", pordTime) : new ObjectParameter("pordTime", typeof(string)));
		ObjectParameter objectParameter17 = (pordTransportation.HasValue ? new ObjectParameter("pordTransportation", pordTransportation) : new ObjectParameter("pordTransportation", typeof(decimal)));
		ObjectParameter objectParameter18 = (pordDiscountPercent.HasValue ? new ObjectParameter("pordDiscountPercent", pordDiscountPercent) : new ObjectParameter("pordDiscountPercent", typeof(decimal)));
		ObjectParameter objectParameter19 = ((pordDiscountTitle != null) ? new ObjectParameter("pordDiscountTitle", pordDiscountTitle) : new ObjectParameter("pordDiscountTitle", typeof(string)));
		ObjectParameter objectParameter20 = ((pordDescriptionI != null) ? new ObjectParameter("pordDescriptionI", pordDescriptionI) : new ObjectParameter("pordDescriptionI", typeof(string)));
		ObjectParameter objectParameter21 = (pordRound.HasValue ? new ObjectParameter("pordRound", pordRound) : new ObjectParameter("pordRound", typeof(decimal)));
		ObjectParameter objectParameter22 = ((pordImportDate != null) ? new ObjectParameter("pordImportDate", pordImportDate) : new ObjectParameter("pordImportDate", typeof(string)));
		ObjectParameter objectParameter23 = (pordImportDateTime.HasValue ? new ObjectParameter("pordImportDateTime", pordImportDateTime) : new ObjectParameter("pordImportDateTime", typeof(DateTime)));
		ObjectParameter objectParameter24 = (pordLinkAccPreOrderId.HasValue ? new ObjectParameter("pordLinkAccPreOrderId", pordLinkAccPreOrderId) : new ObjectParameter("pordLinkAccPreOrderId", typeof(int)));
		ObjectParameter objectParameter25 = ((pordLinkAccPreOrderIdStr != null) ? new ObjectParameter("pordLinkAccPreOrderIdStr", pordLinkAccPreOrderIdStr) : new ObjectParameter("pordLinkAccPreOrderIdStr", typeof(string)));
		ObjectParameter objectParameter26 = ((pordLinkAccPreOrderNumber != null) ? new ObjectParameter("pordLinkAccPreOrderNumber", pordLinkAccPreOrderNumber) : new ObjectParameter("pordLinkAccPreOrderNumber", typeof(string)));
		ObjectParameter objectParameter27 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter28 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter29 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter30 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter31 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter32 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter33 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter34 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter35 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter36 = ((prjStartDate != null) ? new ObjectParameter("prjStartDate", prjStartDate) : new ObjectParameter("prjStartDate", typeof(string)));
		ObjectParameter objectParameter37 = ((prjStartTime != null) ? new ObjectParameter("prjStartTime", prjStartTime) : new ObjectParameter("prjStartTime", typeof(string)));
		ObjectParameter objectParameter38 = (prjStartDateTime.HasValue ? new ObjectParameter("prjStartDateTime", prjStartDateTime) : new ObjectParameter("prjStartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter39 = (prjStarterUserId.HasValue ? new ObjectParameter("prjStarterUserId", prjStarterUserId) : new ObjectParameter("prjStarterUserId", typeof(int)));
		ObjectParameter objectParameter40 = (pordReferUserId.HasValue ? new ObjectParameter("pordReferUserId", pordReferUserId) : new ObjectParameter("pordReferUserId", typeof(int)));
		ObjectParameter objectParameter41 = (pordItemsAmount.HasValue ? new ObjectParameter("pordItemsAmount", pordItemsAmount) : new ObjectParameter("pordItemsAmount", typeof(decimal)));
		ObjectParameter objectParameter42 = (pordInstallAmount.HasValue ? new ObjectParameter("pordInstallAmount", pordInstallAmount) : new ObjectParameter("pordInstallAmount", typeof(decimal)));
		ObjectParameter objectParameter43 = (pordSumAmount.HasValue ? new ObjectParameter("pordSumAmount", pordSumAmount) : new ObjectParameter("pordSumAmount", typeof(decimal)));
		ObjectParameter objectParameter44 = (pordTotalAmount.HasValue ? new ObjectParameter("pordTotalAmount", pordTotalAmount) : new ObjectParameter("pordTotalAmount", typeof(decimal)));
		ObjectParameter objectParameter45 = (defPrjCvnsStatusGroupId.HasValue ? new ObjectParameter("DefPrjCvnsStatusGroupId", defPrjCvnsStatusGroupId) : new ObjectParameter("DefPrjCvnsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter46 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIWSInsertUpdatePreOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, objectParameter42, objectParameter43, objectParameter44, objectParameter45, insertedId, errorMessage, objectParameter46);
	}

	public virtual int CRMspLkShygunIIWSInsertUpdatePreOrderItems(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? wHId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIWSInsertUpdatePreOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual ObjectResult<CRMspLkShygunIIWSDeleteLinkedOrder_Result> CRMspLkShygunIIWSDeleteLinkedOrder(string linkAccOrderIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccOrderIdStr != null) ? new ObjectParameter("LinkAccOrderIdStr", linkAccOrderIdStr) : new ObjectParameter("LinkAccOrderIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIIWSDeleteLinkedOrder_Result>("CRMspLkShygunIIWSDeleteLinkedOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkShygunIIWSInsertUpdateOrder(int? orderOprID, string ordTitle, long? ordNumber, string ordDate, DateTime? ordDateTime, string cmpLinkAccCustomerIdStr, string cmpLinkAccCode, string companyName, string defPrjTitle, int? currencyUnitId, decimal? ordDiscount, decimal? ordTax, decimal? ordTaxIndex, bool? ordCalculateTax, string ordDay, string ordTime, decimal? ordTransportation, decimal? ordDiscountPercent, string ordDiscountTitle, decimal? ordRound, string ordNote, DateTime? ordImportDateTime, int? ordLinkAccCodeId, string ordLinkAccCode, int? ordLinkAccOrderId, string ordLinkAccOrderIdStr, string ordLinkAccOrderNumber, int? ordLinkAccVoucherId, string ordLinkAccVoucherNumber, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, int? defPrjCvnsStatusGroupId, string prjStartDate, string prjStartTime, DateTime? prjStartDateTime, int? prjStarterUserId, int? ordReferUserId, decimal? ordItemsAmount, decimal? ordInstallAmount, decimal? ordSumAmount, decimal? ordTotalAmount, ObjectParameter insertedId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (orderOprID.HasValue ? new ObjectParameter("OrderOprID", orderOprID) : new ObjectParameter("OrderOprID", typeof(int)));
		ObjectParameter objectParameter2 = ((ordTitle != null) ? new ObjectParameter("ordTitle", ordTitle) : new ObjectParameter("ordTitle", typeof(string)));
		ObjectParameter objectParameter3 = (ordNumber.HasValue ? new ObjectParameter("ordNumber", ordNumber) : new ObjectParameter("ordNumber", typeof(long)));
		ObjectParameter objectParameter4 = ((ordDate != null) ? new ObjectParameter("ordDate", ordDate) : new ObjectParameter("ordDate", typeof(string)));
		ObjectParameter objectParameter5 = (ordDateTime.HasValue ? new ObjectParameter("ordDateTime", ordDateTime) : new ObjectParameter("ordDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((cmpLinkAccCustomerIdStr != null) ? new ObjectParameter("cmpLinkAccCustomerIdStr", cmpLinkAccCustomerIdStr) : new ObjectParameter("cmpLinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter7 = ((cmpLinkAccCode != null) ? new ObjectParameter("cmpLinkAccCode", cmpLinkAccCode) : new ObjectParameter("cmpLinkAccCode", typeof(string)));
		ObjectParameter objectParameter8 = ((companyName != null) ? new ObjectParameter("CompanyName", companyName) : new ObjectParameter("CompanyName", typeof(string)));
		ObjectParameter objectParameter9 = ((defPrjTitle != null) ? new ObjectParameter("DefPrjTitle", defPrjTitle) : new ObjectParameter("DefPrjTitle", typeof(string)));
		ObjectParameter objectParameter10 = (currencyUnitId.HasValue ? new ObjectParameter("CurrencyUnitId", currencyUnitId) : new ObjectParameter("CurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter11 = (ordDiscount.HasValue ? new ObjectParameter("ordDiscount", ordDiscount) : new ObjectParameter("ordDiscount", typeof(decimal)));
		ObjectParameter objectParameter12 = (ordTax.HasValue ? new ObjectParameter("ordTax", ordTax) : new ObjectParameter("ordTax", typeof(decimal)));
		ObjectParameter objectParameter13 = (ordTaxIndex.HasValue ? new ObjectParameter("ordTaxIndex", ordTaxIndex) : new ObjectParameter("ordTaxIndex", typeof(decimal)));
		ObjectParameter objectParameter14 = (ordCalculateTax.HasValue ? new ObjectParameter("ordCalculateTax", ordCalculateTax) : new ObjectParameter("ordCalculateTax", typeof(bool)));
		ObjectParameter objectParameter15 = ((ordDay != null) ? new ObjectParameter("ordDay", ordDay) : new ObjectParameter("ordDay", typeof(string)));
		ObjectParameter objectParameter16 = ((ordTime != null) ? new ObjectParameter("ordTime", ordTime) : new ObjectParameter("ordTime", typeof(string)));
		ObjectParameter objectParameter17 = (ordTransportation.HasValue ? new ObjectParameter("ordTransportation", ordTransportation) : new ObjectParameter("ordTransportation", typeof(decimal)));
		ObjectParameter objectParameter18 = (ordDiscountPercent.HasValue ? new ObjectParameter("ordDiscountPercent", ordDiscountPercent) : new ObjectParameter("ordDiscountPercent", typeof(decimal)));
		ObjectParameter objectParameter19 = ((ordDiscountTitle != null) ? new ObjectParameter("ordDiscountTitle", ordDiscountTitle) : new ObjectParameter("ordDiscountTitle", typeof(string)));
		ObjectParameter objectParameter20 = (ordRound.HasValue ? new ObjectParameter("ordRound", ordRound) : new ObjectParameter("ordRound", typeof(decimal)));
		ObjectParameter objectParameter21 = ((ordNote != null) ? new ObjectParameter("ordNote", ordNote) : new ObjectParameter("ordNote", typeof(string)));
		ObjectParameter objectParameter22 = (ordImportDateTime.HasValue ? new ObjectParameter("ordImportDateTime", ordImportDateTime) : new ObjectParameter("ordImportDateTime", typeof(DateTime)));
		ObjectParameter objectParameter23 = (ordLinkAccCodeId.HasValue ? new ObjectParameter("ordLinkAccCodeId", ordLinkAccCodeId) : new ObjectParameter("ordLinkAccCodeId", typeof(int)));
		ObjectParameter objectParameter24 = ((ordLinkAccCode != null) ? new ObjectParameter("ordLinkAccCode", ordLinkAccCode) : new ObjectParameter("ordLinkAccCode", typeof(string)));
		ObjectParameter objectParameter25 = (ordLinkAccOrderId.HasValue ? new ObjectParameter("ordLinkAccOrderId", ordLinkAccOrderId) : new ObjectParameter("ordLinkAccOrderId", typeof(int)));
		ObjectParameter objectParameter26 = ((ordLinkAccOrderIdStr != null) ? new ObjectParameter("ordLinkAccOrderIdStr", ordLinkAccOrderIdStr) : new ObjectParameter("ordLinkAccOrderIdStr", typeof(string)));
		ObjectParameter objectParameter27 = ((ordLinkAccOrderNumber != null) ? new ObjectParameter("ordLinkAccOrderNumber", ordLinkAccOrderNumber) : new ObjectParameter("ordLinkAccOrderNumber", typeof(string)));
		ObjectParameter objectParameter28 = (ordLinkAccVoucherId.HasValue ? new ObjectParameter("ordLinkAccVoucherId", ordLinkAccVoucherId) : new ObjectParameter("ordLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter29 = ((ordLinkAccVoucherNumber != null) ? new ObjectParameter("ordLinkAccVoucherNumber", ordLinkAccVoucherNumber) : new ObjectParameter("ordLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter30 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter31 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter32 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter33 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter34 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter35 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter36 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter37 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter38 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter39 = (defPrjCvnsStatusGroupId.HasValue ? new ObjectParameter("DefPrjCvnsStatusGroupId", defPrjCvnsStatusGroupId) : new ObjectParameter("DefPrjCvnsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter40 = ((prjStartDate != null) ? new ObjectParameter("prjStartDate", prjStartDate) : new ObjectParameter("prjStartDate", typeof(string)));
		ObjectParameter objectParameter41 = ((prjStartTime != null) ? new ObjectParameter("prjStartTime", prjStartTime) : new ObjectParameter("prjStartTime", typeof(string)));
		ObjectParameter objectParameter42 = (prjStartDateTime.HasValue ? new ObjectParameter("prjStartDateTime", prjStartDateTime) : new ObjectParameter("prjStartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter43 = (prjStarterUserId.HasValue ? new ObjectParameter("prjStarterUserId", prjStarterUserId) : new ObjectParameter("prjStarterUserId", typeof(int)));
		ObjectParameter objectParameter44 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter45 = (ordItemsAmount.HasValue ? new ObjectParameter("ordItemsAmount", ordItemsAmount) : new ObjectParameter("ordItemsAmount", typeof(decimal)));
		ObjectParameter objectParameter46 = (ordInstallAmount.HasValue ? new ObjectParameter("ordInstallAmount", ordInstallAmount) : new ObjectParameter("ordInstallAmount", typeof(decimal)));
		ObjectParameter objectParameter47 = (ordSumAmount.HasValue ? new ObjectParameter("ordSumAmount", ordSumAmount) : new ObjectParameter("ordSumAmount", typeof(decimal)));
		ObjectParameter objectParameter48 = (ordTotalAmount.HasValue ? new ObjectParameter("ordTotalAmount", ordTotalAmount) : new ObjectParameter("ordTotalAmount", typeof(decimal)));
		ObjectParameter objectParameter49 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIWSInsertUpdateOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, objectParameter42, objectParameter43, objectParameter44, objectParameter45, objectParameter46, objectParameter47, objectParameter48, insertedId, errorMessage, objectParameter49);
	}

	public virtual int CRMspLkShygunIIWSInsertUpdateOrderItems(string json, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? wHId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIWSInsertUpdateOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual ObjectResult<CRMspLkShygunIIWSDeleteLinkedDoc_Result> CRMspLkShygunIIWSDeleteLinkedDoc(string linkAccDocIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccDocIdStr != null) ? new ObjectParameter("LinkAccDocIdStr", linkAccDocIdStr) : new ObjectParameter("LinkAccDocIdStr", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIIWSDeleteLinkedDoc_Result>("CRMspLkShygunIIWSDeleteLinkedDoc", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkShygunIIWSInsertUpdateDoc(string defProjectTitle, int? defprjcnvsStatusGroupId, string invNo, int? docID, int? oprId, int? senderId, string senderName, string factorNumber, string description, short? isFix, int? wHId, int? orderId, int? buyOrderId, string sendAddress, string driverName, string driverTel, string freightName, string bijakNumber, string carNumber, int? wHIdI, int? companyId, int? personId, int? projectId, string cmpTitle, int? docLinkAccCodeId, string docLinkAccCode, int? docLinkAccDocId, string docLinkAccDocIdStr, string docLinkAccDocNumber, int? docLinkAccVoucherId, string docLinkAccVoucherNumber, string docNumRef, string docDate, DateTime? docDateTime, int? userId, short? month1, int? fPId, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter insertedId, ObjectParameter errorMessage, string prjStartDate, string prjStartTime, DateTime? prjStartDateTime, int? prjStarterUserId, int? centerId)
	{
		ObjectParameter objectParameter = ((defProjectTitle != null) ? new ObjectParameter("DefProjectTitle", defProjectTitle) : new ObjectParameter("DefProjectTitle", typeof(string)));
		ObjectParameter objectParameter2 = (defprjcnvsStatusGroupId.HasValue ? new ObjectParameter("DefprjcnvsStatusGroupId", defprjcnvsStatusGroupId) : new ObjectParameter("DefprjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter3 = ((invNo != null) ? new ObjectParameter("InvNo", invNo) : new ObjectParameter("InvNo", typeof(string)));
		ObjectParameter objectParameter4 = (docID.HasValue ? new ObjectParameter("DocID", docID) : new ObjectParameter("DocID", typeof(int)));
		ObjectParameter objectParameter5 = (oprId.HasValue ? new ObjectParameter("OprId", oprId) : new ObjectParameter("OprId", typeof(int)));
		ObjectParameter objectParameter6 = (senderId.HasValue ? new ObjectParameter("SenderId", senderId) : new ObjectParameter("SenderId", typeof(int)));
		ObjectParameter objectParameter7 = ((senderName != null) ? new ObjectParameter("SenderName", senderName) : new ObjectParameter("SenderName", typeof(string)));
		ObjectParameter objectParameter8 = ((factorNumber != null) ? new ObjectParameter("FactorNumber", factorNumber) : new ObjectParameter("FactorNumber", typeof(string)));
		ObjectParameter objectParameter9 = ((description != null) ? new ObjectParameter("Description", description) : new ObjectParameter("Description", typeof(string)));
		ObjectParameter objectParameter10 = (isFix.HasValue ? new ObjectParameter("IsFix", isFix) : new ObjectParameter("IsFix", typeof(short)));
		ObjectParameter objectParameter11 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter12 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter13 = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter14 = ((sendAddress != null) ? new ObjectParameter("SendAddress", sendAddress) : new ObjectParameter("SendAddress", typeof(string)));
		ObjectParameter objectParameter15 = ((driverName != null) ? new ObjectParameter("DriverName", driverName) : new ObjectParameter("DriverName", typeof(string)));
		ObjectParameter objectParameter16 = ((driverTel != null) ? new ObjectParameter("DriverTel", driverTel) : new ObjectParameter("DriverTel", typeof(string)));
		ObjectParameter objectParameter17 = ((freightName != null) ? new ObjectParameter("FreightName", freightName) : new ObjectParameter("FreightName", typeof(string)));
		ObjectParameter objectParameter18 = ((bijakNumber != null) ? new ObjectParameter("BijakNumber", bijakNumber) : new ObjectParameter("BijakNumber", typeof(string)));
		ObjectParameter objectParameter19 = ((carNumber != null) ? new ObjectParameter("CarNumber", carNumber) : new ObjectParameter("CarNumber", typeof(string)));
		ObjectParameter objectParameter20 = (wHIdI.HasValue ? new ObjectParameter("WHIdI", wHIdI) : new ObjectParameter("WHIdI", typeof(int)));
		ObjectParameter objectParameter21 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter22 = (personId.HasValue ? new ObjectParameter("PersonId", personId) : new ObjectParameter("PersonId", typeof(int)));
		ObjectParameter objectParameter23 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter24 = ((cmpTitle != null) ? new ObjectParameter("cmpTitle", cmpTitle) : new ObjectParameter("cmpTitle", typeof(string)));
		ObjectParameter objectParameter25 = (docLinkAccCodeId.HasValue ? new ObjectParameter("DocLinkAccCodeId", docLinkAccCodeId) : new ObjectParameter("DocLinkAccCodeId", typeof(int)));
		ObjectParameter objectParameter26 = ((docLinkAccCode != null) ? new ObjectParameter("DocLinkAccCode", docLinkAccCode) : new ObjectParameter("DocLinkAccCode", typeof(string)));
		ObjectParameter objectParameter27 = (docLinkAccDocId.HasValue ? new ObjectParameter("DocLinkAccDocId", docLinkAccDocId) : new ObjectParameter("DocLinkAccDocId", typeof(int)));
		ObjectParameter objectParameter28 = ((docLinkAccDocIdStr != null) ? new ObjectParameter("DocLinkAccDocIdStr", docLinkAccDocIdStr) : new ObjectParameter("DocLinkAccDocIdStr", typeof(string)));
		ObjectParameter objectParameter29 = ((docLinkAccDocNumber != null) ? new ObjectParameter("DocLinkAccDocNumber", docLinkAccDocNumber) : new ObjectParameter("DocLinkAccDocNumber", typeof(string)));
		ObjectParameter objectParameter30 = (docLinkAccVoucherId.HasValue ? new ObjectParameter("DocLinkAccVoucherId", docLinkAccVoucherId) : new ObjectParameter("DocLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter31 = ((docLinkAccVoucherNumber != null) ? new ObjectParameter("DocLinkAccVoucherNumber", docLinkAccVoucherNumber) : new ObjectParameter("DocLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter32 = ((docNumRef != null) ? new ObjectParameter("DocNumRef", docNumRef) : new ObjectParameter("DocNumRef", typeof(string)));
		ObjectParameter objectParameter33 = ((docDate != null) ? new ObjectParameter("DocDate", docDate) : new ObjectParameter("DocDate", typeof(string)));
		ObjectParameter objectParameter34 = (docDateTime.HasValue ? new ObjectParameter("DocDateTime", docDateTime) : new ObjectParameter("DocDateTime", typeof(DateTime)));
		ObjectParameter objectParameter35 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter36 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter37 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter38 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter39 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter40 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter41 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter42 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter43 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter44 = ((prjStartDate != null) ? new ObjectParameter("prjStartDate", prjStartDate) : new ObjectParameter("prjStartDate", typeof(string)));
		ObjectParameter objectParameter45 = ((prjStartTime != null) ? new ObjectParameter("prjStartTime", prjStartTime) : new ObjectParameter("prjStartTime", typeof(string)));
		ObjectParameter objectParameter46 = (prjStartDateTime.HasValue ? new ObjectParameter("prjStartDateTime", prjStartDateTime) : new ObjectParameter("prjStartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter47 = (prjStarterUserId.HasValue ? new ObjectParameter("prjStarterUserId", prjStarterUserId) : new ObjectParameter("prjStarterUserId", typeof(int)));
		ObjectParameter objectParameter48 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIWSInsertUpdateDoc", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, objectParameter42, objectParameter43, insertedId, errorMessage, objectParameter44, objectParameter45, objectParameter46, objectParameter47, objectParameter48);
	}

	public virtual int CRMspLkShygunIIWSInsertUpdateDocItems(string json, string defProjectTitle, int? defprjcnvsStatusGroupId, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = ((defProjectTitle != null) ? new ObjectParameter("DefProjectTitle", defProjectTitle) : new ObjectParameter("DefProjectTitle", typeof(string)));
		ObjectParameter objectParameter3 = (defprjcnvsStatusGroupId.HasValue ? new ObjectParameter("DefprjcnvsStatusGroupId", defprjcnvsStatusGroupId) : new ObjectParameter("DefprjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIWSInsertUpdateDocItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, errorMessage);
	}

	public virtual int CRMspUpdateProductFirstGroupWithLinkAccField(int? prdFirstGroupId, int? fGLinkAccGroupId, string fGLinkAccGroupCode, string fGLinkAccGroupIdStr, string fGLinkAccGroupName, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (fGLinkAccGroupId.HasValue ? new ObjectParameter("FGLinkAccGroupId", fGLinkAccGroupId) : new ObjectParameter("FGLinkAccGroupId", typeof(int)));
		ObjectParameter objectParameter3 = ((fGLinkAccGroupCode != null) ? new ObjectParameter("FGLinkAccGroupCode", fGLinkAccGroupCode) : new ObjectParameter("FGLinkAccGroupCode", typeof(string)));
		ObjectParameter objectParameter4 = ((fGLinkAccGroupIdStr != null) ? new ObjectParameter("FGLinkAccGroupIdStr", fGLinkAccGroupIdStr) : new ObjectParameter("FGLinkAccGroupIdStr", typeof(string)));
		ObjectParameter objectParameter5 = ((fGLinkAccGroupName != null) ? new ObjectParameter("FGLinkAccGroupName", fGLinkAccGroupName) : new ObjectParameter("FGLinkAccGroupName", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateProductFirstGroupWithLinkAccField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual int CRMspUpdateProductSecondGroupWithLinkAccField(int? prdSecondGroupId, int? sGLinkAccGroupId, string sGLinkAccGroupCode, string sGLinkAccGroupIdStr, string sGLinkAccGroupName, string sGLinkAccGroups, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (prdSecondGroupId.HasValue ? new ObjectParameter("PrdSecondGroupId", prdSecondGroupId) : new ObjectParameter("PrdSecondGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (sGLinkAccGroupId.HasValue ? new ObjectParameter("SGLinkAccGroupId", sGLinkAccGroupId) : new ObjectParameter("SGLinkAccGroupId", typeof(int)));
		ObjectParameter objectParameter3 = ((sGLinkAccGroupCode != null) ? new ObjectParameter("SGLinkAccGroupCode", sGLinkAccGroupCode) : new ObjectParameter("SGLinkAccGroupCode", typeof(string)));
		ObjectParameter objectParameter4 = ((sGLinkAccGroupIdStr != null) ? new ObjectParameter("SGLinkAccGroupIdStr", sGLinkAccGroupIdStr) : new ObjectParameter("SGLinkAccGroupIdStr", typeof(string)));
		ObjectParameter objectParameter5 = ((sGLinkAccGroupName != null) ? new ObjectParameter("SGLinkAccGroupName", sGLinkAccGroupName) : new ObjectParameter("SGLinkAccGroupName", typeof(string)));
		ObjectParameter objectParameter6 = ((sGLinkAccGroups != null) ? new ObjectParameter("SGLinkAccGroups", sGLinkAccGroups) : new ObjectParameter("SGLinkAccGroups", typeof(string)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateProductSecondGroupWithLinkAccField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12);
	}

	public virtual ObjectResult<WSspSelectProductGroupLinkAccFieldByPrdId_Result> WSspSelectProductGroupLinkAccFieldByPrdId(int? productId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductGroupLinkAccFieldByPrdId_Result>("WSspSelectProductGroupLinkAccFieldByPrdId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspUpdatePreOrderPaymentWithLinkAccField(int? preOrderPaymentId, int? pordpayLinkAccHeaderId, string pordpayLinkAccHeaderNumber, int? pordpayLinkAccDetailId, int? pordpayLinkAccVoucherId, string pordpayLinkAccVoucherNumber, string pordpayLinkAccHeaderIdStr, string pordpayLinkAccDetailIdStr, string pordpayLinkAccVoucherIdStr, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (pordpayLinkAccHeaderId.HasValue ? new ObjectParameter("pordpayLinkAccHeaderId", pordpayLinkAccHeaderId) : new ObjectParameter("pordpayLinkAccHeaderId", typeof(int)));
		ObjectParameter objectParameter3 = ((pordpayLinkAccHeaderNumber != null) ? new ObjectParameter("pordpayLinkAccHeaderNumber", pordpayLinkAccHeaderNumber) : new ObjectParameter("pordpayLinkAccHeaderNumber", typeof(string)));
		ObjectParameter objectParameter4 = (pordpayLinkAccDetailId.HasValue ? new ObjectParameter("pordpayLinkAccDetailId", pordpayLinkAccDetailId) : new ObjectParameter("pordpayLinkAccDetailId", typeof(int)));
		ObjectParameter objectParameter5 = (pordpayLinkAccVoucherId.HasValue ? new ObjectParameter("pordpayLinkAccVoucherId", pordpayLinkAccVoucherId) : new ObjectParameter("pordpayLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter6 = ((pordpayLinkAccVoucherNumber != null) ? new ObjectParameter("pordpayLinkAccVoucherNumber", pordpayLinkAccVoucherNumber) : new ObjectParameter("pordpayLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter7 = ((pordpayLinkAccHeaderIdStr != null) ? new ObjectParameter("pordpayLinkAccHeaderIdStr", pordpayLinkAccHeaderIdStr) : new ObjectParameter("pordpayLinkAccHeaderIdStr", typeof(string)));
		ObjectParameter objectParameter8 = ((pordpayLinkAccDetailIdStr != null) ? new ObjectParameter("pordpayLinkAccDetailIdStr", pordpayLinkAccDetailIdStr) : new ObjectParameter("pordpayLinkAccDetailIdStr", typeof(string)));
		ObjectParameter objectParameter9 = ((pordpayLinkAccVoucherIdStr != null) ? new ObjectParameter("pordpayLinkAccVoucherIdStr", pordpayLinkAccVoucherIdStr) : new ObjectParameter("pordpayLinkAccVoucherIdStr", typeof(string)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdatePreOrderPaymentWithLinkAccField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15);
	}

	public virtual int CRMspUpdateOrderPaymentWithLinkAccField(int? orderPaymentId, int? ordpayLinkAccHeaderId, string ordpayLinkAccHeaderNumber, int? ordpayLinkAccDetailId, int? ordpayLinkAccVoucherId, string ordpayLinkAccVoucherNumber, string ordpayLinkAccHeaderIdStr, string ordpayLinkAccDetailIdStr, string ordpayLinkAccVoucherIdStr, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (ordpayLinkAccHeaderId.HasValue ? new ObjectParameter("ordpayLinkAccHeaderId", ordpayLinkAccHeaderId) : new ObjectParameter("ordpayLinkAccHeaderId", typeof(int)));
		ObjectParameter objectParameter3 = ((ordpayLinkAccHeaderNumber != null) ? new ObjectParameter("ordpayLinkAccHeaderNumber", ordpayLinkAccHeaderNumber) : new ObjectParameter("ordpayLinkAccHeaderNumber", typeof(string)));
		ObjectParameter objectParameter4 = (ordpayLinkAccDetailId.HasValue ? new ObjectParameter("ordpayLinkAccDetailId", ordpayLinkAccDetailId) : new ObjectParameter("ordpayLinkAccDetailId", typeof(int)));
		ObjectParameter objectParameter5 = (ordpayLinkAccVoucherId.HasValue ? new ObjectParameter("ordpayLinkAccVoucherId", ordpayLinkAccVoucherId) : new ObjectParameter("ordpayLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter6 = ((ordpayLinkAccVoucherNumber != null) ? new ObjectParameter("ordpayLinkAccVoucherNumber", ordpayLinkAccVoucherNumber) : new ObjectParameter("ordpayLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter7 = ((ordpayLinkAccHeaderIdStr != null) ? new ObjectParameter("ordpayLinkAccHeaderIdStr", ordpayLinkAccHeaderIdStr) : new ObjectParameter("ordpayLinkAccHeaderIdStr", typeof(string)));
		ObjectParameter objectParameter8 = ((ordpayLinkAccDetailIdStr != null) ? new ObjectParameter("ordpayLinkAccDetailIdStr", ordpayLinkAccDetailIdStr) : new ObjectParameter("ordpayLinkAccDetailIdStr", typeof(string)));
		ObjectParameter objectParameter9 = ((ordpayLinkAccVoucherIdStr != null) ? new ObjectParameter("ordpayLinkAccVoucherIdStr", ordpayLinkAccVoucherIdStr) : new ObjectParameter("ordpayLinkAccVoucherIdStr", typeof(string)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateOrderPaymentWithLinkAccField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15);
	}

	public virtual int CRMspLkShygunIIInsertUpdateUser(string json, int? crmRollId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? languageId, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (crmRollId.HasValue ? new ObjectParameter("CrmRollId", crmRollId) : new ObjectParameter("CrmRollId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShygunIIInsertUpdateUser", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual ObjectResult<CRMspLkShygunIILinkedUser_Result> CRMspLkShygunIILinkedUser(string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShygunIILinkedUser_Result>("CRMspLkShygunIILinkedUser", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccChamberCommerceSetting_Result> CRMspSelectLinkAccChamberCommerceSetting(int? linkAccChamberCommerceSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccChamberCommerceSettingId.HasValue ? new ObjectParameter("LinkAccChamberCommerceSettingId", linkAccChamberCommerceSettingId) : new ObjectParameter("LinkAccChamberCommerceSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccChamberCommerceSetting_Result>("CRMspSelectLinkAccChamberCommerceSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspUpdateLinkAccChamberCommerceSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccChamberCommerceSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkChamberCommerceInsertCmpPrsPrj(string json, int? cmpReferUserId, string prjTitle, int? prjcnvsStatusGroupId, int? cmpQuickRegisterDefSettingId, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? languageID, int? defaultLanguageId, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = (cmpReferUserId.HasValue ? new ObjectParameter("CmpReferUserId", cmpReferUserId) : new ObjectParameter("CmpReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((prjTitle != null) ? new ObjectParameter("prjTitle", prjTitle) : new ObjectParameter("prjTitle", typeof(string)));
		ObjectParameter objectParameter4 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (cmpQuickRegisterDefSettingId.HasValue ? new ObjectParameter("cmpQuickRegisterDefSettingId", cmpQuickRegisterDefSettingId) : new ObjectParameter("cmpQuickRegisterDefSettingId", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkChamberCommerceInsertCmpPrsPrj", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, errorMessage, objectParameter15);
	}

	public virtual ObjectResult<CRMspLkSepWSExportOrder_Result> CRMspLkSepWSExportOrder(int? sepOrdType, int? sepFiscalYearRef, DateTime? fDate, DateTime? tDATE, long? ordNumber, string selectedIds, int? pageNumber, int? pageSize, int? userId, bool? sendPreOrderToAcc, string appType, ObjectParameter errorMessage, int? sepUserId, bool? sendPordPayToAcc, bool? sendOrdPayToAcc, int? orderOprId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (sepOrdType.HasValue ? new ObjectParameter("SepOrdType", sepOrdType) : new ObjectParameter("SepOrdType", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter5 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter6 = ((selectedIds != null) ? new ObjectParameter("SelectedIds", selectedIds) : new ObjectParameter("SelectedIds", typeof(string)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (sendPreOrderToAcc.HasValue ? new ObjectParameter("SendPreOrderToAcc", sendPreOrderToAcc) : new ObjectParameter("SendPreOrderToAcc", typeof(bool)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (sepUserId.HasValue ? new ObjectParameter("SepUserId", sepUserId) : new ObjectParameter("SepUserId", typeof(int)));
		ObjectParameter objectParameter13 = (sendPordPayToAcc.HasValue ? new ObjectParameter("SendPordPayToAcc", sendPordPayToAcc) : new ObjectParameter("SendPordPayToAcc", typeof(bool)));
		ObjectParameter objectParameter14 = (sendOrdPayToAcc.HasValue ? new ObjectParameter("SendOrdPayToAcc", sendOrdPayToAcc) : new ObjectParameter("SendOrdPayToAcc", typeof(bool)));
		ObjectParameter objectParameter15 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter16 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSExportOrder_Result>("CRMspLkSepWSExportOrder", new ObjectParameter[17]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, errorMessage, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16
		});
	}

	public virtual ObjectResult<CRMspLkSepLinkedCompany_Result> CRMspLkSepLinkedCompany(string syncField, int? mode, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepLinkedCompany_Result>("CRMspLkSepLinkedCompany", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspLkSepWSLinkedProduct_Result> CRMspLkSepWSLinkedProduct(string syncField, int? mode, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSLinkedProduct_Result>("CRMspLkSepWSLinkedProduct", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspLkSepWSLinkedWareHouse_Result> CRMspLkSepWSLinkedWareHouse(string syncField, int? mode, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSLinkedWareHouse_Result>("CRMspLkSepWSLinkedWareHouse", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int CRMspLkImportCompany(string json, string linkAccName, bool? canUpdate, int? fPId, short? year1, int? month1, int? userId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defLanguageID, ObjectParameter errorMessage, int? centerId, string encryptionKey)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = ((linkAccName != null) ? new ObjectParameter("LinkAccName", linkAccName) : new ObjectParameter("LinkAccName", typeof(string)));
		ObjectParameter objectParameter3 = (canUpdate.HasValue ? new ObjectParameter("CanUpdate", canUpdate) : new ObjectParameter("CanUpdate", typeof(bool)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter14 = ((encryptionKey != null) ? new ObjectParameter("EncryptionKey", encryptionKey) : new ObjectParameter("EncryptionKey", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkImportCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, errorMessage, objectParameter13, objectParameter14);
	}

	public virtual ObjectResult<CRMspLkImportWareHouse_Result> CRMspLkImportWareHouse(string json, string linkAccName, bool? canUpdate, int? fPId, short? year1, int? month1, int? userId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = ((linkAccName != null) ? new ObjectParameter("LinkAccName", linkAccName) : new ObjectParameter("LinkAccName", typeof(string)));
		ObjectParameter objectParameter3 = (canUpdate.HasValue ? new ObjectParameter("CanUpdate", canUpdate) : new ObjectParameter("CanUpdate", typeof(bool)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkImportWareHouse_Result>("CRMspLkImportWareHouse", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, errorMessage
		});
	}

	public virtual int CRMspLkWSImportOrder(string json, string linkAccName, bool? canUpdate, int? orderOprID, int? fPId, short? year1, int? month1, int? userId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defLanguageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((json != null) ? new ObjectParameter("Json", json) : new ObjectParameter("Json", typeof(string)));
		ObjectParameter objectParameter2 = ((linkAccName != null) ? new ObjectParameter("LinkAccName", linkAccName) : new ObjectParameter("LinkAccName", typeof(string)));
		ObjectParameter objectParameter3 = (canUpdate.HasValue ? new ObjectParameter("CanUpdate", canUpdate) : new ObjectParameter("CanUpdate", typeof(bool)));
		ObjectParameter objectParameter4 = (orderOprID.HasValue ? new ObjectParameter("OrderOprID", orderOprID) : new ObjectParameter("OrderOprID", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSImportOrder", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, errorMessage, objectParameter14);
	}

	public virtual int CRMspLkSepReturnCmpAccountRemaining(int? companyId, ObjectParameter payRemain, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepReturnCmpAccountRemaining", objectParameter, payRemain, objectParameter2);
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkSepWSLinkedProductUnit(int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkSepWSLinkedProductUnit", new ObjectParameter[1] { objectParameter });
	}

	public virtual int CRMspLkSepDeleteCompanyInfoFromSep(int? companyId, int? crmUserId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepDeleteCompanyInfoFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSDeleteBuyOrderInfoFromSep(int? buyOrderId, int? buyOrderItemId, int? mode, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (buyOrderItemId.HasValue ? new ObjectParameter("BuyOrderItemId", buyOrderItemId) : new ObjectParameter("BuyOrderItemId", typeof(int)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteBuyOrderInfoFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual int CRMspLkSepWSDeleteBuyOrderPaymentFromSep(int? buyOrderPaymentId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderPaymentId.HasValue ? new ObjectParameter("BuyOrderPaymentId", buyOrderPaymentId) : new ObjectParameter("BuyOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteBuyOrderPaymentFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSDeleteBuyOrderPaymentsAllFromSep(int? buyOrderId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteBuyOrderPaymentsAllFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSDeleteDocInfoFromSep(int? docId, int? docItemId, int? mode, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (docItemId.HasValue ? new ObjectParameter("DocItemId", docItemId) : new ObjectParameter("DocItemId", typeof(int)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteDocInfoFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual int CRMspLkSepWSDeleteOrderInfoFromSep(int? orderId, int? orderItemId, int? mode, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteOrderInfoFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual int CRMspLkSepWSDeleteOrderPaymentFromSep(int? orderPaymentId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteOrderPaymentFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSDeleteOrderPaymentsAllFromSep(int? orderId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteOrderPaymentsAllFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSDeletePreOrderInfoFromSep(int? preOrderId, int? preOrderItemId, int? mode, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (preOrderItemId.HasValue ? new ObjectParameter("PreOrderItemId", preOrderItemId) : new ObjectParameter("PreOrderItemId", typeof(int)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeletePreOrderInfoFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage, objectParameter10);
	}

	public virtual int CRMspLkSepWSDeletePreOrderPaymentFromSep(int? preOrderPaymentId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeletePreOrderPaymentFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSDeletePreOrderPaymentsAllFromSep(int? preOrderId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeletePreOrderPaymentsAllFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkSepWSDeleteProductInfoFromSep(int? productId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? mode, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter9 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteProductInfoFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkSepSelectCompanyById_Result> CRMspLkSepSelectCompanyById(int? companyId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectCompanyById_Result>("CRMspLkSepSelectCompanyById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectOrderByOrdId_Result> CRMspLkSepWSSelectOrderByOrdId(int? orderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectOrderByOrdId_Result>("CRMspLkSepWSSelectOrderByOrdId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectOrderItemsByOrdId_Result> CRMspLkSepWSSelectOrderItemsByOrdId(int? orderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectOrderItemsByOrdId_Result>("CRMspLkSepWSSelectOrderItemsByOrdId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectOrderPaymentsByOrdId_Result> CRMspLkSepWSSelectOrderPaymentsByOrdId(int? orderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectOrderPaymentsByOrdId_Result>("CRMspLkSepWSSelectOrderPaymentsByOrdId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectPreOrderByPordId_Result> CRMspLkSepWSSelectPreOrderByPordId(int? preOrderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectPreOrderByPordId_Result>("CRMspLkSepWSSelectPreOrderByPordId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectPreOrderItemsByPordId_Result> CRMspLkSepWSSelectPreOrderItemsByPordId(int? preOrderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectPreOrderItemsByPordId_Result>("CRMspLkSepWSSelectPreOrderItemsByPordId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result> CRMspLkSepWSSelectPreOrderPaymentsByPordId(int? preOrderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result>("CRMspLkSepWSSelectPreOrderPaymentsByPordId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectProductById_Result> CRMspLkSepWSSelectProductById(int? productId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectProductById_Result>("CRMspLkSepWSSelectProductById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectBuyOrderByBordId_Result> CRMspLkSepWSSelectBuyOrderByBordId(int? buyOrderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectBuyOrderByBordId_Result>("CRMspLkSepWSSelectBuyOrderByBordId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result> CRMspLkSepWSSelectBuyOrderItemsByBordId(int? buyOrderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result>("CRMspLkSepWSSelectBuyOrderItemsByBordId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result> CRMspLkSepWSSelectBuyOrderPaymentsByBordId(int? buyOrderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result>("CRMspLkSepWSSelectBuyOrderPaymentsByBordId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectDocByDocId_Result> CRMspLkSepWSSelectDocByDocId(int? docId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectDocByDocId_Result>("CRMspLkSepWSSelectDocByDocId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectDocItemsByDocId_Result> CRMspLkSepWSSelectDocItemsByDocId(int? docId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectDocItemsByDocId_Result>("CRMspLkSepWSSelectDocItemsByDocId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepSelectBank_Result> CRMspLkSepSelectBank(int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectBank_Result>("CRMspLkSepSelectBank", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspDeleteLinkAccHolooSettingUser(int? linkAccHolooSettingUserId)
	{
		ObjectParameter objectParameter = (linkAccHolooSettingUserId.HasValue ? new ObjectParameter("LinkAccHolooSettingUserId", linkAccHolooSettingUserId) : new ObjectParameter("LinkAccHolooSettingUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspDeleteLinkAccHolooSettingUser", new ObjectParameter[1] { objectParameter });
	}

	public virtual int CRMspInsertUpdateLinkAccHolooSettingUsers(int? linkAccHolooSettingUserId, int? crmUserId, string userName, string password, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter insertedId)
	{
		ObjectParameter objectParameter = (linkAccHolooSettingUserId.HasValue ? new ObjectParameter("LinkAccHolooSettingUserId", linkAccHolooSettingUserId) : new ObjectParameter("LinkAccHolooSettingUserId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter4 = ((password != null) ? new ObjectParameter("Password", password) : new ObjectParameter("Password", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertUpdateLinkAccHolooSettingUsers", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, insertedId);
	}

	public virtual ObjectResult<CRMspSelectLinkAccHolooSettingUsers_Result> CRMspSelectLinkAccHolooSettingUsers(int? linkAccHolooSettingUserId, int? crmUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccHolooSettingUserId.HasValue ? new ObjectParameter("LinkAccHolooSettingUserId", linkAccHolooSettingUserId) : new ObjectParameter("LinkAccHolooSettingUserId", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccHolooSettingUsers_Result>("CRMspSelectLinkAccHolooSettingUsers", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkShomaranDeleteLinkedProduct_Result> CRMspLkShomaranDeleteLinkedProduct(string linkAccCode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccCode != null) ? new ObjectParameter("LinkAccCode", linkAccCode) : new ObjectParameter("LinkAccCode", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranDeleteLinkedProduct_Result>("CRMspLkShomaranDeleteLinkedProduct", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkShomaranSelectProducts_Result> CRMspLkShomaranSelectProducts(string fromPrdCode, string toPrdCode, string prdFGName, string prdSGName, string prdName, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((fromPrdCode != null) ? new ObjectParameter("FromPrdCode", fromPrdCode) : new ObjectParameter("FromPrdCode", typeof(string)));
		ObjectParameter objectParameter2 = ((toPrdCode != null) ? new ObjectParameter("ToPrdCode", toPrdCode) : new ObjectParameter("ToPrdCode", typeof(string)));
		ObjectParameter objectParameter3 = ((prdFGName != null) ? new ObjectParameter("PrdFGName", prdFGName) : new ObjectParameter("PrdFGName", typeof(string)));
		ObjectParameter objectParameter4 = ((prdSGName != null) ? new ObjectParameter("PrdSGName", prdSGName) : new ObjectParameter("PrdSGName", typeof(string)));
		ObjectParameter objectParameter5 = ((prdName != null) ? new ObjectParameter("PrdName", prdName) : new ObjectParameter("PrdName", typeof(string)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranSelectProducts_Result>("CRMspLkShomaranSelectProducts", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<int?> CRMspLkShomaranWSInsertUpdateProductFromShomaran(string prdPartNo, int? prdGroupId, bool? addToPrdGroup, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedPrdId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((prdPartNo != null) ? new ObjectParameter("PrdPartNo", prdPartNo) : new ObjectParameter("PrdPartNo", typeof(string)));
		ObjectParameter objectParameter2 = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (addToPrdGroup.HasValue ? new ObjectParameter("AddToPrdGroup", addToPrdGroup) : new ObjectParameter("AddToPrdGroup", typeof(bool)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("CRMspLkShomaranWSInsertUpdateProductFromShomaran", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			insertedPrdId, errorMessage
		});
	}

	public virtual ObjectResult<CRMspLkShomaranWSLinkedProduct_Result> CRMspLkShomaranWSLinkedProduct(string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranWSLinkedProduct_Result>("CRMspLkShomaranWSLinkedProduct", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspLkShomaranWSImportProduct(string selectedPrds, int? prdGroupId, bool? addToPrdGroup, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((selectedPrds != null) ? new ObjectParameter("SelectedPrds", selectedPrds) : new ObjectParameter("SelectedPrds", typeof(string)));
		ObjectParameter objectParameter2 = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (addToPrdGroup.HasValue ? new ObjectParameter("AddToPrdGroup", addToPrdGroup) : new ObjectParameter("AddToPrdGroup", typeof(bool)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShomaranWSImportProduct", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage);
	}

	public virtual ObjectResult<CRMspSelectLinkAccShomaranSetting_Result> CRMspSelectLinkAccShomaranSetting(int? linkAccShomaranSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccShomaranSettingId.HasValue ? new ObjectParameter("LinkAccShomaranSettingId", linkAccShomaranSettingId) : new ObjectParameter("LinkAccShomaranSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccShomaranSetting_Result>("CRMspSelectLinkAccShomaranSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspUpdateLinkAccShomaranSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccShomaranSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkShomaranDeleteLinkedCompany_Result> CRMspLkShomaranDeleteLinkedCompany(string linkAccCode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((linkAccCode != null) ? new ObjectParameter("LinkAccCode", linkAccCode) : new ObjectParameter("LinkAccCode", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranDeleteLinkedCompany_Result>("CRMspLkShomaranDeleteLinkedCompany", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkShomaranImportCompany(string cmpSelected, int? cmpReferUserId, int? userId, int? month1, int? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((cmpSelected != null) ? new ObjectParameter("CmpSelected", cmpSelected) : new ObjectParameter("CmpSelected", typeof(string)));
		ObjectParameter objectParameter2 = (cmpReferUserId.HasValue ? new ObjectParameter("cmpReferUserId", cmpReferUserId) : new ObjectParameter("cmpReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShomaranImportCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11);
	}

	public virtual int CRMspLkShomaranInsertUpdateCompanyFromShomaran(string cmpPersonCode, int? cmpReferUserId, int? userId, int? month1, int? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter insertedCmpId, ObjectParameter insertedPrsId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((cmpPersonCode != null) ? new ObjectParameter("CmpPersonCode", cmpPersonCode) : new ObjectParameter("CmpPersonCode", typeof(string)));
		ObjectParameter objectParameter2 = (cmpReferUserId.HasValue ? new ObjectParameter("cmpReferUserId", cmpReferUserId) : new ObjectParameter("cmpReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShomaranInsertUpdateCompanyFromShomaran", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, insertedCmpId, insertedPrsId, errorMessage, objectParameter11);
	}

	public virtual int CRMspLkShomaranInsertUpdateCompanyMoneyBag(string compnayCode, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((compnayCode != null) ? new ObjectParameter("CompnayCode", compnayCode) : new ObjectParameter("CompnayCode", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShomaranInsertUpdateCompanyMoneyBag", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkShomaranLinkedCompany_Result> CRMspLkShomaranLinkedCompany(string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranLinkedCompany_Result>("CRMspLkShomaranLinkedCompany", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkShomaranSelectCompany_Result> CRMspLkShomaranSelectCompany(string fromCmpCode, string toCmpCode, string cmpName, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((fromCmpCode != null) ? new ObjectParameter("FromCmpCode", fromCmpCode) : new ObjectParameter("FromCmpCode", typeof(string)));
		ObjectParameter objectParameter2 = ((toCmpCode != null) ? new ObjectParameter("ToCmpCode", toCmpCode) : new ObjectParameter("ToCmpCode", typeof(string)));
		ObjectParameter objectParameter3 = ((cmpName != null) ? new ObjectParameter("CmpName", cmpName) : new ObjectParameter("CmpName", typeof(string)));
		ObjectParameter objectParameter4 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranSelectCompany_Result>("CRMspLkShomaranSelectCompany", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspLkShomaranReturnProductQuantity_Result> CRMspLkShomaranReturnProductQuantity(int? prdId, int? whId, string linkAccWhCode, string tracing, string sefaresh, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter3 = ((linkAccWhCode != null) ? new ObjectParameter("LinkAccWhCode", linkAccWhCode) : new ObjectParameter("LinkAccWhCode", typeof(string)));
		ObjectParameter objectParameter4 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter5 = ((sefaresh != null) ? new ObjectParameter("Sefaresh", sefaresh) : new ObjectParameter("Sefaresh", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranReturnProductQuantity_Result>("CRMspLkShomaranReturnProductQuantity", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspLkShomaranSelectWareHouse_Result> CRMspLkShomaranSelectWareHouse(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranSelectWareHouse_Result>("CRMspLkShomaranSelectWareHouse", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccArpaSetting_Result> CRMspSelectLinkAccArpaSetting(int? linkAccArpaSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccArpaSettingId.HasValue ? new ObjectParameter("LinkAccArpaSettingId", linkAccArpaSettingId) : new ObjectParameter("LinkAccArpaSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccArpaSetting_Result>("CRMspSelectLinkAccArpaSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspUpdateLinkAccArpaSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccArpaSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkDeleteLinkedProduct_Result> CRMspLkDeleteLinkedProduct(int? linkAccSystemId, string linkAccIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((linkAccIdStr != null) ? new ObjectParameter("LinkAccIdStr", linkAccIdStr) : new ObjectParameter("LinkAccIdStr", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkDeleteLinkedProduct_Result>("CRMspLkDeleteLinkedProduct", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspLkWSInsertUpdateProducts(int? linkAccSystemId, string prdJson, string prdPriceJson, int? prdFGId, int? prdSGId, bool? importWithPrice, int? prdPriceGroupId, int? prdCostGroupId, int? userId, int? month1, short? year1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage, string linkAccSystemIdsNoPrdGroup, int? centerId, bool? canDupPrdCode, bool? useAccPrdCode, bool? useAccPrdCodeInError)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((prdJson != null) ? new ObjectParameter("PrdJson", prdJson) : new ObjectParameter("PrdJson", typeof(string)));
		ObjectParameter objectParameter3 = ((prdPriceJson != null) ? new ObjectParameter("PrdPriceJson", prdPriceJson) : new ObjectParameter("PrdPriceJson", typeof(string)));
		ObjectParameter objectParameter4 = (prdFGId.HasValue ? new ObjectParameter("PrdFGId", prdFGId) : new ObjectParameter("PrdFGId", typeof(int)));
		ObjectParameter objectParameter5 = (prdSGId.HasValue ? new ObjectParameter("PrdSGId", prdSGId) : new ObjectParameter("PrdSGId", typeof(int)));
		ObjectParameter objectParameter6 = (importWithPrice.HasValue ? new ObjectParameter("ImportWithPrice", importWithPrice) : new ObjectParameter("ImportWithPrice", typeof(bool)));
		ObjectParameter objectParameter7 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter8 = (prdCostGroupId.HasValue ? new ObjectParameter("PrdCostGroupId", prdCostGroupId) : new ObjectParameter("PrdCostGroupId", typeof(int)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter11 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter17 = ((linkAccSystemIdsNoPrdGroup != null) ? new ObjectParameter("LinkAccSystemIdsNoPrdGroup", linkAccSystemIdsNoPrdGroup) : new ObjectParameter("LinkAccSystemIdsNoPrdGroup", typeof(string)));
		ObjectParameter objectParameter18 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter19 = (canDupPrdCode.HasValue ? new ObjectParameter("CanDupPrdCode", canDupPrdCode) : new ObjectParameter("CanDupPrdCode", typeof(bool)));
		ObjectParameter objectParameter20 = (useAccPrdCode.HasValue ? new ObjectParameter("UseAccPrdCode", useAccPrdCode) : new ObjectParameter("UseAccPrdCode", typeof(bool)));
		ObjectParameter objectParameter21 = (useAccPrdCodeInError.HasValue ? new ObjectParameter("UseAccPrdCodeInError", useAccPrdCodeInError) : new ObjectParameter("UseAccPrdCodeInError", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateProducts", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, errorMessage, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21);
	}

	public virtual ObjectResult<CRMspLkWSLinkedProduct_Result> CRMspLkWSLinkedProduct(int? linkAccSystemId, string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter3 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter4 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSLinkedProduct_Result>("CRMspLkWSLinkedProduct", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int CRMspLkWSInsertUpdateProductUnitByJson(string unitJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((unitJson != null) ? new ObjectParameter("UnitJson", unitJson) : new ObjectParameter("UnitJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateProductUnitByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<CRMspLkDeleteLinkedCompany_Result> CRMspLkDeleteLinkedCompany(int? linkAccSystemId, string linkAccCustomerIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((linkAccCustomerIdStr != null) ? new ObjectParameter("LinkAccCustomerIdStr", linkAccCustomerIdStr) : new ObjectParameter("LinkAccCustomerIdStr", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkDeleteLinkedCompany_Result>("CRMspLkDeleteLinkedCompany", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspLkInsertUpdateCompanyByJson(string cmpJson, int? referUserId, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? defaultLanguageID, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((cmpJson != null) ? new ObjectParameter("CmpJson", cmpJson) : new ObjectParameter("CmpJson", typeof(string)));
		ObjectParameter objectParameter2 = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateCompanyByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11);
	}

	public virtual int CRMspLkInsertUpdateCompanyTypeByJson(string cmpTypeJson, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((cmpTypeJson != null) ? new ObjectParameter("CmpTypeJson", cmpTypeJson) : new ObjectParameter("CmpTypeJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateCompanyTypeByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<CRMspLkLinkedCompany_Result> CRMspLkLinkedCompany(int? linkAccSystemId, string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter3 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter4 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkLinkedCompany_Result>("CRMspLkLinkedCompany", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int CRMspLkInsertUpdateUserByJson(string userJson, int? crmRollId, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? defaultLanguageID, string appType, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((userJson != null) ? new ObjectParameter("UserJson", userJson) : new ObjectParameter("UserJson", typeof(string)));
		ObjectParameter objectParameter2 = (crmRollId.HasValue ? new ObjectParameter("CrmRollId", crmRollId) : new ObjectParameter("CrmRollId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateUserByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11);
	}

	public virtual ObjectResult<CRMspLkLinkedUser_Result> CRMspLkLinkedUser(int? linkAccSystemId, string itemJson, string syncField, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter3 = ((syncField != null) ? new ObjectParameter("SyncField", syncField) : new ObjectParameter("SyncField", typeof(string)));
		ObjectParameter objectParameter4 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkLinkedUser_Result>("CRMspLkLinkedUser", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int CRMspLkWSInsertUpdateDeliveryTermByJson(string deliveryTermJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((deliveryTermJson != null) ? new ObjectParameter("DeliveryTermJson", deliveryTermJson) : new ObjectParameter("DeliveryTermJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateDeliveryTermByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateSaleCenterByJson(string saleCenterJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((saleCenterJson != null) ? new ObjectParameter("SaleCenterJson", saleCenterJson) : new ObjectParameter("SaleCenterJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateSaleCenterByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateSettlementTypeByJson(string settlementTypeJson, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((settlementTypeJson != null) ? new ObjectParameter("SettlementTypeJson", settlementTypeJson) : new ObjectParameter("SettlementTypeJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateSettlementTypeByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<WSspSelectSettlementTypeWithAccLinkField_Result> WSspSelectSettlementTypeWithAccLinkField(bool? withLinkAccSettlementTypeIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (withLinkAccSettlementTypeIdStr.HasValue ? new ObjectParameter("WithLinkAccSettlementTypeIdStr", withLinkAccSettlementTypeIdStr) : new ObjectParameter("WithLinkAccSettlementTypeIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectSettlementTypeWithAccLinkField_Result>("WSspSelectSettlementTypeWithAccLinkField", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkWSDeleteLinkedOrder_Result> CRMspLkWSDeleteLinkedOrder(int? linkAccSystemId, string linkAccOrderIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((linkAccOrderIdStr != null) ? new ObjectParameter("LinkAccOrderIdStr", linkAccOrderIdStr) : new ObjectParameter("LinkAccOrderIdStr", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSDeleteLinkedOrder_Result>("CRMspLkWSDeleteLinkedOrder", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkWSIssueOrUpdateOrderByJson(int? linkAccSystemId, int? orderOprID, int? ordReferUserId, int? defWhId, string orderJson, string orderItemJson, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage, int? ordCurrencyUnitId, int? prjcnvsStatusGroupId, string prjTitle, int? centerId)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (orderOprID.HasValue ? new ObjectParameter("OrderOprID", orderOprID) : new ObjectParameter("OrderOprID", typeof(int)));
		ObjectParameter objectParameter3 = (ordReferUserId.HasValue ? new ObjectParameter("ordReferUserId", ordReferUserId) : new ObjectParameter("ordReferUserId", typeof(int)));
		ObjectParameter objectParameter4 = (defWhId.HasValue ? new ObjectParameter("DefWhId", defWhId) : new ObjectParameter("DefWhId", typeof(int)));
		ObjectParameter objectParameter5 = ((orderJson != null) ? new ObjectParameter("OrderJson", orderJson) : new ObjectParameter("OrderJson", typeof(string)));
		ObjectParameter objectParameter6 = ((orderItemJson != null) ? new ObjectParameter("OrderItemJson", orderItemJson) : new ObjectParameter("OrderItemJson", typeof(string)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter11 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter15 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (ordCurrencyUnitId.HasValue ? new ObjectParameter("ordCurrencyUnitId", ordCurrencyUnitId) : new ObjectParameter("ordCurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter17 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter18 = ((prjTitle != null) ? new ObjectParameter("prjTitle", prjTitle) : new ObjectParameter("prjTitle", typeof(string)));
		ObjectParameter objectParameter19 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkWSIssueOrUpdateOrderByJson", new ObjectParameter[20]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, errorMessage, objectParameter16, objectParameter17, objectParameter18, objectParameter19
		});
	}

	public virtual int CRMspLkShomaranWSInsertUpdateOrderOpr(int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShomaranWSInsertUpdateOrderOpr", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage);
	}

	public virtual int CRMspLkShomaranWSInsertUpdatePreOrderOpr(int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkShomaranWSInsertUpdatePreOrderOpr", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage);
	}

	public virtual ObjectResult<CRMspLkShomaranReturnProductSefareshCode_Result> CRMspLkShomaranReturnProductSefareshCode(int? prdId, int? whId, string linkAccWhCode)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter3 = ((linkAccWhCode != null) ? new ObjectParameter("LinkAccWhCode", linkAccWhCode) : new ObjectParameter("LinkAccWhCode", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranReturnProductSefareshCode_Result>("CRMspLkShomaranReturnProductSefareshCode", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkShomaranReturnProductTracing_Result> CRMspLkShomaranReturnProductTracing(int? prdId, int? whId, string linkAccWhCode)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter3 = ((linkAccWhCode != null) ? new ObjectParameter("LinkAccWhCode", linkAccWhCode) : new ObjectParameter("LinkAccWhCode", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkShomaranReturnProductTracing_Result>("CRMspLkShomaranReturnProductTracing", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkSepSelectLocation_Result> CRMspLkSepSelectLocation(string type, int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((type != null) ? new ObjectParameter("Type", type) : new ObjectParameter("Type", typeof(string)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectLocation_Result>("CRMspLkSepSelectLocation", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectCountryWithAccLinkField_Result> CRMspSelectCountryWithAccLinkField(bool? withLinkAccCountryIdStr, int? languageID, int? defaultLanguageID, bool? withLinkAccData)
	{
		ObjectParameter objectParameter = (withLinkAccCountryIdStr.HasValue ? new ObjectParameter("WithLinkAccCountryIdStr", withLinkAccCountryIdStr) : new ObjectParameter("WithLinkAccCountryIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (withLinkAccData.HasValue ? new ObjectParameter("WithLinkAccData", withLinkAccData) : new ObjectParameter("WithLinkAccData", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCountryWithAccLinkField_Result>("CRMspSelectCountryWithAccLinkField", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspLkUpdateCountryLinkAccByJson(string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkUpdateCountryLinkAccByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8);
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkSepLinkedCity(int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkSepLinkedCity", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkSepLinkedCountry(int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkSepLinkedCountry", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkSepLinkedProvince(int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkSepLinkedProvince", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual int CRMspLkUpdateCityLinkAccByJson(string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkUpdateCityLinkAccByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8);
	}

	public virtual int CRMspLkUpdateProvinceLinkAccByJson(string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkUpdateProvinceLinkAccByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage, objectParameter8);
	}

	public virtual ObjectResult<CRMspSelectCityWithAccLinkField_Result> CRMspSelectCityWithAccLinkField(bool? withLinkAccCityIdStr, int? languageID, int? defaultLanguageID, bool? withLinkAccData)
	{
		ObjectParameter objectParameter = (withLinkAccCityIdStr.HasValue ? new ObjectParameter("WithLinkAccCityIdStr", withLinkAccCityIdStr) : new ObjectParameter("WithLinkAccCityIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (withLinkAccData.HasValue ? new ObjectParameter("WithLinkAccData", withLinkAccData) : new ObjectParameter("WithLinkAccData", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCityWithAccLinkField_Result>("CRMspSelectCityWithAccLinkField", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectProvinceWithAccLinkField_Result> CRMspSelectProvinceWithAccLinkField(bool? withLinkAccProvinceIdStr, int? languageID, int? defaultLanguageID, bool? withLinkAccData)
	{
		ObjectParameter objectParameter = (withLinkAccProvinceIdStr.HasValue ? new ObjectParameter("WithLinkAccProvinceIdStr", withLinkAccProvinceIdStr) : new ObjectParameter("WithLinkAccProvinceIdStr", typeof(bool)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (withLinkAccData.HasValue ? new ObjectParameter("WithLinkAccData", withLinkAccData) : new ObjectParameter("WithLinkAccData", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectProvinceWithAccLinkField_Result>("CRMspSelectProvinceWithAccLinkField", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSReturnOrderTotalCount_Result> CRMspLkSepWSReturnOrderTotalCount(int? userId, DateTime? fDate, DateTime? tDATE, long? ordNumber, int? orderOprId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDATE.HasValue ? new ObjectParameter("TDATE", tDATE) : new ObjectParameter("TDATE", typeof(DateTime)));
		ObjectParameter objectParameter4 = (ordNumber.HasValue ? new ObjectParameter("OrdNumber", ordNumber) : new ObjectParameter("OrdNumber", typeof(long)));
		ObjectParameter objectParameter5 = (orderOprId.HasValue ? new ObjectParameter("OrderOprId", orderOprId) : new ObjectParameter("OrderOprId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSReturnOrderTotalCount_Result>("CRMspLkSepWSReturnOrderTotalCount", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int CRMspInsertUpdateLinkAccSettingDetails(string objectType, string objectJson, bool? delByObjectType, string linkAccSettingIds, bool? delByLinkAccSettingId, string noAddForLinkAccSettingIds, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? linkAccSystemId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter2 = ((objectJson != null) ? new ObjectParameter("ObjectJson", objectJson) : new ObjectParameter("ObjectJson", typeof(string)));
		ObjectParameter objectParameter3 = (delByObjectType.HasValue ? new ObjectParameter("DelByObjectType", delByObjectType) : new ObjectParameter("DelByObjectType", typeof(bool)));
		ObjectParameter objectParameter4 = ((linkAccSettingIds != null) ? new ObjectParameter("LinkAccSettingIds", linkAccSettingIds) : new ObjectParameter("LinkAccSettingIds", typeof(string)));
		ObjectParameter objectParameter5 = (delByLinkAccSettingId.HasValue ? new ObjectParameter("DelByLinkAccSettingId", delByLinkAccSettingId) : new ObjectParameter("DelByLinkAccSettingId", typeof(bool)));
		ObjectParameter objectParameter6 = ((noAddForLinkAccSettingIds != null) ? new ObjectParameter("NoAddForLinkAccSettingIds", noAddForLinkAccSettingIds) : new ObjectParameter("NoAddForLinkAccSettingIds", typeof(string)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter15 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertUpdateLinkAccSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15);
	}

	public virtual int CRMspInsertUpdateLinkAccSettingDetailsByDefValue(string objectType, string objectJson, string defObjectJson, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? linkAccSystemId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter2 = ((objectJson != null) ? new ObjectParameter("ObjectJson", objectJson) : new ObjectParameter("ObjectJson", typeof(string)));
		ObjectParameter objectParameter3 = ((defObjectJson != null) ? new ObjectParameter("DefObjectJson", defObjectJson) : new ObjectParameter("DefObjectJson", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertUpdateLinkAccSettingDetailsByDefValue", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12);
	}

	public virtual ObjectResult<CRMspLkSepSelectStock_Result> CRMspLkSepSelectStock(int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectStock_Result>("CRMspLkSepSelectStock", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectBuyOrderPaymentsById_Result> CRMspLkSepWSSelectBuyOrderPaymentsById(int? buyOrderPaymentId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (buyOrderPaymentId.HasValue ? new ObjectParameter("BuyOrderPaymentId", buyOrderPaymentId) : new ObjectParameter("BuyOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectBuyOrderPaymentsById_Result>("CRMspLkSepWSSelectBuyOrderPaymentsById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectOrderPaymentsById_Result> CRMspLkSepWSSelectOrderPaymentsById(int? orderPaymentId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectOrderPaymentsById_Result>("CRMspLkSepWSSelectOrderPaymentsById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkSepWSSelectPreOrderPaymentsById_Result> CRMspLkSepWSSelectPreOrderPaymentsById(int? preOrderPaymentId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectPreOrderPaymentsById_Result>("CRMspLkSepWSSelectPreOrderPaymentsById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkNoAvIIWSSelectDoc_Result> CRMspLkNoAvIIWSSelectDoc(int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvIIWSSelectDoc_Result>("CRMspLkNoAvIIWSSelectDoc", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkNoAvIIWSSelectOrder_Result> CRMspLkNoAvIIWSSelectOrder(int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkNoAvIIWSSelectOrder_Result>("CRMspLkNoAvIIWSSelectOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkVwReturnCmpAccountRemaining(int? companyId, ObjectParameter companyRemain)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkVwReturnCmpAccountRemaining", objectParameter, companyRemain);
	}

	public virtual ObjectResult<CRMspSelectLinkAccByViewSetting_Result> CRMspSelectLinkAccByViewSetting(int? linkAccSystemId, int? linkAccByViewSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccByViewSettingId.HasValue ? new ObjectParameter("LinkAccByViewSettingId", linkAccByViewSettingId) : new ObjectParameter("LinkAccByViewSettingId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccByViewSetting_Result>("CRMspSelectLinkAccByViewSetting", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int CRMspUpdateLinkAccByViewSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccByViewSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspSelectLinkAccSettingDB_Result> CRMspSelectLinkAccSettingDB(int? linkAccSystemId, int? linkAccSettingDBId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccSettingDB_Result>("CRMspSelectLinkAccSettingDB", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspInsertLinkAccSettingDB(int? linkAccSystemId, string linkAccSettingDbName, bool? isActive, int? orderView, string linkAccSettingDbTitle, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter insertedLinkAccSettingDBId, ObjectParameter errorCode, string linkAccSettingServerName)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((linkAccSettingDbName != null) ? new ObjectParameter("LinkAccSettingDbName", linkAccSettingDbName) : new ObjectParameter("LinkAccSettingDbName", typeof(string)));
		ObjectParameter objectParameter3 = (isActive.HasValue ? new ObjectParameter("IsActive", isActive) : new ObjectParameter("IsActive", typeof(bool)));
		ObjectParameter objectParameter4 = (orderView.HasValue ? new ObjectParameter("OrderView", orderView) : new ObjectParameter("OrderView", typeof(int)));
		ObjectParameter objectParameter5 = ((linkAccSettingDbTitle != null) ? new ObjectParameter("LinkAccSettingDbTitle", linkAccSettingDbTitle) : new ObjectParameter("LinkAccSettingDbTitle", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = ((linkAccSettingServerName != null) ? new ObjectParameter("LinkAccSettingServerName", linkAccSettingServerName) : new ObjectParameter("LinkAccSettingServerName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccSettingDB", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedLinkAccSettingDBId, errorCode, objectParameter13);
	}

	public virtual ObjectResult<CRMspSelectLinkAccSettingDBIsActive_Result> CRMspSelectLinkAccSettingDBIsActive(int? linkAccSystemId)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccSettingDBIsActive_Result>("CRMspSelectLinkAccSettingDBIsActive", new ObjectParameter[1] { objectParameter });
	}

	public virtual int CRMspUpdateLinkAccSettingDB(int? linkAccSettingDBId, int? orderView, string linkAccSettingDbTitle, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (orderView.HasValue ? new ObjectParameter("OrderView", orderView) : new ObjectParameter("OrderView", typeof(int)));
		ObjectParameter objectParameter3 = ((linkAccSettingDbTitle != null) ? new ObjectParameter("LinkAccSettingDbTitle", linkAccSettingDbTitle) : new ObjectParameter("LinkAccSettingDbTitle", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccSettingDB", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspUpdateLinkAccSettingDBIsActive(int? linkAccSettingDBId, bool? isActive, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter2 = (isActive.HasValue ? new ObjectParameter("IsActive", isActive) : new ObjectParameter("IsActive", typeof(bool)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccSettingDBIsActive", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<CRMspLkSepSelectDatabases_Result> CRMspLkSepSelectDatabases(string linkAccSettingServerName)
	{
		ObjectParameter objectParameter = ((linkAccSettingServerName != null) ? new ObjectParameter("LinkAccSettingServerName", linkAccSettingServerName) : new ObjectParameter("LinkAccSettingServerName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepSelectDatabases_Result>("CRMspLkSepSelectDatabases", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspSelectLinkAccHamrahanSetting_Result> CRMspSelectLinkAccHamrahanSetting(int? linkAccHamrahanSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccHamrahanSettingId.HasValue ? new ObjectParameter("LinkAccHamrahanSettingId", linkAccHamrahanSettingId) : new ObjectParameter("LinkAccHamrahanSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccHamrahanSetting_Result>("CRMspSelectLinkAccHamrahanSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspUpdateLinkAccHamrahanSetting(string settingIdsWithValue, string settingIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((settingIdsWithValue != null) ? new ObjectParameter("SettingIdsWithValue", settingIdsWithValue) : new ObjectParameter("SettingIdsWithValue", typeof(string)));
		ObjectParameter objectParameter2 = ((settingIdsWithValueLang != null) ? new ObjectParameter("SettingIdsWithValueLang", settingIdsWithValueLang) : new ObjectParameter("SettingIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccHamrahanSetting", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int CRMspLkInsertUpdateCompanyGroupsMultiByJson(string companyGroupsMultiJson, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((companyGroupsMultiJson != null) ? new ObjectParameter("CompanyGroupsMultiJson", companyGroupsMultiJson) : new ObjectParameter("CompanyGroupsMultiJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateCompanyGroupsMultiByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkSepWSLinkedDeliveryTerms(int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkSepWSLinkedDeliveryTerms", new ObjectParameter[1] { objectParameter });
	}

	public virtual int CRMspLkSepReturnCmpAccountRemainingInAccCode(int? companyId, ObjectParameter payRemain, int? linkAccSettingDBId, ObjectParameter debitBalance, ObjectParameter creditBalance)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepReturnCmpAccountRemainingInAccCode", objectParameter, payRemain, objectParameter2, debitBalance, creditBalance);
	}

	public virtual int CRMspInsertLinkAccHamrahanSettingDetails(int? objectId, string objectType, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertLinkAccHamrahanSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspLkWSSelectOrderItems_Result> CRMspLkWSSelectOrderItems(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectOrderItems_Result>("CRMspLkWSSelectOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccHamrahanSettingDetails_Result> CRMspSelectLinkAccHamrahanSettingDetails(int? linkAccHamrahanSettingDetailId, int? objectId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccHamrahanSettingDetailId.HasValue ? new ObjectParameter("LinkAccHamrahanSettingDetailId", linkAccHamrahanSettingDetailId) : new ObjectParameter("LinkAccHamrahanSettingDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccHamrahanSettingDetails_Result>("CRMspSelectLinkAccHamrahanSettingDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int CRMspUpdateLinkAccHamrahanSettingDetails(int? objectId, string objectType, string settingDetailIdsWithValue, string settingDetailIdsWithValueLang, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = ((settingDetailIdsWithValue != null) ? new ObjectParameter("SettingDetailIdsWithValue", settingDetailIdsWithValue) : new ObjectParameter("SettingDetailIdsWithValue", typeof(string)));
		ObjectParameter objectParameter4 = ((settingDetailIdsWithValueLang != null) ? new ObjectParameter("SettingDetailIdsWithValueLang", settingDetailIdsWithValueLang) : new ObjectParameter("SettingDetailIdsWithValueLang", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccHamrahanSettingDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkLinkedCountry(int? linkAccSystemId, string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkLinkedCountry", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkLinkedProvince(int? linkAccSystemId, string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkLinkedProvince", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkLinkedCity(int? linkAccSystemId, string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkLinkedCity", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual int CRMspLkWSInsertUpdateOrderGroupsByJson(string orderGroupJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((orderGroupJson != null) ? new ObjectParameter("OrderGroupJson", orderGroupJson) : new ObjectParameter("OrderGroupJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateOrderGroupsByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<CRMspLkWSSelectOrderById_Result> CRMspLkWSSelectOrderById(int? orderId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectOrderById_Result>("CRMspLkWSSelectOrderById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int WSspUpdateOrderAndItemWithAccLinkField(int? orderId, int? ordLinkAccCodeId, string ordLinkAccCode, int? ordLinkAccOrderId, string ordLinkAccOrderNumber, int? ordLinkAccVoucherId, string ordLinkAccVoucherNumber, string ordLinkAccOrderIdStr, string ordLinkAccTransferKey, string ordLinkAccTransferResult, string ordLinkAccData, string itemJson, bool? clearLinkAccFields, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (ordLinkAccCodeId.HasValue ? new ObjectParameter("ordLinkAccCodeId", ordLinkAccCodeId) : new ObjectParameter("ordLinkAccCodeId", typeof(int)));
		ObjectParameter objectParameter3 = ((ordLinkAccCode != null) ? new ObjectParameter("ordLinkAccCode", ordLinkAccCode) : new ObjectParameter("ordLinkAccCode", typeof(string)));
		ObjectParameter objectParameter4 = (ordLinkAccOrderId.HasValue ? new ObjectParameter("ordLinkAccOrderId", ordLinkAccOrderId) : new ObjectParameter("ordLinkAccOrderId", typeof(int)));
		ObjectParameter objectParameter5 = ((ordLinkAccOrderNumber != null) ? new ObjectParameter("ordLinkAccOrderNumber", ordLinkAccOrderNumber) : new ObjectParameter("ordLinkAccOrderNumber", typeof(string)));
		ObjectParameter objectParameter6 = (ordLinkAccVoucherId.HasValue ? new ObjectParameter("ordLinkAccVoucherId", ordLinkAccVoucherId) : new ObjectParameter("ordLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter7 = ((ordLinkAccVoucherNumber != null) ? new ObjectParameter("ordLinkAccVoucherNumber", ordLinkAccVoucherNumber) : new ObjectParameter("ordLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter8 = ((ordLinkAccOrderIdStr != null) ? new ObjectParameter("ordLinkAccOrderIdStr", ordLinkAccOrderIdStr) : new ObjectParameter("ordLinkAccOrderIdStr", typeof(string)));
		ObjectParameter objectParameter9 = ((ordLinkAccTransferKey != null) ? new ObjectParameter("ordLinkAccTransferKey", ordLinkAccTransferKey) : new ObjectParameter("ordLinkAccTransferKey", typeof(string)));
		ObjectParameter objectParameter10 = ((ordLinkAccTransferResult != null) ? new ObjectParameter("ordLinkAccTransferResult", ordLinkAccTransferResult) : new ObjectParameter("ordLinkAccTransferResult", typeof(string)));
		ObjectParameter objectParameter11 = ((ordLinkAccData != null) ? new ObjectParameter("ordLinkAccData", ordLinkAccData) : new ObjectParameter("ordLinkAccData", typeof(string)));
		ObjectParameter objectParameter12 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter13 = (clearLinkAccFields.HasValue ? new ObjectParameter("ClearLinkAccFields", clearLinkAccFields) : new ObjectParameter("ClearLinkAccFields", typeof(bool)));
		ObjectParameter objectParameter14 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter15 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter16 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter17 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter18 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspUpdateOrderAndItemWithAccLinkField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18);
	}

	public virtual int WSspUpdateOrderPaymentWithAccLinkField(int? orderPaymentId, int? ordpayLinkAccHeaderId, string ordpayLinkAccHeaderNumber, int? ordpayLinkAccDetailId, int? ordpayLinkAccVoucherId, string ordpayLinkAccVoucherNumber, string ordpayLinkAccHeaderIdStr, string ordpayLinkAccDetailIdStr, string ordpayLinkAccVoucherIdStr, string ordpayLinkAccPayType, string ordpayLinkAccData, bool? clearLinkAccFields, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (ordpayLinkAccHeaderId.HasValue ? new ObjectParameter("ordpayLinkAccHeaderId", ordpayLinkAccHeaderId) : new ObjectParameter("ordpayLinkAccHeaderId", typeof(int)));
		ObjectParameter objectParameter3 = ((ordpayLinkAccHeaderNumber != null) ? new ObjectParameter("ordpayLinkAccHeaderNumber", ordpayLinkAccHeaderNumber) : new ObjectParameter("ordpayLinkAccHeaderNumber", typeof(string)));
		ObjectParameter objectParameter4 = (ordpayLinkAccDetailId.HasValue ? new ObjectParameter("ordpayLinkAccDetailId", ordpayLinkAccDetailId) : new ObjectParameter("ordpayLinkAccDetailId", typeof(int)));
		ObjectParameter objectParameter5 = (ordpayLinkAccVoucherId.HasValue ? new ObjectParameter("ordpayLinkAccVoucherId", ordpayLinkAccVoucherId) : new ObjectParameter("ordpayLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter6 = ((ordpayLinkAccVoucherNumber != null) ? new ObjectParameter("ordpayLinkAccVoucherNumber", ordpayLinkAccVoucherNumber) : new ObjectParameter("ordpayLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter7 = ((ordpayLinkAccHeaderIdStr != null) ? new ObjectParameter("ordpayLinkAccHeaderIdStr", ordpayLinkAccHeaderIdStr) : new ObjectParameter("ordpayLinkAccHeaderIdStr", typeof(string)));
		ObjectParameter objectParameter8 = ((ordpayLinkAccDetailIdStr != null) ? new ObjectParameter("ordpayLinkAccDetailIdStr", ordpayLinkAccDetailIdStr) : new ObjectParameter("ordpayLinkAccDetailIdStr", typeof(string)));
		ObjectParameter objectParameter9 = ((ordpayLinkAccVoucherIdStr != null) ? new ObjectParameter("ordpayLinkAccVoucherIdStr", ordpayLinkAccVoucherIdStr) : new ObjectParameter("ordpayLinkAccVoucherIdStr", typeof(string)));
		ObjectParameter objectParameter10 = ((ordpayLinkAccPayType != null) ? new ObjectParameter("ordpayLinkAccPayType", ordpayLinkAccPayType) : new ObjectParameter("ordpayLinkAccPayType", typeof(string)));
		ObjectParameter objectParameter11 = ((ordpayLinkAccData != null) ? new ObjectParameter("ordpayLinkAccData", ordpayLinkAccData) : new ObjectParameter("ordpayLinkAccData", typeof(string)));
		ObjectParameter objectParameter12 = (clearLinkAccFields.HasValue ? new ObjectParameter("ClearLinkAccFields", clearLinkAccFields) : new ObjectParameter("ClearLinkAccFields", typeof(bool)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspUpdateOrderPaymentWithAccLinkField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17);
	}

	public virtual ObjectResult<CRMspLkWSCheckDuplicateOrderPayment_Result> CRMspLkWSCheckDuplicateOrderPayment(int? orderPaymentId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSCheckDuplicateOrderPayment_Result>("CRMspLkWSCheckDuplicateOrderPayment", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspLkWSDeleteLinkedPreOrder_Result> CRMspLkWSDeleteLinkedPreOrder(int? linkAccSystemId, string linkAccPreOrderIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((linkAccPreOrderIdStr != null) ? new ObjectParameter("LinkAccPreOrderIdStr", linkAccPreOrderIdStr) : new ObjectParameter("LinkAccPreOrderIdStr", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSDeleteLinkedPreOrder_Result>("CRMspLkWSDeleteLinkedPreOrder", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkWSIssueOrUpdatePreOrderByJson(int? linkAccSystemId, int? preOrderOprID, int? defReferUserId, int? defWhId, string preOrderJson, string preOrderItemJson, int? pordCurrencyUnitId, int? prjcnvsStatusGroupId, string prjTitle, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage, bool? addPayFromLinkAcc, int? paymentTypeId, string preOrderPaymentJson, int? centerId)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (preOrderOprID.HasValue ? new ObjectParameter("PreOrderOprID", preOrderOprID) : new ObjectParameter("PreOrderOprID", typeof(int)));
		ObjectParameter objectParameter3 = (defReferUserId.HasValue ? new ObjectParameter("DefReferUserId", defReferUserId) : new ObjectParameter("DefReferUserId", typeof(int)));
		ObjectParameter objectParameter4 = (defWhId.HasValue ? new ObjectParameter("DefWhId", defWhId) : new ObjectParameter("DefWhId", typeof(int)));
		ObjectParameter objectParameter5 = ((preOrderJson != null) ? new ObjectParameter("PreOrderJson", preOrderJson) : new ObjectParameter("PreOrderJson", typeof(string)));
		ObjectParameter objectParameter6 = ((preOrderItemJson != null) ? new ObjectParameter("PreOrderItemJson", preOrderItemJson) : new ObjectParameter("PreOrderItemJson", typeof(string)));
		ObjectParameter objectParameter7 = (pordCurrencyUnitId.HasValue ? new ObjectParameter("pordCurrencyUnitId", pordCurrencyUnitId) : new ObjectParameter("pordCurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter8 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter9 = ((prjTitle != null) ? new ObjectParameter("prjTitle", prjTitle) : new ObjectParameter("prjTitle", typeof(string)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter12 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (addPayFromLinkAcc.HasValue ? new ObjectParameter("AddPayFromLinkAcc", addPayFromLinkAcc) : new ObjectParameter("AddPayFromLinkAcc", typeof(bool)));
		ObjectParameter objectParameter20 = (paymentTypeId.HasValue ? new ObjectParameter("PaymentTypeId", paymentTypeId) : new ObjectParameter("PaymentTypeId", typeof(int)));
		ObjectParameter objectParameter21 = ((preOrderPaymentJson != null) ? new ObjectParameter("PreOrderPaymentJson", preOrderPaymentJson) : new ObjectParameter("PreOrderPaymentJson", typeof(string)));
		ObjectParameter objectParameter22 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkWSIssueOrUpdatePreOrderByJson", new ObjectParameter[23]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, errorMessage, objectParameter19,
			objectParameter20, objectParameter21, objectParameter22
		});
	}

	public virtual ObjectResult<CRMspLkWSCheckDuplicatePreOrderPayment_Result> CRMspLkWSCheckDuplicatePreOrderPayment(int? preOrderPaymentId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSCheckDuplicatePreOrderPayment_Result>("CRMspLkWSCheckDuplicatePreOrderPayment", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspLkWSSelectPreOrderById_Result> CRMspLkWSSelectPreOrderById(int? preOrderId, int? languageId, int? defaultLanguageId, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectPreOrderById_Result>("CRMspLkWSSelectPreOrderById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkWSSelectPreOrderItems_Result> CRMspLkWSSelectPreOrderItems(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectPreOrderItems_Result>("CRMspLkWSSelectPreOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int WSspUpdatePreOrderAndItemWithAccLinkField(int? preOrderId, int? pordLinkAccPreOrderId, string pordLinkAccPreOrderNumber, string pordLinkAccPreOrderIdStr, string pordLinkAccData, string itemJson, bool? clearLinkAccFields, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (pordLinkAccPreOrderId.HasValue ? new ObjectParameter("pordLinkAccPreOrderId", pordLinkAccPreOrderId) : new ObjectParameter("pordLinkAccPreOrderId", typeof(int)));
		ObjectParameter objectParameter3 = ((pordLinkAccPreOrderNumber != null) ? new ObjectParameter("pordLinkAccPreOrderNumber", pordLinkAccPreOrderNumber) : new ObjectParameter("pordLinkAccPreOrderNumber", typeof(string)));
		ObjectParameter objectParameter4 = ((pordLinkAccPreOrderIdStr != null) ? new ObjectParameter("pordLinkAccPreOrderIdStr", pordLinkAccPreOrderIdStr) : new ObjectParameter("pordLinkAccPreOrderIdStr", typeof(string)));
		ObjectParameter objectParameter5 = ((pordLinkAccData != null) ? new ObjectParameter("pordLinkAccData", pordLinkAccData) : new ObjectParameter("pordLinkAccData", typeof(string)));
		ObjectParameter objectParameter6 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter7 = (clearLinkAccFields.HasValue ? new ObjectParameter("ClearLinkAccFields", clearLinkAccFields) : new ObjectParameter("ClearLinkAccFields", typeof(bool)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspUpdatePreOrderAndItemWithAccLinkField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12);
	}

	public virtual int WSspUpdatePreOrderPaymentWithAccLinkField(int? preOrderPaymentId, int? pordpayLinkAccHeaderId, string pordpayLinkAccHeaderNumber, int? pordpayLinkAccDetailId, int? pordpayLinkAccVoucherId, string pordpayLinkAccVoucherNumber, string pordpayLinkAccHeaderIdStr, string pordpayLinkAccDetailIdStr, string pordpayLinkAccVoucherIdStr, string pordpayLinkAccPayType, string pordpayLinkAccData, bool? clearLinkAccFields, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (pordpayLinkAccHeaderId.HasValue ? new ObjectParameter("pordpayLinkAccHeaderId", pordpayLinkAccHeaderId) : new ObjectParameter("pordpayLinkAccHeaderId", typeof(int)));
		ObjectParameter objectParameter3 = ((pordpayLinkAccHeaderNumber != null) ? new ObjectParameter("pordpayLinkAccHeaderNumber", pordpayLinkAccHeaderNumber) : new ObjectParameter("pordpayLinkAccHeaderNumber", typeof(string)));
		ObjectParameter objectParameter4 = (pordpayLinkAccDetailId.HasValue ? new ObjectParameter("pordpayLinkAccDetailId", pordpayLinkAccDetailId) : new ObjectParameter("pordpayLinkAccDetailId", typeof(int)));
		ObjectParameter objectParameter5 = (pordpayLinkAccVoucherId.HasValue ? new ObjectParameter("pordpayLinkAccVoucherId", pordpayLinkAccVoucherId) : new ObjectParameter("pordpayLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter6 = ((pordpayLinkAccVoucherNumber != null) ? new ObjectParameter("pordpayLinkAccVoucherNumber", pordpayLinkAccVoucherNumber) : new ObjectParameter("pordpayLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter7 = ((pordpayLinkAccHeaderIdStr != null) ? new ObjectParameter("pordpayLinkAccHeaderIdStr", pordpayLinkAccHeaderIdStr) : new ObjectParameter("pordpayLinkAccHeaderIdStr", typeof(string)));
		ObjectParameter objectParameter8 = ((pordpayLinkAccDetailIdStr != null) ? new ObjectParameter("pordpayLinkAccDetailIdStr", pordpayLinkAccDetailIdStr) : new ObjectParameter("pordpayLinkAccDetailIdStr", typeof(string)));
		ObjectParameter objectParameter9 = ((pordpayLinkAccVoucherIdStr != null) ? new ObjectParameter("pordpayLinkAccVoucherIdStr", pordpayLinkAccVoucherIdStr) : new ObjectParameter("pordpayLinkAccVoucherIdStr", typeof(string)));
		ObjectParameter objectParameter10 = ((pordpayLinkAccPayType != null) ? new ObjectParameter("pordpayLinkAccPayType", pordpayLinkAccPayType) : new ObjectParameter("pordpayLinkAccPayType", typeof(string)));
		ObjectParameter objectParameter11 = ((pordpayLinkAccData != null) ? new ObjectParameter("pordpayLinkAccData", pordpayLinkAccData) : new ObjectParameter("pordpayLinkAccData", typeof(string)));
		ObjectParameter objectParameter12 = (clearLinkAccFields.HasValue ? new ObjectParameter("ClearLinkAccFields", clearLinkAccFields) : new ObjectParameter("ClearLinkAccFields", typeof(bool)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspUpdatePreOrderPaymentWithAccLinkField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17);
	}

	public virtual ObjectResult<CRMspLkWSDeleteLinkedDoc_Result> CRMspLkWSDeleteLinkedDoc(int? linkAccSystemId, string linkAccDocIdStr, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = ((linkAccDocIdStr != null) ? new ObjectParameter("LinkAccDocIdStr", linkAccDocIdStr) : new ObjectParameter("LinkAccDocIdStr", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSDeleteLinkedDoc_Result>("CRMspLkWSDeleteLinkedDoc", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspLkWSIssueOrUpdateDocByJson(int? linkAccSystemId, int? docOprId, int? defWhId, int? defWhIdI, string docJson, string docItemJson, int? prjcnvsStatusGroupId, string prjTitle, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (docOprId.HasValue ? new ObjectParameter("DocOprId", docOprId) : new ObjectParameter("DocOprId", typeof(int)));
		ObjectParameter objectParameter3 = (defWhId.HasValue ? new ObjectParameter("DefWhId", defWhId) : new ObjectParameter("DefWhId", typeof(int)));
		ObjectParameter objectParameter4 = (defWhIdI.HasValue ? new ObjectParameter("DefWhIdI", defWhIdI) : new ObjectParameter("DefWhIdI", typeof(int)));
		ObjectParameter objectParameter5 = ((docJson != null) ? new ObjectParameter("DocJson", docJson) : new ObjectParameter("DocJson", typeof(string)));
		ObjectParameter objectParameter6 = ((docItemJson != null) ? new ObjectParameter("DocItemJson", docItemJson) : new ObjectParameter("DocItemJson", typeof(string)));
		ObjectParameter objectParameter7 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter8 = ((prjTitle != null) ? new ObjectParameter("prjTitle", prjTitle) : new ObjectParameter("prjTitle", typeof(string)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter11 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter12 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter17 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspLkWSIssueOrUpdateDocByJson", new ObjectParameter[19]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, errorMessage, objectParameter18
		});
	}

	public virtual ObjectResult<CRMspLkWSSelectDocById_Result> CRMspLkWSSelectDocById(int? docId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectDocById_Result>("CRMspLkWSSelectDocById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkWSSelectDocItems_Result> CRMspLkWSSelectDocItems(int? docId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectDocItems_Result>("CRMspLkWSSelectDocItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int WSspUpdateDocAndItemWithAccLinkField(int? docId, int? docLinkAccCodeId, string docLinkAccCode, int? docLinkAccDocId, string docLinkAccDocNumber, int? docLinkAccVoucherId, string docLinkAccVoucherNumber, string docLinkAccDocIdStr, string docLinkAccDocType, string docLinkAccData, string itemJson, bool? clearLinkAccFields, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (docId.HasValue ? new ObjectParameter("DocId", docId) : new ObjectParameter("DocId", typeof(int)));
		ObjectParameter objectParameter2 = (docLinkAccCodeId.HasValue ? new ObjectParameter("DocLinkAccCodeId", docLinkAccCodeId) : new ObjectParameter("DocLinkAccCodeId", typeof(int)));
		ObjectParameter objectParameter3 = ((docLinkAccCode != null) ? new ObjectParameter("DocLinkAccCode", docLinkAccCode) : new ObjectParameter("DocLinkAccCode", typeof(string)));
		ObjectParameter objectParameter4 = (docLinkAccDocId.HasValue ? new ObjectParameter("DocLinkAccDocId", docLinkAccDocId) : new ObjectParameter("DocLinkAccDocId", typeof(int)));
		ObjectParameter objectParameter5 = ((docLinkAccDocNumber != null) ? new ObjectParameter("DocLinkAccDocNumber", docLinkAccDocNumber) : new ObjectParameter("DocLinkAccDocNumber", typeof(string)));
		ObjectParameter objectParameter6 = (docLinkAccVoucherId.HasValue ? new ObjectParameter("DocLinkAccVoucherId", docLinkAccVoucherId) : new ObjectParameter("DocLinkAccVoucherId", typeof(int)));
		ObjectParameter objectParameter7 = ((docLinkAccVoucherNumber != null) ? new ObjectParameter("DocLinkAccVoucherNumber", docLinkAccVoucherNumber) : new ObjectParameter("DocLinkAccVoucherNumber", typeof(string)));
		ObjectParameter objectParameter8 = ((docLinkAccDocIdStr != null) ? new ObjectParameter("DocLinkAccDocIdStr", docLinkAccDocIdStr) : new ObjectParameter("DocLinkAccDocIdStr", typeof(string)));
		ObjectParameter objectParameter9 = ((docLinkAccDocType != null) ? new ObjectParameter("DocLinkAccDocType", docLinkAccDocType) : new ObjectParameter("DocLinkAccDocType", typeof(string)));
		ObjectParameter objectParameter10 = ((docLinkAccData != null) ? new ObjectParameter("DocLinkAccData", docLinkAccData) : new ObjectParameter("DocLinkAccData", typeof(string)));
		ObjectParameter objectParameter11 = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter12 = (clearLinkAccFields.HasValue ? new ObjectParameter("ClearLinkAccFields", clearLinkAccFields) : new ObjectParameter("ClearLinkAccFields", typeof(bool)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspUpdateDocAndItemWithAccLinkField", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17);
	}

	public virtual int CRMspUpdateLinkAccSettingPartValue(int? linkAccSettingId, string partValue, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (linkAccSettingId.HasValue ? new ObjectParameter("LinkAccSettingId", linkAccSettingId) : new ObjectParameter("LinkAccSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((partValue != null) ? new ObjectParameter("PartValue", partValue) : new ObjectParameter("PartValue", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateLinkAccSettingPartValue", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual int CRMspLkSepWSDistributeCmpSumPaymentToOrders(int? sepOrdType, string orderIds, bool? isInsertPayAccordingPayRemain, int? crmFPId, int? linkAccSettingDBId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (sepOrdType.HasValue ? new ObjectParameter("SepOrdType", sepOrdType) : new ObjectParameter("SepOrdType", typeof(int)));
		ObjectParameter objectParameter2 = ((orderIds != null) ? new ObjectParameter("OrderIds", orderIds) : new ObjectParameter("OrderIds", typeof(string)));
		ObjectParameter objectParameter3 = (isInsertPayAccordingPayRemain.HasValue ? new ObjectParameter("IsInsertPayAccordingPayRemain", isInsertPayAccordingPayRemain) : new ObjectParameter("IsInsertPayAccordingPayRemain", typeof(bool)));
		ObjectParameter objectParameter4 = (crmFPId.HasValue ? new ObjectParameter("CrmFPId", crmFPId) : new ObjectParameter("CrmFPId", typeof(int)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter8 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (defLanguageID.HasValue ? new ObjectParameter("DefLanguageID", defLanguageID) : new ObjectParameter("DefLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDistributeCmpSumPaymentToOrders", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdatePayConditionByJson(string payConditionJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((payConditionJson != null) ? new ObjectParameter("PayConditionJson", payConditionJson) : new ObjectParameter("PayConditionJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdatePayConditionByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<CRMspLkInsertUpdateCenter_Result> CRMspLkInsertUpdateCenter(string js, int? userId, int? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((js != null) ? new ObjectParameter("Js", js) : new ObjectParameter("Js", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkInsertUpdateCenter_Result>("CRMspLkInsertUpdateCenter", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspLkInsertUpdateCompanyGroups_Result> CRMspLkInsertUpdateCompanyGroups(string js, int? userId, int? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((js != null) ? new ObjectParameter("Js", js) : new ObjectParameter("Js", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkInsertUpdateCompanyGroups_Result>("CRMspLkInsertUpdateCompanyGroups", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<CRMspSelectCenterWithAccLinkField_Result> CRMspSelectCenterWithAccLinkField(int? languageID, int? defaultLanguageID, bool? withLinkAccCenterIdStr, bool? withLinkAccCenterCode, bool? withLinkAccData)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (withLinkAccCenterIdStr.HasValue ? new ObjectParameter("WithLinkAccCenterIdStr", withLinkAccCenterIdStr) : new ObjectParameter("WithLinkAccCenterIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (withLinkAccCenterCode.HasValue ? new ObjectParameter("WithLinkAccCenterCode", withLinkAccCenterCode) : new ObjectParameter("WithLinkAccCenterCode", typeof(bool)));
		ObjectParameter objectParameter5 = (withLinkAccData.HasValue ? new ObjectParameter("WithLinkAccData", withLinkAccData) : new ObjectParameter("WithLinkAccData", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCenterWithAccLinkField_Result>("CRMspSelectCenterWithAccLinkField", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectCompanyGroupsWithAccLinkField_Result> CRMspSelectCompanyGroupsWithAccLinkField(int? languageID, int? defaultLanguageID, bool? withLinkAccGroupIdStr, bool? withLinkAccData)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (withLinkAccGroupIdStr.HasValue ? new ObjectParameter("WithLinkAccGroupIdStr", withLinkAccGroupIdStr) : new ObjectParameter("WithLinkAccGroupIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (withLinkAccData.HasValue ? new ObjectParameter("WithLinkAccData", withLinkAccData) : new ObjectParameter("WithLinkAccData", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyGroupsWithAccLinkField_Result>("CRMspSelectCompanyGroupsWithAccLinkField", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int CRMspLkInsertUpdateCompanySubGroupsByJson(string companySubGroupJson, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((companySubGroupJson != null) ? new ObjectParameter("CompanySubGroupJson", companySubGroupJson) : new ObjectParameter("CompanySubGroupJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateCompanySubGroupsByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateCurrencyUnitByJson(string currencyUnitJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((currencyUnitJson != null) ? new ObjectParameter("CurrencyUnitJson", currencyUnitJson) : new ObjectParameter("CurrencyUnitJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateCurrencyUnitByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdatePreOrderOprByJson(string preOrderOprJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((preOrderOprJson != null) ? new ObjectParameter("PreOrderOprJson", preOrderOprJson) : new ObjectParameter("PreOrderOprJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdatePreOrderOprByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdatePreOrderTypeByJson(string preOrderTypeJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((preOrderTypeJson != null) ? new ObjectParameter("PreOrderTypeJson", preOrderTypeJson) : new ObjectParameter("PreOrderTypeJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdatePreOrderTypeByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateOrderOprByJson(string orderOprJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((orderOprJson != null) ? new ObjectParameter("OrderOprJson", orderOprJson) : new ObjectParameter("OrderOprJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateOrderOprByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateSaleAreasByJson(string saleAreaJson, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((saleAreaJson != null) ? new ObjectParameter("SaleAreaJson", saleAreaJson) : new ObjectParameter("SaleAreaJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateSaleAreasByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkInsertUpdateCompanyGroupsIIIByJson(string companyGroupsIIIJson, int? userId, int? month1, int? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((companyGroupsIIIJson != null) ? new ObjectParameter("CompanyGroupsIIIJson", companyGroupsIIIJson) : new ObjectParameter("CompanyGroupsIIIJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateCompanyGroupsIIIByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkInsertUpdateBankingAccountsByJson(string itemJson, int? crmUserId, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateBankingAccountsByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkInsertUpdateBankingBanksByJson(string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateBankingBanksByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkInsertUpdateBankingBranchesByJson(string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateBankingBranchesByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkInsertUpdateCashesByJson(string itemJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkInsertUpdateCashesByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateOrderPaymentGroupsIByJson(string itemJson, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateOrderPaymentGroupsIByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual int CRMspLkWSInsertUpdateOrderPaymentGroupsIIByJson(string itemJson, int? userId, short? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((itemJson != null) ? new ObjectParameter("ItemJson", itemJson) : new ObjectParameter("ItemJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkWSInsertUpdateOrderPaymentGroupsIIByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage);
	}

	public virtual ObjectResult<CRMspLkWSSelectOrderPayments_Result> CRMspLkWSSelectOrderPayments(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectOrderPayments_Result>("CRMspLkWSSelectOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkWSSelectOrderPaymentsWithId_Result> CRMspLkWSSelectOrderPaymentsWithId(int? orderPaymentId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectOrderPaymentsWithId_Result>("CRMspLkWSSelectOrderPaymentsWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkWSSelectPreOrderPayments_Result> CRMspLkWSSelectPreOrderPayments(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectPreOrderPayments_Result>("CRMspLkWSSelectPreOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspLkWSSelectPreOrderPaymentsWithId_Result> CRMspLkWSSelectPreOrderPaymentsWithId(int? preOrderPaymentId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkWSSelectPreOrderPaymentsWithId_Result>("CRMspLkWSSelectPreOrderPaymentsWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkSepWSDeleteOrderCommissionFromSep(int? orderCommissionId, int? mode, int? linkAccSettingDBId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (orderCommissionId.HasValue ? new ObjectParameter("OrderCommissionId", orderCommissionId) : new ObjectParameter("OrderCommissionId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteOrderCommissionFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkSepWSDeleteOrderCommissionsAllFromSep(int? orderId, int? mode, int? linkAccSettingDBId, int? crmUserId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSDeleteOrderCommissionsAllFromSep", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, errorMessage);
	}

	public virtual int CRMspLkSepWSInsertUpdateOrderCommission(int? orderCommissionId, int? sepFiscalYearRef, int? linkAccSettingDBId, int? crmUserId, string appType, ObjectParameter insertedId, ObjectParameter insertedNumber, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (orderCommissionId.HasValue ? new ObjectParameter("OrderCommissionId", orderCommissionId) : new ObjectParameter("OrderCommissionId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateOrderCommission", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, insertedId, insertedNumber, errorMessage);
	}

	public virtual int CRMspLkSepWSInsertUpdateOrderCommissionsAll(int? orderId, int? sepFiscalYearRef, int? crmUserId, string appType, ObjectParameter errorMessage, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (sepFiscalYearRef.HasValue ? new ObjectParameter("SepFiscalYearRef", sepFiscalYearRef) : new ObjectParameter("SepFiscalYearRef", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepWSInsertUpdateOrderCommissionsAll", objectParameter, objectParameter2, objectParameter3, objectParameter4, errorMessage, objectParameter5);
	}

	public virtual ObjectResult<CRMspLkSepWSSelectOrderCommissionsByOrdId_Result> CRMspLkSepWSSelectOrderCommissionsByOrdId(int? orderId, int? linkAccSettingDBId, int? languageID, int? defaultLanguageID, int? commUserId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (commUserId.HasValue ? new ObjectParameter("CommUserId", commUserId) : new ObjectParameter("CommUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkSepWSSelectOrderCommissionsByOrdId_Result>("CRMspLkSepWSSelectOrderCommissionsByOrdId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<mct_Link_Result> CRMspDeleteLinkAccSettingUser(int? linkAccSettingUserId)
	{
		ObjectParameter objectParameter = (linkAccSettingUserId.HasValue ? new ObjectParameter("LinkAccSettingUserId", linkAccSettingUserId) : new ObjectParameter("LinkAccSettingUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Link_Result>("CRMspDeleteLinkAccSettingUser", new ObjectParameter[1] { objectParameter });
	}

	public virtual int CRMspInsertUpdateLinkAccSettingUsers(int? linkAccSettingUserId, int? linkAccSettingDBId, int? crmUserId, string userName, string password, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter insertedId)
	{
		ObjectParameter objectParameter = (linkAccSettingUserId.HasValue ? new ObjectParameter("LinkAccSettingUserId", linkAccSettingUserId) : new ObjectParameter("LinkAccSettingUserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter5 = ((password != null) ? new ObjectParameter("Password", password) : new ObjectParameter("Password", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInsertUpdateLinkAccSettingUsers", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedId);
	}

	public virtual ObjectResult<CRMspSelectLinkAccSettingUsers_Result> CRMspSelectLinkAccSettingUsers(int? linkAccSettingUserId, int? linkAccSettingDBId, int? crmUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSettingUserId.HasValue ? new ObjectParameter("LinkAccSettingUserId", linkAccSettingUserId) : new ObjectParameter("LinkAccSettingUserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccSettingUsers_Result>("CRMspSelectLinkAccSettingUsers", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectProductWithAccLinkField_Result> CRMspSelectProductWithAccLinkField(bool? withLinkAccPrdCode, bool? withLinkPrdId, bool? withLinkPrdIdStr, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (withLinkAccPrdCode.HasValue ? new ObjectParameter("WithLinkAccPrdCode", withLinkAccPrdCode) : new ObjectParameter("WithLinkAccPrdCode", typeof(bool)));
		ObjectParameter objectParameter2 = (withLinkPrdId.HasValue ? new ObjectParameter("WithLinkPrdId", withLinkPrdId) : new ObjectParameter("WithLinkPrdId", typeof(bool)));
		ObjectParameter objectParameter3 = (withLinkPrdIdStr.HasValue ? new ObjectParameter("WithLinkPrdIdStr", withLinkPrdIdStr) : new ObjectParameter("WithLinkPrdIdStr", typeof(bool)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectProductWithAccLinkField_Result>("CRMspSelectProductWithAccLinkField", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<CRMspLkHolooWSSelectOrderItems_Result> CRMspLkHolooWSSelectOrderItems(int? orderId, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkHolooWSSelectOrderItems_Result>("CRMspLkHolooWSSelectOrderItems", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result> CRMspLkHolooSelectCompanyWithLinkAccIdStr(string linkAccIds, int? languageID, int? defaultLanguageID, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = ((linkAccIds != null) ? new ObjectParameter("LinkAccIds", linkAccIds) : new ObjectParameter("LinkAccIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result>("CRMspLkHolooSelectCompanyWithLinkAccIdStr", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspLkHolooSelectProductWithLinkAccFields_Result> CRMspLkHolooSelectProductWithLinkAccFields(int? productId, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLkHolooSelectProductWithLinkAccFields_Result>("CRMspLkHolooSelectProductWithLinkAccFields", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int CRMspLkHolooInsertUpdateCompanyByJson(string cmpJson, int? referUserId, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, int? defaultLanguageID, string appType, ObjectParameter errorMessage, int? centerId, int? linkAccSettingDBId, bool? preventCompanyFieldsUpdate)
	{
		ObjectParameter objectParameter = ((cmpJson != null) ? new ObjectParameter("CmpJson", cmpJson) : new ObjectParameter("CmpJson", typeof(string)));
		ObjectParameter objectParameter2 = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter12 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter13 = (preventCompanyFieldsUpdate.HasValue ? new ObjectParameter("PreventCompanyFieldsUpdate", preventCompanyFieldsUpdate) : new ObjectParameter("PreventCompanyFieldsUpdate", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkHolooInsertUpdateCompanyByJson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual ObjectResult<CRMspSelectLinkAccSettingBySystemId_Result> CRMspSelectLinkAccSettingBySystemId(int? linkAccSystemId, int? linkAccSettingId, int? linkAccSettingDBId, string objectType, string partTitle, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingId.HasValue ? new ObjectParameter("LinkAccSettingId", linkAccSettingId) : new ObjectParameter("LinkAccSettingId", typeof(int)));
		ObjectParameter objectParameter3 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter4 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter5 = ((partTitle != null) ? new ObjectParameter("PartTitle", partTitle) : new ObjectParameter("PartTitle", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccSettingBySystemId_Result>("CRMspSelectLinkAccSettingBySystemId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result> CRMspLKWSSelectActiveWareHouseByLinkAccData(int? userId, int? centerId, int? linkAccSystemId, int? linkAccSettingDBId, bool? isAccLinked, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter3 = (linkAccSystemId.HasValue ? new ObjectParameter("LinkAccSystemId", linkAccSystemId) : new ObjectParameter("LinkAccSystemId", typeof(int)));
		ObjectParameter objectParameter4 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		ObjectParameter objectParameter5 = (isAccLinked.HasValue ? new ObjectParameter("IsAccLinked", isAccLinked) : new ObjectParameter("IsAccLinked", typeof(bool)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result>("CRMspLKWSSelectActiveWareHouseByLinkAccData", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}
}
