   M S B A M L   `   `   `  ���� [  WlopstaControlAdressenVerzeichnis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:lopstaControlAdressenVerzeichnis lopstaControlAdressenVerzeichnis  B    <lopstaControlAdressenVerzeichnis.UserControlGeschaeftsstelle   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:lopstaControlAdressenVerzeichnis     .��� -     �Name$  GridCONTROL������  �� 
TargetType" � � 	Resources ��%     � ColumnDefinitions ��  � RowDefinitions �� $	��120 ��� $	��340 ��� $��40 �.+�� -   $  GridFORMULAR000������ " �.���  �� Property � �� �� Value$ 3,3,3,10q� ��%6  '��       '�� l     �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=���  � {� .   �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Gericht/Behörde���� -    ��Name$ TextBoxSTELLE��$��0������  �� Path$ Label�	 �� Mode$	 OneTime=�
 �� UpdateSourceTrigger$
 Explicit=��� $��1��$��Aktenzeichen���� -   $ TextBoxAKTENZEICHEN��$��1������ $ Aktenzeichen�$	 OneTime=�$
 Explicit=��� $��2��$��Betreff���� -   $ TextBoxBETREFF��$��2������ $ Betreff�$	 OneTime=�$
 Explicit=��� $��0��$��1������ " ��.���  � ��$ 0,0,0,0q�  �� MergedDictionaries   Key��  �� �� lopstaTabItemHeader  " ��.���  � ��$	 150����  � ��$ 26����  �@��Orientation$ 
Horizontal=��� " ��.���  � ��$ Center=�%
   '��       .@��� ����   lopstaTabItemHeader#��[ .+��� �� $�Name und Telefon��.��� -   $  GridFORMULAR001��$��0��$��0������ " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q� �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Bezeichnung���� -   $ TextBoxBEZEICHNUNG��$��0������ $ Bezeichnung�$	 OneTime=�$
 Explicit=��� $��1��$��Ansprechpartner*in���� -   $ TextBoxANSPRECHPERSON��$��1������ $ Ansprechpartner�$	 OneTime=�$
 Explicit=��� $��2��$��Zimmer���� -	   $ TextBoxZIMMER��$��2������ $ Vorname�$	 OneTime=�$
 Explicit=��� $��3���� $��4��$��Telefon (Durchwahl)���� -
   $ TextBoxTELEFON��$��4������ $ Telefon�$	 OneTime=�$
 Explicit=��� $��5��$	��Fax���� -   $ 
TextBoxFAX��$��5������ $	 Fax�$	 OneTime=�$
 Explicit=��� $��6��$��Email���� -   $ TextBoxEMAIL��$��6������ $ Email�$	 OneTime=�$
 Explicit=��� -    ��Name$! StackPanelUserControlBUTONS��$��0��$��2��$y�Visible=� ��%I   '��       �� " ��.���  � ��$ 5,0,0,0q���  � ��$	 180������ " ��.���  � ��$ 10q���  � ��$ Right=���  �@��Orientation$ 
Horizontal=�.+��� -    ��Name$ ButtonOk�� �� 	IsDefault . $��Übernehmen.���� -   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��