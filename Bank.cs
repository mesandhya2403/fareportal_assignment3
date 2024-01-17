using System.Transactions;
using BankScaffold.Models;
using Microsoft.Identity.Client;
namespace BankScaffold{
  
   
    public class Bank:IBankRepo{
        int TransId=1;
     static Ace52024Context db=new Ace52024Context();
     public void AddNewAccount(){
     SandhyasSbaccount acc=new SandhyasSbaccount();
     Console.WriteLine("Enter account no, account holder name, account holder address, current balance for the account to be added");
     acc.AccountNumber=Convert.ToInt32(Console.ReadLine());
     acc.CustomerName=Console.ReadLine();
     acc.CustomerAddress=Console.ReadLine();
     acc.CurrentBalance=Convert.ToDecimal(Console.ReadLine());
     acc.Amount=acc.CurrentBalance;
     db.SandhyasSbaccounts.Add(acc);
     db.SaveChanges();
     Console.WriteLine("Your Account is added successfully");
     } //function to add a new account

    public void GetDetailsOfAccount(int account_no){
       SandhyasSbaccount account=new SandhyasSbaccount();
       account=db.SandhyasSbaccounts.Find(account_no);
       if(account==null){
        Console.WriteLine("Sorry no such account exists,please check and enter the account number again");
        throw new InvalidOperationException("Account not found");
       }
       else{
         System.Console.WriteLine($"Account Number: {account.AccountNumber}, Account Holder Name: {account.CustomerName}, Account Balance : {account.CurrentBalance}, Address: {account.CustomerAddress}");
       }
       } //Gives the details of the account with this account number
        public void GetDetailsOfAllAccounts(){

        foreach(var item in db.SandhyasSbaccounts){
            Console.WriteLine($"Account Number:{item.AccountNumber},Account Holder Name:{item.CustomerName}, Account Holder's Address: {item.CustomerAddress}, Current Balance: {item.CurrentBalance}");
        }
        }
            // Gives details of all the accounts
        public void DeleteAccount(int account_no){
          SandhyasSbaccount account=new SandhyasSbaccount();
          account=db.SandhyasSbaccounts.Find(account_no);
          if(account==null){
        Console.WriteLine("Sorry no such account exists,please check and enter the account number again");
        throw new InvalidOperationException("Account not found");
       }
       else{
          db.SandhyasSbaccounts.Remove(account);
          db.SaveChanges();
          Console.WriteLine("The record was deleted");
       }
        } //Deletes the Account with the given account number
        public void UpdateDetails(int account_no){
         SandhyasSbaccount acc=new SandhyasSbaccount();
         acc=db.SandhyasSbaccounts.Find(account_no);
         if(acc==null){
        Console.WriteLine("Sorry no such account exists,please check and enter the account number again");
        throw new InvalidOperationException("Account not found");
       }
       else{
     Console.WriteLine("Enter account no, account holder name, account holder address, currentbalance for he account to be added");
     acc.AccountNumber=Convert.ToInt32(Console.ReadLine());
     acc.CustomerName=Console.ReadLine();
     acc.CustomerAddress=Console.ReadLine();
     acc.CurrentBalance=Convert.ToDecimal(Console.ReadLine());
     acc.Amount=acc.CurrentBalance;
     db.SandhyasSbaccounts.Update(acc);
     db.SaveChanges();
     Console.WriteLine("Your Account is updated successfully");
       }
        } //Update the details of account with the given account number
        

       public void MakeTransaction(int acc_no,decimal amount,string TransType,DateTime tdate){
        SandhyasSbaccount acount=new SandhyasSbaccount();
        SandhyaSbtransaction trans= new SandhyaSbtransaction();
        acount=db.SandhyasSbaccounts.Find(acc_no);
        if(acount==null){
            Console.WriteLine("Sorry this account doesnt exists, check and enter again");
        }
        else{
         if(TransType.ToLower()=="withdraw"){
            if(amount>acount.CurrentBalance){
             Console.WriteLine("Sorry you dont have enough balance");
            }
            else{
                TransId=TransId++;
                acount.CurrentBalance=acount.CurrentBalance-amount;
                Console.WriteLine("you withdrawed "+amount+ " from the account named "+acount.CustomerName+" and your current balance is "+ acount.CurrentBalance);
            }
         }
         else if(TransType.ToLower()=="deposit"){
            TransId=TransId++;
            acount.CurrentBalance=acount.CurrentBalance+amount;
            Console.WriteLine("you deposited "+amount+ " to the account named "+acount.CustomerName +" and your current balance is "+ acount.CurrentBalance);
         }
         trans.TransactionId=TransId;
         trans.Amount=amount;
         trans.TransactionType=TransType;
         trans.AccountNumber=acc_no;
         trans.TransactionDate=tdate;
         db.SandhyaSbtransactions.Add(trans);
         db.SaveChanges();
         db.SandhyasSbaccounts.Update(acount);
         db.SaveChanges();
        }
        } //Update the transaction table and current balance in the account table based on the transaction type and add this new record to the transaction table
        public void GetDetailsOfAlltransactions(){
         foreach (var item in db.SandhyaSbtransactions)
         {
            Console.WriteLine($"Transaction id:{item.TransactionId}, Transaction type:{item.TransactionType}, Transaction amount: {item.Amount}, Transaction Date: {item.TransactionDate}, Transaction Acoount no.{item.AccountNumber}");
         }
        } //Gives the details of all the transactions in the transaction table
        public void GetDetailsOfAllTransactionsForAllAccount(){

         foreach (var i in db.SandhyasSbaccounts)
         {
            Console.WriteLine("For the account with account no:"+ i.AccountNumber+" The details of transactions are as follows");
           foreach (var item in i.SandhyaSbtransactions)
           {
            Console.WriteLine($"Transaction id:{item.TransactionId}, Transaction type:{item.TransactionType}, Transacrion amount: {item.Amount}, Transaction Date: {item.TransactionDate}, Transaction Acoount no.{item.AccountNumber}");
           } 
         }
        } //Gives the details of all the transactions associated with a each account
    }
    }
    
