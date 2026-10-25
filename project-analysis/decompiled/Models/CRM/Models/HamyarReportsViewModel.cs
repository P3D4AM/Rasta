namespace CRM.Models;

public class HamyarReportsViewModel
{
	public class GozareshFactorha
	{
		public long? rowNumber { get; set; }

		public string kindForm { get; set; }

		public long? shoBarg { get; set; }

		public string tarBarg { get; set; }

		public long? customer { get; set; }

		public string tafName { get; set; }

		public string moshtariMotefaregheh { get; set; }

		public long? markaz { get; set; }

		public long? mabFactor { get; set; }

		public long? mabTakhfifEzafeKala { get; set; }

		public long? mabMaliatFactor { get; set; }

		public long? mabTakhfifEzafeFactor { get; set; }

		public long? mabGhabelePardakht { get; set; }

		public string tafsili2 { get; set; }

		public string tafsili2Name { get; set; }
	}

	public class GozareshVaredeSadereBetafkikTaf
	{
		public long? rowNumber { get; set; }

		public long? anbarCode { get; set; }

		public string anbarName { get; set; }

		public string kalacode { get; set; }

		public string kalaName { get; set; }

		public string vahedName { get; set; }

		public string noeBargName { get; set; }

		public long? formId { get; set; }

		public string tarikh { get; set; }

		public long? meghdar_Sadere { get; set; }

		public string sharhMeghdari { get; set; }

		public string farayand_FaaliatName { get; set; }

		public long? shoSefaresh { get; set; }

		public long? radifSefaresh { get; set; }

		public long? meghdar_Varede { get; set; }

		public long? vaznKhales { get; set; }

		public string tahvilGirandehName { get; set; }

		public decimal? vaznBaskul { get; set; }

		public string shomareBarName { get; set; }

		public decimal? shoGhabzBaskul { get; set; }

		public string nameDriver { get; set; }

		public string carNumber { get; set; }

		public string shoSefareshKharid { get; set; }

		public string itemSefareshKharid { get; set; }

		public string shKTejarat { get; set; }

		public string namMarkazHaml { get; set; }

		public string shomareBarNameTamin { get; set; }
	}

	public class GozareshVaredeSadereBetafkikTaf2
	{
		public long? rowNumber { get; set; }

		public long? anbarCode { get; set; }

		public string anbarName { get; set; }

		public string kalacode { get; set; }

		public string kalaName { get; set; }

		public string vahedName { get; set; }

		public string noeBargName { get; set; }

		public long? formId { get; set; }

		public string tarikh { get; set; }

		public long? meghdar_Sadere { get; set; }

		public string sharhMeghdari { get; set; }

		public string farayand_FaaliatName { get; set; }

		public string shoSefaresh { get; set; }

		public long? radifSefaresh { get; set; }

		public long? meghdar_Varede { get; set; }

		public string tafMeghdariName { get; set; }

		public string shKTejarat { get; set; }

		public string namMarkazHaml { get; set; }
	}

	public class MojudiAvalDore
	{
		public long? rowNumber { get; set; }

		public string kala { get; set; }

		public string kalaName { get; set; }

		public string vahedKala { get; set; }

		public long? mojoodiAval { get; set; }

		public long? sumMojoodiAvalFaree { get; set; }
	}

	public class MojudiMeghdariKala
	{
		public int? rowNumber { get; set; }

		public string kala { get; set; }

		public string kalaName { get; set; }

		public string vahedName { get; set; }

		public string groupAsliName { get; set; }

		public string tafMeghdariName { get; set; }

		public string shoSefareshKharid { get; set; }

		public string itemSefareshKharid { get; set; }

		public int? meghdar_Varede { get; set; }

		public string kala_Position { get; set; }

		public string aposi04 { get; set; }

		public string aposi05 { get; set; }

		public string aposi06 { get; set; }
	}

	public class GozareshVaraghReside
	{
		public string RowNumber { get; set; }

		public string FormId { get; set; }

		public string Tarikh { get; set; }

		public string AnbarName { get; set; }

		public string FaaliatName_Farayand { get; set; }

		public string Tafsili { get; set; }

		public string TafsiliNam { get; set; }

		public string RadifKala { get; set; }

		public string GroupAsli { get; set; }

		public string GroupFaree { get; set; }

		public string Kalacode { get; set; }

		public string KalaName { get; set; }

		public string ShoGhabzBaskul { get; set; }

		public string VanzBaskul { get; set; }

		public string MeghdarKala { get; set; }

		public string VaznKala { get; set; }

		public string ShoSefareshKharid { get; set; }

		public string ItemSefareshKharid { get; set; }

		public string GhaymjatPaye { get; set; }

		public string MabKharid { get; set; }

		public string KerayeHamel { get; set; }

		public string MarkazHamal { get; set; }

		public string MarkazHamalName { get; set; }

		public string ShoMashin { get; set; }

		public string NameRanandeh { get; set; }

		public string CodeMeliRanadeh { get; set; }

		public string ShoShabaRanandeh { get; set; }

		public string ShoHamrahRanandeh { get; set; }

		public string ShoBarnameJadeh { get; set; }

		public string TarBarnameJadeh { get; set; }

		public string ShoFactor { get; set; }

		public string TarFactor { get; set; }

		public string TarSarresid { get; set; }

		public string ShoBarname { get; set; }

		public string TarBarname { get; set; }

		public string EtebarAsnadi { get; set; }

		public string EtebarAsnadiName { get; set; }

		public string NahvePardakht { get; set; }

		public string NahvePardakhtName { get; set; }

		public string KerayeHamelKala { get; set; }

		public string MabdaSefaresh { get; set; }

		public string MabdaSefareshName { get; set; }
	}

	public class GardeshHesab2
	{
		public long? RowNumber { get; set; }

		public string Kol { get; set; }

		public string Moin { get; set; }

		public string Taf2 { get; set; }

		public string Name2Taf { get; set; }

		public string Project { get; set; }

		public string MHazineh { get; set; }

		public string ShoSanad { get; set; }

		public string ShoBargeh { get; set; }

		public string TarBargeh { get; set; }

		public string TarMoaser { get; set; }

		public string Sharh { get; set; }

		public long? Meghdar { get; set; }

		public string UnitName { get; set; }

		public string MabMaliatAvarez { get; set; }

		public string MabBed { get; set; }

		public string MabBes { get; set; }

		public string ManBed { get; set; }

		public string ManBes { get; set; }

		public string Taf { get; set; }

		public string TafName { get; set; }
	}
}
