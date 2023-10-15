using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class DeleteModel : PageModel
    {
		public MenusClassRepositary _repo { get; set; }

		public bool IsDeleting { get; set; } = false;
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

		public DeleteModel(MenusClassRepositary repo)
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
				IsDeleting = true;

				DishName = Item.DishName;
				Day = Item.Day;
				MealTime = Item.MealTime;
			}

		}

		public void OnPost()
		{
			_repo.Remove(System.Guid.Parse(Request.Query["guid"].ToList().FirstOrDefault() ?? ""));
		}
	}
}
