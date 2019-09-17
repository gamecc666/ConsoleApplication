using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 字符串的拼接
            /*
             * KeyNote:
             *       1:对于字符串的拼接使用 Join,拆分的话使用 Split()
             */
            Console.WriteLine("-------------------字符串数组的拼接操作-------------------");
            string[] _arr = new string[] { "liu", "yue", "can" };          
            //string _res = string.Join("|", _arr);
            //将字符串数组组装成是字符串
            string _res = string.Join("", _arr);
            Console.WriteLine("链接后的结果是：" + _res);

            List<string> _demo = new List<string>();
            _demo.Add("you");
            _demo.Add("can");
            _demo.Add("fly");
            string[] _arrlist = _demo.ToArray();
            //foreach (var item in _arrlist)
            //{                                                       
            //    Console.WriteLine("子元素：" + item);
            //}
            string _ss = string.Join("|", _arrlist);
            Console.WriteLine("最终结果是："+_ss);
            #endregion

            #region C#使用Python包
            /* 
             * KeyNote:
             *       1:IndexOf()与LastIndexOf()的区别：都是取第一次出现时候的索引，前者从前往后，后者从后往前；唯一不变的是字符串的索引不变索然是从后往前查
             *                                         但是索引和从前往后查的索引一样，都是从0开始
             *       2:详细参考网址：https://www.cnblogs.com/pasoraku/p/4906715.html
             */
            Console.WriteLine("--------------------C#使用Pathon包--------------------");
            var pythonEngine = Python.CreateEngine();
            //var Index = Directory.GetCurrentDirectory().LastIndexOf("bin");
            //var strpath = Directory.GetCurrentDirectory().Remove(Index) + @"PythonLibrary\PyLib.py";

            //var pyText = Convert.ToBase64String(File.ReadAllBytes(new FileInfo(strpath).ToString()));
            //var CodeString = Encoding.UTF8.GetString(Convert.FromBase64String(pyText));
            //读取文件 方法一
            //var script = pythonEngine.CreateScriptSourceFromString(CodeString);
            //读取文件 方法二
            var script = pythonEngine.CreateScriptSourceFromFile("../../../PythonLibrary/PyLib.py");
            var code = script.Compile(); //编译

            var scope = pythonEngine.CreateScope();
            var executeres= code.Execute(scope);
            //调用py方法,不带参数
            //var _func = scope.GetVariable("SayWord");
            //var CustomerData = _func();

            //调用py方法,带参数
            var _func = scope.GetVariable("GetSum");
            var CustomerData = _func(555,445);

            Console.WriteLine($"得到的最终结果是：{CustomerData}");

            #endregion
            #region 测试对象为空不为空
            Console.WriteLine("------------------测试对象为空不为空-----------------");
            Persion sb =null;
            //Persion sb = new Persion();
            if(sb is null)
            {
                Console.WriteLine("对象为空");
            }
            else
            {
                Console.WriteLine("对象不为空");
            }
            #endregion
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
            #region 模块三：C#操作Xml文档
            /* KeyNote:
             *      1:CreateXmlDeclaration()方法的第三个参数 standalone的汉意：值：yes/no 
             *        yes:表示不依赖任何外部定义的DTD(文档类型定义目的以某个模板来校验你写的XML)；
             *        no;表示该Xml文档不是独立的，引用了外部的DTD规范文档；
             */
            Console.WriteLine("---------------------C#操作Xml文档--------------------");
            //写XML文件
            XmlDocument _xmldocument = new XmlDocument();
            XmlDeclaration _xmldeclaration = _xmldocument.CreateXmlDeclaration("1.0", "utf-8", "yes");
            _xmldocument.AppendChild(_xmldeclaration);
            //根节点
            XmlElement _persion = _xmldocument.CreateElement("Persion");
            _persion.SetAttribute("公司", "XXX");
            _xmldocument.AppendChild(_persion);
            //附加成员
            XmlElement _persion1 = _xmldocument.CreateElement("Persion1");
            _persion.AppendChild(_persion1);

            XmlElement _persion1_1 = _xmldocument.CreateElement("姓名");
            _persion1_1.InnerText = "gamecc666";
            _persion1.AppendChild(_persion1_1);
            XmlElement _persion1_2 = _xmldocument.CreateElement("性别");
            _persion1_2.InnerText = "男";
            _persion1.AppendChild(_persion1_2);
            XmlElement _persion1_3 = _xmldocument.CreateElement("年龄");
            _persion1_3.InnerText = "27";
            _persion1.AppendChild(_persion1_3);

            XmlElement _persion2 = _xmldocument.CreateElement("Persion2");
            _persion.AppendChild(_persion2);

            XmlElement _persion2_1 = _xmldocument.CreateElement("姓名");
            _persion2_1.InnerText = "xiaoyu";
            _persion2.AppendChild(_persion2_1);
            XmlElement _persion2_2 = _xmldocument.CreateElement("性别");
            _persion2_2.InnerText = "女";
            _persion2.AppendChild(_persion2_2);
            XmlElement _persion2_3 = _xmldocument.CreateElement("年龄");
            _persion2_3.InnerText = "28";
            _persion2.AppendChild(_persion2_3);
            //保存Xml文件
            _xmldocument.Save("gamecc666.xml");

            //读Xml文件
            //Console.WriteLine("读取xml文件");
            //XmlDocument _xmldocument = new XmlDocument();
            //_xmldocument.Load("gamecc666.xml");
            ////获得根节点的第二种方法：_xmldocument.DocumentElement.Name
            //XmlNode _xmlnode = _xmldocument.SelectSingleNode("Persion");
            ////获得根节点的信息
            //Console.WriteLine("name:" + _xmlnode.Name + "||属性公司：" +((XmlElement)_xmlnode).GetAttribute("公司"));
            ////获得所有的孩子节点的List集合
            //XmlNodeList _nodelist = _xmlnode.ChildNodes;
            //foreach(XmlNode item in _nodelist)
            //{
            //    string _persioninfo = "\n";

            //    XmlElement _xmlelementitem = (XmlElement)item;
            //    _persioninfo += "ID："+_xmlelementitem.Name;
            //    foreach(XmlNode xn in item )
            //    {
            //        var _xmlelementxn = (XmlElement)xn;
            //        _persioninfo += "||" + _xmlelementxn.Name + " : " + _xmlelementxn.InnerText;
            //        //修改XML文档
            //        if(_xmlelementxn.InnerText=="xiaoyu")
            //        {
            //            _xmlelementxn.InnerText = "小鱼";
            //        }
            //    }
            //    Console.WriteLine("输出个人信息：" + _persioninfo);
            //}            
            //_xmldocument.Save("gamecc666.xml");
            Console.WriteLine("xml文件操作结束！");
            #endregion
            #region 模块四：路径测试
            /* KeyNote:
             *       1: '..'代表上级目录
             */
            Console.WriteLine("---------------------路径测试--------------------");
            XmlDocument _xd = new XmlDocument();
            XmlDeclaration _dec = _xd.CreateXmlDeclaration("1.0", "utf-8", "yes");
            _xd.AppendChild(_dec);
            XmlElement _pen = _xd.CreateElement("Persion");
            _pen.SetAttribute("格格", "XXX");
            _xd.AppendChild(_pen);
            //保存文件
            Console.WriteLine("当前目录的完全限定路径："+ Environment.CurrentDirectory);
            Console.WriteLine("当前应用程序的工作目录："+System.IO.Directory.GetCurrentDirectory());
            _xd.Save("../../../TestXml/gamecc666.xml");


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
