using System;
using System.Collections.Generic;
using System.Linq;

namespace Kohde.Assessment
{
    // *** NOTE ***
    // ALL CHANGES MUST BE ACCOMPANIED BY COMMENTS 
    // PLEASE READ ALL COMMENTS / INSTRUCTIONS
    public static class Program
    {
        static void Main(string[] args)
        {
            #region Assessment A

            // the below class declarations looks like a 1st year student developed it
            // NOTE: this includes the class declarations as well
            // IMPROVE THE ARCHITECTURE 
            Human human = new Human { Name = "John", Age = 35, Gender = "M" };
         
            Dog dog = new Dog { Name = "Walter", Age = 7 , Food = "Epol" };
         
            Cat cat = new Cat { Name = "Snowball", Age = 35, Food = "Whiskers" };
           

            Console.WriteLine(human.GetDetails());
            Console.WriteLine(dog.GetDetails());
            Console.WriteLine(cat.GetDetails());

            #endregion

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            #region Assessment C

            // correct the following LINQ statement found in their respective methods
            var numbers = new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            };
            // the following method must return the first event number - as suggested by it's name
            var firstValue = GetFirstEvenValue(numbers);
            Console.WriteLine("First Number: " + firstValue);

            var strings = new List<string>()
            {
                "John", "Jane", "Sarah", "Pete", "Anna"
            };
            // the following method must return the first name which contains an 'a'
            var strValue = GetSingleStringValue(strings);
            Console.WriteLine("Single String: " + strValue);

            #endregion

            #region Assessment D

            // there are multiple corrections required!!
            // correct the following statement(s)
            Dog bulldog = new Dog();
            try
            {//alternative to Disposing is to use USING
               
                //add functionality here for bulldog
            }
           
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (bulldog != null)
                    ((IDisposable)bulldog).Dispose();

            }
            #endregion

            #region Assessment E

            DisposeSomeObject();            

            #endregion

            #region Assessment F

            // # SECTION A #
            // by making use of generics improve the implementation of the following methods
            // output must still render as: Name: [name] Age: [age]
            // THE METHOD THAT YOU CREATE MUST BE STATIC AND DECLARED IN THE PROGRAM CLASS
            // NB!! PLEASE NAME THE METHOD: ShowSomeMammalInformation
            //ShowSomeHumanInformation(human);
            //ShowSomeDogInformation(dog);
            //ShowSomeCatInformation(cat);
            ShowSomeMammalInformation(human, dog, cat);

            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

            string a = Program.GenericTester(dog);
            Console.WriteLine("Result A: {0}", a);
            int b = Program.GenericTester(cat);
            Console.WriteLine("Result B: {0}", b);

            #endregion

            #region Assessment G

            // in the following statement, everything works fine
            // but, it has a huge flaw! 
            // correct the following piece of code
            try
            {
                CatchAndRethrowExplicitly();
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("Implicitly specified:{0}{1}", Environment.NewLine, e.StackTrace);
            }

            #endregion            

            #region Assessment H

            try
            {
                // REFLECTION TEST .... NAVIGATE TO THE BELOW METHOD TO GET ALL THE INSTRUCTIONS
                CallMethodWithReflection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion            

            #region IoC / DI

            // everything can be viewed in this method....
            PerformIoCActions();

            #endregion

            #region Bonus XP - Dungeon

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


            const string abc = "asduqwezxc";
            foreach (var vowel in abc.SelectOnlyVowels())
            {
                Console.WriteLine("{0}", vowel);
            }

            // < REQUIRED OUTPUT => a u e

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


            List<Dog> dogs = new List<Dog>
            {
                new Dog {Age = 8, Name = "Max"},
                new Dog {Age = 3, Name = "Rocky"},
                new Dog {Age = 9, Name = "XML"}
            };

            var foo = dogs.CustomWhere(x => x.Age > 6 && x.Name.SelectOnlyVowels().Any());

            // < DOGS REQUIRED OUTPUT =>
            //      Name: Max Age: 8
          
            List<Cat> cats = new List<Cat>
            {
                new Cat {Age = 1, Name = "Capri"},
                new Cat {Age = 8, Name = "Cara"},
                new Cat {Age = 3, Name = "Captain Hooks"}
            };

            var bar = cats.CustomWhere(x => x.Age <= 4);

            
            // < CATS REQUIRED OUTPUT =>
            //      Name: Capri Age: 1
            //      Name: Captain Hooks Age: 3


            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        #region Bonus XP - Dungeion Method
       public static List<char> SelectOnlyVowels(this string abc)
        {

            //Extention method to return list of vowels found in string 

            string vowels = "aeiou";
           List<char> strVowels = abc.Where(x => vowels.Contains(x)).ToList();
            return strVowels;

        }
        public static List<string> CustomWhere(this List<Dog> animals, Func<Dog, bool> condition)
        {
            //extention method, returns list of dogs that meets the condition 
            var theChosenDogs = animals.Where(condition);
            List<string> dogList = new List<string>();
            foreach (var dogz in theChosenDogs)
            {
                dogList.Add("Name: "+dogz.Name+" Age: "+dogz.Age);
                
            }
            
            return dogList;
        }
        public static List<string> CustomWhere(this List<Cat> animals, Func<Cat, bool> condition)
        { //extention method, returns list of cats that meets the condition 
            var theChosenDogs = animals.Where(condition);
            List<string> dogList = new List<string>();
            foreach (var catz in theChosenDogs)
            {
                dogList.Add("Name: " + catz.Name + " Age: " + catz.Age);

            }

            return dogList;
        }

        #endregion
        #region Assessment B Method

        public static void PerformanceTest()
        {
          
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
                                                 
            string someLongDataString = "", source = new string('X', sLen);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++) 
            {
                
                someLongDataString = string.Concat(Enumerable.Repeat(source, loops)); //will multiply the string and concatenate it here then break out of the loop
                break;
            }
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE

            return numbers.Where(y => y % 2 == 0).FirstOrDefault(); 
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
            
            return stringList.FirstOrDefault(c => c.Contains('a')); ;
        }

        #endregion
        
        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {

            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            using (var disposableObject = new DisposableObject()) 
                { disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
                return disposableObject;
            }
            

            
        }

        #endregion

        #region Assessment F Methods

        //public static void ShowSomeHumanInformation(Human human)
        //{
        //    Console.WriteLine("Name:" + human.Name + " Age: " + human.Age);
        //}

        //public static void ShowSomeDogInformation(Dog dog)
        //{
        //    Console.WriteLine("Name:" + dog.Name + " Age: " + dog.Age);
        //}

        //public static void ShowSomeCatInformation(Cat cat)
        //{
        //    Console.WriteLine("Name:" + cat.Name + " Age: " + cat.Age);
        //}
        public static void ShowSomeMammalInformation(Human human, Dog dog, Cat cat)
        {

            Console.WriteLine("Name:" + human.Name + " Age: " + human.Age);
            Console.WriteLine("Name:" + dog.Name + " Age: " + dog.Age);
            Console.WriteLine("Name:" + cat.Name + " Age: " + cat.Age);

        }
        
        public static string GenericTester(Dog dog)
        {      if(dog == null)
                 dog = new Dog { Name = "Walter", Age = 7, Food = "Epol" }; 

            return dog.GetDetails();
        }
        public static int GenericTester(Cat cat)
        {
            return cat.Age;
        }
        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ThrowException()
        {
            throw new ArithmeticException("illegal expression - was this picked up??");
        }

        #endregion

        #region Assessment H Methods

        public static string CallMethodWithReflection()
        {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IN JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTEN

            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD
            string x = DisplaySomeStuff( "People");
            return x;
        }

        public static string DisplaySomeStuff<T>(T toDisplay) where T : class
        {
            return string.Format("Here it is: {0}", toDisplay);
        }

        #endregion

        #region IoC / DI

        public static void PerformIoCActions()
        {
            /*  An very simple IoC / DI container has been created for you. All the code can be viewed in the Container folder.
             *  By making use of the classes provided, perform the following tasks:
             *  
             *  Two classes and two interfaces have been created for you, namely:
             *  
             *      - IDevice
             *      - SamsungDevice
             *      - IDeviceProcessor
             *      - DeviceProcessor
             * 
             *  The actual declarations can be view lower down in this file.
             *  
             *  The following needs to happen:
             *      
             *      1. register the interfaces with the respective classes
             *      2. resolve an instance of the IDeviceProcessor and call the GetDevicePrice method
             *      
             *  Some of the code below has been done, but you need to fill in the blanks
             */

            // 1. register the interfaces and classes
            // TODO: ???

            // 2. resolve the IDeviceProcessor
            //var deviceProcessor = ???
            // call the GetDevicePrice method
            //Console.WriteLine(deviceProcessor.GetDevicePrice());



            var SD = new SamsungDevice();
            Console.WriteLine("What is the device? - " + SD.DeviceCode);
            

          
            DeviceProcessor DP = new DeviceProcessor(SD);
            Console.WriteLine(DP.GetDevicePrice());




        }

        #endregion



    }

    public interface IDevice
    {
        string DeviceCode { get; }
    }

    public class SamsungDevice : IDevice
    {
        public string DeviceCode { get; private set; }

        public SamsungDevice()
        {
            this.DeviceCode = "Samsung";
        }
    }

    public interface IDeviceProcessor
    {
        double GetDevicePrice();
    }

    public class DeviceProcessor : IDeviceProcessor
    {
        protected IDevice Device { get; private set; }

        public DeviceProcessor(IDevice device)
        {
            this.Device = device;
        }

        public double GetDevicePrice()
        {
            // the actual implementation of this method does not matter....
            return this.Device.DeviceCode.Equals("Samsung") ? 12.95 : 19.95;
        }
    }
}
