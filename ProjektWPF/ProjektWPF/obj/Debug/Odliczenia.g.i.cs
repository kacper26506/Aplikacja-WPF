﻿#pragma checksum "..\..\Odliczenia.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AEF4B83DB0DBD04291DD94404D6CB66195AAF793C81312A831C37C869BF1ABF6"
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
    /// Odliczenia
    /// </summary>
    public partial class Odliczenia : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Odliczenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelCurrentTime;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Odliczenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewOdliczenia;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Odliczenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOpusc;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Odliczenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDodajWydarzenie;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Odliczenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonEdytujWydarzenie;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Odliczenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonUsuńWydarzenie;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjektWPF;component/odliczenia.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Odliczenia.xaml"
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
            this.labelCurrentTime = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.listViewOdliczenia = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.buttonOpusc = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Odliczenia.xaml"
            this.buttonOpusc.Click += new System.Windows.RoutedEventHandler(this.buttonOpusc_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonDodajWydarzenie = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Odliczenia.xaml"
            this.buttonDodajWydarzenie.Click += new System.Windows.RoutedEventHandler(this.buttonDodajWydarzenie_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonEdytujWydarzenie = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Odliczenia.xaml"
            this.buttonEdytujWydarzenie.Click += new System.Windows.RoutedEventHandler(this.buttonEdytujWydarzenie_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonUsuńWydarzenie = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Odliczenia.xaml"
            this.buttonUsuńWydarzenie.Click += new System.Windows.RoutedEventHandler(this.buttonUsunWydarzenie_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

