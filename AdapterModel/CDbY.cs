using System;

namespace ConsoleApplication.AdapterModel
{
    public interface IDbY
    {
        void ReadData();
        void WriteData();
    }
    public class CDbY : IDbY
    {
        void IDbY.ReadData()
        {
            Console.WriteLine("  读取Y公司的数据");
        }

        void IDbY.WriteData()
        {
            Console.WriteLine("  写入Y公司的数据");
        }
    }
}
