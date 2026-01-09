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

        //Properties
        public string SubscriberName { get; set; }
        public string SubscriberEmail { get; set; }


        //Konstruktor
        public Subscriber() { }

        public Subscriber(string name, string email)
        {
            SubscriberName = name;
            SubscriberEmail = email;
        }

        public static List<Subscriber> SubscribersList = new List<Subscriber>();


        public void AddSubscriber()
        {
            Console.WriteLine("Så kul att du vill prenumerera på Blendas coola blogg!"
                + "\nFörst behöver vi lite information om dig.");

            Console.WriteLine("\nVänligen ange ditt namn: ");
            name = Console.ReadLine();

            Console.WriteLine("\nVänligen ange din e-postadress: ");
            isInMenu = true;
            while (isInMenu)
            {
                email = Console.ReadLine();

                if (!email.Contains('@'))
                {
                    Console.Write("\nOgiltig inmatning, skriv en riktig e-postadress:");
                }
                else
                {
                    isInMenu = false;
                }
            }

            Subscriber newSubscriber = new Subscriber(name, email);

            SubscribersList.Add(newSubscriber);

            Console.Clear();
            Console.WriteLine("Klart! Tack för att du prenumererar!");
            Menu.BackToMenuMessage();
        }

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
        
        public void RemoveSubscriber()
        {
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

                    Subscriber removeSubscriber = new Subscriber(removeInputName, removeInputEmail);

                    foreach (Subscriber subscriber in SubscribersList)
                    {

                        if (removeSubscriber.SubscriberEmail == subscriber.SubscriberEmail)
                        {
                            SubscribersList.Remove(subscriber);
                            Console.Clear();
                            Console.WriteLine($"\n{subscriber.SubscriberName} har tagits bort från prenumeranterna.");
                            Menu.BackToMenuMessage();
                            isInMenu = false;
                            isFound = true;
                        }
                    }
                    if (isFound = false)
                    {
                        Console.WriteLine("Det finns ingen prenumerant med de angivna uppgifterna");
                        isInMenu = true;
                        break;
                    }

                }
            }
            while (isInMenu);
        }
    }
}
