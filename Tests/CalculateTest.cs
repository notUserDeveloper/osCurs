using System.Collections.Generic;
using NUnit.Framework;
using WebService.Helpers;
using WebService.Managers;
using WebService.Models;

namespace Tests
{
    [TestFixture]
    public class CalculateTest
    {
        [Test]
        public void TestFindSolution2Knap()
        {
            var calculateModel = new CalculateModel {Knapsacks = new List<Knapsack>()};
            calculateModel.Knapsacks.Add(new Knapsack {Capacity = 0.7});
            calculateModel.Knapsacks.Add(new Knapsack {Capacity = 0.7});

            calculateModel.Items = new List<Item>
            {
                new Item {Id = 1, Weight = 0.11},
                new Item {Id = 2, Weight = 0.24},
                new Item {Id = 3, Weight = 0.15},
                new Item {Id = 4, Weight = 0.33},
                new Item {Id = 5, Weight = 0.12},
                new Item {Id = 6, Weight = 0.27}
            };

            Result cm = new CalculateManager(calculateModel, new VariationManager()).TryCalculate();
        }

        [Test]
        public void TestFindSolution3Knap()
        {
            var calculateModel = new CalculateModel {Knapsacks = new List<Knapsack>()};
            calculateModel.Knapsacks.Add(new Knapsack {Capacity = 0.71});
            calculateModel.Knapsacks.Add(new Knapsack {Capacity = 0.69});
            calculateModel.Knapsacks.Add(new Knapsack {Capacity = 0.7});

            calculateModel.Items = new List<Item>
            {
                new Item {Id = 1, Weight = 0.33},
                new Item {Id = 2, Weight = 0.40},
                new Item {Id = 3, Weight = 0.22},
                new Item {Id = 4, Weight = 0.35},
                new Item {Id = 5, Weight = 0.29},
                new Item {Id = 6, Weight = 0.39}
            };

            Result cm = new CalculateManager(calculateModel, new VariationManager()).TryCalculate();
        }

        [Test]
        public void GetSequence()
        {
            int num = 8;
            var rez = new[] {false, false, false, true};

            var sequence = SequenceHelper.GetSequence(num);
           

        }
    }
}