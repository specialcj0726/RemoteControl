using RemoteControl.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteControl
{
    public partial class Form1 : Form
    {
        public string sIp = "";
        public string sUser = "";
        public string sPwd = "";

        public const string DOMAIN = "MAGNA";

        public const string USER_ACCOUNT_NB = "NB=nb";
        public const string USER_ACCOUNT_PU = "pu=pu";
        public const string USER_ACCOUNT_CFMADMIN = "cfmadmin=1qaz@wsx";

        public Form1()
        {
            InitializeComponent();
        }



        #region RDR1 Remote Control
        private void btn_R1SWLRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_SWL.txt");

            listBox1.Items.Add("开始远程登录");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_NB);
        }

        private void btn_R1EOL1Remote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_EOL_1.txt");

            listBox1.Items.Add("开始远程登录");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_NB);
        }

        private void btn_R1EOL2Remote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_EOL_2.txt");

            listBox1.Items.Add("开始远程登录");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R1LaserRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_Laser.txt");

            listBox1.Items.Add("开始远程登录");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }

        private void btn_R1PDIRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_PDI.txt");

            listBox1.Items.Add("开始远程登录");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }

        private void btn_R1PackingRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_Packing.txt");

            listBox1.Items.Add("开始远程登录");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }
        #endregion


        #region RDR2 Remote Control
        private void btn_R2MasterRemote_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region RDR5 Remote Control
        private void btn_R5MasterRemote_Click(object sender, EventArgs e)
        {
            sIp = "10.234.21.102";
            sUser = "MAGNA\\pu";
            sPwd = "pu";
            //StartRemoteControl(RemoteControlDo);
        }

        private void btn_R5SWLRemote_Click(object sender, EventArgs e)
        {
            sIp = "10.234.21.104";
            sUser = "MAGNA\\pu";
            sPwd = "pu";
            //StartRemoteControl(RemoteControlDo);
        }

        private void btn_R5EOLRemote_Click(object sender, EventArgs e)
        {
            sIp = "10.234.21.107";
            sUser = "MAGNA\\pu";
            sPwd = "pu";
            //StartRemoteControl(RemoteControlDo);
        }

        private void btn_R5PDIRemote_Click(object sender, EventArgs e)
        {

        }

        private void btn_R5PackingRemote_Click(object sender, EventArgs e)
        {

        }
        #endregion



        private void StartRemoteControl(Action<string, string, string> act, string userAccount)
        {
            if (userAccount.Equals(USER_ACCOUNT_NB))
            {
                sUser = DOMAIN + "\\" + USER_ACCOUNT_NB.Substring(0, USER_ACCOUNT_NB.IndexOf('='));
                sPwd = USER_ACCOUNT_NB.Substring(USER_ACCOUNT_NB.IndexOf('=') + 1);
            }
            else if(userAccount.Equals(USER_ACCOUNT_PU))
            {
                sUser = DOMAIN + "\\" + USER_ACCOUNT_PU.Substring(0, USER_ACCOUNT_PU.IndexOf('='));
                sPwd = USER_ACCOUNT_PU.Substring(USER_ACCOUNT_PU.IndexOf('=') + 1);
            }
            else if (userAccount.Equals(USER_ACCOUNT_CFMADMIN))
            {
                sUser = DOMAIN + "\\" + USER_ACCOUNT_CFMADMIN.Substring(0, USER_ACCOUNT_CFMADMIN.IndexOf('='));
                sPwd = USER_ACCOUNT_CFMADMIN.Substring(USER_ACCOUNT_CFMADMIN.IndexOf('=') + 1);
            }

            if (string.IsNullOrEmpty(sIp))
            {
                MessageBox.Show("ip: " + sIp + "\n\n" + "ip地址获取失败！");
                return;
            }

            if (string.IsNullOrEmpty(sUser))
            {
                MessageBox.Show("user: " + sUser + "\n\n" + "user配置错误！");
                return;
            }

            if (string.IsNullOrEmpty(sPwd))
            {
                MessageBox.Show("password: " + sPwd + "\n\n" + "password配置错误！");
                return;
            }

            act.Invoke(sIp, sUser, sPwd);
        }



        private void RemoteControlDo(string ip, string user, string pwd)
        {
            Process rdcProcess = new Process();
            //使用Powershell自动保存此IP远程桌面的登录用户名和密码
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            //rdcProcess.StartInfo.Arguments = "/add:TERMSRV/" + ip + " /user:" + user + " /pass:" + pwd;
            rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/" + ip + " /user:" + user + " /pass:" + pwd;
            rdcProcess.Start();

            //加载远程桌面
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            //rdcProcess.StartInfo.Arguments = "/v: " + server + " /prompt" + " /console";        //ip or name of computer to connect
            rdcProcess.StartInfo.Arguments = "/v: " + ip + " /console";        //ip or name of computer to connect
            rdcProcess.Start();

            //使用Powershell删除刚刚保存此IP桌面的登录用户名和密码
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            rdcProcess.StartInfo.Arguments = "/delete:TERMSRV/" + ip;
            rdcProcess.Start();
        }

        private string ReadIpFromFtp(string file)
        {
            string line = "";
            string lineDate = "";
            string lineStation = "";
            string lineIp = "";
            string ipFileLocalPath = "";

            try
            {
                ipFileLocalPath = @"C:\RemoteControlIPDownload";
                if (!Directory.Exists(ipFileLocalPath))
                {
                    Directory.CreateDirectory(ipFileLocalPath);
                }

                FtpHelper ftpHelper = new FtpHelper("10.234.29.80/PTool/IPAddress", "", "MAGNA\\svc_cfxoperator", "*Sz00M#u");

                ftpHelper.Download(ipFileLocalPath, file);

                listBox1.Items.Add("====================================================================================");
                listBox1.Items.Add("ip地址文件下载成功");

                StreamReader sr = new StreamReader(Path.Combine(ipFileLocalPath, file));
                line = sr.ReadLine();
                while (line != null)
                {
                    if (line.Contains("date="))
                    {
                        lineDate = line;
                    }
                    if (line.Contains("station="))
                    {
                        lineStation = line;
                    }
                    if (line.Contains("10.234."))
                    {
                        lineIp = line;
                    }

                    line = sr.ReadLine();
                }
                sr.Close();

                listBox1.Items.Add(lineDate + ", " + lineStation + ", " + lineIp);

                return lineIp.Substring(lineIp.IndexOf('=') + 1);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
                throw ex;
            }

        }




        private void btn_Test_Click(object sender, EventArgs e)
        {


        }

        
    }
}
