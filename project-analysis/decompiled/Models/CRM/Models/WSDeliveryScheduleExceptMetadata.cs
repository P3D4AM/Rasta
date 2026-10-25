using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDeliveryScheduleExceptMetadata
{
	[Key]
	public int DeliveryScheduleExceptId { get; set; }

	public DateTime ExDate { get; set; }

	public string ExDatePersian { get; set; }

	public string ExFTime { get; set; }

	public string ExTTime { get; set; }

	public int ExCnt { get; set; }

	public string ExDesc { get; set; }

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
