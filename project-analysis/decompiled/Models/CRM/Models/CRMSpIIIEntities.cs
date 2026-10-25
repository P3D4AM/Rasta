using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using CRM.General.Security;

namespace CRM.Models;

public class CRMSpIIIEntities : DbContext
{
	public CRMSpIIIEntities()
		: base("name=CRMSpIIIEntities")
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

	public virtual ObjectResult<CRMspFileSearchWebSmart_Result> CRMspFileSearchWebSmart(string searchVal, int? userID, int? languageID, int? defaultLanguageID, string searchConditionMode, int? centerId, int? pageNumber, int? pageSize, ObjectParameter totalCount)
	{
		ObjectParameter objectParameter = ((searchVal != null) ? new ObjectParameter("SearchVal", searchVal) : new ObjectParameter("SearchVal", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchConditionMode != null) ? new ObjectParameter("SearchConditionMode", searchConditionMode) : new ObjectParameter("SearchConditionMode", typeof(string)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspFileSearchWebSmart_Result>("CRMspFileSearchWebSmart", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, totalCount });
	}

	public virtual int ScorespInsertDuplicateScoreRule(int? ruleId, string ruleTitleJson, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, int? languageId, ObjectParameter insertedRuleId)
	{
		ObjectParameter objectParameter = (ruleId.HasValue ? new ObjectParameter("RuleId", ruleId) : new ObjectParameter("RuleId", typeof(int)));
		ObjectParameter objectParameter2 = ((ruleTitleJson != null) ? new ObjectParameter("RuleTitleJson", ruleTitleJson) : new ObjectParameter("RuleTitleJson", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ScorespInsertDuplicateScoreRule", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, insertedRuleId);
	}

	public virtual ObjectResult<WSspSearchBuyOrders_Result> WSspSearchBuyOrders(string searchVal, int? userID, int? languageID, int? defaultLanguageID, string searchConditionMode, int? centerId, int? pageNumber, int? pageSize, ObjectParameter totalCount)
	{
		ObjectParameter objectParameter = ((searchVal != null) ? new ObjectParameter("SearchVal", searchVal) : new ObjectParameter("SearchVal", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchConditionMode != null) ? new ObjectParameter("SearchConditionMode", searchConditionMode) : new ObjectParameter("SearchConditionMode", typeof(string)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSearchBuyOrders_Result>("WSspSearchBuyOrders", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, totalCount });
	}

	public virtual ObjectResult<WSspSearchOrders_Result> WSspSearchOrders(string searchVal, int? userID, int? languageID, int? defaultLanguageID, string searchConditionMode, int? centerId, int? pageNumber, int? pageSize, ObjectParameter totalCount)
	{
		ObjectParameter objectParameter = ((searchVal != null) ? new ObjectParameter("SearchVal", searchVal) : new ObjectParameter("SearchVal", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchConditionMode != null) ? new ObjectParameter("SearchConditionMode", searchConditionMode) : new ObjectParameter("SearchConditionMode", typeof(string)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSearchOrders_Result>("WSspSearchOrders", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, totalCount });
	}

	public virtual ObjectResult<WSspSearchPreOrders_Result> WSspSearchPreOrders(string searchVal, int? userID, int? languageID, int? defaultLanguageID, string searchConditionMode, int? centerId, int? pageNumber, int? pageSize, ObjectParameter totalCount)
	{
		ObjectParameter objectParameter = ((searchVal != null) ? new ObjectParameter("SearchVal", searchVal) : new ObjectParameter("SearchVal", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchConditionMode != null) ? new ObjectParameter("SearchConditionMode", searchConditionMode) : new ObjectParameter("SearchConditionMode", typeof(string)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSearchPreOrders_Result>("WSspSearchPreOrders", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, totalCount });
	}

	public virtual int WSspUpdateProductMulti(string prdGroupdJson, string fieldJson, int? userId, DateTime? registerDate, string registerDatePersian, int? fPId, short? month1, string appType, int? defaultLanguageId, ObjectParameter result)
	{
		ObjectParameter objectParameter = ((prdGroupdJson != null) ? new ObjectParameter("PrdGroupdJson", prdGroupdJson) : new ObjectParameter("PrdGroupdJson", typeof(string)));
		ObjectParameter objectParameter2 = ((fieldJson != null) ? new ObjectParameter("FieldJson", fieldJson) : new ObjectParameter("FieldJson", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspUpdateProductMulti", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, result);
	}

	public virtual ObjectResult<SecspSearchLetters_Result> SecspSearchLetters(string searchVal, int? userID, int? languageID, int? defaultLanguageID, string searchConditionMode, int? centerId, int? pageNumber, int? pageSize, ObjectParameter totalCount)
	{
		ObjectParameter objectParameter = ((searchVal != null) ? new ObjectParameter("SearchVal", searchVal) : new ObjectParameter("SearchVal", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchConditionMode != null) ? new ObjectParameter("SearchConditionMode", searchConditionMode) : new ObjectParameter("SearchConditionMode", typeof(string)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SecspSearchLetters_Result>("SecspSearchLetters", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, totalCount });
	}

	public virtual int ScorespInsertAndCalcOrderCancelledScores(int? orderId, DateTime? currDate, bool? updateCompanyGroups, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, int? centerId, ObjectParameter result)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ScorespInsertAndCalcOrderCancelledScores", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, result);
	}

	public virtual ObjectResult<ScorespReport_Result> ScorespReport(DateTime? fromScoreDate, DateTime? toScoreDate, string scoreRuleIds, string companyId, string textEarningScore, string textSpendScore, int? centerId, int? rptUserId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fromScoreDate.HasValue ? new ObjectParameter("FromScoreDate", fromScoreDate) : new ObjectParameter("FromScoreDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (toScoreDate.HasValue ? new ObjectParameter("ToScoreDate", toScoreDate) : new ObjectParameter("ToScoreDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((scoreRuleIds != null) ? new ObjectParameter("ScoreRuleIds", scoreRuleIds) : new ObjectParameter("ScoreRuleIds", typeof(string)));
		ObjectParameter objectParameter4 = ((companyId != null) ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(string)));
		ObjectParameter objectParameter5 = ((textEarningScore != null) ? new ObjectParameter("TextEarningScore", textEarningScore) : new ObjectParameter("TextEarningScore", typeof(string)));
		ObjectParameter objectParameter6 = ((textSpendScore != null) ? new ObjectParameter("TextSpendScore", textSpendScore) : new ObjectParameter("TextSpendScore", typeof(string)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (rptUserId.HasValue ? new ObjectParameter("rptUserId", rptUserId) : new ObjectParameter("rptUserId", typeof(int)));
		ObjectParameter objectParameter9 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter10 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ScorespReport_Result>("ScorespReport", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<ScorespReportSearchCompany_Result> ScorespReportSearchCompany(string val, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ScorespReportSearchCompany_Result>("ScorespReportSearchCompany", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<ScorespInsertAndCalcScores_Result> ScorespInsertAndCalcScores(DateTime? fromDate, DateTime? toDate, string scoreRuleIds, string companyId, DateTime? currDate, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, bool? updateCompanyGroups, int? centerId, bool? isReturnCntRow, ObjectParameter returnCntRow, string textEarningScore, string textSpendScore)
	{
		ObjectParameter objectParameter = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((scoreRuleIds != null) ? new ObjectParameter("ScoreRuleIds", scoreRuleIds) : new ObjectParameter("ScoreRuleIds", typeof(string)));
		ObjectParameter objectParameter4 = ((companyId != null) ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(string)));
		ObjectParameter objectParameter5 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (updateCompanyGroups.HasValue ? new ObjectParameter("UpdateCompanyGroups", updateCompanyGroups) : new ObjectParameter("UpdateCompanyGroups", typeof(bool)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter16 = (isReturnCntRow.HasValue ? new ObjectParameter("IsReturnCntRow", isReturnCntRow) : new ObjectParameter("IsReturnCntRow", typeof(bool)));
		ObjectParameter objectParameter17 = ((textEarningScore != null) ? new ObjectParameter("TextEarningScore", textEarningScore) : new ObjectParameter("TextEarningScore", typeof(string)));
		ObjectParameter objectParameter18 = ((textSpendScore != null) ? new ObjectParameter("TextSpendScore", textSpendScore) : new ObjectParameter("TextSpendScore", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ScorespInsertAndCalcScores_Result>("ScorespInsertAndCalcScores", new ObjectParameter[19]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, returnCntRow, objectParameter17, objectParameter18
		});
	}

	public virtual ObjectResult<ScorespSelectScores_Result> ScorespSelectScores(DateTime? fromScoreDate, DateTime? toScoreDate, string scoreRuleIds, string companyId, string scoreUserIds, string scoreSysPartIds, string scoreObjectIds, string textEarningScore, string textSpendScore, int? centerId, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fromScoreDate.HasValue ? new ObjectParameter("FromScoreDate", fromScoreDate) : new ObjectParameter("FromScoreDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (toScoreDate.HasValue ? new ObjectParameter("ToScoreDate", toScoreDate) : new ObjectParameter("ToScoreDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((scoreRuleIds != null) ? new ObjectParameter("ScoreRuleIds", scoreRuleIds) : new ObjectParameter("ScoreRuleIds", typeof(string)));
		ObjectParameter objectParameter4 = ((companyId != null) ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(string)));
		ObjectParameter objectParameter5 = ((scoreUserIds != null) ? new ObjectParameter("ScoreUserIds", scoreUserIds) : new ObjectParameter("ScoreUserIds", typeof(string)));
		ObjectParameter objectParameter6 = ((scoreSysPartIds != null) ? new ObjectParameter("ScoreSysPartIds", scoreSysPartIds) : new ObjectParameter("ScoreSysPartIds", typeof(string)));
		ObjectParameter objectParameter7 = ((scoreObjectIds != null) ? new ObjectParameter("ScoreObjectIds", scoreObjectIds) : new ObjectParameter("ScoreObjectIds", typeof(string)));
		ObjectParameter objectParameter8 = ((textEarningScore != null) ? new ObjectParameter("TextEarningScore", textEarningScore) : new ObjectParameter("TextEarningScore", typeof(string)));
		ObjectParameter objectParameter9 = ((textSpendScore != null) ? new ObjectParameter("TextSpendScore", textSpendScore) : new ObjectParameter("TextSpendScore", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ScorespSelectScores_Result>("ScorespSelectScores", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<CRMspDySearchStockSupplies_Result> CRMspDySearchStockSupplies(string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDySearchStockSupplies_Result>("CRMspDySearchStockSupplies", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<int?> EmailspSelectEmailTankCount(int? userId, DateTime? sendDateTime)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("EmailspSelectEmailTankCount", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> EmailspGetUnReadEmailReceiveCount(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("EmailspGetUnReadEmailReceiveCount", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> WSspDeleteSalesTarget(int? salesTargetId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("WSspDeleteSalesTarget", new ObjectParameter[2] { objectParameter, errorMessage });
	}

	public virtual ObjectResult<EmailspSelectEmailReadySendByUserId_Result> EmailspSelectEmailReadySendByUserId(int? userId, DateTime? sendDateTime)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmailspSelectEmailReadySendByUserId_Result>("EmailspSelectEmailReadySendByUserId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CRMspSelectCompanyGroupsIIIWithPaging_Result> CRMspSelectCompanyGroupsIIIWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyGroupsIIIWithPaging_Result>("CRMspSelectCompanyGroupsIIIWithPaging", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectCompanyGroupsIIWithPaging_Result> CRMspSelectCompanyGroupsIIWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyGroupsIIWithPaging_Result>("CRMspSelectCompanyGroupsIIWithPaging", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectCompanyGroupsIVWithPaging_Result> CRMspSelectCompanyGroupsIVWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyGroupsIVWithPaging_Result>("CRMspSelectCompanyGroupsIVWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspSelectCompanyGroupsWithPaging_Result> CRMspSelectCompanyGroupsWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyGroupsWithPaging_Result>("CRMspSelectCompanyGroupsWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspSelectCompanyPresentationsWithPaging_Result> CRMspSelectCompanyPresentationsWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyPresentationsWithPaging_Result>("CRMspSelectCompanyPresentationsWithPaging", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectCompanyTypesWithPaging_Result> CRMspSelectCompanyTypesWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyTypesWithPaging_Result>("CRMspSelectCompanyTypesWithPaging", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspSelectProvinceWithPaging_Result> CRMspSelectProvinceWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm, int? countryId)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		ObjectParameter objectParameter8 = (countryId.HasValue ? new ObjectParameter("CountryId", countryId) : new ObjectParameter("CountryId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectProvinceWithPaging_Result>("CRMspSelectProvinceWithPaging", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<CRMspSelectUsersWithPaging_Result> CRMspSelectUsersWithPaging(int? userId, int? pageNumber, int? pageSize, int? centerId, int? departmentId, bool? isActive, string searchTerm, int? languageID, int? defaultLanguageID, int? linkedTypeId, string excludeUserIds)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter5 = (departmentId.HasValue ? new ObjectParameter("DepartmentId", departmentId) : new ObjectParameter("DepartmentId", typeof(int)));
		ObjectParameter objectParameter6 = (isActive.HasValue ? new ObjectParameter("IsActive", isActive) : new ObjectParameter("IsActive", typeof(bool)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (linkedTypeId.HasValue ? new ObjectParameter("LinkedTypeId", linkedTypeId) : new ObjectParameter("LinkedTypeId", typeof(int)));
		ObjectParameter objectParameter11 = ((excludeUserIds != null) ? new ObjectParameter("ExcludeUserIds", excludeUserIds) : new ObjectParameter("ExcludeUserIds", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectUsersWithPaging_Result>("CRMspSelectUsersWithPaging", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11
		});
	}

	public virtual ObjectResult<CRMspSelectCityWithPaging_Result> CRMspSelectCityWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, int? provinceId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (provinceId.HasValue ? new ObjectParameter("ProvinceId", provinceId) : new ObjectParameter("ProvinceId", typeof(int)));
		ObjectParameter objectParameter8 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCityWithPaging_Result>("CRMspSelectCityWithPaging", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual int CRMspUpdateUserLastCheckEmailDate(int? userId, DateTime? lastCheckEmailDate)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (lastCheckEmailDate.HasValue ? new ObjectParameter("LastCheckEmailDate", lastCheckEmailDate) : new ObjectParameter("LastCheckEmailDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateUserLastCheckEmailDate", objectParameter, objectParameter2);
	}

	public virtual ObjectResult<CRMspSelectUsersByIdsWithPaging_Result> CRMspSelectUsersByIdsWithPaging(int? userId, string userIdList, int? pageNumber, int? pageSize, int? centerId, bool? isActive, string searchTerm, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((userIdList != null) ? new ObjectParameter("UserIdList", userIdList) : new ObjectParameter("UserIdList", typeof(string)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter6 = (isActive.HasValue ? new ObjectParameter("IsActive", isActive) : new ObjectParameter("IsActive", typeof(bool)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectUsersByIdsWithPaging_Result>("CRMspSelectUsersByIdsWithPaging", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int CRMspUpdateCompanyQuickRegisterDefSettingLocation(int? companyQuickRegisterDefSettingId, string cmpLocationLat, string cmpLocationLong, double? cmpLocationZoom, DateTime? registerDate, string registerDatePersian, int? userId, string appType)
	{
		ObjectParameter objectParameter = (companyQuickRegisterDefSettingId.HasValue ? new ObjectParameter("CompanyQuickRegisterDefSettingId", companyQuickRegisterDefSettingId) : new ObjectParameter("CompanyQuickRegisterDefSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((cmpLocationLat != null) ? new ObjectParameter("CmpLocationLat", cmpLocationLat) : new ObjectParameter("CmpLocationLat", typeof(string)));
		ObjectParameter objectParameter3 = ((cmpLocationLong != null) ? new ObjectParameter("CmpLocationLong", cmpLocationLong) : new ObjectParameter("CmpLocationLong", typeof(string)));
		ObjectParameter objectParameter4 = (cmpLocationZoom.HasValue ? new ObjectParameter("CmpLocationZoom", cmpLocationZoom) : new ObjectParameter("CmpLocationZoom", typeof(double)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdateCompanyQuickRegisterDefSettingLocation", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual int CRMspUpdatePersonQuickRegisterDefSettingLocation(int? companyQuickRegisterDefSettingId, string prsLocationLat, string prsLocationLong, double? prsLocationZoom, DateTime? registerDate, string registerDatePersian, int? userId, string appType)
	{
		ObjectParameter objectParameter = (companyQuickRegisterDefSettingId.HasValue ? new ObjectParameter("CompanyQuickRegisterDefSettingId", companyQuickRegisterDefSettingId) : new ObjectParameter("CompanyQuickRegisterDefSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((prsLocationLat != null) ? new ObjectParameter("PrsLocationLat", prsLocationLat) : new ObjectParameter("PrsLocationLat", typeof(string)));
		ObjectParameter objectParameter3 = ((prsLocationLong != null) ? new ObjectParameter("PrsLocationLong", prsLocationLong) : new ObjectParameter("PrsLocationLong", typeof(string)));
		ObjectParameter objectParameter4 = (prsLocationZoom.HasValue ? new ObjectParameter("PrsLocationZoom", prsLocationZoom) : new ObjectParameter("PrsLocationZoom", typeof(double)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUpdatePersonQuickRegisterDefSettingLocation", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<CRMspSelectCompanySubGroupsWithPaging_Result> CRMspSelectCompanySubGroupsWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm, int? companyGroupId)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		ObjectParameter objectParameter8 = (companyGroupId.HasValue ? new ObjectParameter("CompanyGroupId", companyGroupId) : new ObjectParameter("CompanyGroupId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanySubGroupsWithPaging_Result>("CRMspSelectCompanySubGroupsWithPaging", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<WSspSelectDeliveryTermWithPaging_Result> WSspSelectDeliveryTermWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectDeliveryTermWithPaging_Result>("WSspSelectDeliveryTermWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspSelectOrderGroupWithPaging_Result> WSspSelectOrderGroupWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderGroupWithPaging_Result>("WSspSelectOrderGroupWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspSelectOrderOprWithPaging_Result> WSspSelectOrderOprWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderOprWithPaging_Result>("WSspSelectOrderOprWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspSelectOrderStatusWithPaging_Result> WSspSelectOrderStatusWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderStatusWithPaging_Result>("WSspSelectOrderStatusWithPaging", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<WSspSelectSettlementTypeWithPaging_Result> WSspSelectSettlementTypeWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectSettlementTypeWithPaging_Result>("WSspSelectSettlementTypeWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual int WSspDeleteBuyOrderItemLinkOrderItem(int? buyOrderId, int? buyOrderItemId, int? orderId, int? orderItemId, int? userId, int? month1, int? fPId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter result)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (buyOrderItemId.HasValue ? new ObjectParameter("BuyOrderItemId", buyOrderItemId) : new ObjectParameter("BuyOrderItemId", typeof(int)));
		ObjectParameter objectParameter3 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter4 = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspDeleteBuyOrderItemLinkOrderItem", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, result);
	}

	public virtual ObjectResult<EmailspSelectEmailTankReadySend_Result> EmailspSelectEmailTankReadySend(int? userId, DateTime? sendDateTime, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmailspSelectEmailTankReadySend_Result>("EmailspSelectEmailTankReadySend", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectProductFirstGroupWithPaging_Result> WSspSelectProductFirstGroupWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string searchTerm)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductFirstGroupWithPaging_Result>("WSspSelectProductFirstGroupWithPaging", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspSelectProductSecondGroupWithPaging_Result> WSspSelectProductSecondGroupWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string searchTerm, int? fGId)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		ObjectParameter objectParameter6 = (fGId.HasValue ? new ObjectParameter("FGId", fGId) : new ObjectParameter("FGId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductSecondGroupWithPaging_Result>("WSspSelectProductSecondGroupWithPaging", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<WSspSelectProductWithPaging_Result> WSspSelectProductWithPaging(int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, string searchTerm, int? fGId, int? sGId)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		ObjectParameter objectParameter6 = (fGId.HasValue ? new ObjectParameter("FGId", fGId) : new ObjectParameter("FGId", typeof(int)));
		ObjectParameter objectParameter7 = (sGId.HasValue ? new ObjectParameter("SGId", sGId) : new ObjectParameter("SGId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductWithPaging_Result>("WSspSelectProductWithPaging", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspSelectSalesTarget_Result> WSspSelectSalesTarget(int? salesTargetId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectSalesTarget_Result>("WSspSelectSalesTarget", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> WSspInsertSalesTarget(string titleLangJson, int? targetOrderCount, decimal? targetOrderAmount, DateTime? targetFromDate, DateTime? targetToDate, string targetFromDatePersian, string targetToDatePersian, string targetDistributionDetailsJson, string targetTermsJson, string targetScopeJson, int? userId, int? fPId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageId, int? defaultLanguageId, ObjectParameter insertedId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((titleLangJson != null) ? new ObjectParameter("TitleLangJson", titleLangJson) : new ObjectParameter("TitleLangJson", typeof(string)));
		ObjectParameter objectParameter2 = (targetOrderCount.HasValue ? new ObjectParameter("TargetOrderCount", targetOrderCount) : new ObjectParameter("TargetOrderCount", typeof(int)));
		ObjectParameter objectParameter3 = (targetOrderAmount.HasValue ? new ObjectParameter("TargetOrderAmount", targetOrderAmount) : new ObjectParameter("TargetOrderAmount", typeof(decimal)));
		ObjectParameter objectParameter4 = (targetFromDate.HasValue ? new ObjectParameter("TargetFromDate", targetFromDate) : new ObjectParameter("TargetFromDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (targetToDate.HasValue ? new ObjectParameter("TargetToDate", targetToDate) : new ObjectParameter("TargetToDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((targetFromDatePersian != null) ? new ObjectParameter("TargetFromDatePersian", targetFromDatePersian) : new ObjectParameter("TargetFromDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((targetToDatePersian != null) ? new ObjectParameter("TargetToDatePersian", targetToDatePersian) : new ObjectParameter("TargetToDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((targetDistributionDetailsJson != null) ? new ObjectParameter("TargetDistributionDetailsJson", targetDistributionDetailsJson) : new ObjectParameter("TargetDistributionDetailsJson", typeof(string)));
		ObjectParameter objectParameter9 = ((targetTermsJson != null) ? new ObjectParameter("TargetTermsJson", targetTermsJson) : new ObjectParameter("TargetTermsJson", typeof(string)));
		ObjectParameter objectParameter10 = ((targetScopeJson != null) ? new ObjectParameter("TargetScopeJson", targetScopeJson) : new ObjectParameter("TargetScopeJson", typeof(string)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter18 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("WSspInsertSalesTarget", new ObjectParameter[20]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, insertedId, errorMessage
		});
	}

	public virtual ObjectResult<int?> WSspUpdateSalesTarget(int? salesTargetId, string titleLangJson, int? targetOrderCount, decimal? targetOrderAmount, DateTime? targetFromDate, DateTime? targetToDate, string targetFromDatePersian, string targetToDatePersian, string targetDistributionDetailsJson, string targetTermsJson, string targetScopeJson, int? userId, int? fPId, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageId, int? defaultLanguageId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		ObjectParameter objectParameter2 = ((titleLangJson != null) ? new ObjectParameter("TitleLangJson", titleLangJson) : new ObjectParameter("TitleLangJson", typeof(string)));
		ObjectParameter objectParameter3 = (targetOrderCount.HasValue ? new ObjectParameter("TargetOrderCount", targetOrderCount) : new ObjectParameter("TargetOrderCount", typeof(int)));
		ObjectParameter objectParameter4 = (targetOrderAmount.HasValue ? new ObjectParameter("TargetOrderAmount", targetOrderAmount) : new ObjectParameter("TargetOrderAmount", typeof(decimal)));
		ObjectParameter objectParameter5 = (targetFromDate.HasValue ? new ObjectParameter("TargetFromDate", targetFromDate) : new ObjectParameter("TargetFromDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (targetToDate.HasValue ? new ObjectParameter("TargetToDate", targetToDate) : new ObjectParameter("TargetToDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((targetFromDatePersian != null) ? new ObjectParameter("TargetFromDatePersian", targetFromDatePersian) : new ObjectParameter("TargetFromDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((targetToDatePersian != null) ? new ObjectParameter("TargetToDatePersian", targetToDatePersian) : new ObjectParameter("TargetToDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((targetDistributionDetailsJson != null) ? new ObjectParameter("TargetDistributionDetailsJson", targetDistributionDetailsJson) : new ObjectParameter("TargetDistributionDetailsJson", typeof(string)));
		ObjectParameter objectParameter10 = ((targetTermsJson != null) ? new ObjectParameter("TargetTermsJson", targetTermsJson) : new ObjectParameter("TargetTermsJson", typeof(string)));
		ObjectParameter objectParameter11 = ((targetScopeJson != null) ? new ObjectParameter("TargetScopeJson", targetScopeJson) : new ObjectParameter("TargetScopeJson", typeof(string)));
		ObjectParameter objectParameter12 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter13 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter18 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter19 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("WSspUpdateSalesTarget", new ObjectParameter[20]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, errorMessage
		});
	}

	public virtual ObjectResult<WSspSelectSalesTargetsWithPaging_Result> WSspSelectSalesTargetsWithPaging(int? languageID, int? defaultLanguageID, string searchTerm, int? pageNumber, int? pageSize, ObjectParameter totalCount)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = ((searchTerm != null) ? new ObjectParameter("SearchTerm", searchTerm) : new ObjectParameter("SearchTerm", typeof(string)));
		ObjectParameter objectParameter4 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectSalesTargetsWithPaging_Result>("WSspSelectSalesTargetsWithPaging", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, totalCount });
	}

	public virtual ObjectResult<CRMspSelectConsecutiveLeaveByDate_Result> CRMspSelectConsecutiveLeaveByDate(DateTime? date, int? userId, int? timeAttendanceMode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (timeAttendanceMode.HasValue ? new ObjectParameter("TimeAttendanceMode", timeAttendanceMode) : new ObjectParameter("TimeAttendanceMode", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectConsecutiveLeaveByDate_Result>("CRMspSelectConsecutiveLeaveByDate", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspChartSalesTargetDistributionReport_Result> WSspChartSalesTargetDistributionReport(int? salesTargetId, int? centerId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspChartSalesTargetDistributionReport_Result>("WSspChartSalesTargetDistributionReport", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspChartSalesTargetReport_Result> WSspChartSalesTargetReport(int? salesTargetId, int? centerId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspChartSalesTargetReport_Result>("WSspChartSalesTargetReport", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspSelectSaleTargets_Result> WSspSelectSaleTargets(int? salesTargetId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectSaleTargets_Result>("WSspSelectSaleTargets", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspReturnSoldOrdPrdCount_Result> WSspReturnSoldOrdPrdCount(int? prdId, int? currOrdItemId, double? fCR, double? fCRI, int? whId, string tracing, int? centerId)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (currOrdItemId.HasValue ? new ObjectParameter("CurrOrdItemId", currOrdItemId) : new ObjectParameter("CurrOrdItemId", typeof(int)));
		ObjectParameter objectParameter3 = (fCR.HasValue ? new ObjectParameter("FCR", fCR) : new ObjectParameter("FCR", typeof(double)));
		ObjectParameter objectParameter4 = (fCRI.HasValue ? new ObjectParameter("FCRI", fCRI) : new ObjectParameter("FCRI", typeof(double)));
		ObjectParameter objectParameter5 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter6 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspReturnSoldOrdPrdCount_Result>("WSspReturnSoldOrdPrdCount", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspControlPreOrderItemsSoldStock_Result> WSspControlPreOrderItemsSoldStock(int? preOrderId, string pordItemJson, int? centerId, int? prdKind, int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((pordItemJson != null) ? new ObjectParameter("PordItemJson", pordItemJson) : new ObjectParameter("PordItemJson", typeof(string)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspControlPreOrderItemsSoldStock_Result>("WSspControlPreOrderItemsSoldStock", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspControlOrderItemsSoldStock_Result> WSspControlOrderItemsSoldStock(int? orderId, string ordItemJson, string ordItemListStr, int? centerId, int? prdKind, int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((ordItemJson != null) ? new ObjectParameter("OrdItemJson", ordItemJson) : new ObjectParameter("OrdItemJson", typeof(string)));
		ObjectParameter objectParameter3 = ((ordItemListStr != null) ? new ObjectParameter("OrdItemListStr", ordItemListStr) : new ObjectParameter("OrdItemListStr", typeof(string)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter5 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspControlOrderItemsSoldStock_Result>("WSspControlOrderItemsSoldStock", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<WSspControlBuyOrderItemsSoldStock_Result> WSspControlBuyOrderItemsSoldStock(int? buyOrderId, string bordItemJson, int? centerId, int? prdKind, int? fPId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((bordItemJson != null) ? new ObjectParameter("BordItemJson", bordItemJson) : new ObjectParameter("BordItemJson", typeof(string)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspControlBuyOrderItemsSoldStock_Result>("WSspControlBuyOrderItemsSoldStock", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspSelectOrderDefaultSettingById_Result> WSspSelectOrderDefaultSettingById(int? orderSettingId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderSettingId.HasValue ? new ObjectParameter("OrderSettingId", orderSettingId) : new ObjectParameter("OrderSettingId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderDefaultSettingById_Result>("WSspSelectOrderDefaultSettingById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectOrdersForSalesTarget_Result> WSspSelectOrdersForSalesTarget(int? salesTargetId, int? centerId, int? languageID, int? defaultLanguageID, int? userId, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrdersForSalesTarget_Result>("WSspSelectOrdersForSalesTarget", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<WSspSendUserSalesTargetNotif_Result> WSspSendUserSalesTargetNotif(int? userId, int? toUserId, int? salesTargetId, DateTime? date, int? languageID, int? defaultLanguageID, int? centerId, string templateUserMessageJson, string templateResponsibleUserMessageJson, string messageSubjectJson, string achievementDateJson, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (toUserId.HasValue ? new ObjectParameter("ToUserId", toUserId) : new ObjectParameter("ToUserId", typeof(int)));
		ObjectParameter objectParameter3 = (salesTargetId.HasValue ? new ObjectParameter("SalesTargetId", salesTargetId) : new ObjectParameter("SalesTargetId", typeof(int)));
		ObjectParameter objectParameter4 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = ((templateUserMessageJson != null) ? new ObjectParameter("TemplateUserMessageJson", templateUserMessageJson) : new ObjectParameter("TemplateUserMessageJson", typeof(string)));
		ObjectParameter objectParameter9 = ((templateResponsibleUserMessageJson != null) ? new ObjectParameter("TemplateResponsibleUserMessageJson", templateResponsibleUserMessageJson) : new ObjectParameter("TemplateResponsibleUserMessageJson", typeof(string)));
		ObjectParameter objectParameter10 = ((messageSubjectJson != null) ? new ObjectParameter("MessageSubjectJson", messageSubjectJson) : new ObjectParameter("MessageSubjectJson", typeof(string)));
		ObjectParameter objectParameter11 = ((achievementDateJson != null) ? new ObjectParameter("AchievementDateJson", achievementDateJson) : new ObjectParameter("AchievementDateJson", typeof(string)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter15 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSendUserSalesTargetNotif_Result>("WSspSendUserSalesTargetNotif", new ObjectParameter[16]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16
		});
	}

	public virtual ObjectResult<CRMspSelectCompanyLogoByCmpIds_Result> CRMspSelectCompanyLogoByCmpIds(string companyIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((companyIds != null) ? new ObjectParameter("CompanyIds", companyIds) : new ObjectParameter("CompanyIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyLogoByCmpIds_Result>("CRMspSelectCompanyLogoByCmpIds", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int WSspBuyOrderPaymentDeActive(int? buyOrderPaymentId, int? bordpayDeActiveUserId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (buyOrderPaymentId.HasValue ? new ObjectParameter("BuyOrderPaymentId", buyOrderPaymentId) : new ObjectParameter("BuyOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (bordpayDeActiveUserId.HasValue ? new ObjectParameter("bordpayDeActiveUserId", bordpayDeActiveUserId) : new ObjectParameter("bordpayDeActiveUserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspBuyOrderPaymentDeActive", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int WSspBuyOrderPaymentDeActiveExit(int? buyOrderPaymentId)
	{
		ObjectParameter objectParameter = (buyOrderPaymentId.HasValue ? new ObjectParameter("BuyOrderPaymentId", buyOrderPaymentId) : new ObjectParameter("BuyOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspBuyOrderPaymentDeActiveExit", objectParameter);
	}

	public virtual int WSspBuyOrderPaymentVerify(int? buyOrderPaymentId, int? bordpayVerifierId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (buyOrderPaymentId.HasValue ? new ObjectParameter("BuyOrderPaymentId", buyOrderPaymentId) : new ObjectParameter("BuyOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (bordpayVerifierId.HasValue ? new ObjectParameter("bordpayVerifierId", bordpayVerifierId) : new ObjectParameter("bordpayVerifierId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspBuyOrderPaymentVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int WSspBuyOrderPaymentVerifyExit(int? buyOrderPaymentId)
	{
		ObjectParameter objectParameter = (buyOrderPaymentId.HasValue ? new ObjectParameter("BuyOrderPaymentId", buyOrderPaymentId) : new ObjectParameter("BuyOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspBuyOrderPaymentVerifyExit", objectParameter);
	}

	public virtual int WSspOrderPaymentDeActive(int? orderPaymentId, int? ordpayDeActiveUserId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (ordpayDeActiveUserId.HasValue ? new ObjectParameter("ordpayDeActiveUserId", ordpayDeActiveUserId) : new ObjectParameter("ordpayDeActiveUserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspOrderPaymentDeActive", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int WSspOrderPaymentDeActiveExit(int? orderPaymentId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspOrderPaymentDeActiveExit", objectParameter);
	}

	public virtual int WSspPreOrderPaymentDeActive(int? preOrderPaymentId, int? pordpayDeActiveUserId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (pordpayDeActiveUserId.HasValue ? new ObjectParameter("pordpayDeActiveUserId", pordpayDeActiveUserId) : new ObjectParameter("pordpayDeActiveUserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspPreOrderPaymentDeActive", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int WSspPreOrderPaymentDeActiveExit(int? preOrderPaymentId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspPreOrderPaymentDeActiveExit", objectParameter);
	}

	public virtual int WSspPreOrderPaymentVerify(int? preOrderPaymentId, int? pordpayVerifierId, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = (pordpayVerifierId.HasValue ? new ObjectParameter("pordpayVerifierId", pordpayVerifierId) : new ObjectParameter("pordpayVerifierId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspPreOrderPaymentVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int WSspPreOrderPaymentVerifyExit(int? preOrderPaymentId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspPreOrderPaymentVerifyExit", objectParameter);
	}

	public virtual int WSspOrderCommissionPreVerify(int? orderCommissionId, int? preVerifierUserId, DateTime? preVerifiedDate, string preVerifiedDatePersian)
	{
		ObjectParameter objectParameter = (orderCommissionId.HasValue ? new ObjectParameter("OrderCommissionId", orderCommissionId) : new ObjectParameter("OrderCommissionId", typeof(int)));
		ObjectParameter objectParameter2 = (preVerifierUserId.HasValue ? new ObjectParameter("PreVerifierUserId", preVerifierUserId) : new ObjectParameter("PreVerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = (preVerifiedDate.HasValue ? new ObjectParameter("PreVerifiedDate", preVerifiedDate) : new ObjectParameter("PreVerifiedDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((preVerifiedDatePersian != null) ? new ObjectParameter("PreVerifiedDatePersian", preVerifiedDatePersian) : new ObjectParameter("PreVerifiedDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspOrderCommissionPreVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int WSspOrderCommissionPreVerifyExit(int? orderCommissionId)
	{
		ObjectParameter objectParameter = (orderCommissionId.HasValue ? new ObjectParameter("OrderCommissionId", orderCommissionId) : new ObjectParameter("OrderCommissionId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspOrderCommissionPreVerifyExit", objectParameter);
	}

	public virtual int CRMspUserTaskDidIt(int? userTaskId, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, DateTime? targetDate, bool? isFinish)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUserTaskDidIt", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<CRMspSelectUserTaskById_Result> CRMspSelectUserTaskById(int? languageID, int? defaultLanguageID, int? userTaskId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectUserTaskById_Result>("CRMspSelectUserTaskById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectLeaveWithPaging_Result> CRMspSelectLeaveWithPaging(int? crmUserId, int? leaveId, int? leaveTypeId, int? userId, DateTime? fDateTime, DateTime? tDateTime, int? languageID, int? defaultLanguageID, int? leaveStatusId, int? centerId, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter3 = (leaveTypeId.HasValue ? new ObjectParameter("LeaveTypeId", leaveTypeId) : new ObjectParameter("LeaveTypeId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (leaveStatusId.HasValue ? new ObjectParameter("LeaveStatusId", leaveStatusId) : new ObjectParameter("LeaveStatusId", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter11 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter12 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLeaveWithPaging_Result>("CRMspSelectLeaveWithPaging", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<WSspSelectValidPordProduct_Result> WSspSelectValidPordProduct(int? prdId, double? fCR, double? fCRI, int? whId, string tracing, int? currId, DateTime? currDate, int? userId, int? centerId, int? topCount, long? lastRowNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (fCR.HasValue ? new ObjectParameter("FCR", fCR) : new ObjectParameter("FCR", typeof(double)));
		ObjectParameter objectParameter3 = (fCRI.HasValue ? new ObjectParameter("FCRI", fCRI) : new ObjectParameter("FCRI", typeof(double)));
		ObjectParameter objectParameter4 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter5 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter6 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter7 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter10 = (topCount.HasValue ? new ObjectParameter("TopCount", topCount) : new ObjectParameter("TopCount", typeof(int)));
		ObjectParameter objectParameter11 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(long)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectValidPordProduct_Result>("WSspSelectValidPordProduct", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<WSspSelectWareHouseWithId_Result> WSspSelectWareHouseWithId(int? wareHouseId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (wareHouseId.HasValue ? new ObjectParameter("WareHouseId", wareHouseId) : new ObjectParameter("WareHouseId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectWareHouseWithId_Result>("WSspSelectWareHouseWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectSoldOrdProduct_Result> WSspSelectSoldOrdProduct(int? prdId, double? fCR, double? fCRI, int? whId, string tracing, int? currOrdItemId, int? userId, int? centerId, int? topCount, long? lastRowNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (fCR.HasValue ? new ObjectParameter("FCR", fCR) : new ObjectParameter("FCR", typeof(double)));
		ObjectParameter objectParameter3 = (fCRI.HasValue ? new ObjectParameter("FCRI", fCRI) : new ObjectParameter("FCRI", typeof(double)));
		ObjectParameter objectParameter4 = (whId.HasValue ? new ObjectParameter("WhId", whId) : new ObjectParameter("WhId", typeof(int)));
		ObjectParameter objectParameter5 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter6 = (currOrdItemId.HasValue ? new ObjectParameter("CurrOrdItemId", currOrdItemId) : new ObjectParameter("CurrOrdItemId", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter9 = (topCount.HasValue ? new ObjectParameter("TopCount", topCount) : new ObjectParameter("TopCount", typeof(int)));
		ObjectParameter objectParameter10 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(long)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectSoldOrdProduct_Result>("WSspSelectSoldOrdProduct", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual int WSspInsertBuyOrderOprUserAccessToAllUsers(int? buyOrderOprId, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (buyOrderOprId.HasValue ? new ObjectParameter("BuyOrderOprId", buyOrderOprId) : new ObjectParameter("BuyOrderOprId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("WSspInsertBuyOrderOprUserAccessToAllUsers", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<CRMspChartDailyOrdersExtraInfo_Result> CRMspChartDailyOrdersExtraInfo(short? horizontalField, short? verticalMode, string selectedValues, string filtersJson, DateTime? fDate, DateTime? tDate, int? groupFieldKey, string groupFieldValues, int? userId, int? currUserId, int? centerId, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = (horizontalField.HasValue ? new ObjectParameter("HorizontalField", horizontalField) : new ObjectParameter("HorizontalField", typeof(short)));
		ObjectParameter objectParameter2 = (verticalMode.HasValue ? new ObjectParameter("VerticalMode", verticalMode) : new ObjectParameter("VerticalMode", typeof(short)));
		ObjectParameter objectParameter3 = ((selectedValues != null) ? new ObjectParameter("SelectedValues", selectedValues) : new ObjectParameter("SelectedValues", typeof(string)));
		ObjectParameter objectParameter4 = ((filtersJson != null) ? new ObjectParameter("FiltersJson", filtersJson) : new ObjectParameter("FiltersJson", typeof(string)));
		ObjectParameter objectParameter5 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = (groupFieldKey.HasValue ? new ObjectParameter("GroupFieldKey", groupFieldKey) : new ObjectParameter("GroupFieldKey", typeof(int)));
		ObjectParameter objectParameter8 = ((groupFieldValues != null) ? new ObjectParameter("GroupFieldValues", groupFieldValues) : new ObjectParameter("GroupFieldValues", typeof(string)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (currUserId.HasValue ? new ObjectParameter("CurrUserId", currUserId) : new ObjectParameter("CurrUserId", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter15 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspChartDailyOrdersExtraInfo_Result>("CRMspChartDailyOrdersExtraInfo", new ObjectParameter[15]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15
		});
	}

	public virtual int CRMspUserTaskAlarmDidIt(int? userTaskId, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType, DateTime? userTaskRemindDateTime, string userTaskRemindDate)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspUserTaskAlarmDidIt", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<mct_III_Result> CRMspExecuteLeave(int? leaveId, int? userId, DateTime? registerDate, string registerDatePersian, short? month1, short? year1, string appType, int? languageId, int? defaultLanguageId, ObjectParameter result, string requestUserIds, DateTime? fromLeaveDate, DateTime? toLeaveDate)
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
		ObjectParameter objectParameter10 = ((requestUserIds != null) ? new ObjectParameter("RequestUserIds", requestUserIds) : new ObjectParameter("RequestUserIds", typeof(string)));
		ObjectParameter objectParameter11 = (fromLeaveDate.HasValue ? new ObjectParameter("FromLeaveDate", fromLeaveDate) : new ObjectParameter("FromLeaveDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = (toLeaveDate.HasValue ? new ObjectParameter("ToLeaveDate", toLeaveDate) : new ObjectParameter("ToLeaveDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_III_Result>("CRMspExecuteLeave", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, result,
			objectParameter10, objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<WSspSelectProductsWithCodeAndGroup_Result> WSspSelectProductsWithCodeAndGroup(string jsonText, int? languageId, int? defaultLanguageId)
	{
		ObjectParameter objectParameter = ((jsonText != null) ? new ObjectParameter("JsonText", jsonText) : new ObjectParameter("JsonText", typeof(string)));
		ObjectParameter objectParameter2 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductsWithCodeAndGroup_Result>("WSspSelectProductsWithCodeAndGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<string> CRMspSelectPrjTitleGroupsByCmpId(int? companyID, int? languageID, int? defaultLanguageID, int? centerId, int? userId, int? isFinished, int? isTicket)
	{
		ObjectParameter objectParameter = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(int)));
		ObjectParameter objectParameter7 = (isTicket.HasValue ? new ObjectParameter("IsTicket", isTicket) : new ObjectParameter("IsTicket", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("CRMspSelectPrjTitleGroupsByCmpId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<int?> WSspSelectOrderDefaultSettingIsDefUserAccess(short? useType, int? referUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter2 = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("WSspSelectOrderDefaultSettingIsDefUserAccess", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> WSspUpdateOrderDefaultSettingDefFields(int? userId, string settingIds, short? useType)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((settingIds != null) ? new ObjectParameter("SettingIds", settingIds) : new ObjectParameter("SettingIds", typeof(string)));
		ObjectParameter objectParameter3 = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("WSspUpdateOrderDefaultSettingDefFields", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> CRMspSelectCompanyQuickRegisterDefSettingIsDefUserAccess(short? useType, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("CRMspSelectCompanyQuickRegisterDefSettingIsDefUserAccess", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspCalculateCnvsDoingTimeByPrjTitleGroup_Result> CRMspCalculateCnvsDoingTimeByPrjTitleGroup(int? companyID, int? languageID, int? defaultLanguageID, DateTime? fromDate, DateTime? toDate, int? centerId, int? userId, int? isFinished, int? isTicket, string prjTitleGroup)
	{
		ObjectParameter objectParameter = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(int)));
		ObjectParameter objectParameter9 = (isTicket.HasValue ? new ObjectParameter("IsTicket", isTicket) : new ObjectParameter("IsTicket", typeof(int)));
		ObjectParameter objectParameter10 = ((prjTitleGroup != null) ? new ObjectParameter("PrjTitleGroup", prjTitleGroup) : new ObjectParameter("PrjTitleGroup", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspCalculateCnvsDoingTimeByPrjTitleGroup_Result>("CRMspCalculateCnvsDoingTimeByPrjTitleGroup", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<WSspCheckDefaultOrderSettingUserConflict_Result> WSspCheckDefaultOrderSettingUserConflict(string userIdList, int? orderSettingId, short? useType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((userIdList != null) ? new ObjectParameter("UserIdList", userIdList) : new ObjectParameter("UserIdList", typeof(string)));
		ObjectParameter objectParameter2 = (orderSettingId.HasValue ? new ObjectParameter("OrderSettingId", orderSettingId) : new ObjectParameter("OrderSettingId", typeof(int)));
		ObjectParameter objectParameter3 = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspCheckDefaultOrderSettingUserConflict_Result>("WSspCheckDefaultOrderSettingUserConflict", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<WSspCheckPublicDefaultOrderSettingConflict_Result> WSspCheckPublicDefaultOrderSettingConflict(int? orderSettingId, short? useType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderSettingId.HasValue ? new ObjectParameter("OrderSettingId", orderSettingId) : new ObjectParameter("OrderSettingId", typeof(int)));
		ObjectParameter objectParameter2 = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspCheckPublicDefaultOrderSettingConflict_Result>("WSspCheckPublicDefaultOrderSettingConflict", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result> CRMspSelectCompanyQuickRegisterDefSettingUserAccess(short? useType, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>("CRMspSelectCompanyQuickRegisterDefSettingUserAccess", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspSelectOrderDefaultSettingUserAccess_Result> WSspSelectOrderDefaultSettingUserAccess(short? useType, int? referUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter2 = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectOrderDefaultSettingUserAccess_Result>("WSspSelectOrderDefaultSettingUserAccess", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspSelectPreOrderDefaultSettingUserAccess_Result> WSspSelectPreOrderDefaultSettingUserAccess(int? referUserId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectPreOrderDefaultSettingUserAccess_Result>("WSspSelectPreOrderDefaultSettingUserAccess", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspCheckDefaultCompanySettingUserConflict_Result> CRMspCheckDefaultCompanySettingUserConflict(string userIdList, int? settingId, short? useType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((userIdList != null) ? new ObjectParameter("UserIdList", userIdList) : new ObjectParameter("UserIdList", typeof(string)));
		ObjectParameter objectParameter2 = (settingId.HasValue ? new ObjectParameter("SettingId", settingId) : new ObjectParameter("SettingId", typeof(int)));
		ObjectParameter objectParameter3 = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspCheckDefaultCompanySettingUserConflict_Result>("CRMspCheckDefaultCompanySettingUserConflict", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspCheckPublicDefaultCompanySettingConflict_Result> CRMspCheckPublicDefaultCompanySettingConflict(int? settingId, short? useType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (settingId.HasValue ? new ObjectParameter("SettingId", settingId) : new ObjectParameter("SettingId", typeof(int)));
		ObjectParameter objectParameter2 = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspCheckPublicDefaultCompanySettingConflict_Result>("CRMspCheckPublicDefaultCompanySettingConflict", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> CRMspUpdateCompanyDefaultSettingDefFields(int? userId, string settingIds, short? useType)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((settingIds != null) ? new ObjectParameter("SettingIds", settingIds) : new ObjectParameter("SettingIds", typeof(string)));
		ObjectParameter objectParameter3 = (useType.HasValue ? new ObjectParameter("UseType", useType) : new ObjectParameter("UseType", typeof(short)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("CRMspUpdateCompanyDefaultSettingDefFields", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<EmailspSearchEmails_Result> EmailspSearchEmails(string searchedValue, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((searchedValue != null) ? new ObjectParameter("SearchedValue", searchedValue) : new ObjectParameter("SearchedValue", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmailspSearchEmails_Result>("EmailspSearchEmails", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result> CRMspCallerIDCleanPhoneNumberByUserCallPreNumber(int? callTypeId, string phoneNumber, string trunkSource, string trunkDestination)
	{
		ObjectParameter objectParameter = (callTypeId.HasValue ? new ObjectParameter("CallTypeId", callTypeId) : new ObjectParameter("CallTypeId", typeof(int)));
		ObjectParameter objectParameter2 = ((phoneNumber != null) ? new ObjectParameter("PhoneNumber", phoneNumber) : new ObjectParameter("PhoneNumber", typeof(string)));
		ObjectParameter objectParameter3 = ((trunkSource != null) ? new ObjectParameter("TrunkSource", trunkSource) : new ObjectParameter("TrunkSource", typeof(string)));
		ObjectParameter objectParameter4 = ((trunkDestination != null) ? new ObjectParameter("TrunkDestination", trunkDestination) : new ObjectParameter("TrunkDestination", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>("CRMspCallerIDCleanPhoneNumberByUserCallPreNumber", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int EmailspInsertEmailUserTempTankByCompanyPerson(int? userId, int? emailSystemPartId, long? emailObjectId, int? companyId, int? companyPersonId, int? emailCmpPrjId, string filePath, string filePathII, string filePathIII, string filePathIV, string filePathV, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (emailSystemPartId.HasValue ? new ObjectParameter("EmailSystemPartId", emailSystemPartId) : new ObjectParameter("EmailSystemPartId", typeof(int)));
		ObjectParameter objectParameter3 = (emailObjectId.HasValue ? new ObjectParameter("EmailObjectId", emailObjectId) : new ObjectParameter("EmailObjectId", typeof(long)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter6 = (emailCmpPrjId.HasValue ? new ObjectParameter("EmailCmpPrjId", emailCmpPrjId) : new ObjectParameter("EmailCmpPrjId", typeof(int)));
		ObjectParameter objectParameter7 = ((filePath != null) ? new ObjectParameter("FilePath", filePath) : new ObjectParameter("FilePath", typeof(string)));
		ObjectParameter objectParameter8 = ((filePathII != null) ? new ObjectParameter("FilePathII", filePathII) : new ObjectParameter("FilePathII", typeof(string)));
		ObjectParameter objectParameter9 = ((filePathIII != null) ? new ObjectParameter("FilePathIII", filePathIII) : new ObjectParameter("FilePathIII", typeof(string)));
		ObjectParameter objectParameter10 = ((filePathIV != null) ? new ObjectParameter("FilePathIV", filePathIV) : new ObjectParameter("FilePathIV", typeof(string)));
		ObjectParameter objectParameter11 = ((filePathV != null) ? new ObjectParameter("FilePathV", filePathV) : new ObjectParameter("FilePathV", typeof(string)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmailspInsertEmailUserTempTankByCompanyPerson", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual ObjectResult<CRMspChartMonthlyOrdersInfo_Result> CRMspChartMonthlyOrdersInfo(string firstDayOfMonths, DateTime? fDate, DateTime? tDate, string selectedValue, int? userId, int? currUserId, int? centerId, int? groupFieldKey, string groupFieldValues, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = ((firstDayOfMonths != null) ? new ObjectParameter("FirstDayOfMonths", firstDayOfMonths) : new ObjectParameter("FirstDayOfMonths", typeof(string)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((selectedValue != null) ? new ObjectParameter("SelectedValue", selectedValue) : new ObjectParameter("SelectedValue", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (currUserId.HasValue ? new ObjectParameter("CurrUserId", currUserId) : new ObjectParameter("CurrUserId", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (groupFieldKey.HasValue ? new ObjectParameter("GroupFieldKey", groupFieldKey) : new ObjectParameter("GroupFieldKey", typeof(int)));
		ObjectParameter objectParameter9 = ((groupFieldValues != null) ? new ObjectParameter("GroupFieldValues", groupFieldValues) : new ObjectParameter("GroupFieldValues", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter13 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspChartMonthlyOrdersInfo_Result>("CRMspChartMonthlyOrdersInfo", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<CRMspIntMsgGetUnReadMessgeForUsers_Result> CRMspIntMsgGetUnReadMessgeForUsers(string userIds)
	{
		ObjectParameter objectParameter = ((userIds != null) ? new ObjectParameter("UserIds", userIds) : new ObjectParameter("UserIds", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspIntMsgGetUnReadMessgeForUsers_Result>("CRMspIntMsgGetUnReadMessgeForUsers", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspGetUnReadTicketForUsers_Result> CRMspGetUnReadTicketForUsers(string userIds)
	{
		ObjectParameter objectParameter = ((userIds != null) ? new ObjectParameter("UserIds", userIds) : new ObjectParameter("UserIds", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspGetUnReadTicketForUsers_Result>("CRMspGetUnReadTicketForUsers", new ObjectParameter[1] { objectParameter });
	}
}
