# Foraging-Kentucky
## Capstone Project for Code:You Software Development Pathway

## Built by Ryan Cornett

### Project Description
This is a Blazor Server App that allows users to add wild edible food items (nuts, fruit, mushrooms, vegetables) for foraging to a database, view existing items, and note discovery of items in season. In addition to the features below, I met the requirements for visual appeal, incorporated a database to persist data, and wrote more than the minimum of three methods.

### Features List
 1. *Create 3 or more unit tests* (optional feature #1). **Testing/UnitTests.cs**
 2. *Implement a regular expression (regex) to ensure either a phone number or an email address is always stored and displayed in the same format* (optional feature #2). **Common/Validators.cs** & **Data/Repository.cs** 
 3. *Create a dictionary or list, populate it with several values, retrieve at least one value, and use it* (optional feature #3). **Domain/ItemOptions.cs**
 4. *Implement a log that records errors, invalid inputs, or other important events and writes them to a text file* (optional feature #4). **Common/Logger.cs**
 5. *Add comments to your code explaining how you are using at least 2 of the solid principles* (optional feature #5). **(SRP) Data/ClearDb.cs lines 5 & 6** and **(OCP) Domain/Item.cs lines 3 & 4** 
 6. *Make your application asynchronous* (optional feature #6). **Asynchronous database methods in @code sections of Pages/Dashboard.razor, /WildFoods.razor, & /Recipes.razor**

### How to Run 
 1. Restore NuGet packages
 2. In Powershell, navigate to the Solution folder and enter *dotnet ef migrations add "InitialCreate"*
 3. Then enter *dotnet ef database update* 
 4. On building, *foraging-kentucky.db* will be created on your desktop (if running on a Mac, check ForageContext.cs to ensure the path works)
 5. You might have to change the build from *https* to *http* to run the app in your browser
 6. Use some or all of these suggested Items, Users, or Recipes to interact with the app/database:
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
