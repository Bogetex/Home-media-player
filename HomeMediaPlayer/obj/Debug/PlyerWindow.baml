   M S B A M L   `   `   `  ����  HomeMediaPlayer"    HomeMediaPlayer.PlayerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  PlayerWindow��5   	   $	��500��6   $	��700��6+   .��5      �  � RowDefinitions 5   
   �� 5      $��26 �6   �� 5      $	��18* �6   �� 5	      $��2* �6   .+�5   
   o� $��0��6   $��18(�6   ��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      �  � Color$ 	#FFF6F6F6��6#    � Offset$
 0.75Q�65   � 5      $ White��6#   5      .@�5      m� $��_File��6   .@�5      m� -   5        $��mnuExit��5   *   $��_Exit��6   69   5      5      r� 5   
   -   5        $��mePlayer��5       r� LoadedBehavior$ Manual=�6'   $��Center=�5      $��1��64   $��Center=�5       r� Stretch$ Uniform=�62   ]� 5   
   $��2��6   $��Center=�6!   $��30��6>   .+�5      �� -   5        $��
btnPrevios��5      ��6@   ��  �� ElementName$ btnPlay��	 �� Path$	 Padding�.��5      �� 
 �� Orientation$
 
Horizontal=�6   $��16��66   $��16��6A   .+�5      �� $%��/Resources/control-skip-180.png��6   5      5      �� 5      -   5        $��btnPause��5      ��6<   �� $ btnPlay��$	 Padding�.��5       �� $
 
Horizontal=�6   $��16��66   $��16��6A   .+�5!      �� $"��/Resources/control-pause.png��6   5"      5#      �� 5$      -   5        $��btnPlay��5$       � ToolTip$ Click to start.��6:   $��5q�6T   .��5%      �� $
 
Horizontal=�6   $��16��66   $��16��6A   .+�5&      �� $��/Resources/control.png��6   5'      5(      �� 5)      -   5        $��btnStop��5)      ��6:   �� $ btnPlay��$	 Padding�.��5*      �� $
 
Horizontal=�6   $��16��66   $��16��6A   .+�5+      �� $(��"/Resources/control-stop-square.png��6   5,      5-      �� 5.      -   5        $��btnNext��5.      ��6:   �� $ btnPlay��$	 Padding�.��5/      �� $
 
Horizontal=�6   $��16��66   $��16��6A   .+�50      �� $!��/Resources/control-skip.png��6   51      52      54      55      56      