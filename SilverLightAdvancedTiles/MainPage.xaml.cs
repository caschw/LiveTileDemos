using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SilverLightAdvancedTiles.Resources;

namespace SilverLightAdvancedTiles
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void PivotItem1(object sender, RoutedEventArgs e)
        {
            var battery = new BatteryControl(TileHelper.GetRandomColor(), new Random().Next(100));
            battery.SaveAsImageToIsolatedStorage("livetile", new Size(450, 450), new Size(336,336));

            var fd = new FlipTileData
            {
                BackgroundImage = new Uri("isostore:/Shared/ShellContent/livetile.jpg", UriKind.Absolute), Title=""
            };
            var tile = ShellTile.ActiveTiles.FirstOrDefault();
            tile.Update(fd);

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}