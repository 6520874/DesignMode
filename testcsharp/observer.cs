using System;

namespace testcsharp.Properties
{
    public abstract class BaseSubject
    {
        public event Action CallObservers;

        public void CallAllObservers()
        {
            CallObservers?.Invoke();
        }
    }


    public abstract class BaseObserver
    {
        public abstract void OnEnable();
        public abstract void OnDisable();
        public abstract void UpdateMyState();
    }


    public class Subject : BaseSubject
    {
        private void Start()
        {
            changeState();

        }


        private void  changeState()
        {  
            Console.WriteLine("Player(Subject) : Drink to heal myself.");
        }
        
        
    }
    
    
    public class Observer : BaseObserver
    {
        public BaseSubject subject;
	
        public override void OnEnable()
        {
            subject.CallObservers += UpdateMyState;
        }
	
        public override void OnDisable()
        {
            subject.CallObservers -= UpdateMyState;
        }
	
        public override void UpdateMyState()
        {
            Console.WriteLine("Enemy(Observer) : Attack right now!");
        }
    }
    
    
    


}