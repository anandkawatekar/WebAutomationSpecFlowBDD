using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationSpecFlow.Utils;

namespace TestAutomationSpecFlow.Data
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AddressAlias { get; set; }

        public static User GetNewUserData()
        {
            return new User()
            {
                FirstName = RandomData.GetRandomString(4),
                LastName = RandomData.GetRandomString(4),
                Email = RandomData.GetRandomString(4) + RandomData.GetRandomNumbers(3) + "@testmail.com",
                Password = RandomData.GetRandomString(8),
                DOB = Convert.ToDateTime("01/02/1987"),

                AddressLine1 = RandomData.GetRandomString(6),
                AddressLine2 = RandomData.GetRandomString(7),
                City = RandomData.GetRandomString(5),
                State = "Alaska",
                PostalCode = RandomData.GetRandomNumbers(5),
                Country = "United States",
                Phone = RandomData.GetRandomNumbers(10),
                AddressAlias = RandomData.GetRandomString(5)
            };
        }
    }
}
