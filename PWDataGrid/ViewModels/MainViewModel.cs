using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PWDataGrid.Models;
using Xamarin.Forms;

namespace PWDataGrid.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public List<GridColumn> Columns { get; set; }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                if (value != _selectedPerson)
                {
                    _selectedPerson = value;
                    RaisePropertyChanged(nameof(SelectedPerson));

                    ShowPersonDetails(_selectedPerson);
                }
            }
        }

        public Command ReorderColumnsCommand => new Command(ReorderColumns);

        public MainViewModel()
        {
            People = GetPeople();
            Columns = GetColumns();
        }

        public override void ReverseInit(object returnedData)
        {
            if (returnedData is ObservableCollection<GridColumn> returnedColumns)
            {
                Columns = returnedColumns.ToList();
                MessagingCenter.Send(this, MessageKeys.COLUMNS_REORDED);
            }
        }

        public ObservableCollection<Person> GetPeople()
        {
            return new ObservableCollection<Person>
            {
                new Person { FirstName = "Eliezer", LastName = "Sant Ana", FullName = "Eliezer Sant Ana", Age = 31, Gender = "Male", Nationality = "Brazilian", Nickname = "Shaft", SkinColor = "Brown" },
                new Person { FirstName = "Lewis", LastName = "Hamilton", FullName = "Lewis Hamilton", Age = 34, Gender = "Male", Nationality = "British", Nickname = "Lewis", SkinColor = "Black" },
                new Person { FirstName = "Ayrton", LastName = "Senna", FullName = "Ayrton Senna da Silva", Age = 33, Gender = "Male", Nationality = "Brazilian", Nickname = "Rain master", SkinColor = "White" },
                new Person { FirstName = "Michael", LastName = "Schumacher", FullName = "Michael Schumacher", Age = 50, Gender = "Male", Nationality = "German", Nickname = "Schumi", SkinColor = "White" },
                new Person { FirstName = "Alain", LastName = "Prost", FullName = "Alain Prost", Age = 53, Gender = "Male", Nationality = "French", Nickname = "Professor", SkinColor = "White" },
                new Person { FirstName = "Rubens", LastName = "Barrichello", FullName = "Rubens Barrichello", Age = 45, Gender = "Male", Nationality = "Brazilian", Nickname = "Rubinho", SkinColor = "White" },
            };
        }

        private List<GridColumn> GetColumns()
        {
            return new List<GridColumn>
            {
                new GridColumn{ IsVisible = true, Order = 0, Title = "First name", PropertyValue = "FirstName" },
                new GridColumn{ IsVisible = true, Order = 1, Title = "Last name", PropertyValue = "LastName" },
                new GridColumn{ IsVisible = true, Order = 2, Title = "Full name", PropertyValue = "FullName" },
                new GridColumn{ IsVisible = true, Order = 3, Title = "Nickname", PropertyValue = "Nickname" },
                new GridColumn{ IsVisible = true, Order = 4, Title = "Age", PropertyValue = "Age" },
                new GridColumn{ IsVisible = true, Order = 5, Title = "Gender", PropertyValue = "Gender" },
                new GridColumn{ IsVisible = true, Order = 6, Title = "Skin", PropertyValue = "SkinColor" },
                new GridColumn{ IsVisible = true, Order = 7, Title = "Nationality", PropertyValue = "Nationality" },

            };
        }

        void ShowPersonDetails(Person person)
        {
            if (person == null)
            {
                base.CoreMethods.DisplayAlert("Selected Item", "Nothing has been selected", "OK");
                return;
            }

            var message =
                $"First name: {person.FirstName}{Environment.NewLine}" +
                $"Age: {person.Age}{Environment.NewLine}" +
                $"Nick name: {person.Nickname}{Environment.NewLine}";
            base.CoreMethods.DisplayAlert("Selected Item", message, "OK");
        }
        
        void ReorderColumns()
        {
            CoreMethods.PushPageModel<ColumnsViewModel>(Columns);
        }

    }
}
