using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Model
{
    public class LayerValue
    {
        public Image image { get; private set; }
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }
        public float Transparency { get; private set; }
        public int TypeOperation { get; private set; }
        public LayerValue(Layer layer)
        {
            this.image = layer.image;
            this.R = layer.Check_R.Checked ? 1 : 0;
            this.G = layer.Check_G.Checked ? 1 : 0;
            this.B = layer.Check_B.Checked ? 1 : 0;
            this.Transparency = (float)(1.0 - layer.trackBar.Value / 100.0);
            this.TypeOperation = layer.comboBox.SelectedIndex;
        }
    }
}
