   M S B A M L   `   `   `  ���� [  WlopstaControlAdressenVerzeichnis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:lopstaControlAdressenVerzeichnis lopstaControlAdressenVerzeichnis  9    3lopstaControlAdressenVerzeichnis.UserControlPolizei   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:lopstaControlAdressenVerzeichnis     .��� -     �Name$  GridCONTROL������  �� 
TargetType" � � 	Resources ��%     � ColumnDefinitions ��  � RowDefinitions �� $	��410 ��� $��40 �.+��� $��0��$��0������ " ��.���  �� Property � �� �� Value$ 0,0,0,0q�  �� MergedDictionaries   Key��  �� �� lopstaTabItemHeader  " ��.���  � ��$	 150����  � ��$ 26����  �@��Orientation$ 
Horizontal=��� " ��.���  � ��$ Center=�%
   '��       .@��� ����   lopstaTabItemHeader#��[ .+��� �� $�Bezeichnung und Telefon��.��� -   $  GridFORMULAR001��$��0��$��0������ " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q� �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$
��Name���� -    ��Name$ TextBoxNAME��$��0������ 	 �� Path$
	 Name�
 �� Mode$
 OneTime=��� $��1��$��Zusatz���� -   $ TextBoxZUSATZ��$��1������ $	 Zusatz�$
 OneTime=��� $��2���� $��3��$��Telefon���� -   $ TextBoxTELEFON��$��3������ $	 Telefon�$
 OneTime=� �� UpdateSourceTrigger$ Explicit=��� $��4��$	��Fax���� -   $ 
TextBoxFAX��$��4������ $		 Fax�$
 OneTime=�$ Explicit=��� $��5��$��Email���� -   $ TextBoxEMAIL��$��5������ $	 Email�$
 OneTime=�$ Explicit=��� $��6���� $��7��$��Internet���� -   $ TextBoxINTERNET��$��7������ $	 Internet�$
 OneTime=�$ Explicit=��� ���� #��[ .+��� �� $�	Anschrift��.��� -	   $  GridFORMULAR002��$��0��$��0������ " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q� �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Hausanschrift��$��2���� $��1��$��Strasse, Nr.���� -
   $ TextBoxSTRASSE��$��1������ $	 Strasse�$
 OneTime=�$ Explicit=��� $��2��$��Postleitzahl���� -   $ TextBoxPOSTLEITZAHL��$��2������ $	 Postleitzahl�$
 OneTime=�$ Explicit=��� $��3��$	��Ort���� -   $ 
TextBoxORT��$��3������ $		 Ort�$
 OneTime=�$ Explicit=��� $��4��$��
Bundesland���� -   $ TextBoxLAND��$��4������ $
	 Land�$
 OneTime=�$ Explicit=��� $��5���� $��6��$��Postfach��$��2���� $��7��$��Postfach���� -   $ TextBoxPOSTFACH��$��7������ $	 Postfach�$
 OneTime=�$ Explicit=��� $��8��$��Postleitzahl (Postfach)���� -   $! TextBoxPOSTLEITZAHLPOSTFACH��$��8������ $	 PostleitzahlPostfach�$
 OneTime=�$ Explicit=��� ���� #��[ .+��� �� $�Betreff��.��� -   $  GridFORMULAR004��$��0��$��0������ " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q� �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Vorgangsnummer���� -   $ TextBoxAKTENZEICHEN��$��0������ $	 Aktenzeichen�$
 OneTime=�$ Explicit=��� $��1���� $��2��$��Betreff (1. Zeile)���� -   $ TextBoxBETREFF001��$��2������ $	 
Betreff001�$
 OneTime=�$ Explicit=��� $��3��$��Betreff (2. Zeile)���� -   $ TextBoxBETREFF002��$��3������ $	 
Betreff002�$
 OneTime=�$ Explicit=��� $��4��$��Betreff (3. Zeile)���� -   $ TextBoxBETREFF003��$��4������ $	 
Betreff003�$
 OneTime=�$ Explicit=��� $��5��$��Betreff (4. Zeile)���� -   $ TextBoxBETREFF004��$��5������ $	 
Betreff004�$
 OneTime=�$ Explicit=��� -    ��Name$! StackPanelUserControlBUTONS��$��0��$��1��$y�Visible=� ��%I   '��       �� " ��.���  � ��$ 5,0,0,0q���  � ��$	 180������ " ��.���  � ��$ 10q���  � ��$ Right=���  �@��Orientation$ 
Horizontal=�.+��� -    ��Name$ ButtonOk�� �� 	IsDefault . $��Übernehmen.���� -   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��