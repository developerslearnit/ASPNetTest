using ExcelReader.Web.Models.Entities;
using System.Data;

namespace ExcelReader.Web.Repository
{
    public interface IRepository
    {
        Task<bool> ReadExcelFile(FileInfo fileStream);

        IQueryable<Person> GetAllPersons();
        IQueryable<Book> GetAllBooks();
        IQueryable<School> GetAllSchools();
    }
}
