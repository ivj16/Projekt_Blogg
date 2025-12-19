using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public int PostCommentID { get; set; }

        // Comments : List (key postID och value är comment)
        public List<Comment> CommentList = new List<Comment>();

        // Konstruktor:

        public Comment() { }
        // Innehåller mail, name, title, content, date, commentID
        public Comment(
            string commentMail, 
            string commentName, 
            string commentTitle, 
            string commentContent,
            int commentID,
            int postCommentID
        )
        {
            CommentMail = commentMail;
            CommentName = commentName;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
            CommentDate = DateTime.Now;
            CommentID = commentID;
            PostCommentID = postCommentID;
        }

        // Metoder

        // Skapa ID:
        // For-loop som räknar antalet kommentarer som finns
        // Plussar på 1 på ID-countern för varje kommentar

        public int ChoosePostID()
        {
            Console.Write("Ange ID på det inlägg du vill interagera med: ");
            int postCommentID = Convert.ToInt32(Console.ReadLine());
            return postCommentID;
        }

        // Lägga till kommentar:
        // Input för title, content, name och mail
        // Tilldelar dagens datum till Date
        // Anropar Skapa ID-metoden
        public void AddComment()
        {
            int commentID = 1;
            int postCommentID = ChoosePostID();

            Console.Write("\n Ange din e-postadress: ");
            string commentMail = Console.ReadLine();

            Console.Write("Ange ditt användarnamn: ");
            string commentName = Console.ReadLine();

            Console.WriteLine("\nSkriv in en titel för din kommentar: ");
            string CommentTitle = Console.ReadLine();

            Console.WriteLine("\nSkriv in innehållet för din kommentar: ");
            string commentContent = Console.ReadLine();

            Comment newComment = new Comment(commentMail, commentName, CommentTitle, commentContent, commentID++, postCommentID);
            CommentList.Add(newComment);
        }

       public override string ToString()
        {
            return $"{CommentName}\n" +
                   $"{CommentMail}\n" +
                   $"{CommentTitle}\n" +
                   $"{CommentContent}\n" +
                   $"Datum: {CommentDate}\n" +
                   $"Kommentar ID: {CommentID}\n" +
                   $"PostCommentID: {PostCommentID}";
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
