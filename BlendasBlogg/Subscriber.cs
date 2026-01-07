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
        string removeInput;
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
            Post.BackToMenuMessage();
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
                Post.BackToMenuMessage();
            }
        } 
        
        public void RemoveSubscriber()
        {
            
            Console.WriteLine("\nAnge e-postadressen för den prenumerant du vill ta bort, " +
                "\nalternativt skriv ångra för att gå tillbaka: ");

            do
            {
                removeInput = Console.ReadLine();
                foreach (Subscriber subscriber in SubscribersList)
                {
                    if (removeInput == subscriber.SubscriberEmail)
                    {
                        SubscribersList.Remove(subscriber);
                        Console.WriteLine($"\n{subscriber.SubscriberName} har tagits bort från prenumeranterna.");
                        Post.BackToMenuMessage();
                        isInMenu = false;
                        break;
                    }
                    else if (removeInput.ToLower() == "ångra")
                    {
                        Console.WriteLine("\nIngen prenumerant har tagits bort.");
                        Post.BackToMenuMessage();
                        isInMenu = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nDet hittades ingen prenumerant med den e-postadressen.");
                        
                        isInMenu = true;
                    }
                }
            }
            while (isInMenu);
        }
    }
}
