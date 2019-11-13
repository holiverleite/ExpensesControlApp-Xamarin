using System;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var expense = (Expense)BindingContext;
            if (expense.ID != 0)
            {
                SaveOrUpdateButton.Text = "Atualizar";
            }
        }

        async void DidTapCancelExpenseCreation(object sender, EventArgs e)
        {
            if (BindingContext != null)
            {
                await Navigation.PopModalAsync();
            } else
            {
                if (title.Text != null || description.Text != null || amount.Text != null)
                {
                    bool confirmCancel = await DisplayAlert("Atenção", "Você perderá seus dados ao cancelar. Cancelar mesmo assim?", "Sim", "Não");
                    if (confirmCancel)
                    {
                        await Navigation.PopModalAsync();
                    }
                }
                else
                {
                    await Navigation.PopModalAsync();
                }
            }
        }

        async void DidTapSaveOrUpdateButton(object sender, EventArgs e)
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
                var currentTime = DateTime.Now.ToString();

                var expense = (Expense)BindingContext;
                if (expense.ID != 0)
                {
                    await App.Database.SaveExpenseAsync(expense);
                } else
                {
                    var exp = new Expense
                    {
                        expenseTitle = title.Text,
                        expenseDescription = description.Text,
                        expenseAmount = amount.Text,
                        expenseDate = currentTime
                    };

                    await App.Database.SaveExpenseAsync(exp);
                }
                await Navigation.PopModalAsync();
            }
        }
    }
}
