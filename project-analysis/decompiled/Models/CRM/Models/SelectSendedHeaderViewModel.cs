using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SelectSendedHeaderViewModel
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsSendDate")]
	public string SendDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsSendDay")]
	public string SendDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsSendTime")]
	public string SendTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SmsSendTopic")]
	public string SendTopic { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsHeaderNumberCount")]
	public int? NumberCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsBodyCount")]
	public int? smsBodyCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsUserCost")]
	public decimal? UserCost { get; set; }

	public int? UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsSID")]
	public long? SID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsHeaderFromNumber")]
	public string FromNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsSendType")]
	public int SendType { get; set; }
}
