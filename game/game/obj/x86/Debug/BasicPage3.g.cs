﻿

#pragma checksum "C:\Users\Naraharasetti Uday\documents\visual studio 2013\Projects\game\game\BasicPage3.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EA8B49CCB44D1EDC42BFE38C4A2B34F6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace game
{
    partial class BasicPage3 : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 75 "..\..\..\BasicPage3.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).DoubleTapped += this.key1_DoubleTapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 76 "..\..\..\BasicPage3.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).PointerPressed += this.Image_PointerPressed;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 71 "..\..\..\BasicPage3.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.submitbtn_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 61 "..\..\..\BasicPage3.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.closebtn_Click_1;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 51 "..\..\..\BasicPage3.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.backButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

