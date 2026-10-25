using System;

namespace Mobile.Models;

public class MobspSelectLinkedProducts_Result
{
	public int LinkedProductId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string SGroupName { get; set; }

	public string EditUser { get; set; }

	public int PrdId { get; set; }

	public int LinkedPrdId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public double? LinkedPrdQuantity { get; set; }

	public bool? LinkedPrdNotVisible { get; set; }

	public bool? LinkedPrdNotInSum { get; set; }

	public bool? LinkedPrdAddQuantity { get; set; }

	public bool? LinkedPrdAddPrice { get; set; }

	public double? PrdFCRInUnit { get; set; }

	public double? PrdFCRIInUnit { get; set; }

	public long? ManualOrderView { get; set; }

	public int? OrderView { get; set; }

	public string PrdUnit { get; set; }

	public string PrdUnitI { get; set; }

	public string PrdUnitII { get; set; }
}
