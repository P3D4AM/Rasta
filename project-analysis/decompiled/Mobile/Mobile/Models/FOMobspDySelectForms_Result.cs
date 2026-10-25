using System;

namespace Mobile.Models;

public class FOMobspDySelectForms_Result
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

	public int? CheckerRollId { get; set; }

	public string FormCIds { get; set; }

	public string FormCenterInfoJs { get; set; }

	public string cmpCIds { get; set; }

	public string cmpFOInfo { get; set; }

	public bool? cmpFOIsActive { get; set; }

	public bool? cmpShpIsActive { get; set; }

	public DateTime? cmpShpLoginExpireDate { get; set; }

	public string prsCIds { get; set; }

	public string prsFOInfo { get; set; }

	public bool? prsFOIsActive { get; set; }

	public bool? prsShpIsActive { get; set; }

	public DateTime? prsShpLoginExpireDate { get; set; }

	public int? LastCId { get; set; }

	public string FoActiveCIds { get; set; }

	public string FoShpInfo { get; set; }

	public int? cmpKind { get; set; }
}
