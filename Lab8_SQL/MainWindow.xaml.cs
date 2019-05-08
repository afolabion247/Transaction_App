using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace Banking_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private List<Account> CustomersList = new List<Account>(); //create object for account
        private List<Transactions> TransactionsList = new List<Transactions>();//create object for transactions
        private Account CurrentCustomer;
        private int CurrentSelectedIndex;
        private Transactions CurrentTransaction;
        private int CurrentTransactionSeletedIndex;
       
        public MainWindow()
        {
            InitializeComponent();
            LoadCustomers();// load the accounts in the customer account list box

        }


        private void DisplayCustomer(Account CustomerItem)
        {
            if (displayListBox.SelectedItem != null)
            {
                accountNumberTextBox.Text = CustomerItem.AccountNumber.ToString();
                firstNameTextBox.Text = CustomerItem.FirstName;
                lastNameTextBox.Text = CustomerItem.LastName;
                emailTextBox.Text = CustomerItem.Email;
                phoneTextBox.Text = CustomerItem.Phone;

            }
            else
            {
                accountNumberTextBox.Text = "";
                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                emailTextBox.Text = "";
                phoneTextBox.Text = "";
                balanceTextBox.Text = "";
            }

        }


        // load customer method
        public void LoadCustomers()
        {
            CustomersList.Clear(); // empty out the List<>

            displayListBox.Items.Clear();  // empty out the listbox

            //declare a connection object
            using (SqlConnection connection = new SqlConnection())
            {
                // connection to the Customer Account  database
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";

                connection.Open();//open the connection

                string sql = "SELECT * FROM CustomerAccounts Order By AccountNumber;";


                SqlCommand myCommand = new SqlCommand(sql, connection);// create a new connection object


                using (SqlDataReader myDataReader = myCommand.ExecuteReader())//sing the ExecuteReader() method.
                {

                    while (myDataReader.Read())
                    {
                        // each colum of the datareader goes into one property of a Customer Object
                        Account NewCustomer = new Account(myDataReader.GetInt32(0),
                                                            (string)myDataReader["FirstName"],
                                                            (string)myDataReader["LastName"],
                                                            myDataReader.GetString(3),
                                                             (string)myDataReader["Phone"]);

                        //add the Customer to the List<Contact>
                        CustomersList.Add(NewCustomer); // adds an object to end of List<>

                        // add the contact to the listbox
                        displayListBox.Items.Add(NewCustomer);
                        CurrentSelectedIndex++;

                    }
                }
            }

        }

      

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            IsDataValid();// validate data and call the save method
            
        }

           void SaveRecord()
        {
            IsDataValid();// validate data and call the save method
                          // get the new updated data from the form
            CurrentCustomer.AccountNumber = Convert.ToInt32(accountNumberTextBox.Text);
            CurrentCustomer.FirstName = firstNameTextBox.Text;
            CurrentCustomer.LastName = lastNameTextBox.Text;
            CurrentCustomer.Email = emailTextBox.Text;
            CurrentCustomer.Phone = phoneTextBox.Text;
            //CurrentCustomer.Balance = Convert.ToDecimal(balanceTextBox.Text);


            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";
                
                connection.Open();// To open the connection

                string sql = $"Update CustomerAccounts Set " +

                             $"FirstName = '{CurrentCustomer.FirstName}', " +
                             $"LastName = '{CurrentCustomer.LastName}', " +
                             $"Email = '{CurrentCustomer.Email}', " +
                             $"Phone = '{CurrentCustomer.Phone}' " +
                 $"Where AccountNumber = '{CurrentCustomer.AccountNumber}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery(); // to return records back
                }

                
                LoadCustomers(); // refresh the lists
                
            }

            // to clear screen after deleting
            accountNumberTextBox.Clear();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();          
            balanceTextBox.Clear();

        }

        bool IsDataValid()
        {

            if (firstNameTextBox.Text == "" ||
              lastNameTextBox.Text == " " ||
            accountNumberTextBox.Text == "" ||
            emailTextBox.Text == "")

            {
                errorTextBox.Text = (" You cant save a blank information ");

                return false;


            }
           
            // save record if its true
            SaveRecord();
            
            return true;

        }
        private void saveNewButton_Click(object sender, RoutedEventArgs e)
        {
            Account NewCustomerInfo = new Account();

            NewCustomerInfo.AccountNumber = Convert.ToInt32(accountNumberTextBox.Text);
            NewCustomerInfo.FirstName = firstNameTextBox.Text;
            NewCustomerInfo.LastName = lastNameTextBox.Text;
            NewCustomerInfo.Email = emailTextBox.Text;
            NewCustomerInfo.Phone = phoneTextBox.Text;

         
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";

                connection.Open();

                string sql = $"INSERT INTO CustomerAccounts " +
                                 "(AccountNumber, FirstName, LastName, Email, Phone) " +
                                 "VALUES " +
                                 $"({NewCustomerInfo.AccountNumber}, " +
                                 $"'{NewCustomerInfo.FirstName}', " +
                                 $"'{NewCustomerInfo.LastName}', " +
                                 $"'{NewCustomerInfo.Email}', " +
                                 $"'{NewCustomerInfo.Phone}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                LoadCustomers();// refesh the screen
                    
            }
            //  clear the textboxes , to prevent the user to save twice.
            accountNumberTextBox.Clear();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            balanceTextBox.Clear();

        }

        private void displayListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            CurrentCustomer = (Account)displayListBox.SelectedItem;
            CurrentSelectedIndex = displayListBox.SelectedIndex;
            if (displayListBox.SelectedItem != null)
            {
                LoadTransactions();
            }
            DisplayCustomer(CurrentCustomer);// To display the current customer 

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            {
                int IndexToDelete= CurrentSelectedIndex;

                if (CurrentSelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Customer to delete.");
                    return;
                }
                var Result = MessageBox.Show("Are you sure you want to delete " + CurrentCustomer.ToString() + "?",
                "Current Record", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {
                    IndexToDelete = CurrentSelectedIndex;

                    using (SqlConnection connection = new SqlConnection())
                    {
                        connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";
                        connection.Open();

                        string sql = $"Delete from CustomerAccounts where AccountNumber = {CurrentCustomer.AccountNumber}";
                        SqlCommand myCommand = new SqlCommand(sql, connection);

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                Exception error = new Exception("No record matching the CustomerNumber", ex);
                                throw error;
                            }
                        }
                    }


               }

                if (IndexToDelete == CustomersList.Count)
                {
                    CurrentSelectedIndex = CustomersList.Count - 1;
                }
                else
                {
                    CurrentSelectedIndex = IndexToDelete;
                }
              
                // otherwise, just use same index as the deleted item 

                displayListBox.SelectedIndex = CurrentSelectedIndex;

                LoadCustomers();
            }

            accountNumberTextBox.Clear();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            balanceTextBox.Clear();

           
        }
        public void LoadTransactions()
        {
            decimal Bal = 0;
            TransactionsList.Clear(); // empty out the List<>

            listBox.Items.Clear();  // empty out the listbox

            // To Load the Transaction from the database and add them to the listbox
            //declare a connection object to connect to customer account
            using (SqlConnection connection = new SqlConnection())
            {
                // connection to the Customer Account  database
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";

                connection.Open();//open the connection
                // select from the account transaction table
                string sql = $"SELECT * FROM AccountTransactions where AccountNumber = '{CurrentCustomer.AccountNumber}';";


                SqlCommand myCommand = new SqlCommand(sql, connection);// in a new connection object


                using (SqlDataReader myDataReader = myCommand.ExecuteReader())//using the ExecuteReader() method to read the date from the transaction table
                {

                    while (myDataReader.Read())
                    {
                        // each colum of the datareader goes into one property of a Customer Object
                        Transactions Newtransactions = new Transactions (myDataReader.GetInt32(0),
                                                                         myDataReader.GetInt32(1),
                                                                         myDataReader.GetDateTime(2),
                                                                         myDataReader.GetDecimal(3));

                        //add the new transaction to the List<Transaction>
                        TransactionsList.Add(Newtransactions); // adds an object to end of List<>

                        Bal += myDataReader.GetDecimal(3);// to add the initial balance in the 
                       
                        // add the trasaction to the listbox
                        listBox.Items.Add(Newtransactions);
                        //CurrentSelectedIndex++;

                    }
                }
            }
            balanceTextBox.Text = $"{Bal}";
        }
        private void DisplayTransactions(Transactions TransactionItem)
        {
            if (listBox.SelectedItem != null)
            {

                transactionNumberTextBox.Text = $"{TransactionItem.TransactionNumber}";
                transactionDateTextBox.Text = $"{TransactionItem.TransactionDate}";
                amountTextBox.Text = $"{TransactionItem.TransactionAmount}";
              

            }
            else
            {

                transactionNumberTextBox.Text = "";
                transactionDateTextBox.Text = "";
                amountTextBox.Text = "";

            }

        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentTransaction = (Transactions)listBox.SelectedItem;
            CurrentTransactionSeletedIndex= listBox.SelectedIndex;
            DisplayTransactions(CurrentTransaction);
        }

        private void DeleteTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            {
                int IndexToDelete1;

                if (CurrentTransactionSeletedIndex == -1)
                {
                    MessageBox.Show("You must select a Customer to delete.");
                    return;
                }
                var Result = MessageBox.Show("Are you sure you want to delete " + CurrentTransaction.ToString() + "?",
                "Current Record", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {
                    IndexToDelete1 = CurrentTransactionSeletedIndex;

                    using (SqlConnection connection = new SqlConnection())
                    {
                        connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";
                        connection.Open();

                        string sql = $"Delete from AccountTransactions where TransactionNumber = {CurrentTransaction.TransactionNumber}";
                        SqlCommand myCommand = new SqlCommand(sql, connection);

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                Exception error = new Exception("No record matching the TransactionNumber", ex);
                                throw error;
                            }
                        }
                    }
                }


                LoadTransactions();
            }

            transactionNumberTextBox.Clear();
            transactionDateTextBox.Clear();
            amountTextBox.Clear();
            
        }

        private void SaveTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            SaveTransactionRecord();
        }
        void SaveTransactionRecord()
        {// get the new updated data from the form
            CurrentTransaction.TransactionDate=Convert.ToDateTime(transactionDateTextBox.Text);
            CurrentTransaction.TransactionAmount =Convert.ToDecimal(amountTextBox.Text);

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";

                connection.Open();// To open the connection

                string sql = $"Update AccountTransactions Set " +
                             $"TransactionDate= '{CurrentTransaction.TransactionDate}', " +
                             $"TransactionAmount= '{CurrentTransaction.TransactionAmount}' " +
                             $"Where TransactionNumber = '{CurrentTransaction.TransactionNumber}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery(); // to return  transaction records back
                }


                LoadTransactions(); // refresh the transaction  lists
            }
            // to clear screen after deleting
            transactionNumberTextBox.Clear();
            transactionDateTextBox.Clear();
            amountTextBox.Clear();

        }

        private void NewTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            Transactions NewTransactionInfo = new Transactions();

            NewTransactionInfo.TransactionNumber = Convert.ToInt32(transactionNumberTextBox.Text);
            NewTransactionInfo.TransactionDate = Convert.ToDateTime(transactionDateTextBox.Text);
            NewTransactionInfo.TransactionAmount = Convert.ToDecimal(amountTextBox.Text);


            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CustomerAccounts.mdf;Integrated Security=True";

                connection.Open();

                string sql = $"INSERT INTO AccountTransactions " +
                                 "(TransactionNumber, AccountNumber, TransactionDate, TransactionAmount) " +
                                 "VALUES " +
                                 $"({NewTransactionInfo.TransactionNumber}, " +
                                 $"'{CurrentCustomer.AccountNumber}', " +
                                 $"'{NewTransactionInfo.TransactionDate}', " +
                                 $"'{NewTransactionInfo.TransactionAmount}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                LoadTransactions();


            }

            transactionNumberTextBox.Clear();
            transactionDateTextBox.Clear();
            amountTextBox.Clear();
        }
    }

}
