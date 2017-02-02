using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinq.Classes;

namespace TestLinq
{

    public static class testerLinq
    {

        #region "Modalità per filtrare un array di oggetti"
       
        public static void QueryAnObjectArrayWithForCicle()
        {
            Student[] studentArray = {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 },
            new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 },
            new Student() { StudentID = 7, StudentName = "Rob",Age = 19  },
        };

            Student[] students = new Student[10];

            int i = 0;

            foreach (Student std in studentArray)
            {
                if (std.Age > 12 && std.Age < 20)
                {
                    students[i] = std;
                    i++;
                }
            }
        }
        public static void QueryAnObjectArrayWithDelegate()
        {

            Student[] studentArray = {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
            new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
        };

            Student[] students = StudentExtension.where(studentArray, delegate (Student std)
            {
                return std.Age > 12 && std.Age < 20;
            });

            //Student[] students = StudentExtension.where(studentArray, delegate (Student std) {
            //    return std.StudentID == 5;
            //});

            //Student[] students = StudentExtension.where(studentArray, delegate (Student std) {
            //    return std.StudentName == "Bill";
            //});
        }
        public static void QueryAnObjectArrayWithLinq()
        {
            Student[] studentArray = {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
                    new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
                    new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
                };

            // Use LINQ to find teenager students
            Student[] teenAgerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();

            // Use LINQ to find first student whose name is Bill 
            Student bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();

            // Use LINQ to find student whose StudentID is 5
            Student student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();
        }
        #endregion

        #region "Linq query and method syntax examples" 
        public static void LinqQuerySyntaxExample()
        {
          // string collection
          IList<string> stringList = new List<string>() {
            "C# Tutorials",
            "VB.NET Tutorials",
            "Learn C++",
            "MVC Tutorials" ,
            "Java"
        };

            // LINQ Query Syntax
            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;
        }
        public static void LinqMethodSyntaxExample()
        {
         // string collection
        IList<string> stringList = new List<string>() {
            "C# Tutorials",
            "VB.NET Tutorials",
            "Learn C++",
            "MVC Tutorials" ,
            "Java"
        };

            // LINQ Query Syntax
            var result = stringList.Where(s => s.Contains("Tutorials"));

            // Student collection
            IList<Student> studentList = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
        new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
        new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
    };

            // LINQ Method Syntax to find out teenager students
            var teenAgerStudents = studentList.Where(s => s.Age > 12 && s.Age < 20)
                                              .ToList<Student>();
           
        }

        #endregion

        #region "le funzioni anonime e lambda expression"
        delegate bool IsTeenAger(Student stud);
        public static void TestAnonFuncWithDelegate()
        {
            //funzione anonima perche viene associata direttamente al delegate la funzione senza crearla prima
            IsTeenAger isTeenAger = delegate (Student s) { return s.Age > 12 && s.Age < 20; };
            Student stud = new Student() { Age = 25 };
            Console.WriteLine(isTeenAger(stud));
        }
        public static void TestAnonFuncWithLambdaExpr()
        {
            IsTeenAger isTeenAger = s => s.Age > 12 && s.Age < 20;
            Student stud = new Student() { Age = 25 };
            Console.WriteLine(isTeenAger(stud));
        }
        delegate bool IsYougerThan(Student stud, int yougAge);
        public static void TestAnonFuncWithLambdaExprMultPar()
        {
            //IsYougerThan isYoungerThan2 = delegate (Student s, int youngAge) { return s.Age < youngAge; };
            IsYougerThan isYoungerThan = (s, youngAge) => s.Age < youngAge;
            Student stud = new Student() { Age = 25 };
            bool a = isYoungerThan(stud, 26);
            Console.WriteLine(isYoungerThan(stud,26));
        }
        delegate void Print();
        public static void TestAnonFuncWithoutParam()
        {
            Print print = () => Console.WriteLine("This is parameter less lambda expression");
            print();
        }

        public static void TestFuncDelegate()
        {
            //è un modo per creare una funzione anonima dichiarando un delegate a livello di sub
            //si usa anche quando si dichiarano degli argomenti di passaggio di tipo delegate nelle funzioni o routine
            //i primi argomenti sono input mentr l'ultimo argomento è output
            Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;

            Student std = new Student() { Age = 21 };

            bool isTeen = isStudentTeenAger(std);// returns false
        }
        public static void TestActionDelegate()
        {
            //a differenza di func ha solo parametri di input
            Action<Student> PrintStudDetail = s => Console.WriteLine("Name: {0}, Age: {1} ", s.StudentName, s.Age);
            Student std = new Student() { StudentName = "Bill", Age = 21 };

            PrintStudDetail(std);//output: Name: Bill, Age: 21
        }


        public static void testLambdainLinqMethod()
        {
            IList<Student> studentList = new List<Student>(){
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };
            //List<Student> studentList = new List<Student>();
            Func<Student,bool> isStudentTennAger= s => s.Age > 12 && s.Age < 20;
            var teenStudent = studentList.Where(isStudentTennAger).ToList<Student>();
            //var teenStudent2 = studentList.Where(isStudentTennAger);


        }

        public static void TestLambdainQueryMethod()
        {
            IList<Student> studentList = new List<Student>(){
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };
           
            Func<Student, bool> isStudentTennAger = s => s.Age > 12 && s.Age < 20;
            var teenAgerStudents = from s in studentList
                              where isStudentTennAger(s)
                              select s;
            //var teenStudent2 = studentList.Where(isStudentTennAger);

            foreach (Student std in teenAgerStudents)
            {
                Console.WriteLine(std.StudentName);
            }
        }

        #endregion

        #region "where extension method"
        public static void testWhereWithLinqMethodAndFuncDelegate()
        {
            IList<Student> studentList = new List<Student>(){
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };
            //List<Student> studentList = new List<Student>();
            Func<Student, bool> isStudentTennAger = s => s.Age > 12 && s.Age < 20;
            var teenStudent = studentList.Where(isStudentTennAger).ToList<Student>();
            //var teenStudent2 = studentList.Where(isStudentTennAger);

            //si può chiamare where più di una volta!!!
            //var filteredResult = studentList.Where(s => s.Age > 12).Where(s => s.Age < 20);
        }

        public static void TestWhereWhithLinqQueryAndFuncDelegate()
        {
            IList<Student> studentList = new List<Student>(){
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            Func<Student, bool> isStudentTennAger = s => s.Age > 12 && s.Age < 20;
            var teenAgerStudents = from s in studentList
                                   where isStudentTennAger(s)
                                   select s;
            //var teenStudent2 = studentList.Where(isStudentTennAger);

            foreach (Student std in teenAgerStudents)
            {
                Console.WriteLine(std.StudentName);
            }

            //si può chiamare where più di una volta!!!
            //var filteredResult = from s in studentList
           // where s.Age > 12
                   // where s.Age < 20
                   // select s;
        }

        public static void TestWhereWhithLinqQueryAndNormalFunction()
        {
            IList<Student> studentList = new List<Student>(){
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

          
            var teenAgerStudents = from s in studentList
                                   where IsTeenAgernormFun(s)
                                   select s;
        

            foreach (Student std in teenAgerStudents)
            {
                Console.WriteLine(std.StudentName);
            }
        }
        private static bool IsTeenAgernormFun(Student stud)
        {
            return stud.Age > 12 && stud.Age < 20;
        }
        public static void TestWhereWithSecondOverload()
        {
            //the Where extension method also have second overload 
            //that includes index of current element in the collection. You can use that index in your logic if you need.
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            var filteredResult = studentList.Where((s, i) => {
                if (i % 2 == 0) // if it is even element
                    return true;

                return false;
            });

            foreach (var std in filteredResult)
                Console.WriteLine(std.StudentName);
        }
        public static void TestWhereWithOfType()
        {
            //The OfType operator filters the collection based on a given type
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = from s in mixedList.OfType<string>()
                               select s;

            var intResult = from s in mixedList.OfType<int>()
                            select s;

            var stdResult = from s in mixedList.OfType<Student>()
                            select s;

            //si può usare questo metodo anche con la stintassi linq method:
            //var stringResult = mixedList.OfType<string>();

            foreach (var str in stringResult)
                Console.WriteLine(str);

            foreach (var integer in intResult)
                Console.WriteLine(integer);

            foreach (var std in stdResult)
                Console.WriteLine(std.StudentName);
        }

        #endregion

        #region "orderby linq"

        public static void TestOrderBy()
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var orderByResult = from s in studentList
                                orderby s.StudentName //Sorts the studentList collection in ascending order
                                select s;

            var orderByDescendingResult = from s in studentList //Sorts the studentList collection in descending order
                                          orderby s.StudentName descending
                                          select s;
            //con method syntax
            //var studentsInAscOrder = studentList.OrderBy(s => s.StudentName);
            //var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName).ThenBy(y => y.Age);
            //var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);
            //var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName).ThenByDescending(y=>y.Age);
            //multiple sorting:
            //var orderByResult = from s in studentList
            //                    orderby s.StudentName, s.Age
            //                    select new { s.StudentName, s.Age };
            //Multiple sorting in method syntax works differently. Use ThenBy or ThenByDecending extension methods for secondary sorting.

            Console.WriteLine("Ascending Order:");

            foreach (var std in orderByResult)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("Descending Order:");

            foreach (var std in orderByDescendingResult)
                Console.WriteLine(std.StudentName);
        }

        #endregion


        #region "grouping linq"

        public static void TestGroupBy()
        {
            //group by multiplo????
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };
           
            var groupedResult = from s in studentList
                                group s by s.Age;
            //with method sintax
            //var groupedResult = studentList.GroupBy(s => s.Age);
            //ToLookup stesso di groupby ma esecuzione immediata mentre groupby differita
            //var lookupResult = studentList.ToLookup(s => s.age);
            //iterate each group        
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 

                foreach (Student s in ageGroup) // Each group has inner collection
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
        }

        #endregion


        #region "join linq"

        public static void TestJoin()
        {
            // Student collection
            IList<string> strList1 = new List<string>() {
            "One",
            "Two",
            "Three",
            "Four"
            };

            IList<string> strList2 = new List<string>() {
            "One",
            "Two",
            "Five",
            "Six"
            };

            var innerJoinResult = strList1.Join(// outer sequence 
                          strList2,  // inner sequence 
                          str1 => str1,    // outerKeySelector
                          str2 => str2,  // innerKeySelector
                          (str1, str2) => str1);

            foreach (var str in innerJoinResult)
            {
                Console.WriteLine("{0} ", str);
            }
        }
        public static void TestJoinWithKeyAndMethodSintax()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron"  }
            };

                        IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

                        var innerJoin = studentList.Join(// outer sequence 
                                              standardList,  // inner sequence 
                                              student => student.StandardID,    // outerKeySelector
                                              standard => standard.StandardID,  // innerKeySelector
                                              (student, standard) => new  // result selector
                                  {
                                                  StudentName = student.StudentName,
                                                  StandardName = standard.StandardName
                                              });

        }
        public static void TestJoinWithKeyAndQuerySintax()
        {
            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 13, StandardID =1 },
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21, StandardID =1 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID =2 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID =2 },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
        };

                    IList<Standard> standardList = new List<Standard>() {
            new Standard(){ StandardID = 1, StandardName="Standard 1"},
            new Standard(){ StandardID = 2, StandardName="Standard 2"},
            new Standard(){ StandardID = 3, StandardName="Standard 3"}
        };

                    var innerJoin = from s in studentList // outer sequence
                                    join st in standardList //inner sequence 
                                    on s.StandardID equals st.StandardID // key selector  outerkeyselctor on left side of equals and on right sinde the inner
                                    select new
                                    { // result selector 
                                        StudentName = s.StudentName,
                                        StandardName = st.StandardName
                                    };
        }
        public static void TestGroupJoinWithKeyAndMethodSintax()
        {
            //We have seen the Join operator in the previous section. The GroupJoin operator performs the same task as Join operator except that GroupJoin returns a result in group based on specified group key

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram",  StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron" }
            };

                        IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

                        var groupJoin = standardList.GroupJoin(studentList,  //inner sequence
                                                        std => std.StandardID, //outerKeySelector 
                                                        s => s.StandardID,     //innerKeySelector
                                                        (std, studentsGroup) => new // resultSelector 
                                            {
                                                            Students = studentsGroup,
                                                            StandarFulldName = std.StandardName
                                                        });

                        foreach (var item in groupJoin)
                        {
                            Console.WriteLine(item.StandarFulldName);

                            foreach (var stud in item.Students)
                                Console.WriteLine(stud.StudentName);
                        }
        }
        public static void TestGroupJoinWithKeyAndQuerySintax()
        {
            //We have seen the Join operator in the previous section. The GroupJoin operator performs the same task as Join operator except that GroupJoin returns a result in group based on specified group key

            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };
            //Use the into keyword to create the grouped collection
            var groupJoin = from std in standardList
                            join s in studentList
                            on std.StandardID equals s.StandardID
                                into studentGroup
                            select new
                            {
                                Students = studentGroup,
                                StandardName = std.StandardName
                            };


            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandardName);

                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }

        }


        #endregion

        
        #region "Select linq"

        public static void TestSelectQuerySintax()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John" },
                new Student() { StudentID = 2, StudentName = "Moin" },
                new Student() { StudentID = 3, StudentName = "Bill" },
                new Student() { StudentID = 4, StudentName = "Ram" },
                new Student() { StudentID = 5, StudentName = "Ron" }
            };

            var selectResult = from s in studentList
                               select s.StudentName;

        }

        public static void TestSelect2QuerySintax()
        {
            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
        };

            // returns collection of anonymous objects with Name and Age property
            var selectResult = from s in studentList
                               select new { Name = "Mr. " + s.StudentName, Age = s.Age };

            // iterate selectResult
            foreach (var item in selectResult)
                Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);

        }

        public static void TestSelectMethodSintax()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };
            //anche qui oggetto anonimo di ritorno
            var selectResult = studentList.Select(s => new {
                Name = "Mr." + s.StudentName,
                Age = s.Age
            });
        }

        public static void TestSelectManyMethodSintax()
        {


            IEnumerable<Person> people = new List<Person>();

            // Select gets a list of lists of phone numbers
            IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);

            // SelectMany flattens it to just a list of phone numbers.
            IEnumerable<PhoneNumber> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);

            // And to include data from the parent in the result: 
            // pass an expression to the second parameter (resultSelector) in the overload:
            var directory = people
               .SelectMany(p => p.PhoneNumbers,
                           (parent, child) => new { parent.Name, child.Number });
        }

        #endregion


        #region "quantifier operator all, any, contain"

        //The quantifier operators evaluate elements of the sequence on some condition and return a boolean value to indicate that some or all 
        //elements satisfy the condition.

        public static void TestAllAnyOperator()
        {
            //non sono supportate dalla query syntax
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

                    // checks whether all the students are teenagers    
                    bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);
                    bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);


            Console.WriteLine(areAllStudentsTeenAger);
        }

        public static void TestContainOperator()
        {
            //contains 2 overload, il primo funziona bene coi primitivi ma con le classi non funzione
            //non è supportata dalla query syntax
            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5 };
            bool result = intList.Contains(10);  // returns false

            //con le classi bisogna implementare la interfaccia IEqualityComparer

            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
        };

            Student std = new Student() { StudentID = 3, StudentName = "Bill" };

            bool result2 = studentList.Contains(std, new StudentComparer());

            Console.WriteLine(result2);

        }

        #endregion


        #region "aggregation operator"

        //The aggregation operators perform mathematical operations like Average, Aggregate, Count, Max, Min and Sum, on the numeric property of the elements in the collection.
        public static void TestAggregateMethod()
        {
            //metodo aggergate 3 overload
            //non supportato da query sintax
            //esempio 1
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(commaSeperatedString);

            //esempio 2
            // Student collection
            IList<Student> studentList = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
                         };

                    string commaSeparatedStudentNames = studentList.Aggregate<Student, string>(
                                                            "Student Names: ",  // seed value
                                                            (str, s) => str += s.StudentName + ",");

                    Console.WriteLine(commaSeparatedStudentNames);

            //esempio 3
            IList<Student> studentList2 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
        };
           
            int SumOfStudentsAge = studentList2.Aggregate<Student, int>(0, (age, s) => age += s.Age);

            Console.WriteLine(SumOfStudentsAge);


            //esempio4

            // Student collection
            IList<Student> studentList3 = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
               };

            string commaSeparatedStudentNames2 = studentList3.Aggregate<Student, string, string>(
            String.Empty, // seed value
           (str, s) => str += s.StudentName + ",", // returns result using seed value, String.Empty goes to lambda expression as str
           str => str.Substring(0, str.Length - 1)); // result selector that removes last comma

            Console.WriteLine(commaSeparatedStudentNames2);

        }

        public static void TestAverageOperator()
        {
            //primo esempio
            IList<int> intList = new List<int> () { 10, 20, 30 };

            var avg = intList.Average();

            Console.WriteLine("Average: {0}", avg);

            //secondo esempio
            IList<Student> studentList = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
             };

            var avgAge = studentList.Average(s => s.Age);

            Console.WriteLine("Average Age of Student: {0}", avgAge);

        }
        public static void TestCountOperator()
        {
            IList<Student> studentList = new List<Student> () {
             new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
            new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Mathew", Age = 15 }
          };

            var numOfStudents = studentList.Count();

            Console.WriteLine("Number of Students: {0}", numOfStudents);

            //Student collection
            IList<Student> studentList2 = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Mathew", Age = 15 }
             };
            
               var numOfStudents2 = studentList2.Count(s => s.Age >= 18);

            Console.WriteLine("Number of Students: {0}", numOfStudents2);
        }

        public static void TestUtilizzoAggregationInQuerySyntax()
        {
            //Query Syntax doesn't support aggregation operators. However, you can wrap the query into brackets and use an aggregation functions as shown below.
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Mathew", Age = 15 }
             };

            var totalAge = (from s in studentList
                            select s.Age).Count();

        }


        public static void TestMaxOperator()
        {

            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
           
            var largest = intList.Max();

            Console.WriteLine("Largest Element: {0}", largest);

            var largestEvenElements = intList.Max(i => {
                if (i % 2 == 0)
                    return i;

                return 0;
            });

            Console.WriteLine("Largest Even Element: {0}", largestEvenElements);


            IList<Student> studentList2 = new List<Student> () {
                        new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
             };
            
            var oldest = studentList2.Max(s => s.Age);

            Console.WriteLine("Oldest Student Age: {0}", oldest);
        }


        public static void TestSumOperator()
        {
            //non supporttata in query syntax
            //es 1
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            var total = intList.Sum();

            Console.WriteLine("Sum: {0}", total);
            //es 2
            
                        var sumOfEvenElements = intList.Sum(i => {
                if (i % 2 == 0)
                    return i;

                return 0;
            });

            Console.WriteLine("Sum of Even Elements: {0}", sumOfEvenElements);

            //es 3
            IList<Student> studentList = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
        new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
        new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
        new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
        new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
     };

            var sumOfAge = studentList.Sum(s => s.Age);

            Console.WriteLine("Sum of all student's age: {0}", sumOfAge);
            
            //es 4
            var numOfAdults = studentList.Sum(s => {

                if (s.Age >= 18)
                    return 1;
                else
                    return 0;
            });

            Console.WriteLine("Total Adult Students: {0}", numOfAdults);
        }
        #endregion


        #region "element at, first, last, single, sequenceEqual, concat, DefaultEmpty, distinct, unione except, intersect"

        public static void TestElementAtFirstLastSingle()
        {
            //            The ElementAt() method returns an element from the specified index from a given collection.If the specified index is out of the range of a collection then it will throw an Index out of range exception.Please note that index is a zero based index.

            //The ElementAtOrDefault() method also returns an element from the specified index from a collaction and if the specified index is out of range of a collection then it will return a default value of the data type instead of throwing an error.

            //ELEMENT AT
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            IList<string> strList = new List<string>() { "One", null, "Three", "Four", "Five" };


            Console.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strList.ElementAt(0));

            Console.WriteLine("2nd Element in intList: {0}", intList.ElementAt(1));
            Console.WriteLine("2nd Element in strList: {0}", strList.ElementAt(1));

            Console.WriteLine("3rd Element in intList: {0}", intList.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strList.ElementAtOrDefault(2));

            Console.WriteLine("10th Element in intList: {0} - default int value", intList.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)", strList.ElementAtOrDefault(9));


            Console.WriteLine("intList.ElementAt(9) throws an exception: Index out of range");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(intList.ElementAt(9));

            //ELEMENT FIRST
            IList<int> intList2 = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList2 = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList2.First());
            Console.WriteLine("1st Even Element in intList: {0}", intList2.First(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList2.First());

            Console.WriteLine("emptyList.First() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(emptyList.First());


            //first or default...
            Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());

            Console.WriteLine("1st Even Element in intList: {0}", intList.FirstOrDefault(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());

            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());

            //first with condition...:
       

            Console.WriteLine("1st Element which is greater than 250 in intList: {0}",
                                            intList.First(i =>i > 250));

            Console.WriteLine("1st Even Element in intList: {0}",
                                            strList.FirstOrDefault(s => s.Contains("T")));


           //ELEMENT LAST

            Console.WriteLine("Last Element in intList: {0}", intList.Last());

            Console.WriteLine("Last Even Element in intList: {0}", intList.Last(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList.Last());

            Console.WriteLine("emptyList.Last() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(emptyList.Last());


            //ELEMENT SINGLE
            //Single Returns the only element from a collection, or the only element that satisfies a condition.If Single() found no elements or more than one elements in the collection then throws InvalidOperationException.
            //SingleOrDefault     The same as Single, except that it returns a default value of a specified generic type, instead of throwing an exception if no element found for the specified condition.However, it will thrown InvalidOperationException if it found more than one element for the specified condition in the collection.


            IList<int> oneElementList = new List<int>() { 7 };
            Console.WriteLine("The only element in oneElementList: {0}", oneElementList.Single());
            Console.WriteLine("The only element in oneElementList: {0}",
                         oneElementList.SingleOrDefault());

            Console.WriteLine("Element in emptyList: {0}", emptyList.SingleOrDefault());

            Console.WriteLine("The only element which is less than 10 in intList: {0}",
                         intList.Single(i => i < 10));

            //Followings throw an exception
            //Console.WriteLine("The only Element in intList: {0}", intList.Single());
            //Console.WriteLine("The only Element in intList: {0}", intList.SingleOrDefault());
            //Console.WriteLine("The only Element in emptyList: {0}", emptyList.Single());


        }


        public static void TestSequenceEqual()
        {
            //es 1
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
           
            bool isEqual = strList1.SequenceEqual(strList2); // returns true
            Console.WriteLine(isEqual);
            //es 2


            Student std = new Student() { StudentID = 1, StudentName = "Bill" };

            IList<Student> studentList1 = new List<Student>() { std };

            IList<Student> studentList2 = new List<Student>() { std };

            bool isEqual2 = studentList1.SequenceEqual(studentList2); // returns true

            Student std1 = new Student() { StudentID = 1, StudentName = "Bill" };
            Student std2 = new Student() { StudentID = 1, StudentName = "Bill" };

            IList<Student> studentList3 = new List<Student>() { std1 };

            IList<Student> studentList4 = new List<Student>() { std2 };

            isEqual2 = studentList3.SequenceEqual(studentList4);// returns false
            isEqual2 = studentList3.SequenceEqual(studentList4, new StudentComparer());// returns false
          

        }

        public static void TestConcat()
        {
            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Five", "Six" };
           
            var collection3 = collection1.Concat(collection2);

            foreach (string str in collection3)
                Console.WriteLine(str);
        }

        public static void TestDefaultEmpty()
        {
            //definisce un default per le liste vuote
            //es1
            IList<string> emptyList = new List<string>();
            //emptyList.Add(null);
            //emptyList.Add("aa");
            
            //emptyList.Add("bb");
            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine("Count: {0}", newList1.Count());
            Console.WriteLine("Value: {0}", newList1.ElementAt(0));

            Console.WriteLine("Count: {0}", newList2.Count());
            Console.WriteLine("Value: {0}", newList2.ElementAt(0));

            //es2
            IList<Student> emptyStudentList = new List<Student>();

            var newStudentList1 = emptyStudentList.DefaultIfEmpty();
            var newStudentList2 = emptyStudentList.DefaultIfEmpty(new Student() { StudentID = 0, StudentName = "" });

            Console.WriteLine("Count: {0} ", newStudentList1.Count());
            Console.WriteLine("Student ID: {0} ", newStudentList1.ElementAt(0));

            Console.WriteLine("Count: {0} ", newStudentList2.Count());
            Console.WriteLine("Student ID: {0} ", newStudentList2.ElementAt(0).StudentID);

        }

        public static void TestDistinctInterceptUnionExcept()
        {
            //DISTINCT
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };

            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distinctList1 = strList.Distinct();

            foreach (var str in distinctList1)
                Console.WriteLine(str);

            var distinctList2 = intList.Distinct();

            foreach (var i in distinctList2)
                Console.WriteLine(i);

            //The Distinct extension method doesn't compare values of complex type object:
            //devi implementare l'interfaccia IEqualityComparer
            IList<Student> studentList = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
        new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
    };


            var distinctStudents = studentList.Distinct(new StudentComparer());

            foreach (Student std in distinctStudents)
                Console.WriteLine(std.StudentName);

            //EXCEPT
            //per i tipi complessi vale quanto detto per distinct
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Except(strList2);

            foreach (string str in result)
                Console.WriteLine(str);

            //INTERCEPT
            //per i tipi complessi vale quanto detto per distinct
           
            var result2 = strList1.Intersect(strList2);

            foreach (string str in result2)
                Console.WriteLine(str);

            //UNION
            //per i tipi complessi vale quanto detto per distinct
            IList<string> strList3 = new List<string>() { "One", "Two", "three", "Four" };
            IList<string> strList4 = new List<string>() { "Two", "THREE", "Four", "Five" };

            var result3 = strList3.Union(strList4);

            foreach (string str in result3)
                Console.WriteLine(str);
        }

        #endregion

        #region "altri esempi"

        //delegate int MyFunc(int i);
        ////dichiarazione delegate a due argomenti
        //delegate int MyFunc2(int num1,int num2);
        ////definisco un metodo anonimo assegnando direttamente al delegate la definizione di funzione senza creare prima la funzione
        //private static MyFunc p = delegate (int i) { return i * 10; };
        ////definisco una lambda expression (equivalente a istruzione precedente), vedere appunti
        //static MyFunc p2 = i => i * 10;
        ////definisco il body della funzione a cui punta il delegate con due argomenti
        //static MyFunc2 p3 = (i,y) => i * y;
        //public static void DefineDelegateExample()
        //{
        //  int result= p(7);
        //  int result2 = p2(7);
        //}
        #endregion

    }
}
    
