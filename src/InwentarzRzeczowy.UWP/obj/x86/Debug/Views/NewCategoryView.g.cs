﻿#pragma checksum "D:\Projects\InwentarzRzeczowy\src\InwentarzRzeczowy.UWP\Views\NewCategoryView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E14D1FF6AB6628818FB2F3544686BC85"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InwentarzRzeczowy.UWP.Views
{
    partial class NewCategoryView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\NewCategoryView.xaml line 24
                {
                    this.CategoryName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Views\NewCategoryView.xaml line 25
                {
                    this.CategoryPrefix = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Views\NewCategoryView.xaml line 26
                {
                    this.CategoryDescription = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Views\NewCategoryView.xaml line 29
                {
                    this.CategoryAttributes = (global::Microsoft.Toolkit.Uwp.UI.Controls.TokenizingTextBox)(target);
                }
                break;
            case 6: // Views\NewCategoryView.xaml line 32
                {
                    this.CategoryTags = (global::Microsoft.Toolkit.Uwp.UI.Controls.TokenizingTextBox)(target);
                }
                break;
            case 7: // Views\NewCategoryView.xaml line 34
                {
                    this.CreateCategory = (global::Windows.UI.Xaml.Controls.Button)(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

