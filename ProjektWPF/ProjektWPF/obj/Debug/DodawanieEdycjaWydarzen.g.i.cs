﻿#pragma checksum "..\..\DodawanieEdycjaWydarzen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "80C3C0B8234A7FF35F76BA531DBAF896D38EB92003145A6C1E4437284664B210"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjektWPF;
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


namespace ProjektWPF {
    
    
    /// <summary>
    /// DodawanieEdycjaWydarzen
    /// </summary>
    public partial class DodawanieEdycjaWydarzen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOpusc;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPotwierdz;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazwaWydarzenia;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cykl;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typCyklu;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerData;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxGodziny;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\DodawanieEdycjaWydarzen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxMinuty;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjektWPF;component/dodawanieedycjawydarzen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DodawanieEdycjaWydarzen.xaml"
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
            this.buttonOpusc = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\DodawanieEdycjaWydarzen.xaml"
            this.buttonOpusc.Click += new System.Windows.RoutedEventHandler(this.buttonOpusc_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonPotwierdz = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\DodawanieEdycjaWydarzen.xaml"
            this.buttonPotwierdz.Click += new System.Windows.RoutedEventHandler(this.buttonPotwierdz_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nazwaWydarzenia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cykl = ((System.Windows.Controls.CheckBox)(target));
            
            #line 17 "..\..\DodawanieEdycjaWydarzen.xaml"
            this.cykl.Checked += new System.Windows.RoutedEventHandler(this.cykl_Checked);
            
            #line default
            #line hidden
            
            #line 17 "..\..\DodawanieEdycjaWydarzen.xaml"
            this.cykl.Unchecked += new System.Windows.RoutedEventHandler(this.cykl_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.typCyklu = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.datePickerData = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.comboBoxGodziny = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.comboBoxMinuty = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

