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
