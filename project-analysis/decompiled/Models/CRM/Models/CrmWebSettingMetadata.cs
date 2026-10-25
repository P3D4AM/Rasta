using System;

namespace CRM.Models;

public class CrmWebSettingMetadata
{
	public int WebSettingID { get; set; }

	public string Key { get; set; }

	public string Value { get; set; }

	public string Type { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public bool IsActive { get; set; }
}
