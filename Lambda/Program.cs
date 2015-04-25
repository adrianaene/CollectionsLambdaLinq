using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lambda.Delegate;
using System.Collections;

namespace Lambda
{
    class Program
    {
        private static void DelegateExample()
        {
            Console.WriteLine("=====Example 1 (Delegate)===");

            //Create Delegate instances
            PerformCalculation sum_Function = new PerformCalculation(SpecialFunctions.Sum);
            PerformCalculation prod_Function = new PerformCalculation(SpecialFunctions.Product);

            double val1 = 2.0, val2 = 3.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_Result);

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_Result);

            //Using sum_function reference
            Console.Write("{0} + {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write("{0} * {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);


            /**
             * TODO 0
             * Goto SpecialFunctions sources and resolve TODO 1, 2 and 3.
             */

            //TODO 4: Create an instance of NumberCheck (TODO 1)
            NumberCheck even_function = new NumberCheck(SpecialFunctions.IsEven);
            //TODO 5: Use function GetEvenNumbers to select the even numbers from numbersList collection
            ArrayList numbersList = new ArrayList(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            List<int> result = SpecialFunctions.GetEvenNumbers(even_function, numbersList);
            //TODO 6: Print the resulted numbers
            foreach (int i in result)
                Console.WriteLine(i);
            Console.WriteLine();
        }

        private static void FuncDelegateExample()
        {
            Console.WriteLine("=====Example 2 (Func Delegate)===");

            //Create Func Delegate instances
            Func<double, double, double> sum_Function = new Func<double, double, double>(SpecialFunctions.Sum);
            Func<double, double, double> prod_Function = new Func<double, double, double>(SpecialFunctions.Product);
            Func<int, bool> even_Function = new Func<int, bool>(SpecialFunctions.IsEven);

            double val1 = 4.0, val2 = 5.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_Result);

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_Result);

            //Using sum_function reference
            Console.Write("{0} + {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write("{0} * {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(prod_Function, val1, val2);

            //Omitting the explicit creation of a Func instance
            Console.Write("{0} - {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(SpecialFunctions.Diff, val1, val2);

            ArrayList numbersList = new ArrayList(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            /**
             * TODO 7 
             * Create an instance of function created at TODO 2 and use it to print the odd numbers from numbersList collection
             */
            foreach (int i in numbersList)
                if (even_Function(i))
                    Console.WriteLine(i);

            Console.WriteLine();
        }

        private static void AnonymousFunctExample()
        {
            Console.WriteLine("=====Example 3 (Anonymous Functions)===");

            //Create a Func Delegate instance
            Func<double, double, double> sum_Function = delegate(double var1, double var2)
            {
                return var1 + var2;
            };
            //Create a Delegate instance
            PerformCalculation prod_Function = delegate(double var1, double var2)
            {
                return var1 * var2;
            };
            Func<int, bool> even_Function = delegate(int number)
            {
                return number % 2 == 0;
            };

            double val1 = 4.0, val2 = 3.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_Result);

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_Result);

            //Using sum_function reference
            Console.Write("{0} + {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write("{0} * {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);

            ArrayList numbersList = new ArrayList(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            /**
             * TODO 8 
             * Create an instance of function created at TODO 2 and use it to print the odd numbers from numbersList collection
             */
            foreach (int number in numbersList)
                if (even_Function(number))
                    Console.WriteLine(number);
            //Omitting the explicit creation of a Func instance
            Console.Write("{0} - {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(delegate(double var1, double var2) { return var1 + var2; },
                                                      val1,
                                                      val2);

            Console.WriteLine();
        }

        private static void LambdaExample()
        {
            Console.WriteLine("=====Example 4 (Lambda example)===");

            //Use lamba expression to create a Func delegate instance
            Func<double, double, double> sum_Function = (double var1, double var2) => var1 + var2;

            //Use lambda expression without data type to create a Func delegate instance
            Func<double, double, double> sum_Function_withoutType = (var1, var2) => var1 + var2;

            //Use lamba expression to create a delegate instance
            PerformCalculation prod_Function = (double var1, double var2) => var1 * var2;

            //Use lamba expression without data type to create a delegate instance
            PerformCalculation prod_Function_withoutType = (var1, var2) => var1 * var2;

            double val1 = 4.0, val2 = 3.0;

            //Call sum function
            double sum_Result = sum_Function(val1, val2);
            Console.WriteLine("{0} + {1} = {2}", val1, val2, sum_Result);

            //Call product function
            double prod_Result = prod_Function(val1, val2);
            Console.WriteLine("{0} * {1} = {2}", val1, val2, prod_Result);

            //Using sum_function reference
            Console.Write("{0} + {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc(sum_Function, val1, val2);

            //Using product_function reference
            Console.Write("{0} * {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction(prod_Function, val1, val2);

            //Omitting the explicit creation of a Func instance
            Console.Write("{0} - {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunctionUsingFunc((var1, var2) => var1 - var2, val1, val2);

            //Omitting the explicit creation of a delegate instance
            Console.Write("{0} - {1} = ", val1, val2);
            SpecialFunctions.ExecuteFunction((var1, var2) => var1 - var2, val1, val2);

            List<int> numbersList = new List<int>(new int[] { 0, 1, 2, 6, 8, 9, 21, 24, 10 });
            /**
             * TODO 9
             *
             * Create a lambda expression which receives two parameters and returns the biggest number
             * and use it to extract the biggest number from numbersList collection.
             */
            Func<int,int,int> max =  ((int x, int y) =>
            {
                if (x > y)
                {
                    return x;
                }
                else
                {
                    return y;
                }
            });
            int maxN = numbersList[0];
            for (int i = 1; i < numbersList.Count; i++){
                    maxN = max(numbersList[i], maxN);
            } 
            Console.WriteLine("Nr maxim:");
            Console.WriteLine(maxN);
            /**
             * TODO 10 (for home)
             * Use the lambda expression from TODO 9  to sort the collection ascending.
             */
            Console.WriteLine("Sortare:");
            int swap = 0;
            for (int i = 0; i < numbersList.Count() - 1; i++)
            {
                for (int j = i + 1; j < numbersList.Count(); j++)
                {
                    if (max(numbersList[i], numbersList[j]) == numbersList[i]) 
                    {
                        swap = numbersList[i];
                        numbersList[i] = numbersList[j];
                        numbersList[j] = swap;
                    }
                }
            }
            foreach (int i in numbersList)
                    Console.WriteLine(i);
            Console.WriteLine();
        }

        private static Func<int, int> GetIncFunc()
        {
            var incrementedValue = 0;
            Func<int, int> inc = delegate(int var1)
            {
                incrementedValue = incrementedValue + 1;
                return var1 + incrementedValue;
            };
            return inc;
        }

        private static void ClosureExample()
        {
            Console.WriteLine("=====Example 5 (Closure example)===");

            Func<int, int> incFunction = GetIncFunc();
            Console.WriteLine(incFunction(2));
            Console.WriteLine(incFunction(4));
            Console.WriteLine(GetIncFunc()(5));

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //run Delegate example
          //  DelegateExample();

            //run Func Delegate example
            // FuncDelegateExample();

            //run Anonymous functions example
           // AnonymousFunctExample();

            //run Lambda expressions example
            LambdaExample();

            //run Closure example
            //ClosureExample();

            Console.ReadKey();
        }
    }
}
