using System;
using System.Collections.Generic;

namespace Lab4_3_CustomerManagementSystem
{
    class Customer
    {
        private string pCompany;
        private string pContactName;
        private string pContactEmail;
        private string pPhone;
        public Customer(string _Company, string _ContactName, string _ContactEmail, string _ContactPhone)
        {
            SetCompany(_Company);
            SetContactName(_ContactName);
            SetContactEmail(_ContactEmail);
            SetPhone(_ContactPhone);
        }
        public string GetCompany()
        {
            return pCompany;
        }
        public void SetCompany(string _Company)
        {
            pCompany = _Company;
        }
        public string GetContactName()
        {
            return pContactName;
        }
        public void SetContactName(string _ContactName)
        {
            pContactName = _ContactName;
        }
        public string GetContactEmail()
        {
            return pContactEmail;
        }
        public void SetContactEmail(string _ContactEmail)
        {
            pContactEmail = _ContactEmail;
        }
        public string GetPhone()
        {
            return pPhone;
        }
        public void SetPhone(string _Phone)
        {
            pPhone = _Phone;
        }
        public override string ToString()
        {
            return $"\nCompany: {pCompany}\nContact Name: {pContactName}\nContact Email: {pContactEmail}\nCompany Phone: {pPhone}";
        }
    }
    class Program
    {
        static bool KeepSearching()
        {
            bool done = false;
            bool result = false;

            while (!done)
            {
                Console.Write("\nDo you want to search again? (y/n): ");
                string userContinue = Console.ReadLine().ToLower();

                if (userContinue == "y" || userContinue == "yes")
                {
                    result = true;
                    done = true;
                }

                else if (userContinue == "n" || userContinue == "no")
                {
                    result = false;
                    done = true;
                }

                else Console.WriteLine("Please type \"y\" or \"n\"");
            }

            return result;
        }
        static void ListCustomers(List<Customer> _customers)
        {
            foreach (Customer customer in _customers) Console.WriteLine(customer);
        }
        static Customer SearchForCustomer(List<Customer> _customers, string _userInput)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.GetCompany() == _userInput) return customer;
                else if (customer.GetPhone() == _userInput) return customer;
            }

            return null;
        }
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();

            Customer aCustomer = new Customer("Rocket Mortgage", "Jeremy Jones", "jeremyjones@rocketmortgage.com", "313-757-9201");
            customers.Add(aCustomer);

            aCustomer = new Customer("Acme Corp", "Road Runner", "roadrunner@acme.com", "555-123-4567");
            customers.Add(aCustomer);

            aCustomer = new Customer("Sirius Cybernetics Corp.", "Arthur Philip Dent", "arthurdent@siriuscybernetics.com", "42");
            customers.Add(aCustomer);
            
            Console.WriteLine("\t\t----- List of customers -----");
            ListCustomers(customers);
            Console.WriteLine("\n\t\t-------- end of list --------\n");

            do
            {
                Console.Write("Enter a company name or phone number to search for: ");
                string userInput = Console.ReadLine();
                aCustomer = SearchForCustomer(customers, userInput);
                if (aCustomer != null) Console.WriteLine($"\nCustomer found!\n{aCustomer}");
                else Console.WriteLine($"\nNo matches found for {userInput}.");
            }
            while (KeepSearching());
        }
    }
}
