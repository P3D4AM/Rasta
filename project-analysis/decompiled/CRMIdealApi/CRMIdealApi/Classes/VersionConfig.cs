namespace CRMIdealApi.Classes;

public static class VersionConfig
{
	private static string _currentVerApi = "0.0.4.45.0507";

	private static int _currentDyFormFieldMasterValuesTableVersion = 1;

	public static string CurrentVerApi => _currentVerApi;

	public static int CurrentDyFormFieldMasterValuesTableVersion => _currentDyFormFieldMasterValuesTableVersion;
}
