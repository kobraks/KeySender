using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySender
{
    public partial class ReadyIconControl : Control
    {
        const int StartAlpha = 50;

        Color _color1 = Color.Green, _color2 = Color.Red;
        bool _ready = false;

        public ReadyIconControl()
        {
            InitializeComponent();
        }

        void Draw(Graphics gr, Color color)
        {
            Point point = new Point(0, 0);

            for (int i = StartAlpha, x = Size.Width - 1, y = Size.Height - 1; i < 255; i++, x -= 2, y -= 2)
            {
                if (point.X < (Size.Width - 1) / 2)
                    point.X += 1;
                if (point.Y < (Size.Height - 1) / 2)
                    point.Y += 1;

                if (x < 0 || y < 0) return;

                color = Color.FromArgb(i, color.R, color.G, color.B);
                Size size = new Size(x, y);

                using (Brush b = new SolidBrush(color))
                {
                    gr.FillEllipse(b, new Rectangle(point, size));
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            using (Graphics gr = pe.Graphics)
            {
                if (IsReady)
                    Draw(gr, ReadyColor);
                else
                    Draw(gr, UnReadyColor);
            }
        }

        public Color ReadyColor
        {
            get
            {
                return _color1;
            }

            set
            {
                _color1 = value;
                this.Invalidate();
            }
        }

        public Color UnReadyColor
        {
            get
            {
                return _color2;
            }

            set
            {
                _color2 = value;
                this.Invalidate();

            }
        }

        public bool IsReady
        {
            get
            {
                return _ready;
            }

            set
            {
                _ready = value;
                this.Invalidate();
            }
        }
    }
}
