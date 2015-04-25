using System.Collections.Generic;
using Windows.UI.Notifications;

namespace LiveTiles.Helpers
{
    public class LiveTileData
    {
        #region Fields

        public readonly int ImageDataLimit;

        public readonly int TextLimit;

        public readonly TileTemplateType TileTemplateType;

        private List<ImageMetadata> _imageData = new List<ImageMetadata>();

        private List<string> _text = new List<string>();

        #endregion

        #region Properties

        public List<ImageMetadata> ImageData
        {
            get
            {
                    return _imageData;
            }
            set
            {
                _imageData = new List<ImageMetadata>();

                var counterLimit = value.Count > ImageDataLimit ? ImageDataLimit : value.Count;
                for (var i = 0; i < counterLimit; i++)
                {
                    _imageData.Add(value[i]);
                }
            }
        }

        public List<string> Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = new List<string>();

                var counterLimit = value.Count > TextLimit ? TextLimit : value.Count;
                for (var i = 0; i < counterLimit; i++)
                {
                    _text.Add(value[i]);
                }
            }
        }

        #endregion

        #region Constructors

        public LiveTileData(TileTemplateType tileTemplateType)
        {
            TileTemplateType = tileTemplateType;

            var tileXml = TileUpdateManager.GetTemplateContent(tileTemplateType);
            TextLimit = (int)tileXml.GetElementsByTagName("text").Length;
            ImageDataLimit = (int)tileXml.GetElementsByTagName("image").Length;
        }

        #endregion
    }


}