using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsComments_LangMetadata
{
	[Key]
	public int CrmCmsCommentLangID { get; set; }

	public int CommentId { get; set; }

	public int LanguageID { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string Description { get; set; }
}
