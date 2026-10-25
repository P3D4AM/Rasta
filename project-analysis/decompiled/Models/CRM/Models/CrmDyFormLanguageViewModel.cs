using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmDyFormLanguageViewModel
{
	[Key]
	public int FormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FormName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FormTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormTitleColor")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FormTitleColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormBgColor")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FormBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormHeader")]
	[UIHint("RichText")]
	[AllowHtml]
	public string FormHeader { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormBody")]
	[UIHint("RichText")]
	[AllowHtml]
	public string FormBody { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFooter")]
	[UIHint("RichText")]
	[AllowHtml]
	public string FormFooter { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormHaveUploadFile")]
	public bool? HaveUploadFile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormUploadFileDescription")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UploadFileDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormUploadFileCount")]
	public int? UploadFileCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormUploadFileMaxSize")]
	public int? UploadFileMaxSize { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormColumnCount")]
	public int? ColumnCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormOrderView")]
	public int? OrderView { get; set; }

	public int? ParentFormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormCrmSysPartId")]
	public int? CrmSysPartId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFOSysPartId")]
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

	[Display(ResourceType = typeof(Labels), Name = "DyFormUploadFileExtension")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UploadFileExtension { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormPrintFormatId")]
	public int? PrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFOIsVisible")]
	public bool? FOIsVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFOIsEnable")]
	public bool? FOIsEnable { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFOCanInsertMulti")]
	public bool? FOCanInsertMulti { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormEnableForUsersId")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EnableForUsersId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormEnableForRollId")]
	public int? EnableForRollId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormCheckerUsersId")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CheckerUsersId { get; set; }

	public int? WorkflowId { get; set; }

	public string FormName_Lang { get; set; }

	public string FormTitle_Lang { get; set; }

	[AllowHtml]
	public string FormHeader_Lang { get; set; }

	[AllowHtml]
	public string FormBody_Lang { get; set; }

	[AllowHtml]
	public string FormFooter_Lang { get; set; }

	public string UploadFileDescription_Lang { get; set; }

	public string CrmSysPartShow { get; set; }

	public string CrmSysPartShowNames { get; set; }

	public string FOSysPartShow { get; set; }

	public string FOSysPartShowNames { get; set; }

	public bool? SetSysPartFieldByUser { get; set; }

	public bool? EnableForResponsibleUserChecker { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormVerificationWorkFlowId")]
	public int? VerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormCheckerRollId")]
	public int? CheckerRollId { get; set; }
}
