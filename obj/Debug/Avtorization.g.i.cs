﻿#pragma checksum "..\..\Avtorization.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C608E57F1BF8B0F05DB2AADBB2738A994C46C4B21EFB2976845D9F7A5E612649"
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
    /// Avtorization
    /// </summary>
    public partial class Avtorization : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\Avtorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TableSS;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Avtorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReadDannie;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Avtorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReadDannie1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Avtorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ReadDannie2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Avtorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dobav;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Avtorization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Izmen;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Avtorization.xaml"
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
            System.Uri resourceLocater = new System.Uri("/YP5;component/avtorization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Avtorization.xaml"
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
            
            #line 25 "..\..\Avtorization.xaml"
            this.TableSS.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TableSS_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 32 "..\..\Avtorization.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ReadDannie = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\Avtorization.xaml"
            this.ReadDannie.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ReadDannie_TextChanged);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Avtorization.xaml"
            this.ReadDannie.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ReadDannie_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ReadDannie1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\Avtorization.xaml"
            this.ReadDannie1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ReadDannie1_TextChanged);
            
            #line default
            #line hidden
            
            #line 37 "..\..\Avtorization.xaml"
            this.ReadDannie1.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ReadDannie1_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ReadDannie2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Dobav = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Avtorization.xaml"
            this.Dobav.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Izmen = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Avtorization.xaml"
            this.Izmen.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Ydal = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Avtorization.xaml"
            this.Ydal.Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

