using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderItemSerialsMetadata))]
public class WSOrderItemSerials
{
	public int OrderItemSerialID { get; set; }

	public int OrderItemId { get; set; }

	public int SerialId { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? WHId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderItemSerials_Lang> WSOrderItemSerials_Lang { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual WSOrderItems WSOrderItems { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSOrderItemSerials()
	{
		WSOrderItemSerials_Lang = (ICollection<WSOrderItemSerials_Lang>)new HashSet<WSOrderItemSerials_Lang>();
	}
}
