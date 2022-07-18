using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bashTool
{
    public partial class Form1 : Form
    {
        public String str = "";
        public String IPs = "";
        public String Port = "";
        public String Passwd = "";
        private void textGenerate(string Text)
        {
            
            /*StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                textBox1.Text += line + "\r\n";
            }*/
            textBox1.Text = Text;

        }
        /*
         初始化
         */
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            textGenerate(Properties.Resources.mysql_autoinstall);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //文本替换
            textBox1.Text = textBox1.Text.Replace("setPasswd", "172.16.128.166");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "";
                textGenerate(Properties.Resources.mysql_autoinstall);
                
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "";
                textGenerate(Properties.Resources.yum_autoinstall);
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                textBox1.Text = "";
                textGenerate(Properties.Resources.exec);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setIP setIP = new setIP();
            setIP.getParam += new backParam(fun_GetChildParam);
            if (setIP.ShowDialog() == DialogResult.OK) {
                textBox1.Text = textBox1.Text.Replace("setIP", str);
                IPs = str;
                return;
            }
            
        }
        //委托事件执行方法
        void fun_GetChildParam(string w_childpara)
        {
            str = w_childpara;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setPasswd setPasswd = new setPasswd();
            
            setPasswd.getParam +=new backParam(fun_GetChildParam);
            if (setPasswd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = textBox1.Text.Replace("setPasswd", str);
                Passwd = str;
                setPasswd.str = Passwd;
                return;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setPort setPort = new setPort();
            setPort.getParam +=new backParam(fun_GetChildParam);
            if (setPort.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = textBox1.Text.Replace("setPort", str);
                Port = str;
                return;
            }
        }
    }
}
