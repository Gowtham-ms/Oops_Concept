﻿#pragma checksum "..\..\CustomImageViewer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0010E3742786AB3C226B1E2023ED75C2DD92E50F0F4D42A93162E3221E73F66A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace WpfApp1 {
    
    
    /// <summary>
    /// CustomImageViewer
    /// </summary>
    public partial class CustomImageViewer : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\CustomImageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CustomImageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZoomInButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CustomImageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZoomOutButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CustomImageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/customimageviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomImageViewer.xaml"
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
            
            #line 8 "..\..\CustomImageViewer.xaml"
            ((WpfApp1.CustomImageViewer)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CustomImageViewer_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.image = ((System.Windows.Controls.Image)(target));
            
            #line 10 "..\..\CustomImageViewer.xaml"
            this.image.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 10 "..\..\CustomImageViewer.xaml"
            this.image.MouseMove += new System.Windows.Input.MouseEventHandler(this.image_MouseMove);
            
            #line default
            #line hidden
            
            #line 10 "..\..\CustomImageViewer.xaml"
            this.image.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.image_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ZoomInButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\CustomImageViewer.xaml"
            this.ZoomInButton.Click += new System.Windows.RoutedEventHandler(this.ZoomInButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ZoomOutButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\CustomImageViewer.xaml"
            this.ZoomOutButton.Click += new System.Windows.RoutedEventHandler(this.ZoomOutButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\CustomImageViewer.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

