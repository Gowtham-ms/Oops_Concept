using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Configuration;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly List<string> searchResults = [];
        private readonly int itemsPerPage = 1;
        private int currentPage = 1;
        private List<int> _paginationButtons = [];
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Button> paginationButtons = [];
        public static string documentsPath { get; set; }
        public class AppConfig {
            public string GetFolderPath() {
                var environment = System.Configuration.ConfigurationManager.AppSettings.Get("RUNTIME_ENVIRONMENT");
                environment = "Dev";
                var builder = new ConfigurationBuilder()
                                    .AddJsonFile($"appsettings.json", true, true)
                                    .AddJsonFile($"appsettings.{environment}.json", true, true);
                var config = builder.Build();
                documentsPath = config["AppSettings:documentsPath"];
                string path = config["DocumentPath"];
                return documentsPath;
            }

        }
        public List<int> PaginationButtons
        {
            get { return _paginationButtons; }
            set
            {
                _paginationButtons = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                AppConfig config = new AppConfig();
                documentsPath = config.GetFolderPath();
                DataContext = this;
                HideAllUIElements();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred during initialization");
            }
        }

        #region ShowHideButtons
        private void ShowAllUIElements()
        {
            Previous.Visibility = Visibility.Visible;
            Next.Visibility = Visibility.Visible;
            FirstPage.Visibility = Visibility.Visible;
            LastPage.Visibility = Visibility.Visible;
            //PaginationButton_Click = visibility.Visible;
            DownloadDropdownButton.Visibility = Visibility.Visible;
            ExportDropdownButton.Visibility = Visibility.Visible;
            //PrintDropdownButton.Visibility = Visibility.Visible;
            ZoomInButton.Visibility = Visibility.Visible;
            ZoomOutButton.Visibility = Visibility.Visible;
            Reset.Visibility = Visibility.Visible;
        }
        private void HideAllUIElements()
        {
            Previous.Visibility = Visibility.Collapsed;
            Next.Visibility = Visibility.Collapsed;
            FirstPage.Visibility = Visibility.Collapsed;
            LastPage.Visibility = Visibility.Collapsed;
            //Download.Visibility = Visibility.Collapsed;
            //DownloadAll.Visibility = Visibility.Collapsed;
            //Print.Visibility = Visibility.Collapsed;
            ZoomInButton.Visibility = Visibility.Collapsed;
            ZoomOutButton.Visibility = Visibility.Collapsed;
            Reset.Visibility = Visibility.Collapsed;
            DownloadDropdownButton.Visibility = Visibility.Collapsed;
            ExportDropdownButton.Visibility = Visibility.Collapsed;
            //PrintDropdownButton.Visibility = Visibility.Collapsed;
            //Export.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Search Button Logic
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Please enter a claim number to search");

                }
                else
                {
                    searchResults.Clear();
                    string SearchClaims = txtSearch.Text;
                    //string documentsPath = @"C:\Users\msgow\Downloads\NewFolder";

                    if (!Directory.Exists(documentsPath))
                    {
                        MessageBox.Show($"{documentsPath} does not exist");
                        return;
                    }

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
                        ShowAllUIElements();
                        EnablePrevNext();
                        EnableFirstLast();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error searching claim number");
            }

        }
        #endregion

        #region Enabling Prev, Next, First & Last Buttons
        private void EnablePrevNext()
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("An Error occurred while enabling Previous and next buttons");
            }

        }

        private void EnableFirstLast()
        {
            try
            {
                if (currentPage == 1)
                    FirstPage.IsEnabled = false;
                else
                    FirstPage.IsEnabled = true;
                if (currentPage == searchResults.Count)
                    LastPage.IsEnabled = false;
                else
                    LastPage.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("An Error occurred while enabling FirstPage and LastPage buttons");
            }

        }
        #endregion

        #region Pagination

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
            EnableFirstLast();
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
                button.Background = Brushes.LightGray;
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
            EnableFirstLast();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    ShowImage();
                    UpdatePaginationButtons();
                    claimsImg.Width = 521;
                    claimsImg.Height = 300;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while navigating to the previous page");
            }

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentPage < Math.Ceiling((double)searchResults.Count / itemsPerPage))
                {
                    currentPage++;
                    ShowImage();
                    UpdatePaginationButtons();
                    claimsImg.Width = 521;
                    claimsImg.Height = 300;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while navigating to the next page");

            }
        }
        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentPage = 1;
                ShowImage();
                UpdatePaginationButtons();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while navigating to the first page");
            }
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
                currentPage = totalPages;
                ShowImage();
                UpdatePaginationButtons();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while naviagting to the last page");
            }

        }

        #endregion

        #region Fetching & Showing Image after searching
        private void ShowImage()
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("An error occurred while displaying images");
            }
        }
        #endregion

        #region Download Options
        private void Download_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var inputDialog = new ImageRangeInputDialog();
                if (inputDialog.ShowDialog() == true)
                {
                    int startNumber = inputDialog.StartNumber;
                    int endNumber = inputDialog.EndNumber;

                    DownloadImagesInRange(startNumber, endNumber);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while downloading");
            }

        }
        private void DownloadAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DownloadImagesInRange(1, searchResults.Count);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while downloading");
            }
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
                        string downloadPath = Path.Combine(downloadFolder, Path.GetFileName(imagePath));
                        File.Copy(imagePath, downloadPath, true);
                    }
                    MessageBox.Show("Images downloaded successfully.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to download images");
            }
        }
        private void DownloadCurrent_Click(object sender, RoutedEventArgs e)
        {
            DownloadImagesInRange(currentPage, currentPage);
        }
        #endregion

        #region Folder Dialog Utility
        public static string GetDownloadFolder()
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("An Error occurred while getting download folder");
                return null;
            }
        }
        #endregion

        #region Zoom Options
        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (claimsImg.Width < 1000)
                {
                    double zoomFactor = 1.2;
                    claimsImg.Width *= zoomFactor;
                    claimsImg.Height *= zoomFactor;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while while zooming in");
            }

        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double zoomFactor = 1.2;
                claimsImg.Width /= zoomFactor;
                claimsImg.Height /= zoomFactor;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while zooming out");
            }
        }
        #endregion

        #region Resetting 
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtSearch.Text = string.Empty;
                HideAllUIElements();
                claimsImg.Source = null;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while resetting");
            }

        }
        #endregion

        #region Export Options
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchResults.Count == 0)
                {
                    MessageBox.Show("No Images to export");
                    return;
                }
                var inputDialog = new ImageRangeInputDialog();
                if (inputDialog.ShowDialog() == true)
                {
                    int startNumber = inputDialog.StartNumber;
                    int endNumber = inputDialog.EndNumber;

                    ExportPDfInRange(startNumber, endNumber);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error exporting PDF");
            }

        }
        private void ExportCurrent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ExportPDfInRange(currentPage, currentPage);
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Exporting current page");
            }
        }
        private void ExportAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ExportPDfInRange(1, searchResults.Count);
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Exporting all pdf");
            }
        }
        private void ExportPDfInRange(int startNumber, int endNumber)
        {
            string filePath = "";
            string filename = "";
            string downloadFolder = GetDownloadFolder();
            if (downloadFolder == null)
            {
                MessageBox.Show("Download folder not selected.");
                return;
            }
            if (downloadFolder != null)
            {
                for (int i = startNumber; i <= endNumber && i <= searchResults.Count; i++)
                {
                    PdfDocument document = new PdfDocument();
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XImage x_Image = XImage.FromFile(searchResults[i - 1]);
                    BitmapImage bitmapImage = new BitmapImage(new Uri(searchResults[i - 1]));
                    double imageWidth = bitmapImage.PixelWidth;
                    double imageHeight = bitmapImage.PixelHeight;
                    filename = Path.GetFileNameWithoutExtension(searchResults[i - 1]);
                    filePath = Path.Combine(downloadFolder, filename + ".pdf");
                    gfx.DrawImage(x_Image, 0, 0, imageWidth, imageHeight);
                    document.Save(filePath);
                    document.Close();
                }
            }


            MessageBox.Show("PDF exported successfully to:" + filePath);
        }
        #endregion

        //#region Print options
        //private void Print_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {

        //        if (searchResults.Count == 0)
        //        {
        //            MessageBox.Show("No Images to Print");
        //            return;
        //        }
        //        var inputDialog = new Print();
        //        if (inputDialog.ShowDialog() == true)
        //        {
        //            int startNumber = inputDialog.StartNumber;
        //            int endNumber = inputDialog.EndNumber;

        //            PrintInRange(startNumber, endNumber);
        //        }
        //    }

        //    catch (Exception)
        //    {
        //        MessageBox.Show("An Error occurred while printing");
        //    }

        //}
        //private void PrintCurrent_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        this.PrintInRange(currentPage, currentPage);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error in Printing current page");
        //    }
        //}
        //private void PrintAll_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        this.PrintInRange(1, searchResults.Count);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error in Printing all");
        //    }
        //}
        //private void PrintInRange(int startNumber, int endNumber)
        //{
        //    try
        //    {
        //        PrintDialog pd = new();
        //        if (pd.ShowDialog() == true)
        //        {
        //            for (int i = startNumber; i <= endNumber; i++)
        //            {
        //                claimsImg.Source = new BitmapImage(new Uri(searchResults[i - 1], UriKind.RelativeOrAbsolute));
        //                pd.PrintVisual(claimsImg, "Print Image");
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error in Print Range");
        //    }
        //}
        //#endregion


        private void claimsImg_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (claimsImg.Source is BitmapImage imgSrc)
            {
                ImagePopup imgPopup = new()
                {
                    ImageSource = imgSrc
                };
                imgPopup.ShowDialog();
            }
        }
    }
}