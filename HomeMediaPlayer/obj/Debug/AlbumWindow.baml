   M S B A M L   `   `   `  ����  HomeMediaPlayer!    HomeMediaPlayer.AlbumWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	New Album��5   	   $	��500��6   $	��700��6(   $��14(�64   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��2* �6   �� 5	      $��35 �6    � ColumnDefinitions 5   
   �� 5      $
��3.5* �6   �� 5      $
��0.6* �6   �� 5      $
��3.5* �6   .+�5   
   �� $��0��6   $��
Album info��6    $��3��64   .��5      �  5      �� 5      $��* �6$   �� 5      $
��1.2* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� -   5        $��txtPath��5      $	��560��6-   �� 5      -   5        $��btnSearchForFile��5      $��Brows��6T   $	��100��6d   $��10,0,0,0q�6p   5      �� 5      $��1��6   $ 
Horizontal=�6*   $��0,5,0,0q�6C   .+�5      �� $��Album Name:��6   �� 5      -   5        $��txtAlbumName��5      $	��567��62   $��10,0,0,0q�6>   5      5      5      �� 5    
   -   5        $��lstBrowsFile��5       $��1��6'   $��0��64   $��2��6D   $��5,0,0,3q�6U   6h   �� 5!   
   $��1��6   $��1��6%   $��Center=�62   $��5q�6M   .+�5"      �� -   5        $��btnAddToAlbum��5"      $��1��6F   $��1��6V   $��50��6c   .��5#      �� $ 
Horizontal=�6   $��16��66   $��16��6A   .+�5$      �� $��/Resources/arrow-090.png��6    J� RenderTransformOrigin$ 0.5,0.5&�6>   z�5%      V� 5&      .~�5'   "   �� �� 5(   "   �� 5)   "    �� Angle$ 90Q�62   T� 5*   "   5+      5-      5.      5/      �� 50      -   5        $��btnDeleteFromAlbum��50      $��1��6P   $��1��6`   $��50��6m   .��51      �� $ 
Horizontal=�6   $��16��66   $��16��6A   .+�52      �� $��/Resources/arrow-090.png��6   $ 0.5,0.5&�6>   z�53      V� 54      .~�55   "   �� �� 56   "   �� 57   "   $	 -90Q�62   T� 58   "   59      5;      5<      5=      5>      �� 5?   
   -   5        $��lstAlbumFile��5?      $��1��6'   $��2��5@      $��2q�6"   5B      �� 5C   
   -	   5        $��btnOk��5C      $��2��62   $��3��6B   $��Ok��6O   $	��155��6\   $
��Left=�6h   $��2q�6�   �� 5D   
   -
   5        $��	btnCancel��5D      $��2��6:   $��3��6J   $��Cancel��6W   $	��155��6h   $��Right=�6t   $��2q�6�   5E      5F      