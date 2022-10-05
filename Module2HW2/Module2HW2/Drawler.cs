using InternetMarket;

namespace Module2HW2
{
    public class Drawler
    {
        private int _commonCost;
        public int Cost
        {
            get { return _commonCost; }
        }

        public void Draw(Stock stock)
        {
            for (int i = 0; i < stock.StockMag.Length; i++)
            {
                Product prod = stock.StockMag[i];
                Console.WriteLine("Id: {0}", prod.Id);
                Console.WriteLine($"Name: {prod.Name}, Characteristic: {prod.Characteristic}");
                Console.WriteLine($"Cost: {prod.Cost}");
                Console.WriteLine();
            }
        }

        public void DrawBasketList(Product[] prodArray)
        {
            _commonCost = 0;
            Console.WriteLine("Ваша корзина: ");
            for (int i = 0; i < prodArray.Length; i++)
            {
                Console.WriteLine($"{i + 1}: Название товара: {prodArray[i].Name}, Цена: {prodArray[i].Cost}");
                _commonCost += prodArray[i].Cost;
            }

            Console.WriteLine("Общая стоимость: {0}\n\n", _commonCost);
        }
    }
}
