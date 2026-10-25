namespace CRMIdeal.Classes.Common;

public static class VersionConfig
{
	private static string _currentVerWeb = "3.1.18.187.0507";

	private static string _currentVerWin = "4.4.3.213.0507";

	private static string _currentVerStyle = _currentVerWeb;

	private static string _currentVerCallerId = "4-2-3-16";

	private static string _currentVerSmdService = "1-0-0-7";

	private static string _currentVerPrdImportExcel = "1.0.0.1.9509";

	private static string _currentVerPrdExportExcel = "1.0.0.1.9509";

	private static int _currentDyFormFieldMasterValuesTableVersion = 1;

	public static string CurrentVerWeb => _currentVerWeb;

	public static string CurrentVerWin => _currentVerWin;

	public static string CurrentVerStyle => _currentVerStyle;

	public static string CurrentVerCallerId => _currentVerCallerId;

	public static string CurrentVerSmdService => _currentVerSmdService;

	public static string CurrentVerPrdImportExcel => _currentVerPrdImportExcel;

	public static string CurrentVerPrdExportExcel => _currentVerPrdExportExcel;

	public static int CurrentDyFormFieldMasterValuesTableVersion => _currentDyFormFieldMasterValuesTableVersion;
}
