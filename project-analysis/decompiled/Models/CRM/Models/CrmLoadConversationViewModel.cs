using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmLoadConversationViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "cnvsOpr")]
	public string Opr { get; set; }

	public long OprId { get; set; }

	public string OprDate { get; set; }

	public string OprDay { get; set; }

	public string OprTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDate")]
	public string OprDayDateTime => OprDate + " - " + OprDay + " - " + OprTime;

	[Display(ResourceType = typeof(Labels), Name = "cnvsOprPerson")]
	public string OprPerson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsOprUser")]
	public string OprUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferUserId")]
	public string OprReferUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsOprDesc")]
	public string OprDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsOprStatus")]
	public string OprStatus { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsOprRemindDate")]
	public string OprRemindDate { get; set; }

	public int? OprRemindOk { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsOprRemindOk")]
	public bool RemindOk
	{
		get
		{
			if (OprRemindOk.HasValue)
			{
				return OprRemindOk != 0;
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "cnvsOprTopic")]
	public string OprTopic { get; set; }
}
