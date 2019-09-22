using System;
using System.Collections;

namespace ConsoleApplication.IteratorModel
{
    //迭代器模式实现的目标是：让自定义的类可以通过使用foreach()来访问里面的对象
    class IteratorClass : IEnumerable
    {
        object[] objcollection;
        int count;

        public IteratorClass()
        {
            count = 0;
        }

        public void Add(object obj)
        {
            count++;
            Array.Resize(ref objcollection, count);
            objcollection[count - 1] = obj;
        }

        public IEnumerator GetEnumerator()
        {
            for(int i=0;i<count;i++)
            {
                yield return objcollection[i];//状态机实现每次的读取都从上次停止的位置
            }
        }
    }
}
