using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebService.Helpers
{
    public static class DBCon
    {
        public static SqlConnection SqlCon
        {
            get { return new SqlConnection(ConString); }
        }
        private const string ConString = "Data Source=(localdb)\\v11.0;Initial Catalog=KnapsackProblem;Integrated Security=True";
    }
}