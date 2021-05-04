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

            Console.WriteLine("Users whose password is 'Hello':");
            users.Where(x => x.Password == "hello").ToList().ForEach(x => Console.WriteLine(x.Name));

            // Remove users where password is their name in lower case
            Console.WriteLine("\nRemoving users where the password is their name in lower case.");
            users.FindAll(x => x.Password == x.Name.ToLower()).ForEach(x => x.Password = "");

            // Delete first user where password is 'hello'
            Console.WriteLine("Deleting the first user who's password is 'hello'.");
            users.Remove(users.FirstOrDefault(x => x.Password == "hello"));

            // Display the remaining users
            Console.WriteLine("\nThese are the remaining users.");
            users.Where(x => x.Password == "hello").ToList().ForEach(x => Console.WriteLine($"Name: {x.Name}  Password: {x.Password}"));
        }
    }
}
