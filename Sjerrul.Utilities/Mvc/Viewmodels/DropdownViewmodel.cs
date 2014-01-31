using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sjerrul.Utilities.Mvc.Viewmodels
{
    class DropdownViewmodel
    {
        public string SelectedId { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}
