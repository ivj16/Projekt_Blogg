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
            Post postObj = new Post();

            //while-loop som skriver ut menyn tills användaren väljer att avsluta

            //switch-sats för att hantera användarens val utifrån en meny
            while (isRunAgain)
            {
                Console.WriteLine("Välj ett av nedan val för det som du önskar göra idag:\n");
                Console.WriteLine("1, Jag är en användare som vill läsa bloggen \n2, Jag vill logga in som admin och få full kontroll över bloggen \n3, Jag har läst nog för idag och vill säga hejdå\n");
                Console.Write("Skriv den siffra som motsvara ditt val: ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    //Huvudmeny
                    //case 1: Använda bloggen som användare
                    case "1":
                        //**************************************************************************************************************************************************************************
                        //användarmeny
                        Console.WriteLine("************************\n");
                        Console.WriteLine("Så kul att du hittat hit! Det finns massor av kul att läsa om och kommentera gärna och dela med dig av dina historier\n\n");
                        Console.WriteLine("Vad är du intresserad av att läsa om idag\n?");
                        Console.WriteLine("1, Jag vill läsa alla inlägg från alla kategorier! \n2, Lista alla inlägg utifrån en kategori \n3, JAg vill söka efter ett inlägg");
                        Console.Write("Skriv den siffra som motsvara ditt val: ");
                        userChoice = Console.ReadLine();
                        
                        switch (userChoice)
                        { 
                        // case 1: Lista alla inlägg
                            case "1":    
                                //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                 break;

                            // case 2: Lista alla inlägg utifrån kategori
                            case "2":
                                //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                 break;

                            //case 3: Söka efter inlägg
                            case "3":
                                //Inläggssök-meny. Användaren får välja vilket sätt den vill söka på:
                                switch(userChoice)
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
                        break;
    //**************************************************************************************************************************************************************************


                    //case 2: Logga in som admin
                    case "2":
                        UserInfo user = new UserInfo();
                        Console.WriteLine("************************\n");
                        Console.WriteLine("Välkommen Blenda! Eller är det verkligen du??\n\n");
                        Console.Write("Skriv in ditt användarnamn: ");
                        user.Username = Console.ReadLine(); 
                        Console.Write("Skriv in ditt lösenord: ");
                        user.Password = Console.ReadLine();
                        //IF-sats för att kolla användarnamn och lösenord
                        if (user.Username == user.BlendasUsername && user.Password == user.BlendasPassword)
                        {




                            //**************************************************************************************************************************************************************************

                            //Admin-meny
                            Console.WriteLine("Ja det är verkligen du Blenda, hej!! Vad önskar du göra idag?\n");
                            Console.WriteLine("1, Skapa ett nytt inlägg  \n2, Redigera ett befintligt inlägg eller ta bort en kommentar \n3, Ta bort ett inlägg");
                            Console.Write("Skriv den siffra som motsvara ditt val: ");
                            userChoice = Console.ReadLine();

                            switch (userChoice)
                            {
                                //case 1: Skapa nytt inlägg
                                case "1":
                                    postObj.AddPost();
                                    Console.WriteLine(postObj.Posts);
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

                                    //Liknande upplägg som för användare när inlägg listas - metod från Post-klassen.

                                    //if-else-sats för att välja ta bort eller gå tillbaka till admin-menyn
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("`\nDu är inte Blenda, vänligen gå in som användare i stället.");
                            Console.WriteLine("PS. Om du faktiskt är Blenda så skrev du in fel inloggningsuppgifter. Försök igen!\n");
                        }
                        break;
    //**************************************************************************************************************************************************************************




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
