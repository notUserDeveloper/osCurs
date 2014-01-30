using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebService.Helpers;
using WebService.Models;

namespace WebService.Managers
{
    public class ItemManager
    {
        private readonly SqlConnection _dbCon;
        public ItemManager()
        {
            _dbCon = DBCon.SqlCon;
        }
        public List<Item> GetItems(int exId)
        {
            var items = new List<Item>();

            _dbCon.Open();
            var qr = "SELECT * FROM Items where ExampleId="+exId;
            var dbcom = new SqlCommand(qr, _dbCon);
            var reader = dbcom.ExecuteReader();
            while (reader.Read())
                items.Add(new Item()
                {
                    Id = reader.GetInt32(1),
                    Weight = (double)reader.GetDecimal(2)
                });
            _dbCon.Close();

            return items;
        }
    }
}