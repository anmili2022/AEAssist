﻿#pragma checksum "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F766A7FAFCEE6838DEFC5B31DB1DE210E6F6A4586DA03C7CFD308199062CE3FC"
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
using AEAssist.View;
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


namespace AEAssist.View {
    
    
    /// <summary>
    /// DancerOverlayWindow
    /// </summary>
    public partial class DancerOverlayWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 82 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UseTactician;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UseArmsLength;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UseSprint;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UsePotion;
        
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
            System.Uri resourceLocater = new System.Uri("/AEAssist;component/view/overlay/danceroverlaywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.UseTactician = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
            this.UseTactician.Click += new System.Windows.RoutedEventHandler(this.UseTactician_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UseArmsLength = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
            this.UseArmsLength.Click += new System.Windows.RoutedEventHandler(this.UseArmsLength_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UseSprint = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
            this.UseSprint.Click += new System.Windows.RoutedEventHandler(this.UseSprint_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UsePotion = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\View\Overlay\DancerOverlayWindow.xaml"
            this.UsePotion.Click += new System.Windows.RoutedEventHandler(this.UsePotion_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

