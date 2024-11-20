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
            // ���ļ����ı�ʱ��ͬʱ�ı�ʫ��
            if (!TitleTextBox.Equals(FocusManager.GetFocusedElement()))
            {
                TitleTextBox.Text = FileNameTextBox.Text.Trim();
            }
        }

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ��ʫ��ı�ʱ�����ı��ļ���
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FileNameTextBox.Text.Trim();
            string title = TitleTextBox.Text.Trim();
            string author = AuthorTextBox.Text.Trim();
            string content = ContentTextBox.Text.Trim();

            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(content))
            {
                await ShowErrorDialog("�����ֶζ��Ǳ���ġ�");
                return;
            }

            string appDataPath = Path.Combine(Environment.CurrentDirectory, "AppData");
            string filePath = Path.Combine(appDataPath, fileName);

            if (File.Exists(filePath))
            {
                await ShowErrorDialog("�ļ����Ѵ��ڣ���ѡ�������ļ�����");
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
                await ShowErrorDialog($"�����ļ�ʱ����{ex.Message}");
            }
        }

        private async System.Threading.Tasks.Task ShowErrorDialog(string message)
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "����",
                Content = message,
                CloseButtonText = "ȷ��",
                XamlRoot = this.Content.XamlRoot
            };

            await errorDialog.ShowAsync();
        }
    }
}
