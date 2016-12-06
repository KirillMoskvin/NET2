using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace NET2
{
    class Subject:INotifyPropertyChanged
    {
        string name;//название
        string teacher;//преводаватель
        int hours; //количество часов
        string description;//описание
        string category;
        static ObservableCollection<string> categoryList = new ObservableCollection<string>
            { "Программирование", "Математика", "Гуманитарное", "Другое"};


        public event PropertyChangedEventHandler PropertyChanged;

        //свойства для реализации биндинга
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string Teacher
        {
            get { return teacher; }
            set
            {
                teacher = value;
                OnPropertyChanged("Teacher");
            }
        }
        public int Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                OnPropertyChanged("Hours");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
        public static ObservableCollection<string> CategoryList
        {
            get { return categoryList; }
            set
            {
                categoryList = value;
            }
        }
    }
}
