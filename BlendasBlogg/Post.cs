using System;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

namespace BlendasBlogg
{
    public class Post
    {
        // Fält
        string header;
        string title;
        string content;
        string userChoice;
        int dislikes = 0;
        int likes = 0;
        // Startar på 4 på grund av default-inläggen som alltid skapas
        int postID = 4;
        int headerIndex = 0;
        int idChoice = 0;
        public Category categoryChoice;  
        DateTime date = DateTime.Now;
        bool isInvalid = true;
        bool isFound;

        // Array med headers
        static string[] headerArray =
        {
            "C-:|)  (-:|]  C-:|=  (-:|B  C-:|>  (-:P  C-:|)  (-:|]  (-:|B  (-:P",
            "<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3",
            "°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO",
            "|^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^|",
            "|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|"
        };

        // Lista med inlägg
        public static List<Post> PostList = new List<Post>();

        // Properties
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; } 
        public int Dislikes { get; set; }  
        public Category Category { get; set; }
        public int PostID { get; set; }
        public int HeaderIndex { get; set; } = 0;

        // Konstruktorer:
        public Post() { }
        public Post(
            int headerIndex,
            string title,
            string content,
            Category categoryChoice,
            int postID,
            int likes,
            int dislikes   
        )
        {
            HeaderIndex = headerIndex;
            header = headerArray[HeaderIndex];
            Title = title;
            Content = content;
            Category = categoryChoice;
            Likes = likes;
            Dislikes = dislikes;
            date = DateTime.Now;
            PostID = postID;
        }

        // Metoder:

        //Default-inlägg:
        public void CreateDefaultPosts()
        {
            PostList.Add(new Post(1, "Välkommen till Blendas Blogg!", "Hej och välkommen till min blogg! Här kommer jag att dela med mig \nav mina tankar, idéer och äventyr. Hoppas du gillar det!", Category.Nyheter, 1, 5, 0));
            PostList.Add(new Post(4, "Ordspråk med mumsig twist!", "Brukar du säga \"Som man bäddar får man ligga\"? Då tycker jag du \nkan lägga till en fika-twist och istället säga \n\"Som man bakar får man fika!\" :D", Category.Ordspråk, 2, 0, 0));
            PostList.Add(new Post(0, "Du är snabbare än du tror!", "I alla fall när du är sjuk... Visste du att nysningar kan nå \nupp till 160 km/h i hastighet?! Det är snabbare än en \nkategori 1 orkan!", Category.Roliga_Fakta, 3, 0, 0));
        }

        // Lägga till inlägg:
        public void AddPost()
        {
            Console.WriteLine("Välj en header till ditt inlägg!" +
                "" +
                "\n1. Gubbar i hattar" +
                "\n2. Hjärtan" +
                "\n3. Bubblor" +
                "\n4. Glada ansikten" +
                "\n5. Förvånade gubbar");
            Console.Write("\nSkriv den siffra som motsvarar ditt val: ");

            // Do-while loop som fortsätter tills ett giltigt header-val gjorts
            do
            {
                try
                {
                        
                    headerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (headerIndex < 0 || headerIndex > headerArray.Length)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        isInvalid = false;
                    }
                }
                catch
                {
                    Console.Write("\nOgiltigt val, vänligen skriv en siffra som motsvarar ett header-alternativ: ");
                    isInvalid = true;
                }
            } while (isInvalid);

            Console.WriteLine("\nSkriv in en titel för ditt inlägg: ");
            title = Console.ReadLine();
            
            Console.WriteLine("\nSkriv in innehållet för ditt inlägg: ");
            content = Console.ReadLine();
            
            CategoryChoice();

            // Skapar det nya inlägget och lägger till det i listan med alla inlägg
            Post newPost = new Post(headerIndex, title, content, categoryChoice, postID++, likes, dislikes);

            PostList.Add(newPost);

            // Sortera inlägg på datum direkt i AddPost eftersom inläggen alltid
            // ska skrivas ut i samma ordning oavsett var i listan
            // Använder ett lambda-uttryck för att sortera listan i fallande ordning baserat på datum
            PostList.Sort((a, b) => b.date.CompareTo(a.date));
            Console.Clear();
            Console.WriteLine("Inlägget har laddats upp!");
            Menu.BackToMenuMessage();
        }

        // Välja kategori:
        public void CategoryChoice()
        {
            Console.WriteLine("\nVälj en kategori:" +
               "\n1. Nyheter" +
               "\n2. Ordspråk" +
               "\n3. Roliga fakta");
            Console.Write("\nSkriv den siffra som motsvarar ditt val och tryck sedan enter: ");
            do
            {
                try
                {
                    categoryChoice = (Category)(Convert.ToInt32(Console.ReadLine()));

                    if (Convert.ToInt32(categoryChoice) < 1 || Convert.ToInt32(categoryChoice) > 3)
                    {
                        throw new Exception();
                    }

                    else
                    {
                        isInvalid = false;
                    }

                }
                catch
                {
                    Console.Write("\nOgiltigt val, vänligen välj en kategori ur listan. Skriv endast siffran: ");
                    isInvalid = true;

                }
            } while (isInvalid);
        }

        // Ta bort inlägg:
        public void RemovePost()
        {
            // Bool för att kontrollera om några matchande inlägg hittas
            isFound = false;

            foreach (Post post in PostList)
            {
                Console.WriteLine(post + "\n\n");

            }

            //Kollar om det finns några inlägg i listan, som kan tas bort. Annars skrivs passande felmeddelande ut
            if (PostList.Count > 0)
            {
                Console.Write("\nAnge ID:t för det inlägg du vill ta bort, alternativt skriv '0' för att gå tillbaka: ");
                
                // do-while som kör om tills ett matchande inlägg hittas
                do
                {

                    //do-while som kör om tills ett giltigt värde inmatas från användaren, siffra för int.
                    do
                    {
                        try
                        {
                            idChoice = Convert.ToInt32(Console.ReadLine());
                            isInvalid = false;
                        }
                        catch
                        {
                            Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                            isInvalid = true;
                        }
                    } while (isInvalid);

                    foreach (Post post in PostList)
                    {
                        if (post.PostID == idChoice)
                        {
                            PostList.Remove(post);
                            Console.Clear();
                            Console.WriteLine("Inlägget har tagits bort!");
                            Menu.BackToMenuMessage();
                            isFound = true;
                            break;
                        }
                        else if (idChoice == 0)
                        {
                            Console.Clear();
                            Menu.BackToMenuMessage();
                            isFound = true;
                            break;
                        }
                    }

                    //Om inget inlägg matchade med det valda ID:t förblir isFound falskt och felmeddelande skrivs ut. do.while-loopen körs sedan om.
                    if (!isFound)
                    {
                        Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                    }
                } while(!isFound);
            }
            else
            {
                Console.WriteLine("Det finns inga inlägg.");
                Menu.BackToMenuMessage();
            }
        }

        // Gilla inlägg:
        public void LikePost()
        {
            Console.Write("\nAnge ID:t för det inlägg du vill ge en tumme upp och tryck sedan enter: ");
            do
            {
                isFound = false;
                try
                {
                    idChoice = Convert.ToInt32(Console.ReadLine());
                    
                    foreach (Post post in PostList)
                    {
                        if (post.PostID == idChoice)
                        {
                            isFound = true;
                            post.likes++;
                            isInvalid = false;
                            Console.Clear();
                            Console.WriteLine("Du har gett inlägget en tumme upp!");
                            Menu.BackToMenuMessage();
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                        isInvalid = true;
                    }
                }
                catch
                {
                    Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                    isInvalid = true;
                }
            } while (isInvalid);
        }

        // Ogilla inlägg:
        public void DislikePost()
        {
            Console.Write("\nAnge ID:t för det inlägg du vill ge en tumme ner och tryck sedan enter: ");
            do
            {
                isFound = false;
                try
                {
                    idChoice = Convert.ToInt32(Console.ReadLine());

                    foreach (Post post in PostList)
                    {
                        if (post.PostID == idChoice)
                        {
                            isFound = true;
                            post.dislikes++;
                            isInvalid = false;
                            Console.Clear();
                            Console.WriteLine("Du har gett inlägget en tumme ner!");
                            Menu.BackToMenuMessage();
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                        isInvalid = true;
                    }
                }
                catch
                {
                    Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                    isInvalid = true;
                }
            } while (isInvalid);
        }

        // Redigera inlägg:
        public void EditPost()
        {
            // If-sats som kollar om det finns inlägg i listan
            if (PostList.Count > 0)
            {
                // Använder en bool som kollar om det skrivits ut några matchande inlägg med idChoice.
                isFound = false;

                foreach (Post post in PostList)
                {
                    Console.WriteLine(post + "\n");

                }

                Console.Write("\nAnge ID:t för det inlägg du vill redigera: ");

                // Do-while loop som fortsätter tills ett matchande inlägg valts alternativt gått tillbaka
                do
                {
                    // Do-while loop som fortsätter tills ett giltigt ID skrivits in, alltså en siffra för int
                    do
                    {
                        isInvalid = false;
                        try
                        {
                            idChoice = Convert.ToInt32(Console.ReadLine());

                        }
                        catch
                        {
                            Console.Write("\nOgiltigt val, vänligen ange ett befintligt ID. Skriv endast siffran: ");
                            isInvalid = true;
                        }
                    } while (isInvalid);

                    foreach (Post post in PostList)
                    {
                        if (idChoice == post.PostID)
                        {
                            isFound = true;
                            Console.Clear();
                            Console.WriteLine("REDIGERAR:\n");
                            Console.WriteLine(post);
                            Console.WriteLine("\nVad önskar du redigera?" +
                                "\n1, Titel" +
                                "\n2, Innehåll" +
                                "\n3, Kategori" +
                                "\n4, Header" +
                                "\n5, Gå tillbaka");
                            Console.Write("\nSkriv den siffra som motsvarar ditt val: ");

                            // Do-while loop som fortsätter tills ett giltigt val gjorts från menyn
                            do
                            {
                                isInvalid = false;
                                userChoice = Console.ReadLine();

                                switch (userChoice)
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("REDIGERAR:\n");
                                        Console.WriteLine(post);
                                        Console.WriteLine("\nAnge ny titel:");
                                        post.Title = Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("Titeln har uppdaterats!\n");
                                        Console.WriteLine(post);
                                        Console.WriteLine("\nKlicka på valfri knapp för att gå tillbaka till menyn.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Menu.BackToMenuMessage();
                                        break;

                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine("REDIGERAR:\n");
                                        Console.WriteLine(post);
                                        Console.WriteLine("\nAnge nytt innehåll:");
                                        post.Content = Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("Innehållet har uppdaterats!\n");
                                        Console.WriteLine(post);
                                        Console.WriteLine("\nKlicka på valfri knapp för att gå tillbaka till menyn.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Menu.BackToMenuMessage();
                                        break;

                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine("REDIGERAR:\n");
                                        Console.WriteLine(post);
                                        CategoryChoice();
                                        post.Category = categoryChoice;
                                        Console.Clear();
                                        Console.WriteLine("Kategorin har uppdaterats!\n");
                                        Console.WriteLine(post);
                                        Console.WriteLine("\nKlicka på valfri knapp för att gå tillbaka till menyn.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Menu.BackToMenuMessage();
                                        break;

                                    case "4":
                                        Console.Clear();
                                        Console.WriteLine("REDIGERAR:\n");
                                        Console.WriteLine(post);
                                        Console.WriteLine("\nVälj en header till ditt inlägg!" +
                                        "\n1. Gubbar med hattar" +
                                        "\n2. Hjärtan" +
                                        "\n3. Bubblor" +
                                        "\n4. Glada ansikten" +
                                        "\n5. Förvånade gubbar");
                                        Console.Write("\nSkriv den siffra som motsvarar ditt val: ");

                                        // Do-while loop som fortsätter tills ett giltigt header-val gjorts
                                        do
                                        {
                                            isInvalid = false;
                                            try
                                            {
                                                // Tar in header-valet och kollar så det är en int och finns i arrayen
                                                headerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                                if (headerIndex < 0 || headerIndex > headerArray.Length)
                                                {
                                                    throw new Exception();
                                                }
                                                else
                                                {
                                                    isInvalid = false;
                                                }
                                            }
                                            catch
                                            {
                                                Console.Write("\nOgiltigt val, vänligen skriv en siffra som motsvarar ett header-alternativ: "); 
                                                isInvalid = true;
                                            }
                                        } while (isInvalid);

                                        post.header = headerArray[headerIndex];
                                        Console.Clear();
                                        Console.WriteLine("Inläggets header har uppdaterats!\n");
                                        Console.WriteLine(post);
                                        Console.WriteLine("\nKlicka på valfri knapp för att gå tillbaka till menyn.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        Menu.BackToMenuMessage();
                                        break;

                                    case "5":
                                        Console.Clear();
                                        Menu.BackToMenuMessage();
                                        break;

                                    default:
                                        Console.Write("\nOgiltigt val, välj ett av alternativen från menyn, skriv endast siffran: ");
                                        isInvalid = true;
                                        break;
                                }
                            } while (isInvalid);
                        }
                    }
                    // Om inget inlägg matchade med det valda ID:t
                    if (isFound == false)
                    {
                        Console.Write("\nOgiltigt val, vänligen ange ett befintligt ID. Skriv endast siffran: ");
                    }
                } while (isFound == false);
            }
            // Om det inte finns några inlägg i listan
            else
            {
                Console.Clear();
                Console.WriteLine("Det finns inga inlägg ännu :'(");
                Menu.BackToMenuMessage();
            }
            
        }

        // Overridead ToString-metod:
        public override string ToString()
        {
            return
                $"{header}\n" +
                $"\nTITEL: {Title}\n" +
                $"| Kategori: {Category}" +
                $" | Datum: {date}" +
                $" | InläggsID: {PostID} |\n" +
                $"- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" +
                $"\n\n{Content}\n\n" +
                $"- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" +
                $"\nLikes: {likes}" +
                $"\nDislikes: {dislikes}\n" +
                $"************************** Kommentarer **************************";
        }
    }
}
