   M S B A M L   `   `   `  ���� J  FHomeMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HomeMediaPlayerHomeMediaPlayer  I EMediaPlayerLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:MediaPlayerLib;assembly=MediaPlayerLibMediaPlayerLib /    )HomeMediaPlayer.HomeMediaPlayerMainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /localclr-namespace:HomeMediaPlayer     OMediaPlayerLib4clr-namespace:MediaPlayerLib;assembly=MediaPlayerLib     -     � Title$  File browser��$	��500��$	��700��.���  � RowDefinitions �� $��28 ��� $��4* ��� $��2* � � ColumnDefinitions �� $��* ��� $��2* ��� $��50 �.+�o� $��0��$��3��$��16(�����  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFF6F6F6�� � Offset$
 0.75Q�� $ White��.@�m� -    m�Name$ mnuOpen��$��2q� � ToolTip$ Open media folder��$��26��$��24��	 m� Icon	 �� $/��)/Resources/folder-open-document-music.png��$��16��$��16��m� -   $ mnuNewAlbum��$��2q�$ Add New Folder��$��26������ 
 �� ElementName$
 mnuOpen��	 �� $!��/Resources/folder--plus.png��$��16��$��16��m� -   $ mnuExit��$��2q�$ Exit (End application)��$��26��$��22��	 �� $"��/Resources/door-open-out.png��$��16��$��16��m� -   $ mnuHelp��$��2q�$ Help!��$��26��$��22��	 �� $$��/Resources/question-button.png��$��16��$��16��R� -   $��0��$��1��.@�Q� -   $��treeViewAlbums�� Q� 
IsExpanded . $��
My Library���  � Orientation$ 
Horizontal=�$��2��$��0��.+��� -   $��btnNewAlbum��$ Add new Album��$��5q�.���� $��16��$��16��.+��� $ ��/Resources/plus-button.png���� -	   $��btnDeleteAlbum��$ Delete Selected Album��$��5q�.���� $��16��$��16��.+��� $!��/Resources/cross-button.png���� -
   $��lstAlbumFile��$��1��$��1��$��2��$
��Auto=� � ContextMenu �� .@�m� -   $��mnuContexAdd��$��Add to SlidShow��&   System.Windows.Controls.DataGrid  -     Name$ dgrPlayList��$��1��$��2��   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Description��$	 250  �� *Description+  $
 Type�� . $ 70  �� *
TypeOfFile+�� $��2��$��2��$��Center=�$��30��.+��� -    ��Name$ btnUpp��$��5q�.����  �� Orientation$ 
Horizontal=�$��16��$��16��.+��� $��/Resources/arrow-090.png���� -   $ btnDown������ *	Padding+$
 btnUpp��.���� -    ��Name$ vectorPanel��$ 
Horizontal=�$��16��$��16��.+��� $��/Resources/arrow-270.png���� -   $ btnAdd������ *	Padding+$
 btnUpp��.���� $ 
Horizontal=�$��16��$��16��.+��� $ ��/Resources/plus-button.png���� -   $ 	btnRemove������ *	Padding+$
 btnUpp��.���� $ 
Horizontal=�$��16��$��16��.+��� $!��/Resources/cross-button.png���� -   $��btnPlay������ *	Padding+$
 btnUpp��.���� $ 
Horizontal=�$��16��$��16��.+��� $��/Resources/control.png��