using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class DailyConversationViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "DailyConversationUser")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int UserList { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DailyConversationFromDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DailyConversationToDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DailyConversationOrderType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public short? OrderType { get; set; }

	public string CnvsUserIds { get; set; }
}
