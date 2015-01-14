using SQLiteWP8_Tinder4Jobs_POC.Model;
using SQLiteWP8_Tinder4Jobs_POC.DbHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SQLiteWP8_Tinder4Jobs_POC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string DB_PATH = Path.Combine(Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, DB_FILE_NAME));//DataBase Name
        private const string DB_FILE_NAME = "Tinder4Jobs.sqlite";
        private LinkedinJobList jobList = new LinkedinJobList();

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            InitDatabase();

           
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            try
            {

                LoadJson();
            }
            catch (Exception)
            {

                throw;
            }


            //MessageDialog d = new MessageDialog(result);

            //await d.ShowAsync();

      
        }

        private async void InitDatabase()
        {
            if (FileExists(DB_FILE_NAME).Result)
            {
                // file exists;
                DB_PATH = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                 DB_FILE_NAME);


            }
            else
            {
                // file does not exist
                StorageFile databaseFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(DB_FILE_NAME);
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
                DB_PATH = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DB_FILE_NAME);
            }


         
        }

        private void LoadJobs(LinkedinJobList jobList)
        {
            try
            {
                DatabaseLinkedinJobHelperClass data = new DatabaseLinkedinJobHelperClass();

                foreach (var job in jobList.Jobs.Values)
                {
                    if (data.ReadJob(job.Id) == null)
                        data.Insert(job);
                    else
                        data.UpdateJob(job);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<string> GetDbPath(string fileName)
        {
            string DBPath = "";

            if (FileExists(fileName).Result)
            {
                // file exists;
                DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                 fileName);


            }
            else
            {
                // file does not exist
                StorageFile databaseFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(fileName);
                DBPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            }

            return DBPath;
        }

        private async Task<bool> FileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

                return true;
            }
            catch
            {
            }
            return false;
        }

        public async void LoadJson()
        {
            // Load json file
            string fileContent;

            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //sb.Append(String.Format("Installed Location: {0}", Windows.ApplicationModel.Package.Current.InstalledLocation.Path));
            //sb.Append(Environment.NewLine);

            //var folders = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFoldersAsync(Windows.Storage.Search.CommonFolderQuery.DefaultQuery);

            //foreach (var folder in folders)
            //{
            //    sb.Append("Folder = " + folder.Name + Environment.NewLine);

            //    var files = await folder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery);

            //    foreach (var file in files)
            //    {
            //        sb.Append("File = " + file.Name + Environment.NewLine);

            //    }
            //}

            //string txtInstallationFolderContent = sb.ToString();

            var file = await folder.GetFileAsync("Assets\\jobs.json");

            using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
                fileContent = await sRead.ReadToEndAsync();

            // Parse
            jobList = JsonConvert.DeserializeObject<LinkedinJobList>(fileContent);



            try
            {
                DatabaseLinkedinJobHelperClass data = new DatabaseLinkedinJobHelperClass();

                foreach (var job in jobList.Jobs.Values)
                {
                    if (data.ReadJob(job.Id) == null)
                        data.Insert(job);
                    else
                        data.UpdateJob(job);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
