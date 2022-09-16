namespace NFCI_winforms
{
    public partial class Form1 : Form
    {
#pragma warning disable IDE1006 // Naming Styles
        private string convert_to { get; set; }
        private string video_codecs { get; set; }
        private string audio_codecs { get; set; }
        private void MainTask()
        {
            richTextBox1.Text = "";
            richTextBox1.AppendText($"Input: {openFileDialog1.FileName}\n");
            richTextBox1.AppendText($"Convert to: {convert_to}\n");
            richTextBox1.AppendText($"Video codec: {video_codecs}\n");
            if (!checkBox1.Checked)
            {
            richTextBox1.AppendText($"Audio codec: {audio_codecs}\n");
            }
            richTextBox1.AppendText($"Disable audio: {checkBox1.Checked}");
        }

        public Form1()
        {
            InitializeComponent();
            convert_to = "webm";
            video_codecs = "libvpx-vp9";
            audio_codecs = "libopus";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Video files|*.mp4;*.mov;*.wmv;*.avi;*.flv;*.webm;*.mkv;*.avi;*.mpeg;*.mpv;*.svi;*.3gp|All files|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MainTask();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                convert_to =radioButton1.Text.ToLower();
                radioButton3.Show();
                radioButton4.Show();
                radioButton5.Hide();
                radioButton6.Hide();
                radioButton7.Hide();
                radioButton3.Checked = true;
                radioButton8.Show();
                radioButton9.Show();
                radioButton10.Hide();
                radioButton8.Checked = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                convert_to = radioButton2.Text.ToLower();
                groupBox2.Size = new Size(97, 104);
                radioButton3.Hide();
                radioButton4.Hide();
                radioButton5.Show();
                radioButton6.Show();
                radioButton7.Show();
                radioButton5.Checked = true;
                radioButton8.Hide();
                radioButton9.Hide();
                radioButton10.Show();
                radioButton10.Checked = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                video_codecs = radioButton3.Text;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                video_codecs = radioButton4.Text;
            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                video_codecs = radioButton5.Text;
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                video_codecs = radioButton6.Text;
            }
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                video_codecs = radioButton7.Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox3.Hide();
            }
            else if (!checkBox1.Checked)
            {
                groupBox3.Show();
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                audio_codecs = radioButton8.Text;
            }
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                audio_codecs = radioButton9.Text;
            }
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                audio_codecs = radioButton10.Text;
            }
        }
    }
}