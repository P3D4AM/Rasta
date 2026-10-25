using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLeaveVehicleType_LangMetadata
{
	[Key]
	public int CrmLeaveVehicleTypeLangID { get; set; }

	public int LeavdVehicleTypeID { get; set; }

	public int LanguageID { get; set; }

	public string LeaveVehicleType { get; set; }
}
