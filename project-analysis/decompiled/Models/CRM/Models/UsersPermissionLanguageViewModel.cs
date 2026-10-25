using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UsersPermissionLanguageViewModel
{
	[Key]
	public int ID { get; set; }

	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? RollId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollPrjId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int PrjId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollDescription")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string AccessLevel { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string Description_Lang { get; set; }

	public string UserCIds { get; set; }

	public int? CId { get; set; }
}
