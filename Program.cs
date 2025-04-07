namespace SimpleHotelRoomManagementProjectCSharpProject2
{
    internal class Program
    {

        static int[] roomNumbers = new int[3];
        static double[] roomRates = new double[3];
        static bool[] isReserved = new bool[3];
        static string[] guestNames = new string[3];
        static int[] nights = new int[3];
        static DateTime[] bookingDates = new DateTime[3];
        static int roomCount = 0;
        static int MAX_ROOMS = 3;

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


            //-------------------------------
            Console.Write("How many rooms do you want to add? "); // ask user how many rooms to add
            int numRoomsToAdd = int.Parse(Console.ReadLine()); // read the number of rooms to add

            if (roomCount + numRoomsToAdd > MAX_ROOMS) // check if adding the rooms exceeds the maximum
            {
                Console.WriteLine($"You can only add up to {MAX_ROOMS - roomCount} more rooms."); // show the remaining space
                return; // exit the method
            }

            for (int i = 0; i < numRoomsToAdd; i++) // loop for the number of rooms to be added
            {
                int roomNumber;
                bool isUnique;// to check if the room number is unique

                // Check unique number of room using do while loop
                do
                {
                    isUnique = true; // Assume the room number is unique
                    Console.Write("Enter room number for room : ");
                    roomNumber = int.Parse(Console.ReadLine());

                    for (int j = 0; j < roomCount; j++)//all the room numbers that are already in the array
                    {
                        if (roomNumbers[j] == roomNumber) //check if the room number is already in the array
                        {
                            Console.WriteLine("Room number already exists! Try again.");//massage appears if the room number is already in the array
                            isUnique = false; // set isUnique to false
                            break; // exit the loop
                        }
                    }

                } while (!isUnique); // repeat until a unique room number is found

                double rate;

                // Use do-while for validating rate
                do
                {
                    Console.Write("Enter room rate : "); // ask user to enter the room rate
                                                         //convert the string input to a double value and put the number in the rate variable
                    if (!double.TryParse(Console.ReadLine(), out rate) || rate < 100) // check if the input is a valid double or >= 100
                    {


                        Console.WriteLine("Invalid rate. Please enter a number >= 100."); // show error message
                    }

                } while (rate < 100); // repeat until a valid rate is entered

                // Store the room details
                roomNumbers[roomCount] = roomNumber; // store the room number in the array
                roomRates[roomCount] = rate; // store the room rate in the array
                isReserved[roomCount] = false; // set the room as not reserved
                guestNames[roomCount] = ""; // store an empty string for guest name
                nights[roomCount] = 0; // set the number of nights to 0
                roomCount++; // increment the room count

                Console.WriteLine("Room added successfully.\n"); // show success message
            }

        }

        //2. View All Rooms
        static void ViewAllRooms()
        {

            

            


            for (int i = 0; i < roomCount; i++) // start looping from 0 until reach all rooms that are available in array

            {
                Console.Write("Room  " + roomNumbers[i] + "\n"); // show the room number

                if (isReserved[i]) // check if the room is reserved (true)
                {
                    Console.WriteLine("Reserved by : " + guestNames[i]); // show the guest name
                    Console.WriteLine("Booking Date : " + bookingDates[i]); // show the booking date
                    Console.WriteLine("Nights : " + nights[i]); // show the number of nights
                    Console.WriteLine("Rate : " + roomRates[i]); // show the room rate
                    double totalCost = roomRates[i] * nights[i]; // calculate the total cost
                    Console.WriteLine("Total Cost : " + totalCost); // show the total cost
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

            Console.Write("Enter guest name: "); // ask user to enter the guest name
            string guest = Console.ReadLine(); // read the guest name

            Console.Write("Enter room number: "); // ask user to enter the room number
            int roomNumber = int.Parse(Console.ReadLine()); // read the room number

            // Loop until valid stayNights is entered
            int stayNights; // declare stayNights variable
            do
            {
                Console.Write("Enter number of nights : "); // ask user to enter the number of nights
                // convert the string input to an integer value. and put the number in the stayNights variable
                if (!int.TryParse(Console.ReadLine(), out stayNights) || stayNights <= 0) // check if the input is a valid integer or <= 0
                {
                    Console.WriteLine("Invalid input. Please enter a number greater than 0."); // show error message
                    stayNights = 0; // reset stayNights to 0

                }

            } while (stayNights <= 0); // repeat until a valid stayNights is entered

            // reserve the room
            for (int i = 0; i < roomCount; i++) // start looping from 0 until reach all rooms that are available in array
            {
                if (roomNumbers[i] == roomNumber)// check if the room number is already in the array
                {

                    if (isReserved[i]) // check if the room is reserved (true)
                    {
                        Console.WriteLine("Room is already reserved."); // show error message
                        return; // exit the method
                    }

                    isReserved[i] = true; // set the room as reserved
                    guestNames[i] = guest; // store the guest name in the array
                    nights[i] = stayNights; // store the number of nights in the array
                    bookingDates[i] = DateTime.Now; // store the booking date in the array

                    Console.WriteLine("Room reserved successfully."); // show success message
                    return; // exit the method.
                }
            }

            Console.WriteLine("Room not found."); // show error message


        }


        //4. View All Reservations With Total Cost
        static void ViewAllReservationsWithTotalCost()
        {
           
        }
        //5. Search Reservation By Guest Name
        static void SearchReservationByGuestName()
        {
            
        }

        //6. Find Highest Paying Guest
        static void FindHighestPayingGuest()
        {

        }

        //7. Cancel Reservation By Room Number
        static void CancelReservationByRoomNumber()
        {
            
        }


    }
}
