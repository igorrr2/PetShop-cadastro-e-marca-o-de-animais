using Util.Criptografia;

namespace ConverterGuidShortGuid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Guid teste = Guid.NewGuid();
        }

        private void ConverterButton_Click(object sender, EventArgs e)
        {
            if (GuidTextBox.Text != "")
            {
                Guid.TryParse(GuidTextBox.Text, out Guid guid);
                if (guid != Guid.Empty)
                {
                    ShortGuid shortGuid = guid;
                    ShortGuidTextBox.Text = shortGuid.ToString();
                }
            }
            else if (ShortGuidTextBox.Text != "")
            {
                ShortGuid shortGuid = new ShortGuid(ShortGuidTextBox.Text);
                if (shortGuid != null)
                {
                    Guid guid = shortGuid;
                    GuidTextBox.Text = guid.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SenhaTextBox.Text == "" || ChaveCriptografiaTextBox.Text == "")
                return;

            Guid chaveCriptografia = new Guid(ChaveCriptografiaTextBox.Text);
            Criptografia.Criptografar(SenhaTextBox.Text, chaveCriptografia, out string senhaCriptografada);
            SenhaCriptografadaTextBox.Text = senhaCriptografada;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SenhaCriptografadaTextBox.Text == "" || ChaveCriptografiaTextBox.Text == "")
                return;

            Guid chaveCriptografia = new Guid(ChaveCriptografiaTextBox.Text);
            Criptografia.Descriptografar(SenhaCriptografadaTextBox.Text, chaveCriptografia, out string senhaDescriptografada);
            SenhaTextBox.Text = senhaDescriptografada;
        }
    }
}