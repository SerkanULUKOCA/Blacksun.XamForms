Blacksun.XamForms
=================

Changed everythign to make the way it is done similar to the good old DataForm in Silverlight or WPF but its not a dataform so no edit delete or new its just to make views easier to do

##View Helpers

Xamforms is just a view are custom controls that wraps xamarin controls and adds a label to them and exposes properties for easy databinding for non xaml users 

Aside from adding labels There are Global Positioning Paddings and spacing which are already implemented so you dont have to

if you wish to Change these setting for you can do it by using The Appropiate Static class and modifying its value



##NOTE

THere are static colors implemented in these Controls if you want to use HoloLightTheme or Light Theme in Windows Phone please use these, they do not change the theme these are just so that the DataField Controls Use the appropiate colors

```c#

AppColors.WindowsPhoneTheme = WindowsPhoneTheme.LightTheme;
AppColors.AndroidTheme = AndroidTheme.HoloLightTheme;
        
        
```

##DATAFORM

a main container that has a scrollviewer and has a spacing of 20 , 20 ,40 on Device Platform and a padding of 30


```c#

<controls:DataForm >

</controls:DataForm>
        
        
```


##Bindable Picker

Theres even a bindable picker which can be used like so

```c#
new DataFormPickerField(){Label = "Picker",DatamemberBindingPath = "CustomerID",DisplayMemberPath="Name",SelectedValueMemberPath = "ID",ItemSourcePath = "Customers"},

```

