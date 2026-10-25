using System.Collections.Generic;

namespace Mobile.Models;

public class PersonViewModel
{
	public int CompanyPersonID { get; set; }

	public int prsCompanyId { get; set; }

	public string prsFullName { get; set; }

	public string prsFullJob { get; set; }

	public string prsFullTelMob { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }
}
