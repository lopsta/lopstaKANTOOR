   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   lopstaListViewHeader  �� 
TargetType J� SnapsToDevicePixels ��Name � RowDefinitions �� Padding ��Name �� ContentStringFormat �� ContentStringFormat n�Name	 �� 
TargetType
 �� Property �� Value �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName  brush003  lopstaListViewHeaderStyle 3 /lopsta.ListView.Color.Header.Default.Background 3 /lopsta.ListView.Color.Header.Default.Foreground �� Triggers 6 2lopsta.ListView.Color.Header.IsMousOver.Background 7 3lopsta.ListView.Color.Header.IsMouseOver.Foreground  ListViewItemFocusVisual �� RadiusY �� RadiusX �� CornerRadius 4 0lopsa.ListView.Color.Item.IsMouseOver.Background 5	 1lopsa.ListView.Color.Item.IsMouseOver.BorderBrush 3
 /lopsa.ListView.Color.Item.IsSelected.Background 4 0lopsa.ListView.Color.Item.IsSelected.BorderBrush ]� 
Conditions �� Property �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %E  &	        7  &	 ?    7  7  7  7  &	 �    '�� b    7  7 	 7 
 7  7 
 7  7  7 	 �� 5      "  ��63   .R�5   
   �  . .+�5      �� $ HeaderBorder��6   #��z��6+   $��1q�6W   #��z��6k   ._�5      �  5      �� 5      .+�5      �� # z��6   ._�5      �� $ HeaderContent��5   )   #��z��5   )   #��z��5   )   # z 5   )   $��0q�5   )   #��z��5   )   #��z��5   )   ��. # z 5   )   5!      5"      5#      �� 5%      $ HeaderHoverBorder��6   $��0q�60   $��0q�6D   �� 5'      $ HeaderPressBorder��6   $��0q�60   $��0q�6D   �� 5)      .+�5*      n� $ PART_HeaderGripper��6   ��5+      �� 5,      "	 n�6    .�5-      �� 
 �@��Right$ -9��6=   �� 5.      
 � ��$ 18��66   �� 5/      
 � �� 67   �� *ActualHeight+ �� *TemplatedParent+�� 50      
 � ��$ 1q�68   �� 51      
 � ��
 �����6;   �� 52      
 � �� 53   "   �� 54   &   "  n�66   .R�55   *   �� 
������ # z��6J   ._�56   .   �� #��z��68   $��Center=�6\   $��1��6y   57   +   58   '   5:      5;      5=      5>      5@       5A   
   P� 5B       �@J�IsMouseOver . . �5D      �� $ HeaderHoverBorder��60   8   
 � ��6O   5F      P� 5G       � �� . . �5H      �� 
 �@J�Opacity$	 0.5Q�6,   �� 5L      $ PART_HeaderGripper��6/   
 � y�$ Hidden=�6O   �� 5M      $ HeaderContent��6+   
 � ��$ 1q�6F   5N      P� 5O       � ��$
 Auto��6(   . �5P      �� 
 � ��$ 20��6.   5Q      P� 5R       � {� .  . �5S      �� # � ��6/   
 � ��5T      5V      �� 5Y      "	 ��6.   .�5Z   
   �� 
 � ��$ 28��6#   �� 5[   
   
 � ��$ 0,0,0,0q�6#   �� 5\   
   
 � ��$
 Left=�67   �� 5]   
   
 � ��8   6'   �� 5^   
   
 � ��8  6'   �� 5_   
   
 � ��$ 12(�6%    5`   
   P� 5a       �@J�IsMouseOver . . �5b      �� 
 � ��8  6/   �� 5c      
 � ��8  6/   5d      5f      �� 5l      .�5m   
   �� 
 � �� 5n      �� 5o      .R�5p      �� $ 2��6    $ 2��6,   ���	#8E6EA6F5$��1��6K   5q      5s      5t      �� 5v      "	 ��6   .�5x   
   �� 
 � ��$ 24��6#   �� 5y   
   
 � ��
 ���� 6'   �� 5z   
   
 � ��
 ���� 6(   �� 5{   
   
 � ��$ 1q�6,   �� 5|   
   
 � ��$ 0,0,0,1q�6#   �� 5}   
   
 � ��$ 5,2,5,2q�6$   �� 5~   
   
 � ��$ Center=�65   �� 5   
   
 � �� 5�      �� 5�      "  ��6"   .R�5�      �� #��z��6   #��z��6I   #��z��6}   $ 2��6�    . ._�5�      �� $ InnerBorder��6!   $��1q�66   $ 1��6J   ._�5�      �  5�   "   �� 5�   &   .+�5�   "   �� # z 67   #��z��6s   5�      5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� 8   
 � ��6;   �� 5�      8  
 � ��6<   5�      P� 5�       �@��
IsSelected . . �5�      �� 8  
 � ��6;   �� 5�      8  
 � ��6<   �� 5�      $ InnerBorder��6<   
 � �� �	#80FFFFFF6U   5�      ]� 5�       5�      �� 5�   "    �@��
IsSelected . 6B   �� 5�   "    �@��IsSelectionActive .  6R   ./�5�      �� 8  
 � ��6;   �� 5�      8  
 � ��6<   5�      ]� 5�       5�      �� 5�   "    �@��
IsSelected . 6B   �� 5�   "    �@J�IsMouseOver . 6C   ./�5�      �� 8  
 � ��6;   �� 5�      8  
 � ��6<   5�      P� 5�       � {� .  . �5�      �� # � ��6;   
 � ��5�      5�      5�      5�      5�      