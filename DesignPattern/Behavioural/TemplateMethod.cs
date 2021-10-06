using System;

namespace DesignPattern.Behavioural
{
    //Template Method defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps
    //of the algorithm without changing its structure.

    public abstract class TemplateMethodBase
    {
        public void TemplateMethod()
        {
            DoActionA();
            DoActionB();
        }

        protected abstract void DoActionA();
        protected abstract void DoActionB();
    }

    public class TemplateMethodAlpha : TemplateMethodBase
    {
        protected override void DoActionA()
            => Console.WriteLine("Alpha do Action A");

        protected override void DoActionB()
            => Console.WriteLine("Alpha do Action B");
    }

    public class TemplateMethodBeta : TemplateMethodBase
    {
        protected override void DoActionA()
            => Console.WriteLine("Beta do Action A");

        protected override void DoActionB()
            => Console.WriteLine("Beta do Action B");
    }

    public class TemplateMethodClient
    {
        public void UseTemplateMethod()
        {
            new TemplateMethodAlpha().TemplateMethod();
            new TemplateMethodBeta().TemplateMethod();
        }
    }
}
