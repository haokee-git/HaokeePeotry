using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.IO;

namespace HaokeePeotry
{
    public partial class NewPoetryWindow : Window
    {
        public event EventHandler PoetryCreated;

        public NewPoetryWindow()
        {
            InitializeComponent();
            TitleTextBox.TextChanged += TitleTextBox_TextChanged;
            FileNameTextBox.TextChanged += FileNameTextBox_TextChanged;
            this.AppWindow.SetIcon(System.Environment.CurrentDirectory + "\\icon.ico");
            this.AppWindow.Resize(new Windows.Graphics.SizeInt32(300, 670));
        }

        private void FileNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 当文件名改变时，同时改变诗题
            if (!TitleTextBox.Equals(FocusManager.GetFocusedElement()))
            {
                TitleTextBox.Text = FileNameTextBox.Text.Trim();
            }
        }

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 当诗题改变时，不改变文件名
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FileNameTextBox.Text.Trim();
            string title = TitleTextBox.Text.Trim();
            string author = AuthorTextBox.Text.Trim();
            string content = ContentTextBox.Text.Trim();

            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(content))
            {
                await ShowErrorDialog("所有字段都是必填的。");
                return;
            }

            string appDataPath = Path.Combine(Environment.CurrentDirectory, "AppData");
            string filePath = Path.Combine(appDataPath, fileName);

            if (File.Exists(filePath))
            {
                await ShowErrorDialog("文件名已存在，请选择其他文件名。");
                return;
            }

            try
            {
                File.WriteAllText(filePath, $"{title}\n{author}\n{content}");
                PoetryCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                await ShowErrorDialog($"创建文件时出错：{ex.Message}");
            }
        }

        private async System.Threading.Tasks.Task ShowErrorDialog(string message)
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "错误",
                Content = message,
                CloseButtonText = "确定",
                XamlRoot = this.Content.XamlRoot
            };

            await errorDialog.ShowAsync();
        }
    }
}
