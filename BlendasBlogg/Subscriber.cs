using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendasBlogg
{
    public class Subscriber
    {
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
            Thread.Sleep(1500);
            Post.BackToMenuMessage();
            Console.Clear();

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
                Thread.Sleep(2000);
                Console.Clear();
            }
        } 
        
        public void RemoveSubscriber()
        {
            Console.WriteLine("Ange e-postadressen för den prenumerant du vill ta bort, " +
                "\nalternativt skriv ångra för att gå tillbaka: ");
            string removeInput = Console.ReadLine();
            foreach (Subscriber subscriber in SubscribersList)
            {
                if (removeInput == subscriber.SubscriberEmail)
                {
                    SubscribersList.Remove(subscriber);
                    Console.WriteLine($"{subscriber.SubscriberName} har tagits bort från prenumeranterna.");
                    break;
                }
                else if (removeInput.ToLower() == "ångra")
                {
                    Console.WriteLine("Ingen prenumerant har tagits bort.");
                    Post.BackToMenuMessage();

                }
                else
                {
                    Console.WriteLine("Det hittades ingen prenumerant med den e-postadressen.");
                }
            }
            Thread.Sleep(2000);
            Console.Clear();
        }

    }
}
