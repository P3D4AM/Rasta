using System;

namespace CRMIdealApi.ApiModels;

public class TreeColumnsDyFormViewModel
{
	public int Id { get; set; }

	public string Text { get; set; }

	public int ApiFormId { get; set; }

	public string ApiFormName { get; set; }

	public string ApiFormTitle { get; set; }

	public string ApiFormTitleColor { get; set; }

	public string ApiFormBgColor { get; set; }

	public string ApiFormHeader { get; set; }

	public string ApiFormBody { get; set; }

	public string ApiFormFooter { get; set; }

	public bool? ApiHaveUploadFile { get; set; }

	public string ApiUploadFileDescription { get; set; }

	public int? ApiUploadFileCount { get; set; }

	public int? ApiUploadFileMaxSize { get; set; }

	public int? ApiColumnCount { get; set; }

	public bool? ApiIsActive { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiParentFormId { get; set; }

	public int? ApiCrmSysPartId { get; set; }

	public int? ApiFOSysPartId { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public string ApiUploadFileExtension { get; set; }

	public int? ApiPrintFormatId { get; set; }

	public bool? ApiFOIsVisible { get; set; }

	public bool? ApiFOIsEnable { get; set; }

	public bool? ApiFOCanInsertMulti { get; set; }

	public string ApiEnableForUsersId { get; set; }

	public int? ApiEnableForRollId { get; set; }

	public string ApiCheckerUsersId { get; set; }

	public int? ApiWorkflowId { get; set; }

	public string ApiCrmSysPartShow { get; set; }

	public string ApiFOSysPartShow { get; set; }

	public bool? ApiSetSysPartFieldByUser { get; set; }

	public bool? ApiEnableForResponsibleUserChecker { get; set; }

	public int? ApiVerificationWorkFlowId { get; set; }
}
