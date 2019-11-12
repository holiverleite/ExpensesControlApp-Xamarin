using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using ExpensesControlApp.Model;

namespace ExpensesControlApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static List<Expense> expenses;
        public MainPage()
        {
            InitializeComponent();
            expenses = new List<Expense>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetExpensesAsync();

            var amount = 0.0;
            foreach (Expense item in listView.ItemsSource)
            {
                try
                {
                    var floatValue = Math.Round(float.Parse(item.expenseAmount), 2);
                    amount = amount + floatValue;
                }
                catch
                {

                }             
            }

            total.Text = "R$ " + amount.ToString();
        }

        async void createExpenseClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseCreation
            {
                BindingContext = new Expense()
            });
        }

        async void didTapItemListView(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpenseDetail
                {
                    BindingContext = e.SelectedItem as Expense
                });
            }
        }
    }
}
