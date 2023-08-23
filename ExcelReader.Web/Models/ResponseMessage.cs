namespace ExcelReader.Web.Models
{
    public class ResponseMessage
    {
        public string message { get; set; } = string.Empty;

        public bool hasError { get; set; } = false;

        public object data { get; set; }
    }
}
