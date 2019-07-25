/**
 * MetroFramework - Modern UI for WinForms
 * 
 * The MIT License (MIT)
 * Copyright (c) 2011 Sven Walter, http://github.com/viperneo
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in the 
 * Software without restriction, including without limitation the rights to use, copy, 
 * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
 * and to permit persons to whom the Software is furnished to do so, subject to the 
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
 * CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
 * OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using smartpos.wpos.App.Components.UserDefined.Drawing;

namespace MetroFramework.Controls
{
    [Designer("MetroFramework.Design.Controls.MetroButtonDesigner")]
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public class MetroButton : Button, IMetroControl
    {
        #region Interface

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroDefaults.Style;
                }

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroDefaults.Theme;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; }
        }

        private bool useCustomBackColor= false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(MetroDefaults.PropertyCategory.Behaviour)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, false); }
        }

        #endregion

        #region Fields

        private bool displayFocusRectangle = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool DisplayFocus
        {
            get { return displayFocusRectangle; }
            set { displayFocusRectangle = value; }
        }

        private bool highlight = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool Highlight
        {
            get { return highlight; }
            set { highlight = value; }
        }

        private MetroButtonSize metroButtonSize = MetroButtonSize.Px18;
        [DefaultValue(MetroButtonSize.Px18)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroButtonSize FontSize
        {
            get { return metroButtonSize; }
            set { metroButtonSize = value; }
        }

        public Image dowmbitmap=null;
        public Image BackgroundImageDown
        {
            get { return dowmbitmap; }
            set { dowmbitmap = value; }
        }
        /// <summary>
        /// 是否支持控件多重色彩
        /// </summary>
        public bool IsMutilColors = false;
        /// <summary>
        /// 多重色彩显示信息
        /// </summary>
        public List<MutilColor> MutilColors = null;
        /// <summary>
        /// 是否显示边框
        /// </summary>
        public bool IsShowBorder = false;
        /// <summary>
        /// 是否显示复选框
        /// </summary>
        public bool IsShowCheck = false;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                Invalidate();     
            }
        }

        private bool _isChecked = false;
        public Image upbitmap=null;
        public Image BackgroundImageUp
        {
            get { return upbitmap; }
            set { upbitmap = value; }
        }
        private MetroButtonWeight metroButtonWeight = MetroButtonWeight.Bold;
        [DefaultValue(MetroButtonWeight.Bold)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public MetroButtonWeight FontWeight
        {
            get { return metroButtonWeight; }
            set { metroButtonWeight = value; }
        }

        private bool isHovered = false;
        private bool isPressed = false;
        private bool isFocused = false;

        #endregion

        #region Constructor

        public MetroButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
        }

        #endregion

        #region Paint Methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try 
            {
                Color backColor = BackColor;
                if (isHovered && !isPressed && Enabled)
                {
                    backColor = MetroPaint.BackColor.Button.Hover(Theme);
                    if (BackgroundImageDown != null)
                    {
                        BackgroundImage = BackgroundImageUp;
                    }
                }
                else if (isHovered && isPressed && Enabled)
                {
                    backColor = MetroPaint.BackColor.Button.Press(Theme);
                    if (BackgroundImageDown != null)
                    {
                        BackgroundImage = BackgroundImageDown;
                    }
                }
                else if (!Enabled)
                {
                    backColor = Color.FromArgb(241, 240, 238);//MetroPaint.BackColor.Button.Disabled(Theme);
                      if (BackgroundImageDown != null)
                    {
                        BackgroundImage = BackgroundImageUp;
                    }
                }
                else
                {
                    if (!useCustomBackColor)
                    {
                        backColor = MetroPaint.BackColor.Button.Normal(Theme);
                   if (BackgroundImageDown != null)
                    {
                        BackgroundImage = BackgroundImageUp;
                    }
                    } 
                }

                if (backColor.A == 255 && BackgroundImage == null)
                { 
                    e.Graphics.Clear(backColor); 
                    return; 
                } 
                
                base.OnPaintBackground(e);

                OnCustomPaintBackground(new MetroPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            { 
                Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try			
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                OnCustomPaint(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
                OnPaintForeground(e);            
            }
            catch 
            { 
                Invalidate();
            }
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            Color borderColor, foreColor;

            if (isHovered && !isPressed && Enabled)
            {
                borderColor = Color.Transparent;// MetroPaint.BorderColor.Button.Hover(Theme);
                foreColor = MetroPaint.ForeColor.Button.Hover(Theme);
            }
            else if (isHovered && isPressed && Enabled)
            {
                borderColor =Color.Transparent;// MetroPaint.BorderColor.Button.Press(Theme);
                foreColor = MetroPaint.ForeColor.Button.Press(Theme);
            }
            else if (!Enabled)
            {
                borderColor =Color.Transparent;// MetroPaint.BorderColor.Button.Disabled(Theme);
                foreColor = Color.FromArgb(137, 133, 132); //MetroPaint.ForeColor.Button.Disabled(Theme);
            }
            else
            {
                if (IsShowBorder)
                {
                    borderColor = Color.FromArgb(235, 128, 4);
                }
                else
                {
                    borderColor = Color.Transparent;//MetroPaint.BorderColor.Button.Normal(Theme);
                }
                
                if (useCustomForeColor)
                {
                    foreColor = ForeColor;
                }
                else if (useStyleColors)
                {
                    foreColor = MetroPaint.GetStyleColor(Style);
                }
                else
                {
                    foreColor = MetroPaint.ForeColor.Button.Normal(Theme);
                }
            }
            
            using (Pen p = new Pen(borderColor))
            {
                Rectangle borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(p, borderRect);
            }

            if (Highlight && !isHovered && !isPressed && Enabled)
            {
                using (Pen p = MetroPaint.GetStylePen(Style))
                {
                    Rectangle borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                    e.Graphics.DrawRectangle(p, borderRect);
                    borderRect = new Rectangle(1, 1, Width - 3, Height - 3);
                    e.Graphics.DrawRectangle(p, borderRect);
                }
            }
            if (IsShowCheck)
            {
                //if (_isChecked)
                //{
                //    Image bmp3 = smartpos.wpos.App.Components.Properties.Resources.单选2;
                //    Size size = new Size(bmp3.Width, bmp3.Height);
                //    Rectangle rect = new Rectangle(new Point(0, 0), size);
                //    e.Graphics.DrawImage(bmp3, rect, new Rectangle(0, 0, bmp3.Width, bmp3.Height), GraphicsUnit.Pixel);
                //}
                //else
                //{
                //    Image bmp3 = smartpos.wpos.App.Components.Properties.Resources.单选1;
                //    Size size = new Size(bmp3.Width, bmp3.Height);
                //    Rectangle rect = new Rectangle(new Point(0, 0), size);
                //    e.Graphics.DrawImage(bmp3, rect, new Rectangle(0, 0, bmp3.Width, bmp3.Height), GraphicsUnit.Pixel);
                //}
            }
            if (IsMutilColors)
            {
                if (MutilColors != null)
                {
                    foreach (var p in MutilColors)
                    {
                        Color mColor;
                        if (isHovered && !isPressed && Enabled)
                        {
                            mColor = p.HoverColor;
                        }
                        else if (isHovered && isPressed && Enabled)
                        {
                            mColor = p.PressColor;
                        }else if (!Enabled)
                        {
                            mColor = p.DisableColor;
                        }
                        else
                        {
                            mColor = p.DefaultColor;
                        }
                        if (MutilColors.Count == 4) //这里表示无图模式的菜品
                        {
                            Rectangle temp = new Rectangle(ClientRectangle.X + ClientRectangle.Width / 15, ClientRectangle.Y + ClientRectangle.Height / 15, ClientRectangle.Width * 13 / 15,
                                ClientRectangle.Height * 13 / 15);
                            TextRenderer.DrawText(e.Graphics, p.Text, MetroFonts.Button(p.FontSize, metroButtonWeight),
                                temp, mColor, MetroPaint.GetTextFormatFlags(p.Alignment));
                        }
                        else
                        {
                            TextRenderer.DrawText(e.Graphics, p.Text, MetroFonts.Button(p.FontSize, metroButtonWeight),
                       ClientRectangle, mColor, MetroPaint.GetTextFormatFlags(p.Alignment));
                        }
                        
                    }
                }
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, Text, MetroFonts.Button(metroButtonSize, metroButtonWeight),
                    ClientRectangle, foreColor, MetroPaint.GetTextFormatFlags(TextAlign));
            }
            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, foreColor, e.Graphics));

            if (displayFocusRectangle && isFocused)
                ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);
        }

        #endregion

        #region Focus Methods

        protected override void OnGotFocus(EventArgs e)
        {
            isFocused = true;
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            isFocused = false;
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnLostFocus(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            isFocused = true;
            isHovered = true;
            Invalidate();

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            isFocused = false;
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnLeave(e);
        }

        #endregion

        #region Keyboard Methods

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                isHovered = true;
                isPressed = true;
                Invalidate();
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //Remove this code cause this prevents the focus color
            //isHovered = false;
            //isPressed = false;
            Invalidate();

            base.OnKeyUp(e);
        }

        #endregion

        #region Mouse Methods

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();

            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //This will check if control got the focus
            //If not thats the only it will remove the focus color
        //    if (!isFocused)
       //     {
                isHovered = false;
       //     }

            Invalidate();

            base.OnMouseLeave(e);
        }

        #endregion

        #region Overridden Methods

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        #endregion
    }
}
