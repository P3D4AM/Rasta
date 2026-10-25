namespace RegisterCompany.Models;

public class ApispSelectCrmFoSetting_Result
{
	public int CrmFoSettingLandID { get; set; }

	public int? FoSettingId { get; set; }

	public int? CmpDefaultGroupId { get; set; }

	public int? CmpDefaultSubGroupId { get; set; }

	public int? CmpDefaultGroupIdII { get; set; }

	public int? CmpDefaultGroupIdIII { get; set; }

	public int? CmpDefaultGroupIdIV { get; set; }

	public int? CmpDefaultTypeId { get; set; }

	public int? CmpDefaultPresentationId { get; set; }

	public int? CmpDefaultReferUserId { get; set; }

	public string PrjDefaultTitle { get; set; }

	public int PrjDefaultStarterUserId { get; set; }

	public int? PrjDefaultGradeId { get; set; }

	public int? PrjDefaultPriorityId { get; set; }

	public int? PrjDefaultGroupId { get; set; }

	public int PrjDefaultCnvsStatusGroupId { get; set; }

	public string PrjDefaultPostFix { get; set; }

	public bool? PrjDefaultFOCmpCanSee { get; set; }

	public bool? PrjInsertCrmProjectsForbiddenFUFDPActive { get; set; }

	public bool? PrjInsertProjectInformationsDefualtFieldActive { get; set; }

	public int CnvsDefaultTopicId { get; set; }

	public string CnvsDefaultDesc { get; set; }

	public int CnvsDefaultUserId { get; set; }

	public int CnvsDefaultReferUserId { get; set; }

	public string CnvsDefaultReferDesc { get; set; }

	public int CnvsDefaultStatusId { get; set; }

	public int? CnvsDefaultPriorityId { get; set; }

	public bool? EmailSendingIsActive { get; set; }

	public int? EmailSettingId { get; set; }

	public int? EmailUserInfoId { get; set; }

	public string EmailSubjectPatternFormula { get; set; }

	public string EmailBodyPatternFormula { get; set; }

	public bool? SmsSendingIsActive { get; set; }

	public string SmsWebServiceUserName { get; set; }

	public string SmsWebServicePassword { get; set; }

	public string SmsWebServiceNumber { get; set; }

	public string SmsWebServiceUrl { get; set; }

	public string SmsBodyPatternFormula { get; set; }

	public string FoLogEmailAdminI { get; set; }

	public string FoLogEmailAdminII { get; set; }

	public int LanguageID { get; set; }
}
