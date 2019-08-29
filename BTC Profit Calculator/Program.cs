/* Yannick's BTC Profit Calculator v0.5;
 */
using System;
using System.Net;
using Newtonsoft;
using System.IO;

namespace CSharp_BTC_Profit_Calculator
{
    public class Program
    {
        
            //Define all possible variables we are going to use;
            int choice;
        Double version = 0.5;
        bool programContinue = true;
        Double btcValue;
        Double amountTraded;
        Double btcSellValue;
        Double totalValue;
        Double exchangeFee;
        Double profit;
        Double profitCalc;
        Double feeProfit;
        Double percGain;
        Double increase;
        Double negaFee;
        public static void Main(string[] args)
        {
            
            Program main = new Program();

            Console.ForegroundColor = ConsoleColor.Green;

            string json;
            using (var web = new WebClient()) //Using WebClient for a second;
            {
                var url = @"https://api.coindesk.com/v1/bpi/currentprice/btc.json"; //URL into variable for quick use;
                json = web.DownloadString(url);
            }

            dynamic livePr = Newtonsoft.Json.JsonConvert.DeserializeObject(json); //Making the JSON file readable;
            Double btcLivePrice = Convert.ToDouble(livePr.bpi.USD.rate.Value); //And converting it to Double var
            while (main.programContinue == true) //While loop for MAIN SEQUENCE;
            {
                Console.WriteLine("-====================================================-");
                Console.WriteLine("-==Welcome to Yannick's BTC Profit Calculator v0.5==-");
                Console.WriteLine("-========BTC PRICE NOW " + btcLivePrice + "$========-");
                Console.WriteLine("-====================================================-");
                Console.WriteLine("Choose one:");
                Console.WriteLine("1. BTC Profit Calculator");
                Console.WriteLine("2. How High it has to go?");
                Console.WriteLine("3. What is my BTC worth");
                Console.WriteLine("4. BTC per one Person");
                Console.WriteLine("5. How much coins I need for profit");
                Console.WriteLine("6. Your average BTC Value");
                Console.WriteLine("0. Exit");
                main.choice = int.Parse(Console.ReadLine()); //asking for choice input;
                switch (main.choice)
                {
                    case 0: //Exit the program and display bb message;
                        Exit();
                        main.programContinue = false;
                        break;
                    case 1: //BTC PROFIT CALCULATOR;
                        Console.WriteLine("");
                        Console.WriteLine("Enter BTC value at Buy position:");
                        main.btcValue = Double.Parse(Console.ReadLine()); //Read btcValue, amountTraded, btcSellValue, exchangeFee;

                        Console.WriteLine("Enter BTC value at Sell position:");
                        main.btcSellValue = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter amount of BTC traded: ");
                        main.amountTraded = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter fees that your Exchange is using (value in percent ie.:0,0075):");
                        main.exchangeFee = Double.Parse(Console.ReadLine());

                        main.profit = (main.btcSellValue * main.amountTraded) - (main.btcValue * main.amountTraded); //Take on on the profit variable and total value;
                        main.totalValue = main.profit + (main.btcValue * main.amountTraded);

                        Console.WriteLine("Your pure profit is: " + main.profit); //Display what we managed to calculate;
                        Console.WriteLine("Your total value is: !" + main.totalValue + "!");
                        main.profitCalc = (main.profit / 100.0) * main.exchangeFee;
                        main.feeProfit = main.profit - main.profitCalc;

                        bool negFee = main.feeProfit < 0; //New variable to make sure Negative Fee is not an problem;
                        Console.WriteLine("Your fees are equal to: " + main.profitCalc);
                        if (negFee == true) //Condition to check for Negative Fee and calculate by that;
                        { //Something can go wrong easily, this is to make sure it doesn't;
                            main.negaFee = main.profit + main.profitCalc;
                            Console.WriteLine("Your profit with Fees is: " + main.negaFee);
                        }
                        else
                        {
                            Console.WriteLine("Your profit with Fees is: " + main.feeProfit);

                        }

                        main.increase = main.btcSellValue - main.btcValue; //Back with variable defining;
                        main.percGain = (main.increase / main.btcValue) * 100;
                        Console.WriteLine("Your percentage gain is: " + main.percGain + "%");
                        Console.WriteLine("");

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0] or Save this Data[2]?"); //Ask if user wants to continue or leave the program;
                        main.choice = int.Parse(Console.ReadLine());
                        switch (main.choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                main.programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                main.programContinue = true;
                                break;
                            case 2: //SAVE TO FILE;
                                using (StreamWriter writeText = new StreamWriter("short.btc", true))
                                {
                                    writeText.WriteLine(main.percGain + " " + DateTime.Now.ToString());
                                }
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                main.programContinue = false;
                                Console.ReadLine();
                                break;
                        }

                        break; //Breaking option 1. profit calc;

                    case 2: //EXPECTED RESULT;
                        double expectedResult;
                        double amountOwned;
                        double valueNeeded;
                        Console.WriteLine("");
                        Console.WriteLine("What is your expected result:");
                        expectedResult = Double.Parse(Console.ReadLine());

                        Console.WriteLine("How much coins do you own:");
                        amountOwned = Double.Parse(Console.ReadLine());

                        valueNeeded = expectedResult / amountOwned;
                        Console.WriteLine("Your coins need to get to: ");
                        Console.WriteLine(valueNeeded + "$$$ to reach your goal of " + expectedResult + "$");
                        Console.WriteLine("");

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        main.choice = int.Parse(Console.ReadLine());
                        switch (main.choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                main.programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                main.programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                main.programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break; //Break Case 2;

                    case 3: //WHAT IS MY BTC WORTH;

                        Console.WriteLine("");
                        Console.WriteLine("BTC Value NOW: " + btcLivePrice + "$");
                        main.btcValue = btcLivePrice;

                        Console.WriteLine("Enter amount of BTC Hodled: ");
                        main.amountTraded = Double.Parse(Console.ReadLine());

                        main.totalValue = main.amountTraded * main.btcValue;
                        Console.WriteLine("Your " + main.amountTraded + " BTC is worth $" + main.totalValue + "$ at Value of " + main.btcValue + "$ per coin");
                        Console.WriteLine("");

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0] or Save[2]?"); //Ask if user wants to continue or leave the program;
                        main.choice = int.Parse(Console.ReadLine());
                        switch (main.choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                main.programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                main.programContinue = true;
                                break;
                            case 2:
                                using (StreamWriter writeText = new StreamWriter("value.btc", true))
                                {
                                    Double[] valueArray = { main.totalValue };

                                    writeText.WriteLine(valueArray[0]);
                                }
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                main.programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break; //Breaking Case 3;


                    case 4: //BTC PER PERSON;
                        double personOnWorld = 7725989100.00; //More vars!!!;
                        double btcTotalVolume = 21000000;
                        double lostBtc = 3790000;
                        Console.WriteLine("");
                        Console.WriteLine("If you would have to distribute all of the BTC in world to all people.");
                        Console.WriteLine("Total Volume of BTC: " + btcTotalVolume);
                        Console.WriteLine("Total population: " + personOnWorld);
                        double btcPerPerson = btcTotalVolume / personOnWorld; //Quick and easy math;
                        Console.WriteLine("Volume per person: " + btcPerPerson + " BTC");
                        btcPerPerson = (btcTotalVolume - lostBtc) / personOnWorld; //Counting in the losses at BTC end;
                        Console.WriteLine("Volume per person with $$Lost$$ BTC: " + btcPerPerson);
                        Console.WriteLine("");

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        main.choice = int.Parse(Console.ReadLine());
                        switch (main.choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                main.programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                main.programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                main.programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break; //Breaking Case 4;

                    case 5: //CHECK HOW MANY COINS ARE NEEDED FOR TARGETED PROFIT
                        double coinsNeeded;
                        Console.WriteLine("");
                        Console.WriteLine("Enter expected profit: ");
                        main.totalValue = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter BUY price: ");
                        main.btcValue = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter expected SELL price: ");
                        main.btcSellValue = Double.Parse(Console.ReadLine());

                        coinsNeeded = main.totalValue / (main.btcSellValue - main.btcValue);
                        Console.WriteLine("You would need to have " + coinsNeeded + " BTC to reach your expected profit!");
                        Console.WriteLine("");

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        main.choice = int.Parse(Console.ReadLine());
                        switch (main.choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                main.programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                main.programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                main.programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break; //Breaking Case 5;

                    case 6:

                        int n = 0;
                        String[] input = File.ReadAllLines("value.btc");
                        Double[] result = new double[input.Length];
                        bool dataExists = File.Exists("value.btc");


                        Console.WriteLine("");
                        Console.WriteLine("Looking for value.btc");
                        if (dataExists == true)
                        {
                            double sum = 0;
                            double average;
                            Console.WriteLine("value.btc Found!");
                            Console.WriteLine("Checking for saved Array");
                            var okay = input;

                            /*
                             * for(int x=0; x<input.length;x++)
                             * {
                             *      result[x] = Double.Parse(value[x]);
                             *      Console.WriteLine(result[x]);
                             *      
                             *      {
                             *          
                             *      }
                             * }
                             */

                            foreach (var value in okay)
                            {
                                result[n] = Double.Parse(value);
                                Console.WriteLine(result[n]);
                                sum += result[n];
                                n += 1;
                                
                            }
                            average = sum / result.Length;
                            Console.WriteLine("Your average BTC value is:" + average);
                        }
                        else
                        {
                            Console.WriteLine("value.btc Not Found!");
                            Console.WriteLine("Be sure to save some data from Option 3!");
                            break;
                        }
                        Console.WriteLine("");

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        main.choice = int.Parse(Console.ReadLine());
                        switch (main.choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                main.programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                main.programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                main.programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break;

                    default: //DEFAULT INPUT FOR ANYTHING THAT IS NOT CHOICE VAR;
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("404#EXPECTED CHOICE ERROR#404");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        main.programContinue = true;
                        break;
                }


            }
        }
        static void Exit()
        { 
            Program main = new Program();
            
            main.programContinue = false;
            Console.WriteLine("Thanks for using Yannick's BTC Profit Calculator " + main.version);
            Console.ReadLine();
            

        }


        
    }
}//END OF PROGRAM;
