namespace Mobile.Models;

public class MobspSelectSmsProvidersById_Result
{
	public int Id { get; set; }

	public int ProviderIdentity { get; set; }

	public string ProviderName { get; set; }

	public string ProviderDomain { get; set; }

	public string ProviderUrl { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public string Number { get; set; }

	public decimal? EnCost { get; set; }

	public decimal? FaCost { get; set; }

	public bool? SendIsActive { get; set; }

	public bool? ReceiveIsActive { get; set; }

	public decimal? LastCreditAmount { get; set; }

	public bool? IsActive { get; set; }

	public bool? IsDefault { get; set; }

	public int? OrderView { get; set; }

	public string Description { get; set; }

	public string SmsCustomer { get; set; }

	public string TokenUserName { get; set; }
}
