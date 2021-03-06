﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Office2013CustomActionsLib;
using System.IO.Packaging;
//Using Document
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Text.RegularExpressions;



namespace AnalisatorPrices
{
    public partial class MainWindow : System.Windows.Window
    {


        // Инициазация переменных
        public string textTov;
        public string textPrice;
        public string textTown;
      //  public event EventHandler SelectionChangeCommitted;
       


        public MainWindow()
        {
            InitializeComponent();
            this.prices.PreviewTextInput += new TextCompositionEventHandler(OnlyNumberInput);
           // this.tovSelect.Selected += new EventHandler(this.tovSelect_SelectChanged);
            //Массив









        }


        //Work For File
        private void CreateExcelDocument(object fileName, object saveAs)
        {
    
        }



        /*
         * Метод добавления текста 
        */
        ObservableCollection<SimpleDataBase> sdb = null;
        private void addText_Click(object sender, RoutedEventArgs e)
        {
            if (tov != null && prices != null && town != null)
            {
                
                //Запись товара
                textTov = tov.Text;

                if (textTov == "" || textTov == " " || textTov == "  " || textTov == "   " || textTov == "    " || textTov == "      ")
                {

                }
                else { tovSelect.Items.Add(textTov); }


                //Запись Цены

                textPrice = prices.Text;
                pr.Text = textPrice;

                //Запись Города

                textTown = town.Text;
                town1.Text = textTown;

                

                List<SimpleDataBase> r = new List<SimpleDataBase>(3);


                r.Add(new SimpleDataBase(textTov, textPrice, textTown));
               
                
                dataBase.ItemsSource = r;
                dataBase.Items.Refresh();
                
               


            }
        }

        /*
         * Метод открытия файла
         */

        private void openFileDialog_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";


            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {

                string filename = dlg.FileName;
                debug.Text = File.ReadAllText(filename);
            }


        }




        /*
         * Защита от дурака
         * onKeyDown_pr и onKeyDown_Town - запрет написания любых символов в ручную
         * OnlyNumberInput - запрет написания букв
         */
        private void onKeyDown_pr(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            pr.IsReadOnly = true;
            // pr.IsEnabled = false;


        }


        private void onKeyDown_Town(object sender, KeyEventArgs k)
        {
            k.Handled = true;
            town1.IsReadOnly = true;
            //town1.IsEnabled = false;
        }
        private Regex regex = new Regex("[^0-9\\-]+");

        public object ComboBoxStyle { get; }

        private void OnlyNumberInput(object sender, TextCompositionEventArgs g)
        {
            g.Handled = regex.IsMatch(g.Text);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            tovSelect.Items.Remove(tovSelect.SelectedItem);
            pr.Clear();
            town1.Clear();
        }





        private void tovSelect_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void dataBase_Loaded(object sender, RoutedEventArgs e)
        {
            List<SimpleDataBase> r = new List<SimpleDataBase>(3);


            r.Add(new SimpleDataBase(textTov,textPrice,textTown));

            dataBase.ItemsSource = r;
        }

        
    }
    
}


