using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student student;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void clear()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }
        private void fillStudentInfo(Student student)
        {
            this.student = student;

            txtFirstName.Text = this.student.FirstName;
            txtSecondName.Text = this.student.SecondName;
            txtLastName.Text = this.student.LastName;
            txtFaculty.Text = this.student.FacultyName;
            txtSpeciality.Text = this.student.Speciality;
            txtDegree.Text = this.student.Degree;
            txtStatus.Text = this.student.Status;
            txtFacultyNumber.Text = this.student.FacultyNumber;
            txtCourse.Text = Convert.ToString(this.student.Course);
            txtFlow.Text = Convert.ToString(this.student.Flow);
            txtGroup.Text = Convert.ToString(this.student.Group);
        }
        private Boolean isStudentDataCorrect(Student student)
        {
            return student != null && !String.IsNullOrWhiteSpace(student.FirstName) &&
                !String.IsNullOrWhiteSpace(student.SecondName) && !String.IsNullOrWhiteSpace(student.LastName)
                && !String.IsNullOrWhiteSpace(student.FacultyName) && !String.IsNullOrWhiteSpace(student.Speciality) &&
                !String.IsNullOrWhiteSpace(student.Degree) && !String.IsNullOrWhiteSpace(student.Status) &&
                !String.IsNullOrWhiteSpace(student.FacultyNumber) && student.Course != 0
                && student.Flow != 0 && student.Group != 0;
        }
        private void setStudent(Student student)
        {
            if (isStudentDataCorrect(student))
            {
                enableControls();
                fillStudentInfo(student);
            }
            else
            {
                clear();
                disableControls();
            }

        }
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            StudentData data = new StudentData();
            setStudent(data.getStudents().First());
        }

        private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            setStudent(null);
        }
        private void disableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                if (ctr.Name == "btnUnlock" || ctr.Name == "btnTest")
                {
                    ctr.IsEnabled = true;
                }
                else
                {
                    ctr.IsEnabled = false;
                }
            }
        }

        private void enableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                ctr.IsEnabled = true;
            }
        }
        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            disableControls();
        }

        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            enableControls();
        }

    }
}
