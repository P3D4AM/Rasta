using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSLinkedProductsViewModel
{
	[Key]
	public int LinkedProductId { get; set; }

	public int PrdId { get; set; }

	public string PrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int LinkedPrdId { get; set; }

	public string LinkedPrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdQuantity")]
	public double? LinkedPrdQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdNotVisible")]
	public bool? LinkedPrdNotVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdNotInSum")]
	public bool? LinkedPrdNotInSum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdAddQuantity")]
	public bool? LinkedPrdAddQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdAddPrice")]
	public bool? LinkedPrdAddPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdAddDiscount")]
	public bool? LinkedPrdAddDiscount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdIsSelect")]
	public bool? LinkedPrdIsSelect { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkedPrdOrderView")]
	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
