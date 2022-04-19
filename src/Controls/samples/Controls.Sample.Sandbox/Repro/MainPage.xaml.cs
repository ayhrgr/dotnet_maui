using System;
using Microsoft.Maui.Controls;

namespace MauiApp24;

public partial class MainPage : ContentPage
{
    //int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    void OnCounterClicked(object sender, EventArgs e)
    {
        button.IsEnabled = !button.IsEnabled;
    }

    void OnCounterClicked2(object sender, EventArgs e)
    {
        button.IsEnabled = !button.IsEnabled;
    }
}

