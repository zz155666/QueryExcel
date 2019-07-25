using System;
using System.Drawing;

namespace smartpos.wpos.App.Components.UserDefined.Button
{
    public class RibbonColor
    {
        #region Constructors
        public RibbonColor(Color color)
        {
            red = color.R;
            green = color.G;
            blue = color.B;
            alpha = color.A;

            HsvColor();
        }

        public RibbonColor(uint alpha, int hue, int saturation, int brightness)
        {
            this.hue = hue;
            this.saturation = saturation;
            value = brightness;
            this.alpha = alpha;

            GetColor();
        }
        #endregion

        #region Alpha
        private readonly uint alpha;

        public uint Alpha
        {
            get { return alpha; }
            set { Math.Min(value, 255); }
        }
        #endregion

        #region RGB
        private int blue;
        private int green;
        private int red;

        public int Red
        {
            get { return red; }
            set { red = Math.Min(value, 255); }
        }

        public int Green
        {
            get { return green; }
            set { green = Math.Min(value, 255); }
        }

        public int Blue
        {
            get { return blue; }
            set { blue = Math.Min(value, 255); }
        }

        public Color GetGrayScaleColor()
        {
            double val = value / 100.0f;
            int conv = (int)(255.0f * val);
            red = green = blue = conv;
            return Color.FromArgb(red, green, blue);
        }

        public Color GetColor()
        {
            double sat = saturation / 100.0f;
            double val = value / 100.0f;

            if ((float)saturation == 0) // Gray Colors
            {
                int conv = (int)(255.0f * val);
                red = green = blue = conv;
                return Color.FromArgb(red, green, blue);
            }

            int basis = (int)(255.0f * (1.0 - sat) * val);

            switch ((int)(hue / 60.0f))
            {
                case 0:
                    red = (int)(255.0f * val);
                    green = (int)((255.0f * val - basis) * (hue / 60.0f) + basis);
                    blue = basis;
                    break;

                case 1:
                    red = (int)((255.0f * val - basis) * (1.0f - ((hue % 60) / 60.0f)) + basis);
                    green = (int)(255.0f * val);
                    blue = basis;
                    break;

                case 2:
                    red = basis;
                    green = (int)(255.0f * val);
                    blue = (int)((255.0f * val - basis) * ((hue % 60) / 60.0f) + basis);
                    break;

                case 3:
                    red = basis;
                    green = (int)((255.0f * val - basis) * (1.0f - ((hue % 60) / 60.0f)) + basis);
                    blue = (int)(255.0f * val);
                    break;

                case 4:
                    red = (int)((255.0f * val - basis) * ((hue % 60) / 60.0f) + basis);
                    green = basis;
                    blue = (int)(255.0f * val);
                    break;

                case 5:
                    red = (int)(255.0f * val);
                    green = basis;
                    blue = (int)((255.0f * val - basis) * (1.0f - ((hue % 60) / 60.0f)) + basis);
                    break;
            }
            return Color.FromArgb((int)alpha, red, green, blue);
        }

        #endregion

        #region HSV
        public enum ColorComponent
        {
            None,
            Red,
            Green,
            Blue
        }

        private ColorComponent maxComponent;

        private int hue;
        private int maxval, minval;
        private int saturation, value;

        public float Hue
        {
            get { return hue; }
            set
            {
                hue = (int)Math.Min(value, 359);
                hue = Math.Max(hue, 0);
            }
        }

        public float Saturation
        {
            get { return saturation; }
            set
            {
                saturation = (int)Math.Min(value, 100);
                saturation = Math.Max(saturation, 0);
            }
        }

        public float Value
        {
            get { return value; }
            set
            {
                this.value = (int)Math.Min(value, 100);
                this.value = Math.Max(this.value, 0);
            }
        }

        private void HsvColor()
        {
            hue = GetHue();
            saturation = GetSaturation();
            value = GetBrightness();
        }

        private void CMax()
        {
            if (red > green)
            {
                if (red < blue)
                {
                    maxval = blue;
                    maxComponent = ColorComponent.Blue;
                }
                else
                {
                    maxval = red;
                    maxComponent = ColorComponent.Red;
                }
            }
            else
            {
                if (green < blue)
                {
                    maxval = blue;
                    maxComponent = ColorComponent.Blue;
                }
                else
                {
                    maxval = green;
                    maxComponent = ColorComponent.Green;
                }
            }
        }

        private void CMin()
        {
            if (red < green)
            {
                minval = red > blue ? blue : red;
            }
            else
            {
                minval = green > blue ? blue : green;
            }
        }

        public int GetBrightness() //Brightness is from 0 to 100
        {
            CMax();
            return 100 * maxval / 255;
        }

        public int GetSaturation() //Saturation from 0 to 100
        {
            CMax();
            CMin();

            if (maxComponent == ColorComponent.None)
            {
                return 0;
            }

            if (maxval != minval)
            {
                Decimal temp = Decimal.Divide(minval, maxval);
                temp = Decimal.Subtract(1, temp);
                temp = Decimal.Multiply(temp, 100);
                return Convert.ToUInt16(temp);
            }

            return 0;
        }

        public int GetHue()
        {
            CMax();
            CMin();

            if (maxval == minval)
            {
                return 0;
            }

            if (maxComponent == ColorComponent.Red)
            {
                if (green >= blue)
                {
                    Decimal d1 = Decimal.Divide((green - blue), (maxval - minval));
                    return Convert.ToUInt16(60 * d1);
                }
                else
                {
                    Decimal d1 = Decimal.Divide((blue - green), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(360 - d1);
                }
            }

            if (maxComponent == ColorComponent.Green)
            {
                if (blue >= red)
                {
                    Decimal d1 = Decimal.Divide((blue - red), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(120 + d1);
                }
                else
                {
                    Decimal d1 = Decimal.Divide((red - blue), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(120 - d1);
                }
            }

            if (maxComponent == ColorComponent.Blue)
            {
                if (red >= green)
                {
                    Decimal d1 = Decimal.Divide((red - green), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(240 + d1);
                }
                else
                {
                    Decimal d1 = Decimal.Divide((green - red), (maxval - minval));
                    d1 = 60 * d1;
                    return Convert.ToUInt16(240 - d1);
                }
            }

            return 0;
        }
        #endregion

        #region Methods
        public bool IsDark()
        {
            return Blue <= 50;
        }

        public void IncreaseBrightness(int val)
        {
            Value = Value + val;
        }

        public void SetBrightness(int val)
        {
            Value = val;
        }

        public void IncreaseHue(int val)
        {
            Hue = Hue + val;
        }

        public void SetHue(int val)
        {
            Hue = val;
        }

        public void IncreaseSaturation(int val)
        {
            Saturation = Saturation + val;
        }

        public void SetSaturation(int val)
        {
            Saturation = val;
        }

        public Color IncreaseHsv(int h, int s, int b)
        {
            Hue = Hue + h;
            Saturation = Saturation + s;
            Value = Value + b;
            return GetColor();
        }
        #endregion
    }
}
