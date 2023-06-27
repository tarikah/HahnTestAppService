namespace HahnTestAppService.Domain.Entities
{
    public class CarPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public string SerialNumber { get; set; }
        public DateTime MadeOn { get; set; }
        public DateTime? ValidTill { get; set; }
        public int ManufacturerId { get; set; }
        public int PartTypeId { get; set; }
        public int AvailableQuantity { get; set; }
        public int AVAILABLE_QUANTITY
        {
            get
            {
                return TotalQuantity - ReservedQuantity;
            }
        }
        public int ReservedQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public PartType PartType { get; set; }
        public List<PartBrand> partBrands { get; set; }

    }
}
