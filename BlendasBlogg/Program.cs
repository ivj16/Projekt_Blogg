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
            Post.PostList.Add(new Post(1, "Välkommen till Blendas Blogg!", "Hej och välkommen till min blogg! Här kommer jag att dela med mig \nav mina tankar, idéer och äventyr. Hoppas du gillar det!", Category.Nyheter, 1, 0, 0));
            Post.PostList.Add(new Post(4, "Ordspråk med mumsig twist!", "Brukar du säga \"Som man bäddar får man ligga?\" Då tycker jag du \nkan lägga till en fika-twist och istället säga \n\"Som man bakar får man fika!\" :D", Category.Ordspråk, 2, 0, 0));
            Post.PostList.Add(new Post(0, "Du är snabbare än du tror!", "I alla fall när du är sjuk... Visste du att nysningar kan nå \nupp till 160 km/h i hastighet?! Det är snabbare än en \nkategori 1 orkan!", Category.FunFact, 3, 0, 0));
            
            menu.MainMenu();
            
            
        }
    }
}
