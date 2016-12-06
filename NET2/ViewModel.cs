using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET2
{
    class ViewModel:INotifyPropertyChanged
    {
        Subject selectedSubject; //с которым работаем в данный момент
        public ObservableCollection<Subject> Subjects { get; set;}
        public static string SearchedHours { get; set; }//параметр фильтра

        //добавление(реализовать!)
        public void Add()
        {
            return; 
        }
        //удаление(реализовать!)
        public void Remove()
        {
            return;
        }

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set {
                selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }

        public ViewModel()
        {
            Subjects = new ObservableCollection<Subject>
            {
                new Subject {Name="C#", Teacher="Иванов И.И.", Category=Subject.CategoryList[0], Hours=288, Description="Описание" },
                new Subject {Name="C++", Teacher="Петров П.П.",Category=Subject.CategoryList[0], Hours=144, Description="Описание" },
                new Subject {Name="Java", Teacher="Иванов И.И.",Category=Subject.CategoryList[0], Hours=72, Description="Описание" },
                new Subject {Name="Python", Teacher="Петров П.П.",Category=Subject.CategoryList[0], Hours=36, Description="Описание" },
                new Subject {Name="Матанализ", Teacher="Иванова И.Б.",Category=Subject.CategoryList[1], Hours=3000, Description="Описание" },
                new Subject {Name="Геометрия", Teacher="Сидорова С.С.",Category=Subject.CategoryList[1], Hours=400, Description="Описание" },
                new Subject {Name="Алгебра", Teacher="Сидоренко В.С.",Category=Subject.CategoryList[1], Hours=150, Description="Описание" },
                new Subject {Name="История", Teacher="Иваненко С.С.",Category=Subject.CategoryList[2], Hours=20, Description="Описание" },
                new Subject {Name="Экономика", Teacher="Петренко П.С.",Category=Subject.CategoryList[2], Hours=144, Description="Описание" },
                new Subject {Name="Физкультура", Teacher="Пупкин В.С.",Category=Subject.CategoryList[3], Hours=300, Description="Описание" },
                new Subject {Name="Курсовая", Teacher="Сидоров С.С.",Category=Subject.CategoryList[3], Hours=1, Description="Описание" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public enum HoursComparaion
        {
            Less=-1,
            Equal=0,
            More=1,
            NotDate=-2
        }

        HoursComparaion compareHours(string hour)
        {
            int value = 0;
            if (!int.TryParse(hour, out value))
                return HoursComparaion.NotDate;
            else if (value == selectedSubject.Hours)
                return HoursComparaion.Equal;
            else if (value > selectedSubject.Hours)
                return HoursComparaion.More;
            return HoursComparaion.Less;
        }

        public HoursComparaion HoursComparasion
        {
            get { return compareHours(SearchedHours); }
        }
    }
}
