namespace PetShop
{
    partial class LoadingForm
    {
        private Label lblMensagem;
        private ProgressBar progressBar;

        private void InitializeComponent()
        {
            lblMensagem = new Label();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // lblMensagem
            // 
            lblMensagem.AutoSize = true;
            lblMensagem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMensagem.Location = new Point(30, 20);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(90, 19);
            lblMensagem.TabIndex = 1;
            lblMensagem.Text = "Carregando...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 50);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(379, 15);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(424, 90);
            ControlBox = false;
            Controls.Add(progressBar);
            Controls.Add(lblMensagem);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoadingForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aguarde...";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
