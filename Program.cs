using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 模块一：测试泛型方法
            Console.WriteLine("---------------------测试泛型方法--------------------");
            dynamic obj = new Persion();
            obj.Name = "gamecc";
            obj.Age = 52;
            obj.Gender = "男";

            int[] arr = { 0, 2, 5, 7, 8, 6, 45 };
            List<int> list = new List<int>();
            Func<int>(arr);
            #endregion
            #region 模块二：?/?:/?? 区别及用法
            Console.WriteLine("------------------?/?:/?? 区别及用法&模式匹配与switch语句-------------------\n");
            var p1 = new Persion("gamecc","男",25);
            var p2 = new Persion("gamedd", "女", 27);
            var p3 = new Persion("gameee", "sex", 26);

            object[] data = { null, 42, "gameccstring",p1,new Persion[] { p2,p3} };
            Console.WriteLine("?/?:/?? 区别及用法：");
            foreach (var item in data)
            {
                IsOperator(item);               
            }
            Console.WriteLine("\n模式匹配与switch语句：");
            foreach (var item in data)
            {                
                //模式匹配与switch语句               
                SwitchStatement(item);
            }
            //测试 ?? 两边都为空时的返回值
            Console.WriteLine("\n测试 ?? 两边都为空时的返回值:");
            dynamic test1 = null;
            dynamic test2 = "参数2";
            Console.WriteLine($"参数1为空，参数2不为空，最终取得值是：{test1 ?? test2}");
            dynamic test3 = "参数1";
            dynamic test4 = null;
            Console.WriteLine($"参数1不为空，参数2为空，最终取得值是：{test3??test4}");
            dynamic test5 = null;
            dynamic test6 = null;
            Console.WriteLine($"参数1参数2都为空，最终取得值是：{ test5??test6}");
            #endregion           
        }


        #region 模块一：测试泛型方法
        private static void Func<T>(T[] arr)
        {
            foreach (T item in arr)
            {
                Console.WriteLine(item.ToString() + "-||-");
            }
        }
        #endregion
        #region 模块二：?/?:/?? 区别及用法
        static void IsOperator(object item)
        {
            if(item is var every)
            {
                Console.WriteLine($"it's var of type {every?.GetType().Name??"null"}"+
                    $"with ths value {every??"nothing"}"               
                    );
            }
        }
        //模式匹配与switch语句
        static void SwitchStatement(object item)
        {
            switch(item)
            {
                case null:
                case 42:
                    Console.WriteLine("it's a const pattern");
                    break;
                case int i:
                    Console.WriteLine($"it's a type pattern with int：{i}");
                    break;
                case string s:
                    Console.WriteLine($"it's a type pattern with string : {s}");
                    break;
                case Persion p when p.Name == "gamecc":
                    Console.WriteLine($"type pattern match with Person and when clause:{p}");
                    break;
                case Persion p:
                    Console.WriteLine($"type pattern match with person:{p}");
                    break;
                case var every:
                    Console.WriteLine($"var pattern match:{every?.GetType().Name}");
                    break;
                default:
            }
        }
        #endregion
    }
}
