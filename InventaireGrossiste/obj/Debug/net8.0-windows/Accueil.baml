   M S B A M L   `   `   `  ����N  JInventaireGrossiste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InventaireGrossisteInventaireGrossiste  5   	   !    InventaireGrossiste.Accueil   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   0faWPF$http://schemas.fontawesome.io/icons/  5   	   -local!clr-namespace:InventaireGrossiste  5   	     � Title$  Accueil��5
   	    � WindowState$ Normal=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $
��1225��6.   $	��700��6;   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #212E53��6    � Offset$	 0.0Q�6+   � 5      $ #2CCED2��6   $	 2.5Q�6+   5      .��5      � $��Stretch=�6   $��Stretch=�6)    � RowDefinitions 5   
   �� 5      $	��62* �6   �� 5      $	��41* �6   	 � ColumnDefinitions	 5   
   �� 5      $��1* �6   �� 5      $��5* �6   .+�5"   
   �� $��0��6   $��2��6   $��Center=�62   $	��Top=�6O   $��0,10,0,0q�6g   ._�5#      �� $��OptiFlux��6   
�������$��24(�6;   $
��Bold"�6I   $��Center=�6[   5$      �� 5'   
   $��	0,0,10,10q�6   $��2��6$   $��0��65   $��Center=�6E   $	��187��6b   ._�5(      �� 
 �� Orientation$
 Vertical=�6   $��0,0,0,0q�60   .+�5)      �� -   5        ���#212E53
�������
������ $
��Bold"�5)   u   .��5*      �� $
 
Horizontal=�6!   .+�5+      "  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�6-      
Foreground
 �����$��Center=�6L   $��0,0,5,0q�6g   $��24��6x   $��24��6�   �� 5,      $��Accueil��6$   $��Center=�63   5-      5.      �� 5/      -   5        ���#212E53
�������
������ $
��Bold"�5/   u   .��50      �� $
 
Horizontal=�6!   .+�51        $
 User=�6-   
 �����$��Center=�6L   $��0,0,5,0q�6g   $��24��6x   $��24��6�   �� 52      $��Clients��6$   $��Center=�63   53      54      �� 55      -   5        ���#212E53
�������
������ $
��Bold"�55   w   .��56      �� $
 
Horizontal=�6!   .+�57        $ 	Clipboard=�6-   
 �����$��Center=�6Q   $��0,0,5,0q�6l   $��24��6}   $��24��6�   �� 58      $��	Commandes��6$   $��Center=�65   59      5:      �� 5;      -   5        ���#212E53
�������
������ $
��Bold"�5;   v   .��5<      �� $
 
Horizontal=�6!   .+�5=        $
 Tags=�6-   
 �����$��Center=�6L   $��0,0,5,0q�6g   $��24��6x   $��24��6�   �� 5>      $��Produits��6$   $��Center=�64   5?      5@      �� 5A      -   5        ���#212E53
�������
������ $
��Bold"�5A   w   .��5B      �� $
 
Horizontal=�6!   .+�5C        $
 List=�6-   
 �����$��Center=�6L   $��0,0,5,0q�6g   $��24��6x   $��24��6�   �� 5D      $��Catégories��6$   $��Center=�66   5E      5F      5G      5H      �� 5K   
   $��1q�6    �� CornerRadius$ 5��6%   
�������$��	204,0,0,0q�6I   $��2��6\   $��2��6m   ._�5L      �� $
 Vertical=�6   $��Center=�60   $��Center=�6M   $	��468��6h   $	��744��6u   .+�5N       � -   5        $��	MainFrame��5N        � NavigationUIVisibility$ Hidden=�6)   $��Stretch=�6I   $��Stretch=�6g   $��0,40,0,0q�6�   5P      5Q      5R      5T      