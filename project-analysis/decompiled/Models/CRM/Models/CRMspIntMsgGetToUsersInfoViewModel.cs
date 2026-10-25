using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspIntMsgGetToUsersInfoViewModel
{
	public int msgdToUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ToUser")]
	public string ToUser { get; set; }

	public string msgdReceiveDate { get; set; }

	public string msgdReceiveTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDateTime")]
	public DateTime? msgdReceiveDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDateTime")]
	public string ReceiveDateTime1 => msgdReceiveTime + "  " + msgdReceiveDate;

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDateTime")]
	public string ReceiveDateTime { get; set; }

	public string msgdReadDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReadDateTime")]
	public DateTime? msgdReadDateTime { get; set; }

	public string msgdReadTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReadDateTime")]
	public string ReadDateTime1 => msgdReadTime + "  " + msgdReadDate;

	[Display(ResourceType = typeof(Labels), Name = "msgdReadDateTime")]
	public string ReadDateTime { get; set; }
}
