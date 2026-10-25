using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UserRollViewModel
{
	[Key]
	public int ID { get; set; }

	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollId")]
	public int? RollId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollId")]
	public string RollIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollPrjId")]
	public int PrjId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollPrjId")]
	public string PrjIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RollDescription")]
	public string Description { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string AccessLevel { get; set; }

	public Guid? GUId { get; set; }
}
