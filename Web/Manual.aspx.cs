using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Managers;
using WebService.Models;

namespace Web
{
    public partial class Manual : Page
    {
        private double _calculateError;
        private List<Item> _items;
        private List<Knapsack> _knapsacks;

        protected void Page_Load(object sender, EventArgs e)
        {
            _knapsacks = (List<Knapsack>) Session["kn"];
            _items = (List<Item>) Session["it"];

            if (Session["ce"] != null)
            {
                _calculateError = (double) Session["ce"];
            }
        }

        protected void btnGridParameters_OnClick(object sender, EventArgs e)
        {
            _knapsacks = new List<Knapsack>();
            _items = new List<Item>();

            int knapCount = Convert.ToInt32(KnapsacksCount.Text);
            int itemCount = Convert.ToInt32(ItemsCount.Text);

            for (int i = 0; i < knapCount; i++)
            {
                _knapsacks.Add(new Knapsack {Id = i});
            }
            for (int i = 0; i < itemCount; i++)
            {
                _items.Add(new Item {Id = i});
            }

            Session["kn"] = _knapsacks;
            Session["it"] = _items;
            Session["ce"] = Convert.ToDouble(CalculateError.Text);

            KnapsacksGrid.DataSource = _knapsacks;
            KnapsacksGrid.DataBind();
            ItemsGrid.DataSource = _items;
            ItemsGrid.DataBind();
        }

//        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            var a = KnapsacksGrid.Rows[0].Cells[0].Controls;
//            if (e.Row.RowType == DataControlRowType.DataRow)
//            {
//                var lb = new Label{ID = "LbId"};
//                var tb = new TextBox {CssClass = "form-control input-sm", ID = "GrIn"};
//                e.Row.Cells[0].Controls.Add(lb);
//                e.Row.Cells[1].Controls.Add(tb);
//            }
//        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int idExp = new ExampleManager().AddExample(_knapsacks, _items, _calculateError);
            Response.Redirect("Resault.aspx?idExp="+idExp,true);
        }

        private List<Item> GetItemsFromGrid(GridView itemsGrid)
        {
            var items = new List<Item>();
            foreach (GridViewRow row in itemsGrid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    items.Add(new Item
                    {
                        Id = Convert.ToInt32((row.Cells[0].Controls[0] as Label).Text),
                        Weight = Convert.ToDouble((row.Cells[1].Controls[0] as TextBox).Text)
                    });
                }
            }
            return items;
        }

        private List<Knapsack> GetKnapsacksFromGrid(GridView knapsacksGrid)
        {
            var knaps = new List<Knapsack>();
            foreach (GridViewRow row in knapsacksGrid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    knaps.Add(new Knapsack
                    {
                        Id = Convert.ToInt32((row.Cells[0].Controls[0] as Label).Text),
                        Capacity = Convert.ToDouble((row.Cells[1].Controls[0] as TextBox).Text)
                    });
                }
            }
            return knaps;
        }

        protected void KnapsacksGrid_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            KnapsacksGrid.EditIndex = e.NewEditIndex;
            KnapsacksGrid.DataSource = _knapsacks;
            KnapsacksGrid.DataBind();
        }

        protected void ItemsGrid_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            ItemsGrid.EditIndex = e.NewEditIndex;
            ItemsGrid.DataSource = _items;
            ItemsGrid.DataBind();
        }

        protected void KnapsacksGrid_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = KnapsacksGrid.Rows[e.RowIndex];
            _knapsacks[row.DataItemIndex].Capacity = Convert.ToDouble((row.Cells[2].Controls[0] as TextBox).Text);

            KnapsacksGrid.EditIndex = -1;
            KnapsacksGrid.DataSource = _knapsacks;
            KnapsacksGrid.DataBind();
        }

        protected void ItemsGrid_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = ItemsGrid.Rows[e.RowIndex];
            _items[row.DataItemIndex].Weight = Convert.ToDouble((row.Cells[2].Controls[0] as TextBox).Text);

            ItemsGrid.EditIndex = -1;
            ItemsGrid.DataSource = _items;
            ItemsGrid.DataBind();
        }
    }
}