# 📱 YouTube Android Automation with Appium and NUnit (C#)

This project demonstrates mobile test automation using **Appium**, **NUnit**, and **C#** on the **YouTube Android app**. It includes several automated tests simulating real user interactions such as searching videos, opening Shorts, accessing the account section, and handling ads.

## 🛠 Tech Stack

- C# (.NET)
- Appium
- Appium.WebDriver
- NUnit
- AndroidDriver (UiAutomator2)
- Android Emulator: Pixel 5 - API 34

## ✅ Frameworks & Tools

- **NUnit**: Used as the test framework to structure and run test cases.
- **Appium**: Mobile automation framework.
- **Android Emulator**: Virtual device to run the YouTube app.

## 📲 Automated Test Cases

### 1. 🔍 `SearchSabrina`
- Launches the YouTube app
- Searches for “Sabrina Carpenter juno”
- Opens the second result
- Skips ads if present using a helper method

### 2. 🎬 `AbrirShorts`
- Opens the Shorts tab from the homepage
- Waits while the short plays

### 3. 👤 `AbrirCuenta`
- Opens the account section
- Attempts to sign in

### 4. 🔎 `SearchInSettings` *(currently commented out)*
- Placeholder for a settings-related search

## 💡 Features

- Handles permission popups
- Interacts with UI using `XPath` and `resource-id`
- Includes a custom method to detect and skip ads
- Organized with NUnit `[SetUp]`, `[Test]`, and `[TearDown]` attributes

## 🚀 How to Run

1. Install:
   - Appium Server and start it at `http://127.0.0.1:4723/`
   - Android Emulator or connect a physical device with YouTube installed
2. Open the solution in Visual Studio
3. Run tests via **Test Explorer** (NUnit)

## 📌 Notes

- You can customize device name, app package, and activity in the `SetUp()` method.
- Tests use basic `Thread.Sleep` for timing.

