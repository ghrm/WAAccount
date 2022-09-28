using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WAAccount.Models1;

namespace WAAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("XLS");
                var pathSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    readXLS(fullPath);
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal Server Error: {ex}");
                //throw;
            }
        }
        private void readXLS(string FilePath)
        {
            try
            {
                FileInfo existingFile = new FileInfo(FilePath);
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets[0];
                    int colCount = ws.Dimension.End.Column;
                    int rowCount = ws.Dimension.End.Row;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (ws.Cells[row, 2].Value == null)
                            continue;
                        string mAcc = ws.Cells[row, 2].Value.ToString().Trim();
                        AccountT account = new AccountT();
                        account.Account = ws.Cells[row, 2].Value.ToString().Trim();
                        account.AcctType = ws.Cells[row, 1].Value.ToString().Trim();
                        account.CreditOffset = ws.Cells[row, 7].Value == null ? "" : ws.Cells[row, 7].Value.ToString().Trim();
                        account.DebitOffset = ws.Cells[row, 6].Value == null ? "" : ws.Cells[row, 7].Value.ToString().Trim();
                        account.Deparment = ws.Cells[row, 4].Value == null ? "" : ws.Cells[row, 4].Value.ToString().Trim();
                        account.Description = ws.Cells[row, 3].Value.ToString().Trim();
                        account.Sts = true;
                        demoContext _context = new demoContext();
                        _context.Accounts.Add(account);
                        try
                        {
                            _context.SaveChangesAsync();
                        }
                        catch (DbUpdateException)
                        {
                        }
                        Console.WriteLine(mAcc);
                    }
                }
            }
            catch (Exception e)
            {
                int x = 0;
            }
        }

    }
}
