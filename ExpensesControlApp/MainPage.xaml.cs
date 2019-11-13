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
            listView.SeparatorColor = Color.White;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetExpensesAsync();

            var totalItems = listView.ItemsSource;

            var amount = 0.00;
            foreach (Expense item in listView.ItemsSource)
            {
                try
                {
                    var floatValue = float.Parse(item.expenseAmount);
                    amount = amount + floatValue;
                }
                catch
                {

                }             
            }

            bool containDecimalPart = amount.ToString().Contains(".");
            if (containDecimalPart)
            {
                var floatValue = Math.Round(float.Parse(amount.ToString()), 2);
                total.Text = "R$ " + floatValue.ToString();
            }
            else
            {
                total.Text = "R$ " + amount.ToString() + ".00";
            }
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
