using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace InternetMarket
{
    public class Product
    {
        private readonly sbyte _id;
        private Product _next;
        private Product _previous;
        private int _index;
        private int _cost;
        private string _name;
        private string _characteristic;
        public Product(Product prod)
        {
            _id = prod.Id;
            Cost = prod.Cost;
            Name = prod.Name;
            Characteristic = prod.Characteristic;
            Next = prod.Next;
            Previous = prod.Previous;
        }

        public Product(int cost, string name, string characteristic, sbyte id, Product next = null, Product previous = null)
        {
            _id = id;
            Cost = cost;
            Name = name;
            Characteristic = characteristic;
            Next = next;
            Previous = previous;
        }

        public sbyte Id
        {
            get { return _id; }
        }

        public Product Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public Product Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }

        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                if (_index == 0)
                {
                    _index = value;
                }
            }
        }

        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public string Name
        {
            get { return _name; }
            init { _name = value; }
        }

        public string Characteristic
        {
            get { return _characteristic; }
            init { _characteristic = value; }
        }
    }
}