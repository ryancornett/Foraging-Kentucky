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
 6. Take note of the **Clear and/or Seed Database** region (lines 10-16) of Program.cs and comment out/in those methods for the behavior necessary.
 7. Use dummy input or these wild food items to interact with the app/database:
 ___
    - Name: "Persimmon" 
    - Type: "Fruit" 
    - Description: "Large as wild fruits go, persimmons are roughly spherical, normally a little wider than long and flattened or slightly depressed on the stem end where the tough, four-lobed calyx leftover from the flower remains attached.
    
    The skin is thin and smooth with a bloom; it is wrinkly, soft, and dull orange when ripe. SOFT is a keyword here--you don't want to eat an unripe persimmon. Before ripening, the persimmon is astringent and will pucker your mouth like no other native fruit if eaten unripe.

    Then why risk it? Because a ripe persimmon is one of the sweetest fruits on Earth. The scientific name, Diospyros virginiana, means \"Fruit of the Gods.\" It is a well-earned moniker." 
    - Is Edible Raw? "Yes" 
    - Image URL: "images/items/persimmon.webp"
___
    - Name: "Poke" 
    - Type: "Vegetable" 
    - Description: "Euell Gibbons thought poke \"is probably the best known and most widely used wild vegetable in America.\" It's a large, long-lived perennial shrub with a fleshy taproot. Older plants have several stems clustered at the root crown.
    
    Typically 5-7 feet tall at maturity with outer stems drooping under their own weight. Stems are smooth and hairless, green as shoots but purplish when mature.
    
    Only collect young leaves and PREPARE THEM PROPERLY. Poke contains toxic chemicals that are removed by boiling in water. Seek proper preparation procedures elsewhere. But note that poke has been safely prepared and consumed for generations, and is worth the trouble as a superb, hearty, and nutritious addition to your diet." 
    - Is Edible Raw? "No" 
    - Image URL: "images/items/poke.webp"
___
    - Name: "Hickory" 
    - Type: "Nut" 
    - Description: "Hickory nuts are inside a hull that separates fairly easily from the shell after falling from the tree in early autumn. There are several varieties, with the shagbark producing the most desirable nut.
    
    Though sweeter and tastier than its cousin the pecan, hickory nuts take longer to bear and their nut meat is harder to extract. They certainly worth the effort however, and substituted for pecans in your favorite pecan pie recipe, they will blow your mind.
    
    Another option is to grind or smash together the shells with the nut meat and \"brew\" hickory nut ambrosia, which is akin to a creamy, sweetened tea or coffee." 
    - Is Edible Raw? "Yes" 
    - Image URL: "images/items/hickory.webp"

### Next Steps
- Make app an API, which I think is better suited for the UX.
- Integrate real user authentication and authorization, which I did not configure the app for initially.
- Remove the option for users to add new wild foods.
- Include the option for users to upload images of wild foods.
- ... Which means image formatting and normalization needs to be included.
- Wild food items need more properties to be truly useful for users: scientific name, seasonal availability, geographic range, habitat, identification, image alt text, and how to prepare foods not edible raw.

### Acknowledgements 
In addition to prior knowledge of my own gleaned from years traipsing through the woods of Eastern Kentucky learning plants, information for wild edibles was obtained from the following sources I endorse wholeheartedly:
 - *Mushrooms of West Virginia and the Central Appalachians* by William C. Roody; The University Press of Kentucky, 2002. 
 - *The Forager's Harvest: A Guide to Identifying, Harvesting, and Preparing Edible Wild Plants* by Samuel Thayer; Forager's Harvest Press, 2006 
 - *Nature's Garden: A Guide to Identifying, Harvesting, and Preparing Edible Wild Plants* by Samuel Thayer; Forager's Harvest Press, 2010 
 - *Pawpaw: In Search of America’s Forgotten Fruit* by Andrew Moore; Chelsea Green Publishing, 2015 
 - *Incredible Wild Edibles* by Samuel Thayer; Forager's Harvest Press, 2017 
 - *Field Guide to Edible Wild Plants* by Samuel Thayer; Forager's Harvest Press, 2023 
