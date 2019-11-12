﻿using System;
namespace ExpensesControlApp.Model
{
    public class Expense
    {

        public Expense(){}

        public Expense(String title, String description, String amount, string date)
        {
            this.expenseTitle = title;
            this.expenseDescription = description;
            this.expenseAmount = amount;
            this.expenseDate = date;
        }

        public string expenseTitle { get; set; }
        public string expenseDescription { get; set; }
        public string expenseAmount { get; set; }
        public string expenseDate { get; set; }
    }
}
