using System;

namespace FinalProject
{
    class Program
    {
        static bool valid = true; //bool for input validation
        static string P1 = ""; //string for P1 name
        static string P2 = "";//string for P2 name
        static string winner = ""; //string for winner (either P1 or P2)
        static string player = ""; //string for player (either P1 or P2)
        static char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //array for number choices (on board)
        static int location = 0; //user location choice to put their pin
        static bool hasWonValidation = false; //bool for HasWon validation
        static int tie = 0; //counter for if its a tie
        


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe!");
            Console.WriteLine("Player 1. Enter your username"); //user1 name
            P1 = Console.ReadLine();
          
            Console.WriteLine("Player 2. Enter your username"); //user2 name
            P2 = Console.ReadLine();

            for (int i = 1; i < 10; i++) //if statement that goes 9 times (from 1 to 9), because there are 9 slots on the board
            {
                table(); //prints table
                

                if (i % 2 == 0) //if divided by 2, and rest is zero then it is player 2 (because it is a even number)
                {

                    player = P2; //player is P2 

                    input(); //reads input
                    numbers[location-1] = 'O'; //sets input location to O (so that it can print O on the board)
                    winner = P2; //if haswon = true, then winner is P2
                    hasWon(numbers); //runs the haswon statement to see if we have a winner or not

                }


                else //else (if its not an even number then its odd so its p1)
                {
                    player = P1;//player is P1

                    input(); //reads input
                    numbers[location-1] = 'X'; //sets input location to X (so that it can print X on the board)
                    winner = P1; //if haswon = true, then winner is P1
                    hasWon(numbers); //runs the haswon statement to see if we have a winner or not

                }
                tie++; //counter tie increases

                if (tie == 9 && hasWonValidation ==false) //if tie reaches 9 (max space available), and haswon validation is false, then we have a tie
                {
                    Console.WriteLine("It is a tie"); //print tie
                    table();
                }

                if (hasWonValidation == true) //if haswon validation is true, we insert a break to leave the loop
                {
                    break;
                }


            }

            static void table() //print statement for the table
            {
                Console.WriteLine(numbers[0] + " | " + numbers[1] + " | " + numbers[2] + "\n----------\n" + numbers[3] + " | " + numbers[4] + " | " + numbers[5] + "\n----------\n" + numbers[6] + " | " + numbers[7] + " | " + numbers[8]+ "\n\n\n");
               
            }


            static bool hasWon(char[] numbers) //haswon, if any of the win opportunities are there, then we have a winner. (3x horizontal, 3x vertical and 2x diagonal win opportunities)
            {

                if (numbers[0] == numbers[1] && numbers[2] == numbers[1] || numbers[3] == numbers[4] && numbers[4] == numbers[5] || numbers[6] == numbers[7] && numbers[7] == numbers[8] //there are three horizontal ways to win
                    || numbers[0] == numbers[3] && numbers[3] == numbers[6] || numbers[1] == numbers[4] && numbers[4] == numbers[7] || numbers[2] == numbers[5] && numbers[5] == numbers[8] || //there are three vertical ways to win
                    numbers[0] == numbers[4] && numbers[4] == numbers[8] || numbers[6] == numbers[4] && numbers[4] == numbers[2]) //there are two diagonal ways to win
                {
                    Console.WriteLine("Congrats " + winner + " won the game"); //if there is a winner we print it
                    hasWonValidation = true; //set haswon validation to true
                    table(); //print final table
                    
                }

                
                return hasWonValidation; //return method (brings us back to the main code)
                    

            }

            static void input() //input processing
            {
                
                {
                    Console.WriteLine(player + " input your desired location ");
                    valid = int.TryParse(Console.ReadLine(), out location); //input validation
                  
                    while (valid == false || location < 1 || location >9) //if its not a number between 1 and 9, we ask user to input a valid value
                    {
                        Console.WriteLine("Please enter a valid input");
                        valid = int.TryParse(Console.ReadLine(), out location);
                    }

                    while (numbers[location - 1] == 'O' || numbers[location - 1] == 'X') //if the location chosen is already taken, then we mention it and ask user to choose something else
                    {
                        Console.WriteLine("Please enter a location that isn't aready taken");
                        valid = int.TryParse(Console.ReadLine(), out location);
                    }
                      


                }

            }


        }
    }
}
