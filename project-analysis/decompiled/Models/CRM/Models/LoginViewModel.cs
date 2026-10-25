using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class LoginViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "LoginUsername")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LoginPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LoginRememberMe")]
	[DefaultValue(false)]
	public bool RememberMe { get; set; }

	public string SendFromAdmin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LoginCaptchaCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string CaptchaCode { get; set; }

	[DefaultValue(false)]
	public bool IsCheckCaptchaCode { get; set; }

	public bool? CanSetFree { get; set; }

	public bool? InactiveSaveTimeAttendance { get; set; }

	public bool? CheckedTimeAttendance { get; set; }

	public bool? UseActiveDirectoryUser { get; set; }

	public int? LoginAuthType { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public int? ShiftWorkingTimeId { get; set; }

	public int? LeaveId { get; set; }

	public string LeaveStepIds { get; set; }

	public string ClearTimeAttendanceIds { get; set; }
}
