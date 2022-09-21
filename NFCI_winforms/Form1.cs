namespace NFCI_winforms
{
    public partial class Form1 : Form
    {
#pragma warning disable IDE1006 // Naming Styles
        private string convert_to { get; set; }
        private string video_codecs { get; set; }
        private string audio_codecs { get; set; }
        private string bitrate { get; set; }
        private string bitrate_option { get; set; }
        private char bitrate_suffix { get; set; }
        public Form1()
        {
            InitializeComponent();
            // set default variables
            convert_to = "webm";
            video_codecs = "libvpx-vp9";
            audio_codecs = "libopus";
            bitrate = "Variable";
            bitrate_option = "CRF";
            comboBox1.SelectedIndex = 0;
            bitrate_suffix = 'M';
        }
        private void button1_Click(object sender, EventArgs e) //Button for selecting video file
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
        private void button2_Click(object sender, EventArgs e) //Start button with main tasks
        {
            richTextBox1.Text = "";
            richTextBox1.AppendText($"Input: {openFileDialog1.FileName}\n");
            richTextBox1.AppendText($"Convert to: {convert_to}\n");
            richTextBox1.AppendText($"Video codec: {video_codecs}\n");
            if (!checkBox1.Checked)
            {
                richTextBox1.AppendText($"Audio codec: {audio_codecs}\n");
            }
            richTextBox1.AppendText($"Disable audio: {checkBox1.Checked}\n");
            richTextBox1.AppendText($"Bitrate mode: {bitrate}\n");
            if (Convert.ToString(bitrate) == "Variable")
            {
            richTextBox1.AppendText($"Bitrate option: {bitrate_option}\n");
            }
            else
            {
                richTextBox1.AppendText($"Bitrate: {bitrate_option}{bitrate_suffix}");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Convert to WebM button
        {
            if (radioButton1.Checked)
            {
                convert_to = radioButton1.Text.ToLower();
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
                ActiveForm.Text = "Convert to WebM";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Convert to MP4 button
        {
            if (radioButton2.Checked)
            {
                convert_to = radioButton2.Text.ToLower();
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
                ActiveForm.Text = "Convert to MP4";
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) //libvpx-vp9 video codec
        {
            if (radioButton3.Checked)
            {
                video_codecs = radioButton3.Text;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e) //libvpx-vp8 video codec
        {
            if (radioButton4.Checked)
            {
                video_codecs = radioButton4.Text;
            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e) //libx264 video codec
        {
            if (radioButton5.Checked)
            {
                video_codecs = radioButton5.Text;
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e) //libx265 video codec
        {
            if (radioButton6.Checked)
            {
                video_codecs = radioButton6.Text;
            }
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e) //h264_nvenc video codec
        {
            if (radioButton7.Checked)
            {
                video_codecs = radioButton7.Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //hide or show audio groupbox if "Disable audio" is enabled or disabled
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

        private void radioButton8_CheckedChanged(object sender, EventArgs e) //libopus audio codec
        {
            if (radioButton8.Checked)
            {
                audio_codecs = radioButton8.Text;
            }
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e) //libvorbis audio codec
        {
            if (radioButton9.Checked)
            {
                audio_codecs = radioButton9.Text;
            }
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e) //aac audio codec
        {
            if (radioButton10.Checked)
            {
                audio_codecs = radioButton10.Text;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e) //Variable bitrate
        {
            if (radioButton11.Checked)
            {
                bitrate = radioButton11.Text;
                radioButton13.Show();
                radioButton14.Show();
                radioButton15.Show();
                maskedTextBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Hide();
                textBox5.Hide();
                comboBox1.Hide();
                textBox4.Clear();
                if (openFileDialog1.FileName != null)
                {
                    button2.Enabled = true;
                }
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e) //Constant bitrate
        {
            if (radioButton12.Checked)
            {
                bitrate = radioButton12.Text;
                radioButton13.Hide();
                radioButton14.Hide();
                radioButton15.Hide();
                maskedTextBox1.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Show();
                textBox5.Show();
                comboBox1.Show();
                button2.Enabled = false;
            }
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e) //CRF variable bitrate
        {
            if (radioButton13.Checked)
            {
                bitrate_option = radioButton13.Text;
            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e) //ABR variable bitrate
        {
            if (radioButton14.Checked)
            {
                bitrate_option = radioButton14.Text;
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e) //CQ variable bitrate
        {
            if (radioButton15.Checked)
            {
                bitrate_option = radioButton15.Text;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bitrate_suffix = Convert.ToChar(comboBox1.GetItemText(comboBox1.SelectedItem));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            bitrate_option = textBox4.Text;
        }
    }
}