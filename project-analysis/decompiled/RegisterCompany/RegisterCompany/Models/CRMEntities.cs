using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace RegisterCompany.Models;

public class CRMEntities : DbContext
{
	public CRMEntities()
		: base(DbConnection.ConString)
	{
		base.Configuration.LazyLoadingEnabled = false;
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}

	public virtual ObjectResult<int?> ApispRegisterCompanyWithCnvs(string userName, string password, int? cmpNumber, string cmpName, string cmpNameEng, int? cmpTitleId, string cmpFame, string cmpActivityType, int? cmpGroupId, int? cmpSubGroupId, int? cmpGroupIdII, int? cmpGroupIdIII, int? cmpGroupIdIV, int? cmpTypeId, int? cmpPresentationId, string cmpPreTel, string cmpTel, string cmpTelUpTo, string cmpTelDesc, string cmpPreTelII, string cmpTelII, string cmpTelUpToII, string cmpTelIIDesc, string cmpMobile, string cmpFax, string cmpFaxDesc, int? cmpCountryId, int? cmpProvinceId, int? cmpCityId, string cmpAddress, string cmpAddressDesc, string cmpZipCode, string cmpPostBox, string cmpWebSite, string cmpEmail, string cmpInteresting, string cmpSpecialPoint, string cmpDescription, string cmpUserName, string cmpPassword, string cmpRegistrationNumber, string cmpEconomicCode, string cmpNationalCode, string cmpBuyLimit, string cmpAccountNumber, string cmpAccInquiry, string cmpFreight, string cmpInquiry, int? cmpReferUserId, string cmpSpecialWordForCI, string cmpCode, string cmpEffectiveDatePersian, DateTime? cmpEffectiveDateTime, string cmpCoordinateLatitude, string cmpCoordinateLongitude, DateTime? cmpCoordinateLastDate, string cmpCoordinateLastDatePersian, int? cmpCoordinateZoomLevel, int? cmpCoordinateLastUserId, string prsLName, string prsFName, int? prsTitleId, int? prsJobId, int? prsTypeId, int? prsGroupId, int? prsSexId, string prsPreTel, string prsTel, string prsTelUpTo, string prsTelDesc, string prsTelII, string prsFax, string prsFaxDesc, string prsMobile, string prsEmail, string prsEmailII, string prsAddress, string prsAddressDesc, string prsNationalCode, string prsBirthDate, DateTime? prsBirthDateTime, string prsMarriageDate, DateTime? prsMarriageDateTime, string prsDescription, int? prsDepartmentId, string prjTitle, string prjDesc, int? prjStarterUserId, int? prjGradeId, int? prjPriorityId, int? prjGroupId, int? prjcnvsStatusGroupId, string prjPostFix, string prjRemindDate, DateTime? prjRemindDateTime, bool? prjInsertCrmProjectForbiddenFUFDPActive, int? cnvsTopicId, string cnvsDesc, int? cnvsUserId, int? cnvsReferUserId, string cnvsReferDesc, int? cnvsStatusId, int? cnvsPriorityId, string cnvsRemindDate, DateTime? cnvsRemindDateTime, string cnvsReferToMultilUser, int? userId, short? month1, DateTime? registerDate, string registerDatePersian, string registerTime, string registerDay, string appType, string needErjaRefMsgSubject, string needErjaRefMsgBody, string needErjaMultiIntmsgSubject, string needErjaMultiIntmsgBody, string conversationErjaShowText, string value, ObjectParameter insertedCompanyId, ObjectParameter insertedPersonId, ObjectParameter insertedProjectId, ObjectParameter insertedConversationId, ObjectParameter errorMessage, bool? cmpCodeNotDup)
	{
		ObjectParameter objectParameter = ((userName != null) ? new ObjectParameter("UserName", userName) : new ObjectParameter("UserName", typeof(string)));
		ObjectParameter objectParameter2 = ((password != null) ? new ObjectParameter("Password", password) : new ObjectParameter("Password", typeof(string)));
		ObjectParameter objectParameter3 = (cmpNumber.HasValue ? new ObjectParameter("CmpNumber", cmpNumber) : new ObjectParameter("CmpNumber", typeof(int)));
		ObjectParameter objectParameter4 = ((cmpName != null) ? new ObjectParameter("CmpName", cmpName) : new ObjectParameter("CmpName", typeof(string)));
		ObjectParameter objectParameter5 = ((cmpNameEng != null) ? new ObjectParameter("CmpNameEng", cmpNameEng) : new ObjectParameter("CmpNameEng", typeof(string)));
		ObjectParameter objectParameter6 = (cmpTitleId.HasValue ? new ObjectParameter("CmpTitleId", cmpTitleId) : new ObjectParameter("CmpTitleId", typeof(int)));
		ObjectParameter objectParameter7 = ((cmpFame != null) ? new ObjectParameter("CmpFame", cmpFame) : new ObjectParameter("CmpFame", typeof(string)));
		ObjectParameter objectParameter8 = ((cmpActivityType != null) ? new ObjectParameter("CmpActivityType", cmpActivityType) : new ObjectParameter("CmpActivityType", typeof(string)));
		ObjectParameter objectParameter9 = (cmpGroupId.HasValue ? new ObjectParameter("CmpGroupId", cmpGroupId) : new ObjectParameter("CmpGroupId", typeof(int)));
		ObjectParameter objectParameter10 = (cmpSubGroupId.HasValue ? new ObjectParameter("CmpSubGroupId", cmpSubGroupId) : new ObjectParameter("CmpSubGroupId", typeof(int)));
		ObjectParameter objectParameter11 = (cmpGroupIdII.HasValue ? new ObjectParameter("CmpGroupIdII", cmpGroupIdII) : new ObjectParameter("CmpGroupIdII", typeof(int)));
		ObjectParameter objectParameter12 = (cmpGroupIdIII.HasValue ? new ObjectParameter("CmpGroupIdIII", cmpGroupIdIII) : new ObjectParameter("CmpGroupIdIII", typeof(int)));
		ObjectParameter objectParameter13 = (cmpGroupIdIV.HasValue ? new ObjectParameter("CmpGroupIdIV", cmpGroupIdIV) : new ObjectParameter("CmpGroupIdIV", typeof(int)));
		ObjectParameter objectParameter14 = (cmpTypeId.HasValue ? new ObjectParameter("CmpTypeId", cmpTypeId) : new ObjectParameter("CmpTypeId", typeof(int)));
		ObjectParameter objectParameter15 = (cmpPresentationId.HasValue ? new ObjectParameter("CmpPresentationId", cmpPresentationId) : new ObjectParameter("CmpPresentationId", typeof(int)));
		ObjectParameter objectParameter16 = ((cmpPreTel != null) ? new ObjectParameter("CmpPreTel", cmpPreTel) : new ObjectParameter("CmpPreTel", typeof(string)));
		ObjectParameter objectParameter17 = ((cmpTel != null) ? new ObjectParameter("CmpTel", cmpTel) : new ObjectParameter("CmpTel", typeof(string)));
		ObjectParameter objectParameter18 = ((cmpTelUpTo != null) ? new ObjectParameter("CmpTelUpTo", cmpTelUpTo) : new ObjectParameter("CmpTelUpTo", typeof(string)));
		ObjectParameter objectParameter19 = ((cmpTelDesc != null) ? new ObjectParameter("CmpTelDesc", cmpTelDesc) : new ObjectParameter("CmpTelDesc", typeof(string)));
		ObjectParameter objectParameter20 = ((cmpPreTelII != null) ? new ObjectParameter("CmpPreTelII", cmpPreTelII) : new ObjectParameter("CmpPreTelII", typeof(string)));
		ObjectParameter objectParameter21 = ((cmpTelII != null) ? new ObjectParameter("CmpTelII", cmpTelII) : new ObjectParameter("CmpTelII", typeof(string)));
		ObjectParameter objectParameter22 = ((cmpTelUpToII != null) ? new ObjectParameter("CmpTelUpToII", cmpTelUpToII) : new ObjectParameter("CmpTelUpToII", typeof(string)));
		ObjectParameter objectParameter23 = ((cmpTelIIDesc != null) ? new ObjectParameter("CmpTelIIDesc", cmpTelIIDesc) : new ObjectParameter("CmpTelIIDesc", typeof(string)));
		ObjectParameter objectParameter24 = ((cmpMobile != null) ? new ObjectParameter("CmpMobile", cmpMobile) : new ObjectParameter("CmpMobile", typeof(string)));
		ObjectParameter objectParameter25 = ((cmpFax != null) ? new ObjectParameter("CmpFax", cmpFax) : new ObjectParameter("CmpFax", typeof(string)));
		ObjectParameter objectParameter26 = ((cmpFaxDesc != null) ? new ObjectParameter("CmpFaxDesc", cmpFaxDesc) : new ObjectParameter("CmpFaxDesc", typeof(string)));
		ObjectParameter objectParameter27 = (cmpCountryId.HasValue ? new ObjectParameter("CmpCountryId", cmpCountryId) : new ObjectParameter("CmpCountryId", typeof(int)));
		ObjectParameter objectParameter28 = (cmpProvinceId.HasValue ? new ObjectParameter("CmpProvinceId", cmpProvinceId) : new ObjectParameter("CmpProvinceId", typeof(int)));
		ObjectParameter objectParameter29 = (cmpCityId.HasValue ? new ObjectParameter("CmpCityId", cmpCityId) : new ObjectParameter("CmpCityId", typeof(int)));
		ObjectParameter objectParameter30 = ((cmpAddress != null) ? new ObjectParameter("CmpAddress", cmpAddress) : new ObjectParameter("CmpAddress", typeof(string)));
		ObjectParameter objectParameter31 = ((cmpAddressDesc != null) ? new ObjectParameter("CmpAddressDesc", cmpAddressDesc) : new ObjectParameter("CmpAddressDesc", typeof(string)));
		ObjectParameter objectParameter32 = ((cmpZipCode != null) ? new ObjectParameter("CmpZipCode", cmpZipCode) : new ObjectParameter("CmpZipCode", typeof(string)));
		ObjectParameter objectParameter33 = ((cmpPostBox != null) ? new ObjectParameter("CmpPostBox", cmpPostBox) : new ObjectParameter("CmpPostBox", typeof(string)));
		ObjectParameter objectParameter34 = ((cmpWebSite != null) ? new ObjectParameter("CmpWebSite", cmpWebSite) : new ObjectParameter("CmpWebSite", typeof(string)));
		ObjectParameter objectParameter35 = ((cmpEmail != null) ? new ObjectParameter("CmpEmail", cmpEmail) : new ObjectParameter("CmpEmail", typeof(string)));
		ObjectParameter objectParameter36 = ((cmpInteresting != null) ? new ObjectParameter("CmpInteresting", cmpInteresting) : new ObjectParameter("CmpInteresting", typeof(string)));
		ObjectParameter objectParameter37 = ((cmpSpecialPoint != null) ? new ObjectParameter("CmpSpecialPoint", cmpSpecialPoint) : new ObjectParameter("CmpSpecialPoint", typeof(string)));
		ObjectParameter objectParameter38 = ((cmpDescription != null) ? new ObjectParameter("CmpDescription", cmpDescription) : new ObjectParameter("CmpDescription", typeof(string)));
		ObjectParameter objectParameter39 = ((cmpUserName != null) ? new ObjectParameter("CmpUserName", cmpUserName) : new ObjectParameter("CmpUserName", typeof(string)));
		ObjectParameter objectParameter40 = ((cmpPassword != null) ? new ObjectParameter("CmpPassword", cmpPassword) : new ObjectParameter("CmpPassword", typeof(string)));
		ObjectParameter objectParameter41 = ((cmpRegistrationNumber != null) ? new ObjectParameter("CmpRegistrationNumber", cmpRegistrationNumber) : new ObjectParameter("CmpRegistrationNumber", typeof(string)));
		ObjectParameter objectParameter42 = ((cmpEconomicCode != null) ? new ObjectParameter("CmpEconomicCode", cmpEconomicCode) : new ObjectParameter("CmpEconomicCode", typeof(string)));
		ObjectParameter objectParameter43 = ((cmpNationalCode != null) ? new ObjectParameter("CmpNationalCode", cmpNationalCode) : new ObjectParameter("CmpNationalCode", typeof(string)));
		ObjectParameter objectParameter44 = ((cmpBuyLimit != null) ? new ObjectParameter("CmpBuyLimit", cmpBuyLimit) : new ObjectParameter("CmpBuyLimit", typeof(string)));
		ObjectParameter objectParameter45 = ((cmpAccountNumber != null) ? new ObjectParameter("CmpAccountNumber", cmpAccountNumber) : new ObjectParameter("CmpAccountNumber", typeof(string)));
		ObjectParameter objectParameter46 = ((cmpAccInquiry != null) ? new ObjectParameter("CmpAccInquiry", cmpAccInquiry) : new ObjectParameter("CmpAccInquiry", typeof(string)));
		ObjectParameter objectParameter47 = ((cmpFreight != null) ? new ObjectParameter("CmpFreight", cmpFreight) : new ObjectParameter("CmpFreight", typeof(string)));
		ObjectParameter objectParameter48 = ((cmpInquiry != null) ? new ObjectParameter("CmpInquiry", cmpInquiry) : new ObjectParameter("CmpInquiry", typeof(string)));
		ObjectParameter objectParameter49 = (cmpReferUserId.HasValue ? new ObjectParameter("CmpReferUserId", cmpReferUserId) : new ObjectParameter("CmpReferUserId", typeof(int)));
		ObjectParameter objectParameter50 = ((cmpSpecialWordForCI != null) ? new ObjectParameter("CmpSpecialWordForCI", cmpSpecialWordForCI) : new ObjectParameter("CmpSpecialWordForCI", typeof(string)));
		ObjectParameter objectParameter51 = ((cmpCode != null) ? new ObjectParameter("CmpCode", cmpCode) : new ObjectParameter("CmpCode", typeof(string)));
		ObjectParameter objectParameter52 = ((cmpEffectiveDatePersian != null) ? new ObjectParameter("CmpEffectiveDatePersian", cmpEffectiveDatePersian) : new ObjectParameter("CmpEffectiveDatePersian", typeof(string)));
		ObjectParameter objectParameter53 = (cmpEffectiveDateTime.HasValue ? new ObjectParameter("CmpEffectiveDateTime", cmpEffectiveDateTime) : new ObjectParameter("CmpEffectiveDateTime", typeof(DateTime)));
		ObjectParameter objectParameter54 = ((cmpCoordinateLatitude != null) ? new ObjectParameter("CmpCoordinateLatitude", cmpCoordinateLatitude) : new ObjectParameter("CmpCoordinateLatitude", typeof(string)));
		ObjectParameter objectParameter55 = ((cmpCoordinateLongitude != null) ? new ObjectParameter("CmpCoordinateLongitude", cmpCoordinateLongitude) : new ObjectParameter("CmpCoordinateLongitude", typeof(string)));
		ObjectParameter objectParameter56 = (cmpCoordinateLastDate.HasValue ? new ObjectParameter("CmpCoordinateLastDate", cmpCoordinateLastDate) : new ObjectParameter("CmpCoordinateLastDate", typeof(DateTime)));
		ObjectParameter objectParameter57 = ((cmpCoordinateLastDatePersian != null) ? new ObjectParameter("CmpCoordinateLastDatePersian", cmpCoordinateLastDatePersian) : new ObjectParameter("CmpCoordinateLastDatePersian", typeof(string)));
		ObjectParameter objectParameter58 = (cmpCoordinateZoomLevel.HasValue ? new ObjectParameter("CmpCoordinateZoomLevel", cmpCoordinateZoomLevel) : new ObjectParameter("CmpCoordinateZoomLevel", typeof(int)));
		ObjectParameter objectParameter59 = (cmpCoordinateLastUserId.HasValue ? new ObjectParameter("CmpCoordinateLastUserId", cmpCoordinateLastUserId) : new ObjectParameter("CmpCoordinateLastUserId", typeof(int)));
		ObjectParameter objectParameter60 = ((prsLName != null) ? new ObjectParameter("PrsLName", prsLName) : new ObjectParameter("PrsLName", typeof(string)));
		ObjectParameter objectParameter61 = ((prsFName != null) ? new ObjectParameter("PrsFName", prsFName) : new ObjectParameter("PrsFName", typeof(string)));
		ObjectParameter objectParameter62 = (prsTitleId.HasValue ? new ObjectParameter("PrsTitleId", prsTitleId) : new ObjectParameter("PrsTitleId", typeof(int)));
		ObjectParameter objectParameter63 = (prsJobId.HasValue ? new ObjectParameter("PrsJobId", prsJobId) : new ObjectParameter("PrsJobId", typeof(int)));
		ObjectParameter objectParameter64 = (prsTypeId.HasValue ? new ObjectParameter("PrsTypeId", prsTypeId) : new ObjectParameter("PrsTypeId", typeof(int)));
		ObjectParameter objectParameter65 = (prsGroupId.HasValue ? new ObjectParameter("PrsGroupId", prsGroupId) : new ObjectParameter("PrsGroupId", typeof(int)));
		ObjectParameter objectParameter66 = (prsSexId.HasValue ? new ObjectParameter("PrsSexId", prsSexId) : new ObjectParameter("PrsSexId", typeof(int)));
		ObjectParameter objectParameter67 = ((prsPreTel != null) ? new ObjectParameter("PrsPreTel", prsPreTel) : new ObjectParameter("PrsPreTel", typeof(string)));
		ObjectParameter objectParameter68 = ((prsTel != null) ? new ObjectParameter("PrsTel", prsTel) : new ObjectParameter("PrsTel", typeof(string)));
		ObjectParameter objectParameter69 = ((prsTelUpTo != null) ? new ObjectParameter("PrsTelUpTo", prsTelUpTo) : new ObjectParameter("PrsTelUpTo", typeof(string)));
		ObjectParameter objectParameter70 = ((prsTelDesc != null) ? new ObjectParameter("PrsTelDesc", prsTelDesc) : new ObjectParameter("PrsTelDesc", typeof(string)));
		ObjectParameter objectParameter71 = ((prsTelII != null) ? new ObjectParameter("PrsTelII", prsTelII) : new ObjectParameter("PrsTelII", typeof(string)));
		ObjectParameter objectParameter72 = ((prsFax != null) ? new ObjectParameter("PrsFax", prsFax) : new ObjectParameter("PrsFax", typeof(string)));
		ObjectParameter objectParameter73 = ((prsFaxDesc != null) ? new ObjectParameter("PrsFaxDesc", prsFaxDesc) : new ObjectParameter("PrsFaxDesc", typeof(string)));
		ObjectParameter objectParameter74 = ((prsMobile != null) ? new ObjectParameter("PrsMobile", prsMobile) : new ObjectParameter("PrsMobile", typeof(string)));
		ObjectParameter objectParameter75 = ((prsEmail != null) ? new ObjectParameter("PrsEmail", prsEmail) : new ObjectParameter("PrsEmail", typeof(string)));
		ObjectParameter objectParameter76 = ((prsEmailII != null) ? new ObjectParameter("PrsEmailII", prsEmailII) : new ObjectParameter("PrsEmailII", typeof(string)));
		ObjectParameter objectParameter77 = ((prsAddress != null) ? new ObjectParameter("PrsAddress", prsAddress) : new ObjectParameter("PrsAddress", typeof(string)));
		ObjectParameter objectParameter78 = ((prsAddressDesc != null) ? new ObjectParameter("PrsAddressDesc", prsAddressDesc) : new ObjectParameter("PrsAddressDesc", typeof(string)));
		ObjectParameter objectParameter79 = ((prsNationalCode != null) ? new ObjectParameter("PrsNationalCode", prsNationalCode) : new ObjectParameter("PrsNationalCode", typeof(string)));
		ObjectParameter objectParameter80 = ((prsBirthDate != null) ? new ObjectParameter("PrsBirthDate", prsBirthDate) : new ObjectParameter("PrsBirthDate", typeof(string)));
		ObjectParameter objectParameter81 = (prsBirthDateTime.HasValue ? new ObjectParameter("PrsBirthDateTime", prsBirthDateTime) : new ObjectParameter("PrsBirthDateTime", typeof(DateTime)));
		ObjectParameter objectParameter82 = ((prsMarriageDate != null) ? new ObjectParameter("PrsMarriageDate", prsMarriageDate) : new ObjectParameter("PrsMarriageDate", typeof(string)));
		ObjectParameter objectParameter83 = (prsMarriageDateTime.HasValue ? new ObjectParameter("PrsMarriageDateTime", prsMarriageDateTime) : new ObjectParameter("PrsMarriageDateTime", typeof(DateTime)));
		ObjectParameter objectParameter84 = ((prsDescription != null) ? new ObjectParameter("PrsDescription", prsDescription) : new ObjectParameter("PrsDescription", typeof(string)));
		ObjectParameter objectParameter85 = (prsDepartmentId.HasValue ? new ObjectParameter("PrsDepartmentId", prsDepartmentId) : new ObjectParameter("PrsDepartmentId", typeof(int)));
		ObjectParameter objectParameter86 = ((prjTitle != null) ? new ObjectParameter("PrjTitle", prjTitle) : new ObjectParameter("PrjTitle", typeof(string)));
		ObjectParameter objectParameter87 = ((prjDesc != null) ? new ObjectParameter("PrjDesc", prjDesc) : new ObjectParameter("PrjDesc", typeof(string)));
		ObjectParameter objectParameter88 = (prjStarterUserId.HasValue ? new ObjectParameter("PrjStarterUserId", prjStarterUserId) : new ObjectParameter("PrjStarterUserId", typeof(int)));
		ObjectParameter objectParameter89 = (prjGradeId.HasValue ? new ObjectParameter("PrjGradeId", prjGradeId) : new ObjectParameter("PrjGradeId", typeof(int)));
		ObjectParameter objectParameter90 = (prjPriorityId.HasValue ? new ObjectParameter("PrjPriorityId", prjPriorityId) : new ObjectParameter("PrjPriorityId", typeof(int)));
		ObjectParameter objectParameter91 = (prjGroupId.HasValue ? new ObjectParameter("PrjGroupId", prjGroupId) : new ObjectParameter("PrjGroupId", typeof(int)));
		ObjectParameter objectParameter92 = (prjcnvsStatusGroupId.HasValue ? new ObjectParameter("PrjcnvsStatusGroupId", prjcnvsStatusGroupId) : new ObjectParameter("PrjcnvsStatusGroupId", typeof(int)));
		ObjectParameter objectParameter93 = ((prjPostFix != null) ? new ObjectParameter("PrjPostFix", prjPostFix) : new ObjectParameter("PrjPostFix", typeof(string)));
		ObjectParameter objectParameter94 = ((prjRemindDate != null) ? new ObjectParameter("PrjRemindDate", prjRemindDate) : new ObjectParameter("PrjRemindDate", typeof(string)));
		ObjectParameter objectParameter95 = (prjRemindDateTime.HasValue ? new ObjectParameter("PrjRemindDateTime", prjRemindDateTime) : new ObjectParameter("PrjRemindDateTime", typeof(DateTime)));
		ObjectParameter objectParameter96 = (prjInsertCrmProjectForbiddenFUFDPActive.HasValue ? new ObjectParameter("PrjInsertCrmProjectForbiddenFUFDPActive", prjInsertCrmProjectForbiddenFUFDPActive) : new ObjectParameter("PrjInsertCrmProjectForbiddenFUFDPActive", typeof(bool)));
		ObjectParameter objectParameter97 = (cnvsTopicId.HasValue ? new ObjectParameter("CnvsTopicId", cnvsTopicId) : new ObjectParameter("CnvsTopicId", typeof(int)));
		ObjectParameter objectParameter98 = ((cnvsDesc != null) ? new ObjectParameter("CnvsDesc", cnvsDesc) : new ObjectParameter("CnvsDesc", typeof(string)));
		ObjectParameter objectParameter99 = (cnvsUserId.HasValue ? new ObjectParameter("CnvsUserId", cnvsUserId) : new ObjectParameter("CnvsUserId", typeof(int)));
		ObjectParameter objectParameter100 = (cnvsReferUserId.HasValue ? new ObjectParameter("CnvsReferUserId", cnvsReferUserId) : new ObjectParameter("CnvsReferUserId", typeof(int)));
		ObjectParameter objectParameter101 = ((cnvsReferDesc != null) ? new ObjectParameter("CnvsReferDesc", cnvsReferDesc) : new ObjectParameter("CnvsReferDesc", typeof(string)));
		ObjectParameter objectParameter102 = (cnvsStatusId.HasValue ? new ObjectParameter("CnvsStatusId", cnvsStatusId) : new ObjectParameter("CnvsStatusId", typeof(int)));
		ObjectParameter objectParameter103 = (cnvsPriorityId.HasValue ? new ObjectParameter("CnvsPriorityId", cnvsPriorityId) : new ObjectParameter("CnvsPriorityId", typeof(int)));
		ObjectParameter objectParameter104 = ((cnvsRemindDate != null) ? new ObjectParameter("CnvsRemindDate", cnvsRemindDate) : new ObjectParameter("CnvsRemindDate", typeof(string)));
		ObjectParameter objectParameter105 = (cnvsRemindDateTime.HasValue ? new ObjectParameter("CnvsRemindDateTime", cnvsRemindDateTime) : new ObjectParameter("CnvsRemindDateTime", typeof(DateTime)));
		ObjectParameter objectParameter106 = ((cnvsReferToMultilUser != null) ? new ObjectParameter("CnvsReferToMultilUser", cnvsReferToMultilUser) : new ObjectParameter("CnvsReferToMultilUser", typeof(string)));
		ObjectParameter objectParameter107 = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter108 = (month1.HasValue ? new ObjectParameter("Month1", month1) : new ObjectParameter("Month1", typeof(short)));
		ObjectParameter objectParameter109 = (registerDate.HasValue ? new ObjectParameter("RegisterDate", registerDate) : new ObjectParameter("RegisterDate", typeof(DateTime)));
		ObjectParameter objectParameter110 = ((registerDatePersian != null) ? new ObjectParameter("RegisterDatePersian", registerDatePersian) : new ObjectParameter("RegisterDatePersian", typeof(string)));
		ObjectParameter objectParameter111 = ((registerTime != null) ? new ObjectParameter("RegisterTime", registerTime) : new ObjectParameter("RegisterTime", typeof(string)));
		ObjectParameter objectParameter112 = ((registerDay != null) ? new ObjectParameter("RegisterDay", registerDay) : new ObjectParameter("RegisterDay", typeof(string)));
		ObjectParameter objectParameter113 = ((appType != null) ? new ObjectParameter("AppType", appType) : new ObjectParameter("AppType", typeof(string)));
		ObjectParameter objectParameter114 = ((needErjaRefMsgSubject != null) ? new ObjectParameter("NeedErjaRefMsgSubject", needErjaRefMsgSubject) : new ObjectParameter("NeedErjaRefMsgSubject", typeof(string)));
		ObjectParameter objectParameter115 = ((needErjaRefMsgBody != null) ? new ObjectParameter("NeedErjaRefMsgBody", needErjaRefMsgBody) : new ObjectParameter("NeedErjaRefMsgBody", typeof(string)));
		ObjectParameter objectParameter116 = ((needErjaMultiIntmsgSubject != null) ? new ObjectParameter("NeedErjaMultiIntmsgSubject", needErjaMultiIntmsgSubject) : new ObjectParameter("NeedErjaMultiIntmsgSubject", typeof(string)));
		ObjectParameter objectParameter117 = ((needErjaMultiIntmsgBody != null) ? new ObjectParameter("NeedErjaMultiIntmsgBody", needErjaMultiIntmsgBody) : new ObjectParameter("NeedErjaMultiIntmsgBody", typeof(string)));
		ObjectParameter objectParameter118 = ((conversationErjaShowText != null) ? new ObjectParameter("ConversationErjaShowText", conversationErjaShowText) : new ObjectParameter("ConversationErjaShowText", typeof(string)));
		ObjectParameter objectParameter119 = ((value != null) ? new ObjectParameter("Value", value) : new ObjectParameter("Value", typeof(string)));
		ObjectParameter objectParameter120 = (cmpCodeNotDup.HasValue ? new ObjectParameter("CmpCodeNotDup", cmpCodeNotDup) : new ObjectParameter("CmpCodeNotDup", typeof(bool)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<int?>("ApispRegisterCompanyWithCnvs", new ObjectParameter[125]
		{
			objectParameter, objectParameter2, objectParameter3, objectParameter4, objectParameter5, objectParameter6, objectParameter7, objectParameter8, objectParameter9, objectParameter10,
			objectParameter11, objectParameter12, objectParameter13, objectParameter14, objectParameter15, objectParameter16, objectParameter17, objectParameter18, objectParameter19, objectParameter20,
			objectParameter21, objectParameter22, objectParameter23, objectParameter24, objectParameter25, objectParameter26, objectParameter27, objectParameter28, objectParameter29, objectParameter30,
			objectParameter31, objectParameter32, objectParameter33, objectParameter34, objectParameter35, objectParameter36, objectParameter37, objectParameter38, objectParameter39, objectParameter40,
			objectParameter41, objectParameter42, objectParameter43, objectParameter44, objectParameter45, objectParameter46, objectParameter47, objectParameter48, objectParameter49, objectParameter50,
			objectParameter51, objectParameter52, objectParameter53, objectParameter54, objectParameter55, objectParameter56, objectParameter57, objectParameter58, objectParameter59, objectParameter60,
			objectParameter61, objectParameter62, objectParameter63, objectParameter64, objectParameter65, objectParameter66, objectParameter67, objectParameter68, objectParameter69, objectParameter70,
			objectParameter71, objectParameter72, objectParameter73, objectParameter74, objectParameter75, objectParameter76, objectParameter77, objectParameter78, objectParameter79, objectParameter80,
			objectParameter81, objectParameter82, objectParameter83, objectParameter84, objectParameter85, objectParameter86, objectParameter87, objectParameter88, objectParameter89, objectParameter90,
			objectParameter91, objectParameter92, objectParameter93, objectParameter94, objectParameter95, objectParameter96, objectParameter97, objectParameter98, objectParameter99, objectParameter100,
			objectParameter101, objectParameter102, objectParameter103, objectParameter104, objectParameter105, objectParameter106, objectParameter107, objectParameter108, objectParameter109, objectParameter110,
			objectParameter111, objectParameter112, objectParameter113, objectParameter114, objectParameter115, objectParameter116, objectParameter117, objectParameter118, objectParameter119, insertedCompanyId,
			insertedPersonId, insertedProjectId, insertedConversationId, errorMessage, objectParameter120
		});
	}

	public virtual ObjectResult<ApispSelectCompanyTitleWithId_Result> ApispSelectCompanyTitleWithId(int? companyTitleId)
	{
		ObjectParameter objectParameter = (companyTitleId.HasValue ? new ObjectParameter("CompanyTitleId", companyTitleId) : new ObjectParameter("CompanyTitleId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApispSelectCompanyTitleWithId_Result>("ApispSelectCompanyTitleWithId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<ApispSelectCrmFoSetting_Result> ApispSelectCrmFoSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApispSelectCrmFoSetting_Result>("ApispSelectCrmFoSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<ApispSelectCrmsysSetting_Result> ApispSelectCrmsysSetting()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApispSelectCrmsysSetting_Result>("ApispSelectCrmsysSetting", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<ApispSelectLanguages_Result> ApispSelectLanguages()
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApispSelectLanguages_Result>("ApispSelectLanguages", Array.Empty<ObjectParameter>());
	}

	public virtual ObjectResult<ApispSelectPersonTitleWithId_Result> ApispSelectPersonTitleWithId(int? personTitleId)
	{
		ObjectParameter objectParameter = (personTitleId.HasValue ? new ObjectParameter("PersonTitleId", personTitleId) : new ObjectParameter("PersonTitleId", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApispSelectPersonTitleWithId_Result>("ApispSelectPersonTitleWithId", new ObjectParameter[1] { objectParameter });
	}

	public virtual ObjectResult<ApispSelectUsers_Result> ApispSelectUsers(int? userId, int? languageID, int? defaultLanguageID)
	{
		ObjectParameter objectParameter = (userId.HasValue ? new ObjectParameter("UserId", userId) : new ObjectParameter("UserId", typeof(int)));
		ObjectParameter objectParameter2 = (languageID.HasValue ? new ObjectParameter("LanguageID", languageID) : new ObjectParameter("LanguageID", typeof(int)));
		ObjectParameter objectParameter3 = (defaultLanguageID.HasValue ? new ObjectParameter("DefaultLanguageID", defaultLanguageID) : new ObjectParameter("DefaultLanguageID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApispSelectUsers_Result>("ApispSelectUsers", new ObjectParameter[3] { objectParameter, objectParameter2, objectParameter3 });
	}
}
