   M S B A M L   `   `   `  ����   HomeMediaPlayer"    HomeMediaPlayer.PlayerWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  PlayerWindow��$	��500��$	��700��.���  � RowDefinitions �� $��26 ��� $	��18* ��� $��2* �.+�o� $��0��$��18(�����  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFF6F6F6�� � Offset$
 0.75Q�� $ White��.@�m� $��_File��.@�m� -   $��mnuExit��$��_Exit��r� -   $��mePlayer�� r� LoadedBehavior$ Manual=�$��Center=�$��1��$��Center=� r� Stretch$ Uniform=�]� $��2��$��Center=�$��30��.+��� -   $��
btnPrevios������  �� ElementName$ btnPlay��	 �� Path$	 Padding�.���� 
 �� Orientation$
 
Horizontal=�$��16��$��16��.+��� $%��/Resources/control-skip-180.png���� -   $��btnPause������ $ btnPlay��$	 Padding�.���� $
 
Horizontal=�$��16��$��16��.+��� $"��/Resources/control-pause.png���� -   $��btnPlay�� � ToolTip$ Click to start.��$��5q�.���� $
 
Horizontal=�$��16��$��16��.+��� $��/Resources/control.png���� -   $��btnStop������ $ btnPlay��$	 Padding�.���� $
 
Horizontal=�$��16��$��16��.+��� $(��"/Resources/control-stop-square.png���� -   $��btnNext������ $ btnPlay��$	 Padding�.���� $
 
Horizontal=�$��16��$��16��.+��� $!��/Resources/control-skip.png��