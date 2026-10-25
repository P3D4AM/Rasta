using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmImportFromExcelMetadata))]
public class CrmImportFromExcel
{
	public long Id { get; set; }

	public bool? Selector { get; set; }

	public int? RelationId { get; set; }

	public string cmpName { get; set; }

	public string cmpNameEng { get; set; }

	public string cmpFame { get; set; }

	public string cmpActivityType { get; set; }

	public string cmpPreTel { get; set; }

	public string cmpTel { get; set; }

	public string cmpTelUpTo { get; set; }

	public string cmpTelDesc { get; set; }

	public string cmpPreTelII { get; set; }

	public string cmpTelII { get; set; }

	public string cmpTelUpToII { get; set; }

	public string cmpTelIIDesc { get; set; }

	public string cmpMobile { get; set; }

	public string cmpFax { get; set; }

	public string cmpFaxDesc { get; set; }

	public string cmpAddress { get; set; }

	public string cmpAddressDesc { get; set; }

	public string cmpZipCode { get; set; }

	public string cmpPostBox { get; set; }

	public string cmpWebSite { get; set; }

	public string cmpEmail { get; set; }

	public string cmpInteresting { get; set; }

	public string cmpSpecialPoint { get; set; }

	public string cmpDescription { get; set; }

	public string cmpUserName { get; set; }

	public string cmpPassword { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public string prsFName { get; set; }

	public string prsLName { get; set; }

	public int? prsTitleId { get; set; }

	public string prsPreTel { get; set; }

	public string prsTel { get; set; }

	public string prsTelUpTo { get; set; }

	public string prsTelDesc { get; set; }

	public string prsTelII { get; set; }

	public string prsFax { get; set; }

	public string prsFaxDesc { get; set; }

	public string prsMobile { get; set; }

	public string prsWebSite { get; set; }

	public string prsEmail { get; set; }

	public string prsEmailII { get; set; }

	public string prsAddress { get; set; }

	public string prsAddressDesc { get; set; }

	public string prsZipCode { get; set; }

	public string prsPostBox { get; set; }

	public string prsBirthDate { get; set; }

	public string prsMarriageDate { get; set; }

	public string prsDescription { get; set; }

	public string prjTitle { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsReferDesc { get; set; }

	public string cnvsRemindDate { get; set; }

	public string cnvsRemindTime { get; set; }

	public string cnvsRemindDateForAllarm { get; set; }

	public int? IsDuplicate { get; set; }

	public int? FindedcmpId { get; set; }

	public int? InsertedcmpId { get; set; }

	public int? InsertedprsId { get; set; }

	public int? InsertedprjId { get; set; }

	public int? InsertedcnvsId { get; set; }

	public string cmpCode { get; set; }

	public string cmpEffectiveDatePersian { get; set; }

	public DateTime? cmpEffectiveDateTime { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? prsBirthDateTime { get; set; }

	public DateTime? prsMarriageDateTime { get; set; }

	public DateTime? prsImportDateTime { get; set; }

	public string prjPostFix { get; set; }

	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public DateTime? cnvsFirstRegisterDateTime { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public string prsNationalCode { get; set; }

	public int? cmpKind { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpBuyLimit { get; set; }

	public string cmpAccountNumber { get; set; }

	public string cmpAccInquiry { get; set; }

	public string cmpFreight { get; set; }

	public string cmpInquiry { get; set; }

	public string cmpSpecialWordForCI { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public string cmpCoordinateLastDatePersian { get; set; }

	public int? cmpCoordinateZoomLevel { get; set; }

	public string prjDesc { get; set; }

	public string ErrorMessage { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string prsFatherName { get; set; }

	public string prsIdentityNumber { get; set; }

	public int? cmpReferUserId { get; set; }

	public int? FoundedCmpId { get; set; }

	public int? FoundedPrsId { get; set; }

	public int? FoundedPrjId { get; set; }

	public int? FoundedCnvsId { get; set; }

	public int? cmpCId { get; set; }

	public int? prsCId { get; set; }

	public int? prjCId { get; set; }

	public int? cnvsCId { get; set; }

	public string cmpCenterCode { get; set; }

	public string prsCenterCode { get; set; }

	public string prjCenterCode { get; set; }

	public string cnvsCenterCode { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpTitleId { get; set; }

	public string cmpTitle { get; set; }

	public int? cmpPresentationId { get; set; }

	public string cmpPresentation { get; set; }

	public int? cmpTypeId { get; set; }

	public string cmpType { get; set; }

	public int? cmpCountryId { get; set; }

	public string cmpCountry { get; set; }

	public int? cmpProvinceId { get; set; }

	public string cmpProvince { get; set; }

	public int? cmpCityId { get; set; }

	public string cmpCity { get; set; }

	public int? cmpGroupId { get; set; }

	public string cmpGroup { get; set; }

	public int? cmpSubGroupId { get; set; }

	public string cmpSubGroup { get; set; }

	public int? cmpGroupIdII { get; set; }

	public string cmpGroupII { get; set; }

	public int? cmpGroupIdIII { get; set; }

	public string cmpGroupIII { get; set; }

	public int? cmpGroupIdIV { get; set; }

	public string cmpGroupIV { get; set; }

	public string cmpReferUser_UserName { get; set; }

	public string cmpReferUser_PersCode { get; set; }

	public string cmpImportDate { get; set; }

	public int? prsJobId { get; set; }

	public string prsJob { get; set; }

	public int? prsDepartmentId { get; set; }

	public string prsDepartment { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public string prjcnvsStatusGroup { get; set; }

	public int? prjGroupId { get; set; }

	public string prjGroup { get; set; }

	public int? prjGradeId { get; set; }

	public string prjGrade { get; set; }

	public int? prjPriorityId { get; set; }

	public string prjPriority { get; set; }

	public int? prjStarterUserId { get; set; }

	public string prjStarterUser_Username { get; set; }

	public string prjStarterUser_PersCode { get; set; }

	public string prjStartDate { get; set; }

	public string prjStartTime { get; set; }

	public string cnvsDate { get; set; }

	public string cnvsTime { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsTopic { get; set; }

	public int? cnvsUserId { get; set; }

	public string cnvsUser_PersCode { get; set; }

	public string cnvsUser_Username { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string cnvsReferUser_PersCode { get; set; }

	public string cnvsReferUser_Username { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public int? cnvsPriorityId { get; set; }

	public string cnvsPriority { get; set; }
}
