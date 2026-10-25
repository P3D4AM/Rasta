using System;

namespace CRM.Models;

public class WSspSelectsysCIDeviceType_Result
{
	public int CIDeviceTypeId { get; set; }

	public int CIDeviceTypeMode { get; set; }

	public string CIDeviceType { get; set; }

	public string CIDesc { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
