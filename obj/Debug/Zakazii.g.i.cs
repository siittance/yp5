﻿#pragma checksum "..\..\Zakazii.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DD0B47FDD0F72982CBCDB63360A6F44D56FB4C5C285C4D968FAF0F99A4CA54AA"
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
    /// Zakazii
    /// </summary>
    public partial class Zakazii : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TableSS;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Combo1;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo2;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo3;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo4;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo5;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo6;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo7;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dobav;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Izmen;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Zakazii.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ydal;
        
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
            System.Uri resourceLocater = new System.Uri("/YP5;component/zakazii.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Zakazii.xaml"
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
            
            #line 28 "..\..\Zakazii.xaml"
            this.TableSS.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TableSS_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 39 "..\..\Zakazii.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Combo1 = ((System.Windows.Controls.DatePicker)(target));
            
            #line 47 "..\..\Zakazii.xaml"
            this.Combo1.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.ReadDannie2_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Combo2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Combo3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Combo4 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Combo5 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Combo6 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 52 "..\..\Zakazii.xaml"
            this.Combo6.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combo2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Combo7 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 53 "..\..\Zakazii.xaml"
            this.Combo7.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combo3_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Dobav = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\Zakazii.xaml"
            this.Dobav.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Izmen = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\Zakazii.xaml"
            this.Izmen.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Ydal = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\Zakazii.xaml"
            this.Ydal.Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

