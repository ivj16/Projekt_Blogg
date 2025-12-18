using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public class Post
    {
        // Properties
        // Title : string
        // Content : string
        // Date : dagens datum
        // Comments
        // Anropa listan med kommentarer och sorterar på key för postID
        // Likes : int
        // Category : Category enum
        // Header : string array

        string[] header =
        {
            "",
            "═══════•°• ⚠ •°•══════════════•°• ⚠ •°•══════════════•°• ⚠ •°•═══════",
            "*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*＊✿❀　❀✿＊*",
            "ღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღღ꧁ღ╭⊱ꕥꕥ⊱╮ღ꧂ღ",
            "■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■□■"
        };
        // postID : int
        // Posts : List (Post)

        // Konstruktor:
        // Innehåller Title, Content, Category, Header, Likes, ID, Date, Comments 

        // Metoder

        // Overridead ToString-metod
        // Gör en fin utskrift av ett inlägg med allt innehåll som parametrar

        // Lägga till inlägg:
        // Input för title, content och category
        // Tilldelar dagens datum till Date
        // Anropar Skapa ID-metoden
        // Lägger till nya inlägget i listan med alla inlägg

        // Skapa ID:
        // For-loop som räknar antalet inlägg som finns
        // Plussar på 1 på ID-countern för varje inlägg

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
