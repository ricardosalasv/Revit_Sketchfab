﻿#pragma checksum "..\..\..\UI\Window_Login.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73E128C031379E6196392DD18B291BD8DA0ABAB16B4B58336CF2A9EA4258E2E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Revit_Sketchfab_UI.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Revit_Sketchfab_UI.UI {
    
    
    /// <summary>
    /// Window_Login
    /// </summary>
    public partial class Window_Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\UI\Window_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border maskHeader;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\UI\Window_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\UI\Window_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\UI\Window_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border maskActionButtons;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\UI\Window_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit_button;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\UI\Window_Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button login_button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Revit_Sketchfab_UI;component/ui/window_login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\Window_Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.maskHeader = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.emailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.maskActionButtons = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.exit_button = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\UI\Window_Login.xaml"
            this.exit_button.Click += new System.Windows.RoutedEventHandler(this.exit_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.login_button = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\..\UI\Window_Login.xaml"
            this.login_button.Click += new System.Windows.RoutedEventHandler(this.login_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

