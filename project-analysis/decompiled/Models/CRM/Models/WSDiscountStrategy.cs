using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDiscountStrategyMetadata))]
public class WSDiscountStrategy
{
	public int DiscountStrategyId { get; set; }

	public string DisStTitle { get; set; }

	public int DisStSystemPartId { get; set; }

	public int DisStDiscountStrategyTypeId { get; set; }

	public string DisStTypeValues { get; set; }

	public DateTime? DisStExpireDate { get; set; }

	public string DisStExpireDatePersian { get; set; }

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

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<UserMoneyBag> UserMoneyBag { get; set; }

	public virtual ICollection<WSDiscountStrategy_Lang> WSDiscountStrategy_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderDiscounts> WSOrderDiscounts { get; set; }

	public virtual ICollection<WSPreOrderDiscounts> WSPreOrderDiscounts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSDiscountStrategy()
	{
		UserMoneyBag = (ICollection<UserMoneyBag>)new HashSet<UserMoneyBag>();
		WSDiscountStrategy_Lang = (ICollection<WSDiscountStrategy_Lang>)new HashSet<WSDiscountStrategy_Lang>();
		WSOrderDiscounts = (ICollection<WSOrderDiscounts>)new HashSet<WSOrderDiscounts>();
		WSPreOrderDiscounts = (ICollection<WSPreOrderDiscounts>)new HashSet<WSPreOrderDiscounts>();
	}
}
