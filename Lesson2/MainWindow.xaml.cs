using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace Lesson2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _openedFile = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Plane Text (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                tbxText.Text = File.ReadAllText(ofd.FileName);
                _openedFile = ofd.FileName;
                tbxStatus.Text = $"Открыт файл: {ofd.FileName}";
            }
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            var sfd=new SaveFileDialog();
            sfd.Filter = "Plane Text (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, tbxText.Text);
                _openedFile=sfd.FileName;
                tbxStatus.Text = $"Файл сохранен как: {sfd.FileName}";
            }
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result=MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }        

        private void tbxText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            tbxStatus.Text = $"Открыт файл: {_openedFile}. Изменения не сохранены!";
        }
    }
}