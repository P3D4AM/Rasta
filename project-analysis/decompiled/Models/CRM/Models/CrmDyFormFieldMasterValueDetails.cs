using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormFieldMasterValueDetailsMetadata))]
public class CrmDyFormFieldMasterValueDetails
{
	public int FormFieldMasterValueDetailId { get; set; }

	public int MasterValueId { get; set; }

	public int FormId { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsChecked { get; set; }

	public int? CheckerUserId { get; set; }

	public DateTime? CheckedDate { get; set; }

	public string CheckedDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? CId { get; set; }

	public int? DeletedUserId { get; set; }

	public DateTime? DeletedDate { get; set; }

	public string DeletedDatePersian { get; set; }

	public virtual CrmDyFormFieldMasterValues CrmDyFormFieldMasterValues { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }
}
