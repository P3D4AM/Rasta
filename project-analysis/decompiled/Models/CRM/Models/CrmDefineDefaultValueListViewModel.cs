using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmDefineDefaultValueListViewModel
{
	[Key]
	public int ProjectDefualtValueId { get; set; }

	public int FieldTitleId { get; set; }

	public string DefualtValue { get; set; }

	public string Description { get; set; }
}
