using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public class Comment
    {
        // Title : string
        // Content : string
        // Date : dagens datum
        // Name : string
        // Mail : string
        // commentID : int
        // Comments : List (key postID och value är comment)

        // Konstruktor:
        // Innehåller mail, name, title, content, date, commentID

        // Metoder

        // Skapa ID:
        // For-loop som räknar antalet kommentarer som finns
        // Plussar på 1 på ID-countern för varje kommentar

        // Lägga till kommentar:
        // Input för title, content, name och mail
        // Tilldelar dagens datum till Date
        // Anropar Skapa ID-metoden
        // Lägger till nya kommentaren i listan med alla kommentarer

        // Ta bort kommentar:
        // Välj en kommentar via ID - variabel : idChoice : int
        // Ta bort kommentaren ur listan med alla kommentarer

        // Gilla / ogilla
        // Input för om man vill likea eller dislikea - Variabel : likeChoice : string
        // Switch-case eller if-sats som gör Likes++ eller Likes-- beroende på valet
    }

}
