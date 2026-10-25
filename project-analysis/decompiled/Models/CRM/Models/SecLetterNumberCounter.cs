using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SecLetterNumberCounterMetadata))]
public class SecLetterNumberCounter
{
	public int LetterNumberCounterId { get; set; }

	public int LetterTypeId { get; set; }

	public string LtrNumCntTitle { get; set; }

	public long LtrNumCntBeginner { get; set; }

	public string LtrNumCntPreNumber { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public virtual ICollection<SecLetterNumberCounter_Lang> SecLetterNumberCounter_Lang { get; set; }

	public virtual SecLetterType SecLetterType { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public SecLetterNumberCounter()
	{
		SecLetterDefaultSettings = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetterNumberCounter_Lang = (ICollection<SecLetterNumberCounter_Lang>)new HashSet<SecLetterNumberCounter_Lang>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
	}
}
