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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Drawing.Text;
using System;

namespace MetroFramework
{
    public enum MetroLabelSize
    {
        Px12,
        Px14,
        Px16,
        Px18,
        Px20,
        Px22,
        Px24,
        Px28,
        Px42
    }

    public enum MetroLabelWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroTileTextSize
    {
        Small,
        Medium,
        Tall
    }

    public enum MetroTileTextWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroLinkSize
    {
        Small,
        Medium,
        Tall
    }

    public enum MetroLinkWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroComboBoxSize
    {
        Small,
        Medium,
        Tall
    }

    public enum MetroComboBoxWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroDateTimeSize
    {
        Small,
        Medium,
        Tall
    }

    public enum MetroDateTimeWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroTextBoxSize
    {
        Px18,
        Px20,
        Px22,
        Px24,
        Px26
    }

    public enum MetroTextBoxWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroProgressBarSize
    {
        Small,
        Medium,
        Tall
    }

    public enum MetroProgressBarWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroTabControlSize
    {
        Small,
        Medium,
        Tall
    }

    public enum MetroTabControlWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroCheckBoxSize
    {
        Px16,
        Px18,
        Px20,
        Px22
    }

    public enum MetroCheckBoxWeight
    {
        Light,
        Regular,
        Bold
    }

    public enum MetroButtonSize
    {
        Px12,
        Px14,
        Px16,
        Px18,
        Px20,
        Px22,
        Px24,
        Px26
    }

    public enum MetroButtonWeight
    {
        Light,
        Regular,
        Bold
    }

    public static class MetroFonts
    {

        #region Font Resolver

        internal interface IMetroFontResolver
        {
            Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit);
        }

        private class DefaultFontResolver : IMetroFontResolver
        {
            public Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit)
            {
                return new Font(familyName, emSize, fontStyle, unit);
            }
        }

        private static IMetroFontResolver FontResolver;

        static MetroFonts()
        {
            try
            {
                Type t = Type.GetType("");
                if (t != null)
                {
                    FontResolver = (IMetroFontResolver)Activator.CreateInstance(t);
                    if (FontResolver != null)
                    {
                        Debug.WriteLine("'" + "' loaded.", "MetroFonts");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // ignore
                Debug.WriteLine(ex.Message, "MetroFonts");
            }
            FontResolver = new DefaultFontResolver();
        }

        #endregion

        public static Font DefaultLight(float size)
        {
            return FontResolver.ResolveFont("Segoe UI Light", size, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public static Font Default(float size)
        {
            return FontResolver.ResolveFont("微软雅黑", size, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public static Font DefaultBold(float size)
        {
            return FontResolver.ResolveFont("微软雅黑", size, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        public static Font Title
        {
            get { return Default(24f); }
        }

        public static Font Subtitle
        {
            get { return Default(14f); }
        }

        public static Font Tile(MetroTileTextSize labelSize, MetroTileTextWeight labelWeight)
        {
            if (labelSize == MetroTileTextSize.Small)
            {
                if (labelWeight == MetroTileTextWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroTileTextWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroTileTextWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (labelSize == MetroTileTextSize.Medium)
            {
                if (labelWeight == MetroTileTextWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroTileTextWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroTileTextWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroTileTextSize.Tall)
            {
                if (labelWeight == MetroTileTextWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroTileTextWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroTileTextWeight.Bold)
                    return DefaultBold(18f);
            }

            return DefaultLight(14f);
        }

        public static Font TileCount
        {
            get { return Default(44f); }
        }

        public static Font Link(MetroLinkSize linkSize, MetroLinkWeight linkWeight)
        {
            if (linkSize == MetroLinkSize.Small)
            {
                if (linkWeight == MetroLinkWeight.Light)
                    return DefaultLight(12f);
                if (linkWeight == MetroLinkWeight.Regular)
                    return Default(12f);
                if (linkWeight == MetroLinkWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (linkSize == MetroLinkSize.Medium)
            {
                if (linkWeight == MetroLinkWeight.Light)
                    return DefaultLight(14f);
                if (linkWeight == MetroLinkWeight.Regular)
                    return Default(14f);
                if (linkWeight == MetroLinkWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (linkSize == MetroLinkSize.Tall)
            {
                if (linkWeight == MetroLinkWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroLinkWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroLinkWeight.Bold)
                    return DefaultBold(18f);
            }

            return Default(12f);
        }

        public static Font ComboBox(MetroComboBoxSize linkSize, MetroComboBoxWeight linkWeight)
        {
            if (linkSize == MetroComboBoxSize.Small)
            {
                if (linkWeight == MetroComboBoxWeight.Light)
                    return DefaultLight(12f);
                if (linkWeight == MetroComboBoxWeight.Regular)
                    return Default(12f);
                if (linkWeight == MetroComboBoxWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (linkSize == MetroComboBoxSize.Medium)
            {
                if (linkWeight == MetroComboBoxWeight.Light)
                    return DefaultLight(14f);
                if (linkWeight == MetroComboBoxWeight.Regular)
                    return Default(14f);
                if (linkWeight == MetroComboBoxWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (linkSize == MetroComboBoxSize.Tall)
            {
                if (linkWeight == MetroComboBoxWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroComboBoxWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroComboBoxWeight.Bold)
                    return DefaultBold(18f);
            }

            return Default(12f);
        }

        public static Font DateTime(MetroDateTimeSize linkSize, MetroDateTimeWeight linkWeight)
        {
            if (linkSize == MetroDateTimeSize.Small)
            {
                if (linkWeight == MetroDateTimeWeight.Light)
                    return DefaultLight(12f);
                if (linkWeight == MetroDateTimeWeight.Regular)
                    return Default(12f);
                if (linkWeight == MetroDateTimeWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (linkSize == MetroDateTimeSize.Medium)
            {
                if (linkWeight == MetroDateTimeWeight.Light)
                    return DefaultLight(14f);
                if (linkWeight == MetroDateTimeWeight.Regular)
                    return Default(14f);
                if (linkWeight == MetroDateTimeWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (linkSize == MetroDateTimeSize.Tall)
            {
                if (linkWeight == MetroDateTimeWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroDateTimeWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroDateTimeWeight.Bold)
                    return DefaultBold(18f);
            }

            return Default(12f);
        }

        public static Font Label(MetroLabelSize labelSize, MetroLabelWeight labelWeight)
        {
            if (labelSize == MetroLabelSize.Px16)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(16f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(16f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(16f);
            }
                else if (labelSize == MetroLabelSize.Px12)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(12f);
            }
                 else if (labelSize == MetroLabelSize.Px14)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroLabelSize.Px18)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(18f);
            }
            else if (labelSize == MetroLabelSize.Px20)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(20f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(20f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(20f);
            } else if (labelSize == MetroLabelSize.Px22)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(22f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(22f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(22f);
            }
             else if (labelSize == MetroLabelSize.Px24)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(24f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(24f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(24f);
            }
            else if (labelSize == MetroLabelSize.Px28)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(28f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(28f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(28f);
            }
             else if (labelSize == MetroLabelSize.Px42)
            {
                if (labelWeight == MetroLabelWeight.Light)
                    return DefaultLight(42f);
                if (labelWeight == MetroLabelWeight.Regular)
                    return Default(42f);
                if (labelWeight == MetroLabelWeight.Bold)
                    return DefaultBold(42f);
            }

            return DefaultLight(20f);
        }

        public static Font TextBox(MetroTextBoxSize linkSize, MetroTextBoxWeight linkWeight)
        {
            if (linkSize == MetroTextBoxSize.Px18)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(18f);
            }
                else if (linkSize == MetroTextBoxSize.Px20)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(20f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(20f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(20f);
            }
            else if (linkSize == MetroTextBoxSize.Px22)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(22f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(22f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(22f);
            }
                 else if (linkSize == MetroTextBoxSize.Px24)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(24f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(24f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(24f);
            }
            else if (linkSize == MetroTextBoxSize.Px26)
            {
                if (linkWeight == MetroTextBoxWeight.Light)
                    return DefaultLight(26f);
                if (linkWeight == MetroTextBoxWeight.Regular)
                    return Default(26f);
                if (linkWeight == MetroTextBoxWeight.Bold)
                    return DefaultBold(26f);
            }

            return Default(12f);
        }

        public static Font ProgressBar(MetroProgressBarSize labelSize, MetroProgressBarWeight labelWeight)
        {
            if (labelSize == MetroProgressBarSize.Small)
            {
                if (labelWeight == MetroProgressBarWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroProgressBarWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroProgressBarWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (labelSize == MetroProgressBarSize.Medium)
            {
                if (labelWeight == MetroProgressBarWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroProgressBarWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroProgressBarWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroProgressBarSize.Tall)
            {
                if (labelWeight == MetroProgressBarWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroProgressBarWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroProgressBarWeight.Bold)
                    return DefaultBold(18f);
            }

            return DefaultLight(14f);
        }

        public static Font TabControl(MetroTabControlSize labelSize, MetroTabControlWeight labelWeight)
        {
            if (labelSize == MetroTabControlSize.Small)
            {
                if (labelWeight == MetroTabControlWeight.Light)
                    return DefaultLight(12f);
                if (labelWeight == MetroTabControlWeight.Regular)
                    return Default(12f);
                if (labelWeight == MetroTabControlWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (labelSize == MetroTabControlSize.Medium)
            {
                if (labelWeight == MetroTabControlWeight.Light)
                    return DefaultLight(14f);
                if (labelWeight == MetroTabControlWeight.Regular)
                    return Default(14f);
                if (labelWeight == MetroTabControlWeight.Bold)
                    return DefaultBold(14f);
            }
            else if (labelSize == MetroTabControlSize.Tall)
            {
                if (labelWeight == MetroTabControlWeight.Light)
                    return DefaultLight(18f);
                if (labelWeight == MetroTabControlWeight.Regular)
                    return Default(18f);
                if (labelWeight == MetroTabControlWeight.Bold)
                    return DefaultBold(18f);
            }

            return DefaultLight(14f);
        }

        public static Font CheckBox(MetroCheckBoxSize linkSize, MetroCheckBoxWeight linkWeight)
        {
            if (linkSize == MetroCheckBoxSize.Px16)
            {
                if (linkWeight == MetroCheckBoxWeight.Light)
                    return DefaultLight(16f);
                if (linkWeight == MetroCheckBoxWeight.Regular)
                    return Default(16f);
                if (linkWeight == MetroCheckBoxWeight.Bold)
                    return DefaultBold(16f);
            }
            else if (linkSize == MetroCheckBoxSize.Px20)
            {
                if (linkWeight == MetroCheckBoxWeight.Light)
                    return DefaultLight(20f);
                if (linkWeight == MetroCheckBoxWeight.Regular)
                    return Default(20f);
                if (linkWeight == MetroCheckBoxWeight.Bold)
                    return DefaultBold(20f);
            }
            else if (linkSize == MetroCheckBoxSize.Px18)
            {
                if (linkWeight == MetroCheckBoxWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroCheckBoxWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroCheckBoxWeight.Bold)
                    return DefaultBold(18f);
            }
            else if (linkSize == MetroCheckBoxSize.Px22)
            {
                if (linkWeight == MetroCheckBoxWeight.Light)
                    return DefaultLight(22f);
                if (linkWeight == MetroCheckBoxWeight.Regular)
                    return Default(22f);
                if (linkWeight == MetroCheckBoxWeight.Bold)
                    return DefaultBold(22f);
            }

            return Default(12f);
        }

        public static Font Button(MetroButtonSize linkSize, MetroButtonWeight linkWeight)
        {
            if (linkSize == MetroButtonSize.Px18)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(18f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(18f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(18f);
            }else if (linkSize == MetroButtonSize.Px16)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(16f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(16f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(16f);
            }
                else if (linkSize == MetroButtonSize.Px14)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(14f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(14f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(14f);
            }
                
                else if (linkSize == MetroButtonSize.Px12)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(12f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(12f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(12f);
            }
            else if (linkSize == MetroButtonSize.Px20)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(20f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(20f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(20f);
            }
            else if (linkSize == MetroButtonSize.Px22)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(22f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(22f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(22f);
            }
                else if (linkSize == MetroButtonSize.Px24)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(24f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(24f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(24f);
            }              else if (linkSize == MetroButtonSize.Px26)
            {
                if (linkWeight == MetroButtonWeight.Light)
                    return DefaultLight(26f);
                if (linkWeight == MetroButtonWeight.Regular)
                    return Default(26f);
                if (linkWeight == MetroButtonWeight.Bold)
                    return DefaultBold(26f);
            }


            return Default(11f);
        }
    }
}
