using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmPersonJobs_LangMetadata))]
public class CrmPersonJobs_Lang
{
	public int CrmPersonJobsLangID { get; set; }

	public int PersonJobID { get; set; }

	public int LanguageID { get; set; }

	public string Jobs { get; set; }

	public virtual CrmPersonJobs CrmPersonJobs { get; set; }

	public virtual Languages Languages { get; set; }
}
