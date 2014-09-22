using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MABiggerImage
{
    public partial class DECTool : Form
    {
        #region Init
        List<string> ProgressList;
        int i;
        System.Timers.Timer DECTimer = new System.Timers.Timer(5000);
        System.Timers.Timer GetTimer = new System.Timers.Timer(800);
        string HostCn = "MA.webpatch.sdg-china.com/MA/PROD";
        string HostTw = "download.ma.mobimon.com.tw/contents";

        void GetTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (i >= ProgressList.Count)
            {
                GetTimer.Stop();
                BeginInvoke(new Action(() => { lblMessage.Text = "Ready"; }));
                BeginInvoke(new Action(() => AllEnable()));
                pbAll.Value = 0;
                return;
            }
            BeginInvoke(new Action(() =>
            {
                lblMessage.Text = "当前处理进度： " + i.ToString() + "/" + ProgressList.Count.ToString();
                pbAll.Value = 100 * i / ProgressList.Count;
            }));
            string Url = ProgressList[i];
            i++;
            SaveResponse(Url);
        }

        void DECTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string ExecPath = "mapngdecoder.py";
            //string ExecPath = txtTarget.Text + "\\mapngdecoder.py";
            if (i >= ProgressList.Count)
            {
                DECTimer.Stop();
                BeginInvoke(new Action(() => { lblMessage.Text = "Ready"; }));
                BeginInvoke(new Action(() => AllEnable()));
                pbAll.Value = 0;
                return;
            }
            BeginInvoke(new Action(() =>
            {
                lblMessage.Text = "当前处理进度： " + i.ToString() + "/" + ProgressList.Count.ToString();
                pbAll.Value = 100 * i / ProgressList.Count;
            }));
            string file = ProgressList[i];
            i++;
            Process pro = Process.Start(ExecPath, file);
        }

        public DECTool()
        {
            InitializeComponent();
            GetTimer.Elapsed += GetTimer_Elapsed;
            DECTimer.Elapsed += DECTimer_Elapsed;
        }

        #endregion

        void AllDisable()
        {
            //btnGet.Enabled = false;
            //btnDEC.Enabled = false;
            //btnMove.Enabled = false;
            //btnSelectSource.Enabled = false;
            //btnSelectTarget.Enabled = false;
            //txtSource.ReadOnly = true;
            //txtTarget.ReadOnly = true;
            tcAll.Enabled = false;
        }

        void AllEnable()
        {
            //btnGet.Enabled = true;
            //btnDEC.Enabled = true;
            //btnMove.Enabled = true;
            //btnSelectSource.Enabled = true;
            //btnSelectTarget.Enabled = true;
            //txtSource.ReadOnly = false;
            //txtTarget.ReadOnly = false;
            tcAll.Enabled = true;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSource.Text) || string.IsNullOrWhiteSpace(txtTarget.Text))
            {
                lblMessage.Text = "路径不能为空！";
                return;
            }
            if (txtSource.Text.Contains(".txt"))
            {
                if (!File.Exists(txtSource.Text))
                {
                    lblMessage.Text = "源文件不存在！";
                    return;
                }
            }
            else
            {
                if (!Directory.Exists(txtSource.Text))
                {
                    lblMessage.Text = "源文件夹不存在！";
                    return;
                }
            }
            try
            {
                if (!Directory.Exists(txtTarget.Text))
                    Directory.CreateDirectory(txtTarget.Text);
                if (!Directory.Exists(txtTarget.Text + "\\ori"))
                    Directory.CreateDirectory(txtTarget.Text + "\\ori");
                if (!Directory.Exists(txtTarget.Text + "\\png"))
                    Directory.CreateDirectory(txtTarget.Text + "\\png");
            }
            catch
            {
                lblMessage.Text = "创建文件夹失败！";
                return;
            }
            ProgressList = GetUrls(!txtSource.Text.Contains(".txt"));
            i = 0;
            GetTimer.Interval = chkTW.Checked ? 3000 : 800;
            GetTimer.Start();
            BeginInvoke(new Action(() => AllDisable()));
        }

        public List<string> GetFiles(string DirPath, string NameRequire = "*chara*")
        {
            string[] Files = Directory.GetFiles(DirPath, NameRequire, System.IO.SearchOption.TopDirectoryOnly);
            return Files.ToList().FindAll(item => !item.Contains(" "));
        }

        public List<string> GetFilesFromFile(string FilePath)
        {
            return File.ReadAllLines(FilePath, Encoding.UTF8).ToList();
        }

        public List<string> GetUrls(bool IsFromDir = true)
        {
            List<string> SourceList;
            if (IsFromDir)
                SourceList = GetFiles(txtSource.Text);
            else
                SourceList = GetFilesFromFile(txtSource.Text);
            List<string> ExistList = GetFiles(txtTarget.Text + "\\ori");
            foreach (string s in ExistList)
            {
                string FileName = s.Substring(s.LastIndexOf("full_") + 5);
                if (IsFromDir && SourceList.Contains(txtSource.Text + "\\" + FileName))
                    SourceList.Remove(txtSource.Text + "\\" + FileName);
                if (!IsFromDir && SourceList.Contains(FileName))
                    SourceList.Remove(FileName);
            }
            List<string> Urls = new List<string>();
            Regex Ex4Num = new Regex("5\\d\\d\\d");
            Regex Ex4Num2 = new Regex("6\\d\\d\\d");
            foreach (string s in SourceList)
            {
                string FileName = s.Substring(s.LastIndexOf("\\") + 1);
                string Url;
                if (Ex4Num.Matches(FileName).Count > 0 || Ex4Num2.Matches(FileName).Count > 0)
                    Url = string.Format("http://{1}/2/card_full_max/full_{0}?cyt=1", FileName, chkTW.Checked ? HostTw : HostCn);
                else
                    Url = string.Format("http://{1}/2/card_full/full_{0}?cyt=1", FileName, chkTW.Checked ? HostTw : HostCn);
                if (Url.Contains("horo"))
                    Url = Url.Replace("card_full", "card_full_h");
                Urls.Add(Url);
            }
            return Urls;
        }

        public List<string> GetFilesNeedDEC()
        {
            List<string> oriFiles = GetFiles(txtTarget.Text + "\\ori");
            List<string> pngFiles = GetFiles(txtTarget.Text + "\\png");
            foreach (string png in pngFiles)
            {
                if (oriFiles.Contains(png.Replace(".png", "").Replace("png", "ori")))
                    oriFiles.Remove(png.Replace(".png", "").Replace("png", "ori"));
            }
            List<string> othFiles = oriFiles.FindAll(item => item.Contains(".png"));
            foreach (string file in othFiles)
            {
                if (oriFiles.Contains(file.Replace(".png", "")))
                    oriFiles.Remove(file.Replace(".png", ""));
                oriFiles.Remove(file);
            }
            return oriFiles;
        }

        public void SaveResponse(string Url)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(Url));
                webRequest.Method = "GET";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.UserAgent = "PP's PostTool";

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                Stream rs = response.GetResponseStream();
                List<byte> bl = new List<byte>();
                while (true)
                {
                    int data = rs.ReadByte();
                    if (data == -1)
                        break;
                    else
                    {
                        byte b = (byte)data;
                        bl.Add(b);
                    }
                }
                byte[] byteArray = bl.ToArray();
                string FileName = Url.Substring(Url.LastIndexOf("/") + 1);
                FileName = FileName.Substring(0, FileName.IndexOf("?"));
                File.WriteAllBytes(txtTarget.Text + "\\ori\\" + FileName, byteArray);
            }
            catch { }
        }

        private void btnDEC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTarget.Text))
            {
                lblMessage.Text = "目标路径不能为空！";
                return;
            }
            if (!Directory.Exists(txtTarget.Text))
            {
                lblMessage.Text = "目标文件夹不存在！";
                return;
            }
            ProgressList = GetFilesNeedDEC();
            i = 0;
            DECTimer.Interval = chkTW.Checked ? 20000 : 5000;
            if (chkSlow.Checked)
                DECTimer.Interval *= 1.5;
            DECTimer.Start();
            BeginInvoke(new Action(() => AllDisable()));
        }

        void MovePNG()
        {
            List<string> AllFiles = GetFiles(txtTarget.Text + "\\ori");
            foreach (string file in AllFiles)
            {
                if (file.Contains(".png"))
                {
                    if (File.Exists(file.Replace("ori", "png")))
                        File.Delete(file);
                    else
                        File.Move(file, file.Replace("ori", "png"));
                }
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTarget.Text))
            {
                lblMessage.Text = "目标路径不能为空！";
                return;
            }
            if (!Directory.Exists(txtTarget.Text))
            {
                lblMessage.Text = "目标文件夹不存在！";
                return;
            }
            BeginInvoke(new Action(() => AllDisable()));
            MovePNG();
            BeginInvoke(new Action(() => { lblMessage.Text = "Ready"; }));
            BeginInvoke(new Action(() => AllEnable()));
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择源文件夹路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = dialog.SelectedPath;
            }
        }

        private void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                txtSource.Text = dialog.FileName;
        }

        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择目标文件夹路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtTarget.Text = dialog.SelectedPath;
            }
        }

        private void btnNormalDEC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNormalPath.Text))
            {
                lblMessage.Text = "目标路径不能为空！";
                return;
            }
            if (!Directory.Exists(txtNormalPath.Text))
            {
                lblMessage.Text = "目标文件夹不存在！";
                return;
            }
            try
            {
                if (!Directory.Exists(txtNormalPath.Text + "\\png"))
                    Directory.CreateDirectory(txtNormalPath.Text + "\\png");
            }
            catch
            {
                lblMessage.Text = "创建文件夹失败！";
                return;
            }
            ProgressList = GetNormalFilesNeedDEC();
            i = 0;
            DECTimer.Interval = chkTW.Checked ? 20000 : 5000;
            if (chkFast.Checked)
                DECTimer.Interval = 1000;
            if (chkSlow.Checked)
                DECTimer.Interval *= 1.5;
            DECTimer.Start();
            BeginInvoke(new Action(() => AllDisable()));
        }


        public List<string> GetNormalFilesNeedDEC()
        {
            List<string> oriFiles = GetFiles(txtNormalPath.Text, "*");
            List<string> pngFiles = GetFiles(txtNormalPath.Text + "\\png", "*.png");
            foreach (string png in pngFiles)
            {
                if (oriFiles.Contains(png.Replace(".png", "").Replace("\\png", "")))
                    oriFiles.Remove(png.Replace(".png", "").Replace("\\png", ""));
            }
            List<string> othFiles = oriFiles.FindAll(item => item.Contains(".png"));
            foreach (string file in othFiles)
            {
                if (oriFiles.Contains(file.Replace(".png", "")))
                    oriFiles.Remove(file.Replace(".png", ""));
                oriFiles.Remove(file);
            }
            return oriFiles;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择源文件夹路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtNormalPath.Text = dialog.SelectedPath;
            }
        }

        private void btnNormalMove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNormalPath.Text))
            {
                lblMessage.Text = "目标路径不能为空！";
                return;
            }
            if (!Directory.Exists(txtNormalPath.Text))
            {
                lblMessage.Text = "目标文件夹不存在！";
                return;
            }
            try
            {
                if (!Directory.Exists(txtNormalPath.Text + "\\png"))
                    Directory.CreateDirectory(txtNormalPath.Text + "\\png");
            }
            catch
            {
                lblMessage.Text = "创建文件夹失败！";
                return;
            }
            BeginInvoke(new Action(() => AllDisable()));
            MovePNGNormal();
            BeginInvoke(new Action(() => { lblMessage.Text = "Ready"; }));
            BeginInvoke(new Action(() => AllEnable()));
        }

        void MovePNGNormal()
        {
            List<string> AllFiles = GetFiles(txtNormalPath.Text, "*.png");
            foreach (string file in AllFiles)
            {
                if (File.Exists(file.Replace(txtNormalPath.Text, txtNormalPath.Text + "\\png")))
                    File.Delete(file);
                else
                    File.Move(file, file.Replace(txtNormalPath.Text, txtNormalPath.Text + "\\png"));
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            if (GetTimer.Enabled)
                GetTimer.Stop();
            if (DECTimer.Enabled)
                DECTimer.Stop();
            AllEnable();
        }

    }
}
