using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cifratore
{
    public partial class Form1 : Form
    {
        const int xOffset = 5;
        const int yOffset = 20;

        bool readyToTranslate = false;

        bool inputControl = true;

        const int maxChar = 126;
        const int minChar = 32;

        bool readyToBeCopied = false;

        int fontSize;

        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(720, 480);  //dimensioni minime e massime per la finestra
            this.MaximumSize = new Size(1200, 800);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Cifrario di Vigenère by Filippo Marini"; //titolo e forma iniziale della finestra
            this.Size = new Size(910, 640);

            fontSize = (this.Width + this.Height) / 100 - 5;

            button1.Font = new Font(Font.FontFamily, fontSize);
            button2.Font = new Font(Font.FontFamily, fontSize);
            button3.Font = new Font(Font.FontFamily, fontSize);
            label1.Font = new Font(Font.FontFamily, fontSize);
            label2.Font = new Font(Font.FontFamily, fontSize);
            label3.Font = new Font(Font.FontFamily, fontSize);
            textBox1.Font = new Font(Font.FontFamily, fontSize);
            textBox2.Font = new Font(Font.FontFamily, fontSize);
            textBox3.Font = new Font(Font.FontFamily, fontSize);

            textBox1.Multiline = true;  //set up di tutti i componenti e le loro posizioni
            textBox1.Width = this.Width / 7 * 2;
            textBox1.Height = this.Height / 3 * 2;
            textBox1.Left = this.Width / 14 - xOffset;
            textBox1.Top = this.Height / 2 - textBox1.Height / 2 - yOffset;

            button1.Text = "Inserisci un messaggio e un verme";
            button1.Width = this.Width / 14 * 3;
            button1.Height = this.Height / 10;
            button1.Left = this.Width / 28 * 11 - xOffset;
            button1.Top = this.Height / 2 - button1.Height / 2 - yOffset;

            textBox2.Multiline = true;
            textBox2.Width = this.Width / 7 * 2;
            textBox2.Height = this.Height / 3 * 2;
            textBox2.Left = this.Width / 14 * 9 - xOffset;
            textBox2.Top = this.Height / 2 - textBox1.Height / 2 - yOffset;

            textBox3.Width = this.Width / 14 * 3;
            textBox3.Height = this.Height / 10;
            textBox3.Left = this.Width / 28 * 11 - xOffset;
            textBox3.Top = this.Height / 2 - button1.Height / 2 - button1.Height - yOffset;

            button2.Text = "Copia il testo qua sopra";
            button2.Width = textBox1.Width;
            button2.Height = this.Height / 20;
            button2.Left = textBox1.Left;
            button2.Top = textBox1.Top + textBox1.Height + button2.Height;

            button3.Text = "Copia il testo qua sopra";
            button3.Width = textBox2.Width;
            button3.Height = this.Height / 20;
            button3.Left = textBox2.Left;
            button3.Top = textBox2.Top + textBox2.Height + button3.Height;

            label1.Text = "Messaggio decrittografato";
            label1.Left = textBox1.Left + textBox1.Width / 2 - label1.Width / 2;
            label1.Top = textBox1.Top - label1.Height * 2;

            label2.Text = "Messaggio crittografato";
            label2.Left = textBox2.Left + textBox2.Width / 2 - label2.Width / 2;
            label2.Top = textBox2.Top - label2.Height * 2;

            progressBar1.Visible = false;
            progressBar1.Width = button1.Width;
            progressBar1.Height = this.Height / 25;
            progressBar1.Left = button1.Left;
            progressBar1.Top = button1.Top + button1.Height + progressBar1.Height;

            label3.Text = "Verme";
            label3.Left = textBox3.Left + textBox3.Width / 2 - label3.Width / 2;
            label3.Top = textBox3.Top - label3.Height * 2;

            toolTip1.ShowAlways = true;
            toolTip1.InitialDelay = 1000;
            toolTip1.SetToolTip(label1, "Nella textBox qui sotto viene visualizzato il messaggio decrittografato oppure può essere inserito il messaggio da crittografare");

            toolTip1.ShowAlways = true;
            toolTip1.InitialDelay = 1000;
            toolTip1.SetToolTip(label2, "Nella textBox qui sotto viene visualizzato il messaggio crittografato oppure può essere inserito il messaggio da decrittografare");

            toolTip1.ShowAlways = true;
            toolTip1.InitialDelay = 1000;
            toolTip1.SetToolTip(label3, "Nella textbox qui sotto bisogna inserire un verme, ovvero una stringa alfanumerica che permetterà di ottenere il messaggio crittografato\nSe si vuole ottenere una corrispondnza tra messaggio crittografato e decritttografato bisogna usare lo stesso verme");

            MessageBox.Show("Inserire la frase da crittografare nella casella di testo a sinistra e un verme nella casella di testo centrale, per poi premere il pulsante e generare la frase crittografata nella casella di testo a destra e viceversa");  //istruzioni
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            fontSize = (this.Width + this.Height) / 100 - 5;

            button1.Font = new Font(Font.FontFamily, fontSize);
            button2.Font = new Font(Font.FontFamily, fontSize);
            button3.Font = new Font(Font.FontFamily, fontSize);
            label1.Font = new Font(Font.FontFamily, fontSize);
            label2.Font = new Font(Font.FontFamily, fontSize);
            label3.Font = new Font(Font.FontFamily, fontSize);
            textBox1.Font = new Font(Font.FontFamily, fontSize);
            textBox2.Font = new Font(Font.FontFamily, fontSize);
            textBox3.Font = new Font(Font.FontFamily, fontSize);

            textBox1.Width = this.Width / 7 * 2;    //design responsive
            textBox1.Height = this.Height / 3 * 2;
            textBox1.Left = this.Width / 14 - xOffset;
            textBox1.Top = this.Height / 2 - textBox1.Height / 2 - yOffset;

            button1.Width = this.Width / 14 * 3;
            button1.Height = this.Height / 10;
            button1.Left = this.Width / 28 * 11 - xOffset;
            button1.Top = this.Height / 2 - button1.Height / 2 - yOffset;

            textBox2.Width = this.Width / 7 * 2;
            textBox2.Height = this.Height / 3 * 2;
            textBox2.Left = this.Width / 14 * 9 - xOffset;
            textBox2.Top = this.Height / 2 - textBox1.Height / 2 - yOffset;

            textBox3.Width = this.Width / 14 * 3;
            textBox3.Height = this.Height / 10;
            textBox3.Left = this.Width / 28 * 11 - xOffset;
            textBox3.Top = this.Height / 2 - button1.Height / 2 - button1.Height - yOffset;

            button2.Width = textBox1.Width;
            button2.Height = this.Height / 20;
            button2.Left = textBox1.Left;
            button2.Top = textBox1.Top + textBox1.Height + button2.Height;

            button3.Width = textBox2.Width;
            button3.Height = this.Height / 20;
            button3.Left = textBox2.Left;
            button3.Top = textBox2.Top + textBox2.Height + button3.Height;

            label1.Left = textBox1.Left + textBox1.Width / 2 - label1.Width / 2;
            label1.Top = textBox1.Top - label1.Height * 2;

            label2.Left = textBox2.Left + textBox2.Width / 2 - label2.Width / 2;
            label2.Top = textBox2.Top - label2.Height * 2;

            progressBar1.Width = button1.Width;
            progressBar1.Height = this.Height / 25;
            progressBar1.Left = button1.Left;
            progressBar1.Top = button1.Top + button1.Height + progressBar1.Height;

            label3.Left = textBox3.Left + textBox3.Width / 2 - label3.Width / 2;
            label3.Top = textBox3.Top - label3.Height * 2;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (inputControl)
            {
                if (textBox2.Text != "")
                {
                    e.Handled = true;
                    MessageBox.Show("Si puo inserire il testo solo in uno dei due textbox, cosi che il programma possa crittografare o decrittografare");
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (inputControl)
            {
                if (textBox1.Text != "")
                {
                    e.Handled = true;
                    MessageBox.Show("Si puo inserire il testo solo in uno dei due textbox, cosi che il programma possa crittografare o decrittografare");
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputControl)
            {
                if (readyToTranslate)
                {
                    if (textBox2.Text == "")
                    {
                        if (textBox3.Text.Length > textBox1.Text.Length)
                        {
                            DialogResult res = MessageBox.Show("Il verme inserito è più lungo del messaggio da cifrare, vuoi comunque usarlo ?\nEsso verrà comunque troncato", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.No)
                            {
                                textBox3.Focus();
                                return;
                            }
                        }

                        inputControl = false;
                        Cripting();
                    }
                    else if (textBox1.Text == "")
                    {
                        if (textBox3.Text.Length > textBox2.Text.Length)
                        {
                            DialogResult res = MessageBox.Show("Il verme inserito è più lungo del messaggio da cifrare, vuoi comunque usarlo ?\nEsso verrà comunque troncato", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.No)
                            {
                                textBox3.Focus();
                                return;
                            }
                        }

                        inputControl = false;
                        Decripting();
                    }
                }
                else
                {
                    MessageBox.Show("Devi inserire un messaggio da crittografare o decrtittografare e un verme per poter cliccare questo pulsante");
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("Le due textBox verranno svuotate\nVuoi mantenere il verme ?", "Conferma", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(res == DialogResult.No)
                {
                    textBox3.Text = "";
                }
                else if(res == DialogResult.Cancel)
                {
                    return;
                }

                readyToBeCopied = false;
                inputControl = true;
                button1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                progressBar1.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un mesaggio e un verme";
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un mesaggio";
            }
            else if (textBox1.Text != "" && textBox3.Text != "")
            {
                readyToTranslate = true;
                button1.Text = "Crittografa il messaggio ----->";
            }
            else if (textBox2.Text != "" && textBox3.Text != "")
            {
                readyToTranslate = true;
                button1.Text = "<----- Decrittografa il messaggio";
            }
            else if (textBox3.Text == "" && (textBox1.Text != "" || textBox2.Text != ""))
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un verme";
            }
        }

        private void Cripting()
        {
            char[] message = new char[textBox1.Text.Length];

            int vermeL;

            if (textBox3.Text.Length > textBox1.Text.Length)
            {
                vermeL = textBox1.Text.Length;
            }
            else
            {
                vermeL = textBox3.Text.Length;
            }

            char[] verme = new char[vermeL];

            for (int i = 0; i < message.Length; i++)
            {
                textBox1.Text.CopyTo(i, message, i, 1);
            }

            for (int i = 0; i < verme.Length; i++)
            {
                textBox3.Text.CopyTo(i, verme, i, 1);
            }

            progressBar1.Value = 0;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = message.Length;
            progressBar1.Step = 1;

            for (int i = 0; i < message.Length; i++)
            {

                int newChar = Convert.ToInt32(message[i]) + Convert.ToInt32(verme[i % vermeL]);

                while (newChar > maxChar)
                {
                    newChar -= (maxChar - minChar);
                }

                textBox2.Text += Convert.ToChar(newChar);

                progressBar1.PerformStep();
            }

            readyToBeCopied = true;

            MessageBox.Show("Crittografia completata, per inserire nuovi messaggi premere il pulsante centrale");
            button1.Text = "Premi qua";
        }

        private void Decripting()
        {
            char[] message = new char[textBox2.Text.Length];

            int vermeL;

            if (textBox3.Text.Length > textBox2.Text.Length)
            {
                vermeL = textBox2.Text.Length;
            }
            else
            {
                vermeL = textBox3.Text.Length;
            }

            char[] verme = new char[vermeL];

            for (int i = 0; i < message.Length; i++)
            {
                textBox2.Text.CopyTo(i, message, i, 1);
            }

            for (int i = 0; i < verme.Length; i++)
            {
                textBox3.Text.CopyTo(i, verme, i, 1);
            }

            progressBar1.Value = 0;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = message.Length;
            progressBar1.Step = 1;

            for (int i = 0; i < message.Length; i++)
            {

                int newChar = Convert.ToInt32(message[i]) - Convert.ToInt32(verme[i % vermeL]);

                while (newChar < minChar)
                {
                    newChar += (maxChar - minChar);
                }

                textBox1.Text += Convert.ToChar(newChar);

                progressBar1.PerformStep();
            }

            readyToBeCopied = true;

            MessageBox.Show("Decrittografia completata, per inserire nuovi messaggi premere il pulsante centrale");
            button1.Text = "Premi qua";
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (inputControl)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (readyToBeCopied)
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("Il testo della textBox1 è stato copiato negli appunti");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (readyToBeCopied)
            {
                Clipboard.SetText(textBox2.Text);
                MessageBox.Show("Il testo della textBox2 è stato copiato negli appunti");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un mesaggio e un verme";
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un mesaggio";
            }
            else if (textBox1.Text != "" && textBox3.Text != "")
            {
                readyToTranslate = true;
                button1.Text = "Crittografa il messaggio ----->";
            }
            else if (textBox2.Text != "" && textBox3.Text != "")
            {
                readyToTranslate = true;
                button1.Text = "<----- Decrittografa il messaggio";
            }
            else if (textBox3.Text == "" && (textBox1.Text != "" || textBox2.Text != ""))
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un verme";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un mesaggio e un verme";
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un mesaggio";
            }
            else if (textBox1.Text != "" && textBox3.Text != "")
            {
                readyToTranslate = true;
                button1.Text = "Crittografa il messaggio ----->";
            }
            else if (textBox2.Text != "" && textBox3.Text != "")
            {
                readyToTranslate = true;
                button1.Text = "<----- Decrittografa il messaggio";
            }
            else if (textBox3.Text == "" && (textBox1.Text != "" || textBox2.Text != ""))
            {
                readyToTranslate = false;
                button1.Text = "Inserisci un verme";
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }
    }
}