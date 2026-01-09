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
        int postID = 1;
        int headerIndex = 0;
        int idChoice = 0;
        public Category categoryChoice;  
        bool isInvalid = true;
        public DateTime date = DateTime.Now;
        bool isFound;

        // Properties
        public string Title { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; } 

        public int Dislikes { get; set; }
        
        public Category Category { get; set; }
        
        public int PostID { get; set; }

        public int HeaderIndex { get; set; } = 0;

        

        // Header : string array
        static string[] headerArray =
        {
            "C-:|)  (-:|]  C-:|=  (-:|B  C-:|>  (-:P  C-:|)  (-:|]  (-:|B  (-:P",
            "<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3<3",
            "°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO°oO",
            "|^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^||^_^|",
            "|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|:-O|"
        };  

        // Posts : List (Post)
        public static List<Post> PostList = new List<Post>();


        // Konstruktor

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


        // Lägga till inlägg:
        // Input för title, content och category
        // Tilldelar dagens datum till Date
        // Anropar Skapa ID-metoden
        // Lägger till nya inlägget i listan med alla inlägg

        public void AddPost()
        {
            Console.WriteLine("Välj en header till ditt inlägg!" +
                "\n1. Gubbar i hattar" +
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
            title = Console.ReadLine();
            Console.WriteLine("\nSkriv in innehållet för ditt inlägg: ");
            content = Console.ReadLine();
            CategoryChoice();

            Post newPost = new Post(headerIndex, title, content, categoryChoice, postID++, likes, dislikes);

            PostList.Add(newPost);
            
            // Sortera inlägg på datum:
            // Göra en List - Sort
            // Skriva ut med ToString
            PostList.Sort((a, b) => b.date.CompareTo(a.date));
            Console.Clear();
            Console.WriteLine("Inlägget har laddats upp!");
            Menu.BackToMenuMessage();
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
                    Console.Write("\nOgiltigt val, vänligen välj en kategori ur listan. Skriv endast siffran: ");
                    isInvalid = true;

                }
            } while (isInvalid);
        }

        // Ta bort inlägg:
        // Välj ett inlägg via ID - variabel : idChoice : int
        // Ta bort inlägget ur listan med alla inlägg
        public void RemovePost()
        {
            isFound = false;
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
                        Menu.BackToMenuMessage();
                        isFound = true;
                        break;
                    }
                    else if (idChoice == 0)
                    {
                        Console.Clear();
                        Menu.BackToMenuMessage(); 
                        break;
                    }
                }
                if (isFound == false)
                {
                    Console.Clear();
                    Console.WriteLine("Det finns inget inlägg med det ID:t, inget inlägg har tagits bort.");
                    Menu.BackToMenuMessage();
                    Thread.Sleep(500);
                }
            }
            else
            {
                Console.WriteLine("Det finns inga inlägg.");
                Menu.BackToMenuMessage();
            }
        }

        // Gilla / ogilla
        // Input för om man vill likea eller dislikea - Variabel : likeChoice : string
        public void LikePost()
        {
            Console.Write("Ange ID:t för det inlägg du vill ge en tumme upp och tryck sedan enter: ");
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
            Console.Write("Ange ID:t för det inlägg du vill ge en tumme ner och tryck sedan enter: ");
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
        public void EditPost()
        {
            if (PostList.Count > 0)
            {
                foreach (Post post in PostList)
                {
                    Console.WriteLine(post);
                }

                Console.Write("Ange ID:t för det inlägg du vill redigera: ");
                do
                {
                    isInvalid = false;
                    try
                    {
                        idChoice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                        isInvalid = true;
                    }
                } while (isInvalid);

                foreach (Post post in PostList)
                {
                    if (idChoice == post.PostID)
                    {
                        Console.WriteLine("Vad önskar du redigera?" +
                            "\n1, Titel" +
                            "\n2, Innehåll" +
                            "\n3, Kategori" +
                            "\n4, Header" +
                            "\n5, Gå tillbaka");
                        Console.Write("\nSkriv den siffra som motsvarar ditt val: ");

                        userChoice = Console.ReadLine();
                        switch (userChoice)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Ange ny titel:");
                                post.Title = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Titeln har uppdaterats!");
                                Menu.BackToMenuMessage();
                                break;

                            case "2":
                                Console.Clear();
                                Console.WriteLine("Ange nytt innehåll:");
                                post.Content = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Innehållet har uppdaterats!");
                                Menu.BackToMenuMessage();
                                break;

                            case "3":
                                Console.Clear();
                                CategoryChoice();
                                post.Category = categoryChoice;
                                Console.Clear();
                                Console.WriteLine("Kategorin har uppdaterats!");
                                Menu.BackToMenuMessage();
                                break;

                            case "4":
                                Console.Clear();
                                Console.WriteLine("Välj en header till ditt inlägg!" +
                                "\n1. Gubbar med hattar" +
                                "\n2. Hjärtan" +
                                "\n3. Bubblor" +
                                "\n4. Glada ansikten" +
                                "\n5. Förvånade gubbar");
                                Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
                                do
                                {
                                    isInvalid = false;
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
                                        Console.Write("\nOgiltigt val, vänligen ange ett giltigt ID. Skriv endast siffran: ");
                                        isInvalid = true;
                                    }
                                } while (isInvalid);
                                post.header = headerArray[headerIndex];
                                Console.Clear();
                                Console.WriteLine("Inläggets header har uppdaterats!");
                                Menu.BackToMenuMessage();
                                break;

                            case "5":
                                Console.Clear();
                                Menu.BackToMenuMessage();
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Det finn inga inlägg ännu :'(");
                Menu.BackToMenuMessage();
            }
            
        }

        


        // Overridead ToString-metod
        // Gör en fin utskrift av ett inlägg med allt innehåll som parametrar
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
