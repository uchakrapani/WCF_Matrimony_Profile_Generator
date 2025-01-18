using AngadisBioDataGenerator.Utility;
using CsvHelper;
using Microsoft.Win32;
using PuppeteerSharp;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WpfApp2;

namespace AngadisBioDataGenerator
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			InitializeBrowserFetcher();
		}

		private async void InitializeBrowserFetcher()
		{
			try
			{
				var browserFetcher = new BrowserFetcher();
				await browserFetcher.DownloadAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Failed to download Chrome: {ex.Message}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void BrowseCsvButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "CSV files (*.csv)|*.csv",
				Title = "Select a CSV file"
			};

			if (openFileDialog.ShowDialog() == true)
			{
				CsvFilePath.Text = openFileDialog.FileName;
			}
		}

		private async void ConvertCsvToImageButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(CsvFilePath.Text) || 
                PortalTypeComboBox.SelectedItem == null || 
                TemplateTypeComboBox.SelectedItem == null || 
                string.IsNullOrEmpty(OutputPathTextBox.Text))
			{
				lblMessage.Visibility = Visibility.Visible;
				lblMessage.Foreground = new SolidColorBrush(Colors.Red);
				lblMessage.Content = $"Please fill in all fields.";
				return;
			}

			if (!Directory.Exists(OutputPathTextBox.Text))
			{
				lblMessage.Visibility = Visibility.Visible;
				lblMessage.Foreground = new SolidColorBrush(Colors.Red);
				lblMessage.Content = $"Invalid destination folder path entered. Please provide a valid folder location.";
				return;
			}

			lblMessage.Visibility = Visibility.Hidden;
			ProgressBar.Visibility = Visibility.Visible;
			string portalType = (PortalTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString();
			string templateType = (TemplateTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString();
			string outputPath = OutputPathTextBox.Text;

			try
			{
				string userImageSource = string.Empty;
				var browserFetcher = new BrowserFetcher();
				await browserFetcher.DownloadAsync();

				var browser = await Puppeteer.LaunchAsync(new LaunchOptions
				{
					Headless = true
				});

				var page = await browser.NewPageAsync();

				if (portalType == "Doctors Matrimony")
					userImageSource = "https://www.medicowedding.com/assets/photos/watermark.php?image=";
				else
					userImageSource = "https://www.lingayatwedding.com/assets/photos/watermark.php?image=";

				using (var reader = new StreamReader(CsvFilePath.Text))
				using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
				{
					PrepareHeaderForMatch = args => args.Header.ToLower(),
				}))
				{
					var records = csv.GetRecords<UserModel>().ToList();
					int totalRecords = records.Count;
					ProgressBar.Minimum = 0;
					ProgressBar.Maximum = totalRecords;
					ProgressBar.Value = 0;

					for (int i = 0; i < totalRecords; i++)
					{
						var record = records[i];
						string htmlContent = string.Empty;

						if (templateType.ToLower() == "basic" && portalType.ToLower() == "lingayat matrimony")
							htmlContent = BasicLingayatMatrimonyHTML.BasicLingayatMatrimony(record, userImageSource);
						else if (templateType.ToLower() == "basic_v2" && portalType.ToLower() == "lingayat matrimony")
							htmlContent = BasicLingayatMatrimonyHTML.BasicLingayatMatrimonyV2(record, userImageSource);
						else if (templateType.ToLower() == "basic" && portalType.ToLower() == "doctors matrimony")
							htmlContent = BasicDoctorHTML.BasicDoctor(record, userImageSource);
						else if (templateType.ToLower() == "vip" && portalType.ToLower() == "lingayat matrimony")
							htmlContent = VIPLingayatMatrimonyHTML.VIPLingayatMatrimony(record, userImageSource);
						else if (templateType.ToLower() == "vip_v2" && portalType.ToLower() == "lingayat matrimony")
							htmlContent = VIPLingayatMatrimonyHTML.VIPLingayatMatrimonyV2(record, userImageSource);

						await page.SetContentAsync(htmlContent);

						// Capture the full page screenshot
						var screenshotOptions = new ScreenshotOptions
						{
							FullPage = true, // Capture the full page
							Type = ScreenshotType.Png
						};

						string filePath = Path.Combine(outputPath, $"{record.Matri_Id}.png");
						await page.ScreenshotAsync(filePath, screenshotOptions);

						// Update progress bar
						ProgressBar.Value = i + 1;

						// Allow the UI to update
						Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
					}
				}

				await browser.CloseAsync();

                ProgressBar.Visibility = Visibility.Hidden;
                lblMessage.Visibility = Visibility.Visible;
				lblMessage.Foreground = new SolidColorBrush(Colors.Green);
				lblMessage.Content = $"CSV data has been successfully converted to images. Please check output path";
			}
			catch (Exception ex)
			{
				ProgressBar.Visibility = Visibility.Hidden;
				lblMessage.Visibility = Visibility.Visible;
				lblMessage.Foreground = new SolidColorBrush(Colors.Red);
				lblMessage.Content = $"An error occurred: {ex.Message}";
			}
		}
	}
}
