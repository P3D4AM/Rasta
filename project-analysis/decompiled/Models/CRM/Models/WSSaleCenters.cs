using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSSaleCentersMetadata))]
public class WSSaleCenters
{
	public int SaleCenterId { get; set; }

	public string SaleCenterName { get; set; }

	public string LinkAccSaleCenterIdStr { get; set; }

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

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public int? ParentId { get; set; }

	public string StartTime { get; set; }

	public string EndTime { get; set; }

	public int? ReferUserId { get; set; }

	public string SaleCenterTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSSaleCenters_Lang> WSSaleCenters_Lang { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public WSSaleCenters()
	{
		WSSaleCenters_Lang = (ICollection<WSSaleCenters_Lang>)new HashSet<WSSaleCenters_Lang>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSTmpUserItemCopy = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
