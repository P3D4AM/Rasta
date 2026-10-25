using System;

namespace Mobile.Models;

public class MobspSelectCompanyOperations_Result
{
	public int AllPage { get; set; }

	public long? RowNumber { get; set; }

	public int? OprTypeId { get; set; }

	public string Opr { get; set; }

	public long OprId { get; set; }

	public string OprDate { get; set; }

	public string OprDay { get; set; }

	public string OprTime { get; set; }

	public DateTime? OprDateTime { get; set; }

	public int? OprTopicId { get; set; }

	public string OprTopic { get; set; }

	public int? OprPersonId { get; set; }

	public string OprPerson { get; set; }

	public int? OprProjectId { get; set; }

	public int? OprUserId { get; set; }

	public string OprUser { get; set; }

	public int? OprReferUserId { get; set; }

	public string OprReferUser { get; set; }

	public string OprDesc { get; set; }

	public int? OprStatusId { get; set; }

	public string OprStatus { get; set; }

	public int? OprProgressPercent { get; set; }

	public string OprRemindDate { get; set; }

	public DateTime? OprRemindDateTime { get; set; }

	public int? OprRemindOk { get; set; }

	public DateTime? RegisterDate { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? OprCompanyId { get; set; }

	public string tmpVal { get; set; }

	public int? OprFilecnt { get; set; }

	public string OprRemindTime { get; set; }

	public string OprRemindDateForAllarm { get; set; }

	public DateTime? OprRemindDateTimeForAllarm { get; set; }

	public bool? OprFOCmpCanSee { get; set; }

	public bool? OprIsTicket { get; set; }
}
