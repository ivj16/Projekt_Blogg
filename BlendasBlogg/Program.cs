namespace BlendasBlogg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ TITEL ************");
            Console.WriteLine("En blogg av Blenda blogger, för dig som vill veta så mycket onödigt som möjligt\n");

            bool isRunAgain = true;
            string userChoice;
            Menu menu = new Menu();

            //while-loop som skriver ut menyn tills användaren väljer att avsluta
            //switch-sats för att hantera användarens val utifrån en meny
            while (isRunAgain)
            {
                menu.MainMenu();

                switch (menu.userChoice)
                {
                    case "1":
                        //användarmenyn
                        menu.UserMenu();
                        break;

                    case "2":
                        //adminmenyn
                        menu.AdminMenu();
                        break;

                    //case 3: avsluta programmet
                    case "3":
                        Console.WriteLine("Hejdå!");
                        isRunAgain = false;
                        break;
                }
            }
        }
    }
}
