NASA API Integration Web App
Overview
This web application, built with ASP.NET Core 8.0 MVC, integrates with NASA's API to deliver a dynamic and engaging web experience for enthusiasts, educators, and students interested in exploring space-related data. The app provides a unified interface for accessing various features offered by NASA's API while ensuring compliance with data usage regulations.
Features
•	NASA API Integration: Fetch and display dynamic space-related data from NASA's API.
•	User Authentication: Secure login system using authentication cookies for validating user emails.
•	Search Functionality: Users can search for specific topics or data using a search bar.
•	Search History: Saves user search keywords for reference and convenience.
•	Data Download: Allows users to download the NASA API data obtained from the  search option in JSON format for personal use only. No other pages allows the download facility. For this facility we even do not need any API key.
•	User-Friendly Interface: Designed to cater to a broad audience, ensuring accessibility and ease of use.
Technology Stack
•	Framework: ASP.NET Core 8.0 MVC
•	Authentication: Cookie-based authentication for user validation
•	Entity Framework: Used for storing User details managing user search keyword storage.
•	NASA API: Provides space-related data for the application
Data Source
The application utilizes the following data sources from NASA's API:
•	APOD (Astronomy Picture of the Day): Provides daily images or videos with descriptions.
•	Mars Photos: Offers images captured by rovers on Mars.
•	NEO (Near-Earth Object): Supplies information about asteroids and comets near Earth.
•	CME (Coronal Mass Ejections): Shares data about solar eruptions.
•	Solar Flares: Provides information about solar flare events.

•	Data Processing
•	Transformations: Data fetched from NASA's API undergoes minor transformations, such as formatting timestamps or converting units, for display purposes.
•	Cleaning Steps: Data is validated to ensure completeness and correctness before being displayed to users. For example, null or incomplete records are filtered out.
Database Structure
The database schema includes the following components:
•	Users Table: Stores user information (e.g., email for authentication).
•	Search History Table: Contains user search keywords, timestamps, and related metadata.
•	Relationships: The users table is linked to the SearchHistory table through a foreign key to associate searches with specific users.
Intended Use
•	Visualization: The data fetched from NASA's API is primarily used for dynamic and interactive visualizations.
•	Educational Purposes: Enables users to explore and learn about space-related topics in an intuitive way.
Key Design Choices
•	Compliance with NASA API Policies: The application does not store any data fetched from the NASA API. Users can only download data for their reference that too only for his own search action.
•	Solid Design Principles: Adopts a robust design pattern to ensure code maintainability and scalability.
•	Dependency Injection (DI) principle, which is a core aspect of Inversion of Control (IoC)—a key object-oriented programming (OOP) design principle. Used it exclusively for adding and injecting my DataContext class and other core ASP.net services like session, authentication, HttpClientFactory and more.
•	Development Workflow: Initial work and testing were performed using a console application, ensuring functionality and accuracy before implementing features in the web app.
Installation and Setup
1. Clone the Repository
Clone the project repository and navigate to the project folder:
git clone https://github.com/Binshila/NASA.git
cd NASAWebApp
2. Restore Dependencies
Run the following command to restore required dependencies:
dotnet restore
3. Run the Application
Start the application using the following command:
dotnet run
4. Access the Application
Open your browser and navigate to https://localhost:5001 (or the URL specified in your configuration).
Usage
1. Login
•	Sign up with a valid email and create a password.
2. Login
•	Enter a valid email to log in.
3. Search
•	Use the search bar to explore specific topics or data from NASA's API.
4. Download Data
•	Fetch data from NASA API and download it for personal reference.
5. View Search History
•	Access previously searched keywords for quick reference.
Development Notes
•	Console Application: Used during development for testing and debugging purposes. This is not part of the production app.
•	Entity Framework: Only used to store user search keywords. No data from NASA API is saved.
Legal Compliance
This application adheres to NASA API's terms and conditions by:
•	Not storing or redistributing NASA API data.
•	Allowing users to download fetched data solely for personal use and that too only in the search feature.
Future Improvements
•	Add more advanced search filters and sorting options.
•	Enhance the UI for better user engagement.
•	Implement additional NASA API features, such as All Satellites or NASA Image and Video Library Search.
