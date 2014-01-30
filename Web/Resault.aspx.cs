using System;
using System.Collections.Generic;
using System.Web.UI;
using Web.Code;
using Web.localhost;
using WebService.Managers;
using WebService.Models;
using CalculateModel = WebService.Models.CalculateModel;
using Knapsack = Web.localhost.Knapsack;
using Result = Web.localhost.Result;
using Variation = Web.localhost.Variation;

namespace Web
{
    public partial class Resault : Page
    {
        private Service1 _proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            _proxy = new Service1();
        }


        private void _proxy_CalculateCompleted(object sender, CalculateCompletedEventArgs e)
        {
            Result result = e.Result;

            var allowable = new List<ResultViewModel>();
            var optimal = new List<ResultViewModel>();


            foreach (Variation acceptable in result.Acceptables)
            {
                allowable.Add(new ResultViewModel
                {
                    G = Math.Round(acceptable.G,3),
                    Knapsacks = getLineKnapsacks(acceptable.Knapsacks),
                    Items = getLineItems(acceptable.Knapsacks)
                });
            }

            optimal.Add(new ResultViewModel
            {
                G = Math.Round(result.Optimal.G, 3),
                Knapsacks = getLineKnapsacks(result.Optimal.Knapsacks),
                Items = getLineItems(result.Optimal.Knapsacks)
            });

            OptimalGrid.DataSource = optimal;
            OptimalGrid.DataBind();

            AllowableGrid.DataSource = allowable;
            AllowableGrid.DataBind();

            new ExampleManager().UpdateExecuteTime(Convert.ToInt32(Request.QueryString["idExp"]), 
                                                    Math.Round(result.RunTime));

            info.Text = "Время рассчета: " + Math.Round(result.RunTime) + " мс";
        }

        private string getLineItems(IEnumerable<Knapsack> knapsacks)
        {
            string rez = string.Empty;
            foreach (var knapsack in knapsacks)
            {
                foreach (var item in knapsack.Items)
                {
                    rez += ",[" + knapsack.Id + ":" + item.Weight + "]";
                }
                
            }
            return rez.TrimStart(',');
        }

        private string getLineKnapsacks(IEnumerable<Knapsack> knapsacks)
        {
            string rez = string.Empty;
            foreach (var knapsack in knapsacks)
            {
                rez += "," + knapsack.Capacity;
            }
            return rez.TrimStart(',');
        }

        private void TryCalculate(int idEx)
        {
            var calculateModel = new CalculateModel();

            var knManager = new KnapsackManager();
            var itManager = new ItemManager();
            var exManager = new ExampleManager();

            calculateModel.Knapsacks = knManager.GetKnapsacks(idEx);
            calculateModel.Items = itManager.GetItems(idEx);
            calculateModel.CalculateError = exManager.GetCalculateError(idEx);

            _proxy.CalculateCompleted += _proxy_CalculateCompleted;
            _proxy.CalculateAsync(TransportConverter.CalculateModelConverter(calculateModel));
        }

        protected void btnCalculate_OnClick(object sender, EventArgs e)
        {
            var exManager = new ExampleManager();

            if (Request.QueryString["idExp"] != null)
            {
                int idEx = Convert.ToInt32(Request.QueryString["idExp"]);
                if (exManager.CheckExists(idEx))
                {
                    TryCalculate(idEx);
                }
            }
        }
    }
}