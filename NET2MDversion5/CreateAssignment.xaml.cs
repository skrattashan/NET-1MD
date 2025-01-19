namespace NET2MDversion5;
using NET_1MD;

public partial class CreateAssignment : ContentPage
{
	public CreateAssignment()
	{
		InitializeComponent();
        BindingContext = App.schoolMan.SchoolInfo;
    }

    private async void OnAddAssignmentClicked(object sender, EventArgs e)
    {
		try
		{
            //TimeSpan selectedTime = AssignmentTime.Time
            DateTime deadline = AssignmentDate.Date;
            var course = (Course)AssignmentCourse.SelectedItem;

            if (course == null)
            {
                await DisplayAlert("Error", "Please select a course", "Ok");
                return;
            }

            TeacherLabel.Text = $"Teacher: {course.Teacher.ToString()}";

            string description = AssignmentDescription.Text;

            if (string.IsNullOrWhiteSpace(description))
            {
                await DisplayAlert("Error", "Please enter a description", "Ok");
                return;
            }

            App.schoolMan.addAssignment(deadline, course, description);
            await DisplayAlert("Success", "Assignment added successfully", "Ok");

            await Navigation.PopAsync(); //view data
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error adding assignment: {ex.Message}", "Ok");
        }

    }
}