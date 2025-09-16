using Template.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public string AnimalIdSelection { get; set; }

        [BindProperty]
        public string FruitIdSelection { get; set; }

        public List<SelectListItem> AnimauxList { get; set; }
        public List<SelectListItem> FruitsList { get; set; }

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

        public void OnGet()
        {
            AnimauxList = GetAnimauxList();
            FruitsList = GetFruitsList();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Results", new {
                animalId = AnimalIdSelection,
                fruitId = FruitIdSelection
            });
        }
    }
}