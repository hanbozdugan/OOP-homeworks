using System;
using System.Drawing;
using System.Linq;
using Novacode;

// Please add the image file to the "data folder". The archive was > 2MB so I had to remove it.
namespace WordDocumentGeneratorApp
{
    public class SoftUniSandbox
    {
        public static void CreateDocument()
        {
            string headerText = "SoftUni OOP Game Contest";
            string contentText = "SoftUni is organizing a contest for the best role playing game from the OOP teamwork projects." +
                                 " The winning teams will receive a grand prize!" +
                    " The game should be:";
            string[] bullets =
            {
                "Properly structured and follow all good OOP practices",
                "Awesome",
                "..Very Awesome"
            };

            string[] tableHeaders =
            {
                "Team", "Game", "Points"
            };

            string preFooter = "The top 3 teams will receive a SPECTACULAR prize:";
            string footer = "A HANDSHAKE FROM NAKOV";

            // Creating a Document
            var doc = DocX.Create("../../MyDoc.docx");

            //Some formatting...
            var titleFormat = new Formatting();
            titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            titleFormat.Size = 24D;
            titleFormat.Position = 22;

            var contentFormat = new Formatting();
            contentFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            contentFormat.Size = 8D;
            contentFormat.Position = 12;

            var bulletedList = doc.AddList(bullets[0], 0, ListItemType.Bulleted);

            doc.AddListItem(bulletedList, bullets[1]);
            doc.AddListItem(bulletedList, bullets[2]);

            // HEADER
            Paragraph title = doc.InsertParagraph(headerText, false, titleFormat);
            title.Alignment = Alignment.center;

            // Add an Image to the docx file
            Novacode.Image img = doc.AddImage(@"../../data/rpg-game.png");

            // Insert an emptyParagraph into this document.
            Paragraph p = doc.InsertParagraph("", false);

            Picture pic = img.CreatePicture();

            pic.Height = 250;
            pic.Width = 500;

            // PICTURE
            p.AppendPicture(pic);

            p.InsertParagraphAfterSelf("", false);
            p.Alignment = Alignment.center;
            p.Position(0);

            doc.InsertParagraph(Environment.NewLine);

            // CONTENT
            Paragraph letterBody = doc.InsertParagraph(contentText, false, contentFormat);
            letterBody.Alignment = Alignment.both;

            doc.InsertParagraph("", false);

            // BULLETED LIST
            doc.InsertList(bulletedList);

            doc.InsertParagraph(Environment.NewLine);

            Table t = doc.AddTable(4, 3);

            for (int i = 0; i < t.ColumnCount; i++)
            {
                t.Rows[0].Cells[i].Paragraphs.First().Append(tableHeaders[i])
                .Color(Color.Blue).Bold().Alignment = Alignment.center;
            }

            for (int i = 1; i < t.RowCount; i++)
            {
                for (int j = 0; j < t.ColumnCount; j++)
                {
                    t.Rows[i].Cells[j].Paragraphs.First().Append("-").Alignment = Alignment.center;
                }
            }

            t.Alignment = Alignment.center;
            t.Design = TableDesign.LightShadingAccent1;

            // TABLE
            doc.InsertTable(t);

            doc.InsertParagraph(Environment.NewLine);

            // FOOTER INFO
            Paragraph footer1 = doc.InsertParagraph(preFooter, false);

            footer1.InsertParagraphAfterSelf(footer)
                .Bold()
                .FontSize(24)
                .UnderlineStyle(UnderlineStyle.singleLine)
                .Color(Color.Aqua)
                .Alignment = Alignment.center;
            footer1.Alignment = Alignment.center;

            doc.SaveAs("../../MyDoc.docx");
        }
    }

    public class TestWordGenerator
    {
        public static void Main()
        {
            SoftUniSandbox.CreateDocument();
        }
    }
}