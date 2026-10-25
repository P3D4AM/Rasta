using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDeliveryTermsMetadata))]
public class WSDeliveryTerms
{
	public int DeliveryTermId { get; set; }

	public string DeliveryTerm { get; set; }

	public int? OrderView { get; set; }

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

	public string LinkAccDeliveryTermIdStr { get; set; }

	public bool? SHPVisible { get; set; }

	public bool? SHPDefault { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public bool? SHPNeedAddress { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSDeliveryTerms_Lang> WSDeliveryTerms_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSDeliveryTerms()
	{
		WSDeliveryTerms_Lang = (ICollection<WSDeliveryTerms_Lang>)new HashSet<WSDeliveryTerms_Lang>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
