﻿#pragma checksum "C:\haokee\HaokeePeotry\HaokeePeotry\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "089B10939A92B92FFE91A7D33A2AF1CF9E6AFD0E13F41E4343F35DC752E8343F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HaokeePeotry
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2411")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainWindow.xaml line 61
                {
                    this.CenterTextToggleSwitch = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ToggleSwitch>(target);
                    ((global::Microsoft.UI.Xaml.Controls.ToggleSwitch)this.CenterTextToggleSwitch).Toggled += this.CenterTextToggleSwitch_Toggled;
                }
                break;
            case 3: // MainWindow.xaml line 59
                {
                    this.FileContentTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 4: // MainWindow.xaml line 55
                {
                    this.AuthorTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 5: // MainWindow.xaml line 51
                {
                    this.TitleTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 6: // MainWindow.xaml line 42
                {
                    global::Microsoft.UI.Xaml.Controls.Button element6 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element6).Click += this.EditButton_Click;
                }
                break;
            case 7: // MainWindow.xaml line 43
                {
                    global::Microsoft.UI.Xaml.Controls.Button element7 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element7).Click += this.DeleteButton_Click;
                }
                break;
            case 8: // MainWindow.xaml line 38
                {
                    global::Microsoft.UI.Xaml.Controls.Button element8 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element8).Click += this.RefreshButton_Click;
                }
                break;
            case 9: // MainWindow.xaml line 39
                {
                    global::Microsoft.UI.Xaml.Controls.Button element9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element9).Click += this.NewButton_Click;
                }
                break;
            case 10: // MainWindow.xaml line 26
                {
                    this.FileListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                    ((global::Microsoft.UI.Xaml.Controls.ListView)this.FileListView).SelectionChanged += this.FileListView_SelectionChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }


        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2411")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

