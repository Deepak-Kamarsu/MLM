using System;
using NewMLM;

namespace MLM
{
    class Program
    {
        static void Main()
        {
            var firstHouse = CreateHouses();
            MultiLevelMarket.StartToInvade(firstHouse);
            Console.ReadKey();
        }
        private static House CreateHouses()
        {
            var house1 = new House();
            var house2 = new House();
            var house3 = new House();
            var house4 = new House();
            var house5 = new House();
            var house6 = new House();
            var house7 = new House();
            var house8 = new House();
            var house9 = new House();
            var house10 = new House();
            var house11 = new House();
            var house12 = new House();
            house1.Number = 1;
            house1.Left = null;
            house1.Top = null;
            house1.Right = house2;
            house1.Bottom = house5;
            house1.IsInvaded = true;

            house2.Number = 2;
            house2.Left = house1;
            house2.Top = null;
            house2.Right = house3;
            house2.Bottom = house6;

            house3.Number = 3;
            house3.Left = house2;
            house3.Top = null;
            house3.Right = house4;
            house3.Bottom = house7;

            house4.Number = 4;
            house4.Left = house3;
            house4.Top = null;
            house4.Right = null;
            house4.Bottom = house8;

            house5.Number = 5;
            house5.Left = null;
            house5.Top = house1;
            house5.Right = house6;
            house5.Bottom = house9;

            house6.Number = 6;
            house6.Left = house5;
            house6.Top = house2;
            house6.Right = house7;
            house6.Bottom = house10;

            house7.Number = 7;
            house7.Left = house6;
            house7.Top = house3;
            house7.Right = house8;
            house7.Bottom = house11;

            house8.Number = 8;
            house8.Left = house7;
            house8.Top = house4;
            house8.Right = null;
            house8.Bottom = house12;

            house9.Number = 9;
            house9.Left = null;
            house9.Top = house5;
            house9.Right = house10;
            house9.Bottom = null;

            house10.Number = 10;
            house10.Left = house9;
            house10.Top = house6;
            house10.Right = house11;
            house10.Bottom = null;

            house11.Number = 11;
            house11.Left = house10;
            house11.Top = house7;
            house11.Right = house12;
            house11.Bottom = null;

            house12.Number = 12;
            house12.Left = house11;
            house12.Top = house8;
            house12.Right = null;
            house12.Bottom = null;

            return house1;
        }
    }
}
