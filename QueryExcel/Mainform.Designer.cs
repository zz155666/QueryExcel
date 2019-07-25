namespace QueryExcel
{
    partial class Mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelbottom = new MetroFramework.Controls.MetroPanel();
            this.panelbottomfull = new MetroFramework.Controls.MetroPanel();
            this.panelbottomfulltop = new MetroFramework.Controls.MetroPanel();
            this.delete = new MetroFramework.Controls.MetroButton();
            this.fresh = new MetroFramework.Controls.MetroButton();
            this.paneltop = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panelbottom.SuspendLayout();
            this.panelbottomfull.SuspendLayout();
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.panelbottomfull);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.HorizontalScrollbarBarColor = true;
            this.panelbottom.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbottom.HorizontalScrollbarSize = 10;
            this.panelbottom.Location = new System.Drawing.Point(0, 82);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(980, 530);
            this.panelbottom.TabIndex = 2;
            this.panelbottom.VerticalScrollbarBarColor = true;
            this.panelbottom.VerticalScrollbarHighlightOnWheel = false;
            this.panelbottom.VerticalScrollbarSize = 10;
            // 
            // panelbottomfull
            // 
            this.panelbottomfull.Controls.Add(this.panelbottomfulltop);
            this.panelbottomfull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottomfull.HorizontalScrollbarBarColor = true;
            this.panelbottomfull.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbottomfull.HorizontalScrollbarSize = 10;
            this.panelbottomfull.Location = new System.Drawing.Point(0, 0);
            this.panelbottomfull.Name = "panelbottomfull";
            this.panelbottomfull.Size = new System.Drawing.Size(980, 530);
            this.panelbottomfull.TabIndex = 3;
            this.panelbottomfull.VerticalScrollbarBarColor = true;
            this.panelbottomfull.VerticalScrollbarHighlightOnWheel = false;
            this.panelbottomfull.VerticalScrollbarSize = 10;
            // 
            // panelbottomfulltop
            // 
            this.panelbottomfulltop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottomfulltop.HorizontalScrollbarBarColor = true;
            this.panelbottomfulltop.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbottomfulltop.HorizontalScrollbarSize = 10;
            this.panelbottomfulltop.Location = new System.Drawing.Point(0, 0);
            this.panelbottomfulltop.Name = "panelbottomfulltop";
            this.panelbottomfulltop.Size = new System.Drawing.Size(980, 530);
            this.panelbottomfulltop.TabIndex = 3;
            this.panelbottomfulltop.VerticalScrollbarBarColor = true;
            this.panelbottomfulltop.VerticalScrollbarHighlightOnWheel = false;
            this.panelbottomfulltop.VerticalScrollbarSize = 10;
            // 
            // delete
            // 
            this.delete.BackgroundImage = global::QueryExcel.Properties.Resources.删除24;
            this.delete.BackgroundImageDown = null;
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.delete.BackgroundImageUp = null;
            this.delete.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.delete.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.delete.IsChecked = false;
            this.delete.Location = new System.Drawing.Point(892, 35);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(64, 24);
            this.delete.TabIndex = 8;
            this.delete.Text = "删除";
            this.delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete.UseCustomForeColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // fresh
            // 
            this.fresh.BackgroundImage = global::QueryExcel.Properties.Resources.刷新24;
            this.fresh.BackgroundImageDown = null;
            this.fresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fresh.BackgroundImageUp = null;
            this.fresh.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.fresh.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.fresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.fresh.IsChecked = false;
            this.fresh.Location = new System.Drawing.Point(751, 35);
            this.fresh.Name = "fresh";
            this.fresh.Size = new System.Drawing.Size(93, 24);
            this.fresh.TabIndex = 7;
            this.fresh.Text = "刷新列表";
            this.fresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fresh.UseCustomForeColor = true;
            this.fresh.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.paneltop.Controls.Add(this.metroLabel1);
            this.paneltop.Controls.Add(this.fresh);
            this.paneltop.Controls.Add(this.delete);
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.HorizontalScrollbarBarColor = true;
            this.paneltop.HorizontalScrollbarHighlightOnWheel = false;
            this.paneltop.HorizontalScrollbarSize = 10;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.Size = new System.Drawing.Size(980, 82);
            this.paneltop.TabIndex = 0;
            this.paneltop.UseCustomBackColor = true;
            this.paneltop.VerticalScrollbarBarColor = true;
            this.paneltop.VerticalScrollbarHighlightOnWheel = false;
            this.paneltop.VerticalScrollbarSize = 10;
            this.paneltop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltop_MouseDown);
            this.paneltop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paneltop_MouseMove);
            // 
            // metroLabel1
            // 
            this.metroLabel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel1.Location = new System.Drawing.Point(62, 35);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(493, 23);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "metroLabel1";
            // 
            // Mainform
            // 
            this.AcceptButton = this.fresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 612);
            this.ControlBox = false;
            this.Controls.Add(this.panelbottom);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Mainform";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mainform_KeyDown);
            this.panelbottom.ResumeLayout(false);
            this.panelbottomfull.ResumeLayout(false);
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel paneltop;
        private MetroFramework.Controls.MetroPanel panelbottom;
        private MetroFramework.Controls.MetroPanel panelbottomfull;
        private MetroFramework.Controls.MetroPanel panelbottomfulltop;
        private MetroFramework.Controls.MetroButton delete;
        private MetroFramework.Controls.MetroButton fresh;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}