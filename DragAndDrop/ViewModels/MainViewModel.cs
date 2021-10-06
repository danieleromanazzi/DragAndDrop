using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DragAndDrop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            DropCommand = new DelegateCommand((o) =>
            {
                if (o is IDataObject e)
                {
                    string[] droppedFiles = null;
                    if (e.GetDataPresent(DataFormats.FileDrop))
                    {
                        droppedFiles = (string[])e.GetData(DataFormats.FileDrop, true);

                        foreach (string s in droppedFiles)
                        {
                            MessageBox.Show($"{s}");
                            LoadImage(s);
                        }
                    }
                }
            });
        }

        public ICommand DropCommand { get; set; }

        public ImageSource Image
        {
            get { return GetValue<ImageSource>(); }
            set { SetValue(value); }
        }

        private void LoadImage(string filename)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filename);
            bitmap.EndInit();
            Image = bitmap;
        }
    }
}
