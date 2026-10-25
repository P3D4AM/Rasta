using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmWebSettingViewModel
{
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorAllInformationWebSetting")]
	public string AllSettings { get; set; }
}
