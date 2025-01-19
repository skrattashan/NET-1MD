namespace NET2MDversion5;

using NET_1MD;
using static System.Formats.Asn1.AsnWriter;
using System.Collections.ObjectModel;

public partial class CreateSubmission : ContentPage
{
	public CreateSubmission()
	{
		InitializeComponent();
        BindingContext = App.schoolMan.SchoolInfo;
    }



    //protected override void OnAppearing() //allowed to delete if no work pls
    //{
    //    base.OnAppearing();

    //    var students = App.schoolMan.getStudents();

    //    foreach (var student in students)
    //    {
    //        students.Add(student);
    //    }
    //    SubmissionStudent.ItemsSource = students;

        //SubmissionStudent.Items.Clear();

        //var students = App.schoolMan.getStudents();
        //foreach (var student in students)
        //{
        //    students.Add(student);
        //}
    //}

    private async void OnAddSubmissionClicked(object sender, EventArgs e)
    {
        try
        {
            var assignment = (Assignment)SubmissionAssignment.SelectedItem;
            if (assignment == null)
            {
                await DisplayAlert("Error", "Please select an assignment", "Ok");
                return;
            }

            var student = (Student)SubmissionStudent.SelectedItem;
            if (student == null)
            {
                await DisplayAlert("Error", "Please select a student", "Ok");
                return;
            }
            DateTime submissionTime = SubmissionTime.Date;
            int score = int.Parse(SubmissionScore.Text);
            if (int.TryParse(SubmissionScore.Text, out int result))
            {
                if (result < 0 || result > 10)
                {
                    await DisplayAlert("Error", "Score must be between 0 and 10", "Ok");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Error", "Score must be a number", "Ok");
                return;
            }

            App.schoolMan.addSubmission(assignment, student, submissionTime, score);
            await DisplayAlert("Success", "Submission added successfully", "Ok");
            await Navigation.PopAsync(); //view data
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error adding submission: {ex.Message}", "Ok");
        }
    }

    //NavigatedToEventArgs OnNavigatedTo(object sender, EventArgs e)
    //{
    //    var assignments = App.schoolMan.getAssignments();
    //    var students = App.schoolMan.getStudents();
    //    SubmissionAssignment.ItemsSource = assignments;
    //    SubmissionStudent.ItemsSource = students;
    //}
}