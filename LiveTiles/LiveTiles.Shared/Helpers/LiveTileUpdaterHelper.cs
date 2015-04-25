using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace LiveTiles.Helpers
{
    public static class LiveTileUpdaterHelper
    {
        #region Static Methods

        public static bool PushToLiveTile(this LiveTileSet tileSet, DateTimeOffset? expirationTime)
        {
            var liveTileData = new List<LiveTileData>();
            if (tileSet.MediumSquareTile != null)
            {
                liveTileData.Add(tileSet.MediumSquareTile);
            }

            if (tileSet.WideTile != null)
            {
                liveTileData.Add(tileSet.WideTile);
            }
            if (tileSet.LargeSquareTile != null)
            {
                liveTileData.Add(tileSet.LargeSquareTile);
            }
            if (liveTileData.Count > 0)
            {
                UpdateLiveTile(liveTileData, expirationTime);
                return true;
            }
            return false;
        }

        private static XmlDocument GetTileXml(LiveTileData tile)
        {
            var tileXml = TileUpdateManager.GetTemplateContent(tile.TileTemplateType);

            if (tile.TextLimit > 0)
            {
                var tileTextAttributes = tileXml.GetElementsByTagName("text");
                for (var i = 0; i < (tile.Text.Count < tile.TextLimit ? tile.Text.Count : tile.TextLimit); i++)
                {
                    tileTextAttributes[i].InnerText = tile.Text[i];
                }
            }

            if (tile.ImageDataLimit > 0)
            {
                var tileImageAttributes = tileXml.GetElementsByTagName("image");

                for (var i = 0; i < (tile.ImageData.Count < tile.ImageDataLimit ? tile.ImageData.Count : tile.ImageDataLimit); i++)
                {
                    ((XmlElement)tileImageAttributes[i]).SetAttribute("src", tile.ImageData[i].ImagePath);
                    ((XmlElement)tileImageAttributes[i]).SetAttribute("alt", tile.ImageData[i].ImageAlt);
                }
            }
            return tileXml;
        }

        public static void UpdateLiveTile(IEnumerable<LiveTileData> tileData, DateTimeOffset? expirationTime)
        {
            var tileDataList = tileData.ToList();
            var baseTileXml = new XmlDocument();

            foreach (var tile in tileDataList)
            {
                var tileXml = GetTileXml(tile);
                if (tile == tileDataList.ToList()[0])
                {
                    baseTileXml = tileXml;
                }
                else
                {
                    var node = baseTileXml.ImportNode(tileXml.GetElementsByTagName("binding").Item(0), true);
                    baseTileXml.GetElementsByTagName("visual").Item(0).AppendChild(node);
                }
            }
            var tileNotification = new TileNotification(baseTileXml);

            if (expirationTime != null)
            {
                tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddDays(1);
            }
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

        #endregion
    }
}