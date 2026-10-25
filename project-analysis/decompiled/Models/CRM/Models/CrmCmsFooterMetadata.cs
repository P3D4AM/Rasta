using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsFooterMetadata
{
	[Key]
	public int FooterId { get; set; }

	public string FooterBody { get; set; }

	public string FooterStyle { get; set; }

	public string FooterScript { get; set; }

	public bool? IsActive { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
