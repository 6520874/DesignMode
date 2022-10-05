using System;
using System.Data;
using testcsharp.Properties;

namespace testcsharp
{
    //状态模式是一种行为设计模式，让你能在一个对象的内部状态变化时改变其行为，使其看上去就像改成了自身所属的类一样
        
    // 单一职责原则。 将与特定状态相关的代码放在单独的类中。
    // 开闭原则。 无需修改已有状态类和上下文就能引入新状态。
    // 通过消除臃肿的状态机条件语句简化上下文代码。
    // 如果状态机只有很少的几个状态， 或者很少发生改变， 那么应用该模式可能会显得小题
    
    
    
    class Context
    {
        private State _state = null;

        public Context(State state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(State state)
        {
            Console.WriteLine($"context: transition to {state.GetType().Name}");
            this._state = state;
            this._state.SetContext(this);
        }


        public void Request1()
        {
            this._state.Handle1();
        }

        public void Request2()
        {
            this._state.Handle2();
        }
    }


    abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract void Handle1();
        public abstract void Handle2();
    }


    class ConcreteStateA : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateA handles request1.");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            this._context.TransitionTo(new ConcreteStrategyB());
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }

    class ConcreteStrategyB : State
    {
        public override void Handle1()
        {
            Console.Write("ConcreteStateB handles request1.");
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateB handles request2.");
            Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            this._context.TransitionTo(new ConcreteStateA());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            var context = new Context(new ConcreteStateA());
            context.Request1();
            context.Request2();
        }
    }
    
}