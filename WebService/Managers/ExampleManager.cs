using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebService.Helpers;
using WebService.Models;

namespace WebService.Managers
{
    public class ExampleManager
    {
        private readonly SqlConnection _dbCon;

        public ExampleManager()
        {
            _dbCon = DBCon.SqlCon;
        }

        public int AddExample(List<Knapsack> knapsacks, List<Item> items, double calculateError)
        {
            _dbCon.Open();
            string qr = @"INSERT INTO Examples(CalculateError) VALUES(" + calculateError + ")";
            var dbcom = new SqlCommand(qr, _dbCon);
            dbcom.ExecuteNonQuery();

            qr = "SELECT SCOPE_IDENTITY()";
            dbcom.CommandText = qr;
            int exId = Int32.Parse(dbcom.ExecuteScalar().ToString());

            foreach (Knapsack knapsack in knapsacks)
            {
                qr = "Insert into Knapsacks(Id,ExampleId,Capacity) VALUES(" +
                     knapsack.Id + "," + exId + "," + knapsack.Capacity + ")";
                dbcom.CommandText = qr;
                dbcom.ExecuteNonQuery();
            }

            foreach (Item item in items)
            {
                qr = "Insert into Items(ExampleId,Id,Weight) VALUES(" +
                     exId + "," + item.Id + "," + item.Weight + ")";
                dbcom.CommandText = qr;
                dbcom.ExecuteNonQuery();
            }
            _dbCon.Close();

            return exId;
        }

        public bool CheckExists(int idEx)
        {
            bool rez = true;
            _dbCon.Open();
            string qr = "SELECT count(*) FROM Examples where id=" + idEx;
            var dbcom = new SqlCommand(qr, _dbCon);
            var count = (int) dbcom.ExecuteScalar();
            if (count == 0)
            {
                rez = false;
            }
            _dbCon.Close();
            return rez;
        }

        public void UpdateExecuteTime(int exId, double timeMs)
        {
            _dbCon.Open();
            string qr = "UPDATE Examples SET ExecuteTime=" + timeMs + " where Id=" + exId;
            var dbcom = new SqlCommand(qr, _dbCon);
            dbcom.ExecuteNonQuery();
            _dbCon.Close();
        }

        public List<int> GetAllExamplesId()
        {
            var idEx = new List<int>();
            _dbCon.Open();
            string qr = "SELECT * FROM Examples";
            var dbcom = new SqlCommand(qr, _dbCon);
            SqlDataReader reader = dbcom.ExecuteReader();
            while (reader.Read())
                idEx.Add(reader.GetInt32(0));
            _dbCon.Close();

            return idEx;
        }

        public double GetCalculateError(int idEx)
        {
            _dbCon.Open();
            string qr = "SELECT CalculateError FROM Examples where id=" + idEx;
            var dbcom = new SqlCommand(qr, _dbCon);
            var rez = Convert.ToDouble(dbcom.ExecuteScalar());
            _dbCon.Close();
            return rez;
        }
    }
}