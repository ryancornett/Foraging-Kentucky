using Microsoft.AspNetCore.Components;

namespace Foraging_Kentucky.Common
{
    public static class Info
    {
        public static MarkupString ReadMe = new MarkupString($@"<div class='container flex-column w-75 my-4 align-content-center'>
    <div class='row p-2'>
       <h4>Project Description</h4>
<p>This is a Blazor Server App that allows users to add wild edible food items (nuts, fruit, mushrooms, vegetables, other) for foraging to a database, view existing items, and save items to the user. In addition to the features below, I met the requirements for visual appeal, incorporated a database to persist data, and wrote more than the minimum of three methods.</p>

<h4>Features List</h4>
<ol>
    <li><span class=""fst-italic"">Create 3 or more unit tests</span> (optional feature #1). <span class=""badge bg-secondary"">Testing/UnitTests.cs</span></li>
    <li><span class=""fst-italic"">Implement a regular expression (regex) to ensure either a phone number or an email address is always stored and displayed in the same format</span> (optional feature #2). <span class=""badge bg-secondary"">Common/Validators.cs</span></li>
    <li><span class=""fst-italic"">Create a dictionary or list, populate it with several values, retrieve at least one value, and use it</span> (optional feature #3). <span class=""badge bg-secondary"">Domain/ItemOptions.cs</span></li>
    <li><span class=""fst-italic"">Implement a log that records errors, invalid inputs, or other important events and writes them to a text file</span> (optional feature #4). <span class=""badge bg-secondary"">Common/Logger.cs</span></li>
    <li><span class=""fst-italic"">Add comments to your code explaining how you are using at least 2 of the solid principles</span> (optional feature #5). <span class=""badge bg-secondary"">(SRP) Data/ClearDb.cs lines 5 & 6</span> and <span class=""badge bg-secondary"">(OCP) Domain/Item.cs lines 3 & 4</span></li>
    <li><span class=""fst-italic"">Make your application asynchronous</span> (optional feature #6). Asynchronous database methods in @code sections of <span class=""badge bg-secondary"">Pages/Dashboard.razor</span>, <span class=""badge bg-secondary"">/WildFoods.razor</span>, & <span class=""badge bg-secondary"">/Recipes.razor</span></li>
</ol>

<h4>How to Run</h4>
<h5><em>You will need a Blazor-capable web server. Visual Studio stands up Kestrel automatically</em></h5>

<ol>
    <li>Restore NuGet packages.</li>
    <li>Enter <span class=""badge bg-secondary"">dotnet ef database update</span> in PowerShell.</li>
    <li>On building, <span class=""badge bg-secondary"">foraging-kentucky.db</span> will be created on your desktop (if running on a Mac, check ForageContext.cs to ensure the path works).</li>
    <li>You might have to change the build from <span class=""badge bg-secondary"">https</span> to <span class=""badge bg-secondary"">http</span> to run the app in your browser.</li>
    <li>Take note of the <span class=""badge bg-secondary"">Clear and/or Seed Database</span> region (lines 10-16) of Program.cs and comment out/in those methods for your desired program behavior.</li>
    <li>Use dummy input or these wild food items to interact with the app/database:</li>
</ol>
<small class=""text-muted""> Name: ""Persimmon"" </small>
<small class=""text-muted""> Type: ""Fruit"" </small>
<small class=""text-muted""> Description: ""Large as wild fruits go, persimmons are roughly spherical, normally a little wider than long and flattened or slightly depressed on the stem end where the tough, four-lobed calyx leftover from the flower remains attached.

The skin is thin and smooth with a bloom; it is wrinkly, soft, and dull orange when ripe. SOFT is a keyword here--you don't want to eat an unripe persimmon. Before ripening, the persimmon is astringent and will pucker your mouth like no other native fruit if eaten unripe.

Then why risk it? Because a ripe persimmon is one of the sweetest fruits on Earth. The scientific name, Diospyros virginiana, means ""Fruit of the Gods."" It is a well-earned moniker."" </small>
<small class=""text-muted""> Is Edible Raw? ""Yes"" </small>
<small class=""text-muted""> Image URL: ""images/items/persimmon.webp"" </small>
<br><br><br>
<small class=""text-muted""> Name: ""Poke"" </small>
<small class=""text-muted""> Type: ""Vegetable"" </small>
<small class=""text-muted""> Description: ""Euell Gibbons thought poke ""is probably the best known and most widely used wild vegetable in America."" It's a large, long-lived perennial shrub with a fleshy taproot. Older plants have several stems clustered at the root crown.

Typically 5-7 feet tall at maturity with outer stems drooping under their own weight. Stems are smooth and hairless, green as shoots but purplish when mature.

Only collect young leaves and PREPARE THEM PROPERLY. Poke contains toxic chemicals that are removed by boiling in water. Seek proper preparation procedures elsewhere, but note that poke has been safely prepared and consumed for generations and is worth the trouble as a superb, hearty, and nutritious addition to your diet."" </small>
<small class=""text-muted""> Is Edible Raw? ""No"" </small>
<small class=""text-muted""> Image URL: ""images/items/poke.webp""</small>
<br><br><br>
<small class=""text-muted""> Name: ""Hickory"" </small>
<small class=""text-muted""> Type: ""Nut"" </small>
<small class=""text-muted""> Description: ""Hickory nuts are inside a hull that separates fairly easily from the shell after falling from the tree in early autumn. There are several varieties, with the shagbark producing the most desirable nut.

Though sweeter and tastier than its cousin the pecan, hickory nuts take longer to bear and their nut meat is harder to extract. They are certainly worth the effort however, and substituted for pecans in your favorite pecan pie recipe, they will blow your mind!

Another option is to grind or smash together the shells with the nut meat and ""brew"" hickory nut ambrosia, which is akin to a creamy, sweetened tea or coffee."" </small>
<small class=""text-muted""> Is Edible Raw? ""Yes"" </small>
<small class=""text-muted""> Image URL: ""images/items/hickory.webp""</small>
<br><br><br>
<h4>Next Steps</h4>
<ul>
    <li>Make app an API, which I think is better suited for the UX.</li>
    <li>Integrate real user authentication and authorization, which I did not configure the app for initially.</li>
    <li>Remove the option for users to add new wild foods.</li>
    <li>Include the option for users to upload images of wild foods.</li>
    <li>... Which means image formatting and normalization needs to be included.</li>
    <li>Wild food items need more properties to be truly useful for users: scientific name, seasonal availability, geographic range, habitat, identification, image alt text, and how to prepare foods not edible raw. </li>
    <li>Figure out how to transition the <span class=""fst-italic"">Save This</span> buttons on item cards to <span class=""fst-italic"">Remove This</span> when clicked and adjust that functionality. This should be easier and more user-friendly by making wild food-specific pages in an API.</li>
</ul>
    </div>
</div>");

        public static MarkupString Basics = new MarkupString($@"<div class='container flex-column w-75 my-4 align-content-center'>
    <div class='row p-2'>
        <h3>Foraging Basics</h3>

        <h5>First Off--Why Foraging?</h5>

        <p>
            Foraging offers a plethora of health benefits, connecting individuals with fresh, nutrient-rich foods straight from nature. Wild plants often boast higher nutritional content than their cultivated counterparts, providing a diverse array of vitamins, minerals, and antioxidants. Incorporating foraged foods into your diet introduces a variety of flavors and textures, contributing to a more well-rounded and enjoyable culinary experience. Additionally, the act of foraging itself promotes physical activity and outdoor exploration, fostering a healthier and more active lifestyle.
        </p>

        <p>
            Beyond personal health, foraging extends its benefits to the community, the pocketbook, and the environment. Foragers often build connections with family members who accompany them and within local foraging communities by sharing knowledge, experiences, and their harvests. This sense of community fosters a deeper appreciation for nature and its resources. Foraging also presents an opportunity for individuals and families to save money on grocery bills, as wild foods are freely available in many natural spaces. Additionally, by sourcing food locally and sustainably, foragers contribute to reducing the environmental impact associated with conventional agriculture, such as transportation, packaging, and resource-intensive farming practices. Embracing foraging as a hobby or lifestyle choice encompasses not only personal wellness but also a commitment to community, frugality, and environmental stewardship.
        </p>

        <h5>I'm In! Now What?</h5>

        <p><b>Choosing the Right Equipment:</b></p>

        <p>Foraging in Kentucky requires minimal equipment, but having the right tools can enhance your experience and ensure safety. Start with a sturdy basket or bag to collect your findings. A field guide specific to Kentucky's flora is invaluable for plant identification. Consider bringing along a small knife or scissors for harvesting and a pair of gloves to protect your hands.</p>

        <p><b>Identifying Suitable Foraging Locations:</b></p>

        <p>Kentucky offers diverse ecosystems, each with its unique foraging opportunities. Research and identify suitable locations based on the types of wild foods you're interested in. State parks, nature reserves, and public lands can be excellent starting points, but always respect local regulations and obtain any necessary permits.</p>

        <p><b>Prioritizing Safety:</b></p>

        <p>Safety is paramount in foraging. Familiarize yourself with poisonous plants in the region and learn to differentiate them from edible ones. It's advisable to forage with a companion, especially if you're a beginner. Let someone know your location and expected return time. Dress appropriately, wear sturdy footwear, and be cautious of your surroundings to avoid hazards like uneven terrain or wildlife.</p>

        <p><b>Understanding Seasonal Opportunities:</b></p>

        <p>Kentucky's diverse climate brings forth a variety of wild edibles throughout the year. Research the seasons for specific plants, berries, mushrooms, and nuts. Spring may offer a bounty of tender greens, while summer brings berries and fruits. Fall is often prime time for nuts and mushrooms. Understanding the seasonal cycles will enhance your foraging success.</p>

        <p><b>Ethical Foraging Practices:</b></p>

        <p>Responsible foraging is key to maintaining the delicate balance of natural ecosystems. Harvest only what you need, leaving enough for wildlife and future foragers. Avoid disturbing fragile habitats, and be mindful of local regulations regarding foraging. Respect private property and seek permission when necessary.</p>

        <p><b>Connecting with Local Foraging Communities:</b></p>

        <p>Foraging is a communal activity, and connecting with local foraging communities can provide valuable insights, tips, and shared experiences. Attend local workshops, join online forums, or participate in guided foraging walks to expand your knowledge and meet like-minded enthusiasts.</p>

        <p>Embarking on a foraging journey in Kentucky can be a rewarding and educational experience. By equipping yourself with knowledge, respecting nature, and adopting ethical practices, you'll not only enjoy the flavors of the wild but also contribute to the preservation of these valuable resources.</p>
    </div>
</div>");

        public static MarkupString Accessibility = new MarkupString($@"<div class='container flex-column w-75 my-4 align-content-center'>
    <div class='row p-2'>
        <h3>Accessibility</h3>

<p>At Foraging Kentucky, we are dedicated to ensuring that our website is accessible to all users, regardless of their abilities or disabilities. We strive to provide a seamless and inclusive online experience for everyone. This Accessibility Page outlines our commitment to accessibility and the measures we take to make our site accessible.</p>

<p><b>1. Accessibility Features</b></p>

<ul>
    <li><b>Alternative Text for Images:</b> We provide alternative text (alt text) for all images on our website. This text is descriptive and allows users with visual impairments to understand the content of the images.</li>

    <li><b>Keyboard Navigation:</b> Our website is designed to be fully navigable and usable using only a keyboard. You can access all interactive elements and content without the need for a mouse.</li>

    <li><b>Contrast and Color:</b> We maintain a color scheme and contrast that ensures readability and usability for users with low vision or color blindness.</li>

    <li><b>Responsive Design:</b> Foraging Kentucky is built with a responsive design, making it accessible and functional on various devices, including smartphones, tablets, and desktop computers.</li>

    <li><b>Readable Fonts:</b> We use web fonts that are easy to read, and users can adjust the text size through their browser settings.</li>
</ul>

<p><b>2. Web Accessibility Guidelines</b></p>

<p>Foraging Kentucky aims to meet the Web Content Accessibility Guidelines (WCAG) 2.1, Level AA standards to ensure our website's accessibility. We regularly review our site and content to identify and rectify any accessibility issues.</p>

<p><b>3. Assistance and Feedback</b></p>

<p>We are committed to improving the accessibility of our website. If you encounter any accessibility problems or have suggestions for improvement, please contact us at [contact email]. Your feedback is valuable and helps us make our site better for all users.</p>

<p><b>4. Accessibility for Users with Disabilities</b></p>

<p>We are dedicated to providing equal access to our website for all users. If you have specific accessibility requirements or encounter any difficulties, please let us know, and we will do our best to accommodate your needs.</p>

<p><b>5. Third-Party Content and Services</b></p>

<p>While we strive to maintain high accessibility standards on our site, we may occasionally use third-party content or services. These external services may have their accessibility challenges. However, we make efforts to work with third-party providers that are also committed to accessibility.</p>

<p><b>6. Ongoing Accessibility Improvements</b></p>

<p>Foraging Kentucky is committed to continuously improving the accessibility of our website. We regularly review and update our content, design, and features to ensure we meet or exceed accessibility standards.</p>

<p><b>7. Contact Us</b></p>

<p>If you have any questions, suggestions, or need assistance related to accessibility on Foraging Kentucky, please contact us <a href=""contact"">here</a>. Your input is essential in our ongoing efforts to create a welcoming and accessible online environment for all visitors.</p>

<p>We thank you for choosing Foraging Kentucky and are dedicated to providing a positive and accessible experience for all users.</p>
</div>");

        public static MarkupString Acknowledgements = new MarkupString($@"<div class='container flex-column w-75 my-4 align-content-center'>
    <div class='row p-2'>
        <h3>Acknowledgements</h3>

<h6>In addition to prior knowledge of my own gleaned from years traipsing through the woods of Eastern Kentucky learning plants, information for wild edibles was obtained from the following sources Foraging Kentucky endorses wholeheartedly:</h6>

<ul>
    <li><b>Mushrooms of West Virginia and the Central Appalachians</b> by William C. Roody; The University Press of Kentucky, 2002.</li>
    <li><b>The Forager's Harvest: A Guide to Identifying, Harvesting, and Preparing Edible Wild Plants</b> by Samuel Thayer; Forager's Harvest Press, 2006</li>
    <li><b>Nature's Garden: A Guide to Identifying, Harvesting, and Preparing Edible Wild Plants</b> by Samuel Thayer; Forager's Harvest Press, 2010</li>
    <li><b>Pawpaw: In Search of America’s Forgotten Fruit</b> by Andrew Moore; Chelsea Green Publishing, 2015</li>
    <li><b>Incredible Wild Edibles</b> by Samuel Thayer; Forager's Harvest Press, 2017</li>
    <li><b>Field Guide to Edible Wild Plants</b> by Samuel Thayer; Forager's Harvest Press, 2023</li>
</ul>
</div>");

        public static MarkupString Contact = new MarkupString($@"<div class='container flex-column w-75 my-4 align-content-center'>
    <div class='row p-2'>
        <h3>Contact</h3>

<h5>Please send all comments, questions, tips, issues, idea, etc. to ryandcornett (at) gmail (dot) com.</h5>
<h6>We look forward to hearing from you!</h6>
</div>");

        public static MarkupString Disclaimer = new MarkupString($@"<div class='container flex-column w-75 my-4 align-content-center'>
    <div class='row p-2'>
        <h3>Disclaimer</h3>

<p>Foraging Kentucky is a website that provides information about wild foods available in the state of Kentucky and tips on responsible foraging. While we strive to offer accurate and helpful information, it is crucial to understand and acknowledge that foraging carries inherent risks and responsibilities. This disclaimer is intended to emphasize user safety and relieve and absolve the website creator and associated parties from any liability related to irresponsible use of the information provided on this website.</p>

<p><b>1. Assumption of Responsibility</b></p>

<p>By using the information on Foraging Kentucky, you acknowledge and assume full responsibility for your actions while foraging for wild foods. It is essential to understand that foraging involves inherent risks, such as misidentification of plants, allergic reactions, or environmental hazards.</p>

<p><b>2. Accuracy of Information</b></p>

<p>We make every effort to provide accurate and up-to-date information on the website. However, the content on Foraging Kentucky should be considered as general guidance. It is essential to verify any information and consult additional reputable sources to ensure the safety and accuracy of your foraging activities.</p>

<p><b>3. Plant Identification</b></p>

<p>Foraging for wild foods requires a high degree of plant identification skills. Misidentification can lead to health risks. Users are responsible for correctly identifying plants and should seek training or consult with experts in botany or foraging before consuming any wild plants.</p>

<p><b>4. Safety Precautions</b></p>

<p>Foraging Kentucky provides information on best practices for safe foraging. Users are responsible for taking all necessary safety precautions, including proper clothing, tools, and equipment, to minimize the risks associated with foraging activities.</p>

<p><b>5. Legal Compliance</b></p>

<p>Foraging may be subject to state and local laws and regulations. Users must ensure that they comply with all relevant laws and obtain any required permits or permissions before foraging in a particular area.</p>

<p><b>6. Allergic Reactions and Health Risks</b></p>

<p>Foraging Kentucky does not provide medical advice. Users should be aware of potential allergic reactions and health risks associated with consuming wild foods. If you have known allergies or health conditions, consult a healthcare professional before consuming wild plants.</p>

<p><b>7. Liability Waiver</b></p>

<p>By using Foraging Kentucky, you agree to waive and absolve the website creator, its operators, employees, and any affiliated parties from any liability, claims, demands, or damages that may arise from your use of the information provided on this website. This includes but is not limited to injuries, illnesses, property damage, or any other consequences related to foraging activities.</p>

<p><b>8. Ongoing Learning and Responsible Foraging</b></p>

<p>Foraging Kentucky encourages users to engage in ongoing learning and to forage responsibly. We are committed to promoting the safe and sustainable practice of foraging, and we are not responsible for the actions or decisions made by users.</p>

<p><b>9. Contact Us</b></p>

<p>If you have any questions or concerns about this disclaimer, please contact us <a href=""contact"">here</a>. Your safety and responsible foraging are our top priorities.</p>

<p>Foraging Kentucky exists to provide information and foster a deeper appreciation for the natural world. We hope that you find our content helpful and that you enjoy the foraging experience while taking responsibility for your actions and safety.</p>
</div>");

        public static MarkupString Privacy = new MarkupString($@"<div class='container flex-column w-75 my-4 align-content-center'>
    <div class='row p-2'>
        <h3>Privacy Policy</h3>

<p>Welcome to Foraging Kentucky (""we,"" ""our,"" or ""us""). At Foraging Kentucky, we are committed to protecting your privacy and ensuring the security of your personal information. This Privacy Policy outlines our practices concerning the collection, use, and disclosure of your information when you use our website (the ""Site"").</p>

<p>By accessing or using Foraging Kentucky, you agree to the terms and practices described in this Privacy Policy. If you do not agree with these terms, please do not use our Site.</p>

<p>
    <b>1. Information We Collect</b>
</p>

<p>We collect two types of information when you use Foraging Kentucky:</p>

<p><b>a. User-Provided Information:</b></p>

<ul>
    <li><b>Username:</b> When you create an account on Foraging Kentucky, you provide us with a username. This username is visible to other users of the site.</li>

    <li><b>Email Address:</b> We collect your email address during the registration process. Your email address is never sold or given out to third parties.</li>
</ul>

<p><b>b. Automatically Collected Information:</b></p>

<p>Log Data: Our servers automatically collect certain information when you access our Site. This information may include your IP address, browser type, the pages you visit, the time and date of your visit, and the time spent on those pages.</p>

        <p><b>2. How We Use Your Information</b></p>

<p>We use the information we collect for the following purposes:</p>

<ul>
    <li>To provide, maintain, and improve our services.</li>
    <li>To communicate with you, including responding to your requests and inquiries.</li>
    <li>To monitor and analyze Site usage and trends.</li>
    <li>To personalize your experience on Foraging Kentucky.</li>
    <li>To protect the security and integrity of our Site.</li>
    <li>To comply with legal obligations and resolve disputes.</li>
</ul>

                <p><b>3. Information Sharing</b></p>

<p>We do not sell, trade, or share your email address with third parties. However, other users on Foraging Kentucky may see your username, as it is displayed in public areas of the Site, such as forums and comments.</p>

                        <p><b>4. Security</b></p>

<p>We take the security of your information seriously and employ reasonable measures to protect it from unauthorized access, disclosure, alteration, and destruction. While we make efforts to protect your personal information, we cannot guarantee its absolute security.</p>

                                <p><b>5. Your Choices</b></p>

<p>You have certain rights regarding your personal information. You may access, update, correct, or delete your account information at any time. If you wish to delete your account, please contact us <a href=""contact"" target=""_blank"">here</a>.</p>

                                        <p><b>6. Changes to this Privacy Policy</b></p>

<p>We may update this Privacy Policy from time to time to reflect changes to our practices or for other operational, legal, or regulatory reasons. If we make changes, we will post the revised policy on this page and update the ""Last Updated"" date.</p>

<p><b>7. Contact Us</b></p>

<p>If you have any questions or concerns about this Privacy Policy or our data practices, please contact us <a href=""contact"" target=""_blank"">here</a>.</p>

<p>Thank you for using Foraging Kentucky. We appreciate your trust in us and are committed to protecting your privacy and personal information.</p>
</div>");
    }
}
