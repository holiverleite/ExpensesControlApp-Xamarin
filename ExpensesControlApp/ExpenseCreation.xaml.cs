using System;
using System.Collections.Generic;
using ExpensesControlApp.Model;

using Xamarin.Forms;

namespace ExpensesControlApp
{
    public partial class ExpenseCreation : ContentPage
    {
        public ExpenseCreation()
        {
            InitializeComponent();
        }

        async void DidTapCancelExpenseCreation(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void DidTapSaveButton(object sender, EventArgs e)
        {
            var expense = new Expense
            {
                expenseTitle = title.Text,
                expenseDescription = description.Text,
                expenseAmount = amount.Text,
                expenseDate = new DateTime().Date.ToString()
            };

            await App.Database.SaveExpenseAsync(expense);
            await Navigation.PopModalAsync();
        }
    }
}
