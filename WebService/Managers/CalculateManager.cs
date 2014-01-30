using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebService.Helpers;
using WebService.Models;

namespace WebService.Managers
{
    public class CalculateManager
    {
        private readonly CalculateModel _calculate;
        private readonly VariationManager _variationManager;

        public CalculateManager(CalculateModel calculate, VariationManager variationManager)
        {
            _calculate = calculate;
            _variationManager = variationManager;
        }

        public Result TryCalculate()
        {
            int variationsCount = GetVariationsCount();

            double gMin = Double.MaxValue;
            var result = new Result {Acceptables = new List<Variation>(), ItemsCount = _calculate.Items.Count};
            var dtStart = DateTime.Now;

            for (int i = 0; i < variationsCount; i++)
            {
                var currentVariation = new Variation();
                _variationManager.AddKnapsack(currentVariation, _calculate.Knapsacks);
                
                _variationManager.FillFromSequence(currentVariation, _calculate.Items, SequenceHelper.GetSequence(i));

                if (IsOneItemInKnapsack(currentVariation, _calculate.Items) 
                    && IsKnapsackAcceptables(currentVariation)) 
                {
                    double sumWeightItem = _calculate.Items.Sum(item => item.Weight) / _calculate.Knapsacks.Count;

                    currentVariation.G = CalcDifference(currentVariation, sumWeightItem);
                    result.Acceptables.Add(currentVariation);

                    if (currentVariation.G < gMin)
                    {
                        result.Optimal = currentVariation;
                        gMin = currentVariation.G;
                    }

                    if (_calculate.CalculateError > 0
                        && IsAcceptablesCalculateError(currentVariation.G, _calculate.CalculateError, sumWeightItem))
                    {
                        break;
                    }
                }
            }
            result.RunTime = new TimeSpan(DateTime.Now.Ticks-dtStart.Ticks).TotalMilliseconds;
            return result;
        }

        private bool IsAcceptablesCalculateError(double g, double calculateError, double sumWeightItem)
        {
            return g <= sumWeightItem * calculateError;
        }

        private double CalcDifference(Variation solution, double sumWeightItem)
        {
            double difference = 0;
            foreach (Knapsack knapsack in solution.Knapsacks)
            {
                double knapsackWeightSum = knapsack.Items.Sum(i => i.Weight);
                difference += Math.Abs(knapsackWeightSum - sumWeightItem);
            }

            return difference;
        }

        private bool IsOneItemInKnapsack(Variation currentVariation, IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                int use = 0;
                foreach (Knapsack knapsack in currentVariation.Knapsacks)
                {
                    use += knapsack.Items.Count(i => i.Id == item.Id);
                }
                if (use > 1)
                {
                    return false;
                }
            }
            return true;
        }

        private int GetVariationsCount()
        {
            var variationsCount = (int) Math.Pow(2, _calculate.Items.Count*_calculate.Knapsacks.Count);
            return variationsCount;
        }

        private static bool IsKnapsackAcceptables(Variation currentVariation)
        {
            bool acceptables = true;
            foreach (Knapsack knapsack in currentVariation.Knapsacks)
            {
                if (knapsack.Capacity < knapsack.Items.Sum(i => i.Weight))
                {
                    acceptables = false;
                }
            }
            return acceptables;
        }
    }
}