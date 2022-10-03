using System;
using System.Diagnostics.PerformanceData;
using System.Runtime.Remoting.Contexts;

namespace testcsharp.Properties.Properties
{
    //命令模式
    // - 网络通信时候，客户端服务器之间数据封包传递。
    // - 资源异步加载的命令队列。
    // - 游戏录制和回放功能。

    public interface ICommand
    {
        void Execute();
    }
    public class SimpleCommand:ICommand
    {
        private string _payload = string.Empty;

        public SimpleCommand(string payload)
        {
            this._payload = payload;

        }
        
        public void Execute()
        {
            Console.WriteLine($"看啊，我可以做简单的命令，比如打印啊 ");
            
        }
    }

    class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }
        public void Execute()
        {
            Console.WriteLine("复杂命令执行.");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }


    class Receiver
    {
       public  void DoSomething(string a)
        {
            Console.WriteLine($"工作中 {a}");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"也在工作中 {b}");
        }
    }

    class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }
        public void SetOnFinish(ICommand command)
        {
            this._onStart = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("做重要事情开始");
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            Console.WriteLine("做重要事情");

            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("小单子"));

            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver,"发邮件","保存报告"));
            invoker.DoSomethingImportant();


        }
    }
}