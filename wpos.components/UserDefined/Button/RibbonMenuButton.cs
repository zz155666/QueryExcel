using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace smartpos.wpos.App.Components.UserDefined.Button
{
    public class RibbonMenuButton : System.Windows.Forms.Button
    {
        #region Static Fields
        /// <summary>
        /// Standard gray-scale conversion for images
        /// </summary>
        /// <remarks>
        /// This is a very generic definition and is defined as <see langword="static"/> so
        /// that it can be shared by all instances 
        /// </remarks>
        private static ImageAttributes grayScaleAttributes;
        #endregion Static Fields

        #region Color Fields
        private int alpha;
        private int blue;
        private int green;
        private int red;

        private Color baseColor = Color.FromArgb(255,128,0);
        private Color colorStroke = Color.FromArgb(255, 192, 0);
        private Color onColor = Color.Orange;
        private Color pressedColor = Color.FromArgb(255, 192, 0);
        private Color colorOnStroke;
        private Color colorPressedStroke;
        #endregion Color Fields

        #region Cached Drawing Objects
        private Font boldFont;
        private Font italicFont;
        private SolidBrush fillBandBrush;
        private SolidBrush fillSplitBrush;
        private Pen lightShadowPen;
        private Pen darkShadowPen;
        private Pen thinColorStrokePen;
        private Pen colorOnStrokePen;
        private Pen colorPressedStrokePen;
        private SolidBrush disabledForeColorBrush;
        private SolidBrush foreColorBrush;
        #endregion Cached Drawing Objects

        #region Button Property Fields
        private ArrowStyle arrowStyle;
        private GroupPositionStyle groupPosition;
        private bool isPressed;
        private bool keepPressed;
        private int radius = 6;
        private bool showBase;
        private bool isSplitButton;
        private int splitDistance;
        private bool activeShowBase;
        private string title = String.Empty;
        private ImageLocationType imageLocation;
        private RibbonMenuButtonState ribbonMenuButtonState;
        #endregion Button Property Fields

        #region Image Fields (runtime)
        private int imageheight, imagewidth;
        private int imageOffsetX, imageOffsetY;
        #endregion Image Fields (runtime)

        #region About Constructor
        public RibbonMenuButton()
        {
            MenuPosition = new Point(0, 0);
            ColorPressedStroke = Color.FromArgb(255, 255, 255);
            ColorOnStroke = Color.FromArgb(255, 255, 255);
            ColorBaseStroke = Color.FromArgb(255, 255, 255);
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.Opaque, false);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.Transparent;

            fadeTimer.Interval = 5;
            fadeTimer.Tick += TimerTick;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            alpha = ColorBase.A;
            red = ColorBase.R;
            green = ColorBase.G;
            blue = ColorBase.B;
            ColorStroke = ColorBaseStroke;

            Rectangle r = new Rectangle(new Point(-1, -1), new Size(Width + radius, Height + radius));

            // Transform to SmoothRectangle Region
            if (!Size.IsEmpty)
            {
                GraphicsPath pathregion = new GraphicsPath();
                AddArcPath(radius, GroupPosition, r, pathregion);
                Region = new Region(pathregion);
            }

            activeShowBase = ShowBase;
            RibbonMenuButtonState = (KeepPressed && IsPressed)
                                        ? RibbonMenuButtonState.Pressed
                                        : RibbonMenuButtonState.None;
        }
        #endregion

        #region About Image Settings
        /// <summary>
        /// Returns the standard grayscale matrix for image transformations
        /// </summary>
        [Browsable(false)]
        public static ImageAttributes GrayScaleAttributes
        {
            get
            {
                // prevent two of these from being created concurrently by locking the class
                lock (typeof(RibbonMenuButton))
                {
                    if (grayScaleAttributes == null)
                    {
                        ColorMatrix matrix = new ColorMatrix();
                        matrix.Matrix00 = 1 / 3f;
                        matrix.Matrix01 = 1 / 3f;
                        matrix.Matrix02 = 1 / 3f;
                        matrix.Matrix10 = 1 / 3f;
                        matrix.Matrix11 = 1 / 3f;
                        matrix.Matrix12 = 1 / 3f;
                        matrix.Matrix20 = 1 / 3f;
                        matrix.Matrix21 = 1 / 3f;
                        matrix.Matrix22 = 1 / 3f;

                        grayScaleAttributes = new ImageAttributes();

                        grayScaleAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    }
                }

                return grayScaleAttributes;
            }
        }

        public ImageLocationType ImageLocation
        {
            get { return imageLocation; }
            set
            {
                imageLocation = value;
                Refresh();
            }
        }

        public int ImageOffset { get; set; }

        public Point MaxImageSize { get; set; }
        #endregion

        #region About Button Settings
        public bool ShowBase
        {
            get { return showBase; }
            set
            {
                showBase = value;
                Refresh();
            }
        }

        public int Radius
        {
            get { return radius; }
            set
            {
                if (radius > 0)
                {
                    radius = value;
                }
                Refresh();
            }
        }

        public GroupPositionStyle GroupPosition
        {
            get { return groupPosition; }
            set
            {
                groupPosition = value;
                Refresh();
            }
        }

        public ArrowStyle ArrowStyle
        {
            get { return arrowStyle; }
            set
            {
                arrowStyle = value;
                Refresh();
            }
        }

        public bool IsSplitButton
        {
            get { return isSplitButton; }
            set
            {
                isSplitButton = value;
                Refresh();
            }
        }

        public int SplitDistance
        {
            get { return splitDistance; }
            set
            {
                splitDistance = value;
                Refresh();
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                Refresh();
            }
        }

        public bool KeepPressed
        {
            get { return keepPressed; }
            set { keepPressed = value; }
        }

        public bool IsPressed
        {
            get { return isPressed; }
            set { isPressed = value; }
        }

        private RibbonMenuButtonState RibbonMenuButtonState
        {
            get
            {
                return ribbonMenuButtonState;
            }

            set
            {
                if ((keepPressed && isPressed) &&
                    (value != RibbonMenuButtonState.Pressed))
                {
                    return;
                }

                if (ribbonMenuButtonState != value)
                {
                    ribbonMenuButtonState = value;
                    OnButtonStateChange(ribbonMenuButtonState);
                }
            }
        }
        #endregion

        #region Menu Pos
        public Point MenuPosition { get; set; }
        #endregion

        #region Colors
        public Color ColorBase
        {
            get { return baseColor; }
            set
            {
                if (value != baseColor)
                {
                    baseColor = value;
                    red = baseColor.R;
                    blue = baseColor.B;
                    green = baseColor.G;
                    alpha = baseColor.A;
                    RibbonColor hsb = new RibbonColor(baseColor);
                    hsb.SetBrightness(hsb.Blue < 50 ? 60 : 30);
                    ColorBaseStroke = Color.FromArgb(baseColor.A > 0 ? 100 : 0, hsb.GetColor());
                    ForeColorBrush = null;
                    DisabledForeColorBrush = null;
                    Refresh();
                }
            }
        }

        private Color ColorStroke
        {
            get
            {
                return colorStroke;
            }

            set
            {
                if (colorStroke != value)
                {
                    colorStroke = value;
                    ThinColorStrokePen = null;
                }
            }
        }

        public Color ColorOn
        {
            get { return onColor; }
            set
            {
                if (onColor != value)
                {
                    onColor = value;

                    RibbonColor hsb = new RibbonColor(onColor);
                    hsb.SetBrightness(hsb.Blue < 50 ? 60 : 30);
                    ColorOnStroke = Color.FromArgb(ColorBaseStroke.A > 0 ? 100 : 0, hsb.GetColor());
                    Refresh();
                }
            }
        }

        public Color ColorPressed
        {
            get { return pressedColor; }
            set
            {
                if (pressedColor != value)
                {
                    pressedColor = value;

                    RibbonColor hsb = new RibbonColor(pressedColor);
                    hsb.SetBrightness(hsb.Blue < 50 ? 60 : 30);
                    ColorPressedStroke = Color.FromArgb(
                        ColorBaseStroke.A > 0 ? 100 : 0, hsb.GetColor()
                        );
                    ColorPressedStrokePen = null;
                    Refresh();
                }
            }
        }

        public Color ColorBaseStroke { get; set; }

        public Color ColorOnStroke
        {
            get
            {
                return colorOnStroke;
            }

            set
            {
                if (colorOnStroke != value)
                {
                   colorOnStroke = value;
                    ColorOnStrokePen = null;
                }
            }
        }

        public Color ColorPressedStroke
        {
            get
            {
                return colorPressedStroke;
            }

            set
            {
                if (colorPressedStroke != value)
                {
                    colorPressedStroke = value;
                    ColorPressedStrokePen = null;
                }
            }
        }

        public static Color GetColorIncreased(Color color, int h, int s, int b)
        {
            RibbonColor ribbonColor = new RibbonColor(color);
            int ss = ribbonColor.GetSaturation();
            float vc = b + ribbonColor.GetBrightness();
            float hc = h + ribbonColor.GetHue();
            float sc = s + ss;

            ribbonColor.Value = vc;
            ribbonColor.Hue = hc;
            ribbonColor.Saturation = sc;

            return ribbonColor.GetColor();
        }

        public Color GetColor(int alphaMod, int redMod, int greenMod, int blueMod)
        {
            alphaMod = Math.Min(alphaMod + alpha, 255);
            redMod = Math.Min(redMod + red, 255);
            greenMod = Math.Min(greenMod + green, 255);
            blueMod = Math.Min(blueMod + blue, 255);

            return Color.FromArgb(alphaMod, redMod, greenMod, blueMod);
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.High;

            FillGradients(g);

            DrawImage(g);
            DrawString(g);
            DrawArrow(g);
        }

        protected override void OnResize(EventArgs e)
        {
            if (!Size.IsEmpty)
            {
                Rectangle rect = new Rectangle(
                        new Point(-1, -1),
                        new Size(Width + Radius, Height + Radius)
                        );

                using (GraphicsPath pathregion = new GraphicsPath())
                {
                    AddArcPath(radius, GroupPosition, rect, pathregion);
                    Region = new Region(pathregion);
                }
            }
            base.OnResize(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            BoldFont = null;
            ItalicFont = null;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            ForeColorBrush = null;
            DisabledForeColorBrush = null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FillSplitBrush = null;
                FillBandBrush = null;
                ForeColorBrush = null;
                ColorOnStrokePen = null;
                ColorPressedStrokePen = null;
                ThinColorStrokePen = null;
                DarkShadowPen = null;
                LightShadowPen = null;
                BoldFont = null;
                ItalicFont = null;
            }

            base.Dispose(disposing);
        }
        #endregion Overrides

        #region Paint Methods
        private SolidBrush FillSplitBrush
        {
            get
            {
                return fillSplitBrush ?? (fillSplitBrush =
                    new SolidBrush(Color.FromArgb(200, 255, 255, 255)));
            }

            set
            {
                if (fillSplitBrush != null)
                {
                    fillSplitBrush.Dispose();
                }

                fillSplitBrush = value;
            }
        }

        private SolidBrush FillBandBrush
        {
            get
            {
                return fillBandBrush ?? (fillBandBrush =
                       new SolidBrush(Color.FromArgb(60, 255, 255, 255)));
            }

            set
            {
                if (fillBandBrush != null)
                {
                    fillBandBrush.Dispose();
                }

                fillBandBrush = value;
            }
        }

        private Pen LightShadowPen
        {
            get
            {
                return lightShadowPen ??
                    (lightShadowPen = new Pen(Color.FromArgb(100, 250, 250, 250), 3.0F));
            }

            set
            {
                if (lightShadowPen != null)
                {
                    lightShadowPen.Dispose();
                }

                lightShadowPen = value;
            }
        }

        private Pen DarkShadowPen
        {
            get
            {
                return darkShadowPen ?? (darkShadowPen =
                    new Pen(Color.FromArgb(50, 20, 20, 20), 2.0F));
            }

            set
            {
                if (darkShadowPen != null)
                {
                    darkShadowPen.Dispose();
                }

                darkShadowPen = value;
            }
        }

        private Pen ThinColorStrokePen
        {
            get
            {
                return thinColorStrokePen ??
                    (thinColorStrokePen = new Pen(ColorStroke, 0.9F));
            }

            set
            {
                if (thinColorStrokePen != null)
                {
                    thinColorStrokePen.Dispose();
                }

                thinColorStrokePen = value;
            }
        }

        private Pen ColorOnStrokePen
        {
            get
            {
                return colorOnStrokePen ??
                  (colorOnStrokePen = new Pen(ColorOnStroke));
            }

            set
            {
                if (colorOnStrokePen != null)
                {
                    colorOnStrokePen.Dispose();
                }

                colorOnStrokePen = value;
            }
        }

        private Pen ColorPressedStrokePen
        {
            get
            {
                return colorPressedStrokePen ??
                  (colorPressedStrokePen = new Pen(ColorPressedStroke));
            }

            set
            {
                if (colorPressedStrokePen != null)
                {
                    colorPressedStrokePen.Dispose();
                }

                colorPressedStrokePen = value;
            }
        }

        private Font BoldFont
        {
            get { return boldFont ?? (boldFont = new Font(Font, FontStyle.Bold)); }

            set
            {
                if (boldFont != null)
                {
                    boldFont.Dispose();
                }

                boldFont = value;
            }
        }

        private Font ItalicFont
        {
            get
            {
                return italicFont ?? (italicFont = new Font(Font, FontStyle.Italic));
            }

            set
            {
                if (italicFont != null)
                {
                    italicFont.Dispose();
                }

                italicFont = value;
            }
        }

        private SolidBrush ForeColorBrush
        {
            get
            {
                if (foreColorBrush == null)
                {
                    RibbonColor ribbonColor = new RibbonColor(Color.FromArgb(red, green, blue));
                    RibbonColor foreColor = new RibbonColor(ForeColor);

//                    if (ribbonColor.GetBrightness() > 50)
//                    {
//                        foreColor.Blue = 1;
//                        foreColor.Saturation = 80;
//                    }
//                    else
//                    {
//                        foreColor.Blue = 99;
//                        foreColor.Saturation = 20;
//                    }
                    foreColor.Blue = 255;
                    foreColor.Saturation = 0;
                    foreColorBrush = new SolidBrush(foreColor.GetColor());
                }

                return foreColorBrush;
            }

            set
            {
                if (foreColorBrush != null)
                {
                    foreColorBrush.Dispose();
                }

                foreColorBrush = value;
            }
        }

        private SolidBrush DisabledForeColorBrush
        {
            get
            {
                if (disabledForeColorBrush == null)
                {
                    RibbonColor ribbonColor = new RibbonColor(Color.FromArgb(red, green, blue));
                    RibbonColor foreColor = new RibbonColor(ForeColor);

                    if (ribbonColor.GetBrightness() > 50)
                    {
                        foreColor.Blue = 1;
                        foreColor.Saturation = 80;
                    }
                    else
                    {
                        foreColor.Blue = 99;
                        foreColor.Saturation = 20;
                    }
                    disabledForeColorBrush = new SolidBrush(foreColor.GetGrayScaleColor());
                }

                return disabledForeColorBrush;
            }

            set
            {
                if (disabledForeColorBrush != null)
                {
                    disabledForeColorBrush.Dispose();
                }

                disabledForeColorBrush = value;
            }
        }

        public void FillGradients(Graphics graphics)
        {
            if (!activeShowBase)
            {
                return;
            }

            Rectangle rect = new Rectangle(
                Point.Empty,
                new Size(Width - 1, Height - 1)
                );

            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                AddArcPath(radius, GroupPosition, rect, graphicsPath);

                using (LinearGradientBrush lgbrush = new LinearGradientBrush(
                    rect,
                    Color.Transparent,
                    Color.Transparent,
                    LinearGradientMode.Vertical
                    ))
                {
                    float[] pos = new[] { 0.0f, 0.3f, 0.35f, 1.0f };

                    Color[] colors = new Color[4];
                    if (Enabled)
                    {
                        if (RibbonMenuButtonState == RibbonMenuButtonState.None)
                        {
                            colors[0] = GetColor(0, 35, 24, 9);
                            colors[1] = GetColor(0, 13, 8, 3);
                            colors[2] = Color.FromArgb(alpha, red, green, blue);
                            colors[3] = GetColor(0, 28, 29, 14);
                        }
                        else
                        {
                            colors[3] = colors[0] = GetColor(0, 0, 50, 100);
                            colors[1] = GetColor(0, 0, 0, 30);
                            colors[2] = Color.FromArgb(alpha, red, green, blue);
                        }
                    }
                    else
                    {
                        RibbonColor rc = new RibbonColor(GetColor(0, 0, 50, 100));
                        colors[3] = colors[0] = rc.GetGrayScaleColor();

                        rc = new RibbonColor(GetColor(0, 0, 0, 30));
                        colors[1] = rc.GetGrayScaleColor();

                        rc = new RibbonColor(Color.FromArgb(alpha, red, green, blue));
                        colors[2] = rc.GetGrayScaleColor();
                    }

                    ColorBlend mix = new ColorBlend { Colors = colors, Positions = pos };
                    lgbrush.InterpolationColors = mix;
                    graphics.FillPath(lgbrush, graphicsPath);
                }
            }

            rect = new Rectangle(
                Point.Empty,
                new Size(Width, Height / 3)
                );

            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                AddArcPath(radius - 1, GroupPosition, rect, graphicsPath);
                if (alpha > 80)
                {
                    graphics.FillPath(FillBandBrush, graphicsPath);
                }
            }

            if (isSplitButton & mouseCapture)
            {
                FillSplit(graphics);
            }

            if (RibbonMenuButtonState == RibbonMenuButtonState.Pressed && mouseCapture)
            {
                rect = new Rectangle(1, 1, Width - 2, Height);
                using (GraphicsPath graphicsPath = new GraphicsPath())
                {
                    AddShadowPath(radius, GroupPosition, rect, graphicsPath);
                    graphics.DrawPath(DarkShadowPen, graphicsPath);
                }
            }
            else
            {
                rect = new Rectangle(1, 1, Width - 2, Height - 1);
                using (GraphicsPath graphicsPath = new GraphicsPath())
                {
                    AddShadowPath(radius, GroupPosition, rect, graphicsPath);
                    if (alpha > 80)
                    {
                        graphics.DrawPath(LightShadowPen, graphicsPath);
                    }
                }
            }

            if (isSplitButton)
            {
                if (imageLocation == ImageLocationType.Top)
                {
                    switch (RibbonMenuButtonState)
                    {
                        case RibbonMenuButtonState.Highlight:
                            graphics.DrawLine(
                                ColorOnStrokePen,
                                new Point(1, Height - splitDistance),
                                new Point(Width - 1, Height - splitDistance)
                                );
                            break;
                        case RibbonMenuButtonState.Pressed:
                            graphics.DrawLine(
                                ColorPressedStrokePen,
                                new Point(1, Height - splitDistance),
                                new Point(Width - 1, Height - splitDistance)
                                );
                            break;
                    }
                }
                else if ((imageLocation == ImageLocationType.Left) ||
                      (imageLocation == ImageLocationType.None))
                {
                    switch (RibbonMenuButtonState)
                    {
                        case RibbonMenuButtonState.Highlight:
                            graphics.DrawLine(
                                ColorOnStrokePen,
                                new Point(Width - splitDistance, 0),
                                new Point(Width - splitDistance, Height)
                                );
                            break;
                        case RibbonMenuButtonState.Pressed:
                            graphics.DrawLine(
                                ColorPressedStrokePen,
                                new Point(Width - splitDistance, 0),
                                new Point(Width - splitDistance, Height)
                                );
                            break;
                    }
                }
            }

            rect = new Rectangle(new Point(0, 0), new Size(Width - 1, Height - 1));
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                AddArcPath(radius, GroupPosition, rect, graphicsPath);
                graphics.DrawPath(ThinColorStrokePen, graphicsPath);
            }
        }

        public void DrawImage(Graphics graphics)
        {
            if (Image == null || (ImageLocation == ImageLocationType.None))
            {
                return;
            }

            imageOffsetY = ImageOffset;
            imageOffsetX = ImageOffset;

            if (imageLocation == ImageLocationType.Left | imageLocation == ImageLocationType.Right)
            {
                imageheight = Height - imageOffsetY * 2;
                if (imageheight > MaxImageSize.Y & MaxImageSize.Y != 0)
                {
                    imageheight = MaxImageSize.Y;
                }
                imagewidth = (int)((double)imageheight / Image.Height) * Image.Width;
            }
            else if (imageLocation == ImageLocationType.Top | imageLocation == ImageLocationType.Bottom)
            {
                imagewidth = Width - imageOffsetX * 2;
                if (imagewidth > MaxImageSize.X & MaxImageSize.X != 0)
                {
                    imagewidth = MaxImageSize.X;
                }
                imageheight = (int)((double)imagewidth / Image.Width) * Image.Height;
            }

            Rectangle rect = Rectangle.Empty;

            switch (imageLocation)
            {
                case ImageLocationType.Left:
                    rect = new Rectangle(imageOffsetX, imageOffsetY, imagewidth, imageheight);
                    break;
                case ImageLocationType.Right:
                    rect = new Rectangle(Width - imagewidth - imageOffsetX, imageOffsetY, imagewidth, imageheight);
                    break;
                case ImageLocationType.Top:
                    imageOffsetX = Width / 2 - imagewidth / 2;
                    rect = new Rectangle(imageOffsetX, imageOffsetY, imagewidth, imageheight);
                    break;
                case ImageLocationType.Bottom:
                    rect = new Rectangle(imageOffsetX, Height - imageheight - imageOffsetY, imagewidth, imageheight);
                    break;
            }

            if (!rect.IsEmpty)
            {
                graphics.DrawImage(
                    Image,
                    rect,
                    0, 0, Image.Width, Image.Height,
                    GraphicsUnit.Pixel,
                    Enabled ? null : GrayScaleAttributes
                    );
            }
        }


        private PointF GetTextAlignment(int textWidth, int textHeight)
        {
            float x = Padding.Left;
            float y = Padding.Top;

            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    y = Height - textHeight - Padding.Bottom;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    y = (Height - textHeight) / 2.0f;
                    break;
            }

            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.MiddleLeft:
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    x = (Width - textWidth);
                    if (IsSplitButton && (ImageLocation != ImageLocationType.Top))
                    {
                        if (ArrowStyle != ArrowStyle.None)
                        {
                            x -= SplitDistance;
                        }
                    }
                    x /= 2;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    x = Width - textWidth - Padding.Right;

                    if (IsSplitButton && (ImageLocation != ImageLocationType.Top))
                    {
                        if (ArrowStyle != ArrowStyle.None)
                        {
                            x -= SplitDistance;
                        }
                    }
                    break;
            }

            return new PointF(x, y);
        }

        /*
         *  This is the correct way to Draw the disabled text, but given the number
         *  of calls I decided to settle for basic style changes (font,brush)
         *  
            // draw the text disabled using the (using a method provided by the framework)
            ControlPaint.DrawStringDisabled(
                            graphics, 
                            Text, 
                            ItalicFont,
                            SystemColors.GrayText,
                            textRectF, 
                            DrawTextFormat
                            );
         * */

        public void DrawString(Graphics graphics)
        {
            if (!String.IsNullOrEmpty(Text))
            {
                int textwidth = (int)graphics.MeasureString(Text, Font).Width;
                int textheight = (int)graphics.MeasureString(Text, Font).Height;

                int extraoffset = 0;
                if (!String.IsNullOrEmpty(title))
                {
                    extraoffset = textheight / 2;
                }

                string s1 = Text;
                string s2 = String.Empty;
                int jump = Text.IndexOf("\\n");

                if (jump != -1)
                {
                    s2 = s1.Substring(jump + 3);
                    s1 = s1.Substring(0, jump);
                }

                SolidBrush brush = Enabled ? ForeColorBrush : DisabledForeColorBrush;
                Font font = Enabled ? Font : ItalicFont;

                switch (imageLocation)
                {
                    case ImageLocationType.None:
                        graphics.DrawString(
                            s1,
                            font,
                            brush,
                            GetTextAlignment(textwidth, textheight)
                            );
                        break;
                    case ImageLocationType.Left:
                        if (!String.IsNullOrEmpty(Title))
                        {
                            graphics.DrawString(
                                Title,
                                Enabled ? BoldFont : ItalicFont,
                                brush,
                                new PointF(imageOffsetX + imagewidth + 4, Font.Size / 2)
                                );
                            graphics.DrawString(
                                s1,
                                font,
                                brush,
                                new PointF(imageOffsetX + imagewidth + 4, 2 * Font.Size + 1)
                                );
                            graphics.DrawString(
                                s2,
                                font,
                                brush,
                                new PointF(imageOffsetX + imagewidth + 4, 3 * Font.Size + 4)
                                );
                        }
                        else
                        {
                            graphics.DrawString(
                                s1,
                                font,
                                brush,
                                new PointF(imageOffsetX + imagewidth + 4, Height / 2 - Font.Size + 1)
                                );
                        }
                        break;
                    case ImageLocationType.Right:
                        graphics.DrawString(
                            Title,
                            Enabled ? BoldFont : ItalicFont,
                            brush,
                            new PointF(imageOffsetX, Height / 2 - Font.Size + 1 - extraoffset)
                            );
                        graphics.DrawString(
                            Text,
                            font,
                            brush,
                            new PointF(imageOffsetX, extraoffset + Height / 2 - Font.Size + 1)
                            );
                        break;
                    case ImageLocationType.Top:
                        graphics.DrawString(
                            Text,
                            font,
                            brush,
                            new PointF(Width / 2 - textwidth / 2 - 1, imageOffsetY + imageheight)
                            );
                        break;
                    case ImageLocationType.Bottom:
                        graphics.DrawString(
                            Text,
                            font,
                            brush,
                            new PointF(Width / 2 - textwidth / 2 - 1, Height - imageheight - textheight - 1)
                            );
                        break;
                }
            }
        }

        public static GraphicsPath AddArcPath(
                int arcRadius,
                GroupPositionStyle groupPositionStyle,
                Rectangle re,
                GraphicsPath graphicsPath
                )
        {
            int radiusX0Y0 = arcRadius;
            int radiusXfy0 = arcRadius;
            int radiusX0Yf = arcRadius;
            int radiusXfyf = arcRadius;

            switch (groupPositionStyle)
            {
                case GroupPositionStyle.Left:
                    radiusXfy0 = 1;
                    radiusXfyf = 1;
                    break;
                case GroupPositionStyle.Center:
                    radiusX0Y0 = 1;
                    radiusX0Yf = 1;
                    radiusXfy0 = 1;
                    radiusXfyf = 1;
                    break;
                case GroupPositionStyle.Right:
                    radiusX0Y0 = 1;
                    radiusX0Yf = 1;
                    break;
                case GroupPositionStyle.Top:
                    radiusX0Yf = 1;
                    radiusXfyf = 1;
                    break;
                case GroupPositionStyle.Bottom:
                    radiusX0Y0 = 1;
                    radiusXfy0 = 1;
                    break;
            }

            graphicsPath = graphicsPath ?? new GraphicsPath();

            graphicsPath.AddArc(re.X, re.Y, radiusX0Y0, radiusX0Y0, 180, 90);
            graphicsPath.AddArc(re.Width - radiusXfy0, re.Y, radiusXfy0, radiusXfy0, 270, 90);
            graphicsPath.AddArc(re.Width - radiusXfyf, re.Height - radiusXfyf, radiusXfyf, radiusXfyf, 0, 90);
            graphicsPath.AddArc(re.X, re.Height - radiusX0Yf, radiusX0Yf, radiusX0Yf, 90, 90);
            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        public static GraphicsPath AddShadowPath(
                        int arcRadius,
                        GroupPositionStyle groupPositionStyle,
                        Rectangle re,
                        GraphicsPath graphicsPath
                        )
        {
            int radiusX0Y0 = arcRadius;
            int radiusXfy0 = arcRadius;
            int radiusX0Yf = arcRadius;
            int radiusXfyf = arcRadius;

            switch (groupPositionStyle)
            {
                case GroupPositionStyle.Left:
                    radiusXfy0 = 1;
                    radiusXfyf = 1;
                    break;
                case GroupPositionStyle.Center:
                    radiusX0Y0 = 1;
                    radiusX0Yf = 1;
                    radiusXfy0 = 1;
                    radiusXfyf = 1;
                    break;
                case GroupPositionStyle.Right:
                    radiusX0Y0 = 1;
                    radiusX0Yf = 1;
                    break;
                case GroupPositionStyle.Top:
                    radiusX0Yf = 1;
                    radiusXfyf = 1;
                    break;
                case GroupPositionStyle.Bottom:
                    radiusX0Y0 = 1;
                    radiusXfy0 = 1;
                    break;
            }

            graphicsPath = graphicsPath ?? new GraphicsPath();

            graphicsPath.AddArc(re.X, re.Y, radiusX0Y0, radiusX0Y0, 180, 90);
            graphicsPath.AddArc(re.Width - radiusXfy0, re.Y, radiusXfy0, radiusXfy0, 270, 90);
            graphicsPath.AddArc(re.Width - radiusXfyf, re.Height - radiusXfyf, radiusXfyf, radiusXfyf, 0, 90);
            graphicsPath.AddArc(re.X, re.Height - radiusX0Yf, radiusX0Yf, radiusX0Yf, 90, 90);
            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        public void DrawArrow(Graphics graphics)
        {
            const int size = 1;

            switch (arrowStyle)
            {
                case ArrowStyle.ToDown:
                    if ((imageLocation == ImageLocationType.Left) ||
                        (imageLocation == ImageLocationType.None))
                    {
                        Point[] points = new Point[3];
                        points[0] = new Point(Width - 8 * size - ImageOffset, Height / 2 - size / 2);
                        points[1] = new Point(Width - 2 * size - ImageOffset, Height / 2 - size / 2);
                        points[2] = new Point(Width - 5 * size - ImageOffset, Height / 2 + size * 2);
                        graphics.FillPolygon(ForeColorBrush, points);
                    }
                    else if (imageLocation == ImageLocationType.Top)
                    {
                        Point[] points = new Point[3];
                        points[0] = new Point(Width / 2 + 8 * size - ImageOffset, Height - ImageOffset - 5 * size);
                        points[1] = new Point(Width / 2 + 2 * size - ImageOffset, Height - ImageOffset - 5 * size);
                        points[2] = new Point(Width / 2 + 5 * size - ImageOffset, Height - ImageOffset - 2 * size);
                        graphics.FillPolygon(ForeColorBrush, points);
                    }
                    break;
                case ArrowStyle.ToRight:
                    if ((imageLocation == ImageLocationType.Left) ||
                        (imageLocation == ImageLocationType.None))
                    {
                        int splitStart = Width - splitDistance;
                        int arrowSize = Math.Max(4, (int)(splitDistance * .25));
                        int arrowxpos = splitStart + ((splitDistance - 6) >> 1);

                        Point[] points = new Point[3];
                        points[0] = new Point(arrowxpos, Height / 2 - 4 * size);
                        points[1] = new Point(arrowxpos + arrowSize, Height / 2);
                        points[2] = new Point(arrowxpos, Height / 2 + 4 * size);

                        graphics.FillPolygon(ForeColorBrush, points);
                    }
                    break;
            }
        }

        public void FillSplit(Graphics graphics)
        {
            int x1 = Width - splitDistance;
            int x2 = 0;
            int y1 = Height - splitDistance;
            int y2 = 0;

            Rectangle rectangle = Rectangle.Empty;

            if (imageLocation == ImageLocationType.Left)
            {
                // Small button
                if (mouseX < Width - splitDistance & mouseCapture)
                {
                    rectangle = new Rectangle(x1 + 1, 1, Width - 2, Height - 1);
                    // Big Button
                }
                else if (mouseCapture)
                {
                    rectangle = new Rectangle(x2 + 1, 1, Width - splitDistance - 1, Height - 1);
                }
            }
            else if (imageLocation == ImageLocationType.Top)
            {
                // Small button
                if (mouseY < Height - splitDistance & mouseCapture)
                {
                    rectangle = new Rectangle(1, y1 + 1, Width - 1, Height - 1);
                    // Big Button
                }
                else if (mouseCapture)
                {
                    rectangle = new Rectangle(1, y2 + 1, Width - 1, Height - splitDistance - 1);
                }
            }

            if (!rectangle.IsEmpty)
            {
                using (GraphicsPath p = new GraphicsPath())
                {
                    graphics.FillPath(FillSplitBrush, AddArcPath(4, GroupPosition, rectangle, p));
                }
            }
        }
        #endregion

        #region About Fading
        private readonly Timer fadeTimer = new Timer();
        private int fadeAlpha = 1;
        private int fadeBlue = 1;
        private int fadeGreen = 1;
        private int fadeRed = 1;
        private int fadeSpeed = 35;

        public int FadeSpeed
        {
            get { return fadeSpeed; }
            set
            {
                if (value > -1)
                {
                    fadeSpeed = value;
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (RibbonMenuButtonState ==RibbonMenuButtonState.Highlight)
            {
                fadeRed = Math.Abs(ColorOn.R - red) > fadeSpeed ? fadeSpeed : 1;
                fadeGreen = Math.Abs(ColorOn.G - green) > fadeSpeed ? fadeSpeed : 1;

                fadeBlue = Math.Abs(ColorOn.B - blue) > fadeSpeed ? fadeSpeed : 1;

                if (ColorOn.R < red)
                {
                    red -= fadeRed;
                }
                else if (ColorOn.R > red)
                {
                    red += fadeRed;
                }

                if (ColorOn.G < green)
                {
                    green -= fadeGreen;
                }
                else if (ColorOn.G > green)
                {
                    green += fadeGreen;
                }

                if (ColorOn.B < blue)
                {
                    blue -= fadeBlue;
                }
                else if (ColorOn.B > blue)
                {
                    blue += fadeBlue;
                }

                if (ColorOn == Color.FromArgb(red, green, blue))
                {
                    fadeTimer.Stop();
                }
            }

            if (RibbonMenuButtonState == RibbonMenuButtonState.None)
            {
                fadeRed = Math.Abs(ColorBase.R - red) < fadeSpeed ? 1 : fadeSpeed;
                fadeGreen = Math.Abs(ColorBase.G - green) < fadeSpeed ? 1 : fadeSpeed;
                fadeBlue = Math.Abs(ColorBase.B - blue) < fadeSpeed ? 1 : fadeSpeed;
                fadeAlpha = Math.Abs(ColorBase.A - alpha) < fadeSpeed ? 1 : fadeSpeed;

                if (ColorBase.R < red)
                {
                    red -= fadeRed;
                }
                else if (ColorBase.R > red)
                {
                    red += fadeRed;
                }
                if (ColorBase.G < green)
                {
                    green -= fadeGreen;
                }
                else if (ColorBase.G > green)
                {
                    green += fadeGreen;
                }
                if (ColorBase.B < blue)
                {
                    blue -= fadeBlue;
                }
                else if (ColorBase.B > blue)
                {
                    blue += fadeBlue;
                }
                if (ColorBase.A < alpha)
                {
                    alpha -= fadeAlpha;
                }
                else if (ColorBase.A > alpha)
                {
                    alpha += fadeAlpha;
                }
                if (ColorBase == Color.FromArgb(alpha, red, green, blue))
                {
                    fadeTimer.Stop();
                }
                else
                {
                    // Stop out of control timer, when no fading is needed. Added by gpgemini.
                    if (fadeSpeed == 0)
                    {
                        fadeTimer.Stop();
                    }
                }
            }

            Refresh();
        }
        #endregion

        private void OnButtonStateChange(RibbonMenuButtonState ribbonMenuButtonState)
        {
            switch (ribbonMenuButtonState)
            {
                case RibbonMenuButtonState.None:
                    ColorStroke = ColorBaseStroke;
                    activeShowBase = ShowBase;
                    if (fadeSpeed == 0)
                    {
                        red = baseColor.R;
                        green = baseColor.G;
                        blue = baseColor.B;
                        Refresh();
                    }
                    else
                    {
                        fadeTimer.Stop();
                        fadeTimer.Start();
                    }
                    break;
                case RibbonMenuButtonState.Highlight:
                    ColorStroke = ColorOnStroke;
                    activeShowBase = true;
                    alpha = 200;
                    if (fadeSpeed == 0)
                    {
                        red = onColor.R;
                        green = onColor.G;
                        blue = onColor.B;
                    }
                    fadeTimer.Start();
                    break;
                case RibbonMenuButtonState.Pressed:
                    red = ColorPressed.R;
                    green = ColorPressed.G;
                    blue = ColorPressed.B;
                    ColorStroke = ColorPressedStroke;
                    activeShowBase = true;
                    break;
            }

            Refresh();
        }

        #region Mouse Events
        private bool mouseCapture;
        private int prevMouseX, prevMouseY;
        private int mouseX, mouseY;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            mouseX = PointToClient(Cursor.Position).X;
            mouseY = PointToClient(Cursor.Position).Y;
            mouseCapture = true;
            RibbonMenuButtonState = RibbonMenuButtonState.Highlight;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseCapture = false;
            RibbonMenuButtonState = RibbonMenuButtonState.None;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            mouseX = mevent.X;
            mouseY = mevent.Y;
            mouseCapture = true;

            RibbonMenuButtonState = RibbonMenuButtonState.Pressed;
        }

        private void ClearPressedButtons()
        {
            try
            {
                // this whole concept is just plain wrong. It needs to be pushed 
                // up to the application layer because if you don't understand the
                // ramifications it can really screw you

                foreach (Control control in Parent.Controls)
                {
                    if ((control != this) && typeof(RibbonMenuButton).IsAssignableFrom(control.GetType()))
                    {
                        ((RibbonMenuButton)(control)).IsPressed = false;
                        ((RibbonMenuButton)(control)).RibbonMenuButtonState = RibbonMenuButtonState.None;
                    }
                }
            }
            catch { }
        }

        private int restoreFadeSpeed;

        private void ShowContextMenu(int width, int height)
        {
            restoreFadeSpeed = fadeSpeed;
            fadeSpeed = 0;
            ContextMenuStrip.Closed += ContextMenuStrip_Closed;
            ContextMenuStrip.Show(this, width, height);
        }

        void ContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            fadeSpeed = restoreFadeSpeed;
            ContextMenuStrip.Closed -= ContextMenuStrip_Closed;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (!ClientRectangle.Contains(mevent.X, mevent.Y))
            {
                mouseCapture = false;
                base.OnMouseUp(mevent);
                return;
            }

            mouseCapture = true;

            // don't mess with contextMenu when user right-click's the button. 
            // Added by gpgemini.
            if (mevent.Button == MouseButtons.Right)
            {
                base.OnMouseUp(mevent);
                return;
            }

            if (((imageLocation == ImageLocationType.Left) ||
                (imageLocation == ImageLocationType.None)) &&
                (mouseX > Width - splitDistance) && isSplitButton)
            {
                if (arrowStyle == ArrowStyle.ToDown)
                {
                    if (ContextMenuStrip != null)
                    {
                        ContextMenuStrip.Opacity = 1.0;
                        ShowContextMenu(0, Height);
                    }
                }
                else if (arrowStyle == ArrowStyle.ToRight)
                {
                    if (ContextMenuStrip != null)
                    {
                        ContextMenuStrip.Opacity = 1.0;
                        if (MenuPosition.Y == 0)
                        {
                            ShowContextMenu(Width + 2, -Height);
                        }
                        else
                        {
                            ShowContextMenu(Width + 2, MenuPosition.Y);
                        }
                    }
                }
            }
            else if (imageLocation == ImageLocationType.Top & mouseY > Height - splitDistance &
                     isSplitButton)
            {
                if (arrowStyle == ArrowStyle.ToDown)
                {
                    if (ContextMenuStrip != null)
                    {
                        ShowContextMenu(0, Height);
                    }
                }
            }
            else
            {
                if (KeepPressed)
                {
                    IsPressed = true;
                    ClearPressedButtons();
                }

                base.OnMouseUp(mevent);
            }

            RibbonMenuButtonState = RibbonMenuButtonState.Highlight;
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            if (mouseCapture & IsSplitButton)
            {
                prevMouseX = mouseX;
                prevMouseY = mouseY;
                mouseX = mevent.X;
                mouseY = mevent.Y;
                if (prevMouseX != mouseX || prevMouseY != mouseY)
                {
                    // Refresh only if mouse ACTUALLY moved. Added by gpgemini.
                    Refresh();
                }
            }
            base.OnMouseMove(mevent);
        }
        #endregion
    }
}
