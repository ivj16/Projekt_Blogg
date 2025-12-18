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
        public DateTime Date;

        // Comments
        // Anropa listan med kommentarer och sorterar på key för postID
        // Likes : int
        public int Likes { get; set; }

        // Category : Category enum
        public Category Category { get; set; }

        // Header : string array
        static string[] headerArray =
        {
            "",
            "═══════•°• ⚠ •°•══════════════•°• ⚠ •°•══════════════•°• ⚠ •°•═══════",
            "*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*",
            "ღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღ",
            "■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■"
        };

        public int HeaderIndex { get; set; } = 0;

        // postID : int


        // Posts : List (Post)
        public List<Post> Posts = new List<Post>();

        // Konstruktor:
        // Innehåller Title, Content, Category, Header, Likes, ID, Date, Comments 

        public Post() { }
        public Post(
            int headerIndex,
            string title,
            string content,
            Category category
        )
        {
            HeaderIndex = headerIndex;
            header = headerArray[HeaderIndex];
            Title = title;
            Content = content;
            Category = category;
            Likes = 0;
            DateTime Date = DateTime.Now;
            CreateID();

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
                "\n2. Varningstrianglar" +
                "\n3. Blommor" +
                "\n4. Maxade krumelurer" +
                "\n5. Kvadrater");
            int headerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("\nSkriv in en titel för ditt inlägg: ");
            string title = Console.ReadLine();
            Console.WriteLine("\nSkriv in innehållet för ditt inlägg: ");
            string content = Console.ReadLine();
            Console.WriteLine("\nVälj en kategori för ditt inlägg!" +
                "\n1. Nyheter" +
                "\n2. Ordspråk" +
                "\n3. Roliga fakta");
            Console.Write("Skriv den siffra som motsvarar ditt val: ");
            Category category = (Category)(Convert.ToInt32(Console.ReadLine()) - 1);

            Post newPost = new Post(headerIndex, title, content, category);

            Posts.Add(newPost);
        }


        // Skapa ID:
        // For-loop som räknar antalet inlägg som finns
        // Plussar på 1 på ID-countern för varje inlägg
        public int CreateID()
            {
                int idCounter = 0;
                for (int i = 0; i <= Posts.Count; i++)
                {
                    idCounter++;
                }
                return idCounter;
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

        // Skriva ut alla inlägg:
        // Foreach-loop som skriver ut alla inlägg med en egen ToString-metod

        // Skriva ut inlägg från kategori:
        // Input för vilken kategori som ska skrivas ut - Variabel : categoryChoice : string
        // If-sats som skriver ut inläggen som matchar en vald kategori

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
