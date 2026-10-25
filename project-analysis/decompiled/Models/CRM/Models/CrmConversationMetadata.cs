using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationMetadata
{
	[Key]
	[Display(ResourceType = typeof(Labels), Name = "cnvsConversationID")]
	public int ConversationID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsProjectId")]
	public int? cnvsProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int cnvsCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDay")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTime")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTopicId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsSubject")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDesc")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(10000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPersonId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPriorityId")]
	public int? cnvsPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindTime")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindOk")]
	public bool? cnvsRemindOk { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsIsBookMark")]
	public bool? cnvsIsBookMark { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterUserId")]
	public int? cnvsFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsFirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDateForAllarm")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindDateForAllarm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterDate")]
	public DateTime? FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public DateTime? cnvsFirstRegisterDateTime { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public int? LanguageID { get; set; }
}
