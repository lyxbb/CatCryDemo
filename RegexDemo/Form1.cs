using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace RegexDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonValify_Click(object sender, EventArgs e)
        {
            //由数字和26个英文字母组成的字符串
            //Regex reg = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,10}$");

            string input = textBoxValify.Text;
            //if (input.Length < 8 || input.Length > 20)
            //{
            //    MessageBox.Show("密码位数必须大于8位小于20位");
            //}
            //Regex regn = new Regex(@"^[0-9]*$");
            //bool a = regn.IsMatch(input);
            //if (!a)
            //{
            //    MessageBox.Show("不包含数字");
            //}
            //regn = new Regex(@"^[a-z]*$");
            //a = regn.IsMatch(input);
            //if (!a)
            //{
            //    MessageBox.Show("不包含小写字母");
            //}
            //regn = new Regex(@"^[A-Z]*$");
            //a = regn.IsMatch(input);
            //if (!a)
            //{
            //    MessageBox.Show("不包含大写字母");
            //}

          
            Regex reg = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$");
            Console.WriteLine($"1.2开始执行验证：{DateTime.Now}");
            bool a = reg.IsMatch(input);
            Console.WriteLine($"1.3开始执行验证：{DateTime.Now}");
            MessageBox.Show(a ? "通过验证" : "验证失败");
        }
    }
}
