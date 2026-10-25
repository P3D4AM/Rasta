using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductsRateMetadata
{
	[Key]
	public int ProductRateId { get; set; }

	public int StarRate { get; set; }

	public string IPAddress { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }
}
