using System;

namespace CRM.Models;

public class CRMspDySelectFormAndSubForms_Result
{
	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public string FormTitleColor { get; set; }

	public string FormBgColor { get; set; }

	public string FormHeader { get; set; }

	public string FormBody { get; set; }

	public string FormFooter { get; set; }

	public bool? HaveUploadFile { get; set; }

	public string UploadFileDescription { get; set; }

	public int? UploadFileCount { get; set; }

	public int? UploadFileMaxSize { get; set; }

	public int? ColumnCount { get; set; }

	public bool? IsActive { get; set; }

	public int? OrderView { get; set; }

	public int? ParentFormId { get; set; }

	public int? CrmSysPartId { get; set; }

	public int? FOSysPartId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string CrmSysPartTitle { get; set; }

	public string CrmSysPart { get; set; }

	public string CrmSysPartType { get; set; }

	public string FOSysPartTitle { get; set; }

	public string FOSysPart { get; set; }

	public string FOSysPartType { get; set; }

	public string ParentForm { get; set; }

	public string UploadFileExtension { get; set; }

	public int? PrintFormatId { get; set; }

	public bool? FOIsVisible { get; set; }

	public bool? FOIsEnable { get; set; }

	public bool? FOCanInsertMulti { get; set; }

	public string EnableForUsersId { get; set; }

	public int? EnableForRollId { get; set; }

	public string CheckerUsersId { get; set; }

	public int? WorkflowId { get; set; }

	public string Workflow { get; set; }

	public int? WorkflowPanelShowType { get; set; }

	public string EnableForUsers { get; set; }

	public string ReferUserIds { get; set; }

	public bool? WorkflowPanelHide { get; set; }

	public string FrmCheckerUsers { get; set; }

	public string CrmSysPartShow { get; set; }

	public string CrmSysPartShowTitle { get; set; }

	public string FOSysPartShow { get; set; }

	public string FOSysPartShowTitle { get; set; }

	public bool? SetSysPartFieldByUser { get; set; }

	public bool? EnableForResponsibleUserChecker { get; set; }

	public string FormFieldsJs { get; set; }

	public int? CheckerRollId { get; set; }

	public string CheckerRoll { get; set; }

	public string FormCIds { get; set; }

	public string FormCenterInfoJs { get; set; }
}
