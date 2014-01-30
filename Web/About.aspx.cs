using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.localhost;

namespace Web
{
    public partial class About : System.Web.UI.Page
    {

        private readonly Service1 _proxy = new Service1();

        protected void Page_Load(object sender, EventArgs e)
        {
//            _proxy.Timeout = 1000*60*30;
        }

//        protected void test(object sender, EventArgs e)
//        {
//            var calculateModel = new CalculateModel {Knapsacks = new Knapsack[2]};
//            calculateModel.Knapsacks[0] = new Knapsack {Capacity = 0.7};
//            calculateModel.Knapsacks[1] = new Knapsack {Capacity = 0.7};
//
//            calculateModel.Items = new Item[6];
//
//            calculateModel.Items[0] = new Item {Id = 1, Weight = 0.11};
//            calculateModel.Items[1] = new Item {Id = 2, Weight = 0.24};
//            calculateModel.Items[2] = new Item {Id = 3, Weight = 0.15};
//            calculateModel.Items[3] = new Item {Id = 4, Weight = 0.33};
//            calculateModel.Items[4] = new Item {Id = 5, Weight = 0.12};
//            calculateModel.Items[5] = new Item {Id = 6, Weight = 0.27};
//
//            var result = _proxy.Calculate(calculateModel);
//        }
    }
}