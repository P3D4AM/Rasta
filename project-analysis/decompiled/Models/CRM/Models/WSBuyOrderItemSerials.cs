using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderItemSerialsMetadata))]
public class WSBuyOrderItemSerials
{
	public int BuyOrderItemSerialID { get; set; }

	public int BuyOrderItemId { get; set; }

	public string Serial { get; set; }

	public int? StatusId { get; set; }

	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int? WHId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? SerialId { get; set; }

	public bool? IsAutoBarcode { get; set; }

	public int? tblTmpBarcodeId { get; set; }

	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public string InfoI { get; set; }

	public string InfoII { get; set; }

	public string InfoIII { get; set; }

	public string InfoIV { get; set; }

	public string InfoV { get; set; }

	public string InfoVI { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderItems WSBuyOrderItems { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials_Lang> WSBuyOrderItemSerials_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSBuyOrderItemSerials()
	{
		WSBuyOrderItemSerials_Lang = (ICollection<WSBuyOrderItemSerials_Lang>)new HashSet<WSBuyOrderItemSerials_Lang>();
	}
}
