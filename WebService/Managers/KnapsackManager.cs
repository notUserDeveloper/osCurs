using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebService.Helpers;
using WebService.Models;

namespace WebService.Managers
{
    public class KnapsackManager
    {
        private readonly SqlConnection _dbCon;
        public KnapsackManager()
        {
            _dbCon = DBCon.SqlCon;
        }
        public List<Knapsack> GetKnapsacks(int exId)
        {
            var knapsacks = new List<Knapsack>();

            _dbCon.Open();
            var qr = "SELECT * FROM Knapsacks where ExampleId="+exId;
            var dbcom = new SqlCommand(qr, _dbCon);
            var reader = dbcom.ExecuteReader();
            while (reader.Read())
                knapsacks.Add(new Knapsack()
                {
                    Id = reader.GetInt32(0),
                    Capacity = (double)reader.GetDecimal(2)
                });
            _dbCon.Close();

            return knapsacks;
        }

        public List<int> GetKnapsacksCountAvailable()
        {
            var knAvailable = new List<int>();

            _dbCon.Open();
            var qr = "select distinct count(Id) from Knapsacks group by ExampleId";
            var dbcom = new SqlCommand(qr, _dbCon);
            var reader = dbcom.ExecuteReader();
            while (reader.Read())
                knAvailable.Add(reader.GetInt32(0));
            _dbCon.Close();

            return knAvailable;
        }
    }
}