using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class TreeSysPartsDyFormViewModel
{
	public int Id { get; set; }

	public string Text { get; set; }

	public List<TreeParentDyFormViewModel> Items { get; set; }
}
