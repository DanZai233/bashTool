﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bashTool
{
    public partial class setPasswd : Form
    {
        public setPasswd()
        {
            InitializeComponent();
            
        }
        //私有变量和赋值，value值在父窗口传递
        private string w_str;
        public string str
        {
            set
            {
                w_str = value;
            }
        }
        public event backParam getParam;//委托事件，接受一个string变量
        private void button1_Click(object sender, EventArgs e)
        {
            getParam(this.textBox1.Text);//将变量委托
            this.DialogResult = DialogResult.OK;
        }
    }
}
