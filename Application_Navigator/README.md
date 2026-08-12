# Application Navigator - Web Edition

A modern ASP.NET Core web application that provides quick navigation to 10 different systems via an interactive button interface running on localhost.

## Project Structure

```
Application_Navigator/
├── ApplicationNavigator.csproj     # Project file
├── Program.cs                      # Application entry point
├── appsettings.json                # Application configuration
├── Controllers/
│   └── HomeController.cs           # Handles routing and navigation
├── Models/
│   └── NavigationItem.cs           # Data model for navigation items
├── Services/
│   └── NavigationService.cs        # Navigation logic and logging
├── Views/
│   └── Home/
│       └── Index.cshtml            # Main page with 10 buttons
├── wwwroot/
│   ├── css/
│   │   └── style.css               # Responsive styling
│   └── js/
│       └── app.js                  # Client-side navigation logic
├── navigation.log                   # Auto-generated log file
└── README.md                        # This file
```

## Features

- **10 Navigation Buttons**: Test 1 through Test 10
- **Modern Responsive UI**: Works on desktop and mobile
- **Smooth Animations**: Hover effects and transitions
- **Client-Side Navigation**: Opens URLs in new tabs
- **Server-Side Logging**: All navigation actions logged to `navigation.log`
- **Gradient Design**: Beautiful purple and blue gradient background

## Getting Started

### Prerequisites
- .NET 8 SDK or later
- Windows, macOS, or Linux

### Running the Application

1. Navigate to the project directory:
   ```bash
   cd d:\Application_Navigator
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to:
   ```
   http://localhost:5000
   ```

## Customizing Navigation URLs

Edit the `Services/NavigationService.cs` file and update the URLs in the `GetNavigationItems()` method:

```csharp
new NavigationItem(1, "Test 1", "YOUR_URL_HERE", "First test system"),
```

## How It Works

1. User visits `http://localhost:5000`
2. Page displays 10 navigation buttons
3. Clicking a button:
   - Sends a log request to the server
   - Opens the URL in a new browser tab
   - Shows a confirmation message
4. All navigation actions are logged to `navigation.log`

## Technology Stack

- **Backend**: ASP.NET Core 8.0
- **Frontend**: HTML5, CSS3, Vanilla JavaScript
- **Language**: C#
- **Architecture**: MVC Pattern

## API Endpoints

- `GET /` - Main page with navigation buttons
- `POST /Home/Navigate` - Logs navigation action

## Responsive Design

The application is fully responsive and works on:
- Desktop (Windows, macOS, Linux)
- Tablets
- Mobile devices

## Customization Options

### Change Button Layout
Edit `Views/Home/Index.cshtml` to modify the button grid

### Customize Colors
Edit `wwwroot/css/style.css` to change the color scheme

### Add More Buttons
Edit `Services/NavigationService.cs` to add more items to the list

## Future Enhancements

- Configuration file support (JSON/XML)
- User authentication
- Navigation history
- Favorites system
- Search functionality
- Multiple navigation categories

