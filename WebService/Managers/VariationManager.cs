using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService.Managers
{
    public class VariationManager
    {
        public Variation FillFromSequence(Variation variation, List<Item> items, bool[] sequence)
        {
            int knapsackIndx = 0;
            int itemIndx = 0;

            foreach (var s in sequence)
            {
                if (knapsackIndx == variation.Knapsacks.Count)
                {
                    knapsackIndx = 0;
                    itemIndx++;
                }
                if (s)
                {
                    variation.Knapsacks[knapsackIndx].Items.Add(new Item { Id = items[itemIndx].Id, Weight = items[itemIndx].Weight });
                }
                knapsackIndx++;
            }
            return variation;
        }

        public void AddKnapsack(Variation currentVariation, List<Knapsack> knapsacks)
        {
            if (currentVariation.Knapsacks == null)
            {
                currentVariation.Knapsacks = new List<Knapsack>();
            }
            foreach (var knapsack in knapsacks)
            {
                currentVariation.Knapsacks.Add(new Knapsack {Capacity = knapsack.Capacity, Items = new List<Item>(), Id = knapsack.Id});
            }
        }
    }

}