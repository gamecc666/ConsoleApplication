using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.StrategyModel
{
    abstract class StrategyClass
    {
        abstract public void EntranceFun();
    }
    class StrategyA : StrategyClass
    {
        public override void EntranceFun()
        {
            Console.WriteLine("Call-StatategyA-EntranceFun()");
        }
    }
    class StrategyB : StrategyClass
    {
        public override void EntranceFun()
        {
            Console.WriteLine("Call-StatategyB-EntranceFun()");
        }
    }
    class StrategyC : StrategyClass
    {
        public override void EntranceFun()
        {
            Console.WriteLine("Call-StatategyC-EntranceFun()");
        }
    }
    class Context
    {
        StrategyClass strategy;

        public Context(StrategyClass strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.EntranceFun();
        }
    }
}
