﻿using RemoteControl.Helper;
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
using static RemoteControl.Form1;

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

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_NB);
        }

        private void btn_R1EOL1Remote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_EOL_1.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_NB);
        }

        private void btn_R1EOL2Remote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_EOL_2.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R1LaserRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_Laser.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }

        private void btn_R1PDIRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_PDI.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }

        private void btn_R1PackingRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR1_Packing.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }
        #endregion


        private void checkBox_R1_IP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_R1_IP.Checked)
            {
                //lbl_R1_SWL_IP.Text = ReadIpFromFtp("RDR1_SWL.txt");
                //lbl_R1_EOL1_IP.Text = ReadIpFromFtp("RDR1_EOL_1.txt");
                //lbl_R1_EOL2_IP.Text = ReadIpFromFtp("RDR1_EOL_2.txt");
                //lbl_R1_LASER_IP.Text = ReadIpFromFtp("RDR1_Laser.txt");
                //lbl_R1_PDI_IP.Text = ReadIpFromFtp("RDR1_PDI.txt");
                //lbl_R1_PACKING_IP.Text = ReadIpFromFtp("RDR1_Packing.txt");
                Task.Run(() =>
                {
                    if (lbl_R1_SWL_IP.InvokeRequired)
                    {
                        lbl_R1_SWL_IP.Invoke(new Action(() =>
                        {
                            lbl_R1_SWL_IP.Text = ReadIpFromFtp("RDR1_SWL.txt");
                        }));
                    };

                    if (lbl_R1_EOL1_IP.InvokeRequired)
                    {
                        lbl_R1_EOL1_IP.Invoke(new Action(() =>
                        {
                            lbl_R1_EOL1_IP.Text = ReadIpFromFtp("RDR1_EOL_1.txt");
                        }));
                    };

                    if (lbl_R1_EOL2_IP.InvokeRequired)
                    {
                        lbl_R1_EOL2_IP.Invoke(new Action(() =>
                        {
                            lbl_R1_EOL2_IP.Text = ReadIpFromFtp("RDR1_EOL_2.txt");
                        }));
                    };

                    if (lbl_R1_LASER_IP.InvokeRequired)
                    {
                        lbl_R1_LASER_IP.Invoke(new Action(() =>
                        {
                            lbl_R1_LASER_IP.Text = ReadIpFromFtp("RDR1_Laser.txt");
                        }));
                    };

                    if (lbl_R1_PDI_IP.InvokeRequired)
                    {
                        lbl_R1_PDI_IP.Invoke(new Action(() =>
                        {
                            lbl_R1_PDI_IP.Text = ReadIpFromFtp("RDR1_PDI.txt");
                        }));
                    };

                    if (lbl_R1_PACKING_IP.InvokeRequired)
                    {
                        lbl_R1_PACKING_IP.Invoke(new Action(() =>
                        {
                            lbl_R1_PACKING_IP.Text = ReadIpFromFtp("RDR1_Packing.txt");
                        }));
                    };
                });


                //lbl_R2_MASTER_IP.Text = ReadIpFromFtp("RDR2_SEL_MASTER.txt");
                //lbl_R2_SWL_IP.Text = ReadIpFromFtp("RDR2_SEL_SWL.txt");
                //lbl_R2_EOL_IP.Text = ReadIpFromFtp("RDR2_SEL_EOL.txt");
                //lbl_R2_PDI_IP.Text = ReadIpFromFtp("RDR2_PDI.txt");
                //lbl_R2_PACKING_IP.Text = ReadIpFromFtp("RDR2_Packing.txt");
                Task.Run(new Action(() =>
                {
                    if (lbl_R2_MASTER_IP.InvokeRequired)
                    {
                        lbl_R2_MASTER_IP.Invoke(new Action(() =>
                        {
                            lbl_R2_MASTER_IP.Text = ReadIpFromFtp("RDR2_SEL_MASTER.txt");
                        }));
                    };

                    if (lbl_R2_SWL_IP.InvokeRequired)
                    {
                        lbl_R2_SWL_IP.Invoke(new Action(() =>
                        {
                            lbl_R2_SWL_IP.Text = ReadIpFromFtp("RDR2_SEL_SWL.txt");
                        }));
                    };

                    if (lbl_R2_EOL_IP.InvokeRequired)
                    {
                        lbl_R2_EOL_IP.Invoke(new Action(() =>
                        {
                            lbl_R2_EOL_IP.Text = ReadIpFromFtp("RDR2_SEL_EOL.txt");
                        }));
                    };

                    if (lbl_R2_PDI_IP.InvokeRequired)
                    {
                        lbl_R2_PDI_IP.Invoke(new Action(() =>
                        {
                            lbl_R2_PDI_IP.Text = ReadIpFromFtp("RDR2_PDI.txt");
                        }));
                    };

                    if (lbl_R2_PACKING_IP.InvokeRequired)
                    {
                        lbl_R2_PACKING_IP.Invoke(new Action(() =>
                        {
                            lbl_R2_PACKING_IP.Text = ReadIpFromFtp("RDR2_Packing.txt");
                        }));
                    };
                }));


                //lbl_R4_MASTER_IP.Text = ReadIpFromFtp("RDR4_SEL_MASTER.txt");
                //lbl_R4_SWL_IP.Text = ReadIpFromFtp("RDR4_SEL_SWL.txt");
                //lbl_R4_EOL_IP.Text = ReadIpFromFtp("RDR4_SEL_EOL.txt");
                //lbl_R4_PDI_IP.Text = ReadIpFromFtp("RDR4_PDI.txt");
                //lbl_R4_PACKING_IP.Text = ReadIpFromFtp("RDR4_Packing.txt");
                Task.Run(new Action(() =>
                {
                    if (lbl_R4_MASTER_IP.InvokeRequired)
                    {
                        lbl_R4_MASTER_IP.Invoke(new Action(() =>
                        {
                            lbl_R4_MASTER_IP.Text = ReadIpFromFtp("RDR4_SEL_MASTER.txt");
                        }));
                    };

                    if (lbl_R4_SWL_IP.InvokeRequired)
                    {
                        lbl_R4_SWL_IP.Invoke(new Action(() =>
                        {
                            lbl_R4_SWL_IP.Text = ReadIpFromFtp("RDR4_SEL_SWL.txt");
                        }));
                    };

                    if (lbl_R4_EOL_IP.InvokeRequired)
                    {
                        lbl_R4_EOL_IP.Invoke(new Action(() =>
                        {
                            lbl_R4_EOL_IP.Text = ReadIpFromFtp("RDR4_SEL_EOL.txt");
                        }));
                    };

                    if (lbl_R4_PDI_IP.InvokeRequired)
                    {
                        lbl_R4_PDI_IP.Invoke(new Action(() =>
                        {
                            lbl_R4_PDI_IP.Text = ReadIpFromFtp("RDR4_PDI.txt");
                        }));
                    };

                    if (lbl_R4_PACKING_IP.InvokeRequired)
                    {
                        lbl_R4_PACKING_IP.Invoke(new Action(() =>
                        {
                            lbl_R4_PACKING_IP.Text = ReadIpFromFtp("RDR4_Packing.txt");
                        }));
                    };
                }));


                //lbl_R5_MASTER_IP.Text = ReadIpFromFtp("RDR5_SEL_MASTER.txt");
                //lbl_R5_SWL_IP.Text = ReadIpFromFtp("RDR5_SEL_SWL.txt");
                //lbl_R5_EOL_IP.Text = ReadIpFromFtp("RDR5_SEL_EOL.txt");
                //lbl_R5_PDI_IP.Text = ReadIpFromFtp("RDR5_PDI.txt");
                //lbl_R5_PACKING_IP.Text = ReadIpFromFtp("RDR5_Packing.txt");
                Task.Run(new Action(() =>
                {
                    if (lbl_R5_MASTER_IP.InvokeRequired)
                    {
                        lbl_R5_MASTER_IP.Invoke(new Action(() =>
                        {
                            lbl_R5_MASTER_IP.Text = ReadIpFromFtp("RDR5_SEL_MASTER.txt");
                        }));
                    };

                    if (lbl_R5_SWL_IP.InvokeRequired)
                    {
                        lbl_R5_SWL_IP.Invoke(new Action(() =>
                        {
                            lbl_R5_SWL_IP.Text = ReadIpFromFtp("RDR5_SEL_SWL.txt");
                        }));
                    };

                    if (lbl_R5_EOL_IP.InvokeRequired)
                    {
                        lbl_R5_EOL_IP.Invoke(new Action(() =>
                        {
                            lbl_R5_EOL_IP.Text = ReadIpFromFtp("RDR5_SEL_EOL.txt");
                        }));
                    };

                    if (lbl_R5_PDI_IP.InvokeRequired)
                    {
                        lbl_R5_PDI_IP.Invoke(new Action(() =>
                        {
                            lbl_R5_PDI_IP.Text = ReadIpFromFtp("RDR5_PDI.txt");
                        }));
                    };

                    if (lbl_R5_PACKING_IP.InvokeRequired)
                    {
                        lbl_R5_PACKING_IP.Invoke(new Action(() =>
                        {
                            lbl_R5_PACKING_IP.Text = ReadIpFromFtp("RDR5_Packing.txt");
                        }));
                    };
                }));
            }
            else
            {
                lbl_R1_SWL_IP.Text = "-";
                lbl_R1_EOL1_IP.Text = "-";
                lbl_R1_EOL2_IP.Text = "-";
                lbl_R1_LASER_IP.Text = "-";
                lbl_R1_PDI_IP.Text = "-";
                lbl_R1_PACKING_IP.Text = "-";

                lbl_R2_MASTER_IP.Text = "-";
                lbl_R2_SWL_IP.Text = "-";
                lbl_R2_EOL_IP.Text = "-";
                lbl_R2_PDI_IP.Text = "-";
                lbl_R2_PACKING_IP.Text = "-";

                lbl_R4_MASTER_IP.Text = "-";
                lbl_R4_SWL_IP.Text = "-";
                lbl_R4_EOL_IP.Text = "-";
                lbl_R4_PDI_IP.Text = "-";
                lbl_R4_PACKING_IP.Text = "-";

                lbl_R5_MASTER_IP.Text = "-";
                lbl_R5_SWL_IP.Text = "-";
                lbl_R5_EOL_IP.Text = "-";
                lbl_R5_PDI_IP.Text = "-";
                lbl_R5_PACKING_IP.Text = "-";
            }
        }


        #region RDR2 Remote Control
        private void btn_R2MasterRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR2_SEL_MASTER.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R2SWLRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR2_SEL_SWL.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R2EOLRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR2_SEL_EOL.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R2PDIRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR2_PDI.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }

        private void btn_R2PackingRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR2_Packing.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }
        #endregion


        #region RDR4 Remote Control
        private void btn_R4MasterRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR4_SEL_MASTER.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R4SWLRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR4_SEL_SWL.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R4EOLRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR4_SEL_EOL.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R4PDIRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR4_PDI.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }

        private void btn_R4PackingRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR4_Packing.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }
        #endregion


        #region RDR5 Remote Control
        private void btn_R5MasterRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR5_SEL_MASTER.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R5SWLRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR5_SEL_SWL.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R5EOLRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR5_SEL_EOL.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_PU);
        }

        private void btn_R5PDIRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR5_PDI.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }

        private void btn_R5PackingRemote_Click(object sender, EventArgs e)
        {
            sIp = ReadIpFromFtp("RDR5_Packing.txt");

            StartRemoteControl(RemoteControlDo, USER_ACCOUNT_CFMADMIN);
        }
        #endregion



        private void btn_Test_Click(object sender, EventArgs e)
        {
            

        }

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
            listBox1.Items.Add("开始远程登录！");

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

            //if (listBox1.InvokeRequired)
            //{
            //    listBox1.Invoke(new Action(() =>
            //    {
            //        listBox1.Items.Add("====================================================================================");
            //    }));
            //}
            //else
            //{
            //    listBox1.Items.Add("====================================================================================");
            //}

            listBox1.Items.Add("====================================================================================");


            try
            {
                ipFileLocalPath = @"C:\RemoteControlIPDownload";
                if (!Directory.Exists(ipFileLocalPath))
                {
                    Directory.CreateDirectory(ipFileLocalPath);
                }

                FtpHelper ftpHelper = new FtpHelper("10.234.29.80/PTool/IPAddress", "", "MAGNA\\svc_cfxoperator", "*Sz00M#u");

                ftpHelper.Download(ipFileLocalPath, file);

                listBox1.Items.Add("ip地址文件下载成功！");

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
                listBox1.Items.Add("ip地址文件下载异常！");
                listBox1.Items.Add(ex.Message);

                FileInfo fi = new FileInfo(Path.Combine(ipFileLocalPath, file));
                if (fi.Length == 0)
                {
                    listBox1.Items.Add("ip地址文件下载失败，文件大小为0！");
                    return "";
                }

                return "";
                //throw ex;
            }

        }

        
    }
}
