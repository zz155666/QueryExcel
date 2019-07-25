using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MetroFramework;

namespace smartpos.wpos.App.Components.UserDefined.Drawing
{
    /// <summary>
    /// 用与多个颜色的信息显示
    /// </summary>
   public class MutilColor
    {
       /// <summary>
       /// 显示的内容
       /// </summary>
       public string Text { set; get; }
       /// <summary>
       /// 颜色
       /// </summary>
       public Color HoverColor{ set; get; }
       /// <summary>
       /// 颜色
       /// </summary>
       public Color PressColor{ set; get; }
       /// <summary>
       /// 颜色
       /// </summary>
       public Color DefaultColor{ set; get; }
       /// <summary>
       /// 颜色
       /// </summary>
       public Color DisableColor{ set; get; }
       /// <summary>
       /// 字体大小
       /// </summary>
       public MetroButtonSize FontSize{ set; get; }
       /// <summary>
       /// 布局
       /// </summary>
       public ContentAlignment Alignment{ set; get; }
    }
}
