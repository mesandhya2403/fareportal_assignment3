using BankScaffold.Models;
namespace BankScaffold{
    public interface IBankRepo{
         void AddNewAccount(); //function to add a new account
        void GetDetailsOfAccount(int account_no); //Gives the details of the account with this account number
        void GetDetailsOfAllAccounts();// Gives details of all the accounts
        void DeleteAccount(int account_no); //Deletes the Account with the given account number
        void UpdateDetails(int account_no); //Update the details of account with the given account number

        void MakeTransaction(int acc_no,decimal amount,string TransType,DateTime tdate); //Update the transaction table and current balance in the account table based on the transaction type and add this new record to the transaction table
        void GetDetailsOfAlltransactions(); //Gives the details of all the transactions in the transaction table
        void GetDetailsOfAllTransactionsForAllAccount(); //Gives the details of all the transactions associated with a single account
    }
}