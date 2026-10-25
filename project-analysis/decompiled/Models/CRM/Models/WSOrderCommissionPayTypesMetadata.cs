using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

internal class WSOrderCommissionPayTypesMetadata
{
	[Key]
	public int OrderCommissionPayTypeId { get; set; }

	public string CommPayTypeTitle { get; set; }

	public string CommPayTypeDescription { get; set; }

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

	public int? OrderView { get; set; }

	public int LanguageID { get; set; }
}
