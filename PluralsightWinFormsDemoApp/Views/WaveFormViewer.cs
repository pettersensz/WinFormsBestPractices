using System;
using System.Drawing;
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
            hScrollBar1.Scroll += hScrollBar1_Scroll;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }


        public void SetPeaks(float[] newPeaks)
        {
            _peaks = newPeaks;
            CalculateScrollbar();
            Invalidate();
        }

        private void CalculateScrollbar()
        {
            if (_peaks != null)
            {
                hScrollBar1.Maximum = _peaks.Length;
                hScrollBar1.LargeChange = Width;
                hScrollBar1.SmallChange = Width / 10;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CalculateScrollbar();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_peaks != null)
            {
                _backBrush = _backBrush ?? new SolidBrush(BackColor);
                _waveformPen = _waveformPen ?? new Pen(ForeColor);

                var startPeak = hScrollBar1.Value;

                e.Graphics.FillRectangle(_backBrush, ClientRectangle);
                for (int x = 0; (startPeak + x < _peaks.Length) && x < Width; x++)
                {
                    var availableHeight = Height - hScrollBar1.Height;
                    var height = _peaks[startPeak + x] * availableHeight;
                    var top = (availableHeight - height) / 2;
                    e.Graphics.DrawLine(_waveformPen, x, top, x, top + height);
                }
            }
        }
    }
}
