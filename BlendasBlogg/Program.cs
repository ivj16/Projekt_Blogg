namespace BlendasBlogg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ TITEL ************");
            Console.WriteLine("En blogg av Blenda blogger, för dig som vill veta så mycket onödigt som möjligt");

            bool isRunAgaing;

        //while-loop som skriver ut menyn tills användaren väljer att avsluta

        //switch-sats för att hantera användarens val utifrån en meny
            switch(x)
            {

                //Huvudmeny
                //case 1: Använda bloggen som användare
                case 1:
                    break;

//**************************************************************************************************************************************************************************
                    //Användarmeny
                    switch ()
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
                            switch()
                            {
                                //case 1: Sök efter rubrik
                                case 1: 
                        
                                //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                    break;

                                case 2: 
                                //case 2: Sök efter kategori
                                //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                    break;

                                //case 3: Sök efter fritext
                                case 3:
                                //Utifrån ID ska användaren kunna välja att gilla eller kommentera, alternativt gå tillbaka till huvudmenyn
                                    break;
                        }
                            break;
                    }
//**************************************************************************************************************************************************************************

                
        //case 2: Logga in som admin
                case 2:
                    break;
//**************************************************************************************************************************************************************************

            //Admin-meny
                //case 1: Skapa nytt inlägg
                //case 2: Redigera befintligt inlägg eller ta bort kommentarer
                    //Lista alla inlägg med ID
                    //Välj inlägg att redigera
                    //Redigeringsmeny
                        //case 1: Redigera rubrik
                        //case 2: Redigera kategori
                        //case 3: Redigera innehåll
                        //case 4: Redigera header
                        //case 5: Ta bort kommentar
                            //Lista alla kommentarer med ID
                            //Välj kommentar att ta bort
                        //case 6: Gå tillbaka till admin-menyn
                
                //case 3: Ta bort inlägg

                    //Liknande upplägg som för användare när inlägg listas
                    //Utifrån ID ska admin kunna ta bort inlägg eller gå tillbaka till admin-menyn
//**************************************************************************************************************************************************************************




        //case 3: avsluta programmet
                case 3:
                    break;
            }
        }
    }
}
