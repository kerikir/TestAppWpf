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

namespace TestAppWpf
{
    /// <summary>
    /// Логика взаимодействия для TestLifeQuality.xaml
    /// </summary>
    public partial class TestLifeQuality : Page
    {
        int testResult = 0;

        public TestLifeQuality()
        {
            InitializeComponent();
        }

        public void buttonMainMenu_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void button_CalculateResult(object sender, System.EventArgs e)
        {
            ReadDataPicker();
            if (AnswersAllQuestions())
            {
                CalculateResult();
                MessageBox.Show($"Ваше количество баллов = {App.patient.resultLifeQuality.TotalResultLifeQuality}", "Результат", MessageBoxButton.OK);
                testResult = 0;
                ResetAnswersInTest();
                NavigationService.Navigate(new Menu());

            }
            //пациент ответил не на все вопросы
            else
            {
                MessageBox.Show("Введены не все данные", "Предупреждение", MessageBoxButton.OK);
            }
        }
        private void ResetAnswersInTest()
        {
            firstQuestion.SelectedIndex = -1;
            secondQuestion.SelectedIndex = -1;
            thirdQuestion.SelectedIndex = -1;
            fourthQuestion.SelectedIndex = -1;
            fifthQuestion.SelectedIndex = -1;
            sixthQuestion.SelectedIndex = -1;
        }

        /// <summary>
        /// Считывание ответов из выпадающих списков
        /// </summary>
        private void ReadDataPicker()
        {
            App.patient.resultLifeQuality.arrayAnswerLifeQuality[0] = firstQuestion.SelectedIndex;
            App.patient.resultLifeQuality.arrayAnswerLifeQuality[1] = secondQuestion.SelectedIndex;
            App.patient.resultLifeQuality.arrayAnswerLifeQuality[2] = thirdQuestion.SelectedIndex;
            App.patient.resultLifeQuality.arrayAnswerLifeQuality[3] = fourthQuestion.SelectedIndex;
            App.patient.resultLifeQuality.arrayAnswerLifeQuality[4] = fifthQuestion.SelectedIndex;
            App.patient.resultLifeQuality.arrayAnswerLifeQuality[5] = sixthQuestion.SelectedIndex;
        }

        /// <summary>
        /// Проверка на все ли вопросы ответил пациент
        /// </summary>
        /// <returns></returns>
        private bool AnswersAllQuestions()
        {

            for (int i = 0; i < 6; i++)
            {
                if (App.patient.resultLifeQuality.arrayAnswerLifeQuality[i] == -1)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Определение количества баллов за тест
        /// </summary>
        private void CalculateResult()
        {
            for (int i = 0; i < 6; i++)
            {
                testResult += App.patient.resultLifeQuality.arrayAnswerLifeQuality[i];
            }
            App.patient.resultLifeQuality.TotalResultLifeQuality = testResult;
        }
    }
}
