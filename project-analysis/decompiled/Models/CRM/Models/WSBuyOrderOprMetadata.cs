using System;

namespace CRM.Models;

public class WSBuyOrderOprMetadata
{
	public int BuyOrderOprID { get; set; }

	public string Name { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public int? DocOprId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
