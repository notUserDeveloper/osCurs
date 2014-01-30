using System.Collections.Generic;

namespace WebService.Models
{
    public class CalculateModel
    {
        public double CalculateError { get; set; }
        public List<Item> Items { get; set; }
        public List<Knapsack> Knapsacks { get; set; }
    }
}