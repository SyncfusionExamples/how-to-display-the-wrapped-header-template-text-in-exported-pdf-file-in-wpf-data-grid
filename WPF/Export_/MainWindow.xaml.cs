using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Export_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            PdfExportingOptions options = new PdfExportingOptions();
            options.PageHeaderFooterEventHandler = PdfHeaderFooterEventHandler;
            var document = dataGrid.ExportToPdf(options);
            document.Save("Sample3.pdf");
        }        
        static void PdfHeaderFooterEventHandler(object sender, PdfHeaderFooterEventArgs e)
        {
            var document = new PdfDocument();
            var page = document.Pages.Add();
            PdfPageTemplateElement header = new PdfPageTemplateElement(page.Graphics.ClientSize.Width, 38);
            var _headerFont = new PdfTrueTypeFont(new Font("Microsoft Sans Serif", 10f), true);
            var _blackBrush = new PdfSolidBrush(System.Drawing.Color.Black);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.WordWrap = PdfWordWrapType.Word;
            string title = "This text is too long and doesn't match in one line of the page XXX-3 111111111 22222 33333 44444 55555 66666 77777 88888 99999 000000";
            //Draw title
            header.Graphics.DrawString(title, _headerFont, _blackBrush, new RectangleF(0, 0, header.Width, header.Height), format);           
            e.PdfDocumentTemplate.Top = header;
        }
    }
}
