using System;

namespace CRM.Models;

public class CrmCallBlackListMetadata
{
	public int BlackListId { get; set; }

	public int BLUserId { get; set; }

	public string BLNumber { get; set; }

	public string BLNumberTitle { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
