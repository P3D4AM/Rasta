using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSGuarantyMetadata))]
public class WSGuaranty
{
	public int GuarantyID { get; set; }

	public string Guaranty { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSGuaranty_Lang> WSGuaranty_Lang { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSGuaranty()
	{
		WSGuaranty_Lang = (ICollection<WSGuaranty_Lang>)new HashSet<WSGuaranty_Lang>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
