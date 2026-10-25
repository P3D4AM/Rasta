using System;

namespace CRM.Models;

public class WSspSelectDeliveryScheduleByDayNumber_Result
{
	public int DeliveryScheduleId { get; set; }

	public short DayNumber { get; set; }

	public string Title { get; set; }

	public string FTime { get; set; }

	public string TTime { get; set; }

	public int Cnt { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string Prdjson { get; set; }

	public bool? DeActive { get; set; }
}
