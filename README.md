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

for example a simple login viewn would be done like so

```c#

public LoginView()
        {
            Content = ViewHelper.GetCenteredForm(new List<View>
            {
                new DataFormDataField(){Label = "Username",DataMemberBindingPath = "Username",LabelType = LabelType.Watermark},
                new DataFormPasswordField(){Label = "Password",DataMemberBindingPath = "Password",LabelType = LabelType.Watermark},
                new DataFormButton(){Text = "Login"}
                
            });
        }
        
        
```

A more complex example showing grouping would be

```c#
public MainView()
        {

            BindingContext = new MainViewModel();
            
            Content = new DataForm()
            {
                Children =
                {
                    new DataFormGroup()
                    {
                        Header = "Group",
                        Children =
                        {
                            new DataFormDataField(){Label = "Editable",DataMemberBindingPath = "Property"},
                            new DataFormDataField(){Label = "I am a watermarked Entry",DataMemberBindingPath = "WatermarkProperty",LabelType = LabelType.Watermark},
                            new DataFormReadOnlyField(){Label = "Read Only",DataMemberBindingPath = "Property"},
                            new DataFormContentField(){Label = "Busy indicator",Content = new DataFormButton(){Text= "Show busy indicator",Command = ViewModel.LoadingCommand}},
                            new DataFormContentField(){Label = "Progress Dialog",Content = new DataFormButton(){Text= "Show Progress Dialog",Command = ViewModel.ProgressCommand}},
                            new DataFormPickerField(){Label = "Picker",DatamemberBindingPath = "CustomerID",DisplayMemberPath="Name",SelectedValueMemberPath = "ID",ItemSourcePath = "Customers"},
                            new DataFormReadOnlyField(){Label = "Picker Selected Value",DataMemberBindingPath = "CustomerID"},
                            new DataFormSliderField(){Label= "Slider",DataMemberBindingPath="SliderValue",Minimum = 0,Maximum = 255},
                            new DataFormImageField(){Label = "Image",DataMemberBindingPath = "ImageSource"}
                        }
                    }

                }
            };

        }

```

##Bindable Picker

Theres even a bindable picker which can be used like so

```c#
new DataFormPickerField(){Label = "Picker",DatamemberBindingPath = "CustomerID",DisplayMemberPath="Name",SelectedValueMemberPath = "ID",ItemSourcePath = "Customers"},

```

