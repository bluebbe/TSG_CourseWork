using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private static Dictionary<string, Account> _account = new Dictionary<string, Account>();

        private string fileSource = @"\\Mac\Home\Documents\SWGuild\bert-luebbe-individual-work\SGBank\SGBank.UI\bin\Debug\Accounts.txt";

        private static string dataHeader;

        public FileAccountRepository()
        {

            ReadDataFromFile();

        }

        public Account LoadAccount(string AccountNumber)
        {

            

            if (_account.ContainsKey(AccountNumber)) return _account[AccountNumber];


            return null;
            
        }

        public void SaveAccount(Account account)
        {
            if (_account.ContainsKey(account.AccountNumber))
            {
                _account[account.AccountNumber] = account;
                SaveDataToFile();
            }

            
        }

        private void ReadDataFromFile()
        {
            if(_account.Count == 0)
            {
                FileInfo file = new FileInfo(fileSource);



                using (TextReader tr = file.OpenText())
                {
                    dataHeader = tr.ReadLine(); // capture dataHeader when saving data back to file

                    string row;
                    Account account;

                    while (!string.IsNullOrEmpty(row = tr.ReadLine()))
                    {

                        account = new Account();
                        row = row.Replace('"', ' ');

                        string[] output = row.Split(',');

                        account.AccountNumber = output[0];
                        account.Name = output[1];
                        account.Balance = Convert.ToDecimal(output[2]);

                        switch (output[3])
                        {
                            case "F":
                                account.Type = AccountType.Free;
                                break;
                            case "B":
                                account.Type = AccountType.Basic;
                                break;
                            case "P":
                                account.Type = AccountType.Premium;
                                break;

                        }



                        _account.Add(account.AccountNumber, account);

                       
                    }
                }
            }


        }

        private void SaveDataToFile()
        {

 
            using (TextWriter tw = File.CreateText(fileSource))
            {


                tw.WriteLine(dataHeader);

                string accountType="";

                foreach (var account in _account)
                {
                    switch (account.Value.Type)
                    {

                        case AccountType.Free:
                            accountType = "F";
                            break;

                        case AccountType.Basic:
                            accountType = "B";
                            break;

                        case AccountType.Premium:
                            accountType = "P";
                            break;


                    }

                    tw.WriteLine($"{account.Value.AccountNumber},{account.Value.Name},{account.Value.Balance:#},{accountType}");

                }

                //dataHeader = tr.ReadLine(); // capture dataHeader when saving data back to file

                //string row;
                //Account account;

                //while (!string.IsNullOrEmpty(row = tr.ReadLine()))
                //{

                //    account = new Account();
                //    row = row.Replace('"', ' ');

                //    string[] output = row.Split(',');

                //    account.AccountNumber = output[0];
                //    account.Name = output[1];
                //    account.Balance = Convert.ToDecimal(output[2]);

                //    switch (output[3])
                //    {
                //        case "F":
                //            account.Type = AccountType.Free;
                //            break;
                //        case "B":
                //            account.Type = AccountType.Basic;
                //            break;
                //        case "P":
                //            account.Type = AccountType.Premium;
                //            break;

                //    }



                    //_account.Add(account.AccountNumber, account);

                
            }



        }



    }
}
