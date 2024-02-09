using IScaleAPI.Entities;

namespace IScaleAPI.ViewModel
{
    public class RainfallViewModel
    {
        public string? @context { get; set; }
        public MetaData? meta { get; set; }
        public List<Measure>? items { get; set; }
    }
}
