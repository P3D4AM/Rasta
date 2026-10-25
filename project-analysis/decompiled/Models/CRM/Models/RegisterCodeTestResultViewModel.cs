using System.Collections.Generic;

namespace CRM.Models;

public class RegisterCodeTestResultViewModel
{
	public string DomainName { get; set; }

	public string SerialKey { get; set; }

	public string UserCount { get; set; }

	public string UserCountMob { get; set; }

	public string DeActiveUserCount { get; set; }

	public string UserCountHrm { get; set; }

	public string LanguageCount { get; set; }

	public string PfCount { get; set; }

	public string WhCount { get; set; }

	public string UserCountCic { get; set; }

	public string UserCountCrmShop { get; set; }

	public string AccDbCount { get; set; }

	public string VoipCount { get; set; }

	public string VoipTrunkCount { get; set; }

	public string FoCount { get; set; }

	public string CenterCount { get; set; }

	public List<PrdModuleNameByValViewModel> ModuleList { get; set; }
}
