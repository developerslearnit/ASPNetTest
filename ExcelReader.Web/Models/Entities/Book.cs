namespace ExcelReader.Web.Models.Entities
{
    public class Book : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
