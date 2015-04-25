using System;
using System.Collections.Generic;
using Windows.UI.Notifications;

namespace LiveTiles.Helpers
{
    public class LiveTileSet
    {
        #region Fields

        private LiveTileData _largeSquareTile;

        private LiveTileData _mediumSquareTile;

        private LiveTileData _wideTile;

        #endregion

        #region Properties

        public LiveTileData LargeSquareTile
        {
            get
            {
                return _largeSquareTile;
            }
            set
            {
                if (IsLargeSquareTileType(value.TileTemplateType))
                {
                    _largeSquareTile = value;
                }
                else
                {
                    throw new ArgumentException(
                        String.Format("Provided TileTemplateType is not a LargeSquareTile template type: {0}",
                            value.TileTemplateType));
                }
            }
        }

        public LiveTileData MediumSquareTile
        {
            get
            {
                return _mediumSquareTile;
            }
            set
            {
                if (IsMediumSquareTileType(value.TileTemplateType))
                {
                    _mediumSquareTile = value;
                }
                else
                {
                    throw new ArgumentException(
                        String.Format("Provided TileTemplateType is not a MediumSquareTile template type: {0}",
                            value.TileTemplateType));
                }
            }
        }

        public LiveTileData WideTile
        {
            get
            {
                return _wideTile;
            }
            set
            {
                if (IsWideTileType(value.TileTemplateType))
                {
                    _wideTile = value;
                }
                else
                {
                    throw new ArgumentException(
                        String.Format("Provided TileTemplateType is not a WideTile template type: {0}",
                            value.TileTemplateType));
                }
            }
        }

        #endregion

        #region private

        private static bool IsLargeSquareTileType(TileTemplateType tileTemplate)
        {
            var validLargeTileTemplates = new List<TileTemplateType>
            {
                TileTemplateType.TileSquare310x310BlockAndText01,
                TileTemplateType.TileSquare310x310BlockAndText02,
                TileTemplateType.TileSquare310x310Image,
                TileTemplateType.TileSquare310x310ImageAndText01,
                TileTemplateType.TileSquare310x310ImageAndText02,
                TileTemplateType.TileSquare310x310ImageAndTextOverlay01,
                TileTemplateType.TileSquare310x310ImageAndTextOverlay02,
                TileTemplateType.TileSquare310x310ImageAndTextOverlay03,
                TileTemplateType.TileSquare310x310ImageCollection,
                TileTemplateType.TileSquare310x310ImageCollectionAndText01,
                TileTemplateType.TileSquare310x310ImageCollectionAndText02,
                TileTemplateType.TileSquare310x310SmallImageAndText01,
                TileTemplateType.TileSquare310x310SmallImagesAndTextList01,
                TileTemplateType.TileSquare310x310SmallImagesAndTextList02,
                TileTemplateType.TileSquare310x310SmallImagesAndTextList03,
                TileTemplateType.TileSquare310x310SmallImagesAndTextList04,
                TileTemplateType.TileSquare310x310SmallImagesAndTextList05,
                TileTemplateType.TileSquare310x310Text01,
                TileTemplateType.TileSquare310x310Text02,
                TileTemplateType.TileSquare310x310Text03,
                TileTemplateType.TileSquare310x310Text04,
                TileTemplateType.TileSquare310x310Text05,
                TileTemplateType.TileSquare310x310Text06,
                TileTemplateType.TileSquare310x310Text07,
                TileTemplateType.TileSquare310x310Text08,
                TileTemplateType.TileSquare310x310Text09,
                TileTemplateType.TileSquare310x310TextList01,
                TileTemplateType.TileSquare310x310TextList02,
                TileTemplateType.TileSquare310x310TextList03
            };
            return validLargeTileTemplates.Contains(tileTemplate);
        }

        private static bool IsMediumSquareTileType(TileTemplateType tileTemplate)
        {
            var validMediumTemplates = new List<TileTemplateType>
            {
                TileTemplateType.TileSquare150x150Block,
                TileTemplateType.TileSquare150x150Image,
                TileTemplateType.TileSquare150x150PeekImageAndText01,
                TileTemplateType.TileSquare150x150PeekImageAndText02,
                TileTemplateType.TileSquare150x150PeekImageAndText03,
                TileTemplateType.TileSquare150x150PeekImageAndText04,
                TileTemplateType.TileSquare150x150Text01,
                TileTemplateType.TileSquare150x150Text02,
                TileTemplateType.TileSquare150x150Text03,
                TileTemplateType.TileSquare150x150Text04,
                TileTemplateType.TileSquareBlock,
                TileTemplateType.TileSquareImage,
                TileTemplateType.TileSquarePeekImageAndText01,
                TileTemplateType.TileSquarePeekImageAndText02,
                TileTemplateType.TileSquarePeekImageAndText03,
                TileTemplateType.TileSquarePeekImageAndText04,
                TileTemplateType.TileSquareText01,
                TileTemplateType.TileSquareText02,
                TileTemplateType.TileSquareText03,
                TileTemplateType.TileSquareText04
            };
            return validMediumTemplates.Contains(tileTemplate);
        }

        private static bool IsWideTileType(TileTemplateType tileTemplate)
        {
            var validWideTemplates = new List<TileTemplateType>
            {
                TileTemplateType.TileWide310x150BlockAndText01,
                TileTemplateType.TileWide310x150BlockAndText02,
                TileTemplateType.TileWide310x150Image,
                TileTemplateType.TileWide310x150ImageAndText01,
                TileTemplateType.TileWide310x150ImageAndText02,
                TileTemplateType.TileWide310x150ImageCollection,
                TileTemplateType.TileWide310x150PeekImage01,
                TileTemplateType.TileWide310x150PeekImage02,
                TileTemplateType.TileWide310x150PeekImage03,
                TileTemplateType.TileWide310x150PeekImage04,
                TileTemplateType.TileWide310x150PeekImage05,
                TileTemplateType.TileWide310x150PeekImage06,
                TileTemplateType.TileWide310x150PeekImageAndText01,
                TileTemplateType.TileWide310x150PeekImageAndText02,
                TileTemplateType.TileWide310x150PeekImageCollection01,
                TileTemplateType.TileWide310x150PeekImageCollection02,
                TileTemplateType.TileWide310x150PeekImageCollection03,
                TileTemplateType.TileWide310x150PeekImageCollection04,
                TileTemplateType.TileWide310x150PeekImageCollection05,
                TileTemplateType.TileWide310x150PeekImageCollection06,
                TileTemplateType.TileWide310x150SmallImageAndText01,
                TileTemplateType.TileWide310x150SmallImageAndText02,
                TileTemplateType.TileWide310x150SmallImageAndText03,
                TileTemplateType.TileWide310x150SmallImageAndText04,
                TileTemplateType.TileWide310x150SmallImageAndText05,
                TileTemplateType.TileWide310x150Text01,
                TileTemplateType.TileWide310x150Text02,
                TileTemplateType.TileWide310x150Text03,
                TileTemplateType.TileWide310x150Text04,
                TileTemplateType.TileWide310x150Text05,
                TileTemplateType.TileWide310x150Text06,
                TileTemplateType.TileWide310x150Text07,
                TileTemplateType.TileWide310x150Text08,
                TileTemplateType.TileWide310x150Text09,
                TileTemplateType.TileWide310x150Text10,
                TileTemplateType.TileWide310x150Text11,
                TileTemplateType.TileWideBlockAndText01,
                TileTemplateType.TileWideBlockAndText02,
                TileTemplateType.TileWideImage,
                TileTemplateType.TileWideImageAndText01,
                TileTemplateType.TileWideImageAndText02,
                TileTemplateType.TileWideImageCollection,
                TileTemplateType.TileWidePeekImage01,
                TileTemplateType.TileWidePeekImage02,
                TileTemplateType.TileWidePeekImage03,
                TileTemplateType.TileWidePeekImage04,
                TileTemplateType.TileWidePeekImage05,
                TileTemplateType.TileWidePeekImage06,
                TileTemplateType.TileWidePeekImageAndText01,
                TileTemplateType.TileWidePeekImageAndText02,
                TileTemplateType.TileWidePeekImageCollection01,
                TileTemplateType.TileWidePeekImageCollection02,
                TileTemplateType.TileWidePeekImageCollection03,
                TileTemplateType.TileWidePeekImageCollection04,
                TileTemplateType.TileWidePeekImageCollection05,
                TileTemplateType.TileWidePeekImageCollection06,
                TileTemplateType.TileWideSmallImageAndText01,
                TileTemplateType.TileWideSmallImageAndText02,
                TileTemplateType.TileWideSmallImageAndText03,
                TileTemplateType.TileWideSmallImageAndText04,
                TileTemplateType.TileWideSmallImageAndText05,
                TileTemplateType.TileWideText01,
                TileTemplateType.TileWideText02,
                TileTemplateType.TileWideText03,
                TileTemplateType.TileWideText04,
                TileTemplateType.TileWideText05,
                TileTemplateType.TileWideText06,
                TileTemplateType.TileWideText07,
                TileTemplateType.TileWideText08,
                TileTemplateType.TileWideText09,
                TileTemplateType.TileWideText10,
                TileTemplateType.TileWideText11
            };
            return validWideTemplates.Contains(tileTemplate);
        }

        #endregion
    }
}