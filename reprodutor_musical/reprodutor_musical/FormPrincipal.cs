using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace reprodutor_musical
{
    public partial class FormPrincipal : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int wmsg, int wparam, int lparam);
        public FormPrincipal()
        {
            InitializeComponent();
            PersonalizarDesign();
            //102; 20; 17

        }

        private void PersonalizarDesign()
        {
            panelSubMedia.Visible = false;
            panelToolsSub.Visible = false;
            panelPlaylist.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelPlaylist.Visible==true)
                panelPlaylist.Visible = false;
            if (panelSubMedia.Visible==true)
                panelSubMedia.Visible = false;
            if (panelToolsSub.Visible==true)
               panelToolsSub.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #region Media
        private void btnMedia_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMedia);

        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion
        #region Management
        private void button1_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelPlaylist);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion
        #region Tools
        private void btnTools_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelToolsSub);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion
        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3());
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private Form ativeform = null;
        private void OpenChildForm(Form childForm)
        {
            if (ativeform!=null)
                ativeform.Close();
            ativeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            if (this.WindowState == FormWindowState.Maximized)
            {
                btnMax.BackgroundImage = Bitmap.FromFile(@"C:\\Users\\Heliandro\\Pictures\\Imagens gratuitas\\Icons\max.png");
                this.WindowState = FormWindowState.Normal;
            }
            else if(this.WindowState == FormWindowState.Normal)
            {
                btnMax.BackgroundImage = Bitmap.FromFile(@"C:\\Users\\Heliandro\\Pictures\\Imagens gratuitas\\Icons\res.png");
                this.WindowState = FormWindowState.Maximized;

            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label_data.Text = DateTime.Now.ToLongTimeString().ToString();
        }
    }
}
