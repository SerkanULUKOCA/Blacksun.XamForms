using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms.Helpers;
using Xamarin.Forms;

namespace BlacksunForms.CustomControls
{
    public class BlacksunFormsPicker : Picker
    {

        public BlacksunFormsPicker()
        {
            this.SelectedIndexChanged += BlacksunFormsPicker_SelectedIndexChanged;
        }

        void BlacksunFormsPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = SelectedIndex;

            if (index < 0)
            {
                return;
            }

            if (index < ItemsSource.Count())
            {
                SelectedItem = ItemsSource.ElementAt(index);

                var displayValue = SelectedItem.GetPropertyValueIfExists(SelectedValueMemberPath).ToString();

                SelectedValue = displayValue;
            }
            else
            {
                SelectedItem = null;
            }


        }


        public static readonly BindableProperty SelectedValueProperty = BindableProperty.Create<BlacksunFormsPicker, object>(p => p.SelectedValue,null);

        private IEnumerable<object> _itemsSource;
        public IEnumerable<object> ItemsSource
        {
            get { return _itemsSource; }
            set
            {
                _itemsSource = value;
                OnPropertyChanged();
                ProcessSource();
            }
        }

        private object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public object SelectedValue
        {
            get { return GetValue(SelectedValueProperty); }
            set
            {
                SetValue(SelectedValueProperty, value);
                OnPropertyChanged();
            }
        }

        

        private string _displayMemberPath = "";
        public string DisplayMemberPath
        {
            get { return _displayMemberPath; }
            set
            {
                _displayMemberPath = value;
                OnPropertyChanged();
            }
        }

        private string _selectedValueMemberPath = "";
        public string SelectedValueMemberPath
        {
            get { return _selectedValueMemberPath; }
            set
            {
                _selectedValueMemberPath = value;
                OnPropertyChanged();
            }
        }

        private void ProcessSource()
        {

            Items.Clear();

            if(ItemsSource == null)
                return;

            
            foreach (var item in ItemsSource)
            {
                var displayValue = item.GetPropertyValueIfExists(DisplayMemberPath,"").ToString();
                Items.Add(displayValue);
            }

        }




    }
}
