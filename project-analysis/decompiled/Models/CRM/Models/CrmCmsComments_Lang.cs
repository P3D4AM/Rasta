using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsComments_LangMetadata))]
public class CrmCmsComments_Lang
{
	public int CrmCmsCommentLangID { get; set; }

	public int CommentId { get; set; }

	public int LanguageID { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string Description { get; set; }

	public virtual CrmCmsComments CrmCmsComments { get; set; }

	public virtual Languages Languages { get; set; }
}
