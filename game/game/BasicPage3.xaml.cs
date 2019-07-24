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
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace game
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class BasicPage3 : Page
    {
        string pwd;
        private TextBlock tb1;
        ApplicationDataContainer localSettings;
       // private NavigationHelper navigationHelper;
      //  private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        //public ObservableDictionary DefaultViewModel
        //{
         //   get { return this.defaultViewModel; }
       // }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        //{
          //  get { return this.navigationHelper; }
        //}


        public BasicPage3()
        {
            this.InitializeComponent();
            //this.navigationHelper = new NavigationHelper(this);
            //this.navigationHelper.LoadState += navigationHelper_LoadState;
            //this.navigationHelper.SaveState += navigationHelper_SaveState;
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
       // private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        //{
        //}

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
       // private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        //{
        //}
        #region NavigationHelper registration

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

       // protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //  navigationHelper.OnNavigatedTo(e);
     //   }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
           // navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //navigationHelper.OnNavigatedFrom(e);
            SizeChanged += BasicPage3_SizeChanged;
            var bound = Window.Current.Bounds;
            var height = bound.Height;
            var breadth = bound.Width;


            // navigationHelper.OnNavigatedTo(e);
            //popup1.Margin = new Thickness(breadth / 2 - 160, Height / 2 - 70, 0, 0);
            //popup2.Margin = new Thickness(breadth / 2 - 160, Height / 2 - 70, 0, 0);
            localSettings = ApplicationData.Current.LocalSettings;
            if (!localSettings.Values.ContainsKey("Password"))
            {
                popup1.IsOpen = true;
                popup1.Visibility = Visibility.Visible;
            }
            else
            {
                popup1.Visibility = Visibility.Collapsed;
                pwd = localSettings.Values["Password"].ToString();
            }
        }

        private void BasicPage3_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ApplicationViewState.FullScreenLandscape == ApplicationView.Value || ApplicationViewState.Filled == ApplicationView.Value)
            {
                //SnappedGrid.Visibility = Visibility.Collapsed;
                MainGrid.Visibility = Visibility.Visible;

            }
            else if (ApplicationViewState.Snapped == ApplicationView.Value)
            {
                //SnappedGrid.Visibility = Visibility.Visible;
                MainGrid.Visibility = Visibility.Collapsed;

            }
        }

       // protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
            //navigationHelper.OnNavigatedFrom(e);
        //}

        #endregion

        private void Image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            popup2.IsOpen = true;
        }
        private void key_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            popup2.IsOpen = true;
        }
        private void submitbtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (taketxt.Password == pwd)
            {
                this.Frame.Navigate(typeof(BasicPage4));

            }
            else
            {
                popup2.IsOpen = false;
            }
        }
        private void closebtn_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
            try
            {
                if (txt.Password == txt1.Password)
                {
                    localSettings.Values.Add("Password", txt.Password);
                    pwd = localSettings.Values["Password"].ToString();
                    //popup1.IsOpen = false;
                    MainGrid.Visibility = Visibility.Visible;
                    Caution.Visibility = Visibility.Collapsed;
                    Frame.Navigate(typeof(BasicPage9));
                    
                
                }
                else
                {
                    txt.Password = "";
                    txt1.Password = "";
                    Caution.Visibility = Visibility.Visible;
                }
            }
            catch (Exception z)
            {


            }
        }
        private void Grid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            popup2.IsOpen = true;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void key1_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            popup2.IsOpen = true;
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BasicPage2));
        }

        
    }
}
