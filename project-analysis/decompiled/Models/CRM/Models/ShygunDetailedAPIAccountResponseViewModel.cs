using System.Collections.Generic;

namespace CRM.Models;

public class ShygunDetailedAPIAccountResponseViewModel
{
	public List<ShygunDetailedAPIAccountInfoViewModel> Result { get; set; }

	public long? Checksum { get; set; }

	public string TokenString { get; set; }
}
