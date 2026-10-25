using System;

namespace CRM.Models;

public class CRMspDySelectFormsWithSysPartId_Result
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
}
