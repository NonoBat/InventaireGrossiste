﻿#pragma checksum "..\..\..\..\EditProducts\AjoutManuProducts.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ECA3E9314BFE52EEA92671636A50B5A9BD91303"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace InventaireGrossiste.EditProducts {
    
    
    /// <summary>
    /// AjoutManuProducts
    /// </summary>
    public partial class AjoutManuProducts : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NomTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QteTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prixTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DLCDatePicker;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategorieComboBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmpTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InventaireGrossiste;component/editproducts/ajoutmanuproducts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NomTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.QteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.prixTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DLCDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.CategorieComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.EmpTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 33 "..\..\..\..\EditProducts\AjoutManuProducts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

