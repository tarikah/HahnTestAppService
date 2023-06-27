namespace HahnTestAppService.Contracts.Request
{
    public class AddUpdatePartRequest
    {
        public int? Id{ get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public int SerialNumber { get; set; }
        public DateTime MadeOn { get; set; } = DateTime.Now;
        public DateTime? ValidTill { get; set; }
        public int ManufacturerId { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReservedQuantity { get; set; } = 0;
        public int TotalQuantity { get; set; }
    }
}
