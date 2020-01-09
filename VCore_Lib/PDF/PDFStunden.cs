using iTextSharp.text;
using iTextSharp.text.pdf;
using VCore_Lib.Model;
using System;
using System.Diagnostics;
using System.IO;

namespace VCore_Lib.PDF
{
    public class PDFStunden
    {
        private readonly string _UserPass;
        private readonly string _OwnerPass;
        private readonly string _FileName;
        private readonly string _FinalName;
        private readonly string _FilePath;
        private readonly string _FinalPath;

        public PDFStunden(string UserPass = "1234", string OwnerPass = "Test", string FinalName = "Test")
        {
            _UserPass = UserPass;
            _OwnerPass = OwnerPass;
            _FileName = "tmp.pdf";
            _FinalName = $@"{FinalName}.pdf";
            _FilePath = $@"{Directory.GetCurrentDirectory()}\{_FileName}";
            _FinalPath = $@"{Directory.GetCurrentDirectory()}\{_FinalName}";
            if (File.Exists(_FilePath))
                File.Delete(_FilePath);
            if (File.Exists(_FinalPath))
                File.Delete(_FinalPath);
        }

        public void CreateTableStundenNachweiß(ref SortableBindingList<MStunden> value, string Owner = "Test")
        {
            Document document = new Document(PageSize.A4.Rotate());
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(_FilePath, FileMode.Create));
                PdfPTable table = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };
                float[] widths = new float[] { 6f, 6f, 2f, 3f };
                table.SetWidths(widths);
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;
                PdfPCell cell = new PdfPCell(new Phrase($@"Stunden Nachweiß von {Owner.Split(".")[0]}"))
                {
                    Colspan = 4,
                    HorizontalAlignment = 1
                };
                table.AddCell(cell);
                table.AddCell("Start");
                table.AddCell("Ende");
                table.AddCell("Pause");
                table.AddCell("Arbeitszeit");
                foreach (MStunden std in value)
                {
                    table.AddCell(std.Start);
                    table.AddCell(std.Ende);
                    table.AddCell(std.Pause);
                    table.AddCell(std.Arbeitszeit);
                }
                document.Open();
                Paragraph top = new Paragraph
                {
                    Alignment = 2
                };
                top.Add($@"{DateTime.Now.ToLongDateString()}");
                document.Add(top);
                document.Add(table);
                Paragraph bottom = new Paragraph
                {
                    Alignment = 2
                };
                bottom.Add(new Chunk($@"Gesamt Stunden : {AllTime(ref value)}"));
                document.Add(bottom);
            }
            catch
            {

            }
            finally
            {
                if (document != null)
                {
                    document.Close();
                }
            }
            PdfReader reader = new PdfReader(_FilePath);
            PdfEncryptor.Encrypt(reader, new FileStream(_FinalPath, FileMode.Append), PdfWriter.STRENGTH128BITS, _UserPass, _OwnerPass, PdfWriter.AllowPrinting);
            reader.Close();
            if (File.Exists(_FilePath))
                File.Delete(_FilePath);
            Process.Start("cmd", $"/c start {_FinalPath}");
        }

        private string AllTime(ref SortableBindingList<MStunden> Value)
        {
            double result = 0.0f;
            foreach (MStunden std in Value)
            {
                string value = std.Arbeitszeit;
                value = value.Replace(",", ".");
                try
                {
                    result += double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    result += 0.0;
                }
            }
            return result.ToString("0.00");
        }
    }
}
