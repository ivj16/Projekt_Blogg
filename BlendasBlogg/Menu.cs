using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlendasBlogg
{
    public class Menu
    {
        public string userChoice;

        Post postObj = new Post();
        Comment commentObj = new Comment();
        PostAndComment postAndCommentObj = new PostAndComment();
        bool isLoggedIn = true;
        public void MainMenu()
        {
            Console.WriteLine("Välj ett av nedan val för det som du önskar göra idag:\n");
            Console.WriteLine("1, Jag är en användare som vill läsa bloggen \n2, Jag vill logga in som admin och få full kontroll över bloggen \n3, Jag har läst nog för idag och vill säga hejdå\n");
            Console.Write("Skriv den siffra som motsvara ditt val: ");
            userChoice = Console.ReadLine();
            Console.Clear();
        }

        public void UserMenu ()
        {
            Console.WriteLine("************************\n");
            Console.WriteLine("Så kul att du hittat hit! Det finns massor av kul att läsa om och kommentera gärna och dela med dig av dina historier\n\n");
            Console.WriteLine("Vad är du intresserad av att läsa om idag?\n");
            Console.WriteLine("1, Jag vill läsa alla inlägg från alla kategorier! \n2, Lista alla inlägg utifrån en kategori \n3, Jag vill söka efter ett inlägg");
            Console.Write("Skriv den siffra som motsvara ditt val: ");
            userChoice = Console.ReadLine();
            Console.Clear();

            switch (userChoice)
            {
                // case 1: Lista alla inlägg
                case "1":
                    postAndCommentObj.ListPosts();


        Console.WriteLine("Vill du interagera med inlägget?");
                    Console.WriteLine("1, Ge innlägget en tumme upp\n" +
                        "2, Ge inlägget en tumme ner\n" +
                        "3, Kommentera\n" +
                        "4, Återvänd till användarmenyn ");
                    userChoice = Console.ReadLine();
                    Console.Clear();

                    switch (userChoice)
                    {
                        case "1":
                            //anropa metod för att gilla inlägget
                            break;
                        case "2":
                            //anropa metod för att ogilla inlägget
                            break;
                        case "3":
                            //anropa metod för att kommentera inlägget
                            postAndCommentObj.AddCommentToDictonary();

                            break;
                        case "4":
                            //gå tillbaka till användarmenyn
                            break;
                    }
                    //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                    break;

                // case 2: Lista alla inlägg utifrån kategori
                case "2":
                    postObj.ListPostFromCategory();
                    
                    //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                    break;

                //case 3: Söka efter inlägg
                case "3":
                    //Inläggssök-meny. Användaren får välja vilket sätt den vill söka på:
                    switch (userChoice)
                    {
                        //case 1: Sök efter rubrik
                        case "1":

                            //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                            break;

                        //case 2: Sök efter kategori
                        case "2":
                            //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                            break;

                        //case 3: Sök efter fritext
                        case "3":
                            //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                            break;
                    }
                    break;
            }

        }

        public void AdminMenu ()
        {
            UserInfo user = new UserInfo();
            Console.WriteLine("************************\n");
            Console.WriteLine("Välkommen Blenda! Eller är det verkligen du??\n\n");
            Console.Write("Skriv in ditt användarnamn: ");
            user.Username = Console.ReadLine();
            Console.Write("Skriv in ditt lösenord: ");
            user.Password = Console.ReadLine();
            Console.Clear();

            //IF-sats för att kolla användarnamn och lösenord
            if (user.Username == user.BlendasUsername && user.Password == user.BlendasPassword)
            {
                while (isLoggedIn)
                {
                    Console.WriteLine("Du är inloggad som admin\n");
                    Console.WriteLine("1, Skapa ett nytt inlägg  \n" +
                        "2, Redigera ett befintligt inlägg eller ta bort en kommentar \n" +
                        "3, Ta bort ett inlägg\n" +
                        "4, Logga ut");
                    Console.Write("Skriv den siffra som motsvara ditt val: ");
                    userChoice = Console.ReadLine();
                    Console.Clear();

                    switch (userChoice)
                    {
                        //case 1: Skapa nytt inlägg
                        case "1":
                            postAndCommentObj.AddPostToDictionary();
                            Console.Clear();

                            //anropa metod från Post-klassen för att skapa nytt inlägg
                            break;

                        //case 2: Redigera befintligt inlägg eller ta bort kommentarer
                        case "2":
                            //Lista alla inlägg med ID - via metod från Post-klassen
                            //Ta input från användaren för att välja inlägg att redigera
                            //Anropa redigera inlägg-metoden från Post-klassen
                            break;

                        //case 3: Ta bort inlägg
                        case "3":

                            postObj.RemovePost();
                            Console.Clear();
                            //Liknande upplägg som för användare när inlägg listas - metod från Post-klassen.

                            //if-else-sats för att välja ta bort eller gå tillbaka till admin-menyn
                            break;

                        //case 4: Logga ut
                        case "4":
                            isLoggedIn = false;

                            Console.WriteLine("Du har loggats ut från admin-kontot.\n");

                            Thread.Sleep(2000);
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.\n");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("`\nDu är inte Blenda, vänligen gå in som användare i stället.");
                Console.WriteLine("PS. Om du faktiskt är Blenda så skrev du in fel inloggningsuppgifter. Försök igen!\n");
            }
        }
    }
}
