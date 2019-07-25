using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;

namespace smartpos.wpos.App.Components.UserDefined.MessageBox
{
    /// <summary>
    /// Metro-styled message notification.
    /// </summary>
    public static class MetroMessageBox
    {
        /// <summary>
        /// ���������Ϊ�˼���ԭ�ȵĶԻ�����
        ///// </summary>
        ///// <param name="code"></param>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public static DialogResult ShowDialog(MessageBoxCodes code,string message)
        //{
        //    return Show(message);
        //}
        ///// <summary>
        ///// ��ʾ�Ի���ļ򵥷���
        ///// </summary>
        ///// <param name="message"></param>
        ///// <param name="height"></param>
        ///// <returns></returns>
        //public static DialogResult Show(String message,int height=211)
        //{ return Show(WindowsControl.Main, message, "��ʾ", height); }
        /// <summary>
        /// Shows a metro-styles message notification into the specified owner window.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="height" optional=211></param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message,int height=211)
        { return Show(owner, message, "��ʾ", height); }

        /// <summary>
        /// Shows a metro-styles message notification into the specified owner window.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="height" optional=211></param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message, String title, int height = 211)
        { return Show(owner, message, title, MessageBoxButtons.OK, height); }

        /// <summary>
        /// Shows a metro-styles message notification into the specified owner window.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <param name="height" optional=211></param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, int height = 211)
        { return Show(owner, message, title, buttons, MessageBoxIcon.Information, height); }

       /// <summary>
       /// Shows a metro-styles message notification into the specified owner window.
       /// </summary>
       /// <param name="owner"></param>
       /// <param name="message"></param>
       /// <param name="title"></param>
       /// <param name="buttons"></param>
       /// <param name="icon"></param>
       /// <param name="height"></param>
       /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, MessageBoxIcon icon, int height = 211)
        { return Show(owner, message, title, buttons, icon, MessageBoxDefaultButton.Button1, height); }

        /// <summary>
        /// Shows a metro-styles message notification into the specified owner window.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <param name="defaultbutton"></param>
        /// <param name="height" optional=211></param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton, int height = 300)
        {
            DialogResult _result = DialogResult.None;

            if (owner != null)
            {
                Form _owner = (Form)owner;
                
                //int _minWidth = 500;
                //int _minHeight = 350;

                //if (_owner.Size.Width < _minWidth ||
                //    _owner.Size.Height < _minHeight)
                //{
                //    if (_owner.Size.Width < _minWidth && _owner.Size.Height < _minHeight) {
                //            _owner.Size = new Size(_minWidth, _minHeight);
                //    }
                //    else
                //    {
                //        if (_owner.Size.Width < _minWidth) _owner.Size = new Size(_minWidth, _owner.Size.Height);
                //        else _owner.Size = new Size(_owner.Size.Width, _minHeight);
                //    }

                //    int x = Convert.ToInt32(Math.Ceiling((decimal)(Screen.PrimaryScreen.WorkingArea.Size.Width / 2) - (_owner.Size.Width / 2)));
                //    int y = Convert.ToInt32(Math.Ceiling((decimal)(Screen.PrimaryScreen.WorkingArea.Size.Height / 2) - (_owner.Size.Height / 2)));
                //    _owner.Location = new Point(x, y);
                //}

                switch (icon)
                {
                    case MessageBoxIcon.Error:
                        SystemSounds.Hand.Play(); break;
                    case MessageBoxIcon.Exclamation:
                        SystemSounds.Exclamation.Play(); break;
                    case MessageBoxIcon.Question:
                        SystemSounds.Beep.Play(); break;
                    default:
                        SystemSounds.Asterisk.Play(); break;
                }

                MetroMessageBoxControl _control = new MetroMessageBoxControl();
                _control.BackColor = _owner.BackColor;
                _control.Properties.Buttons = buttons;
                _control.Properties.DefaultButton = defaultbutton;
                _control.Properties.Icon = icon;
                _control.Properties.Message = message;
                _control.Properties.Title = title;
                _control.Padding = new Padding(0, 0, 0, 0);
                _control.ControlBox = false;
                _control.ShowInTaskbar = false;                
                //_owner.Controls.Add(_control);
                //if (_owner is IMetroForm)
                //{
                //    //if (((MetroForm)_owner).DisplayHeader)
                //    //{
                //    //    _offset += 30;
                //    //}
                //    _control.Theme = ((MetroForm)_owner).Theme;
                //    _control.Style = ((MetroForm)_owner).Style;
                //}
                _control.Size = new Size(_owner.Size.Width*2 / 5, height);
                if (_owner.Size.Width*2 / 5 < 400)
                {
                    _control.Size = new Size(400, height);
                }
                _control.Location = new Point(_owner.Location.X + (_owner.Size.Width -_control.Width) / 2, _owner.Location.Y + (_owner.Height - _control.Height) / 2);
                _control.ArrangeApperance();
                int _overlaySizes = Convert.ToInt32(Math.Floor(_control.Size.Height * 0.28));
                //_control.OverlayPanelTop.Size = new Size(_control.Size.Width, _overlaySizes - 30);
                //_control.OverlayPanelBottom.Size = new Size(_control.Size.Width, _overlaySizes);

                _control.ShowDialog();
                _control.BringToFront();
                _control.SetDefaultButton();
                Action<MetroMessageBoxControl> _delegate = new Action<MetroMessageBoxControl>(ModalState);
                IAsyncResult _asyncresult = _delegate.BeginInvoke(_control, null, _delegate);
                bool _cancelled = false;

                try
                {
                    while (!_asyncresult.IsCompleted)
                    { Thread.Sleep(1); Application.DoEvents(); }
                }
                catch 
                {
                    _cancelled = true;

                    if (!_asyncresult.IsCompleted)
                    {
                        try { _asyncresult = null; }
                        catch { }
                    }

                    _delegate = null;
                }

                if (!_cancelled)
                {
                    _result = _control.Result;
                    //_owner.Controls.Remove(_control);
                    _control.Dispose(); _control = null;
                }
                 
            }

            return _result;
        }

        private static void ModalState(MetroMessageBoxControl control)
        {
            while (control.Visible)
            { }
        }

    }
}
