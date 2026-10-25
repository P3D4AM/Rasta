using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductSpecificationFieldGroupsMetadata
{
	[Key]
	public int SpecificationFieldGroupID { get; set; }

	public string FieldGroupTitle { get; set; }

	public bool? FieldGroupInActive { get; set; }

	public int? OrderView { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FieldGroupCId { get; set; }
}
