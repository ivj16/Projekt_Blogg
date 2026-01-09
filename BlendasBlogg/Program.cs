namespace BlendasBlogg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Objects
            Menu menu = new Menu();
            Post post = new Post();

            Console.WriteLine("************ Blendas Blogg ************");
            Console.WriteLine("En blogg av Blenda blogger, för dig som vill veta så mycket onödigt som möjligt!\n");

            // Default posts som laddas in i listan vid start av programmet

            post.CreateDefaultPosts();

            menu.MainMenu();
            
            
        }
    }
}
