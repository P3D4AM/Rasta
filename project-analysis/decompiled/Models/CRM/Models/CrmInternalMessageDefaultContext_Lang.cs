using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageDefaultContext_LangMetadata))]
public class CrmInternalMessageDefaultContext_Lang
{
	public int CrmInternalMessageDefaultContextLangID { get; set; }

	public int InternalMessageDefaultContextId { get; set; }

	public int LanguageID { get; set; }

	public string Col1 { get; set; }

	public string Col2 { get; set; }

	public string Col3 { get; set; }

	public string Col4 { get; set; }

	public string Col5 { get; set; }

	public string Col6 { get; set; }

	public string Col7 { get; set; }

	public string Col8 { get; set; }

	public string Col9 { get; set; }

	public string Col10 { get; set; }

	public string Col11 { get; set; }

	public string Col12 { get; set; }

	public string Col13 { get; set; }

	public string Col14 { get; set; }

	public string Col15 { get; set; }

	public virtual CrmInternalMessageDefaultContext CrmInternalMessageDefaultContext { get; set; }

	public virtual Languages Languages { get; set; }
}
