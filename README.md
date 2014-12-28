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

