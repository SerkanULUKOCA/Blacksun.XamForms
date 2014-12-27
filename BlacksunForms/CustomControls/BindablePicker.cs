using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms.Helpers;
using Xamarin.Forms;

namespace BlacksunForms.CustomControls
{
    public class BindablePicker : Picker
    {

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindablePicker, IEnumerable<object>>(o => o.ItemsSource, default(IEnumerable<object>), propertyChanged: OnItemsSourceChanged);
        public static BindableProperty SelectedItemProperty = BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object), propertyChanged: OnSelectedItemChanged);


        public BindablePicker()
        {
            this.SelectedIndexChanged += BlacksunFormsPicker_SelectedIndexChanged;
        }

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var picker = bindable as BindablePicker;
            /*
            picker.Items.Clear();
            if (newvalue != null)
            {
                //now it works like "subscribe once" but you can improve
                foreach (var item in newvalue)
                {
                    picker.Items.Add(item.ToString());
                }
            }
            */

            picker.Items.Clear();

            if (picker.ItemsSource == null)
                return;


            foreach (var item in picker.ItemsSource)
            {
                var displayValue = item.GetPropertyValueIfExists(picker.DisplayMemberPath, "").ToString();
                picker.Items.Add(displayValue);
            }

        }

        /*
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = Items[SelectedIndex];
            }
        }
        */

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as BindablePicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
            }
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


        public static readonly BindableProperty SelectedValueProperty = BindableProperty.Create<BindablePicker, object>(p => p.SelectedValue,null);

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
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
