using System;
using System.Threading;
using CSharpInterop.Domain;

namespace CsharpInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            // ======= F# Classes =======

            var customerClass1 = new Customer("John", "Doe", new DateTime(1990, 10, 23));
            var customerClass2 = new Customer("John", "Doe", new DateTime(1990, 10, 23));

            // This doesn't compile, as F# classes have immutable properties by default
            // customerClass1.FirstName = "test";

            // unfortunately F# classes don't auto-implement Equals(), unlike F# records!
            Console.WriteLine($"Comparing two F# classes with identical data (by ref): {customerClass1 == customerClass2}"); // False
            Console.WriteLine($"Comparing two F# classes with identical data: {customerClass1.Equals(customerClass2)}"); // False

            Console.WriteLine($"calling ToString() on a F# class: {customerClass1.ToString()}"); // Displays the name of the class... Sad!
            Console.WriteLine($"Customer Code from the F# class (before delay): {customerClass1.Code}");
            Thread.Sleep(1000);
            Console.WriteLine($"Customer Code from the F# class (after delay): {customerClass1.Code}"); // the value will be the same as it was calculated in the ctor

            // ======= F# Records =======

            var customerRecord1 = new CustomerRecord("John", "Doe", new DateTime(1990, 10, 23));
            var customerRecord2 = new CustomerRecord("John", "Doe", new DateTime(1990, 10, 23));

            // This doesn't compile either, as F# records are fully immutable
            // customerRecord1.FirstName = "test";

            // F# records do implement semantic equality
            Console.WriteLine($"Comparing two F# records with identical data (by ref): {customerRecord1 == customerRecord2}"); // False
            Console.WriteLine($"Comparing two F# records with identical data: {customerRecord1.Equals(customerRecord2)}"); // True, thanks to auto-implementation of Equals()!

            Console.WriteLine($"calling ToString() on a F# record: {customerRecord1.ToString()}"); // Pretty-prints the content of all fields in the record
            Console.WriteLine($"Customer Code from the F# record (before delay): {customerRecord1.Code}");
            Thread.Sleep(1000);
            Console.WriteLine($"Customer Code from the F# record (after delay): {customerRecord1.Code}"); // the value will change since it is calling a function each time

            // Variant where we use a Create function where the Code is calculated only once
            var firstName = "John";
            var lastName = "Doe";
            var customerRecord21 =  CustomerRecord2.Create(firstName, lastName, new DateTime(1990, 10, 23));
            Console.WriteLine($"calling ToString() on a F# record (variant): {customerRecord21.ToString()}");
        }
    }
}
