﻿#pragma checksum "..\..\..\..\..\Vue\Description.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2DAE6905B1BE52F7F4B7F57569FCE80E11C45A36"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using MyScan.ControlUtilisateur;
using MyScan.Vue;
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


namespace MyScan.Vue {
    
    
    /// <summary>
    /// Description
    /// </summary>
    public partial class Description : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyScan.ControlUtilisateur.TextUnderline ScanTitle;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Cover;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run DateParution;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButton;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DelText;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FailDelText;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\Vue\Description.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlayButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyScan;component/vue/description.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Vue\Description.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ScanTitle = ((MyScan.ControlUtilisateur.TextUnderline)(target));
            return;
            case 2:
            this.Cover = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.DateParution = ((System.Windows.Documents.Run)(target));
            return;
            case 4:
            this.EditButton = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\..\..\Vue\Description.xaml"
            this.EditButton.Click += new System.Windows.RoutedEventHandler(this.ModifyButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DelButton = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\..\Vue\Description.xaml"
            this.DelButton.Click += new System.Windows.RoutedEventHandler(this.DelButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DelText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.FailDelText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.PlayButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
