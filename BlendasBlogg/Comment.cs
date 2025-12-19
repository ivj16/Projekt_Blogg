using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public class Comment
    {
        // Title : string
        public string CommentTitle { get; set; }

        // Content : string
        public string CommentContent { get; set; }

        // Date : dagens datum
        public DateTime CommentDate = DateTime.Now;

        // Name : string
        public string CommentName { get; set; }

        // Mail : string
        public string CommentMail { get; set; }
        
        // commentID : int
        public int CommentID { get; set; }

        // Comments : List (key postID och value är comment)
        public List<Comment> CommentList = new List<Comment>();

        // Konstruktor:

        public Comment() { }
        // Innehåller mail, name, title, content, date, commentID
        public Comment(
            string commentMail, 
            string commentName, 
            string commentTitle, 
            string commentContent
        )
        {
            CommentMail = commentMail;
            CommentName = commentName;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
            CommentDate = DateTime.Now;
            CreateCommentID();
        }

        // Metoder

        // Skapa ID:
        // For-loop som räknar antalet kommentarer som finns
        // Plussar på 1 på ID-countern för varje kommentar
        int commentIdCounter = 0;
        public int CreateCommentID()
        {
            commentIdCounter = 0;
            for (int i = 0; i <= CommentList.Count; i++)
            {
                commentIdCounter++;
            }
            return commentIdCounter;
        }

        // Lägga till kommentar:
        // Input för title, content, name och mail
        // Tilldelar dagens datum till Date
        // Anropar Skapa ID-metoden
        public void AddComment()
        {
            Console.Write("\n Ange din e-postadress: ");
            string commentMail = Console.ReadLine();

            Console.Write("Ange ditt användarnamn: ");
            string commentName = Console.ReadLine();

            Console.WriteLine("\nSkriv in en titel för din kommentar: ");
            string CommentTitle = Console.ReadLine();

            Console.WriteLine("\nSkriv in innehållet för din kommentar: ");
            string commentContent = Console.ReadLine();

            Comment newComment = new Comment(commentMail, commentName, CommentTitle, commentContent);
            CommentList.Add(newComment);
        }

       public override string ToString()
        {
            return $"{CommentName}\n" +
                   $"{CommentMail}\n" +
                   $"{CommentTitle}\n" +
                   $"{CommentContent}\n" +
                   $"Datum: {CommentDate}\n" +
                   $"Kommentar ID: {CommentID}\n";
        }

        public void PrintComments()
        {
            foreach (Comment comment in CommentList)
            {
                Console.WriteLine(comment);
            }
        }

            // Lägger till nya kommentaren i listan med alla kommentarer

            // Ta bort kommentar:
            // Välj en kommentar via ID - variabel : idChoice : int
            // Ta bort kommentaren ur listan med alla kommentarer

            // Gilla / ogilla
            // Input för om man vill likea eller dislikea - Variabel : likeChoice : string
            // Switch-case eller if-sats som gör Likes++ eller Likes-- beroende på valet
        }

}
