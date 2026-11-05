namespace Sharek.API.Areas.Catalog.Models
{
    public class ConditionPhoto
    {
        public int ConditionPhotoId { get; set; }
        public int RentId { get; set; } // related with Rent table in Orders
        public string PhotoUrl { get; set; }
        public string Phase { get; set; } // Before, After
        public DateTime TakenAt { get; set; }
    }
}