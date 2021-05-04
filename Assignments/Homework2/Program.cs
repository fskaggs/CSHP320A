//CSHP320A
//Frederick J. Skaggs - Homework 2

using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            // Display the users who's password is 'Hello'
            Console.WriteLine("Users whose password is 'Hello':");
            users.Where(x => x.Password == "hello").ToList().ForEach(x => Console.WriteLine(x.Name));

            // Delete any passwords that are the lower-cased version of their Name.
            Console.WriteLine("\nDeleting passwords which are the user's name in lower case.");
            users.FindAll(x => x.Password == x.Name.ToLower()).ForEach(x => x.Password = "");

            // Delete first user that has the password 'hello'
            Console.WriteLine("Deleting the first user that has the password 'hello'.");
            users.Remove(users.FirstOrDefault(x => x.Password == "hello"));

            // Display the remaining users
            Console.WriteLine("\nThese are the remaining users.");
            users.ForEach(x => Console.WriteLine($"Name: {x.Name}  Password: {x.Password}"));
        }
    }
}
