using System;

namespace Kohde.Assessment
{
    public class Dog : System.IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }

        public void Dispose()
        {
            //code actions to dipsose
       
            Console.WriteLine("Object disposed");
         
        }

        public string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }
    }
}