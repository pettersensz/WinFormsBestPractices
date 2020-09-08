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
        private int _positionInSeconds;

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

        public int PositionInSeconds
        {
            get => _positionInSeconds;
            set
            {
                if (_positionInSeconds != value)
                {
                    _positionInSeconds = value;
                    Invalidate();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CalculateScrollbar();
        }

        private static readonly Pen PositionPen = new Pen(Color.FromArgb(80,80,80), 2);
        private static readonly Brush PositionBrush = new SolidBrush(Color.FromArgb(229,215,200));

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

            var positionX = PositionInSeconds - hScrollBar1.Value;
            e.Graphics.DrawLine(PositionPen,positionX,0,positionX,Height);

            var timeString = TimeSpan.FromMilliseconds(PositionInSeconds).ToString(@"hh\:mm\:ss");
            var timeStringRect = e.Graphics.MeasureString(timeString, Font);
            var timeRect = new Rectangle(positionX,1,(int)timeStringRect.Width+6,15);
            
            e.Graphics.FillRectangle(PositionBrush,timeRect);
            e.Graphics.DrawRectangle(PositionPen,timeRect);
            timeRect.Inflate(-2,-2);
            e.Graphics.DrawString(timeString,Font,Brushes.Black,timeRect);
        }
    }
}
