using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationStatusGroupLanguageViewModel
{
	[Key]
	public int ConversationStatusGroupID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ConversationStatusGroup")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ConversationStatusGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ConversationStatusGroupDesc")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ConversationStatusGroupDesc { get; set; }

	public string ConversationStatusGroupColor { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ConversationStatusGroupFOCnvsReferUserId")]
	public int? FOCnvsReferUserId { get; set; }

	public string FOCnvsReferMultiUser { get; set; }

	public bool? NoRegCnvsOlderStatus { get; set; }

	public bool? DeActive { get; set; }

	public string ConversationStatusGroup_Lang { get; set; }

	public string ConversationStatusGroupDesc_Lang { get; set; }
}
