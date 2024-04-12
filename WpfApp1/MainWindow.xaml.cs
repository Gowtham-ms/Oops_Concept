using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Win32;

namespace WpfApp1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<string> searchResults = new List<string>();
        private int itemsPerPage = 1;
        private int currentPage = 1;
        private List<int> _paginationButtons = new List<int>();
        public event PropertyChangedEventHandler PropertyChanged;

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
            if (txtSearch.Text == "") {
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
                    Paging.Visibility = Visibility.Visible;
                    GeneratePaginationButtons();
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
        private void GeneratePaginationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
            if (totalPages < 3)
            {
                PaginationButtons = Enumerable.Range(1, totalPages).ToList();
            }
            else
            {
                int startPage = Math.Max(currentPage - 1, 1);
                int endPage = Math.Min(currentPage + 2, totalPages);
                PaginationButtons = Enumerable.Range(startPage, endPage - startPage + 1).ToList();
            }
        }

        private void PageButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            int clickedPage = Convert.ToInt32(button.Content);

            if (clickedPage != currentPage)
            {
                currentPage = clickedPage;
                ShowImage();

                int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
                if (totalPages < 3)
                {
                    PaginationButtons = Enumerable.Range(1, totalPages).ToList();
                }
                else
                {
                    int startPage = Math.Max(currentPage - 1, 1);
                    int endPage = Math.Min(startPage + 2, totalPages);
                    if (endPage == totalPages)
                    {
                        startPage = Math.Max(endPage - 2, 1);
                    }
                    PaginationButtons = Enumerable.Range(startPage, endPage - startPage + 1).ToList();
                }
            }
            EnablePrevNext();
        }

        private void UpdatePaginationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)searchResults.Count / itemsPerPage);
            if (totalPages < 3)
            {
                PaginationButtons = Enumerable.Range(1, totalPages).ToList();
            }
            else
            {
                int startPage = Math.Max(currentPage - 1, 1);
                int endPage = Math.Min(startPage + 2, totalPages);
                if (endPage == totalPages)
                {
                    startPage = Math.Max(endPage - 2, 1);
                }
                PaginationButtons = Enumerable.Range(startPage, endPage - startPage + 1).ToList();

            }
            EnablePrevNext();
        }



        private void ShowImage()
        {
            if (searchResults != null && searchResults.Any())
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
                        string downloadPath = Path.Combine(downloadFolder, Path.GetFileName(imagePath));
                        File.Copy(imagePath, downloadPath, true);
                    }
                    System.Windows.MessageBox.Show("Images downloaded successfully.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Failed to download images: " + ex.Message);
            }
        }
        public string GetDownloadFolder()
        {
            string downloadFolder = "";

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    downloadFolder = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    downloadFolder = null;
                }
            }

            return downloadFolder;
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (searchResults != null && searchResults.Count > 0)
            {
                System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
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
            Paging.Visibility = Visibility.Collapsed;
            claimsImg.Source = null;
        }
    }
}

