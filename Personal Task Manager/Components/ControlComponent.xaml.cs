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

namespace Personal_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for ControlComponent.xaml
    /// </summary>
    public partial class ControlComponent : UserControl
    {

        public ControlComponent()
        {
            InitializeComponent();
        }


        private void btnAdd_New_Task(object sender, RoutedEventArgs e)
        {
            AddNewTask addNewTask = new AddNewTask();
            addNewTask.ShowDialog();
        }
    }
}