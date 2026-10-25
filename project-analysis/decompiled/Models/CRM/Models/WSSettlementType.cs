using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSSettlementTypeMetadata))]
public class WSSettlementType
{
	public int Id { get; set; }

	public short? Code { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccSettlementTypeIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSSettlementType_Lang> WSSettlementType_Lang { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSSettlementType()
	{
		WSSettlementType_Lang = (ICollection<WSSettlementType_Lang>)new HashSet<WSSettlementType_Lang>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
	}
}
