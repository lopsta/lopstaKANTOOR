   M S B A M L   `   `   `  ���� [  WlopstaControlAdressenVerzeichnis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:lopstaControlAdressenVerzeichnis lopstaControlAdressenVerzeichnis  ?    9lopstaControlAdressenVerzeichnis.UserControlJustizadresse   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:lopstaControlAdressenVerzeichnis     .��� -     �Name$  GridCONTROL������  �� 
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
��Auto ��� $
��Auto �.+��� $��0��$��	xJustizID���� -    ��Name$ TextBoxXJUSTIZID��$��0��{�.  ���� 	 �� Path$	 	xJUstizID�
 �� Mode$
 OneTime=� �� UpdateSourceTrigger$ Explicit=��� $��1��$
��Name���� -   $ TextBoxNAME��$��1������ $
	 Name�$
 OneTime=��� $��2��$��Zusatz���� -   $ TextBoxZUSATZ��$��2������ $	 Zusatz�$
 OneTime=��� $��3���� $��4��$��Telefon���� -   $ TextBoxTELEFON��$��4������ $	 Telefon�$
 OneTime=�$ Explicit=��� $��5��$	��Fax���� -   $ 
TextBoxFAX��$��5������ $		 Fax�$
 OneTime=�$ Explicit=��� $��6��$��Email���� -   $ TextBoxEMAIL��$��6������ $	 Email�$
 OneTime=�$ Explicit=��� $��7���� $��8��$��Internet���� -	   $ TextBoxINTERNET��$��8������ $	 Internet�$
 OneTime=�$ Explicit=��� ���� #��[ .+��� �� $�	Anschrift��.��� -
   $  GridFORMULAR002��$��0��$��0������ " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q� �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Hausanschrift��$��2���� $��1��$��Strasse, Nr.���� -   $ TextBoxSTRASSE��$��1������ $	 Strasse�$
 OneTime=�$ Explicit=��� $��2��$��Postleitzahl���� -   $ TextBoxPOSTLEITZAHL��$��2������ $	 Postleitzahl�$
 OneTime=�$ Explicit=��� $��3��$	��Ort���� -   $ 
TextBoxORT��$��3������ $		 Ort�$
 OneTime=�$ Explicit=��� $��4��$��
Bundesland���� -   $ TextBoxLAND��$��4������ $
	 Land�$
 OneTime=�$ Explicit=��� $��5���� $��6��$��Postfach��$��2���� $��7��$��Postfach���� -   $ TextBoxPOSTFACH��$��7������ $	 Postfach�$
 OneTime=�$ Explicit=��� $��8��$��Postleitzahl (Postfach)���� -   $! TextBoxPOSTLEITZAHLPOSTFACH��$��8������ $	 PostleitzahlPostfach�$
 OneTime=�$ Explicit=��� ���� #��[ .+��� �� $�Bankverbindung��.��� -   $  GridFORMULAR003��$��0��$��0������ " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q� �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Kontoinhaber���� -   $ TextBoxKONTOINHABER��$��0������ $	 Kontoinhaber�$
 OneTime=�$ Explicit=��� $��1��$
��Bank���� -   $ TextBoxBANK��$��1������ $
	 Bank�$
 OneTime=�$ Explicit=��� $��2��$
��IBAN���� -   $ TextBoxIBAN��$��2������ $
	 IBAN�$
 OneTime=�$ Explicit=��� $��3��$	��BIC���� -   $ 
TextBoxBIC��$��3������ $		 BIC�$
 OneTime=�$ Explicit=��� ���� #��[ .+��� �� $�Betreff��.��� -   $  GridFORMULAR004��$��0��$��0������ " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q� �� $��1* �$	��130��$	��180���� $��2* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Aktenzeichen���� -   $ TextBoxAKTENZEICHEN��$��0������ $	 Aktenzeichen�$
 OneTime=�$ Explicit=��� $��1���� $��2��$��Betreff (1. Zeile)���� -   $ TextBoxBETREFF001��$��2������ $	 
Betreff001�$
 OneTime=�$ Explicit=��� $��3��$��Betreff (2. Zeile)���� -   $ TextBoxBETREFF002��$��3������ $	 
Betreff002�$
 OneTime=�$ Explicit=��� $��4��$��Betreff (3. Zeile)���� -   $ TextBoxBETREFF003��$��4������ $	 
Betreff003�$
 OneTime=�$ Explicit=��� $��5��$��Betreff (4. Zeile)���� -   $ TextBoxBETREFF004��$��5������ $	 
Betreff004�$
 OneTime=�$ Explicit=��� -    ��Name$! StackPanelUserControlBUTONS��$��0��$��1��$y�Visible=� ��%I   '��       �� " ��.���  � ��$ 5,0,0,0q���  � ��$	 180������ " ��.���  � ��$ 10q���  � ��$ Right=���  �@��Orientation$ 
Horizontal=�.+��� -    ��Name$ ButtonOk�� �� 	IsDefault . $��Übernehmen.���� -   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��