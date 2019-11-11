using System;
using System.Collections.Generic;

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
    }
}
