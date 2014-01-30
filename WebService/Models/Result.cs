using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public class Result
    {
        public Variation Optimal { get; set; }
        public List<Variation> Acceptables { get; set; }
        public double RunTime { get; set; }
        public int ItemsCount { get; set; }
    }
}