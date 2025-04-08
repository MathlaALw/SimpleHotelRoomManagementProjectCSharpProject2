namespace SimpleHotelRoomManagementProjectCSharpProject2
{
    internal class Program
    {

        static int[] roomNumbers = new int[5];
        static double[] roomRates = new double[5];
        static bool[] isReserved = new bool[5];
        static string[] guestNames = new string[5];
        static int[] nights = new int[5];
        static DateTime[] bookingDates = new DateTime[5];
        static int roomCount = 0;
        static int MAX_ROOMS = 5;

        static void Main(string[] args)
        {
            int choice = 0; //Declare and initialize choice
            while (true)
            {

                try //handle the exception if the user enter invalid input
                {
                    //Menu System
                    Console.Clear();
                    Console.WriteLine("\nSelect a Program:");
                    Console.WriteLine("1. Add a new room");
                    Console.WriteLine("2. View all rooms");
                    Console.WriteLine("3. Reserve a room for a guest");
                    Console.WriteLine("4. View all reservations with total cost");
                    Console.WriteLine("5. Search reservation by guest name");
                    Console.WriteLine("6. Find the highest-paying guest");
                    Console.WriteLine("7. Cancel a reservation by room number");
                    Console.WriteLine("8. Exit the system");


                    Console.Write("Enter your choice : ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: AddNewRoom(); break;
                        case 2: ViewAllRooms(); break;
                        case 3: ReserveRoomForGuest(); break;
                        case 4: ViewAllReservationsWithTotalCost(); break;
                        case 5: SearchReservationByGuestName(); break;
                        case 6: FindHighestPayingGuest(); break;
                        case 7: CancelReservationByRoomNumber(); break;
                        case 8: return;

                        default: Console.WriteLine("Invalid Choice! Try again."); break;
                    }
                    Console.WriteLine("Press any key  "); //ask user to press any key to continue
                    Console.ReadLine(); //read the user input

                }
                catch (Exception e)//show exception message if the user enter invalid input
                {
                    Console.WriteLine(e.Message);


                    Console.WriteLine("Invalid Choice! Try again.");
                    Console.WriteLine("Press any key  "); //ask user to press any key to continue
                    Console.ReadLine(); //read the user inputConsole.ReadLine();
                }

            }
        }




        //1. Add New Room 
        static void AddNewRoom()
        {

            

            


            try
            {

                // ask and read user number of rooms to add
                Console.Write("How many rooms do you want to add? ");
            int numRoomsToAdd = int.Parse(Console.ReadLine());

            // check if adding the rooms exceeds the maximum
            if (roomCount + numRoomsToAdd > MAX_ROOMS)
            {

                Console.WriteLine("You can only add up to " + (MAX_ROOMS - roomCount) + "more rooms.");
                return;
            }
            // loop for the number of rooms to be added
            for (int i = 0; i < numRoomsToAdd; i++)
            {
                int roomNumber;
                bool isUnique;

                // Check unique number of room using do while loop
                do
                {


                    isUnique = true;
                    Console.Write("Enter room number : ");
                    roomNumber = int.Parse(Console.ReadLine());

                    //all the room numbers that are already in the array
                    for (int j = 0; j < roomCount; j++)
                    {
                        //check if the room number is already in the array
                        if (roomNumbers[j] == roomNumber)
                        {
                            Console.WriteLine("Room number already exists! Try again.");
                            isUnique = false;
                            break;
                        }
                    }





                } while (!isUnique); // repeat until a unique room number is found

                double rate;

                // validating rate
                bool found = false;
                do
                {
                    Console.Write("Enter room rate : ");
                    rate = double.Parse(Console.ReadLine());
                    //convert the string input to a double value and put the number in the rate variable
                    if (rate < 100)
                    {
                        Console.WriteLine("Invalid rate. Please enter a number >= 100.");
                        found = true;

                    }
                    else
                    {
                        found = false;
                    }

                } while (found);  // repeat until a valid rate is entered

                // Store the room details
                roomNumbers[roomCount] = roomNumber;
                roomRates[roomCount] = rate;
                isReserved[roomCount] = false; // set the room as not reserved
                guestNames[roomCount] = "";
                nights[roomCount] = 0;
                roomCount++; // increment the room count

                Console.WriteLine("Room added successfully.\n");
            }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        //2. View All Rooms
        static void ViewAllRooms()
        {



                // start looping from 0 until reach all rooms that are available in array
                for (int i = 0; i < roomCount; i++)

                {
                    // show the room number
                    Console.Write("Room  " + roomNumbers[i] + "\n");

                    // check if the room is reserved (true)
                    if (isReserved[i])
                    {
                        Console.WriteLine("Reserved by : " + guestNames[i]);
                        Console.WriteLine("Booking Date : " + bookingDates[i]);
                        Console.WriteLine("Nights : " + nights[i]);
                        Console.WriteLine("Rate : " + roomRates[i]);
                        double totalCost = roomRates[i] * nights[i]; // calculate the total cost
                        Console.WriteLine("Total Cost : " + totalCost);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Available"); // show the room status (false)
                    }
                }
           



        }
        //3. Reserve Room For Guest
        static void ReserveRoomForGuest()
        {
            try { 
            // ask and read the guest name
            Console.Write("Enter guest name: "); 
            string guest = Console.ReadLine();

            //ask and read the room number
            Console.Write("Enter room number: "); 
            int roomNumber = int.Parse(Console.ReadLine()); 

            // Loop until valid stayNights is entered
            int stayNights;
            do
            {
                Console.Write("Enter number of nights : ");
                stayNights = int.Parse(Console.ReadLine());
                if (stayNights <= 0) 
                {
                    Console.WriteLine("Invalid input. Please enter a number greater than 0."); 
                    

                }

            } while (stayNights <= 0); // repeat until a valid stayNights is entered

            // reserve the room
            for (int i = 0; i < roomCount; i++) 
            {
                // check if the room number is already in the array
                if (roomNumbers[i] == roomNumber)
                {
                    // check if the room is reserved (true)
                    if (isReserved[i]) 
                    {
                        Console.WriteLine("Room is already reserved.");
                        return; 
                    }

                    isReserved[i] = true; // set the room as reserved
                    guestNames[i] = guest; 
                    nights[i] = stayNights; 
                    bookingDates[i] = DateTime.Now; 

                    Console.WriteLine("Room reserved successfully."); 
                    return; 
                }
            }

            Console.WriteLine("Room not found.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        //4. View All Reservations With Total Cost
        static void ViewAllReservationsWithTotalCost()
        {
            for (int i = 0; i < roomCount; i++) 
            {
                // check if the room is reserved (true)
                if (isReserved[i]) 
                {



                    Console.WriteLine("Room Number: " + roomNumbers[i]); 
                    Console.WriteLine("Reserved by : " + guestNames[i]); 
                    Console.WriteLine("Booking Date : " + bookingDates[i]); 
                    Console.WriteLine("Nights : " + nights[i]); 
                    Console.WriteLine("Rate : " + roomRates[i]); 
                    double totalCost = roomRates[i] * nights[i]; 
                    Console.WriteLine("Total Cost : " + totalCost); 
                    Console.WriteLine(); 




                }
            }

        }
        //5. Search Reservation By Guest Name
        static void SearchReservationByGuestName()
        {
            try { 
            Console.Write("Enter guest name to search: "); 
            string searchName = Console.ReadLine().ToLower(); // convert the string input to lower case
            bool found = false; 

            for (int i = 0; i < roomCount; i++) 
            {
                // check if the room is reserved (true) and the guest name is equal to the search name
                if (isReserved[i] && guestNames[i].ToLower() == searchName) 
                {

                    Console.WriteLine("Room Number : " + roomNumbers[i]); 
                    Console.WriteLine("Guest Name : " + guestNames[i]);
                    Console.WriteLine("Nights : " + nights[i]);
                    Console.WriteLine("Booking Dates : " + bookingDates[i]);
                    Console.WriteLine("Total Cost : " + (roomRates[i] * nights[i]));
                    Console.WriteLine("Room Rate : " + roomRates[i]);
                    Console.WriteLine("Room Statuse : Reserved");

                    found = true; 
                    break; 
                }
            }

            if (!found)
                Console.WriteLine("Reservation not found.");


            }
            catch (NullReferenceException e)
            {
                
                Console.WriteLine("Name cant be null " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input. Please enter a valid name." + e.Message);
            }
        
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //6. Find Highest Paying Guest
        static void FindHighestPayingGuest()
        {
           
            double maxCost = 0;
            int maxIndex = -1; // initialize maxIndex variable to -1 --> (-1 is a flag value to mean "No reservation found")

            for (int i = 0; i < roomCount; i++) 

            {
                // check if the room is reserved (true).
                
                    double totalCost = roomRates[i] * nights[i]; 
                    if (totalCost > maxCost) 
                    {

                        maxCost = totalCost; 
                        maxIndex = i;
                    }
                
            }

            if (maxIndex != -1) 
            {

                Console.WriteLine("Highest Paying Guest: " + guestNames[maxIndex]); // show the guest name has the highest total cost
                Console.WriteLine("Total Amount = " + maxCost); // show the total cost of the highest paying guest


            }
            else 
            {
                Console.WriteLine("No reservations found."); 
            }


           
        
             
        }
        //7. Cancel Reservation By Room Number
        static void CancelReservationByRoomNumber()
        {
            try
            {

            
            //ask and read the room number
            Console.Write("Enter room number to cancel reservation: "); 
            int roomNumber = int.Parse(Console.ReadLine()); 

            for (int i = 0; i < roomCount; i++) 
            {
                if (roomNumbers[i] == roomNumber) 
                {
                    // check if the room is reserved (true)
                    if (isReserved[i]) 
                    {
                        isReserved[i] = false; // set the room as not reserved
                        guestNames[i] = ""; 
                        nights[i] = 0; 
                        Console.WriteLine("Reservation cancelled.");
                        return; 
                    }
                    else 
                    {
                        Console.WriteLine("Room is not reserved."); 
                        return; 
                    }
                }
            }

            Console.WriteLine("Room not found.");

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Room number cant be null " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input. Please enter a valid room number." + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



    }
}
