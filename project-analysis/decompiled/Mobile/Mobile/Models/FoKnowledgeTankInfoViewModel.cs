using System.Collections.Generic;

namespace Mobile.Models;

public class FoKnowledgeTankInfoViewModel
{
	public FOMobspknlgSelectKnowledgeTankById_Result KnowledgeTank { get; set; }

	public List<FOMobspSelectFilesDirectory_Result> ListKnlgFiles { get; set; }
}
