using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class WaveFormViewer : UserControl
    {
        private float[] _peaks;
        private Brush _backBrush;
        private Pen _waveformPen;
        
        public WaveFormViewer()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void SetPeaks(float[] newPeaks)
        {
            _peaks = newPeaks;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_peaks != null)
            {
                _backBrush = _backBrush ?? new SolidBrush(BackColor);
                _waveformPen = _waveformPen ?? new Pen(ForeColor);
                e.Graphics.FillRectangle(_backBrush, ClientRectangle);
                for (int x = 0; x < _peaks.Length && x < Width; x++)
                {
                    var height = _peaks[x] * Height;
                    var top = (Height - height) / 2;
                    e.Graphics.DrawLine(_waveformPen, x, top,x,top+height);
                }
            }
        }
    }
}
