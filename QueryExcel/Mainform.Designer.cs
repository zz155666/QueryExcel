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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelbottom = new MetroFramework.Controls.MetroPanel();
            this.panelbottomfull = new MetroFramework.Controls.MetroPanel();
            this.panelbottomfulltop = new MetroFramework.Controls.MetroPanel();
            this.metroGrid1 = new smartpos.wpos.App.Components.UserDefined.Controls.MetroGrid();
            this.panelbottomfullbottom = new MetroFramework.Controls.MetroPanel();
            this.nextpage = new MetroFramework.Controls.MetroButton();
            this.uppage = new MetroFramework.Controls.MetroButton();
            this.panelbootomleft = new MetroFramework.Controls.MetroPanel();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.paneltopoperation = new MetroFramework.Controls.MetroPanel();
            this.delete = new MetroFramework.Controls.MetroButton();
            this.fresh = new MetroFramework.Controls.MetroButton();
            this.down = new MetroFramework.Controls.MetroButton();
            this.paneltop = new MetroFramework.Controls.MetroPanel();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.man = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelbottom.SuspendLayout();
            this.panelbottomfull.SuspendLayout();
            this.panelbottomfulltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.panelbottomfullbottom.SuspendLayout();
            this.panelbootomleft.SuspendLayout();
            this.paneltopoperation.SuspendLayout();
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.panelbottomfull);
            this.panelbottom.Controls.Add(this.panelbootomleft);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.HorizontalScrollbarBarColor = true;
            this.panelbottom.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbottom.HorizontalScrollbarSize = 10;
            this.panelbottom.Location = new System.Drawing.Point(0, 148);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(980, 464);
            this.panelbottom.TabIndex = 2;
            this.panelbottom.VerticalScrollbarBarColor = true;
            this.panelbottom.VerticalScrollbarHighlightOnWheel = false;
            this.panelbottom.VerticalScrollbarSize = 10;
            // 
            // panelbottomfull
            // 
            this.panelbottomfull.Controls.Add(this.panelbottomfulltop);
            this.panelbottomfull.Controls.Add(this.panelbottomfullbottom);
            this.panelbottomfull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottomfull.HorizontalScrollbarBarColor = true;
            this.panelbottomfull.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbottomfull.HorizontalScrollbarSize = 10;
            this.panelbottomfull.Location = new System.Drawing.Point(83, 0);
            this.panelbottomfull.Name = "panelbottomfull";
            this.panelbottomfull.Size = new System.Drawing.Size(897, 464);
            this.panelbottomfull.TabIndex = 3;
            this.panelbottomfull.VerticalScrollbarBarColor = true;
            this.panelbottomfull.VerticalScrollbarHighlightOnWheel = false;
            this.panelbottomfull.VerticalScrollbarSize = 10;
            // 
            // panelbottomfulltop
            // 
            this.panelbottomfulltop.Controls.Add(this.metroGrid1);
            this.panelbottomfulltop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottomfulltop.HorizontalScrollbarBarColor = true;
            this.panelbottomfulltop.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbottomfulltop.HorizontalScrollbarSize = 10;
            this.panelbottomfulltop.Location = new System.Drawing.Point(0, 0);
            this.panelbottomfulltop.Name = "panelbottomfulltop";
            this.panelbottomfulltop.Size = new System.Drawing.Size(897, 414);
            this.panelbottomfulltop.TabIndex = 3;
            this.panelbottomfulltop.VerticalScrollbarBarColor = true;
            this.panelbottomfulltop.VerticalScrollbarHighlightOnWheel = false;
            this.panelbottomfulltop.VerticalScrollbarSize = 10;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeColumns = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.mobile,
            this.day,
            this.time,
            this.type,
            this.man,
            this.name,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(0, 0);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.RowTemplate.Height = 23;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(897, 414);
            this.metroGrid1.TabIndex = 2;
            // 
            // panelbottomfullbottom
            // 
            this.panelbottomfullbottom.Controls.Add(this.nextpage);
            this.panelbottomfullbottom.Controls.Add(this.uppage);
            this.panelbottomfullbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottomfullbottom.HorizontalScrollbarBarColor = true;
            this.panelbottomfullbottom.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbottomfullbottom.HorizontalScrollbarSize = 10;
            this.panelbottomfullbottom.Location = new System.Drawing.Point(0, 414);
            this.panelbottomfullbottom.Name = "panelbottomfullbottom";
            this.panelbottomfullbottom.Size = new System.Drawing.Size(897, 50);
            this.panelbottomfullbottom.TabIndex = 4;
            this.panelbottomfullbottom.VerticalScrollbarBarColor = true;
            this.panelbottomfullbottom.VerticalScrollbarHighlightOnWheel = false;
            this.panelbottomfullbottom.VerticalScrollbarSize = 10;
            // 
            // nextpage
            // 
            this.nextpage.BackColor = System.Drawing.Color.White;
            this.nextpage.BackgroundImage = global::QueryExcel.Properties.Resources.下一页24;
            this.nextpage.BackgroundImageDown = null;
            this.nextpage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.nextpage.BackgroundImageUp = null;
            this.nextpage.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.nextpage.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.nextpage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.nextpage.IsChecked = false;
            this.nextpage.Location = new System.Drawing.Point(789, 12);
            this.nextpage.Name = "nextpage";
            this.nextpage.Size = new System.Drawing.Size(75, 24);
            this.nextpage.TabIndex = 3;
            this.nextpage.Text = "下一页";
            this.nextpage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nextpage.UseCustomBackColor = true;
            this.nextpage.UseCustomForeColor = true;
            this.nextpage.UseSelectable = true;
            this.nextpage.Click += new System.EventHandler(this.nextpage_Click);
            // 
            // uppage
            // 
            this.uppage.BackColor = System.Drawing.Color.White;
            this.uppage.BackgroundImage = global::QueryExcel.Properties.Resources.上一页24;
            this.uppage.BackgroundImageDown = null;
            this.uppage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uppage.BackgroundImageUp = null;
            this.uppage.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.uppage.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.uppage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.uppage.IsChecked = false;
            this.uppage.Location = new System.Drawing.Point(668, 13);
            this.uppage.Name = "uppage";
            this.uppage.Size = new System.Drawing.Size(75, 24);
            this.uppage.TabIndex = 2;
            this.uppage.Text = "上一页";
            this.uppage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uppage.UseCustomBackColor = true;
            this.uppage.UseCustomForeColor = true;
            this.uppage.Click += new System.EventHandler(this.uppage_Click);
            // 
            // panelbootomleft
            // 
            this.panelbootomleft.Controls.Add(this.metroButton7);
            this.panelbootomleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelbootomleft.HorizontalScrollbarBarColor = true;
            this.panelbootomleft.HorizontalScrollbarHighlightOnWheel = false;
            this.panelbootomleft.HorizontalScrollbarSize = 10;
            this.panelbootomleft.Location = new System.Drawing.Point(0, 0);
            this.panelbootomleft.Name = "panelbootomleft";
            this.panelbootomleft.Size = new System.Drawing.Size(83, 464);
            this.panelbootomleft.TabIndex = 2;
            this.panelbootomleft.VerticalScrollbarBarColor = true;
            this.panelbootomleft.VerticalScrollbarHighlightOnWheel = false;
            this.panelbootomleft.VerticalScrollbarSize = 10;
            // 
            // metroButton7
            // 
            this.metroButton7.BackColor = System.Drawing.Color.White;
            this.metroButton7.BackgroundImage = global::QueryExcel.Properties.Resources.设置48png;
            this.metroButton7.BackgroundImageDown = null;
            this.metroButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton7.BackgroundImageUp = null;
            this.metroButton7.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.metroButton7.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.metroButton7.IsChecked = false;
            this.metroButton7.Location = new System.Drawing.Point(19, 6);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(48, 71);
            this.metroButton7.TabIndex = 6;
            this.metroButton7.Text = "设置";
            this.metroButton7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroButton7.UseCustomBackColor = true;
            this.metroButton7.UseCustomForeColor = true;
            this.metroButton7.UseSelectable = true;
            this.metroButton7.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // paneltopoperation
            // 
            this.paneltopoperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.paneltopoperation.Controls.Add(this.delete);
            this.paneltopoperation.Controls.Add(this.fresh);
            this.paneltopoperation.Controls.Add(this.down);
            this.paneltopoperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltopoperation.HorizontalScrollbarBarColor = true;
            this.paneltopoperation.HorizontalScrollbarHighlightOnWheel = false;
            this.paneltopoperation.HorizontalScrollbarSize = 10;
            this.paneltopoperation.Location = new System.Drawing.Point(0, 110);
            this.paneltopoperation.Name = "paneltopoperation";
            this.paneltopoperation.Size = new System.Drawing.Size(980, 38);
            this.paneltopoperation.TabIndex = 1;
            this.paneltopoperation.UseCustomBackColor = true;
            this.paneltopoperation.VerticalScrollbarBarColor = true;
            this.paneltopoperation.VerticalScrollbarHighlightOnWheel = false;
            this.paneltopoperation.VerticalScrollbarSize = 10;
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
            this.delete.Location = new System.Drawing.Point(124, 7);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(64, 24);
            this.delete.TabIndex = 8;
            this.delete.Text = "删除";
            this.delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete.UseCustomForeColor = true;
            this.delete.UseSelectable = true;
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
            this.fresh.Location = new System.Drawing.Point(733, 7);
            this.fresh.Name = "fresh";
            this.fresh.Size = new System.Drawing.Size(93, 24);
            this.fresh.TabIndex = 7;
            this.fresh.Text = "刷新列表";
            this.fresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fresh.UseCustomForeColor = true;
            this.fresh.UseSelectable = true;
            this.fresh.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // down
            // 
            this.down.BackgroundImage = global::QueryExcel.Properties.Resources.下载24;
            this.down.BackgroundImageDown = null;
            this.down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.down.BackgroundImageUp = null;
            this.down.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.down.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.down.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.down.IsChecked = false;
            this.down.Location = new System.Drawing.Point(19, 7);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(64, 24);
            this.down.TabIndex = 4;
            this.down.Text = "下载";
            this.down.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.down.UseCustomForeColor = true;
            this.down.UseSelectable = true;
            this.down.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.paneltop.Controls.Add(this.metroButton6);
            this.paneltop.Controls.Add(this.metroButton5);
            this.paneltop.Controls.Add(this.metroButton2);
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.HorizontalScrollbarBarColor = true;
            this.paneltop.HorizontalScrollbarHighlightOnWheel = false;
            this.paneltop.HorizontalScrollbarSize = 10;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.Size = new System.Drawing.Size(980, 110);
            this.paneltop.TabIndex = 0;
            this.paneltop.UseCustomBackColor = true;
            this.paneltop.VerticalScrollbarBarColor = true;
            this.paneltop.VerticalScrollbarHighlightOnWheel = false;
            this.paneltop.VerticalScrollbarSize = 10;
            this.paneltop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paneltop_MouseDown);
            this.paneltop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paneltop_MouseMove);
            // 
            // metroButton6
            // 
            this.metroButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.metroButton6.BackgroundImageDown = null;
            this.metroButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton6.BackgroundImageUp = null;
            this.metroButton6.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.metroButton6.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton6.ForeColor = System.Drawing.Color.White;
            this.metroButton6.IsChecked = false;
            this.metroButton6.Location = new System.Drawing.Point(342, 15);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(72, 90);
            this.metroButton6.TabIndex = 6;
            this.metroButton6.Text = "下载列表";
            this.metroButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroButton6.UseCustomBackColor = true;
            this.metroButton6.UseCustomForeColor = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.metroButton5.BackgroundImageDown = null;
            this.metroButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton5.BackgroundImageUp = null;
            this.metroButton5.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.metroButton5.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton5.ForeColor = System.Drawing.Color.White;
            this.metroButton5.IsChecked = false;
            this.metroButton5.Location = new System.Drawing.Point(875, 15);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(72, 90);
            this.metroButton5.TabIndex = 5;
            this.metroButton5.Text = "退出";
            this.metroButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroButton5.UseCustomBackColor = true;
            this.metroButton5.UseCustomForeColor = true;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.metroButton2.BackgroundImageDown = null;
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton2.BackgroundImageUp = null;
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Px14;
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.ForeColor = System.Drawing.Color.White;
            this.metroButton2.IsChecked = false;
            this.metroButton2.Location = new System.Drawing.Point(173, 15);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(72, 90);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "文件列表";
            this.metroButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // num
            // 
            this.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num.FillWeight = 30F;
            this.num.HeaderText = "序号";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // mobile
            // 
            this.mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mobile.HeaderText = "手机号";
            this.mobile.Name = "mobile";
            this.mobile.ReadOnly = true;
            // 
            // day
            // 
            this.day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.day.HeaderText = "通话日期";
            this.day.Name = "day";
            this.day.ReadOnly = true;
            // 
            // time
            // 
            this.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.time.HeaderText = "通话时间";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.type.HeaderText = "通话方式";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // man
            // 
            this.man.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.man.HeaderText = "联系人";
            this.man.Name = "man";
            this.man.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "公司名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 612);
            this.ControlBox = false;
            this.Controls.Add(this.panelbottom);
            this.Controls.Add(this.paneltopoperation);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mainform";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.panelbottom.ResumeLayout(false);
            this.panelbottomfull.ResumeLayout(false);
            this.panelbottomfulltop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.panelbottomfullbottom.ResumeLayout(false);
            this.panelbootomleft.ResumeLayout(false);
            this.paneltopoperation.ResumeLayout(false);
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel paneltop;
        private MetroFramework.Controls.MetroPanel paneltopoperation;
        private MetroFramework.Controls.MetroPanel panelbottom;
        private MetroFramework.Controls.MetroPanel panelbootomleft;
        private MetroFramework.Controls.MetroPanel panelbottomfull;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton down;
        private smartpos.wpos.App.Components.UserDefined.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroPanel panelbottomfullbottom;
        private MetroFramework.Controls.MetroPanel panelbottomfulltop;
        private MetroFramework.Controls.MetroButton nextpage;
        private MetroFramework.Controls.MetroButton uppage;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton delete;
        private MetroFramework.Controls.MetroButton fresh;
        private MetroFramework.Controls.MetroButton metroButton7;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn day;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn man;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}