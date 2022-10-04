using System;
using System.Collections.Generic;

namespace testcsharp.Properties
{  
    //策略模式 https://refactoringguru.cn/design-patterns/strategy
    // 适用场景
    //当你想使用对象中各种不同的算法辩题，并希望能在运行时切换算法
    //策略模式让你能将各种算法的代码、 内部数据和依赖关系与其他代码隔离开来。 不同客户端可通过一个简单接口执行算法， 并能在运行时进行切换。
    
    public class Context
    {
        private IStrategy _strategy;

        public Context()
        {
            this._strategy = _strategy;

        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        { 
            Console.WriteLine("测试");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "a", "a", "a" });
            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + "";

            }
            Console.WriteLine(resultStr);
        }

    }
    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();
            return list;
        }
    }
    
    
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    class Program
    {

        static void Main(string [] args)
        {
            var context = new Context();
            Console.WriteLine("Client: Strategy is set to normal sorting.");
            
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();
            
            Console.WriteLine();
            
            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
            
        }
    }
    
}