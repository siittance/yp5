﻿#pragma checksum "..\..\IgrushkaPets.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EABD0A257A6E3D51BAE91DED839B908724A1ED0BDB5282F7B0D9D64AF83029BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using YP5;


namespace YP5 {
    
    
    /// <summary>
    /// IgrushkaPets
    /// </summary>
    public partial class IgrushkaPets : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\IgrushkaPets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TableSS;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\IgrushkaPets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReadDannie;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\IgrushkaPets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReadDannie1;
        
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
            System.Uri resourceLocater = new System.Uri("/YP5;component/igrushkapets.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\IgrushkaPets.xaml"
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
            this.TableSS = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\IgrushkaPets.xaml"
            this.TableSS.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TableSS_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 31 "..\..\IgrushkaPets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ReadDannie = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\IgrushkaPets.xaml"
            this.ReadDannie.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ReadDannie_TextChanged);
            
            #line default
            #line hidden
            
            #line 34 "..\..\IgrushkaPets.xaml"
            this.ReadDannie.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ReadDannie_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ReadDannie1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\IgrushkaPets.xaml"
            this.ReadDannie1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ReadDannie1_TextChanged);
            
            #line default
            #line hidden
            
            #line 35 "..\..\IgrushkaPets.xaml"
            this.ReadDannie1.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ReadDannie1_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 36 "..\..\IgrushkaPets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 37 "..\..\IgrushkaPets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 38 "..\..\IgrushkaPets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

