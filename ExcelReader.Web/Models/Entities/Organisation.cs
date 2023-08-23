namespace ExcelReader.Web.Models.Entities
{
    public class Organisation:BaseEntity
    {
        public string Name { get; set; }
        public string OrgNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Unknown { get; set; }
    }
}
