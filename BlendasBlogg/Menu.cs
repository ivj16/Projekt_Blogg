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
        bool isInSecondMenu = true;
        bool isInvalid = false;
        bool isrunAgain = true;  

        //Objects
        Post postObj = new Post();
        Comment commentObj = new Comment();
        PostAndComment postAndCommentObj = new PostAndComment();
        Subscriber subscriberObj = new Subscriber();
        UserInfo user = new UserInfo();

        // Metoder:

        // Metod för att visa "går tillbaka till menyn"-meddelande:
        public static void BackToMenuMessage()
        {
            Console.Write("\nGår tillbaka till menyn");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(1500);
            Console.Clear();
        }

        // Huvudmeny:
        public void MainMenu()
        {
            while (isrunAgain)
            {
                
                Console.WriteLine("Välj ett av nedan val för det som du önskar göra idag:");
                Console.WriteLine("\n1. Jag är en användare som vill läsa bloggen " +
                    "\n2. Jag vill logga in som admin och få full kontroll över bloggen " +
                    "\n3. Jag har läst nog för idag och vill säga hejdå");
                Console.Write("\nSkriv den siffra som motsvara ditt val och tryck sedan enter: ");

                do
                {
                    userChoice = Console.ReadLine();
                    isInMenu = true;

                    switch (userChoice)
                    {
                        case "1":
                            //användarmenyn
                            Console.Clear();
                            UserMenu();
                            break;

                        case "2":
                            //adminmenyn
                            Console.Clear();
                            AdminMenu();
                            break;

                        //case 3: avsluta programmet
                        case "3":
                            Console.Clear();
                            Console.WriteLine("Hejdå!");
                            isInMenu = false;
                            isrunAgain = false;                           
                            break;

                        default:
                            Console.Write("\nOgiltigt val, välj ett av alternativen från menyn. Skriv endast siffran: ");
                            break;
                    }
                } while (isInMenu);
            }
        }

        // Användarmeny:
        public void UserMenu ()
        {
            Console.Clear();
            Console.WriteLine("Så kul att du hittat hit! Det finns massor av kul att läsa om och kommentera gärna och dela med dig av dina historier\n\n");

            isInMenu = true;
            while (isInMenu)
            {
                Console.WriteLine("Vad är du intresserad av att läsa om idag?\n");
                Console.WriteLine("\n1. Jag vill läsa alla inlägg från alla kategorier!" +
                    "\n2. Lista alla inlägg utifrån en kategori" +
                    "\n3. Jag vill söka efter ett inlägg" +
                    "\n4. Jag vill prenumerera på bloggen" +
                    "\n5. Gå tillbaka till huvudmenyn");
                Console.Write("\nSkriv den siffra som motsvarar ditt val och tryck sedan enter: ");

                isInMenu = true;
                do
                {
                    isInvalid = false;
                    userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        // case 1: Lista alla inlägg
                        case "1":
                            Console.Clear();
                            postAndCommentObj.ListPosts();
                            break;

                        // case 2: Lista alla inlägg utifrån kategori
                        case "2":
                            Console.Clear();
                            postAndCommentObj.ListPostFromCategory();
                            break;

                        //case 3: Söka efter inlägg
                        case "3":
                            Console.Clear();
                            //Inläggssök-meny. Användaren får välja vilket sätt den vill söka på:
                            while (isInSecondMenu)
                            {
                                Console.WriteLine("Nu ska vi leta reda på inlägget du söker! Hur vill du söka efter det?" +
                                "\n1. Sök efter rubrik" +
                                "\n2. Sök efter kategori" +
                                "\n3. Sök efter fritext" +
                                "\n4. Gå tillbaka");
                                Console.Write("\nSkriv den siffra som motsvarar ditt val och tryck sedan enter: ");

                                do
                                {
                                    isInvalid = false;
                                    userChoice = Console.ReadLine();

                                    switch (userChoice)
                                    {
                                        //case 1: Sök efter rubrik
                                        case "1":
                                            Console.Clear();
                                            postAndCommentObj.SearchPostTitle();                                            
                                            break;

                                        //case 2: Sök efter kategori
                                        case "2":
                                            Console.Clear();
                                            postAndCommentObj.ListPostFromCategory();
                                            break;

                                        //case 3: Sök efter fritext
                                        case "3":
                                            Console.Clear();
                                            postAndCommentObj.SearchPostContent();
                                            break;

                                        case "4":
                                            Console.Clear();
                                            BackToMenuMessage();
                                            isInSecondMenu = false;
                                            break;

                                        default:
                                            isInvalid = true;
                                            Console.Write("\nOgiltigt val, välj ett av alternativen från menyn, skriv endast siffran:");
                                            break;
                                    }
                                } while (isInvalid);
                            }                           
                            break;

                        case "4":
                            Console.Clear();
                            subscriberObj.AddSubscriber();
                            break;


                        case "5":
                            Console.Clear();
                            BackToMenuMessage();
                            isInMenu = false;
                            break;

                        default:
                            Console.Write("\nOgiltigt val, välj ett av alternativen från menyn, skriv endast siffran:");
                            isInvalid = true;
                            break;
                    }                   
                }
                while (isInvalid);
            }
        }

        // Adminmeny:
        public void AdminMenu ()
        {
            Console.Clear();
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
                    Console.WriteLine("\n1. Skapa ett nytt inlägg" +
                        "\n2. Redigera ett befintligt inlägg" +
                        "\n3. Ta bort ett inlägg" +
                        "\n4. Ta bort en kommentar" +
                        "\n5. Visa en lista över prenumeranter" +
                        "\n6. Logga ut");
                    Console.Write("\nSkriv den siffra som motsvarar ditt val: ");
                    do
                    {
                        userChoice = Console.ReadLine();
                        isInvalid = false;

                        switch (userChoice)
                        {
                            //case 1: Skapa nytt inlägg
                            case "1":
                                Console.Clear();
                                postObj.AddPost();
                                Console.Clear();
                                break;

                            //case 2: Redigera befintligt inlägg eller ta bort kommentarer
                            case "2":
                                Console.Clear();
                                postObj.EditPost();
                                Console.Clear();
                                break;

                            //case 3: Ta bort inlägg
                            case "3":
                                Console.Clear();
                                postObj.RemovePost();
                                Console.Clear();
                                break;

                            //case 4: Ta bort kommentar
                            case "4":
                                Console.Clear();
                                commentObj.RemoveComment();
                                Console.Clear();
                                break;

                            case "5":
                                Console.Clear();
                                if (Subscriber.SubscribersList.Count > 0)
                                {
                                    while (isInMenu)
                                    {
                                        subscriberObj.PrintSubscribers();
                                        Console.Write("\nVill du ta bort en prenumerant?\n" +
                                        "\n1, Ja" +
                                        "\n2, Nej" +
                                        "\nSkriv siffran som motsvarar ditt val: ");
                                        do
                                        {
                                            isInvalid = false;
                                            userChoice = Console.ReadLine();

                                            //Switch-sats för att hantera admins val att ta bort prenumerant eller inte
                                            switch (userChoice)
                                            {

                                                case "1":
                                                    subscriberObj.RemoveSubscriber();
                                                    isInMenu = false;
                                                    break;

                                                case "2":
                                                    Console.Clear();
                                                    Console.WriteLine("Ingen prenumerant har tagits bort");
                                                    BackToMenuMessage();
                                                    isInMenu = false;
                                                    break;

                                                default:
                                                    Console.Write("\nOgiltigt val, välj ett av alternativen från menyn, skriv endast siffran: ");
                                                    isInvalid = true;
                                                    break;
                                            }
                                        } while (isInvalid);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Det finns inga prenumeranter. :'(");
                                    BackToMenuMessage();
                                }
                                isInMenu = true;
                                break;

                            //case 4: Logga ut
                            case "6":
                                isInMenu = false;
                                Console.Clear();
                                Console.WriteLine("Du har loggats ut från admin-kontot.\n");
                                BackToMenuMessage();
                                break;

                            default:
                                Console.Write("\nOgiltigt val, välj ett av alternativen från menyn, skriv endast siffran: ");
                                isInvalid = true;
                                break;
                        }
                    } while (isInvalid);
                }
            }
            else
            {
                isInMenu = false;
                Console.WriteLine("\nFel inloggningsuppgifter.");
                BackToMenuMessage();
            }
        }
    }
}
