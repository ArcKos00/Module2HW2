using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public class Basket
    {
        private static int counter = 1;
        private static int length = 0;
        private static Basket _basket = new Basket();
        private static Product _headBasket;
        private static Product _currentProduct;
        private Basket()
        {
        }

        public static Basket Instance
        {
            get
            {
                if (_basket == null)
                {
                    _basket = new Basket();
                }

                return _basket;
            }
        }

        public Product Head
        {
            get
            {
                return _headBasket;
            }
            set
            {
                _headBasket = value;
            }
        }

        public Product Current
        {
            get { return _currentProduct; }
            set { _currentProduct = value; }
        }

        public int Length
        {
            get
            {
                return length;
            }
        }

        public void AddToBasket(Product prod)
        {
            if (_headBasket == null)
            {
                _headBasket = prod;
                _currentProduct = _headBasket;
                _headBasket.Index = counter;
                length++;
            }
            else
            {
                length++;
                counter++;
                _currentProduct.Next = new Product(prod);
                _currentProduct.Next.Index = counter;
                _currentProduct.Next.Previous = _currentProduct;
                _currentProduct = _currentProduct.Next;
            }
        }

        public void RemoveFromBasket(int delIndex)
        {
            Product curr = Head;
            while (curr != null)
            {
                if (curr.Index == delIndex && curr != Head && curr.Next != null)
                {
                    curr.Previous.Next = curr.Next;
                    curr.Next.Previous = curr.Previous;
                    break;
                }
                else if (curr.Index == delIndex && curr == Head && curr.Next != null)
                {
                    Head = Head.Next;
                    break;
                }
                else if (curr.Index == delIndex && curr == Head && curr.Next == null)
                {
                    Head = null;
                    break;
                }
                else if (curr.Index == delIndex && curr.Next == null)
                {
                    curr.Previous.Next = null;
                    break;
                }

                curr = curr.Next;
            }

            length--;
        }

        public void ChangeGoods()
        {
            int counter = 0;
            while (true)
            {
                sbyte id = 0;
                try
                {
                    string? str = Console.ReadLine();
                    if (str == "y")
                    {
                        break;
                    }
                    else
                    {
                        id = sbyte.Parse(str);
                    }
                }
                catch
                {
                    Console.WriteLine("Выберите корректный Id...");
                    continue;
                }

                for (int i = 0; i < Stock.IdArray.Length; i++)
                {
                    if (id == Stock.IdArray[i])
                    {
                        AddToBasket(Stock.Instance.stock[i]);
                        counter++;
                        Console.WriteLine("У вас в корзине {0} товаров", counter);
                        break;
                    }
                }

                Console.WriteLine("Введите \"y\" чтобы продолжить оформление заказа: ");
                Console.Write("Или ");
                Console.Write("Введите Id товара:");
            }
        }
    }
}
