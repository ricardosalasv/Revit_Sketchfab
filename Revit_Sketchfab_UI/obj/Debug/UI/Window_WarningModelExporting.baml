   M S B A M L   `   `   `  ����M  IRevit_Sketchfab_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Revit_Sketchfab_UI.UIRevit_Sketchfab_UI.UI  5   	   8    2Revit_Sketchfab_UI.UI.Window_WarningModelExporting   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Revit_Sketchfab_UI.UI     5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency . 
������  � Title$" Window_WarningModelExporting��5   	   $	��300��6.   $	��600��6;    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $1 +../ResourceDictionaries/BaseDictionary.xaml?�6%   �� 5      $3 -../ResourceDictionaries/ButtonDictionary.xaml?�6%   �� 5      $1 +../ResourceDictionaries/TextDictionary.xaml?�6%   �� 5      $4 .../ResourceDictionaries/TextBoxDictionary.xaml?�6%   %    5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      ShadowDepth$ 10Q�5         Opacity$	 0.5Q�5      	   
BlurRadius$	 15Q�5      .��5       ��    
out_border#��[  6   $��	0 0 30 30q�5!      ���#58C5E9._�5%   
   � .+�5'      �� -   5        
 ��Name$

 text��5'      
������� �� Padding$ 	30 0 30 0q�5*      $y��sThe model is uploading, another window is going to be shown to notify when the model has been succesfully exported.��5,      $��24(�5-      $
��Wrap=�5.       �� TextAlignment$ Center=�5/      $��Center=�50      52      53      54      