using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace Mobile.Models;

public class WebSettingViewModel
{
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MobMsgErrorAllInfoWebSetting")]
	public string AllSettings { get; set; }
}
