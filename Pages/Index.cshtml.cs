using Lab2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Pages
{
    public class IndexModel : PageModel
    {
        public List<MenusClass> Items { get; set; }

        public IndexModel(MenusClassRepositary repo)
        {
            Items = repo.List().OrderBy(x => x.Day).ThenByDescending(x => x.MealTime).ToList();
        }
    }
}
