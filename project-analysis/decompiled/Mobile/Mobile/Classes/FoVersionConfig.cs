namespace Mobile.Classes;

public static class FoVersionConfig
{
	private static string _currentANDVerApi = "1.0.2.24.0507";

	private static string _currentIOSVerApi = "1.0.2.24.0507";

	private static string _currentPWAVerApi = "1.0.2.24.0507";

	public static string CurrentVerApi => _currentANDVerApi;

	public static string CurrentIOSVerApi => _currentIOSVerApi;

	public static string CurrentPWAVerApi => _currentPWAVerApi;
}
