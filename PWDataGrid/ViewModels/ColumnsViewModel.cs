using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PWDataGrid.Models;
using Xamarin.Forms;

namespace PWDataGrid.ViewModels
{
    public class ColumnsViewModel : BaseViewModel
    {
        public Command SaveCommand => new Command(Save);

        public ObservableCollection<GridColumn> Columns { get; set; }

        public ColumnsViewModel()
        {
            Columns = new ObservableCollection<GridColumn>();
        }

        public override void Init(object initData)
        {
            if (initData is List<GridColumn> initialColumns)
            {
                Columns = initialColumns.ToObservableCollection();
            }
        }

        void Save()
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                Columns[i].Order = i;
            }

            CoreMethods.PopPageModel(Columns);
        }
    }
}
