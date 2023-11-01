# Foraging-Kentucky
## Capstone Project for Code:You Software Development Pathway

## Built by Ryan Cornett

### Project Description
This is a Blazor Server App that allows users to add wild edible food items (nuts, fruit, mushrooms, vegetables) for foraging to a database, view existing items, and note discovery of items in season. In addition to the features below, I met the requirements for visual appeal, incorporated a database to persist data, and wrote more than the minimum of three methods.

### Features List
 - *Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program* (optional feature #1). ItemOptions.cs <<LINE NUMBER>> contains a list used throughout the app. 
 - *Comments in the code explaining how I employ the SOLID principles Single Responsibility Principle (SRP) and the Open/Closed Principle (OCP)* (optional feature #2). <<FILE.CS AND LINE NUMBERS>> 
 - *Implement a regular expression (regex) to ensure a field either a phone number or an email address is always stored and displayed in the same format* (optional feature #3). <<FILE.CS AND LINE NUMBERS>> 
 - *Have 2 or more tables (entities) in your application that are related and have a function return data from both entities. In entity framework, this is equivalent to a join* (optional feature #4). <<FILE.CS AND LINE NUMBERS>> 

### How to Run 
 - Restore NuGet packages
 - In Powershell, enter *dotnet ef migrations add InitialCreate*
 - Then enter *dotnet ef database update* 
 - On building, *foraging-kentucky.db* will be created on your desktop (if running on a Mac, check ForageContext.cs to ensure the path works)
 - You might have to change the build from *https* to *http* to run the app in your browser
 - Use some or all of these suggested Items, Users, or Recipes to interact with the app/database:
    - #### Items
    - 
    - #### Users
    - 
    - #### Recipes 
    - 

### Acknowledgements 
In addition to prior knowledge of my own gleaned from years traipsing through the woods of Eastern Kentucky learning plants, information for wild edibles was obtained from the following sources I endorse wholeheartedly:
 - *Mushrooms of West Virginia and the Central Appalachians* by William C. Roody; The University Press of Kentucky, 2002. 
 - *The Forager's Harvest: A Guide to Identifying, Harvesting, and Preparing Edible Wild Plants* by Samuel Thayer; Forager's Harvest Press, 2006 
 - *Nature's Garden: A Guide to Identifying, Harvesting, and Preparing Edible Wild Plants* by Samuel Thayer; Forager's Harvest Press, 2010 
 - *Pawpaw: In Search of America’s Forgotten Fruit* by Andrew Moore; Chelsea Green Publishing, 2015 
 - *Incredible Wild Edibles* by Samuel Thayer; Forager's Harvest Press, 2017 
 - *Field Guide to Edible Wild Plants* by Samuel Thayer; Forager's Harvest Press, 2023 
