using vaccinecalend;

namespace App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using (var context = new VaccineCalendarContext())
            {
                LoginForm loginForm = new LoginForm();
                Application.Run(loginForm);

                if (loginForm.AuthenticatedUser != null)
                {
                    if(loginForm.AuthenticatedUser.UserRoles.Any(a => a.Role == "ADMIN"))
                    {
                        AdminForm adminForm = new AdminForm(loginForm.AuthenticatedUser);
                        Application.Run(adminForm);                       
                    }
                    else if (loginForm.AuthenticatedUser.UserRoles.Any(a => a.Role == "MED_PERSONAL"))
                    {
                        MedPersonalForm medPersonalForm = new MedPersonalForm(loginForm.AuthenticatedUser);
                        Application.Run(medPersonalForm);
                    }
                    else
                    {
                        UserForm userForm = new UserForm(loginForm.AuthenticatedUser);
                        Application.Run(userForm);
                    }   
                }
            }
        }
    }
}