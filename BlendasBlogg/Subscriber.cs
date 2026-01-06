using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public class Subscriber
    {
        bool isInMenu = true;
        public string SubscriberName { get; set; }
        public string SubscriberEmail { get; set; }

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

            Console.WriteLine("Vänligen ange ditt namn: ");
            string name = Console.ReadLine();

            Console.WriteLine("Vänligen ange din e-postadress: ");
            string email = Console.ReadLine();

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
                    Console.WriteLine($"Namn: {subscriber.SubscriberName}, E-post: {subscriber.SubscriberEmail}\n");
                }
            }
            else 
            {
                Console.WriteLine("Det finns inga prenumeranter att lista. :(");
                Post.BackToMenuMessage();
            }
        } 
        
        public void RemoveSubscriber()
        {
            
            Console.WriteLine("Ange e-postadressen för den prenumerant du vill ta bort, " +
                "\nalternativt skriv ångra för att gå tillbaka: ");

            do
            {
                string removeInput = Console.ReadLine();
                foreach (Subscriber subscriber in SubscribersList)
                {
                    if (removeInput == subscriber.SubscriberEmail)
                    {
                        SubscribersList.Remove(subscriber);
                        Console.WriteLine($"{subscriber.SubscriberName} har tagits bort från prenumeranterna.");
                        Post.BackToMenuMessage();
                        isInMenu = false;
                        break;
                    }
                    else if (removeInput.ToLower() == "ångra")
                    {
                        Console.WriteLine("Ingen prenumerant har tagits bort.");
                        Post.BackToMenuMessage();
                        isInMenu = false;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Det hittades ingen prenumerant med den e-postadressen.");
                        
                        isInMenu = true;
                    }
                }
            }
            while (isInMenu);
        }
    }
}
