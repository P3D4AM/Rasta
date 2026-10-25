using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UserLoginAllowedTimesViewModel
{
	[Key]
	public int UserLoginAllowedTimeId { get; set; }

	public int Mode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesCrmUserId")]
	public int? crmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesCrmRollId")]
	public int? crmRollId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesDayNumber")]
	public string DayNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesFTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorFormatTime")]
	public string FTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesTTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorFormatTime")]
	public string TTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesIPAddress")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorFormatIP")]
	public string IPAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesFDatePersian")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginAllowedTimesTDatePersian")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string TDatePersian { get; set; }

	public int? OrderView { get; set; }

	public int? RegisterUserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string AppType { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
