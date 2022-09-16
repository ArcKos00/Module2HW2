using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public class Stock
    {
        private Product[] _stock = new Product[15];
        private static sbyte[] _idArr = new sbyte[15];
        private static Stock _instance = new Stock();
        private Stock()
        {
            GenerateProductStock(ref _stock);
        }

        public Product[] StockMag
        {
            get { return _stock; }
        }

        public static sbyte[] IdArray
        {
            get { return _idArr; }
        }

        public static Stock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Stock();
                }

                return _instance;
            }
        }

        private void GenerateProductStock(ref Product[] stock)
        {
            Random rand = new Random();
            for (int i = 0; i < stock.Length; i++)
            {
                sbyte id = 0;
                bool isAccept = true;
                while (isAccept)
                {
                    sbyte randid = (sbyte)rand.Next(0, 11);
                    for (int j = 0; j < stock.Length; j++)
                    {
                        if (randid == _idArr[j])
                        {
                            break;
                        }

                        if (j >= _idArr.Length - 1)
                        {
                            isAccept = false;
                            id = randid;
                        }
                    }
                }

                stock[i] = new Product(rand.Next(0, 1000), $"Product{i}", "Something characteristic ", id);
                _idArr[i] = id;
            }
        }
    }
}
