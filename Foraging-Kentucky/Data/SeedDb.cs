using Foraging_Kentucky.Common;
using Foraging_Kentucky.Domain;
using System.Reflection;

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
            new User("Dread Pirate Roberts", "pirateguy08@asyouwish.net"),
            new User("Aragorn Stryder", "king@gondor.com"),
            new User("Eowyn", "rohanrules@horselords.gov"),
            new User("Olivia Dunham", "olive@fringe.fbi.gov")
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
                IsEdibleRaw = true
            },
            new Item("Autumn Olive")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"This is an invasive plant with small, slightly astringent drupes that are high in lycopene. Autumn olives--or autumnberries--come from a hefty shrub with small, tough, sprawling tree. It usually produces several gnarled and spreading trunks, the largest of which may reach 6 inches in diameter. Look for silver speckles on the stems, leaves, and fruit which is why sometimes this fruit goes erroneously by the name Silver Berry.

If you don’t know what autumn olives look like, smell for them in the spring. They give off a lovely and overwhelming, sometimes cloying aroma when in bloom. You will also see the dull yellow flowers in crowded clusters that hang from leaf axles. A blooming thick.

Olive shaped fruits, typically smaller than a pea, are produced and hang all summer long in gray clumps seemingly never to ripen. But when they finally do, the fruit is an appealing reddish, ripening to an even deeper crimoson red on some buches. Flavor varies on different bushes as well.",
                IsEdibleRaw = true
            },
            new Item("Common Milkweed")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"Milkweed is a perennial herb of old fields, roadsides, small clearings, stream sides, and fencerows. Several parts are edible. Do not mistake for dogbane, a mildly poisonous lookalike.",
                IsEdibleRaw = false
            },
            new Item("Pawpaw")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"North America's largest native fruit, the pawpaw (Asimina Triloba) is a prized ""tropical"" treat in the fall",
                IsEdibleRaw = true },
            new Item("Morel")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"One of the most highly sought fungi in the United States, and certainly in Kentucky.
Up to 6 inches tall; consisting of a conical to elongated, bluntly, triangular, pitted head on a cylindrical, hollow stock.

Usually gregarious on the ground in woods and near trees in more open areas, such as woodland, clearings and margins, especially near tulip, poplar, and ash, also on burn sites; saprobic and mycorrhizal. Common.",
                IsEdibleRaw = false
            },
            new Item("Chantrelle")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Convex at first, becoming nearly flat, with a central depression to somewhat funnel shaped, Margin incurved when young.

The stock is more or less equal or flaring near the Apex, becoming hollow with age; colored like the cap or paler, base often white; surface smooth.

These occur in solitary or scattered groups, sometimes clustered, on the ground in mixed words; Michael Wright is home; summer; occasional to fairly common locally.",
                IsEdibleRaw = false
            },
            new Item("Chicken of the Woods")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Annual; semi circular to fan shaped brackets with blunt wavy margins, usually in compound overlapping clusters.

These occur sometimes in solitary fashion, but usually in compound clusters on living or dead tree trucks, logs, stumps, and larger, fallen branches of broadleaved trees; parasitic and saprobic; spring – fall; common.

The entire fruit body is very good when young, but lighter, as it matures and becomes fibrous, only the tender margin is edible.",
                IsEdibleRaw = false
            },
            new Item("Hen of the Woods")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"These wonderful mushrooms are up to 2 feet or more wide; compound clusters of overlapping, fan-shaped caps attached laterally to a branched stalk.

These occur in rosette-like clusters, often massive, at the base of oak trees, or around decaying oak stumps, also reported to occur with other broad–leaved trees; parasitic; late summer-fall; occasional to locally common.",
                IsEdibleRaw = false
            },
            new Item("Oyster Mushroom")
            {
                Type = ItemOptions.ItemTypes[1],
                Description = @"Convex with an incurved margin at first, often becoming flattened with an upturned wavy margin in age, fan–shaped, oyster shell, hash shaped, or semi-circular in outline.

Gregarious, usually in overlapping clusters, sometimes solitary, on living or dead, standing trunks, logs, and stumps of broad-leaved trees, less frequently on hemlock or pine; parasitic and saprobic; spring-early winter; common.

Edible and very good when young and fresh, discard the tough basal portion. Small, black beetles and other insects that often inhabit the gills can be evicted by tapping on the caps.",
                IsEdibleRaw = false
            },

            new Item("Acorn")
            {
                Type = ItemOptions.ItemTypes[2],
                Description = @"An acorn consists of a rather large seed, encapsulated by a smooth shell with no surrounding fleshy tissue. The shells are thin, compared to those of most other nuts, and also differ in being pliable, until they are dry.
All or acorns terminate in a nipple – like point, and all of them are born in tight, hash, fitting, scaly, or Bristley cups. These cups (also called caps) may cover only the base of the nut, or they may enclosed it entirely. No other North American, fruits or nuts are born in cups like these.

Acorns are produced by oaks of the Genera Quercus and Lithocarpus.

Acorns are widely believed to be poisonous or an edible, but with proper processing they make for a staple food.",
                IsEdibleRaw = false
            },

            new Item("Hazelnut")
            {
                Type = ItemOptions.ItemTypes[2],
                Description = @"Hazelnuts ripen in late summer and are born in tight clusters of up to 15 nuts near the tips of the branches. About 0.5 inches in diameter, the nuts are hard-shield, smooth, and an attractive light brown when ripe. Each night is wrapped in in in Volker, a pair of modified leaves that hides and protects it. All the nuts and in value cars are packed in tightly together with no stems connecting them, forming a big, leafy ball. Large ones may weigh several ounces.

Hazelnuts will be ripe in August or September, but most years they will not produce very much, be empty, or full of worms. American hazels will quickly fill a container with their fluffy, volume in us in value cars; all things considered American hazels are easy to collect.",
                IsEdibleRaw = true
            },

            new Item("Maypop")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"A perennial herbaceous fine with rough, slightly hairy, green stems rarely more than 8 mm thick. The vines may grow as much as 30 feet long, climbing over fenses, walls, bushes, small trees, or buildings.

The alternate leaves are deeply three-lobed (occasionally five-lobed), 3-5 inches long, and about equally wide.

Maypop is unique among American plants in that its fruit and flower (passiflora incarnata) generally go by separate names. The striking blossom, 2-3 inches wide, is the best-known part of this plant–and it is the state flower of Tennessee. It is quite possibly the coolest-looking flower in the world.

The fruit is a large berry, usually 1-2.5 inches long and elliptic, spherical, or egg-shaped at maturity. The maypop's skin is smooth and dark green at first, but slowly gets wrinkly and yellowish after ripening.

The inside is full of seeds in small sacs with pale, yellowish pulp that tastes like passion fruit (it is the same family, after all). When you break the surface of a Maypop, watch out because it MAY POP!",
                IsEdibleRaw = true
            },

            new Item("Wild Plum")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Usually some combination of red, orange, yellow, and blue. They are coated with a bloom just like cultivated plums. Wild plums range from oblong to globe-shaped.

The fruit of larger kinds may reach nearly 2 inches in length, but the smaller species are typically less than 1 inch in diameter. Each plum contains a single, oblong, flattened stone like those found in cultivated plums. The skins are thick and tough. When ripe, wild plums are soft, tart, sweet, and juicy.

You might have trouble finding them before the animals get to them. Not only do animals eat them for the fleshy part of the fruit, but the nut-like structure inside as the pit is highly sought after by critters as well.",
                IsEdibleRaw = true
            },

            new Item("Wood Sorrel")
            {
                Type = ItemOptions.ItemTypes[3],
                Description = @"There are numerous species of wood sorrel found throughout North America. They all belong to the oxalis family.

The flowers have five petals, five sepals, and ten stamens. Some species are yellow, while others are pink or white. The yellow is by far the most abundant species in Kentucky.

Look for blooms in the spring to late summer. After the flowers wither, the plants bare elongated, green, banana-shaped seed pods, 0.3–0.6 inches long. They are delightfully crunchy and add a wonderful texture to a mouth full of wood sorrel greens.

Although these make for a wonderful trailside snack, be sure not to eat too much until you know if the oxalic acid will upset your stomach.",
                IsEdibleRaw = true
            },

            new Item("Elderberry")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Medium to large shrubs or small trees. American elder has large, opposite, pinnately compound leaves, sometimes as much as 20 inches in length. The leaves typically consist of seven leaflets, which are sharply serrated, 2-5 inches long, elliptic with sharply pointed tips, and sesile on or growing on very short petioles. The leaves and stems of elderberry give off a strong, unpleasant odor when cut or bruised.

The small, white, five-petaled flowers, about 0.25 inches across, are produced in rounded, somewhat flattenned, topped clusters called umbrels at the ends of the branches. The fragrant blossoms open in late June and July.

The elderberry fruit is a tiny drupe, generally about 0.13 inches in diameter. Dark purple and juicy when ripe, they make up for their lack of size with copious production. American elderberries ripen in July, August, and September with the plump clusters often drooping under their own weight.",
                IsEdibleRaw = false
            },

            new Item("Dandelion")
            {
                Type = ItemOptions.ItemTypes[0],
                Description = @"Dandelion greens are usually picked in early spring before the plants have flowered. The best leaves grow in rich, moist soil in locations where the plants do not get mowed. If there is a little shade or competition. The leaves usually stand erect rather than lie on the ground, which means they are more likely to be clean. Don’t pick leaves from dandelions that grow all alone on bare ground exposed to full sun, as these usually have a stronger flavor, tougher texture, and dirt clinging to them.

The best dandelion greens, collected an early spring, are milder in flavor, and more tender than the older leaves but they are still somewhat bitter. Many dandelion aficionados claim that the spring greens are not bitter. We at FK have no reason to believe this; dandelion greens are just bitter! They are, however, quite nutricious, so use dandelions sparingly--cooked!--to balance something rich like chowder.",
                IsEdibleRaw = true
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

        return itemList;
    }

    #endregion

    public static List<Recipe> CreateRecipes()
    {
        var list = new List<Recipe>()
        {
            new Recipe() { Name = "Banana Nut Bread", WildFoodIncluded = null, Ingredients = "Lorem Ipsum", Instructions = @"Put it in your face-mouth.", AddedBy = null },

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
