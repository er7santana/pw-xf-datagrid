using System;
using PWDataGrid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWDataGrid
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Xamarin.Forms.DataGrid.DataGridComponent.Init();

            InitializeIoC();
            InitializeNavigation();
        }

        void InitializeIoC()
        {

        }

        void InitializeNavigation()
        {
            var mainPage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<MainViewModel>();
            var mainContainer = new FreshMvvm.FreshNavigationContainer(mainPage);

            MainPage = mainContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
