using Foraging_Kentucky.Common;
using Foraging_Kentucky.Domain;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace Foraging_Kentucky.Data;
public static class SeedDb
{
    public static void SeedAndVerify()
    {
        var seedCheck = SeedDatabase();
        using var context = new ForageContext();
        if (!context.Items.Any(id => id.Id == 1))
        {
            Logger.Log(seedCheck, $"{Logger.error} No items were added to the database.");
        }
        else { Logger.Log(seedCheck, $"{Logger.success} The database was seeded."); }
    }
    public static List<User> CreateUsers()
    {
        var list = new List<User>
        {
            new User("Dave", "dave@wendys.com"),
            new User("DreadPirateRoberts", "pirateguy08@asyouwish.net"),
            new User("Aragorn_Stryder", "king@gondor.com"),
            new User("Eowyn", "rohanrules@horselords.gov"),
            new User("Olivia_Dunham", "olive@fringe.fbi.gov")
        };
        return list;
    }

    #region Items are created here; users are tracked and seeded via _context.Items.Add
    public static List<Item> CreateItems()
    {
        var userList = CreateUsers();
        var itemList = new List<Item>()
        {
            new Item("Black Walnut")
            {
                Type = ItemOptions.ItemTypes[2],
                Description = @"Black walnut is one of the easiest to collect and most prolific wild foods in North America. It is a more consistent producer than oaks, hickories, or beech, and the yield tends to be heavy.

Under good conditions, one can gather a few bushels per hour once they ripen in September or October. If you collect them too early, the husk will be extremely hard and totally green. Ripe walnut husks are yellow-green and turn black as they soften.

To process: remove the husks, clean the shells, dry them, and allow the nuts to cure for 1 week to 1 year.",
                IsEdibleRaw = true,
                ImagePath = "images/items/black-walnut.webp"
            },
            new Item("Autumn Olive")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"This is an invasive plant with small, slightly astringent drupes that are high in lycopene. Autumn olives--or autumnberries--come from a hefty shrub or small, tough, sprawling tree. It usually produces several gnarled and spreading trunks, the largest of which may reach 6 inches in diameter. Look for silver speckles on the stems, leaves, and fruit which is why sometimes this fruit goes erroneously by the name Silver Berry.

If you don’t know what autumn olives look like, smell for them in the spring. They give off a lovely and overwhelming, sometimes cloying aroma when in bloom. You will also see the dull yellow flowers in crowded clusters that hang from leaf axles.

Olive-shaped fruits, typically smaller than a pea, are produced and hang all summer long in gray clumps seemingly never to ripen. But when they finally do, the fruit is an appealing reddish, ripening to an even deeper crimson red on some bushes. Flavor varies on different bushes as well.",
                IsEdibleRaw = true,
                ImagePath = "images/items/autumn-olive.webp"
            },
            new Item("Common Milkweed")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"Milkweed is a perennial herb of old fields, roadsides, small clearings, stream sides, and fencerows. Its flowers have one of the most pleasant aromas of any in Kentucky, even though it is faint.

Several parts are edible: the emerging stalk in the spring, which is similar to asparagus in appearance and texture; the flowers in the summer that are akin to broccoli; and the immature seed pods in the early fall, which look like okra pods.

Do not mistake for dogbane, a mildly poisonous lookalike.",
                IsEdibleRaw = false,
                ImagePath = "images/items/milkweed.webp"
            },
            new Item("Pawpaw")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Pawpaws are our largest native fruit in North America. Look for them in rich soil near rivers and streams. The largest fruit will be from trees that have a good amount of sunlight.

For thousands of years the pawpaw provided a seasonal feast for the native people of this continent, and early European settlers gladly emulated them. It is said that the party of Lewis and Clark would have starved if they hadn't found stands of ripe pawpaws.

The fruit is highly aromatic when ripe and tastes like a banana - cantelope - pineapple - strawberry hybrid. There is truly nothing more tropical tasting in our woods. The skin is tough and should not be eaten; most fruits have seeds we would call 'clingstone': the seeds are surrounded by a gelatinous sack of membrane that holds onto the fruit. There is truly nothing better than a ripe pawpaw!",
                IsEdibleRaw = true,
                ImagePath = "images/items/pawpaw.webp"
            },
            new Item("Morel")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"One of the most highly sought fungi in the United States, and certainly in Kentucky.
Up to 6 inches tall; consisting of a conical to elongated, bluntly triangular, pitted head on a cylindrical, hollow stock.

Usually gregarious on the ground in woods and near trees in more open areas, such as woodland clearings and margins, especially near tulip, poplar, and ash, also on burn sites; saprobic and mycorrhizal. Common.",
                IsEdibleRaw = false,
                ImagePath = "images/items/morel.webp"
            },
            new Item("Chanterelle")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Convex at first, becoming nearly flat, with a central depression to somewhat funnel-shaped, Margin incurved when young.

The stalk is more or less equal or flaring near the apex, becoming hollow with age; colored like the cap or paler, base often white; surface smooth.

These occur in solitary or scattered groups, sometimes clustered on the ground in mixed words; Mycorrhizal; summer; occasional to fairly common locally.",
                IsEdibleRaw = false,
                ImagePath = "images/items/chanterelle.webp"
            },
            new Item("Chicken of the Woods")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Annual; semi circular to fan-shaped brackets with blunt, wavy margins, usually in compound overlapping clusters.

These occur sometimes in solitary fashion, but usually in compound clusters on living or dead tree trunks, logs, stumps, and larger, fallen branches of broad-leaved trees; parasitic and saprobic; spring-fall; common.

The entire fruit body is very good when young; as it matures and becomes fibrous, only the tender margin is edible.",
                IsEdibleRaw = false,
                ImagePath = "images/items/chicken-of-the-woods.webp"
            },
            new Item("Hen of the Woods")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"These wonderful mushrooms are up to 2 feet or more wide; compound clusters of overlapping, fan-shaped caps attached laterally to a branched stalk.

These occur in rosette-like clusters, often massive, at the base of oak trees, or around decaying oak stumps, also reported to occur with other broad–leaved trees; parasitic; late summer-fall; occasional to locally common.",
                IsEdibleRaw = false,
                ImagePath = "images/items/hen-of-the-woods.webp"
            },
            new Item("Oyster Mushroom")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Convex with an incurved margin at first, often becoming flattened with an upturned wavy margin in age, fan–shaped, oyster shell- or hash-shaped, or semi-circular in outline.

Gregarious, usually in overlapping clusters, sometimes solitary, on living or dead standing trunks, logs, and stumps of broad-leaved trees, less frequently on hemlock or pine; parasitic and saprobic; spring-early winter; common.

Edible and very good when young and fresh, discard the tough basal portion. Small, black beetles and other insects that often inhabit the gills can be evicted by tapping on the caps.",
                IsEdibleRaw = false,
                ImagePath = "images/items/oyster.webp"
            },

            new Item("Acorn")
            {
                Type = ItemOptions.ItemTypes[2],
                Description = @"An acorn consists of a rather large seed, encapsulated by a smooth shell with no surrounding fleshy tissue. The shells are thin, compared to those of most other nuts, and also differ in being pliable until they are dry.
All or acorns terminate in a nipple–like point, and all of them are born in tight-fitting, scaly, or bristley cups. These cups (also called caps) may cover only the base of the nut or they may enclose it entirely. No other North American nuts are borne in cups like these.

Acorns are widely believed to be poisonous or inedible, but with proper processing to remove tannins they make for a staple food that can be subsituted for flour in many recipes.",
                IsEdibleRaw = false,
                ImagePath = "images/items/acorn.webp"
            },

            new Item("Hazelnut")
            {
                Type = ItemOptions.ItemTypes[2],
                Description = @"Hazelnuts ripen in late summer and are borne in tight clusters of up to 15 nuts near the tips of the branches. About 0.5 inches in diameter, the nuts are hard-shelled, smooth, and an attractive light brown when ripe. Each nut is wrapped in an involucre, a pair of modified leaves that hides and protects it. All the nuts and involucres are packed tightly together with no stems connecting them, forming a big, leafy ball. Large ones may weigh several ounces.

Hazelnuts will be ripe in August or September, but most years they will not produce very much, be empty, or full of worms. American hazels will quickly fill a container with their fluffy, voluminous involucres; all things considered American hazels are easy to collect.",
                IsEdibleRaw = true,
                ImagePath = "images/items/hazelnut.webp"
            },

            new Item("Maypop")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"A perennial herbaceous fine with rough, slightly hairy, green stems rarely more than 8 mm thick. The vines may grow as much as 30 feet long, climbing over fenses, walls, bushes, small trees, or buildings.

The alternate leaves are deeply three-lobed (occasionally five-lobed), 3-5 inches long, and about equally wide.

Maypop is unique among American plants in that its fruit and flower (passiflora incarnata) generally go by separate names. The striking blossom, 2-3 inches wide, is the best-known part of this plant–and it is the state flower of Tennessee. It is quite possibly the coolest-looking flower in the world.

The fruit is a large berry, usually 1-2.5 inches long and elliptic, spherical, or egg-shaped at maturity. The maypop's skin is smooth and dark green at first, but slowly gets wrinkly and yellowish after ripening.

The inside is full of seeds in small sacs with pale, yellowish pulp that tastes like passion fruit (it is the same family, after all). When you break the surface of a Maypop, watch out because it MAY POP!",
                IsEdibleRaw = true,
                ImagePath = "images/items/maypop.webp"
            },

            new Item("Wild Plum")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Usually some combination of red, orange, yellow, and blue. They are coated with a bloom just like cultivated plums. Wild plums range from oblong to globe-shaped.

The fruit of larger kinds may reach nearly 2 inches in length, but the smaller species are typically less than 1 inch in diameter. Each plum contains a single, oblong, flattened stone like those found in cultivated plums. The skins are thick and tough. When ripe, wild plums are soft, tart, sweet, and juicy.

You might have trouble finding them before the animals get to them. Not only do animals eat them for the fleshy part of the fruit, but the nut-like structure inside as the pit is highly sought after by critters as well.",
                IsEdibleRaw = true,
                ImagePath = "images/items/wild-plum.webp"
            },

            new Item("Wood Sorrel")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"There are numerous species of wood sorrel found throughout North America. They all belong to the oxalis family.

The flowers have five petals, five sepals, and ten stamens. Some species are yellow, while others are pink or white. The yellow is by far the most abundant species in Kentucky.

Look for blooms in the spring to late summer. After the flowers wither, the plants bare elongated, green, banana-shaped seed pods, 0.3–0.6 inches long. They are delightfully crunchy and add a wonderful texture to a mouth full of wood sorrel greens.

Although these make for a wonderful trailside snack, be sure not to eat too much until you know if the oxalic acid will upset your stomach.",
                IsEdibleRaw = true,
                ImagePath = "images/items/wood-sorrel.webp"
            },

            new Item("Elderberry")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Medium to large shrubs or small trees. American elder has large, opposite, pinnately compound leaves, sometimes as much as 20 inches in length. The leaves typically consist of seven leaflets, which are sharply serrated, 2-5 inches long, elliptic with sharply pointed tips, and sesile on or growing on very short petioles. The leaves and stems of elderberry give off a strong, unpleasant odor when cut or bruised.

The small, white, five-petaled flowers, about 0.25 inches across, are produced in rounded, somewhat flattenned, topped clusters called umbrels at the ends of the branches. The fragrant blossoms open in late June and July.

The elderberry fruit is a tiny drupe, generally about 0.13 inches in diameter. Dark purple and juicy when ripe, they make up for their lack of size with copious production. American elderberries ripen in July, August, and September with the plump clusters often drooping under their own weight.",
                IsEdibleRaw = false,
                ImagePath = "images/items/elderberry.webp"
            },

            new Item("Dandelion")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"Dandelion greens are usually picked in early spring before the plants have flowered. The best leaves grow in rich, moist soil in locations where the plants do not get mowed. If there is a little shade or competition. The leaves usually stand erect rather than lie on the ground, which means they are more likely to be clean. Don’t pick leaves from dandelions that grow all alone on bare ground exposed to full sun, as these usually have a stronger flavor, tougher texture, and dirt clinging to them.

The best dandelion greens, collected an early spring, are milder in flavor, and more tender than the older leaves but they are still somewhat bitter. Many dandelion aficionados claim that the spring greens are not bitter. We at FK have no reason to believe this; dandelion greens are just bitter! They are, however, quite nutricious, so use dandelions sparingly--cooked!--to balance something rich like chowder.",
                IsEdibleRaw = true,
                ImagePath = "images/items/dandelion.webp"
            },
            new Item("Lobster Mushroom")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Lobster mushroom is an oddity. It is neither a crustacean nor a mushroom, but a fungus forming a parasitic crust-like surface on certain gilled mushrooms. By all accounts, no matter the edibility or safety of the mushroom the lobster fungus parasitizes, the infected mushroom body is safe to eat. However, there are reports of gastrointestinal–type poisonings associated with the lobster mushroom, so caution is advised.

The parasite infects various white species of Lactarius and Russula, which grow on the ground, sometimes partially buried, in woods; summer-fall; occasional two locally common in some years.

<small>Information for the attached image and its creator, Erlon, can be found <a href='https://commons.wikimedia.org/wiki/Category:Hypomyces_lactifluorum#/media/File:2014-08-03_Hypomyces_lactifluorum_(Schwein.)_Tul._&_C._Tul_440594.jpg'>here</a>. This image is used with the Creative Commons license <a href='https://creativecommons.org/licenses/by-sa/3.0/'>CC BY-SA 3.0</a></small>",
                IsEdibleRaw = false,
                ImagePath = "images/items/lobster-mushroom.webp"
            },
            new Item("Lion's Mane")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"A cushion–shaped to somewhat globose mass of hanging spines up to 10 inches or more wide; white at first, becoming yellowish to pale brownish in age, especially at the spine tips. The flesh is white, firm, elastic, sponge-like, odor and taste, not distinctive when young, sour and unpleasant when old.

This beautiful fungus is always a treat to encounter. Cultivated versions, sometimes called “Pom Poms,” are becoming increasingly available for growers and consumers. Edible and good when young, a favorite vegan alternative to crab meat.

These usually occur as solitary, growing from wounds on the trunks of broad–leaved trees, especially beech, maple, and oak, also on cut stumps and logs; parasitic and saprobic; summer–fall; occasional.

<small>Information for the attached image and its creator, Lebrac, can be found <a href='https://en.wikipedia.org/wiki/Hericium_erinaceus#/media/File:Igelstachelbart_Nov_06.jpg'>here</a>. This image is used with the Creative Commons license <a href='https://creativecommons.org/licenses/by-sa/3.0/'>CC BY-SA 3.0</a></small>",
                IsEdibleRaw = false,
                ImagePath = "images/items/lions-mane.webp"
            },
            new Item("Black Trumpet")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Also known as poor man's truffle, black trumpets are much appreciated by connoisseurs of wild mushrooms. They are often found in clusters on the ground in broad-leaved and mixed woods, especially with oak and beech; mycorrhizal; summer–fall; common.

Black trumpets are 1 1/2 to 3 1/2 inches tall, trumpet–shaped to deep, hollow funnel–shaped, with an incurved margin at first that becomes flared, wavy, and often recurved with age.

Black trumpets are easily preserved by drying.",
                IsEdibleRaw = false,
                ImagePath = "images/items/black-trumpet.webp"
            },
            new Item("Shaggy Mane")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Oval to bluntly cylindrical with an incurved margin at first, becoming somewhat bell-shaped as the margin expands at maturity. The gills are nearly free from the stalk, densely crowded, white at first, becoming pinkish-gray then black from the lower margin upward as the spores mature, finally dissolving into a black, inky fluid.

Gregarious on the ground in grassy places, lawns, pastures, or on hard-packed soil in waste areas and on roadsides; saprobic; spring–fall; common.

Edible when young before the gills begin to deliquesce.",
                IsEdibleRaw = false,
                ImagePath = "images/items/shaggy-mane.webp"
            },
            new Item("Puffball")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"2 1/2 to 7 inches broad; globose or pear-shaped, often with folds or wrinkles at the base.

The common puffball is often found after rainfall in late summer. They occur solitarily or in groups on the ground and open grassy areas such as lawns, meadows, pastures, cemeteries, and ballfields; saprobic; summer-fall, common.

These are edible when young and completely white inside. If you cut into a puffball and find anything other than white, discard the fruit body and do not consume.",
                IsEdibleRaw = false,
                ImagePath = "images/items/puffball.webp"
            },
            new Item("Blackberry")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Blackberries ripen in mid to late summer. They are identifiable compared to black raspberries due to the lack of the divot where the berry meets the vine's stem.

Many Kentucky families traditionally is pick blackberries and for cobbler on Independence Day. The ideal time to pick is the morning before the sun gets high in the sky and before the heat of the day. An empty milk jug with the top cut off and wearing your belt through the jug handle frees both hands to pick. One can pick several gallons of berries in a good year.",
                IsEdibleRaw = true,
                ImagePath = "images/items/blackberry.webp"
            },
            new Item("Black Raspberry")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Black raspberries might look like blackberries when ripe, but they are significantly smaller, ripen before blackberries, are coated in a heavy bloom, and have a noticeable divot or cavity from where the berry is pulled from the vine.

Black raspberries are not available in the same quantities as blackberries, so generally these are a great trail snack and nothing more. However, black raspberries are definitely worth picking because they are far superior in taste to raspberries bought at the grocery.",
                IsEdibleRaw = true,
                ImagePath = "images/items/raspberry.webp"
            },
            new Item("Maple")
            {
                Type = ItemOptions.ItemTypes[4],
                Description = @"If you like the idea of magical sugar water flowing from a hole in a tree by the gallons, then you will be a fan of maples! Although syrup can be made from the sap of most maples, you want to tap sugar maples if available. Differentiate them by leaf shape.

Due to the variance in temperatures in Kentucky in the winter, there is a broad range of times when it is advisable to tap sugar maples. Look for someone already working with maple sap in your area, volunteer to pitch in and help, and learn the tricks associated with making maple syrup.",
                IsEdibleRaw = true,
                ImagePath = "images/items/maple.webp"
            },
            new Item("Sassafras")
            {
                Type = ItemOptions.ItemTypes[4],
                Description = @"Sassafras is most commonly identified by its leaves. They may be oval, or they may have one lobe on either side (mitten-shaped), or a lobe on both sides that looks something like a trident (as pictured).

Sassafras leaves may be dried and ground up to make the powdery flavoring used in Cajun gumbo called filé. Also, and more widely well known, is the use of sassafras root for flavoring in tea and root beer.",
                IsEdibleRaw = false,
                ImagePath = "images/items/sassafras.webp"
            },
            new Item("Violet")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"Violets are comfort plants for the traveling forager: easy to identify, reliably edible, and perhaps most importantly, found everywhere: in your lawn, in hayfields, in brushy woodlots and city parks, etc.

Violets are easily identified by their five-petaled flowers and almost heart-shaped leaves. Occasionally a violet flower will be quite sweet, however the typical violet flower is simply a nice snack with little flavor, having a decent crunch where the flower head meets the stem. They can be picked in significant quantities and make a beautiful addition to salads.",
                IsEdibleRaw = true,
                ImagePath = "images/items/violet.webp"
            },
            new Item("Redbud")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"When blossomed out in the spring, eastern redbuds are unmistakable. Roadsides are typically lined with them, although we don't advise consuming plants growing so near vehicle exhaust and chemicals sprayed for highway maintenance.

To identify redbud in the summer and fall so you may return to them when flowering, look for zigzagging stems, heart-shaped leaves, and bean-like seedpods (redbud is a leguminous tree).

Though flower colors range from light pink to dark magenta/purple, that doesn't appear to be indicative of flower taste. Only one in 30-40 trees will have a noticeably sweet tasting flower. Use redbud flowers for garnish, additions to salads, or topping pancakes.",
                IsEdibleRaw = true,
                ImagePath = "images/items/redbud.webp"
            },
            new Item("Basswood, or Linden")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"The bBasswood has several edible parts. The young leaves, just as they unfurl from their buds, make for excellent wild salad greens. Basswood leaves our best when less than half of their full size, light green, and shiny-looking. The tips of young shoots remain good to eat a little past the shiny age–as long as the stem is tender and easy to pinch through or break. If you miss that cue, you’ll be able to tell when they are too old because you won’t like their texture. The older leaves won’t harm you, they’ll just help you commiserate with cudding livestock! 

Perhaps best known is the tea made from basswood flowers, steeped in hot water. You can take the unopened flower buds and cook them with wild rice, or use them in stirfry. They are rather firm, although not tough, and pleasant in flavor. The main drawback of these unopened buds is the annoying necessity of removing the numerous stems, which make it in practical to use them.",
                IsEdibleRaw = true,
                ImagePath = "images/items/linden.webp"
            },
            new Item("Ramp, or Wild Leek")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"This plant is called wild leek further north. It belongs to a large, diverse genus, Allium, which contains our domestic onion, leek, garlic, shallot, chive, and a large number of other wild onion species around the world. Despite its name, the wild leek is not some woodland counterpart of the domestic vegetable that goes by the same name; it is no more closely related to the cultivated leek than it is to the onion or chives.

Ramps tend to form large clumps about 4 to 10 inches wide with bulbs packed tightly together. In areas where many such clumps are side-by-side or run together, leeks may carpet large areas of the forest floor with a magical luxuriance. Each plant has two or three lanceolate, basal leaves, which are 8 to 12 inches long and 1 to 3 inches wide. These leaves are quite un-onionlike: they are flat and wide, resembling lily leaves.

Please forage responsibly, as overharvesting has resulted in declining populations; locally, entire populations have disappeared.",
                IsEdibleRaw = true,
                ImagePath = "images/items/ramp.webp"
            },
            new Item("Serviceberry")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Serviceberry is among the earliest of our showy trees. Blossoms appear in spring before the leaves have unfurled. Its fragrant, five–petaled, white blossoms add aromatic beauty to many thickets and forest edges.

Serviceberry goes by many names: Juneberry, Shadbush, Saskatoon, and more.

The berries look remarkably like blueberries, only of course they come from a tree, not a bush. Good, highly-desirable serviceberry trees bear some of the most incredible fruit available. The taste is something like a blueberry-apple-cherry blend. There is an almond like seed inside that is hard and crunchy, but edible.",
                IsEdibleRaw = true,
                ImagePath = "images/items/serviceberry.webp"
            },
            new Item("Sumac")
            {
                Type = ItemOptions.ItemTypes[4],
                Description = @"This is not to be confused with poison sumac which grows near streams as a perennial herb up to 12 feet tall. In contrast, this sumac (smooth, staghorn, other varieties) is an entirely different species and is a true tree.

Since sumac is related to cashews and mangoes, anyone allergic to those foods should avoid it or proceed with caution. The various species of red-berried sumacs have been widely used to brew a tart, refreshing drink. This beverage has been called sumac-ade, rhus-ade, sumac lemonade, Indian lemonade, sumac tea, and more.

Prepared cool, we think this is an incredible alternative to lemonade. Prepared with very hot or boiling water, the flavor profile changes entirely and somehow tastes incredibly like the fall. It’s hard to describe something tasting like autumn, but sumac tea prepared hot certainly does! You can also dry and grind the berries to make the spice commonly used in Mediterranean dishes.",
                IsEdibleRaw = true,
                ImagePath = "images/items/sumac.webp"
            }
        };
        itemList[0].Users.Add(userList[0]); // Adds Dave to Black Walnut; use indexing to vary users added
        itemList[1].Users.Add(userList[1]);
        itemList[2].Users.Add(userList[2]);
        itemList[3].Users.Add(userList[3]);
        itemList[4].Users.Add(userList[4]);
        itemList[5].Users.Add(userList[0]);
        itemList[6].Users.Add(userList[1]);
        itemList[7].Users.Add(userList[2]);
        itemList[8].Users.Add(userList[3]);
        itemList[9].Users.Add(userList[4]);
        itemList[10].Users.Add(userList[0]);
        itemList[11].Users.Add(userList[1]);
        itemList[12].Users.Add(userList[2]);
        itemList[13].Users.Add(userList[3]);
        itemList[14].Users.Add(userList[4]);
        itemList[15].Users.Add(userList[0]);
        itemList[30].Users.Add(userList[1]);

        return itemList;
    }

    #endregion

    public static List<Recipe> CreateRecipes()
    {
        var list = new List<Recipe>()
        {
            new Recipe() { Name = "Banana Nut Bread", WildFoodIncluded = null, Ingredients = "Flour, oil, salt, eggs, sugar, bananas, walnuts", Instructions = @"Mash overripe bananas in a bowl. Then, whisk together your dry ingredients. Whisk together the sugar, oil, vanilla, and eggs in a separate mixing bowl. Add the mashed bananas to that mixture and mix gently. Finally, add the dry ingredients and fold gently to combine. Gently fold in the chopped walnuts.

Divide the batter between two 8-inch loaf pans and bake at 350 degrees until golden brown and a thin knife inserted in the center comes out clean. Click <a href='https://www.browneyedbaker.com/banana-nut-bread/'>here</a> for full recipe.", AddedBy = null },

            new Recipe() { Name = "Acorn Grits", WildFoodIncluded = null, Ingredients = @"Cold-leached acorn flour, water, and an alkali solution", Instructions = @"Soak cold leached a cornmeal in an alkali solution for 24 hours then leach out the alkali with several water changes over a few days. It is recommended to do so, in a gallon jar, with a piece of cheese, cloth attached to the mouth with a rubber band, which makes a convenient strainer. At the end, boil the grits in a few water changes to rid it of any trace of alkali (just as is done with how many or corn grits made from scratch.) before calling it ready to eat.

Samuel fair does not give an exact recommendation on the strength of the alkali solution to use, because every strength he tried worked. Stronger alkali solutions Soffer soften the acorn mower and turn it a lighter color, but even weak solutions seem to neutralize every last bit of tannin.", AddedBy = null },

            new Recipe() { Name = "Acorn Pizza Crust", WildFoodIncluded = null, Ingredients = @"2 cups of moist, cold-leached a corn flour. Add a little salt and a quarter cup of tomato juice.", Instructions = @"The desired texture is probably much drier-looking than you think it should be. Little to no liquid should run from the acorn though even when it is pressed hard. Mold of the day go into the bottom of a nonstick frying pan pig, curving the edges slightly up the sides to hold the sauce. Even out the thickness and make it look Nice. Put a cover on the pan and put it in a top a burner on low heat for 20 to 30 minutes until the crust is cooked – you’ll see and feel the texture change as the acorn starts sticking together.

Don’t turn the heat to high, or bubbles in a form that will break the crust. Once the texture changes, indicating that the acorn has cooked, take the cover off and let the crust cook a few more minutes until the surface is dry. Remove from the pan, put on a pizza tray, apply your sauce, cheese, and toppings, and bake.", AddedBy = null }
        };
        return list;
    }

    public static string SeedDatabase()
    {
        var items = CreateItems();
        var context = new ForageContext();
        context.Items.AddRange(items);
        context.SaveChanges();

        //Now that items and users are in the DB, we can relate the recipes:
        var recipes = CreateRecipes();
        recipes[0].WildFoodIncluded = items[0];
        recipes[0].AddedBy = context.Users.Find(1);
        recipes[1].WildFoodIncluded = items[9];
        recipes[1].AddedBy = context.Users.Find(4);
        recipes[2].WildFoodIncluded = items[9];
        recipes[2].AddedBy = context.Users.Find(4);

        context.Recipes.AddRange(recipes);
        context.SaveChanges();
        return MethodBase.GetCurrentMethod().Name;
    }
}
