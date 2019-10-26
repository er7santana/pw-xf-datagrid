using System;
using System.ComponentModel;
using System.Linq;
using PWDataGrid.ViewModels;
using Xamarin.Forms;

namespace PWDataGrid.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<MainViewModel>(this, MessageKeys.COLUMNS_REORDED, vm => RefreshLayout(vm));
        }

        void RefreshLayout(MainViewModel vm)
        {
            mainScrollView.Content = null;

            myDataGrid.Columns.Clear();

            var columns = vm.Columns.OrderBy(c => c.Order).ToList();

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].IsVisible)
                {
                    myDataGrid.Columns.Add(new Xamarin.Forms.DataGrid.DataGridColumn
                    {
                        Title = columns[i].Title,
                        PropertyName = columns[i].PropertyValue,
                        Width = 100.0
                    });
                }
            }

            mainScrollView.Content = myDataGrid;
        }
    }
}
