using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.GetObjByStr
{
    public class Class_01: IObject
    {
        public Class_01()
        {
        }

        public void PrintName()
        {
            Console.WriteLine("my name is Class_01");
        }

        public void Sun(int a, int b)
        {
            Console.WriteLine($"两个数的和是：{a + b}");
        }
    }
}
