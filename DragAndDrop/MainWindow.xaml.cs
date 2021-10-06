using System.Windows;

namespace DragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //RtbInputFile.PreviewDragOver += RtbInputFile_PreviewDragOver;

        }

        private void RtbInputFile_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                //HandleFileOpen(files[0]);
            }
        }

        private void Border_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.GetData("").ToString());
        }

        private void StackPanel_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
