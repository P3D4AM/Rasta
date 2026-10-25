using System.Collections.Generic;

namespace CRM.Models;

public class AdvanceResultItemViewModel
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Code { get; set; }

	public dynamic Obj { get; set; }

	public CommonResultStatusViewModel Status { get; set; } = CommonResultStatusViewModel.Fail;


	public string Success { get; set; }

	public List<string> Errors { get; set; } = new List<string>();


	public List<string> Warnings { get; set; } = new List<string>();

}
