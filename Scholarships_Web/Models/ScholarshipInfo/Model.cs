namespace Scholarships_Web.Models.ScholarshipInfo;

public class Model
{
    private EfContext _efContext;
    public Scholarship Scholarship;

    public Model(EfContext efContext, Scholarship scholarship)
    {
        this._efContext = efContext;
        this.Scholarship = scholarship;
    }
}