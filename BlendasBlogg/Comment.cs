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
        //Fields
        bool isFound = false;
        bool isInvalid = true;
        int postCommentID;
        int commentID = 1;
        int idChoice;
        string commentMail;
        string commentName;
        string commentTitle;
        string commentContent;
        public DateOnly commentDate;
        DateTime dateNow = DateTime.Now;

        // Properties
        public string CommentTitle { get; set; }

        public string CommentContent { get; set; }

        

        public string CommentName { get; set; }

        public string CommentMail { get; set; }

        public int CommentID { get; set; }

        public int PostCommentID { get; set; }

        // Comments : List
        static public List<Comment> CommentList = new List<Comment>();

        Post postObj = new Post();

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
            commentDate = DateOnly.FromDateTime(dateNow);
            CommentID = commentID;
            PostCommentID = postCommentID;
        }

        // Metoder

        //ToString-metod för att skriva ut kommentarer
        public override string ToString()
        {
            return $">> {CommentName} ({CommentMail}) skrev: {CommentTitle} || {commentDate}, ID: {CommentID} |\n" +
                   $"   {CommentContent}\n";
        }

        // Lägga till kommentar:
        public void AddComment()
        {
            Console.Write("\nAnge ID:t för det inlägg du vill interagera med och tryck sedan enter: ");

            //Kontrollerar att det angivna värdet är en siffra (som kan konverteras till int) samt matchar med ett inlägg
            isInvalid = true;
            while (isInvalid)
            {
                isFound = false;
                try
                {
                    postCommentID = Convert.ToInt32(Console.ReadLine());
                    foreach (Post post in Post.PostList)
                    {
                        if (post.PostID == postCommentID)
                        {
                            isInvalid = false;
                            isFound = true;
                            break;
                        }
                    }
                    if(!isFound)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.Write("\nOgiltigt val, skriv ID för ett existerande inlägg: ");
                }
            }

            Console.Clear();

            // Tar in uppgifter om användaren
            Console.Write("\nAnge din e-postadress och tryck sedan enter: ");
            isInvalid = true;
            while (isInvalid)
            {
                commentMail = Console.ReadLine();

                if (!commentMail.Contains('@'))
                {
                    Console.Write("\nOgiltig inmatning, skriv en riktig e-postadress:");
                }
                else
                {
                    isInvalid= false;
                }
            }

            Console.Write("\nAnge ditt användarnamn och tryck sedan enter: ");
            isInvalid= true;
            while (isInvalid)
            {
                commentName = Console.ReadLine();
                if (commentName == "")
                {
                    Console.Write("Obligatoriskt fält, ange ditt användarnamn: ");
                }
                else
                {
                    isInvalid = false;
                }
            }

            Console.WriteLine("\nSkriv in en titel för din kommentar och tryck sedan enter: ");
            isInvalid = true;
            while (isInvalid)
            {
                commentTitle = Console.ReadLine();
                if (commentTitle == "")
                {
                    Console.WriteLine("Obligatoriskt fält, ange titel för kommentar: ");
                }
                else
                {
                    isInvalid = false;
                }
            }

            Console.WriteLine("\nSkriv in innehållet för din kommentar och tryck sedan enter: ");
            isInvalid = true;
            while (isInvalid)
            {
                commentContent = Console.ReadLine();

                //Ser till att ingen användare kan "spamma" tomma kommentarer 
                if (commentContent == "")
                {
                    Console.WriteLine("Obligatoriskt fält, ange innehåll för kommentar: ");
                }
                else
                {
                    isInvalid = false;
                }
            }

            // Lägger till nya kommentaren i listan med alla kommentarer
            Comment newComment = new Comment(commentMail, commentName, commentTitle, commentContent, commentID++, postCommentID);
            CommentList.Add(newComment);

            Console.Clear();
            Console.WriteLine("Kommentaren har laddats upp!");
            Menu.BackToMenuMessage();
        }

        // Ta bort kommentar:
        public void RemoveComment()
        {
            // Ser till att bara gå vidare om det finns några kommentarer tillagda, annars skrivs passande felmeddelande ut
            if (CommentList.Count > 0)
            {
                isFound = false;
                foreach (Comment comment in CommentList)
                {
                    Console.WriteLine(comment);
                    Console.WriteLine("-----------------------------\n");
                }              
                    Console.Write("\nAnge ID på den kommentar du vill ta bort, eller ange \"0\" för att gå tillbaka: ");

                //Do-while som kör om tills matchande värde matas in
                do
                {

                    //Do-while som kontrollerar om input är ett giltigt värde (siffra som kan konverteras till int). 
                    do
                    {
                        isInvalid = false;
                        try
                        {
                            idChoice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Write("\nOgiltigt val, skriv ett giltigt ID med endast siffror: ");
                            isInvalid = true;
                        }
                    } while (isInvalid);

                    foreach (Comment comment in CommentList)
                    {
                        //Kontrollerar om input matchar en kommentar, alternativt "0" vilket innebär att gå tillbaka till admin-menyn
                        if (comment.CommentID == idChoice)
                        {
                            CommentList.Remove(comment);
                            isFound = true;
                            Console.Clear();
                            Console.WriteLine("Kommentaren har tagits bort!");
                            Menu.BackToMenuMessage();
                            break;
                        }
                        else if (idChoice == 0)
                        {
                            isFound = true;
                            Console.Clear();
                            Menu.BackToMenuMessage();
                            break;
                        }

                    }
                    if (!isFound)
                    {
                        Console.Write("\nOgiltigt val, skriv ett giltigt ID med endast siffror: ");
                    }

                } while (!isFound);
            }
            else
            {
                Console.WriteLine("Det finns inga kommentarer att ta bort.");
                Menu.BackToMenuMessage();
            }
        }
    }
}
