namespace CRM.Models;

public class CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result
{
	public int? CallTypeId { get; set; }

	public string PhoneNumber { get; set; }

	public string TrunkSource { get; set; }

	public string TrunkDestination { get; set; }

	public string CallPreNumber { get; set; }

	public int? SelectedUserId { get; set; }
}
