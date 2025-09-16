using Template.Data;
using Template.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Template.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly AppDbContext _context;
        public ResultsModel(AppDbContext context) => _context = context;

        // Bindable search properties
        [BindProperty(SupportsGet = true)]
        public string? AnimalSearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FruitSearchTerm { get; set; }

        public List<AnimalEntity> AnimalResults { get; set; } = new();
        public List<FruitEntity> FruitResults { get; set; } = new();

        public async Task OnGet()
        {
            AnimalResults = string.IsNullOrEmpty(AnimalSearchTerm)
                ? new List<AnimalEntity>()
                : await _context.Animaux
                    .Where(a => a.Nom.ToLower().Contains(AnimalSearchTerm.ToLower()))
                    .ToListAsync();

            FruitResults = string.IsNullOrEmpty(FruitSearchTerm)
                ? new List<FruitEntity>()
                : await _context.Fruits
                    .Where(f => f.Nom.ToLower().Contains(FruitSearchTerm.ToLower()))
                    .ToListAsync();
        }
    }
}
