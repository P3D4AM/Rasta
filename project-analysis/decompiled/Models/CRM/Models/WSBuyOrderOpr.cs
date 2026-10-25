using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderOprMetadata))]
public class WSBuyOrderOpr
{
	public int BuyOrderOprID { get; set; }

	public string Name { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public int? DocOprId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccBuyOrderOprIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public int? UserId { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderOpr_Lang> WSBuyOrderOpr_Lang { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSBuyOrderOpr()
	{
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderOpr_Lang = (ICollection<WSBuyOrderOpr_Lang>)new HashSet<WSBuyOrderOpr_Lang>();
		WSBuyOrderDefaultSetting = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
	}
}
