using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSLinkedProductsMetadata
{
	[Key]
	public int LinkedProductId { get; set; }

	public int PrdId { get; set; }

	public int LinkedPrdId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public double? LinkedPrdQuantity { get; set; }

	public bool? LinkedPrdNotVisible { get; set; }

	public bool? LinkedPrdNotInSum { get; set; }

	public bool? LinkedPrdAddQuantity { get; set; }

	public bool? LinkedPrdAddPrice { get; set; }
}
