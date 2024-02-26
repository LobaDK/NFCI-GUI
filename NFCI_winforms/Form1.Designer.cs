namespace NFCI_winforms
{
    public partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSelectFile = new Button();
            openFileDialog1 = new OpenFileDialog();
            chkDisableAudio = new CheckBox();
            txtFileInput = new TextBox();
            richTextBox1 = new RichTextBox();
            btnStart = new Button();
            rdoWebm = new RadioButton();
            rdoMP4 = new RadioButton();
            grpConvertTo = new GroupBox();
            grpVideoCodec = new GroupBox();
            cmbVideoCodec = new ComboBox();
            grpAudioCodec = new GroupBox();
            cmbAudioCodec = new ComboBox();
            grpBitrateMode = new GroupBox();
            rdoConstantBitrate = new RadioButton();
            rdoVariableBitrate = new RadioButton();
            grpVideoBitrateOption = new GroupBox();
            cmbVideoBitrateSuffix = new ComboBox();
            txtVideoBitrate = new TextBox();
            mtxtConstrainedQuality = new TextBox();
            mtxtAverageQuality = new TextBox();
            rdoCQ = new RadioButton();
            rdoABR = new RadioButton();
            mtxtConstantQuality = new MaskedTextBox();
            rdoCRF = new RadioButton();
            txtVideoBitrateInfo = new TextBox();
            textBox6 = new TextBox();
            grpAudioBitrate = new GroupBox();
            txtAudioBitrate = new TextBox();
            grpConvertTo.SuspendLayout();
            grpVideoCodec.SuspendLayout();
            grpAudioCodec.SuspendLayout();
            grpBitrateMode.SuspendLayout();
            grpVideoBitrateOption.SuspendLayout();
            grpAudioBitrate.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(btnSelectFile, "btnSelectFile");
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += Button_SelectFile;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkDisableAudio
            // 
            resources.ApplyResources(chkDisableAudio, "chkDisableAudio");
            chkDisableAudio.Name = "chkDisableAudio";
            chkDisableAudio.UseVisualStyleBackColor = true;
            chkDisableAudio.CheckedChanged += CheckBox_ShoworHide_Audio;
            // 
            // txtFileInput
            // 
            resources.ApplyResources(txtFileInput, "txtFileInput");
            txtFileInput.Name = "txtFileInput";
            txtFileInput.ReadOnly = true;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(richTextBox1, "richTextBox1");
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            // 
            // btnStart
            // 
            resources.ApplyResources(btnStart, "btnStart");
            btnStart.Name = "btnStart";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += Button_Start;
            // 
            // rdoWebm
            // 
            resources.ApplyResources(rdoWebm, "rdoWebm");
            rdoWebm.Checked = true;
            rdoWebm.Name = "rdoWebm";
            rdoWebm.TabStop = true;
            rdoWebm.UseVisualStyleBackColor = true;
            rdoWebm.CheckedChanged += RadioButton_Select_ConvertTo_Webm;
            // 
            // rdoMP4
            // 
            resources.ApplyResources(rdoMP4, "rdoMP4");
            rdoMP4.Name = "rdoMP4";
            rdoMP4.UseVisualStyleBackColor = true;
            // 
            // grpConvertTo
            // 
            grpConvertTo.Controls.Add(rdoWebm);
            grpConvertTo.Controls.Add(rdoMP4);
            resources.ApplyResources(grpConvertTo, "grpConvertTo");
            grpConvertTo.Name = "grpConvertTo";
            grpConvertTo.TabStop = false;
            // 
            // grpVideoCodec
            // 
            grpVideoCodec.Controls.Add(cmbVideoCodec);
            resources.ApplyResources(grpVideoCodec, "grpVideoCodec");
            grpVideoCodec.Name = "grpVideoCodec";
            grpVideoCodec.TabStop = false;
            // 
            // cmbVideoCodec
            // 
            cmbVideoCodec.FormattingEnabled = true;
            resources.ApplyResources(cmbVideoCodec, "cmbVideoCodec");
            cmbVideoCodec.Name = "cmbVideoCodec";
            // 
            // grpAudioCodec
            // 
            grpAudioCodec.Controls.Add(cmbAudioCodec);
            resources.ApplyResources(grpAudioCodec, "grpAudioCodec");
            grpAudioCodec.Name = "grpAudioCodec";
            grpAudioCodec.TabStop = false;
            // 
            // cmbAudioCodec
            // 
            cmbAudioCodec.FormattingEnabled = true;
            resources.ApplyResources(cmbAudioCodec, "cmbAudioCodec");
            cmbAudioCodec.Name = "cmbAudioCodec";
            // 
            // grpBitrateMode
            // 
            grpBitrateMode.Controls.Add(rdoConstantBitrate);
            grpBitrateMode.Controls.Add(rdoVariableBitrate);
            resources.ApplyResources(grpBitrateMode, "grpBitrateMode");
            grpBitrateMode.Name = "grpBitrateMode";
            grpBitrateMode.TabStop = false;
            // 
            // rdoConstantBitrate
            // 
            resources.ApplyResources(rdoConstantBitrate, "rdoConstantBitrate");
            rdoConstantBitrate.Name = "rdoConstantBitrate";
            rdoConstantBitrate.TabStop = true;
            rdoConstantBitrate.UseVisualStyleBackColor = true;
            rdoConstantBitrate.CheckedChanged += RadioButton_Select_BitrateMode_Constant;
            // 
            // rdoVariableBitrate
            // 
            resources.ApplyResources(rdoVariableBitrate, "rdoVariableBitrate");
            rdoVariableBitrate.Checked = true;
            rdoVariableBitrate.Name = "rdoVariableBitrate";
            rdoVariableBitrate.TabStop = true;
            rdoVariableBitrate.UseVisualStyleBackColor = true;
            rdoVariableBitrate.CheckedChanged += RadioButton_Select_BitrateMode_Variable;
            // 
            // grpVideoBitrateOption
            // 
            grpVideoBitrateOption.Controls.Add(cmbVideoBitrateSuffix);
            grpVideoBitrateOption.Controls.Add(txtVideoBitrateInfo);
            grpVideoBitrateOption.Controls.Add(txtVideoBitrate);
            grpVideoBitrateOption.Controls.Add(mtxtConstrainedQuality);
            grpVideoBitrateOption.Controls.Add(mtxtAverageQuality);
            grpVideoBitrateOption.Controls.Add(rdoCQ);
            grpVideoBitrateOption.Controls.Add(rdoABR);
            grpVideoBitrateOption.Controls.Add(mtxtConstantQuality);
            grpVideoBitrateOption.Controls.Add(rdoCRF);
            resources.ApplyResources(grpVideoBitrateOption, "grpVideoBitrateOption");
            grpVideoBitrateOption.Name = "grpVideoBitrateOption";
            grpVideoBitrateOption.TabStop = false;
            // 
            // cmbVideoBitrateSuffix
            // 
            cmbVideoBitrateSuffix.FormattingEnabled = true;
            cmbVideoBitrateSuffix.Items.AddRange(new object[] { resources.GetString("cmbVideoBitrateSuffix.Items"), resources.GetString("cmbVideoBitrateSuffix.Items1") });
            resources.ApplyResources(cmbVideoBitrateSuffix, "cmbVideoBitrateSuffix");
            cmbVideoBitrateSuffix.Name = "cmbVideoBitrateSuffix";
            cmbVideoBitrateSuffix.SelectedIndexChanged += ComboBox_BitrateMode_Constant_Suffix;
            // 
            // txtVideoBitrate
            // 
            resources.ApplyResources(txtVideoBitrate, "txtVideoBitrate");
            txtVideoBitrate.Name = "txtVideoBitrate";
            txtVideoBitrate.TextChanged += TextBox_BitrateMode_Constant_Bitrate;
            // 
            // mtxtConstrainedQuality
            // 
            mtxtConstrainedQuality.BorderStyle = BorderStyle.None;
            resources.ApplyResources(mtxtConstrainedQuality, "mtxtConstrainedQuality");
            mtxtConstrainedQuality.Name = "mtxtConstrainedQuality";
            mtxtConstrainedQuality.ReadOnly = true;
            // 
            // mtxtAverageQuality
            // 
            mtxtAverageQuality.BorderStyle = BorderStyle.None;
            resources.ApplyResources(mtxtAverageQuality, "mtxtAverageQuality");
            mtxtAverageQuality.Name = "mtxtAverageQuality";
            mtxtAverageQuality.ReadOnly = true;
            // 
            // rdoCQ
            // 
            resources.ApplyResources(rdoCQ, "rdoCQ");
            rdoCQ.Name = "rdoCQ";
            rdoCQ.UseVisualStyleBackColor = true;
            // 
            // rdoABR
            // 
            resources.ApplyResources(rdoABR, "rdoABR");
            rdoABR.Name = "rdoABR";
            rdoABR.UseVisualStyleBackColor = true;
            // 
            // mtxtConstantQuality
            // 
            mtxtConstantQuality.BorderStyle = BorderStyle.None;
            resources.ApplyResources(mtxtConstantQuality, "mtxtConstantQuality");
            mtxtConstantQuality.Name = "mtxtConstantQuality";
            mtxtConstantQuality.ReadOnly = true;
            // 
            // rdoCRF
            // 
            resources.ApplyResources(rdoCRF, "rdoCRF");
            rdoCRF.Checked = true;
            rdoCRF.Name = "rdoCRF";
            rdoCRF.TabStop = true;
            rdoCRF.UseVisualStyleBackColor = true;
            // 
            // txtVideoBitrateInfo
            // 
            txtVideoBitrateInfo.BorderStyle = BorderStyle.None;
            resources.ApplyResources(txtVideoBitrateInfo, "txtVideoBitrateInfo");
            txtVideoBitrateInfo.Name = "txtVideoBitrateInfo";
            txtVideoBitrateInfo.ReadOnly = true;
            // 
            // textBox6
            // 
            textBox6.BorderStyle = BorderStyle.None;
            resources.ApplyResources(textBox6, "textBox6");
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            // 
            // grpAudioBitrate
            // 
            grpAudioBitrate.Controls.Add(textBox6);
            grpAudioBitrate.Controls.Add(txtAudioBitrate);
            resources.ApplyResources(grpAudioBitrate, "grpAudioBitrate");
            grpAudioBitrate.Name = "grpAudioBitrate";
            grpAudioBitrate.TabStop = false;
            // 
            // txtAudioBitrate
            // 
            resources.ApplyResources(txtAudioBitrate, "txtAudioBitrate");
            txtAudioBitrate.Name = "txtAudioBitrate";
            txtAudioBitrate.TextChanged += TextBox_Audio_Bitrate;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grpAudioBitrate);
            Controls.Add(grpVideoBitrateOption);
            Controls.Add(grpBitrateMode);
            Controls.Add(grpAudioCodec);
            Controls.Add(grpVideoCodec);
            Controls.Add(grpConvertTo);
            Controls.Add(btnStart);
            Controls.Add(richTextBox1);
            Controls.Add(txtFileInput);
            Controls.Add(chkDisableAudio);
            Controls.Add(btnSelectFile);
            Name = "Form1";
            Load += Form1_Load;
            grpConvertTo.ResumeLayout(false);
            grpConvertTo.PerformLayout();
            grpVideoCodec.ResumeLayout(false);
            grpAudioCodec.ResumeLayout(false);
            grpBitrateMode.ResumeLayout(false);
            grpBitrateMode.PerformLayout();
            grpVideoBitrateOption.ResumeLayout(false);
            grpVideoBitrateOption.PerformLayout();
            grpAudioBitrate.ResumeLayout(false);
            grpAudioBitrate.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFile;
        private OpenFileDialog openFileDialog1;
        private CheckBox chkDisableAudio;
        private TextBox txtFileInput;
        private RichTextBox richTextBox1;
        private Button btnStart;
        private RadioButton rdoWebm;
        private RadioButton rdoMP4;
        private GroupBox grpConvertTo;
        private GroupBox grpVideoCodec;
        private GroupBox grpAudioCodec;
        private GroupBox grpBitrateMode;
        private RadioButton rdoConstantBitrate;
        private RadioButton rdoVariableBitrate;
        private GroupBox grpVideoBitrateOption;
        private MaskedTextBox mtxtConstantQuality;
        private RadioButton rdoCRF;
        private TextBox mtxtConstrainedQuality;
        private TextBox mtxtAverageQuality;
        private RadioButton rdoCQ;
        private RadioButton rdoABR;
        private TextBox txtVideoBitrateInfo;
        private TextBox txtVideoBitrate;
        private ComboBox cmbVideoBitrateSuffix;
        private TextBox textBox6;
        private GroupBox grpAudioBitrate;
        private TextBox txtAudioBitrate;
        private ComboBox cmbVideoCodec;
        private ComboBox cmbAudioCodec;
    }
}