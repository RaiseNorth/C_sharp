using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrocePaste
{
    public partial class Form1 : Form
    {
        private int hotkey = (int)Keys.F2;
        public Form1()
        {
            InitializeComponent();
            KeyboardHook k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
        }
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==hotkey)
            {
                paste();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }
        private void paste()
        {
            String str = Clipboard.GetText();
            for (int i = 0; i < 10000; i++) ;//短暂的延时
            SendKeys.Send(str);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: hotkey = (int)Keys.F1; break;
                case 1: hotkey = (int)Keys.F2; break;
                case 2: hotkey = (int)Keys.F3; break;
                case 3: hotkey = (int)Keys.F4; break;


            }
        }
    }
}
