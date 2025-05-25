# Zip Code App Project
This is a simple project written in the cross-platform framework .NET MAUI (C# and XAML). The user provides a zip code and the application makes an API call (details below) to retrieve the city and state associated with the zip code. The application is a simple 2 screen program. The first screen having the user input a zip code with error handling and feedback. Specifically, the submit button is not enabled until the user inputs a 5 digit Zip Code. The second screen displays the result, which is the corresponding city and state from the provided zip code.

The API utilized is linked here: https://api.zippopotam.us/us/{zipcode}

The API documentation is linked here: https://docs.zippopotam.us/docs/getting-started/

Overall, this was a learning experience for me to try a new framework I haven't learned prior. I had some experience in Xamarin so there were some similarities between that and .NET MAUI. I also practiced separation of concerns between the UI and core functionality within this new framework utilizing  MVVM (Model-View-ViewModel).

The intent for this application is to be ran on a **Windows Machine**. Since this is a cross-platform framework, it is likely other platforms will function as well. I have experimented and ran it on an Android Emulator and it appears to function correctly.

# Screenshots
| Starting Page  | Error Validation (Starting Page) |
| ------------- | ------------- |
| ![image](https://github.com/user-attachments/assets/5c9d71cb-e781-4b18-80f5-ca9ab0bc0b3a)| ![image](https://github.com/user-attachments/assets/e756b77f-7117-4bc5-b4ce-168e277dcdb9)|

| Correct Zip Code (Starting Page)  | Second Page (Zip Code Details) |
| ------------- | ------------- |
 ![image](https://github.com/user-attachments/assets/e3002e8a-c66b-4d87-9277-a95eaf55562d)| ![image](https://github.com/user-attachments/assets/e41f8062-bdeb-4ec3-89b8-5793dfa22ee7)

# Assumptions
Some assumptions I made while creating the project.
1. I assumed the scope would be only for the United States despite this API supporting other countries as well.
1. The user would only input a 5 digit Zip Code in the United States. While not explicit from the API documentation, it does not seem to support a ZIP+4 code and only supports a 5 digit Zip Code, which this application validates.
2. If the API doesn't return any details about a 5 digit Zip Code, I made the assumption that the Zip Code is invalid and prompt the user to enter a different Zip Code.
3. I saw that a Zip Code can have multiple places since it returns an array.
```   
{
  "country": "United States",
  "country abbreviation": "US",
  "post code": "85001",
  "places": [
    {
      "place name": "Phoenix",
      "longitude": "-112.3518",
      "latitude": "33.704",
      "state": "Arizona",
      "state abbreviation": "AZ"
    }
  ]
}
```
However, I could not replicate a Zip Code that had multiple places in the United States. This API also supports other countries, which is where I saw multiple values in the array "places". To cover for this, I display all of the places returned in that array, but through my testing, the API only returns one place when constrained to search Zip Codes in the United States.

# Steps to Build and Run .NET MAUI Project
## Necessary Downloads
1. Install [Visual Studio 2022 17.12 or later](https://visualstudio.microsoft.com/vs/)
2. Install .NET Multi-platform App UI workload in the Visual Studio Installer
![image](https://github.com/user-attachments/assets/03613f37-7c61-4c45-8695-adf0425b317b)

## Steps to Run the .NET Maui Project on Windows
1. Download or clone the source code.
2. Open the ZipCodeAppProject.sln file in Visual Studio.
3. Ensure the Target Platform is set to "Windows Machine".

   ![image](https://github.com/user-attachments/assets/0ca144bd-e4da-4aaf-afd9-984ad8718415)

4. Click the start button to build and run the application

# Packages installed for Development
1. Newtonsoft.Json - Used for serializing and deserializing the JSON response from the API.
2. CommunityToolkit.Mvvm - Provides tools to implement the MVVM (Model-View-ViewModel) architecture.

# Basic Design Document
Linked here is a basic design document explaining the code architecture: (INSERT LINK HERE)

# Images used in the Application
The images used in the application are hosted on Pixabay a website hosting free images.

1. USA Image (Start Page): https://pixabay.com/vectors/america-states-map-usa-geography-147939/
2. Check Mark Image (Zip Code Detail Page): https://pixabay.com/vectors/ok-check-to-do-agenda-icon-symbol-1976099/
