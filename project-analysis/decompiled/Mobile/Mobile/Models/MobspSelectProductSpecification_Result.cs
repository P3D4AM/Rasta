using System;

namespace Mobile.Models;

public class MobspSelectProductSpecification_Result
{
	public int ProductSpecificationID { get; set; }

	public int PrdId { get; set; }

	public string Specification { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string SpecificationI { get; set; }

	public string SpecificationII { get; set; }

	public string PrdName { get; set; }
}
