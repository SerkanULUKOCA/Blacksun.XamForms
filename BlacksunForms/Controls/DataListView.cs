using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public class DataListView : ListView
    {
        public static BindableProperty ItemClickedCommandProperty = BindableProperty.Create<DataListView, ICommand>(o => o.ItemClickedCommand, default(ICommand));
        public static BindableProperty SelectedItemProperty = BindableProperty.Create<DataPicker, object>(o => o.SelectedItem, default(object), propertyChanged: OnSelectedItemChanged);

        public ICommand ItemClickedCommand
        {
            get { return (ICommand)GetValue(ItemClickedCommandProperty); }
            set { SetValue(ItemClickedCommandProperty, value); }
        }

        public static BindableProperty ScrollableItemsSourceProperty = BindableProperty.Create<DataListView, IEnumerable>(o => o.ScrollableItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var listView = bindable as DataListView;
            if (listView == null)
                return;

            listView.ItemsSource = newvalue;
            if (newvalue is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)newvalue).CollectionChanged += async (s, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        var item = listView.ItemsSource.OfType<object>().FirstOrDefault();
                        listView.Layout(listView.Bounds);
                    }
                };
            }

        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as DataPicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
            }
        }

        public IEnumerable ScrollableItemsSource
        {
            get { return (IEnumerable)GetValue(ScrollableItemsSourceProperty); }
            set { SetValue(ScrollableItemsSourceProperty, value); }
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

        public DataListView()
        {
            ItemTapped += OnItemTapped;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && ItemClickedCommand != null && ItemClickedCommand.CanExecute(e))
            {
                ItemClickedCommand.Execute(e.Item);
                SelectedItem = null; //we don't need the SelectedItem if we have binding to ItemClickedCommand
            }
        }
    }

}
