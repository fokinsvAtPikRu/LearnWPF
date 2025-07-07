using Lesson3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Lesson3.ViewModel
{
    internal class CoursesViewModel : DependencyObject
    {


        public string StudentName
        {
            get { return (string)GetValue(StudentNameProperty); }
            set { SetValue(StudentNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StudentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StudentNameProperty =
            DependencyProperty.Register("StudentName", typeof(string), typeof(CoursesViewModel), new PropertyMetadata(""));


        public int FacultySelected
        {
            get { return (int)GetValue(FacultySelectedProperty); }
            set { SetValue(FacultySelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FacultySelectedProperty =
            DependencyProperty.Register("FacultySelected", typeof(int), typeof(CoursesViewModel), new PropertyMetadata(-1, OnFacultySelectedChanged));

        private static void OnFacultySelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var vm= (CoursesViewModel)d;
            vm.UpdateCorses();
        }

        private void UpdateCorses()
        {
            if (FacultySelected > -1)
            {
                ItemsCourses = CollectionViewSource.GetDefaultView(FaculityCourses.GetCourses(FacultySelected));
            }
            else
                ItemsCourses = null;
        }

        public Course CourseSelected
        {
            get { return (Course)GetValue(CourseSelectedProperty); }
            set { SetValue(CourseSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CourseSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CourseSelectedProperty =
            DependencyProperty.Register("CourseSelected", typeof(Course), typeof(CoursesViewModel), new PropertyMetadata(null));



        public ICollectionView ItemsFaculty
        {
            get { return (ICollectionView)GetValue(ItemsFacultyProperty); }
            set { SetValue(ItemsFacultyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsFacultyProperty =
            DependencyProperty.Register("ItemsFaculty", typeof(ICollectionView), typeof(CoursesViewModel), new PropertyMetadata(null));



        public ICollectionView ItemsCourses
        {
            get { return (ICollectionView)GetValue(ItemsCoursesProperty); }
            set { SetValue(ItemsCoursesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsCourses.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsCoursesProperty =
            DependencyProperty.Register("ItemsCourses", typeof(ICollectionView), typeof(CoursesViewModel), new PropertyMetadata(null));



        public bool ConsentDataProcessing
        {
            get { return (bool)GetValue(ConsentDataProcessingProperty); }
            set { SetValue(ConsentDataProcessingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConsentDataProcessing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConsentDataProcessingProperty =
            DependencyProperty.Register("ConsentDataProcessing", typeof(bool), typeof(CoursesViewModel), new PropertyMetadata(true));



        public CoursesViewModel()
        {            
            ItemsFaculty = CollectionViewSource.GetDefaultView(FaculityCourses.GetFaculty());
            ItemsCourses = null;           
        }
    }
}
