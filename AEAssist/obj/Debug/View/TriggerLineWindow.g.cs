﻿#pragma checksum "..\..\..\View\TriggerLineWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5F3ED91ADE68234815DEFCF1AD0B5652EAE9FA7234F69DD481ECAC9C1DF6D5A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using AEAssist;
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


namespace AEAssist.View.Overlay {
    
    
    /// <summary>
    /// TriggerLineWindow
    /// </summary>
    public partial class TriggerLineWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\View\TriggerLineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadTriggerLine;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\TriggerLineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearTriggerLine;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\TriggerLineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TriggerLineAuthor;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\TriggerLineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TriggerLineVersion;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\TriggerLineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TriggerLineTargetDuty;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\TriggerLineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TriggerLineJob;
        
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
            System.Uri resourceLocater = new System.Uri("/AEAssist;component/view/triggerlinewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\TriggerLineWindow.xaml"
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
            this.LoadTriggerLine = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\View\TriggerLineWindow.xaml"
            this.LoadTriggerLine.Click += new System.Windows.RoutedEventHandler(this.LoadTriggerLine_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ClearTriggerLine = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\View\TriggerLineWindow.xaml"
            this.ClearTriggerLine.Click += new System.Windows.RoutedEventHandler(this.ClearTriggerLine_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TriggerLineAuthor = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.TriggerLineVersion = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.TriggerLineTargetDuty = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.TriggerLineJob = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

