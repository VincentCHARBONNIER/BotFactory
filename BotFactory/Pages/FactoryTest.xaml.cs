
using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Factories;
using BotFactory.Models;
using BotFactory.Tools;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace BotFactory.Pages
{
    /// <summary>
    /// Interaction logic for FactoryTest.xaml
    /// </summary>
    public partial class FactoryTest : Page
    {
        FactoryDataContext _dataContext = new FactoryDataContext();
        UnitTest _unitTestPage;

        public FactoryTest()
        {
            InitializeComponent();
            ModelsRobots.SelectedIndex = 0;
            DataContext = _dataContext;
        }

        public void SetTestingFactory(UnitFactory factory)
        {
            _dataContext.Builder = factory;
            _dataContext.Builder.FactoryProgress += Builder_FactoryProgress;
        }

        private void Builder_FactoryProgress(object sender, System.EventArgs e)
        {
            _dataContext.ForceUpdate();
        }

        private void AddUnitToQueue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (ModelsList.SelectedIndex >= 0 && !string.IsNullOrEmpty(UnitName.Text))
            if (ModelsRobots.SelectedIndex >= 0 && !string.IsNullOrEmpty(UnitName.Text))
            {
                //Type item = (Type)ModelsList.SelectedItem;
                Type item = (Type)ModelsRobots.SelectedItem;
                WorkingUnit instance = (WorkingUnit)Activator.CreateInstance(item);
                MessageBoxResult result = MessageBox.Show("Vous avez choisi de construire le robot " + instance.Name + " qui a pour temps de construction " + instance.BuildTime + " . Etes-vous sûr de vouloir construire ce robot ?", "BotFactory", MessageBoxButton.YesNo);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        return;
                }

                _dataContext.Builder.AddWorkableUnitToQueue(item, UnitName.Text, new Coordinates(0, 0), new Coordinates(10, 10));
                _dataContext.ForceUpdate();

                // Update Storage and Queue ItemsSources.
                StorageList.Items.Refresh();
                QueueList.Items.Refresh();

                // Reset ComboBox.
                ModelsRobots.SelectedIndex = 0;
            }
        }
        private void UpdateButtonValidity()
        {
            //AddUnitToQueue.IsEnabled = (ModelsRobots.SelectedIndex >= 0) && !string.IsNullOrEmpty(UnitName.Text);
            AddUnitToQueue.IsEnabled = ModelsRobots.SelectedIndex >= 0 && !string.IsNullOrEmpty(UnitName.Text);
        }

        private void UnitName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateButtonValidity();
        }

        private void ModelsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonValidity();
        }

        private void ModelsRobots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonValidity();
        }

        private void StorageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StorageList.SelectedIndex >= 0)
            {
                if (_unitTestPage == null)
                {
                    _unitTestPage = new UnitTest();
                    _unitTestPage.SetUnitToTest((ITestingUnit)StorageList.SelectedItem);
                    UnitFrame.Navigate(_unitTestPage);
                }
                else
                {
                    _unitTestPage.SetUnitToTest((ITestingUnit)StorageList.SelectedItem);
                }
            }
        }
    }
}
