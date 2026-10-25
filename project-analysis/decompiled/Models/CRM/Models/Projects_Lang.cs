using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Projects_LangMetadata))]
public class Projects_Lang
{
	public int ProjectsLangID { get; set; }

	public int Id { get; set; }

	public int LanguageID { get; set; }

	public string Name { get; set; }

	public string Title { get; set; }

	public string Company { get; set; }

	public string AboutCompany { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Projects Projects { get; set; }
}
