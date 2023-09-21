using System.Drawing.Drawing2D;

namespace BFSSpiralTree
{
    public partial class MainForm : Form
    {
        private SpiralTree? SpiralTree;
        private List<FlPoint[]> cachedTreePoints = new();
        private Polygon? Boundry;
        private bool showIdxs = false;
        private Color scrollColor = Color.Black;
        private Bitmap bmpSurface;
        private Graphics plotter;
        private readonly float scale = 1f;

        /*
           // for testing CircularEdge
           private float ht //this.mainPanel.Size.Height;
           private float wd //this.mainPanel.Size.Width;
           private float[][] coordArry = new float[7][] { new float[2] { 0f, 0f },
                               new float[2] { 0f, ht/3f },
                               new float[2] { 0f, 2*ht/3f },
                               new float[2] { 0f, ht },
                               new float[2] { wd/3f, ht },
                               new float[2] { 2*wd/3f, ht },
                               new float[2] { wd, ht },
                               new float[2] { wd, ht/3f },
                               new float[2] { wd, 2*ht/3f },
                               new float[2] { wd, 0f } };
           */


        public MainForm()
        {
            //prevent tree logging on form load - we don't know if
            //there are directory problems
            bool resetLogTrue = false;
            if (Configs.LOG)
            {
                resetLogTrue = true;
                Configs.LOG = false;
            }

            InitializeComponent();
            SetMainPanelSizeAndLocation();
            InitFieldVals();

            int ht = (int)(mainPanel.Size.Height * scale);
            int wd = (int)(mainPanel.Size.Width * scale);
            bmpSurface = new Bitmap(wd, ht);
            plotter = Graphics.FromImage(bmpSurface);

            CreateTree();
            if (resetLogTrue)
            {
                if (AppDirectoryOK())
                {
                    Configs.LOG = true;
                    lnkLog.Text = "log: \u2713";
                }   //if directory problems, disable logging
                else
                {
                    lnkLog.Enabled = false;
                }
            }
        }


        private void BtnPreview_Click(object sender, EventArgs e)
        {
            CreateTree();
            if (Configs.RANDANG) { trkStrtAngle.Value = (int)(100 * Configs.rootAngle / (float)Math.PI); }
            mainPanel.Refresh();
        }


        private void CreateTree()
        {
            float ht = mainPanel.Size.Height;
            float wd = mainPanel.Size.Width;
            float[][] coordArry = new float[4][] { new float[2] { 0f, 0f },
                                                   new float[2] { 0f, ht },
                                                   new float[2] { wd, ht },
                                                   new float[2] { wd, 0f } };

            BFSSpiralTree.Configs.scale = scale;
            Boundry = new Polygon(coordArry, true);

            SpiralTree = new SpiralTree(Boundry);
            SpiralTree.Grow();
            List<FlPoint[]> spiralPtsLst = SpiralTree.PlotSpiralTreePoints();
            cachedTreePoints = spiralPtsLst;
        }


        private void DrawIdx(PointF ctr, int nodeIdx)
        {
            int fontSize = (int)(7 * scale);
            int scldDim = (int)(18 * scale);
            //Rectangle txtRect = new((int)ctr.X - scldDim/2, (int)ctr.Y - scldDim/2, (int)(scldDim*1.5), scldDim);
            Rectangle txtRect = new((int)ctr.X - scldDim, (int)ctr.Y - (scldDim / 2), scldDim * 2, scldDim);
            string nodeNum = $"{nodeIdx}";
            TextRenderer.DrawText(plotter, nodeNum, new Font("ArialNarrow", fontSize), txtRect, SystemColors.ControlText);
        }


        private void RefreshGraphics()
        {
            float ht = mainPanel.Size.Height;
            float wd = mainPanel.Size.Width;

            bmpSurface = new Bitmap((int)(wd * scale), (int)(ht * scale));
            plotter = Graphics.FromImage(bmpSurface);
            plotter.SmoothingMode = SmoothingMode.AntiAlias;
        }


        private Bitmap RenderTree()
        {
            RefreshGraphics();
            float penWidth = 1.7f;
            if (showIdxs) { penWidth = 1.5f; }
            Pen pen = new(scrollColor, penWidth);
            SolidBrush solidBrush = new(mainPanel.BackColor);
            plotter.FillRectangle(solidBrush, 0, 0, mainPanel.Size.Width, mainPanel.Size.Height);

            foreach (FlPoint[] _pArry in cachedTreePoints)
            {
                //convert to PointF format & draw
                List<PointF> _fPts = new();
                foreach (FlPoint _p in _pArry) { _fPts.Add(_p.ToPointF()); }
                PointF[] spiralPtsArry = _fPts.ToArray();

                plotter.DrawCurve(pen, spiralPtsArry);
            }

            if (showIdxs)
            {
                Point point = new(0, 0);
                Point corner = point;
                if (SpiralTree is not null)
                {
                    string treeCount = $"count={SpiralTree.Count}";
                    int fontSize = (int)(7 * scale);
                    int scldWd = (int)(80 * scale);
                    int scldHt = (int)(18 * scale);
                    //TextRenderer.DrawText(plotter, treeCount, new Font("Arial Narrow", fontSize),
                    //                      new Rectangle(corner.X, corner.Y, scldWd, scldHt), SystemColors.ControlText);
                    TextRenderer.DrawText(plotter, treeCount, new Font("Arial", fontSize),
                                          new Rectangle(corner.X, corner.Y, scldWd, scldHt), SystemColors.ControlText);

                    for (int i = 0; i < SpiralTree.Count; i++)
                    {
                        DrawIdx(SpiralTree[i].Ctr.ToPointF(), i);
                    }
                }
            }

            Bitmap bmpImage = new(bmpSurface);
            return bmpImage;
        }


        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.ScaleTransform(1 / scale, 1 / scale);

            Bitmap treeImage = RenderTree();
            e.Graphics.DrawImage(treeImage, 0, 0);
        }


        private void ChkGradSz_CheckedChanged(object sender, EventArgs e)
        {
            Configs.GRAD = chkGradSz.Checked;

            rdioGradStoL.Enabled = chkGradSz.Checked;
            rdioGradLtoS.Enabled = chkGradSz.Checked;

            rdioGradLtoS.Checked = chkGradSz.Checked && !Configs.SMTOLG;
            rdioGradStoL.Checked = chkGradSz.Checked && Configs.SMTOLG;
        }


        private void RdioGradStoL_CheckedChanged(object sender, EventArgs e)
        {
            Configs.SMTOLG = rdioGradStoL.Checked;
        }


        private void RdioNoRnd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioNoRnd.Checked == true)
            {
                Configs.RANDSZ = false;
                Configs.RANDLRG = false;
            }
        }


        private void RdioRndLrg_CheckedChanged(object sender, EventArgs e)
        {
            Configs.RANDLRG = rdioRndLrg.Checked;
        }


        private void RdioRndSz_CheckedChanged(object sender, EventArgs e)
        {
            Configs.RANDSZ = rdioRndSz.Checked;
            if (rdioRndSz.Checked) { Configs.RANDLRG = true; }
        }


        private void ChkTwin_CheckedChanged(object sender, EventArgs e)
        {
            Configs.TWIN = chkTwin.Checked;
            if (chkTwin.Checked) { chkTwin.Text = "twin curl"; }
            else { chkTwin.Text = "single curl"; }
        }


        private void RdioOpt1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioOpt1.Checked) { Configs.DIVOPTION = 1; }
        }


        private void RdioOpt2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioOpt2.Checked) { Configs.DIVOPTION = 2; }
        }


        private void RdioOpt3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioOpt3.Checked) { Configs.DIVOPTION = 3; }
        }


        private void RdioOpt4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioOpt4.Checked) { Configs.DIVOPTION = 4; }
        }


        private void RdioOpt5_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioOpt5.Checked) { Configs.DIVOPTION = 5; }
        }


        private void TrkMaxTotal_ValueChanged(object sender, EventArgs e)
        {
            if (trkMaxTotal.Value < 2) { trkMaxTotal.Value = 2; }
            txtMaxNodes.Text = trkMaxTotal.Value.ToString();
            Configs.maxNodes = trkMaxTotal.Value;
        }

        private void LnkSubNodes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkMaxTotal.Value = Math.Max(trkMaxTotal.Value - 1, trkMaxTotal.Minimum); }


        private void LnkAddNodes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkMaxTotal.Value = Math.Min(trkMaxTotal.Value + 1, trkMaxTotal.Maximum); }


        private void InitFieldVals()
        {
            txtMaxNodes.Text = Configs.maxNodes.ToString();
            updownMaxLeaves.Text = Configs.maxLeaves.ToString();
            trkMaxTotal.Value = Configs.maxNodes;
            chkTwin.Checked = Configs.TWIN;
            chkRandAngl.Checked = Configs.RANDANG;
            trkStrtAngle.Enabled = !Configs.RANDANG;
            chkRndLeaves.Checked = Configs.RANDNUM;
            ChkLgMax.Checked = Configs.LGMAX;
            chkGradSz.Checked = Configs.GRAD;
            rdioGradStoL.Checked = Configs.GRAD && Configs.SMTOLG;
            rdioGradLtoS.Checked = Configs.GRAD && !Configs.SMTOLG;

            lblStrtAngle.Text = "angle(*\u03C0):";
            trkStrtAngle.Value = (int)(100 * Configs.rootAngle / (float)Math.PI);
            lblAngle.Text = $"{trkStrtAngle.Value / 100f:F2}";

            chkResprout.Checked = Configs.GROWTINY;
            chkResprout.Text = Configs.GROWTINY ? "on" : "off";
            trkSproutAngle.Enabled = Configs.GROWTINY;

            trkSproutAngle.Value = (int)(Configs.sproutAdjustment * 100);
            string sAngSgn = (Configs.sproutAdjustment > 0) ? "+" : " ";
            lblSproutAngle.Text = $"{sAngSgn}{Configs.sproutAdjustment:F2}";

            trkSpread.Value = (int)(2 * Configs.spreadFactor / Configs.nodeHalo);
            string sprdSgn = (Configs.spreadFactor > 0) ? "+" : " ";
            lblSpread.Text = $"{sprdSgn}{Configs.spreadFactor:F2}";

            trkShift.Value = (int)(Configs.shiftFactor * 100);
            string shftSgn = (Configs.shiftFactor > 0) ? "+" : " ";
            lblShift.Text = $"{shftSgn}{Configs.shiftFactor:F2}";

            lnkLog.Text = Configs.LOG ? "log: \u2713" : "log: \u2717";
            lnkIDs.Text = "IDs: \u2717";

            int opt = Configs.DIVOPTION;
            RadioButton[] btnArry = { rdioOpt1, rdioOpt2, rdioOpt3, rdioOpt4, rdioOpt5 };
            btnArry[opt - 1].Checked = true;
        }


        private void ChkRandAngl_CheckedChanged(object sender, EventArgs e)
        {
            Configs.RANDANG = chkRandAngl.Checked;
            trkStrtAngle.Enabled = !chkRandAngl.Checked;
        }


        private void ChkLgMax_CheckedChanged(object sender, EventArgs e)
        {
            Configs.LGMAX = ChkLgMax.Checked;
        }


        private void ChkRndLeaves_CheckedChanged(object sender, EventArgs e)
        {
            Configs.RANDNUM = chkRndLeaves.Checked;

            updownMaxLeaves.Enabled = !chkRndLeaves.Checked;
            if (!chkRndLeaves.Checked) { updownMaxLeaves.SelectedItem = 0; }
        }


        private void UpdownMaxLeaves_SelectedItemChanged(object sender, EventArgs e)
        {
            object item = updownMaxLeaves.SelectedItem;
            if (item != null)
            {
                string? val = updownMaxLeaves.SelectedItem.ToString();
                int maxLeaves = 0;
                if (val is not "" and not null) { maxLeaves = int.Parse(val); }
                Configs.maxLeaves = maxLeaves;
            }

        }


        private void BtnScrollColor_Click(object sender, EventArgs e)
        {
            if (clrDlgScroll.ShowDialog() == DialogResult.OK)
            {
                scrollColor = clrDlgScroll.Color;
                mainPanel.Refresh();
            }
        }


        private void BtnBkgColor_Click(object sender, EventArgs e)
        {
            if (clrDlgScroll.ShowDialog() == DialogResult.OK)
            {
                mainPanel.BackColor = clrDlgScroll.Color;
            }
        }


        private void LnkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Configs.LOG = !Configs.LOG;

            if (Configs.LOG && !AppDirectoryOK()) //if directory problems, disable logging
            {
                Configs.LOG = false;
                lnkLog.Enabled = false;
            }
            else { lnkLog.Text = Configs.LOG ? "log: \u2713" : "log: \u2717"; }
        }


        private void LnkIDs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showIdxs = !showIdxs;
            lnkIDs.Text = showIdxs ? "IDs: \u2713" : "IDs: \u2717";
            scrollColor = showIdxs ? Color.FromName("DeepPink") : Color.FromName("Black");
            mainPanel.Refresh();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(bmpSurface);
        }


        private void BtnSVG_Click(object sender, EventArgs e)
        {
            string colorName = scrollColor.Name.ToLower();
            int ht = mainPanel.Size.Height;
            int wd = mainPanel.Size.Width;

            if (AppDirectoryOK())
            {
                SpiralTree.WriteSVG(cachedTreePoints, wd, ht, colorName, 1);
            }
            else { btnSVG.Enabled = false; }
        }


        //make sure we have/can create a MyDocuments directory to put files into
        public static bool AppDirectoryOK()
        {
            string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appFolderName = "ScrollGenerator";
            string dirPath = Path.Combine(myDocsPath, appFolderName);
            bool success = true;
            try
            {
                // Determine whether the directory already exists
                if (!Directory.Exists(dirPath))
                {
                    //If not, try to create it
                    DirectoryInfo dirInfo = Directory.CreateDirectory(dirPath);
                }
            }

            catch (Exception e)
            {
                _ = MessageBox.Show(e.ToString(), "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally { }

            return success;
        }


        private void SplitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            SetMainPanelSizeAndLocation();
        }


        private void SetMainPanelSizeAndLocation()
        {
            mainPanel.Height = splitContainer1.Panel2.Height;
            mainPanel.Width = Math.Max(splitContainer1.Panel2.Height, splitContainer1.Panel2.Width - 110);

            int leftPad = Math.Min(55, (splitContainer1.Panel2.Width - splitContainer1.Panel2.Height) / 2);
            mainPanel.Location = new Point(leftPad, 0);
        }


        private void TrkStrtAngle_ValueChanged(object sender, EventArgs e)
        {
            lblAngle.Text = $"{trkStrtAngle.Value / 100f:F2}";
            Configs.rootAngle = trkStrtAngle.Value / 100f * (float)Math.PI;
        }

        private void TrkStrtAngle_EnabledChanged(object sender, EventArgs e)
        {
            lnkAddStrt.Visible = trkStrtAngle.Enabled;
            lnkSubStrt.Visible = trkStrtAngle.Enabled;
        }

        private void LnkAddStrt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkStrtAngle.Value = Math.Min(trkStrtAngle.Value + 1, trkStrtAngle.Maximum); }

        private void LnkSubStrt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkStrtAngle.Value = Math.Max(trkStrtAngle.Value - 1, trkStrtAngle.Minimum); }

        private void ChkResprout_CheckedChanged(object sender, EventArgs e)
        {
            Configs.GROWTINY = chkResprout.Checked;
            chkResprout.Text = Configs.GROWTINY ? "on" : "off";
            trkSproutAngle.Enabled = chkResprout.Checked;
        }


        private void TrkSproutAngle_ValueChanged(object sender, EventArgs e)
        {
            Configs.sproutAdjustment = trkSproutAngle.Value / 100f;
            string sign = (Configs.sproutAdjustment > 0) ? "+" : (Configs.sproutAdjustment == 0) ? " " : "";
            lblSproutAngle.Text = $"{sign}{Configs.sproutAdjustment:F2}";
        }

        private void TrkSproutAngle_EnabledChanged(object sender, EventArgs e)
        {
            lnkAddSprout.Visible = trkSproutAngle.Enabled;
            lnkSubSprout.Visible = trkSproutAngle.Enabled;
            lnkSproutAngle.Enabled = trkSproutAngle.Enabled;
        }

        private void LnkSproutAngle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trkSproutAngle.Value = 0;
        }

        private void LnkAddSprout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkSproutAngle.Value = Math.Min(trkSproutAngle.Value + 1, trkSproutAngle.Maximum); }
        private void LnkSubSprout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkSproutAngle.Value = Math.Max(trkSproutAngle.Value - 1, trkSproutAngle.Minimum); }


        private void TrkSpread_ValueChanged(object sender, EventArgs e)
        {
            Configs.spreadFactor = trkSpread.Value * (Configs.nodeHalo / 2f);
            string sign = (Configs.spreadFactor > 0) ? "+" : (Configs.spreadFactor == 0) ? " " : "";
            lblSpread.Text = $"{sign}{Configs.spreadFactor:F2}";
        }


        private void LnkSpread_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trkSpread.Value = 0;
        }

        private void LnkAddSprd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkSpread.Value = Math.Min(trkSpread.Value + 1, trkSpread.Maximum); }
        private void LnkSubSprd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkSpread.Value = Math.Max(trkSpread.Value - 1, trkSpread.Minimum); }

        private void TrkShift_ValueChanged(object sender, EventArgs e)
        {
            Configs.shiftFactor = trkShift.Value / 100f;
            string sign = (Configs.shiftFactor > 0) ? "+" : (Configs.shiftFactor == 0) ? " " : "";
            lblShift.Text = $"{sign}{Configs.shiftFactor:F2}";
        }

        private void LnkShift_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trkShift.Value = 0;
        }

        private void LnkAddShift_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkShift.Value = Math.Min(trkShift.Value + 1, trkShift.Maximum); }
        private void LnkSubShift_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { trkShift.Value = Math.Max(trkShift.Value - 1, trkShift.Minimum); }

    }
}