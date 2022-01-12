using System;

namespace Decorator
{
    class Program
    {

        static void Main(string[] args)
        {
            Rubber rubber1 = new WheelRubber();
            rubber1 = new StuddedRubber(rubber1); // зимняя резина с шипами
            Console.WriteLine("Наименование: {0}", rubber1.Name);
            Console.WriteLine("Цена: {0}", rubber1.GetCost());

            Rubber rubber2 = new WheelRubber();
            rubber2 = new StickyRubber(rubber2);// зимняя резина "липучка"
            Console.WriteLine("Наименование: {0}", rubber2.Name);
            Console.WriteLine("Цена: {0}", rubber2.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Rubber
    {
        public Rubber(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class WheelRubber : Rubber
    {
        public WheelRubber() : base("Зимняя резина")
        { }
        public override int GetCost()
        {
            return 10000;
        }
    }

    abstract class RubberDecorator : Rubber
    {
        protected Rubber rubber;
        public RubberDecorator(string n, Rubber rubber) : base(n)
        {
            this.rubber = rubber;
        }
    }

    class StuddedRubber : RubberDecorator
    {
        public StuddedRubber(Rubber p)
            : base(p.Name + ", с шипами", p)
        { }

        public override int GetCost()
        {
            return rubber.GetCost() + 3700;
        }
    }

    class StickyRubber : RubberDecorator
    {
        public StickyRubber(Rubber p)
            : base(p.Name + " - липучка", p)
        { }

        public override int GetCost()
        {
            return rubber.GetCost() + 1000;
        }
    }
}

