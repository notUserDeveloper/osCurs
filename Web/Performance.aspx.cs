using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Web.Code;
using Web.localhost;
using WebService.Managers;
using CalculateModel = WebService.Models.CalculateModel;
using Item = WebService.Models.Item;
using Knapsack = WebService.Models.Knapsack;
using Result = Web.localhost.Result;

namespace Web
{
    public partial class Performance : Page
    {
        private Random _rnd;
        private List<Result> _resaults;
        private const int IterationCount = 11;

        protected void Page_Load(object sender, EventArgs e)
        {
            _rnd = new Random();
            _resaults = new List<Result>();
        }

        protected void DrawChart()
        {
            _resaults = _resaults.OrderBy(r => r.ItemsCount).ToList();
            foreach (var resault in _resaults)
            {
                PerformChart.Series[0].IsValueShownAsLabel = true;
                PerformChart.Series[0].Points.Add(new DataPoint
                {
                    XValue = resault.ItemsCount,
                    YValues = new[]{resault.RunTime},
                    Label = "[" + resault.ItemsCount + ":" + Math.Round(resault.RunTime) + "]",
                });
            }
        }

        protected void Calculate_OnClick(object sender, EventArgs e)
        {
            var calculateModel = new List<CalculateModel>();

            double calcError = 0;
            double.TryParse(CalculateError.Text, out calcError);
            int knapsackCount = Convert.ToInt32(KnapsacksCountSelect.SelectedValue);

            for (int i = 1; i <= IterationCount; i++)
            {
                calculateModel.Add(new CalculateModel()
                {
                    CalculateError = calcError,
                    Items = GetRandomItems(i),
                    Knapsacks = GetRandomKnapsacks(knapsackCount)
                });
            }
            foreach (var model in calculateModel)
            {
                var proxy = new Service1();
                proxy.CalculateCompleted += OnCalculateCompleted;
                proxy.CalculateAsync(TransportConverter.CalculateModelConverter(model));    
            }
        }

        private void OnCalculateCompleted(object sender, CalculateCompletedEventArgs e)
        {
            _resaults.Add(e.Result);
            if (_resaults.Count == IterationCount)
            {
                DrawChart();
            }
        }

        private List<Knapsack> GetRandomKnapsacks(int knapsackCount)
        {
            var knapsacks = new List<Knapsack>();
            for (int i = 0; i < knapsackCount; i++)
            {
                knapsacks.Add(new Knapsack
                {
                    Capacity = _rnd.NextDouble()*6,
                    Id = i
                });
            }
            return knapsacks;
        }

        private List<Item> GetRandomItems(int itemsCount)
        {
            var items = new List<Item>();
            for (int i = 0; i < itemsCount; i++)
            {
                items.Add(new Item
                {
                    Id = i,
                    Weight = _rnd.NextDouble()*2
                });
            }
            return items;
        }
    }
}