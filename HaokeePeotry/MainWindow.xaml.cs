using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.IO;
using System.Linq;

namespace HaokeePeotry
{
    public partial class MainWindow : Window
    {
        private NewPoetryWindow _newPoetryWindow;
        private bool _isNewPoetryWindowOpen = false;
        private EditPoetryWindow _editPoetryWindow;
        private bool _isEditPoetryWindowOpen = false;

        public MainWindow()
        {
            InitializeComponent();
            LoadFileList();
            this.AppWindow.SetIcon(System.Environment.CurrentDirectory + "\\icon.ico");
            this.AppWindow.Resize(new Windows.Graphics.SizeInt32(1250, 700));
        }

        private void LoadFileList()
        {
            FileListView.Items.Clear();
            string appDataPath = Path.Combine(Environment.CurrentDirectory, "AppData");
            if (Directory.Exists(appDataPath))
            {
                var files = Directory.GetFiles(appDataPath).Select(Path.GetFileName).ToList();
                if (files.Any())
                {
                    foreach (var file in files)
                    {
                        FileListView.Items.Add(file);
                    }
                    // Ĭ��ѡ���һ���ļ�
                    FileListView.SelectedIndex = 0;
                }
                else
                {
                    FileListView.Items.Add("δ�ҵ��ļ�");
                }
            }
            else
            {
                Directory.CreateDirectory(appDataPath);
                FileListView.Items.Add("δ�ҵ��ļ�");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFileList();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNewPoetryWindowOpen)
            {
                _newPoetryWindow = new NewPoetryWindow();
                _newPoetryWindow.PoetryCreated += NewPoetryWindow_PoetryCreated;
                _newPoetryWindow.Closed += NewPoetryWindow_Closed;
                _newPoetryWindow.Activate();
                _isNewPoetryWindowOpen = true;
            }
        }

        private void NewPoetryWindow_PoetryCreated(object sender, EventArgs e)
        {
            LoadFileList();
        }

        private void NewPoetryWindow_Closed(object sender, WindowEventArgs e)
        {
            _isNewPoetryWindowOpen = false;
        }

        private void FileListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FileListView.SelectedItem != null)
            {
                string selectedFile = FileListView.SelectedItem.ToString();
                string filePath = Path.Combine(Environment.CurrentDirectory, "AppData", selectedFile);
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    if (lines.Length >= 2)
                    {
                        TitleTextBox.Text = lines[0].Trim();
                        AuthorTextBox.Text = lines[1].Trim();
                        FileContentTextBox.Text = string.Join(Environment.NewLine, lines.Skip(2).Select(line => line.Trim()));
                    }
                    else
                    {
                        TitleTextBox.Text = "�ޱ���";
                        AuthorTextBox.Text = "������";
                        FileContentTextBox.Text = "���ݲ���";
                    }
                }
                else
                {
                    TitleTextBox.Text = "�ļ�������";
                    AuthorTextBox.Text = "�ļ�������";
                    FileContentTextBox.Text = "�ļ�������";
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isEditPoetryWindowOpen && FileListView.SelectedItem != null)
            {
                string selectedFile = FileListView.SelectedItem.ToString();
                string filePath = Path.Combine(Environment.CurrentDirectory, "AppData", selectedFile);
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    if (lines.Length >= 2)
                    {
                        _editPoetryWindow = new EditPoetryWindow(selectedFile, lines[0].Trim(), lines[1].Trim(), string.Join(Environment.NewLine, lines.Skip(2).Select(line => line.Trim())));
                        _editPoetryWindow.PoetryEdited += EditPoetryWindow_PoetryEdited;
                        _editPoetryWindow.Closed += EditPoetryWindow_Closed;
                        _editPoetryWindow.Activate();
                        _isEditPoetryWindowOpen = true;
                    }
                }
            }
        }

        private void EditPoetryWindow_PoetryEdited(object sender, EventArgs e)
        {
            if (FileListView.SelectedItem != null)
            {
                string selectedFile = FileListView.SelectedItem.ToString();
                string filePath = Path.Combine(Environment.CurrentDirectory, "AppData", selectedFile);
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    if (lines.Length >= 2)
                    {
                        TitleTextBox.Text = lines[0].Trim();
                        AuthorTextBox.Text = lines[1].Trim();
                        FileContentTextBox.Text = string.Join(Environment.NewLine, lines.Skip(2).Select(line => line.Trim()));
                    }
                }
            }
        }

        private void EditPoetryWindow_Closed(object sender, WindowEventArgs e)
        {
            _isEditPoetryWindowOpen = false;
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileListView.SelectedItem != null)
            {
                string selectedFile = FileListView.SelectedItem.ToString();
                ContentDialog deleteDialog = new ContentDialog
                {
                    Title = "ȷ��ɾ��",
                    Content = $"ȷ��Ҫɾ��ʫ�� '{selectedFile}' ��",
                    PrimaryButtonText = "ɾ��",
                    CloseButtonText = "ȡ��",
                    XamlRoot = this.Content.XamlRoot
                };

                var result = await deleteDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    string filePath = Path.Combine(Environment.CurrentDirectory, "AppData", selectedFile);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        LoadFileList();
                        TitleTextBox.Text = string.Empty;
                        AuthorTextBox.Text = string.Empty;
                        FileContentTextBox.Text = string.Empty;
                    }
                }
            }
        }
    }
}
