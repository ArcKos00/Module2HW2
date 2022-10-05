using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public class Order
    {
        private readonly int _id;
        private int _commonOrderCost;
        private Product[] _prodOrder;
        private Product _product;
        public Order(Product product, int orderCost, int length)
        {
            _product = new Product(product);
            _commonOrderCost = orderCost;
            _prodOrder = AddToOrder(_product, length);
            _id = new Random().Next(1000, 10000);
            Console.WriteLine($"Создан заказ №: {_id}");
            Console.WriteLine("Посмотреть можно в папке дебаг...");
            WriteToFileOrder(_prodOrder, _commonOrderCost, _id);
            Basket.Instance.Head = null;
        }

        private Product[] AddToOrder(Product prod, int length)
        {
            int counter = 0;
            Product[] prods = new Product[length];
            do
            {
                prods[counter] = prod;
                prod = prod.Next;
                counter++;
            }
            while (prod != null);
            return prods;
        }

        private void WriteToFileOrder(Product[] prod, int commonCost, int id)
        {
            var sb = new StringBuilder();
            sb.Append($"Order Id: {id}\n");
            for (int i = 0; i < prod.Length; i++)
            {
                sb.AppendLine($"Id: {prod[i].Id} \nName: {prod[i].Name} \nCharacteristic: {prod[i].Characteristic} \nCost: {prod[i].Cost}");
            }

            sb.AppendLine($"Total Cost: {commonCost}");
            File.WriteAllText($"Order Check №{id}.txt", sb.ToString());
        }
    }
}
