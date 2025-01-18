using System;
using System.Windows;
using NET_1MD;

namespace NET2MDversion5;

public partial class CreateData : ContentPage
{
	public CreateData()
	{
		InitializeComponent();
    }
	private schoolManager _schoolManager = App.schoolMan;

	private async void OnAddStudentClicked(object sender, EventArgs e)
    {
		try
		{
			string name = StudentName.Text;
            if (name == null)
            {
                await DisplayAlert("Error", "Please input student name", "Ok");
            }
            string surname = StudentSurname.Text;
            if (surname == null)
            {
                await DisplayAlert("Error", "Please input student surname", "Ok");
            }
            Person.GenderType gender = (Person.GenderType)Enum.Parse(typeof(Person.GenderType), StudentGender.SelectedItem.ToString()); //*
            if (StudentGender.SelectedItem == null)
            {
                await DisplayAlert("Error", "Please select a student gender", "Ok"); 
            }
            string studentIdNumber = StudentIDNumber.Text;
            if (studentIdNumber == null)
            {
                await DisplayAlert("Error", "Please input a student ID number", "Ok"); 
            }

            //var newStudent = new Student(name, surname, gender, studentIdNumber)
            App.schoolMan.addStudent(name, surname, gender, studentIdNumber);
            await DisplayAlert("Success", "Student added successfully", "Ok");

            await Navigation.PopAsync(); //view data
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error adding student: {ex.Message}", "Ok");
        }
    }
}