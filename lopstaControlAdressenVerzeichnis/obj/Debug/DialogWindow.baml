   M S B A M L   `   `   `  ����[  WlopstaControlAdressenVerzeichnis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:lopstaControlAdressenVerzeichnis lopstaControlAdressenVerzeichnis  5   	   3    -lopstaControlAdressenVerzeichnis.DialogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:lopstaControlAdressenVerzeichnis     5   	     � Title$  DialogWindow��5   	   $	��450��6   $	��800��6+    � SizeToContent$ Height=�67    � 
ResizeMode$ NoResize=�6N    � ShowInTaskbar .   � Topmost . .��5
      �  � 	Resources 5   
   ��%    6   ��5   
   �� 5       �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value$ 10,20,10,10q�6+   5      	 � ColumnDefinitions	 5   
   �� 5      
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5      $��44 �6   .+�5   
   � -   5         �Name$ GridCONTENT��5      $��0��6$   $��0��64   6C   �� 5   
   -   5         ��Name$ StackPanelDialogBUTTONS��5      $��0��66   $��1��6F   $y�	Collapsed=�6S    5      ��%|   '��       �� 5       " ��6   .�5!      ��  � ��$ 5,0,0,0q�6/   �� 5"       � ��$	 180��6.   5#      5$      ��5%      �� 5&      " ��6   .�5'      ��  � ��$ 10q�6/   �� 5(       � ��$ Right=�6<   �� 5)       �@��Orientation$ 
Horizontal=�64   5*      .+�5-      �� -   5         ��Name$ ButtonOk��5-       �� 	IsDefault . $��Übernehmen.��68   �� 5/      -   5        $ ButtonCancel��5/       �� IsCancel . $��
Abbrechen.��6;   50      52      53      