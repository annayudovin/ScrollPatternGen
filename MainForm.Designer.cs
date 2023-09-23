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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            lblAngle = new Label();
            trkStrtAngle = new TrackBar();
            chkRandAngl = new CheckBox();
            lblStrtAngle = new Label();
            label3 = new Label();
            lnkAddStrt = new LinkLabel();
            lnkSubStrt = new LinkLabel();
            chkTwin = new CheckBox();
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
            resources.ApplyResources(mainPanel, "mainPanel");
            mainPanel.BackColor = Color.White;
            mainPanel.Name = "mainPanel";
            toolTip1.SetToolTip(mainPanel, resources.GetString("mainPanel.ToolTip"));
            mainPanel.Paint += MainPanel_Paint;
            // 
            // btnPreview
            // 
            resources.ApplyResources(btnPreview, "btnPreview");
            btnPreview.Name = "btnPreview";
            toolTip1.SetToolTip(btnPreview, resources.GetString("btnPreview.ToolTip"));
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += BtnPreview_Click;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(splitContainer1.Panel1, "splitContainer1.Panel1");
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
            toolTip1.SetToolTip(splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
            splitContainer1.Panel2.Controls.Add(lnkIDs);
            splitContainer1.Panel2.Controls.Add(lnkLog);
            splitContainer1.Panel2.Controls.Add(mainPanel);
            toolTip1.SetToolTip(splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            splitContainer1.Panel2.Resize += SplitContainer1_Panel2_Resize;
            toolTip1.SetToolTip(splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            // 
            // grpAdjustCurls
            // 
            resources.ApplyResources(grpAdjustCurls, "grpAdjustCurls");
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
            grpAdjustCurls.Name = "grpAdjustCurls";
            grpAdjustCurls.TabStop = false;
            toolTip1.SetToolTip(grpAdjustCurls, resources.GetString("grpAdjustCurls.ToolTip"));
            // 
            // lblSpread
            // 
            resources.ApplyResources(lblSpread, "lblSpread");
            lblSpread.BackColor = Color.Transparent;
            lblSpread.Name = "lblSpread";
            toolTip1.SetToolTip(lblSpread, resources.GetString("lblSpread.ToolTip"));
            // 
            // lblShift
            // 
            resources.ApplyResources(lblShift, "lblShift");
            lblShift.BackColor = Color.Transparent;
            lblShift.Name = "lblShift";
            toolTip1.SetToolTip(lblShift, resources.GetString("lblShift.ToolTip"));
            // 
            // trkSpread
            // 
            resources.ApplyResources(trkSpread, "trkSpread");
            trkSpread.Maximum = 50;
            trkSpread.Minimum = -50;
            trkSpread.Name = "trkSpread";
            trkSpread.TickFrequency = 10;
            toolTip1.SetToolTip(trkSpread, resources.GetString("trkSpread.ToolTip"));
            trkSpread.ValueChanged += TrkSpread_ValueChanged;
            // 
            // trkShift
            // 
            resources.ApplyResources(trkShift, "trkShift");
            trkShift.Maximum = 100;
            trkShift.Minimum = -100;
            trkShift.Name = "trkShift";
            trkShift.TickFrequency = 20;
            toolTip1.SetToolTip(trkShift, resources.GetString("trkShift.ToolTip"));
            trkShift.ValueChanged += TrkShift_ValueChanged;
            // 
            // lnkSpread
            // 
            resources.ApplyResources(lnkSpread, "lnkSpread");
            lnkSpread.ActiveLinkColor = Color.Black;
            lnkSpread.LinkColor = Color.Black;
            lnkSpread.Name = "lnkSpread";
            lnkSpread.TabStop = true;
            toolTip1.SetToolTip(lnkSpread, resources.GetString("lnkSpread.ToolTip"));
            lnkSpread.VisitedLinkColor = Color.Black;
            lnkSpread.LinkClicked += LnkSpread_LinkClicked;
            // 
            // lnkShift
            // 
            resources.ApplyResources(lnkShift, "lnkShift");
            lnkShift.ActiveLinkColor = Color.Black;
            lnkShift.LinkColor = Color.Black;
            lnkShift.Name = "lnkShift";
            lnkShift.TabStop = true;
            toolTip1.SetToolTip(lnkShift, resources.GetString("lnkShift.ToolTip"));
            lnkShift.VisitedLinkColor = Color.Black;
            lnkShift.LinkClicked += LnkShift_LinkClicked;
            // 
            // lnkAddShift
            // 
            resources.ApplyResources(lnkAddShift, "lnkAddShift");
            lnkAddShift.ActiveLinkColor = Color.Blue;
            lnkAddShift.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddShift.Name = "lnkAddShift";
            lnkAddShift.TabStop = true;
            toolTip1.SetToolTip(lnkAddShift, resources.GetString("lnkAddShift.ToolTip"));
            lnkAddShift.VisitedLinkColor = Color.Blue;
            lnkAddShift.LinkClicked += LnkAddShift_LinkClicked;
            // 
            // lnkSubShift
            // 
            resources.ApplyResources(lnkSubShift, "lnkSubShift");
            lnkSubShift.ActiveLinkColor = Color.Blue;
            lnkSubShift.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubShift.Name = "lnkSubShift";
            lnkSubShift.TabStop = true;
            toolTip1.SetToolTip(lnkSubShift, resources.GetString("lnkSubShift.ToolTip"));
            lnkSubShift.VisitedLinkColor = Color.Blue;
            lnkSubShift.LinkClicked += LnkSubShift_LinkClicked;
            // 
            // lnkSubSprd
            // 
            resources.ApplyResources(lnkSubSprd, "lnkSubSprd");
            lnkSubSprd.ActiveLinkColor = Color.Blue;
            lnkSubSprd.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubSprd.Name = "lnkSubSprd";
            lnkSubSprd.TabStop = true;
            toolTip1.SetToolTip(lnkSubSprd, resources.GetString("lnkSubSprd.ToolTip"));
            lnkSubSprd.VisitedLinkColor = Color.Blue;
            lnkSubSprd.LinkClicked += LnkSubSprd_LinkClicked;
            // 
            // lnkAddSprd
            // 
            resources.ApplyResources(lnkAddSprd, "lnkAddSprd");
            lnkAddSprd.ActiveLinkColor = Color.Blue;
            lnkAddSprd.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddSprd.Name = "lnkAddSprd";
            lnkAddSprd.TabStop = true;
            toolTip1.SetToolTip(lnkAddSprd, resources.GetString("lnkAddSprd.ToolTip"));
            lnkAddSprd.VisitedLinkColor = Color.Blue;
            lnkAddSprd.LinkClicked += LnkAddSprd_LinkClicked;
            // 
            // groupBox9
            // 
            resources.ApplyResources(groupBox9, "groupBox9");
            groupBox9.Controls.Add(btnCopy);
            groupBox9.Controls.Add(btnSVG);
            groupBox9.Name = "groupBox9";
            groupBox9.TabStop = false;
            toolTip1.SetToolTip(groupBox9, resources.GetString("groupBox9.ToolTip"));
            // 
            // btnCopy
            // 
            resources.ApplyResources(btnCopy, "btnCopy");
            btnCopy.Name = "btnCopy";
            toolTip1.SetToolTip(btnCopy, resources.GetString("btnCopy.ToolTip"));
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += BtnCopy_Click;
            // 
            // btnSVG
            // 
            resources.ApplyResources(btnSVG, "btnSVG");
            btnSVG.Name = "btnSVG";
            toolTip1.SetToolTip(btnSVG, resources.GetString("btnSVG.ToolTip"));
            btnSVG.UseVisualStyleBackColor = true;
            btnSVG.Click += BtnSVG_Click;
            // 
            // grpBoxOrigin
            // 
            resources.ApplyResources(grpBoxOrigin, "grpBoxOrigin");
            grpBoxOrigin.Controls.Add(lblAngle);
            grpBoxOrigin.Controls.Add(trkStrtAngle);
            grpBoxOrigin.Controls.Add(chkRandAngl);
            grpBoxOrigin.Controls.Add(lblStrtAngle);
            grpBoxOrigin.Controls.Add(label3);
            grpBoxOrigin.Controls.Add(lnkAddStrt);
            grpBoxOrigin.Controls.Add(lnkSubStrt);
            grpBoxOrigin.Controls.Add(chkTwin);
            grpBoxOrigin.Name = "grpBoxOrigin";
            grpBoxOrigin.TabStop = false;
            toolTip1.SetToolTip(grpBoxOrigin, resources.GetString("grpBoxOrigin.ToolTip"));
            // 
            // lblAngle
            // 
            resources.ApplyResources(lblAngle, "lblAngle");
            lblAngle.BackColor = Color.Transparent;
            lblAngle.Name = "lblAngle";
            toolTip1.SetToolTip(lblAngle, resources.GetString("lblAngle.ToolTip"));
            // 
            // trkStrtAngle
            // 
            resources.ApplyResources(trkStrtAngle, "trkStrtAngle");
            trkStrtAngle.Maximum = 200;
            trkStrtAngle.Name = "trkStrtAngle";
            trkStrtAngle.TickFrequency = 25;
            toolTip1.SetToolTip(trkStrtAngle, resources.GetString("trkStrtAngle.ToolTip"));
            trkStrtAngle.ValueChanged += TrkStrtAngle_ValueChanged;
            trkStrtAngle.EnabledChanged += TrkStrtAngle_EnabledChanged;
            // 
            // chkRandAngl
            // 
            resources.ApplyResources(chkRandAngl, "chkRandAngl");
            chkRandAngl.Name = "chkRandAngl";
            toolTip1.SetToolTip(chkRandAngl, resources.GetString("chkRandAngl.ToolTip"));
            chkRandAngl.UseVisualStyleBackColor = true;
            chkRandAngl.CheckedChanged += ChkRandAngl_CheckedChanged;
            // 
            // lblStrtAngle
            // 
            resources.ApplyResources(lblStrtAngle, "lblStrtAngle");
            lblStrtAngle.Name = "lblStrtAngle";
            toolTip1.SetToolTip(lblStrtAngle, resources.GetString("lblStrtAngle.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            toolTip1.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // lnkAddStrt
            // 
            resources.ApplyResources(lnkAddStrt, "lnkAddStrt");
            lnkAddStrt.ActiveLinkColor = Color.Blue;
            lnkAddStrt.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddStrt.Name = "lnkAddStrt";
            lnkAddStrt.TabStop = true;
            toolTip1.SetToolTip(lnkAddStrt, resources.GetString("lnkAddStrt.ToolTip"));
            lnkAddStrt.VisitedLinkColor = Color.Blue;
            lnkAddStrt.LinkClicked += LnkAddStrt_LinkClicked;
            // 
            // lnkSubStrt
            // 
            resources.ApplyResources(lnkSubStrt, "lnkSubStrt");
            lnkSubStrt.ActiveLinkColor = Color.Blue;
            lnkSubStrt.BackColor = Color.Transparent;
            lnkSubStrt.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubStrt.Name = "lnkSubStrt";
            lnkSubStrt.TabStop = true;
            toolTip1.SetToolTip(lnkSubStrt, resources.GetString("lnkSubStrt.ToolTip"));
            lnkSubStrt.VisitedLinkColor = Color.Blue;
            lnkSubStrt.LinkClicked += LnkSubStrt_LinkClicked;
            // 
            // chkTwin
            // 
            resources.ApplyResources(chkTwin, "chkTwin");
            chkTwin.BackColor = Color.Transparent;
            chkTwin.Checked = true;
            chkTwin.CheckState = CheckState.Checked;
            chkTwin.Name = "chkTwin";
            toolTip1.SetToolTip(chkTwin, resources.GetString("chkTwin.ToolTip"));
            chkTwin.UseVisualStyleBackColor = false;
            chkTwin.CheckedChanged += ChkTwin_CheckedChanged;
            // 
            // colorBox
            // 
            resources.ApplyResources(colorBox, "colorBox");
            colorBox.Controls.Add(btnBkgColor);
            colorBox.Controls.Add(btnScrollColor);
            colorBox.Name = "colorBox";
            colorBox.TabStop = false;
            toolTip1.SetToolTip(colorBox, resources.GetString("colorBox.ToolTip"));
            // 
            // btnBkgColor
            // 
            resources.ApplyResources(btnBkgColor, "btnBkgColor");
            btnBkgColor.Name = "btnBkgColor";
            toolTip1.SetToolTip(btnBkgColor, resources.GetString("btnBkgColor.ToolTip"));
            btnBkgColor.UseVisualStyleBackColor = true;
            btnBkgColor.Click += BtnBkgColor_Click;
            // 
            // btnScrollColor
            // 
            resources.ApplyResources(btnScrollColor, "btnScrollColor");
            btnScrollColor.Name = "btnScrollColor";
            toolTip1.SetToolTip(btnScrollColor, resources.GetString("btnScrollColor.ToolTip"));
            btnScrollColor.UseVisualStyleBackColor = true;
            btnScrollColor.Click += BtnScrollColor_Click;
            // 
            // groupBox5
            // 
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.Controls.Add(updownMaxLeaves);
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(chkRndLeaves);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
            toolTip1.SetToolTip(groupBox5, resources.GetString("groupBox5.ToolTip"));
            // 
            // updownMaxLeaves
            // 
            resources.ApplyResources(updownMaxLeaves, "updownMaxLeaves");
            updownMaxLeaves.Items.Add(resources.GetString("updownMaxLeaves.Items"));
            updownMaxLeaves.Items.Add(resources.GetString("updownMaxLeaves.Items1"));
            updownMaxLeaves.Items.Add(resources.GetString("updownMaxLeaves.Items2"));
            updownMaxLeaves.Items.Add(resources.GetString("updownMaxLeaves.Items3"));
            updownMaxLeaves.Items.Add(resources.GetString("updownMaxLeaves.Items4"));
            updownMaxLeaves.Items.Add(resources.GetString("updownMaxLeaves.Items5"));
            updownMaxLeaves.Name = "updownMaxLeaves";
            updownMaxLeaves.ReadOnly = true;
            toolTip1.SetToolTip(updownMaxLeaves, resources.GetString("updownMaxLeaves.ToolTip"));
            updownMaxLeaves.SelectedItemChanged += UpdownMaxLeaves_SelectedItemChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            toolTip1.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // chkRndLeaves
            // 
            resources.ApplyResources(chkRndLeaves, "chkRndLeaves");
            chkRndLeaves.Name = "chkRndLeaves";
            toolTip1.SetToolTip(chkRndLeaves, resources.GetString("chkRndLeaves.ToolTip"));
            chkRndLeaves.UseVisualStyleBackColor = true;
            chkRndLeaves.CheckedChanged += ChkRndLeaves_CheckedChanged;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(rdioNoRnd);
            groupBox1.Controls.Add(rdioRndLrg);
            groupBox1.Controls.Add(rdioRndSz);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            toolTip1.SetToolTip(groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // rdioNoRnd
            // 
            resources.ApplyResources(rdioNoRnd, "rdioNoRnd");
            rdioNoRnd.Checked = true;
            rdioNoRnd.Name = "rdioNoRnd";
            rdioNoRnd.TabStop = true;
            toolTip1.SetToolTip(rdioNoRnd, resources.GetString("rdioNoRnd.ToolTip"));
            rdioNoRnd.UseVisualStyleBackColor = true;
            rdioNoRnd.CheckedChanged += RdioNoRnd_CheckedChanged;
            // 
            // rdioRndLrg
            // 
            resources.ApplyResources(rdioRndLrg, "rdioRndLrg");
            rdioRndLrg.Name = "rdioRndLrg";
            toolTip1.SetToolTip(rdioRndLrg, resources.GetString("rdioRndLrg.ToolTip"));
            rdioRndLrg.UseVisualStyleBackColor = true;
            rdioRndLrg.CheckedChanged += RdioRndLrg_CheckedChanged;
            // 
            // rdioRndSz
            // 
            resources.ApplyResources(rdioRndSz, "rdioRndSz");
            rdioRndSz.Name = "rdioRndSz";
            toolTip1.SetToolTip(rdioRndSz, resources.GetString("rdioRndSz.ToolTip"));
            rdioRndSz.UseVisualStyleBackColor = true;
            rdioRndSz.CheckedChanged += RdioRndSz_CheckedChanged;
            // 
            // groupBox4
            // 
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Controls.Add(txtMaxNodes);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(trkMaxTotal);
            groupBox4.Controls.Add(lnkSubNodes);
            groupBox4.Controls.Add(lnkAddNodes);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            toolTip1.SetToolTip(groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // txtMaxNodes
            // 
            resources.ApplyResources(txtMaxNodes, "txtMaxNodes");
            txtMaxNodes.Name = "txtMaxNodes";
            txtMaxNodes.ReadOnly = true;
            toolTip1.SetToolTip(txtMaxNodes, resources.GetString("txtMaxNodes.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            toolTip1.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // trkMaxTotal
            // 
            resources.ApplyResources(trkMaxTotal, "trkMaxTotal");
            trkMaxTotal.LargeChange = 10;
            trkMaxTotal.Maximum = 200;
            trkMaxTotal.Name = "trkMaxTotal";
            trkMaxTotal.TickFrequency = 5;
            toolTip1.SetToolTip(trkMaxTotal, resources.GetString("trkMaxTotal.ToolTip"));
            trkMaxTotal.ValueChanged += TrkMaxTotal_ValueChanged;
            // 
            // lnkSubNodes
            // 
            resources.ApplyResources(lnkSubNodes, "lnkSubNodes");
            lnkSubNodes.ActiveLinkColor = Color.Blue;
            lnkSubNodes.BackColor = Color.Transparent;
            lnkSubNodes.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubNodes.Name = "lnkSubNodes";
            lnkSubNodes.TabStop = true;
            toolTip1.SetToolTip(lnkSubNodes, resources.GetString("lnkSubNodes.ToolTip"));
            lnkSubNodes.VisitedLinkColor = Color.Blue;
            lnkSubNodes.LinkClicked += LnkSubNodes_LinkClicked;
            // 
            // lnkAddNodes
            // 
            resources.ApplyResources(lnkAddNodes, "lnkAddNodes");
            lnkAddNodes.ActiveLinkColor = Color.Blue;
            lnkAddNodes.BackColor = Color.Transparent;
            lnkAddNodes.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddNodes.Name = "lnkAddNodes";
            lnkAddNodes.TabStop = true;
            toolTip1.SetToolTip(lnkAddNodes, resources.GetString("lnkAddNodes.ToolTip"));
            lnkAddNodes.VisitedLinkColor = Color.Blue;
            lnkAddNodes.LinkClicked += LnkAddNodes_LinkClicked;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(rdioGradStoL);
            groupBox2.Controls.Add(rdioGradLtoS);
            groupBox2.Controls.Add(chkGradSz);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            toolTip1.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // rdioGradStoL
            // 
            resources.ApplyResources(rdioGradStoL, "rdioGradStoL");
            rdioGradStoL.Name = "rdioGradStoL";
            rdioGradStoL.TabStop = true;
            toolTip1.SetToolTip(rdioGradStoL, resources.GetString("rdioGradStoL.ToolTip"));
            rdioGradStoL.UseVisualStyleBackColor = true;
            rdioGradStoL.CheckedChanged += RdioGradStoL_CheckedChanged;
            // 
            // rdioGradLtoS
            // 
            resources.ApplyResources(rdioGradLtoS, "rdioGradLtoS");
            rdioGradLtoS.Name = "rdioGradLtoS";
            rdioGradLtoS.TabStop = true;
            toolTip1.SetToolTip(rdioGradLtoS, resources.GetString("rdioGradLtoS.ToolTip"));
            rdioGradLtoS.UseVisualStyleBackColor = true;
            // 
            // chkGradSz
            // 
            resources.ApplyResources(chkGradSz, "chkGradSz");
            chkGradSz.Name = "chkGradSz";
            toolTip1.SetToolTip(chkGradSz, resources.GetString("chkGradSz.ToolTip"));
            chkGradSz.UseVisualStyleBackColor = true;
            chkGradSz.CheckedChanged += ChkGradSz_CheckedChanged;
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(ChkLgMax);
            groupBox3.Controls.Add(rdioOpt5);
            groupBox3.Controls.Add(rdioOpt4);
            groupBox3.Controls.Add(rdioOpt3);
            groupBox3.Controls.Add(rdioOpt2);
            groupBox3.Controls.Add(rdioOpt1);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            toolTip1.SetToolTip(groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // ChkLgMax
            // 
            resources.ApplyResources(ChkLgMax, "ChkLgMax");
            ChkLgMax.Name = "ChkLgMax";
            toolTip1.SetToolTip(ChkLgMax, resources.GetString("ChkLgMax.ToolTip"));
            ChkLgMax.UseVisualStyleBackColor = true;
            ChkLgMax.CheckedChanged += ChkLgMax_CheckedChanged;
            // 
            // rdioOpt5
            // 
            resources.ApplyResources(rdioOpt5, "rdioOpt5");
            rdioOpt5.Name = "rdioOpt5";
            rdioOpt5.TabStop = true;
            toolTip1.SetToolTip(rdioOpt5, resources.GetString("rdioOpt5.ToolTip"));
            rdioOpt5.UseVisualStyleBackColor = true;
            rdioOpt5.CheckedChanged += RdioOpt5_CheckedChanged;
            // 
            // rdioOpt4
            // 
            resources.ApplyResources(rdioOpt4, "rdioOpt4");
            rdioOpt4.Name = "rdioOpt4";
            rdioOpt4.TabStop = true;
            toolTip1.SetToolTip(rdioOpt4, resources.GetString("rdioOpt4.ToolTip"));
            rdioOpt4.UseVisualStyleBackColor = true;
            rdioOpt4.CheckedChanged += RdioOpt4_CheckedChanged;
            // 
            // rdioOpt3
            // 
            resources.ApplyResources(rdioOpt3, "rdioOpt3");
            rdioOpt3.Name = "rdioOpt3";
            rdioOpt3.TabStop = true;
            toolTip1.SetToolTip(rdioOpt3, resources.GetString("rdioOpt3.ToolTip"));
            rdioOpt3.UseVisualStyleBackColor = true;
            rdioOpt3.CheckedChanged += RdioOpt3_CheckedChanged;
            // 
            // rdioOpt2
            // 
            resources.ApplyResources(rdioOpt2, "rdioOpt2");
            rdioOpt2.Name = "rdioOpt2";
            rdioOpt2.TabStop = true;
            toolTip1.SetToolTip(rdioOpt2, resources.GetString("rdioOpt2.ToolTip"));
            rdioOpt2.UseVisualStyleBackColor = true;
            rdioOpt2.CheckedChanged += RdioOpt2_CheckedChanged;
            // 
            // rdioOpt1
            // 
            resources.ApplyResources(rdioOpt1, "rdioOpt1");
            rdioOpt1.Name = "rdioOpt1";
            rdioOpt1.TabStop = true;
            toolTip1.SetToolTip(rdioOpt1, resources.GetString("rdioOpt1.ToolTip"));
            rdioOpt1.UseVisualStyleBackColor = true;
            rdioOpt1.CheckedChanged += RdioOpt1_CheckedChanged;
            // 
            // groupBox6
            // 
            resources.ApplyResources(groupBox6, "groupBox6");
            groupBox6.Controls.Add(lnkSproutAngle);
            groupBox6.Controls.Add(lblSproutAngle);
            groupBox6.Controls.Add(trkSproutAngle);
            groupBox6.Controls.Add(chkResprout);
            groupBox6.Controls.Add(lnkSubSprout);
            groupBox6.Controls.Add(lnkAddSprout);
            groupBox6.ForeColor = Color.Black;
            groupBox6.Name = "groupBox6";
            groupBox6.TabStop = false;
            toolTip1.SetToolTip(groupBox6, resources.GetString("groupBox6.ToolTip"));
            // 
            // lnkSproutAngle
            // 
            resources.ApplyResources(lnkSproutAngle, "lnkSproutAngle");
            lnkSproutAngle.ActiveLinkColor = Color.Black;
            lnkSproutAngle.LinkColor = Color.Black;
            lnkSproutAngle.Name = "lnkSproutAngle";
            lnkSproutAngle.TabStop = true;
            toolTip1.SetToolTip(lnkSproutAngle, resources.GetString("lnkSproutAngle.ToolTip"));
            lnkSproutAngle.VisitedLinkColor = Color.Black;
            lnkSproutAngle.LinkClicked += LnkSproutAngle_LinkClicked;
            // 
            // lblSproutAngle
            // 
            resources.ApplyResources(lblSproutAngle, "lblSproutAngle");
            lblSproutAngle.Name = "lblSproutAngle";
            toolTip1.SetToolTip(lblSproutAngle, resources.GetString("lblSproutAngle.ToolTip"));
            // 
            // trkSproutAngle
            // 
            resources.ApplyResources(trkSproutAngle, "trkSproutAngle");
            trkSproutAngle.Maximum = 20;
            trkSproutAngle.Minimum = -20;
            trkSproutAngle.Name = "trkSproutAngle";
            trkSproutAngle.TickFrequency = 5;
            toolTip1.SetToolTip(trkSproutAngle, resources.GetString("trkSproutAngle.ToolTip"));
            trkSproutAngle.ValueChanged += TrkSproutAngle_ValueChanged;
            trkSproutAngle.EnabledChanged += TrkSproutAngle_EnabledChanged;
            // 
            // chkResprout
            // 
            resources.ApplyResources(chkResprout, "chkResprout");
            chkResprout.Name = "chkResprout";
            toolTip1.SetToolTip(chkResprout, resources.GetString("chkResprout.ToolTip"));
            chkResprout.UseVisualStyleBackColor = true;
            chkResprout.CheckedChanged += ChkResprout_CheckedChanged;
            // 
            // lnkSubSprout
            // 
            resources.ApplyResources(lnkSubSprout, "lnkSubSprout");
            lnkSubSprout.ActiveLinkColor = Color.Blue;
            lnkSubSprout.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSubSprout.Name = "lnkSubSprout";
            lnkSubSprout.TabStop = true;
            toolTip1.SetToolTip(lnkSubSprout, resources.GetString("lnkSubSprout.ToolTip"));
            lnkSubSprout.VisitedLinkColor = Color.Blue;
            lnkSubSprout.LinkClicked += LnkSubSprout_LinkClicked;
            // 
            // lnkAddSprout
            // 
            resources.ApplyResources(lnkAddSprout, "lnkAddSprout");
            lnkAddSprout.ActiveLinkColor = Color.Blue;
            lnkAddSprout.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkAddSprout.Name = "lnkAddSprout";
            lnkAddSprout.TabStop = true;
            toolTip1.SetToolTip(lnkAddSprout, resources.GetString("lnkAddSprout.ToolTip"));
            lnkAddSprout.VisitedLinkColor = Color.Blue;
            lnkAddSprout.LinkClicked += LnkAddSprout_LinkClicked;
            // 
            // lnkIDs
            // 
            resources.ApplyResources(lnkIDs, "lnkIDs");
            lnkIDs.ActiveLinkColor = Color.DimGray;
            lnkIDs.BackColor = Color.Transparent;
            lnkIDs.DisabledLinkColor = Color.Gray;
            lnkIDs.LinkColor = Color.Silver;
            lnkIDs.Name = "lnkIDs";
            lnkIDs.TabStop = true;
            toolTip1.SetToolTip(lnkIDs, resources.GetString("lnkIDs.ToolTip"));
            lnkIDs.LinkClicked += LnkIDs_LinkClicked;
            // 
            // lnkLog
            // 
            resources.ApplyResources(lnkLog, "lnkLog");
            lnkLog.ActiveLinkColor = Color.DimGray;
            lnkLog.BackColor = Color.Transparent;
            lnkLog.DisabledLinkColor = Color.Gray;
            lnkLog.LinkColor = Color.Silver;
            lnkLog.Name = "lnkLog";
            lnkLog.TabStop = true;
            toolTip1.SetToolTip(lnkLog, resources.GetString("lnkLog.ToolTip"));
            lnkLog.LinkClicked += LnkLog_LinkClicked;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            ForeColor = Color.Black;
            Name = "MainForm";
            toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
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