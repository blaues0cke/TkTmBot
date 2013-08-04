using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using gma.System.Windows;

namespace TkTmBot
{
    public partial class Form1 : Form
    {


        public bool UpKeyDown = false;
        public bool DownKeyDown = false;
        public bool LeftKeyDown = false;
        public bool RightKeyDown = false;
        public bool SpaceDown = false;



        public long LastKeyLog;


        public Form1()
        {
            InitializeComponent();
        }








        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox1.Checked)
            {


                if ((e.KeyData == Keys.Up && !UpKeyDown) || (e.KeyData == Keys.Down && !DownKeyDown) || (e.KeyData == Keys.Left && !LeftKeyDown) || (e.KeyData == Keys.Right && !RightKeyDown) || (e.KeyData == Keys.Space && !SpaceDown))
                {
                    listView1.Items.Add(new ListViewItem(new string[] { (GetTickCount() - LastKeyLog).ToString() + " ms", "Gedrückt", e.KeyData.ToString() }));
                    LastKeyLog = GetTickCount();
                }
                if (e.KeyData == Keys.Up && !UpKeyDown) {
                    UpKeyDown = true;
                }
                if (e.KeyData == Keys.Down && !DownKeyDown)
                {
                    DownKeyDown = true;
                }
                if (e.KeyData == Keys.Left && !LeftKeyDown) 
                {
                    LeftKeyDown = true;
                } 
                if (e.KeyData == Keys.Right && !RightKeyDown)
                {
                    RightKeyDown = true;
                }
                if (e.KeyData == Keys.Space && !SpaceDown)
                {
                    SpaceDown = true;
                }
                


            }
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            if (checkBox1.Checked)
            {

                if (e.KeyData == Keys.Back)
                {
                    listView1.Items.Clear();
                    listView1.Items.Add(new ListViewItem(new string[] { "0 ms", "Losgelassen", e.KeyData.ToString() }));


                }
                else if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Left || e.KeyData == Keys.Right || e.KeyData == Keys.Space)
                {

                    listView1.Items.Add(new ListViewItem(new string[] { (GetTickCount() - LastKeyLog).ToString() + " ms", "Losgelassen", e.KeyData.ToString() }));

                    if (e.KeyData == Keys.Up)
                    {
                        UpKeyDown = false;
                    }
                    if (e.KeyData == Keys.Down)
                    {
                        DownKeyDown = false;
                    }
                    if (e.KeyData == Keys.Left)
                    {
                        LeftKeyDown = false;
                    }
                    if (e.KeyData == Keys.Right)
                    {
                        RightKeyDown = false;
                    }
                    if (e.KeyData == Keys.Space)
                    {
                        SpaceDown = false;
                    }

                }
                LastKeyLog = GetTickCount();


            }
        }






        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern long GetTickCount();

        private void button1_Click(object sender, EventArgs e)
        {
            LastKeyLog = GetTickCount();
        }

        UserActivityHook actHook;

        private void Form1_Load(object sender, EventArgs e)
        {
            actHook = new UserActivityHook(); // crate an instance with global hooks

            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            actHook.KeyUp += new KeyEventHandler(MyKeyUp);
        }



        
        [DllImport("user32.dll")]
        private static extern int keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public enum KeyboardEventFlags
        {
            KEYDOWN = 0,
            KEYUP = 2
        } 
        
      private void SendKeystroke(Keys key) {
         keybd_event((byte)key, 0, 0, 0);
      }













        private void button1_Click_1(object sender, EventArgs e)
        {
           // textBox1.Focus();
            Thread test = new Thread(new ThreadStart(tttt));
            test.Start();
        }


        public void tttt()
        {
            
            Thread.Sleep(5000);
           // keybd_event(Keys.Up, 0, KeyboardEventFlags.KEYDOWN, UIntPtr.Zero);
            Thread.Sleep(2000);
            //keybd_event(Keys.Up, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
            
             /*
            //SendKeys.SendWait("{UP}");
            SendKeystroke(Keys.Up);*/
            Thread.Sleep(100);
            tttt();
        }

        int pos = 0;


        public void ttt()
        {

            Thread.Sleep(Convert.ToInt16(listView1.Items[pos].SubItems[0].Text.ToString().Replace(" ms", "")));
            
            /*
            if (listView1.Items[pos].SubItems[1].Text.ToString() == "Losgelassen")
            {
               
                
                switch (listView1.Items[pos].SubItems[2].Text.ToString())
                {
                    case "Back":
                        //keybd_event(Keys.Back, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                        SendKeys.SendWait("{DOWN}");
                        break;
                    case "Up":
                        SendKeys.SendWait("{UP}");
                       // keybd_event(Keys.Up, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                        break;
                    case "Left":
                        //keybd_event(Keys.Left, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                        SendKeys.SendWait("{LEFT}");
                        break;
                    case "Right":
                        //keybd_event(Keys.Right, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                        SendKeys.SendWait("{RIGHT}");
                        break;

                    
                case "Return":
                    SendKeys.SendWait("{ENTER}");
                    break;


                default:
                    SendKeys.SendWait(listView1.Items[pos].SubItems[2].Text.ToString());
                    break;

                }

            }
            else if (listView1.Items[pos].SubItems[1].Text.ToString() == "Gedrückt")
            {
              
                switch (listView1.Items[pos].SubItems[2].Text.ToString())
                {
                    case "Back":
                        keybd_event(Keys.Back, 0, KeyboardEventFlags.KEYDOWN, UIntPtr.Zero);
                        break;
                    case "Up":
                        keybd_event(Keys.Up, 0, KeyboardEventFlags.KEYDOWN, UIntPtr.Zero);
                        break;
                    case "Left":
                        keybd_event(Keys.Left, 0, KeyboardEventFlags.KEYDOWN, UIntPtr.Zero);
                        break;
                    case "Right":
                        keybd_event(Keys.Right, 0, KeyboardEventFlags.KEYDOWN, UIntPtr.Zero);
                        break;

                        /*
                    case "Return":
                        SendKeys.SendWait("{ENTER}");
                        break;


                    default:
                        SendKeys.SendWait(listView1.Items[pos].SubItems[2].Text.ToString());
                        break;

                }

            }
*/
            switch (listView1.Items[pos].SubItems[2].Text.ToString())
            {
                case "Back":
                    //keybd_event(Keys.Back, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                    SendKeys.SendWait("{DOWN}");
                    break;
                case "Up":
                    SendKeys.SendWait("{UP}");
                    // keybd_event(Keys.Up, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                    break;
                case "Left":
                    //keybd_event(Keys.Left, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                    SendKeys.SendWait("{LEFT}");
                    break;
                case "Right":
                    //keybd_event(Keys.Right, 0, KeyboardEventFlags.KEYUP, UIntPtr.Zero);
                    SendKeys.SendWait("{RIGHT}");
                    break;
            }

            
                pos++;
            if (pos < listView1.Items.Count)
            {
                ttt();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listView1.Items[pos].SubItems[Convert.ToInt16(textBox1.Text)].Text.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            keybd_event((byte)Keys.Up, 0, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            keybd_event((byte)Keys.Up, 0, 2, 0);
        }


    }
}
