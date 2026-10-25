using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormRegularExpressions_LangMetadata))]
public class CrmDyFormRegularExpressions_Lang
{
	public int CrmDyFormRegularExpressionLangID { get; set; }

	public int RegularExpressionId { get; set; }

	public string Title { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmDyFormRegularExpressions CrmDyFormRegularExpressions { get; set; }

	public virtual Languages Languages { get; set; }
}
