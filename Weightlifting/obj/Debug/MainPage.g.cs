﻿#pragma checksum "C:\Users\sujan\documents\visual studio 2010\Projects\Weightlifting\Weightlifting\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "39B905502761CED7CA0E744AE3E41B02"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Weightlifting {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Canvas canvas1;
        
        internal System.Windows.Controls.HyperlinkButton hyperlinkButton1;
        
        internal System.Windows.Controls.HyperlinkButton hyperlinkButton2;
        
        internal System.Windows.Controls.Canvas helpCanvas;
        
        internal System.Windows.Controls.Button closeHelp;
        
        internal System.Windows.Controls.ScrollViewer helpscroll;
        
        internal System.Windows.Controls.TextBlock helptext;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Weightlifting;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.canvas1 = ((System.Windows.Controls.Canvas)(this.FindName("canvas1")));
            this.hyperlinkButton1 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hyperlinkButton1")));
            this.hyperlinkButton2 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("hyperlinkButton2")));
            this.helpCanvas = ((System.Windows.Controls.Canvas)(this.FindName("helpCanvas")));
            this.closeHelp = ((System.Windows.Controls.Button)(this.FindName("closeHelp")));
            this.helpscroll = ((System.Windows.Controls.ScrollViewer)(this.FindName("helpscroll")));
            this.helptext = ((System.Windows.Controls.TextBlock)(this.FindName("helptext")));
        }
    }
}

