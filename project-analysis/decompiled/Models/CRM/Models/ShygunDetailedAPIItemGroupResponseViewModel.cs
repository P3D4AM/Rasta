using System.Collections.Generic;

namespace CRM.Models;

public class ShygunDetailedAPIItemGroupResponseViewModel
{
	public List<ShygunDetailedAPIItemGroupInfoViewModel> Result { get; set; }

	public long? Checksum { get; set; }

	public string TokenString { get; set; }
}
