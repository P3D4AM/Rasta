namespace CRM.Models;

public class CRMspSearchUsers_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public string PersCode { get; set; }

	public string UserName { get; set; }

	public int? PositionId { get; set; }

	public string PositionName { get; set; }

	public int? UserRollId { get; set; }

	public string UserRollName { get; set; }

	public string Tel { get; set; }

	public string Mobile { get; set; }

	public string MobileII { get; set; }

	public string Address { get; set; }

	public string FatherName { get; set; }

	public string NationalCode { get; set; }

	public string IdentityNumber { get; set; }

	public string InsuranceCode { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }
}
