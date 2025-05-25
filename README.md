# Zip Code App Project
This is a simple project written in the cross-platform framework .NET MAUI (C# and XAML). The user provides a zip code and the application makes an API call (details below) to retrieve the city and state associated with the zip code. The application is a simple 2 screen program. The first screen having the user input a zip code with error handling and feedback. Specifically, the submit button is not enabled until the user inputs a 5 digit Zip Code. The second screen displays the result, which is the corresponding city and state from the provided zip code.

The API utilized is linked here: https://api.zippopotam.us/us/{zipcode}

The API documentation is linked here: https://docs.zippopotam.us/docs/getting-started/

Overall, this was a learning experience for me to try a new framework I haven't learned prior. I had some experience in Xamarin so there were some similarities between that and .NET MAUI. I also practiced separation of concerns between the UI and core functionality within this new framework utilizing  MVVM (Model-View-ViewModel).

The intent for this application is to be ran on a Windows Machine. Since this is a cross-platform framework, it is likely other platforms will function as well. I have experimented and ran it on an Android Emulator and it appears to function correctly.

# Screenshots
| Starting Page  | Error Validation | Correct Zip Code | Second Page (Zip Code Details) |
| ------------- | ------------- | ------------- | ------------- |
| ![image](https://github.com/user-attachments/assets/5c9d71cb-e781-4b18-80f5-ca9ab0bc0b3a)| ![image](https://github.com/user-attachments/assets/e756b77f-7117-4bc5-b4ce-168e277dcdb9)| ![image](https://github.com/user-attachments/assets/e3002e8a-c66b-4d87-9277-a95eaf55562d)| ![image](https://github.com/user-attachments/assets/e41f8062-bdeb-4ec3-89b8-5793dfa22ee7)

# Assumptions
Some assumptions I made while creating the project.
1. The user would only input a 5 digit Zip Code in the United States. While not explicit from the API documentation, it does not seem to support a ZIP+4 code and only supports a 5 digit Zip Code, which this application enforces.

# Steps to Build and Run .NET MAUI Project
## Necessary Downloads
1. Install Visual Studio 2022 17.12 or greater
2. Install .NET Multi-platform App UI workload in the Visual Studio Installer
![image](https://github.com/user-attachments/assets/03613f37-7c61-4c45-8695-adf0425b317b)

## Steps to Run the .NET Maui Project
1. Download or clone the source code.
2. Open the ZipCodeAppProject.sln file in Visual Studio.
3. Ensure the Target Platform is set to "Windows Machine".

   ![image](https://github.com/user-attachments/assets/0ca144bd-e4da-4aaf-afd9-984ad8718415)

4. Click the start button to build and run the app.

# Packages installed for Development
1. Newtonsoft.Json - Used for serializing and deserializing the JSON response from the API.
2. CommunityToolkit.Mvvm - Provides tools to implement the MVVM (Model-View-ViewModel) architecture.

# Basic Design Document
Linked here is a basic design document explaining the code architecture: (INSERT LINK HERE)

# Images used in the Application
The images used in the application are hosted on Pixabay a website hosting free images.

1. USA Image (Start Page): https://pixabay.com/vectors/america-states-map-usa-geography-147939/
2. Check Mark Image (Zip Code Detail Page): https://pixabay.com/vectors/ok-check-to-do-agenda-icon-symbol-1976099/
