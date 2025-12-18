namespace BlendasBlogg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ TITEL ************");
            Console.WriteLine("En blogg av Blenda blogger, för dig som vill veta så mycket onödigt som möjligt");

            bool isRunAgain = true;

        //while-loop som skriver ut menyn tills användaren väljer att avsluta

        //switch-sats för att hantera användarens val utifrån en meny
            while (isRunAgain)
            {
                Console.WriteLine("Välj ett av nedan val för det som du önskar göra idag:");
                Console.WriteLine("1, Jag är en användare som vill läsa bloggen \n2, Jag vill logga in som admin och få full kontroll över bloggen \n3, Jag har läst nog för idag och vill säga hejdå");4
                Console.Write("Skriv den siffra som motsvara ditt val: ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    //Huvudmeny
                    //case 1: Använda bloggen som användare
                    case "1":
    //**************************************************************************************************************************************************************************
                        //användarmeny
                        switch (x)
                        { 
                        // case 1: Lista alla inlägg
                            case 1:    
                                //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                 break;

                            // case 2: Lista alla inlägg utifrån kategori
                            case 2:
                                //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                 break;

                            //case 3: Söka efter inlägg
                            case 3:
                                //Inläggssök-meny. Användaren får välja vilket sätt den vill söka på:
                                switch(x)
                                {
                                    //case 1: Sök efter rubrik
                                    case 1: 
                        
                                    //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                        break;

                                    //case 2: Sök efter kategori
                                    case 2: 
                                    //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                        break;

                                    //case 3: Sök efter fritext
                                    case 3:
                                    //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                        break;
                                }
                            break;
                        }
                        break;
    //**************************************************************************************************************************************************************************


                    //case 2: Logga in som admin
                    case "2":
                        //IF-sats för att kolla användarnamn och lösenord

     //**************************************************************************************************************************************************************************
                    
                        //Admin-meny
                        switch ()
                        {
                            //case 1: Skapa nytt inlägg
                            case 1:
                                //anropa metod från Post-klassen för att skapa nytt inlägg
                                break;

                            //case 2: Redigera befintligt inlägg eller ta bort kommentarer
                            case 2:
                                //Lista alla inlägg med ID - via metod från Post-klassen
                                //Ta input från användaren för att välja inlägg att redigera
                                //Anropa redigera inlägg-metoden från Post-klassen
                                break;
                  
                            //case 3: Ta bort inlägg
                            case 3:

                                //Liknande upplägg som för användare när inlägg listas - metod från Post-klassen.

                                //if-else-sats för att välja ta bort eller gå tillbaka till admin-menyn
                                break;
                        }
                    break;
    //**************************************************************************************************************************************************************************




            //case 3: avsluta programmet
                    case "3":
                        break;
                }
            }
        }
    }
}
