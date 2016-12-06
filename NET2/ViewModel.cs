using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NET2
{
    class ViewModel:INotifyPropertyChanged
    {
        Subject selectedSubject; //с которым работаем в данный момент
        public static ObservableCollection<Subject> Subjects { get; set;}
        public ListCollectionView col { get; set; } // для группировки
        int searchedMinHours; //для фильтрации
        int searchedMaxHours;

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
            col = new ListCollectionView(Subjects);
            col.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            selectedSubject = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        void compareHours(int hour1, int hour2)
        {
            foreach (Subject subj in Subjects)
            {
                if (hour2 < hour1 || ( hour2 <= 0 && hour1 <= 0))
                    subj.Comparasion= Subject.HoursComparaion.Incorrect;
                else if (subj.Hours < hour1)
                        subj.Comparasion = Subject.HoursComparaion.Less;
                    else if (subj.Hours >= hour1 && subj.Hours <= hour2)
                        subj.Comparasion = Subject.HoursComparaion.In;
                        else
                            subj.Comparasion = Subject.HoursComparaion.More;
            }

        }

        /// <summary>
        /// Пересчет диапазонов часов при изменении фильтра
        /// </summary>
        public  int SearchedMinHours
        {
            get { return searchedMinHours; }
            set
            {
                searchedMinHours = value;
                compareHours(searchedMinHours, searchedMaxHours);
            }
        }
        public int SearchedMaxHours
        {
            get { return searchedMaxHours; }
            set
            {
                searchedMaxHours = value;
                compareHours(searchedMinHours, searchedMaxHours);
            }
        }

        /// <summary>
        /// Для корректного отображения панели редактирования
        /// </summary>
        Visibility IsRedactPanelVisible
        {
            get
            {
                if (selectedSubject != null)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }
    }
}
