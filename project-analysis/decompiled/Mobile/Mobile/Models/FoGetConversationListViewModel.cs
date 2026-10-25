using System.Collections.Generic;

namespace Mobile.Models;

public class FoGetConversationListViewModel
{
	public List<FOMobspSelectPrjConversationAndFiles_Result> ListConversation { get; set; }

	public FOMobspSelectCompanyProjectById_Result Project { get; set; }

	public List<FOMobspSelectFilesDirectory_Result> ListConversationFiles { get; set; }

	public List<FOMobspknlgSelectKnowledgeTankByIds_Result> ListConversationKnowledgeTank { get; set; }
}
