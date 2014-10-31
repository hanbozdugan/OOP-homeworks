using System;
using System.Linq;

namespace GenericListApp
{
    public class GenericListTester
    {
        public static void Main()
        {
            GenericList<int> myList = new GenericList<int>();

            Console.WriteLine();

            myList.Add(123);
            myList.Add(1293);
            myList.Add(11);
            myList.Add(12314);
            myList.Add(111111);
            
            Console.WriteLine(myList);
            myList.Remove(2);
            myList.Insert(11, 2);
            myList.Insert(666, 0);
            Console.WriteLine(myList);
            Console.WriteLine(myList.Find(11));
            Console.WriteLine(myList.Contains(11121));
            myList.Add(-100);
            Console.WriteLine(myList.Min());

            Type type = myList.GetType();
            object[] allAttributes =
                type.GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof (VersionAttribute))
                .ToArray();

            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine(attr.Major + "." + attr.Minor);
            }
        } 
    }
}