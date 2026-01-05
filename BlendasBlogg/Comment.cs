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
        int commentID = 1;

        public int PostCommentID { get; set; }

        public int PostLikeID { get; set; }

        // Comments : List (key postID och value är comment)
        static public List<Comment> CommentList = new List<Comment>();

        static public List<KeyValuePair<int, int>> LikesList = new List<KeyValuePair<int, int>>();

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



        // Lägga till kommentar:
        // Input för title, content, name och mail
        // Tilldelar dagens datum till Date
        // Anropar Skapa ID-metoden

        //public int ChoosePostID()
        //{
        //    Console.Write("Ange ID på det inlägg du vill interagera med: ");
        //    postCommentID = Convert.ToInt32(Console.ReadLine());
        //    return postCommentID;
        //}
        public void AddComment()
        {
            Console.Write("Ange ID på det inlägg du vill interagera med: ");
            int postCommentID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.Write("\nAnge din e-postadress: ");
            string commentMail = Console.ReadLine();

            Console.Write("\nAnge ditt användarnamn: ");
            string commentName = Console.ReadLine();

            Console.WriteLine("\nSkriv in en titel för din kommentar: ");
            string CommentTitle = Console.ReadLine();

            Console.WriteLine("\nSkriv in innehållet för din kommentar: ");
            string commentContent = Console.ReadLine();

            Comment newComment = new Comment(commentMail, commentName, CommentTitle, commentContent, commentID++, postCommentID);
            CommentList.Add(newComment);

            Console.Clear();
            Console.WriteLine("Kommentaren har laddats upp!");
            Thread.Sleep(1500);
        }

        public override string ToString()
        {
            return $"Användare: {CommentName}, {CommentMail}\n" +
                   $"\n{CommentTitle}\n" +
                   $"\n{CommentContent}\n" +
                   $"\nDatum: {CommentDate}\n" +
                   $"Kommentars-ID: {CommentID}\n" +
                   $"------------------";
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

        public void RemoveComment()
        {
            foreach (Comment comment in CommentList)
            {
                Console.WriteLine(comment);
                Console.WriteLine("-----------------------------\n");
            }

            Console.Write("Ange ID på den kommentar du vill ta bort: ");
            int idChoice = Convert.ToInt32(Console.ReadLine());
            foreach (Comment comment in CommentList)
            {
                if (comment.commentID == idChoice)
                {
                    CommentList.Remove(comment);
                   
                    Console.Clear();
                    Console.WriteLine("Kommentaren har tagits bort!");
                    Thread.Sleep(1500);
                    break;
                }
                else
                {
                    Console.WriteLine("Kommentaren med det ID:t finns inte.");
                    break;
                }
            }
        }
    }
}
