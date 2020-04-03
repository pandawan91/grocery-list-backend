using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grocery_list_backend.Models
{
    public class GroceryListItemModel
    {
        public int GroceryListItemModelId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
