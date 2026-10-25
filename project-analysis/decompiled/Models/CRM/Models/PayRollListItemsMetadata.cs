using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollListItemsMetadata
{
	[Key]
	public int PayRollListItemId { get; set; }

	public int PayRollListId { get; set; }

	public int CycleId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
