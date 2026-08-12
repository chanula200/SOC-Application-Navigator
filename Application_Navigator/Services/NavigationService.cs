using ApplicationNavigator.Models;

namespace ApplicationNavigator.Services
{
    public class NavigationService
    {
        public List<NavigationItem> GetNavigationItems()
        {
            return new List<NavigationItem>
            {
                new NavigationItem(1, "NOC Portal", "http://localhost:5083", "Monitor Network Alarms and Escalations"),
                new NavigationItem(2, "CDR Portal", "https://www.example.com/test2", "Get the summary of call records and new connection testing"),
                new NavigationItem(3, "RTU Monitoring", "https://www.example.com/test3", "Telemetry Unit maintenance and Alarm configuring portal"),
                new NavigationItem(4, "Issue Register", "https://www.example.com/test4", "Log any with the contractors during the project completion"),
                new NavigationItem(5, "Network Logs", "https://www.example.com/test5", "View real time network alarm monitoring"),
                new NavigationItem(6, "LTE Fault Handling", "https://www.example.com/test6", "Integrated with necessary system logs to support LTE fault handling"),
                new NavigationItem(7, "Digital Service", "https://www.example.com/test7", "Inventory Management system for the Managed Services Operation"),
                new NavigationItem(8, "Power Outages", "https://www.example.com/test8", "View Planned Commercial Power Outages of CEB and LECO"),
                new NavigationItem(9, "Test 9", "https://www.example.com/test9", "Ninth system for testing and development"),
                new NavigationItem(10, "Test 10", "https://www.example.com/test10", "Tenth system for testing and development")
            };
        }

        public void LogNavigation(string systemName, string url)
        {
            try
            {
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Navigated to: {systemName} - {url}";
                File.AppendAllText("navigation.log", logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logging error: {ex.Message}");
            }
        }
    }
}
