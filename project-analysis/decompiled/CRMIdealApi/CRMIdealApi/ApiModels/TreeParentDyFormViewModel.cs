using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class TreeParentDyFormViewModel : TreeColumnsDyFormViewModel
{
	public List<TreeChildDyFormViewModel> Items { get; set; }
}
