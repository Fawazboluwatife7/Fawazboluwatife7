using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aBookApp.Models.Viewmodel
{
    public class ProductVM
    {
        public Products Products { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> OrderList { get; set; }
    }
}
 