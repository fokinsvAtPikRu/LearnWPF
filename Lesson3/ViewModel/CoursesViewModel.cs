using Lesson3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Lesson3.ViewModel
{
    internal class CoursesViewModel : INotifyPropertyChanged
    {
        #region
        public ICommand JoinCourseCommand { get; }

        private bool NotifyCanExecuteChanged()
        {
            if (!string.IsNullOrWhiteSpace(StudentName) &&
                FacultySelected >= 0 &&
                CourseSelected != null &&
                ConsentDataProcessing)
                return true;
            return false;
        }

        private void Execute()
        {
            MessageBox.Show($"Студент: {StudentName}\nФакультет: {FacultySelected}\nКурс: {CourseSelected}", "Данные отправлены");
        }
        private bool CanExecute()
        {
            if (!string.IsNullOrWhiteSpace(StudentName) &&
                FacultySelected >= 0 &&
                CourseSelected != null &&
                ConsentDataProcessing)
                return true;
            return false;
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _studentName;
        public string StudentName
        {
            get => _studentName;
            set
            {
                _studentName = value;
                OnPropertyChanged();
                ((RelayCommand)JoinCourseCommand).NotifyCanExecuteChanged();
            }
        }
        private int _facultySelected;
        public int FacultySelected
        {
            get => _facultySelected;
            set
            {
                _facultySelected = value;
                OnPropertyChanged();
                UpdateCourses();
                ((RelayCommand)JoinCourseCommand).NotifyCanExecuteChanged();
            }
        }
        
        private Course _courseSelected;
        public Course CourseSelected
        {
            get => _courseSelected;
            set
            {
                _courseSelected = value;
                OnPropertyChanged();
                ((RelayCommand)JoinCourseCommand).NotifyCanExecuteChanged();
            }
        }
        private ICollectionView _itemsFaculty;
        public ICollectionView ItemsFaculty
        {
            get => _itemsFaculty;
            set
            {
                _itemsFaculty = value;
                OnPropertyChanged();
                ((RelayCommand)JoinCourseCommand).NotifyCanExecuteChanged();
            }
        }
        private ICollectionView _itemsCourses;
        public ICollectionView ItemsCourses
        {
            get => _itemsCourses;
            set
            {
                _itemsCourses = value;
                OnPropertyChanged();
                ((RelayCommand)JoinCourseCommand).NotifyCanExecuteChanged();
            }
        }
        private bool _consentDataProcessing;
        public bool ConsentDataProcessing
        {
            get => _consentDataProcessing;
            set
            {
                _consentDataProcessing = value;
                OnPropertyChanged();
                ((RelayCommand)JoinCourseCommand).NotifyCanExecuteChanged();
            }
        }

        public CoursesViewModel()
        {
            JoinCourseCommand = new RelayCommand(Execute, CanExecute);
            ItemsFaculty = CollectionViewSource.GetDefaultView(FaculityCourses.GetFaculty());
            ItemsCourses = CollectionViewSource.GetDefaultView(FaculityCourses.GetCourses(0));            
        }

        private void UpdateCourses()
        {
            ItemsCourses = FacultySelected >= 0
                ? CollectionViewSource.GetDefaultView(FaculityCourses.GetCourses(FacultySelected))
                : null;
            OnPropertyChanged(nameof(ItemsCourses));
        }
    }
}
