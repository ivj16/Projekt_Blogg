namespace BlendasBlogg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Objects
            Menu menu = new Menu();

            Console.WriteLine("************ Blendas Blogg ************");
            Console.WriteLine("En blogg av Blenda blogger, för dig som vill veta så mycket onödigt som möjligt!\n");
            
            menu.MainMenu();
            
            
        }
    }
}
