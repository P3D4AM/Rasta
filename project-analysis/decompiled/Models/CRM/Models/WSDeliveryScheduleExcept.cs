using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDeliveryScheduleExceptMetadata))]
public class WSDeliveryScheduleExcept
{
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

	public string ExTitle { get; set; }

	public string ExPrdJson { get; set; }

	public bool? ExDeActive { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSDeliveryScheduleExcept_Lang> WSDeliveryScheduleExcept_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSDeliveryScheduleExcept()
	{
		WSDeliveryScheduleExcept_Lang = (ICollection<WSDeliveryScheduleExcept_Lang>)new HashSet<WSDeliveryScheduleExcept_Lang>();
	}
}
