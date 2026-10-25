using System.Collections.Generic;

namespace CRM.Models;

public class ShygunDetailedAPIAccountClosingBalanceResponseViewModel
{
	public List<ShygunDetailedAPIAccountClosingBalanceInfoViewModel> Result { get; set; }

	public long? Checksum { get; set; }

	public string TokenString { get; set; }
}
