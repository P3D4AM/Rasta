namespace CRM.Models;

public class CRMspSelectCompanyPushNotifTank_Result
{
	public int CompnayPushNotifTankId { get; set; }

	public int cpCompanyId { get; set; }

	public int cpTypeId { get; set; }

	public string cpTitle { get; set; }

	public string cpBody { get; set; }

	public string cpExtraData { get; set; }

	public int? cpPriority { get; set; }
}
