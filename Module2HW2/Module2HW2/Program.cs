using InternetMarket;

namespace Module2HW2
{
    public class Program
    {
        private static Stock _stock = Stock.Instance;
        private static Basket _basket = Basket.Instance;
        private static Product[] _prodArray;
        private readonly Drawler _drawler = new Drawler();
        public static void Main(string[] args)
        {
            Drawler drawler = new Drawler();
            while (true)
            {
                drawler.Draw(_stock);
                Console.Write("Выберите Id товара для того чтобы добавить его в корзину: ");
                _basket.ChangeGoods();
                AcceptOrder();

                Console.Write("Введите \"exit\" чтобы закончить: ");
                Console.WriteLine("Или продолжить выполнение и создание нового заказа)");
                if (Console.ReadLine() == "exit")
                {
                    break;
                }
            }
        }

        private static void AcceptOrder()
        {
            Drawler drawler = new Drawler();
            while (true)
            {
                _prodArray = new Product[Basket.Instance.Length];
                Product prod = Basket.Instance.Head;
                int counter = 0;
                do
                {
                    _prodArray[counter] = prod;
                    prod = prod.Next;
                    counter++;
                }
                while (prod != null);

                drawler.DrawBasketList(_prodArray);
                Console.WriteLine("Если хотите удалить товар из корзины, введите номер товара:");
                Console.Write("Если продолжить оформление, введите любую клавишу: ");

                try
                {
                    int i = int.Parse(Console.ReadLine());
                    if (i >= 1 && i <= _prodArray.Length)
                    {
                        Basket.Instance.RemoveFromBasket(_prodArray[i - 1].Index);
                    }
                }
                catch
                {
                    break;
                }
            }

            Console.WriteLine("Оформление заказа: ");
            Order order = new Order(_basket.Head, drawler.Cost, _prodArray.Length);
        }
    }
}