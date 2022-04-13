using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormAnimation;
namespace reprodutor_musical
{
    public partial class FormInicio : Form
    {
        int aux = 0;
        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
            timer3.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            
            if(circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
                FormPrincipal principal = new FormPrincipal();
                principal.ShowDialog();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label_especial.Text += ".";
            if (label_especial.Text.Contains("."))
            {
                aux++;
                if (aux == 4)
                {
                    label_especial.Text = "Opening";
                    aux = 0;
                }
            }
        }
    }
}
