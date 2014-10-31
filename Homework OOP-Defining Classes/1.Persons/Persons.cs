using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class PersonsClass
    {
       static void Main(string[] args)
       {
               List<Person> persons=new List<Person>(){
                   new Person("Ivan", 41),
                   new Person("Pesho", 34, "alabala@abv.bg"),
                   new Person("Gosho", 28, "alabala@dir.bg"),
               };
               persons.ForEach(p=>Console.WriteLine(p.ToString()));
       }
    }
}