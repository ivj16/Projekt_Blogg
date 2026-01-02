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

        public void ListPosts()
        {

            foreach (var post in Post.PostList) 
            {
                Console.WriteLine("--------------------------------------------------------------\n");
                Console.WriteLine(post);
                foreach (Comment comment in Comment.CommentList)
                {
                    if (comment.PostCommentID == post.PostID)
                    {
                        Console.WriteLine(comment);
                    }
                }
                
                Thread.Sleep(1000);
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
                    foreach (Comment comment in Comment.CommentList)
                    {
                        if (comment.PostCommentID == post.PostID)
                        {
                            Console.WriteLine(comment);
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }

    }
}

