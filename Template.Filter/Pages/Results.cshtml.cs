using Template.Data;
using Template.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Template.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ResultsModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string AnimalId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FruitId { get; set; }

        public AnimalEntity SelectedAnimal { get; set; }
        public FruitEntity SelectedFruit { get; set; }

        public void OnGet()
        {
            SelectedAnimal = _context.Animaux
                .FirstOrDefault(a => a.Id == AnimalId);

            SelectedFruit = _context.Fruits
                .FirstOrDefault(f => f.Id == FruitId);
        }
    }
}

//namespace Template.Pages
//{
//    public class ResultsModel : PageModel
//    {
//        private readonly AppDbContext _db;
//        public ResultsModel(AppDbContext db) => _db = db;

//        public List<AnimalEntity> AnimalResults { get; set; } = new();
//        public List<FruitEntity> FruitResults { get; set; } = new();

//        public async Task OnGet(string? nom, string? id)
//        {
//            var query = _db.Animaux.AsQueryable();

//            if (!string.IsNullOrEmpty(nom))
//                query = query.Where(animal => animal.Id.Contains(animalId));

//            if (!string.IsNullOrEmpty(id))
//                query = query.Where(res => res.Id == id);

//            Results = await query.ToListAsync();
//        }
//    }
//}

