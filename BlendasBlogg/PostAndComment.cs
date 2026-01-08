using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public  class PostAndComment
    {
        //Fields
        string userChoice;
        bool hasComment;
        public bool hasPrinted = false;
        bool isInvalid = false;

        //Objects
        Post postObj = new Post();
        Comment commentObj = new Comment();

        //Konstruktor
        public PostAndComment() { }


        // Skriva ut alla inlägg:
        // Foreach-loop som skriver ut alla inlägg med en egen ToString-metod
        public void ListPosts()
        {
            hasPrinted = false;
            foreach (var post in Post.PostList) 
            {
                Console.WriteLine(post);
                hasComment = false;
                hasPrinted = true;

                foreach (Comment comment in Comment.CommentList)
                {
                    if (comment.PostCommentID == post.PostID)
                    {
                        hasComment = true;
                        Console.WriteLine(comment);
                    }
                }

                if (!hasComment)
                {
                    Console.WriteLine("Inga kommentarer ännu\n");
                }
                Console.WriteLine("------------------------------------------------------------------\n\n");
                Thread.Sleep(1000);
            }
        }

        // Skriva ut inlägg från kategori:
        // Input för vilken kategori som ska skrivas ut - Variabel : categoryChoice : string
        // If-sats som skriver ut inläggen som matchar en vald kategori
        public void ListPostFromCategory()
        {
            hasPrinted = false;
            postObj.CategoryChoice();
            foreach (Post post in Post.PostList)
            {
                if (post.Category == postObj.categoryChoice)
                {  
                    Console.WriteLine(post);
                    hasComment = false;
                    hasPrinted = true;

                    foreach (Comment comment in Comment.CommentList)
                    {
                        if (comment.PostCommentID == post.PostID)
                        {
                            hasComment = true;
                            Console.WriteLine(comment);
                        }
                    }

                    if (!hasComment)
                    {
                        Console.WriteLine("Inga kommentarer ännu\n");
                    }
                    Thread.Sleep(1000);
                }
            }
        }


        // Söka på inlägg:

        public void SearchPostTitle() 
        {
            hasPrinted = false;
            Console.WriteLine("Här kan du hitta ett inlägg genom att söka på rubriken på inlägget.");
            Console.Write("Skriv in sökordet här: ");
            string searchTitle = Console.ReadLine();

            foreach (Post post in Post.PostList)
            {
                if (post.Title.ToLower().Contains(searchTitle.ToLower()))
                {
                    Console.WriteLine(post);
                    hasComment = false;
                    hasPrinted = true;

                    foreach (Comment comment in Comment.CommentList)
                    {
                        if (comment.PostCommentID == post.PostID)
                        {
                            hasComment = true;
                            Console.WriteLine(comment);
                        }
                    }

                    if (!hasComment)
                    {
                        Console.WriteLine("Inga kommentarer ännu\n");
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public void SearchPostContent()
        {
            hasPrinted = false;
            Console.WriteLine("Här kan du hitta ett inlägg genom att söka på ett ord som inlägget innehåller");
            Console.Write("Skriv in sökordet här: ");
            string searchContent = Console.ReadLine();

            foreach (Post post in Post.PostList)
            {
                if (post.Content.ToLower().Contains(searchContent.ToLower()))
                {
                    Console.WriteLine(post);
                    hasComment = false;
                    hasPrinted = true;

                    foreach (Comment comment in Comment.CommentList)
                    {
                        if (comment.PostCommentID == post.PostID)
                        {
                            hasComment = true;
                            Console.WriteLine(comment);
                        }
                    }

                    if (!hasComment)
                    {
                        Console.WriteLine("Inga kommentarer ännu\n");
                    }
                }
                Thread.Sleep(1000);
            }
        }

        //Utifrån ID ska användaren kunna välja att gilla eller kommentera,
        //alternativt gå tillbaka till huvudmenyn
        public void InteractWithPost()
        {
            Console.WriteLine("Vill du interagera med ett inlägg?");
            Console.WriteLine("\n1, Ge en tumme upp" +
                "\n2, Ge en tumme ner" +
                "\n3, Kommentera" +
                "\n4, Återvänd till användarmenyn");
            Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
            do
            {
                userChoice = Console.ReadLine();
                isInvalid = false;

                switch (userChoice)
                {
                    case "1":
                        //anropa metod för att gilla inlägget                      
                        postObj.LikePost();
                        Console.Clear();
                        break;
                    case "2":
                        //anropa metod för att ogilla inlägget
                        postObj.DislikePost();
                        Console.Clear();
                        break;
                    case "3":
                        //anropa metod för att kommentera inlägget
                        commentObj.AddComment();
                        Console.Clear();
                        break;
                    case "4":
                        //Går tillbaka till användarmenyn
                        Console.Clear();
                        Post.BackToMenuMessage();
                        break;
                    default:
                        Console.Write("\nOgiltigt val, välj ett av alternativen från menyn, skriv endast siffran: ");
                        isInvalid = true;
                        break;

                }
            } while (isInvalid);
        }
    }
}

