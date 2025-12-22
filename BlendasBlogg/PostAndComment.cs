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

        //Lägger till post (key) till dictionary
        public void AddPostToDictionary()
        {
            post.AddPost();
            postAndComments.Add(Post.PostList.Last(), new List<Comment>());

        }

        //Lägger till comment till listan (value)

        public void AddCommentToDictonary()
        {
            comment.AddComment();

            if (post.PostID == comment.PostCommentID)
            {
                if (!postAndComments.TryGetValue(Post.PostList[post.PostID], out List<Comment> list))
                {
                    list = new List<Comment>();
                    postAndComments.Add(Post.PostList[post.PostID], list);
                }
                list.Add(Comment.CommentList.Last());
            }
        }
        
        

        public void ListPosts()
        {
            foreach (var pair in postAndComments) 
            {
                Console.WriteLine("--------------------------------------------------------------\n");
                Console.WriteLine(pair.Key);
                Console.WriteLine(pair.Value);
                

                Thread.Sleep(1000);
            }
        }


    }
}

