   M S B A M L   `   `   `  ���� H  DlopstaKANZLEI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:lopstaKANZLEIlopstaKANZLEI  +    %lopstaKANZLEI.DialogWindowHinzufuegen   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:lopstaKANZLEI       � Title$  Neue Akte hinzufügen ...��$	��600�� � Topmost .  � SizeToContent$ Height=� � 
ResizeMode$ NoResize=�.���  � 	Resources ��%    ����  �� 
TargetType" �.���  �� Property � �� �� Value$ 10,20,10,10q� � ColumnDefinitions �� 	 � RowDefinitions	 �� $��* ��� $��* �.+�� $��0��$��0������ " � ��%�  '��       '�� l     '��     �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(� �� $��1* �$	��130��$	��180���� $��2* �	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��RegNr.���� -   
 ��Name$
 TextBoxREGNR��$��0������  �� Path$ Registernummer� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL��� $��1��$��Jahrgang���� -   $
 TextBoxJAHRGANG��$��1���� $��2��$
��Name���� -   $
 TextBoxNAME��$��2���� $��3��$��Vorname���� -   $
 TextBoxVORNAME��$��3���� $��4��$��Bezeichnung���� -   $
 TextBoxBezeichnung��$��4���� $��0��$��1�� ��%I   '��       �� " ��.���  � ��$ 5,0,0,0q���  � ��$	 180������ " ��.���  � ��$ 10,20,10,10q���  � ��$ Right=���  �@��Orientation$ 
Horizontal=�.+��� -    ��Name$ ButtonOk�� �� 	IsDefault . $��Projekt Hinzufügen.���� -   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��