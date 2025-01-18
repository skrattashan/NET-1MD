namespace NET2MDversion5;
using NET_1MD;
public partial class EditAssignment : ContentPage
{
	public EditAssignment()
	{
		InitializeComponent();
	}

	private async void OnEditAssignmentClicked(object sender, EventArgs e)
	{
		try
		{
            // Use the editAssignment method to update assignment data
            var assignment = (Assignment)BindingContext;
            var deadline = AssignmentDate.Date;
            var course = (Course)AssignmentCourse.SelectedItem;
            var description = AssignmentDescription.Text;

            App.schoolMan.editAssignment(assignment, deadline, course, description);
            await DisplayAlert("Success", "Assignment updated successfully", "Ok");
            await Navigation.PopAsync(); // Navigate back
        }
		catch (Exception ex)
		{
			await DisplayAlert("Error", $"Error editing assignment: {ex.Message}", "Ok");
		}
	}
}