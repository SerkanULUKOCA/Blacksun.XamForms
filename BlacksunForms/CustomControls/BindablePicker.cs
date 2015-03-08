using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BlacksunForms.Helpers;
using Xamarin.Forms;

namespace Blacksun.XamForms.CustomControls
{
    public class BindablePicker : Picker
    {

        public static BindableProperty ItemsSourceProperty = BindableProperty.Create<BindablePicker, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);
        public static BindableProperty SelectedItemProperty = BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object), propertyChanged: OnSelectedItemChanged);
        public static BindableProperty SelectedValueProperty = BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object), propertyChanged: OnValueChanged);

        public BindablePicker()
        {
            this.SelectedIndexChanged += BlacksunFormsPicker_SelectedIndexChanged;
        }

        private static void OnValueChanged(BindableObject bindable, object oldvalue, object newvalue)
        {

            var picker = bindable as BindablePicker;

            if (picker.ItemsSource == null)
                return;

            picker.ProcessSelectedValue();


        }

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var picker = bindable as BindablePicker;

            picker.Items.Clear();

            if (picker.ItemsSource == null)
                return;


            foreach (var item in picker.ItemsSource)
            {
                var displayValue = item.GetPropertyValueIfExists(picker.DisplayMemberPath, "").ToString();
                picker.Items.Add(displayValue);
            }

            if (picker.SelectedValue != null)
            {
                picker.SetSelectedItem();
            }


        }

        private void SetSelectedItem()
        {
            if(ItemsSource == null)
                return;

            if (SelectedItem == null)
            {

                try
                {
                    foreach (var item in ItemsSource)
                    {
                        var value = item.GetPropertyValue(SelectedValueMemberPath);

                        if (value.Equals(SelectedValue))
                        {
                            SelectedItem = item;
                            break;
                        }
                    }

                }
                catch (Exception)
                {

                }

            }
            else
            {
                ProcessSelectedItem();
            }

            

            
        }

        private void ProcessSelectedValue()
        {
            try
            {
                foreach (var item in ItemsSource)
                {
                    var selectedValue = item.GetPropertyValueIfExists(SelectedValueMemberPath, "");

                    if (selectedValue.Equals(SelectedValue))
                    {
                        SelectedItem = item;
                        break;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ProcessSelectedItem()
        {
            if (SelectedItem != null)
            {
                if (SelectedIndex != -1 && Items[SelectedIndex].Equals(SelectedItem.GetPropertyValue(DisplayMemberPath)))
                {

                }
                else
                {
                    SelectedIndex = Items.IndexOf(SelectedItem.GetPropertyValue(DisplayMemberPath).ToString());
                }
            }
        }


        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {

            if (oldvalue != null && oldvalue.Equals(newvalue))
            {
                return;
            }

            var picker = bindable as BindablePicker;
            picker.ProcessSelectedItem();
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

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
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
