﻿
using ExcelReader.Web.Data;
using ExcelReader.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace ExcelReader.Web.Repository;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Book> GetAllBooks()
    {
        return _context.Books.AsNoTracking();
    }

    public IQueryable<Employee> GetAllEmployees()
    {
        return _context.Employees.AsNoTracking();
    }

    public IQueryable<Organisation> GetAllOrganisations()
    {
       return _context.Organisations.AsNoTracking();
    }

    public IQueryable<Person> GetAllPersons()
    {
        return _context.People.AsNoTracking();
    }

    public IQueryable<School> GetAllSchools()
    {
        return _context.Schools.AsNoTracking();
    }

    public async Task<bool> ReadExcelFile(FileInfo fileStream)
    {
        var result = false;

        try
        {
            var sheetName = string.Empty;
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(fileStream, true))
            {
                foreach (var worksheet in fastExcel.Worksheets)
                {

                    worksheet.Read();
                    sheetName = worksheet.Name;
                    var rows = worksheet.Rows.ToArray();
                    //Do something with rows

                    if (sheetName.ToLower() == "sheet1")
                    {
                        var dt = new DataTable();
                        var rowNum = 1;
                        foreach (var row in rows)
                        {
                            if (rowNum == 1)
                            {
                                foreach (var cell in row.Cells)
                                {
                                    var columnName = cell.Value.ToString();
                                    dt.Columns.Add(columnName);
                                }
                                rowNum++;
                            }
                            else
                            {

                                int i = 0;
                                DataRow dr = dt.NewRow();
                                foreach (var cell in row.Cells)
                                {
                                    dr[i++] = cell.Value;
                                    //dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                dt.Rows.Add(dr);
                            }

                        }

                        var sheetOneSb = new StringBuilder();
                        foreach (DataRow row in dt.Rows)
                        {
                            sheetOneSb.Append($"INSERT INTO People (FirstName,LastName,MiddleName)values('{row[0].ToString()}'," +
                                $"'{row[1].ToString()}','{row[2].ToString()}')");
                        }
                        await _context.Database.ExecuteSqlRawAsync(sheetOneSb.ToString());
                    }
                    else if (sheetName.ToLower() == "sheet2")
                    {
                        var dt1 = new DataTable();
                        var rowNum1 = 1;
                        foreach (var row in rows)
                        {
                            if (rowNum1 == 1)
                            {
                                foreach (var cell in row.Cells)
                                {
                                    var columnName = cell.Value.ToString();
                                    dt1.Columns.Add(columnName);
                                }
                                rowNum1++;
                            }
                            else
                            {

                                int j = 0;
                                DataRow dr1 = dt1.NewRow();
                                foreach (var cell in row.Cells)
                                {
                                    dr1[j++] = cell.Value;
                                    //dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                dt1.Rows.Add(dr1);
                            }

                        }

                        var sb1 = new StringBuilder();
                        foreach (DataRow row in dt1.Rows)
                        {
                            sb1.Append($"INSERT INTO Schools (SchoolClass,Name,Description)values('{row[0].ToString()}'," +
                                $"'{row[1].ToString()}','{row[2].ToString()}')");
                        }
                        await _context.Database.ExecuteSqlRawAsync(sb1.ToString());
                    }
                    else if (sheetName.ToLower() == "sheet3")
                    {
                        var dt2 = new DataTable();
                        var rowNum2 = 1;
                        foreach (var row in rows)
                        {
                            if (rowNum2 == 1)
                            {
                                foreach (var cell in row.Cells)
                                {
                                    var columnName = cell.Value.ToString();
                                    dt2.Columns.Add(columnName);
                                }
                                rowNum2++;
                            }
                            else
                            {

                                int k = 0;
                                DataRow dr2 = dt2.NewRow();
                                foreach (var cell in row.Cells)
                                {
                                    dr2[k++] = cell.Value;
                                    //dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                dt2.Rows.Add(dr2);
                            }

                        }

                        var sb2 = new StringBuilder();
                        foreach (DataRow row in dt2.Rows)
                        {
                            sb2.Append($"INSERT INTO Books (CategoryId,Name,Description)values('{int.Parse(row[0].ToString())}'," +
                               $"'{row[1].ToString()}','{row[2].ToString()}')");
                        }
                        await _context.Database.ExecuteSqlRawAsync(sb2.ToString());
                    }
                    else if (sheetName.ToLower() == "employee")
                    {
                        var empDt = new DataTable();
                        var empRowNum = 1;
                        foreach (var row in rows)
                        {
                            if (empRowNum == 1)
                            {
                                foreach (var cell in row.Cells)
                                {
                                    var columnName = cell.Value.ToString();
                                    empDt.Columns.Add(columnName);
                                }
                                empRowNum++;
                            }
                            else
                            {

                                int l = 0;
                                DataRow dr = empDt.NewRow();
                                foreach (var cell in row.Cells)
                                {
                                    dr[l++] = cell.Value;
                                    //dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                empDt.Rows.Add(dr);
                            }

                        }

                        var query = new StringBuilder();
                        foreach (DataRow row in empDt.Rows)
                        {
                            query.Append($"INSERT INTO Employees (OrgNumber,FirstName,LastName)values('{row[0].ToString()}'," +
                               $"'{row[1].ToString()}','{row[2].ToString()}')");
                        }
                        await _context.Database.ExecuteSqlRawAsync(query.ToString());
                    }
                    else if (sheetName.ToLower() == "organisation")
                    {
                        var orgDt = new DataTable();
                        var orgRowNum = 1;
                        foreach (var row in rows)
                        {
                            if (orgRowNum == 1)
                            {
                                foreach (var cell in row.Cells)
                                {
                                    var columnName = cell.Value.ToString();
                                    orgDt.Columns.Add(columnName);
                                }
                                orgRowNum++;
                            }
                            else
                            {

                                int m = 0;
                                DataRow dr = orgDt.NewRow();
                                foreach (var cell in row.Cells)
                                {
                                    dr[m++] = cell.Value;
                                    //dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                orgDt.Rows.Add(dr);
                            }

                        }

                        var query = new StringBuilder();
                        foreach (DataRow row in orgDt.Rows)
                        {
                            query.Append($"INSERT INTO Organisations (Name,OrgNumber,Address1,Address2,Address3,Address4,Town,PostCode,Unknown)values('{row[0].ToString()}'," +
                               $"'{row[1].ToString()}','{row[2].ToString()}','{row[3].ToString()}'" +
                               $",'{row[4].ToString()}','{row[5].ToString()}'," +
                               $"'{row[6].ToString()}','{row[7].ToString()}','-')");
                        }
                        await _context.Database.ExecuteSqlRawAsync(query.ToString());
                    }

                }
            }
            result = true;
        }
        catch (Exception e)
        {
            throw;
        }

        return result;
    }
}
