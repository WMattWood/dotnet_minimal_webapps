using Template.Data;
using Template.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Template.Pages
{
    public class SearchModel : PageModel
    {
        private readonly AppDbContext _context;

        public SearchModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string AnimalSearchTerm { get; set; }

        [BindProperty]
        public string FruitSearchTerm { get; set; }

        public List<SelectListItem> AnimauxList { get; set; }
        public List<SelectListItem> FruitsList { get; set; }

        public void OnGet()
        {
            AnimauxList = GetAnimauxList();
            FruitsList = GetFruitsList();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Results", new {
                AnimalSearchTerm,
                FruitSearchTerm
            });
        }

        private List<SelectListItem> GetAnimauxList() =>
            _context.Animaux
                .OrderBy(a => a.Nom)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.Nom} ({a.Id})"
                })
                .ToList();


        private List<SelectListItem> GetFruitsList() =>
            _context.Fruits
                .OrderBy(f => f.Nom)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.Nom} ({f.Id})"
                })
                .ToList();
    }
}




