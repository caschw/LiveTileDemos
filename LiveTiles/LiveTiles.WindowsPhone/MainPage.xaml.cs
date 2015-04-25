using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.StartScreen;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Notifications;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using LiveTiles.Helpers;

namespace LiveTiles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<string> _secondaryTiles;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            _secondaryTiles = new List<string>();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void PivotItem1(object sender, RoutedEventArgs e)
        {
            //var items = Enum.GetValues(typeof(TileTemplateType));
            //foreach (TileTemplateType item in items)
            //{
            //    TileXml.Text += TileUpdateManager.GetTemplateContent(item).GetXml();
            //    TileXml.Text += Environment.NewLine;
            //    TileXml.Text += Environment.NewLine;
            //}
            TileXml.Text = Strings.LiveTileTemplateXml();
        }

        private void PivotItem2(object sender, RoutedEventArgs e)
        {
            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text02);

            var tileTextAttributes = tileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = "Twin Cities Code Camp 2015";
            tileTextAttributes[1].InnerText = new DateTimeFormatter("shortdate shorttime").Format(DateTime.Now);

            var tileNotification = new TileNotification(tileXml)
            {
                ExpirationTime = DateTimeOffset.UtcNow.AddDays(1)
            };
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

        private void PivotItem3(object sender, RoutedEventArgs e)
        {
            // first tile size
            var squareXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text02);
            var tileTextAttributes = squareXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = "TCCC 2015";
            tileTextAttributes[1].InnerText = new DateTimeFormatter("shortdate shorttime").Format(DateTime.Now);

            var squareTileNotification = new TileNotification(squareXml)
            {
                ExpirationTime = DateTimeOffset.UtcNow.AddDays(1)
            };
            TileUpdateManager.CreateTileUpdaterForApplication().Update(squareTileNotification);

            // second tile size
            var wideTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150BlockAndText02);
            var tileTextAttributes2 = wideTileXml.GetElementsByTagName("text");
            tileTextAttributes2[0].InnerText = "Twin Cities Code Camp 2015";
            tileTextAttributes2[1].InnerText = new DateTimeFormatter("shortdate shorttime").Format(DateTime.Now);

            var wideTileNotification = new TileNotification(wideTileXml)
            {
                ExpirationTime = DateTimeOffset.UtcNow.AddDays(1)
            };
            TileUpdateManager.CreateTileUpdaterForApplication().Update(wideTileNotification);
        }

        private void PivotItem4(object sender, RoutedEventArgs e)
        {
            // first tile size
            var squareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150PeekImageAndText02);
            var tileTextAttributes = squareTileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = "TCCC 2015";
            tileTextAttributes[1].InnerText = new DateTimeFormatter("shortdate shorttime").Format(DateTime.Now);
            var tileImageAttributes = squareTileXml.GetElementsByTagName("image");
            ((XmlElement)tileImageAttributes[0]).SetAttribute("src", "Assets/tccc150.jpg");
            ((XmlElement)tileImageAttributes[0]).SetAttribute("alt", "Link" + " image");

            var bindingXml = squareTileXml.GetElementsByTagName("binding");
            var bindingnode = bindingXml[0];
            var newAttribute = squareTileXml.CreateAttribute("branding");
            newAttribute.Value = "none";
            bindingnode.Attributes.SetNamedItem(newAttribute);

            // second tile size
            var wideTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150ImageAndText02);
            var tileTextAttributes2 = wideTileXml.GetElementsByTagName("text");
            tileTextAttributes2[0].InnerText = "Twin Cities Code Camp 2015";
            tileTextAttributes2[1].InnerText = new DateTimeFormatter("shortdate shorttime").Format(DateTime.Now);
            var tileImageAttributes2 = wideTileXml.GetElementsByTagName("image");
            ((XmlElement)tileImageAttributes2[0]).SetAttribute("src", "Assets/tcccWide.jpg");
            ((XmlElement)tileImageAttributes2[0]).SetAttribute("alt", "Link" + " image");

            var bindingXml2 = wideTileXml.GetElementsByTagName("binding");
            var bindingnode2 = bindingXml2[0];
            var newAttribute2 = wideTileXml.CreateAttribute("branding");
            newAttribute2.Value = "none";
            bindingnode2.Attributes.SetNamedItem(newAttribute2);

            // Merge the XML
            var node = wideTileXml.ImportNode(squareTileXml.GetElementsByTagName("binding").Item(0), true);
            wideTileXml.GetElementsByTagName("visual").Item(0).AppendChild(node);

            var tileNotification = new TileNotification(wideTileXml)
            {
                ExpirationTime = DateTimeOffset.UtcNow.AddDays(1)
            };

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

        private void PivotItem5(object sender, RoutedEventArgs e)
        {
            var tileSet = new LiveTileSet()
            {
                MediumSquareTile = new LiveTileData(TileTemplateType.TileSquare150x150PeekImageAndText02)
                {
                    Text = new List<string>
                    {
                        "TCCC 2015",
                        new DateTimeFormatter("shortdate shorttime").Format(DateTime.Now)
                    },
                    ImageData = new List<ImageMetadata>
                    {
                        new ImageMetadata {
                            ImageAlt ="  ",
                            ImagePath="Assets/tccc150.jpg"
                        }
                    }
                },
                WideTile = new LiveTileData(TileTemplateType.TileWide310x150ImageAndText02)
                {
                    Text = new List<string>
                    {
                        "TCCC 2015",
                        new DateTimeFormatter("shortdate shorttime").Format(DateTime.Now)
                    },
                    ImageData = new List<ImageMetadata>
                    {
                        new ImageMetadata {
                            ImageAlt ="  ",
                            ImagePath="Assets/tcccWide.jpg"
                        }
                    }
                }
            };
            tileSet.PushToLiveTile(DateTimeOffset.Now.AddDays(1));
        }
    }
}
