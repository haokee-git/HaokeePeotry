using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.IO;

namespace HaokeePeotry
{
    public partial class EditPoetryWindow : Window
    {
        public event EventHandler PoetryEdited;

        private string _fileName;

        public EditPoetryWindow(string fileName, string title, string author, string content)
        {
            InitializeComponent();
            _fileName = fileName;
            TitleTextBox.Text = title;
            AuthorTextBox.Text = author;
            ContentTextBox.Text = content;
            this.AppWindow.Resize(new Windows.Graphics.SizeInt32(300, 500));
            this.AppWindow.SetIcon(System.Environment.CurrentDirectory + "\\icon.ico");
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) || string.IsNullOrWhiteSpace(AuthorTextBox.Text) || string.IsNullOrWhiteSpace(ContentTextBox.Text))
            {
                var dialog = new ContentDialog
                {
                    Title = "错误",
                    Content = "所有字段不能为空",
                    CloseButtonText = "确定",
                    XamlRoot = this.Content.XamlRoot
                };
                await dialog.ShowAsync();
                return;
            }

            string filePath = Path.Combine(Environment.CurrentDirectory, "AppData", _fileName);
            File.WriteAllLines(filePath, new[] { TitleTextBox.Text, AuthorTextBox.Text, ContentTextBox.Text });

            PoetryEdited?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}

