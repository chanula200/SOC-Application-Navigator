using ApplicationNavigator.Models;

namespace ApplicationNavigator.Services
{
    public class NavigationService
    {
        public List<NavigationItem> GetNavigationItems()
        {
            return new List<NavigationItem>
            {
                new NavigationItem(
                    1, 
                    "NOC Portal", 
                    "http://localhost:5083", 
                    "Monitor Network Alarms and Escalations",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><rect x=""2"" y=""3"" width=""20"" height=""14"" rx=""2"" ry=""2""/><line x1=""8"" y1=""21"" x2=""16"" y2=""21""/><line x1=""12"" y1=""17"" x2=""12"" y2=""21""/><path d=""M6 10h3l1.5-3 3 6 1.5-3H18""/></svg>"
                ),
                new NavigationItem(
                    2, 
                    "CDR Portal", 
                    "https://www.example.com/test2", 
                    "Get the summary of call records and new connection testing",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z""/><line x1=""14"" y1=""3"" x2=""20"" y2=""3""/><line x1=""14"" y1=""7"" x2=""20"" y2=""7""/><line x1=""14"" y1=""11"" x2=""18"" y2=""11""/></svg>"
                ),
                new NavigationItem(
                    3, 
                    "RTU Monitoring", 
                    "https://www.example.com/test3", 
                    "Telemetry Unit maintenance and Alarm configuring portal",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M4.9 19.1C1.9 16.1 1.9 11.3 4.9 8.3""/><path d=""M7.8 16.2c-1.6-1.6-1.6-4.1 0-5.7""/><path d=""M16.2 10.5c1.6 1.6 1.6 4.1 0 5.7""/><path d=""M19.1 7.6c3 3 3 7.8 0 10.8""/><circle cx=""12"" cy=""12"" r=""2""/><path d=""M12 14v8""/></svg>"
                ),
                new NavigationItem(
                    4, 
                    "Issue Register", 
                    "https://www.example.com/test4", 
                    "Log any with the contractors during the project completion",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2""/><rect x=""8"" y=""2"" width=""8"" height=""4"" rx=""1"" ry=""1""/><line x1=""9"" y1=""12"" x2=""15"" y2=""12""/><line x1=""9"" y1=""16"" x2=""13"" y2=""16""/></svg>"
                ),
                new NavigationItem(
                    5, 
                    "Network Logs", 
                    "https://www.example.com/test5", 
                    "View real time network alarm monitoring",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><polyline points=""4 17 10 11 4 5""/><line x1=""12"" y1=""19"" x2=""20"" y2=""19""/><rect x=""2"" y=""3"" width=""20"" height=""18"" rx=""2""/></svg>"
                ),
                new NavigationItem(
                    6, 
                    "LTE Fault Handling", 
                    "https://www.example.com/test6", 
                    "Integrated with necessary system logs to support LTE fault handling",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M12 20h.01""/><path d=""M2 8.82a15 15 0 0 1 20 0""/><path d=""M5 12.85a10 10 0 0 1 14 0""/><path d=""M8.5 16.88a5 5 0 0 1 7 0""/><line x1=""12"" y1=""12"" x2=""12"" y2=""17""/></svg>"
                ),
                new NavigationItem(
                    7, 
                    "Digital Service", 
                    "https://www.example.com/test7", 
                    "Inventory Management system for the Managed Services Operation",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M21 16V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16z""/><polyline points=""3.27 6.96 12 12.01 20.73 6.96""/><line x1=""12"" y1=""22.08"" x2=""12"" y2=""12""/></svg>"
                ),
                new NavigationItem(
                    8, 
                    "Power Outages", 
                    "https://www.example.com/test8", 
                    "View Planned Commercial Power Outages of CEB and LECO",
                    @"<svg viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><polygon points=""13 2 3 14 12 14 11 22 21 10 12 10 13 2""/></svg>"
                ),
                new NavigationItem(
                    9, 
                    "Test 9", 
                    "https://www.example.com/test9", 
                    "Ninth system for testing and development",
                    ""
                ),
                new NavigationItem(
                    10, 
                    "Test 10", 
                    "https://www.example.com/test10", 
                    "Tenth system for testing and development",
                    ""
                )
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
