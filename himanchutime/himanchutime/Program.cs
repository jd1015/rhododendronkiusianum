using System;
using System.Drawing;
using System.Windows.Forms;

namespace himanchutime
{ 

    static class MainWindow
    {
        static void Main()
        {
            ResidentTest rm = new ResidentTest();
            Application.Run();
        }
    }

    class ResidentTest : Form
    {
        Form2 fm2;
        ContextMenuStrip menu;
        ToolStripMenuItem menuItem2;
        NotifyIcon icon;
        public ResidentTest()
        {
            this.ShowInTaskbar = false;
            this.setComponents();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setComponents()
        {
            icon = new NotifyIcon();
            icon.Icon = new Icon("app.ico");
            icon.Visible = true;
            icon.Text = "常駐アプリテスト";
            menu = new ContextMenuStrip();
            menuItem2 = new ToolStripMenuItem();
            menuItem2.Text = "&スタート";
            menuItem2.Click += new EventHandler(Start_Click);
            menu.Items.Add(menuItem2);
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem = new ToolStripMenuItem();
            menuItem.Text = "&終了";
            menuItem.Click += new EventHandler(Close_Click);
            menu.Items.Add(menuItem);
            icon.ContextMenuStrip = menu;
            fm2 = new Form2();
            fm2.ShowInTaskbar = false;
            fm2.Show();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            fm2.button1_Click_Public(null, null);
            menuItem2.Text = fm2.getStatusText();
            if ("ストップ".Equals(menuItem2.Text))
            {
                icon.Text = fm2.getTimeStr();
            }
        }
    }
}