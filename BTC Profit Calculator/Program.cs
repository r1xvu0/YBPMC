/* Yannick's BTC Profit Calculator v0.3;
 */
using System;
using System.Net;
using Newtonsoft;

namespace CSharp_BTC_Profit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define all possible variables we are going to use;
            int choice;
            Double version = 0.3;
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
            string json;
            using (var web = new System.Net.WebClient())
            {
                var url = @"https://api.coindesk.com/v1/bpi/currentprice/btc.json";
                json = web.DownloadString(url);
            }

            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var btcLivePrice = Convert.ToDecimal(obj.bpi.USD.rate.Value);

            while (programContinue == true) //While loop for MAIN SEQUENCE;
            {
                Console.WriteLine("-====================================================-");
                Console.WriteLine("-==Welcome to Yannick's BTC Profit Calculator v0.3==-");
                Console.WriteLine("-========BTC PRICE NOW " + btcLivePrice + "$========-");
                Console.WriteLine("-====================================================-");
                Console.WriteLine("Choose one:");
                Console.WriteLine("1. BTC Profit Calculator");
                Console.WriteLine("2. Price for Coin");
                Console.WriteLine("3. What is my BTC worth");
                Console.WriteLine("4. BTC per one Person");
                Console.WriteLine("5. How much coins I need for profit");
                Console.WriteLine("0. Exit");
                choice = int.Parse(Console.ReadLine()); //asking for choice input;
                switch (choice)
                {
                    case 0: //Exit the program and display bb message;
                        programContinue = false;
                        Console.WriteLine("Thanks for using Yannick's BTC Profit Calculator " + version);
                        Console.ReadLine();
                        break;
                    case 1: //BTC PROFIT CALCULATOR;
                        Console.WriteLine("");
                        Console.WriteLine("Enter BTC value at Buy position:");
                        btcValue = Double.Parse(Console.ReadLine()); //Read btcValue, amountTraded, btcSellValue, exchangeFee;

                        Console.WriteLine("Enter BTC value at Sell position:");
                        btcSellValue = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter amount of BTC traded: ");
                        amountTraded = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter fees that your Exchange is using (value in percent ie.:0,0075):");
                        exchangeFee = Double.Parse(Console.ReadLine());

                        profit = (btcSellValue * amountTraded) - (btcValue * amountTraded); //Take on on the profit variable and total value;
                        totalValue = profit + (btcValue * amountTraded);

                        Console.WriteLine("Your pure profit is: " + profit); //Display what we managed to calculate;
                        Console.WriteLine("Your total value is: !" + totalValue + "!");
                        profitCalc = (profit / 100.0) * exchangeFee;
                        feeProfit = profit - profitCalc;

                        bool negFee = feeProfit < 0; //New variable to make sure Negative Fee is not an problem;
                        Console.WriteLine("Your fees are equal to: " + profitCalc);
                        if (negFee == true) //Condition to check for Negative Fee and calculate by that;
                        { //Something can go wrong easily, this is to make sure it doesn't;
                            negaFee = profit + profitCalc;
                            Console.WriteLine("Your profit with Fees is: " + negaFee);
                        }
                        else
                        {
                            Console.WriteLine("Your profit with Fees is: " + feeProfit);

                        }

                        increase = btcSellValue - btcValue; //Back with variable defining;
                        percGain = (increase / btcValue) * 100;
                        Console.WriteLine("Your percentage gain is: " + percGain + "%");
                        Console.WriteLine("");
                        
                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        choice = int.Parse(Console.ReadLine());
                        switch (choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                programContinue = false;
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
                        
                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        choice = int.Parse(Console.ReadLine());
                        switch (choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break;

                    case 3: //WHAT IS MY BTC WORTH;

                        Console.WriteLine("");
                        Console.WriteLine("BTC Value ATM: ");
                        btcValue = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter amount of BTC Hodled: ");
                        amountTraded = Double.Parse(Console.ReadLine());

                        totalValue = amountTraded * btcValue;
                        Console.WriteLine("Your " + amountTraded + " BTC is worth $" + totalValue + "$ at Value of " + btcValue + "$ per coin");
                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        choice = int.Parse(Console.ReadLine());
                        switch (choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break;


                    case 4: //BTC PER PERSON;
                        double personOnWorld = 7725989100.00; //More vars!!!;
                        double btcTotalVolume = 21000000;
                        double lostBtc = 3790000;
                        Console.WriteLine("If you would have to distribute all of the BTC in world to all people.");
                        Console.WriteLine("Total Volume of BTC: " + btcTotalVolume);
                        Console.WriteLine("Total population: " + personOnWorld);
                        double btcPerPerson = btcTotalVolume / personOnWorld; //Quick and easy math;
                        Console.WriteLine("Volume per person: " + btcPerPerson + " BTC");
                        btcPerPerson = (btcTotalVolume - lostBtc) / personOnWorld; //Counting in the losses at BTC end;
                        Console.WriteLine("Volume per person with $$Lost$$ BTC: " + btcPerPerson);

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        choice = int.Parse(Console.ReadLine());
                        switch (choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                programContinue = false;
                                Console.ReadLine();
                                break;
                        }
                        break;

                    case 5: //CHECK HOW MANY COINS ARE NEEDED FOR TARGETED PROFIT
                        double coinsNeeded;
                        Console.WriteLine("Enter expected profit: ");
                        totalValue = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter BUY price: ");
                        btcValue = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter expected SELL price: ");
                        btcSellValue = Double.Parse(Console.ReadLine());

                        coinsNeeded = totalValue / (btcSellValue - btcValue);
                        Console.WriteLine("You would need to have " + coinsNeeded + " BTC to reach your expected profit!");

                        Console.WriteLine("Do you wish to Continue[1] or Exit[0]?"); //Ask if user wants to continue or leave the program;
                        choice = int.Parse(Console.ReadLine());
                        switch (choice) //Switch for direction of the program [0]Exit or [1]Continue;
                        {
                            case 0: //EXIT;
                                programContinue = false;
                                Console.WriteLine("Thanks for using my BTC Profit Calculator. Good Bye ;]");
                                break;
                            case 1: //CONTINUE;
                                programContinue = true;
                                break;
                            default:
                                Console.WriteLine("Wrong Choice! Exitting Now");
                                programContinue = false;
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
                        programContinue = true;
                        break;
                }


            }
        }
    }
}//END OF PROGRAM;
