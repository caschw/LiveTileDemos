using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Controls;
using System.Windows.Media;


// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SilverLightAdvancedTiles
{
    public sealed partial class BatteryControl : UserControl
    {
        public BatteryControl(Color backgroundColor, int batteryPercentage)
        {
            InitializeComponent();

            BatteryLevelBlock.Text = batteryPercentage + "%";
            BatteryLevelBlockShadow.Text = BatteryLevelBlock.Text;

            LayoutRoot.Background = new SolidColorBrush(backgroundColor);
            ScaleTransform.ScaleY = batteryPercentage / 100.0;
        }
    }
}
