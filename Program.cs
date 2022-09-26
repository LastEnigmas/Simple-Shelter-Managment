using System;
using System.Collections;



namespace Major_Assignment_2_Aria_Taghizade
{
    public class Program
    {
        //This arraylist holds the data about the dogs, and all the dogs are in this arraylist as an object of the dog class.
         public static ArrayList dogsarray = new ArrayList();
        //This array is not essential, however it is very handy for the times when we want to add or check a dog's id.
        public static ArrayList dogsidarray = new ArrayList();

        //in our main method, we get the option that the user chose, and we call the apporpriate method accordingly.
        static void Main(string[] args) {
            //all the logics are inside a do-while loop so, the user sees the menu again after they're done with each section, until he/she decides to exit.
            do
            {
                //Show the menu to the user, let them decide, and also save the user's choice in a string.
                string chosenoption=menu();

                if (chosenoption.Equals("6"))
                {
                    //if the user wanted to exit the program, thank them and then break the loop, so the program stops.
                    Console.WriteLine("Thank you for using the Dog Shelter Management System.");
                    break;
                }
                //these statements call a method according to the user's choice.
                else if (chosenoption.Equals("1")) addDog();
                else if (chosenoption.Equals("2")) viewAlldogs();
                else if (chosenoption.Equals("3")) viewAllavailabledogs();
                else if (chosenoption.Equals("4")) viewspecificdog();
                else if (chosenoption.Equals("5")) updatehomestatus();
                //if what user enters isn't available, let them know.
                else Console.WriteLine("\n Invalid choice! ");

            } while (true);  


            }

        public static void viewAllavailabledogs()
        {
            //This is a list which holds onto dogs that are available for adoption.
            ArrayList availabledogs= new ArrayList();
            //loop through each dog, and choose the ones which are available and add them to the availabledogs list.
            foreach (Dog dog in dogsarray)
            {
                //if s dog doesn't have a house, add him/her to the availabledogs list.
                if (dog.getHomeStatus() == false)
                {
                    availabledogs.Add(dog);
                }
                
            }
            //if the availabledogs list is not empty, show the information of each dog.
            if (availabledogs.Count != 0)
            {
                foreach(Dog dog in availabledogs)
                {
                    Console.WriteLine(dog.getInfo());
                }
            }
            //if the availabledogs list is empty, let the user know.
            else
            {
                Console.WriteLine("Sorry, there is no dog available!!");

            }

        }
        public static void addDog()
        {
            int dogid=0;
            //A while loop, just in case if the user enters an already-existing id for a new dog id.
            while (true)
            {
                try {
                    //Ask the user for the new dog's id, and if it's a negative number or not a number contiue the loop,
                    //otherwise dogid is the positive integer that the use enterd.
                    Console.WriteLine("What will be the ID of this new dog? ");
                    dogid = Int32.Parse(Console.ReadLine());
                    if (dogid < 0) continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ID should be a number.");
                    continue;
                }
                //if there are dogs in the dagsarray list, then check if the entered dogid doesn't already exist.
                if (dogsarray != null)
                {
                    //make a list of dogs' id, so we can check if the id already exists.
                    foreach (Dog d in dogsarray)
                    {
                        dogsidarray.Add(d.getId());

                    }
                    if (dogsidarray.Contains(dogid))
                    {
                        //if the id exist ask the again.( tell the user,and continue the loop. )
                        Console.WriteLine("This ID already exists for a different dog. Please try again. ");

                        continue;
                    }
                    else
                    {
                        //if the id is okay, then break the loop.
                        break;
                    }
                }
            }
            //ask for the name of the dog.
                Console.WriteLine("What is the name of the dog? ");
                String dogname = Console.ReadLine();
                
                int dogage;
            //ask the age of the dog and if it's not a positive integer, ask again.(ask untill the user enters a valid positive integer.)
                while (true)
                {
                    Console.WriteLine("How old is the dog? ");
                    try
                    {
                        dogage = Int32.Parse(Console.ReadLine());
                        if(dogage < 0) continue;
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter a positive integer.");
                    }

                }

                //ask for the breed.
                

                Console.WriteLine("What is the breed of the dog? ");
                String dogbreed = Console.ReadLine();
                
                char doggender;
            //This block of code asks the user for the gender, and only accepts m or f as a valid input.
                while (true) { 
                try {
                        Console.WriteLine("What is the gender of the dog? m for Male, f for Female ");
                        doggender = Char.Parse(Console.ReadLine());
                    //if what usered entered is 'm' or 'f' ,the everything is okay. No need to repeat the loop.
                        if(doggender.Equals('m') || doggender.Equals('f'))
                        {
                            break ;
                        }
                        //if the user entered an invalid character. Give them instruction, then continue the loop.
                        else
                        {
                            Console.WriteLine("Please enter a valid character for the gender. m for Male, or f for Female ");
                            continue ;
                        }
                       
                    }
                //if the user entered anything that is not a character. Give them instruction, then continue the loop.
                catch (Exception e)
                {
                    Console.WriteLine("Please enter m for Male, or f for Female ");
                        continue;
                }
                }

                //Make the dog object using the information which the user gave you, then add the new object to the dogsarray list.

                dogsarray.Add(new Dog(dogid,dogname,dogage,dogbreed,doggender));
                Console.WriteLine("The dog has been succesfully added to the system.");
















        }
        public static void viewspecificdog()
        {
            int id;
            while (true) { 
            try { 
                    //ask the user for a valid dog id. Keep asking if the id is not a valid positive integer.
                Console.WriteLine("What is the id of your specific dog? ");
                id=Int32.Parse(Console.ReadLine());
                break ;


            }catch (Exception e)
            {
                Console.WriteLine("Please enter an integer ");
                    continue;

            }
            }
            //make an arraylist with all the dogs id inside it.
            foreach (Dog dog in dogsarray)
            {
                dogsidarray.Add(dog.getId());
            }
            //if the id exists in the database, the loop through each dog and show the user only the dog with the matching id.
            if(dogsidarray.Contains(id))
            {
                foreach (Dog dog in dogsarray)
                {
                    if (id == dog.getId())
                    {
                        Console.WriteLine(dog.getInfo());

                    }
                }

            }
            //if the id is not in the database.
            else
            {
                //Let the user know the id that she/he entered is not associated with any dog.
                Console.WriteLine("There is no dog with the id you provided.");
            }






        }
        public static void viewAlldogs()
        {
            //if there are any dog  in the shelter, loop through the dogsarray list, and print the information about each dog.
            if(dogsarray.Count != 0)
            {
                foreach (Dog dog in dogsarray)
                {
                    Console.WriteLine(dog.getInfo());
                }

            }
            //if there aren't any dog in the shelter, tell the user.
            else
            {
                Console.WriteLine("There is no dog in the shelter.");

            }

            

        }
        public static void updatehomestatus()
        {
            int id;
            while (true)
            {

                try
                {
                    //ask the user for a valid id.Keep asking if the given id is not valid.
                    Console.WriteLine("What is the id of your specific dog? ");
                    id = Int32.Parse(Console.ReadLine());
                    break;


                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter an integer ");
                    continue;

                }
            }
            //make an arraylist with all the dogs id inside it.
            foreach (Dog dog in dogsarray)
            {
                dogsidarray.Add(dog.getId());
            }
            //if the id exist in the database, go through each dog,and change the home status of the dog with the matching id.
            if (dogsidarray.Contains(id)) {
                foreach (Dog dog in dogsarray)
                {
                    //find the dog with the matching id.
                    if (dog.getId() == id)
                    {
                        //change the home status of the dog with the matching id.
                        dog.setHomeStatus(!dog.getHomeStatus());
                        //print the dog new updated information.
                        Console.WriteLine(dog.getInfo());
                    }
                }
            }
            //Let the user know that the id that they've entered is not in the database.
            else
            {
                Console.WriteLine("There is no dog with the id you provided.");
            }


            





        }


        //This method simply shows the users all the options. It returns the user's choice as a string.
        public static String menu()
        {

            Console.WriteLine("\n +++++++++++++++++++ Dog Shelter Management System +++++++++++++++++++");
            Console.WriteLine("1) Add dog  ");
            Console.WriteLine("2) View all dogs  ");
            Console.WriteLine("3) View all available dogs  ");
            Console.WriteLine("4) View specific dog  ");
            Console.WriteLine("5) Update dog home status  ");
            Console.WriteLine("6) Exit  ");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Please enter the number of your option (Example 1,2,3,4,5,6):  ");
            return Console.ReadLine();


        }
    }


            
        

        
             
    }

