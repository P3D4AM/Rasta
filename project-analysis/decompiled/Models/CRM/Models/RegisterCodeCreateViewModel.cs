namespace CRM.Models;

public class RegisterCodeCreateViewModel
{
	public string DomainName { get; set; }

	public string SerialKey { get; set; }

	public int UserCount { get; set; }

	public int UserCountMob { get; set; }

	public int DeActiveUserCount { get; set; }

	public int UserCountHrm { get; set; }

	public int LanguageCount { get; set; }

	public int CompanyId { get; set; }

	public int PfCount { get; set; }

	public int WhCount { get; set; }

	public int UserCountCic { get; set; }

	public int UserCountCrmShop { get; set; }

	public int AccDbCount { get; set; }

	public int VoipCount { get; set; }

	public int VoipTrunkCount { get; set; }

	public int FoCount { get; set; }

	public int CenterCount { get; set; }
}
