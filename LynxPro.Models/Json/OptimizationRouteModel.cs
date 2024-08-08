using System.Collections.Generic;

namespace LynxPro.Models.Json
{
    public class OptimizationRouteModel
    {
        public DirectionsRoute DirectionsRoute { get; set; }
        public ComparedEntry ComparedEntry { get; set; }
        public List<string> DeletedRoutes { get; set; }
    }
    public class ComparedEntry
    {
        public string Number { get; set; }
        public int Index { get; set; }
    }
}
