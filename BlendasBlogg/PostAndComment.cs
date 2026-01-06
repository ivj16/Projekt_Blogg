using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public  class PostAndComment
    {

        Post postObj = new Post();
        Comment commentObj = new Comment();


        public PostAndComment() { }


        bool hasComment;

        // Skriva ut alla inlägg:
        // Foreach-loop som skriver ut alla inlägg med en egen ToString-metod
        public void ListPosts()
        {

            foreach (var post in Post.PostList) 
            {
                Console.WriteLine("--------------------------------------------------------------\n");
                Console.WriteLine(post);
                Console.WriteLine("******************* Kommentarer *******************");
                hasComment = false;

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

                Thread.Sleep(500);
            }
        }

        // Skriva ut inlägg från kategori:
        // Input för vilken kategori som ska skrivas ut - Variabel : categoryChoice : string
        // If-sats som skriver ut inläggen som matchar en vald kategori
        public void ListPostFromCategory()
        {
            postObj.CategoryChoice();
            foreach (Post post in Post.PostList)
            {
                if (post.Category == postObj.categoryChoice)
                {
                    Console.WriteLine("--------------------------------------------------------------\n");
                    Console.WriteLine(post);
                    Console.WriteLine("******************* Kommentarer *******************");
                    hasComment = false;

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
                    Thread.Sleep(500);
                }
            }
        }


        // Söka på inlägg:
        // Input för sökord inom den valda delen - Variabel : searchWord : string
        // För varje del som går att söka igenom:
        // Foreach-loop som går igenom alla inlägg
        // If-sats som skriver ut de som matchar sökordet
        public void SearchPostTitle() 
        {
            Console.WriteLine("Här kan du hitta ett inlägg genom att söka på rubriken på inlägget.");
            Console.Write("Skriv in sökordet här: ");
            string searchTitle = Console.ReadLine();

            foreach (Post post in Post.PostList)
            {
                if (post.Title.ToLower().Contains(searchTitle.ToLower()))
                {
                    Console.WriteLine(post);
                    Console.WriteLine("******************* Kommentarer *******************");
                    hasComment = false;

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
                    Thread.Sleep(500);
                }
            }
        }

        public void SearchPostContent()
        {
            Console.WriteLine("Här kan du hitta ett inlägg genom att söka på ett ord som inlägget innehåller");
            Console.Write("Skriv in sökordet här: ");
            string searchContent = Console.ReadLine();

            foreach (Post post in Post.PostList)
            {
                if (post.Content.ToLower().Contains(searchContent.ToLower()))
                {
                    Console.WriteLine(post);
                    Console.WriteLine("******************* Kommentarer *******************");
                    hasComment = false;

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
                    Thread.Sleep(500);
                }
            }
        }

        //Utifrån ID ska användaren kunna välja att gilla eller kommentera,
        //alternativt gå tillbaka till huvudmenyn
        public void InteractWithPost()
        {
            string userChoice;
            Console.WriteLine("Vill du interagera med ett inlägg?");
                        Console.WriteLine("\n1, Ge en tumme upp" +
                            "\n2, Ge en tumme ner" +
                            "\n3, Kommentera" +
                            "\n4, Återvänd till användarmenyn");
                        Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
                        userChoice = Console.ReadLine();


            switch (userChoice)
            {
                case "1":
                    //anropa metod för att gilla inlägget
                    postObj.LikePost();
                    break;
                case "2":
                    //anropa metod för att ogilla inlägget
                    postObj.DislikePost();
                    break;
                case "3":
                    //anropa metod för att kommentera inlägget
                    commentObj.AddComment();
                    Console.Clear();
                    break;
                default:
                    //gå tillbaka till användarmenyn
                    Console.Clear();
                    break;

            }
        }
    }
}

