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
        Comment comment = new Comment();


        public PostAndComment() { }


        bool hasComment;
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

    }
}

