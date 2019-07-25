using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MetroFramework;

namespace smartpos.wpos.App.Components.UserDefined.Drawing
{
   public class MutilColorAndPrictures
    {
        /// <summary>
        /// 显示的内容
        /// </summary>
        public string Text { set; get; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Color HoverColor { set; get; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Color PressColor { set; get; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Color DefaultColor { set; get; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Color DisableColor { set; get; }
        /// <summary>
        /// 字体大小
        /// </summary>
        public MetroButtonSize FontSize { set; get; }
       /// <summary>
       /// 第一张图片
       /// </summary>
       public Image Image { set; get; }
       /// <summary>
       /// 第二张图片
       /// </summary>
       public  Image Image2{ set; get; }
       public DateTime DateTime { set; get; }
    }
}
