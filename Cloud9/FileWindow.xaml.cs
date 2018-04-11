using ClassLibr;
using ClassLibr.Service;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Cloud9
{
    /// <summary>
    /// Логика взаимодействия для FileWindow.xaml
    /// </summary>
    public partial class FileWindow : Window
    {
        Window window;
        User user;
        public FileWindow(MainWindow window, User user)
        {
            this.window = window;
            this.user = user;
            InitializeComponent();
        }

        //загрузка файла
        private void UploadFileButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.ShowDialog();
            string filePath = dialog.FileName;

            byte[] data;
            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, FileMode.Open))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }

            DocumentService ds = new DocumentService();
            Document doc = new Document();
            doc.UserId = user.Id;
            doc.Name = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            doc.Content = data;
            ds.Create(doc);
        }



        //Из-за отсутствия визуализации просто оставил реализованные методы

        //открытие файла
        private void OpenButtonClick(int id)
        {
            DocumentService ds = new DocumentService();
            Document doc = ds.Select(id);
            MessageBox.Show(doc.Name);
        }

        //удаление файла
        private void DeleteButtonClick(int id)
        {
            DocumentService ds = new DocumentService();
            ds.Delete(id);
        }
    }
}
