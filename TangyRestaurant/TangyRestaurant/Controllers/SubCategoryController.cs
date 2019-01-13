using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using TangyRestaurant.Models.SubCategoryViewModels;
using TangyRestaurant.Utility;

namespace TangyRestaurant.Controllers
{
    [Authorize(Roles = SD.AdminAndUser)]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        [TempData] //This will display something only ONE TIME !!!! AFTER REFRESHING IT GOES AWAY !!!
        public string StatusMessage { get; set; }

        public SubCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            ICollection<SubCategory> subCategories = await _db.SubCategories
                .Include(sc => sc.category)
                .ToListAsync();

            return View(subCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {

            SubCategoryAndCategoryViewModel subCategoryAndCategoryViewModel = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = _db.Categories.ToList(),
                subCategory = new SubCategory(),
                SubCategoriesNamesList = _db.SubCategories
                    .OrderBy(p => p.Name)
                    .Select(p => p.Name)
                    .Distinct()
                    .ToList(),
            };


            return View(subCategoryAndCategoryViewModel);
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = await _db.Categories.SingleOrDefaultAsync(c => c.Name == model.subCategory.category.Name);

                model.subCategory.category = category;
                model.subCategory.categoryId = category.Id;


                //chack if the subcategory exists
                int doesSubCategoryExists = _db.SubCategories.Where(sc => sc.Name == model.subCategory.Name).Count();

                //check if the combination exists
                int doesSubCatAndCatExists = _db.SubCategories
                    .Where(sc => sc.Name == model.subCategory.Name && sc.categoryId == model.subCategory.categoryId).Count();

                //if te SubCategory exists and the user sad that it does not exist, then we display a error
                if (doesSubCategoryExists > 0 && model.isNew)
                {
                    //Show error
                    StatusMessage = "Error : Sub Category already exists !";
                }
                else
                {
                    //If the user sad that the sibcategory exista but in reality it does not then we display a error
                    if (doesSubCategoryExists == 0 && !model.isNew)
                    {
                        //Error
                        StatusMessage = "Error : Sub Category does not exists !";

                    }
                    else
                    {

                        //If the category exists we display a message because it is already there
                        if (doesSubCatAndCatExists > 0)
                        {
                            //error
                            StatusMessage = "Error : Category and Sub Category combination already exists !";

                        }
                        else
                        {

                            
                            await _db.SubCategories.AddAsync(model.subCategory);
                            await _db.SaveChangesAsync();
                            this.StatusMessage = "Sub Category Created Successfully !";
                            
                            //Category category = _db.Categories.ToList().Last();
                            //_db.Categories.Remove(category);
                            //await _db.SaveChangesAsync();

                            return RedirectToAction(nameof(Index));
                        }
                    }

                }

            }

            SubCategoryAndCategoryViewModel VM = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = _db.Categories.ToList(),
                subCategory = model.subCategory,
                StatusMessage = this.StatusMessage,
                SubCategoriesNamesList = _db.SubCategories
                    .OrderBy(p => p.Name)
                    .Select(p => p.Name)
                    .ToList(),
            };

            this.StatusMessage = VM.StatusMessage;

            return View(VM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubCategory subCategory = await _db.SubCategories
                .Include(sc => sc.category)
                .SingleOrDefaultAsync(sc => sc.Id == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            SubCategoryAndCategoryViewModel subCategoryAndCategoryViewModel = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = _db.Categories.ToList(),
                subCategory = subCategory,
                SubCategoriesNamesList = _db.SubCategories
                    .OrderBy(p => p.Name)
                    .Select(p => p.Name)
                    .Distinct()
                    .ToList()
            };

            return View(subCategoryAndCategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel subCategoryAndCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {

                SubCategoryAndCategoryViewModel VM = new SubCategoryAndCategoryViewModel()
                {
                    CategoriesList = _db.Categories.ToList(),
                    subCategory = subCategoryAndCategoryViewModel.subCategory,
                    StatusMessage = "Error : The model state is not valid !",
                    SubCategoriesNamesList = _db.SubCategories
                     .OrderBy(p => p.Name)
                     .Select(p => p.Name)
                     .ToList(),
                };

                this.StatusMessage = VM.StatusMessage;

                return View(VM);
            }

            bool subcategoryExists = await _db.SubCategories.AnyAsync(sc => sc.Name == subCategoryAndCategoryViewModel.subCategory.Name);

            if (subcategoryExists)
            {

                //If the combination betweeen subcategory and category exists
                foreach (SubCategory subcat in _db.SubCategories.Where(sc => sc.Name == subCategoryAndCategoryViewModel.subCategory.Name).Include(sc => sc.category))
                {
                    if (subcat.category.Name == subCategoryAndCategoryViewModel.subCategory.category.Name)
                    {
                        SubCategoryAndCategoryViewModel VM = new SubCategoryAndCategoryViewModel()
                        {
                            CategoriesList = _db.Categories.ToList(),
                            subCategory = subCategoryAndCategoryViewModel.subCategory,
                            StatusMessage = "Error : Sub category already exists with the category " + subCategoryAndCategoryViewModel.subCategory.category.Name + " !",
                            SubCategoriesNamesList = _db.SubCategories
                            .OrderBy(p => p.Name)
                            .Select(p => p.Name)
                            .ToList(),
                        };

                        this.StatusMessage = VM.StatusMessage;

                        return View(VM);
                    }
                }
            }

            Category category = await _db.Categories.SingleOrDefaultAsync(sc => sc.Name == subCategoryAndCategoryViewModel.subCategory.category.Name);

            if (category == null)
            {
                SubCategoryAndCategoryViewModel VM = new SubCategoryAndCategoryViewModel()
                {
                    CategoriesList = _db.Categories.ToList(),
                    subCategory = subCategoryAndCategoryViewModel.subCategory,
                    StatusMessage = "Error : The category does not exist !",
                    SubCategoriesNamesList = _db.SubCategories
                       .OrderBy(p => p.Name)
                       .Select(p => p.Name)
                       .ToList(),
                };

                this.StatusMessage = VM.StatusMessage;

                return View(VM);
            }

            SubCategory subCategory = await _db.SubCategories
                .SingleOrDefaultAsync(sc => sc.Id == subCategoryAndCategoryViewModel.subCategory.Id);

            if (!subcategoryExists)
            {

                SubCategoryAndCategoryViewModel VM = new SubCategoryAndCategoryViewModel()
                {
                    CategoriesList = _db.Categories.ToList(),
                    subCategory = subCategoryAndCategoryViewModel.subCategory,
                    StatusMessage = "Error : Sub category does not exist !  You cannot create new Sub categories here !",
                    SubCategoriesNamesList = _db.SubCategories
                       .OrderBy(p => p.Name)
                       .Select(p => p.Name)
                       .ToList(),
                };

                this.StatusMessage = VM.StatusMessage;

                return View(VM);
            }

            subCategory.category = category;

            subCategory.Name = subCategoryAndCategoryViewModel.subCategory.Name;

            subCategory.categoryId = category.Id;

            _db.SubCategories.Update(subCategory);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubCategory subCategory = await _db.SubCategories
                .Include(sc => sc.category)
                .SingleOrDefaultAsync(sc => sc.Id == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            SubCategoryAndCategoryViewModel subCategoryAndCategoryViewModel = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = _db.Categories.ToList(),
                subCategory = subCategory,
                SubCategoriesNamesList = _db.SubCategories
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToList(),
            };

            return View(subCategoryAndCategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SubCategory subCategory)
        {
            if (id != subCategory.Id)
            {
                return NotFound();
            }

            SubCategory subToDelete = await _db
                .SubCategories
                .SingleOrDefaultAsync(sc => sc.Id == id);

            _db.SubCategories.Remove(subToDelete);

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubCategory subCategory = await _db.SubCategories.Include(sc => sc.category).SingleOrDefaultAsync(sc => sc.Id == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }
    }
}