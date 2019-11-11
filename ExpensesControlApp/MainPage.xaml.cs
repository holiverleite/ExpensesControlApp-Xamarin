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
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var expenses = new List<Expense>();

            var e1 = new Expense(title:"Alimentação",description:"Praça de alimentação",amount:"R$200,00",date:new DateTime());
            var e2 = new Expense(title: "Carro", description: "Mecanica", amount: "R$100,00", date: new DateTime());
            var e3 = new Expense(title: "Transporte", description: "Onibus", amount: "R$20,00", date: new DateTime());
            var e4 = new Expense(title: "Estadia", description: "Aluguel", amount: "R$130,00", date: new DateTime());
            var e5 = new Expense(title: "Cinema", description: "Lazer", amount: "R$50,00", date: new DateTime());
            var e6 = new Expense(title: "Alimentação", description: "Praça de alimentação", amount: "R$240,50", date: new DateTime());

            expenses.Add(e1);
            expenses.Add(e2);
            expenses.Add(e3);
            expenses.Add(e4);
            expenses.Add(e5);
            expenses.Add(e6);

            listView.ItemsSource = expenses.ToList();
        }

        async void createExpenseClicked(object sender, EventArgs e)
        {

        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
