using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Users_LangMetadata))]
public class Users_Lang
{
	public int UsersLangID { get; set; }

	public int UserId { get; set; }

	public int LanguageID { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string Description { get; set; }

	public string TelDesc { get; set; }

	public string Address { get; set; }

	public string FatherName { get; set; }

	public string Nickname { get; set; }

	public string DefCmpPrjTitle { get; set; }

	public string UserLoginCheckLocations { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
