namespace Scholarships_Web.Models.AddScholarship;

public class Model
{
    private EfContext _efContext;

    public Model(EfContext efContext)
    {
        this._efContext = efContext;
    }

    public List<ScholarshipType> GetScholarshipTypes()
    {
        return this._efContext.ScholarshipTypes.Local.ToList();
    }
    
    public List<Degree> GetDegrees()
    {
        return this._efContext.Degrees.Local.ToList();
    }
}
