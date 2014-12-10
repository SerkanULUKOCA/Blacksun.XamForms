Blacksun.XamForms
=================

I have no idea of what Im doing so bare with me

##View Helpers

Xamforms is just a view helper that cuts down the time you make views, when doing them in code behind c# what it does is have a standard padding margins and spacings already done so you only have to write down the properties and their bindings, this is a small library which I did to make my job a little easier. I have made it public so that anyone who wishes to help me make this better ill have the chance to do so

for example a simple login viewn would be done like so

```c#

public LoginView()
        {
            Content = ViewHelper.GetCenteredForm(new List<View>
            {
                ViewHelper.GetTextProperty("Username", "Username",bindingMode:BindingMode.TwoWay,labelType:LabelType.Watermark),
                ViewHelper.GetPasswordProperty("Password", "Password",bindingMode:BindingMode.TwoWay,labelType:LabelType.Watermark),
                ViewHelper.GetButton("Login",Color.White,AppColors.Accent),
                
            });
        }
        
        
```

A more complex example showing grouping would be

```c#
public MainView()
        {

            BindingContext = new MainViewModel();
            
            Content = ViewHelper.GetForm(new List<GroupLayout>
            {
                ViewHelper.GetFormGroup("Group", new List<View>
                {
                    ViewHelper.GetTextProperty("Editable", "Property"),
                    ViewHelper.GetTextProperty("I am a watermarked Entry", "WatermarkProperty", new PropertyConfig(){LabelType = LabelType.Watermark}),
                    ViewHelper.GetReadOnlyTextProperty("Read Only", "Property"),
                    ViewHelper.GetPasswordProperty("Password", "Property"),
                    ViewHelper.GetLabelForContent("Busy indicator",ViewHelper.GetButton("Show busy indicator",ViewModel.LoadingCommand)),
                    ViewHelper.GetLabelForContent("Progress bar",ViewHelper.GetButton("Show progress bar",ViewModel.ProgressCommand)),
                    ViewHelper.GetPickerProperty("Picker","CustomerID","Name","ID",ViewModel.Customers),
                    ViewHelper.GetReadOnlyTextProperty("Picker Selected Value", "CustomerID"),
                    ViewHelper.GetSliderProperty("Slider", "SliderValue",0,255),
                    ViewHelper.GetImageProperty("Image", "ImageSource"),
                })
            });
        }

```

##Bindable Picker

Theres even a bindable picker which can be used like so

```c#
ViewHelper.GetPickerProperty("LABEL VALUE","VIEWMODELPROPERTY","DISPLAYPATH","VALUEMEMBERPATH",ITEMSSOURCE)

```

