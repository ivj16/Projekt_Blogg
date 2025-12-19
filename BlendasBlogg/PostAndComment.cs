using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public  class PostAndComment
    {

        Post post = new Post();
        Comment comment = new Comment();

        public PostAndComment() { }

        //dictionary med inlägg och kommentarer
        
        Dictionary<Post, List<Comment>> postAndComments = new Dictionary<Post, List<Comment>>();

        public void AddPostAndComment(Post post, Comment comment)
        {
            if (postAndComments.ContainsKey(post))
            {
                postAndComments[post].Add(comment);
            }
            else
            {
                postAndComments[post] = new List<Comment> { comment };
            }
        }

        public void ListPosts()
        {
            foreach (Post post in post.PostList)
            {
                Console.WriteLine("--------------------------------------------------------------\n");
                Console.WriteLine(post);
                PrintCommentsForPost(post);

                Thread.Sleep(1000);
            }
        }

        public void PrintCommentsForPost(Post post)
        {
            if (postAndComments.ContainsKey(post))
            {
                Console.WriteLine("************************************************************************************");
                Console.WriteLine($"Kommentarer för inlägg {post.PostID}:");
                foreach (var comment in postAndComments[post])
                {
                    if (post.PostID == comment.PostCommentID)
                    {
                        Console.WriteLine($"- {comment.CommentTitle} av {comment.CommentName} den {comment.CommentDate}");
                        Console.WriteLine($"  {comment.CommentContent}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Inga kommentarer för detta inlägg.");
            }
        }
    }
}
