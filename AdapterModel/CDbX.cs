using System;

namespace ConsoleApplication.AdapterModel
{
    public interface IDbx
    {
        void LoadData();
        void SaveData();
    }
    class CDbX : IDbx
    {
        public void LoadData()
        {
            Console.WriteLine("  读取X公司的数据");
        }

        public void SaveData()
        {
            Console.WriteLine("  写入X公司的数据");
        }
    }
}
