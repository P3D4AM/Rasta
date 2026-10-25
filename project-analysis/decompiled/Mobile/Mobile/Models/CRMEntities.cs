using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace Mobile.Models;

public class CRMEntities : DbContext
{
	public DbSet<MobCompanyAppInfo> MobCompanyAppInfo { get; set; }

	public DbSet<CrmPersonPicture> CrmPersonPicture { get; set; }

	public DbSet<CrmWebSetting> CrmWebSetting { get; set; }

	public DbSet<CrmCompanyLoGo> CrmCompanyLoGo { get; set; }

	public CRMEntities()
		: base(DbConnection.ConString)
	{
		base.Configuration.LazyLoadingEnabled = false;
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}

	public virtual ObjectResult<MobspCheckExtraCode_Result> MobspCheckExtraCode(string extraCode)
	{
		ObjectParameter objectParameter = ((extraCode != null) ? new ObjectParameter("ExtraCode", extraCode) : new ObjectParameter("ExtraCode", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckExtraCode_Result>("MobspCheckExtraCode", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectCompanyMoreInfo_Result> MobspSelectCompanyMoreInfo(int? companyID, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyMoreInfo_Result>("MobspSelectCompanyMoreInfo", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectCompanyWithIDForGroup_Result> MobspSelectCompanyWithIDForGroup(int? companyID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyWithIDForGroup_Result>("MobspSelectCompanyWithIDForGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectPersonMoreInfo_Result> MobspSelectPersonMoreInfo(int? companyPersonID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyPersonID.HasValue ? new ObjectParameter("CompanyPersonID", companyPersonID) : new ObjectParameter("CompanyPersonID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonMoreInfo_Result>("MobspSelectPersonMoreInfo", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectUserRollPermission_Result> MobspSelectUserRollPermission(int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserRollPermission_Result>("MobspSelectUserRollPermission", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectUserRollPermissionByForm_Result> MobspSelectUserRollPermissionByForm(int? userId, string formName, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((formName != null) ? new ObjectParameter("FormName", formName) : new ObjectParameter("FormName", typeof(string)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserRollPermissionByForm_Result>("MobspSelectUserRollPermissionByForm", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectCompanyGroupsMulti_Result> CRMspSelectCompanyGroupsMulti(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyGroupsMulti_Result>("CRMspSelectCompanyGroupsMulti", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CRMspCompanyCheckHaveMultiGroup_Result> CRMspCompanyCheckHaveMultiGroup(int? companyId, int? groupsMultiId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (groupsMultiId.HasValue ? new ObjectParameter("GroupsMultiId", groupsMultiId) : new ObjectParameter("GroupsMultiId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspCompanyCheckHaveMultiGroup_Result>("CRMspCompanyCheckHaveMultiGroup", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CRMspSelectCrmsysSetting_Result> CRMspSelectCrmsysSetting(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCrmsysSetting_Result>("CRMspSelectCrmsysSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectSmsReceivedWithID_Result> MobspSelectSmsReceivedWithID(int? smsReceiveId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (smsReceiveId.HasValue ? new ObjectParameter("SmsReceiveId", smsReceiveId) : new ObjectParameter("SmsReceiveId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsReceivedWithID_Result>("MobspSelectSmsReceivedWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSmsSendedWithID_Result> MobspSelectSmsSendedWithID(int? smsSendId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (smsSendId.HasValue ? new ObjectParameter("SmsSendId", smsSendId) : new ObjectParameter("SmsSendId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsSendedWithID_Result>("MobspSelectSmsSendedWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectConversationStatusGroups_Result> MobspSelectConversationStatusGroups(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationStatusGroups_Result>("MobspSelectConversationStatusGroups", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCrmWebSetting_Result> MobspSelectCrmWebSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCrmWebSetting_Result>("MobspSelectCrmWebSetting", Array.Empty<ObjectParameter>());
	}

	public virtual int CRMspInternalMessageUpdate(string mode, int? messageID, int? userID, int? typeID, string time, string date, string appType, int? centerId)
	{
		ObjectParameter objectParameter = ((mode != null) ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(string)));
		ObjectParameter objectParameter2 = (messageID.HasValue ? new ObjectParameter("MessageID", messageID) : new ObjectParameter("MessageID", typeof(int)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter4 = (typeID.HasValue ? new ObjectParameter("TypeID", typeID) : new ObjectParameter("TypeID", typeof(int)));
		ObjectParameter objectParameter5 = ((time != null) ? new ObjectParameter("Time", time) : new ObjectParameter("Time", typeof(string)));
		ObjectParameter objectParameter6 = ((date != null) ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInternalMessageUpdate", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<MobspSelectUserForCnvsReferToMultilUser_Result> MobspSelectUserForCnvsReferToMultilUser(int? userId, int? linkedType, int? referUserIdSelected, int? companyId, string cmpNotAccess, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (referUserIdSelected.HasValue ? new ObjectParameter("ReferUserIdSelected", referUserIdSelected) : new ObjectParameter("ReferUserIdSelected", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = ((cmpNotAccess != null) ? new ObjectParameter("CmpNotAccess", cmpNotAccess) : new ObjectParameter("CmpNotAccess", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserForCnvsReferToMultilUser_Result>("MobspSelectUserForCnvsReferToMultilUser", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspSelectUserForCnvsReferToUser_Result> MobspSelectUserForCnvsReferToUser(int? userId, int? linkedType, int? companyId, string cmpNotAccess, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = ((cmpNotAccess != null) ? new ObjectParameter("CmpNotAccess", cmpNotAccess) : new ObjectParameter("CmpNotAccess", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserForCnvsReferToUser_Result>("MobspSelectUserForCnvsReferToUser", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspSelectCompanyConversationLastStatus_Result> CRMspSelectCompanyConversationLastStatus(int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyConversationLastStatus_Result>("CRMspSelectCompanyConversationLastStatus", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<WSspSelectFinancialPeriod_Result> WSspSelectFinancialPeriod()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectFinancialPeriod_Result>("WSspSelectFinancialPeriod", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<CRMspSelectCompanyById_Result> CRMspSelectCompanyById(int? companyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectCompanyById_Result>("CRMspSelectCompanyById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<bool?> CRMspSelectDisableReceiveCNVSInfoAllarmStatus(int? refUserId)
	{
		ObjectParameter objectParameter = (refUserId.HasValue ? new ObjectParameter("RefUserId", refUserId) : new ObjectParameter("RefUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<bool?>("CRMspSelectDisableReceiveCNVSInfoAllarmStatus", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspIntMsgSelectReceiver_Result> MobspIntMsgSelectReceiver(int? userID, int? msgType, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (msgType.HasValue ? new ObjectParameter("msgType", msgType) : new ObjectParameter("msgType", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgSelectReceiver_Result>("MobspIntMsgSelectReceiver", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectInternalMessageDefaultContext_Result> MobspSelectInternalMessageDefaultContext(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectInternalMessageDefaultContext_Result>("MobspSelectInternalMessageDefaultContext", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectInternalMessagePriority_Result> MobspSelectInternalMessagePriority(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectInternalMessagePriority_Result>("MobspSelectInternalMessagePriority", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int CRMspIntMsgUpdateSelectReceiver(string crmUserId, string userId, bool? selected, int? mode)
	{
		ObjectParameter objectParameter = ((crmUserId != null) ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(string)));
		ObjectParameter objectParameter2 = ((userId != null) ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(string)));
		ObjectParameter objectParameter3 = (selected.HasValue ? new ObjectParameter("Selected", selected) : new ObjectParameter("Selected", typeof(bool)));
		ObjectParameter objectParameter4 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspIntMsgUpdateSelectReceiver", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int CRMspInternalMessageLoadReceiver(int? crmUserId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspInternalMessageLoadReceiver", objectParameter);
	}

	public virtual ObjectResult<string> CRMspInternalMessageMakeAllReceiverTogether(int? type, int? crmUserId, int? internalMessageId, int? msgdTypeId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (type.HasValue ? new ObjectParameter("Type", type) : new ObjectParameter("Type", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (internalMessageId.HasValue ? new ObjectParameter("InternalMessageId", internalMessageId) : new ObjectParameter("InternalMessageId", typeof(int)));
		ObjectParameter objectParameter4 = (msgdTypeId.HasValue ? new ObjectParameter("msgdTypeId", msgdTypeId) : new ObjectParameter("msgdTypeId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("CRMspInternalMessageMakeAllReceiverTogether", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectInternalMessage_Result> MobspSelectInternalMessage(int? internalMessageId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (internalMessageId.HasValue ? new ObjectParameter("InternalMessageId", internalMessageId) : new ObjectParameter("InternalMessageId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectInternalMessage_Result>("MobspSelectInternalMessage", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspIntMsgUpdateMultiReceiver(int? crmUserId, string multiReceiver, bool? selected)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		ObjectParameter objectParameter2 = ((multiReceiver != null) ? new ObjectParameter("MultiReceiver", multiReceiver) : new ObjectParameter("MultiReceiver", typeof(string)));
		ObjectParameter objectParameter3 = (selected.HasValue ? new ObjectParameter("Selected", selected) : new ObjectParameter("Selected", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspIntMsgUpdateMultiReceiver", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual ObjectResult<CRMspIntMsgCheckReceiveSms_Result> CRMspIntMsgCheckReceiveSms()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspIntMsgCheckReceiveSms_Result>("CRMspIntMsgCheckReceiveSms", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<int?> CRMspIntMsgGetUnReadMessge(int? userID, int? centerId)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("CRMspIntMsgGetUnReadMessge", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CRMspIntMsgGetUnReadVerify_Result> CRMspIntMsgGetUnReadVerify(int? userID, int? centerId)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspIntMsgGetUnReadVerify_Result>("CRMspIntMsgGetUnReadVerify", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<CRMspSelectSystemCrmProject_Result> CRMspSelectSystemCrmProject()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectSystemCrmProject_Result>("CRMspSelectSystemCrmProject", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectUsersCoordinate_Result> MobspSelectUsersCoordinate(int? languageID, int? defaultLanguageID, int? lastHours)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (lastHours.HasValue ? new ObjectParameter("LastHours", lastHours) : new ObjectParameter("LastHours", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUsersCoordinate_Result>("MobspSelectUsersCoordinate", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectUsersCoordinateAroundCompany_Result> MobspSelectUsersCoordinateAroundCompany(int? languageID, int? defaultLanguageID, int? lastHours, int? userId, int? linkedType, int? companyId, int? centerId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (lastHours.HasValue ? new ObjectParameter("LastHours", lastHours) : new ObjectParameter("LastHours", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter6 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUsersCoordinateAroundCompany_Result>("MobspSelectUsersCoordinateAroundCompany", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual int MobspUpdateUserCoordinate(int? userId, int? registerUserId, string appType, string registerDatePersian, int? month, string coordinateLatitude, string coordinateLongitude)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (registerUserId.HasValue ? new ObjectParameter("RegisterUserId", registerUserId) : new ObjectParameter("RegisterUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (month.HasValue ? new ObjectParameter("Month", month) : new ObjectParameter("Month", typeof(int)));
		ObjectParameter objectParameter6 = ((coordinateLatitude != null) ? new ObjectParameter("CoordinateLatitude", coordinateLatitude) : new ObjectParameter("CoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter7 = ((coordinateLongitude != null) ? new ObjectParameter("CoordinateLongitude", coordinateLongitude) : new ObjectParameter("CoordinateLongitude", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateUserCoordinate", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual ObjectResult<MobspResultsUserLocationCartable_Result> MobspResultsUserLocationCartable(int? userId, int? lastHours, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (lastHours.HasValue ? new ObjectParameter("LastHours", lastHours) : new ObjectParameter("LastHours", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsUserLocationCartable_Result>("MobspResultsUserLocationCartable", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectErrorLogs_Result> MobspSelectErrorLogs(DateTime? fDate, DateTime? tDate, int? companyId, int? companyPersonId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectErrorLogs_Result>("MobspSelectErrorLogs", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> MobspInsertErrorLogs(string activityName, string cause, string discription, int? androidVersion, string applicationVersion, string apiVersion, string internetType, string deviceResolution, int? userId, string userName, int? companyID, string companyName, int? companyPersonID, string personName, DateTime? registerDate, string registerDatePersian, int? languageID)
	{
		ObjectParameter objectParameter = ((activityName != null) ? new ObjectParameter("ActivityName", activityName) : new ObjectParameter("ActivityName", typeof(string)));
		ObjectParameter objectParameter2 = ((cause != null) ? new ObjectParameter("Cause", cause) : new ObjectParameter("Cause", typeof(string)));
		ObjectParameter objectParameter3 = ((discription != null) ? new ObjectParameter("Discription", discription) : new ObjectParameter("Discription", typeof(string)));
		ObjectParameter objectParameter4 = (androidVersion.HasValue ? new ObjectParameter("AndroidVersion", androidVersion) : new ObjectParameter("AndroidVersion", typeof(int)));
		ObjectParameter objectParameter5 = ((applicationVersion != null) ? new ObjectParameter("ApplicationVersion", applicationVersion) : new ObjectParameter("ApplicationVersion", typeof(string)));
		ObjectParameter objectParameter6 = ((apiVersion != null) ? new ObjectParameter("ApiVersion", apiVersion) : new ObjectParameter("ApiVersion", typeof(string)));
		ObjectParameter objectParameter7 = ((internetType != null) ? new ObjectParameter("InternetType", internetType) : new ObjectParameter("InternetType", typeof(string)));
		ObjectParameter objectParameter8 = ((deviceResolution != null) ? new ObjectParameter("DeviceResolution", deviceResolution) : new ObjectParameter("DeviceResolution", typeof(string)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter11 = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter12 = ((companyName != null) ? new ObjectParameter("CompanyName", companyName) : new ObjectParameter("CompanyName", typeof(string)));
		ObjectParameter objectParameter13 = (companyPersonID.HasValue ? new ObjectParameter("CompanyPersonID", companyPersonID) : new ObjectParameter("CompanyPersonID", typeof(int)));
		ObjectParameter objectParameter14 = ((personName != null) ? new ObjectParameter("PersonName", personName) : new ObjectParameter("PersonName", typeof(string)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertErrorLogs", new ObjectParameter[17]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17
		});
	}

	public virtual int MobspInsertConversationSupportReferMultilUser(int? cnvsProjectId, int? cnvsCompanyId, string cnvsDate, string cnvsDay, string cnvsTime, int? cnvsTopicId, string cnvsSubject, string cnvsDesc, int? cnvsPersonId, int? cnvsUserId, int? cnvsReferUserId, string cnvsReferDesc, int? cnvsStatusId, int? cnvsPriorityId, string cnvsRemindDate, string cnvsRemindTime, bool? cnvsRemindOk, bool? cnvsIsBookMark, int? cnvsFirstRegisterUserId, string cnvsFirstRegisterDate, DateTime? firstRegisterDate, int? userId, short? year1, short? month1, string registerDatePersian, string cnvsRemindDateForAllarm, string appType, string multiUsers, bool? needErja, string needErjaIntmsgSubject, string needErjaIntmsgBody, string needErjaIntmsgdAttachRecDesc, bool? needSendErjaAllarm, string needSendErjaAllarmIntmsgSubject, string needSendErjaAllarmIntmsgBody, string needSendErjaAllarmIntmsgdAttachRecDesc, string currTime, DateTime? cnvsDateTime, DateTime? cnvsRemindDateTime, DateTime? cnvsFirstRegisterDateTime, DateTime? cnvsRemindDateTimeForAllarm, ObjectParameter allIds, ObjectParameter allSendErjaAllarmIds, ObjectParameter allErjaIds, int? languageID, short? internalMessageYear1, string apiId, string cnvsCoordinateLatitude, string cnvsCoordinateLongitude, DateTime? cnvsCoordinateLastDate, string cnvsCoordinateLastDatePersian, TimeSpan? cnvsDoingTime, bool? cnvsIsCopy, long? cnvsDoingTimeSec, bool? cnvsIsTicket, int? cnvsStatusResultId, bool? cnvsIsCopyRemindDate, bool? cnvsIsCopyRemindDateForAllarm, int? centerId)
	{
		ObjectParameter objectParameter = (cnvsProjectId.HasValue ? new ObjectParameter("cnvsProjectId", cnvsProjectId) : new ObjectParameter("cnvsProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (cnvsCompanyId.HasValue ? new ObjectParameter("cnvsCompanyId", cnvsCompanyId) : new ObjectParameter("cnvsCompanyId", typeof(int)));
		ObjectParameter objectParameter3 = ((cnvsDate != null) ? new ObjectParameter("cnvsDate", cnvsDate) : new ObjectParameter("cnvsDate", typeof(string)));
		ObjectParameter objectParameter4 = ((cnvsDay != null) ? new ObjectParameter("cnvsDay", cnvsDay) : new ObjectParameter("cnvsDay", typeof(string)));
		ObjectParameter objectParameter5 = ((cnvsTime != null) ? new ObjectParameter("cnvsTime", cnvsTime) : new ObjectParameter("cnvsTime", typeof(string)));
		ObjectParameter objectParameter6 = (cnvsTopicId.HasValue ? new ObjectParameter("cnvsTopicId", cnvsTopicId) : new ObjectParameter("cnvsTopicId", typeof(int)));
		ObjectParameter objectParameter7 = ((cnvsSubject != null) ? new ObjectParameter("cnvsSubject", cnvsSubject) : new ObjectParameter("cnvsSubject", typeof(string)));
		ObjectParameter objectParameter8 = ((cnvsDesc != null) ? new ObjectParameter("cnvsDesc", cnvsDesc) : new ObjectParameter("cnvsDesc", typeof(string)));
		ObjectParameter objectParameter9 = (cnvsPersonId.HasValue ? new ObjectParameter("cnvsPersonId", cnvsPersonId) : new ObjectParameter("cnvsPersonId", typeof(int)));
		ObjectParameter objectParameter10 = (cnvsUserId.HasValue ? new ObjectParameter("cnvsUserId", cnvsUserId) : new ObjectParameter("cnvsUserId", typeof(int)));
		ObjectParameter objectParameter11 = (cnvsReferUserId.HasValue ? new ObjectParameter("cnvsReferUserId", cnvsReferUserId) : new ObjectParameter("cnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter12 = ((cnvsReferDesc != null) ? new ObjectParameter("cnvsReferDesc", cnvsReferDesc) : new ObjectParameter("cnvsReferDesc", typeof(string)));
		ObjectParameter objectParameter13 = (cnvsStatusId.HasValue ? new ObjectParameter("cnvsStatusId", cnvsStatusId) : new ObjectParameter("cnvsStatusId", typeof(int)));
		ObjectParameter objectParameter14 = (cnvsPriorityId.HasValue ? new ObjectParameter("cnvsPriorityId", cnvsPriorityId) : new ObjectParameter("cnvsPriorityId", typeof(int)));
		ObjectParameter objectParameter15 = ((cnvsRemindDate != null) ? new ObjectParameter("cnvsRemindDate", cnvsRemindDate) : new ObjectParameter("cnvsRemindDate", typeof(string)));
		ObjectParameter objectParameter16 = ((cnvsRemindTime != null) ? new ObjectParameter("cnvsRemindTime", cnvsRemindTime) : new ObjectParameter("cnvsRemindTime", typeof(string)));
		ObjectParameter objectParameter17 = (cnvsRemindOk.HasValue ? new ObjectParameter("cnvsRemindOk", cnvsRemindOk) : new ObjectParameter("cnvsRemindOk", typeof(bool)));
		ObjectParameter objectParameter18 = (cnvsIsBookMark.HasValue ? new ObjectParameter("cnvsIsBookMark", cnvsIsBookMark) : new ObjectParameter("cnvsIsBookMark", typeof(bool)));
		ObjectParameter objectParameter19 = (cnvsFirstRegisterUserId.HasValue ? new ObjectParameter("cnvsFirstRegisterUserId", cnvsFirstRegisterUserId) : new ObjectParameter("cnvsFirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter20 = ((cnvsFirstRegisterDate != null) ? new ObjectParameter("cnvsFirstRegisterDate", cnvsFirstRegisterDate) : new ObjectParameter("cnvsFirstRegisterDate", typeof(string)));
		ObjectParameter objectParameter21 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter22 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter23 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter24 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter25 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter26 = ((cnvsRemindDateForAllarm != null) ? new ObjectParameter("cnvsRemindDateForAllarm", cnvsRemindDateForAllarm) : new ObjectParameter("cnvsRemindDateForAllarm", typeof(string)));
		ObjectParameter objectParameter27 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter28 = ((multiUsers != null) ? new ObjectParameter("MultiUsers", multiUsers) : new ObjectParameter("MultiUsers", typeof(string)));
		ObjectParameter objectParameter29 = (needErja.HasValue ? new ObjectParameter("NeedErja", needErja) : new ObjectParameter("NeedErja", typeof(bool)));
		ObjectParameter objectParameter30 = ((needErjaIntmsgSubject != null) ? new ObjectParameter("NeedErjaIntmsgSubject", needErjaIntmsgSubject) : new ObjectParameter("NeedErjaIntmsgSubject", typeof(string)));
		ObjectParameter objectParameter31 = ((needErjaIntmsgBody != null) ? new ObjectParameter("NeedErjaIntmsgBody", needErjaIntmsgBody) : new ObjectParameter("NeedErjaIntmsgBody", typeof(string)));
		ObjectParameter objectParameter32 = ((needErjaIntmsgdAttachRecDesc != null) ? new ObjectParameter("NeedErjaIntmsgdAttachRecDesc", needErjaIntmsgdAttachRecDesc) : new ObjectParameter("NeedErjaIntmsgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter33 = (needSendErjaAllarm.HasValue ? new ObjectParameter("NeedSendErjaAllarm", needSendErjaAllarm) : new ObjectParameter("NeedSendErjaAllarm", typeof(bool)));
		ObjectParameter objectParameter34 = ((needSendErjaAllarmIntmsgSubject != null) ? new ObjectParameter("NeedSendErjaAllarmIntmsgSubject", needSendErjaAllarmIntmsgSubject) : new ObjectParameter("NeedSendErjaAllarmIntmsgSubject", typeof(string)));
		ObjectParameter objectParameter35 = ((needSendErjaAllarmIntmsgBody != null) ? new ObjectParameter("NeedSendErjaAllarmIntmsgBody", needSendErjaAllarmIntmsgBody) : new ObjectParameter("NeedSendErjaAllarmIntmsgBody", typeof(string)));
		ObjectParameter objectParameter36 = ((needSendErjaAllarmIntmsgdAttachRecDesc != null) ? new ObjectParameter("NeedSendErjaAllarmIntmsgdAttachRecDesc", needSendErjaAllarmIntmsgdAttachRecDesc) : new ObjectParameter("NeedSendErjaAllarmIntmsgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter37 = ((currTime != null) ? new ObjectParameter("CurrTime", currTime) : new ObjectParameter("CurrTime", typeof(string)));
		ObjectParameter objectParameter38 = (cnvsDateTime.HasValue ? new ObjectParameter("cnvsDateTime", cnvsDateTime) : new ObjectParameter("cnvsDateTime", typeof(DateTime)));
		ObjectParameter objectParameter39 = (cnvsRemindDateTime.HasValue ? new ObjectParameter("cnvsRemindDateTime", cnvsRemindDateTime) : new ObjectParameter("cnvsRemindDateTime", typeof(DateTime)));
		ObjectParameter objectParameter40 = (cnvsFirstRegisterDateTime.HasValue ? new ObjectParameter("cnvsFirstRegisterDateTime", cnvsFirstRegisterDateTime) : new ObjectParameter("cnvsFirstRegisterDateTime", typeof(DateTime)));
		ObjectParameter objectParameter41 = (cnvsRemindDateTimeForAllarm.HasValue ? new ObjectParameter("cnvsRemindDateTimeForAllarm", cnvsRemindDateTimeForAllarm) : new ObjectParameter("cnvsRemindDateTimeForAllarm", typeof(DateTime)));
		ObjectParameter objectParameter42 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter43 = (internalMessageYear1.HasValue ? new ObjectParameter("InternalMessageYear1", internalMessageYear1) : new ObjectParameter("InternalMessageYear1", typeof(short)));
		ObjectParameter objectParameter44 = ((apiId != null) ? new ObjectParameter("ApiId", apiId) : new ObjectParameter("ApiId", typeof(string)));
		ObjectParameter objectParameter45 = ((cnvsCoordinateLatitude != null) ? new ObjectParameter("CnvsCoordinateLatitude", cnvsCoordinateLatitude) : new ObjectParameter("CnvsCoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter46 = ((cnvsCoordinateLongitude != null) ? new ObjectParameter("CnvsCoordinateLongitude", cnvsCoordinateLongitude) : new ObjectParameter("CnvsCoordinateLongitude", typeof(string)));
		ObjectParameter objectParameter47 = (cnvsCoordinateLastDate.HasValue ? new ObjectParameter("CnvsCoordinateLastDate", cnvsCoordinateLastDate) : new ObjectParameter("CnvsCoordinateLastDate", typeof(DateTime)));
		ObjectParameter objectParameter48 = ((cnvsCoordinateLastDatePersian != null) ? new ObjectParameter("CnvsCoordinateLastDatePersian", cnvsCoordinateLastDatePersian) : new ObjectParameter("CnvsCoordinateLastDatePersian", typeof(string)));
		ObjectParameter objectParameter49 = (cnvsDoingTime.HasValue ? new ObjectParameter("CnvsDoingTime", cnvsDoingTime) : new ObjectParameter("CnvsDoingTime", typeof(TimeSpan)));
		ObjectParameter objectParameter50 = (cnvsIsCopy.HasValue ? new ObjectParameter("CnvsIsCopy", cnvsIsCopy) : new ObjectParameter("CnvsIsCopy", typeof(bool)));
		ObjectParameter objectParameter51 = (cnvsDoingTimeSec.HasValue ? new ObjectParameter("CnvsDoingTimeSec", cnvsDoingTimeSec) : new ObjectParameter("CnvsDoingTimeSec", typeof(long)));
		ObjectParameter objectParameter52 = (cnvsIsTicket.HasValue ? new ObjectParameter("CnvsIsTicket", cnvsIsTicket) : new ObjectParameter("CnvsIsTicket", typeof(bool)));
		ObjectParameter objectParameter53 = (cnvsStatusResultId.HasValue ? new ObjectParameter("cnvsStatusResultId", cnvsStatusResultId) : new ObjectParameter("cnvsStatusResultId", typeof(int)));
		ObjectParameter objectParameter54 = (cnvsIsCopyRemindDate.HasValue ? new ObjectParameter("CnvsIsCopyRemindDate", cnvsIsCopyRemindDate) : new ObjectParameter("CnvsIsCopyRemindDate", typeof(bool)));
		ObjectParameter objectParameter55 = (cnvsIsCopyRemindDateForAllarm.HasValue ? new ObjectParameter("CnvsIsCopyRemindDateForAllarm", cnvsIsCopyRemindDateForAllarm) : new ObjectParameter("CnvsIsCopyRemindDateForAllarm", typeof(bool)));
		ObjectParameter objectParameter56 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertConversationSupportReferMultilUser", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, allIds, allSendErjaAllarmIds, allErjaIds, objectParameter42, objectParameter43, objectParameter44, objectParameter45, objectParameter46, objectParameter47, objectParameter48, objectParameter49, objectParameter50, objectParameter51, objectParameter52, objectParameter53, objectParameter54, objectParameter55, objectParameter56);
	}

	public virtual ObjectResult<MobspSelectCompanyCity_Result> MobspSelectCompanyCity(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyCity_Result>("MobspSelectCompanyCity", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyPresentation_Result> MobspSelectCompanyPresentation(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyPresentation_Result>("MobspSelectCompanyPresentation", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCompanyProvince_Result> MobspSelectCompanyProvince(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyProvince_Result>("MobspSelectCompanyProvince", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyReferUsers_Result> MobspSelectCompanyReferUsers(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyReferUsers_Result>("MobspSelectCompanyReferUsers", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyTitle_Result> MobspSelectCompanyTitle(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyTitle_Result>("MobspSelectCompanyTitle", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCompanyType_Result> MobspSelectCompanyType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyType_Result>("MobspSelectCompanyType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCountry_Result> MobspSelectCountry(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCountry_Result>("MobspSelectCountry", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectEducation_Result> MobspSelectEducation(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEducation_Result>("MobspSelectEducation", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPersonDepartments_Result> MobspSelectPersonDepartments(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonDepartments_Result>("MobspSelectPersonDepartments", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPersonGroups_Result> MobspSelectPersonGroups(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonGroups_Result>("MobspSelectPersonGroups", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPersonJobs_Result> MobspSelectPersonJobs(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonJobs_Result>("MobspSelectPersonJobs", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPersonTitle_Result> MobspSelectPersonTitle(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonTitle_Result>("MobspSelectPersonTitle", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPersonType_Result> MobspSelectPersonType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonType_Result>("MobspSelectPersonType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectSex_Result> MobspSelectSex(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSex_Result>("MobspSelectSex", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProjectGrade_Result> MobspSelectProjectGrade(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectGrade_Result>("MobspSelectProjectGrade", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProjectGroups_Result> MobspSelectProjectGroups(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectGroups_Result>("MobspSelectProjectGroups", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProjectPriority_Result> MobspSelectProjectPriority(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectPriority_Result>("MobspSelectProjectPriority", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectsysDBObjectsNotNull_Result> MobspSelectsysDBObjectsNotNull(string dBObjectName, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((dBObjectName != null) ? new ObjectParameter("DBObjectName", dBObjectName) : new ObjectParameter("DBObjectName", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectsysDBObjectsNotNull_Result>("MobspSelectsysDBObjectsNotNull", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectsysDBObjects_Result> MobspSelectsysDBObjects(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectsysDBObjects_Result>("MobspSelectsysDBObjects", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspInternalMessageSendSingle(int? msgMasterId, string msgSubject, string msgBody, int? msgdTypeId, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? msgdPriorityId, string msgdAttachFile, int? msgdAttachRecId, string msgdAttachRecDesc, int? msgdGroupId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter insertedID, int? languageID, int? msgdAttachRecIdI, string msgdAttachRecDescI, int? centerId)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInternalMessageSendSingle", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, insertedID, objectParameter21, objectParameter22, objectParameter23, objectParameter24);
	}

	public virtual ObjectResult<MobspSelectCompanyConversationLastStatus_Result> MobspSelectCompanyConversationLastStatus(int? companyId, int? projectId, int? languageID, int? defaultLanguageID, ObjectParameter cnvsReferUserId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyConversationLastStatus_Result>("MobspSelectCompanyConversationLastStatus", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, cnvsReferUserId });
	}

	public virtual ObjectResult<string> MobspGetCnvsEventPolicyInfo(int? conversationID, int? conversationStatusID, int? cnvsProjectID, int? cnvsCompanyId, int? cnvsPersonId)
	{
		ObjectParameter objectParameter = (conversationID.HasValue ? new ObjectParameter("ConversationID", conversationID) : new ObjectParameter("ConversationID", typeof(int)));
		ObjectParameter objectParameter2 = (conversationStatusID.HasValue ? new ObjectParameter("ConversationStatusID", conversationStatusID) : new ObjectParameter("ConversationStatusID", typeof(int)));
		ObjectParameter objectParameter3 = (cnvsProjectID.HasValue ? new ObjectParameter("cnvsProjectID", cnvsProjectID) : new ObjectParameter("cnvsProjectID", typeof(int)));
		ObjectParameter objectParameter4 = (cnvsCompanyId.HasValue ? new ObjectParameter("cnvsCompanyId", cnvsCompanyId) : new ObjectParameter("cnvsCompanyId", typeof(int)));
		ObjectParameter objectParameter5 = (cnvsPersonId.HasValue ? new ObjectParameter("cnvsPersonId", cnvsPersonId) : new ObjectParameter("cnvsPersonId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MobspGetCnvsEventPolicyInfo", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<int?> MobspInsertQuickCompany(string company, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string personLabel, ObjectParameter insertedCompanyId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((company != null) ? new ObjectParameter("Company", company) : new ObjectParameter("Company", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((personLabel != null) ? new ObjectParameter("PersonLabel", personLabel) : new ObjectParameter("PersonLabel", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickCompany", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			insertedCompanyId, errorMessage, objectParameter11
		});
	}

	public virtual ObjectResult<int?> MobspInsertQuickPerson(string personList, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string typeTable, ObjectParameter insertedPersonIds, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((personList != null) ? new ObjectParameter("PersonList", personList) : new ObjectParameter("PersonList", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((typeTable != null) ? new ObjectParameter("TypeTable", typeTable) : new ObjectParameter("TypeTable", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickPerson", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			insertedPersonIds, errorMessage, objectParameter11
		});
	}

	public virtual ObjectResult<int?> MobspInsertQuickProject(string projectList, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string typeTable, ObjectParameter insertedProjectIds, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((projectList != null) ? new ObjectParameter("ProjectList", projectList) : new ObjectParameter("ProjectList", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((typeTable != null) ? new ObjectParameter("TypeTable", typeTable) : new ObjectParameter("TypeTable", typeof(string)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickProject", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			insertedProjectIds, errorMessage, objectParameter11
		});
	}

	public virtual ObjectResult<int?> MobspDeleteCrmFilesDirectory(int? fileDirectoryID)
	{
		ObjectParameter objectParameter = (fileDirectoryID.HasValue ? new ObjectParameter("FileDirectoryID", fileDirectoryID) : new ObjectParameter("FileDirectoryID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCrmFilesDirectory", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectCrmFilesDirectory_Result> MobspSelectCrmFilesDirectory(int? fileDirectoryId)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCrmFilesDirectory_Result>("MobspSelectCrmFilesDirectory", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_MobspSearchCompanyQuick_Result> MobspSearchCompanyQuick(string val, int? userID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_MobspSearchCompanyQuick_Result>("MobspSearchCompanyQuick", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<mct_MobspSearchCompany_Result> MobspSearchCompany(int? userId, string val, int? languageID, int? defaultLanguageID, string personLabel, int? pageNumber, int? pageSize, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((personLabel != null) ? new ObjectParameter("PersonLabel", personLabel) : new ObjectParameter("PersonLabel", typeof(string)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_MobspSearchCompany_Result>("MobspSearchCompany", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual int MobspInternalMessageLoadReceiver(int? crmUserId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInternalMessageLoadReceiver", objectParameter);
	}

	public virtual int MobspIntMsgUpdateSelectReceiver(string crmUserId, string userId, bool? selected, int? mode)
	{
		ObjectParameter objectParameter = ((crmUserId != null) ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(string)));
		ObjectParameter objectParameter2 = ((userId != null) ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(string)));
		ObjectParameter objectParameter3 = (selected.HasValue ? new ObjectParameter("Selected", selected) : new ObjectParameter("Selected", typeof(bool)));
		ObjectParameter objectParameter4 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspIntMsgUpdateSelectReceiver", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<string> MobspInternalMessageMakeAllReceiverTogether(int? type, int? crmUserId, int? internalMessageId, int? msgdTypeId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (type.HasValue ? new ObjectParameter("Type", type) : new ObjectParameter("Type", typeof(int)));
		ObjectParameter objectParameter2 = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		ObjectParameter objectParameter3 = (internalMessageId.HasValue ? new ObjectParameter("InternalMessageId", internalMessageId) : new ObjectParameter("InternalMessageId", typeof(int)));
		ObjectParameter objectParameter4 = (msgdTypeId.HasValue ? new ObjectParameter("msgdTypeId", msgdTypeId) : new ObjectParameter("msgdTypeId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MobspInternalMessageMakeAllReceiverTogether", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectInternalMessageGroup_Result> MobspSelectInternalMessageGroup(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectInternalMessageGroup_Result>("MobspSelectInternalMessageGroup", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspUpdateCompanyProject(int? companyId, int? projectId, string project, int? userId, short? year1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter updatedProjectId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((project != null) ? new ObjectParameter("Project", project) : new ObjectParameter("Project", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCompanyProject", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, updatedProjectId, errorMessage,
			objectParameter9
		});
	}

	public virtual int MobspUpdateConversation(int? companyId, int? projectId, int? conversationId, string conversation, int? userId, short? year1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter updatedConversationId, ObjectParameter errorMessage, ObjectParameter result, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter4 = ((conversation != null) ? new ObjectParameter("Conversation", conversation) : new ObjectParameter("Conversation", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateConversation", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, updatedConversationId, errorMessage, result, objectParameter10);
	}

	public virtual ObjectResult<MobspSelectConversationPriority_Result> MobspSelectConversationPriority(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationPriority_Result>("MobspSelectConversationPriority", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspDeleteCrmCompany(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCrmCompany", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteCrmCompanyPerson(int? companyPersonId)
	{
		ObjectParameter objectParameter = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCrmCompanyPerson", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteCrmConversation(int? conversationId)
	{
		ObjectParameter objectParameter = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCrmConversation", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteCrmProject(int? projectId, int? companyId, int? prjcnvsStatusGroupId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCrmProject", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspUpdateCompany(int? companyId, string company, int? userId, short? year1, string appType, int? languageID, int? defaultLanguageID, string personLabel, string lackOfShowText, ObjectParameter updatedCompanyId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((company != null) ? new ObjectParameter("Company", company) : new ObjectParameter("Company", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = ((personLabel != null) ? new ObjectParameter("PersonLabel", personLabel) : new ObjectParameter("PersonLabel", typeof(string)));
		ObjectParameter objectParameter9 = ((lackOfShowText != null) ? new ObjectParameter("LackOfShowText", lackOfShowText) : new ObjectParameter("LackOfShowText", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCompany", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, updatedCompanyId,
			errorMessage, objectParameter10
		});
	}

	public virtual ObjectResult<int?> MobspUpdateCompanyPerson(int? personId, string person, int? companyId, int? userId, short? year1, string appType, int? languageID, int? defaultLanguageID, string lackOfShowText, ObjectParameter updatedPersonId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (personId.HasValue ? new ObjectParameter("PersonId", personId) : new ObjectParameter("PersonId", typeof(int)));
		ObjectParameter objectParameter2 = ((person != null) ? new ObjectParameter("Person", person) : new ObjectParameter("Person", typeof(string)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = ((lackOfShowText != null) ? new ObjectParameter("LackOfShowText", lackOfShowText) : new ObjectParameter("LackOfShowText", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCompanyPerson", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, updatedPersonId,
			errorMessage, objectParameter10
		});
	}

	public virtual ObjectResult<int?> MobspUpdateFileDirectory(int? fileDirectoryId, int? fileDirectoryTypeId, string title, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string docDate, DateTime? docDateTime, string docDay, string docTime, string appType, int? defaultLanguageID, ObjectParameter updatedFileDirectoryId, ObjectParameter errorMessage, string fileDesc)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		ObjectParameter objectParameter2 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter3 = ((title != null) ? new ObjectParameter("Title", title) : new ObjectParameter("Title", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((docDate != null) ? new ObjectParameter("DocDate", docDate) : new ObjectParameter("DocDate", typeof(string)));
		ObjectParameter objectParameter10 = (docDateTime.HasValue ? new ObjectParameter("DocDateTime", docDateTime) : new ObjectParameter("DocDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((docDay != null) ? new ObjectParameter("DocDay", docDay) : new ObjectParameter("DocDay", typeof(string)));
		ObjectParameter objectParameter12 = ((docTime != null) ? new ObjectParameter("DocTime", docTime) : new ObjectParameter("DocTime", typeof(string)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter15 = ((fileDesc != null) ? new ObjectParameter("FileDesc", fileDesc) : new ObjectParameter("FileDesc", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateFileDirectory", new ObjectParameter[17]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, updatedFileDirectoryId, errorMessage, objectParameter15
		});
	}

	public virtual ObjectResult<int?> MobspDeleteCrmUserTasks(int? userTaskId)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCrmUserTasks", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspUpdateCrmConversationRemindTimeForAllarm(int? conversationId, string cnvsRemindTime, string cnvsRemindDateForAllarm, DateTime? cnvsRemindDateTimeForAllarm, string appType, ObjectParameter updatedConversationId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter2 = ((cnvsRemindTime != null) ? new ObjectParameter("cnvsRemindTime", cnvsRemindTime) : new ObjectParameter("cnvsRemindTime", typeof(string)));
		ObjectParameter objectParameter3 = ((cnvsRemindDateForAllarm != null) ? new ObjectParameter("cnvsRemindDateForAllarm", cnvsRemindDateForAllarm) : new ObjectParameter("cnvsRemindDateForAllarm", typeof(string)));
		ObjectParameter objectParameter4 = (cnvsRemindDateTimeForAllarm.HasValue ? new ObjectParameter("cnvsRemindDateTimeForAllarm", cnvsRemindDateTimeForAllarm) : new ObjectParameter("cnvsRemindDateTimeForAllarm", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCrmConversationRemindTimeForAllarm", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, updatedConversationId, errorMessage });
	}

	public virtual ObjectResult<int?> MobspUpdateCrmUserTaskRemindTime(int? userTaskId, string userTaskRemindDate, string userTaskRemindTime, DateTime? userTaskRemindDateTime, string appType, ObjectParameter updatedUserTaskId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		ObjectParameter objectParameter2 = ((userTaskRemindDate != null) ? new ObjectParameter("UserTaskRemindDate", userTaskRemindDate) : new ObjectParameter("UserTaskRemindDate", typeof(string)));
		ObjectParameter objectParameter3 = ((userTaskRemindTime != null) ? new ObjectParameter("UserTaskRemindTime", userTaskRemindTime) : new ObjectParameter("UserTaskRemindTime", typeof(string)));
		ObjectParameter objectParameter4 = (userTaskRemindDateTime.HasValue ? new ObjectParameter("UserTaskRemindDateTime", userTaskRemindDateTime) : new ObjectParameter("UserTaskRemindDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCrmUserTaskRemindTime", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, updatedUserTaskId, errorMessage });
	}

	public virtual ObjectResult<MobspSelectLastCrmConversation_Result> MobspSelectLastCrmConversation(int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLastCrmConversation_Result>("MobspSelectLastCrmConversation", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspLoadRemindingTaskWithFuture_Result> MobspLoadRemindingTaskWithFuture(int? userId, DateTime? dateTime, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (dateTime.HasValue ? new ObjectParameter("DateTime", dateTime) : new ObjectParameter("DateTime", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLoadRemindingTaskWithFuture_Result>("MobspLoadRemindingTaskWithFuture", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectLogoWithID_Result> MobspSelectLogoWithID(int? logoId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (logoId.HasValue ? new ObjectParameter("LogoId", logoId) : new ObjectParameter("LogoId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLogoWithID_Result>("MobspSelectLogoWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectPreOrderItemSpecificationByItemId_Result> MobspSelectPreOrderItemSpecificationByItemId(int? preOrderItemId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderItemId.HasValue ? new ObjectParameter("PreOrderItemId", preOrderItemId) : new ObjectParameter("PreOrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderItemSpecificationByItemId_Result>("MobspSelectPreOrderItemSpecificationByItemId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectLanguages_Result> MobspSelectLanguages()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLanguages_Result>("MobspSelectLanguages", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectUsers_Result> MobspSelectUsers(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUsers_Result>("MobspSelectUsers", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspGetUserForCnvsReferToMultilUser(int? userId, int? linkedType, string referMultiUserIdsSelected, int? companyId, string cmpNotAccess, int? languageID, int? defaultLanguageID, ObjectParameter referMultiUsersSelected)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = ((referMultiUserIdsSelected != null) ? new ObjectParameter("ReferMultiUserIdsSelected", referMultiUserIdsSelected) : new ObjectParameter("ReferMultiUserIdsSelected", typeof(string)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = ((cmpNotAccess != null) ? new ObjectParameter("CmpNotAccess", cmpNotAccess) : new ObjectParameter("CmpNotAccess", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspGetUserForCnvsReferToMultilUser", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, referMultiUsersSelected);
	}

	public virtual ObjectResult<MobspSelectConversationForcedStatusBFCurr_Result> MobspSelectConversationForcedStatusBFCurr(int? conversationStatusId, int? cnvsProjectId, int? languageID, int? defaultLanguageID, ObjectParameter conversationForcedStatus, int? conversationID, int? mode)
	{
		ObjectParameter objectParameter = (conversationStatusId.HasValue ? new ObjectParameter("ConversationStatusId", conversationStatusId) : new ObjectParameter("ConversationStatusId", typeof(int)));
		ObjectParameter objectParameter2 = (cnvsProjectId.HasValue ? new ObjectParameter("cnvsProjectId", cnvsProjectId) : new ObjectParameter("cnvsProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (conversationID.HasValue ? new ObjectParameter("ConversationID", conversationID) : new ObjectParameter("ConversationID", typeof(int)));
		ObjectParameter objectParameter6 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationForcedStatusBFCurr_Result>("MobspSelectConversationForcedStatusBFCurr", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, conversationForcedStatus, objectParameter5, objectParameter6 });
	}

	public virtual int MobspPreOrderVerifyExit(int? preOrderId, int? verifierUserId, string registerDatePersian, DateTime? registerDate)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderVerifyExit", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<MobspSelectCompanyPersons_Result> MobspSelectCompanyPersons(int? companyId, int? languageID, int? defaultLanguageID, int? userId, int? centerId, bool? prsWorkingOut)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter6 = (prsWorkingOut.HasValue ? new ObjectParameter("prsWorkingOut", prsWorkingOut) : new ObjectParameter("prsWorkingOut", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyPersons_Result>("MobspSelectCompanyPersons", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int MobspMainSearchQuick(string val, int? userId, int? searchType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (searchType.HasValue ? new ObjectParameter("SearchType", searchType) : new ObjectParameter("SearchType", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspMainSearchQuick", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<mct_MobspMainSearchQuick_Result> mfi_MobspMainSearchQuick(string val, int? userId, int? searchType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (searchType.HasValue ? new ObjectParameter("SearchType", searchType) : new ObjectParameter("SearchType", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_MobspMainSearchQuick_Result>("mfi_MobspMainSearchQuick", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	[EdmFunction("CRMEntities", "MobfnReturnOrderItemsWareHouseCnt")]
	public virtual IQueryable<int?> MobfnReturnOrderItemsWareHouseCnt(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<int?>("[CRMEntities].[MobfnReturnOrderItemsWareHouseCnt](@OrderId)", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspBuyOrderVerify(int? buyOrderId, int? verifierUserId, string registerDatePersian, DateTime? registerDate)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspBuyOrderVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int MobspBuyOrderVerifyExit(int? buyOrderId, int? verifierUserId, string registerDatePersian, DateTime? registerDate)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspBuyOrderVerifyExit", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int MobspOrderVerifyExit(int? orderId, int? verifierUserId, string registerDatePersian, DateTime? registerDate)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderVerifyExit", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<MobspReturnDocForBuyOrder_Result> MobspReturnDocForBuyOrder(int? buyOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocForBuyOrder_Result>("MobspReturnDocForBuyOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectBuyOrderItemSerials_Result> MobspSelectBuyOrderItemSerials(int? buyOrderItemId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderItemId.HasValue ? new ObjectParameter("BuyOrderItemId", buyOrderItemId) : new ObjectParameter("BuyOrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectBuyOrderItemSerials_Result>("MobspSelectBuyOrderItemSerials", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspLetterVerify(int? letterId, int? verifierUserId, string registerDatePersian, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		ObjectParameter objectParameter2 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLetterVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual int MobspLetterVerifyExit(int? letterId, int? verifierUserId, string registerDatePersian, DateTime? registerDate)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		ObjectParameter objectParameter2 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLetterVerifyExit", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<MobspSelectCompanyProjects_Result> MobspSelectCompanyProjects(int? companyId, int? isFinished, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyProjects_Result>("MobspSelectCompanyProjects", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectCompanyGroup_Result> MobspSelectCompanyGroup(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyGroup_Result>("MobspSelectCompanyGroup", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyGroupsII_Result> MobspSelectCompanyGroupsII(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyGroupsII_Result>("MobspSelectCompanyGroupsII", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCompanyGroupsIII_Result> MobspSelectCompanyGroupsIII(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyGroupsIII_Result>("MobspSelectCompanyGroupsIII", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCompanyGroupsIV_Result> MobspSelectCompanyGroupsIV(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyGroupsIV_Result>("MobspSelectCompanyGroupsIV", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyGroupsMulti_Result> MobspSelectCompanyGroupsMulti(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyGroupsMulti_Result>("MobspSelectCompanyGroupsMulti", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCompanySubGroup_Result> MobspSelectCompanySubGroup(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanySubGroup_Result>("MobspSelectCompanySubGroup", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectFileDirectoryType_Result> MobspSelectFileDirectoryType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectFileDirectoryType_Result>("MobspSelectFileDirectoryType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectUserBaseInfoStatus_Result> MobspSelectUserBaseInfoStatus(int? userId, string imeiCode, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserBaseInfoStatus_Result>("MobspSelectUserBaseInfoStatus", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdatedUserMobBaseInfo(int? userId, string imeiCode, string appName, DateTime? registerDate, string registerDatePersian)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdatedUserMobBaseInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<MobspSelectPreOrderOpr_Result> MobspSelectPreOrderOpr(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderOpr_Result>("MobspSelectPreOrderOpr", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectGuaranty_Result> MobspSelectGuaranty(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectGuaranty_Result>("MobspSelectGuaranty", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectDeliveryTime_Result> MobspSelectDeliveryTime(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDeliveryTime_Result>("MobspSelectDeliveryTime", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPayCondition_Result> MobspSelectPayCondition(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPayCondition_Result>("MobspSelectPayCondition", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPrintFormat_Result> MobspSelectPrintFormat(int? printFormatTypeId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (printFormatTypeId.HasValue ? new ObjectParameter("PrintFormatTypeId", printFormatTypeId) : new ObjectParameter("PrintFormatTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPrintFormat_Result>("MobspSelectPrintFormat", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectPreOrderVerifiers_Result> MobspSelectPreOrderVerifiers(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderVerifiers_Result>("MobspSelectPreOrderVerifiers", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectLogo_Result> MobspSelectLogo(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLogo_Result>("MobspSelectLogo", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductPriceGroup_Result> MobspSelectProductPriceGroup(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductPriceGroup_Result>("MobspSelectProductPriceGroup", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductCostGroup_Result> MobspSelectProductCostGroup(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductCostGroup_Result>("MobspSelectProductCostGroup", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<WSspSelectProductUnits_Result> WSspSelectProductUnits(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectProductUnits_Result>("WSspSelectProductUnits", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectOrderPaymentTypes_Result> MobspSelectOrderPaymentTypes(int? languageID, int? defaultLanguageID, int? userId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderPaymentTypes_Result>("MobspSelectOrderPaymentTypes", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectProductSpecification_Result> MobspSelectProductSpecification(DateTime? registerDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductSpecification_Result>("MobspSelectProductSpecification", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspSearchQuickCompany(string val, int? userID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSearchQuickCompany", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<mct_MobspSearchQuickCompany_Result> mfi_MobspSearchQuickCompany(string val, int? userID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_MobspSearchQuickCompany_Result>("mfi_MobspSearchQuickCompany", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<int?> MobspUpdatePreOrder(int? preOrderId, string preOrder, int? userId, short? month1, int? fPId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter updatedPreOrderId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((preOrder != null) ? new ObjectParameter("PreOrder", preOrder) : new ObjectParameter("PreOrder", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdatePreOrder", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, updatedPreOrderId, errorMessage,
			objectParameter9
		});
	}

	public virtual ObjectResult<int?> MobspDeleteWSPreOrder(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteWSPreOrder", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteWSPreOrderItems(int? preOrderItemId)
	{
		ObjectParameter objectParameter = (preOrderItemId.HasValue ? new ObjectParameter("PreOrderItemId", preOrderItemId) : new ObjectParameter("PreOrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteWSPreOrderItems", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteWSPreOrderPayments(int? preOrderPaymentId)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteWSPreOrderPayments", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspUpdatePreOrderPayment(int? preOrderPaymentId, string preOrderPayment, int? userId, short? month1, int? fPId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter updatedPordPaymentId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (preOrderPaymentId.HasValue ? new ObjectParameter("PreOrderPaymentId", preOrderPaymentId) : new ObjectParameter("PreOrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = ((preOrderPayment != null) ? new ObjectParameter("PreOrderPayment", preOrderPayment) : new ObjectParameter("PreOrderPayment", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdatePreOrderPayment", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, updatedPordPaymentId, errorMessage });
	}

	public virtual ObjectResult<MobspSelectUserForLinkedType_Result> MobspSelectUserForLinkedType(int? userId, int? linkedType, int? languageID, int? defaultLanguageID, int? centerId, bool? sort)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter6 = (sort.HasValue ? new ObjectParameter("Sort", sort) : new ObjectParameter("Sort", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserForLinkedType_Result>("MobspSelectUserForLinkedType", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<int?> MobspInsertQuickPreOrderPayment(string preOrderPayment, DateTime? registerDate, string registerDatePersian, int? userId, short? month1, int? fPId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter insertedPordPaymentId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((preOrderPayment != null) ? new ObjectParameter("PreOrderPayment", preOrderPayment) : new ObjectParameter("PreOrderPayment", typeof(string)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickPreOrderPayment", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, insertedPordPaymentId,
			errorMessage, objectParameter10
		});
	}

	public virtual ObjectResult<int?> MobspUpdatePreOrderItem(int? preOrderItemId, string preOrderItem, int? userId, short? month1, int? fPId, string appType, int? languageID, int? defaultLanguageID, bool? actCanNotSelectWithNoStock, ObjectParameter updatedPordItemId, ObjectParameter errorMessage, bool? dontCheckQuantity, bool? actCanNotSelectWithNoReserveStock, bool? actCanNotSelectWithNoSoldStock)
	{
		ObjectParameter objectParameter = (preOrderItemId.HasValue ? new ObjectParameter("PreOrderItemId", preOrderItemId) : new ObjectParameter("PreOrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = ((preOrderItem != null) ? new ObjectParameter("PreOrderItem", preOrderItem) : new ObjectParameter("PreOrderItem", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (actCanNotSelectWithNoStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoStock", actCanNotSelectWithNoStock) : new ObjectParameter("ActCanNotSelectWithNoStock", typeof(bool)));
		ObjectParameter objectParameter10 = (dontCheckQuantity.HasValue ? new ObjectParameter("DontCheckQuantity", dontCheckQuantity) : new ObjectParameter("DontCheckQuantity", typeof(bool)));
		ObjectParameter objectParameter11 = (actCanNotSelectWithNoReserveStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoReserveStock", actCanNotSelectWithNoReserveStock) : new ObjectParameter("ActCanNotSelectWithNoReserveStock", typeof(bool)));
		ObjectParameter objectParameter12 = (actCanNotSelectWithNoSoldStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoSoldStock", actCanNotSelectWithNoSoldStock) : new ObjectParameter("ActCanNotSelectWithNoSoldStock", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdatePreOrderItem", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, updatedPordItemId,
			errorMessage, objectParameter10, objectParameter11, objectParameter12
		});
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

	public virtual ObjectResult<CRMspDyPrintPordForm_Result> CRMspDyPrintPordForm(int? preOrderId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintPordForm_Result>("CRMspDyPrintPordForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
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

	public virtual ObjectResult<CRMspPrintProjectInformationTree_Result> CRMspPrintProjectInformationTree(int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspPrintProjectInformationTree_Result>("CRMspPrintProjectInformationTree", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspSelectPreOrderItemSpecificationByItemId_Result> WSspSelectPreOrderItemSpecificationByItemId(int? preOrderItemId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderItemId.HasValue ? new ObjectParameter("PreOrderItemId", preOrderItemId) : new ObjectParameter("PreOrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspSelectPreOrderItemSpecificationByItemId_Result>("WSspSelectPreOrderItemSpecificationByItemId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnPrintFormatFileNameById_Result> MobspReturnPrintFormatFileNameById(int? printFormatID)
	{
		ObjectParameter objectParameter = (printFormatID.HasValue ? new ObjectParameter("PrintFormatID", printFormatID) : new ObjectParameter("PrintFormatID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnPrintFormatFileNameById_Result>("MobspReturnPrintFormatFileNameById", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspGetMaxSmsSendDetailId_Result> MobspGetMaxSmsSendDetailId()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspGetMaxSmsSendDetailId_Result>("MobspGetMaxSmsSendDetailId", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectOrderOpr_Result> MobspSelectOrderOpr(int? languageID, int? defaultLanguageID, int? userId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderOpr_Result>("MobspSelectOrderOpr", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSettlementType_Result> MobspSettlementType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSettlementType_Result>("MobspSettlementType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspCheckDuplicatePrsMobileByCmpId_Result> MobspCheckDuplicatePrsMobileByCmpId(string prsMobile, int? companyId, int? currId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((prsMobile != null) ? new ObjectParameter("PrsMobile", prsMobile) : new ObjectParameter("PrsMobile", typeof(string)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicatePrsMobileByCmpId_Result>("MobspCheckDuplicatePrsMobileByCmpId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectCompanyByIdWithOutAccess_Result> MobspSelectCompanyByIdWithOutAccess(int? companyId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyByIdWithOutAccess_Result>("MobspSelectCompanyByIdWithOutAccess", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCrmProjectByProjectTitle_Result> MobspSelectCrmProjectByProjectTitle(string projectTitle, int? companyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((projectTitle != null) ? new ObjectParameter("ProjectTitle", projectTitle) : new ObjectParameter("ProjectTitle", typeof(string)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCrmProjectByProjectTitle_Result>("MobspSelectCrmProjectByProjectTitle", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> MobspUpdateCompanyForPs(int? companyId, string company, int? userId, short? year1, string appType, int? languageID, int? defaultLanguageID, string personLabel, string lackOfShowText, ObjectParameter updatedCompanyId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((company != null) ? new ObjectParameter("Company", company) : new ObjectParameter("Company", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = ((personLabel != null) ? new ObjectParameter("PersonLabel", personLabel) : new ObjectParameter("PersonLabel", typeof(string)));
		ObjectParameter objectParameter9 = ((lackOfShowText != null) ? new ObjectParameter("LackOfShowText", lackOfShowText) : new ObjectParameter("LackOfShowText", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCompanyForPs", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, updatedCompanyId,
			errorMessage, objectParameter10
		});
	}

	public virtual ObjectResult<int?> MobspUpdateCompanyPersonForPs(int? personId, string person, int? companyId, int? userId, short? year1, string appType, int? languageID, int? defaultLanguageID, string lackOfShowText, ObjectParameter updatedPersonId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (personId.HasValue ? new ObjectParameter("PersonId", personId) : new ObjectParameter("PersonId", typeof(int)));
		ObjectParameter objectParameter2 = ((person != null) ? new ObjectParameter("Person", person) : new ObjectParameter("Person", typeof(string)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = ((lackOfShowText != null) ? new ObjectParameter("LackOfShowText", lackOfShowText) : new ObjectParameter("LackOfShowText", typeof(string)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("centerId", centerId) : new ObjectParameter("centerId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCompanyPersonForPs", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, updatedPersonId,
			errorMessage, objectParameter10
		});
	}

	public virtual ObjectResult<int?> MobspReturnCmpDraftCount(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnCmpDraftCount", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_MobspSearchCompany_Result> MobspSearchCompanyWithName(int? userId, string name, int? languageID, int? defaultLanguageID, string personLabel, int? pageNumber, int? pageSize, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((name != null) ? new ObjectParameter("Name", name) : new ObjectParameter("Name", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = ((personLabel != null) ? new ObjectParameter("PersonLabel", personLabel) : new ObjectParameter("PersonLabel", typeof(string)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_MobspSearchCompany_Result>("MobspSearchCompanyWithName", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<mct_MobspSelectCompanyWithID_Result> MobspSelectCompanyWithID(int? companyId, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_MobspSelectCompanyWithID_Result>("MobspSelectCompanyWithID", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectPersonWithID_Result> MobspSelectPersonWithID(int? companyPersonId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonWithID_Result>("MobspSelectPersonWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspGetNotExistCompany_Result> MobspGetNotExistCompany(string allIds)
	{
		ObjectParameter objectParameter = ((allIds != null) ? new ObjectParameter("AllIds", allIds) : new ObjectParameter("AllIds", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspGetNotExistCompany_Result>("MobspGetNotExistCompany", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectCompanyProjectFromRemindDate_Result> MobspSelectCompanyProjectFromRemindDate(string fDate, string tDate, DateTime? fDateTime, DateTime? tDateTime, bool? prjIsFinished, int? prjcnvsStatusGroupId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = ((fDate != null) ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(string)));
		ObjectParameter objectParameter2 = ((tDate != null) ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(string)));
		ObjectParameter objectParameter3 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (prjIsFinished.HasValue ? new ObjectParameter("prjIsFinished", prjIsFinished) : new ObjectParameter("prjIsFinished", typeof(bool)));
		ObjectParameter objectParameter6 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("prjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("prjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyProjectFromRemindDate_Result>("MobspSelectCompanyProjectFromRemindDate", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	[EdmFunction("CRMEntities", "MobfnReturnBuyOrderSumFooter")]
	public virtual IQueryable<MobfnReturnBuyOrderSumFooter_Result> MobfnReturnBuyOrderSumFooter(int? buyOrderId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<MobfnReturnBuyOrderSumFooter_Result>("[CRMEntities].[MobfnReturnBuyOrderSumFooter](@BuyOrderId)", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<decimal?> MobspReturnPreOrderINotInSumTotalPrice(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<decimal?>("MobspReturnPreOrderINotInSumTotalPrice", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnSumBuyOrderPay_Result> MobspReturnSumBuyOrderPay(int? buyOrderId)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnSumBuyOrderPay_Result>("MobspReturnSumBuyOrderPay", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectBuyOrderItems_Result> MobspSelectBuyOrderItems(int? buyOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectBuyOrderItems_Result>("MobspSelectBuyOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectBuyOrderPayments_Result> MobspSelectBuyOrderPayments(int? buyOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectBuyOrderPayments_Result>("MobspSelectBuyOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectBuyOrderWithID_Result> MobspSelectBuyOrderWithID(int? buyOrderId, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (buyOrderId.HasValue ? new ObjectParameter("BuyOrderId", buyOrderId) : new ObjectParameter("BuyOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectBuyOrderWithID_Result>("MobspSelectBuyOrderWithID", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspCheckDuplicateCmpMobile_Result> MobspCheckDuplicateCmpMobile(string cmpMobile, int? currId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((cmpMobile != null) ? new ObjectParameter("CmpMobile", cmpMobile) : new ObjectParameter("CmpMobile", typeof(string)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicateCmpMobile_Result>("MobspCheckDuplicateCmpMobile", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> MobspInsertLinkCompanyByCmpNumber(int? companyId, int? linkedCompanyId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedCompanyId.HasValue ? new ObjectParameter("LinkedCompanyId", linkedCompanyId) : new ObjectParameter("LinkedCompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertLinkCompanyByCmpNumber", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspSearchCompanyWithAllFields_Result> MobspSearchCompanyWithAllFields(string fieldName, string value, int? centerId)
	{
		ObjectParameter objectParameter = ((fieldName != null) ? new ObjectParameter("FieldName", fieldName) : new ObjectParameter("FieldName", typeof(string)));
		ObjectParameter objectParameter2 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSearchCompanyWithAllFields_Result>("MobspSearchCompanyWithAllFields", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectDeliveryScheduleByDayNumberAndDate_Result> MobspSelectDeliveryScheduleByDayNumberAndDate(int? dayNumber, DateTime? date, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (dayNumber.HasValue ? new ObjectParameter("DayNumber", dayNumber) : new ObjectParameter("DayNumber", typeof(int)));
		ObjectParameter objectParameter2 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDeliveryScheduleByDayNumberAndDate_Result>("MobspSelectDeliveryScheduleByDayNumberAndDate", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectDiscountCodeByDisCode_Result> MobspSelectDiscountCodeByDisCode(string disCode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((disCode != null) ? new ObjectParameter("DisCode", disCode) : new ObjectParameter("DisCode", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDiscountCodeByDisCode_Result>("MobspSelectDiscountCodeByDisCode", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectProductGroupPictureByPrdGroupId_Result> MobspSelectProductGroupPictureByPrdGroupId(int? prdGroupId, int? type)
	{
		ObjectParameter objectParameter = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (type.HasValue ? new ObjectParameter("Type", type) : new ObjectParameter("Type", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductGroupPictureByPrdGroupId_Result>("MobspSelectProductGroupPictureByPrdGroupId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductGroupPictureInMode_Result> MobspSelectProductGroupPictureInMode(int? showMode, int? type)
	{
		ObjectParameter objectParameter = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter2 = (type.HasValue ? new ObjectParameter("Type", type) : new ObjectParameter("Type", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductGroupPictureInMode_Result>("MobspSelectProductGroupPictureInMode", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductPriceGroupTop1_Result> MobspSelectProductPriceGroupTop1(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductPriceGroupTop1_Result>("MobspSelectProductPriceGroupTop1", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductWithPriceByPrdId_Result> MobspSelectProductWithPriceByPrdId(int? prdId, int? prdPriceGroupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductWithPriceByPrdId_Result>("MobspSelectProductWithPriceByPrdId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectProjectCategory_Result> MobspSelectProjectCategory(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectCategory_Result>("MobspSelectProjectCategory", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProjectCategoryByParentId_Result> MobspSelectProjectCategoryByParentId(int? parentId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (parentId.HasValue ? new ObjectParameter("ParentId", parentId) : new ObjectParameter("ParentId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectCategoryByParentId_Result>("MobspSelectProjectCategoryByParentId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspInternalMessageUpdate(string mode, int? messageID, int? userID, int? typeID, string time, string date, string appType, int? centerId)
	{
		ObjectParameter objectParameter = ((mode != null) ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(string)));
		ObjectParameter objectParameter2 = (messageID.HasValue ? new ObjectParameter("MessageID", messageID) : new ObjectParameter("MessageID", typeof(int)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter4 = (typeID.HasValue ? new ObjectParameter("TypeID", typeID) : new ObjectParameter("TypeID", typeof(int)));
		ObjectParameter objectParameter5 = ((time != null) ? new ObjectParameter("Time", time) : new ObjectParameter("Time", typeof(string)));
		ObjectParameter objectParameter6 = ((date != null) ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInternalMessageUpdate", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<MobspIntMsgGetToUsersInfo_Result> MobspIntMsgGetToUsersInfo(int? messageId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (messageId.HasValue ? new ObjectParameter("MessageId", messageId) : new ObjectParameter("MessageId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgGetToUsersInfo_Result>("MobspIntMsgGetToUsersInfo", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspIntMsgSelectInternalMessageType_Result> MobspIntMsgSelectInternalMessageType(int? userId, DateTime? fDate, DateTime? tDate, int? languageID, int? defaultLanguageID, string unReadText, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = ((unReadText != null) ? new ObjectParameter("UnReadText", unReadText) : new ObjectParameter("UnReadText", typeof(string)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgSelectInternalMessageType_Result>("MobspIntMsgSelectInternalMessageType", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspIntMsgSelectMessageFiles_Result> MobspIntMsgSelectMessageFiles(int? messageId)
	{
		ObjectParameter objectParameter = (messageId.HasValue ? new ObjectParameter("MessageId", messageId) : new ObjectParameter("MessageId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgSelectMessageFiles_Result>("MobspIntMsgSelectMessageFiles", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnDailyCIRecordVoiceLineNumber_Result> MobspReturnDailyCIRecordVoiceLineNumber(DateTime? fDate, DateTime? tDate, string allLineText, string lineText, int? currUserId, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((allLineText != null) ? new ObjectParameter("AllLineText", allLineText) : new ObjectParameter("AllLineText", typeof(string)));
		ObjectParameter objectParameter4 = ((lineText != null) ? new ObjectParameter("LineText", lineText) : new ObjectParameter("LineText", typeof(string)));
		ObjectParameter objectParameter5 = (currUserId.HasValue ? new ObjectParameter("CurrUserId", currUserId) : new ObjectParameter("CurrUserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDailyCIRecordVoiceLineNumber_Result>("MobspReturnDailyCIRecordVoiceLineNumber", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectCurrencyUnits_Result> MobspSelectCurrencyUnits(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCurrencyUnits_Result>("MobspSelectCurrencyUnits", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectDeliveryTerms_Result> MobspSelectDeliveryTerms(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectDeliveryTerms_Result>("MobspSelectDeliveryTerms", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspInsertDiscountCodeHistory(int? discountCodeId, string disCode, int? disCmpId, int? disPrdId, int? pordId, int? userId, int? fPID, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter insertedId)
	{
		ObjectParameter objectParameter = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter2 = ((disCode != null) ? new ObjectParameter("DisCode", disCode) : new ObjectParameter("DisCode", typeof(string)));
		ObjectParameter objectParameter3 = (disCmpId.HasValue ? new ObjectParameter("DisCmpId", disCmpId) : new ObjectParameter("DisCmpId", typeof(int)));
		ObjectParameter objectParameter4 = (disPrdId.HasValue ? new ObjectParameter("DisPrdId", disPrdId) : new ObjectParameter("DisPrdId", typeof(int)));
		ObjectParameter objectParameter5 = (pordId.HasValue ? new ObjectParameter("pordId", pordId) : new ObjectParameter("pordId", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (fPID.HasValue ? new ObjectParameter("FPID", fPID) : new ObjectParameter("FPID", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertDiscountCodeHistory", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedId);
	}

	public virtual ObjectResult<MobspReturnProductCost_Result> MobspReturnProductCost(DateTime? registerDate, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnProductCost_Result>("MobspReturnProductCost", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspReturnProductUserDiscountValue_Result> MobspReturnProductUserDiscountValue(int? userId, DateTime? registerDate)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnProductUserDiscountValue_Result>("MobspReturnProductUserDiscountValue", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductUnits_Result> MobspSelectProductUnits(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductUnits_Result>("MobspSelectProductUnits", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspReturnPrdQuantityAndValidCount_Result> MobspReturnPrdQuantityAndValidCount(int? prdId, int? fPId, int? wHId, int? currId, int? currPordId, DateTime? currDate, int? languageID, int? defaultLanguageID, double? fCR, double? fCRI, string tracing, int? centerId)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter3 = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter4 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter5 = (currPordId.HasValue ? new ObjectParameter("CurrPordId", currPordId) : new ObjectParameter("CurrPordId", typeof(int)));
		ObjectParameter objectParameter6 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (fCR.HasValue ? new ObjectParameter("FCR", fCR) : new ObjectParameter("FCR", typeof(double)));
		ObjectParameter objectParameter10 = (fCRI.HasValue ? new ObjectParameter("FCRI", fCRI) : new ObjectParameter("FCRI", typeof(double)));
		ObjectParameter objectParameter11 = ((tracing != null) ? new ObjectParameter("Tracing", tracing) : new ObjectParameter("Tracing", typeof(string)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnPrdQuantityAndValidCount_Result>("MobspReturnPrdQuantityAndValidCount", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<MobspReturnProductTracing_Result> MobspReturnProductTracing(int? wHId, int? prdId, int? centerId)
	{
		ObjectParameter objectParameter = (wHId.HasValue ? new ObjectParameter("WHId", wHId) : new ObjectParameter("WHId", typeof(int)));
		ObjectParameter objectParameter2 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnProductTracing_Result>("MobspReturnProductTracing", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectCurrencyUnitRate_Result> MobspSelectCurrencyUnitRate(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCurrencyUnitRate_Result>("MobspSelectCurrencyUnitRate", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspPrdSalePriceHistory_Result> MobspPrdSalePriceHistory(int? prdId, int? mode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspPrdSalePriceHistory_Result>("MobspPrdSalePriceHistory", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspCmpPrdBuyCostNearHistory_Result> MobspCmpPrdBuyCostNearHistory(int? companyId, int? prdId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCmpPrdBuyCostNearHistory_Result>("MobspCmpPrdBuyCostNearHistory", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspCmpPrdSalePriceHistory_Result> MobspCmpPrdSalePriceHistory(int? companyId, int? prdId, int? mode)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (prdId.HasValue ? new ObjectParameter("PrdId", prdId) : new ObjectParameter("PrdId", typeof(int)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCmpPrdSalePriceHistory_Result>("MobspCmpPrdSalePriceHistory", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnProductPrice_Result> MobspReturnProductPrice(int? productID, int? productPriceGroupId, int? languageID, int? defaultLanguageID, int? destCurrencyUnitId, int? centerId)
	{
		ObjectParameter objectParameter = (productID.HasValue ? new ObjectParameter("ProductID", productID) : new ObjectParameter("ProductID", typeof(int)));
		ObjectParameter objectParameter2 = (productPriceGroupId.HasValue ? new ObjectParameter("ProductPriceGroupId", productPriceGroupId) : new ObjectParameter("ProductPriceGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (destCurrencyUnitId.HasValue ? new ObjectParameter("DestCurrencyUnitId", destCurrencyUnitId) : new ObjectParameter("DestCurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnProductPrice_Result>("MobspReturnProductPrice", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectProductPrice_Result> MobspSelectProductPrice(DateTime? registerDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductPrice_Result>("MobspSelectProductPrice", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	[EdmFunction("CRMEntities", "MobfnReturnPreOrderSumFooter")]
	public virtual IQueryable<MobfnReturnPreOrderSumFooter_Result> MobfnReturnPreOrderSumFooter(int? preOrderID)
	{
		ObjectParameter objectParameter = (preOrderID.HasValue ? new ObjectParameter("PreOrderID", preOrderID) : new ObjectParameter("PreOrderID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<MobfnReturnPreOrderSumFooter_Result>("[CRMEntities].[MobfnReturnPreOrderSumFooter](@PreOrderID)", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnCmpAccountingSummary_Result> MobspReturnCmpAccountingSummary(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnCmpAccountingSummary_Result>("MobspReturnCmpAccountingSummary", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnSumPreOrderPay_Result> MobspReturnSumPreOrderPay(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnSumPreOrderPay_Result>("MobspReturnSumPreOrderPay", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectPreOrders_Result> MobspSelectPreOrders(int? pageNumber, int? pageSize, int? userId, int? pordNumber, DateTime? fDateTime, DateTime? tDateTime, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter2 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (pordNumber.HasValue ? new ObjectParameter("pordNumber", pordNumber) : new ObjectParameter("pordNumber", typeof(int)));
		ObjectParameter objectParameter5 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrders_Result>("MobspSelectPreOrders", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<int?> MobspIssueDuplicatePreOrder(int? preOrderId, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter insertedPreOrderId, ObjectParameter insertedPordNumber, ObjectParameter insertedPordNumberRevision, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspIssueDuplicatePreOrder", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, insertedPreOrderId, insertedPordNumber, insertedPordNumberRevision, errorMessage,
			objectParameter7
		});
	}

	public virtual ObjectResult<MobspLoadRemindingTask_Result> MobspLoadRemindingTask(string date, int? userId, DateTime? dateTime, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((date != null) ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (dateTime.HasValue ? new ObjectParameter("DateTime", dateTime) : new ObjectParameter("DateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLoadRemindingTask_Result>("MobspLoadRemindingTask", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectUserFavproductsByUserId_Result> MobspSelectUserFavproductsByUserId(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserFavproductsByUserId_Result>("MobspSelectUserFavproductsByUserId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspCheckDuplicateCompanyWithReason(string company, string personList, string projectList, int? id, int? userId, int? languageID, int? defaultLanguageID, string lackOfShowText, string personLabel, int? mode, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((company != null) ? new ObjectParameter("Company", company) : new ObjectParameter("Company", typeof(string)));
		ObjectParameter objectParameter2 = ((personList != null) ? new ObjectParameter("PersonList", personList) : new ObjectParameter("PersonList", typeof(string)));
		ObjectParameter objectParameter3 = ((projectList != null) ? new ObjectParameter("ProjectList", projectList) : new ObjectParameter("ProjectList", typeof(string)));
		ObjectParameter objectParameter4 = (id.HasValue ? new ObjectParameter("Id", id) : new ObjectParameter("Id", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = ((lackOfShowText != null) ? new ObjectParameter("LackOfShowText", lackOfShowText) : new ObjectParameter("LackOfShowText", typeof(string)));
		ObjectParameter objectParameter9 = ((personLabel != null) ? new ObjectParameter("PersonLabel", personLabel) : new ObjectParameter("PersonLabel", typeof(string)));
		ObjectParameter objectParameter10 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCheckDuplicateCompanyWithReason", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, errorMessage, objectParameter11);
	}

	public virtual ObjectResult<int?> MobspInsertQuickPreOrderItem(string preOrderItemList, DateTime? registerDate, string registerDatePersian, int? userId, short? month1, int? fPId, string appType, int? languageID, int? defaultLanguageID, bool? actCanNotSelectWithNoStock, bool? addLinkedProducts, ObjectParameter insertedPordItemId, ObjectParameter errorMessage, int? centerId, bool? dontCheckQuantity, bool? actCanNotSelectWithNoReserveStock, bool? actCanNotSelectWithNoSoldStock)
	{
		ObjectParameter objectParameter = ((preOrderItemList != null) ? new ObjectParameter("PreOrderItemList", preOrderItemList) : new ObjectParameter("PreOrderItemList", typeof(string)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (actCanNotSelectWithNoStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoStock", actCanNotSelectWithNoStock) : new ObjectParameter("ActCanNotSelectWithNoStock", typeof(bool)));
		ObjectParameter objectParameter11 = (addLinkedProducts.HasValue ? new ObjectParameter("AddLinkedProducts", addLinkedProducts) : new ObjectParameter("AddLinkedProducts", typeof(bool)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter13 = (dontCheckQuantity.HasValue ? new ObjectParameter("DontCheckQuantity", dontCheckQuantity) : new ObjectParameter("DontCheckQuantity", typeof(bool)));
		ObjectParameter objectParameter14 = (actCanNotSelectWithNoReserveStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoReserveStock", actCanNotSelectWithNoReserveStock) : new ObjectParameter("ActCanNotSelectWithNoReserveStock", typeof(bool)));
		ObjectParameter objectParameter15 = (actCanNotSelectWithNoSoldStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoSoldStock", actCanNotSelectWithNoSoldStock) : new ObjectParameter("ActCanNotSelectWithNoSoldStock", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickPreOrderItem", new ObjectParameter[17]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, insertedPordItemId, errorMessage, objectParameter12, objectParameter13, objectParameter14, objectParameter15
		});
	}

	public virtual ObjectResult<int?> MobspInsertPreOrderFull(string preOrder, string pordItemList, string pordItemSpecificationList, string pordPaymentList, int? userId, short? year1, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, bool? actCanNotSelectWithNoStock, ObjectParameter insertedPreOrderId, ObjectParameter insertedPordItemIds, ObjectParameter insertedPordItemSpcfIds, ObjectParameter insertedPordPaymentIds, ObjectParameter errorMessage, int? centerId, bool? dontCheckQuantity, bool? actCanNotSelectWithNoReserveStock, bool? actCanNotSelectWithNoSoldStock)
	{
		ObjectParameter objectParameter = ((preOrder != null) ? new ObjectParameter("PreOrder", preOrder) : new ObjectParameter("PreOrder", typeof(string)));
		ObjectParameter objectParameter2 = ((pordItemList != null) ? new ObjectParameter("PordItemList", pordItemList) : new ObjectParameter("PordItemList", typeof(string)));
		ObjectParameter objectParameter3 = ((pordItemSpecificationList != null) ? new ObjectParameter("PordItemSpecificationList", pordItemSpecificationList) : new ObjectParameter("PordItemSpecificationList", typeof(string)));
		ObjectParameter objectParameter4 = ((pordPaymentList != null) ? new ObjectParameter("PordPaymentList", pordPaymentList) : new ObjectParameter("PordPaymentList", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (actCanNotSelectWithNoStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoStock", actCanNotSelectWithNoStock) : new ObjectParameter("ActCanNotSelectWithNoStock", typeof(bool)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter16 = (dontCheckQuantity.HasValue ? new ObjectParameter("DontCheckQuantity", dontCheckQuantity) : new ObjectParameter("DontCheckQuantity", typeof(bool)));
		ObjectParameter objectParameter17 = (actCanNotSelectWithNoReserveStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoReserveStock", actCanNotSelectWithNoReserveStock) : new ObjectParameter("ActCanNotSelectWithNoReserveStock", typeof(bool)));
		ObjectParameter objectParameter18 = (actCanNotSelectWithNoSoldStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoSoldStock", actCanNotSelectWithNoSoldStock) : new ObjectParameter("ActCanNotSelectWithNoSoldStock", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertPreOrderFull", new ObjectParameter[23]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, insertedPreOrderId, insertedPordItemIds, insertedPordItemSpcfIds, insertedPordPaymentIds, errorMessage, objectParameter15,
			objectParameter16, objectParameter17, objectParameter18
		});
	}

	public virtual ObjectResult<MobspSelectPreOrderTypes_Result> MobspSelectPreOrderTypes(int? languageID, int? defaultLanguageID, int? userId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderTypes_Result>("MobspSelectPreOrderTypes", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspCheckDuplicatePreOrderWithReason(string preOrder, string pordItemList, string pordPayList, int? userId, int? languageID, int? defaultLanguageID, int? mode, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = ((preOrder != null) ? new ObjectParameter("PreOrder", preOrder) : new ObjectParameter("PreOrder", typeof(string)));
		ObjectParameter objectParameter2 = ((pordItemList != null) ? new ObjectParameter("PordItemList", pordItemList) : new ObjectParameter("PordItemList", typeof(string)));
		ObjectParameter objectParameter3 = ((pordPayList != null) ? new ObjectParameter("PordPayList", pordPayList) : new ObjectParameter("PordPayList", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCheckDuplicatePreOrderWithReason", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, errorMessage);
	}

	public virtual ObjectResult<MobspSelectUserFavproductItems_Result> MobspSelectUserFavproductItems(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserFavproductItems_Result>("MobspSelectUserFavproductItems", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectProductFirstGroup_Result> MobspSelectProductFirstGroup(int? showMode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductFirstGroup_Result>("MobspSelectProductFirstGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectProductSecondGroup_Result> MobspSelectProductSecondGroup(int? showMode, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductSecondGroup_Result>("MobspSelectProductSecondGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectPersonList_Result> MobspSelectPersonList(int? companyId, int? userId, int? languageID, int? defaultLanguageID, bool? prsWorkingOut, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (prsWorkingOut.HasValue ? new ObjectParameter("prsWorkingOut", prsWorkingOut) : new ObjectParameter("prsWorkingOut", typeof(bool)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPersonList_Result>("MobspSelectPersonList", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectProductWithPriceByGroupId_Result> MobspSelectProductWithPriceByGroupId(int? prdGroupId, int? prdFirstGroupId, string val, int? prdPriceGroupId, int? prdKind, int? showMode, int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter3 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter4 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter5 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter6 = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter7 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter8 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductWithPriceByGroupId_Result>("MobspSelectProductWithPriceByGroupId", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspSelectUser_Result> MobspSelectUser(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUser_Result>("MobspSelectUser", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectUserPictureByUserId_Result> MobspSelectUserPictureByUserId(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserPictureByUserId_Result>("MobspSelectUserPictureByUserId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectActiveEmailUsersInfoByUserId_Result> MobspSelectActiveEmailUsersInfoByUserId(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveEmailUsersInfoByUserId_Result>("MobspSelectActiveEmailUsersInfoByUserId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectActiveUsers_Result> MobspSelectActiveUsers(int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveUsers_Result>("MobspSelectActiveUsers", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectEmailUserDefaultSettingByUser_Result> MobspSelectEmailUserDefaultSettingByUser(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEmailUserDefaultSettingByUser_Result>("MobspSelectEmailUserDefaultSettingByUser", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<WSspRpt_PrintPreOrderPayments_Result> WSspRpt_PrintPreOrderPayments(int? preOrderID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderID.HasValue ? new ObjectParameter("PreOrderID", preOrderID) : new ObjectParameter("PreOrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintPreOrderPayments_Result>("WSspRpt_PrintPreOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspInsertSurveyAnswerCategoryDetailValue(int? replyCompanyId, int? replyUserId, int? historyId, int? questionId, int? answerId, int? answerCategoryDetail, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (replyCompanyId.HasValue ? new ObjectParameter("ReplyCompanyId", replyCompanyId) : new ObjectParameter("ReplyCompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (replyUserId.HasValue ? new ObjectParameter("ReplyUserId", replyUserId) : new ObjectParameter("ReplyUserId", typeof(int)));
		ObjectParameter objectParameter3 = (historyId.HasValue ? new ObjectParameter("HistoryId", historyId) : new ObjectParameter("HistoryId", typeof(int)));
		ObjectParameter objectParameter4 = (questionId.HasValue ? new ObjectParameter("QuestionId", questionId) : new ObjectParameter("QuestionId", typeof(int)));
		ObjectParameter objectParameter5 = (answerId.HasValue ? new ObjectParameter("AnswerId", answerId) : new ObjectParameter("AnswerId", typeof(int)));
		ObjectParameter objectParameter6 = (answerCategoryDetail.HasValue ? new ObjectParameter("AnswerCategoryDetail", answerCategoryDetail) : new ObjectParameter("AnswerCategoryDetail", typeof(int)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertSurveyAnswerCategoryDetailValue", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual int MobspInsertSurveyAnswerValue(int? systemPartId, int? systemPartObjectId, int? replyCompanyId, int? replyUserId, int? historyId, int? surveyId, int? questionId, int? answerId, string textValue, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (systemPartId.HasValue ? new ObjectParameter("SystemPartId", systemPartId) : new ObjectParameter("SystemPartId", typeof(int)));
		ObjectParameter objectParameter2 = (systemPartObjectId.HasValue ? new ObjectParameter("SystemPartObjectId", systemPartObjectId) : new ObjectParameter("SystemPartObjectId", typeof(int)));
		ObjectParameter objectParameter3 = (replyCompanyId.HasValue ? new ObjectParameter("ReplyCompanyId", replyCompanyId) : new ObjectParameter("ReplyCompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (replyUserId.HasValue ? new ObjectParameter("ReplyUserId", replyUserId) : new ObjectParameter("ReplyUserId", typeof(int)));
		ObjectParameter objectParameter5 = (historyId.HasValue ? new ObjectParameter("HistoryId", historyId) : new ObjectParameter("HistoryId", typeof(int)));
		ObjectParameter objectParameter6 = (surveyId.HasValue ? new ObjectParameter("SurveyId", surveyId) : new ObjectParameter("SurveyId", typeof(int)));
		ObjectParameter objectParameter7 = (questionId.HasValue ? new ObjectParameter("QuestionId", questionId) : new ObjectParameter("QuestionId", typeof(int)));
		ObjectParameter objectParameter8 = (answerId.HasValue ? new ObjectParameter("AnswerId", answerId) : new ObjectParameter("AnswerId", typeof(int)));
		ObjectParameter objectParameter9 = ((textValue != null) ? new ObjectParameter("TextValue", textValue) : new ObjectParameter("TextValue", typeof(string)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter12 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertSurveyAnswerValue", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16);
	}

	public virtual ObjectResult<MobspSelectSurvey_Result> MobspSelectSurvey(int? surveyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (surveyId.HasValue ? new ObjectParameter("SurveyId", surveyId) : new ObjectParameter("SurveyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSurvey_Result>("MobspSelectSurvey", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSurveyAnswerCategory_Result> MobspSelectSurveyAnswerCategory(string answerCategoryIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((answerCategoryIds != null) ? new ObjectParameter("AnswerCategoryIds", answerCategoryIds) : new ObjectParameter("AnswerCategoryIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSurveyAnswerCategory_Result>("MobspSelectSurveyAnswerCategory", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSurveyAnswers_Result> MobspSelectSurveyAnswers(int? questionId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (questionId.HasValue ? new ObjectParameter("QuestionId", questionId) : new ObjectParameter("QuestionId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSurveyAnswers_Result>("MobspSelectSurveyAnswers", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSurveyAnswerValue_Result> MobspSelectSurveyAnswerValue(int? companyId, int? sysPartId, int? sysPartObjId, int? surveyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (sysPartId.HasValue ? new ObjectParameter("SysPartId", sysPartId) : new ObjectParameter("SysPartId", typeof(int)));
		ObjectParameter objectParameter3 = (sysPartObjId.HasValue ? new ObjectParameter("SysPartObjId", sysPartObjId) : new ObjectParameter("SysPartObjId", typeof(int)));
		ObjectParameter objectParameter4 = (surveyId.HasValue ? new ObjectParameter("SurveyId", surveyId) : new ObjectParameter("SurveyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSurveyAnswerValue_Result>("MobspSelectSurveyAnswerValue", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspSelectSurveyQuestionDetailGroups(string questionDetailGroupIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((questionDetailGroupIds != null) ? new ObjectParameter("QuestionDetailGroupIds", questionDetailGroupIds) : new ObjectParameter("QuestionDetailGroupIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSelectSurveyQuestionDetailGroups", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual int MobspSelectSurveyQuestionDetails(int? questionDetailId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (questionDetailId.HasValue ? new ObjectParameter("QuestionDetailId", questionDetailId) : new ObjectParameter("QuestionDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSelectSurveyQuestionDetails", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual ObjectResult<MobspSelectSurveyQuestions_Result> MobspSelectSurveyQuestions(int? surveyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (surveyId.HasValue ? new ObjectParameter("SurveyId", surveyId) : new ObjectParameter("SurveyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSurveyQuestions_Result>("MobspSelectSurveyQuestions", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSurveyAnswerCategoryDetails_Result> MobspSelectSurveyAnswerCategoryDetails(int? answerCategoryId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (answerCategoryId.HasValue ? new ObjectParameter("AnswerCategoryId", answerCategoryId) : new ObjectParameter("AnswerCategoryId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSurveyAnswerCategoryDetails_Result>("MobspSelectSurveyAnswerCategoryDetails", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectVerifiedPreOrdersByCmpId_Result> MobspSelectVerifiedPreOrdersByCmpId(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerifiedPreOrdersByCmpId_Result>("MobspSelectVerifiedPreOrdersByCmpId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectSurveyHistory_Result> MobspSelectSurveyHistory(int? cmpId, int? systemPartId, int? systemPartObjId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cmpId.HasValue ? new ObjectParameter("CmpId", cmpId) : new ObjectParameter("CmpId", typeof(int)));
		ObjectParameter objectParameter2 = (systemPartId.HasValue ? new ObjectParameter("SystemPartId", systemPartId) : new ObjectParameter("SystemPartId", typeof(int)));
		ObjectParameter objectParameter3 = (systemPartObjId.HasValue ? new ObjectParameter("SystemPartObjId", systemPartObjId) : new ObjectParameter("SystemPartObjId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSurveyHistory_Result>("MobspSelectSurveyHistory", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectOrdersByCmpId_Result> MobspSelectOrdersByCmpId(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrdersByCmpId_Result>("MobspSelectOrdersByCmpId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual int MobspUpdateSurveyHistoryRepliedDate(int? surveyHistoryId, DateTime? date, string datePersian)
	{
		ObjectParameter objectParameter = (surveyHistoryId.HasValue ? new ObjectParameter("SurveyHistoryId", surveyHistoryId) : new ObjectParameter("SurveyHistoryId", typeof(int)));
		ObjectParameter objectParameter2 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((datePersian != null) ? new ObjectParameter("DatePersian", datePersian) : new ObjectParameter("DatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateSurveyHistoryRepliedDate", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual ObjectResult<MobspReturnDailyCIRecordVoiceInformation_Result> MobspReturnDailyCIRecordVoiceInformation(DateTime? fDate, DateTime? tDate, string callDate, string callTypeId, string lineNumber, string userId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID, int? pageNumber, string extensionNumber, int? conversasionStatus, long? fCallLength, long? tCallLength, bool? orderByCmp, int? pageSize, int? pageFirstId, int? pageLastId, string selectedUserIds, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((callDate != null) ? new ObjectParameter("CallDate", callDate) : new ObjectParameter("CallDate", typeof(string)));
		ObjectParameter objectParameter4 = ((callTypeId != null) ? new ObjectParameter("CallTypeId", callTypeId) : new ObjectParameter("CallTypeId", typeof(string)));
		ObjectParameter objectParameter5 = ((lineNumber != null) ? new ObjectParameter("LineNumber", lineNumber) : new ObjectParameter("LineNumber", typeof(string)));
		ObjectParameter objectParameter6 = ((userId != null) ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(string)));
		ObjectParameter objectParameter7 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter8 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter12 = ((extensionNumber != null) ? new ObjectParameter("ExtensionNumber", extensionNumber) : new ObjectParameter("ExtensionNumber", typeof(string)));
		ObjectParameter objectParameter13 = (conversasionStatus.HasValue ? new ObjectParameter("ConversasionStatus", conversasionStatus) : new ObjectParameter("ConversasionStatus", typeof(int)));
		ObjectParameter objectParameter14 = (fCallLength.HasValue ? new ObjectParameter("FCallLength", fCallLength) : new ObjectParameter("FCallLength", typeof(long)));
		ObjectParameter objectParameter15 = (tCallLength.HasValue ? new ObjectParameter("TCallLength", tCallLength) : new ObjectParameter("TCallLength", typeof(long)));
		ObjectParameter objectParameter16 = (orderByCmp.HasValue ? new ObjectParameter("OrderByCmp", orderByCmp) : new ObjectParameter("OrderByCmp", typeof(bool)));
		ObjectParameter objectParameter17 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter18 = (pageFirstId.HasValue ? new ObjectParameter("PageFirstId", pageFirstId) : new ObjectParameter("PageFirstId", typeof(int)));
		ObjectParameter objectParameter19 = (pageLastId.HasValue ? new ObjectParameter("PageLastId", pageLastId) : new ObjectParameter("PageLastId", typeof(int)));
		ObjectParameter objectParameter20 = ((selectedUserIds != null) ? new ObjectParameter("SelectedUserIds", selectedUserIds) : new ObjectParameter("SelectedUserIds", typeof(string)));
		ObjectParameter objectParameter21 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDailyCIRecordVoiceInformation_Result>("MobspReturnDailyCIRecordVoiceInformation", new ObjectParameter[21]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21
		});
	}

	public virtual ObjectResult<MobspReturnCmpAccountingDetails_Result> MobspReturnCmpAccountingDetails(int? companyId, int? languageID, int? defaultLanguageID, string orderTitle, string paymentTitle, string wastedTitle, string buyOrderTitle, string preOrderTitle, string saleOrderTitle, DateTime? fDateTime, DateTime? tDateTime, int? rptUserId, string rptDate, string rptDay, int? pageNumber, int? pageSize, int? cmpPerosnId)
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
		ObjectParameter objectParameter15 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter16 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter17 = (cmpPerosnId.HasValue ? new ObjectParameter("CmpPerosnId", cmpPerosnId) : new ObjectParameter("CmpPerosnId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnCmpAccountingDetails_Result>("MobspReturnCmpAccountingDetails", new ObjectParameter[17]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17
		});
	}

	public virtual ObjectResult<MobspSelectProductWithPrice_Result> MobspSelectProductWithPrice(string val, int? prdPriceGroupId, int? prdKind, int? showMode, int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (prdPriceGroupId.HasValue ? new ObjectParameter("PrdPriceGroupId", prdPriceGroupId) : new ObjectParameter("PrdPriceGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter4 = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter5 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter6 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductWithPrice_Result>("MobspSelectProductWithPrice", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspSelectActiveProducts_Result> MobspSelectActiveProducts(int? prdKind, int? showMode, int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter2 = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveProducts_Result>("MobspSelectActiveProducts", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectCompanyConversationsByProject_Result> MobspSelectCompanyConversationsByProject(int? projectId, int? userId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyConversationsByProject_Result>("MobspSelectCompanyConversationsByProject", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectProductPicture_Result> MobspSelectProductPicture(int? productId, int? prdGroupId, int? prdFirstGroupId, int? prdKind, int? showMode, int? companyId, int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (productId.HasValue ? new ObjectParameter("ProductId", productId) : new ObjectParameter("ProductId", typeof(int)));
		ObjectParameter objectParameter2 = (prdGroupId.HasValue ? new ObjectParameter("PrdGroupId", prdGroupId) : new ObjectParameter("PrdGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (prdFirstGroupId.HasValue ? new ObjectParameter("PrdFirstGroupId", prdFirstGroupId) : new ObjectParameter("PrdFirstGroupId", typeof(int)));
		ObjectParameter objectParameter4 = (prdKind.HasValue ? new ObjectParameter("PrdKind", prdKind) : new ObjectParameter("PrdKind", typeof(int)));
		ObjectParameter objectParameter5 = (showMode.HasValue ? new ObjectParameter("ShowMode", showMode) : new ObjectParameter("ShowMode", typeof(int)));
		ObjectParameter objectParameter6 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter7 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductPicture_Result>("MobspSelectProductPicture", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspSelectCompanyAddressesLatLong_Result> MobspSelectCompanyAddressesLatLong(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyAddressesLatLong_Result>("MobspSelectCompanyAddressesLatLong", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspSelectMobPreOrderCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspSelectMobPreOrderCnt", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspCmsSelectGallery_Result> MobspCmsSelectGallery(int? galleryId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (galleryId.HasValue ? new ObjectParameter("GalleryId", galleryId) : new ObjectParameter("GalleryId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCmsSelectGallery_Result>("MobspCmsSelectGallery", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspCmsSelectGalleryItems_Result> MobspCmsSelectGalleryItems(int? galleryId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (galleryId.HasValue ? new ObjectParameter("GalleryId", galleryId) : new ObjectParameter("GalleryId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCmsSelectGalleryItems_Result>("MobspCmsSelectGalleryItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspIntMsgGetCmpReferMessageCnt(int? toUserId, int? companyId)
	{
		ObjectParameter objectParameter = (toUserId.HasValue ? new ObjectParameter("ToUserId", toUserId) : new ObjectParameter("ToUserId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspIntMsgGetCmpReferMessageCnt", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspIntMsgGetCmpVerifyMessageCnt(int? toUserId, int? companyId)
	{
		ObjectParameter objectParameter = (toUserId.HasValue ? new ObjectParameter("ToUserId", toUserId) : new ObjectParameter("ToUserId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspIntMsgGetCmpVerifyMessageCnt", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspCmsSelectNewsPicture_Result> MobspCmsSelectNewsPicture(int? fileDirectoryId, int? fileDirectoryTypeId, int? newsId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		ObjectParameter objectParameter2 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (newsId.HasValue ? new ObjectParameter("NewsId", newsId) : new ObjectParameter("NewsId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCmsSelectNewsPicture_Result>("MobspCmsSelectNewsPicture", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectNewsFilesDirectory_Result> MobspSelectNewsFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((masterId != null) ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(string)));
		ObjectParameter objectParameter2 = ((detailId != null) ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(string)));
		ObjectParameter objectParameter3 = ((subDetailId != null) ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(string)));
		ObjectParameter objectParameter4 = ((fileDirectoryTypeOprId != null) ? new ObjectParameter("FileDirectoryTypeOprId", fileDirectoryTypeOprId) : new ObjectParameter("FileDirectoryTypeOprId", typeof(string)));
		ObjectParameter objectParameter5 = ((typeOprObjectId != null) ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectNewsFilesDirectory_Result>("MobspSelectNewsFilesDirectory", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectCmsNews_Result> MobspSelectCmsNews(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCmsNews_Result>("MobspSelectCmsNews", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectSmsVerificationFoSetting_Result> MobspSelectSmsVerificationFoSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsVerificationFoSetting_Result>("MobspSelectSmsVerificationFoSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectUserBaseInfoLastUpdate_Result> MobspSelectUserBaseInfoLastUpdate(int? userId, string imeiCode, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserBaseInfoLastUpdate_Result>("MobspSelectUserBaseInfoLastUpdate", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectParsServiceAppSetting_Result> MobspSelectParsServiceAppSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectParsServiceAppSetting_Result>("MobspSelectParsServiceAppSetting", Array.Empty<ObjectParameter>());
	}

	public virtual int MobspUpdatePreOrderExpireDate(int? preOrderId, string pordExpireDate, DateTime? pordExpireDateTime, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((pordExpireDate != null) ? new ObjectParameter("PordExpireDate", pordExpireDate) : new ObjectParameter("PordExpireDate", typeof(string)));
		ObjectParameter objectParameter3 = (pordExpireDateTime.HasValue ? new ObjectParameter("PordExpireDateTime", pordExpireDateTime) : new ObjectParameter("PordExpireDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdatePreOrderExpireDate", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<MobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result> MobspSelectVerifiedPreOrdersWithoutOrderByCmpId(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerifiedPreOrdersWithoutOrderByCmpId_Result>("MobspSelectVerifiedPreOrdersWithoutOrderByCmpId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspIntMsgSelectCmpReferMessage_Result> MobspIntMsgSelectCmpReferMessage(int? cmpId, int? toUserId, int? pageNumber, int? pageSize, bool? isRead, int? languageID, int? defaultLanguageID, int? cmpPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (cmpId.HasValue ? new ObjectParameter("CmpId", cmpId) : new ObjectParameter("CmpId", typeof(int)));
		ObjectParameter objectParameter2 = (toUserId.HasValue ? new ObjectParameter("ToUserId", toUserId) : new ObjectParameter("ToUserId", typeof(int)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (isRead.HasValue ? new ObjectParameter("IsRead", isRead) : new ObjectParameter("IsRead", typeof(bool)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (cmpPersonId.HasValue ? new ObjectParameter("CmpPersonId", cmpPersonId) : new ObjectParameter("CmpPersonId", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgSelectCmpReferMessage_Result>("MobspIntMsgSelectCmpReferMessage", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspIntMsgSelectCmpVerifyMessage_Result> MobspIntMsgSelectCmpVerifyMessage(int? cmpId, int? toUserId, int? pageNumber, int? pageSize, bool? isRead, int? languageID, int? defaultLanguageID, int? cmpPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (cmpId.HasValue ? new ObjectParameter("CmpId", cmpId) : new ObjectParameter("CmpId", typeof(int)));
		ObjectParameter objectParameter2 = (toUserId.HasValue ? new ObjectParameter("ToUserId", toUserId) : new ObjectParameter("ToUserId", typeof(int)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (isRead.HasValue ? new ObjectParameter("IsRead", isRead) : new ObjectParameter("IsRead", typeof(bool)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (cmpPersonId.HasValue ? new ObjectParameter("CmpPersonId", cmpPersonId) : new ObjectParameter("CmpPersonId", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgSelectCmpVerifyMessage_Result>("MobspIntMsgSelectCmpVerifyMessage", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<WSspRpt_PrintOrderItemSerials_Result> WSspRpt_PrintOrderItemSerials(int? orderItemID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderItemID.HasValue ? new ObjectParameter("OrderItemID", orderItemID) : new ObjectParameter("OrderItemID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintOrderItemSerials_Result>("WSspRpt_PrintOrderItemSerials", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintOrderPayments_Result> WSspRpt_PrintOrderPayments(int? orderID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderID.HasValue ? new ObjectParameter("OrderID", orderID) : new ObjectParameter("OrderID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintOrderPayments_Result>("WSspRpt_PrintOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspDyPrintOrdForm_Result> CRMspDyPrintOrdForm(int? orderId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintOrdForm_Result>("CRMspDyPrintOrdForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<CRMspReturnCmpAccountingSummary_Result> CRMspReturnCmpAccountingSummary(int? companyId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspReturnCmpAccountingSummary_Result>("CRMspReturnCmpAccountingSummary", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspReturnCurrencyUnitRate_Result> MobspReturnCurrencyUnitRate(int? srcCurrencyUnitId, int? destCurrencyUnitId)
	{
		ObjectParameter objectParameter = (srcCurrencyUnitId.HasValue ? new ObjectParameter("SrcCurrencyUnitId", srcCurrencyUnitId) : new ObjectParameter("SrcCurrencyUnitId", typeof(int)));
		ObjectParameter objectParameter2 = (destCurrencyUnitId.HasValue ? new ObjectParameter("DestCurrencyUnitId", destCurrencyUnitId) : new ObjectParameter("DestCurrencyUnitId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnCurrencyUnitRate_Result>("MobspReturnCurrencyUnitRate", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectExpiredPreOrders_Result> MobspSelectExpiredPreOrders(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectExpiredPreOrders_Result>("MobspSelectExpiredPreOrders", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectNotVerifiedPreOrdersByCmpId_Result> MobspSelectNotVerifiedPreOrdersByCmpId(int? companyId, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectNotVerifiedPreOrdersByCmpId_Result>("MobspSelectNotVerifiedPreOrdersByCmpId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectInternalMessageDetailsById_Result> MobspSelectInternalMessageDetailsById(int? messageDetailID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (messageDetailID.HasValue ? new ObjectParameter("MessageDetailID", messageDetailID) : new ObjectParameter("MessageDetailID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectInternalMessageDetailsById_Result>("MobspSelectInternalMessageDetailsById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintOrderDoc_Result> WSspRpt_PrintOrderDoc(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintOrderDoc_Result>("WSspRpt_PrintOrderDoc", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintVerificationRequestDetails_Result> WSspRpt_PrintVerificationRequestDetails(int? objectId, int? objectType, int? verificationWorkFlowId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter3 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintVerificationRequestDetails_Result>("WSspRpt_PrintVerificationRequestDetails", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspIntMsgGetByTypeAndAttachRecId_Result> MobspIntMsgGetByTypeAndAttachRecId(int? userId, int? msgdTypeId, int? msgdAttachRecId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (msgdAttachRecId.HasValue ? new ObjectParameter("MsgdAttachRecId", msgdAttachRecId) : new ObjectParameter("MsgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgGetByTypeAndAttachRecId_Result>("MobspIntMsgGetByTypeAndAttachRecId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspIntMsgGetOrSendByTypeAndAttachRecId_Result> MobspIntMsgGetOrSendByTypeAndAttachRecId(int? userId, int? msgdTypeId, int? msgdAttachRecId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (msgdAttachRecId.HasValue ? new ObjectParameter("MsgdAttachRecId", msgdAttachRecId) : new ObjectParameter("MsgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgGetOrSendByTypeAndAttachRecId_Result>("MobspIntMsgGetOrSendByTypeAndAttachRecId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectOrderStatus_Result> MobspSelectOrderStatus(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderStatus_Result>("MobspSelectOrderStatus", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPreOrderStatus_Result> MobspSelectPreOrderStatus(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderStatus_Result>("MobspSelectPreOrderStatus", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectOrderVerifiers_Result> MobspSelectOrderVerifiers(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderVerifiers_Result>("MobspSelectOrderVerifiers", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSaleCenters_Result> MobspSelectSaleCenters(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSaleCenters_Result>("MobspSelectSaleCenters", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspInsertQuickOrderPayment(string orderPayment, DateTime? registerDate, string registerDatePersian, int? userId, short? month1, int? fPId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter insertedOrdPaymentId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((orderPayment != null) ? new ObjectParameter("OrderPayment", orderPayment) : new ObjectParameter("OrderPayment", typeof(string)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickOrderPayment", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, insertedOrdPaymentId,
			errorMessage, objectParameter10
		});
	}

	public virtual ObjectResult<int?> MobspUpdateOrder(int? orderId, string order, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, int? fPId, string appType, int? languageID, int? defaultLanguageID, ObjectParameter updatedOrderId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((order != null) ? new ObjectParameter("Order", order) : new ObjectParameter("Order", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateOrder", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			updatedOrderId, errorMessage, objectParameter11
		});
	}

	public virtual ObjectResult<int?> MobspUpdateOrderItem(int? orderItemId, string orderItem, int? userId, short? month1, int? fPId, string appType, DateTime? registerDate, string registerDatePersian, int? languageID, int? defaultLanguageID, bool? actCanNotSelectWithNoStock, ObjectParameter updatedOrdItemId, ObjectParameter errorMessage, bool? dontCheckQuantity, bool? actCanNotSelectWithNoReserveStock, bool? actCanNotSelectWithNoSoldStock)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = ((orderItem != null) ? new ObjectParameter("OrderItem", orderItem) : new ObjectParameter("OrderItem", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (actCanNotSelectWithNoStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoStock", actCanNotSelectWithNoStock) : new ObjectParameter("ActCanNotSelectWithNoStock", typeof(bool)));
		ObjectParameter objectParameter12 = (dontCheckQuantity.HasValue ? new ObjectParameter("DontCheckQuantity", dontCheckQuantity) : new ObjectParameter("DontCheckQuantity", typeof(bool)));
		ObjectParameter objectParameter13 = (actCanNotSelectWithNoReserveStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoReserveStock", actCanNotSelectWithNoReserveStock) : new ObjectParameter("ActCanNotSelectWithNoReserveStock", typeof(bool)));
		ObjectParameter objectParameter14 = (actCanNotSelectWithNoSoldStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoSoldStock", actCanNotSelectWithNoSoldStock) : new ObjectParameter("ActCanNotSelectWithNoSoldStock", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateOrderItem", new ObjectParameter[16]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, updatedOrdItemId, errorMessage, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual ObjectResult<int?> MobspUpdateOrderPayment(int? orderPaymentId, string orderPayment, int? userId, short? month1, int? fPId, string appType, DateTime? registerDate, string registerDatePersian, int? languageID, int? defaultLanguageID, ObjectParameter updatedOrdPaymentId, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		ObjectParameter objectParameter2 = ((orderPayment != null) ? new ObjectParameter("OrderPayment", orderPayment) : new ObjectParameter("OrderPayment", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateOrderPayment", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			updatedOrdPaymentId, errorMessage
		});
	}

	public virtual ObjectResult<int?> MobspInsertOrderFull(string order, string ordItemList, string ordPaymentList, int? userId, short? year1, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, bool? actCanNotSelectWithNoStock, ObjectParameter insertedOrderId, ObjectParameter insertedOrdItemIds, ObjectParameter insertedOrdPaymentIds, ObjectParameter errorMessage, int? centerId, string orderItemSerial, bool? dontCheckQuantity, bool? actCanNotSelectWithNoReserveStock, bool? actCanNotSelectWithNoSoldStock)
	{
		ObjectParameter objectParameter = ((order != null) ? new ObjectParameter("Order", order) : new ObjectParameter("Order", typeof(string)));
		ObjectParameter objectParameter2 = ((ordItemList != null) ? new ObjectParameter("OrdItemList", ordItemList) : new ObjectParameter("OrdItemList", typeof(string)));
		ObjectParameter objectParameter3 = ((ordPaymentList != null) ? new ObjectParameter("OrdPaymentList", ordPaymentList) : new ObjectParameter("OrdPaymentList", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (actCanNotSelectWithNoStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoStock", actCanNotSelectWithNoStock) : new ObjectParameter("ActCanNotSelectWithNoStock", typeof(bool)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter15 = ((orderItemSerial != null) ? new ObjectParameter("OrderItemSerial", orderItemSerial) : new ObjectParameter("OrderItemSerial", typeof(string)));
		ObjectParameter objectParameter16 = (dontCheckQuantity.HasValue ? new ObjectParameter("DontCheckQuantity", dontCheckQuantity) : new ObjectParameter("DontCheckQuantity", typeof(bool)));
		ObjectParameter objectParameter17 = (actCanNotSelectWithNoReserveStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoReserveStock", actCanNotSelectWithNoReserveStock) : new ObjectParameter("ActCanNotSelectWithNoReserveStock", typeof(bool)));
		ObjectParameter objectParameter18 = (actCanNotSelectWithNoSoldStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoSoldStock", actCanNotSelectWithNoSoldStock) : new ObjectParameter("ActCanNotSelectWithNoSoldStock", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertOrderFull", new ObjectParameter[22]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, insertedOrderId, insertedOrdItemIds, insertedOrdPaymentIds, errorMessage, objectParameter14, objectParameter15, objectParameter16,
			objectParameter17, objectParameter18
		});
	}

	[EdmFunction("CRMEntities", "MobfnReturnOrderSumFooter")]
	public virtual IQueryable<MobfnReturnOrderSumFooter_Result> MobfnReturnOrderSumFooter(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<MobfnReturnOrderSumFooter_Result>("[CRMEntities].[MobfnReturnOrderSumFooter](@OrderId)", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnDocForSaleOrder_Result> MobspReturnDocForSaleOrder(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocForSaleOrder_Result>("MobspReturnDocForSaleOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnSumOrderPay_Result> MobspReturnSumOrderPay(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnSumOrderPay_Result>("MobspReturnSumOrderPay", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectOrderItemSerialsByOrderItemId_Result> MobspSelectOrderItemSerialsByOrderItemId(int? orderItemId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderItemSerialsByOrderItemId_Result>("MobspSelectOrderItemSerialsByOrderItemId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result> MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate(int? companyId, DateTime? expireDate, int? pageNumber, int? pageSize, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (expireDate.HasValue ? new ObjectParameter("ExpireDate", expireDate) : new ObjectParameter("ExpireDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate_Result>("MobspSelectNotVerifiedPreOrdersByCmpIdAndExpireDate", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<int?> MobspDeleteWSOrder(int? orderId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteWSOrder", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteWSOrderItems(int? orderItemId)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteWSOrderItems", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteWSOrderPayments(int? orderPaymentId)
	{
		ObjectParameter objectParameter = (orderPaymentId.HasValue ? new ObjectParameter("OrderPaymentId", orderPaymentId) : new ObjectParameter("OrderPaymentId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteWSOrderPayments", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspInsertQuickOrderItem(string orderItemList, DateTime? registerDate, string registerDatePersian, int? userId, short? month1, int? fPId, string appType, int? languageID, int? defaultLanguageID, bool? actCanNotSelectWithNoStock, bool? addLinkedProducts, ObjectParameter insertedOrdItemId, ObjectParameter errorMessage, int? centerId, bool? dontCheckQuantity, bool? actCanNotSelectWithNoReserveStock, bool? actCanNotSelectWithNoSoldStock)
	{
		ObjectParameter objectParameter = ((orderItemList != null) ? new ObjectParameter("OrderItemList", orderItemList) : new ObjectParameter("OrderItemList", typeof(string)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (actCanNotSelectWithNoStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoStock", actCanNotSelectWithNoStock) : new ObjectParameter("ActCanNotSelectWithNoStock", typeof(bool)));
		ObjectParameter objectParameter11 = (addLinkedProducts.HasValue ? new ObjectParameter("AddLinkedProducts", addLinkedProducts) : new ObjectParameter("AddLinkedProducts", typeof(bool)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter13 = (dontCheckQuantity.HasValue ? new ObjectParameter("DontCheckQuantity", dontCheckQuantity) : new ObjectParameter("DontCheckQuantity", typeof(bool)));
		ObjectParameter objectParameter14 = (actCanNotSelectWithNoReserveStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoReserveStock", actCanNotSelectWithNoReserveStock) : new ObjectParameter("ActCanNotSelectWithNoReserveStock", typeof(bool)));
		ObjectParameter objectParameter15 = (actCanNotSelectWithNoSoldStock.HasValue ? new ObjectParameter("ActCanNotSelectWithNoSoldStock", actCanNotSelectWithNoSoldStock) : new ObjectParameter("ActCanNotSelectWithNoSoldStock", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickOrderItem", new ObjectParameter[17]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, insertedOrdItemId, errorMessage, objectParameter12, objectParameter13, objectParameter14, objectParameter15
		});
	}

	public virtual ObjectResult<int?> MobspSelectMobOrderCnt(int? centerId)
	{
		ObjectParameter objectParameter = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspSelectMobOrderCnt", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result> MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId(int? cmpProjectId)
	{
		ObjectParameter objectParameter = (cmpProjectId.HasValue ? new ObjectParameter("cmpProjectId", cmpProjectId) : new ObjectParameter("cmpProjectId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId_Result>("MobspCheckPrdGroupMustExistInPreOrderBycmpPrjId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectCrmProjectBycmpAndUser_Result> MobspSelectCrmProjectBycmpAndUser(int? companyId, int? userID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCrmProjectBycmpAndUser_Result>("MobspSelectCrmProjectBycmpAndUser", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspIntMsgUserTreeInternalMessageCartable_Result> MobspIntMsgUserTreeInternalMessageCartable(int? userId, int? linkedType, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgUserTreeInternalMessageCartable_Result>("MobspIntMsgUserTreeInternalMessageCartable", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspIntMsgSelectMessageInType_Result> MobspIntMsgSelectMessageInType(int? messageId, int? userId, int? typeId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (messageId.HasValue ? new ObjectParameter("MessageId", messageId) : new ObjectParameter("MessageId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (typeId.HasValue ? new ObjectParameter("TypeId", typeId) : new ObjectParameter("TypeId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgSelectMessageInType_Result>("MobspIntMsgSelectMessageInType", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectSmsDefaultBodyText_Result> MobspSelectSmsDefaultBodyText(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsDefaultBodyText_Result>("MobspSelectSmsDefaultBodyText", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectSmsDefaultBodyTextGroups_Result> MobspSelectSmsDefaultBodyTextGroups(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsDefaultBodyTextGroups_Result>("MobspSelectSmsDefaultBodyTextGroups", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectGSMModemSetting_Result> MobspSelectGSMModemSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectGSMModemSetting_Result>("MobspSelectGSMModemSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectActiveWareHouse_Result> MobspSelectActiveWareHouse(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveWareHouse_Result>("MobspSelectActiveWareHouse", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectPreOrdersInMode_Result> MobspSelectPreOrdersInMode(int? userId, int? companyId, long? pordNumber, DateTime? fDateTime, DateTime? tDateTime, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (pordNumber.HasValue ? new ObjectParameter("PordNumber", pordNumber) : new ObjectParameter("PordNumber", typeof(long)));
		ObjectParameter objectParameter4 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrdersInMode_Result>("MobspSelectPreOrdersInMode", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspSelectOrdersInMode_Result> MobspSelectOrdersInMode(int? userId, int? companyId, long? ordNumber, DateTime? fDateTime, DateTime? tDateTime, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (ordNumber.HasValue ? new ObjectParameter("ordNumber", ordNumber) : new ObjectParameter("ordNumber", typeof(long)));
		ObjectParameter objectParameter4 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrdersInMode_Result>("MobspSelectOrdersInMode", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspUserTreeLocationCartable_Result> MobspUserTreeLocationCartable(int? userId, int? linkedType, string allUserText, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = ((allUserText != null) ? new ObjectParameter("AllUserText", allUserText) : new ObjectParameter("AllUserText", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUserTreeLocationCartable_Result>("MobspUserTreeLocationCartable", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectLetterWithID_Result> MobspSelectLetterWithID(int? letterId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLetterWithID_Result>("MobspSelectLetterWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspDyPrintSecLetterForm_Result> CRMspDyPrintSecLetterForm(int? letterId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintSecLetterForm_Result>("CRMspDyPrintSecLetterForm", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<SecspRpt_PrintSendLetter_Result> SecspRpt_PrintSendLetter(int? letterID, int? userId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (letterID.HasValue ? new ObjectParameter("LetterID", letterID) : new ObjectParameter("LetterID", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter4 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SecspRpt_PrintSendLetter_Result>("SecspRpt_PrintSendLetter", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspReturnCallTypeCount_Result> MobspReturnCallTypeCount(DateTime? fDate, DateTime? tDate, int? languageID, int? defaultLanguageID, int? currUserId, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (currUserId.HasValue ? new ObjectParameter("CurrUserId", currUserId) : new ObjectParameter("CurrUserId", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnCallTypeCount_Result>("MobspReturnCallTypeCount", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int MobspUpdateConversationRemindOk(int? cnvsId, int? userId, string registerDatePersian, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = (cnvsId.HasValue ? new ObjectParameter("CnvsId", cnvsId) : new ObjectParameter("CnvsId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateConversationRemindOk", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual int MobspUpdateConversationNotRemindOk(int? cnvsId, int? userId, string registerDatePersian, DateTime? registerDate, string appType)
	{
		ObjectParameter objectParameter = (cnvsId.HasValue ? new ObjectParameter("CnvsId", cnvsId) : new ObjectParameter("CnvsId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateConversationNotRemindOk", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<MobspChartDailyOrders_Result> MobspChartDailyOrders(DateTime? fDate, DateTime? tDate, int? userID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspChartDailyOrders_Result>("MobspChartDailyOrders", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspChartDailyPreOrders_Result> MobspChartDailyPreOrders(DateTime? fDate, DateTime? tDate, int? userID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspChartDailyPreOrders_Result>("MobspChartDailyPreOrders", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspChartMonthlyOrders_Result> MobspChartMonthlyOrders(DateTime? fDate, DateTime? tDate, int? userID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspChartMonthlyOrders_Result>("MobspChartMonthlyOrders", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspChartUserAccess_Result> MobspChartUserAccess(int? userID)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspChartUserAccess_Result>("MobspChartUserAccess", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectCallHistoryWithoutCnvsByCmpId_Result> MobspSelectCallHistoryWithoutCnvsByCmpId(DateTime? fDate, DateTime? tDate, int? companyId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCallHistoryWithoutCnvsByCmpId_Result>("MobspSelectCallHistoryWithoutCnvsByCmpId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectConversationCallHistory_Result> MobspSelectConversationCallHistory(int? conversationId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationCallHistory_Result>("MobspSelectConversationCallHistory", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectUserFavproductItemsWithPriceByUserId_Result> MobspSelectUserFavproductItemsWithPriceByUserId(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserFavproductItemsWithPriceByUserId_Result>("MobspSelectUserFavproductItemsWithPriceByUserId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectMobSetting_Result> MobspSelectMobSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectMobSetting_Result>("MobspSelectMobSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectFilesDirectory_Result> MobspSelectFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, int? languageID, int? defaultLanguageID, bool? isShowAllCmpFile, int? centerId)
	{
		ObjectParameter objectParameter = ((masterId != null) ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(string)));
		ObjectParameter objectParameter2 = ((detailId != null) ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(string)));
		ObjectParameter objectParameter3 = ((subDetailId != null) ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(string)));
		ObjectParameter objectParameter4 = ((fileDirectoryTypeOprId != null) ? new ObjectParameter("FileDirectoryTypeOprId", fileDirectoryTypeOprId) : new ObjectParameter("FileDirectoryTypeOprId", typeof(string)));
		ObjectParameter objectParameter5 = ((typeOprObjectId != null) ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (isShowAllCmpFile.HasValue ? new ObjectParameter("IsShowAllCmpFile", isShowAllCmpFile) : new ObjectParameter("IsShowAllCmpFile", typeof(bool)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectFilesDirectory_Result>("MobspSelectFilesDirectory", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspResultsStatusCartable_Result> MobspResultsStatusCartable(int? userID, int? cnvsReferUserId, int? cnvsStatusId, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize, int? centerId)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (cnvsReferUserId.HasValue ? new ObjectParameter("cnvsReferUserId", cnvsReferUserId) : new ObjectParameter("cnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (cnvsStatusId.HasValue ? new ObjectParameter("cnvsStatusId", cnvsStatusId) : new ObjectParameter("cnvsStatusId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsStatusCartable_Result>("MobspResultsStatusCartable", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspCheckRegisterCode_Result> MobspCheckRegisterCode(string registerCode, string extraCode, string imeiCode, int? devTypeId, string currentVersion)
	{
		ObjectParameter objectParameter = ((registerCode != null) ? new ObjectParameter("RegisterCode", registerCode) : new ObjectParameter("RegisterCode", typeof(string)));
		ObjectParameter objectParameter2 = ((extraCode != null) ? new ObjectParameter("ExtraCode", extraCode) : new ObjectParameter("ExtraCode", typeof(string)));
		ObjectParameter objectParameter3 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter4 = (devTypeId.HasValue ? new ObjectParameter("DevTypeId", devTypeId) : new ObjectParameter("DevTypeId", typeof(int)));
		ObjectParameter objectParameter5 = ((currentVersion != null) ? new ObjectParameter("CurrentVersion", currentVersion) : new ObjectParameter("CurrentVersion", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckRegisterCode_Result>("MobspCheckRegisterCode", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int MobspInternalMessageLoadReceiverWithoutLink(int? crmUserId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInternalMessageLoadReceiverWithoutLink", objectParameter);
	}

	public virtual ObjectResult<MobspSelectLinkedProducts_Result> MobspSelectLinkedProducts(int? languageID, int? defaultLanguageID, int? lastPrdLinkId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (lastPrdLinkId.HasValue ? new ObjectParameter("LastPrdLinkId", lastPrdLinkId) : new ObjectParameter("LastPrdLinkId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLinkedProducts_Result>("MobspSelectLinkedProducts", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectUserFavproductItemsByUserId_Result> MobspSelectUserFavproductItemsByUserId(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserFavproductItemsByUserId_Result>("MobspSelectUserFavproductItemsByUserId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateProjectIsTicketNew(int? projectID, bool? isTicketNew)
	{
		ObjectParameter objectParameter = (projectID.HasValue ? new ObjectParameter("ProjectID", projectID) : new ObjectParameter("ProjectID", typeof(int)));
		ObjectParameter objectParameter2 = (isTicketNew.HasValue ? new ObjectParameter("IsTicketNew", isTicketNew) : new ObjectParameter("IsTicketNew", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateProjectIsTicketNew", objectParameter, objectParameter2);
	}

	public virtual ObjectResult<MobspSelectHomePageSetting_Result> MobspSelectHomePageSetting(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectHomePageSetting_Result>("MobspSelectHomePageSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspUpdateConversationForRefer(int? conversatonId, int? cnvsReferUserId, int? cnvsUserId, string cnvsReferDesc, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (conversatonId.HasValue ? new ObjectParameter("ConversatonId", conversatonId) : new ObjectParameter("ConversatonId", typeof(int)));
		ObjectParameter objectParameter2 = (cnvsReferUserId.HasValue ? new ObjectParameter("cnvsReferUserId", cnvsReferUserId) : new ObjectParameter("cnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter3 = (cnvsUserId.HasValue ? new ObjectParameter("cnvsUserId", cnvsUserId) : new ObjectParameter("cnvsUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((cnvsReferDesc != null) ? new ObjectParameter("cnvsReferDesc", cnvsReferDesc) : new ObjectParameter("cnvsReferDesc", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateConversationForRefer", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual int MobspCloseTicket(int? projectId, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? centerId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCloseTicket", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<string> MobspSelectTicketsProjectTitleGroups(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MobspSelectTicketsProjectTitleGroups", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspCalculateProjectToDoTimes_Result> MobspCalculateProjectToDoTimes(int? projectId, DateTime? currDateTime)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (currDateTime.HasValue ? new ObjectParameter("CurrDateTime", currDateTime) : new ObjectParameter("CurrDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCalculateProjectToDoTimes_Result>("MobspCalculateProjectToDoTimes", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectTicketConversationHistoryWithProjectId_Result> MobspSelectTicketConversationHistoryWithProjectId(int? projectId, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTicketConversationHistoryWithProjectId_Result>("MobspSelectTicketConversationHistoryWithProjectId", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectProjectUserDepartments_Result> MobspSelectProjectUserDepartments(int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectUserDepartments_Result>("MobspSelectProjectUserDepartments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSearchProjectTitleGroup_Result> MobspSearchProjectTitleGroup(string val, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSearchProjectTitleGroup_Result>("MobspSearchProjectTitleGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspCheckDuplicateCmpEmail_Result> CRMspCheckDuplicateCmpEmail(string cmpEmail, int? currId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((cmpEmail != null) ? new ObjectParameter("CmpEmail", cmpEmail) : new ObjectParameter("CmpEmail", typeof(string)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspCheckDuplicateCmpEmail_Result>("CRMspCheckDuplicateCmpEmail", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<CRMspCheckDuplicateCmpMobile_Result> CRMspCheckDuplicateCmpMobile(string cmpMobile, int? currId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((cmpMobile != null) ? new ObjectParameter("CmpMobile", cmpMobile) : new ObjectParameter("CmpMobile", typeof(string)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspCheckDuplicateCmpMobile_Result>("CRMspCheckDuplicateCmpMobile", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> MobspCopyCompanyPersonDataToCmp(int? companyId, int? companyPesronId, int? userId, DateTime? registerDate, string registerDatePersian, short? month1, short? year1, string appType)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPesronId.HasValue ? new ObjectParameter("CompanyPesronId", companyPesronId) : new ObjectParameter("CompanyPesronId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspCopyCompanyPersonDataToCmp", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<MobspCheckDuplicateCmpEmail_Result> MobspCheckDuplicateCmpEmail(string cmpEmail, int? currId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((cmpEmail != null) ? new ObjectParameter("CmpEmail", cmpEmail) : new ObjectParameter("CmpEmail", typeof(string)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicateCmpEmail_Result>("MobspCheckDuplicateCmpEmail", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> MobspGetUnReadTicket(int? companyId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspGetUnReadTicket", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspDeleteCompanyLogoByCmpId(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCompanyLogoByCmpId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeletePersonPictureByPrsId(int? personId)
	{
		ObjectParameter objectParameter = (personId.HasValue ? new ObjectParameter("PersonId", personId) : new ObjectParameter("PersonId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeletePersonPictureByPrsId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspDeleteCompanyAppDeviceInfo(string deviceId, int? deviceType)
	{
		ObjectParameter objectParameter = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter2 = (deviceType.HasValue ? new ObjectParameter("DeviceType", deviceType) : new ObjectParameter("DeviceType", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteCompanyAppDeviceInfo", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspInsertCompanyAppDeviceInfo(int? companyId, string deviceId, int? deviceType, DateTime? firstRegisterDate, string firstRegisterDatePersian)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((deviceId != null) ? new ObjectParameter("DeviceId", deviceId) : new ObjectParameter("DeviceId", typeof(string)));
		ObjectParameter objectParameter3 = (deviceType.HasValue ? new ObjectParameter("DeviceType", deviceType) : new ObjectParameter("DeviceType", typeof(int)));
		ObjectParameter objectParameter4 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertCompanyAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5);
	}

	public virtual ObjectResult<MobspSelectCompanyAppDeviceInfo_Result> MobspSelectCompanyAppDeviceInfo(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyAppDeviceInfo_Result>("MobspSelectCompanyAppDeviceInfo", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspUserTreeStatusCartable_Result> MobspUserTreeStatusCartable(int? userId, int? linkedType, string allUserText, string allStatusText, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = ((allUserText != null) ? new ObjectParameter("AllUserText", allUserText) : new ObjectParameter("AllUserText", typeof(string)));
		ObjectParameter objectParameter4 = ((allStatusText != null) ? new ObjectParameter("AllStatusText", allStatusText) : new ObjectParameter("AllStatusText", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUserTreeStatusCartable_Result>("MobspUserTreeStatusCartable", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectCompanyProjectTitle_Result> MobspSelectCompanyProjectTitle(string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyProjectTitle_Result>("MobspSelectCompanyProjectTitle", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspUserTreeTimeAttendanceCartable_Result> MobspUserTreeTimeAttendanceCartable(int? userId, int? linkedType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUserTreeTimeAttendanceCartable_Result>("MobspUserTreeTimeAttendanceCartable", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspUpdateProjectTitleGroup(int? projectId, string titleGroup, string titleGroupLangJs, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((titleGroup != null) ? new ObjectParameter("TitleGroup", titleGroup) : new ObjectParameter("TitleGroup", typeof(string)));
		ObjectParameter objectParameter3 = ((titleGroupLangJs != null) ? new ObjectParameter("TitleGroupLangJs", titleGroupLangJs) : new ObjectParameter("TitleGroupLangJs", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateProjectTitleGroup", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual ObjectResult<MobspResultsDailyCartable_Result> MobspResultsDailyCartable(DateTime? fDate, DateTime? tDate, int? userId, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize, int? cnvsUserId, bool? isShowTicket, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (cnvsUserId.HasValue ? new ObjectParameter("CnvsUserId", cnvsUserId) : new ObjectParameter("CnvsUserId", typeof(int)));
		ObjectParameter objectParameter9 = (isShowTicket.HasValue ? new ObjectParameter("IsShowTicket", isShowTicket) : new ObjectParameter("IsShowTicket", typeof(bool)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsDailyCartable_Result>("MobspResultsDailyCartable", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspUserTreeDailyCartable_Result> MobspUserTreeDailyCartable(int? userId, int? linkedType, DateTime? fDate, DateTime? tDate, string allUserText, int? languageID, int? defaultLanguageID, bool? isShowTicket, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((allUserText != null) ? new ObjectParameter("AllUserText", allUserText) : new ObjectParameter("AllUserText", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (isShowTicket.HasValue ? new ObjectParameter("IsShowTicket", isShowTicket) : new ObjectParameter("IsShowTicket", typeof(bool)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUserTreeDailyCartable_Result>("MobspUserTreeDailyCartable", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspResultsReminderCartable_Result> MobspResultsReminderCartable(int? userId, DateTime? dateTime, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize, int? cnvsReferUserId, bool? isShowTicket, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (dateTime.HasValue ? new ObjectParameter("DateTime", dateTime) : new ObjectParameter("DateTime", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (cnvsReferUserId.HasValue ? new ObjectParameter("CnvsReferUserId", cnvsReferUserId) : new ObjectParameter("CnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter8 = (isShowTicket.HasValue ? new ObjectParameter("IsShowTicket", isShowTicket) : new ObjectParameter("IsShowTicket", typeof(bool)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsReminderCartable_Result>("MobspResultsReminderCartable", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspUserTreeReminderCartable_Result> MobspUserTreeReminderCartable(int? userId, int? linkedType, int? date, DateTime? dateTime, string allUserText, int? languageID, int? defaultLanguageID, bool? isShowTicket, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(int)));
		ObjectParameter objectParameter4 = (dateTime.HasValue ? new ObjectParameter("DateTime", dateTime) : new ObjectParameter("DateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((allUserText != null) ? new ObjectParameter("AllUserText", allUserText) : new ObjectParameter("AllUserText", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (isShowTicket.HasValue ? new ObjectParameter("IsShowTicket", isShowTicket) : new ObjectParameter("IsShowTicket", typeof(bool)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUserTreeReminderCartable_Result>("MobspUserTreeReminderCartable", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<DateTime?> MobspGetTicketFirstDoingInfo(int? projectId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DateTime?>("MobspGetTicketFirstDoingInfo", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspCalcAndUpdateTicketDoingDuration(int? conversationId, int? userId, int? year1, int? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspCalcAndUpdateTicketDoingDuration", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual ObjectResult<MobspInternalMessageLoadShortUserMessage_Result> MobspInternalMessageLoadShortUserMessage(int? userID, int? typeID, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (typeID.HasValue ? new ObjectParameter("TypeID", typeID) : new ObjectParameter("TypeID", typeof(int)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspInternalMessageLoadShortUserMessage_Result>("MobspInternalMessageLoadShortUserMessage", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspIntMsgSelectUserMessageFromType_Result> MobspIntMsgSelectUserMessageFromType(int? userId, int? typeId, DateTime? fDate, DateTime? tDate, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (typeId.HasValue ? new ObjectParameter("TypeId", typeId) : new ObjectParameter("TypeId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgSelectUserMessageFromType_Result>("MobspIntMsgSelectUserMessageFromType", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int MobspUpdateUserMobImeiCode(string imeiCode, int? userId, int? registerUserId, string appType, string registerDatePersian, DateTime? registerDate, int? month)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerUserId.HasValue ? new ObjectParameter("RegisterUserId", registerUserId) : new ObjectParameter("RegisterUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = (month.HasValue ? new ObjectParameter("Month", month) : new ObjectParameter("Month", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateUserMobImeiCode", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual ObjectResult<int?> MobspInsertCrmFilesDirectory(int? fileDirectoryId, int? fileDirectoryTypeId, int? masterId, int? detailId, int? subDetailId, string title, string folderName, string fileName, string filePath, string copyFromPath, string docDate, string docDay, string docTime, int? typeOprObjectId, string fileNumRef, bool? fileFOCmpCanSee, int? firstRegisterUserId, string firstRegisterDatePersian, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter insertedFileDirectoryId, ObjectParameter errorMessage, int? centerId, string fileDesc, string fileTitle_lang, string fileDesc_lang)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		ObjectParameter objectParameter2 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (masterId.HasValue ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(int)));
		ObjectParameter objectParameter4 = (detailId.HasValue ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(int)));
		ObjectParameter objectParameter5 = (subDetailId.HasValue ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(int)));
		ObjectParameter objectParameter6 = ((title != null) ? new ObjectParameter("Title", title) : new ObjectParameter("Title", typeof(string)));
		ObjectParameter objectParameter7 = ((folderName != null) ? new ObjectParameter("FolderName", folderName) : new ObjectParameter("FolderName", typeof(string)));
		ObjectParameter objectParameter8 = ((fileName != null) ? new ObjectParameter("FileName", fileName) : new ObjectParameter("FileName", typeof(string)));
		ObjectParameter objectParameter9 = ((filePath != null) ? new ObjectParameter("FilePath", filePath) : new ObjectParameter("FilePath", typeof(string)));
		ObjectParameter objectParameter10 = ((copyFromPath != null) ? new ObjectParameter("CopyFromPath", copyFromPath) : new ObjectParameter("CopyFromPath", typeof(string)));
		ObjectParameter objectParameter11 = ((docDate != null) ? new ObjectParameter("DocDate", docDate) : new ObjectParameter("DocDate", typeof(string)));
		ObjectParameter objectParameter12 = ((docDay != null) ? new ObjectParameter("DocDay", docDay) : new ObjectParameter("DocDay", typeof(string)));
		ObjectParameter objectParameter13 = ((docTime != null) ? new ObjectParameter("DocTime", docTime) : new ObjectParameter("DocTime", typeof(string)));
		ObjectParameter objectParameter14 = (typeOprObjectId.HasValue ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(int)));
		ObjectParameter objectParameter15 = ((fileNumRef != null) ? new ObjectParameter("FileNumRef", fileNumRef) : new ObjectParameter("FileNumRef", typeof(string)));
		ObjectParameter objectParameter16 = (fileFOCmpCanSee.HasValue ? new ObjectParameter("FileFOCmpCanSee", fileFOCmpCanSee) : new ObjectParameter("FileFOCmpCanSee", typeof(bool)));
		ObjectParameter objectParameter17 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter18 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter19 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter20 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter21 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter22 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter23 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter24 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter25 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter26 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter27 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter28 = ((fileDesc != null) ? new ObjectParameter("FileDesc", fileDesc) : new ObjectParameter("FileDesc", typeof(string)));
		ObjectParameter objectParameter29 = ((fileTitle_lang != null) ? new ObjectParameter("FileTitle_lang", fileTitle_lang) : new ObjectParameter("FileTitle_lang", typeof(string)));
		ObjectParameter objectParameter30 = ((fileDesc_lang != null) ? new ObjectParameter("FileDesc_lang", fileDesc_lang) : new ObjectParameter("FileDesc_lang", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertCrmFilesDirectory", new ObjectParameter[32]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, insertedFileDirectoryId, errorMessage, objectParameter27, objectParameter28,
			objectParameter29, objectParameter30
		});
	}

	public virtual ObjectResult<MobspCheckPrdGroupSameInPreOrder_Result> MobspCheckPrdGroupSameInPreOrder(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckPrdGroupSameInPreOrder_Result>("MobspCheckPrdGroupSameInPreOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectCrmsysSetting_Result> MobspSelectCrmsysSetting(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCrmsysSetting_Result>("MobspSelectCrmsysSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectCreditDuration_Result> MobspSelectCreditDuration(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCreditDuration_Result>("MobspSelectCreditDuration", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspKnlgSelectKnowledgeTankById_Result> MobspKnlgSelectKnowledgeTankById(int? knowledgeId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (knowledgeId.HasValue ? new ObjectParameter("KnowledgeId", knowledgeId) : new ObjectParameter("KnowledgeId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspKnlgSelectKnowledgeTankById_Result>("MobspKnlgSelectKnowledgeTankById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspknlgSelectKnowledgeTankGroup_Result> MobspknlgSelectKnowledgeTankGroup(int? rollId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspknlgSelectKnowledgeTankGroup_Result>("MobspknlgSelectKnowledgeTankGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspKnlgSearch_Result> MobspKnlgSearch(string val, int? rollId, int? searchType, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		ObjectParameter objectParameter3 = (searchType.HasValue ? new ObjectParameter("SearchType", searchType) : new ObjectParameter("SearchType", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspKnlgSearch_Result>("MobspKnlgSearch", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspForgetCrtbSelectConversationStatus_Result> MobspForgetCrtbSelectConversationStatus(int? userId, string allText, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((allText != null) ? new ObjectParameter("AllText", allText) : new ObjectParameter("AllText", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspForgetCrtbSelectConversationStatus_Result>("MobspForgetCrtbSelectConversationStatus", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspForgetCrtbSelectProjectTitle_Result> MobspForgetCrtbSelectProjectTitle(int? userId, string allText, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((allText != null) ? new ObjectParameter("AllText", allText) : new ObjectParameter("AllText", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspForgetCrtbSelectProjectTitle_Result>("MobspForgetCrtbSelectProjectTitle", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspForgetCrtbSelectReferUsers_Result> MobspForgetCrtbSelectReferUsers(int? userId, string allText, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((allText != null) ? new ObjectParameter("AllText", allText) : new ObjectParameter("AllText", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspForgetCrtbSelectReferUsers_Result>("MobspForgetCrtbSelectReferUsers", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspForgetCrtbSelectUsers_Result> MobspForgetCrtbSelectUsers(int? userId, string allText, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((allText != null) ? new ObjectParameter("AllText", allText) : new ObjectParameter("AllText", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspForgetCrtbSelectUsers_Result>("MobspForgetCrtbSelectUsers", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspResultsForgetCompanyCartable_Result> MobspResultsForgetCompanyCartable(string fDate, string tDate, DateTime? fDateTime, DateTime? tDateTime, string cnvsStatusId, string prjTitle, string cnvsuserId, string cnvsReferUserId, bool? noRemindDate, int? rptUserID, string rptDate, string rptDay, string prjPostFix, int? pageSize, int? pageNumber, int? languageId, int? defaultLanguageId, int? centerId)
	{
		ObjectParameter objectParameter = ((fDate != null) ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(string)));
		ObjectParameter objectParameter2 = ((tDate != null) ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(string)));
		ObjectParameter objectParameter3 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((cnvsStatusId != null) ? new ObjectParameter("cnvsStatusId", cnvsStatusId) : new ObjectParameter("cnvsStatusId", typeof(string)));
		ObjectParameter objectParameter6 = ((prjTitle != null) ? new ObjectParameter("prjTitle", prjTitle) : new ObjectParameter("prjTitle", typeof(string)));
		ObjectParameter objectParameter7 = ((cnvsuserId != null) ? new ObjectParameter("cnvsuserId", cnvsuserId) : new ObjectParameter("cnvsuserId", typeof(string)));
		ObjectParameter objectParameter8 = ((cnvsReferUserId != null) ? new ObjectParameter("cnvsReferUserId", cnvsReferUserId) : new ObjectParameter("cnvsReferUserId", typeof(string)));
		ObjectParameter objectParameter9 = (noRemindDate.HasValue ? new ObjectParameter("NoRemindDate", noRemindDate) : new ObjectParameter("NoRemindDate", typeof(bool)));
		ObjectParameter objectParameter10 = (rptUserID.HasValue ? new ObjectParameter("rptUserID", rptUserID) : new ObjectParameter("rptUserID", typeof(int)));
		ObjectParameter objectParameter11 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter12 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter13 = ((prjPostFix != null) ? new ObjectParameter("prjPostFix", prjPostFix) : new ObjectParameter("prjPostFix", typeof(string)));
		ObjectParameter objectParameter14 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter15 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter16 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter17 = (defaultLanguageId.HasValue ? new ObjectParameter("DefaultLanguageId", defaultLanguageId) : new ObjectParameter("DefaultLanguageId", typeof(int)));
		ObjectParameter objectParameter18 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsForgetCompanyCartable_Result>("MobspResultsForgetCompanyCartable", new ObjectParameter[18]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18
		});
	}

	public virtual ObjectResult<MobspUserTreeBookMarksCartable_Result> MobspUserTreeBookMarksCartable(int? userId, int? linkedType, string allUserText, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = ((allUserText != null) ? new ObjectParameter("AllUserText", allUserText) : new ObjectParameter("AllUserText", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUserTreeBookMarksCartable_Result>("MobspUserTreeBookMarksCartable", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspResultsBookMarksCartable_Result> MobspResultsBookMarksCartable(int? cnvsReferUserId, int? userID, int? languageID, int? defaultLanguageID, int? pageNumber, int? pageSize, int? centerId)
	{
		ObjectParameter objectParameter = (cnvsReferUserId.HasValue ? new ObjectParameter("CnvsReferUserId", cnvsReferUserId) : new ObjectParameter("CnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsBookMarksCartable_Result>("MobspResultsBookMarksCartable", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspCheckDuplicateCompany_Result> MobspCheckDuplicateCompany(int? type, int? id, string val, int? titleID, int? cityId, int? userID, string lackOfShowText, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (type.HasValue ? new ObjectParameter("Type", type) : new ObjectParameter("Type", typeof(int)));
		ObjectParameter objectParameter2 = (id.HasValue ? new ObjectParameter("Id", id) : new ObjectParameter("Id", typeof(int)));
		ObjectParameter objectParameter3 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter4 = (titleID.HasValue ? new ObjectParameter("TitleID", titleID) : new ObjectParameter("TitleID", typeof(int)));
		ObjectParameter objectParameter5 = (cityId.HasValue ? new ObjectParameter("CityId", cityId) : new ObjectParameter("CityId", typeof(int)));
		ObjectParameter objectParameter6 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter7 = ((lackOfShowText != null) ? new ObjectParameter("LackOfShowText", lackOfShowText) : new ObjectParameter("LackOfShowText", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCheckDuplicateCompany_Result>("MobspCheckDuplicateCompany", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<int?> MobScorespDeleteOrderScores(int? orderId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobScorespDeleteOrderScores", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual int MobScorespInsertAndCalcOrderScores(int? ruleId, int? orderId, int? companyId, DateTime? fromDate, DateTime? toDate, bool? calcAutoScoreInIssue, bool? calcAutoScoreInVerify, DateTime? currDate, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, bool? returnResult, bool? updateCompanyGroups, int? centerId, bool? calcAutoScoreInStatusCancelled)
	{
		ObjectParameter objectParameter = (ruleId.HasValue ? new ObjectParameter("RuleId", ruleId) : new ObjectParameter("RuleId", typeof(int)));
		ObjectParameter objectParameter2 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (calcAutoScoreInIssue.HasValue ? new ObjectParameter("CalcAutoScoreInIssue", calcAutoScoreInIssue) : new ObjectParameter("CalcAutoScoreInIssue", typeof(bool)));
		ObjectParameter objectParameter7 = (calcAutoScoreInVerify.HasValue ? new ObjectParameter("CalcAutoScoreInVerify", calcAutoScoreInVerify) : new ObjectParameter("CalcAutoScoreInVerify", typeof(bool)));
		ObjectParameter objectParameter8 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter17 = (returnResult.HasValue ? new ObjectParameter("ReturnResult", returnResult) : new ObjectParameter("ReturnResult", typeof(bool)));
		ObjectParameter objectParameter18 = (updateCompanyGroups.HasValue ? new ObjectParameter("UpdateCompanyGroups", updateCompanyGroups) : new ObjectParameter("UpdateCompanyGroups", typeof(bool)));
		ObjectParameter objectParameter19 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter20 = (calcAutoScoreInStatusCancelled.HasValue ? new ObjectParameter("CalcAutoScoreInStatusCancelled", calcAutoScoreInStatusCancelled) : new ObjectParameter("CalcAutoScoreInStatusCancelled", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobScorespInsertAndCalcOrderScores", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20);
	}

	public virtual ObjectResult<MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result> MobspDySelectFormWorkflowStepsNotCheckedForMasterValue(int? masterValueId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>("MobspDySelectFormWorkflowStepsNotCheckedForMasterValue", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectVerificationWorkFlowWithObjectType_Result> MobspSelectVerificationWorkFlowWithObjectType(int? objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationWorkFlowWithObjectType_Result>("MobspSelectVerificationWorkFlowWithObjectType", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspReturnDocItemQuantityByBordItemId_Result> MobspReturnDocItemQuantityByBordItemId(int? buyOrderItemId)
	{
		ObjectParameter objectParameter = (buyOrderItemId.HasValue ? new ObjectParameter("BuyOrderItemId", buyOrderItemId) : new ObjectParameter("BuyOrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDocItemQuantityByBordItemId_Result>("MobspReturnDocItemQuantityByBordItemId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnDraftItemQuantityByOrdItemId_Result> MobspReturnDraftItemQuantityByOrdItemId(int? orderItemId)
	{
		ObjectParameter objectParameter = (orderItemId.HasValue ? new ObjectParameter("OrderItemId", orderItemId) : new ObjectParameter("OrderItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDraftItemQuantityByOrdItemId_Result>("MobspReturnDraftItemQuantityByOrdItemId", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspOrderVerifyWithPreChecks(int? orderId, int? rollId, int? verifierUserId, string registerDatePersian, DateTime? registerDate, ObjectParameter limitOrderDiscountPercent, ObjectParameter result)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		ObjectParameter objectParameter3 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspOrderVerifyWithPreChecks", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, limitOrderDiscountPercent, result);
	}

	public virtual int MobspPreOrderVerifyWithPreChecks(int? preOrderId, int? rollId, int? verifierUserId, string registerDatePersian, DateTime? registerDate, ObjectParameter limitPreOrderDiscountPercent, ObjectParameter result)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		ObjectParameter objectParameter3 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspPreOrderVerifyWithPreChecks", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, limitPreOrderDiscountPercent, result);
	}

	public virtual int MobspDyDeleteFormFieldMasterValuesBySysPart(int? objectId, string sysPart)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = ((sysPart != null) ? new ObjectParameter("SysPart", sysPart) : new ObjectParameter("SysPart", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDyDeleteFormFieldMasterValuesBySysPart", objectParameter, objectParameter2);
	}

	public virtual ObjectResult<HRMMobspSelectCompanyInsidePolygon_Result> HRMMobspSelectCompanyInsidePolygon(int? userId, string polygon, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((polygon != null) ? new ObjectParameter("Polygon", polygon) : new ObjectParameter("Polygon", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectCompanyInsidePolygon_Result>("HRMMobspSelectCompanyInsidePolygon", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<int?> MobspInsertInternalMessage(int? msgMasterId, string msgSubject, string msgBody, bool? msgActiveInCycle, int? msgdTypeId, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? msgdPriorityId, string msgdAttachFile, int? msgdAttachRecId, string msgdAttachRecDesc, int? msgdGroupId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? firstRegisterUserId, DateTime? firstRegisterDate, string firstRegisterDatePersian, string apiId, ObjectParameter internalMessageID, int? msgdAttachRecIdI, string msgdAttachRecDescI, string msgdExtraData, int? centerId)
	{
		ObjectParameter objectParameter = (msgMasterId.HasValue ? new ObjectParameter("MsgMasterId", msgMasterId) : new ObjectParameter("MsgMasterId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("MsgBody", msgBody) : new ObjectParameter("MsgBody", typeof(string)));
		ObjectParameter objectParameter4 = (msgActiveInCycle.HasValue ? new ObjectParameter("MsgActiveInCycle", msgActiveInCycle) : new ObjectParameter("MsgActiveInCycle", typeof(bool)));
		ObjectParameter objectParameter5 = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter6 = (msgdFromUserId.HasValue ? new ObjectParameter("MsgdFromUserId", msgdFromUserId) : new ObjectParameter("MsgdFromUserId", typeof(int)));
		ObjectParameter objectParameter7 = (msgdToUserId.HasValue ? new ObjectParameter("MsgdToUserId", msgdToUserId) : new ObjectParameter("MsgdToUserId", typeof(int)));
		ObjectParameter objectParameter8 = ((msgdSendDate != null) ? new ObjectParameter("MsgdSendDate", msgdSendDate) : new ObjectParameter("MsgdSendDate", typeof(string)));
		ObjectParameter objectParameter9 = ((msgdSendTime != null) ? new ObjectParameter("MsgdSendTime", msgdSendTime) : new ObjectParameter("MsgdSendTime", typeof(string)));
		ObjectParameter objectParameter10 = (msgdSendDateTime.HasValue ? new ObjectParameter("MsgdSendDateTime", msgdSendDateTime) : new ObjectParameter("MsgdSendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = (msgdPriorityId.HasValue ? new ObjectParameter("MsgdPriorityId", msgdPriorityId) : new ObjectParameter("MsgdPriorityId", typeof(int)));
		ObjectParameter objectParameter12 = ((msgdAttachFile != null) ? new ObjectParameter("MsgdAttachFile", msgdAttachFile) : new ObjectParameter("MsgdAttachFile", typeof(string)));
		ObjectParameter objectParameter13 = (msgdAttachRecId.HasValue ? new ObjectParameter("MsgdAttachRecId", msgdAttachRecId) : new ObjectParameter("MsgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter14 = ((msgdAttachRecDesc != null) ? new ObjectParameter("MsgdAttachRecDesc", msgdAttachRecDesc) : new ObjectParameter("MsgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter15 = (msgdGroupId.HasValue ? new ObjectParameter("msgdGroupId", msgdGroupId) : new ObjectParameter("msgdGroupId", typeof(int)));
		ObjectParameter objectParameter16 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter17 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter18 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter19 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter20 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter21 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter22 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter23 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter24 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter25 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter26 = ((apiId != null) ? new ObjectParameter("ApiId", apiId) : new ObjectParameter("ApiId", typeof(string)));
		ObjectParameter objectParameter27 = (msgdAttachRecIdI.HasValue ? new ObjectParameter("MsgdAttachRecIdI", msgdAttachRecIdI) : new ObjectParameter("MsgdAttachRecIdI", typeof(int)));
		ObjectParameter objectParameter28 = ((msgdAttachRecDescI != null) ? new ObjectParameter("MsgdAttachRecDescI", msgdAttachRecDescI) : new ObjectParameter("MsgdAttachRecDescI", typeof(string)));
		ObjectParameter objectParameter29 = ((msgdExtraData != null) ? new ObjectParameter("MsgdExtraData", msgdExtraData) : new ObjectParameter("MsgdExtraData", typeof(string)));
		ObjectParameter objectParameter30 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertInternalMessage", new ObjectParameter[31]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, internalMessageID, objectParameter27, objectParameter28, objectParameter29,
			objectParameter30
		});
	}

	public virtual int MobspUpdateInternalMessageAttachFileCount(int? internalMessageID, int? msgAttachFileCount)
	{
		ObjectParameter objectParameter = (internalMessageID.HasValue ? new ObjectParameter("InternalMessageID", internalMessageID) : new ObjectParameter("InternalMessageID", typeof(int)));
		ObjectParameter objectParameter2 = (msgAttachFileCount.HasValue ? new ObjectParameter("msgAttachFileCount", msgAttachFileCount) : new ObjectParameter("msgAttachFileCount", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateInternalMessageAttachFileCount", objectParameter, objectParameter2);
	}

	public virtual ObjectResult<MobspSelectCompanyCampaign_Result> MobspSelectCompanyCampaign(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyCampaign_Result>("MobspSelectCompanyCampaign", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> HRMMobspInsertInternalMessage(int? msgMasterId, string msgSubject, string msgBody, bool? msgActiveInCycle, int? msgdTypeId, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? msgdPriorityId, string msgdAttachFile, int? msgdAttachRecId, string msgdAttachRecDesc, int? msgdGroupId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? firstRegisterUserId, DateTime? firstRegisterDate, string firstRegisterDatePersian, string apiId, ObjectParameter internalMessageID, int? msgdAttachRecIdI, string msgdAttachRecDescI, string msgdExtraData)
	{
		ObjectParameter objectParameter = (msgMasterId.HasValue ? new ObjectParameter("MsgMasterId", msgMasterId) : new ObjectParameter("MsgMasterId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("MsgBody", msgBody) : new ObjectParameter("MsgBody", typeof(string)));
		ObjectParameter objectParameter4 = (msgActiveInCycle.HasValue ? new ObjectParameter("MsgActiveInCycle", msgActiveInCycle) : new ObjectParameter("MsgActiveInCycle", typeof(bool)));
		ObjectParameter objectParameter5 = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter6 = (msgdFromUserId.HasValue ? new ObjectParameter("MsgdFromUserId", msgdFromUserId) : new ObjectParameter("MsgdFromUserId", typeof(int)));
		ObjectParameter objectParameter7 = (msgdToUserId.HasValue ? new ObjectParameter("MsgdToUserId", msgdToUserId) : new ObjectParameter("MsgdToUserId", typeof(int)));
		ObjectParameter objectParameter8 = ((msgdSendDate != null) ? new ObjectParameter("MsgdSendDate", msgdSendDate) : new ObjectParameter("MsgdSendDate", typeof(string)));
		ObjectParameter objectParameter9 = ((msgdSendTime != null) ? new ObjectParameter("MsgdSendTime", msgdSendTime) : new ObjectParameter("MsgdSendTime", typeof(string)));
		ObjectParameter objectParameter10 = (msgdSendDateTime.HasValue ? new ObjectParameter("MsgdSendDateTime", msgdSendDateTime) : new ObjectParameter("MsgdSendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = (msgdPriorityId.HasValue ? new ObjectParameter("MsgdPriorityId", msgdPriorityId) : new ObjectParameter("MsgdPriorityId", typeof(int)));
		ObjectParameter objectParameter12 = ((msgdAttachFile != null) ? new ObjectParameter("MsgdAttachFile", msgdAttachFile) : new ObjectParameter("MsgdAttachFile", typeof(string)));
		ObjectParameter objectParameter13 = (msgdAttachRecId.HasValue ? new ObjectParameter("MsgdAttachRecId", msgdAttachRecId) : new ObjectParameter("MsgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter14 = ((msgdAttachRecDesc != null) ? new ObjectParameter("MsgdAttachRecDesc", msgdAttachRecDesc) : new ObjectParameter("MsgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter15 = (msgdGroupId.HasValue ? new ObjectParameter("msgdGroupId", msgdGroupId) : new ObjectParameter("msgdGroupId", typeof(int)));
		ObjectParameter objectParameter16 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter17 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter18 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter19 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter20 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter21 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter22 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter23 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter24 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter25 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter26 = ((apiId != null) ? new ObjectParameter("ApiId", apiId) : new ObjectParameter("ApiId", typeof(string)));
		ObjectParameter objectParameter27 = (msgdAttachRecIdI.HasValue ? new ObjectParameter("MsgdAttachRecIdI", msgdAttachRecIdI) : new ObjectParameter("MsgdAttachRecIdI", typeof(int)));
		ObjectParameter objectParameter28 = ((msgdAttachRecDescI != null) ? new ObjectParameter("MsgdAttachRecDescI", msgdAttachRecDescI) : new ObjectParameter("MsgdAttachRecDescI", typeof(string)));
		ObjectParameter objectParameter29 = ((msgdExtraData != null) ? new ObjectParameter("MsgdExtraData", msgdExtraData) : new ObjectParameter("MsgdExtraData", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("HRMMobspInsertInternalMessage", new ObjectParameter[30]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, internalMessageID, objectParameter27, objectParameter28, objectParameter29
		});
	}

	public virtual int HRMMobspInternalMessageLoadReceiver(int? crmUserId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspInternalMessageLoadReceiver", objectParameter);
	}

	public virtual int HRMMobspInternalMessageSend(int? msgMasterId, string msgSubject, string msgBody, bool? msgActiveInCycle, int? msgdTypeId, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? msgdPriorityId, string msgdAttachFile, int? msgdAttachRecId, string msgdAttachRecDesc, int? msgdGroupId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter internalMessageID, int? languageID, int? firstRegisterUserId, DateTime? firstRegisterDate, string firstRegisterDatePersian, string apiId, int? msgdAttachRecIdI, string msgdAttachRecDescI, string msgdExtraData, int? centerId)
	{
		ObjectParameter objectParameter = (msgMasterId.HasValue ? new ObjectParameter("msgMasterId", msgMasterId) : new ObjectParameter("msgMasterId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("msgSubject", msgSubject) : new ObjectParameter("msgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("msgBody", msgBody) : new ObjectParameter("msgBody", typeof(string)));
		ObjectParameter objectParameter4 = (msgActiveInCycle.HasValue ? new ObjectParameter("msgActiveInCycle", msgActiveInCycle) : new ObjectParameter("msgActiveInCycle", typeof(bool)));
		ObjectParameter objectParameter5 = (msgdTypeId.HasValue ? new ObjectParameter("msgdTypeId", msgdTypeId) : new ObjectParameter("msgdTypeId", typeof(int)));
		ObjectParameter objectParameter6 = (msgdFromUserId.HasValue ? new ObjectParameter("msgdFromUserId", msgdFromUserId) : new ObjectParameter("msgdFromUserId", typeof(int)));
		ObjectParameter objectParameter7 = (msgdToUserId.HasValue ? new ObjectParameter("msgdToUserId", msgdToUserId) : new ObjectParameter("msgdToUserId", typeof(int)));
		ObjectParameter objectParameter8 = ((msgdSendDate != null) ? new ObjectParameter("msgdSendDate", msgdSendDate) : new ObjectParameter("msgdSendDate", typeof(string)));
		ObjectParameter objectParameter9 = ((msgdSendTime != null) ? new ObjectParameter("msgdSendTime", msgdSendTime) : new ObjectParameter("msgdSendTime", typeof(string)));
		ObjectParameter objectParameter10 = (msgdSendDateTime.HasValue ? new ObjectParameter("msgdSendDateTime", msgdSendDateTime) : new ObjectParameter("msgdSendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = (msgdPriorityId.HasValue ? new ObjectParameter("msgdPriorityId", msgdPriorityId) : new ObjectParameter("msgdPriorityId", typeof(int)));
		ObjectParameter objectParameter12 = ((msgdAttachFile != null) ? new ObjectParameter("msgdAttachFile", msgdAttachFile) : new ObjectParameter("msgdAttachFile", typeof(string)));
		ObjectParameter objectParameter13 = (msgdAttachRecId.HasValue ? new ObjectParameter("msgdAttachRecId", msgdAttachRecId) : new ObjectParameter("msgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter14 = ((msgdAttachRecDesc != null) ? new ObjectParameter("msgdAttachRecDesc", msgdAttachRecDesc) : new ObjectParameter("msgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter15 = (msgdGroupId.HasValue ? new ObjectParameter("msgdGroupId", msgdGroupId) : new ObjectParameter("msgdGroupId", typeof(int)));
		ObjectParameter objectParameter16 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter17 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter18 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter19 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter20 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter21 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter22 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter23 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter24 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter25 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter26 = ((apiId != null) ? new ObjectParameter("ApiId", apiId) : new ObjectParameter("ApiId", typeof(string)));
		ObjectParameter objectParameter27 = (msgdAttachRecIdI.HasValue ? new ObjectParameter("msgdAttachRecIdI", msgdAttachRecIdI) : new ObjectParameter("msgdAttachRecIdI", typeof(int)));
		ObjectParameter objectParameter28 = ((msgdAttachRecDescI != null) ? new ObjectParameter("msgdAttachRecDescI", msgdAttachRecDescI) : new ObjectParameter("msgdAttachRecDescI", typeof(string)));
		ObjectParameter objectParameter29 = ((msgdExtraData != null) ? new ObjectParameter("msgdExtraData", msgdExtraData) : new ObjectParameter("msgdExtraData", typeof(string)));
		ObjectParameter objectParameter30 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspInternalMessageSend", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, internalMessageID, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30);
	}

	public virtual int HRMMobspInternalMessageUpdate(string mode, int? messageID, int? userID, int? typeID, string time, string date, string appType)
	{
		ObjectParameter objectParameter = ((mode != null) ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(string)));
		ObjectParameter objectParameter2 = (messageID.HasValue ? new ObjectParameter("MessageID", messageID) : new ObjectParameter("MessageID", typeof(int)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter4 = (typeID.HasValue ? new ObjectParameter("TypeID", typeID) : new ObjectParameter("TypeID", typeof(int)));
		ObjectParameter objectParameter5 = ((time != null) ? new ObjectParameter("Time", time) : new ObjectParameter("Time", typeof(string)));
		ObjectParameter objectParameter6 = ((date != null) ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspInternalMessageUpdate", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual int HRMMobspIntMsgUpdateMultiReceiver(int? crmUserId, string multiReceiver, bool? selected)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(int)));
		ObjectParameter objectParameter2 = ((multiReceiver != null) ? new ObjectParameter("MultiReceiver", multiReceiver) : new ObjectParameter("MultiReceiver", typeof(string)));
		ObjectParameter objectParameter3 = (selected.HasValue ? new ObjectParameter("Selected", selected) : new ObjectParameter("Selected", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspIntMsgUpdateMultiReceiver", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual int HRMMobspIntMsgUpdateSelectReceiver(string crmUserId, string userId, bool? selected, int? mode)
	{
		ObjectParameter objectParameter = ((crmUserId != null) ? new ObjectParameter("crmUserId", crmUserId) : new ObjectParameter("crmUserId", typeof(string)));
		ObjectParameter objectParameter2 = ((userId != null) ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(string)));
		ObjectParameter objectParameter3 = (selected.HasValue ? new ObjectParameter("Selected", selected) : new ObjectParameter("Selected", typeof(bool)));
		ObjectParameter objectParameter4 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspIntMsgUpdateSelectReceiver", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<HRMMobspSelectTimeAttendanceFooter_Result> HRMMobspSelectTimeAttendanceFooter(DateTime? fDate, DateTime? tDate, int? userID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectTimeAttendanceFooter_Result>("HRMMobspSelectTimeAttendanceFooter", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<HRMMobspSelectUserPictureByUserId_Result> HRMMobspSelectUserPictureByUserId(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectUserPictureByUserId_Result>("HRMMobspSelectUserPictureByUserId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<HRMMobspIntMsgSelectUserMessageFromType_Result> HRMMobspIntMsgSelectUserMessageFromType(int? userId, int? typeId, DateTime? fDate, DateTime? tDate, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (typeId.HasValue ? new ObjectParameter("TypeId", typeId) : new ObjectParameter("TypeId", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspIntMsgSelectUserMessageFromType_Result>("HRMMobspIntMsgSelectUserMessageFromType", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<HRMMobspSelectLanguages_Result> HRMMobspSelectLanguages()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectLanguages_Result>("HRMMobspSelectLanguages", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<HRMMobspSelectUserBaseInfoLastUpdate_Result> HRMMobspSelectUserBaseInfoLastUpdate(int? userId, string imeiCode, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectUserBaseInfoLastUpdate_Result>("HRMMobspSelectUserBaseInfoLastUpdate", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<HRMMobspSelectTimeAttendance_Result> HRMMobspSelectTimeAttendance(DateTime? fDate, DateTime? tDate, int? userID, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectTimeAttendance_Result>("HRMMobspSelectTimeAttendance", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<HRMMobspSelectCrmsysSetting_Result> HRMMobspSelectCrmsysSetting(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectCrmsysSetting_Result>("HRMMobspSelectCrmsysSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int HRMMobspUpdateUserMobImeiCode(string imeiCode, int? userId, int? registerUserId, string appType, string registerDatePersian, DateTime? registerDate, int? month)
	{
		ObjectParameter objectParameter = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerUserId.HasValue ? new ObjectParameter("RegisterUserId", registerUserId) : new ObjectParameter("RegisterUserId", typeof(int)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = (month.HasValue ? new ObjectParameter("Month", month) : new ObjectParameter("Month", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspUpdateUserMobImeiCode", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual ObjectResult<HRMMobspSelectRequestHistory_Result> HRMMobspSelectRequestHistory(int? userID, int? typeID, DateTime? fDate, DateTime? tDate, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (typeID.HasValue ? new ObjectParameter("TypeID", typeID) : new ObjectParameter("TypeID", typeof(int)));
		ObjectParameter objectParameter3 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter6 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectRequestHistory_Result>("HRMMobspSelectRequestHistory", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<FOMobspCmsSelectGallery_Result> FOMobspCmsSelectGallery(int? galleryId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (galleryId.HasValue ? new ObjectParameter("GalleryId", galleryId) : new ObjectParameter("GalleryId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspCmsSelectGallery_Result>("FOMobspCmsSelectGallery", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspCmsSelectGalleryItems_Result> FOMobspCmsSelectGalleryItems(int? galleryId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (galleryId.HasValue ? new ObjectParameter("GalleryId", galleryId) : new ObjectParameter("GalleryId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspCmsSelectGalleryItems_Result>("FOMobspCmsSelectGalleryItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspDySelectFormAndSubForms_Result> FOMobspDySelectFormAndSubForms(int? formId, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormAndSubForms_Result>("FOMobspDySelectFormAndSubForms", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<FOMobspDySelectFormFieldMasterValuesTree_Result> FOMobspDySelectFormFieldMasterValuesTree(DateTime? fDate, DateTime? tDate, int? formId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter6 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter7 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter8 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter10 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormFieldMasterValuesTree_Result>("FOMobspDySelectFormFieldMasterValuesTree", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual ObjectResult<FOMobspDySelectFormFieldsByParentFormId_Result> FOMobspDySelectFormFieldsByParentFormId(int? parentFormId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (parentFormId.HasValue ? new ObjectParameter("ParentFormId", parentFormId) : new ObjectParameter("ParentFormId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormFieldsByParentFormId_Result>("FOMobspDySelectFormFieldsByParentFormId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspDySelectFormFieldValuesByMasterValueId_Result> FOMobspDySelectFormFieldValuesByMasterValueId(int? masterValueId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormFieldValuesByMasterValueId_Result>("FOMobspDySelectFormFieldValuesByMasterValueId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspDySelectForms_Result> FOMobspDySelectForms(int? formId, int? parentFormId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (parentFormId.HasValue ? new ObjectParameter("ParentFormId", parentFormId) : new ObjectParameter("ParentFormId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectForms_Result>("FOMobspDySelectForms", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<FOMobspDySelectFormsMenuWithSysPartId_Result> FOMobspDySelectFormsMenuWithSysPartId(int? fOSysPartId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (fOSysPartId.HasValue ? new ObjectParameter("FOSysPartId", fOSysPartId) : new ObjectParameter("FOSysPartId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormsMenuWithSysPartId_Result>("FOMobspDySelectFormsMenuWithSysPartId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<string> FOMobspInsertTicket(int? companyId, int? projectId, int? departmentId, string prjTitle, string prjPostFix, int? statusGroupId, int? cnvsTopicId, int? cnvsStatusId, string cnvsDesc, int? cnvsPersonId, int? cnvsPriorityId, int? cnvsReferUserId, int? defaultUserId, DateTime? registerDate, string registerDatePersian, string registerDay, string registerTime, DateTime? firstRegisterDateAddSecond, int? internalMessageYear, int? year1, int? month1, string appType, int? languageID, string needErjaRefmsgSubject, string needErjaRefmsgBody, string needErjaMultiIntmsgSubject, string needErjaMultiIntmsgBody, string conversationErjaShowText, int? linkedTypeId, int? projectTitleGroupId, int? prjValidityPrdId, int? prjValidityOrdItemId, DateTime? currentDate, int? centerId, int? fosettingId, int? foCountModule)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (departmentId.HasValue ? new ObjectParameter("DepartmentId", departmentId) : new ObjectParameter("DepartmentId", typeof(int)));
		ObjectParameter objectParameter4 = ((prjTitle != null) ? new ObjectParameter("PrjTitle", prjTitle) : new ObjectParameter("PrjTitle", typeof(string)));
		ObjectParameter objectParameter5 = ((prjPostFix != null) ? new ObjectParameter("PrjPostFix", prjPostFix) : new ObjectParameter("PrjPostFix", typeof(string)));
		ObjectParameter objectParameter6 = (statusGroupId.HasValue ? new ObjectParameter("StatusGroupId", statusGroupId) : new ObjectParameter("StatusGroupId", typeof(int)));
		ObjectParameter objectParameter7 = (cnvsTopicId.HasValue ? new ObjectParameter("CnvsTopicId", cnvsTopicId) : new ObjectParameter("CnvsTopicId", typeof(int)));
		ObjectParameter objectParameter8 = (cnvsStatusId.HasValue ? new ObjectParameter("CnvsStatusId", cnvsStatusId) : new ObjectParameter("CnvsStatusId", typeof(int)));
		ObjectParameter objectParameter9 = ((cnvsDesc != null) ? new ObjectParameter("CnvsDesc", cnvsDesc) : new ObjectParameter("CnvsDesc", typeof(string)));
		ObjectParameter objectParameter10 = (cnvsPersonId.HasValue ? new ObjectParameter("CnvsPersonId", cnvsPersonId) : new ObjectParameter("CnvsPersonId", typeof(int)));
		ObjectParameter objectParameter11 = (cnvsPriorityId.HasValue ? new ObjectParameter("CnvsPriorityId", cnvsPriorityId) : new ObjectParameter("CnvsPriorityId", typeof(int)));
		ObjectParameter objectParameter12 = (cnvsReferUserId.HasValue ? new ObjectParameter("CnvsReferUserId", cnvsReferUserId) : new ObjectParameter("CnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter13 = (defaultUserId.HasValue ? new ObjectParameter("DefaultUserId", defaultUserId) : new ObjectParameter("DefaultUserId", typeof(int)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = ((registerDay != null) ? new ObjectParameter("RegisterDay", registerDay) : new ObjectParameter("RegisterDay", typeof(string)));
		ObjectParameter objectParameter17 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter18 = (firstRegisterDateAddSecond.HasValue ? new ObjectParameter("FirstRegisterDateAddSecond", firstRegisterDateAddSecond) : new ObjectParameter("FirstRegisterDateAddSecond", typeof(DateTime)));
		ObjectParameter objectParameter19 = (internalMessageYear.HasValue ? new ObjectParameter("InternalMessageYear", internalMessageYear) : new ObjectParameter("InternalMessageYear", typeof(int)));
		ObjectParameter objectParameter20 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter21 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter22 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter23 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter24 = ((needErjaRefmsgSubject != null) ? new ObjectParameter("NeedErjaRefmsgSubject", needErjaRefmsgSubject) : new ObjectParameter("NeedErjaRefmsgSubject", typeof(string)));
		ObjectParameter objectParameter25 = ((needErjaRefmsgBody != null) ? new ObjectParameter("NeedErjaRefmsgBody", needErjaRefmsgBody) : new ObjectParameter("NeedErjaRefmsgBody", typeof(string)));
		ObjectParameter objectParameter26 = ((needErjaMultiIntmsgSubject != null) ? new ObjectParameter("NeedErjaMultiIntmsgSubject", needErjaMultiIntmsgSubject) : new ObjectParameter("NeedErjaMultiIntmsgSubject", typeof(string)));
		ObjectParameter objectParameter27 = ((needErjaMultiIntmsgBody != null) ? new ObjectParameter("NeedErjaMultiIntmsgBody", needErjaMultiIntmsgBody) : new ObjectParameter("NeedErjaMultiIntmsgBody", typeof(string)));
		ObjectParameter objectParameter28 = ((conversationErjaShowText != null) ? new ObjectParameter("ConversationErjaShowText", conversationErjaShowText) : new ObjectParameter("ConversationErjaShowText", typeof(string)));
		ObjectParameter objectParameter29 = (linkedTypeId.HasValue ? new ObjectParameter("LinkedTypeId", linkedTypeId) : new ObjectParameter("LinkedTypeId", typeof(int)));
		ObjectParameter objectParameter30 = (projectTitleGroupId.HasValue ? new ObjectParameter("ProjectTitleGroupId", projectTitleGroupId) : new ObjectParameter("ProjectTitleGroupId", typeof(int)));
		ObjectParameter objectParameter31 = (prjValidityPrdId.HasValue ? new ObjectParameter("prjValidityPrdId", prjValidityPrdId) : new ObjectParameter("prjValidityPrdId", typeof(int)));
		ObjectParameter objectParameter32 = (prjValidityOrdItemId.HasValue ? new ObjectParameter("prjValidityOrdItemId", prjValidityOrdItemId) : new ObjectParameter("prjValidityOrdItemId", typeof(int)));
		ObjectParameter objectParameter33 = (currentDate.HasValue ? new ObjectParameter("CurrentDate", currentDate) : new ObjectParameter("CurrentDate", typeof(DateTime)));
		ObjectParameter objectParameter34 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter35 = (fosettingId.HasValue ? new ObjectParameter("FosettingId", fosettingId) : new ObjectParameter("FosettingId", typeof(int)));
		ObjectParameter objectParameter36 = (foCountModule.HasValue ? new ObjectParameter("FoCountModule", foCountModule) : new ObjectParameter("FoCountModule", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("FOMobspInsertTicket", new ObjectParameter[36]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36
		});
	}

	public virtual ObjectResult<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result> FOMobspReturnTicketAllowAddBeforeAnswerCount(int? companyId, int? projectId, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspReturnTicketAllowAddBeforeAnswerCount_Result>("FOMobspReturnTicketAllowAddBeforeAnswerCount", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyByEmailOrMobile_Result> FOMobspSelectCompanyByEmailOrMobile(string emailMobile, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((emailMobile != null) ? new ObjectParameter("EmailMobile", emailMobile) : new ObjectParameter("EmailMobile", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyByEmailOrMobile_Result>("FOMobspSelectCompanyByEmailOrMobile", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyById_Result> FOMobspSelectCompanyById(int? companyId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyById_Result>("FOMobspSelectCompanyById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyItemsDetail_Result> FOMobspSelectCompanyItemsDetail(int? companyId, int? languageID, int? defaultLanguageID, int? companyPersonId, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter6 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyItemsDetail_Result>("FOMobspSelectCompanyItemsDetail", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyPersonById_Result> FOMobspSelectCompanyPersonById(int? companyPersonId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyPersonById_Result>("FOMobspSelectCompanyPersonById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectCompanyPersonsForTicket_Result> FOMobspSelectCompanyPersonsForTicket(int? companyId, int? languageID, int? defaultLanguageID, int? companyPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCompanyPersonsForTicket_Result>("FOMobspSelectCompanyPersonsForTicket", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<FOMobspSelectConversationPriority_Result> FOMobspSelectConversationPriority(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectConversationPriority_Result>("FOMobspSelectConversationPriority", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<FOMobspSelectCrmConversationStatus_Result> FOMobspSelectCrmConversationStatus(int? statusGroupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (statusGroupId.HasValue ? new ObjectParameter("StatusGroupId", statusGroupId) : new ObjectParameter("StatusGroupId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCrmConversationStatus_Result>("FOMobspSelectCrmConversationStatus", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectEmailSettingById_Result> FOMobspSelectEmailSettingById(int? emailSettingId)
	{
		ObjectParameter objectParameter = (emailSettingId.HasValue ? new ObjectParameter("EmailSettingId", emailSettingId) : new ObjectParameter("EmailSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectEmailSettingById_Result>("FOMobspSelectEmailSettingById", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<FOMobspSelectEmailUsersInfoById_Result> FOMobspSelectEmailUsersInfoById(int? emailUsersInfoId)
	{
		ObjectParameter objectParameter = (emailUsersInfoId.HasValue ? new ObjectParameter("EmailUsersInfoId", emailUsersInfoId) : new ObjectParameter("EmailUsersInfoId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectEmailUsersInfoById_Result>("FOMobspSelectEmailUsersInfoById", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<FOMobspSelectFilesDirectory_Result> FOMobspSelectFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, int? languageID, int? defaultLanguageID, bool? fileFOCmpCanSee, int? centerId)
	{
		ObjectParameter objectParameter = ((masterId != null) ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(string)));
		ObjectParameter objectParameter2 = ((detailId != null) ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(string)));
		ObjectParameter objectParameter3 = ((subDetailId != null) ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(string)));
		ObjectParameter objectParameter4 = ((fileDirectoryTypeOprId != null) ? new ObjectParameter("FileDirectoryTypeOprId", fileDirectoryTypeOprId) : new ObjectParameter("FileDirectoryTypeOprId", typeof(string)));
		ObjectParameter objectParameter5 = ((typeOprObjectId != null) ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (fileFOCmpCanSee.HasValue ? new ObjectParameter("FileFOCmpCanSee", fileFOCmpCanSee) : new ObjectParameter("FileFOCmpCanSee", typeof(bool)));
		ObjectParameter objectParameter9 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectFilesDirectory_Result>("FOMobspSelectFilesDirectory", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<FOMobspSelectHomePageSetting_Result> FOMobspSelectHomePageSetting(int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter2 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectHomePageSetting_Result>("FOMobspSelectHomePageSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<FOMobspSelectSmsGSMModemSetting_Result> FOMobspSelectSmsGSMModemSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectSmsGSMModemSetting_Result>("FOMobspSelectSmsGSMModemSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<FOMobspSelectSmsSetting_Result> FOMobspSelectSmsSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectSmsSetting_Result>("FOMobspSelectSmsSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<FOMobspSelectTicketProjectTitleAndTitleGroup_Result> FOMobspSelectTicketProjectTitleAndTitleGroup(int? languageID, int? defaultLanguageID, int? foSettingId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectTicketProjectTitleAndTitleGroup_Result>("FOMobspSelectTicketProjectTitleAndTitleGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspSelectTicketsWithTicketNumber_Result> FOMobspSelectTicketsWithTicketNumber(int? companyId, int? projectId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? companyPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter8 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectTicketsWithTicketNumber_Result>("FOMobspSelectTicketsWithTicketNumber", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<FOMobspSelectUserForTicketReferToMultilUser_Result> FOMobspSelectUserForTicketReferToMultilUser(int? departmentId, int? linkedType, int? referUserIdSelected, int? companyId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (departmentId.HasValue ? new ObjectParameter("DepartmentId", departmentId) : new ObjectParameter("DepartmentId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (referUserIdSelected.HasValue ? new ObjectParameter("ReferUserIdSelected", referUserIdSelected) : new ObjectParameter("ReferUserIdSelected", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectUserForTicketReferToMultilUser_Result>("FOMobspSelectUserForTicketReferToMultilUser", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual int FOMobspDeleteCrmFilesDirectory(int? fileDirectoryID)
	{
		ObjectParameter objectParameter = (fileDirectoryID.HasValue ? new ObjectParameter("FileDirectoryID", fileDirectoryID) : new ObjectParameter("FileDirectoryID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspDeleteCrmFilesDirectory", objectParameter);
	}

	public virtual ObjectResult<int?> FOMobspGetUnReadTicket(int? companyId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspGetUnReadTicket", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> FOMobspInsertCrmFilesDirectory(int? fileDirectoryId, int? fileDirectoryTypeId, int? masterId, int? detailId, int? subDetailId, string title, string folderName, string fileName, string filePath, string copyFromPath, int? userId, short? year1, short? month1, string registerDatePersian, string docDay, string docTime, int? typeOprObjectId, string appType, int? languageID, int? orderView, int? typeOprObjectIdI, int? typeOprObjectIdII, bool? fileFOCmpCanSee, int? centerId, string fileDesc, string fileTitle_lang, string fileDesc_lang, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		ObjectParameter objectParameter2 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (masterId.HasValue ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(int)));
		ObjectParameter objectParameter4 = (detailId.HasValue ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(int)));
		ObjectParameter objectParameter5 = (subDetailId.HasValue ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(int)));
		ObjectParameter objectParameter6 = ((title != null) ? new ObjectParameter("Title", title) : new ObjectParameter("Title", typeof(string)));
		ObjectParameter objectParameter7 = ((folderName != null) ? new ObjectParameter("FolderName", folderName) : new ObjectParameter("FolderName", typeof(string)));
		ObjectParameter objectParameter8 = ((fileName != null) ? new ObjectParameter("FileName", fileName) : new ObjectParameter("FileName", typeof(string)));
		ObjectParameter objectParameter9 = ((filePath != null) ? new ObjectParameter("FilePath", filePath) : new ObjectParameter("FilePath", typeof(string)));
		ObjectParameter objectParameter10 = ((copyFromPath != null) ? new ObjectParameter("CopyFromPath", copyFromPath) : new ObjectParameter("CopyFromPath", typeof(string)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((docDay != null) ? new ObjectParameter("DocDay", docDay) : new ObjectParameter("DocDay", typeof(string)));
		ObjectParameter objectParameter16 = ((docTime != null) ? new ObjectParameter("DocTime", docTime) : new ObjectParameter("DocTime", typeof(string)));
		ObjectParameter objectParameter17 = (typeOprObjectId.HasValue ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(int)));
		ObjectParameter objectParameter18 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter19 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter20 = (orderView.HasValue ? new ObjectParameter("OrderView", orderView) : new ObjectParameter("OrderView", typeof(int)));
		ObjectParameter objectParameter21 = (typeOprObjectIdI.HasValue ? new ObjectParameter("TypeOprObjectIdI", typeOprObjectIdI) : new ObjectParameter("TypeOprObjectIdI", typeof(int)));
		ObjectParameter objectParameter22 = (typeOprObjectIdII.HasValue ? new ObjectParameter("TypeOprObjectIdII", typeOprObjectIdII) : new ObjectParameter("TypeOprObjectIdII", typeof(int)));
		ObjectParameter objectParameter23 = (fileFOCmpCanSee.HasValue ? new ObjectParameter("FileFOCmpCanSee", fileFOCmpCanSee) : new ObjectParameter("FileFOCmpCanSee", typeof(bool)));
		ObjectParameter objectParameter24 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter25 = ((fileDesc != null) ? new ObjectParameter("FileDesc", fileDesc) : new ObjectParameter("FileDesc", typeof(string)));
		ObjectParameter objectParameter26 = ((fileTitle_lang != null) ? new ObjectParameter("FileTitle_lang", fileTitle_lang) : new ObjectParameter("FileTitle_lang", typeof(string)));
		ObjectParameter objectParameter27 = ((fileDesc_lang != null) ? new ObjectParameter("FileDesc_lang", fileDesc_lang) : new ObjectParameter("FileDesc_lang", typeof(string)));
		ObjectParameter objectParameter28 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspInsertCrmFilesDirectory", new ObjectParameter[28]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28
		});
	}

	public virtual ObjectResult<FOMobspSelectTickets_Result> FOMobspSelectTickets(int? companyId, int? projectId, int? conversationId, bool? isFinished, bool? isAnswered, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, bool? isReadTicket, bool? isStopTicket, int? companyPersonId, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter4 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(bool)));
		ObjectParameter objectParameter5 = (isAnswered.HasValue ? new ObjectParameter("IsAnswered", isAnswered) : new ObjectParameter("IsAnswered", typeof(bool)));
		ObjectParameter objectParameter6 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (isReadTicket.HasValue ? new ObjectParameter("IsReadTicket", isReadTicket) : new ObjectParameter("IsReadTicket", typeof(bool)));
		ObjectParameter objectParameter11 = (isStopTicket.HasValue ? new ObjectParameter("IsStopTicket", isStopTicket) : new ObjectParameter("IsStopTicket", typeof(bool)));
		ObjectParameter objectParameter12 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter14 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectTickets_Result>("FOMobspSelectTickets", new ObjectParameter[14]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14
		});
	}

	public virtual ObjectResult<FOMobspSelectUserBaseInfoLastUpdate_Result> FOMobspSelectUserBaseInfoLastUpdate(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectUserBaseInfoLastUpdate_Result>("FOMobspSelectUserBaseInfoLastUpdate", new ObjectParameter[1] { objectParameter });
	}

	public virtual int FOMobspTicketIsRead(int? companyId, int? projectId, int? companyPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspTicketIsRead", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<int?> FOMobspResetCompanyPassword(int? companyId, string newCmpPassword, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter errorMessage)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((newCmpPassword != null) ? new ObjectParameter("NewCmpPassword", newCmpPassword) : new ObjectParameter("NewCmpPassword", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspResetCompanyPassword", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, errorMessage });
	}

	public virtual ObjectResult<FOMobspSelectLanguages_Result> FOMobspSelectLanguages()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectLanguages_Result>("FOMobspSelectLanguages", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<string> FOMobspSelectTicketSubjectDefaultContext(string newSubjectTXT, int? languageID, int? defaultLanguageID, int? foSettingId)
	{
		ObjectParameter objectParameter = ((newSubjectTXT != null) ? new ObjectParameter("NewSubjectTXT", newSubjectTXT) : new ObjectParameter("NewSubjectTXT", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("FOMobspSelectTicketSubjectDefaultContext", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int FOMobspGetEmailPatternFormulaResult(int? companyId, int? companyPersonId, string cmpPassword, int? foSettingId, int? languageID, int? defaultLanguageID, ObjectParameter emailSubjectPatternFormulaResult, ObjectParameter emailBodyPatternFormulaResult)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((cmpPassword != null) ? new ObjectParameter("CmpPassword", cmpPassword) : new ObjectParameter("CmpPassword", typeof(string)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspGetEmailPatternFormulaResult", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, emailSubjectPatternFormulaResult, emailBodyPatternFormulaResult);
	}

	public virtual int FOMobspGetSmsBodyPatternFormulaResult(int? companyId, int? companyPersonId, string cmpPassword, int? foSettingId, int? languageID, int? defaultLanguageID, ObjectParameter smsBodyPatternFormulaResult)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((cmpPassword != null) ? new ObjectParameter("CmpPassword", cmpPassword) : new ObjectParameter("CmpPassword", typeof(string)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspGetSmsBodyPatternFormulaResult", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, smsBodyPatternFormulaResult);
	}

	public virtual ObjectResult<int?> FOMobspInsertSendedEmail(string emailSubject, string emailBody, int? priorityId, int? emailUsersInfoId, int? emailSettingId, string emailAddress, int? emailCmpId, int? emailCmpPrsId, int? emailCmpPrjId, string emailCmpPrsName, string emailCmpName, string emailPrsJob, int? statusId, int? userId, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter insertedEmailHeaderId, ObjectParameter insertedEmailDetailId, ObjectParameter errorMessage, int? centerId)
	{
		ObjectParameter objectParameter = ((emailSubject != null) ? new ObjectParameter("EmailSubject", emailSubject) : new ObjectParameter("EmailSubject", typeof(string)));
		ObjectParameter objectParameter2 = ((emailBody != null) ? new ObjectParameter("EmailBody", emailBody) : new ObjectParameter("EmailBody", typeof(string)));
		ObjectParameter objectParameter3 = (priorityId.HasValue ? new ObjectParameter("PriorityId", priorityId) : new ObjectParameter("PriorityId", typeof(int)));
		ObjectParameter objectParameter4 = (emailUsersInfoId.HasValue ? new ObjectParameter("EmailUsersInfoId", emailUsersInfoId) : new ObjectParameter("EmailUsersInfoId", typeof(int)));
		ObjectParameter objectParameter5 = (emailSettingId.HasValue ? new ObjectParameter("EmailSettingId", emailSettingId) : new ObjectParameter("EmailSettingId", typeof(int)));
		ObjectParameter objectParameter6 = ((emailAddress != null) ? new ObjectParameter("EmailAddress", emailAddress) : new ObjectParameter("EmailAddress", typeof(string)));
		ObjectParameter objectParameter7 = (emailCmpId.HasValue ? new ObjectParameter("EmailCmpId", emailCmpId) : new ObjectParameter("EmailCmpId", typeof(int)));
		ObjectParameter objectParameter8 = (emailCmpPrsId.HasValue ? new ObjectParameter("EmailCmpPrsId", emailCmpPrsId) : new ObjectParameter("EmailCmpPrsId", typeof(int)));
		ObjectParameter objectParameter9 = (emailCmpPrjId.HasValue ? new ObjectParameter("EmailCmpPrjId", emailCmpPrjId) : new ObjectParameter("EmailCmpPrjId", typeof(int)));
		ObjectParameter objectParameter10 = ((emailCmpPrsName != null) ? new ObjectParameter("EmailCmpPrsName", emailCmpPrsName) : new ObjectParameter("EmailCmpPrsName", typeof(string)));
		ObjectParameter objectParameter11 = ((emailCmpName != null) ? new ObjectParameter("EmailCmpName", emailCmpName) : new ObjectParameter("EmailCmpName", typeof(string)));
		ObjectParameter objectParameter12 = ((emailPrsJob != null) ? new ObjectParameter("EmailPrsJob", emailPrsJob) : new ObjectParameter("EmailPrsJob", typeof(string)));
		ObjectParameter objectParameter13 = (statusId.HasValue ? new ObjectParameter("StatusId", statusId) : new ObjectParameter("StatusId", typeof(int)));
		ObjectParameter objectParameter14 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter18 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter20 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspInsertSendedEmail", new ObjectParameter[23]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, insertedEmailHeaderId,
			insertedEmailDetailId, errorMessage, objectParameter20
		});
	}

	public virtual int FOMobspInsertSendedSms(int? sendType, string sendTopic, int? sID, string fromNumber, string smsBody, int? smsBodyCount, string smsBodyLangType, decimal? smsBodyCost, int? numberCount, string numbers, string refNumbers, int? allSmsCount, decimal? userCost, int? sendUserId, string sendDay, string sendDate, string sendTime, DateTime? sendDateTime, string companiesId, string companyPersonsId, int? userId, int? year1, int? month1, string registerDatePersian, string singleNumber, int? singleCompanyId, int? singleCompanyPersonId, string singleRefNumber, string appType, int? statusId, int? cMessage, DateTime? schedulDate, int? sendPriority, int? defaultLanguageID, bool? sendNeedCheck, int? centerId)
	{
		ObjectParameter objectParameter = (sendType.HasValue ? new ObjectParameter("SendType", sendType) : new ObjectParameter("SendType", typeof(int)));
		ObjectParameter objectParameter2 = ((sendTopic != null) ? new ObjectParameter("SendTopic", sendTopic) : new ObjectParameter("SendTopic", typeof(string)));
		ObjectParameter objectParameter3 = (sID.HasValue ? new ObjectParameter("SID", sID) : new ObjectParameter("SID", typeof(int)));
		ObjectParameter objectParameter4 = ((fromNumber != null) ? new ObjectParameter("FromNumber", fromNumber) : new ObjectParameter("FromNumber", typeof(string)));
		ObjectParameter objectParameter5 = ((smsBody != null) ? new ObjectParameter("smsBody", smsBody) : new ObjectParameter("smsBody", typeof(string)));
		ObjectParameter objectParameter6 = (smsBodyCount.HasValue ? new ObjectParameter("SmsBodyCount", smsBodyCount) : new ObjectParameter("SmsBodyCount", typeof(int)));
		ObjectParameter objectParameter7 = ((smsBodyLangType != null) ? new ObjectParameter("SmsBodyLangType", smsBodyLangType) : new ObjectParameter("SmsBodyLangType", typeof(string)));
		ObjectParameter objectParameter8 = (smsBodyCost.HasValue ? new ObjectParameter("SmsBodyCost", smsBodyCost) : new ObjectParameter("SmsBodyCost", typeof(decimal)));
		ObjectParameter objectParameter9 = (numberCount.HasValue ? new ObjectParameter("NumberCount", numberCount) : new ObjectParameter("NumberCount", typeof(int)));
		ObjectParameter objectParameter10 = ((numbers != null) ? new ObjectParameter("Numbers", numbers) : new ObjectParameter("Numbers", typeof(string)));
		ObjectParameter objectParameter11 = ((refNumbers != null) ? new ObjectParameter("RefNumbers", refNumbers) : new ObjectParameter("RefNumbers", typeof(string)));
		ObjectParameter objectParameter12 = (allSmsCount.HasValue ? new ObjectParameter("AllSmsCount", allSmsCount) : new ObjectParameter("AllSmsCount", typeof(int)));
		ObjectParameter objectParameter13 = (userCost.HasValue ? new ObjectParameter("UserCost", userCost) : new ObjectParameter("UserCost", typeof(decimal)));
		ObjectParameter objectParameter14 = (sendUserId.HasValue ? new ObjectParameter("SendUserId", sendUserId) : new ObjectParameter("SendUserId", typeof(int)));
		ObjectParameter objectParameter15 = ((sendDay != null) ? new ObjectParameter("SendDay", sendDay) : new ObjectParameter("SendDay", typeof(string)));
		ObjectParameter objectParameter16 = ((sendDate != null) ? new ObjectParameter("SendDate", sendDate) : new ObjectParameter("SendDate", typeof(string)));
		ObjectParameter objectParameter17 = ((sendTime != null) ? new ObjectParameter("SendTime", sendTime) : new ObjectParameter("SendTime", typeof(string)));
		ObjectParameter objectParameter18 = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter19 = ((companiesId != null) ? new ObjectParameter("CompaniesId", companiesId) : new ObjectParameter("CompaniesId", typeof(string)));
		ObjectParameter objectParameter20 = ((companyPersonsId != null) ? new ObjectParameter("CompanyPersonsId", companyPersonsId) : new ObjectParameter("CompanyPersonsId", typeof(string)));
		ObjectParameter objectParameter21 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter22 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter23 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter24 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter25 = ((singleNumber != null) ? new ObjectParameter("SingleNumber", singleNumber) : new ObjectParameter("SingleNumber", typeof(string)));
		ObjectParameter objectParameter26 = (singleCompanyId.HasValue ? new ObjectParameter("SingleCompanyId", singleCompanyId) : new ObjectParameter("SingleCompanyId", typeof(int)));
		ObjectParameter objectParameter27 = (singleCompanyPersonId.HasValue ? new ObjectParameter("SingleCompanyPersonId", singleCompanyPersonId) : new ObjectParameter("SingleCompanyPersonId", typeof(int)));
		ObjectParameter objectParameter28 = ((singleRefNumber != null) ? new ObjectParameter("SingleRefNumber", singleRefNumber) : new ObjectParameter("SingleRefNumber", typeof(string)));
		ObjectParameter objectParameter29 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter30 = (statusId.HasValue ? new ObjectParameter("StatusId", statusId) : new ObjectParameter("StatusId", typeof(int)));
		ObjectParameter objectParameter31 = (cMessage.HasValue ? new ObjectParameter("CMessage", cMessage) : new ObjectParameter("CMessage", typeof(int)));
		ObjectParameter objectParameter32 = (schedulDate.HasValue ? new ObjectParameter("SchedulDate", schedulDate) : new ObjectParameter("SchedulDate", typeof(DateTime)));
		ObjectParameter objectParameter33 = (sendPriority.HasValue ? new ObjectParameter("SendPriority", sendPriority) : new ObjectParameter("SendPriority", typeof(int)));
		ObjectParameter objectParameter34 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter35 = (sendNeedCheck.HasValue ? new ObjectParameter("SendNeedCheck", sendNeedCheck) : new ObjectParameter("SendNeedCheck", typeof(bool)));
		ObjectParameter objectParameter36 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInsertSendedSms", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36);
	}

	public virtual int FOMobspInsertSendSms(int? companyId, int? companyPersonId, string fromNumber, decimal? smsEnCost, decimal? smsFaCost, string smsBody, int? sID, long? singleRefNumber, string sendDay, string sendDate, string sendTime, int? userId, int? year1, int? month1, string registerDatePersian, string appType, int? defaultLanguageID, int? statusId, int? sendType, ObjectParameter errorMessage, ObjectParameter result, string oTP, string mobile, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((fromNumber != null) ? new ObjectParameter("FromNumber", fromNumber) : new ObjectParameter("FromNumber", typeof(string)));
		ObjectParameter objectParameter4 = (smsEnCost.HasValue ? new ObjectParameter("SmsEnCost", smsEnCost) : new ObjectParameter("SmsEnCost", typeof(decimal)));
		ObjectParameter objectParameter5 = (smsFaCost.HasValue ? new ObjectParameter("SmsFaCost", smsFaCost) : new ObjectParameter("SmsFaCost", typeof(decimal)));
		ObjectParameter objectParameter6 = ((smsBody != null) ? new ObjectParameter("SmsBody", smsBody) : new ObjectParameter("SmsBody", typeof(string)));
		ObjectParameter objectParameter7 = (sID.HasValue ? new ObjectParameter("SID", sID) : new ObjectParameter("SID", typeof(int)));
		ObjectParameter objectParameter8 = (singleRefNumber.HasValue ? new ObjectParameter("SingleRefNumber", singleRefNumber) : new ObjectParameter("SingleRefNumber", typeof(long)));
		ObjectParameter objectParameter9 = ((sendDay != null) ? new ObjectParameter("SendDay", sendDay) : new ObjectParameter("SendDay", typeof(string)));
		ObjectParameter objectParameter10 = ((sendDate != null) ? new ObjectParameter("SendDate", sendDate) : new ObjectParameter("SendDate", typeof(string)));
		ObjectParameter objectParameter11 = ((sendTime != null) ? new ObjectParameter("SendTime", sendTime) : new ObjectParameter("SendTime", typeof(string)));
		ObjectParameter objectParameter12 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter13 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (statusId.HasValue ? new ObjectParameter("StatusId", statusId) : new ObjectParameter("StatusId", typeof(int)));
		ObjectParameter objectParameter19 = (sendType.HasValue ? new ObjectParameter("SendType", sendType) : new ObjectParameter("SendType", typeof(int)));
		ObjectParameter objectParameter20 = ((oTP != null) ? new ObjectParameter("OTP", oTP) : new ObjectParameter("OTP", typeof(string)));
		ObjectParameter objectParameter21 = ((mobile != null) ? new ObjectParameter("Mobile", mobile) : new ObjectParameter("Mobile", typeof(string)));
		ObjectParameter objectParameter22 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspInsertSendSms", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, errorMessage, result, objectParameter20, objectParameter21, objectParameter22);
	}

	public virtual ObjectResult<int?> FOMobspDyInsertFormFieldMasterValues(int? formId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID, int? centerId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter4 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter5 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter6 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter7 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter8 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspDyInsertFormFieldMasterValues", new ObjectParameter[16]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16
		});
	}

	public virtual ObjectResult<int?> FOMobspDyInsertFormFieldValues(int? masterValueId, int? formId, int? fieldId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, string value, string valueLang, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter3 = (fieldId.HasValue ? new ObjectParameter("FieldId", fieldId) : new ObjectParameter("FieldId", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter6 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter7 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter8 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter10 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter11 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter12 = ((valueLang != null) ? new ObjectParameter("ValueLang", valueLang) : new ObjectParameter("ValueLang", typeof(string)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter17 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter18 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter19 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspDyInsertFormFieldValues", new ObjectParameter[19]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19
		});
	}

	public virtual int FOMobspDyInsertUpdateFormFieldMasterValueDetails(int? mode, int? masterValueId, int? formId, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter3 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspDyInsertUpdateFormFieldMasterValueDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual ObjectResult<FOMobspDySelectFormFieldsWithFormId_Result> FOMobspDySelectFormFieldsWithFormId(int? formId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormFieldsWithFormId_Result>("FOMobspDySelectFormFieldsWithFormId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int FOMobspDySelectFormFieldValues(int? formId, int? masterValueId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter3 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter4 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter5 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter6 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter7 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter8 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspDySelectFormFieldValues", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<int?> FOMobspDyUpdateFormFieldValues(int? fieldValueId, string value, string valueLang, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (fieldValueId.HasValue ? new ObjectParameter("FieldValueId", fieldValueId) : new ObjectParameter("FieldValueId", typeof(int)));
		ObjectParameter objectParameter2 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter3 = ((valueLang != null) ? new ObjectParameter("ValueLang", valueLang) : new ObjectParameter("ValueLang", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspDyUpdateFormFieldValues", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<string> FOMobspDyInternalMessageSendToCheckerUsers(int? masterValueId, string messages, int? msgdTypeId, string checkerUsersId, int? userId, DateTime? registerDate, string registerDatePersian, string registerTime, string msgdAttachRecDesc, short? year1, short? month1, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = ((messages != null) ? new ObjectParameter("Messages", messages) : new ObjectParameter("Messages", typeof(string)));
		ObjectParameter objectParameter3 = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter4 = ((checkerUsersId != null) ? new ObjectParameter("CheckerUsersId", checkerUsersId) : new ObjectParameter("CheckerUsersId", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter9 = ((msgdAttachRecDesc != null) ? new ObjectParameter("MsgdAttachRecDesc", msgdAttachRecDesc) : new ObjectParameter("MsgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter10 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter11 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("FOMobspDyInternalMessageSendToCheckerUsers", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual ObjectResult<FOMobspDySelectFormFieldMasterValueWithId_Result> FOMobspDySelectFormFieldMasterValueWithId(int? masterValueId)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormFieldMasterValueWithId_Result>("FOMobspDySelectFormFieldMasterValueWithId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<FOMobspReturnTicketAllowInCurrntCount_Result> FOMobspReturnTicketAllowInCurrntCount(int? companyId, int? prjTitleGroupId, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (prjTitleGroupId.HasValue ? new ObjectParameter("PrjTitleGroupId", prjTitleGroupId) : new ObjectParameter("PrjTitleGroupId", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspReturnTicketAllowInCurrntCount_Result>("FOMobspReturnTicketAllowInCurrntCount", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCrmFoSetting_Result> MobspSelectCrmFoSetting(int? languageID, int? defaultLanguageID, int? centerId, int? foSettingId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCrmFoSetting_Result>("MobspSelectCrmFoSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectTicketProjectTitleAndTitleGroup_Result> MobspSelectTicketProjectTitleAndTitleGroup(int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTicketProjectTitleAndTitleGroup_Result>("MobspSelectTicketProjectTitleAndTitleGroup", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int FOMobspUpdateConversationHappyVote(int? conversationId, int? cnvsHappyVote, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter2 = (cnvsHappyVote.HasValue ? new ObjectParameter("cnvsHappyVote", cnvsHappyVote) : new ObjectParameter("cnvsHappyVote", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FOMobspUpdateConversationHappyVote", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<MobspResultsTicketCartable_Result> MobspResultsTicketCartable(int? mode, int? userId, int? lastRowNumber, int? pageSize, string prjTitleGroup, DateTime? currDateTime, int? languageID, int? defaultLanguageID, int? prjTitleGroupId, int? cnvsStatusGroupId, int? cnvsStatusId, int? priorityId, int? crmUserId, DateTime? closedTicketDate, DateTime? closedTicketDateTo, int? centerId)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = ((prjTitleGroup != null) ? new ObjectParameter("PrjTitleGroup", prjTitleGroup) : new ObjectParameter("PrjTitleGroup", typeof(string)));
		ObjectParameter objectParameter6 = (currDateTime.HasValue ? new ObjectParameter("CurrDateTime", currDateTime) : new ObjectParameter("CurrDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (prjTitleGroupId.HasValue ? new ObjectParameter("PrjTitleGroupId", prjTitleGroupId) : new ObjectParameter("PrjTitleGroupId", typeof(int)));
		ObjectParameter objectParameter10 = (cnvsStatusGroupId.HasValue ? new ObjectParameter("CnvsStatusGroupId", cnvsStatusGroupId) : new ObjectParameter("CnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter11 = (cnvsStatusId.HasValue ? new ObjectParameter("CnvsStatusId", cnvsStatusId) : new ObjectParameter("CnvsStatusId", typeof(int)));
		ObjectParameter objectParameter12 = (priorityId.HasValue ? new ObjectParameter("PriorityId", priorityId) : new ObjectParameter("PriorityId", typeof(int)));
		ObjectParameter objectParameter13 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter14 = (closedTicketDate.HasValue ? new ObjectParameter("ClosedTicketDate", closedTicketDate) : new ObjectParameter("ClosedTicketDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = (closedTicketDateTo.HasValue ? new ObjectParameter("ClosedTicketDateTo", closedTicketDateTo) : new ObjectParameter("ClosedTicketDateTo", typeof(DateTime)));
		ObjectParameter objectParameter16 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsTicketCartable_Result>("MobspResultsTicketCartable", new ObjectParameter[16]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16
		});
	}

	public virtual ObjectResult<MobspSearchTicketWithProjectId_Result> MobspSearchTicketWithProjectId(int? projectId, int? userId, DateTime? currDateTime, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (currDateTime.HasValue ? new ObjectParameter("CurrDateTime", currDateTime) : new ObjectParameter("CurrDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSearchTicketWithProjectId_Result>("MobspSearchTicketWithProjectId", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectTicketDaily_Result> MobspSelectTicketDaily(DateTime? fromDate, DateTime? toDate, int? userId, int? lastRowNumber, int? pageSize, string prjTitleGroup, DateTime? currDateTime, int? languageID, int? defaultLanguageID, int? prjTitleGroupId, int? cnvsStatusGroupId, int? cnvsStatusId, int? priorityId, int? crmUserId, int? centerId)
	{
		ObjectParameter objectParameter = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter6 = ((prjTitleGroup != null) ? new ObjectParameter("PrjTitleGroup", prjTitleGroup) : new ObjectParameter("PrjTitleGroup", typeof(string)));
		ObjectParameter objectParameter7 = (currDateTime.HasValue ? new ObjectParameter("CurrDateTime", currDateTime) : new ObjectParameter("CurrDateTime", typeof(DateTime)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (prjTitleGroupId.HasValue ? new ObjectParameter("PrjTitleGroupId", prjTitleGroupId) : new ObjectParameter("PrjTitleGroupId", typeof(int)));
		ObjectParameter objectParameter11 = (cnvsStatusGroupId.HasValue ? new ObjectParameter("CnvsStatusGroupId", cnvsStatusGroupId) : new ObjectParameter("CnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter12 = (cnvsStatusId.HasValue ? new ObjectParameter("CnvsStatusId", cnvsStatusId) : new ObjectParameter("CnvsStatusId", typeof(int)));
		ObjectParameter objectParameter13 = (priorityId.HasValue ? new ObjectParameter("PriorityId", priorityId) : new ObjectParameter("PriorityId", typeof(int)));
		ObjectParameter objectParameter14 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTicketDaily_Result>("MobspSelectTicketDaily", new ObjectParameter[15]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15
		});
	}

	public virtual ObjectResult<MobspSelectTicketNotFinished_Result> MobspSelectTicketNotFinished(int? userId, int? lastRowNumber, int? pageSize, string prjTitleGroup, DateTime? currDateTime, int? languageID, int? defaultLanguageID, int? prjTitleGroupId, int? cnvsStatusGroupId, int? cnvsStatusId, int? priorityId, int? crmUserId, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (lastRowNumber.HasValue ? new ObjectParameter("LastRowNumber", lastRowNumber) : new ObjectParameter("LastRowNumber", typeof(int)));
		ObjectParameter objectParameter3 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter4 = ((prjTitleGroup != null) ? new ObjectParameter("PrjTitleGroup", prjTitleGroup) : new ObjectParameter("PrjTitleGroup", typeof(string)));
		ObjectParameter objectParameter5 = (currDateTime.HasValue ? new ObjectParameter("CurrDateTime", currDateTime) : new ObjectParameter("CurrDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (prjTitleGroupId.HasValue ? new ObjectParameter("PrjTitleGroupId", prjTitleGroupId) : new ObjectParameter("PrjTitleGroupId", typeof(int)));
		ObjectParameter objectParameter9 = (cnvsStatusGroupId.HasValue ? new ObjectParameter("CnvsStatusGroupId", cnvsStatusGroupId) : new ObjectParameter("CnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter10 = (cnvsStatusId.HasValue ? new ObjectParameter("CnvsStatusId", cnvsStatusId) : new ObjectParameter("CnvsStatusId", typeof(int)));
		ObjectParameter objectParameter11 = (priorityId.HasValue ? new ObjectParameter("PriorityId", priorityId) : new ObjectParameter("PriorityId", typeof(int)));
		ObjectParameter objectParameter12 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTicketNotFinished_Result>("MobspSelectTicketNotFinished", new ObjectParameter[13]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13
		});
	}

	public virtual int MobspUpdateConversationHappyVote(int? conversationId, int? happyVote, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID, ObjectParameter resultId)
	{
		ObjectParameter objectParameter = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter2 = (happyVote.HasValue ? new ObjectParameter("HappyVote", happyVote) : new ObjectParameter("HappyVote", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateConversationHappyVote", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, resultId);
	}

	public virtual int MobspInsertConversationAutoReplyAfterSetDoingTimeTicket(int? companyId, int? projectId, int? cnvsPersonId, int? currentConversationId, int? cnvsPriorityId, int? defaultUserId, int? cnvsReferUserId, DateTime? registerDate, string registerDatePersian, string registerDay, string registerTime, int? internalMessageYear, int? year1, int? month1, string appType, int? languageID, int? defaultLanguageID, string toDoTime, ObjectParameter errorMessage, ObjectParameter conversationId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = (cnvsPersonId.HasValue ? new ObjectParameter("CnvsPersonId", cnvsPersonId) : new ObjectParameter("CnvsPersonId", typeof(int)));
		ObjectParameter objectParameter4 = (currentConversationId.HasValue ? new ObjectParameter("CurrentConversationId", currentConversationId) : new ObjectParameter("CurrentConversationId", typeof(int)));
		ObjectParameter objectParameter5 = (cnvsPriorityId.HasValue ? new ObjectParameter("CnvsPriorityId", cnvsPriorityId) : new ObjectParameter("CnvsPriorityId", typeof(int)));
		ObjectParameter objectParameter6 = (defaultUserId.HasValue ? new ObjectParameter("DefaultUserId", defaultUserId) : new ObjectParameter("DefaultUserId", typeof(int)));
		ObjectParameter objectParameter7 = (cnvsReferUserId.HasValue ? new ObjectParameter("CnvsReferUserId", cnvsReferUserId) : new ObjectParameter("CnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((registerDay != null) ? new ObjectParameter("RegisterDay", registerDay) : new ObjectParameter("RegisterDay", typeof(string)));
		ObjectParameter objectParameter11 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter12 = (internalMessageYear.HasValue ? new ObjectParameter("InternalMessageYear", internalMessageYear) : new ObjectParameter("InternalMessageYear", typeof(int)));
		ObjectParameter objectParameter13 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter15 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter16 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter17 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter18 = ((toDoTime != null) ? new ObjectParameter("ToDoTime", toDoTime) : new ObjectParameter("ToDoTime", typeof(string)));
		ObjectParameter objectParameter19 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertConversationAutoReplyAfterSetDoingTimeTicket", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, errorMessage, conversationId, objectParameter19);
	}

	public virtual ObjectResult<MobspSelectUserMobImeiCode_Result> MobspSelectUserMobImeiCode(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserMobImeiCode_Result>("MobspSelectUserMobImeiCode", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectProductColor_Result> MobspSelectProductColor(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProductColor_Result>("MobspSelectProductColor", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspInsertCallHistory(int? callTypeId, int? lineNumber, string phoneNumber, int? companyID, string callTime, string callDate, string callDay, int? userID, short? year1, short? month1, string registerDatePersian, string startTime, string endTime, string duration, int? companyPersonID, string recFileName, string data, string appType, int? defaultLanguageID, string trunkCallId, string trunkName, string trunkSource, string trunkDestination, string trunkFileLocation, string trunkDestinationCycle, string preRecFileName, int? devType)
	{
		ObjectParameter objectParameter = (callTypeId.HasValue ? new ObjectParameter("CallTypeId", callTypeId) : new ObjectParameter("CallTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (lineNumber.HasValue ? new ObjectParameter("LineNumber", lineNumber) : new ObjectParameter("LineNumber", typeof(int)));
		ObjectParameter objectParameter3 = ((phoneNumber != null) ? new ObjectParameter("PhoneNumber", phoneNumber) : new ObjectParameter("PhoneNumber", typeof(string)));
		ObjectParameter objectParameter4 = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter5 = ((callTime != null) ? new ObjectParameter("CallTime", callTime) : new ObjectParameter("CallTime", typeof(string)));
		ObjectParameter objectParameter6 = ((callDate != null) ? new ObjectParameter("CallDate", callDate) : new ObjectParameter("CallDate", typeof(string)));
		ObjectParameter objectParameter7 = ((callDay != null) ? new ObjectParameter("CallDay", callDay) : new ObjectParameter("CallDay", typeof(string)));
		ObjectParameter objectParameter8 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter9 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((startTime != null) ? new ObjectParameter("StartTime", startTime) : new ObjectParameter("StartTime", typeof(string)));
		ObjectParameter objectParameter13 = ((endTime != null) ? new ObjectParameter("EndTime", endTime) : new ObjectParameter("EndTime", typeof(string)));
		ObjectParameter objectParameter14 = ((duration != null) ? new ObjectParameter("Duration", duration) : new ObjectParameter("Duration", typeof(string)));
		ObjectParameter objectParameter15 = (companyPersonID.HasValue ? new ObjectParameter("CompanyPersonID", companyPersonID) : new ObjectParameter("CompanyPersonID", typeof(int)));
		ObjectParameter objectParameter16 = ((recFileName != null) ? new ObjectParameter("RecFileName", recFileName) : new ObjectParameter("RecFileName", typeof(string)));
		ObjectParameter objectParameter17 = ((data != null) ? new ObjectParameter("Data", data) : new ObjectParameter("Data", typeof(string)));
		ObjectParameter objectParameter18 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter19 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter20 = ((trunkCallId != null) ? new ObjectParameter("TrunkCallId", trunkCallId) : new ObjectParameter("TrunkCallId", typeof(string)));
		ObjectParameter objectParameter21 = ((trunkName != null) ? new ObjectParameter("TrunkName", trunkName) : new ObjectParameter("TrunkName", typeof(string)));
		ObjectParameter objectParameter22 = ((trunkSource != null) ? new ObjectParameter("TrunkSource", trunkSource) : new ObjectParameter("TrunkSource", typeof(string)));
		ObjectParameter objectParameter23 = ((trunkDestination != null) ? new ObjectParameter("TrunkDestination", trunkDestination) : new ObjectParameter("TrunkDestination", typeof(string)));
		ObjectParameter objectParameter24 = ((trunkFileLocation != null) ? new ObjectParameter("TrunkFileLocation", trunkFileLocation) : new ObjectParameter("TrunkFileLocation", typeof(string)));
		ObjectParameter objectParameter25 = ((trunkDestinationCycle != null) ? new ObjectParameter("TrunkDestinationCycle", trunkDestinationCycle) : new ObjectParameter("TrunkDestinationCycle", typeof(string)));
		ObjectParameter objectParameter26 = ((preRecFileName != null) ? new ObjectParameter("PreRecFileName", preRecFileName) : new ObjectParameter("PreRecFileName", typeof(string)));
		ObjectParameter objectParameter27 = (devType.HasValue ? new ObjectParameter("DevType", devType) : new ObjectParameter("DevType", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertCallHistory", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27);
	}

	public virtual int MobspAutoSendSMSFromCallerID(int? companyId, int? companyPersonId, string mobileNumber, string appType, int? defaultLanguageID, int? sendNeedCheck)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((mobileNumber != null) ? new ObjectParameter("MobileNumber", mobileNumber) : new ObjectParameter("MobileNumber", typeof(string)));
		ObjectParameter objectParameter4 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (sendNeedCheck.HasValue ? new ObjectParameter("SendNeedCheck", sendNeedCheck) : new ObjectParameter("SendNeedCheck", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspAutoSendSMSFromCallerID", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual ObjectResult<MobspCallerIDSearch_Result> MobspCallerIDSearch(string phoneNumber, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((phoneNumber != null) ? new ObjectParameter("PhoneNumber", phoneNumber) : new ObjectParameter("PhoneNumber", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspCallerIDSearch_Result>("MobspCallerIDSearch", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateProjectToDoTime(int? projectId, int? prjToDoTimeYear, int? prjToDoTimeMonth, int? prjToDoTimeDay, int? prjToDoTimeHour, int? prjToDoTimeMinute, DateTime? prjToDoTimeRegister, bool? prjIsTicketNew, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, bool? allowUpdateConversation, int? conversationId, int? cnvsUserId, int? cnvsReferUserId, string cnvsReferDesc, int? cnvsPriorityId, ObjectParameter result, int? autoReplyCnvsId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (prjToDoTimeYear.HasValue ? new ObjectParameter("PrjToDoTimeYear", prjToDoTimeYear) : new ObjectParameter("PrjToDoTimeYear", typeof(int)));
		ObjectParameter objectParameter3 = (prjToDoTimeMonth.HasValue ? new ObjectParameter("PrjToDoTimeMonth", prjToDoTimeMonth) : new ObjectParameter("PrjToDoTimeMonth", typeof(int)));
		ObjectParameter objectParameter4 = (prjToDoTimeDay.HasValue ? new ObjectParameter("PrjToDoTimeDay", prjToDoTimeDay) : new ObjectParameter("PrjToDoTimeDay", typeof(int)));
		ObjectParameter objectParameter5 = (prjToDoTimeHour.HasValue ? new ObjectParameter("PrjToDoTimeHour", prjToDoTimeHour) : new ObjectParameter("PrjToDoTimeHour", typeof(int)));
		ObjectParameter objectParameter6 = (prjToDoTimeMinute.HasValue ? new ObjectParameter("PrjToDoTimeMinute", prjToDoTimeMinute) : new ObjectParameter("PrjToDoTimeMinute", typeof(int)));
		ObjectParameter objectParameter7 = (prjToDoTimeRegister.HasValue ? new ObjectParameter("PrjToDoTimeRegister", prjToDoTimeRegister) : new ObjectParameter("PrjToDoTimeRegister", typeof(DateTime)));
		ObjectParameter objectParameter8 = (prjIsTicketNew.HasValue ? new ObjectParameter("prjIsTicketNew", prjIsTicketNew) : new ObjectParameter("prjIsTicketNew", typeof(bool)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter11 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (allowUpdateConversation.HasValue ? new ObjectParameter("AllowUpdateConversation", allowUpdateConversation) : new ObjectParameter("AllowUpdateConversation", typeof(bool)));
		ObjectParameter objectParameter15 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter16 = (cnvsUserId.HasValue ? new ObjectParameter("cnvsUserId", cnvsUserId) : new ObjectParameter("cnvsUserId", typeof(int)));
		ObjectParameter objectParameter17 = (cnvsReferUserId.HasValue ? new ObjectParameter("cnvsReferUserId", cnvsReferUserId) : new ObjectParameter("cnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter18 = ((cnvsReferDesc != null) ? new ObjectParameter("cnvsReferDesc", cnvsReferDesc) : new ObjectParameter("cnvsReferDesc", typeof(string)));
		ObjectParameter objectParameter19 = (cnvsPriorityId.HasValue ? new ObjectParameter("cnvsPriorityId", cnvsPriorityId) : new ObjectParameter("cnvsPriorityId", typeof(int)));
		ObjectParameter objectParameter20 = (autoReplyCnvsId.HasValue ? new ObjectParameter("AutoReplyCnvsId", autoReplyCnvsId) : new ObjectParameter("AutoReplyCnvsId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateProjectToDoTime", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, result, objectParameter20);
	}

	public virtual ObjectResult<int?> FOMobspDyUpdateFormFieldMasterValues(int? masterValueId, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("FOMobspDyUpdateFormFieldMasterValues", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<FOMobspDySelectFilesDirectory_Result> FOMobspDySelectFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, string typeOprObjectIdI, string typeOprObjectIdII, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((masterId != null) ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(string)));
		ObjectParameter objectParameter2 = ((detailId != null) ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(string)));
		ObjectParameter objectParameter3 = ((subDetailId != null) ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(string)));
		ObjectParameter objectParameter4 = ((fileDirectoryTypeOprId != null) ? new ObjectParameter("FileDirectoryTypeOprId", fileDirectoryTypeOprId) : new ObjectParameter("FileDirectoryTypeOprId", typeof(string)));
		ObjectParameter objectParameter5 = ((typeOprObjectId != null) ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(string)));
		ObjectParameter objectParameter6 = ((typeOprObjectIdI != null) ? new ObjectParameter("TypeOprObjectIdI", typeOprObjectIdI) : new ObjectParameter("TypeOprObjectIdI", typeof(string)));
		ObjectParameter objectParameter7 = ((typeOprObjectIdII != null) ? new ObjectParameter("TypeOprObjectIdII", typeOprObjectIdII) : new ObjectParameter("TypeOprObjectIdII", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFilesDirectory_Result>("FOMobspDySelectFilesDirectory", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<mct_Result> FOMobspDyUpdateToDeleteFormFieldMasterValue(int? masterValueId, int? deletedUserId, DateTime? deletedDate, string deletedDatePersian)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (deletedUserId.HasValue ? new ObjectParameter("DeletedUserId", deletedUserId) : new ObjectParameter("DeletedUserId", typeof(int)));
		ObjectParameter objectParameter3 = (deletedDate.HasValue ? new ObjectParameter("DeletedDate", deletedDate) : new ObjectParameter("DeletedDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((deletedDatePersian != null) ? new ObjectParameter("DeletedDatePersian", deletedDatePersian) : new ObjectParameter("DeletedDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("FOMobspDyUpdateToDeleteFormFieldMasterValue", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyQuickRegisterDefSetting_Result> MobspSelectCompanyQuickRegisterDefSetting(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyQuickRegisterDefSetting_Result>("MobspSelectCompanyQuickRegisterDefSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<FOMobspSelectCrmFilesDirectoryWithId_Result> FOMobspSelectCrmFilesDirectoryWithId(int? fileDirectoryId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspSelectCrmFilesDirectoryWithId_Result>("FOMobspSelectCrmFilesDirectoryWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<FOMobspDySelectFormsWithSysPartId_Result> FOMobspDySelectFormsWithSysPartId(int? fOSysPartId, int? companyId, int? userId, int? languageID, int? defaultLanguageID, int? companyPersonId, int? centerId)
	{
		ObjectParameter objectParameter = (fOSysPartId.HasValue ? new ObjectParameter("FOSysPartId", fOSysPartId) : new ObjectParameter("FOSysPartId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FOMobspDySelectFormsWithSysPartId_Result>("FOMobspDySelectFormsWithSysPartId", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectConversationTopics_Result> MobspSelectConversationTopics(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationTopics_Result>("MobspSelectConversationTopics", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectPreOrderItems_Result> MobspSelectPreOrderItems(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderItems_Result>("MobspSelectPreOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<mct_Result> MobspCheckPreOrderHaveOrder(int? preOrderId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspCheckPreOrderHaveOrder", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnOrderFromPreOrder_Result> MobspReturnOrderFromPreOrder(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnOrderFromPreOrder_Result>("MobspReturnOrderFromPreOrder", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspControlPreOrderItemsStock_Result> MobspControlPreOrderItemsStock(int? preOrderId, int? languageID, int? defaultLanguageID, string pordItemList, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = ((pordItemList != null) ? new ObjectParameter("PordItemList", pordItemList) : new ObjectParameter("PordItemList", typeof(string)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspControlPreOrderItemsStock_Result>("MobspControlPreOrderItemsStock", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int MobspTransferPreOrderFileToOrderOneToOne(int? preOrderId, int? orderId, int? fileDirectoryId, int? fileDirectoryTypeId, int? userId, int? fPId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageId, ObjectParameter insertedId, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter3 = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		ObjectParameter objectParameter4 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageId.HasValue ? new ObjectParameter("LanguageId", languageId) : new ObjectParameter("LanguageId", typeof(int)));
		ObjectParameter objectParameter13 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspTransferPreOrderFileToOrderOneToOne", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedId, objectParameter13);
	}

	public virtual ObjectResult<MobspReturnOrderItemQuantityByPordItemId_Result> MobspReturnOrderItemQuantityByPordItemId(int? preOrdItemId)
	{
		ObjectParameter objectParameter = (preOrdItemId.HasValue ? new ObjectParameter("PreOrdItemId", preOrdItemId) : new ObjectParameter("PreOrdItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnOrderItemQuantityByPordItemId_Result>("MobspReturnOrderItemQuantityByPordItemId", new ObjectParameter[1] { objectParameter });
	}

	public virtual int MobspDistributeDiscountToOrderItems(int? orderId, string orderItemIds, decimal? discount, decimal? discountPercent, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result, int? languageID, int? defaultLanguageID, bool? addToDiscount, int? discountCodeId, int? centerId)
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
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (addToDiscount.HasValue ? new ObjectParameter("AddToDiscount", addToDiscount) : new ObjectParameter("AddToDiscount", typeof(bool)));
		ObjectParameter objectParameter14 = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDistributeDiscountToOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15);
	}

	public virtual int MobspDistributeDiscountToPreOrderItems(int? preOrderId, string preOrderItemIds, decimal? discount, decimal? discountPercent, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result, int? languageID, int? defaultLanguageID, bool? addToDiscount, int? discountCodeId, int? centerId)
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
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (addToDiscount.HasValue ? new ObjectParameter("AddToDiscount", addToDiscount) : new ObjectParameter("AddToDiscount", typeof(bool)));
		ObjectParameter objectParameter14 = (discountCodeId.HasValue ? new ObjectParameter("DiscountCodeId", discountCodeId) : new ObjectParameter("DiscountCodeId", typeof(int)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDistributeDiscountToPreOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15);
	}

	public virtual int MobspDistributeTaxToOrderItems(int? orderId, string orderItemIds, decimal? tax, decimal? taxIndex, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result, int? languageID, int? defaultLanguageID, bool? addToTax)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((orderItemIds != null) ? new ObjectParameter("OrderItemIds", orderItemIds) : new ObjectParameter("OrderItemIds", typeof(string)));
		ObjectParameter objectParameter3 = (tax.HasValue ? new ObjectParameter("Tax", tax) : new ObjectParameter("Tax", typeof(decimal)));
		ObjectParameter objectParameter4 = (taxIndex.HasValue ? new ObjectParameter("TaxIndex", taxIndex) : new ObjectParameter("TaxIndex", typeof(decimal)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (addToTax.HasValue ? new ObjectParameter("AddToTax", addToTax) : new ObjectParameter("AddToTax", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDistributeTaxToOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual int MobspDistributeTaxToPreOrderItems(int? preOrderId, string preOrderItemIds, decimal? tax, decimal? taxIndex, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result, int? languageID, int? defaultLanguageID, bool? addToTax)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = ((preOrderItemIds != null) ? new ObjectParameter("PreOrderItemIds", preOrderItemIds) : new ObjectParameter("PreOrderItemIds", typeof(string)));
		ObjectParameter objectParameter3 = (tax.HasValue ? new ObjectParameter("Tax", tax) : new ObjectParameter("Tax", typeof(decimal)));
		ObjectParameter objectParameter4 = (taxIndex.HasValue ? new ObjectParameter("TaxIndex", taxIndex) : new ObjectParameter("TaxIndex", typeof(decimal)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter10 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter11 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (addToTax.HasValue ? new ObjectParameter("AddToTax", addToTax) : new ObjectParameter("AddToTax", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDistributeTaxToPreOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, result, objectParameter11, objectParameter12, objectParameter13);
	}

	public virtual ObjectResult<MobspSelectUserTasksRepeats_Result> MobspSelectUserTasksRepeats(int? userId, DateTime? currDate, int? languageID, int? defaultLanguageID, int? centerId, int? userTaskGroupId, int? userTaskPriorityId, int? userTaskDidItStatus, int? crmUserId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (currDate.HasValue ? new ObjectParameter("CurrDate", currDate) : new ObjectParameter("CurrDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter6 = (userTaskGroupId.HasValue ? new ObjectParameter("UserTaskGroupId", userTaskGroupId) : new ObjectParameter("UserTaskGroupId", typeof(int)));
		ObjectParameter objectParameter7 = (userTaskPriorityId.HasValue ? new ObjectParameter("UserTaskPriorityId", userTaskPriorityId) : new ObjectParameter("UserTaskPriorityId", typeof(int)));
		ObjectParameter objectParameter8 = (userTaskDidItStatus.HasValue ? new ObjectParameter("UserTaskDidItStatus", userTaskDidItStatus) : new ObjectParameter("UserTaskDidItStatus", typeof(int)));
		ObjectParameter objectParameter9 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserTasksRepeats_Result>("MobspSelectUserTasksRepeats", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspSelectUserTaskWithID_Result> MobspSelectUserTaskWithID(int? userTaskId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserTaskWithID_Result>("MobspSelectUserTaskWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspUpdateUserTaskDidIt(int? userTaskId, bool? state, int? userId, short? month1, short? year1, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		ObjectParameter objectParameter2 = (state.HasValue ? new ObjectParameter("State", state) : new ObjectParameter("State", typeof(bool)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateUserTaskDidIt", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<int?> MobspInsertCrmUserTasks(string userTaskDatePersian, string userTaskTime, DateTime? userTaskDate, string userTaskTitle, string userTaskDescription, int? userTaskPriorityId, int? userTaskGroupId, int? userTaskShowAllarm, bool? userTaskDidIt, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string userTaskRemindDate, string userTaskRemindTime, DateTime? userTaskRemindDateTime, bool? userTaskIsPublic, string firstRegisterDatePersian, DateTime? firstRegisterDate, string appType, int? languageID, string userTaskTimeEnd, int? objectTypeId, int? objectId, bool? userTaskNoTimeOverlap, string userTaskCompanyIds, bool? userTaskRepeatDaily, bool? userTaskRepeatWeekly, bool? userTaskRepeatMonthly, bool? userTaskRepeatYearly, bool? userTaskRemindRepeatDaily, bool? userTaskRemindRepeatWeekly, bool? userTaskRemindRepeatMonthly, bool? userTaskRemindRepeatYearly, int? userTaskUserId, ObjectParameter insertedUserTaskId, int? centerId, string userTaskDateEndPersian, DateTime? userTaskDateEnd)
	{
		ObjectParameter objectParameter = ((userTaskDatePersian != null) ? new ObjectParameter("UserTaskDatePersian", userTaskDatePersian) : new ObjectParameter("UserTaskDatePersian", typeof(string)));
		ObjectParameter objectParameter2 = ((userTaskTime != null) ? new ObjectParameter("UserTaskTime", userTaskTime) : new ObjectParameter("UserTaskTime", typeof(string)));
		ObjectParameter objectParameter3 = (userTaskDate.HasValue ? new ObjectParameter("UserTaskDate", userTaskDate) : new ObjectParameter("UserTaskDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((userTaskTitle != null) ? new ObjectParameter("UserTaskTitle", userTaskTitle) : new ObjectParameter("UserTaskTitle", typeof(string)));
		ObjectParameter objectParameter5 = ((userTaskDescription != null) ? new ObjectParameter("UserTaskDescription", userTaskDescription) : new ObjectParameter("UserTaskDescription", typeof(string)));
		ObjectParameter objectParameter6 = (userTaskPriorityId.HasValue ? new ObjectParameter("UserTaskPriorityId", userTaskPriorityId) : new ObjectParameter("UserTaskPriorityId", typeof(int)));
		ObjectParameter objectParameter7 = (userTaskGroupId.HasValue ? new ObjectParameter("UserTaskGroupId", userTaskGroupId) : new ObjectParameter("UserTaskGroupId", typeof(int)));
		ObjectParameter objectParameter8 = (userTaskShowAllarm.HasValue ? new ObjectParameter("UserTaskShowAllarm", userTaskShowAllarm) : new ObjectParameter("UserTaskShowAllarm", typeof(int)));
		ObjectParameter objectParameter9 = (userTaskDidIt.HasValue ? new ObjectParameter("UserTaskDidIt", userTaskDidIt) : new ObjectParameter("UserTaskDidIt", typeof(bool)));
		ObjectParameter objectParameter10 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter11 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter12 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter13 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter14 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter15 = ((userTaskRemindDate != null) ? new ObjectParameter("UserTaskRemindDate", userTaskRemindDate) : new ObjectParameter("UserTaskRemindDate", typeof(string)));
		ObjectParameter objectParameter16 = ((userTaskRemindTime != null) ? new ObjectParameter("UserTaskRemindTime", userTaskRemindTime) : new ObjectParameter("UserTaskRemindTime", typeof(string)));
		ObjectParameter objectParameter17 = (userTaskRemindDateTime.HasValue ? new ObjectParameter("UserTaskRemindDateTime", userTaskRemindDateTime) : new ObjectParameter("UserTaskRemindDateTime", typeof(DateTime)));
		ObjectParameter objectParameter18 = (userTaskIsPublic.HasValue ? new ObjectParameter("UserTaskIsPublic", userTaskIsPublic) : new ObjectParameter("UserTaskIsPublic", typeof(bool)));
		ObjectParameter objectParameter19 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter20 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter21 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter22 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter23 = ((userTaskTimeEnd != null) ? new ObjectParameter("UserTaskTimeEnd", userTaskTimeEnd) : new ObjectParameter("UserTaskTimeEnd", typeof(string)));
		ObjectParameter objectParameter24 = (objectTypeId.HasValue ? new ObjectParameter("ObjectTypeId", objectTypeId) : new ObjectParameter("ObjectTypeId", typeof(int)));
		ObjectParameter objectParameter25 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter26 = (userTaskNoTimeOverlap.HasValue ? new ObjectParameter("UserTaskNoTimeOverlap", userTaskNoTimeOverlap) : new ObjectParameter("UserTaskNoTimeOverlap", typeof(bool)));
		ObjectParameter objectParameter27 = ((userTaskCompanyIds != null) ? new ObjectParameter("UserTaskCompanyIds", userTaskCompanyIds) : new ObjectParameter("UserTaskCompanyIds", typeof(string)));
		ObjectParameter objectParameter28 = (userTaskRepeatDaily.HasValue ? new ObjectParameter("UserTaskRepeatDaily", userTaskRepeatDaily) : new ObjectParameter("UserTaskRepeatDaily", typeof(bool)));
		ObjectParameter objectParameter29 = (userTaskRepeatWeekly.HasValue ? new ObjectParameter("UserTaskRepeatWeekly", userTaskRepeatWeekly) : new ObjectParameter("UserTaskRepeatWeekly", typeof(bool)));
		ObjectParameter objectParameter30 = (userTaskRepeatMonthly.HasValue ? new ObjectParameter("UserTaskRepeatMonthly", userTaskRepeatMonthly) : new ObjectParameter("UserTaskRepeatMonthly", typeof(bool)));
		ObjectParameter objectParameter31 = (userTaskRepeatYearly.HasValue ? new ObjectParameter("UserTaskRepeatYearly", userTaskRepeatYearly) : new ObjectParameter("UserTaskRepeatYearly", typeof(bool)));
		ObjectParameter objectParameter32 = (userTaskRemindRepeatDaily.HasValue ? new ObjectParameter("UserTaskRemindRepeatDaily", userTaskRemindRepeatDaily) : new ObjectParameter("UserTaskRemindRepeatDaily", typeof(bool)));
		ObjectParameter objectParameter33 = (userTaskRemindRepeatWeekly.HasValue ? new ObjectParameter("UserTaskRemindRepeatWeekly", userTaskRemindRepeatWeekly) : new ObjectParameter("UserTaskRemindRepeatWeekly", typeof(bool)));
		ObjectParameter objectParameter34 = (userTaskRemindRepeatMonthly.HasValue ? new ObjectParameter("UserTaskRemindRepeatMonthly", userTaskRemindRepeatMonthly) : new ObjectParameter("UserTaskRemindRepeatMonthly", typeof(bool)));
		ObjectParameter objectParameter35 = (userTaskRemindRepeatYearly.HasValue ? new ObjectParameter("UserTaskRemindRepeatYearly", userTaskRemindRepeatYearly) : new ObjectParameter("UserTaskRemindRepeatYearly", typeof(bool)));
		ObjectParameter objectParameter36 = (userTaskUserId.HasValue ? new ObjectParameter("UserTaskUserId", userTaskUserId) : new ObjectParameter("UserTaskUserId", typeof(int)));
		ObjectParameter objectParameter37 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter38 = ((userTaskDateEndPersian != null) ? new ObjectParameter("UserTaskDateEndPersian", userTaskDateEndPersian) : new ObjectParameter("UserTaskDateEndPersian", typeof(string)));
		ObjectParameter objectParameter39 = (userTaskDateEnd.HasValue ? new ObjectParameter("UserTaskDateEnd", userTaskDateEnd) : new ObjectParameter("UserTaskDateEnd", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertCrmUserTasks", new ObjectParameter[40]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, insertedUserTaskId, objectParameter37, objectParameter38, objectParameter39
		});
	}

	public virtual ObjectResult<int?> MobspUpdateCrmUserTasks(int? userTaskId, string userTaskDatePersian, DateTime? userTaskDate, string userTaskTime, string userTaskTitle, string userTaskDescription, int? userTaskPriorityId, int? userTaskGroupId, int? userTaskShowAllarm, bool? userTaskDidIt, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string userTaskRemindDate, string userTaskRemindTime, DateTime? userTaskRemindDateTime, bool? userTaskIsPublic, string appType, int? defaultLanguageID, string userTaskTimeEnd, int? objectTypeId, int? objectId, bool? userTaskNoTimeOverlap, string userTaskCompanyIds, bool? userTaskRepeatDaily, bool? userTaskRepeatWeekly, bool? userTaskRepeatMonthly, bool? userTaskRepeatYearly, bool? userTaskRemindRepeatDaily, bool? userTaskRemindRepeatWeekly, bool? userTaskRemindRepeatMonthly, bool? userTaskRemindRepeatYearly, int? userTaskUserId, ObjectParameter updatedUserTaskId, ObjectParameter errorMessage, string userTaskDateEndPersian, DateTime? userTaskDateEnd)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		ObjectParameter objectParameter2 = ((userTaskDatePersian != null) ? new ObjectParameter("UserTaskDatePersian", userTaskDatePersian) : new ObjectParameter("UserTaskDatePersian", typeof(string)));
		ObjectParameter objectParameter3 = (userTaskDate.HasValue ? new ObjectParameter("UserTaskDate", userTaskDate) : new ObjectParameter("UserTaskDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((userTaskTime != null) ? new ObjectParameter("UserTaskTime", userTaskTime) : new ObjectParameter("UserTaskTime", typeof(string)));
		ObjectParameter objectParameter5 = ((userTaskTitle != null) ? new ObjectParameter("UserTaskTitle", userTaskTitle) : new ObjectParameter("UserTaskTitle", typeof(string)));
		ObjectParameter objectParameter6 = ((userTaskDescription != null) ? new ObjectParameter("UserTaskDescription", userTaskDescription) : new ObjectParameter("UserTaskDescription", typeof(string)));
		ObjectParameter objectParameter7 = (userTaskPriorityId.HasValue ? new ObjectParameter("UserTaskPriorityId", userTaskPriorityId) : new ObjectParameter("UserTaskPriorityId", typeof(int)));
		ObjectParameter objectParameter8 = (userTaskGroupId.HasValue ? new ObjectParameter("UserTaskGroupId", userTaskGroupId) : new ObjectParameter("UserTaskGroupId", typeof(int)));
		ObjectParameter objectParameter9 = (userTaskShowAllarm.HasValue ? new ObjectParameter("UserTaskShowAllarm", userTaskShowAllarm) : new ObjectParameter("UserTaskShowAllarm", typeof(int)));
		ObjectParameter objectParameter10 = (userTaskDidIt.HasValue ? new ObjectParameter("UserTaskDidIt", userTaskDidIt) : new ObjectParameter("UserTaskDidIt", typeof(bool)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = ((userTaskRemindDate != null) ? new ObjectParameter("UserTaskRemindDate", userTaskRemindDate) : new ObjectParameter("UserTaskRemindDate", typeof(string)));
		ObjectParameter objectParameter17 = ((userTaskRemindTime != null) ? new ObjectParameter("UserTaskRemindTime", userTaskRemindTime) : new ObjectParameter("UserTaskRemindTime", typeof(string)));
		ObjectParameter objectParameter18 = (userTaskRemindDateTime.HasValue ? new ObjectParameter("UserTaskRemindDateTime", userTaskRemindDateTime) : new ObjectParameter("UserTaskRemindDateTime", typeof(DateTime)));
		ObjectParameter objectParameter19 = (userTaskIsPublic.HasValue ? new ObjectParameter("UserTaskIsPublic", userTaskIsPublic) : new ObjectParameter("UserTaskIsPublic", typeof(bool)));
		ObjectParameter objectParameter20 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter21 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter22 = ((userTaskTimeEnd != null) ? new ObjectParameter("UserTaskTimeEnd", userTaskTimeEnd) : new ObjectParameter("UserTaskTimeEnd", typeof(string)));
		ObjectParameter objectParameter23 = (objectTypeId.HasValue ? new ObjectParameter("ObjectTypeId", objectTypeId) : new ObjectParameter("ObjectTypeId", typeof(int)));
		ObjectParameter objectParameter24 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter25 = (userTaskNoTimeOverlap.HasValue ? new ObjectParameter("UserTaskNoTimeOverlap", userTaskNoTimeOverlap) : new ObjectParameter("UserTaskNoTimeOverlap", typeof(bool)));
		ObjectParameter objectParameter26 = ((userTaskCompanyIds != null) ? new ObjectParameter("UserTaskCompanyIds", userTaskCompanyIds) : new ObjectParameter("UserTaskCompanyIds", typeof(string)));
		ObjectParameter objectParameter27 = (userTaskRepeatDaily.HasValue ? new ObjectParameter("UserTaskRepeatDaily", userTaskRepeatDaily) : new ObjectParameter("UserTaskRepeatDaily", typeof(bool)));
		ObjectParameter objectParameter28 = (userTaskRepeatWeekly.HasValue ? new ObjectParameter("UserTaskRepeatWeekly", userTaskRepeatWeekly) : new ObjectParameter("UserTaskRepeatWeekly", typeof(bool)));
		ObjectParameter objectParameter29 = (userTaskRepeatMonthly.HasValue ? new ObjectParameter("UserTaskRepeatMonthly", userTaskRepeatMonthly) : new ObjectParameter("UserTaskRepeatMonthly", typeof(bool)));
		ObjectParameter objectParameter30 = (userTaskRepeatYearly.HasValue ? new ObjectParameter("UserTaskRepeatYearly", userTaskRepeatYearly) : new ObjectParameter("UserTaskRepeatYearly", typeof(bool)));
		ObjectParameter objectParameter31 = (userTaskRemindRepeatDaily.HasValue ? new ObjectParameter("UserTaskRemindRepeatDaily", userTaskRemindRepeatDaily) : new ObjectParameter("UserTaskRemindRepeatDaily", typeof(bool)));
		ObjectParameter objectParameter32 = (userTaskRemindRepeatWeekly.HasValue ? new ObjectParameter("UserTaskRemindRepeatWeekly", userTaskRemindRepeatWeekly) : new ObjectParameter("UserTaskRemindRepeatWeekly", typeof(bool)));
		ObjectParameter objectParameter33 = (userTaskRemindRepeatMonthly.HasValue ? new ObjectParameter("UserTaskRemindRepeatMonthly", userTaskRemindRepeatMonthly) : new ObjectParameter("UserTaskRemindRepeatMonthly", typeof(bool)));
		ObjectParameter objectParameter34 = (userTaskRemindRepeatYearly.HasValue ? new ObjectParameter("UserTaskRemindRepeatYearly", userTaskRemindRepeatYearly) : new ObjectParameter("UserTaskRemindRepeatYearly", typeof(bool)));
		ObjectParameter objectParameter35 = (userTaskUserId.HasValue ? new ObjectParameter("UserTaskUserId", userTaskUserId) : new ObjectParameter("UserTaskUserId", typeof(int)));
		ObjectParameter objectParameter36 = ((userTaskDateEndPersian != null) ? new ObjectParameter("UserTaskDateEndPersian", userTaskDateEndPersian) : new ObjectParameter("UserTaskDateEndPersian", typeof(string)));
		ObjectParameter objectParameter37 = (userTaskDateEnd.HasValue ? new ObjectParameter("UserTaskDateEnd", userTaskDateEnd) : new ObjectParameter("UserTaskDateEnd", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspUpdateCrmUserTasks", new ObjectParameter[39]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, updatedUserTaskId, errorMessage, objectParameter36, objectParameter37
		});
	}

	public virtual ObjectResult<int?> MobspCheckUserTaskTimeOverlap(int? userTaskId, DateTime? date, string startTime, string endTime, int? userId)
	{
		ObjectParameter objectParameter = (userTaskId.HasValue ? new ObjectParameter("UserTaskId", userTaskId) : new ObjectParameter("UserTaskId", typeof(int)));
		ObjectParameter objectParameter2 = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((startTime != null) ? new ObjectParameter("StartTime", startTime) : new ObjectParameter("StartTime", typeof(string)));
		ObjectParameter objectParameter4 = ((endTime != null) ? new ObjectParameter("EndTime", endTime) : new ObjectParameter("EndTime", typeof(string)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspCheckUserTaskTimeOverlap", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectUserTaskGroups_Result> MobspSelectUserTaskGroups(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserTaskGroups_Result>("MobspSelectUserTaskGroups", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectUserTaskPriorities_Result> MobspSelectUserTaskPriorities(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserTaskPriorities_Result>("MobspSelectUserTaskPriorities", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<CRMspSelectLinkAccHolooSetting_Result> CRMspSelectLinkAccHolooSetting(int? linkAccHolooSettingId, string objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (linkAccHolooSettingId.HasValue ? new ObjectParameter("LinkAccHolooSettingId", linkAccHolooSettingId) : new ObjectParameter("LinkAccHolooSettingId", typeof(int)));
		ObjectParameter objectParameter2 = ((objectType != null) ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectLinkAccHolooSetting_Result>("CRMspSelectLinkAccHolooSetting", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyAccLinkFields_Result> MobspSelectCompanyAccLinkFields(int? companyId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyAccLinkFields_Result>("MobspSelectCompanyAccLinkFields", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectProjectsList_Result> MobspSelectProjectsList(int? companyID, int? isFinished, int? userID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyID.HasValue ? new ObjectParameter("CompanyID", companyID) : new ObjectParameter("CompanyID", typeof(int)));
		ObjectParameter objectParameter2 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(int)));
		ObjectParameter objectParameter3 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectsList_Result>("MobspSelectProjectsList", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectProjectWithID_Result> MobspSelectProjectWithID(int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectWithID_Result>("MobspSelectProjectWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectCompanyLetters_Result> MobspSelectCompanyLetters(int? companyId, int? letterTypeId, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId, int? userId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (letterTypeId.HasValue ? new ObjectParameter("LetterTypeId", letterTypeId) : new ObjectParameter("LetterTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter4 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyLetters_Result>("MobspSelectCompanyLetters", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<HRMMobspSelectTimeAttendanceBase_Result> HRMMobspSelectTimeAttendanceBase()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectTimeAttendanceBase_Result>("HRMMobspSelectTimeAttendanceBase", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<HRMMobspSelectTimeAttendanceByDate_Result> HRMMobspSelectTimeAttendanceByDate(DateTime? date, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectTimeAttendanceByDate_Result>("HRMMobspSelectTimeAttendanceByDate", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<HRMMobspSelectTimeAttendanceRequest_Result> HRMMobspSelectTimeAttendanceRequest(int? requestId, int? requestTypeId, int? userId, string date, int? verifyStatus)
	{
		ObjectParameter objectParameter = (requestId.HasValue ? new ObjectParameter("RequestId", requestId) : new ObjectParameter("RequestId", typeof(int)));
		ObjectParameter objectParameter2 = (requestTypeId.HasValue ? new ObjectParameter("RequestTypeId", requestTypeId) : new ObjectParameter("RequestTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = ((date != null) ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(string)));
		ObjectParameter objectParameter5 = (verifyStatus.HasValue ? new ObjectParameter("VerifyStatus", verifyStatus) : new ObjectParameter("VerifyStatus", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectTimeAttendanceRequest_Result>("HRMMobspSelectTimeAttendanceRequest", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<HRMMobspSelectTimeAttendanceRequestHistory_Result> HRMMobspSelectTimeAttendanceRequestHistory(int? userID, DateTime? fDate, DateTime? tDate, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter5 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectTimeAttendanceRequestHistory_Result>("HRMMobspSelectTimeAttendanceRequestHistory", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<int?> HRMMobspSendTimeAttendanceEditRequest(int? requestId, int? requestTypeId, string requestData, int? requestIdI, int? requestTypeIdI, string requestDataI, string msgSubject, string msgBody, string msgLangValue, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, ObjectParameter insertedID, int? centerId)
	{
		ObjectParameter objectParameter = (requestId.HasValue ? new ObjectParameter("RequestId", requestId) : new ObjectParameter("RequestId", typeof(int)));
		ObjectParameter objectParameter2 = (requestTypeId.HasValue ? new ObjectParameter("RequestTypeId", requestTypeId) : new ObjectParameter("RequestTypeId", typeof(int)));
		ObjectParameter objectParameter3 = ((requestData != null) ? new ObjectParameter("RequestData", requestData) : new ObjectParameter("RequestData", typeof(string)));
		ObjectParameter objectParameter4 = (requestIdI.HasValue ? new ObjectParameter("RequestIdI", requestIdI) : new ObjectParameter("RequestIdI", typeof(int)));
		ObjectParameter objectParameter5 = (requestTypeIdI.HasValue ? new ObjectParameter("RequestTypeIdI", requestTypeIdI) : new ObjectParameter("RequestTypeIdI", typeof(int)));
		ObjectParameter objectParameter6 = ((requestDataI != null) ? new ObjectParameter("RequestDataI", requestDataI) : new ObjectParameter("RequestDataI", typeof(string)));
		ObjectParameter objectParameter7 = ((msgSubject != null) ? new ObjectParameter("msgSubject", msgSubject) : new ObjectParameter("msgSubject", typeof(string)));
		ObjectParameter objectParameter8 = ((msgBody != null) ? new ObjectParameter("msgBody", msgBody) : new ObjectParameter("msgBody", typeof(string)));
		ObjectParameter objectParameter9 = ((msgLangValue != null) ? new ObjectParameter("msgLangValue", msgLangValue) : new ObjectParameter("msgLangValue", typeof(string)));
		ObjectParameter objectParameter10 = (msgdFromUserId.HasValue ? new ObjectParameter("msgdFromUserId", msgdFromUserId) : new ObjectParameter("msgdFromUserId", typeof(int)));
		ObjectParameter objectParameter11 = (msgdToUserId.HasValue ? new ObjectParameter("msgdToUserId", msgdToUserId) : new ObjectParameter("msgdToUserId", typeof(int)));
		ObjectParameter objectParameter12 = ((msgdSendDate != null) ? new ObjectParameter("msgdSendDate", msgdSendDate) : new ObjectParameter("msgdSendDate", typeof(string)));
		ObjectParameter objectParameter13 = ((msgdSendTime != null) ? new ObjectParameter("msgdSendTime", msgdSendTime) : new ObjectParameter("msgdSendTime", typeof(string)));
		ObjectParameter objectParameter14 = (msgdSendDateTime.HasValue ? new ObjectParameter("msgdSendDateTime", msgdSendDateTime) : new ObjectParameter("msgdSendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter15 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter16 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter17 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter18 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter19 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter20 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter21 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter22 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("HRMMobspSendTimeAttendanceEditRequest", new ObjectParameter[23]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, insertedID, objectParameter22
		});
	}

	public virtual int MobspInsertSendedSms(int? sendType, string sendTopic, int? sID, string fromNumber, string smsBody, int? smsBodyCount, string smsBodyLangType, decimal? smsBodyCost, int? numberCount, string numbers, string refNumbers, int? allSmsCount, decimal? userCost, int? sendUserId, string sendDay, string sendDate, string sendTime, DateTime? sendDateTime, string companiesId, string companyPersonsId, int? userId, int? year1, int? month1, string registerDatePersian, string singleNumber, int? singleCompanyId, int? singleCompanyPersonId, string singleRefNumber, string appType, int? statusId, int? cMessage, DateTime? schedulDate, int? sendPriority, int? defaultLanguageID, bool? sendNeedCheck, int? companyProjectId, int? objectId, string objectIdType, int? smsProviderId, string oTP, int? centerId)
	{
		ObjectParameter objectParameter = (sendType.HasValue ? new ObjectParameter("SendType", sendType) : new ObjectParameter("SendType", typeof(int)));
		ObjectParameter objectParameter2 = ((sendTopic != null) ? new ObjectParameter("SendTopic", sendTopic) : new ObjectParameter("SendTopic", typeof(string)));
		ObjectParameter objectParameter3 = (sID.HasValue ? new ObjectParameter("SID", sID) : new ObjectParameter("SID", typeof(int)));
		ObjectParameter objectParameter4 = ((fromNumber != null) ? new ObjectParameter("FromNumber", fromNumber) : new ObjectParameter("FromNumber", typeof(string)));
		ObjectParameter objectParameter5 = ((smsBody != null) ? new ObjectParameter("smsBody", smsBody) : new ObjectParameter("smsBody", typeof(string)));
		ObjectParameter objectParameter6 = (smsBodyCount.HasValue ? new ObjectParameter("SmsBodyCount", smsBodyCount) : new ObjectParameter("SmsBodyCount", typeof(int)));
		ObjectParameter objectParameter7 = ((smsBodyLangType != null) ? new ObjectParameter("SmsBodyLangType", smsBodyLangType) : new ObjectParameter("SmsBodyLangType", typeof(string)));
		ObjectParameter objectParameter8 = (smsBodyCost.HasValue ? new ObjectParameter("SmsBodyCost", smsBodyCost) : new ObjectParameter("SmsBodyCost", typeof(decimal)));
		ObjectParameter objectParameter9 = (numberCount.HasValue ? new ObjectParameter("NumberCount", numberCount) : new ObjectParameter("NumberCount", typeof(int)));
		ObjectParameter objectParameter10 = ((numbers != null) ? new ObjectParameter("Numbers", numbers) : new ObjectParameter("Numbers", typeof(string)));
		ObjectParameter objectParameter11 = ((refNumbers != null) ? new ObjectParameter("RefNumbers", refNumbers) : new ObjectParameter("RefNumbers", typeof(string)));
		ObjectParameter objectParameter12 = (allSmsCount.HasValue ? new ObjectParameter("AllSmsCount", allSmsCount) : new ObjectParameter("AllSmsCount", typeof(int)));
		ObjectParameter objectParameter13 = (userCost.HasValue ? new ObjectParameter("UserCost", userCost) : new ObjectParameter("UserCost", typeof(decimal)));
		ObjectParameter objectParameter14 = (sendUserId.HasValue ? new ObjectParameter("SendUserId", sendUserId) : new ObjectParameter("SendUserId", typeof(int)));
		ObjectParameter objectParameter15 = ((sendDay != null) ? new ObjectParameter("SendDay", sendDay) : new ObjectParameter("SendDay", typeof(string)));
		ObjectParameter objectParameter16 = ((sendDate != null) ? new ObjectParameter("SendDate", sendDate) : new ObjectParameter("SendDate", typeof(string)));
		ObjectParameter objectParameter17 = ((sendTime != null) ? new ObjectParameter("SendTime", sendTime) : new ObjectParameter("SendTime", typeof(string)));
		ObjectParameter objectParameter18 = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter19 = ((companiesId != null) ? new ObjectParameter("CompaniesId", companiesId) : new ObjectParameter("CompaniesId", typeof(string)));
		ObjectParameter objectParameter20 = ((companyPersonsId != null) ? new ObjectParameter("CompanyPersonsId", companyPersonsId) : new ObjectParameter("CompanyPersonsId", typeof(string)));
		ObjectParameter objectParameter21 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter22 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter23 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter24 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter25 = ((singleNumber != null) ? new ObjectParameter("SingleNumber", singleNumber) : new ObjectParameter("SingleNumber", typeof(string)));
		ObjectParameter objectParameter26 = (singleCompanyId.HasValue ? new ObjectParameter("SingleCompanyId", singleCompanyId) : new ObjectParameter("SingleCompanyId", typeof(int)));
		ObjectParameter objectParameter27 = (singleCompanyPersonId.HasValue ? new ObjectParameter("SingleCompanyPersonId", singleCompanyPersonId) : new ObjectParameter("SingleCompanyPersonId", typeof(int)));
		ObjectParameter objectParameter28 = ((singleRefNumber != null) ? new ObjectParameter("SingleRefNumber", singleRefNumber) : new ObjectParameter("SingleRefNumber", typeof(string)));
		ObjectParameter objectParameter29 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter30 = (statusId.HasValue ? new ObjectParameter("StatusId", statusId) : new ObjectParameter("StatusId", typeof(int)));
		ObjectParameter objectParameter31 = (cMessage.HasValue ? new ObjectParameter("CMessage", cMessage) : new ObjectParameter("CMessage", typeof(int)));
		ObjectParameter objectParameter32 = (schedulDate.HasValue ? new ObjectParameter("SchedulDate", schedulDate) : new ObjectParameter("SchedulDate", typeof(DateTime)));
		ObjectParameter objectParameter33 = (sendPriority.HasValue ? new ObjectParameter("SendPriority", sendPriority) : new ObjectParameter("SendPriority", typeof(int)));
		ObjectParameter objectParameter34 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter35 = (sendNeedCheck.HasValue ? new ObjectParameter("SendNeedCheck", sendNeedCheck) : new ObjectParameter("SendNeedCheck", typeof(bool)));
		ObjectParameter objectParameter36 = (companyProjectId.HasValue ? new ObjectParameter("CompanyProjectId", companyProjectId) : new ObjectParameter("CompanyProjectId", typeof(int)));
		ObjectParameter objectParameter37 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter38 = ((objectIdType != null) ? new ObjectParameter("ObjectIdType", objectIdType) : new ObjectParameter("ObjectIdType", typeof(string)));
		ObjectParameter objectParameter39 = (smsProviderId.HasValue ? new ObjectParameter("smsProviderId", smsProviderId) : new ObjectParameter("smsProviderId", typeof(int)));
		ObjectParameter objectParameter40 = ((oTP != null) ? new ObjectParameter("OTP", oTP) : new ObjectParameter("OTP", typeof(string)));
		ObjectParameter objectParameter41 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertSendedSms", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41);
	}

	public virtual int MobspSendCnvsOTPCode(int? conversationStatusResultId, int? cnvsCompanyId, int? cnvsPersonId, int? cnvsProjectId, string cnvsDesc, int? cnvsFirstRegisterUserId, int? cnvsUserId, int? cnvsReferUserId, string cnvsMultiReferUserIds, DateTime? cnvsRemindDate, DateTime? cnvsRemindDateForAllarm, string cnvsRemindTime, string oTPCode, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter sendOTPCode, string prjPrdHisPrdNameJson, int? cmpKind, int? cmpReferUserId, int? cmpSuppUserId, int? cmpTitleId, string cmpName, string cmpPreTel, string cmpTel, string cmpAddress, string cmpMobile, string cmpEmail, int? prsTitleId, string prsFName, string prsLName, string prsMobile, string prsEmail, string prjTitle, int? prjGroupId, int? prjGradeId, int? prjPriorityId, string prjPostFix, DateTime? prjRemindDate, string prjTitleGroup, string prjNumRef, int? centerId)
	{
		ObjectParameter objectParameter = (conversationStatusResultId.HasValue ? new ObjectParameter("ConversationStatusResultId", conversationStatusResultId) : new ObjectParameter("ConversationStatusResultId", typeof(int)));
		ObjectParameter objectParameter2 = (cnvsCompanyId.HasValue ? new ObjectParameter("cnvsCompanyId", cnvsCompanyId) : new ObjectParameter("cnvsCompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (cnvsPersonId.HasValue ? new ObjectParameter("cnvsPersonId", cnvsPersonId) : new ObjectParameter("cnvsPersonId", typeof(int)));
		ObjectParameter objectParameter4 = (cnvsProjectId.HasValue ? new ObjectParameter("cnvsProjectId", cnvsProjectId) : new ObjectParameter("cnvsProjectId", typeof(int)));
		ObjectParameter objectParameter5 = ((cnvsDesc != null) ? new ObjectParameter("CnvsDesc", cnvsDesc) : new ObjectParameter("CnvsDesc", typeof(string)));
		ObjectParameter objectParameter6 = (cnvsFirstRegisterUserId.HasValue ? new ObjectParameter("CnvsFirstRegisterUserId", cnvsFirstRegisterUserId) : new ObjectParameter("CnvsFirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter7 = (cnvsUserId.HasValue ? new ObjectParameter("CnvsUserId", cnvsUserId) : new ObjectParameter("CnvsUserId", typeof(int)));
		ObjectParameter objectParameter8 = (cnvsReferUserId.HasValue ? new ObjectParameter("CnvsReferUserId", cnvsReferUserId) : new ObjectParameter("CnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter9 = ((cnvsMultiReferUserIds != null) ? new ObjectParameter("CnvsMultiReferUserIds", cnvsMultiReferUserIds) : new ObjectParameter("CnvsMultiReferUserIds", typeof(string)));
		ObjectParameter objectParameter10 = (cnvsRemindDate.HasValue ? new ObjectParameter("CnvsRemindDate", cnvsRemindDate) : new ObjectParameter("CnvsRemindDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = (cnvsRemindDateForAllarm.HasValue ? new ObjectParameter("CnvsRemindDateForAllarm", cnvsRemindDateForAllarm) : new ObjectParameter("CnvsRemindDateForAllarm", typeof(DateTime)));
		ObjectParameter objectParameter12 = ((cnvsRemindTime != null) ? new ObjectParameter("CnvsRemindTime", cnvsRemindTime) : new ObjectParameter("CnvsRemindTime", typeof(string)));
		ObjectParameter objectParameter13 = ((oTPCode != null) ? new ObjectParameter("OTPCode", oTPCode) : new ObjectParameter("OTPCode", typeof(string)));
		ObjectParameter objectParameter14 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter15 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter16 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter17 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter18 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter19 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter20 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter21 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter22 = ((prjPrdHisPrdNameJson != null) ? new ObjectParameter("PrjPrdHisPrdNameJson", prjPrdHisPrdNameJson) : new ObjectParameter("PrjPrdHisPrdNameJson", typeof(string)));
		ObjectParameter objectParameter23 = (cmpKind.HasValue ? new ObjectParameter("CmpKind", cmpKind) : new ObjectParameter("CmpKind", typeof(int)));
		ObjectParameter objectParameter24 = (cmpReferUserId.HasValue ? new ObjectParameter("CmpReferUserId", cmpReferUserId) : new ObjectParameter("CmpReferUserId", typeof(int)));
		ObjectParameter objectParameter25 = (cmpSuppUserId.HasValue ? new ObjectParameter("CmpSuppUserId", cmpSuppUserId) : new ObjectParameter("CmpSuppUserId", typeof(int)));
		ObjectParameter objectParameter26 = (cmpTitleId.HasValue ? new ObjectParameter("CmpTitleId", cmpTitleId) : new ObjectParameter("CmpTitleId", typeof(int)));
		ObjectParameter objectParameter27 = ((cmpName != null) ? new ObjectParameter("CmpName", cmpName) : new ObjectParameter("CmpName", typeof(string)));
		ObjectParameter objectParameter28 = ((cmpPreTel != null) ? new ObjectParameter("CmpPreTel", cmpPreTel) : new ObjectParameter("CmpPreTel", typeof(string)));
		ObjectParameter objectParameter29 = ((cmpTel != null) ? new ObjectParameter("CmpTel", cmpTel) : new ObjectParameter("CmpTel", typeof(string)));
		ObjectParameter objectParameter30 = ((cmpAddress != null) ? new ObjectParameter("CmpAddress", cmpAddress) : new ObjectParameter("CmpAddress", typeof(string)));
		ObjectParameter objectParameter31 = ((cmpMobile != null) ? new ObjectParameter("CmpMobile", cmpMobile) : new ObjectParameter("CmpMobile", typeof(string)));
		ObjectParameter objectParameter32 = ((cmpEmail != null) ? new ObjectParameter("CmpEmail", cmpEmail) : new ObjectParameter("CmpEmail", typeof(string)));
		ObjectParameter objectParameter33 = (prsTitleId.HasValue ? new ObjectParameter("PrsTitleId", prsTitleId) : new ObjectParameter("PrsTitleId", typeof(int)));
		ObjectParameter objectParameter34 = ((prsFName != null) ? new ObjectParameter("PrsFName", prsFName) : new ObjectParameter("PrsFName", typeof(string)));
		ObjectParameter objectParameter35 = ((prsLName != null) ? new ObjectParameter("PrsLName", prsLName) : new ObjectParameter("PrsLName", typeof(string)));
		ObjectParameter objectParameter36 = ((prsMobile != null) ? new ObjectParameter("PrsMobile", prsMobile) : new ObjectParameter("PrsMobile", typeof(string)));
		ObjectParameter objectParameter37 = ((prsEmail != null) ? new ObjectParameter("PrsEmail", prsEmail) : new ObjectParameter("PrsEmail", typeof(string)));
		ObjectParameter objectParameter38 = ((prjTitle != null) ? new ObjectParameter("PrjTitle", prjTitle) : new ObjectParameter("PrjTitle", typeof(string)));
		ObjectParameter objectParameter39 = (prjGroupId.HasValue ? new ObjectParameter("PrjGroupId", prjGroupId) : new ObjectParameter("PrjGroupId", typeof(int)));
		ObjectParameter objectParameter40 = (prjGradeId.HasValue ? new ObjectParameter("PrjGradeId", prjGradeId) : new ObjectParameter("PrjGradeId", typeof(int)));
		ObjectParameter objectParameter41 = (prjPriorityId.HasValue ? new ObjectParameter("PrjPriorityId", prjPriorityId) : new ObjectParameter("PrjPriorityId", typeof(int)));
		ObjectParameter objectParameter42 = ((prjPostFix != null) ? new ObjectParameter("PrjPostFix", prjPostFix) : new ObjectParameter("PrjPostFix", typeof(string)));
		ObjectParameter objectParameter43 = (prjRemindDate.HasValue ? new ObjectParameter("PrjRemindDate", prjRemindDate) : new ObjectParameter("PrjRemindDate", typeof(DateTime)));
		ObjectParameter objectParameter44 = ((prjTitleGroup != null) ? new ObjectParameter("PrjTitleGroup", prjTitleGroup) : new ObjectParameter("PrjTitleGroup", typeof(string)));
		ObjectParameter objectParameter45 = ((prjNumRef != null) ? new ObjectParameter("PrjNumRef", prjNumRef) : new ObjectParameter("PrjNumRef", typeof(string)));
		ObjectParameter objectParameter46 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSendCnvsOTPCode", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20, objectParameter21, sendOTPCode, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40, objectParameter41, objectParameter42, objectParameter43, objectParameter44, objectParameter45, objectParameter46);
	}

	public virtual ObjectResult<MobspSelectSmsSetting_Result> MobspSelectSmsSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsSetting_Result>("MobspSelectSmsSetting", Array.Empty<ObjectParameter>());
	}

	public virtual int MobspUpdateSendedDetailStatusAndRefId(string smsDetails, int? statusId, string statusChangeDate, string statusChangeTime, string appType, DateTime? statusChangeDateTime)
	{
		ObjectParameter objectParameter = ((smsDetails != null) ? new ObjectParameter("SmsDetails", smsDetails) : new ObjectParameter("SmsDetails", typeof(string)));
		ObjectParameter objectParameter2 = (statusId.HasValue ? new ObjectParameter("StatusId", statusId) : new ObjectParameter("StatusId", typeof(int)));
		ObjectParameter objectParameter3 = ((statusChangeDate != null) ? new ObjectParameter("StatusChangeDate", statusChangeDate) : new ObjectParameter("StatusChangeDate", typeof(string)));
		ObjectParameter objectParameter4 = ((statusChangeTime != null) ? new ObjectParameter("StatusChangeTime", statusChangeTime) : new ObjectParameter("StatusChangeTime", typeof(string)));
		ObjectParameter objectParameter5 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter6 = (statusChangeDateTime.HasValue ? new ObjectParameter("StatusChangeDateTime", statusChangeDateTime) : new ObjectParameter("StatusChangeDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateSendedDetailStatusAndRefId", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual ObjectResult<MobspSelectCompanyPersonsByID_Result> MobspSelectCompanyPersonsByID(int? companyPersonID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyPersonID.HasValue ? new ObjectParameter("CompanyPersonID", companyPersonID) : new ObjectParameter("CompanyPersonID", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyPersonsByID_Result>("MobspSelectCompanyPersonsByID", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectLastSmsReceive_Result> MobspSelectLastSmsReceive()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLastSmsReceive_Result>("MobspSelectLastSmsReceive", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspSelectEmailReadySend_Result> MobspSelectEmailReadySend(DateTime? curentDate)
	{
		ObjectParameter objectParameter = (curentDate.HasValue ? new ObjectParameter("CurentDate", curentDate) : new ObjectParameter("CurentDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEmailReadySend_Result>("MobspSelectEmailReadySend", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectEmailSendAttachment_Result> MobspSelectEmailSendAttachment(string filter, string sort)
	{
		ObjectParameter objectParameter = ((filter != null) ? new ObjectParameter("Filter", filter) : new ObjectParameter("Filter", typeof(string)));
		ObjectParameter objectParameter2 = ((sort != null) ? new ObjectParameter("Sort", sort) : new ObjectParameter("Sort", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEmailSendAttachment_Result>("MobspSelectEmailSendAttachment", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectEmailSetting_Result> MobspSelectEmailSetting(string filter, string sort)
	{
		ObjectParameter objectParameter = ((filter != null) ? new ObjectParameter("Filter", filter) : new ObjectParameter("Filter", typeof(string)));
		ObjectParameter objectParameter2 = ((sort != null) ? new ObjectParameter("Sort", sort) : new ObjectParameter("Sort", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEmailSetting_Result>("MobspSelectEmailSetting", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspUpdateEmailSendDetail(int? emailSendDetailId, int? emailSendHeaderId, string emailAddress, int? emailCmpId, int? emailCmpPrsId, int? emailCmpPrjId, DateTime? sendDateTime, string sendDatePersian, DateTime? sendedDateTime, string sendedDatePersian, int? statusId, DateTime? registerDate, string registerDatePersian, string emailCmpPrsName, string emailCmpName, string emailPrsJob, string appType, int? tryCount)
	{
		ObjectParameter objectParameter = (emailSendDetailId.HasValue ? new ObjectParameter("EmailSendDetailId", emailSendDetailId) : new ObjectParameter("EmailSendDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (emailSendHeaderId.HasValue ? new ObjectParameter("EmailSendHeaderId", emailSendHeaderId) : new ObjectParameter("EmailSendHeaderId", typeof(int)));
		ObjectParameter objectParameter3 = ((emailAddress != null) ? new ObjectParameter("EmailAddress", emailAddress) : new ObjectParameter("EmailAddress", typeof(string)));
		ObjectParameter objectParameter4 = (emailCmpId.HasValue ? new ObjectParameter("EmailCmpId", emailCmpId) : new ObjectParameter("EmailCmpId", typeof(int)));
		ObjectParameter objectParameter5 = (emailCmpPrsId.HasValue ? new ObjectParameter("EmailCmpPrsId", emailCmpPrsId) : new ObjectParameter("EmailCmpPrsId", typeof(int)));
		ObjectParameter objectParameter6 = (emailCmpPrjId.HasValue ? new ObjectParameter("EmailCmpPrjId", emailCmpPrjId) : new ObjectParameter("EmailCmpPrjId", typeof(int)));
		ObjectParameter objectParameter7 = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((sendDatePersian != null) ? new ObjectParameter("SendDatePersian", sendDatePersian) : new ObjectParameter("SendDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (sendedDateTime.HasValue ? new ObjectParameter("SendedDateTime", sendedDateTime) : new ObjectParameter("SendedDateTime", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((sendedDatePersian != null) ? new ObjectParameter("SendedDatePersian", sendedDatePersian) : new ObjectParameter("SendedDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = (statusId.HasValue ? new ObjectParameter("StatusId", statusId) : new ObjectParameter("StatusId", typeof(int)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = ((emailCmpPrsName != null) ? new ObjectParameter("EmailCmpPrsName", emailCmpPrsName) : new ObjectParameter("EmailCmpPrsName", typeof(string)));
		ObjectParameter objectParameter15 = ((emailCmpName != null) ? new ObjectParameter("EmailCmpName", emailCmpName) : new ObjectParameter("EmailCmpName", typeof(string)));
		ObjectParameter objectParameter16 = ((emailPrsJob != null) ? new ObjectParameter("EmailPrsJob", emailPrsJob) : new ObjectParameter("EmailPrsJob", typeof(string)));
		ObjectParameter objectParameter17 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter18 = (tryCount.HasValue ? new ObjectParameter("TryCount", tryCount) : new ObjectParameter("TryCount", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateEmailSendDetail", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18);
	}

	public virtual int MobspUpdateEmailSendHeader(int? emailSendHeaderId, int? userId, string subject, string body, DateTime? startDateTime, string startDatePersian, DateTime? endDateTime, string endDatePersian, int? priorityId, DateTime? registerDate, string registerDatePersian, int? emailUsersInfoId, int? emailSettingId, string appType)
	{
		ObjectParameter objectParameter = (emailSendHeaderId.HasValue ? new ObjectParameter("EmailSendHeaderId", emailSendHeaderId) : new ObjectParameter("EmailSendHeaderId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = ((subject != null) ? new ObjectParameter("Subject", subject) : new ObjectParameter("Subject", typeof(string)));
		ObjectParameter objectParameter4 = ((body != null) ? new ObjectParameter("Body", body) : new ObjectParameter("Body", typeof(string)));
		ObjectParameter objectParameter5 = (startDateTime.HasValue ? new ObjectParameter("StartDateTime", startDateTime) : new ObjectParameter("StartDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((startDatePersian != null) ? new ObjectParameter("StartDatePersian", startDatePersian) : new ObjectParameter("StartDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (endDateTime.HasValue ? new ObjectParameter("EndDateTime", endDateTime) : new ObjectParameter("EndDateTime", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((endDatePersian != null) ? new ObjectParameter("EndDatePersian", endDatePersian) : new ObjectParameter("EndDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (priorityId.HasValue ? new ObjectParameter("PriorityId", priorityId) : new ObjectParameter("PriorityId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = (emailUsersInfoId.HasValue ? new ObjectParameter("EmailUsersInfoId", emailUsersInfoId) : new ObjectParameter("EmailUsersInfoId", typeof(int)));
		ObjectParameter objectParameter13 = (emailSettingId.HasValue ? new ObjectParameter("EmailSettingId", emailSettingId) : new ObjectParameter("EmailSettingId", typeof(int)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateEmailSendHeader", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14);
	}

	public virtual ObjectResult<MobspSelectEmailSendDetail_Result> MobspSelectEmailSendDetail(string filter, string sort)
	{
		ObjectParameter objectParameter = ((filter != null) ? new ObjectParameter("Filter", filter) : new ObjectParameter("Filter", typeof(string)));
		ObjectParameter objectParameter2 = ((sort != null) ? new ObjectParameter("Sort", sort) : new ObjectParameter("Sort", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEmailSendDetail_Result>("MobspSelectEmailSendDetail", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectEmailSendHeader_Result> MobspSelectEmailSendHeader(string filter, string sort)
	{
		ObjectParameter objectParameter = ((filter != null) ? new ObjectParameter("Filter", filter) : new ObjectParameter("Filter", typeof(string)));
		ObjectParameter objectParameter2 = ((sort != null) ? new ObjectParameter("Sort", sort) : new ObjectParameter("Sort", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEmailSendHeader_Result>("MobspSelectEmailSendHeader", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectActiveConversationStatus_Result> MobspSelectActiveConversationStatus(int? groupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (groupId.HasValue ? new ObjectParameter("GroupId", groupId) : new ObjectParameter("GroupId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveConversationStatus_Result>("MobspSelectActiveConversationStatus", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectActiveConversationStatusGroups_Result> MobspSelectActiveConversationStatusGroups(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveConversationStatusGroups_Result>("MobspSelectActiveConversationStatusGroups", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectActiveConversationStatusResult_Result> MobspSelectActiveConversationStatusResult(int? conversationStatusId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (conversationStatusId.HasValue ? new ObjectParameter("ConversationStatusId", conversationStatusId) : new ObjectParameter("ConversationStatusId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveConversationStatusResult_Result>("MobspSelectActiveConversationStatusResult", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectConversationStatus_Result> MobspSelectConversationStatus(int? groupId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (groupId.HasValue ? new ObjectParameter("GroupId", groupId) : new ObjectParameter("GroupId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationStatus_Result>("MobspSelectConversationStatus", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectConversationStatusResult_Result> MobspSelectConversationStatusResult(int? conversationStatusId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (conversationStatusId.HasValue ? new ObjectParameter("ConversationStatusId", conversationStatusId) : new ObjectParameter("ConversationStatusId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationStatusResult_Result>("MobspSelectConversationStatusResult", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectConversationStatusResultById_Result> MobspSelectConversationStatusResultById(int? conversationStatusResultId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (conversationStatusResultId.HasValue ? new ObjectParameter("ConversationStatusResultId", conversationStatusResultId) : new ObjectParameter("ConversationStatusResultId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationStatusResultById_Result>("MobspSelectConversationStatusResultById", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspInsertQuickCmpPrsPrjCnvs(string company, string personList, string projectList, string conversationList, string companyAddressList, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string personLabel, string needErjaRefmsgSubj, string needErjaRefmsgBody, string needErjaMultiIntmsgSubject, string needErjaMultiIntmsgBody, string needSendErjaAllarmRefmsgSubj, string needSendErjaAllarmRefmsgBody, string conversationErjaShowText, string msgConversationErjaMultiUser, string msgConversationErjaReferDescription, ObjectParameter insertedCompanyId, ObjectParameter insertedPersonIds, ObjectParameter insertedProjectIds, ObjectParameter insertedConversationIds, ObjectParameter insertedCompanyAddressIds, ObjectParameter errorMessage, ObjectParameter typeTable, int? linkedType, string cmpNotAccess, string surveyMainInternalLink, string surveyMainExtrenalLink, string surveyMainExtrenalLinkLogin, string eventConversationErjaShowText, string eventErjaRefmsg, int? centerId, string encryptionKey, int? foCountModule)
	{
		ObjectParameter objectParameter = ((company != null) ? new ObjectParameter("Company", company) : new ObjectParameter("Company", typeof(string)));
		ObjectParameter objectParameter2 = ((personList != null) ? new ObjectParameter("PersonList", personList) : new ObjectParameter("PersonList", typeof(string)));
		ObjectParameter objectParameter3 = ((projectList != null) ? new ObjectParameter("ProjectList", projectList) : new ObjectParameter("ProjectList", typeof(string)));
		ObjectParameter objectParameter4 = ((conversationList != null) ? new ObjectParameter("ConversationList", conversationList) : new ObjectParameter("ConversationList", typeof(string)));
		ObjectParameter objectParameter5 = ((companyAddressList != null) ? new ObjectParameter("CompanyAddressList", companyAddressList) : new ObjectParameter("CompanyAddressList", typeof(string)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter13 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter14 = ((personLabel != null) ? new ObjectParameter("PersonLabel", personLabel) : new ObjectParameter("PersonLabel", typeof(string)));
		ObjectParameter objectParameter15 = ((needErjaRefmsgSubj != null) ? new ObjectParameter("NeedErjaRefmsgSubj", needErjaRefmsgSubj) : new ObjectParameter("NeedErjaRefmsgSubj", typeof(string)));
		ObjectParameter objectParameter16 = ((needErjaRefmsgBody != null) ? new ObjectParameter("NeedErjaRefmsgBody", needErjaRefmsgBody) : new ObjectParameter("NeedErjaRefmsgBody", typeof(string)));
		ObjectParameter objectParameter17 = ((needErjaMultiIntmsgSubject != null) ? new ObjectParameter("NeedErjaMultiIntmsgSubject", needErjaMultiIntmsgSubject) : new ObjectParameter("NeedErjaMultiIntmsgSubject", typeof(string)));
		ObjectParameter objectParameter18 = ((needErjaMultiIntmsgBody != null) ? new ObjectParameter("NeedErjaMultiIntmsgBody", needErjaMultiIntmsgBody) : new ObjectParameter("NeedErjaMultiIntmsgBody", typeof(string)));
		ObjectParameter objectParameter19 = ((needSendErjaAllarmRefmsgSubj != null) ? new ObjectParameter("NeedSendErjaAllarmRefmsgSubj", needSendErjaAllarmRefmsgSubj) : new ObjectParameter("NeedSendErjaAllarmRefmsgSubj", typeof(string)));
		ObjectParameter objectParameter20 = ((needSendErjaAllarmRefmsgBody != null) ? new ObjectParameter("NeedSendErjaAllarmRefmsgBody", needSendErjaAllarmRefmsgBody) : new ObjectParameter("NeedSendErjaAllarmRefmsgBody", typeof(string)));
		ObjectParameter objectParameter21 = ((conversationErjaShowText != null) ? new ObjectParameter("ConversationErjaShowText", conversationErjaShowText) : new ObjectParameter("ConversationErjaShowText", typeof(string)));
		ObjectParameter objectParameter22 = ((msgConversationErjaMultiUser != null) ? new ObjectParameter("MsgConversationErjaMultiUser", msgConversationErjaMultiUser) : new ObjectParameter("MsgConversationErjaMultiUser", typeof(string)));
		ObjectParameter objectParameter23 = ((msgConversationErjaReferDescription != null) ? new ObjectParameter("MsgConversationErjaReferDescription", msgConversationErjaReferDescription) : new ObjectParameter("MsgConversationErjaReferDescription", typeof(string)));
		ObjectParameter objectParameter24 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter25 = ((cmpNotAccess != null) ? new ObjectParameter("CmpNotAccess", cmpNotAccess) : new ObjectParameter("CmpNotAccess", typeof(string)));
		ObjectParameter objectParameter26 = ((surveyMainInternalLink != null) ? new ObjectParameter("SurveyMainInternalLink", surveyMainInternalLink) : new ObjectParameter("SurveyMainInternalLink", typeof(string)));
		ObjectParameter objectParameter27 = ((surveyMainExtrenalLink != null) ? new ObjectParameter("SurveyMainExtrenalLink", surveyMainExtrenalLink) : new ObjectParameter("SurveyMainExtrenalLink", typeof(string)));
		ObjectParameter objectParameter28 = ((surveyMainExtrenalLinkLogin != null) ? new ObjectParameter("SurveyMainExtrenalLinkLogin", surveyMainExtrenalLinkLogin) : new ObjectParameter("SurveyMainExtrenalLinkLogin", typeof(string)));
		ObjectParameter objectParameter29 = ((eventConversationErjaShowText != null) ? new ObjectParameter("EventConversationErjaShowText", eventConversationErjaShowText) : new ObjectParameter("EventConversationErjaShowText", typeof(string)));
		ObjectParameter objectParameter30 = ((eventErjaRefmsg != null) ? new ObjectParameter("EventErjaRefmsg", eventErjaRefmsg) : new ObjectParameter("EventErjaRefmsg", typeof(string)));
		ObjectParameter objectParameter31 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter32 = ((encryptionKey != null) ? new ObjectParameter("EncryptionKey", encryptionKey) : new ObjectParameter("EncryptionKey", typeof(string)));
		ObjectParameter objectParameter33 = (foCountModule.HasValue ? new ObjectParameter("FoCountModule", foCountModule) : new ObjectParameter("FoCountModule", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickCmpPrsPrjCnvs", new ObjectParameter[40]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, insertedCompanyId, insertedPersonIds, insertedProjectIds, insertedConversationIds, insertedCompanyAddressIds, errorMessage, typeTable,
			objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30, objectParameter31, objectParameter32, objectParameter33
		});
	}

	public virtual ObjectResult<MobspInsertQuickConversation_Result> MobspInsertQuickConversation(string conversationList, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, string needErjaRefmsgSubj, string needErjaRefmsgBody, string needErjaMultiIntmsgSubject, string needErjaMultiIntmsgBody, string needSendErjaAllarmRefmsgSubj, string needSendErjaAllarmRefmsgBody, string conversationErjaShowText, string msgConversationErjaMultiUser, string msgConversationErjaReferDescription, string typeTable, ObjectParameter insertedConversationIds, ObjectParameter errorMessage, ObjectParameter result, int? linkedType, string cmpNotAccess, string surveyMainInternalLink, string surveyMainExtrenalLink, string surveyMainExtrenalLinkLogin, string eventConversationErjaShowText, string eventErjaRefmsg, int? centerId, int? foCountModule)
	{
		ObjectParameter objectParameter = ((conversationList != null) ? new ObjectParameter("ConversationList", conversationList) : new ObjectParameter("ConversationList", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter10 = ((needErjaRefmsgSubj != null) ? new ObjectParameter("NeedErjaRefmsgSubj", needErjaRefmsgSubj) : new ObjectParameter("NeedErjaRefmsgSubj", typeof(string)));
		ObjectParameter objectParameter11 = ((needErjaRefmsgBody != null) ? new ObjectParameter("NeedErjaRefmsgBody", needErjaRefmsgBody) : new ObjectParameter("NeedErjaRefmsgBody", typeof(string)));
		ObjectParameter objectParameter12 = ((needErjaMultiIntmsgSubject != null) ? new ObjectParameter("NeedErjaMultiIntmsgSubject", needErjaMultiIntmsgSubject) : new ObjectParameter("NeedErjaMultiIntmsgSubject", typeof(string)));
		ObjectParameter objectParameter13 = ((needErjaMultiIntmsgBody != null) ? new ObjectParameter("NeedErjaMultiIntmsgBody", needErjaMultiIntmsgBody) : new ObjectParameter("NeedErjaMultiIntmsgBody", typeof(string)));
		ObjectParameter objectParameter14 = ((needSendErjaAllarmRefmsgSubj != null) ? new ObjectParameter("NeedSendErjaAllarmRefmsgSubj", needSendErjaAllarmRefmsgSubj) : new ObjectParameter("NeedSendErjaAllarmRefmsgSubj", typeof(string)));
		ObjectParameter objectParameter15 = ((needSendErjaAllarmRefmsgBody != null) ? new ObjectParameter("NeedSendErjaAllarmRefmsgBody", needSendErjaAllarmRefmsgBody) : new ObjectParameter("NeedSendErjaAllarmRefmsgBody", typeof(string)));
		ObjectParameter objectParameter16 = ((conversationErjaShowText != null) ? new ObjectParameter("ConversationErjaShowText", conversationErjaShowText) : new ObjectParameter("ConversationErjaShowText", typeof(string)));
		ObjectParameter objectParameter17 = ((msgConversationErjaMultiUser != null) ? new ObjectParameter("MsgConversationErjaMultiUser", msgConversationErjaMultiUser) : new ObjectParameter("MsgConversationErjaMultiUser", typeof(string)));
		ObjectParameter objectParameter18 = ((msgConversationErjaReferDescription != null) ? new ObjectParameter("MsgConversationErjaReferDescription", msgConversationErjaReferDescription) : new ObjectParameter("MsgConversationErjaReferDescription", typeof(string)));
		ObjectParameter objectParameter19 = ((typeTable != null) ? new ObjectParameter("TypeTable", typeTable) : new ObjectParameter("TypeTable", typeof(string)));
		ObjectParameter objectParameter20 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter21 = ((cmpNotAccess != null) ? new ObjectParameter("CmpNotAccess", cmpNotAccess) : new ObjectParameter("CmpNotAccess", typeof(string)));
		ObjectParameter objectParameter22 = ((surveyMainInternalLink != null) ? new ObjectParameter("SurveyMainInternalLink", surveyMainInternalLink) : new ObjectParameter("SurveyMainInternalLink", typeof(string)));
		ObjectParameter objectParameter23 = ((surveyMainExtrenalLink != null) ? new ObjectParameter("SurveyMainExtrenalLink", surveyMainExtrenalLink) : new ObjectParameter("SurveyMainExtrenalLink", typeof(string)));
		ObjectParameter objectParameter24 = ((surveyMainExtrenalLinkLogin != null) ? new ObjectParameter("SurveyMainExtrenalLinkLogin", surveyMainExtrenalLinkLogin) : new ObjectParameter("SurveyMainExtrenalLinkLogin", typeof(string)));
		ObjectParameter objectParameter25 = ((eventConversationErjaShowText != null) ? new ObjectParameter("EventConversationErjaShowText", eventConversationErjaShowText) : new ObjectParameter("EventConversationErjaShowText", typeof(string)));
		ObjectParameter objectParameter26 = ((eventErjaRefmsg != null) ? new ObjectParameter("EventErjaRefmsg", eventErjaRefmsg) : new ObjectParameter("EventErjaRefmsg", typeof(string)));
		ObjectParameter objectParameter27 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter28 = (foCountModule.HasValue ? new ObjectParameter("FoCountModule", foCountModule) : new ObjectParameter("FoCountModule", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspInsertQuickConversation_Result>("MobspInsertQuickConversation", new ObjectParameter[31]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, insertedConversationIds,
			errorMessage, result, objectParameter20, objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27,
			objectParameter28
		});
	}

	public virtual ObjectResult<MobspGetSMSTankRequest_Result> MobspGetSMSTankRequest(DateTime? sendDateTime)
	{
		ObjectParameter objectParameter = (sendDateTime.HasValue ? new ObjectParameter("SendDateTime", sendDateTime) : new ObjectParameter("SendDateTime", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspGetSMSTankRequest_Result>("MobspGetSMSTankRequest", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspGetSMSTankRequestByOTP_Result> MobspGetSMSTankRequestByOTP(string oTP)
	{
		ObjectParameter objectParameter = ((oTP != null) ? new ObjectParameter("OTP", oTP) : new ObjectParameter("OTP", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspGetSMSTankRequestByOTP_Result>("MobspGetSMSTankRequestByOTP", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectEmailReadySendByOTP_Result> MobspSelectEmailReadySendByOTP(string oTP)
	{
		ObjectParameter objectParameter = ((oTP != null) ? new ObjectParameter("OTP", oTP) : new ObjectParameter("OTP", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectEmailReadySendByOTP_Result>("MobspSelectEmailReadySendByOTP", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectSmsProvidersById_Result> MobspSelectSmsProvidersById(int? smsProviderId)
	{
		ObjectParameter objectParameter = (smsProviderId.HasValue ? new ObjectParameter("SmsProviderId", smsProviderId) : new ObjectParameter("SmsProviderId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsProvidersById_Result>("MobspSelectSmsProvidersById", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectOrderItems_Result> MobspSelectOrderItems(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderItems_Result>("MobspSelectOrderItems", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<mct_Result> MobspDeleteProjectProductHistory(int? projectProductHistoryId)
	{
		ObjectParameter objectParameter = (projectProductHistoryId.HasValue ? new ObjectParameter("ProjectProductHistoryId", projectProductHistoryId) : new ObjectParameter("ProjectProductHistoryId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspDeleteProjectProductHistory", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_Result> MobspInsertUpdateProjectProductHistory(int? prjPrdHCompanyId, int? prjPrdHProjectId, string projectProductHistoryJson, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter resultJson)
	{
		ObjectParameter objectParameter = (prjPrdHCompanyId.HasValue ? new ObjectParameter("PrjPrdHCompanyId", prjPrdHCompanyId) : new ObjectParameter("PrjPrdHCompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (prjPrdHProjectId.HasValue ? new ObjectParameter("PrjPrdHProjectId", prjPrdHProjectId) : new ObjectParameter("PrjPrdHProjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((projectProductHistoryJson != null) ? new ObjectParameter("ProjectProductHistoryJson", projectProductHistoryJson) : new ObjectParameter("ProjectProductHistoryJson", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspInsertUpdateProjectProductHistory", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, resultJson
		});
	}

	public virtual ObjectResult<MobspSelectProjectProductHistory_Result> MobspSelectProjectProductHistory(int? companyId, int? projectId, string txtIsDone, string txtIsNotDone, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((txtIsDone != null) ? new ObjectParameter("TxtIsDone", txtIsDone) : new ObjectParameter("TxtIsDone", typeof(string)));
		ObjectParameter objectParameter4 = ((txtIsNotDone != null) ? new ObjectParameter("TxtIsNotDone", txtIsNotDone) : new ObjectParameter("TxtIsNotDone", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectProductHistory_Result>("MobspSelectProjectProductHistory", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectProjectProductHistoryOrderVerifiedItems_Result> MobspSelectProjectProductHistoryOrderVerifiedItems(int? companyId, int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectProductHistoryOrderVerifiedItems_Result>("MobspSelectProjectProductHistoryOrderVerifiedItems", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectProducts_Result> MobspSelectProducts(DateTime? registerDate, int? languageID, int? defaultLanguageID, int? lastProductId)
	{
		ObjectParameter objectParameter = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (lastProductId.HasValue ? new ObjectParameter("LastProductId", lastProductId) : new ObjectParameter("LastProductId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProducts_Result>("MobspSelectProducts", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspDySelectFormsMenuWithSysPartId_Result> MobspDySelectFormsMenuWithSysPartId(int? crmSysPartId, int? fOSysPartId, int? crmUserId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (crmSysPartId.HasValue ? new ObjectParameter("CrmSysPartId", crmSysPartId) : new ObjectParameter("CrmSysPartId", typeof(int)));
		ObjectParameter objectParameter2 = (fOSysPartId.HasValue ? new ObjectParameter("FOSysPartId", fOSysPartId) : new ObjectParameter("FOSysPartId", typeof(int)));
		ObjectParameter objectParameter3 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormsMenuWithSysPartId_Result>("MobspDySelectFormsMenuWithSysPartId", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspDySelectFormAndSubForms_Result> MobspDySelectFormAndSubForms(int? formId, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormAndSubForms_Result>("MobspDySelectFormAndSubForms", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspDySelectFormFieldMasterValueDetails_Result> MobspDySelectFormFieldMasterValueDetails(int? formId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter4 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter5 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter6 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter7 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter8 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldMasterValueDetails_Result>("MobspDySelectFormFieldMasterValueDetails", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspDySelectFormFieldsByParentFormId_Result> MobspDySelectFormFieldsByParentFormId(int? parentFormId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (parentFormId.HasValue ? new ObjectParameter("ParentFormId", parentFormId) : new ObjectParameter("ParentFormId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldsByParentFormId_Result>("MobspDySelectFormFieldsByParentFormId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspDySelectForms_Result> MobspDySelectForms(int? formId, int? parentFormId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (parentFormId.HasValue ? new ObjectParameter("ParentFormId", parentFormId) : new ObjectParameter("ParentFormId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectForms_Result>("MobspDySelectForms", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspDySelectFormUserAccess_Result> MobspDySelectFormUserAccess(int? crmUserId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormUserAccess_Result>("MobspDySelectFormUserAccess", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspDySelectFormWorkflowStepsForMasterValue_Result> MobspDySelectFormWorkflowStepsForMasterValue(int? workflowId, int? masterValueId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (workflowId.HasValue ? new ObjectParameter("WorkflowId", workflowId) : new ObjectParameter("WorkflowId", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormWorkflowStepsForMasterValue_Result>("MobspDySelectFormWorkflowStepsForMasterValue", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspDySelectFilesDirectory_Result> MobspDySelectFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, string typeOprObjectIdI, string typeOprObjectIdII, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((masterId != null) ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(string)));
		ObjectParameter objectParameter2 = ((detailId != null) ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(string)));
		ObjectParameter objectParameter3 = ((subDetailId != null) ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(string)));
		ObjectParameter objectParameter4 = ((fileDirectoryTypeOprId != null) ? new ObjectParameter("FileDirectoryTypeOprId", fileDirectoryTypeOprId) : new ObjectParameter("FileDirectoryTypeOprId", typeof(string)));
		ObjectParameter objectParameter5 = ((typeOprObjectId != null) ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(string)));
		ObjectParameter objectParameter6 = ((typeOprObjectIdI != null) ? new ObjectParameter("TypeOprObjectIdI", typeOprObjectIdI) : new ObjectParameter("TypeOprObjectIdI", typeof(string)));
		ObjectParameter objectParameter7 = ((typeOprObjectIdII != null) ? new ObjectParameter("TypeOprObjectIdII", typeOprObjectIdII) : new ObjectParameter("TypeOprObjectIdII", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter9 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFilesDirectory_Result>("MobspDySelectFilesDirectory", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspDySearchUsers_Result> MobspDySearchUsers(string val, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchUsers_Result>("MobspDySearchUsers", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspDyCheckDuplicateDyFormNumber_Result> MobspDyCheckDuplicateDyFormNumber(long? dyFormNumber, int? currId, int? formId, int? centerId)
	{
		ObjectParameter objectParameter = (dyFormNumber.HasValue ? new ObjectParameter("DyFormNumber", dyFormNumber) : new ObjectParameter("DyFormNumber", typeof(long)));
		ObjectParameter objectParameter2 = (currId.HasValue ? new ObjectParameter("CurrId", currId) : new ObjectParameter("CurrId", typeof(int)));
		ObjectParameter objectParameter3 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDyCheckDuplicateDyFormNumber_Result>("MobspDyCheckDuplicateDyFormNumber", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspDyInsertUpdateFormFieldMasterValueDetails(int? mode, int? masterValueId, int? formId, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID, int? centerId)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter3 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDyInsertUpdateFormFieldMasterValueDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11);
	}

	public virtual ObjectResult<MobspDySelectFormFieldMasterValueDetailWithId_Result> MobspDySelectFormFieldMasterValueDetailWithId(int? masterValueDetailId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueDetailId.HasValue ? new ObjectParameter("MasterValueDetailId", masterValueDetailId) : new ObjectParameter("MasterValueDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldMasterValueDetailWithId_Result>("MobspDySelectFormFieldMasterValueDetailWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspDySelectFormWorkflowStepWithId_Result> MobspDySelectFormWorkflowStepWithId(int? workflowStepId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (workflowStepId.HasValue ? new ObjectParameter("WorkflowStepId", workflowStepId) : new ObjectParameter("WorkflowStepId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormWorkflowStepWithId_Result>("MobspDySelectFormWorkflowStepWithId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspDyUpdateFormFieldMasterValues(int? masterValueId, long? dyFormNumber, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (dyFormNumber.HasValue ? new ObjectParameter("DyFormNumber", dyFormNumber) : new ObjectParameter("DyFormNumber", typeof(long)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDyUpdateFormFieldMasterValues", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<int?> MobspDyDeleteFormFieldMasterValue(int? masterValueId)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDyDeleteFormFieldMasterValue", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspDySelectFormWorkflowStepBFCurr_Result> MobspDySelectFormWorkflowStepBFCurr(int? workflowId, int? workflowStepId, int? masterValueId, int? formId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (workflowId.HasValue ? new ObjectParameter("WorkflowId", workflowId) : new ObjectParameter("WorkflowId", typeof(int)));
		ObjectParameter objectParameter2 = (workflowStepId.HasValue ? new ObjectParameter("WorkflowStepId", workflowStepId) : new ObjectParameter("WorkflowStepId", typeof(int)));
		ObjectParameter objectParameter3 = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter4 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormWorkflowStepBFCurr_Result>("MobspDySelectFormWorkflowStepBFCurr", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<mct_Result> MobspDyInsertFormFieldMasterValueDetails(int? masterValueId, int? formId, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter7 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspDyInsertFormFieldMasterValueDetails", new ObjectParameter[9] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9 });
	}

	public virtual ObjectResult<MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result> MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId(int? formId, int? masterValueId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result>("MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspDyUpdateFormFieldMasterValueDetails(int? masterValueDetailId, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType)
	{
		ObjectParameter objectParameter = (masterValueDetailId.HasValue ? new ObjectParameter("MasterValueDetailId", masterValueDetailId) : new ObjectParameter("MasterValueDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDyUpdateFormFieldMasterValueDetails", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7);
	}

	public virtual int MobspInsertFilesDirectoryTemplate(string title, string copyFromPath, int? userId, int? typeId, int? fileDirectoryTypeId, int? objectId, int? objectIdI, int? objectIdII, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, ObjectParameter insertedId)
	{
		ObjectParameter objectParameter = ((title != null) ? new ObjectParameter("Title", title) : new ObjectParameter("Title", typeof(string)));
		ObjectParameter objectParameter2 = ((copyFromPath != null) ? new ObjectParameter("CopyFromPath", copyFromPath) : new ObjectParameter("CopyFromPath", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (typeId.HasValue ? new ObjectParameter("TypeId", typeId) : new ObjectParameter("TypeId", typeof(int)));
		ObjectParameter objectParameter5 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter6 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter7 = (objectIdI.HasValue ? new ObjectParameter("ObjectIdI", objectIdI) : new ObjectParameter("ObjectIdI", typeof(int)));
		ObjectParameter objectParameter8 = (objectIdII.HasValue ? new ObjectParameter("ObjectIdII", objectIdII) : new ObjectParameter("ObjectIdII", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter12 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertFilesDirectoryTemplate", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, insertedId);
	}

	public virtual ObjectResult<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result> MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs(int? typeId, int? userId, int? fileDirectoryTypeId, int? objectId, int? objectIdI, int? objectIdII)
	{
		ObjectParameter objectParameter = (typeId.HasValue ? new ObjectParameter("TypeId", typeId) : new ObjectParameter("TypeId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter4 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter5 = (objectIdI.HasValue ? new ObjectParameter("ObjectIdI", objectIdI) : new ObjectParameter("ObjectIdI", typeof(int)));
		ObjectParameter objectParameter6 = (objectIdII.HasValue ? new ObjectParameter("ObjectIdII", objectIdII) : new ObjectParameter("ObjectIdII", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs_Result>("MobspSelectFilesDirectoryTemplateByTypeAndUserAndObjs", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspInsertFilesDirectory_Result> MobspInsertFilesDirectory(int? fileDirectoryId, int? fileDirectoryTypeId, int? masterId, int? detailId, int? subDetailId, string title, string title_Lang, string folderName, string fileName, string filePath, string copyFromPath, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, DateTime? docDateTime, string docDate, string docDay, string docTime, int? typeOprObjectId, string appType, int? languageID, int? orderView, int? typeOprObjectIdI, int? typeOprObjectIdII, string fileDirectoryNumRef, int? fileDirectoryParentId, bool? fileFOCmpCanSee, int? centerId)
	{
		ObjectParameter objectParameter = (fileDirectoryId.HasValue ? new ObjectParameter("FileDirectoryId", fileDirectoryId) : new ObjectParameter("FileDirectoryId", typeof(int)));
		ObjectParameter objectParameter2 = (fileDirectoryTypeId.HasValue ? new ObjectParameter("FileDirectoryTypeId", fileDirectoryTypeId) : new ObjectParameter("FileDirectoryTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (masterId.HasValue ? new ObjectParameter("MasterId", masterId) : new ObjectParameter("MasterId", typeof(int)));
		ObjectParameter objectParameter4 = (detailId.HasValue ? new ObjectParameter("DetailId", detailId) : new ObjectParameter("DetailId", typeof(int)));
		ObjectParameter objectParameter5 = (subDetailId.HasValue ? new ObjectParameter("SubDetailId", subDetailId) : new ObjectParameter("SubDetailId", typeof(int)));
		ObjectParameter objectParameter6 = ((title != null) ? new ObjectParameter("Title", title) : new ObjectParameter("Title", typeof(string)));
		ObjectParameter objectParameter7 = ((title_Lang != null) ? new ObjectParameter("Title_Lang", title_Lang) : new ObjectParameter("Title_Lang", typeof(string)));
		ObjectParameter objectParameter8 = ((folderName != null) ? new ObjectParameter("FolderName", folderName) : new ObjectParameter("FolderName", typeof(string)));
		ObjectParameter objectParameter9 = ((fileName != null) ? new ObjectParameter("FileName", fileName) : new ObjectParameter("FileName", typeof(string)));
		ObjectParameter objectParameter10 = ((filePath != null) ? new ObjectParameter("FilePath", filePath) : new ObjectParameter("FilePath", typeof(string)));
		ObjectParameter objectParameter11 = ((copyFromPath != null) ? new ObjectParameter("CopyFromPath", copyFromPath) : new ObjectParameter("CopyFromPath", typeof(string)));
		ObjectParameter objectParameter12 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter13 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter14 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter15 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter17 = (docDateTime.HasValue ? new ObjectParameter("DocDateTime", docDateTime) : new ObjectParameter("DocDateTime", typeof(DateTime)));
		ObjectParameter objectParameter18 = ((docDate != null) ? new ObjectParameter("DocDate", docDate) : new ObjectParameter("DocDate", typeof(string)));
		ObjectParameter objectParameter19 = ((docDay != null) ? new ObjectParameter("DocDay", docDay) : new ObjectParameter("DocDay", typeof(string)));
		ObjectParameter objectParameter20 = ((docTime != null) ? new ObjectParameter("DocTime", docTime) : new ObjectParameter("DocTime", typeof(string)));
		ObjectParameter objectParameter21 = (typeOprObjectId.HasValue ? new ObjectParameter("TypeOprObjectId", typeOprObjectId) : new ObjectParameter("TypeOprObjectId", typeof(int)));
		ObjectParameter objectParameter22 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter23 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter24 = (orderView.HasValue ? new ObjectParameter("OrderView", orderView) : new ObjectParameter("OrderView", typeof(int)));
		ObjectParameter objectParameter25 = (typeOprObjectIdI.HasValue ? new ObjectParameter("TypeOprObjectIdI", typeOprObjectIdI) : new ObjectParameter("TypeOprObjectIdI", typeof(int)));
		ObjectParameter objectParameter26 = (typeOprObjectIdII.HasValue ? new ObjectParameter("TypeOprObjectIdII", typeOprObjectIdII) : new ObjectParameter("TypeOprObjectIdII", typeof(int)));
		ObjectParameter objectParameter27 = ((fileDirectoryNumRef != null) ? new ObjectParameter("FileDirectoryNumRef", fileDirectoryNumRef) : new ObjectParameter("FileDirectoryNumRef", typeof(string)));
		ObjectParameter objectParameter28 = (fileDirectoryParentId.HasValue ? new ObjectParameter("FileDirectoryParentId", fileDirectoryParentId) : new ObjectParameter("FileDirectoryParentId", typeof(int)));
		ObjectParameter objectParameter29 = (fileFOCmpCanSee.HasValue ? new ObjectParameter("FileFOCmpCanSee", fileFOCmpCanSee) : new ObjectParameter("FileFOCmpCanSee", typeof(bool)));
		ObjectParameter objectParameter30 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspInsertFilesDirectory_Result>("MobspInsertFilesDirectory", new ObjectParameter[30]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30
		});
	}

	public virtual ObjectResult<MobspDySelectFormWorkflowStepNext_Result> MobspDySelectFormWorkflowStepNext(int? workflowId, int? workflowStepId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (workflowId.HasValue ? new ObjectParameter("WorkflowId", workflowId) : new ObjectParameter("WorkflowId", typeof(int)));
		ObjectParameter objectParameter2 = (workflowStepId.HasValue ? new ObjectParameter("WorkflowStepId", workflowStepId) : new ObjectParameter("WorkflowStepId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormWorkflowStepNext_Result>("MobspDySelectFormWorkflowStepNext", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspDySelectUserForFormToMultilUser_Result> MobspDySelectUserForFormToMultilUser(int? formId, string userIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = ((userIds != null) ? new ObjectParameter("UserIds", userIds) : new ObjectParameter("UserIds", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectUserForFormToMultilUser_Result>("MobspDySelectUserForFormToMultilUser", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspDySendFormInternalMessages(int? masterValueId, int? workflowStepId, string toUserIds, string msgBody, string msgAttachRecDesc, string msgAttachRecDescI, int? msgTypeId, int? userId, DateTime? registerDate, string registerDatePersian, string registerTime, int? year1, int? month1, string appType, int? defaultLanguageID, ObjectParameter insertedIntMsgId, int? centerId)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (workflowStepId.HasValue ? new ObjectParameter("WorkflowStepId", workflowStepId) : new ObjectParameter("WorkflowStepId", typeof(int)));
		ObjectParameter objectParameter3 = ((toUserIds != null) ? new ObjectParameter("ToUserIds", toUserIds) : new ObjectParameter("ToUserIds", typeof(string)));
		ObjectParameter objectParameter4 = ((msgBody != null) ? new ObjectParameter("MsgBody", msgBody) : new ObjectParameter("MsgBody", typeof(string)));
		ObjectParameter objectParameter5 = ((msgAttachRecDesc != null) ? new ObjectParameter("MsgAttachRecDesc", msgAttachRecDesc) : new ObjectParameter("MsgAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter6 = ((msgAttachRecDescI != null) ? new ObjectParameter("MsgAttachRecDescI", msgAttachRecDescI) : new ObjectParameter("MsgAttachRecDescI", typeof(string)));
		ObjectParameter objectParameter7 = (msgTypeId.HasValue ? new ObjectParameter("MsgTypeId", msgTypeId) : new ObjectParameter("MsgTypeId", typeof(int)));
		ObjectParameter objectParameter8 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter12 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(int)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(int)));
		ObjectParameter objectParameter14 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter15 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDySendFormInternalMessages", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, insertedIntMsgId, objectParameter16);
	}

	public virtual ObjectResult<mct_Result> MobspDyUpdateToDeleteFormFieldMasterValue(int? masterValueId, int? deletedUserId, DateTime? deletedDate, string deletedDatePersian)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (deletedUserId.HasValue ? new ObjectParameter("DeletedUserId", deletedUserId) : new ObjectParameter("DeletedUserId", typeof(int)));
		ObjectParameter objectParameter3 = (deletedDate.HasValue ? new ObjectParameter("DeletedDate", deletedDate) : new ObjectParameter("DeletedDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((deletedDatePersian != null) ? new ObjectParameter("DeletedDatePersian", deletedDatePersian) : new ObjectParameter("DeletedDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspDyUpdateToDeleteFormFieldMasterValue", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual int MobspDyFormCheck(int? masterValueId, int? checkerUserId, string checkedDatePersian, int? mode)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (checkerUserId.HasValue ? new ObjectParameter("CheckerUserId", checkerUserId) : new ObjectParameter("CheckerUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((checkedDatePersian != null) ? new ObjectParameter("CheckedDatePersian", checkedDatePersian) : new ObjectParameter("CheckedDatePersian", typeof(string)));
		ObjectParameter objectParameter4 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDyFormCheck", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual int MobspDyFormCheckExit(int? masterValueId, string checkedDatePersian, int? mode)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = ((checkedDatePersian != null) ? new ObjectParameter("CheckedDatePersian", checkedDatePersian) : new ObjectParameter("CheckedDatePersian", typeof(string)));
		ObjectParameter objectParameter3 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDyFormCheckExit", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual ObjectResult<WSspRpt_PrintOrderItemPrdPicture_Result> WSspRpt_PrintOrderItemPrdPicture(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintOrderItemPrdPicture_Result>("WSspRpt_PrintOrderItemPrdPicture", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<WSspRpt_PrintPreOrderItemPrdPicture_Result> WSspRpt_PrintPreOrderItemPrdPicture(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WSspRpt_PrintPreOrderItemPrdPicture_Result>("WSspRpt_PrintPreOrderItemPrdPicture", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspDySelectFormFieldMasterValueWithId_Result> MobspDySelectFormFieldMasterValueWithId(int? masterValueId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldMasterValueWithId_Result>("MobspDySelectFormFieldMasterValueWithId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<mct_Result> MobspReferOrderToWrhsUser(int? orderId, string intMsgBody, string intMsgSubject, string intMsgLang, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
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
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspReferOrderToWrhsUser", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<CRMspDyPrintFormDetails_Result> CRMspDyPrintFormDetails(string part, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((part != null) ? new ObjectParameter("Part", part) : new ObjectParameter("Part", typeof(string)));
		ObjectParameter objectParameter2 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter3 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter4 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter5 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintFormDetails_Result>("CRMspDyPrintFormDetails", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<CRMspDyPrintFormFieldMasterValueDetails_Result> CRMspDyPrintFormFieldMasterValueDetails(int? masterValueId, int? masterValueDetailId, int? userId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (masterValueDetailId.HasValue ? new ObjectParameter("MasterValueDetailId", masterValueDetailId) : new ObjectParameter("MasterValueDetailId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter5 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintFormFieldMasterValueDetails_Result>("CRMspDyPrintFormFieldMasterValueDetails", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspDyPrintFormFieldValues_Result> CRMspDyPrintFormFieldValues(int? masterValueId, int? formId, int? userId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter5 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintFormFieldValues_Result>("CRMspDyPrintFormFieldValues", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<CRMspSelectUserSignatureByUserId_Result> CRMspSelectUserSignatureByUserId(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspSelectUserSignatureByUserId_Result>("CRMspSelectUserSignatureByUserId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<CRMspDyPrintForm_Result> CRMspDyPrintForm(int? masterValueId, int? userId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter4 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CRMspDyPrintForm_Result>("CRMspDyPrintForm", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<mct_Result> MobspDyInsertFormFieldValues(int? masterValueId, int? formId, int? fieldId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, string value, string valueLang, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter3 = (fieldId.HasValue ? new ObjectParameter("FieldId", fieldId) : new ObjectParameter("FieldId", typeof(int)));
		ObjectParameter objectParameter4 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter5 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter6 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter7 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter8 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter10 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter11 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter12 = ((valueLang != null) ? new ObjectParameter("ValueLang", valueLang) : new ObjectParameter("ValueLang", typeof(string)));
		ObjectParameter objectParameter13 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter17 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter18 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter19 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspDyInsertFormFieldValues", new ObjectParameter[19]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19
		});
	}

	public virtual ObjectResult<MobspDySelectFormFieldValuesByMasterValueId_Result> MobspDySelectFormFieldValuesByMasterValueId(int? masterValueId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldValuesByMasterValueId_Result>("MobspDySelectFormFieldValuesByMasterValueId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<mct_Result> MobspDyUpdateFormFieldValues(int? fieldValueId, string value, string valueLang, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID)
	{
		ObjectParameter objectParameter = (fieldValueId.HasValue ? new ObjectParameter("FieldValueId", fieldValueId) : new ObjectParameter("FieldValueId", typeof(int)));
		ObjectParameter objectParameter2 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter3 = ((valueLang != null) ? new ObjectParameter("ValueLang", valueLang) : new ObjectParameter("ValueLang", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspDyUpdateFormFieldValues", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result> MobspDyReturnFormIdAndUserAccessFromMasterValueId(int? masterValueId, int? userId)
	{
		ObjectParameter objectParameter = (masterValueId.HasValue ? new ObjectParameter("MasterValueId", masterValueId) : new ObjectParameter("MasterValueId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDyReturnFormIdAndUserAccessFromMasterValueId_Result>("MobspDyReturnFormIdAndUserAccessFromMasterValueId", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspLoadUserLoginInfo_Result> MobspLoadUserLoginInfo(int? userId, string userName, string userPassword, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter3 = ((userPassword != null) ? new ObjectParameter("UserPassword", userPassword) : new ObjectParameter("UserPassword", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLoadUserLoginInfo_Result>("MobspLoadUserLoginInfo", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int MobspInsertUpdateUserMovementTracking(string coordinateLatitude, string coordinateLongitude, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((coordinateLatitude != null) ? new ObjectParameter("CoordinateLatitude", coordinateLatitude) : new ObjectParameter("CoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter2 = ((coordinateLongitude != null) ? new ObjectParameter("CoordinateLongitude", coordinateLongitude) : new ObjectParameter("CoordinateLongitude", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter5 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter6 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter8 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertUpdateUserMovementTracking", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9);
	}

	public virtual ObjectResult<MobspSelectUserMovementTracking_Result> MobspSelectUserMovementTracking(string userIds, DateTime? fromDate, string fromTime, DateTime? toDate, string toTime, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((userIds != null) ? new ObjectParameter("UserIds", userIds) : new ObjectParameter("UserIds", typeof(string)));
		ObjectParameter objectParameter2 = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((fromTime != null) ? new ObjectParameter("FromTime", fromTime) : new ObjectParameter("FromTime", typeof(string)));
		ObjectParameter objectParameter4 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((toTime != null) ? new ObjectParameter("ToTime", toTime) : new ObjectParameter("ToTime", typeof(string)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserMovementTracking_Result>("MobspSelectUserMovementTracking", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result> MobspSelectUserMovementTrackingPolygonWithPolygonUserId(string polygonUserIds, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((polygonUserIds != null) ? new ObjectParameter("PolygonUserIds", polygonUserIds) : new ObjectParameter("PolygonUserIds", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result>("MobspSelectUserMovementTrackingPolygonWithPolygonUserId", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int CRMspLkSepReturnCmpAccountRemaining(int? companyId, ObjectParameter payRemain, int? linkAccSettingDBId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (linkAccSettingDBId.HasValue ? new ObjectParameter("LinkAccSettingDBId", linkAccSettingDBId) : new ObjectParameter("LinkAccSettingDBId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CRMspLkSepReturnCmpAccountRemaining", objectParameter, payRemain, objectParameter2);
	}

	public virtual ObjectResult<MobspDySearchBuyOrders_Result> MobspDySearchBuyOrders(int? companyId, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchBuyOrders_Result>("MobspDySearchBuyOrders", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspDySearchCmsPages_Result> MobspDySearchCmsPages(string val, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchCmsPages_Result>("MobspDySearchCmsPages", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspDySearchCompanyConversations_Result> MobspDySearchCompanyConversations(int? companyId, int? projectId, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter3 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchCompanyConversations_Result>("MobspDySearchCompanyConversations", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspDySearchCompanyPersons_Result> MobspDySearchCompanyPersons(int? companyId, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchCompanyPersons_Result>("MobspDySearchCompanyPersons", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspDySearchCompanyProjects_Result> MobspDySearchCompanyProjects(int? companyId, int? isFinished, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (isFinished.HasValue ? new ObjectParameter("IsFinished", isFinished) : new ObjectParameter("IsFinished", typeof(int)));
		ObjectParameter objectParameter3 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchCompanyProjects_Result>("MobspDySearchCompanyProjects", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspDySearchDocsByType_Result> MobspDySearchDocsByType(int? companyId, int? oprType, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (oprType.HasValue ? new ObjectParameter("OprType", oprType) : new ObjectParameter("OprType", typeof(int)));
		ObjectParameter objectParameter3 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchDocsByType_Result>("MobspDySearchDocsByType", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspDySearchLettersByType_Result> MobspDySearchLettersByType(int? companyId, int? letterTypeId, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (letterTypeId.HasValue ? new ObjectParameter("LetterTypeId", letterTypeId) : new ObjectParameter("LetterTypeId", typeof(int)));
		ObjectParameter objectParameter3 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchLettersByType_Result>("MobspDySearchLettersByType", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual ObjectResult<MobspDySearchOrders_Result> MobspDySearchOrders(int? companyId, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchOrders_Result>("MobspDySearchOrders", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspDySearchPreOrders_Result> MobspDySearchPreOrders(int? companyId, string val, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySearchPreOrders_Result>("MobspDySearchPreOrders", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<mct_Result> MobspDyInsertFormFieldMasterValues(int? formId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, int? workflowId, int? workflowStepId, int? userId, DateTime? registerDate, string registerDatePersian, short? year1, short? month1, string appType, int? languageID, int? tableVersion, int? centerId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter4 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter5 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter6 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter7 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter8 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (workflowId.HasValue ? new ObjectParameter("WorkflowId", workflowId) : new ObjectParameter("WorkflowId", typeof(int)));
		ObjectParameter objectParameter10 = (workflowStepId.HasValue ? new ObjectParameter("WorkflowStepId", workflowStepId) : new ObjectParameter("WorkflowStepId", typeof(int)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter13 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter14 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter15 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (tableVersion.HasValue ? new ObjectParameter("TableVersion", tableVersion) : new ObjectParameter("TableVersion", typeof(int)));
		ObjectParameter objectParameter19 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspDyInsertFormFieldMasterValues", new ObjectParameter[19]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19
		});
	}

	public virtual ObjectResult<MobspDySelectFormFieldMasterValues_Result> MobspDySelectFormFieldMasterValues(int? formId, int? companyId, int? companyPersonId, int? projectId, int? conversationId, int? masterObjectId, int? detailObjectId, int? subDetailObjectId, int? languageID, int? defaultLanguageID, int? userId, int? centerId)
	{
		ObjectParameter objectParameter = (formId.HasValue ? new ObjectParameter("FormId", formId) : new ObjectParameter("FormId", typeof(int)));
		ObjectParameter objectParameter2 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter3 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter4 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter5 = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter6 = (masterObjectId.HasValue ? new ObjectParameter("MasterObjectId", masterObjectId) : new ObjectParameter("MasterObjectId", typeof(int)));
		ObjectParameter objectParameter7 = (detailObjectId.HasValue ? new ObjectParameter("DetailObjectId", detailObjectId) : new ObjectParameter("DetailObjectId", typeof(int)));
		ObjectParameter objectParameter8 = (subDetailObjectId.HasValue ? new ObjectParameter("SubDetailObjectId", subDetailObjectId) : new ObjectParameter("SubDetailObjectId", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectFormFieldMasterValues_Result>("MobspDySelectFormFieldMasterValues", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual ObjectResult<int?> MobspSelectFormFieldMasterValuesCnt(int? centerId)
	{
		ObjectParameter objectParameter = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspSelectFormFieldMasterValuesCnt", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectVerificationWorkFlowStepLast_Result> MobspSelectVerificationWorkFlowStepLast(int? objectId, int? objectType, int? verificationWorkFlowId, int? verificationRequestId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter2 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter3 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter4 = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationWorkFlowStepLast_Result>("MobspSelectVerificationWorkFlowStepLast", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspDySelectCompanyMasterValues_Result> MobspDySelectCompanyMasterValues(int? companyId, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspDySelectCompanyMasterValues_Result>("MobspDySelectCompanyMasterValues", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<HRMMobspLoadUserLoginInfo_Result> HRMMobspLoadUserLoginInfo(int? userId, string userName, string userPassword, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter3 = ((userPassword != null) ? new ObjectParameter("UserPassword", userPassword) : new ObjectParameter("UserPassword", typeof(string)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspLoadUserLoginInfo_Result>("HRMMobspLoadUserLoginInfo", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<HRMMobspReturnLeaveSummary_Result> HRMMobspReturnLeaveSummary(int? typeId, int? userId, DateTime? montlyFromDate, DateTime? montlyToDate, DateTime? yearlyFromDate, DateTime? yearlyToDate)
	{
		ObjectParameter objectParameter = (typeId.HasValue ? new ObjectParameter("TypeId", typeId) : new ObjectParameter("TypeId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (montlyFromDate.HasValue ? new ObjectParameter("MontlyFromDate", montlyFromDate) : new ObjectParameter("MontlyFromDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (montlyToDate.HasValue ? new ObjectParameter("MontlyToDate", montlyToDate) : new ObjectParameter("MontlyToDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (yearlyFromDate.HasValue ? new ObjectParameter("YearlyFromDate", yearlyFromDate) : new ObjectParameter("YearlyFromDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (yearlyToDate.HasValue ? new ObjectParameter("YearlyToDate", yearlyToDate) : new ObjectParameter("YearlyToDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspReturnLeaveSummary_Result>("HRMMobspReturnLeaveSummary", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<HRMMobspSelectAlternativeUsers_Result> HRMMobspSelectAlternativeUsers(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectAlternativeUsers_Result>("HRMMobspSelectAlternativeUsers", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<HRMMobspSelectLeaveKinds_Result> HRMMobspSelectLeaveKinds(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectLeaveKinds_Result>("HRMMobspSelectLeaveKinds", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectLeaveStayType_Result> HRMMobspSelectLeaveStayType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectLeaveStayType_Result>("HRMMobspSelectLeaveStayType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectLeaveType_Result> HRMMobspSelectLeaveType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectLeaveType_Result>("HRMMobspSelectLeaveType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectLeaveVehicleType_Result> HRMMobspSelectLeaveVehicleType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectLeaveVehicleType_Result>("HRMMobspSelectLeaveVehicleType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> HRMMobspInsertUpdateLeave(int? leaveId, int? leaveTypeId, int? requestUserId, int? replaceUserId, DateTime? fromDateTime, string fromDate, DateTime? toDateTime, string toDate, int? dayCount, string fromTime, string toTime, string hourCount, string reason, string description, int? kindId, string place, string placeCoordinateLatitude, string placeCoordinateLongitude, int? placeCoordinateZoomLevel, int? companyId, int? countryId, int? provinceId, int? cityId, int? vehicleTypeId, int? stayTypeId, int? leaveStatusId, int? verifierUserId, string msgLangValue, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter2 = (leaveTypeId.HasValue ? new ObjectParameter("LeaveTypeId", leaveTypeId) : new ObjectParameter("LeaveTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (requestUserId.HasValue ? new ObjectParameter("RequestUserId", requestUserId) : new ObjectParameter("RequestUserId", typeof(int)));
		ObjectParameter objectParameter4 = (replaceUserId.HasValue ? new ObjectParameter("ReplaceUserId", replaceUserId) : new ObjectParameter("ReplaceUserId", typeof(int)));
		ObjectParameter objectParameter5 = (fromDateTime.HasValue ? new ObjectParameter("FromDateTime", fromDateTime) : new ObjectParameter("FromDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((fromDate != null) ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(string)));
		ObjectParameter objectParameter7 = (toDateTime.HasValue ? new ObjectParameter("ToDateTime", toDateTime) : new ObjectParameter("ToDateTime", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((toDate != null) ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(string)));
		ObjectParameter objectParameter9 = (dayCount.HasValue ? new ObjectParameter("DayCount", dayCount) : new ObjectParameter("DayCount", typeof(int)));
		ObjectParameter objectParameter10 = ((fromTime != null) ? new ObjectParameter("FromTime", fromTime) : new ObjectParameter("FromTime", typeof(string)));
		ObjectParameter objectParameter11 = ((toTime != null) ? new ObjectParameter("ToTime", toTime) : new ObjectParameter("ToTime", typeof(string)));
		ObjectParameter objectParameter12 = ((hourCount != null) ? new ObjectParameter("HourCount", hourCount) : new ObjectParameter("HourCount", typeof(string)));
		ObjectParameter objectParameter13 = ((reason != null) ? new ObjectParameter("Reason", reason) : new ObjectParameter("Reason", typeof(string)));
		ObjectParameter objectParameter14 = ((description != null) ? new ObjectParameter("Description", description) : new ObjectParameter("Description", typeof(string)));
		ObjectParameter objectParameter15 = (kindId.HasValue ? new ObjectParameter("KindId", kindId) : new ObjectParameter("KindId", typeof(int)));
		ObjectParameter objectParameter16 = ((place != null) ? new ObjectParameter("Place", place) : new ObjectParameter("Place", typeof(string)));
		ObjectParameter objectParameter17 = ((placeCoordinateLatitude != null) ? new ObjectParameter("PlaceCoordinateLatitude", placeCoordinateLatitude) : new ObjectParameter("PlaceCoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter18 = ((placeCoordinateLongitude != null) ? new ObjectParameter("PlaceCoordinateLongitude", placeCoordinateLongitude) : new ObjectParameter("PlaceCoordinateLongitude", typeof(string)));
		ObjectParameter objectParameter19 = (placeCoordinateZoomLevel.HasValue ? new ObjectParameter("PlaceCoordinateZoomLevel", placeCoordinateZoomLevel) : new ObjectParameter("PlaceCoordinateZoomLevel", typeof(int)));
		ObjectParameter objectParameter20 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter21 = (countryId.HasValue ? new ObjectParameter("CountryId", countryId) : new ObjectParameter("CountryId", typeof(int)));
		ObjectParameter objectParameter22 = (provinceId.HasValue ? new ObjectParameter("ProvinceId", provinceId) : new ObjectParameter("ProvinceId", typeof(int)));
		ObjectParameter objectParameter23 = (cityId.HasValue ? new ObjectParameter("CityId", cityId) : new ObjectParameter("CityId", typeof(int)));
		ObjectParameter objectParameter24 = (vehicleTypeId.HasValue ? new ObjectParameter("VehicleTypeId", vehicleTypeId) : new ObjectParameter("VehicleTypeId", typeof(int)));
		ObjectParameter objectParameter25 = (stayTypeId.HasValue ? new ObjectParameter("StayTypeId", stayTypeId) : new ObjectParameter("StayTypeId", typeof(int)));
		ObjectParameter objectParameter26 = (leaveStatusId.HasValue ? new ObjectParameter("LeaveStatusId", leaveStatusId) : new ObjectParameter("LeaveStatusId", typeof(int)));
		ObjectParameter objectParameter27 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter28 = ((msgLangValue != null) ? new ObjectParameter("msgLangValue", msgLangValue) : new ObjectParameter("msgLangValue", typeof(string)));
		ObjectParameter objectParameter29 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter30 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter31 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter32 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter33 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter34 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter35 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter36 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("HRMMobspInsertUpdateLeave", new ObjectParameter[37]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, result
		});
	}

	public virtual ObjectResult<HRMMobspSearchCompanyQuick_Result> HRMMobspSearchCompanyQuick(string val, int? userID, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSearchCompanyQuick_Result>("HRMMobspSearchCompanyQuick", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<HRMMobspSelectCity_Result> HRMMobspSelectCity(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectCity_Result>("HRMMobspSelectCity", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectCountry_Result> HRMMobspSelectCountry(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectCountry_Result>("HRMMobspSelectCountry", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectProvince_Result> HRMMobspSelectProvince(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectProvince_Result>("HRMMobspSelectProvince", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectUserBaseInfoStatus_Result> HRMMobspSelectUserBaseInfoStatus(int? userId, string imeiCode, string appName)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((imeiCode != null) ? new ObjectParameter("ImeiCode", imeiCode) : new ObjectParameter("ImeiCode", typeof(string)));
		ObjectParameter objectParameter3 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectUserBaseInfoStatus_Result>("HRMMobspSelectUserBaseInfoStatus", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> HRMMobspDeleteLeave(int? leaveId)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("HRMMobspDeleteLeave", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<HRMMobspSelectVerificationWorkFlows_Result> HRMMobspSelectVerificationWorkFlows(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectVerificationWorkFlows_Result>("HRMMobspSelectVerificationWorkFlows", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectVerificationWorkFlowSteps_Result> HRMMobspSelectVerificationWorkFlowSteps(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectVerificationWorkFlowSteps_Result>("HRMMobspSelectVerificationWorkFlowSteps", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<HRMMobspSelectVerificationRequests_Result> HRMMobspSelectVerificationRequests(int? verificationRequestId, int? objectId, int? objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectVerificationRequests_Result>("HRMMobspSelectVerificationRequests", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<HRMMobspSelectVerificationRequestDetails_Result> HRMMobspSelectVerificationRequestDetails(int? verificationRequestDetailId, int? verificationRequestId, int? verificationWorkFlowId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (verificationRequestDetailId.HasValue ? new ObjectParameter("VerificationRequestDetailId", verificationRequestDetailId) : new ObjectParameter("VerificationRequestDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter3 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectVerificationRequestDetails_Result>("HRMMobspSelectVerificationRequestDetails", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<HRMMobspReturnLeaveSummaryCalendar_Result> HRMMobspReturnLeaveSummaryCalendar(int? oprType, int? userId, DateTime? fromDate, DateTime? toDate)
	{
		ObjectParameter objectParameter = (oprType.HasValue ? new ObjectParameter("OprType", oprType) : new ObjectParameter("OprType", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspReturnLeaveSummaryCalendar_Result>("HRMMobspReturnLeaveSummaryCalendar", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<HRMMobspSelectClosedCalendarEvents_Result> HRMMobspSelectClosedCalendarEvents(DateTime? fromDate, DateTime? toDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectClosedCalendarEvents_Result>("HRMMobspSelectClosedCalendarEvents", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<HRMMobspSelectLeave_Result> HRMMobspSelectLeave(int? crmUserId, int? leaveId, int? leaveTypeId, int? userId, DateTime? fDateTime, DateTime? tDateTime, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter3 = (leaveTypeId.HasValue ? new ObjectParameter("LeaveTypeId", leaveTypeId) : new ObjectParameter("LeaveTypeId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectLeave_Result>("HRMMobspSelectLeave", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11
		});
	}

	public virtual ObjectResult<MobspSelectUserForLinkedTypeIsActive_Result> MobspSelectUserForLinkedTypeIsActive(int? userId, int? linkedType, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (linkedType.HasValue ? new ObjectParameter("LinkedType", linkedType) : new ObjectParameter("LinkedType", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserForLinkedTypeIsActive_Result>("MobspSelectUserForLinkedTypeIsActive", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual int HRMMobspSendVerificationRequest(int? verificationWorkFlowId, int? objectId, string verificationReqText, string verificationReqTextLang, string msgSubject, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, ObjectParameter result, int? verificationReqUserId, int? centerId)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HRMMobspSendVerificationRequest", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, result, objectParameter14, objectParameter15);
	}

	public virtual ObjectResult<int?> HRMMobspInsertInternalMessageSingle(int? msgMasterId, string msgSubject, string msgBody, bool? msgActiveInCycle, int? msgdTypeId, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? msgdPriorityId, string msgdAttachFile, int? msgdAttachRecId, string msgdAttachRecDesc, int? msgdGroupId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? firstRegisterUserId, DateTime? firstRegisterDate, string firstRegisterDatePersian, string apiId, ObjectParameter internalMessageID, int? msgdAttachRecIdI, string msgdAttachRecDescI, string msgdExtraData, int? centerId)
	{
		ObjectParameter objectParameter = (msgMasterId.HasValue ? new ObjectParameter("MsgMasterId", msgMasterId) : new ObjectParameter("MsgMasterId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("MsgBody", msgBody) : new ObjectParameter("MsgBody", typeof(string)));
		ObjectParameter objectParameter4 = (msgActiveInCycle.HasValue ? new ObjectParameter("MsgActiveInCycle", msgActiveInCycle) : new ObjectParameter("MsgActiveInCycle", typeof(bool)));
		ObjectParameter objectParameter5 = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter6 = (msgdFromUserId.HasValue ? new ObjectParameter("MsgdFromUserId", msgdFromUserId) : new ObjectParameter("MsgdFromUserId", typeof(int)));
		ObjectParameter objectParameter7 = (msgdToUserId.HasValue ? new ObjectParameter("MsgdToUserId", msgdToUserId) : new ObjectParameter("MsgdToUserId", typeof(int)));
		ObjectParameter objectParameter8 = ((msgdSendDate != null) ? new ObjectParameter("MsgdSendDate", msgdSendDate) : new ObjectParameter("MsgdSendDate", typeof(string)));
		ObjectParameter objectParameter9 = ((msgdSendTime != null) ? new ObjectParameter("MsgdSendTime", msgdSendTime) : new ObjectParameter("MsgdSendTime", typeof(string)));
		ObjectParameter objectParameter10 = (msgdSendDateTime.HasValue ? new ObjectParameter("MsgdSendDateTime", msgdSendDateTime) : new ObjectParameter("MsgdSendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = (msgdPriorityId.HasValue ? new ObjectParameter("MsgdPriorityId", msgdPriorityId) : new ObjectParameter("MsgdPriorityId", typeof(int)));
		ObjectParameter objectParameter12 = ((msgdAttachFile != null) ? new ObjectParameter("MsgdAttachFile", msgdAttachFile) : new ObjectParameter("MsgdAttachFile", typeof(string)));
		ObjectParameter objectParameter13 = (msgdAttachRecId.HasValue ? new ObjectParameter("MsgdAttachRecId", msgdAttachRecId) : new ObjectParameter("MsgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter14 = ((msgdAttachRecDesc != null) ? new ObjectParameter("MsgdAttachRecDesc", msgdAttachRecDesc) : new ObjectParameter("MsgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter15 = (msgdGroupId.HasValue ? new ObjectParameter("msgdGroupId", msgdGroupId) : new ObjectParameter("msgdGroupId", typeof(int)));
		ObjectParameter objectParameter16 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter17 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter18 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter19 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter20 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter21 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter22 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter23 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter24 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter25 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter26 = ((apiId != null) ? new ObjectParameter("ApiId", apiId) : new ObjectParameter("ApiId", typeof(string)));
		ObjectParameter objectParameter27 = (msgdAttachRecIdI.HasValue ? new ObjectParameter("MsgdAttachRecIdI", msgdAttachRecIdI) : new ObjectParameter("MsgdAttachRecIdI", typeof(int)));
		ObjectParameter objectParameter28 = ((msgdAttachRecDescI != null) ? new ObjectParameter("MsgdAttachRecDescI", msgdAttachRecDescI) : new ObjectParameter("MsgdAttachRecDescI", typeof(string)));
		ObjectParameter objectParameter29 = ((msgdExtraData != null) ? new ObjectParameter("MsgdExtraData", msgdExtraData) : new ObjectParameter("MsgdExtraData", typeof(string)));
		ObjectParameter objectParameter30 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("HRMMobspInsertInternalMessageSingle", new ObjectParameter[31]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, internalMessageID, objectParameter27, objectParameter28, objectParameter29,
			objectParameter30
		});
	}

	public virtual ObjectResult<int?> MobspInsertInternalMessageSingle(int? msgMasterId, string msgSubject, string msgBody, bool? msgActiveInCycle, int? msgdTypeId, int? msgdFromUserId, int? msgdToUserId, string msgdSendDate, string msgdSendTime, DateTime? msgdSendDateTime, int? msgdPriorityId, string msgdAttachFile, int? msgdAttachRecId, string msgdAttachRecDesc, int? msgdGroupId, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? firstRegisterUserId, DateTime? firstRegisterDate, string firstRegisterDatePersian, string apiId, ObjectParameter internalMessageID, int? msgdAttachRecIdI, string msgdAttachRecDescI, string msgdExtraData, int? centerId)
	{
		ObjectParameter objectParameter = (msgMasterId.HasValue ? new ObjectParameter("MsgMasterId", msgMasterId) : new ObjectParameter("MsgMasterId", typeof(int)));
		ObjectParameter objectParameter2 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter3 = ((msgBody != null) ? new ObjectParameter("MsgBody", msgBody) : new ObjectParameter("MsgBody", typeof(string)));
		ObjectParameter objectParameter4 = (msgActiveInCycle.HasValue ? new ObjectParameter("MsgActiveInCycle", msgActiveInCycle) : new ObjectParameter("MsgActiveInCycle", typeof(bool)));
		ObjectParameter objectParameter5 = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter6 = (msgdFromUserId.HasValue ? new ObjectParameter("MsgdFromUserId", msgdFromUserId) : new ObjectParameter("MsgdFromUserId", typeof(int)));
		ObjectParameter objectParameter7 = (msgdToUserId.HasValue ? new ObjectParameter("MsgdToUserId", msgdToUserId) : new ObjectParameter("MsgdToUserId", typeof(int)));
		ObjectParameter objectParameter8 = ((msgdSendDate != null) ? new ObjectParameter("MsgdSendDate", msgdSendDate) : new ObjectParameter("MsgdSendDate", typeof(string)));
		ObjectParameter objectParameter9 = ((msgdSendTime != null) ? new ObjectParameter("MsgdSendTime", msgdSendTime) : new ObjectParameter("MsgdSendTime", typeof(string)));
		ObjectParameter objectParameter10 = (msgdSendDateTime.HasValue ? new ObjectParameter("MsgdSendDateTime", msgdSendDateTime) : new ObjectParameter("MsgdSendDateTime", typeof(DateTime)));
		ObjectParameter objectParameter11 = (msgdPriorityId.HasValue ? new ObjectParameter("MsgdPriorityId", msgdPriorityId) : new ObjectParameter("MsgdPriorityId", typeof(int)));
		ObjectParameter objectParameter12 = ((msgdAttachFile != null) ? new ObjectParameter("MsgdAttachFile", msgdAttachFile) : new ObjectParameter("MsgdAttachFile", typeof(string)));
		ObjectParameter objectParameter13 = (msgdAttachRecId.HasValue ? new ObjectParameter("MsgdAttachRecId", msgdAttachRecId) : new ObjectParameter("MsgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter14 = ((msgdAttachRecDesc != null) ? new ObjectParameter("MsgdAttachRecDesc", msgdAttachRecDesc) : new ObjectParameter("MsgdAttachRecDesc", typeof(string)));
		ObjectParameter objectParameter15 = (msgdGroupId.HasValue ? new ObjectParameter("msgdGroupId", msgdGroupId) : new ObjectParameter("msgdGroupId", typeof(int)));
		ObjectParameter objectParameter16 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter17 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter18 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter19 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter20 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter21 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter22 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter23 = (firstRegisterUserId.HasValue ? new ObjectParameter("FirstRegisterUserId", firstRegisterUserId) : new ObjectParameter("FirstRegisterUserId", typeof(int)));
		ObjectParameter objectParameter24 = (firstRegisterDate.HasValue ? new ObjectParameter("FirstRegisterDate", firstRegisterDate) : new ObjectParameter("FirstRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter25 = ((firstRegisterDatePersian != null) ? new ObjectParameter("FirstRegisterDatePersian", firstRegisterDatePersian) : new ObjectParameter("FirstRegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter26 = ((apiId != null) ? new ObjectParameter("ApiId", apiId) : new ObjectParameter("ApiId", typeof(string)));
		ObjectParameter objectParameter27 = (msgdAttachRecIdI.HasValue ? new ObjectParameter("MsgdAttachRecIdI", msgdAttachRecIdI) : new ObjectParameter("MsgdAttachRecIdI", typeof(int)));
		ObjectParameter objectParameter28 = ((msgdAttachRecDescI != null) ? new ObjectParameter("MsgdAttachRecDescI", msgdAttachRecDescI) : new ObjectParameter("MsgdAttachRecDescI", typeof(string)));
		ObjectParameter objectParameter29 = ((msgdExtraData != null) ? new ObjectParameter("MsgdExtraData", msgdExtraData) : new ObjectParameter("MsgdExtraData", typeof(string)));
		ObjectParameter objectParameter30 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertInternalMessageSingle", new ObjectParameter[31]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, internalMessageID, objectParameter27, objectParameter28, objectParameter29,
			objectParameter30
		});
	}

	public virtual int MobspGetSmsBodyPatternFormulaSendFoInfoResult(int? companyId, int? companyPersonId, string cmpPassword, int? foSettingId, int? languageID, int? defaultLanguageID, ObjectParameter smsBodyPatternFormulaSendFoInfoResult)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((cmpPassword != null) ? new ObjectParameter("CmpPassword", cmpPassword) : new ObjectParameter("CmpPassword", typeof(string)));
		ObjectParameter objectParameter4 = (foSettingId.HasValue ? new ObjectParameter("FoSettingId", foSettingId) : new ObjectParameter("FoSettingId", typeof(int)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspGetSmsBodyPatternFormulaSendFoInfoResult", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, smsBodyPatternFormulaSendFoInfoResult);
	}

	public virtual ObjectResult<MobspSelectSmsSendFoSetting_Result> MobspSelectSmsSendFoSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectSmsSendFoSetting_Result>("MobspSelectSmsSendFoSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspReturnDraftItemQuantityByPordItemId_Result> MobspReturnDraftItemQuantityByPordItemId(int? pordItemId)
	{
		ObjectParameter objectParameter = (pordItemId.HasValue ? new ObjectParameter("PordItemId", pordItemId) : new ObjectParameter("PordItemId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnDraftItemQuantityByPordItemId_Result>("MobspReturnDraftItemQuantityByPordItemId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectProjectProductHistoryNotDone_Result> MobspSelectProjectProductHistoryNotDone(int? projectId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectProductHistoryNotDone_Result>("MobspSelectProjectProductHistoryNotDone", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> MobspInsertUpdateTimeAttendance(int? mode, int? timeAttendanceId, DateTime? tmDate, string tmDatePersian, int? tmUserId, DateTime? tmEntryTime, string tmEntryRegisterIP, DateTime? tmExitTime, string tmExitRegisterIP, string tmDescription, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, int? tmEntryTimeVerifyUserId, DateTime? tmEntryTimeVerifyDate, string tmEntryTimeVerifyDatePersian, int? tmExitTimeVerifyUserId, DateTime? tmExitTimeVerifyDate, string tmExitTimeVerifyDatePersian, ObjectParameter result)
	{
		ObjectParameter objectParameter = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter2 = (timeAttendanceId.HasValue ? new ObjectParameter("TimeAttendanceId", timeAttendanceId) : new ObjectParameter("TimeAttendanceId", typeof(int)));
		ObjectParameter objectParameter3 = (tmDate.HasValue ? new ObjectParameter("tmDate", tmDate) : new ObjectParameter("tmDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((tmDatePersian != null) ? new ObjectParameter("tmDatePersian", tmDatePersian) : new ObjectParameter("tmDatePersian", typeof(string)));
		ObjectParameter objectParameter5 = (tmUserId.HasValue ? new ObjectParameter("tmUserId", tmUserId) : new ObjectParameter("tmUserId", typeof(int)));
		ObjectParameter objectParameter6 = (tmEntryTime.HasValue ? new ObjectParameter("tmEntryTime", tmEntryTime) : new ObjectParameter("tmEntryTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = ((tmEntryRegisterIP != null) ? new ObjectParameter("tmEntryRegisterIP", tmEntryRegisterIP) : new ObjectParameter("tmEntryRegisterIP", typeof(string)));
		ObjectParameter objectParameter8 = (tmExitTime.HasValue ? new ObjectParameter("tmExitTime", tmExitTime) : new ObjectParameter("tmExitTime", typeof(DateTime)));
		ObjectParameter objectParameter9 = ((tmExitRegisterIP != null) ? new ObjectParameter("tmExitRegisterIP", tmExitRegisterIP) : new ObjectParameter("tmExitRegisterIP", typeof(string)));
		ObjectParameter objectParameter10 = ((tmDescription != null) ? new ObjectParameter("tmDescription", tmDescription) : new ObjectParameter("tmDescription", typeof(string)));
		ObjectParameter objectParameter11 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter12 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter13 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter14 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter15 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (tmEntryTimeVerifyUserId.HasValue ? new ObjectParameter("tmEntryTimeVerifyUserId", tmEntryTimeVerifyUserId) : new ObjectParameter("tmEntryTimeVerifyUserId", typeof(int)));
		ObjectParameter objectParameter20 = (tmEntryTimeVerifyDate.HasValue ? new ObjectParameter("tmEntryTimeVerifyDate", tmEntryTimeVerifyDate) : new ObjectParameter("tmEntryTimeVerifyDate", typeof(DateTime)));
		ObjectParameter objectParameter21 = ((tmEntryTimeVerifyDatePersian != null) ? new ObjectParameter("tmEntryTimeVerifyDatePersian", tmEntryTimeVerifyDatePersian) : new ObjectParameter("tmEntryTimeVerifyDatePersian", typeof(string)));
		ObjectParameter objectParameter22 = (tmExitTimeVerifyUserId.HasValue ? new ObjectParameter("tmExitTimeVerifyUserId", tmExitTimeVerifyUserId) : new ObjectParameter("tmExitTimeVerifyUserId", typeof(int)));
		ObjectParameter objectParameter23 = (tmExitTimeVerifyDate.HasValue ? new ObjectParameter("tmExitTimeVerifyDate", tmExitTimeVerifyDate) : new ObjectParameter("tmExitTimeVerifyDate", typeof(DateTime)));
		ObjectParameter objectParameter24 = ((tmExitTimeVerifyDatePersian != null) ? new ObjectParameter("tmExitTimeVerifyDatePersian", tmExitTimeVerifyDatePersian) : new ObjectParameter("tmExitTimeVerifyDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertUpdateTimeAttendance", new ObjectParameter[25]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, result
		});
	}

	public virtual ObjectResult<MobspSelectTimeAttendanceByDate_Result> MobspSelectTimeAttendanceByDate(DateTime? date, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (date.HasValue ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(DateTime)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTimeAttendanceByDate_Result>("MobspSelectTimeAttendanceByDate", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectTimeAttendanceRequestMessage_Result> MobspSelectTimeAttendanceRequestMessage(int? requestId, int? requestTypeId, int? userId, string date, int? verifyStatus, int? internalMessageDetailId)
	{
		ObjectParameter objectParameter = (requestId.HasValue ? new ObjectParameter("RequestId", requestId) : new ObjectParameter("RequestId", typeof(int)));
		ObjectParameter objectParameter2 = (requestTypeId.HasValue ? new ObjectParameter("RequestTypeId", requestTypeId) : new ObjectParameter("RequestTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = ((date != null) ? new ObjectParameter("Date", date) : new ObjectParameter("Date", typeof(string)));
		ObjectParameter objectParameter5 = (verifyStatus.HasValue ? new ObjectParameter("VerifyStatus", verifyStatus) : new ObjectParameter("VerifyStatus", typeof(int)));
		ObjectParameter objectParameter6 = (internalMessageDetailId.HasValue ? new ObjectParameter("InternalMessageDetailId", internalMessageDetailId) : new ObjectParameter("InternalMessageDetailId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectTimeAttendanceRequestMessage_Result>("MobspSelectTimeAttendanceRequestMessage", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int MobspUpdateTimeAttendanceRequestVerified(int? requestId, bool? verified, int? userId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = (requestId.HasValue ? new ObjectParameter("RequestId", requestId) : new ObjectParameter("RequestId", typeof(int)));
		ObjectParameter objectParameter2 = (verified.HasValue ? new ObjectParameter("Verified", verified) : new ObjectParameter("Verified", typeof(bool)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter4 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter6 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspUpdateTimeAttendanceRequestVerified", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6);
	}

	public virtual ObjectResult<MobspSelectUsersById_Result> MobspSelectUsersById(int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUsersById_Result>("MobspSelectUsersById", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectCompanyInsidePolygon_Result> MobspSelectCompanyInsidePolygon(int? userId, string polygon, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = ((polygon != null) ? new ObjectParameter("Polygon", polygon) : new ObjectParameter("Polygon", typeof(string)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectCompanyInsidePolygon_Result>("MobspSelectCompanyInsidePolygon", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<mct_Result_StrI> MobspDeleteAllCompanyOperationsWithDependencies(int? companyId, int? projectId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result_StrI>("MobspDeleteAllCompanyOperationsWithDependencies", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<mct_Result_StrI> MobspDeleteAllCompanyPersonsWithDependencies(int? companyId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result_StrI>("MobspDeleteAllCompanyPersonsWithDependencies", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<mct_Result_StrI> MobspDeleteAllCompanyProjectsWithDependencies(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result_StrI>("MobspDeleteAllCompanyProjectsWithDependencies", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<mct_Result_StrI> MobspDeleteAllCompanyWithDependencies(int? companyId, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result_StrI>("MobspDeleteAllCompanyWithDependencies", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<mct_Result_StrI> MobspDeleteCompanyProjectWithDependencies(int? projectId)
	{
		ObjectParameter objectParameter = (projectId.HasValue ? new ObjectParameter("ProjectId", projectId) : new ObjectParameter("ProjectId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result_StrI>("MobspDeleteCompanyProjectWithDependencies", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspReturnLeaveSummary_Result> MobspReturnLeaveSummary(int? typeId, int? userId, DateTime? montlyFromDate, DateTime? montlyToDate, DateTime? yearlyFromDate, DateTime? yearlyToDate)
	{
		ObjectParameter objectParameter = (typeId.HasValue ? new ObjectParameter("TypeId", typeId) : new ObjectParameter("TypeId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (montlyFromDate.HasValue ? new ObjectParameter("MontlyFromDate", montlyFromDate) : new ObjectParameter("MontlyFromDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (montlyToDate.HasValue ? new ObjectParameter("MontlyToDate", montlyToDate) : new ObjectParameter("MontlyToDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (yearlyFromDate.HasValue ? new ObjectParameter("YearlyFromDate", yearlyFromDate) : new ObjectParameter("YearlyFromDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = (yearlyToDate.HasValue ? new ObjectParameter("YearlyToDate", yearlyToDate) : new ObjectParameter("YearlyToDate", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnLeaveSummary_Result>("MobspReturnLeaveSummary", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<MobspSelectClosedCalendarEvents_Result> MobspSelectClosedCalendarEvents(DateTime? fromDate, DateTime? toDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectClosedCalendarEvents_Result>("MobspSelectClosedCalendarEvents", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<int?> MobspDeleteLeave(int? leaveId)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspDeleteLeave", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<int?> MobspInsertUpdateLeave(int? leaveId, int? leaveTypeId, int? requestUserId, int? replaceUserId, DateTime? fromDateTime, string fromDate, DateTime? toDateTime, string toDate, int? dayCount, string fromTime, string toTime, string hourCount, string reason, string description, int? kindId, string place, string placeCoordinateLatitude, string placeCoordinateLongitude, int? placeCoordinateZoomLevel, int? companyId, int? countryId, int? provinceId, int? cityId, int? vehicleTypeId, int? stayTypeId, int? leaveStatusId, int? verifierUserId, string msgLangValue, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter2 = (leaveTypeId.HasValue ? new ObjectParameter("LeaveTypeId", leaveTypeId) : new ObjectParameter("LeaveTypeId", typeof(int)));
		ObjectParameter objectParameter3 = (requestUserId.HasValue ? new ObjectParameter("RequestUserId", requestUserId) : new ObjectParameter("RequestUserId", typeof(int)));
		ObjectParameter objectParameter4 = (replaceUserId.HasValue ? new ObjectParameter("ReplaceUserId", replaceUserId) : new ObjectParameter("ReplaceUserId", typeof(int)));
		ObjectParameter objectParameter5 = (fromDateTime.HasValue ? new ObjectParameter("FromDateTime", fromDateTime) : new ObjectParameter("FromDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((fromDate != null) ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(string)));
		ObjectParameter objectParameter7 = (toDateTime.HasValue ? new ObjectParameter("ToDateTime", toDateTime) : new ObjectParameter("ToDateTime", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((toDate != null) ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(string)));
		ObjectParameter objectParameter9 = (dayCount.HasValue ? new ObjectParameter("DayCount", dayCount) : new ObjectParameter("DayCount", typeof(int)));
		ObjectParameter objectParameter10 = ((fromTime != null) ? new ObjectParameter("FromTime", fromTime) : new ObjectParameter("FromTime", typeof(string)));
		ObjectParameter objectParameter11 = ((toTime != null) ? new ObjectParameter("ToTime", toTime) : new ObjectParameter("ToTime", typeof(string)));
		ObjectParameter objectParameter12 = ((hourCount != null) ? new ObjectParameter("HourCount", hourCount) : new ObjectParameter("HourCount", typeof(string)));
		ObjectParameter objectParameter13 = ((reason != null) ? new ObjectParameter("Reason", reason) : new ObjectParameter("Reason", typeof(string)));
		ObjectParameter objectParameter14 = ((description != null) ? new ObjectParameter("Description", description) : new ObjectParameter("Description", typeof(string)));
		ObjectParameter objectParameter15 = (kindId.HasValue ? new ObjectParameter("KindId", kindId) : new ObjectParameter("KindId", typeof(int)));
		ObjectParameter objectParameter16 = ((place != null) ? new ObjectParameter("Place", place) : new ObjectParameter("Place", typeof(string)));
		ObjectParameter objectParameter17 = ((placeCoordinateLatitude != null) ? new ObjectParameter("PlaceCoordinateLatitude", placeCoordinateLatitude) : new ObjectParameter("PlaceCoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter18 = ((placeCoordinateLongitude != null) ? new ObjectParameter("PlaceCoordinateLongitude", placeCoordinateLongitude) : new ObjectParameter("PlaceCoordinateLongitude", typeof(string)));
		ObjectParameter objectParameter19 = (placeCoordinateZoomLevel.HasValue ? new ObjectParameter("PlaceCoordinateZoomLevel", placeCoordinateZoomLevel) : new ObjectParameter("PlaceCoordinateZoomLevel", typeof(int)));
		ObjectParameter objectParameter20 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter21 = (countryId.HasValue ? new ObjectParameter("CountryId", countryId) : new ObjectParameter("CountryId", typeof(int)));
		ObjectParameter objectParameter22 = (provinceId.HasValue ? new ObjectParameter("ProvinceId", provinceId) : new ObjectParameter("ProvinceId", typeof(int)));
		ObjectParameter objectParameter23 = (cityId.HasValue ? new ObjectParameter("CityId", cityId) : new ObjectParameter("CityId", typeof(int)));
		ObjectParameter objectParameter24 = (vehicleTypeId.HasValue ? new ObjectParameter("VehicleTypeId", vehicleTypeId) : new ObjectParameter("VehicleTypeId", typeof(int)));
		ObjectParameter objectParameter25 = (stayTypeId.HasValue ? new ObjectParameter("StayTypeId", stayTypeId) : new ObjectParameter("StayTypeId", typeof(int)));
		ObjectParameter objectParameter26 = (leaveStatusId.HasValue ? new ObjectParameter("LeaveStatusId", leaveStatusId) : new ObjectParameter("LeaveStatusId", typeof(int)));
		ObjectParameter objectParameter27 = (verifierUserId.HasValue ? new ObjectParameter("VerifierUserId", verifierUserId) : new ObjectParameter("VerifierUserId", typeof(int)));
		ObjectParameter objectParameter28 = ((msgLangValue != null) ? new ObjectParameter("msgLangValue", msgLangValue) : new ObjectParameter("msgLangValue", typeof(string)));
		ObjectParameter objectParameter29 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter30 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter31 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter32 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter33 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter34 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter35 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter36 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertUpdateLeave", new ObjectParameter[37]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, result
		});
	}

	public virtual ObjectResult<MobspSelectLeaveKinds_Result> MobspSelectLeaveKinds(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLeaveKinds_Result>("MobspSelectLeaveKinds", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectLeaveStayType_Result> MobspSelectLeaveStayType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLeaveStayType_Result>("MobspSelectLeaveStayType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectLeaveType_Result> MobspSelectLeaveType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLeaveType_Result>("MobspSelectLeaveType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectLeaveVehicleType_Result> MobspSelectLeaveVehicleType(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLeaveVehicleType_Result>("MobspSelectLeaveVehicleType", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectAlternativeUsers_Result> MobspSelectAlternativeUsers(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectAlternativeUsers_Result>("MobspSelectAlternativeUsers", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspLeaveVerifyExit(int? leaveId)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLeaveVerifyExit", objectParameter);
	}

	public virtual ObjectResult<int?> MobspSelectLeaveCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspSelectLeaveCnt", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<MobspIntMsgGetAttachRecIdMessageHistory_Result> MobspIntMsgGetAttachRecIdMessageHistory(int? msgdTypeId, int? msgdAttachRecId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (msgdTypeId.HasValue ? new ObjectParameter("MsgdTypeId", msgdTypeId) : new ObjectParameter("MsgdTypeId", typeof(int)));
		ObjectParameter objectParameter2 = (msgdAttachRecId.HasValue ? new ObjectParameter("MsgdAttachRecId", msgdAttachRecId) : new ObjectParameter("MsgdAttachRecId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspIntMsgGetAttachRecIdMessageHistory_Result>("MobspIntMsgGetAttachRecIdMessageHistory", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectVerificationRequests_Result> MobspSelectVerificationRequests(int? verificationRequestId, int? objectId, int? objectType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = (objectType.HasValue ? new ObjectParameter("ObjectType", objectType) : new ObjectParameter("ObjectType", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationRequests_Result>("MobspSelectVerificationRequests", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectVerificationWorkFlows_Result> MobspSelectVerificationWorkFlows(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationWorkFlows_Result>("MobspSelectVerificationWorkFlows", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspSendVerificationRequest(int? verificationWorkFlowId, int? objectId, string verificationReqText, string verificationReqTextLang, string msgSubject, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, ObjectParameter result, int? verificationReqUserId, ObjectParameter internalMessageId, int? centerId)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSendVerificationRequest", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, result, objectParameter14, internalMessageId, objectParameter15);
	}

	public virtual int MobspSendVerificationRequestToAlternateUser(int? verificationWorkFlowId, int? objectId, string verificationReqText, string verificationReqTextLang, string msgSubject, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, ObjectParameter result, int? verificationReqUserId, int? centerId)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspSendVerificationRequestToAlternateUser", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, result, objectParameter14, objectParameter15);
	}

	public virtual ObjectResult<MobspSelectVerificationRequestDetails_Result> MobspSelectVerificationRequestDetails(int? verificationRequestDetailId, int? verificationRequestId, int? verificationWorkFlowId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (verificationRequestDetailId.HasValue ? new ObjectParameter("VerificationRequestDetailId", verificationRequestDetailId) : new ObjectParameter("VerificationRequestDetailId", typeof(int)));
		ObjectParameter objectParameter2 = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter3 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter4 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationRequestDetails_Result>("MobspSelectVerificationRequestDetails", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual int MobspLeaveReplaceUserVerify(int? leaveId, DateTime? verifiedRegisterDate, string verifiedRegisterDatePersian)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter2 = (verifiedRegisterDate.HasValue ? new ObjectParameter("VerifiedRegisterDate", verifiedRegisterDate) : new ObjectParameter("VerifiedRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = ((verifiedRegisterDatePersian != null) ? new ObjectParameter("VerifiedRegisterDatePersian", verifiedRegisterDatePersian) : new ObjectParameter("VerifiedRegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLeaveReplaceUserVerify", objectParameter, objectParameter2, objectParameter3);
	}

	public virtual int MobspLeaveReplaceUserVerifyExit(int? leaveId)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLeaveReplaceUserVerifyExit", objectParameter);
	}

	public virtual ObjectResult<MobspReturnLeaveSummaryCalendar_Result> MobspReturnLeaveSummaryCalendar(int? oprType, int? requestUserId, DateTime? fromDate, DateTime? toDate, int? userId, int? languageID, int? defaultLanguageID, int? mode)
	{
		ObjectParameter objectParameter = (oprType.HasValue ? new ObjectParameter("OprType", oprType) : new ObjectParameter("OprType", typeof(int)));
		ObjectParameter objectParameter2 = (requestUserId.HasValue ? new ObjectParameter("RequestUserId", requestUserId) : new ObjectParameter("RequestUserId", typeof(int)));
		ObjectParameter objectParameter3 = (fromDate.HasValue ? new ObjectParameter("FromDate", fromDate) : new ObjectParameter("FromDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = (toDate.HasValue ? new ObjectParameter("ToDate", toDate) : new ObjectParameter("ToDate", typeof(DateTime)));
		ObjectParameter objectParameter5 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter8 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspReturnLeaveSummaryCalendar_Result>("MobspReturnLeaveSummaryCalendar", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8 });
	}

	public virtual ObjectResult<int?> MobspIntMsgGetUnReadMessgeCnt(int? userID, int? centerId)
	{
		ObjectParameter objectParameter = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter2 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspIntMsgGetUnReadMessgeCnt", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<int?> MobspReturnLetterTypeIdFromLetterId(int? letterId)
	{
		ObjectParameter objectParameter = (letterId.HasValue ? new ObjectParameter("LetterId", letterId) : new ObjectParameter("LetterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspReturnLetterTypeIdFromLetterId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectLeave_Result> MobspSelectLeave(int? crmUserId, int? leaveId, int? leaveTypeId, int? userId, DateTime? fDateTime, DateTime? tDateTime, int? pageNumber, int? pageSize, int? languageID, int? defaultLanguageID, int? leaveStatusId, int? centerId)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter3 = (leaveTypeId.HasValue ? new ObjectParameter("LeaveTypeId", leaveTypeId) : new ObjectParameter("LeaveTypeId", typeof(int)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter8 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (leaveStatusId.HasValue ? new ObjectParameter("LeaveStatusId", leaveStatusId) : new ObjectParameter("LeaveStatusId", typeof(int)));
		ObjectParameter objectParameter12 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectLeave_Result>("MobspSelectLeave", new ObjectParameter[12]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12
		});
	}

	public virtual int MobspLeaveCancel(int? leaveId, int? cancelerUserId, DateTime? canceledRegisterDate, string canceledRegisterDatePersian)
	{
		ObjectParameter objectParameter = (leaveId.HasValue ? new ObjectParameter("LeaveId", leaveId) : new ObjectParameter("LeaveId", typeof(int)));
		ObjectParameter objectParameter2 = (cancelerUserId.HasValue ? new ObjectParameter("CancelerUserId", cancelerUserId) : new ObjectParameter("CancelerUserId", typeof(int)));
		ObjectParameter objectParameter3 = (canceledRegisterDate.HasValue ? new ObjectParameter("CanceledRegisterDate", canceledRegisterDate) : new ObjectParameter("CanceledRegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter4 = ((canceledRegisterDatePersian != null) ? new ObjectParameter("CanceledRegisterDatePersian", canceledRegisterDatePersian) : new ObjectParameter("CanceledRegisterDatePersian", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspLeaveCancel", objectParameter, objectParameter2, objectParameter3, objectParameter4);
	}

	public virtual ObjectResult<MobspLoadUserTasks_Result> MobspLoadUserTasks(DateTime? date, int? userId, int? languageID, int? defaultLanguageID, bool? selectWithCnvs, int? crmUserId, int? centerId, int? userTaskGroupId, int? userTaskPriorityId, int? userTaskDidItStatus)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspLoadUserTasks_Result>("MobspLoadUserTasks", new ObjectParameter[10] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10 });
	}

	public virtual ObjectResult<MobspSelectUserOrderCommissionsChartByCmp_Result> MobspSelectUserOrderCommissionsChartByCmp(int? crmUserId, int? mode, DateTime? fDateTime, DateTime? tDateTime, int? languageID, int? defaultLanguageID, string crmUserIds, bool? isShowSameOrder, int? commissionKindId, int? companyId, bool? isVerified, bool? isNotVerified, bool? isPaied, bool? isNotPaied, DateTime? effectiveFromDate, DateTime? effectiveToDate, DateTime? ordFromDate, DateTime? ordToDate, double? percentFrom, double? percentTo, bool? isPreVerified, bool? isNotPreVerified)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = ((crmUserIds != null) ? new ObjectParameter("CrmUserIds", crmUserIds) : new ObjectParameter("CrmUserIds", typeof(string)));
		ObjectParameter objectParameter8 = (isShowSameOrder.HasValue ? new ObjectParameter("IsShowSameOrder", isShowSameOrder) : new ObjectParameter("IsShowSameOrder", typeof(bool)));
		ObjectParameter objectParameter9 = (commissionKindId.HasValue ? new ObjectParameter("CommissionKindId", commissionKindId) : new ObjectParameter("CommissionKindId", typeof(int)));
		ObjectParameter objectParameter10 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter11 = (isVerified.HasValue ? new ObjectParameter("IsVerified", isVerified) : new ObjectParameter("IsVerified", typeof(bool)));
		ObjectParameter objectParameter12 = (isNotVerified.HasValue ? new ObjectParameter("IsNotVerified", isNotVerified) : new ObjectParameter("IsNotVerified", typeof(bool)));
		ObjectParameter objectParameter13 = (isPaied.HasValue ? new ObjectParameter("IsPaied", isPaied) : new ObjectParameter("IsPaied", typeof(bool)));
		ObjectParameter objectParameter14 = (isNotPaied.HasValue ? new ObjectParameter("IsNotPaied", isNotPaied) : new ObjectParameter("IsNotPaied", typeof(bool)));
		ObjectParameter objectParameter15 = (effectiveFromDate.HasValue ? new ObjectParameter("EffectiveFromDate", effectiveFromDate) : new ObjectParameter("EffectiveFromDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = (effectiveToDate.HasValue ? new ObjectParameter("EffectiveToDate", effectiveToDate) : new ObjectParameter("EffectiveToDate", typeof(DateTime)));
		ObjectParameter objectParameter17 = (ordFromDate.HasValue ? new ObjectParameter("OrdFromDate", ordFromDate) : new ObjectParameter("OrdFromDate", typeof(DateTime)));
		ObjectParameter objectParameter18 = (ordToDate.HasValue ? new ObjectParameter("OrdToDate", ordToDate) : new ObjectParameter("OrdToDate", typeof(DateTime)));
		ObjectParameter objectParameter19 = (percentFrom.HasValue ? new ObjectParameter("PercentFrom", percentFrom) : new ObjectParameter("PercentFrom", typeof(double)));
		ObjectParameter objectParameter20 = (percentTo.HasValue ? new ObjectParameter("PercentTo", percentTo) : new ObjectParameter("PercentTo", typeof(double)));
		ObjectParameter objectParameter21 = (isPreVerified.HasValue ? new ObjectParameter("IsPreVerified", isPreVerified) : new ObjectParameter("IsPreVerified", typeof(bool)));
		ObjectParameter objectParameter22 = (isNotPreVerified.HasValue ? new ObjectParameter("IsNotPreVerified", isNotPreVerified) : new ObjectParameter("IsNotPreVerified", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserOrderCommissionsChartByCmp_Result>("MobspSelectUserOrderCommissionsChartByCmp", new ObjectParameter[22]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22
		});
	}

	public virtual ObjectResult<MobspSelectUserOrderCommissionsChartByUser_Result> MobspSelectUserOrderCommissionsChartByUser(int? crmUserId, int? mode, DateTime? fDateTime, DateTime? tDateTime, int? languageID, int? defaultLanguageID, string crmUserIds, bool? isShowSameOrder, int? commissionKindId, int? companyId, bool? isVerified, bool? isNotVerified, bool? isPaied, bool? isNotPaied, DateTime? effectiveFromDate, DateTime? effectiveToDate, DateTime? ordFromDate, DateTime? ordToDate, double? percentFrom, double? percentTo, bool? isPreVerified, bool? isNotPreVerified)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter7 = ((crmUserIds != null) ? new ObjectParameter("CrmUserIds", crmUserIds) : new ObjectParameter("CrmUserIds", typeof(string)));
		ObjectParameter objectParameter8 = (isShowSameOrder.HasValue ? new ObjectParameter("IsShowSameOrder", isShowSameOrder) : new ObjectParameter("IsShowSameOrder", typeof(bool)));
		ObjectParameter objectParameter9 = (commissionKindId.HasValue ? new ObjectParameter("CommissionKindId", commissionKindId) : new ObjectParameter("CommissionKindId", typeof(int)));
		ObjectParameter objectParameter10 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter11 = (isVerified.HasValue ? new ObjectParameter("IsVerified", isVerified) : new ObjectParameter("IsVerified", typeof(bool)));
		ObjectParameter objectParameter12 = (isNotVerified.HasValue ? new ObjectParameter("IsNotVerified", isNotVerified) : new ObjectParameter("IsNotVerified", typeof(bool)));
		ObjectParameter objectParameter13 = (isPaied.HasValue ? new ObjectParameter("IsPaied", isPaied) : new ObjectParameter("IsPaied", typeof(bool)));
		ObjectParameter objectParameter14 = (isNotPaied.HasValue ? new ObjectParameter("IsNotPaied", isNotPaied) : new ObjectParameter("IsNotPaied", typeof(bool)));
		ObjectParameter objectParameter15 = (effectiveFromDate.HasValue ? new ObjectParameter("EffectiveFromDate", effectiveFromDate) : new ObjectParameter("EffectiveFromDate", typeof(DateTime)));
		ObjectParameter objectParameter16 = (effectiveToDate.HasValue ? new ObjectParameter("EffectiveToDate", effectiveToDate) : new ObjectParameter("EffectiveToDate", typeof(DateTime)));
		ObjectParameter objectParameter17 = (ordFromDate.HasValue ? new ObjectParameter("OrdFromDate", ordFromDate) : new ObjectParameter("OrdFromDate", typeof(DateTime)));
		ObjectParameter objectParameter18 = (ordToDate.HasValue ? new ObjectParameter("OrdToDate", ordToDate) : new ObjectParameter("OrdToDate", typeof(DateTime)));
		ObjectParameter objectParameter19 = (percentFrom.HasValue ? new ObjectParameter("PercentFrom", percentFrom) : new ObjectParameter("PercentFrom", typeof(double)));
		ObjectParameter objectParameter20 = (percentTo.HasValue ? new ObjectParameter("PercentTo", percentTo) : new ObjectParameter("PercentTo", typeof(double)));
		ObjectParameter objectParameter21 = (isPreVerified.HasValue ? new ObjectParameter("IsPreVerified", isPreVerified) : new ObjectParameter("IsPreVerified", typeof(bool)));
		ObjectParameter objectParameter22 = (isNotPreVerified.HasValue ? new ObjectParameter("IsNotPreVerified", isNotPreVerified) : new ObjectParameter("IsNotPreVerified", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserOrderCommissionsChartByUser_Result>("MobspSelectUserOrderCommissionsChartByUser", new ObjectParameter[22]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22
		});
	}

	public virtual ObjectResult<MobspSelectUserOrderCommissions_Result> MobspSelectUserOrderCommissions(int? rptUserId, string rptDate, string rptDay, int? crmUserId, DateTime? fDateTime, DateTime? tDateTime, int? pageSize, int? pageNumber, int? languageID, int? defaultLanguageID, string crmUserIds, bool? isShowSameOrder, int? commissionKindId, int? companyId, bool? isVerified, bool? isNotVerified, bool? isPaied, bool? isNotPaied, DateTime? effectiveFromDate, DateTime? effectiveToDate, DateTime? ordFromDate, DateTime? ordToDate, double? percentFrom, double? percentTo, int? centerId, bool? isPreVerified, bool? isNotPreVerified)
	{
		ObjectParameter objectParameter = (rptUserId.HasValue ? new ObjectParameter("rptUserId", rptUserId) : new ObjectParameter("rptUserId", typeof(int)));
		ObjectParameter objectParameter2 = ((rptDate != null) ? new ObjectParameter("rptDate", rptDate) : new ObjectParameter("rptDate", typeof(string)));
		ObjectParameter objectParameter3 = ((rptDay != null) ? new ObjectParameter("rptDay", rptDay) : new ObjectParameter("rptDay", typeof(string)));
		ObjectParameter objectParameter4 = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter5 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter6 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter7 = (pageSize.HasValue ? new ObjectParameter("PageSize", pageSize) : new ObjectParameter("PageSize", typeof(int)));
		ObjectParameter objectParameter8 = (pageNumber.HasValue ? new ObjectParameter("PageNumber", pageNumber) : new ObjectParameter("PageNumber", typeof(int)));
		ObjectParameter objectParameter9 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter10 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter11 = ((crmUserIds != null) ? new ObjectParameter("CrmUserIds", crmUserIds) : new ObjectParameter("CrmUserIds", typeof(string)));
		ObjectParameter objectParameter12 = (isShowSameOrder.HasValue ? new ObjectParameter("IsShowSameOrder", isShowSameOrder) : new ObjectParameter("IsShowSameOrder", typeof(bool)));
		ObjectParameter objectParameter13 = (commissionKindId.HasValue ? new ObjectParameter("CommissionKindId", commissionKindId) : new ObjectParameter("CommissionKindId", typeof(int)));
		ObjectParameter objectParameter14 = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter15 = (isVerified.HasValue ? new ObjectParameter("IsVerified", isVerified) : new ObjectParameter("IsVerified", typeof(bool)));
		ObjectParameter objectParameter16 = (isNotVerified.HasValue ? new ObjectParameter("IsNotVerified", isNotVerified) : new ObjectParameter("IsNotVerified", typeof(bool)));
		ObjectParameter objectParameter17 = (isPaied.HasValue ? new ObjectParameter("IsPaied", isPaied) : new ObjectParameter("IsPaied", typeof(bool)));
		ObjectParameter objectParameter18 = (isNotPaied.HasValue ? new ObjectParameter("IsNotPaied", isNotPaied) : new ObjectParameter("IsNotPaied", typeof(bool)));
		ObjectParameter objectParameter19 = (effectiveFromDate.HasValue ? new ObjectParameter("EffectiveFromDate", effectiveFromDate) : new ObjectParameter("EffectiveFromDate", typeof(DateTime)));
		ObjectParameter objectParameter20 = (effectiveToDate.HasValue ? new ObjectParameter("EffectiveToDate", effectiveToDate) : new ObjectParameter("EffectiveToDate", typeof(DateTime)));
		ObjectParameter objectParameter21 = (ordFromDate.HasValue ? new ObjectParameter("OrdFromDate", ordFromDate) : new ObjectParameter("OrdFromDate", typeof(DateTime)));
		ObjectParameter objectParameter22 = (ordToDate.HasValue ? new ObjectParameter("OrdToDate", ordToDate) : new ObjectParameter("OrdToDate", typeof(DateTime)));
		ObjectParameter objectParameter23 = (percentFrom.HasValue ? new ObjectParameter("PercentFrom", percentFrom) : new ObjectParameter("PercentFrom", typeof(double)));
		ObjectParameter objectParameter24 = (percentTo.HasValue ? new ObjectParameter("PercentTo", percentTo) : new ObjectParameter("PercentTo", typeof(double)));
		ObjectParameter objectParameter25 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		ObjectParameter objectParameter26 = (isPreVerified.HasValue ? new ObjectParameter("IsPreVerified", isPreVerified) : new ObjectParameter("IsPreVerified", typeof(bool)));
		ObjectParameter objectParameter27 = (isNotPreVerified.HasValue ? new ObjectParameter("IsNotPreVerified", isNotPreVerified) : new ObjectParameter("IsNotPreVerified", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserOrderCommissions_Result>("MobspSelectUserOrderCommissions", new ObjectParameter[27]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27
		});
	}

	public virtual ObjectResult<MobspSelectConversationDefaultContext_Result> MobspSelectConversationDefaultContext(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationDefaultContext_Result>("MobspSelectConversationDefaultContext", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspknlgSelectKnowledgeTankByIds_Result> MobspknlgSelectKnowledgeTankByIds(string knowledgeTankIds, int? rollId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((knowledgeTankIds != null) ? new ObjectParameter("KnowledgeTankIds", knowledgeTankIds) : new ObjectParameter("KnowledgeTankIds", typeof(string)));
		ObjectParameter objectParameter2 = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspknlgSelectKnowledgeTankByIds_Result>("MobspknlgSelectKnowledgeTankByIds", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectConversationWithID_Result> MobspSelectConversationWithID(int? conversationId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (conversationId.HasValue ? new ObjectParameter("ConversationId", conversationId) : new ObjectParameter("ConversationId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectConversationWithID_Result>("MobspSelectConversationWithID", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectOrderPayments_Result> MobspSelectOrderPayments(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderPayments_Result>("MobspSelectOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectPreOrderPayments_Result> MobspSelectPreOrderPayments(int? preOrderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderPayments_Result>("MobspSelectPreOrderPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<decimal?> MobspReturnCompanyMoneyBagRemain(int? companyId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<decimal?>("MobspReturnCompanyMoneyBagRemain", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectActiveOrderPaymentTypes_Result> MobspSelectActiveOrderPaymentTypes(int? languageID, int? defaultLanguageID, int? userId)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectActiveOrderPaymentTypes_Result>("MobspSelectActiveOrderPaymentTypes", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<HRMMobPayRollspReturnUserCycleFinalAmount_Result> HRMMobPayRollspReturnUserCycleFinalAmount(int? cycleId)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobPayRollspReturnUserCycleFinalAmount_Result>("HRMMobPayRollspReturnUserCycleFinalAmount", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<HRMMobPayRollspSelectUserCycle_Result> HRMMobPayRollspSelectUserCycle(int? crmUserId, int? cycleId, DateTime? fDateTime, DateTime? tDateTime, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (crmUserId.HasValue ? new ObjectParameter("CrmUserId", crmUserId) : new ObjectParameter("CrmUserId", typeof(int)));
		ObjectParameter objectParameter2 = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter3 = (fDateTime.HasValue ? new ObjectParameter("FDateTime", fDateTime) : new ObjectParameter("FDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (tDateTime.HasValue ? new ObjectParameter("TDateTime", tDateTime) : new ObjectParameter("TDateTime", typeof(DateTime)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobPayRollspSelectUserCycle_Result>("HRMMobPayRollspSelectUserCycle", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<HRMMobPayRollspSelectUserCycleItemValues_Result> HRMMobPayRollspSelectUserCycleItemValues(int? cycleId, int? itemKind, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (itemKind.HasValue ? new ObjectParameter("ItemKind", itemKind) : new ObjectParameter("ItemKind", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobPayRollspSelectUserCycleItemValues_Result>("HRMMobPayRollspSelectUserCycleItemValues", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<HRMMobPayRollspSelectUserPayments_Result> HRMMobPayRollspSelectUserPayments(int? cycleId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobPayRollspSelectUserPayments_Result>("HRMMobPayRollspSelectUserPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<HRMMobspSelectUserSignatureByUserId_Result> HRMMobspSelectUserSignatureByUserId(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobspSelectUserSignatureByUserId_Result>("HRMMobspSelectUserSignatureByUserId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<MobspSelectUserSignatureByUserId_Result> MobspSelectUserSignatureByUserId(int? userId)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserSignatureByUserId_Result>("MobspSelectUserSignatureByUserId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<PayRollspPrintUserCycle_Result> PayRollspPrintUserCycle(int? cycleId, int? rptUserId, string rptDate, string rptDay, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (rptUserId.HasValue ? new ObjectParameter("RptUserId", rptUserId) : new ObjectParameter("RptUserId", typeof(int)));
		ObjectParameter objectParameter3 = ((rptDate != null) ? new ObjectParameter("RptDate", rptDate) : new ObjectParameter("RptDate", typeof(string)));
		ObjectParameter objectParameter4 = ((rptDay != null) ? new ObjectParameter("RptDay", rptDay) : new ObjectParameter("RptDay", typeof(string)));
		ObjectParameter objectParameter5 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter6 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PayRollspPrintUserCycle_Result>("PayRollspPrintUserCycle", new ObjectParameter[6] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6 });
	}

	public virtual ObjectResult<PayRollspPrintUserCycleOrderCommissions_Result> PayRollspPrintUserCycleOrderCommissions(int? cycleId, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PayRollspPrintUserCycleOrderCommissions_Result>("PayRollspPrintUserCycleOrderCommissions", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<PayRollspPrintUserPayments_Result> PayRollspPrintUserPayments(int? cycleId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PayRollspPrintUserPayments_Result>("PayRollspPrintUserPayments", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<int?> HRMMobspSelectLeaveCnt()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("HRMMobspSelectLeaveCnt", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<HRMMobPayRollspSelectUserCycleOrderCommissions_Result> HRMMobPayRollspSelectUserCycleOrderCommissions(int? cycleId, int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HRMMobPayRollspSelectUserCycleOrderCommissions_Result>("HRMMobPayRollspSelectUserCycleOrderCommissions", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<PayRollspPrintUserCycleItemValuesInfo_Result> PayRollspPrintUserCycleItemValuesInfo(int? cycleId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PayRollspPrintUserCycleItemValuesInfo_Result>("PayRollspPrintUserCycleItemValuesInfo", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<PayRollspPrintUserCycleItemValues_Result> PayRollspPrintUserCycleItemValues(int? cycleId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (cycleId.HasValue ? new ObjectParameter("CycleId", cycleId) : new ObjectParameter("CycleId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PayRollspPrintUserCycleItemValues_Result>("PayRollspPrintUserCycleItemValues", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspInsertUserAppDeviceInfo(int? userId, string deviceId, int? deviceType, string appName, DateTime? firstRegisterDate, string firstRegisterDatePersian, string appType, string imeiCode, string deviceProperty, string aESKey)
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
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertUserAppDeviceInfo", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10);
	}

	public virtual int MobspInsertUpdateMultiUserMovementTracking(string coordinateJson, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID)
	{
		ObjectParameter objectParameter = ((coordinateJson != null) ? new ObjectParameter("CoordinateJson", coordinateJson) : new ObjectParameter("CoordinateJson", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter4 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter8 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspInsertUpdateMultiUserMovementTracking", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8);
	}

	public virtual ObjectResult<int?> MobspInsertQuickPrjCnvsForDuplicate(int? companyId, int? companyPersonId, string company, string personList, string projectList, string conversationList, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID, ObjectParameter errorMessage, ObjectParameter insertedPersonIds, ObjectParameter insertedProjectIds, ObjectParameter insertedConversationIds, int? centerId)
	{
		ObjectParameter objectParameter = (companyId.HasValue ? new ObjectParameter("CompanyId", companyId) : new ObjectParameter("CompanyId", typeof(int)));
		ObjectParameter objectParameter2 = (companyPersonId.HasValue ? new ObjectParameter("CompanyPersonId", companyPersonId) : new ObjectParameter("CompanyPersonId", typeof(int)));
		ObjectParameter objectParameter3 = ((company != null) ? new ObjectParameter("Company", company) : new ObjectParameter("Company", typeof(string)));
		ObjectParameter objectParameter4 = ((personList != null) ? new ObjectParameter("PersonList", personList) : new ObjectParameter("PersonList", typeof(string)));
		ObjectParameter objectParameter5 = ((projectList != null) ? new ObjectParameter("ProjectList", projectList) : new ObjectParameter("ProjectList", typeof(string)));
		ObjectParameter objectParameter6 = ((conversationList != null) ? new ObjectParameter("ConversationList", conversationList) : new ObjectParameter("ConversationList", typeof(string)));
		ObjectParameter objectParameter7 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter8 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter9 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter13 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter14 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter15 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("MobspInsertQuickPrjCnvsForDuplicate", new ObjectParameter[19]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, errorMessage, insertedPersonIds, insertedProjectIds, insertedConversationIds, objectParameter15
		});
	}

	public virtual ObjectResult<MobspSelectOrderDefaultSettingByReferUserId_Result> MobspSelectOrderDefaultSettingByReferUserId(int? referUserId, DateTime? registerDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderDefaultSettingByReferUserId_Result>("MobspSelectOrderDefaultSettingByReferUserId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectOrderWithID_Result> MobspSelectOrderWithID(int? orderId, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderWithID_Result>("MobspSelectOrderWithID", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<MobspSelectPreOrderDefaultSettingByReferUserId_Result> MobspSelectPreOrderDefaultSettingByReferUserId(int? referUserId, DateTime? registerDate, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (referUserId.HasValue ? new ObjectParameter("ReferUserId", referUserId) : new ObjectParameter("ReferUserId", typeof(int)));
		ObjectParameter objectParameter2 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderDefaultSettingByReferUserId_Result>("MobspSelectPreOrderDefaultSettingByReferUserId", new ObjectParameter[4] { objectParameter, objectParameter2, objectParameter3, objectParameter4 });
	}

	public virtual ObjectResult<MobspSelectPreOrderWithID_Result> MobspSelectPreOrderWithID(int? preOrderId, int? userId, int? languageID, int? defaultLanguageID, int? centerId)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter4 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter5 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectPreOrderWithID_Result>("MobspSelectPreOrderWithID", new ObjectParameter[5] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5 });
	}

	public virtual ObjectResult<mct_Result> MobspAddProjectProductHistoryFromOrder(int? orderId, bool? addPrdValidity, string addPrdValidityPrjTitle, int? userId, short? year1, short? month1, DateTime? registerDate, string registerDatePersian, string appType, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (addPrdValidity.HasValue ? new ObjectParameter("AddPrdValidity", addPrdValidity) : new ObjectParameter("AddPrdValidity", typeof(bool)));
		ObjectParameter objectParameter3 = ((addPrdValidityPrjTitle != null) ? new ObjectParameter("AddPrdValidityPrjTitle", addPrdValidityPrjTitle) : new ObjectParameter("AddPrdValidityPrjTitle", typeof(string)));
		ObjectParameter objectParameter4 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter5 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter6 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter10 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter11 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mct_Result>("MobspAddProjectProductHistoryFromOrder", new ObjectParameter[11]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11
		});
	}

	public virtual ObjectResult<MobspSelectProjectTitlesByVal_Result> MobspSelectProjectTitlesByVal(string val, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = ((val != null) ? new ObjectParameter("Val", val) : new ObjectParameter("Val", typeof(string)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectTitlesByVal_Result>("MobspSelectProjectTitlesByVal", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspUpdateUserMobAppDevSetting_Result> MobspUpdateUserMobAppDevSetting(string value, int? userId, short? month1, int? registerUserId, DateTime? registerDate, string registerDatePersian, string appType)
	{
		ObjectParameter objectParameter = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter2 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter3 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter4 = (registerUserId.HasValue ? new ObjectParameter("RegisterUserId", registerUserId) : new ObjectParameter("RegisterUserId", typeof(int)));
		ObjectParameter objectParameter5 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter6 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter7 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspUpdateUserMobAppDevSetting_Result>("MobspUpdateUserMobAppDevSetting", new ObjectParameter[7] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7 });
	}

	public virtual int MobspChangePriceInOrderItems(int? orderId, int? mode, string orderItemIds, decimal? amount, decimal? amountPercent, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = ((orderItemIds != null) ? new ObjectParameter("OrderItemIds", orderItemIds) : new ObjectParameter("OrderItemIds", typeof(string)));
		ObjectParameter objectParameter4 = (amount.HasValue ? new ObjectParameter("Amount", amount) : new ObjectParameter("Amount", typeof(decimal)));
		ObjectParameter objectParameter5 = (amountPercent.HasValue ? new ObjectParameter("AmountPercent", amountPercent) : new ObjectParameter("AmountPercent", typeof(decimal)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspChangePriceInOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, result);
	}

	public virtual int MobspChangePriceInPreOrderItems(int? preOrderId, int? mode, string preOrderItemIds, decimal? amount, decimal? amountPercent, int? userId, int? fPId, short? month1, DateTime? registerDate, string registerDatePersian, string appType, ObjectParameter result)
	{
		ObjectParameter objectParameter = (preOrderId.HasValue ? new ObjectParameter("PreOrderId", preOrderId) : new ObjectParameter("PreOrderId", typeof(int)));
		ObjectParameter objectParameter2 = (mode.HasValue ? new ObjectParameter("Mode", mode) : new ObjectParameter("Mode", typeof(int)));
		ObjectParameter objectParameter3 = ((preOrderItemIds != null) ? new ObjectParameter("PreOrderItemIds", preOrderItemIds) : new ObjectParameter("PreOrderItemIds", typeof(string)));
		ObjectParameter objectParameter4 = (amount.HasValue ? new ObjectParameter("Amount", amount) : new ObjectParameter("Amount", typeof(decimal)));
		ObjectParameter objectParameter5 = (amountPercent.HasValue ? new ObjectParameter("AmountPercent", amountPercent) : new ObjectParameter("AmountPercent", typeof(decimal)));
		ObjectParameter objectParameter6 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter7 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter8 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter9 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter10 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter11 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspChangePriceInPreOrderItems", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, result);
	}

	public virtual ObjectResult<MobspSelectProjectTitles_Result> MobspSelectProjectTitles(int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter2 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectProjectTitles_Result>("MobspSelectProjectTitles", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual ObjectResult<MobspSelectOrderItemsValidity_Result> MobspSelectOrderItemsValidity(int? orderId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (orderId.HasValue ? new ObjectParameter("OrderId", orderId) : new ObjectParameter("OrderId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectOrderItemsValidity_Result>("MobspSelectOrderItemsValidity", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual ObjectResult<MobspSelectUserPushNotifTankWithDeviceInfo_Result> MobspSelectUserPushNotifTankWithDeviceInfo(int? upTypeId, string appName)
	{
		ObjectParameter objectParameter = (upTypeId.HasValue ? new ObjectParameter("upTypeId", upTypeId) : new ObjectParameter("upTypeId", typeof(int)));
		ObjectParameter objectParameter2 = ((appName != null) ? new ObjectParameter("AppName", appName) : new ObjectParameter("AppName", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectUserPushNotifTankWithDeviceInfo_Result>("MobspSelectUserPushNotifTankWithDeviceInfo", new ObjectParameter[2] { objectParameter, objectParameter2 });
	}

	public virtual int MobspDeleteUserPushNotifTankByTypeId(int? upTypeId)
	{
		ObjectParameter objectParameter = (upTypeId.HasValue ? new ObjectParameter("upTypeId", upTypeId) : new ObjectParameter("upTypeId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspDeleteUserPushNotifTankByTypeId", objectParameter);
	}

	public virtual ObjectResult<MobspResultsTimeAttendanceCartable_Result> MobspResultsTimeAttendanceCartable(DateTime? fDate, DateTime? tDate, DateTime? currDateTime, int? userID, int? currUserID, int? languageID, int? defaultLanguageID, ObjectParameter executedQuery)
	{
		ObjectParameter objectParameter = (fDate.HasValue ? new ObjectParameter("FDate", fDate) : new ObjectParameter("FDate", typeof(DateTime)));
		ObjectParameter objectParameter2 = (tDate.HasValue ? new ObjectParameter("TDate", tDate) : new ObjectParameter("TDate", typeof(DateTime)));
		ObjectParameter objectParameter3 = (currDateTime.HasValue ? new ObjectParameter("CurrDateTime", currDateTime) : new ObjectParameter("CurrDateTime", typeof(DateTime)));
		ObjectParameter objectParameter4 = (userID.HasValue ? new ObjectParameter("UserID", userID) : new ObjectParameter("UserID", typeof(int)));
		ObjectParameter objectParameter5 = (currUserID.HasValue ? new ObjectParameter("CurrUserID", currUserID) : new ObjectParameter("CurrUserID", typeof(int)));
		ObjectParameter objectParameter6 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter7 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspResultsTimeAttendanceCartable_Result>("MobspResultsTimeAttendanceCartable", new ObjectParameter[8] { objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, executedQuery });
	}

	public virtual ObjectResult<MobspSelectVerificationWorkFlowSteps_Result> MobspSelectVerificationWorkFlowSteps(int? verificationWorkFlowId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MobspSelectVerificationWorkFlowSteps_Result>("MobspSelectVerificationWorkFlowSteps", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}

	public virtual int MobspVerificationRequestVerify(int? verificationWorkFlowId, int? objectId, int? verificationRequestId, int? verificationWorkFlowStepId, string verifyText, string verifyTextLang, string msgSubject, string verifiedMsgSubject, int? rollId, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter maxDiscountPercent, ObjectParameter result, int? verifyReqResultId, ObjectParameter internalMessageId, int? centerId)
	{
		ObjectParameter objectParameter = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter2 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter3 = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter4 = (verificationWorkFlowStepId.HasValue ? new ObjectParameter("VerificationWorkFlowStepId", verificationWorkFlowStepId) : new ObjectParameter("VerificationWorkFlowStepId", typeof(int)));
		ObjectParameter objectParameter5 = ((verifyText != null) ? new ObjectParameter("VerifyText", verifyText) : new ObjectParameter("VerifyText", typeof(string)));
		ObjectParameter objectParameter6 = ((verifyTextLang != null) ? new ObjectParameter("VerifyTextLang", verifyTextLang) : new ObjectParameter("VerifyTextLang", typeof(string)));
		ObjectParameter objectParameter7 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter8 = ((verifiedMsgSubject != null) ? new ObjectParameter("VerifiedMsgSubject", verifiedMsgSubject) : new ObjectParameter("VerifiedMsgSubject", typeof(string)));
		ObjectParameter objectParameter9 = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		ObjectParameter objectParameter10 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter11 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter12 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter13 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter14 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter15 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter16 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter17 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter18 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter19 = (verifyReqResultId.HasValue ? new ObjectParameter("VerifyReqResultId", verifyReqResultId) : new ObjectParameter("VerifyReqResultId", typeof(int)));
		ObjectParameter objectParameter20 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspVerificationRequestVerify", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, maxDiscountPercent, result, objectParameter19, internalMessageId, objectParameter20);
	}

	public virtual int MobspVerificationRequestExpired(int? verificationRequestId, int? verificationWorkFlowId, int? objectId, string messageText, string messageTextLang, string msgSubject, DateTime? registerDate, string registerDatePersian, int? userId, int? fPId, short? year1, short? month1, string appType, int? languageID, int? defaultLanguageID, ObjectParameter result, int? verificationReqExpiredStepId, string verificationReqExpiredText, int? rollId, int? verifyReqResultId, ObjectParameter internalMessageId, int? centerId)
	{
		ObjectParameter objectParameter = (verificationRequestId.HasValue ? new ObjectParameter("VerificationRequestId", verificationRequestId) : new ObjectParameter("VerificationRequestId", typeof(int)));
		ObjectParameter objectParameter2 = (verificationWorkFlowId.HasValue ? new ObjectParameter("VerificationWorkFlowId", verificationWorkFlowId) : new ObjectParameter("VerificationWorkFlowId", typeof(int)));
		ObjectParameter objectParameter3 = (objectId.HasValue ? new ObjectParameter("ObjectId", objectId) : new ObjectParameter("ObjectId", typeof(int)));
		ObjectParameter objectParameter4 = ((messageText != null) ? new ObjectParameter("MessageText", messageText) : new ObjectParameter("MessageText", typeof(string)));
		ObjectParameter objectParameter5 = ((messageTextLang != null) ? new ObjectParameter("MessageTextLang", messageTextLang) : new ObjectParameter("MessageTextLang", typeof(string)));
		ObjectParameter objectParameter6 = ((msgSubject != null) ? new ObjectParameter("MsgSubject", msgSubject) : new ObjectParameter("MsgSubject", typeof(string)));
		ObjectParameter objectParameter7 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter8 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter9 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter10 = (fPId.HasValue ? new ObjectParameter("FPId", fPId) : new ObjectParameter("FPId", typeof(int)));
		ObjectParameter objectParameter11 = (year1.HasValue ? new ObjectParameter("Year1", year1) : new ObjectParameter("Year1", typeof(short)));
		ObjectParameter objectParameter12 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter13 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter14 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter15 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		ObjectParameter objectParameter16 = (verificationReqExpiredStepId.HasValue ? new ObjectParameter("VerificationReqExpiredStepId", verificationReqExpiredStepId) : new ObjectParameter("VerificationReqExpiredStepId", typeof(int)));
		ObjectParameter objectParameter17 = ((verificationReqExpiredText != null) ? new ObjectParameter("VerificationReqExpiredText", verificationReqExpiredText) : new ObjectParameter("VerificationReqExpiredText", typeof(string)));
		ObjectParameter objectParameter18 = (rollId.HasValue ? new ObjectParameter("RollId", rollId) : new ObjectParameter("RollId", typeof(int)));
		ObjectParameter objectParameter19 = (verifyReqResultId.HasValue ? new ObjectParameter("VerifyReqResultId", verifyReqResultId) : new ObjectParameter("VerifyReqResultId", typeof(int)));
		ObjectParameter objectParameter20 = (centerId.HasValue ? new ObjectParameter("CenterId", centerId) : new ObjectParameter("CenterId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MobspVerificationRequestExpired", objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10, objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, result, objectParameter16, objectParameter17, objectParameter18, objectParameter19, internalMessageId, objectParameter20);
	}
}
