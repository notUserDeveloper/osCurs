using System.Collections.Generic;
using System.Web.UI.MobileControls;
using Web.localhost;

namespace Web.Code
{
    public static class TransportConverter
    {

        public static localhost.CalculateModel CalculateModelConverter(WebService.Models.CalculateModel ser)
        {
            var loc = new localhost.CalculateModel();
            loc.Knapsacks = GetlocKnaps(ser.Knapsacks);
            loc.Items = GetlocItems(ser.Items);
            loc.CalculateError = ser.CalculateError;
            return loc;
        }

        private static Item[] GetlocItems(List<WebService.Models.Item> serv)
        {
            var locItems = new Item[serv.Count];
            for (int i = 0; i < serv.Count; i++)
            {
                locItems[i] = new Item{ Weight = serv[i].Weight, Id = serv[i].Id };
            }
            return locItems;
        }

        private static Knapsack[] GetlocKnaps(List<WebService.Models.Knapsack> serv)
        {
            var locKnap = new Knapsack[serv.Count];
            for (int i = 0; i < serv.Count; i++)
            {
                locKnap[i] = new Knapsack {Capacity = serv[i].Capacity, Id = serv[i].Id};
            }
            return locKnap;
        }
    }

}