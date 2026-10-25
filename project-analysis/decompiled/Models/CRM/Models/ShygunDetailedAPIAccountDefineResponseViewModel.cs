using System.Collections.Generic;

namespace CRM.Models;

public class ShygunDetailedAPIAccountDefineResponseViewModel
{
	public List<ShygunDetailedAPIAccountDefineInfoResponseViewModel> Result { get; set; }

	public string ErrorMessage { get; set; }
}
