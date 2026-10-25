using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyLoGoViewModel
{
	public int CompanyLoGoID { get; set; }

	public int? CompanyId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "frmErrorEmpty")]
	public string CompanyLogoPath { get; set; }

	public string LogoDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string AppType { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
