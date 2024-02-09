namespace IScaleAPI.Entities
{
    public class Item
    {
        public int id { get; set; }
        public string? label { get; set; }
        public LatestReading? latestReading { get; set; }
        public string? notation { get; set; }
        public string? parameter { get; set; }
        public string? parameterName { get; set; }
        public string? period { get; set; } 
        public string? qualifier { get; set; }
        public string? station { get; set; }
        public string? stationReference { get; set; }
        public string? unit { get; set; }
        public string? unitName { get; set; }
        public string? valueType { get; set; }

    }
}
