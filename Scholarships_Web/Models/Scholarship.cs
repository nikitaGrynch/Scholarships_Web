using System.Runtime.InteropServices;

namespace Scholarships_Web.Models;

public class Scholarship
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public Guid TypeId { get; set; }
    public String Requirements { get; set; }
    public Guid DegreeId { get; set; }
    public String FinancialCoverage { get; set; }
    
    
    // Navigation Properties
    public ScholarshipType Type { get; set; }
    public Degree Degree { get; set; }
}