   M S B A M L   `   `   `  ���� [  WlopstaControlAdressenVerzeichnis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:lopstaControlAdressenVerzeichnis lopstaControlAdressenVerzeichnis  ;    5lopstaControlAdressenVerzeichnis.UserControlDurchwahl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:lopstaControlAdressenVerzeichnis     .��� -     �Name$  GridCONTROL������  �� 
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
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Anrede���� -   $ TextBoxAnrede��$��0������ $ Anrede�$	 OneTime=�$
 Explicit=��� $��1��$��Dienstbezeichnung���� -   $ TextBoxDienstbezeichnung��$��1������ $ Dienstbezeichnung�$	 OneTime=�$
 Explicit=��� $��2��$
��Name���� -	   $ TextBoxNACHNAME��$��2������ $ Nachname�$	 OneTime=�$
 Explicit=��� $��3��$��Vorname���� -
   $ TextBoxVORNAME��$��3������ $ Vorname�$	 OneTime=�$
 Explicit=��� $��4��$��Titel���� -   $ TextBoxTITEL��$��4������ $ Titel�$	 OneTime=�$
 Explicit=��� $��5��$��Zimmer���� -   $ TextBoxZIMMER��$��5������ $ Vorname�$	 OneTime=�$
 Explicit=��� $��6���� $��7��$��Telefon (Durchwahl)���� -   $ TextBoxTELEFON��$��7������ $ DurchwahlTelefon�$	 OneTime=�$
 Explicit=��� $��8��$��Mobil (Durchwahl)���� -   $ TextBoxDURCHWAHLMOBIL��$��8������ $ DurchwahlMobil�$	 OneTime=�$
 Explicit=��� $��9��$	��Fax���� -   $ 
TextBoxFAX��$��9������ $	 Fax�$	 OneTime=�$
 Explicit=��� $��10��$��Email���� -   $ TextBoxEMAIL��$��10������ $ Email�$	 OneTime=�$
 Explicit=��� -    ��Name$! StackPanelUserControlBUTONS��$��0��$��2��$y�Visible=� ��%I   '��       �� " ��.���  � ��$ 5,0,0,0q���  � ��$	 180������ " ��.���  � ��$ 10q���  � ��$ Right=���  �@��Orientation$ 
Horizontal=�.+��� -    ��Name$ ButtonOk�� �� 	IsDefault . $��Übernehmen.���� -   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��