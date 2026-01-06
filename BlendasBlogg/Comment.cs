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
        bool isInvalid = true;
        int postCommentID;
        string commentMail;
        string commentName;
        string commentTitle;
        string commentContent;
        Post postObj = new Post();
        
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

        // Comments : List
        static public List<Comment> CommentList = new List<Comment>();

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

        public override string ToString()
        {
            return $"Användare: {CommentName}, {CommentMail}\n" +
                   $"\n{CommentTitle}\n" +
                   $"\n{CommentContent}\n" +
                   $"\nDatum: {CommentDate}\n" +
                   $"Kommentars-ID: {CommentID}\n" +
                   $"------------------";
        }

        // Metoder

        // Lägga till kommentar:
        // Input för title, content, name och mail
        // Tilldelar dagens datum till Date

        public void AddComment()
        {
            Console.Write("Ange ID:t för det inlägg du vill interagera med: ");
            isInvalid = true;
            while (isInvalid)
            {
                try
                {
                    postCommentID = Convert.ToInt32(Console.ReadLine());
                    foreach (Post post in Post.PostList)
                        if (post.PostID == postCommentID)
                        {
                            isInvalid = false; 
                            break;                     
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val, skriv ID för ett existerande inlägg");
                        }
                }
                catch
                {
                    Console.WriteLine("Ogiltigt val, skriv ID för ett existerande inlägg");
                    Thread.Sleep(3000);
                }
            }

            Console.Clear();

            Console.Write("\nAnge din e-postadress: ");
            isInvalid = true;
            while (isInvalid)
            {
                commentMail = Console.ReadLine();

                if (!commentMail.Contains('@'))
                {
                    Console.WriteLine("Ogiltig inmatning, skriv en riktig e-postadress.");
                }
                else
                {
                    isInvalid= false;
                }
            }

            Console.Write("\nAnge ditt användarnamn: ");
            isInvalid= true;
            while (isInvalid)
            {
                commentName = Console.ReadLine();
                if (commentName == "")
                {
                    Console.WriteLine("Obligatoriskt fält, ange ditt användarnamn: ");
                }
                else
                {
                    isInvalid = false;
                }
            }

            Console.WriteLine("\nSkriv in en titel för din kommentar: ");
            isInvalid = true;
            while (isInvalid)
            {
                commentTitle = Console.ReadLine();
                if (commentTitle == "")
                {
                    Console.WriteLine("Obligatoriskt fält, ange titel för kommentar");
                }
                else
                {
                    isInvalid = false;
                }
            }

            Console.WriteLine("\nSkriv in innehållet för din kommentar: ");
            isInvalid = true;
            while (isInvalid)
            {
                commentContent = Console.ReadLine();
                if (commentContent == "")
                {
                    Console.WriteLine("Obligatoriskt fält, ange innehåll för kommentar");
                }
                else
                {
                    isInvalid = false;
                }
            }

            // Lägger till nya kommentaren i listan med alla kommentarer
            Comment newComment = new Comment(commentMail, commentName, CommentTitle, commentContent, commentID++, postCommentID);
            CommentList.Add(newComment);

            Console.Clear();
            Console.WriteLine("Kommentaren har laddats upp!");
            Thread.Sleep(1500);
        }

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

            Console.Write("Ange ID på den kommentar du vill ta bort, eller ange \"0\" för att gå tillbaka: ");
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
                else if (idChoice == 0)
                {
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
