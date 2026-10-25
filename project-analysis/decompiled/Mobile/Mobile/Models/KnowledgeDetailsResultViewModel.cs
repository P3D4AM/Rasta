using System.Collections.Generic;

namespace Mobile.Models;

public class KnowledgeDetailsResultViewModel
{
	public MobspKnlgSelectKnowledgeTankById_Result Knowledge { get; set; }

	public List<MobspSelectFilesDirectory_Result> FileList { get; set; }
}
