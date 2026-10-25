using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class TreeDyFormViewModel
{
	public int Id { get; set; }

	public string Text { get; set; }

	public List<TreeSysPartsDyFormViewModel> Items { get; set; }
}
