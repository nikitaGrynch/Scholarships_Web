using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarships_Web.Models;
using Scholarships_Web.Models.Home;
using Model = Scholarships_Web.Models.AddScholarship.Model;

namespace Scholarships_Web.Controllers;

public class HomeController : Controller
{
    private EfContext _efContext;
    private readonly ILogger<HomeController> _logger;
    private Models.Home.Model _homeModel;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        this._efContext = new();
        this._efContext.ScholarshipTypes.Load();
        this._efContext.Degrees.Load();
        this._efContext.Scholarships.Load();
        _homeModel = new(_efContext);
    }
    
    [HttpPost]
    public IActionResult AddScholarship(IFormCollection collection)
    {
        _efContext.Scholarships.Add(new()
        {
            Name = collection["name"],
            Description = collection["description"],
            TypeId = Guid.Parse(collection["scholarshipType"]),
            Requirements = collection["requirements"],
            DegreeId = Guid.Parse(collection["degree"]),
            FinancialCoverage = collection["financialCoverage"]
        });
        _efContext.SaveChanges();
        return RedirectToAction("Index");
    }  

    public IActionResult Index()
    {
        return View(_homeModel);
    }
    
    public IActionResult AddScholarship()
    {
        Models.AddScholarship.Model model = new(_efContext);
        return View(model);
    }
    
    public IActionResult ScholarshipInfo(String id)
    {
        return View(_efContext.Scholarships.First(s => s.Id == Guid.Parse(id)));
    }
    
    public IActionResult DeleteScholarship(String id)
    {
        _efContext.Scholarships.Remove(_efContext.Scholarships.First(s => s.Id == Guid.Parse(id)));
        _efContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult SetScholarshipTypeFilter(String id)
    {

        _homeModel.SelectedTypeIdFilter = id == "0" ? null : Guid.Parse(id);
        return View("Index",_homeModel);
    }
    public IActionResult SetScholarshipDegreeFilter(String id)
    {
        _homeModel.SelectedDegreeIdFilter = id == "0" ? null : Guid.Parse(id);
        return View("Index",_homeModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}