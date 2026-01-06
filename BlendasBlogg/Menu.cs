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
        //Fields
        public string userChoice;
        bool isInMenu = true;

        //Objects
        Post postObj = new Post();
        Comment commentObj = new Comment();
        PostAndComment postAndCommentObj = new PostAndComment();
        Subscriber subscriberObj = new Subscriber();
        UserInfo user = new UserInfo();


        public void MainMenu()
        {
            Console.WriteLine("Välj ett av nedan val för det som du önskar göra idag:");
            Console.WriteLine("\n1, Jag är en användare som vill läsa bloggen " +
                "\n2, Jag vill logga in som admin och få full kontroll över bloggen " +
                "\n3, Jag har läst nog för idag och vill säga hejdå");
            Console.Write("\nSkriv den siffra som motsvara ditt val: ");
            userChoice = Console.ReadLine();
            Console.Clear();


        }

        public void UserMenu ()
        {
            Console.WriteLine("Så kul att du hittat hit! Det finns massor av kul att läsa om och kommentera gärna och dela med dig av dina historier\n\n");
            isInMenu = true;
            while (isInMenu) {
                Console.WriteLine("Vad är du intresserad av att läsa om idag?\n");
                Console.WriteLine("\n1, Jag vill läsa alla inlägg från alla kategorier!" +
                    "\n2, Lista alla inlägg utifrån en kategori" +
                    "\n3, Jag vill söka efter ett inlägg" +
                    "\n4, Jag vill prenumerera på bloggen" +
                    "\n5, Gå tillbaka till huvudmenyn");
                Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
                userChoice = Console.ReadLine();
                Console.Clear();

                switch (userChoice)
                {
                    // case 1: Lista alla inlägg
                    case "1":
                        postAndCommentObj.ListPosts();
                        postAndCommentObj.InteractWithPost();
                        break;

                    // case 2: Lista alla inlägg utifrån kategori
                    case "2":
                        postAndCommentObj.ListPostFromCategory();
                        postAndCommentObj.InteractWithPost();
                        break;

                    //case 3: Söka efter inlägg
                    case "3":
                        //Inläggssök-meny. Användaren får välja vilket sätt den vill söka på:
                        Console.WriteLine("Nu ska vi leta reda på inlägget du söker! Hur vill du söka efter det?" +
                            "\n1, Sök efter rubrik" +
                            "\n2, Sök efter kategori" +
                            "\n3, Sök efter fritext" +
                            "\n4, Gå tillbaka");
                        Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
                        userChoice = Console.ReadLine();

                        switch (userChoice)
                        {
                            //case 1: Sök efter rubrik
                            case "1":
                                postAndCommentObj.SearchPostTitle();
                                postAndCommentObj.InteractWithPost();
                                break;

                            //case 2: Sök efter kategori
                            case "2":
                                postAndCommentObj.ListPostFromCategory();
                                postAndCommentObj.InteractWithPost();
                                break;

                            //case 3: Sök efter fritext
                            case "3":
                                postAndCommentObj.SearchPostContent();
                                postAndCommentObj.InteractWithPost();
                                break;

                            case "4":
                                Thread.Sleep(1000);
                                Post.BackToMenuMessage();
                                break;

                            default:
                                Console.WriteLine("Ogiltigt val, välj ett av alternativen från menyn, skriv endast siffran.");
                                Thread.Sleep(2500);
                                Console.Clear();
                                break;
                        }
                        break;

                    case "4":
                        subscriberObj.AddSubscriber();
                        break;


                    case "5":
                        Post.BackToMenuMessage();
                        isInMenu = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, välj ett av alternativen från menyn, skriv endast siffran.");
                        Thread.Sleep(2500);
                        Console.Clear();
                        break;
                }
            }

        }

        public void AdminMenu ()
        {

            isInMenu = true;
            Console.WriteLine("Välkommen Blenda! Eller är det verkligen du??\n\n");
            Console.Write("Skriv in ditt användarnamn: ");
            user.Username = Console.ReadLine();
            Console.Write("Skriv in ditt lösenord: ");
            user.Password = Console.ReadLine();
            Console.Clear();

            
            //IF-sats för att kolla användarnamn och lösenord
            if (user.Username == user.BlendasUsername && user.Password == user.BlendasPassword)
            {   

                while (isInMenu)
                {
                    Console.WriteLine("Du är inloggad som admin\n");
                    Console.WriteLine("\n1, Skapa ett nytt inlägg" +
                        "\n2, Redigera ett befintligt inlägg" +
                        "\n3, Ta bort ett inlägg" +
                        "\n4, Ta bort en kommentar" +
                        "\n5, Visa en lista över prenumeranter" +
                        "\n6, Logga ut");
                    Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
                    userChoice = Console.ReadLine();
                    Console.Clear();

                    switch (userChoice)
                    {
                        //case 1: Skapa nytt inlägg
                        case "1":
                            //anropa metod från Post-klassen för att skapa nytt inlägg
                            postObj.AddPost();
                            Console.Clear();
                            break;

                        //case 2: Redigera befintligt inlägg eller ta bort kommentarer
                        case "2":
                            postObj.EditPost();
                            Console.Clear();
                            //Lista alla inlägg med ID - via metod från Post-klassen
                            //Ta input från användaren för att välja inlägg att redigera
                            //Anropa redigera inlägg-metoden från Post-klassen
                            break;

                        //case 3: Ta bort inlägg
                        case "3":

                            postObj.RemovePost();
                            Console.Clear();
                            break;

                        //case 4: Ta bort kommentar
                        case "4":
                            commentObj.RemoveComment();
                            Console.Clear();
                            break;

                        case "5":
                            if (Subscriber.SubscribersList.Count > 0)
                            {
                                while (isInMenu)
                                {
                                    subscriberObj.PrintSubscribers();
                                    Console.Write("Vill du ta bort en prenumerant?\n" +
                                    "\n1, Ja" +
                                    "\n2, Nej" +
                                    "\nSkriv siffran som motsvarar ditt val: ");
                                    
                                        userChoice = Console.ReadLine();
                                        switch (userChoice)
                                        {

                                            case "1":
                                                subscriberObj.RemoveSubscriber();
                                                isInMenu = false;
                                                break;

                                            case "2":
                                                Console.Clear();
                                                Console.WriteLine("Ingen prenumerant har tagits bort");
                                                Thread.Sleep(1000);
                                                Post.BackToMenuMessage();
                                                isInMenu = false;
                                                break;

                                            default:
                                                Console.Write("Ogiltigt val, välj ett av alternativen från menyn, skriv endast siffran: ");
                                                break;
                                        }
                                }
                                isInMenu = true;
                            }
                            break;

                        //case 4: Logga ut
                        case "6":
                            isInMenu = false;

                            Console.WriteLine("Du har loggats ut från admin-kontot.\n");
                            Thread.Sleep(1000);
                            Post.BackToMenuMessage();
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val, välj ett av alternativen från menyn, skriv endast siffran.");
                            Thread.Sleep(1500);
                            Post.BackToMenuMessage();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nDu är inte Blenda, vänligen gå in som användare i stället.");
                Console.WriteLine("PS. Om du faktiskt är Blenda så skrev du in fel inloggningsuppgifter. Försök igen!\n");
                Thread.Sleep(4000);
                Post.BackToMenuMessage();
            }
        }
    }
}
