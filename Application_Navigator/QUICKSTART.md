# Quick Start Guide

## Project Overview

Your Application Navigator is an ASP.NET Core web application with 10 navigation buttons running on localhost.

## Directory Structure

```
Application_Navigator/
├── ApplicationNavigator.csproj    # Project configuration
├── Program.cs                     # Application startup
├── appsettings.json               # Configuration
├── Controllers/                   # MVC Controllers
│   └── HomeController.cs          # Main controller
├── Models/                        # Data models
│   └── NavigationItem.cs          # Navigation item class
├── Services/                      # Business logic
│   └── NavigationService.cs       # Navigation & logging service
├── Views/                         # MVC Views
│   └── Home/
│       └── Index.cshtml           # Main HTML page
├── wwwroot/                       # Static files
│   ├── css/
│   │   └── style.css              # Styling
│   └── js/
│       └── app.js                 # Client-side JavaScript
└── README.md                      # Full documentation
```

## Running the Application

### Quick Start (One Command)
```bash
cd d:\Application_Navigator
dotnet run
```

Then open your browser to:
```
http://localhost:5000
```

### Step by Step
1. Open terminal/PowerShell
2. Navigate to: `cd d:\Application_Navigator`
3. Run: `dotnet run`
4. Browser will open at http://localhost:5000 (or manually navigate there)

## Customizing Button URLs

Edit `Services/NavigationService.cs` and modify the `GetNavigationItems()` method:

```csharp
new NavigationItem(1, "Test 1", "https://your-system-url.com", "Description"),
```

## Features Included

✅ 10 Navigation Buttons (Test 1-10)  
✅ Responsive Design (Mobile/Tablet/Desktop)  
✅ Modern UI with Gradient Background  
✅ Hover Effects & Animations  
✅ Server-side Logging  
✅ New Tab Navigation  
✅ ASP.NET Core MVC Architecture  

## Next Steps

1. **Run the app**: `dotnet run`
2. **Customize URLs**: Edit `Services/NavigationService.cs`
3. **Customize Design**: Edit `wwwroot/css/style.css`
4. **Add More Buttons**: Add items to `GetNavigationItems()` in NavigationService.cs

## Stopping the Application

Press `Ctrl+C` in the terminal to stop the web server.

## Troubleshooting

**Port already in use?**
- Edit `Program.cs` and change the port number in `app.Run("http://localhost:5000");`

**Changes not showing?**
- Stop the app (Ctrl+C)
- Run `dotnet run` again to rebuild and restart

