using BankScaffold.Models;
namespace BankScaffold{
    public class BankClient{
      public static void Main(){
         IBankRepo SBA = new Bank();

            while (true)
            {
        Console.WriteLine("................WELCOME..................");
        Console.WriteLine("ENTER ANY OF THE FOLLOWING OPTIONS");
        Console.WriteLine("1.Add a new account");
        Console.WriteLine("2.Get details of an account");
        Console.WriteLine("3.Get details of all accounts");
        Console.WriteLine("4.Update details of an account");
        Console.WriteLine("5.Delete an account");
        Console.WriteLine("6.Make a new transaction");
        Console.WriteLine("7.Get details of all the transactions.");
        Console.WriteLine("8.Get details of all transactions of all accounts");
        int option=Convert.ToInt32(Console.ReadLine());

       switch (option)
                {
                    case 1:
                        // New Account
                       // Console.Write("Enter Account Number,AccountHolder name,AccountHolder address and current balance");
                        SBA.AddNewAccount();
                        break;

                    case 2:
                        // Get Details of an Account
                        Console.Write("Enter Account Number: ");
                        int accountNumber = Convert.ToInt32(Console.ReadLine());
                        SBA.GetDetailsOfAccount(accountNumber);
                        break;

                    case 3:
                        // Get Details of all Accounts
                        Console.WriteLine("All Accounts Details are:");
                        SBA.GetDetailsOfAllAccounts();
                        break;

                    case 4:
                        // Update Details oF an account
                        Console.Write("Enter Account Number of the account to be updated: ");
                        int accountNo = Convert.ToInt32(Console.ReadLine());
                        SBA.UpdateDetails(accountNo);
                        break;

                    case 5:
                        // Delete an account
                        Console.Write("Enter Account Number of account to be deleted: ");
                        int ac_no = Convert.ToInt32(Console.ReadLine());
                        SBA.DeleteAccount(ac_no);
                        break;

                    case 6:
                    //Making a new transaction
                     System.Console.WriteLine("Enter details of the new transaction to be made: 1.Account number 2.Amount 3. Transaction TYpe 4. Transaction date");
                     int AcNo = Convert.ToInt32(System.Console.ReadLine());
                     decimal amnt=Convert.ToDecimal(System.Console.ReadLine());
                     string ttype=Console.ReadLine();
                     DateTime t_date=Convert.ToDateTime(Console.ReadLine());
                     SBA.MakeTransaction(AcNo, amnt,ttype,t_date);
                    break;
                    
                    case 7:
                    //get details of all transactions
                    Console.WriteLine("....Here's the details of all the transactions....");
                    SBA.GetDetailsOfAlltransactions();
                    break;
                    case 8:
                    //Getting details of all transactions related to each account
                    Console.WriteLine("..Here are the details of transactions associated with these account...");
                    SBA.GetDetailsOfAllTransactionsForAllAccount();
                    break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
      }
    }
}