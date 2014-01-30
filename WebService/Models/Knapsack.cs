using System.Collections.Generic;

namespace WebService.Models
{
    public class Knapsack
    {
        public int Id { get; set; }
        public double Capacity { get; set; }
        public List<Item> Items { get; set; }

        public Knapsack()
        {
            Items = new List<Item>();
        }
    }
}