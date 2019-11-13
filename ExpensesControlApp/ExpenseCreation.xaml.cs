using System;
using System.Collections.Generic;
using ExpensesControlApp.Model;
using System.Text.RegularExpressions;

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
            if (title.Text != null || description.Text != null || amount.Text != null)
            {
                bool confirmCancel = await DisplayAlert("Atenção", "Você perderá seus dados ao cancelar. Cancelar mesmo assim?", "Sim","Não");
                if (confirmCancel)
                {
                    await Navigation.PopModalAsync();
                }
            } else
            {
                await Navigation.PopModalAsync();
            }
            
        }

        async void DidTapSaveButton(object sender, EventArgs e)
        {

            var emailPattern = @"^([0-9]+).([0-9]+)([0-9])$";
            
            if (title.Text == null || description.Text == null || amount.Text == null)
            {
                await DisplayAlert("Atenção", "Todos os campos precisam ser preenchidos!", "OK");
            }
            else if (!Regex.IsMatch(amount.Text, emailPattern))
            {
                await DisplayAlert("Atenção", "No campo do valor entre com um valor seguindo o formato 0.00. Não se esqueça de incluir o \'.' separando a parte inteira dos centavos.", "OK");
            }
            else
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
}
