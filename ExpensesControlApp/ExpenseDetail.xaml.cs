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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var expense = (Expense)BindingContext;
            title.Text = expense.expenseTitle;
            description.Text = expense.expenseDescription;
            amount.Text = expense.expenseAmount;
        }

        async void didTapDeleteExpense(object sender, EventArgs e)
        {

            bool confirmCancel = await DisplayAlert("Atenção", "Realmente deseja deletar essa despesa?", "Sim", "Não");
            if (confirmCancel)
            {
                var expense = (Expense)BindingContext;
                await App.Database.DeleteExpenseAsync(expense);
                await Navigation.PopAsync();
            }
        }

        async void didTapEditExpense(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            await Navigation.PushModalAsync(new ExpenseCreation
            {
                BindingContext = expense
            });
        }
    }
}
