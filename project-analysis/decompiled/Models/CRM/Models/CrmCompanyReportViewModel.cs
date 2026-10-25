using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyReportViewModel
{
	public int? cmpFirstRegisterUserId { get; set; }

	public int? cmpUserId { get; set; }

	public string cmpTypeDateForSearch { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportFromDate")]
	public string cmpFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportToDate")]
	public string cmpToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpImportDate")]
	public string cmpImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTitleId")]
	public string cmpTitleIdTitle { get; set; }

	public string cmpTitleStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpActivityType")]
	public string cmpActivityType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupId")]
	public string cmpGroupIdTitle { get; set; }

	public string cmpGroupStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSubGroupId")]
	public string cmpSubGroupIdTitle { get; set; }

	public string cmpSubGroupStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdII")]
	public string cmpGroupIdIITitle { get; set; }

	public string cmpGroupIIStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIII")]
	public string cmpGroupIdIIITitle { get; set; }

	public string cmpGroupIIIStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIV")]
	public string cmpGroupIdIVTitle { get; set; }

	public string cmpGroupIVStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdMultiTitle")]
	public string cmpGroupIdMultiTitle { get; set; }

	public string cmpGroupMultiStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTypeId")]
	public string cmpTypeIdTitle { get; set; }

	public string cmpTypeStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPresentationId")]
	public string cmpPresentationIdTitle { get; set; }

	public string cmpPresentationStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public string cmpCountryIdTitle { get; set; }

	public string cmpCountryStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public string cmpProvinceIdTitle { get; set; }

	public string cmpProvinceStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public string cmpCityIdTitle { get; set; }

	public string cmpCityStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpReferUserId")]
	public string cmpReferUserIdTitle { get; set; }

	public string cmpReferUserStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptRegisterDate")]
	public string cmpRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportOtherFields")]
	public string cmpOtherFields { get; set; }

	public string cmpOtherFieldsStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportSimilarValue")]
	public string cmpSimilarValue { get; set; }

	public string cmpOtherFieldValueLikely { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportCampaignIds")]
	public string cmpCampaignIds { get; set; }

	public string cmpCampaignIdsList { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportKind")]
	public string cmpKind { get; set; }

	public string cmpKindStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportSuppUser")]
	public string cmpSuppUserIdTitle { get; set; }

	public string cmpSuppUserStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportFromScore")]
	public string cmpFromScore { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportToScore")]
	public string cmpToScore { get; set; }

	public bool? prsSel { get; set; }

	public string prsOtherFieldsStr { get; set; }

	public int? prsFirstRegisterUserId { get; set; }

	public int? prsUserId { get; set; }

	public string prsTypeDateForSearch { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportFromDate")]
	public string prsFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportToDate")]
	public string prsToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTitleId")]
	public int prsTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrsTitleId")]
	public string prsTitleIdTitle { get; set; }

	public string prsTitleStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsJobId")]
	public int prsJobId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsJobId")]
	public string prsJobIdTitle { get; set; }

	public string prsJobStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsDepartmentId")]
	public int? prsDepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsDepartmentId")]
	public string prsDepartmentIdTitle { get; set; }

	public string prsDepartmentStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsImportDate")]
	public string prsImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptRegisterDate")]
	public string prsRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTypeId")]
	public int? prsTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTypeId")]
	public string prsTypeIdTitle { get; set; }

	public string prsTypeStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsGroupId")]
	public int? prsGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsGroupId")]
	public string prsGroupIdTitle { get; set; }

	public string prsGroupStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsSexId")]
	public int? prsSexId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsSexId")]
	public string prsSexIdTitle { get; set; }

	public string prsSexStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEducationId")]
	public int? prsEducationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEducationId")]
	public string prsEducationIdTitle { get; set; }

	public string prsEducationStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCountryId")]
	public int? prsCountryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCountryId")]
	public string prsCountryIdTitle { get; set; }

	public string prsCountryStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsProvinceId")]
	public int? prsProvinceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsProvinceId")]
	public string prsProvinceIdTitle { get; set; }

	public string prsProvinceStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCityId")]
	public int? prsCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCityId")]
	public string prsCityIdTitle { get; set; }

	public string prsCityStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEducationFieldRpt")]
	public string prsEducationField { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportOtherFields")]
	public string prsOtherFields { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportSimilarValue")]
	public string prsSimilarValue { get; set; }

	public string prsOtherFieldValueLikely { get; set; }

	public bool? prjSel { get; set; }

	public string prjTypeDateForSearch { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportFromDate")]
	public string prjFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportToDate")]
	public string prjToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjTitle")]
	public string prjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjIsFinished")]
	public string prjIsFinished { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjGradeId")]
	public int? prjGradeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjGradeId")]
	public string prjGradeIdTitle { get; set; }

	public string prjGradeStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjPriorityId")]
	public int? prjPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjPriorityId")]
	public string prjPriorityIdTitle { get; set; }

	public string prjPriorityStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterDate")]
	public string prjFirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterUserId")]
	public int prjFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjFirstRegisterUserId")]
	public string prjFirstRegisterUserIdTitle { get; set; }

	public string prjFirstRegisterUserStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGroupId")]
	public int? prjGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGroupId")]
	public string prjGroupIdTitle { get; set; }

	public string prjGroupStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjcnvsStatusGroupId")]
	public int? prjcnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjcnvsStatusGroupId")]
	public string prjcnvsStatusGroupIdTitle { get; set; }

	public string prjcnvsStatusGroupStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjUserId")]
	public int prjUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjUserIdTitle")]
	public string prjUserIdTitle { get; set; }

	public string prjUserStr { get; set; }

	public string prjRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGroupsMulti")]
	public string prjGroupsMulti { get; set; }

	public string prjGroupsMultiStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjGroupsMultiI")]
	public string prjGroupsMultiI { get; set; }

	public string prjGroupsMultiIStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjTreeInfo")]
	public string prjTreeInfo { get; set; }

	public string prjTreeInfoStr { get; set; }

	public string txtPrjTreeInfo { get; set; }

	public string drpPrjTreeInfo { get; set; }

	public string prjOtherFieldValueLikely { get; set; }

	public string prjOtherFields { get; set; }

	public string prjOtherFieldsStr { get; set; }

	public string prjSimilarValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RptPrjPostFix")]
	public string prjPostFix { get; set; }

	public string projectInformationIdFrom { get; set; }

	public string projectInformationIdTo { get; set; }

	public string projectInformationBetweenChecked { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjReportCmpCampaignIds")]
	public string prjcmpCampaignIds { get; set; }

	public string prjcmpCampaignIdsList { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjReportCmpPresentationId")]
	public string prjcmpPresentationIdTitle { get; set; }

	public string prjcmpPresentationStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptPrjTitleGroup")]
	public string prjTitleGroup { get; set; }

	public bool? cnvsSel { get; set; }

	public string cnvsOtherFieldsStr { get; set; }

	public int? cnvsFirstRegisterUserId { get; set; }

	public int? cnvsUserId2 { get; set; }

	public string cnvsTypeDateForSearch { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportFromDate")]
	public string cnvsFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportToDate")]
	public string cnvsToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTopicId")]
	public int? cnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTopicId")]
	public string cnvsTopicIdTitle { get; set; }

	public string cnvsTopicStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public int? cnvsUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public string cnvsUserIdTitle { get; set; }

	public string cnvsUserStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCnvsReferUserId")]
	public int? cnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCnvsReferUserId")]
	public string cnvsReferUserIdTitle { get; set; }

	public string cnvsReferUserStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusId")]
	public int? cnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptLastCnvsStatus")]
	public string cnvsLastStatus { get; set; }

	public string cnvsLastStatusStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptContainCnvsStatus")]
	public string cnvsContainStatus { get; set; }

	public string cnvsContainStatusStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptLastCnvsStatusResult")]
	public string cnvsLastStatusResult { get; set; }

	public string cnvsLastStatusResultStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptContainCnvsStatusResult")]
	public string cnvsContainStatusResult { get; set; }

	public string cnvsContainStatusResultStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCnvsMaxPercentage")]
	public int? cnvsMaxPercentage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCnvsMinPercentage")]
	public int? cnvsMinPercentage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPriorityId")]
	public int? cnvsPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCnvsPriorityId")]
	public string cnvsPriorityIdTitle { get; set; }

	public string cnvsPriorityStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterDate")]
	public string cnvsFirstRegisterDate { get; set; }

	public string cnvsRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportOtherFields")]
	public string cnvsOtherFields { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptCompanyReportSimilarValue")]
	public string cnvsSimilarValue { get; set; }

	public string cnvsOtherFieldValueLikely { get; set; }
}
