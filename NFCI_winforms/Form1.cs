using System.Text.RegularExpressions;
namespace NFCI_winforms
{
    public partial class Form1 : Form
    {
#pragma warning disable IDE1006 // Naming Styles
        private char bitrate_suffix { get; set; }
        readonly string reg_only_numbers = @"^\d+$";
        public Form1()
        {
            InitializeComponent();
            cmbVideoBitrateSuffix.SelectedIndex = 0;
        }
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> codecMap =
            new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
        {
            {
                "MP4", new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "Video", new Dictionary<string, string>
                        {
                            { "H264", "libx264" },
                            { "H265", "libx265" },
                            { "H264-Nvenc", "h264_nvenc" }
                        }
                    },
                    {
                        "Audio", new Dictionary<string, string>
                        {
                            { "AAC", "aac" },
                            { "MP3", "libmp3lame" }
                        }
                    }
                }
            },
            {
                "WebM", new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "Video", new Dictionary<string, string>
                        {
                            { "VP9", "libvpx-vp9" },
                            { "VP8", "libvpx" }
                        }
                    },
                    {
                        "Audio", new Dictionary<string, string>
                        {
                            { "Opus", "libopus" },
                            { "Vorbis", "libvorbis" }
                        }
                    }
                }
            }
        };
        private void Button_SelectFile(object sender, EventArgs e) //Button for selecting video file
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Video files|*.mp4;*.mov;*.wmv;*.avi;*.flv;*.webm;*.mkv;*.avi;*.mpeg;*.mpv;*.svi;*.3gp|All files|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtFileInput.Text = openFileDialog1.FileName;
                if (txtVideoBitrate.Text == "" && !rdoConstantBitrate.Checked) //if constant bitrate is empty and if Constant bitrate mode is NOT checked e.g. if Variable bitrate is used
                {
                    if (chkDisableAudio.Checked) // if audio is disabled
                    {
                        btnStart.Enabled = true;
                    }
                    else if (!chkDisableAudio.Checked && Regex.IsMatch(txtAudioBitrate.Text, reg_only_numbers, RegexOptions.Compiled)) // if audio is enabled and is a number
                    {
                        btnStart.Enabled = true;
                    }
                    else
                    {
                        btnStart.Enabled = false;
                    }
                }
                else if (Regex.IsMatch(txtVideoBitrate.Text, reg_only_numbers, RegexOptions.Compiled)) //if constant bitrate input is only numbers
                {
                    if (chkDisableAudio.Checked) // if audio is disabled
                    {
                        btnStart.Enabled = true;
                    }
                    else if (!chkDisableAudio.Checked && Regex.IsMatch(txtAudioBitrate.Text, reg_only_numbers, RegexOptions.Compiled)) // if audio is enabled and is a number
                    {
                        btnStart.Enabled = true;
                    }
                    else
                    {
                        btnStart.Enabled = false;
                    }
                }
            }
        }
        private void Button_Start(object sender, EventArgs e) //Start button with main tasks
        {
            string video_codec = "";
            string audio_codec = "";
            string convert_to = "";
            string bitrate = "";
            string bitrate_option = "";
            foreach (Control control in grpConvertTo.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = control as RadioButton;
                    if (radioButton!.Checked)
                    {
                        convert_to = radioButton.Text;
                    }
                }
            }
            if (rdoMP4.Checked)
            {
                video_codec = codecMap["MP4"]["Video"][cmbVideoCodec.Text];
                audio_codec = codecMap["MP4"]["Audio"][cmbAudioCodec.Text];
            }
            else if (rdoWebm.Checked)
            {
                video_codec = codecMap["WebM"]["Video"][cmbVideoCodec.Text];
                audio_codec = codecMap["WebM"]["Audio"][cmbAudioCodec.Text];
            }
            foreach (Control control in grpBitrateMode.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = control as RadioButton;
                    if (radioButton!.Checked)
                    {
                        bitrate = radioButton.Text;
                    }
                }
            }
            if (bitrate == "Variable")
            {
                foreach (Control control in grpVideoBitrateOption.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radioButton = control as RadioButton;
                        if (radioButton!.Checked)
                        {
                            bitrate_option = radioButton.Text;
                        }
                    }
                }
            }
            else if (bitrate == "Constant")
            {
                bitrate_option = txtVideoBitrate.Text;
                bitrate_suffix = Convert.ToChar(cmbVideoBitrateSuffix.GetItemText(cmbVideoBitrateSuffix.SelectedItem));
            }
            richTextBox1.Text = "";
            richTextBox1.AppendText($"Input: {openFileDialog1.FileName}\n");
            richTextBox1.AppendText($"Convert to: {convert_to}\n");
            richTextBox1.AppendText($"Video codec: {video_codec}\n");
            if (!chkDisableAudio.Checked)
            {
                richTextBox1.AppendText($"Audio codec: {audio_codec}\n");
                richTextBox1.AppendText($"Audio bitrate: {txtAudioBitrate.Text}k\n");
            }
            richTextBox1.AppendText($"Disable audio: {chkDisableAudio.Checked}\n");
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
            if (rdoMP4.Checked)
            {
                cmbVideoCodec.Items.Clear();
                cmbAudioCodec.Items.Clear();
                foreach (string codec in codecMap["MP4"]["Video"].Keys)
                {
                    cmbVideoCodec.Items.Add(codec);
                }
                foreach (string codec in codecMap["MP4"]["Audio"].Keys)
                {
                    cmbAudioCodec.Items.Add(codec);
                }

                cmbVideoCodec.SelectedIndex = 0;
                cmbAudioCodec.SelectedIndex = 0;
            }
            else if (rdoWebm.Checked)
            {
                cmbVideoCodec.Items.Clear();
                cmbAudioCodec.Items.Clear();
                foreach (string codec in codecMap["WebM"]["Video"].Keys)
                {
                    cmbVideoCodec.Items.Add(codec);
                }
                foreach (string codec in codecMap["WebM"]["Audio"].Keys)
                {
                    cmbAudioCodec.Items.Add(codec);
                }

                cmbVideoCodec.SelectedIndex = 0;
                cmbAudioCodec.SelectedIndex = 0;
            }
        }

        private void CheckBox_ShoworHide_Audio(object sender, EventArgs e) //hide or show audio groupbox if "Disable audio" is enabled or disabled
        {
            if (chkDisableAudio.Checked)
            {
                grpAudioCodec.Hide();
                grpAudioBitrate.Hide();
            }
            else if (!chkDisableAudio.Checked)
            {
                grpAudioCodec.Show();
                grpAudioBitrate.Show();
            }
        }

        private void RadioButton_Select_BitrateMode_Variable(object sender, EventArgs e) //Variable bitrate
        {
            if (rdoVariableBitrate.Checked)
            {
                rdoCRF.Show();
                rdoABR.Show();
                rdoCQ.Show();
                mtxtConstantQuality.Show();
                mtxtAverageQuality.Show();
                mtxtConstrainedQuality.Show();
                txtVideoBitrate.Hide();
                txtVideoBitrateInfo.Hide();
                cmbVideoBitrateSuffix.Hide();
                txtVideoBitrate.Clear();
                if (openFileDialog1.FileName != "")
                {
                    btnStart.Enabled = true;
                }
                rdoCRF.Checked = true;
            }
        }

        private void RadioButton_Select_BitrateMode_Constant(object sender, EventArgs e) //Constant bitrate
        {
            if (rdoConstantBitrate.Checked)
            {
                rdoCRF.Hide();
                rdoABR.Hide();
                rdoCQ.Hide();
                mtxtConstantQuality.Hide();
                mtxtAverageQuality.Hide();
                mtxtConstrainedQuality.Hide();
                txtVideoBitrate.Show();
                txtVideoBitrateInfo.Show();
                cmbVideoBitrateSuffix.Show();
                btnStart.Enabled = false;
            }
        }

        private void ComboBox_BitrateMode_Constant_Suffix(object sender, EventArgs e) //Bitrate suffix for constant bitrate (M or K)
        {
            bitrate_suffix = Convert.ToChar(cmbVideoBitrateSuffix.GetItemText(cmbVideoBitrateSuffix.SelectedItem));
        }

        private void TextBox_BitrateMode_Constant_Bitrate(object sender, EventArgs e) //Constant bitrate input
        {
            if (Regex.IsMatch(txtVideoBitrate.Text, reg_only_numbers, RegexOptions.Compiled) && openFileDialog1.FileName != "")
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void TextBox_Audio_Bitrate(object sender, EventArgs e) //Audio bitrate input
        {
            if (Regex.IsMatch(txtAudioBitrate.Text, reg_only_numbers, RegexOptions.Compiled) && openFileDialog1.FileName != "")
            {
                if (rdoConstantBitrate.Checked && Regex.IsMatch(txtVideoBitrate.Text, reg_only_numbers, RegexOptions.Compiled))
                {
                    btnStart.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = true;
                }
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RadioButton_Select_ConvertTo_Webm(sender, e);
        }
    }
}