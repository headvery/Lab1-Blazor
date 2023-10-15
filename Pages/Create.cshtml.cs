using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class CreateModel : PageModel
    {
		public MenusClassRepositary _repo { get; set; }
		public bool IsEditing { get; set; } = false;
		public List<string> DaysList { get; set; } = DaysClass.ToList();
		public List<string> MealsTypeList { get; set; } = MealsTypeClass.ToList();
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid? Id { get; set; }
		/// <summary>
		/// Название блюда
		/// </summary>
		public string DishName { get; set; } = string.Empty;
		/// <summary>
		/// День недели
		/// </summary>
		public string Day { get; set; } = string.Empty;
		/// <summary>
		/// Время приёма пищи
		/// </summary>
		public string MealTime { get; set; } = string.Empty;

		public CreateModel(MenusClassRepositary repo)
		{
			_repo = repo;
		}

		public void OnGet()
		{
			try
			{
				Id = System.Guid.Parse(Request.Query["guid"].ToList().FirstOrDefault() ?? "");
			}
			catch
			{
				Id = null;
			}

			if (Id != null)
			{
				var Item = _repo.MenusItems.FirstOrDefault(e => e.Id == Id) ?? new();
				IsEditing = true;

				DishName = Item.DishName;
				Day = Item.Day;
				MealTime = Item.MealTime;
			}

		}

		public IActionResult OnPost()
		{
			DishName = Request.Form["dishname"];
			Day = Request.Form["days"];
			MealTime = Request.Form["mealstime"];
			try
			{
				Guid tempGuid = System.Guid.Parse(Request.Query["guid"].ToList().FirstOrDefault() ?? "");
				_repo.Update(new MenusClass { Id = tempGuid, DishName = DishName, Day = Day, MealTime = MealTime });
			}
			catch
			{
				_repo.Add(new MenusClass { DishName = DishName, Day = Day, MealTime = MealTime });
			}

			return new RedirectToPageResult("Index");
		}
	}
}
