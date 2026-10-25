using System.Collections.Generic;

namespace CRM.Models;

public class SmsMelliSendManyToManyViewModel
{
	public string uname { get; set; }

	public string pass { get; set; }

	public string from { get; set; }

	public List<SmsMelliContentSendManyToManyViewModel> content { get; set; }
}
