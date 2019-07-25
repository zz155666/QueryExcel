using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace smartpos.wpos.App.Components.UserDefined.Button
{
    public class RibbonMenu : ContextMenuStrip
    {
        private SolidBrush backgroundBrush;
        private Pen backgroundPen ;

		public RibbonMenu() {
			SetStyle(ControlStyles.SupportsTransparentBackColor |
			         ControlStyles.UserPaint |
			         ControlStyles.ResizeRedraw |
			         ControlStyles.AllPaintingInWmPaint |
			         ControlStyles.OptimizedDoubleBuffer |
			         ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.Opaque, false);
			BackColor = Color.Transparent;
			DropShadowEnabled = true;

			Renderer = new RibbonMenuRenderer();
		}

		private SolidBrush BackgroundBrush {
			get {
				return backgroundBrush ?? 
					(backgroundBrush = new SolidBrush(Color.FromArgb(250, 250, 250)));
			}

			set {
				if (backgroundBrush != null) {
					backgroundBrush.Dispose();
				}

				backgroundBrush = value;
			}
		}

		private Pen BackgroundPen {
			get { return backgroundPen ?? (backgroundPen = new Pen(Color.FromArgb(134, 134, 134))); }

			set {
				if (backgroundPen != null) {
					backgroundPen.Dispose();
				}

				backgroundPen = value;
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
			Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
			
			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.HighQuality;

			if (rect.Size.Width > 5 & rect.Size.Height > 5) {
				using(GraphicsPath path = new GraphicsPath()) {
					DrawArc(rect, path);
					g.FillPath(BackgroundBrush, path);
					g.DrawPath(BackgroundPen, path);
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			//base.OnPaint(e);
		}

		protected override void OnPaintGrip(PaintEventArgs e) {
			//base.OnPaintGrip(e);
		}

		public void DrawArc(Rectangle rect, GraphicsPath graphicsPath) {
			const int Radius = 5;
			graphicsPath.AddArc(rect.X, rect.Y, Radius, Radius, 180, 90);
			graphicsPath.AddArc(rect.Width - Radius, rect.Y, Radius, Radius, 270, 90);
			graphicsPath.AddArc(rect.Width - Radius, rect.Height - Radius, Radius, Radius, 0, 90);
			graphicsPath.AddArc(rect.X, rect.Height - Radius, Radius, Radius, 90, 90);
			graphicsPath.CloseFigure();
		}

		public Rectangle Deflate(Rectangle re) {
			return new Rectangle(re.X + 1, re.Y + 1, re.Width - 2, re.Height - 2);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				BackgroundBrush = null;
				BackgroundPen = null;
			}

			base.Dispose(disposing);
		}
	}
}
