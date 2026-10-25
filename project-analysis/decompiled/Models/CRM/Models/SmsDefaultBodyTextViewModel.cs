using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SmsDefaultBodyTextViewModel
{
	[Key]
	public int Id { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsDefBodyTextTitle")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsDefBodyText")]
	public string Text { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsDefBodyTextDescription")]
	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsDefBodyTextGroupId")]
	public int? GroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsDefBodyTextGroupId")]
	public string GroupIdTitle { get; set; }

	public Guid? GUId { get; set; }
}
