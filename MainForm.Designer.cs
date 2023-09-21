namespace BFSSpiralTree
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainPanel = new Panel();
            btnPreview = new Button();
            splitContainer1 = new SplitContainer();
            grpAdjustCurls = new GroupBox();
            lblSpread = new Label();
            lblShift = new Label();
            trkSpread = new TrackBar();
            trkShift = new TrackBar();
            lnkSpread = new LinkLabel();
            lnkShift = new LinkLabel();
            lnkAddShift = new LinkLabel();
            lnkSubShift = new LinkLabel();
            lnkSubSprd = new LinkLabel();
            lnkAddSprd = new LinkLabel();
            groupBox9 = new GroupBox();
            btnCopy = new Button();
            btnSVG = new Button();
            grpBoxOrigin = new GroupBox();
            chkTwin = new CheckBox();
            lblAngle = new Label();
            trkStrtAngle = new TrackBar();
            chkRandAngl = new CheckBox();
            lblStrtAngle = new Label();
            label3 = new Label();
            lnkAddStrt = new LinkLabel();
            lnkSubStrt = new LinkLabel();
            colorBox = new GroupBox();
            btnBkgColor = new Button();
            btnScrollColor = new Button();
            groupBox5 = new GroupBox();
            updownMaxLeaves = new DomainUpDown();
            label4 = new Label();
            chkRndLeaves = new CheckBox();
            groupBox1 = new GroupBox();
            rdioNoRnd = new RadioButton();
            rdioRndLrg = new RadioButton();
            rdioRndSz = new RadioButton();
            groupBox4 = new GroupBox();
            txtMaxNodes = new TextBox();
            label2 = new Label();
            trkMaxTotal = new TrackBar();
            lnkSubNodes = new LinkLabel();
            lnkAddNodes = new LinkLabel();
            groupBox2 = new GroupBox();
            rdioGradStoL = new RadioButton();
            rdioGradLtoS = new RadioButton();
            chkGradSz = new CheckBox();
            groupBox3 = new GroupBox();
            ChkLgMax = new CheckBox();
            rdioOpt5 = new RadioButton();
            rdioOpt4 = new RadioButton();
            rdioOpt3 = new RadioButton();
            rdioOpt2 = new RadioButton();
            rdioOpt1 = new RadioButton();
            groupBox6 = new GroupBox();
            lnkSproutAngle = new LinkLabel();
            lblSproutAngle = new Label();
            trkSproutAngle = new TrackBar();
            chkResprout = new CheckBox();
            lnkSubSprout = new LinkLabel();
            lnkAddSprout = new LinkLabel();
            lnkIDs = new LinkLabel();
            lnkLog = new LinkLabel();
            clrDlgScroll = new ColorDialog();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpAdjustCurls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkSpread).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkShift).BeginInit();
            groupBox9.SuspendLayout();
            grpBoxOrigin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkStrtAngle).BeginInit();
            colorBox.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkMaxTotal).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkSproutAngle).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.BackColor = Color.White;
            mainPanel.Font = new Font("Segoe UI Light", 8F, FontStyle.Regular, GraphicsUnit.Point);
            mainPanel.Location = new Point(129, 3);
            mainPanel.MinimumSize = new Size(500, 500);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(600, 601);
            mainPanel.TabIndex = 1;
            mainPanel.Paint += MainPanel_Paint;
            // 
            // btnPreview
            // 
            btnPreview.Location = new Point(708, 199);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(132, 34);
            btnPreview.TabIndex = 8;
            btnPreview.Text = "preview";
            toolTip1.SetToolTip(btnPreview, "refresh image with new options");
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += BtnPreview_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.MinimumSize = new Size(850, 850);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpAdjustCurls);
            splitContainer1.Panel1.Controls.Add(groupBox9);
            splitContainer1.Panel1.Controls.Add(grpBoxOrigin);
            splitContainer1.Panel1.Controls.Add(colorBox);
            splitContainer1.Panel1.Controls.Add(groupBox5);
            splitContainer1.Panel1.Controls.Add(btnPreview);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(groupBox4);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(groupBox6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lnkIDs);
            splitContainer1.Panel2.Controls.Add(lnkLog);
            splitContainer1.Panel2.Controls.Add(mainPanel);
            splitContainer1.Panel2.Resize += SplitContainer1_Panel2_Resize;
            splitContainer1.Size = new Size(859, 852);
            splitContainer1.SplitterDistance = 241;
            splitContainer1.TabIndex = 0;
            // 
            // grpAdjustCurls
            // 
            grpAdjustCurls.Controls.Add(lblSpread);
            grpAdjustCurls.Controls.Add(lblShift);
            grpAdjustCurls.Controls.Add(trkSpread);
            grpAdjustCurls.Controls.Add(trkShift);
            grpAdjustCurls.Controls.Add(lnkSpread);
            grpAdjustCurls.Controls.Add(lnkShift);
            grpAdjustCurls.Controls.Add(lnkAddShift);
            grpAdjustCurls.Controls.Add(lnkSubShift);
            grpAdjustCurls.Controls.Add(lnkSubSprd);
            grpAdjustCurls.Controls.Add(lnkAddSprd);
            grpAdjustCurls.Location = new Point(619, 1);
            grpAdjustCurls.Name = "grpAdjustCurls";
            grpAdjustCurls.Size = new Size(224, 131);
            grpAdjustCurls.TabIndex = 34;
            grpAdjustCurls.TabStop = false;
            grpAdjustCurls.Text = "adjust look:";
            // 
            // lblSpread
            // 
            lblSpread.AutoSize = true;
            lblSpread.BackColor = Color.Transparent;
            lblSpread.Location = new Point(61, 82);
            lblSpread.Name = "lblSpread";
            lblSpread.Size = new Size(34, 25);
            lblSpread.TabIndex = 1;
            lblSpread.Text = "+0";
            // 
            // lblShift
            // 
            lblShift.AutoSize = true;
            lblShift.BackColor = Color.Transparent;
            lblShift.Location = new Point(59, 31);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(34, 25);
            lblShift.TabIndex = 0;
            lblShift.Text = "+0";
            // 
            // trkSpread
            // 
            trkSpread.Location = new Point(111, 85);
            trkSpread.Maximum = 50;
            trkSpread.MaximumSize = new Size(300, 30);
            trkSpread.Minimum = -50;
            trkSpread.Name = "trkSpread";
            trkSpread.RightToLeftLayout = true;
            trkSpread.Size = new Size(110, 30);
            trkSpread.TabIndex = 36;
            trkSpread.TickFrequency = 10;
            toolTip1.SetToolTip(trkSpread, "change the size and spacing of leaf curls");
            trkSpread.ValueChanged += TrkSpread_ValueChanged;
            // 
            // trkShift
            // 
            trkShift.Location = new Point(111, 36);
            trkShift.Maximum = 100;
            trkShift.MaximumSize = new Size(300, 30);
            trkShift.Minimum = -100;
            trkShift.Name = "trkShift";
            trkShift.RightToLeftLayout = true;
            trkShift.Size = new Size(109, 30);
            trkShift.TabIndex = 35;
            trkShift.TickFrequency = 20;
            toolTip1.SetToolTip(trkShift, "adjust location of leaf curls on parent");
            trkShift.ValueChanged += TrkShift_ValueChanged;
            // 
            // lnkSpread
            // 
            lnkSpread.ActiveLinkColor = Color.Black;
            lnkSpread.AutoSize = true;
            lnkSpread.LinkColor = Color.Black;
            lnkSpread.Location = new Point(1, 81);
            lnkSpread.Name = "lnkSpread";
            lnkSpread.Size = new Size(70, 25);
            lnkSpread.TabIndex = 37;
            lnkSpread.TabStop = true;
            lnkSpread.Text = "spread:";
            toolTip1.SetToolTip(lnkSpread, "click to reset to 0");
            lnkSpread.VisitedLinkColor = Color.Black;
            lnkSpread.LinkClicked += LnkSpread_LinkClicked;
            // 
            // lnkShift
            // 
            lnkShift.ActiveLinkColor = Color.Black;
            lnkShift.AutoSize = true;
            lnkShift.LinkColor = Color.Black;
            lnkShift.Location = new Point(19, 31);
            lnkShift.Name = "lnkShift";
            lnkShift.Size = new Size(50, 25);
            lnkShift.TabIndex = 29;
            lnkShift.TabStop = true;
            lnkShift.Text = "shift:";
            toolTip1.SetToolTip(lnkShift, "click to reset to 0");
            lnkShift.VisitedLinkColor = Color.Black;
            lnkShift.LinkClicked += LnkShift_LinkClicked;
            // 
            // lnkAddShift
            // 
            lnkAddShift.ActiveLinkColor = Color.Blue;
            lnkAddShift.AutoSize = true;
            lnkAddShift.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lnkAddShift.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddShift.Location = new Point(194, 19);
            lnkAddShift.Name = "lnkAddShift";
            lnkAddShift.Size = new Size(21, 21);
            lnkAddShift.TabIndex = 32;
            lnkAddShift.TabStop = true;
            lnkAddShift.Text = "+";
            toolTip1.SetToolTip(lnkAddShift, "+1");
            lnkAddShift.VisitedLinkColor = Color.Blue;
            lnkAddShift.LinkClicked += LnkAddShift_LinkClicked;
            // 
            // lnkSubShift
            // 
            lnkSubShift.ActiveLinkColor = Color.Blue;
            lnkSubShift.AutoSize = true;
            lnkSubShift.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lnkSubShift.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubShift.Location = new Point(116, 14);
            lnkSubShift.Name = "lnkSubShift";
            lnkSubShift.Size = new Size(20, 28);
            lnkSubShift.TabIndex = 31;
            lnkSubShift.TabStop = true;
            lnkSubShift.Text = "-";
            toolTip1.SetToolTip(lnkSubShift, "-1");
            lnkSubShift.VisitedLinkColor = Color.Blue;
            lnkSubShift.LinkClicked += LnkSubShift_LinkClicked;
            // 
            // lnkSubSprd
            // 
            lnkSubSprd.ActiveLinkColor = Color.Blue;
            lnkSubSprd.AutoSize = true;
            lnkSubSprd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lnkSubSprd.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubSprd.Location = new Point(116, 63);
            lnkSubSprd.Name = "lnkSubSprd";
            lnkSubSprd.Size = new Size(20, 28);
            lnkSubSprd.TabIndex = 38;
            lnkSubSprd.TabStop = true;
            lnkSubSprd.Text = "-";
            toolTip1.SetToolTip(lnkSubSprd, "-1");
            lnkSubSprd.VisitedLinkColor = Color.Blue;
            lnkSubSprd.LinkClicked += LnkSubSprd_LinkClicked;
            // 
            // lnkAddSprd
            // 
            lnkAddSprd.ActiveLinkColor = Color.Blue;
            lnkAddSprd.AutoSize = true;
            lnkAddSprd.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lnkAddSprd.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddSprd.Location = new Point(195, 69);
            lnkAddSprd.Name = "lnkAddSprd";
            lnkAddSprd.Size = new Size(21, 21);
            lnkAddSprd.TabIndex = 39;
            lnkAddSprd.TabStop = true;
            lnkAddSprd.Text = "+";
            toolTip1.SetToolTip(lnkAddSprd, "+1");
            lnkAddSprd.VisitedLinkColor = Color.Blue;
            lnkAddSprd.LinkClicked += LnkAddSprd_LinkClicked;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(btnCopy);
            groupBox9.Controls.Add(btnSVG);
            groupBox9.Location = new Point(704, 130);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(139, 65);
            groupBox9.TabIndex = 33;
            groupBox9.TabStop = false;
            groupBox9.Text = "image";
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(6, 28);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(61, 34);
            btnCopy.TabIndex = 29;
            btnCopy.Text = "copy";
            toolTip1.SetToolTip(btnCopy, "place current image on clipboard");
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += BtnCopy_Click;
            // 
            // btnSVG
            // 
            btnSVG.Location = new Point(71, 27);
            btnSVG.Name = "btnSVG";
            btnSVG.Size = new Size(63, 34);
            btnSVG.TabIndex = 30;
            btnSVG.Text = "svg";
            toolTip1.SetToolTip(btnSVG, "save a vector file of current image");
            btnSVG.UseVisualStyleBackColor = true;
            btnSVG.Click += BtnSVG_Click;
            // 
            // grpBoxOrigin
            // 
            grpBoxOrigin.Controls.Add(lblAngle);
            grpBoxOrigin.Controls.Add(trkStrtAngle);
            grpBoxOrigin.Controls.Add(chkRandAngl);
            grpBoxOrigin.Controls.Add(lblStrtAngle);
            grpBoxOrigin.Controls.Add(label3);
            grpBoxOrigin.Controls.Add(lnkAddStrt);
            grpBoxOrigin.Controls.Add(lnkSubStrt);
            grpBoxOrigin.Controls.Add(chkTwin);
            grpBoxOrigin.Location = new Point(450, 1);
            grpBoxOrigin.Name = "grpBoxOrigin";
            grpBoxOrigin.Size = new Size(165, 140);
            grpBoxOrigin.TabIndex = 22;
            grpBoxOrigin.TabStop = false;
            grpBoxOrigin.Text = "origin";
            // 
            // chkTwin
            // 
            chkTwin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkTwin.AutoSize = true;
            chkTwin.BackColor = Color.Transparent;
            chkTwin.Checked = true;
            chkTwin.CheckState = CheckState.Checked;
            chkTwin.Location = new Point(57, 12);
            chkTwin.Margin = new Padding(0);
            chkTwin.Name = "chkTwin";
            chkTwin.RightToLeft = RightToLeft.Yes;
            chkTwin.Size = new Size(104, 29);
            chkTwin.TabIndex = 6;
            chkTwin.Text = "twin curl";
            toolTip1.SetToolTip(chkTwin, "start curl: single or double");
            chkTwin.UseVisualStyleBackColor = false;
            chkTwin.CheckedChanged += ChkTwin_CheckedChanged;
            // 
            // lblAngle
            // 
            lblAngle.AutoSize = true;
            lblAngle.BackColor = Color.Transparent;
            lblAngle.Location = new Point(96, 44);
            lblAngle.Name = "lblAngle";
            lblAngle.Size = new Size(46, 25);
            lblAngle.TabIndex = 33;
            lblAngle.Text = "0.00";
            // 
            // trkStrtAngle
            // 
            trkStrtAngle.Location = new Point(1, 77);
            trkStrtAngle.Maximum = 200;
            trkStrtAngle.MaximumSize = new Size(300, 30);
            trkStrtAngle.Name = "trkStrtAngle";
            trkStrtAngle.RightToLeftLayout = true;
            trkStrtAngle.Size = new Size(163, 30);
            trkStrtAngle.TabIndex = 22;
            trkStrtAngle.TickFrequency = 25;
            toolTip1.SetToolTip(trkStrtAngle, "adjust angle of first curl");
            trkStrtAngle.ValueChanged += TrkStrtAngle_ValueChanged;
            trkStrtAngle.EnabledChanged += TrkStrtAngle_EnabledChanged;
            // 
            // chkRandAngl
            // 
            chkRandAngl.AutoSize = true;
            chkRandAngl.Location = new Point(42, 109);
            chkRandAngl.Margin = new Padding(0);
            chkRandAngl.Name = "chkRandAngl";
            chkRandAngl.Size = new Size(101, 29);
            chkRandAngl.TabIndex = 21;
            chkRandAngl.Text = "random";
            chkRandAngl.TextAlign = ContentAlignment.TopLeft;
            chkRandAngl.UseVisualStyleBackColor = true;
            chkRandAngl.CheckedChanged += ChkRandAngl_CheckedChanged;
            // 
            // lblStrtAngle
            // 
            lblStrtAngle.AutoSize = true;
            lblStrtAngle.Location = new Point(18, 43);
            lblStrtAngle.Name = "lblStrtAngle";
            lblStrtAngle.Size = new Size(82, 25);
            lblStrtAngle.TabIndex = 34;
            lblStrtAngle.Text = "angle(* ):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 110);
            label3.Name = "label3";
            label3.Size = new Size(29, 25);
            label3.TabIndex = 19;
            label3.Text = "or";
            // 
            // lnkAddStrt
            // 
            lnkAddStrt.ActiveLinkColor = Color.Blue;
            lnkAddStrt.AutoSize = true;
            lnkAddStrt.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lnkAddStrt.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddStrt.Location = new Point(137, 60);
            lnkAddStrt.Name = "lnkAddStrt";
            lnkAddStrt.Size = new Size(21, 21);
            lnkAddStrt.TabIndex = 40;
            lnkAddStrt.TabStop = true;
            lnkAddStrt.Text = "+";
            toolTip1.SetToolTip(lnkAddStrt, "+1");
            lnkAddStrt.VisitedLinkColor = Color.Blue;
            lnkAddStrt.LinkClicked += LnkAddStrt_LinkClicked;
            // 
            // lnkSubStrt
            // 
            lnkSubStrt.ActiveLinkColor = Color.Blue;
            lnkSubStrt.AutoSize = true;
            lnkSubStrt.BackColor = Color.Transparent;
            lnkSubStrt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lnkSubStrt.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubStrt.Location = new Point(7, 53);
            lnkSubStrt.Name = "lnkSubStrt";
            lnkSubStrt.Size = new Size(20, 28);
            lnkSubStrt.TabIndex = 39;
            lnkSubStrt.TabStop = true;
            lnkSubStrt.Text = "-";
            toolTip1.SetToolTip(lnkSubStrt, "-1");
            lnkSubStrt.VisitedLinkColor = Color.Blue;
            lnkSubStrt.LinkClicked += LnkSubStrt_LinkClicked;
            // 
            // colorBox
            // 
            colorBox.Controls.Add(btnBkgColor);
            colorBox.Controls.Add(btnScrollColor);
            colorBox.Location = new Point(620, 130);
            colorBox.Name = "colorBox";
            colorBox.Size = new Size(79, 105);
            colorBox.TabIndex = 26;
            colorBox.TabStop = false;
            colorBox.Text = "colors";
            // 
            // btnBkgColor
            // 
            btnBkgColor.Location = new Point(8, 29);
            btnBkgColor.Name = "btnBkgColor";
            btnBkgColor.Size = new Size(63, 33);
            btnBkgColor.TabIndex = 27;
            btnBkgColor.Text = "panel";
            toolTip1.SetToolTip(btnBkgColor, "change background color");
            btnBkgColor.UseVisualStyleBackColor = true;
            btnBkgColor.Click += BtnBkgColor_Click;
            // 
            // btnScrollColor
            // 
            btnScrollColor.Location = new Point(8, 68);
            btnScrollColor.Name = "btnScrollColor";
            btnScrollColor.Size = new Size(63, 33);
            btnScrollColor.TabIndex = 26;
            btnScrollColor.Text = "scroll";
            toolTip1.SetToolTip(btnScrollColor, "change ornament color");
            btnScrollColor.UseVisualStyleBackColor = true;
            btnScrollColor.Click += BtnScrollColor_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(updownMaxLeaves);
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(chkRndLeaves);
            groupBox5.Location = new Point(7, 68);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(198, 59);
            groupBox5.TabIndex = 20;
            groupBox5.TabStop = false;
            groupBox5.Text = "leaf number";
            // 
            // updownMaxLeaves
            // 
            updownMaxLeaves.Items.Add("7");
            updownMaxLeaves.Items.Add("6");
            updownMaxLeaves.Items.Add("5");
            updownMaxLeaves.Items.Add("4");
            updownMaxLeaves.Items.Add("3");
            updownMaxLeaves.Items.Add("2");
            updownMaxLeaves.Location = new Point(139, 22);
            updownMaxLeaves.Name = "updownMaxLeaves";
            updownMaxLeaves.ReadOnly = true;
            updownMaxLeaves.Size = new Size(48, 31);
            updownMaxLeaves.TabIndex = 0;
            updownMaxLeaves.TextAlign = HorizontalAlignment.Center;
            toolTip1.SetToolTip(updownMaxLeaves, "maximum number of leaves on a node");
            updownMaxLeaves.SelectedItemChanged += UpdownMaxLeaves_SelectedItemChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 25);
            label4.Name = "label4";
            label4.Size = new Size(29, 25);
            label4.TabIndex = 18;
            label4.Text = "or";
            // 
            // chkRndLeaves
            // 
            chkRndLeaves.AutoSize = true;
            chkRndLeaves.Location = new Point(10, 24);
            chkRndLeaves.Name = "chkRndLeaves";
            chkRndLeaves.Size = new Size(101, 29);
            chkRndLeaves.TabIndex = 17;
            chkRndLeaves.Text = "random";
            toolTip1.SetToolTip(chkRndLeaves, "randomly change maximum number of leaves on each node");
            chkRndLeaves.UseVisualStyleBackColor = true;
            chkRndLeaves.CheckedChanged += ChkRndLeaves_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdioNoRnd);
            groupBox1.Controls.Add(rdioRndLrg);
            groupBox1.Controls.Add(rdioRndSz);
            groupBox1.Location = new Point(211, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(235, 59);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "leaf size randomness";
            // 
            // rdioNoRnd
            // 
            rdioNoRnd.AutoSize = true;
            rdioNoRnd.Checked = true;
            rdioNoRnd.Location = new Point(6, 26);
            rdioNoRnd.Name = "rdioNoRnd";
            rdioNoRnd.Size = new Size(77, 29);
            rdioNoRnd.TabIndex = 0;
            rdioNoRnd.TabStop = true;
            rdioNoRnd.Text = "none";
            rdioNoRnd.UseVisualStyleBackColor = true;
            rdioNoRnd.CheckedChanged += RdioNoRnd_CheckedChanged;
            // 
            // rdioRndLrg
            // 
            rdioRndLrg.AutoSize = true;
            rdioRndLrg.Location = new Point(83, 26);
            rdioRndLrg.Name = "rdioRndLrg";
            rdioRndLrg.Size = new Size(81, 29);
            rdioRndLrg.TabIndex = 1;
            rdioRndLrg.Text = "some";
            toolTip1.SetToolTip(rdioRndLrg, "larger than normal leaves will sometimes be drawn");
            rdioRndLrg.UseVisualStyleBackColor = true;
            rdioRndLrg.CheckedChanged += RdioRndLrg_CheckedChanged;
            // 
            // rdioRndSz
            // 
            rdioRndSz.AutoSize = true;
            rdioRndSz.Location = new Point(167, 26);
            rdioRndSz.Name = "rdioRndSz";
            rdioRndSz.Size = new Size(66, 29);
            rdioRndSz.TabIndex = 2;
            rdioRndSz.Text = "lots";
            toolTip1.SetToolTip(rdioRndSz, "made to look as random as possible");
            rdioRndSz.UseVisualStyleBackColor = true;
            rdioRndSz.CheckedChanged += RdioRndSz_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtMaxNodes);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(trkMaxTotal);
            groupBox4.Controls.Add(lnkSubNodes);
            groupBox4.Controls.Add(lnkAddNodes);
            groupBox4.Location = new Point(7, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(439, 66);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "overall number of nodes";
            // 
            // txtMaxNodes
            // 
            txtMaxNodes.Location = new Point(64, 25);
            txtMaxNodes.MaxLength = 3;
            txtMaxNodes.Name = "txtMaxNodes";
            txtMaxNodes.ReadOnly = true;
            txtMaxNodes.Size = new Size(38, 31);
            txtMaxNodes.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 28);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 11;
            label2.Text = "MAX:";
            // 
            // trkMaxTotal
            // 
            trkMaxTotal.LargeChange = 10;
            trkMaxTotal.Location = new Point(108, 29);
            trkMaxTotal.Maximum = 200;
            trkMaxTotal.MaximumSize = new Size(400, 30);
            trkMaxTotal.Name = "trkMaxTotal";
            trkMaxTotal.Size = new Size(319, 30);
            trkMaxTotal.TabIndex = 18;
            trkMaxTotal.TickFrequency = 5;
            toolTip1.SetToolTip(trkMaxTotal, "change total number of nodes/curls");
            trkMaxTotal.ValueChanged += TrkMaxTotal_ValueChanged;
            // 
            // lnkSubNodes
            // 
            lnkSubNodes.ActiveLinkColor = Color.Blue;
            lnkSubNodes.AutoSize = true;
            lnkSubNodes.BackColor = Color.Transparent;
            lnkSubNodes.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lnkSubNodes.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubNodes.Location = new Point(115, 8);
            lnkSubNodes.Name = "lnkSubNodes";
            lnkSubNodes.Size = new Size(20, 28);
            lnkSubNodes.TabIndex = 39;
            lnkSubNodes.TabStop = true;
            lnkSubNodes.Text = "-";
            toolTip1.SetToolTip(lnkSubNodes, "-1");
            lnkSubNodes.VisitedLinkColor = Color.Blue;
            lnkSubNodes.LinkClicked += LnkSubNodes_LinkClicked;
            // 
            // lnkAddNodes
            // 
            lnkAddNodes.ActiveLinkColor = Color.Blue;
            lnkAddNodes.AutoSize = true;
            lnkAddNodes.BackColor = Color.Transparent;
            lnkAddNodes.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lnkAddNodes.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddNodes.Location = new Point(402, 13);
            lnkAddNodes.Name = "lnkAddNodes";
            lnkAddNodes.Size = new Size(21, 21);
            lnkAddNodes.TabIndex = 40;
            lnkAddNodes.TabStop = true;
            lnkAddNodes.Text = "+";
            toolTip1.SetToolTip(lnkAddNodes, "+1");
            lnkAddNodes.VisitedLinkColor = Color.Blue;
            lnkAddNodes.LinkClicked += LnkAddNodes_LinkClicked;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rdioGradStoL);
            groupBox2.Controls.Add(rdioGradLtoS);
            groupBox2.Controls.Add(chkGradSz);
            groupBox2.Location = new Point(7, 123);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(439, 59);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "leaf size variation";
            // 
            // rdioGradStoL
            // 
            rdioGradStoL.AutoSize = true;
            rdioGradStoL.Enabled = false;
            rdioGradStoL.Location = new Point(281, 25);
            rdioGradStoL.Name = "rdioGradStoL";
            rdioGradStoL.Size = new Size(148, 29);
            rdioGradStoL.TabIndex = 5;
            rdioGradStoL.TabStop = true;
            rdioGradStoL.Text = "small-to-large";
            toolTip1.SetToolTip(rdioGradStoL, "start growing with smallest leaf");
            rdioGradStoL.UseVisualStyleBackColor = true;
            rdioGradStoL.CheckedChanged += RdioGradStoL_CheckedChanged;
            // 
            // rdioGradLtoS
            // 
            rdioGradLtoS.AutoSize = true;
            rdioGradLtoS.Enabled = false;
            rdioGradLtoS.Location = new Point(125, 24);
            rdioGradLtoS.Name = "rdioGradLtoS";
            rdioGradLtoS.Size = new Size(148, 29);
            rdioGradLtoS.TabIndex = 4;
            rdioGradLtoS.TabStop = true;
            rdioGradLtoS.Text = "large-to-small";
            toolTip1.SetToolTip(rdioGradLtoS, "start growing with largest leaf");
            rdioGradLtoS.UseVisualStyleBackColor = true;
            // 
            // chkGradSz
            // 
            chkGradSz.AutoSize = true;
            chkGradSz.Location = new Point(8, 24);
            chkGradSz.Name = "chkGradSz";
            chkGradSz.Size = new Size(112, 29);
            chkGradSz.TabIndex = 3;
            chkGradSz.Text = "dissimilar";
            toolTip1.SetToolTip(chkGradSz, "same size leaves on each node");
            chkGradSz.UseVisualStyleBackColor = true;
            chkGradSz.CheckedChanged += ChkGradSz_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ChkLgMax);
            groupBox3.Controls.Add(rdioOpt5);
            groupBox3.Controls.Add(rdioOpt4);
            groupBox3.Controls.Add(rdioOpt3);
            groupBox3.Controls.Add(rdioOpt2);
            groupBox3.Controls.Add(rdioOpt1);
            groupBox3.Location = new Point(7, 176);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(439, 59);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "variation options";
            // 
            // ChkLgMax
            // 
            ChkLgMax.AutoSize = true;
            ChkLgMax.Location = new Point(308, 25);
            ChkLgMax.Name = "ChkLgMax";
            ChkLgMax.Size = new Size(121, 29);
            ChkLgMax.TabIndex = 23;
            ChkLgMax.Text = "larger max";
            toolTip1.SetToolTip(ChkLgMax, "draw fewer, but larger leaves");
            ChkLgMax.UseVisualStyleBackColor = true;
            ChkLgMax.CheckedChanged += ChkLgMax_CheckedChanged;
            // 
            // rdioOpt5
            // 
            rdioOpt5.AutoSize = true;
            rdioOpt5.Location = new Point(240, 24);
            rdioOpt5.Name = "rdioOpt5";
            rdioOpt5.Size = new Size(47, 29);
            rdioOpt5.TabIndex = 4;
            rdioOpt5.TabStop = true;
            rdioOpt5.Text = "5";
            rdioOpt5.UseVisualStyleBackColor = true;
            rdioOpt5.CheckedChanged += RdioOpt5_CheckedChanged;
            // 
            // rdioOpt4
            // 
            rdioOpt4.AutoSize = true;
            rdioOpt4.Location = new Point(180, 24);
            rdioOpt4.Name = "rdioOpt4";
            rdioOpt4.Size = new Size(47, 29);
            rdioOpt4.TabIndex = 3;
            rdioOpt4.TabStop = true;
            rdioOpt4.Text = "4";
            rdioOpt4.UseVisualStyleBackColor = true;
            rdioOpt4.CheckedChanged += RdioOpt4_CheckedChanged;
            // 
            // rdioOpt3
            // 
            rdioOpt3.AutoSize = true;
            rdioOpt3.Location = new Point(125, 24);
            rdioOpt3.Name = "rdioOpt3";
            rdioOpt3.Size = new Size(47, 29);
            rdioOpt3.TabIndex = 2;
            rdioOpt3.TabStop = true;
            rdioOpt3.Text = "3";
            rdioOpt3.UseVisualStyleBackColor = true;
            rdioOpt3.CheckedChanged += RdioOpt3_CheckedChanged;
            // 
            // rdioOpt2
            // 
            rdioOpt2.AutoSize = true;
            rdioOpt2.Location = new Point(68, 24);
            rdioOpt2.Name = "rdioOpt2";
            rdioOpt2.Size = new Size(47, 29);
            rdioOpt2.TabIndex = 1;
            rdioOpt2.TabStop = true;
            rdioOpt2.Text = "2";
            rdioOpt2.UseVisualStyleBackColor = true;
            rdioOpt2.CheckedChanged += RdioOpt2_CheckedChanged;
            // 
            // rdioOpt1
            // 
            rdioOpt1.AutoSize = true;
            rdioOpt1.Location = new Point(13, 24);
            rdioOpt1.Name = "rdioOpt1";
            rdioOpt1.Size = new Size(47, 29);
            rdioOpt1.TabIndex = 0;
            rdioOpt1.TabStop = true;
            rdioOpt1.Text = "1";
            rdioOpt1.UseVisualStyleBackColor = true;
            rdioOpt1.CheckedChanged += RdioOpt1_CheckedChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lnkSproutAngle);
            groupBox6.Controls.Add(lblSproutAngle);
            groupBox6.Controls.Add(trkSproutAngle);
            groupBox6.Controls.Add(chkResprout);
            groupBox6.Controls.Add(lnkSubSprout);
            groupBox6.Controls.Add(lnkAddSprout);
            groupBox6.ForeColor = Color.Black;
            groupBox6.Location = new Point(450, 137);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(165, 98);
            groupBox6.TabIndex = 32;
            groupBox6.TabStop = false;
            groupBox6.Text = "resprout";
            // 
            // lnkSproutAngle
            // 
            lnkSproutAngle.ActiveLinkColor = Color.Black;
            lnkSproutAngle.AutoSize = true;
            lnkSproutAngle.LinkColor = Color.Black;
            lnkSproutAngle.Location = new Point(9, 58);
            lnkSproutAngle.Name = "lnkSproutAngle";
            lnkSproutAngle.Size = new Size(59, 25);
            lnkSproutAngle.TabIndex = 36;
            lnkSproutAngle.TabStop = true;
            lnkSproutAngle.Text = "angle:";
            toolTip1.SetToolTip(lnkSproutAngle, "click to reset to 0");
            lnkSproutAngle.VisitedLinkColor = Color.Black;
            lnkSproutAngle.LinkClicked += LnkSproutAngle_LinkClicked;
            // 
            // lblSproutAngle
            // 
            lblSproutAngle.AutoSize = true;
            lblSproutAngle.Location = new Point(90, 27);
            lblSproutAngle.Name = "lblSproutAngle";
            lblSproutAngle.Size = new Size(39, 25);
            lblSproutAngle.TabIndex = 35;
            lblSproutAngle.Text = " +0";
            // 
            // trkSproutAngle
            // 
            trkSproutAngle.Location = new Point(68, 63);
            trkSproutAngle.Maximum = 20;
            trkSproutAngle.MaximumSize = new Size(300, 30);
            trkSproutAngle.Minimum = -20;
            trkSproutAngle.Name = "trkSproutAngle";
            trkSproutAngle.RightToLeftLayout = true;
            trkSproutAngle.Size = new Size(95, 30);
            trkSproutAngle.TabIndex = 34;
            trkSproutAngle.TickFrequency = 5;
            toolTip1.SetToolTip(trkSproutAngle, "adjust angle of resprouted curls");
            trkSproutAngle.ValueChanged += TrkSproutAngle_ValueChanged;
            trkSproutAngle.EnabledChanged += TrkSproutAngle_EnabledChanged;
            // 
            // chkResprout
            // 
            chkResprout.AutoSize = true;
            chkResprout.Location = new Point(6, 26);
            chkResprout.Margin = new Padding(0, 3, 0, 3);
            chkResprout.Name = "chkResprout";
            chkResprout.RightToLeft = RightToLeft.Yes;
            chkResprout.Size = new Size(59, 29);
            chkResprout.TabIndex = 31;
            chkResprout.Text = "on";
            chkResprout.TextAlign = ContentAlignment.TopRight;
            chkResprout.TextImageRelation = TextImageRelation.TextAboveImage;
            toolTip1.SetToolTip(chkResprout, "add new growth to otherwise terminal leaves");
            chkResprout.UseVisualStyleBackColor = true;
            chkResprout.CheckedChanged += ChkResprout_CheckedChanged;
            // 
            // lnkSubSprout
            // 
            lnkSubSprout.ActiveLinkColor = Color.Blue;
            lnkSubSprout.AutoSize = true;
            lnkSubSprout.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lnkSubSprout.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubSprout.Location = new Point(73, 40);
            lnkSubSprout.Name = "lnkSubSprout";
            lnkSubSprout.Size = new Size(20, 28);
            lnkSubSprout.TabIndex = 37;
            lnkSubSprout.TabStop = true;
            lnkSubSprout.Text = "-";
            toolTip1.SetToolTip(lnkSubSprout, "-1");
            lnkSubSprout.VisitedLinkColor = Color.Blue;
            lnkSubSprout.LinkClicked += LnkSubSprout_LinkClicked;
            // 
            // lnkAddSprout
            // 
            lnkAddSprout.ActiveLinkColor = Color.Blue;
            lnkAddSprout.AutoSize = true;
            lnkAddSprout.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lnkAddSprout.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddSprout.Location = new Point(138, 45);
            lnkAddSprout.Name = "lnkAddSprout";
            lnkAddSprout.Size = new Size(21, 21);
            lnkAddSprout.TabIndex = 38;
            lnkAddSprout.TabStop = true;
            lnkAddSprout.Text = "+";
            toolTip1.SetToolTip(lnkAddSprout, "+1");
            lnkAddSprout.VisitedLinkColor = Color.Blue;
            lnkAddSprout.LinkClicked += LnkAddSprout_LinkClicked;
            // 
            // lnkIDs
            // 
            lnkIDs.ActiveLinkColor = Color.DimGray;
            lnkIDs.AutoSize = true;
            lnkIDs.BackColor = Color.Transparent;
            lnkIDs.DisabledLinkColor = Color.Gray;
            lnkIDs.Font = new Font("Calibri Light", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lnkIDs.LinkColor = Color.Silver;
            lnkIDs.Location = new Point(5, 27);
            lnkIDs.Name = "lnkIDs";
            lnkIDs.Size = new Size(29, 19);
            lnkIDs.TabIndex = 27;
            lnkIDs.TabStop = true;
            lnkIDs.Text = "IDs";
            toolTip1.SetToolTip(lnkIDs, "debugging: show node IDs");
            lnkIDs.LinkClicked += LnkIDs_LinkClicked;
            // 
            // lnkLog
            // 
            lnkLog.ActiveLinkColor = Color.DimGray;
            lnkLog.AutoSize = true;
            lnkLog.BackColor = Color.Transparent;
            lnkLog.DisabledLinkColor = Color.Gray;
            lnkLog.Font = new Font("Calibri Light", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lnkLog.LinkColor = Color.Silver;
            lnkLog.Location = new Point(5, 5);
            lnkLog.Name = "lnkLog";
            lnkLog.Size = new Size(33, 19);
            lnkLog.TabIndex = 28;
            lnkLog.TabStop = true;
            lnkLog.Text = "log ";
            toolTip1.SetToolTip(lnkLog, "debugging: create process log");
            lnkLog.LinkClicked += LnkLog_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 852);
            Controls.Add(splitContainer1);
            ForeColor = Color.Black;
            Name = "MainForm";
            Text = "Scroll Generator";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpAdjustCurls.ResumeLayout(false);
            grpAdjustCurls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkSpread).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkShift).EndInit();
            groupBox9.ResumeLayout(false);
            grpBoxOrigin.ResumeLayout(false);
            grpBoxOrigin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkStrtAngle).EndInit();
            colorBox.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkMaxTotal).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkSproutAngle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private SplitContainer splitContainer1;
        private RadioButton rdioNoRnd;
        private CheckBox chkGradSz;
        private RadioButton rdioRndSz;
        private RadioButton rdioRndLrg;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private RadioButton rdioGradStoL;
        private RadioButton rdioGradLtoS;
        private CheckBox chkTwin;
        private Button btnPreview;
        private GroupBox groupBox3;
        private RadioButton rdioOpt3;
        private RadioButton rdioOpt2;
        private RadioButton rdioOpt1;
        private RadioButton rdioOpt5;
        private RadioButton rdioOpt4;
        private Label label2;
        private TrackBar trkMaxTotal;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private TextBox txtMaxNodes;
        private CheckBox chkRandAngl;
        private Label label4;
        private CheckBox chkRndLeaves;
        private CheckBox ChkLgMax;
        private ColorDialog clrDlgScroll;
        private DomainUpDown updownMaxLeaves;
        private Button btnBkgColor;
        private Button btnScrollColor;
        private GroupBox colorBox;
        private LinkLabel lnkLog;
        private LinkLabel lnkIDs;
        private Button btnCopy;
        private Button btnSVG;
        private CheckBox chkResprout;
        private GroupBox groupBox6;
        private TrackBar trkStrtAngle;
        private Label label3;
        private GroupBox groupBox9;
        private GroupBox grpBoxOrigin;
        private ToolTip toolTip1;
        private Label lblStrtAngle;
        private Label lblAngle;
        private TrackBar trkSproutAngle;
        private GroupBox grpAdjustCurls;
        private Label lblSpread;
        private Label lblShift;
        private Label lblSproutAngle;
        private TrackBar trkSpread;
        private TrackBar trkShift;
        private LinkLabel lnkSpread;
        private LinkLabel lnkShift;
        private LinkLabel lnkSproutAngle;
        private LinkLabel lnkAddShift;
        private LinkLabel lnkSubShift;
        private LinkLabel lnkAddSprd;
        private LinkLabel lnkSubSprd;
        private LinkLabel lnkSubSprout;
        private LinkLabel lnkAddSprout;
        private LinkLabel lnkSubStrt;
        private LinkLabel lnkAddStrt;
        private LinkLabel lnkSubNodes;
        private LinkLabel lnkAddNodes;
    }
}