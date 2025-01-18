using System;
using System.Windows;
using NET_1MD;

namespace NET2MDversion5;

public partial class ViewData : ContentPage
{

    public ViewData()
	{
		InitializeComponent();
    }

    private void OnPrintClicked(object sender, EventArgs e)
    {
        //izmantojam schoolManager metodi, lai izdrukatu datus
        dataDisplayLabel.Text = App.schoolMan.print();

        //foreach (var student in App.schoolMan.getStudents())
        //{
        //    dataDisplayLabel.Text += student.ToString() + Environment.NewLine;
        //}
    }
    private void OnCreateClicked(object sender, EventArgs e)
    {
        App.schoolMan.createTestData(); //izmantojam schoolManager metodi, lai izveidotu testa datus

        //dataDisplayLabel.Text = "";
        //foreach (var student in App.schoolMan.getStudents()) //WAIT THEY DONT LOVE YOU LIKE I LOVE YOU!! WIAT!! TT
        //{
        //    dataDisplayLabel.Text += student.ToString() + Environment.NewLine;
        //}
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        App.schoolMan.save(); 
    }
    private void OnLoadClicked(object sender, EventArgs e)
    {
        App.schoolMan.load();
        //DisplayStudents(); //tagad stradas ari pie load
    }

    //private void DisplayStudents() //hehhe
    //{
    //    dataDisplayLabel.Text = "";
    //    foreach (var student in App.schoolMan.getStudents())
    //    {
    //        dataDisplayLabel.Text += student.ToString() + Environment.NewLine;
    //    }
    //}

    private void OnRestartClicked(object sender, EventArgs e)
    {
        App.schoolMan.reset();
    }

    private void ContentPage_NavigatedTo(object sender, EventArgs e)
    {
        App.schoolMan.print();
    }
}