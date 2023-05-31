using PSPDFKit.Document;
using PSPDFKit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using PSPDFKit.Document;
using PSPDFKit.Pdf;
using PSPDFKit.UI;

using PSPDFKit.UI.ToolbarComponents;
using PSPDFKit.Pdf.Annotation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KeepSelectedToolTempFix
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void PdfView_InitializationCompletedHandlerAsync(PdfView sender, Document args)
        {
            Button_OpenPDF.IsEnabled = true;

            await sender.Controller.SetViewStateAsync(new ViewState { AppearanceStreamTypes = new[] { AnnotationType.Note } });
            await sender.Controller.SetKeepSelectedToolAsync(true);
        }

        private async void Button_OpenPDF_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".pdf");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                var document = DocumentSource.CreateFromStorageFile(file);
                await PdfView.Controller.ShowDocumentAsync(document);
            }
        }
    }
}
