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

        public void AddPostToDictionary()
        {
            post.AddPost();
            postAndComments.Add(Post.PostList.Last(), new List<Comment> { comment });
        }

        public int ChoosePostID()
        {
            Console.Write("Ange ID på det inlägg du vill interagera med: ");
            int postCommentID = Convert.ToInt32(Console.ReadLine());
            return postCommentID;
        }

        public void AddPostAndComment()
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
            
            foreach (Post post in postAndComments)
            if (post.PostID == comment.PostCommentID)
            {
                postAndComments[post].Add(newComment);
                }

        }

        public void ListPosts()
        {
            foreach (Post post in Post.PostList)
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
