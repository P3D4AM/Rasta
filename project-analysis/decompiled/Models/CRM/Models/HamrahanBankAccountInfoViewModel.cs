using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanBankAccountInfoViewModel
{
	public long? bankRecNo { get; set; }

	public string bankName { get; set; }

	public long? armRecNo { get; set; }

	public string armName { get; set; }

	public long? accountBankRecNo { get; set; }

	public string codeAccount { get; set; }

	public string numberAccount { get; set; }

	public string fullName { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
