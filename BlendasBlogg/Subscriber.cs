using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public class Subscriber
    {
        //Fields
        bool isInMenu = true;
        bool isFound;
        string removeInputName;
        string removeInputEmail;
        string email;
        string name;

        // Lista med subscribers
        public static List<Subscriber> SubscribersList = new List<Subscriber>();

        //Properties
        public string SubscriberName { get; set; }
        public string SubscriberEmail { get; set; }

        //Konstruktorer:
        public Subscriber() { }
        public Subscriber(string name, string email)
        {
            SubscriberName = name;
            SubscriberEmail = email;
        }

        // Metoder:

        // Metod för att lägga till subscribers:
        public void AddSubscriber()
        {
            Console.WriteLine("Så kul att du vill prenumerera på Blendas coola blogg!"
                + "\nFörst behöver vi lite information om dig.");

            Console.WriteLine("\nVänligen ange ditt namn: ");
            do
            {
                isInMenu = true;
                name = Console.ReadLine();
                // Kollar så att namnet inte är tomt
                if (name == "")
                {
                    Console.WriteLine("\nOgiltig inmatning, du måste ange ett användarnamn: ");
                }
                else
                {
                    isInMenu = false;
                }

                // Kollar så att namnet inte redan är taget
                foreach (Subscriber subscriber in SubscribersList)
                {
                    if (name == subscriber.SubscriberName)
                    {
                        Console.WriteLine("\nAnvändarnamnet är redan taget, vänligen ange ett annat namn: ");
                        isInMenu = true;
                        break;
                    }
                }
            } while (isInMenu);

            Console.WriteLine("\nVänligen ange din e-postadress: ");

            do
            {
                isInMenu = true;
                email = Console.ReadLine();

                // Kollar så att e-postadressen innehåller @
                if (!email.Contains('@'))
                {
                    Console.WriteLine("\nOgiltig inmatning, skriv en riktig e-postadress:");
                }
                else
                {
                    isInMenu = false;
                }

                // Kollar så att e-postadressen inte redan är använd
                foreach (Subscriber subscriber in SubscribersList)
                {
                    if (email == subscriber.SubscriberEmail)
                    {
                        Console.WriteLine("\nE-postadressen är redan använd, vänligen ange en annan e-post: ");
                        isInMenu = true;
                        break;
                    }
                }
            } while (isInMenu);

            Subscriber newSubscriber = new Subscriber(name, email);

            SubscribersList.Add(newSubscriber);

            Console.Clear();
            Console.WriteLine("Klart! Tack för att du prenumererar!");
            Menu.BackToMenuMessage();
        }

        // Metod för att skriva ut alla subscribers:
        public void PrintSubscribers()
        {
            if (SubscribersList.Count > 0)
            {
                Console.WriteLine("Här är en lista av alla prenumeranter:");
                foreach (var subscriber in SubscribersList)
                {
                    Console.WriteLine($"\nNamn: {subscriber.SubscriberName}, E-post: {subscriber.SubscriberEmail}");
                }
            }
            else 
            {
                Console.WriteLine("\nDet finns inga prenumeranter att lista. :(");
                Menu.BackToMenuMessage();
            }
        }

        // Metod för att ta bort subscribers:
        public void RemoveSubscriber()
        {
            Console.Clear();
            PrintSubscribers();
            do
            {
                isFound = false;
                isInMenu = true;

                Console.WriteLine("\nAnge namn för den prenumerant du vill ta bort, " +
                "\nalternativt skriv ångra för att gå tillbaka: ");
            
                removeInputName = Console.ReadLine();

                if (removeInputName == "ångra")
                {
                    Console.Clear();
                    Console.WriteLine("\nIngen prenumerant har tagits bort.");
                    Menu.BackToMenuMessage();
                    isInMenu = false;
                    break;
                }
                else 
                {
                    Console.WriteLine("\nAnge e-post för den prenumerant du vill ta bort: ");
                    removeInputEmail = Console.ReadLine();

                    foreach (Subscriber subscriber in SubscribersList)
                    {
                        // Jämför input med varje subscribers namn och e-post
                        if (removeInputEmail == subscriber.SubscriberEmail && removeInputName == subscriber.SubscriberName)
                        {
                            SubscribersList.Remove(subscriber);
                            Console.Clear();
                            Console.WriteLine($"\n{subscriber.SubscriberName} har tagits bort från prenumeranterna.");
                            Menu.BackToMenuMessage();
                            isInMenu = false;
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        Console.Clear();
                        Console.WriteLine("Det finns ingen prenumerant med de angivna uppgifterna, försök igen. \n");
                        PrintSubscribers();
                        isInMenu = true;
                    }

                }
            }
            while (isInMenu);
        }
    }
}
