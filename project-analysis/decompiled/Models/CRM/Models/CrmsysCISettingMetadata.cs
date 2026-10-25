using System;

namespace CRM.Models;

public class CrmsysCISettingMetadata
{
	public int Id { get; set; }

	public string DeviceName { get; set; }

	public string ComPort { get; set; }

	public string ComSetting { get; set; }

	public int? StartLineNumber { get; set; }

	public string CIServerIP { get; set; }

	public string SrvName { get; set; }

	public string DBName { get; set; }

	public string SUser { get; set; }

	public string SPass { get; set; }

	public bool? IsActive { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
