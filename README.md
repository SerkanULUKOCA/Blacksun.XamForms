Blacksun.XamForms For Xamarin Forms
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

##DataForm

a main container that has a scrollviewer and has a spacing of 20 , 20 ,40 on Device Platform and a padding of 30


```c#

<controls:DataForm >

</controls:DataForm>
        
        
```

##DataGroup

groups are like a segmentation of fields for example you have a couple of fields are the customer info and then you want to show something else it would be done like so 

```c#

<controls:DataForm >
  <controls:DataFormGroup Header="Customer Info">
        ...
  </controls:DataFormGroup>
  <controls:DataFormGroup Header="Something else">
        ...
  </controls:DataFormGroup>
</controls:DataForm>
        
        
```

this would show a Subtitle on top of the groups children properties

Fields
=================

these are the diferent types of fields similar to the DataForm instead of binding to Text or Value It binds to DataMemberBinding

##DataFormDataField TextField

```c#

<controls:DataFormDataField Label="Editable" DataMemberBinding="{Binding Property,Mode=TwoWay}"/>
        
        
```

##DataFormDataField TextField with Watermark Label

```c#

<controls:DataFormDataField Label="I am a watermarked Entry" LabelType="Watermark" DataMemberBinding="{Binding WatermarkProperty,Mode=TwoWay}"/>
        
        
```

##DataFormDataField TextField Read Only

```c#

<controls:DataFormLabelField Label="Read Only" DataMemberBinding="{Binding Property}"/>
        
        
```

##DataFormPickerField Picker Field

```c#

<controls:DataFormPickerField Label="Picker" DataMemberBinding="{Binding CustomerID,Mode = TwoWay}" 
                                    DisplayMemberPath="Name" SelectedValueMemberPath ="ID" 
                                    SelectedItem="{Binding SelectedItem,Mode=TwoWay}"
                                    ItemsSource= "{Binding Customers}"/>
        
        
```

##DataFormSliderField Slider

```c#

<controls:DataFormSliderField Label="Slider" DataMemberBinding="{Binding SliderValue,Mode=TwoWay}" Minimum="0" Maximum="255"/>
        
        
```

##DataFormSliderField Slider

```c#

<controls:DataFormImageField Label="Image" DataMemberBinding="{Binding ImageSource}" />
        
        
```

##DataFormDateField Date Picker

```c#

<controls:DataFormDateField Label="Date picker" DataMemberBinding="{Binding CurrentDate,Mode=TwoWay}" />
        
        
```

##DataFormDateField Date Picker

```c#

<controls:DataFormDateField Label="Date picker" DataMemberBinding="{Binding CurrentDate,Mode=TwoWay}" />
        
        
```

##DataFormContentField Content Field

you can use this to encapsulate any other control and give it a label

```c#

<controls:DataFormContentField Label="Busy indicator">
        <controls:DataFormButton Text="Show busy indicator" Command="{Binding LoadingCommand}"/>
      </controls:DataFormContentField>
        
        
```

Bluetooth Services For Xamarin Forms
=================

This a xamarin forms implementation for the bluetooth service

##Check if bluetooth is on

returns boolean

```c#

var result = await _bluetoothClient.IsBluetoothOn();
        
        
```

##Get Paired devices

returns a list of IDevice

```c#

var devices = await _bluetoothClient.GetPairedDevices();
        
        
```

##Connect Write Disconnect

device is an IDevice

```c#

        await device.Connect();

        await device.Write("Hello world");

        await device.Disconnect();
        
        
```

NuGet Support
=================

Just search for them on NuGet Blacksun for all my libraries

TODO
=================

If anyone wishes to do the iOS Services plugins for the services just say so :D

Anything else that is needed just communicate what else you wish to see
