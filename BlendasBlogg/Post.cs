using System;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

namespace BlendasBlogg
{
    public class Post
    {
        // Fält
        string header;
        // Properties
        // Title : string
        public string Title { get; set; }

        // Content : string
        public string Content { get; set; }

        // Date : dagens datum
        public DateTime date = DateTime.Now;

        // Likes : int
        public int Likes { get; set; }
        int likes = 0;

        public int Dislikes { get; set; }
        int dislikes = 0;

        // Category : Category enum
        public Category Category { get; set; }

        public Category categoryChoice;
        

        // postID : int
        public int PostID { get; set; }

        int postID = 1;

        // Header : string array
        static string[] headerArray =
        {   
            "",
            "<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3",
            "°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°",
            "|^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^|",
            ":-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|"
        };

        public int HeaderIndex { get; set; } = 0;

        int headerIndex = 0;

        // Posts : List (Post)
        public static List<Post> PostList = new List<Post>();

        // För felhantering
        bool isInvalid = true;

        // För att hantera inläggs via ID
        int idChoice = 0;

        // Konstruktor:
        // Innehåller Title, Content, Category, Header, Likes, ID, Date, Comments 

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

        // Metoder

        public static void BackToMenuMessage()
        {
            Console.Write("\nGår tillbaka till menyn");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(1500);
            Console.Clear();
        }

        // Lägga till inlägg:
        // Input för title, content och category
        // Tilldelar dagens datum till Date
        // Anropar Skapa ID-metoden
        // Lägger till nya inlägget i listan med alla inlägg

        public void AddPost()
        {
            Console.WriteLine("Välj en header till ditt inlägg!" +
                "\n1. Tom" +
                "\n2. Hjärtan" +
                "\n3. Bubblor" +
                "\n4. Glada ansikten" +
                "\n5. Förvånade gubbar");
            Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
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
                    Console.Write("Ogiltigt val, vänligen skriv en siffra som motsvarar ett header-alternativ: ");
                    isInvalid = true;
                }
            } while (isInvalid);

                Console.WriteLine("\nSkriv in en titel för ditt inlägg: ");
            string title = Console.ReadLine();
            Console.WriteLine("\nSkriv in innehållet för ditt inlägg: ");
            string content = Console.ReadLine();
            CategoryChoice();

            Post newPost = new Post(headerIndex, title, content, categoryChoice, postID++, likes, dislikes);

            PostList.Add(newPost);
            
            // Sortera inlägg på datum:
            // Göra en List - Sort
            // Skriva ut med ToString
            PostList.Sort((a, b) => b.date.CompareTo(a.date));
            Console.Clear();
            Console.WriteLine("Inlägget har laddats upp!");
            Thread.Sleep(1000);
            BackToMenuMessage();
        }



        public void CategoryChoice()
        {
            Console.WriteLine("\nVälj en kategori:" +
               "\n1. Nyheter" +
               "\n2. Ordspråk" +
               "\n3. Roliga fakta");
            Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
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
                    Console.Write("Ogiltigt val, vänligen välj en kategori ur listan. Skriv endast siffran: ");
                    isInvalid = true;

                }
            } while (isInvalid);
        }

        // Ta bort inlägg:
        // Välj ett inlägg via ID - variabel : idChoice : int
        // Ta bort inlägget ur listan med alla inlägg
        public void RemovePost()
        {
            foreach (Post post in PostList)
            {
                Console.WriteLine(post);
            }
            if (PostList.Count > 0)
            {
                Console.Write("Ange ID:t för det inlägg du vill ta bort, alternativt skriv '0' för att gå tillbaka: ");
                do
                {
                    try
                    {
                        idChoice = Convert.ToInt32(Console.ReadLine());
                        isInvalid = false;
                    }
                    catch
                    {
                        Console.Write("Ogiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
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
                        Thread.Sleep(1000);
                        BackToMenuMessage();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Det finns inget inlägg med det ID:t, inget inlägg har tagits bort.");
                        Thread.Sleep(1000);
                        BackToMenuMessage();
                    }
                }
            }
            else
            {
                Console.WriteLine("Det finns inga inlägg.");
                Thread.Sleep(1000);
                BackToMenuMessage();
            }
        }

        // Gilla / ogilla
        // Input för om man vill likea eller dislikea - Variabel : likeChoice : string
        public void LikePost()
        {
            Console.Write("Ange ID:t för det inlägg du vill ge en tumme upp: ");
            do
            {
                try
                {
                    idChoice = Convert.ToInt32(Console.ReadLine());
                    
                    foreach (Post post in PostList)
                    {
                        if (post.PostID == idChoice)
                        {
                            post.likes++;
                            isInvalid = false;
                            break;
                        }
                    }
                }
                catch
                {
                    Console.Write("Ogiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                    isInvalid = true;
                }
            } while (isInvalid);
            Console.Clear();

        }

        public void DislikePost()
        {
            Console.Write("Ange ID:t för det inlägg du vill ge en tumme ner: ");
            do
            {
                try
                {
                    idChoice = Convert.ToInt32(Console.ReadLine());

                    foreach (Post post in PostList)
                    {
                        if (post.PostID == idChoice)
                        {
                            post.dislikes++;
                            isInvalid = false;
                            break;
                        }
                    }
                }
                catch
                {
                    Console.Write("Ogiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                    isInvalid = true;
                }
            } while (isInvalid);
            Console.Clear();
        }


        // Redigera inlägg:
        // Switch-case för vilken del av inlägget som vill redigeras
        // Title:
        // Input för nytt värde
        // Content: 
        // Input för nytt värde
        // Category
        // Input för nytt värde
        // Header
        // Input för nytt värde
        // Avsluta
        // Gå tillbaka med break

        public void EditPost()
        {
            foreach (Post post in PostList)
            {
                Console.WriteLine(post);
            }

            Console.Write("Ange ID:t för det inlägg du vill redigera: ");
            do
            {
                try
                {
                    idChoice = Convert.ToInt32(Console.ReadLine());


                    foreach (Post post in PostList)
                    {
                        if (idChoice == post.PostID)
                        {
                            isInvalid = false;
                            Console.WriteLine("Vad önskar du redigera?" +
                                "\n1, Titel" +
                                "\n2, Innehåll" +
                                "\n3, Kategori" +
                                "\n4, Header" +
                                "\n5, Gå tillbaka");
                            Console.Write("\nSkriv den siffra som motsvarar ditt val: ");

                            string userChoice = Console.ReadLine();
                            switch (userChoice)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Ange ny titel:");
                                    post.Title = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Titeln har uppdaterats!");
                                    Thread.Sleep(1000);
                                    BackToMenuMessage();
                                    break;

                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Ange nytt innehåll:");
                                    post.Content = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Innehållet har uppdaterats!");
                                    Thread.Sleep(1000);
                                    BackToMenuMessage();
                                    break;

                                case "3":
                                    Console.Clear();
                                    CategoryChoice();
                                    post.Category = categoryChoice;
                                    Console.Clear();
                                    Console.WriteLine("Kategorin har uppdaterats!");
                                    Thread.Sleep(1000);
                                    BackToMenuMessage();
                                    break;

                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("Välj en header till ditt inlägg!" +
                                    "\n1. Tom" +
                                    "\n2. Hjärtan" +
                                    "\n3. Bubblor" +
                                    "\n4. Glada ansikten" +
                                    "\n5. Förvånade gubbar");
                                    Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
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
                                            Console.Write("Ogiltigt val, vänligen skriv en siffra som motsvarar ett header-alternativ: ");
                                            isInvalid = true;
                                        }
                                    } while (isInvalid);
                                    post.header = headerArray[headerIndex];
                                    Console.Clear();
                                    Console.WriteLine("Inläggets header har uppdaterats!");
                                    Thread.Sleep(1000);
                                    BackToMenuMessage();
                                    break;

                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Det finns inget inlägg med det ID:t, inget inlägg har redigerats.");
                            Thread.Sleep(1000);
                            BackToMenuMessage();    
                        }
                    }
                }
                catch
                {
                    Console.Write("Ogiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                    isInvalid = true;
                }
            } while (isInvalid);
        }

        // Overridead ToString-metod
        // Gör en fin utskrift av ett inlägg med allt innehåll som parametrar
        public override string ToString()
        {
            return $"{header}" +
                $"\n{Title}\n" +
                $"\n{Content}\n" +
                $"\n\nKategori: {Category}" +
                $"\nDatum: {date}" +
                $"\nInläggsID: {PostID}\n" +
                $"\nLikes: {likes}" +
                $"\nDislikes: {dislikes}\n\n";
        }
    }
}
