using System;

namespace CRM.Models;

public class WSspSelectDeliveryScheduleExceptByDayNumber_Result
{
	public int DeliveryScheduleExceptId { get; set; }

	public DateTime ExDate { get; set; }

	public string ExDatePersian { get; set; }

	public string ExFTime { get; set; }

	public string ExTTime { get; set; }

	public int ExCnt { get; set; }

	public string ExDesc { get; set; }

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

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string ExTitle { get; set; }

	public string ExPrdJson { get; set; }

	public bool? ExDeActive { get; set; }
}
