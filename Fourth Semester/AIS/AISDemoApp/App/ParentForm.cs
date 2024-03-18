namespace App
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();

        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            MainMenuStrip = new MenuStrip();
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = this;
            loginForm.Show();

        }
    }
}
