using System;
using SQLite;

namespace ExpensesControlApp.Model
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string expenseTitle { get; set; }
        public string expenseDescription { get; set; }
        public string expenseAmount { get; set; }
        public string expenseDate { get; set; }
    }
}
