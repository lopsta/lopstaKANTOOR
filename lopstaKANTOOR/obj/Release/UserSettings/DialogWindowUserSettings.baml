   M S B A M L   `   `   `  ���� H  DlopstaKANZLEI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:lopstaKANZLEIlopstaKANZLEI  ,    &lopstaKANZLEI.DialogWindowUserSettings   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:lopstaKANZLEI       � Title$  Benutzereinstellungen��$	��450��$	��800��.���  � DataContext �� *User+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL� �� UpdateSourceTrigger$ Explicit=� �� Mode$ OneTime=� � 	Resources ��%    ����  �� 
TargetType" �.��� 	 �� Property	 � ��
 �� Value$
 10,20,10,10q� � ColumnDefinitions �� $	��150 ���  � RowDefinitions �� $	��350 ��� $��44 �.+��� $��0��$��0��$��0,0,0,0q� ��%2   '��       �� " ��.��� 	 � ��$
 0,0,0,5q����� " ��.��� 	 � ��$
 0,15,0,0q��� 	 �@��Orientation$
 Vertical=�.+��� -    ��Name$ ButtonSeite001��$��Benutzer���� -   $ ButtonSeite002��$��Pfade��� -    �Name$ GridPage001��$��1��$��0��$y�Visible=�$��10,0,0,0q�  �� Source�� $) #DictionaryUserSettingsFormular.xaml?�%     �� $��1* �$	��130��$	��180���� $��2* ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Anrede���� -    ��Name$ ComboBoxAnrede��$��0�� �� Text ��  �� Path$ Anrede�$ OneWay=�$ Explicit=�.@��� $
��Herr��
 � Tag$
 Herr���� $
��Frau��$
 Frau���� $��1��$��Nachname���� -    ��Name$ TextBoxNachname��$��1������ $ Nachname�$ OneWay=�$ Explicit=��� $��2��$��Vorname���� -   $ TextBoxVorname��$��2������ $ Vorname�$ OneWay=�$ Explicit=��� $��3��$��Titel���� -   $ TextBoxTitel��$��3������ $ Titel�$ OneWay=�$ Explicit=�� -   $ GridPage002��$��1��$��0��$y�Hidden=�$��10,0,0,0q� �� $) #DictionaryUserSettingsFormular.xaml?�%     �� $��1* �$	��130��$	��180���� $��2* ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Ordner Akten���� -	   $ TextBoxAKTEN��$��0������ $ PathPROJEKTE�$ OneWay=�$ Explicit=��� -
   $ ButtonAKTEN��$��0��$	������ $��1��$��Ordner Rechnungen���� -   $ TextBoxRECHNUNGEN��$��1������ $ PathRECHNUNGEN�$ OneWay=�$ Explicit=��� -   $ ButtonRECHNUNGEN��$��1��$	������ $��2��$��Ordner Textbausteine���� -   $ TextBoxTEXTBAUSTEINE��$��2������ $ PathTEXTBAUSTEINE�$ OneWay=�$ Explicit=��� -   $ ButtonTEXTBAUSTEINE��$��2��$	������ $��3��$��Ordner Word-Vorlagen���� -   $ TextBoxWORD��$��3������ $ PathWORDVORLAGEN�$ OneWay=�$ Explicit=��� -   $ 
ButtonWORD��$��3��$	������ $��4��$��Ordner Excel-Vorlagen���� -   $ TextBoxEXCEL��$��4������ $ PathEXCELVORLAGEN�$ OneWay=�$ Explicit=��� -   $ ButtonEXCEL��$��4��$	������ -   $ ButtonSTANDARDWERTE002��$��1��$��5��$4��.Auf allgemeine Einstellungen zurücksetzen ...������ " ��.��� 	 � ��$	
 250���� 	 � ��$
 0,7,0,0q��� 	 � ��$
 Center=��� $��1��$��1�� ��%I   '��       �� " ��.��� 	 � ��$
 5,0,0,0q��� 	 � ��$	
 180������ " ��.��� 	 � ��$
 10q��� 	 � ��$
 Right=��� 	 �@��Orientation$
 
Horizontal=�.+��� -   $ ButtonOk�� �� 	IsDefault . $��Übernehmen.���� -   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��