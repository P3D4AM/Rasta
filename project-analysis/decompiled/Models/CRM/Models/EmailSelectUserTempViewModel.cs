using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class EmailSelectUserTempViewModel
{
	[Key]
	public long ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Selector")]
	public bool Selector { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "sutnCompanyName")]
	public string CompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Email")]
	public string EmailAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "sutnPersonName")]
	public string PersonName { get; set; }

	public int CompanyId { get; set; }

	public int CompanyPersonId { get; set; }
}
