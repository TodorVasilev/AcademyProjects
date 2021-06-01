using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SmartGarage.Service.Helpers
{
    public static class SelectListExtention
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> items, int selectedValue = 0)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem selectList = new SelectListItem
            {
                Text = "---Select---",
                Value = "0"
            };

            list.Add(selectList);

            foreach (var item in items)
            {
                selectList = new SelectListItem
                {
                    Text = item.GetPropertyValue("Name"),
                    Value = item.GetPropertyValue("Id"),
                    Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                };

                list.Add(selectList);
            }

            return list;
        }
    }
}
