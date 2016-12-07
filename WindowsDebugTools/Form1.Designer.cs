namespace WindowsDebugTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabUpdateWordLib = new System.Windows.Forms.TabControl();
            this.tabDiskfile = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.nmbReadSpeed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDelayTime = new System.Windows.Forms.CheckBox();
            this.dtPickerUpdateTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radGb2312 = new System.Windows.Forms.RadioButton();
            this.radUTF8 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radFloderMode = new System.Windows.Forms.RadioButton();
            this.radFileMode = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLoadDictionary = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radSegment = new System.Windows.Forms.RadioButton();
            this.radDictionary = new System.Windows.Forms.RadioButton();
            this.btnSaveDictionary = new System.Windows.Forms.Button();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.btnCatchResult = new System.Windows.Forms.Button();
            this.btnClearWordLib = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOrderBy = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCoreWordList = new System.Windows.Forms.TextBox();
            this.chkIsOnlyWord = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabUpdateWordLib.SuspendLayout();
            this.tabDiskfile.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmbReadSpeed)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(736, 450);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(297, 450);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabUpdateWordLib);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(435, 450);
            this.splitContainer2.SplitterDistance = 239;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabUpdateWordLib
            // 
            this.tabUpdateWordLib.Controls.Add(this.tabDiskfile);
            this.tabUpdateWordLib.Location = new System.Drawing.Point(12, 8);
            this.tabUpdateWordLib.Name = "tabUpdateWordLib";
            this.tabUpdateWordLib.SelectedIndex = 0;
            this.tabUpdateWordLib.Size = new System.Drawing.Size(413, 224);
            this.tabUpdateWordLib.TabIndex = 0;
            // 
            // tabDiskfile
            // 
            this.tabDiskfile.Controls.Add(this.groupBox9);
            this.tabDiskfile.Controls.Add(this.groupBox5);
            this.tabDiskfile.Controls.Add(this.progressBar1);
            this.tabDiskfile.Controls.Add(this.groupBox6);
            this.tabDiskfile.Controls.Add(this.groupBox4);
            this.tabDiskfile.Location = new System.Drawing.Point(4, 22);
            this.tabDiskfile.Name = "tabDiskfile";
            this.tabDiskfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiskfile.Size = new System.Drawing.Size(405, 198);
            this.tabDiskfile.TabIndex = 0;
            this.tabDiskfile.Text = "文件";
            this.tabDiskfile.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.nmbReadSpeed);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.chkDelayTime);
            this.groupBox9.Controls.Add(this.dtPickerUpdateTime);
            this.groupBox9.Location = new System.Drawing.Point(10, 115);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(384, 51);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "延时";
            // 
            // nmbReadSpeed
            // 
            this.nmbReadSpeed.Location = new System.Drawing.Point(113, 20);
            this.nmbReadSpeed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmbReadSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmbReadSpeed.Name = "nmbReadSpeed";
            this.nmbReadSpeed.Size = new System.Drawing.Size(49, 21);
            this.nmbReadSpeed.TabIndex = 9;
            this.nmbReadSpeed.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "字，开始于";
            // 
            // chkDelayTime
            // 
            this.chkDelayTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDelayTime.AutoSize = true;
            this.chkDelayTime.Checked = true;
            this.chkDelayTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelayTime.Location = new System.Drawing.Point(10, 21);
            this.chkDelayTime.Name = "chkDelayTime";
            this.chkDelayTime.Size = new System.Drawing.Size(108, 16);
            this.chkDelayTime.TabIndex = 7;
            this.chkDelayTime.Text = "模拟延时，每秒";
            this.chkDelayTime.UseVisualStyleBackColor = true;
            this.chkDelayTime.CheckedChanged += new System.EventHandler(this.chkDelayTime_CheckedChanged);
            // 
            // dtPickerUpdateTime
            // 
            this.dtPickerUpdateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtPickerUpdateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerUpdateTime.Location = new System.Drawing.Point(234, 20);
            this.dtPickerUpdateTime.Name = "dtPickerUpdateTime";
            this.dtPickerUpdateTime.ShowUpDown = true;
            this.dtPickerUpdateTime.Size = new System.Drawing.Size(144, 21);
            this.dtPickerUpdateTime.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.tbFilePath);
            this.groupBox5.Controls.Add(this.btnOpenPath);
            this.groupBox5.Location = new System.Drawing.Point(10, 55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(384, 54);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "路径";
            // 
            // tbFilePath
            // 
            this.tbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilePath.Location = new System.Drawing.Point(6, 20);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(349, 21);
            this.tbFilePath.TabIndex = 3;
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenPath.Location = new System.Drawing.Point(357, 20);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(21, 21);
            this.btnOpenPath.TabIndex = 5;
            this.btnOpenPath.Text = "…";
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(11, 172);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 20);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radGb2312);
            this.groupBox6.Controls.Add(this.radUTF8);
            this.groupBox6.Location = new System.Drawing.Point(221, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(167, 43);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "文件编码";
            // 
            // radGb2312
            // 
            this.radGb2312.AutoSize = true;
            this.radGb2312.Checked = true;
            this.radGb2312.Location = new System.Drawing.Point(82, 19);
            this.radGb2312.Name = "radGb2312";
            this.radGb2312.Size = new System.Drawing.Size(59, 16);
            this.radGb2312.TabIndex = 1;
            this.radGb2312.TabStop = true;
            this.radGb2312.Text = "Gb2312";
            this.radGb2312.UseVisualStyleBackColor = true;
            this.radGb2312.CheckedChanged += new System.EventHandler(this.radUTF8_CheckedChanged);
            // 
            // radUTF8
            // 
            this.radUTF8.AutoSize = true;
            this.radUTF8.Location = new System.Drawing.Point(20, 19);
            this.radUTF8.Name = "radUTF8";
            this.radUTF8.Size = new System.Drawing.Size(47, 16);
            this.radUTF8.TabIndex = 0;
            this.radUTF8.Text = "UTF8";
            this.radUTF8.UseVisualStyleBackColor = true;
            this.radUTF8.CheckedChanged += new System.EventHandler(this.radUTF8_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radFloderMode);
            this.groupBox4.Controls.Add(this.radFileMode);
            this.groupBox4.Location = new System.Drawing.Point(11, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 43);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "类型";
            // 
            // radFloderMode
            // 
            this.radFloderMode.AutoSize = true;
            this.radFloderMode.Location = new System.Drawing.Point(103, 19);
            this.radFloderMode.Name = "radFloderMode";
            this.radFloderMode.Size = new System.Drawing.Size(47, 16);
            this.radFloderMode.TabIndex = 1;
            this.radFloderMode.Text = "目录";
            this.radFloderMode.UseVisualStyleBackColor = true;
            // 
            // radFileMode
            // 
            this.radFileMode.AutoSize = true;
            this.radFileMode.Checked = true;
            this.radFileMode.Location = new System.Drawing.Point(37, 19);
            this.radFileMode.Name = "radFileMode";
            this.radFileMode.Size = new System.Drawing.Size(47, 16);
            this.radFileMode.TabIndex = 0;
            this.radFileMode.TabStop = true;
            this.radFileMode.Text = "文件";
            this.radFileMode.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLoadDictionary);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.btnSaveDictionary);
            this.groupBox3.Controls.Add(this.btnShowResult);
            this.groupBox3.Controls.Add(this.btnCatchResult);
            this.groupBox3.Controls.Add(this.btnClearWordLib);
            this.groupBox3.Location = new System.Drawing.Point(237, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 125);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作面板";
            // 
            // btnLoadDictionary
            // 
            this.btnLoadDictionary.Location = new System.Drawing.Point(99, 84);
            this.btnLoadDictionary.Name = "btnLoadDictionary";
            this.btnLoadDictionary.Size = new System.Drawing.Size(44, 30);
            this.btnLoadDictionary.TabIndex = 6;
            this.btnLoadDictionary.Text = "加载";
            this.btnLoadDictionary.UseVisualStyleBackColor = true;
            this.btnLoadDictionary.Click += new System.EventHandler(this.btnLoadDictionary_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radSegment);
            this.groupBox8.Controls.Add(this.radDictionary);
            this.groupBox8.Location = new System.Drawing.Point(49, 20);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(94, 60);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "操作类型";
            // 
            // radSegment
            // 
            this.radSegment.AutoSize = true;
            this.radSegment.Location = new System.Drawing.Point(21, 38);
            this.radSegment.Name = "radSegment";
            this.radSegment.Size = new System.Drawing.Size(47, 16);
            this.radSegment.TabIndex = 1;
            this.radSegment.Text = "分词";
            this.radSegment.UseVisualStyleBackColor = true;
            // 
            // radDictionary
            // 
            this.radDictionary.AutoSize = true;
            this.radDictionary.Checked = true;
            this.radDictionary.Location = new System.Drawing.Point(21, 20);
            this.radDictionary.Name = "radDictionary";
            this.radDictionary.Size = new System.Drawing.Size(47, 16);
            this.radDictionary.TabIndex = 0;
            this.radDictionary.TabStop = true;
            this.radDictionary.Text = "词库";
            this.radDictionary.UseVisualStyleBackColor = true;
            // 
            // btnSaveDictionary
            // 
            this.btnSaveDictionary.Location = new System.Drawing.Point(47, 84);
            this.btnSaveDictionary.Name = "btnSaveDictionary";
            this.btnSaveDictionary.Size = new System.Drawing.Size(44, 30);
            this.btnSaveDictionary.TabIndex = 4;
            this.btnSaveDictionary.Text = "保存";
            this.btnSaveDictionary.UseVisualStyleBackColor = true;
            this.btnSaveDictionary.Click += new System.EventHandler(this.btnSaveDictionary_Click);
            // 
            // btnShowResult
            // 
            this.btnShowResult.Location = new System.Drawing.Point(149, 20);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(33, 94);
            this.btnShowResult.TabIndex = 1;
            this.btnShowResult.Text = "　显示　";
            this.btnShowResult.UseVisualStyleBackColor = true;
            this.btnShowResult.Click += new System.EventHandler(this.btnShowWordCloud_Click);
            // 
            // btnCatchResult
            // 
            this.btnCatchResult.Location = new System.Drawing.Point(8, 20);
            this.btnCatchResult.Name = "btnCatchResult";
            this.btnCatchResult.Size = new System.Drawing.Size(33, 94);
            this.btnCatchResult.TabIndex = 0;
            this.btnCatchResult.Text = "　获取　 ";
            this.btnCatchResult.UseVisualStyleBackColor = true;
            this.btnCatchResult.Click += new System.EventHandler(this.btnCatchWordCloud_Click);
            // 
            // btnClearWordLib
            // 
            this.btnClearWordLib.Location = new System.Drawing.Point(47, 84);
            this.btnClearWordLib.Name = "btnClearWordLib";
            this.btnClearWordLib.Size = new System.Drawing.Size(44, 30);
            this.btnClearWordLib.TabIndex = 3;
            this.btnClearWordLib.Text = "清理";
            this.btnClearWordLib.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIsOnlyWord);
            this.groupBox2.Controls.Add(this.chkOrderBy);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Location = new System.Drawing.Point(218, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选项设置";
            // 
            // chkOrderBy
            // 
            this.chkOrderBy.AutoSize = true;
            this.chkOrderBy.Checked = true;
            this.chkOrderBy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrderBy.Location = new System.Drawing.Point(150, 25);
            this.chkOrderBy.Name = "chkOrderBy";
            this.chkOrderBy.Size = new System.Drawing.Size(48, 16);
            this.chkOrderBy.TabIndex = 3;
            this.chkOrderBy.Text = "倒序";
            this.chkOrderBy.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Top：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(41, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCoreWordList);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待分词语句";
            // 
            // tbCoreWordList
            // 
            this.tbCoreWordList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCoreWordList.Location = new System.Drawing.Point(7, 23);
            this.tbCoreWordList.Multiline = true;
            this.tbCoreWordList.Name = "tbCoreWordList";
            this.tbCoreWordList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCoreWordList.Size = new System.Drawing.Size(193, 151);
            this.tbCoreWordList.TabIndex = 0;
            this.tbCoreWordList.WordWrap = false;
            // 
            // chkIsOnlyWord
            // 
            this.chkIsOnlyWord.AutoSize = true;
            this.chkIsOnlyWord.Checked = true;
            this.chkIsOnlyWord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsOnlyWord.Location = new System.Drawing.Point(96, 24);
            this.chkIsOnlyWord.Name = "chkIsOnlyWord";
            this.chkIsOnlyWord.Size = new System.Drawing.Size(48, 16);
            this.chkIsOnlyWord.TabIndex = 5;
            this.chkIsOnlyWord.Text = "纯词";
            this.chkIsOnlyWord.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "遗忘算法演示程序（词库生成、分词、词权重） by 老憨 （QQ：244589712 Email：gzdmcaoyc@163.com )";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabUpdateWordLib.ResumeLayout(false);
            this.tabDiskfile.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmbReadSpeed)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabUpdateWordLib;
        private System.Windows.Forms.TabPage tabDiskfile;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown nmbReadSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDelayTime;
        private System.Windows.Forms.DateTimePicker dtPickerUpdateTime;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radGb2312;
        private System.Windows.Forms.RadioButton radUTF8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radFloderMode;
        private System.Windows.Forms.RadioButton radFileMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton radSegment;
        private System.Windows.Forms.RadioButton radDictionary;
        private System.Windows.Forms.Button btnSaveDictionary;
        private System.Windows.Forms.Button btnClearWordLib;
        private System.Windows.Forms.Button btnShowResult;
        private System.Windows.Forms.Button btnCatchResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkOrderBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCoreWordList;
        private System.Windows.Forms.Button btnLoadDictionary;
        private System.Windows.Forms.CheckBox chkIsOnlyWord;
    }
}

