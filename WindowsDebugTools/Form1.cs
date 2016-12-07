using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using ForgetNLP.DictionarySDK;
using ForgetNLP.SegmentSDK;
using ForgetNLP.MemorySDK;
 
namespace WindowsDebugTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void chkDelayTime_CheckedChanged(object sender, EventArgs e)
        {
            nmbReadSpeed.Enabled = dtPickerUpdateTime.Enabled = chkDelayTime.Checked;

        }
        private void AppendText(string src)
        {
            this.richTextBox1.AppendText(String.Format("{0}{1}", src, Environment.NewLine));
            this.richTextBox1.ScrollToCaret();
            Application.DoEvents();
        }

        private Encoding GetEncoding()
        {
            Encoding objEncoding = Encoding.Default;
            if (radGb2312.Checked)
            {
                objEncoding = Encoding.Default;
            }
            if (radUTF8.Checked)
            {
                objEncoding = Encoding.UTF8;
            }
            return objEncoding;
        }
        private void ReadForDebugEncoding()
        {
            string sPathFile = this.tbFilePath.Text;
            if (radFloderMode.Checked)
            {
                if (Directory.Exists(this.tbFilePath.Text))
                {

                    string[] objFileColl = Directory.GetFiles(this.tbFilePath.Text, "*.txt", SearchOption.AllDirectories);
                    if (objFileColl.Count() > 0)
                    {
                        sPathFile = objFileColl[0];
                    }
                }
            }
            if (radFileMode.Checked)
            {
                sPathFile = this.tbFilePath.Text;
            }


            if (File.Exists(sPathFile))
            {
                this.richTextBox1.Text = String.Empty;
                this.AppendText("【如遇乱码，请尝试更换文件编码】");
                Encoding objEncoding = Encoding.Default;
                if (radUTF8.Checked)
                {
                    objEncoding = Encoding.UTF8;
                }
                if (radGb2312.Checked)
                {
                    objEncoding = Encoding.Default;
                }
                using (StreamReader sr = new StreamReader(sPathFile, objEncoding))
                {
                    string line = null;
                    StringBuilder sb = new StringBuilder();
                    int nLoadLineCount = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string text =Regex.Replace( Regex.Replace(line, @"[\p{C}]+", ""),"<.*?>","");
                        if (String.IsNullOrWhiteSpace(text)) continue;
                        sb.AppendLine(text);
                        nLoadLineCount += 1;
                        if (nLoadLineCount > 20)
                        {
                            break;
                        }
                    }
                    AppendText(sb.ToString());
                }
                this.AppendText("【如遇乱码，请尝试更换文件编码】");
            }
        }
        private void radUTF8_CheckedChanged(object sender, EventArgs e)
        {
            ReadForDebugEncoding();
        }
        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            if (radFileMode.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = CachePathDAL.GetWorkSpacePath();
                if (!String.IsNullOrEmpty(this.tbFilePath.Text))
                {
                    try
                    {
                        string floder = Path.GetDirectoryName(this.tbFilePath.Text);
                        if (Directory.Exists(floder))
                        {
                            openFileDialog.InitialDirectory = floder;
                        }
                    }
                    catch
                    {
                    }
                }

                openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.tbFilePath.Text = openFileDialog.FileName;

                }
            }

            if (radFloderMode.Checked)
            {
                FolderBrowserDialog openFloderDialog = new FolderBrowserDialog();
                openFloderDialog.SelectedPath = CachePathDAL.GetWorkSpacePath();
                if (!String.IsNullOrEmpty(this.tbFilePath.Text))
                {
                    try
                    {
                        string floder = Path.GetDirectoryName(this.tbFilePath.Text);
                        if (Directory.Exists(floder))
                        {
                            openFloderDialog.SelectedPath = floder;
                        }
                    }
                    catch
                    {
                    }
                }
                if (openFloderDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tbFilePath.Text = openFloderDialog.SelectedPath;
                }
            }

            ReadForDebugEncoding();
        }



   
        MemoryBondColl<string> objCharBondColl = new MemoryBondColl<string>();    
        MemoryItemColl<string> objKeyWordColl = new MemoryItemColl<string>();


        private void CatchWordIndexColl()
        {

            objCharBondColl.MinuteOffsetSize = Convert.ToInt32(nmbReadSpeed.Value) * 60 * 60 * 24 * 6;
            objKeyWordColl.MinuteOffsetSize = Convert.ToInt32(nmbReadSpeed.Value) * 60 * 60 * 24 * 6;
            Encoding objEncoding = GetEncoding();

            if (!String.IsNullOrWhiteSpace(this.tbCoreWordList.Text))
            {

                if (radSegment.Checked)
                {
                    AppendText(SegmentBLL.ShowSegment(SegmentBLL.Segment(this.tbCoreWordList.Text, objCharBondColl, objKeyWordColl, 4, true, true)));
                    return;
                }
            }

            DateTime dtStartTime = DateTime.Now;

            if (radFileMode.Checked)
            {
                string sPathFile = this.tbFilePath.Text;
                if (File.Exists(sPathFile))
                {
                    this.AppendText(String.Format("【进行】{0}", sPathFile));

                    FileInfo info = new FileInfo(sPathFile);
                    double dFileCharLength = info.Length / 2 + 1;
                    double dLoadCharCount = 0;
                    double dTempCharCount = objCharBondColl.OffsetTotalCount;

                    DateTime dtUpdateTime = DateTime.Now;
                    this.progressBar1.Maximum = Convert.ToInt32(dFileCharLength);
                    this.progressBar1.Minimum = 0;
                    this.progressBar1.Value = this.progressBar1.Minimum;
                    using (StreamReader sr = new StreamReader(sPathFile, objEncoding))
                    {
                        string line = null;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Application.DoEvents();

                            if (!String.IsNullOrWhiteSpace(line)) line = Regex.Replace(Regex.Replace(line, @"\p{C}+", ""), "<.*?>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);//去除可能的控制符、Html标签
                            if (String.IsNullOrWhiteSpace(line)) continue;


                            dLoadCharCount += line.Length;
                            dTempCharCount += line.Length;
                            this.progressBar1.Value = this.progressBar1.Maximum > dLoadCharCount ? Convert.ToInt32(dLoadCharCount) : this.progressBar1.Maximum - 1;

                            string text = line; //这里可以再做一些需要特别处理的数据清洗，如多余的空格等

                            if (!String.IsNullOrEmpty(text))
                            {
                                if (this.chkDelayTime.Checked)
                                {
                                    dtUpdateTime = dtPickerUpdateTime.Value.AddSeconds(dLoadCharCount / (double)nmbReadSpeed.Value);
                                }

                                if (radDictionary.Checked)
                                {
                                    //当数据跑过一个周期的数据时清理一次邻键集、词库，避免内存空间不足
                                    if (dTempCharCount > objCharBondColl.MinuteOffsetSize)
                                    {
                                        DictionaryDAL.ClearMemoryBondColl<string>(objCharBondColl);
                                        DictionaryDAL.ClearMemoryItemColl<string>(objKeyWordColl);
                                        dTempCharCount = 0;
                                    }

                                    WordDictBLL.UpdateKeyWordColl(text, objCharBondColl, objKeyWordColl);
                                }

                                if (radSegment.Checked)
                                {
                                    AppendText(SegmentBLL.ShowSegment(SegmentBLL.Segment(text, objCharBondColl, objKeyWordColl, 4, true, true)));
                                }
                            }
                        }

                    }
                    this.progressBar1.Value = this.progressBar1.Maximum;
                    this.progressBar1.Value = this.progressBar1.Minimum;
                    if (this.chkDelayTime.Checked)
                    {
                        dtPickerUpdateTime.Value = dtPickerUpdateTime.Value.AddSeconds(dLoadCharCount / (double)nmbReadSpeed.Value);
                    }
                }
            }

            if (radFloderMode.Checked)
            {
                if (Directory.Exists(this.tbFilePath.Text))
                {
                    
                    double dTempCharCount = objCharBondColl.OffsetTotalCount;
                    string[] objFileColl = Directory.GetFiles(this.tbFilePath.Text, "*.txt", SearchOption.AllDirectories);
                    foreach (string sPathFile in objFileColl)
                    {
                        if (File.Exists(sPathFile))
                        {
                            double dLoadCharCount = 0;
                            this.AppendText(String.Format("【进行】{0}", sPathFile));

                            FileInfo info = new FileInfo(sPathFile);
                            double dFileCharLength = info.Length / 2 + 1;

                            DateTime dtUpdateTime = DateTime.Now;
                            this.progressBar1.Maximum = Convert.ToInt32(dFileCharLength);
                            this.progressBar1.Minimum = 0;
                            this.progressBar1.Value = this.progressBar1.Minimum;
                            using (StreamReader sr = new StreamReader(sPathFile, objEncoding))
                            {
                                string line = null;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    Application.DoEvents();

                                    if (!String.IsNullOrWhiteSpace(line)) line = Regex.Replace(Regex.Replace(line, @"\p{C}+", ""), "<.*?>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);//去除可能的控制符、Html标签
                                    if (String.IsNullOrWhiteSpace(line)) continue;


                                    dLoadCharCount += line.Length;
                                    dTempCharCount += line.Length;
                                    this.progressBar1.Value = this.progressBar1.Maximum > dLoadCharCount ? Convert.ToInt32(dLoadCharCount) : this.progressBar1.Maximum - 1;

                                    string text = line; //这里可以再做一些需要特别处理的数据清洗，如多余的空格等

                                    if (!String.IsNullOrEmpty(text))
                                    {
                                        if (this.chkDelayTime.Checked)
                                        {
                                            dtUpdateTime = dtPickerUpdateTime.Value.AddSeconds(dLoadCharCount / (double)nmbReadSpeed.Value);
                                        }

                                        if (radDictionary.Checked)
                                        {
                                            //当数据跑过一个周期的数据时清理一次邻键集、词库，避免内存空间不足
                                            if (dTempCharCount > objCharBondColl.MinuteOffsetSize)
                                            {
                                                DictionaryDAL.ClearMemoryBondColl<string>(objCharBondColl);
                                                DictionaryDAL.ClearMemoryItemColl<string>(objKeyWordColl);
                                                dTempCharCount = 0;
                                            }

                                            WordDictBLL.UpdateKeyWordColl(text, objCharBondColl, objKeyWordColl);
                                        }

                                        if (radSegment.Checked)
                                        {
                                            AppendText(SegmentBLL.ShowSegment(SegmentBLL.Segment(text, objCharBondColl, objKeyWordColl, 4, true, true)));
                                        }
                                    }
                                }

                            }
                            this.progressBar1.Value = this.progressBar1.Maximum;
                            this.progressBar1.Value = this.progressBar1.Minimum;
                            if (this.chkDelayTime.Checked)
                            {
                                dtPickerUpdateTime.Value = dtPickerUpdateTime.Value.AddSeconds(dLoadCharCount / (double)nmbReadSpeed.Value);
                            }
                        }
                    }
                }
            }
            AppendText(String.Format("完成，共用时{0}秒。", (DateTime.Now - dtStartTime).ToString()));
        }

 
 
        private void btnCatchWordCloud_Click(object sender, EventArgs e)
        {

            this.CatchWordIndexColl();
             
        }


        private void btnShowWordCloud_Click(object sender, EventArgs e)
        {
            if (radDictionary.Checked)
            {
                string result = WordDictBLL.ShowKeyWordWeightColl(objKeyWordColl, Convert.ToInt32(numericUpDown1.Value), chkOrderBy.Checked, chkIsOnlyWord.Checked);
                this.richTextBox1.Text = result;
            }
            if (radSegment.Checked)
            {
                using (StringReader sr = new StringReader(this.tbCoreWordList.Text))
                {
                    StringBuilder sb = new StringBuilder();
                    Dictionary<string, double> dictValue = new Dictionary<string, double>();
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> objKeyWordList = SegmentBLL.Segment(line, objCharBondColl, objKeyWordColl, 7, false, false);
                        foreach (string keyword in objKeyWordList)
                        {
                            if (!dictValue.ContainsKey(keyword))
                            {
                                dictValue.Add(keyword,!objKeyWordColl.Contains(keyword)?0: -Math.Log(objKeyWordColl[keyword].ValidCount / objKeyWordColl.MinuteOffsetSize));
                            }
                            else
                            {
                                dictValue[keyword] += !objKeyWordColl.Contains(keyword) ? 0 : -Math.Log(objKeyWordColl[keyword].ValidCount / objKeyWordColl.MinuteOffsetSize);
                            }
                        }
                        sb.AppendLine(SegmentBLL.ShowSegment(objKeyWordList));
                    }
                    sb.AppendLine();
                    var buffer = from x in dictValue
                                 orderby x.Value descending
                                 select x;
                    foreach (var x in buffer)
                    {
                        sb.AppendLine(String.Format("【{0}】{1}", x.Key, Math.Round(x.Value, 4)));
                    }
                    this.richTextBox1.Text = sb.ToString();
                }
            }
        }
         

        private void btnLoadDictionary_Click(object sender, EventArgs e)
        {
            string floder = Path.GetFullPath(String.Format(@"{0}\dict", CachePathDAL.GetWorkSpacePath()));
            if (!Directory.Exists(floder))
            {
                Directory.CreateDirectory(floder);
            }

            string filename1 = Path.GetFullPath(String.Format(@"{0}\dict\{1}", CachePathDAL.GetWorkSpacePath(), "CharBond.coll"));
            AppendText(String.Format("请稍候，正在加载文件：{0}", filename1));
            objCharBondColl = SerialLib.DeserializeBinary<MemoryBondColl<string>>(filename1);

            string filename2 = Path.GetFullPath(String.Format(@"{0}\dict\{1}", CachePathDAL.GetWorkSpacePath(), "KeyWord.coll"));
            AppendText(String.Format("请稍候，正在加载文件：{0}", filename2));
            objKeyWordColl = SerialLib.DeserializeBinary<MemoryItemColl<string>>(filename2);

            AppendText("字典集加载完毕！");
        }

        private void btnSaveDictionary_Click(object sender, EventArgs e)
        {
            string floder = Path.GetFullPath(String.Format(@"{0}\dict", CachePathDAL.GetWorkSpacePath()));
            if (!Directory.Exists(floder))
            {
                Directory.CreateDirectory(floder);
            }

           
            string filename1 =Path.GetFullPath( String.Format(@"{0}\dict\{1}", CachePathDAL.GetWorkSpacePath(), "CharBond.coll"));
            AppendText(String.Format("请稍候，正在保存文件：{0}", filename1));
            DictionaryDAL.ClearMemoryBondColl<string>(objCharBondColl);            
            SerialLib.SerializeBinary<MemoryBondColl<string>>(objCharBondColl, filename1);

            string filename2 = Path.GetFullPath(String.Format(@"{0}\dict\{1}", CachePathDAL.GetWorkSpacePath(), "KeyWord.coll"));
            AppendText(String.Format("请稍候，正在保存文件：{0}", filename2));
            DictionaryDAL.ClearMemoryItemColl<string>(objKeyWordColl);
            SerialLib.SerializeBinary<MemoryItemColl<string>>(objKeyWordColl, filename2);
             
            AppendText("字典集保存完毕！");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
 
       

    }
}
