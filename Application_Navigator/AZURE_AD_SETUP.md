# Azure AD SSO Setup Guide

This document provides step-by-step instructions to complete the Azure AD SSO integration for the Application Navigator system.

## Current Status
✅ Code has been configured for Azure AD SSO authentication
❌ Azure AD credentials need to be added to `appsettings.json`

## What Was Implemented

### 1. **Authentication Flow**
- Login page (matching your provided design) at `localhost:5000/Account/Login`
- Azure AD sign-in via "Login with Microsoft" button
- Automatic redirect to navigation dashboard (10 buttons) after successful login
- Logout functionality in the top-right corner
- User profile display showing name and email

### 2. **Protected Pages**
- All pages now require authentication (except Account/Login and Account/AccessDenied)
- Unauthenticated users are automatically redirected to the login page
- User's name and email are displayed in the navbar

### 3. **Files Modified/Created**
- **Program.cs** - Added Azure AD authentication middleware
- **appsettings.json** - Added Azure AD configuration section
- **Controllers/AccountController.cs** - NEW: Handles login/logout flows
- **Controllers/HomeController.cs** - Updated with [Authorize] attribute
- **Views/Account/Login.cshtml** - NEW: Beautiful login page
- **Views/Account/AccessDenied.cshtml** - NEW: Access denied page
- **Views/Home/Index.cshtml** - Updated with logout button and user info

## Required Setup Steps

### Step 1: Get Azure AD Credentials

1. Go to [Azure Portal](https://portal.azure.com)
2. Navigate to **Azure Active Directory** → **App registrations**
3. Click **+ New registration**
4. Fill in the form:
   - **Name**: Application Navigator
   - **Supported account types**: Accounts in this organizational directory only
   - Click **Register**

### Step 2: Configure Your Registered App

1. In your app's overview page, copy and save:
   - **Application (client) ID** - This is your `ClientId`
   - **Directory (tenant) ID** - Already have this: `534253fc-dfb6-462f-b5ca-cbe81939f5ee`

2. Go to **Certificates & secrets** → **+ New client secret**
   - Click **+ New client secret**
   - Add description: "Application Navigator"
   - Set expiration (e.g., 24 months)
   - Click **Add**
   - **Copy the Value** immediately - This is your `ClientSecret`
   - ⚠️ **Important**: You won't be able to see this value again!

3. Go to **Authentication** and add Redirect URI:
   - Click **+ Add a platform**
   - Select **Web**
   - Add Redirect URI: `http://localhost:5000/signin-oidc`
   - Click **Configure**

### Step 3: Update appsettings.json

Open `appsettings.json` and update the Azure AD section with your credentials:

```json
"AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "TenantId": "534253fc-dfb6-462f-b5ca-cbe81939f5ee",
    "ClientId": "YOUR_CLIENT_ID_HERE",          // ← Replace with your Client ID
    "ClientSecret": "YOUR_CLIENT_SECRET_HERE",  // ← Replace with your Client Secret
    "Authority": "https://login.microsoftonline.com/534253fc-dfb6-462f-b5ca-cbe81939f5ee",
    "ValidateAuthority": true,
    "CallbackPath": "/signin-oidc",
    "SignedOutCallbackPath": "/signout-callback-oidc"
}
```

### Step 4: Test the Application

1. Open terminal in VS Code
2. Navigate to the project folder:
   ```bash
   cd d:\Application_Navigator
   ```

3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open browser and navigate to: `http://localhost:5000`

6. You should see the **Login Page** with:
   - "Alarm Management System" title
   - "Secure Azure AD SSO" badge
   - "Login with Microsoft" button

7. Click "Login with Microsoft" and sign in with your corporate Microsoft account

8. After successful login, you'll be redirected to the **10 Buttons Page** showing:
   - NOC Portal
   - CDR Portal
   - RTU Monitoring
   - Issue Register
   - Network Logs
   - LTE Fault Handling
   - Digital Service
   - Power Outages
   - Test 9
   - Test 10

## Troubleshooting

### "Invalid Redirect URI"
- Make sure the redirect URI in Azure AD matches exactly: `http://localhost:5000/signin-oidc`
- For production, use `https://yourdomain.com/signin-oidc`

### "Client ID not found"
- Ensure you've updated `appsettings.json` with your actual Client ID
- The placeholder text shows what needs to be replaced

### Application won't load
- Run `dotnet restore` to ensure all NuGet packages are installed
- Check that .NET 8 is installed: `dotnet --version`

### Login page keeps redirecting
- Verify your Client Secret is correctly copied (no spaces before/after)
- Check that Authority URL includes your Tenant ID

## Production Deployment

For production, update:

1. **appsettings.json**:
   - Change redirect URI to your domain: `https://yourdomain.com/signin-oidc`
   - Update Azure AD app registration with production redirect URI

2. **Program.cs**:
   - Change from `http://localhost:5000` to `https://yourdomain.com`
   - Remove the hard-coded port

3. **SSL/HTTPS**:
   - Obtain SSL certificate for your domain
   - Configure IIS or your hosting platform for HTTPS

## Architecture Overview

```
User Access
    ↓
Requests http://localhost:5000
    ↓
Authentication Middleware checks if authenticated
    ↓
Not Authenticated? Redirect to /Account/Login
    ↓
User sees Login Page
    ↓
Clicks "Login with Microsoft"
    ↓
Redirected to Azure AD Login
    ↓
User signs in with corporate credentials
    ↓
Azure AD redirects back to /signin-oidc with token
    ↓
Application validates token and creates session
    ↓
Redirect to /Home/Index (10 buttons page)
    ↓
User can now click buttons to navigate to systems
```

## Support
For issues with Azure AD configuration, contact: gamunas@slt.com.lk

## Additional Resources
- [Microsoft Identity Platform Documentation](https://docs.microsoft.com/en-us/azure/active-directory/develop/)
- [ASP.NET Core Security Documentation](https://docs.microsoft.com/en-us/aspnet/core/security/)
