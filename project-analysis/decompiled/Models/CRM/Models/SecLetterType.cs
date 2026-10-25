using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SecLetterTypeMetadata))]
public class SecLetterType
{
	public int LetterTypeId { get; set; }

	public string LetterTypeTitle { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<SecLetterType_Lang> SecLetterType_Lang { get; set; }

	public virtual ICollection<SecLetterNumberCounter> SecLetterNumberCounter { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public SecLetterType()
	{
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SecLetterType_Lang = (ICollection<SecLetterType_Lang>)new HashSet<SecLetterType_Lang>();
		SecLetterNumberCounter = (ICollection<SecLetterNumberCounter>)new HashSet<SecLetterNumberCounter>();
	}
}
