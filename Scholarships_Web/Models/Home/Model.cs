using Microsoft.EntityFrameworkCore;

namespace Scholarships_Web.Models.Home;

public class Model
{
    private readonly EfContext _efContext;
    public Guid? SelectedTypeIdFilter { get; set; } = null;
    public String? SelectedTypeNameFilter { get; set; } = null;
    public Guid? SelectedDegreeIdFilter { get; set; } = null;
    private List<Scholarship> _scholarships;
    public List<Scholarship> Scholarships
    {
        get
        {
            if (SelectedDegreeIdFilter == null && SelectedTypeIdFilter == null)
            {
                return this._scholarships;
            }
            var scholarshipList = new List<Scholarship>();
            if (SelectedTypeIdFilter != null)
            {
                scholarshipList.AddRange(_scholarships.Where(s => s.TypeId == SelectedTypeIdFilter));
            }
            if (SelectedDegreeIdFilter != null)
            {
                scholarshipList.AddRange(_scholarships.Where(s => s.DegreeId == SelectedDegreeIdFilter));
            }
            return scholarshipList;
        }
        set => this._scholarships = value;
    }

    public List<Degree> Degrees { get; private set; }
    public List<ScholarshipType> ScholarshipTypes { get; private set; }

    public EfContext GetEfContext()
    {
        return _efContext;
    }

    public Model(EfContext efContext)
    {
        this._efContext = efContext;
        this._scholarships = ShuffleScholarships(_efContext.Scholarships.Local.ToList());
        this.Degrees = _efContext.Degrees.Local.ToList();
        this.ScholarshipTypes = _efContext.ScholarshipTypes.Local.ToList();
    }

    public List<Scholarship> GetScholarships()
    {
        if (SelectedDegreeIdFilter == null && SelectedTypeIdFilter == null)
        {
            return this.Scholarships;
        }
        var scholarshipList = new List<Scholarship>();
        if (SelectedTypeIdFilter != null)
        {
            scholarshipList.AddRange(Scholarships.Where(s => s.TypeId == SelectedTypeIdFilter));
        }
        if (SelectedDegreeIdFilter != null)
        {
            scholarshipList.AddRange(Scholarships.Where(s => s.DegreeId == SelectedDegreeIdFilter));
        }
        return scholarshipList;
    }
    
    
    public static List<Scholarship> ShuffleScholarships(List<Scholarship> list)
    {
        var random = new Random();
        var newShuffledList = new List<Scholarship>();
        var listcCount = list.Count;
        for (int i = 0; i < listcCount; i++)
        {
            var randomElementInList = random.Next(0, list.Count);
            newShuffledList.Add(list[randomElementInList]);
            list.Remove(list[randomElementInList]);
        }
        return newShuffledList;
    }
}