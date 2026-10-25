using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspIntMsgSelectReceiverViewModel
{
	public int crmUserId { get; set; }

	public bool? Selector { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Selector")]
	public bool SelectorValue
	{
		get
		{
			if (Selector.HasValue)
			{
				return Selector != false;
			}
			return false;
		}
	}

	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "IntMsgVal")]
	public string Val { get; set; }
}
