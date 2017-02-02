using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinq.Classes;

namespace TestLinq
{
//   private delegate bool a(Student s) { return s.Age>12 && s.Age<20; };
//public delegate bool FindStudent(Student std);
class Program
    {

        
    static void Main(string[] args)

        {
            ////**************
            ////Modalità per filtrare un array di oggetti
            ////metodo meno efficace, scorrersi l'array
            //testerLinq.QueryAnObjectArrayWithForCicle();
            ////metodo più efficace con delegate
            //testerLinq.QueryAnObjectArrayWithDelegate();
            ////metodo più efficace ancora con linq
            //testerLinq.QueryAnObjectArrayWithLinq();

            ////**************
            ////Linq query and method syntax examples
            //testerLinq.LinqQuerySyntaxExample();
            //testerLinq.LinqMethodSyntaxExample();

            //**************
            //le funzioni anonime e lambda expression
            testerLinq.TestAnonFuncWithDelegate();
            testerLinq.TestAnonFuncWithLambdaExpr();
            testerLinq.TestAnonFuncWithLambdaExprMultPar();
            testerLinq.TestAnonFuncWithoutParam();
            testerLinq.TestFuncDelegate();
            testerLinq.TestActionDelegate();
            testerLinq.testLambdainLinqMethod();
            testerLinq.TestLambdainQueryMethod();

            ////**************
            ////where extension method
            //testerLinq.testWhereWithLinqMethodAndFuncDelegate();
            //testerLinq.TestWhereWhithLinqQueryAndFuncDelegate();
            //testerLinq.TestWhereWhithLinqQueryAndNormalFunction();
            //testerLinq.TestWhereWithSecondOverload();
            //testerLinq.TestWhereWithOfType();

            ////**************
            ////orderby linq
            //testerLinq.TestOrderBy();

            ////**************
            ////grouping linq
            //testerLinq.TestGroupBy();

            ////**************
            ////join linq
            //testerLinq.TestJoin();
            //testerLinq.TestJoinWithKeyAndMethodSintax();
            //testerLinq.TestJoinWithKeyAndQuerySintax();
            //testerLinq.TestGroupJoinWithKeyAndMethodSintax();
            //testerLinq.TestGroupJoinWithKeyAndQuerySintax();

            ////**************
            ////quantifier operator all, any, contain
            //testerLinq.TestAllAnyOperator();
            //testerLinq.TestContainOperator();

            ////**************
            ////aggregation operator
            //testerLinq.TestAggregateMethod();
            //testerLinq.TestAverageOperator();
            //testerLinq.TestCountOperator();
            //testerLinq.TestUtilizzoAggregationInQuerySyntax();
            //testerLinq.TestMaxOperator();
            //testerLinq.TextSumOperator();
            //testerLinq.TestElementAtFirstLastSingle();
            //testerLinq.TestSequenceEqual();
            testerLinq.TestDefaultEmpty();
        }
    }

   
}
