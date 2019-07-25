using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace smartpos.wpos.App.Components.UserDefined.Button
{
    public class RibbonMenuRenderer : ToolStripProfessionalRenderer
    {
        private const int OffsetX = 3;
        private const int OffsetY = 2;
        private const int B0 = 78;
        private const int G0 = 214;
        private const int R0 = 255;

        private int imageheight;
        private int imagewidth;

        private Color strokeColor = Color.FromArgb(196, 177, 118);
        private Pen strokeColorPen;

        public Color StrokeColor
        {
            get { return strokeColor; }

            set
            {
                if (strokeColor != value)
                {
                    strokeColor = value;
                    StrokeColorPen = null;
                }
            }
        }

        private Pen StrokeColorPen
        {
            get
            {
                if (strokeColorPen == null)
                {
                    strokeColorPen = new Pen(strokeColor);
                }

                return strokeColorPen;
            }

            set
            {
                if (strokeColorPen != null)
                {
                    strokeColorPen.Dispose();
                }

                strokeColorPen = value;
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality;

                using (GraphicsPath graphicsPath = new GraphicsPath())
                {
                    Rectangle rect = new Rectangle(
                                            2, 1,
                                            e.Item.Size.Width - 2,
                                            e.Item.Size.Height - 1
                                            );

                    DrawArc(rect, graphicsPath);

                    using (LinearGradientBrush lgbrush =
                        new LinearGradientBrush(
                            rect,
                            Color.White,
                            Color.White,
                            LinearGradientMode.Vertical))
                    {
                        float[] pos = new float[4];
                        pos[0] = 0.0F;
                        pos[1] = 0.4F;
                        pos[2] = 0.45F;
                        pos[3] = 1.0F;
                        Color[] colors = new Color[4];
                        colors[0] = GetColor(0, 50, 100);
                        colors[1] = GetColor(0, 0, 30);
                        colors[2] = Color.FromArgb(R0, G0, B0);
                        colors[3] = GetColor(0, 50, 100);

                        ColorBlend mix = new ColorBlend { Colors = colors, Positions = pos };
                        lgbrush.InterpolationColors = mix;
                        g.FillPath(lgbrush, graphicsPath);
                        g.DrawPath(StrokeColorPen, graphicsPath);
                    }
                }
            }
            else
            {
                base.OnRenderItemBackground(e);
            }
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (e.Image == null)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            imageheight = e.Item.Height - OffsetY * 2;
            imagewidth = (int)((Convert.ToDouble(imageheight) / e.Image.Height) * e.Image.Width);
            e.Graphics.DrawImage(e.Image, new Rectangle(OffsetX, OffsetY, imagewidth, imageheight));
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // base.OnRenderToolStripBorder(e);
        }

        #region Paint Methods
        public void DrawArc(Rectangle re, GraphicsPath pa)
        {
            const int Radius = 6;
            pa.AddArc(re.X, re.Y, Radius, Radius, 180, 90);
            pa.AddArc(re.Width - Radius, re.Y, Radius, Radius, 270, 90);
            pa.AddArc(re.Width - Radius, re.Height - Radius, Radius, Radius, 0, 90);
            pa.AddArc(re.X, re.Height - Radius, Radius, Radius, 90, 90);
            pa.CloseFigure();
        }

        public Rectangle Deflate(Rectangle re)
        {
            return new Rectangle(re.X, re.Y, re.Width - 1, re.Height - 1);
        }

        public Color GetColor(int R, int G, int B)
        {
            if (R + R0 > 255)
            {
                R = 255;
            }
            else
            {
                R = R + R0;
            }
            if (G + G0 > 255)
            {
                G = 255;
            }
            else
            {
                G = G + G0;
            }
            if (B + B0 > 255)
            {
                B = 255;
            }
            else
            {
                B = B + B0;
            }

            return Color.FromArgb(R, G, B);
        }
        #endregion
    }
}
