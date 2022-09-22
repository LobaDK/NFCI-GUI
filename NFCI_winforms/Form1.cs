using System.Text.RegularExpressions;
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
        readonly string reg_only_numbers = @"^\d+$";
        private string audio_bitrate { get; set; }
        public Form1()
        {
            InitializeComponent();
            // set default variables
            convert_to = "webm"; //default converter to webm
            video_codecs = "libvpx-vp9"; //default video codecs to vp9
            audio_codecs = "libopus"; //default audio codecs to opus
            bitrate = "Variable"; //default bitrate mode to variable
            bitrate_option = "CRF"; //default bitrate option to CRF
            comboBox1.SelectedIndex = 0; //default constant bitrate mode to M (Megabytes)
            bitrate_suffix = 'M'; //same as above, could possibly be redundant
            openFileDialog1.FileName = ""; //default Filename to nothing until player has selected one
            audio_bitrate = "192"; //default audio bitrate. kilobit prefix not included, remind myself to add in code
        }
        private void Button_SelectFile(object sender, EventArgs e) //Button for selecting video file
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Video files|*.mp4;*.mov;*.wmv;*.avi;*.flv;*.webm;*.mkv;*.avi;*.mpeg;*.mpv;*.svi;*.3gp|All files|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                if (textBox4.Text == "" && !radioButton12.Checked) //if constant bitrate is empty and if Constant bitrate mode is NOT checked e.g. if Variable bitrate is used
                {
                    if (checkBox1.Checked)
                    {
                        button2.Enabled = true;
                    }
                    else if (!checkBox1.Checked && Regex.IsMatch(textBox8.Text, reg_only_numbers, RegexOptions.Compiled))
                    {
                        button2.Enabled = true;
                    }
                    else
                    {
                        button2.Enabled=false;
                    }
                }
                else if (Regex.IsMatch(textBox4.Text, reg_only_numbers, RegexOptions.Compiled)) //if constant bitrate input is only numbers
                {
                    if (checkBox1.Checked && Regex.IsMatch(textBox8.Text, reg_only_numbers, RegexOptions.Compiled))
                    {
                        button2.Enabled = true;
                    }
                    else if (!checkBox1.Checked)
                    {
                        button2.Enabled = true;
                    }
                    else
                    {
                        button2.Enabled = false;
                    }
                }
            }
        }
        private void Button_Start(object sender, EventArgs e) //Start button with main tasks
        {
            richTextBox1.Text = "";
            richTextBox1.AppendText($"Input: {openFileDialog1.FileName}\n");
            richTextBox1.AppendText($"Convert to: {convert_to}\n");
            richTextBox1.AppendText($"Video codec: {video_codecs}\n");
            if (!checkBox1.Checked)
            {
                richTextBox1.AppendText($"Audio codec: {audio_codecs}\n");
                richTextBox1.AppendText($"Audio bitrate: {audio_bitrate}k\n");
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

        private void RadioButton_Select_ConvertTo_Webm(object sender, EventArgs e) //Convert to WebM button
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

        private void RadioButton_Select_ConvertTo_Mp4(object sender, EventArgs e) //Convert to MP4 button
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
        private void RadioButton_Select_Codecs_Vp9(object sender, EventArgs e) //libvpx-vp9 video codec
        {
            if (radioButton3.Checked)
            {
                video_codecs = radioButton3.Text;
            }
        }
        private void RadioButton_Select_Codecs_Vp8(object sender, EventArgs e) //libvpx-vp8 video codec
        {
            if (radioButton4.Checked)
            {
                video_codecs = radioButton4.Text;
            }
        }
        private void RadioButton_Select_Codecs_H264(object sender, EventArgs e) //libx264 video codec
        {
            if (radioButton5.Checked)
            {
                video_codecs = radioButton5.Text;
            }
        }
        private void RadioButton_Select_Codecs_H265(object sender, EventArgs e) //libx265 video codec
        {
            if (radioButton6.Checked)
            {
                video_codecs = radioButton6.Text;
            }
        }
        private void RadioButton_Select_Codecs_Nvenc(object sender, EventArgs e) //h264_nvenc video codec
        {
            if (radioButton7.Checked)
            {
                video_codecs = radioButton7.Text;
            }
        }

        private void CheckBox_ShoworHide_Audio(object sender, EventArgs e) //hide or show audio groupbox if "Disable audio" is enabled or disabled
        {
            if (checkBox1.Checked)
            {
                groupBox3.Hide();
                groupBox6.Hide();
            }
            else if (!checkBox1.Checked)
            {
                groupBox3.Show();
                groupBox6.Show();
            }
        }

        private void RadioButton_Select_Codecs_Opus(object sender, EventArgs e) //libopus audio codec
        {
            if (radioButton8.Checked)
            {
                audio_codecs = radioButton8.Text;
            }
        }
        private void RadioButton_Select_Codecs_Vorbis(object sender, EventArgs e) //libvorbis audio codec
        {
            if (radioButton9.Checked)
            {
                audio_codecs = radioButton9.Text;
            }
        }
        private void RadioButton_Select_Codecs_Aac(object sender, EventArgs e) //aac audio codec
        {
            if (radioButton10.Checked)
            {
                audio_codecs = radioButton10.Text;
            }
        }

        private void RadioButton_Select_BitrateMode_Variable(object sender, EventArgs e) //Variable bitrate
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
                if (openFileDialog1.FileName != "")
                {
                    button2.Enabled = true;
                }
                radioButton13.Checked = true;
            }
        }

        private void RadioButton_Select_BitrateMode_Constant(object sender, EventArgs e) //Constant bitrate
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

        private void Radiobutton_Select_BitrateMode_Variable_Crf(object sender, EventArgs e) //CRF variable bitrate
        {
            if (radioButton13.Checked)
            {
                bitrate_option = radioButton13.Text;
            }
        }

        private void Radiobutton_Select_BitrateMode_Variable_Abr(object sender, EventArgs e) //ABR variable bitrate
        {
            if (radioButton14.Checked)
            {
                bitrate_option = radioButton14.Text;
            }
        }

        private void Radiobutton_Select_BitrateMode_Variable_Cq(object sender, EventArgs e) //CQ variable bitrate
        {
            if (radioButton15.Checked)
            {
                bitrate_option = radioButton15.Text;
            }
        }

        private void ComboBox_BitrateMode_Constant_Suffix(object sender, EventArgs e) //Bitrate suffix for constant bitrate (M or K)
        {
            bitrate_suffix = Convert.ToChar(comboBox1.GetItemText(comboBox1.SelectedItem));
        }

        private void TextBox_BitrateMode_Constant_Bitrate(object sender, EventArgs e) //Constant bitrate input
        {
            bitrate_option = textBox4.Text;
            if (Regex.IsMatch(textBox4.Text, reg_only_numbers, RegexOptions.Compiled) && openFileDialog1.FileName != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void TextBox_Audio_Bitrate(object sender, EventArgs e) //Audio bitrate input
        {
            audio_bitrate = textBox8.Text;
            if (Regex.IsMatch(textBox8.Text, reg_only_numbers, RegexOptions.Compiled) && openFileDialog1.FileName != "")
            {
                if (radioButton12.Checked && Regex.IsMatch(textBox4.Text, reg_only_numbers, RegexOptions.Compiled))
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = true;
                }
            }
            else
            {
                button2.Enabled = false;
            }
        }
    }
}