using System;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

namespace BlendasBlogg
{
    public class Post
    {
        Comment comment = new Comment();
        // Fält
        string header;
        // Properties
        // Title : string
        public string Title { get; set; }

        // Content : string
        public string Content { get; set; }

        // Date : dagens datum
        public DateTime date = DateTime.Now;

        // Comments
        // Anropa listan med kommentarer och sorterar på key för postID
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


        // Posts : List (Post)
        public static List<Post> PostList = new List<Post>();

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

            // Overridead ToString-metod
            // Gör en fin utskrift av ett inlägg med allt innehåll som parametrar

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
            int headerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("\nSkriv in en titel för ditt inlägg: ");
            string title = Console.ReadLine();
            Console.WriteLine("\nSkriv in innehållet för ditt inlägg: ");
            string content = Console.ReadLine();
            CategoryChoice();



            Post newPost = new Post(headerIndex, title, content, categoryChoice, postID++, likes, dislikes);

            PostList.Add(newPost);
            PostList.Sort((a, b) => b.date.CompareTo(a.date));
        }



        public void CategoryChoice()
        {
            Console.WriteLine("\nVälj en kategori:" +
               "\n1. Nyheter" +
               "\n2. Ordspråk" +
               "\n3. Roliga fakta");
            Console.Write("Skriv den siffra som motsvarar ditt val: ");
            categoryChoice = (Category)(Convert.ToInt32(Console.ReadLine()));
            
           
        }

        public void RemovePost()
        {
            foreach (Post post in PostList)
            {
                Console.WriteLine(post);
            }

            Console.Write("Ange ID på det inlägg du vill ta bort: ");
            int idChoice = Convert.ToInt32(Console.ReadLine());
            foreach (Post post in PostList)
            {
                if (post.PostID == idChoice)
                {
                    PostList.Remove(post);
                    break;
                }
            }
        }

        public void LikePost()
        {
            Console.Write("Ange ID på det inlägg du vill gilla: ");
            int LikeID = Convert.ToInt32(Console.ReadLine());

            foreach (Post post in PostList)
            {
                if (post.PostID == LikeID)
                {
                    post.likes++;
                    break;
                }
            }

        }

        public void DislikePost()
        {
            Console.Write("Ange ID på det inlägg du vill gilla: ");
            int LikeID = Convert.ToInt32(Console.ReadLine());

            foreach (Post post in PostList)
            {
                if (post.PostID == LikeID)
                {
                    post.dislikes++;
                    break;
                }
            }
        }



        // Skapa ID:
        // For-loop som räknar antalet inlägg som finns
        // Plussar på 1 på ID-countern för varje inlägg
        //int idCounter;


        public void EditPost()
        {
            foreach (Post post in PostList)
            {
                Console.WriteLine(post);
            }

            Console.Write("Ange ID på det inlägg du vill redigera: ");
            int idChoice = Convert.ToInt32(Console.ReadLine());
            

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
                    Console.Write("Skriv den siffra som motsvarar ditt val: ");

                    string userChoice = Console.ReadLine();
                    switch (userChoice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Ange ny titel:");
                            post.Title = Console.ReadLine();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Ange nytt innehåll:");
                            post.Content = Console.ReadLine();
                            break;

                        case "3":
                            Console.Clear();
                            CategoryChoice();
                            post.categoryChoice = categoryChoice;
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Välj en header till ditt inlägg!" +
                            "\n1. Tom" +
                            "\n2. Hjärtan" +
                            "\n3. Bubblor" +
                            "\n4. Glada ansikten" +
                            "\n5. Förvånade gubbar");
                            post.HeaderIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                            break;

                        default:
                            break;
                    }

                }
            }
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

        // Ta bort inlägg:
        // Välj ett inlägg via ID - variabel : idChoice : int
        // Ta bort inlägget ur listan med alla inlägg


        public override string ToString()
        {
            return $"{header}\n {Title}\n\n{Content}" +
                $"\n\nKategori: {Category}\nDatum: {date}\n" +
                $"InläggsID: {PostID}\n" +
                $"Likes: {likes}\n" +
                $"Dislikes: {dislikes}\n\n";
        }


        // Skriva ut alla inlägg:
        // Foreach-loop som skriver ut alla inlägg med en egen ToString-metod



        // Söka på inlägg:
        // Input för vilken del som ska sökas på: Title, Content och Category - Variabel: searchChoice: string
        // Input för sökord inom den valda delen - Variabel : searchWord : string
        // För varje del som går att söka igenom:
        // Foreach-loop som går igenom alla inlägg
        // If-sats som skriver ut de som matchar sökordet

        // Sortera inlägg på datum:
        // Göra en List - Sort
        // Skriva ut med ToString

        // Gilla / ogilla
        // Input för om man vill likea eller dislikea - Variabel : likeChoice : string
        // Switch-case eller if-sats som gör Likes++ eller Likes-- beroende på valet


    }
}
