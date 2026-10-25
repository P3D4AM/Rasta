using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class EmailUsersInfoViewModel
{
	[Key]
	public int EmailUsersInfoId { get; set; }

	public int euUserId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "EmailUserNikeName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string euNikeName { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "EmailUserNikeEmail")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string euNikeEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserPOP3Server")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string euPOP3Server { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "EmailUserSMTPServer")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string euSMTPServer { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "EmailUserName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string euUserName { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "EmailUserPassword")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string euPassword { get; set; }

	public bool euIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserAutoDeleteReceivedEmail")]
	public bool? euAutoDeleteReceivedEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserPOP3UseSsl")]
	public bool? euPOP3UseSsl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserPOP3Port")]
	public int? euPOP3Port { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserReceiveServerType")]
	public int? euReceiveServerType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserIMAPServer")]
	public string euIMAPServer { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserIMAPUseSsl")]
	public bool? euIMAPUseSsl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserIMAPPort")]
	public int? euIMAPPort { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserDeleteSrvrAfterDelDb")]
	public bool? euDeleteSrvrAfterDelDb { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserDeleteFromSrvrAfterDay")]
	public int? euDeleteFromSrvrAfterDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserSMTPUseDefCredentials")]
	public bool? euSMTPUseDefCredentials { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserSMTPPort")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int euSMTPPort { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailUserSMTPUseSsl")]
	public bool? euSMTPUseSsl { get; set; }
}
