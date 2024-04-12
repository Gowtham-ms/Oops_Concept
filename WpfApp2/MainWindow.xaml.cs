using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
namespace WpfApp2
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<string> searchResults = new List<string>();
        private int itemsPerPage = 1;
        private int currentPage = 1;
        private List<int> _paginationButtons = new List<int>();
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Button> paginationButtons = new List<Button>();

        public List<int> PaginationButtons
        {
            get { return _paginationButtons; }
            set
            {
                _paginationButtons = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public MainWindow()
        {

            InitializeComponent();
            DataContext = this;
            Previous.Visibility = Visibility.Collapsed;
            Next.Visibility = Visibility.Collapsed;
            FirstPage.Visibility = Visibility.Collapsed;
            LastPage.Visibility = Visibility.Collapsed;
            Download.Visibility = Visibility.Collapsed;
            DownloadAll.Visibility = Visibility.Collapsed;
            Print.Visibility = Visibility.Collapsed;
            ZoomInButton.Visibility = Visibility.Collapsed;
            ZoomOutButton.Visibility = Visibility.Collapsed;
            Reset.Visibility = Visibility.Collapsed;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                System.Windows.MessageBox.Show("Enter any claim number to search");

            }
            else
            {
                searchResults.Clear();
                string SearchClaims = txtSearch.Text;
                string documentsPath = @"C:\Users\msgow\Downloads\NewFolder";
                string[] txtFiles = Directory.GetFiles(documentsPath, "*.txt");
                string pattern = @"\|(\d{10,})\|";

                foreach (string txtFile in txtFiles)
                {
                    string[] lines = System.IO.File.ReadAllLines(txtFile);
                    bool found = false;
                    foreach (string line in lines)
                    {
                        if (line.Contains(SearchClaims))
                        {
                            found = true;
                            searchResults.Add(documentsPath + "\\" + line.Split('|').FirstOrDefault());
                        }
                        else if (found)
                        {
                            if (Regex.IsMatch(line, pattern))
                            {
                                break;
                            }
                            else
                            {
                                searchResults.Add(documentsPath + "\\" + line.Split('|').FirstOrDefault());
                            }
                        }
                    }
                }

                if (searchResults.Count > 0)
                {
                    currentPage = 1;
                    paginationStackPanel.Visibility = Visibility.Visible;
                    int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
                    GeneratePaginationButtons(currentPage, totalPages, 1);
                    ShowImage();
                    Previous.Visibility = Visibility.Visible;
                    Next.Visibility = Visibility.Visible;
                    FirstPage.Visibility = Visibility.Visible;
                    LastPage.Visibility = Visibility.Visible;
                    Download.Visibility = Visibility.Visible;
                    DownloadAll.Visibility = Visibility.Visible;
                    Print.Visibility = Visibility.Visible;
                    ZoomInButton.Visibility = Visibility.Visible;
                    ZoomOutButton.Visibility = Visibility.Visible;
                    Reset.Visibility = Visibility.Visible;
                    EnablePrevNext();
                }
            }
        }
        private void EnablePrevNext()
        {
            if (currentPage == 1)
                Previous.IsEnabled = false;
            else
                Previous.IsEnabled = true;
            if (currentPage == searchResults.Count)
                Next.IsEnabled = false;
            else
                Next.IsEnabled = true;
        }

        private void PaginationButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int clickedPage = Convert.ToInt32(clickedButton.Content);
            int clickedPageNumber = clickedPage;

            foreach (var child in paginationStackPanel.Children)
            {
                if (child is Button paginationButton)
                {
                    paginationButton.Background = Brushes.White;
                }
            }
            int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
            if (totalPages < 3)
            {
                GeneratePaginationButtons(1, totalPages, clickedPage);
            }
            else
            {
                int startPage = Math.Max(clickedPageNumber - 1, 1);
                int endPage = Math.Min(clickedPageNumber + 1, totalPages);
                if (clickedPageNumber == 1)
                {
                    endPage = Math.Min(totalPages, 3);
                }
                else if (clickedPageNumber == totalPages)
                {
                    startPage = Math.Max(1, totalPages - 2);
                }
                GeneratePaginationButtons(startPage, endPage, clickedPage);
            }
            currentPage = clickedPage;
            ShowImage();
            EnablePrevNext();
        }

        private void GeneratePaginationButtons(int startPage, int endPage, int clickedPage)
        {
            ClearPaginationButtons();
            if (endPage < 3)
            {
                for (int i = startPage; i <= endPage; i++)
                {
                    bool isClicked = (i == clickedPage);
                    Button button = CreatePaginationButton(i, isClicked);
                    paginationButtons.Add(button);
                    paginationStackPanel.Children.Insert(paginationStackPanel.Children.Count - 2, button);
                }
            }
            else
            {
                endPage = Math.Min(startPage + 2, endPage);
                for (int i = startPage; i <= endPage; i++)
                {
                    bool isClicked = (i == clickedPage);
                    Button button = CreatePaginationButton(i, isClicked);
                    paginationButtons.Add(button);
                    paginationStackPanel.Children.Insert(paginationStackPanel.Children.Count - 2, button);
                }
            }
        }
        private void ClearPaginationButtons()
        {
            foreach (var button in paginationButtons)
            {
                paginationStackPanel.Children.Remove(button);
            }
            paginationButtons.Clear();
        }
        private Button CreatePaginationButton(int pageNumber, bool isClicked)
        {
            Button button = new Button();
            button.Content = pageNumber.ToString();
            button.Margin = new Thickness(5);
            button.Click += PaginationButton_Click;
            if (isClicked)
            {
                button.Background = Brushes.Red;
            }
            else
            {
                button.Background = Brushes.White;
            }
            return button;
        }

        private void UpdatePaginationButtons()
        {
            int clickedPage = currentPage;
            int clickedPageNumber = clickedPage;
            int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
            if (totalPages < 3)
            {
                GeneratePaginationButtons(1, totalPages, clickedPage);
            }
            else
            {
                int startPage = Math.Max(clickedPageNumber - 1, 1);
                int endPage = Math.Min(clickedPageNumber + 1, totalPages);
                if (clickedPageNumber == 1)
                {
                    endPage = Math.Min(totalPages, 3);
                }
                else if (clickedPageNumber == totalPages)
                {
                    startPage = Math.Max(1, totalPages - 2);
                }
                GeneratePaginationButtons(startPage, endPage, clickedPage);

            }
            EnablePrevNext();
        }

        private void ShowImage()
        {
            if (searchResults != null && searchResults.Count != 0)
            {
                int startIndex = (currentPage - 1) * itemsPerPage;
                int endIndex = Math.Min(startIndex + itemsPerPage, searchResults.Count);
                if (startIndex >= 0 && endIndex > 0)
                {
                    claimsImg.Source = new BitmapImage(new Uri(searchResults[startIndex], UriKind.RelativeOrAbsolute));
                }
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowImage();
                UpdatePaginationButtons();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage < Math.Ceiling((double)searchResults.Count / itemsPerPage))
            {
                currentPage++;
                ShowImage();
                UpdatePaginationButtons();
            }
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new ImageRangeInputDialog();
            if (inputDialog.ShowDialog() == true)
            {
                int startNumber = inputDialog.StartNumber;
                int endNumber = inputDialog.EndNumber;
                DownloadImagesInRange(startNumber, endNumber);
            }
        }
        private void DownloadAll_Click(object sender, RoutedEventArgs e)
        {
            DownloadImagesInRange(1, searchResults.Count);
        }

        private void DownloadImagesInRange(int startNumber, int endNumber)
        {
            try
            {
                string downloadFolder = GetDownloadFolder();
                if (downloadFolder != null)
                {
                    for (int i = startNumber; i <= endNumber && i <= searchResults.Count; i++)
                    {
                        string imagePath = searchResults[i - 1];
                        string downloadPath = System.IO.Path.Combine(downloadFolder, System.IO.Path.GetFileName(imagePath));
                        File.Copy(imagePath, downloadPath, true);
                    }
                    MessageBox.Show("Images downloaded successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to download images: " + ex.Message);
            }
        }
        public string GetDownloadFolder()
        {
            Microsoft.Win32.OpenFolderDialog dialog = new();
            string? downloadFolder;
            if (dialog.ShowDialog() == true)
            {
                downloadFolder = dialog.FolderName;
            }
            else
            {
                MessageBox.Show("Folder selection cancelled.");
                downloadFolder = null;
            }
            return downloadFolder;
        }



        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (searchResults != null && searchResults.Count > 0)
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == true)
                    pd.PrintVisual(claimsImg, "Print Image");
            }
        }
        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            if (claimsImg.Width < 1000)
            {
                double zoomFactor = 1.2;
                claimsImg.Width *= zoomFactor;
                claimsImg.Height *= zoomFactor;
            }
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            double zoomFactor = 1.2;
            claimsImg.Width /= zoomFactor;
            claimsImg.Height /= zoomFactor;
        }
        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            ShowImage();
            UpdatePaginationButtons();
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
            currentPage = totalPages;
            ShowImage();
            UpdatePaginationButtons();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
            Previous.Visibility = Visibility.Collapsed;
            Next.Visibility = Visibility.Collapsed;
            FirstPage.Visibility = Visibility.Collapsed;
            LastPage.Visibility = Visibility.Collapsed;
            Download.Visibility = Visibility.Collapsed;
            DownloadAll.Visibility = Visibility.Collapsed;
            Print.Visibility = Visibility.Collapsed;
            ZoomInButton.Visibility = Visibility.Collapsed;
            ZoomOutButton.Visibility = Visibility.Collapsed;
            Reset.Visibility = Visibility.Collapsed;
            paginationStackPanel.Visibility = Visibility.Collapsed;
            claimsImg.Source = null;
        }
    }
}