using System;
using System.Collections.Generic;
using ExpensesControlApp.Model;

using Xamarin.Forms;

namespace ExpensesControlApp
{
    public partial class ExpenseDetail : ContentPage
    {
        public ExpenseDetail()
        {
            InitializeComponent();
        }

        async void didTapDeleteExpense(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            await App.Database.DeleteExpenseAsync(expense);
            await Navigation.PopAsync();
        }
    }
}
