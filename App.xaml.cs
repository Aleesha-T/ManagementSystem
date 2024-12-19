using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ManagementSystem.ViewModel;

namespace ManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);    
            View.Login login = new View.Login();
            LoginViewModel viewModel = new LoginViewModel();
            login.DataContext = viewModel;
            login.Show();
        }
    }
}
