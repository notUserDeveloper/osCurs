using System.Collections.Generic;
using System.Data.SqlClient;
using WebService.Helpers;
using WebService.Models;

namespace WebService.Managers
{
    public class ChartManager
    {
        private readonly SqlConnection _dbCon;

        public ChartManager()
        {
            _dbCon = DBCon.SqlCon;
        }

        public List<ChartView> GetChartForCountKnapsack(int knapsackCount, int withError)
        {
            var chart = new List<ChartView>();

            _dbCon.Open();
            var errorSelect = (withError == 0) ? "=" : "!=";
            string qr = @"select ex.ExecuteTime, it.ItCount, kn.knCount from Examples as ex 
  LEFT JOIN  (select it.ExampleId,count(it.Id) as ItCount from Items as it group by it.ExampleId) as it
  on it.ExampleId = ex.Id
  LEFT JOIN  (select count(kn.Id) as knCount, kn.ExampleId from Knapsacks as kn group by kn.ExampleId) as kn
  on kn.ExampleId = ex.Id where kn.knCount = " + knapsackCount + " and ex.CalculateError" + errorSelect + "0";
            var dbcom = new SqlCommand(qr, _dbCon);
            SqlDataReader reader = dbcom.ExecuteReader();
            while (reader.Read())
            {
                chart.Add(new ChartView
                {
                    ExecuteTime = (double) reader.GetDecimal(0),
                    ItemCount = reader.GetInt32(1)
                });
            }

            _dbCon.Close();

            return chart;
        }
    }
}