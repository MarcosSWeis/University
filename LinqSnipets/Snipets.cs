//ClassLibrary es un proyecto que no tiene I/O
//Sirve como apoyo a otros proyectos
//Almacena solo procesos

//importamos
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace LinqSnipets
{
    public class Snipets
    {
        //metodos basicos Linq
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "Chevrolet Corsa",
                "Audio A3",
                "Audio A4",
                "Fiat Toro",
                "Fiat palio",
                "Toyota corolla",
                "Ford Raptor",
                "Toyota SW4",
                "Jeep Grand Cherokee",
            };

            // 1. SELECT * of cars
            var carList = from car in cars select car;
            //devuleve un IEnumerable , por lo tanto lo puedo recorer         
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi
            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }




        }
        //Numbers Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Each number multiplied by 3 
            //take all numbers, but 9 // todos los numeros sin el 9 
            //Order numbers by ascending value

            var processdNumbersList =
                //La salida de datos de un es la entrda del otro
                numbers.Select(num => num * 3)//MULTIPLICO TODOS POR 3 
                .Where(num => num != 9)//TODOS MENOS EL 9
                .OrderBy(num => num); //ordenado ASC
        }


        //Linq Avanced
        static public void SearchExamples()
        {
            List<string> TextList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c",
            };

            // 1. First of all element // el primero de todos los elementos

            var first = TextList.First();

            // 2. First element that is "c"

            var cText = TextList.First(text => text.Equals("c")); //text == "c" 

            // 3. First element that contains "j"

            var jText = TextList.First(text => text.Contains("c")); //return "cj"

            // 4. First element that contains "z" or default
            //buca el elemento seleccionado o de lo contrario da un valor por defecto que es vacio (es decir no falla)
            var firstOrDefaultText = TextList.FirstOrDefault(text => text.Contains("z"));//return "" o el primero que contenga "z"

            // 5. Last element that contains "z" or default
            var LastOrDefaultText = TextList.LastOrDefault(text => text.Contains("z"));//return "" o el ultimo que contenga "z"

            // 6. Sigle values
            var uniqueText = TextList.Single();  //me devuelve la IEnumerable si los valores repetidos //si no hay nada manda un exepcion 
            var uniqueOrDefaultText = TextList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherNumbers = { 0, 2, 6 };
            //de evenNumbers dame los numeros que no esten en otherNumbers
            var myEvenNumbers = evenNumbers.Except(otherNumbers);  // {4,6}
        }
        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Option 1, text 1",
                "Option 2, text 2",
                "Option 3, text 3",
            };
            var myOpinionsSelection = myOpinions.SelectMany(options => options.Split(","));

            var enerprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employee = new[]
                    {
                        new Employee()
                        {
                            Id= 1,
                            Name= "Marcos",
                            Email = "marcos@gmail.com",
                            Salary = 20000

                        },
                        new Employee()
                        {
                            Id= 2,
                            Name= "Barbi",
                            Email = "barbi@gmail.com",
                            Salary = 3520

                        },
                        new Employee()
                        {
                            Id= 3,
                            Name= "Guille",
                            Email = "guille@gmail.com",
                            Salary = 80000

                        },
                     }
                },
                 new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 2",
                    Employee = new[]
                    {
                        new Employee()
                        {
                            Id= 4,
                            Name= "Juan",
                            Email = "juan@gmail.com",
                            Salary = 6944

                        },
                        new Employee()
                        {
                            Id= 5,
                            Name= "pepeito",
                            Email = "pepeito@gmail.com",
                            Salary = 2561

                        },
                        new Employee()
                        {
                            Id= 3,
                            Name= "Nano",
                            Email = "Nano@gmail.com",
                            Salary = 454122

                        },
                     }
                },
            };
            // obtain all Empoyed of all Enterprise

            var emplyeedList = enerprises.SelectMany(enterprise => enterprise.Employee);

            //know if ana list is empty // saber si una lista esta vacia

            bool hasEnterprise = enerprises.Any(); //true si contine empresas, del ocontario false

            bool hasEmpoyeed = enerprises.Any(enterprise => enterprise.Employee.Any());//lo que decimos aca es de todas las empresas si todas tienen empleados

            // All enterprise at least has an employee with more than $1000 of salary
            bool hasEmployeeSalaryMoreOf = enerprises.Any(enterprise =>
                                                            enterprise.Employee.Any(
                                                                employeed => employeed.Salary > 1000));//de todas la empreasas , de todos los empleados si el suledo es mayor a 1000

        }

        static public void LinqCollections()
        {
            var firstList = new List<string> { "a", "b", "c" };
            var secondList = new List<string> { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement }; //new {} me da un objeto con esos elemnetos
            //otra forma del inner join
            var commonResult2 = firstList.Join(
                                            secondList,//lista a la que hacer join
                                             element => element,//selecto 1 , es decir por el cual hago una comparativa
                                             secondElement => secondElement,//selecto 2 , es decir por el cual hago la otra comparativa
                                             (element, secondElement) => new { element, secondElement }); //resualt selector


            //OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               into TemporalList
                               from temporalElement in TemporalList.DefaultIfEmpty() //me aseguro que no sea vacio DefaultIfEmpty()
                               where   element != temporalElement
                               select new { Element = element };

            //OUTER JOIN - LEFT 2 (otra forma)
            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new {element, secondElement };

            //OUTER JOIN - RIGHT
            var rigthOuterJoin = from secondElement in secondList
                                 join element in firstList
                               on secondElement equals element  
                               into TemporalList
                               from temporalElement in TemporalList.DefaultIfEmpty() //me aseguro que no sea vacio DefaultIfEmpty()
                               where secondElement != temporalElement
                               select new { Element = secondElement };

            //UNNION
            var unionList = rigthOuterJoin.Union(rigthOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var mylist = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            // ****    SKIP  **** 

            //salteo los dos primeros elementos
            var skipTowFirstElement = mylist.Skip(2); // { 3,4,5,6,7,8,9,10 }

             //salteo los ultiomos  dos primeros elementos
            var skipLastTowFirstElement = mylist.Skip(2); // { 1,2,3,4,5,6,7,8 }

            //salteo elemento dependiendo de una condicion
            var skipWhile = mylist.SkipWhile(num => num < 4 ); // { 4,5,6,7,8,9,10 }

            // ****    TAKE  **** 

            //obtengo los primeros 2 
            var takeFirstTowValues = mylist.Take(2); // { 1,2 }

            //obtengo los ultimos 2 
            var takeLastTowValues = mylist.Take(2); // { 9,10}

            //obtengo los numeros menores que 4 
            var takeWhileSamalllerThan4 = mylist.TakeWhile(num => num < 4 ); // { 1,2,3}


        }
    }
}