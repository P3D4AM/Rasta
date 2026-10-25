using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDeliveryScheduleMetadata
{
	[Key]
	public int DeliveryScheduleId { get; set; }

	public short DayNumber { get; set; }

	public string Title { get; set; }

	public string FTime { get; set; }

	public string TTime { get; set; }

	public int Cnt { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
