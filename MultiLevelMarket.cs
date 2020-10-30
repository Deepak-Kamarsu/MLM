using System;
using System.Collections.Generic;
using System.Linq;
using MLM;

namespace NewMLM
{
    public class MultiLevelMarket
    {
        public static void StartToInvade(House house)
        {
            var firstHouse = GetFirstHouseInTheNeighborhood(house);
            var invadedHouses = GetAllHouses(firstHouse).Where(h => h.IsInvaded);
            var currentHouse = new List<House> { firstHouse };
            int timer = 0;
            while (GetAllHouses(firstHouse).Any(h => h.IsInvaded == false))
            {
                timer++;
                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine($"Hour-{timer}");
                Console.WriteLine("-----------------------------------------");

                var nextToInvadeHouseList = currentHouse.SelectMany(NextToInvade).ToHashSet();
                foreach (var nextToInvadeHouse in nextToInvadeHouseList)
                {
                    if (GetAllHouses(firstHouse).All(h => h.IsInvaded))
                    {
                        Console.WriteLine($"The invaded time is {timer}");
                        return;
                    }
                    Console.WriteLine(nextToInvadeHouse.Number);
                    nextToInvadeHouse.IsInvaded = true;
                }

                currentHouse = nextToInvadeHouseList.ToList();
            }
            Console.WriteLine($"The invaded time is {timer}");

        }
        private static House GetLeftMostHouse(House house)
        {
            return house.Left == null ? house : GetLeftMostHouse(house.Left);
        }
        private static House GetTopMostHouse(House house)
        {
            return house.Top == null ? house : GetTopMostHouse(house.Top);
        }
        private static House GetFirstHouseInTheNeighborhood(House house)
        {
            var leftMostHouse = GetLeftMostHouse(house);
            var topMostHouse = GetTopMostHouse(leftMostHouse);
            return topMostHouse;
        }
        private static IEnumerable<House> GetAllHouses(House house)
        {
            var currentHouse = GetFirstHouseInTheNeighborhood(house);
            yield return currentHouse;
            while (!(currentHouse.Right == null && currentHouse.Bottom == null))
            {
                currentHouse = currentHouse.Right;
                yield return currentHouse;
                if (currentHouse.Right == null && currentHouse.Bottom != null)
                {
                    currentHouse = GetLeftMostHouse(currentHouse.Bottom);
                    yield return currentHouse;
                }
            }
        }
        private static IEnumerable<House> NextToInvade(House house)
        {
            var adjacentHouses = new List<House>();
            if (house.Left != null && house.Left.IsInvaded == false)
                adjacentHouses.Add(house.Left);
            if (house.Top != null && house.Top.IsInvaded == false)
                adjacentHouses.Add(house.Top);
            if (house.Right != null && house.Right.IsInvaded == false)
                adjacentHouses.Add(house.Right);
            if (house.Bottom != null && house.Bottom.IsInvaded == false)
                adjacentHouses.Add(house.Bottom);
            return adjacentHouses.Take(house == GetFirstHouseInTheNeighborhood(house) ? 1 : 2);
        }
    }
}
