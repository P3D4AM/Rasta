using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLeaveVehicleType_LangMetadata))]
public class CrmLeaveVehicleType_Lang
{
	public int CrmLeaveVehicleTypeLangID { get; set; }

	public int LeavdVehicleTypeID { get; set; }

	public int LanguageID { get; set; }

	public string LeaveVehicleType { get; set; }

	public virtual CrmLeaveVehicleType CrmLeaveVehicleType { get; set; }

	public virtual Languages Languages { get; set; }
}
