   M S B A M L   `   `   `  ����Q  MlopstaControlDATEINAME, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:lopstaControlDATEINAMElopstaControlDATEINAME  5   	   -    'lopstaControlDATEINAME.WindowUserDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:lopstaControlDATEINAME     5   	     � Title$  Dateiname erstellen ....��5   	   $	��600��6?    � ShowInTaskbar .   � Topmost .  � 
ResizeMode$ NoResize=�6p    � SizeToContent$ Height=�6�   .��5	      �  � 	Resources 5   
      RowDefinitionContent �� 
TargetType  RowDefinitionLine �� Property �� Value  RowDefinitionDialogButtons��%�   &	        &	      &	 g     �� 5      " ��61   6N   �� 5      " ��6.   .�5      ��  � ��$
 Auto �6+   5      �� 5      " ��67   .�5      ��  � ��$
 Auto �6+   5      5      	 � ColumnDefinitions	 5   
   �� 5      
 � RowDefinitions
 5   
   �� 5      #��[  6   �� 5      #��[ 6   �� 5      #��[ 6   .+�5"   
   � -   5         �Name$ ContainerUserControl��5"      $��0��6-   $��0��6=   �� 5$   
   	 �� X1$ 0��6   	 �� Y1$ 1��6   	 �� X2$	 400��6   	 �� Y2$ 1��6&   
�������$��1��6@   $��Right=�6T   $��
0,20,25,10q�6p   $��0��6�   $��1��6�   �� 5&   
   $��0��6   $��2��6%    5'      �� 5(      %{  '��       '�� �     �� 5)      " ��6   .�5*      ��  � ��$ 0��68   �� 5+       � ��$ 1��65   �� 5,       � ��$ 
10,0,10,10q�63   �� 5-       �@��Orientation$ 
Horizontal=�68   �� 5.       � ��$ Right=�6@   5/      �� 50      " ��6   .�51      ��  � ��$	 130��62   �� 52       � ��$ 5,0,0,0q�63   53      54      .+�56      �� -   5         ��Name$ ButtonClose��56      $��Schließen.��6*   �� 57      -   5        $ ButtonCancel��57      $��
Abbrechen.��6+   58      5:      5;      