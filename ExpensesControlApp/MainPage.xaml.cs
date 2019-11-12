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

            //var e1 = new Expense
            //{
            //    expenseTitle = "Alimentacao",
            //    expenseDescription = "Alimentacao descricao",
            //    expenseAmount = "R$300,00",
            //    expenseDate = ""
            //}; 


            //expenses.Add(e1);

            //listView.ItemsSource = expenses.ToList();

            listView.ItemsSource = await App.Database.GetExpensesAsync();
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
