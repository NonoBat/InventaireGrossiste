   M S B A M L   `   `   `  ����N  JInventaireGrossiste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InventaireGrossisteInventaireGrossiste  5      $    InventaireGrossiste.Categories   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:InventaireGrossiste     5        N� Title$  
Categories��5      .��5
      � $	��223��6   $��64,146,0,146q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ CategoriesListView��5      $��10,10,10,10q�6/   $��2��6D   ��5      �� 5      .R�5      �  5      �� 5      $
��Auto �6/   �� 5      $��* �6/   .+�5      �� 
���   �$��0��6K   $��5q�6[   ��6$   �� *Id+6[   �� 5      
���   �$��1��6L   $��5q�6\   ��6$   �� *Nom+6\   5      5      5!      �� 5$   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $
��Left=�6;   $��	0,10,0,10q�6V   $��2��6i   .+�5%      �� -   5        $��Ajouter��5%      $	��100��6'   $��5q�63   6>   �� 5&      -   5        $��Modifier��5&      $	��100��6(   $��5q�64   6?   �� 5'      -   5        $��	Supprimer��5'      $	��100��6)   $��5q�65   6@   5(      5)      5*      