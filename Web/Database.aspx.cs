using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Managers;
using WebService.Models;

namespace Web
{
    public partial class Database : Page
    {
        private List<ExampleModel> _exampleModel;
        protected void Page_Load(object sender, EventArgs e)
        {
            _exampleModel = new List<ExampleModel>();

            var exManager = new ExampleManager();
            var knManager = new KnapsackManager();
            var itManager = new ItemManager();

            var idEx = exManager.GetAllExamplesId();

            foreach (var id in idEx)
            {
                string knapsacks = string.Empty;
                string items = string.Empty;

                knManager.GetKnapsacks(id).ForEach(k => knapsacks+=","+k.Capacity);
                itManager.GetItems(id).ForEach(i => items+=","+i.Weight);

                _exampleModel.Add(new ExampleModel
                {
                    Id = id,
                    Error = exManager.GetCalculateError(id),
                    Knapsacks = knapsacks.TrimStart(','),
                    Items = items.TrimStart(',')
                });
            }

            ExamplesGrid.DataSource = _exampleModel;
            ExamplesGrid.DataBind();

        }

        protected void ExamplesGrid_OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var exId = ExamplesGrid.Rows[e.NewSelectedIndex].Cells[1].Text;
            Response.Redirect("Resault.aspx?idExp=" + exId, true);
        }
    }
}