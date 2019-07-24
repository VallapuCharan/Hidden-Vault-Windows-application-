using game.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.FileProperties;
using Windows.UI.ViewManagement;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace game
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class BasicPage4 : Page
    {
        List<PicsInfo> MyPics;
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public BasicPage4()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            MyPics = new List<PicsInfo>();
        }
        public class PicsInfo
        {
            public BitmapImage img { get; set; }
            public string path { get; set; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //navigationHelper.OnNavigatedTo(e);
            SizeChanged += BasicPage3_SizeChanged;
            StorageFolder dispic = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var dispiccollect = await dispic.GetFilesAsync();
            foreach (var check in dispiccollect)
            {
                if (check.FileType == ".png" || check.FileType == ".jpg")
                {
                    // await check.DeleteAsync();
                    var tnail = await check.GetThumbnailAsync(ThumbnailMode.PicturesView);
                    BitmapImage i = new BitmapImage();
                    i.SetSource(tnail);
                    MyPics.Add(new PicsInfo() { img = i, path = check.Path });
                    //imageviewer.Items.Add(i);
                }

            }
            imageviewer.ItemsSource = MyPics;
        }

        private async void add_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.ViewMode = PickerViewMode.List;
            var files = await picker.PickMultipleFilesAsync();
            foreach (var file in files)
            {
                if (file != null)
                {
                    await file.MoveAsync(Windows.ApplicationModel.Package.Current.InstalledLocation);
                    //await file.DeleteAsync();
                    var v = imageviewer.ItemsSource;
                }
            }

            MyPics = new List<PicsInfo>();
            StorageFolder dispic = Windows.ApplicationModel.Package.Current.InstalledLocation;

            var dispiccollect = await dispic.GetFilesAsync();
            foreach (var check in dispiccollect)
            {
                if (check.FileType == ".png" || check.FileType == ".jpg")
                {

                    var tnail = await check.GetThumbnailAsync(ThumbnailMode.PicturesView);
                    BitmapImage i = new BitmapImage();
                    i.SetSource(tnail);
                    MyPics.Add(new PicsInfo() { img = i, path = check.Path });
                    //imageviewer.Items.Add(i);
                }

            }
            imageviewer.ItemsSource = null;
            imageviewer.ItemsSource = MyPics;

        }
        private void BasicPage3_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ApplicationViewState.FullScreenLandscape == ApplicationView.Value || ApplicationViewState.Filled == ApplicationView.Value)
            {
                // SnappedGrid.Visibility = Visibility.Collapsed;
                Maingrid.Visibility = Visibility.Visible;

            }
            else if (ApplicationViewState.Snapped == ApplicationView.Value)
            {
                //SnappedGrid.Visibility = Visibility.Visible;
                Maingrid.Visibility = Visibility.Collapsed;

            }
        }
        private void imageviewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PicsInfo pic = (PicsInfo)imageviewer.SelectedItem;

            // var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            if (pic != null)
            {

                BitmapImage img = new BitmapImage();
                img.UriSource = new Uri(pic.path);
                MyMedia.Source = img;

            }
        }
       







        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

      

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
         
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".txt");

            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.ViewMode = PickerViewMode.List;
            var files = await picker.PickMultipleFilesAsync();
            foreach (var file in files)
            {
                if (file != null)
                {
                    await file.MoveAsync(Windows.ApplicationModel.Package.Current.InstalledLocation);
                    //await file.DeleteAsync();
                    var v = imageviewer.ItemsSource;
                }
            }

            MyPics = new List<PicsInfo>();
            StorageFolder dispic = Windows.ApplicationModel.Package.Current.InstalledLocation;

            var dispiccollect = await dispic.GetFilesAsync();
            foreach (var check in dispiccollect)
            {
                if (check.FileType == ".png" || check.FileType == ".jpg")
                {

                    var tnail = await check.GetThumbnailAsync(ThumbnailMode.PicturesView);
                    BitmapImage i = new BitmapImage();
                    i.SetSource(tnail);
                    MyPics.Add(new PicsInfo() { img = i, path = check.Path });
                    //imageviewer.Items.Add(i);
                }

            }
            imageviewer.ItemsSource = null;
            imageviewer.ItemsSource = MyPics;
        
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BasicPage1));
        }
        }

        
    }
#endregion