   M S B A M L   `   `   `  ���� H  DlopstaKANZLEI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:lopstaKANZLEIlopstaKANZLEI  (    "lopstaKANZLEI.DialogWindowSettings   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:lopstaKANZLEI       � Title$  Einstellungen��$	��800�� � Topmost .  � SizeToContent$ Height=� � 
ResizeMode$ NoResize=�.���  � DataContext �� *AppSettings+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL� �� Mode$ OneWay=�	 �� UpdateSourceTrigger$	 Explicit=�
 � 	Resources
 ��%    ����  �� 
TargetType" �.���  �� Property � �� �� Value$ 10,20,10,10q� � ColumnDefinitions �� $	��150 ���  � RowDefinitions �� $	��410 ��� $��44 �.+��� $��0��$��0��
 ��%2   '��       �� " ��.���  � ��$ 0,0,0,5q����� " ��.���  � ��$ 0,15,0,0q���  �@��Orientation$ Vertical=�.+��� -    ��Name$ ButtonSeite001��$��Einstellungen���� -   $ ButtonSeite002��$��Lizenz��� -    �Name$ GridPage001��$��1��$��0��$y�Visible=�
  �� Source�� $% DictionarySettingsFormular.xaml?�%     �� $��1* �$	��130��$	��180���� $��2* ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $��0 ��� $
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
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Ordner - Akten���� -    ��Name$ TextBoxAKTEN��$��0������  �� Path$ PfadProjekte�$ OneWay=�$	 Explicit=��� -   $ ButtonAKTEN��$��0��$	������ $��1��$��Ordner - Rechnungen���� -   $ TextBoxRECHNUNGEN��$��1������ $ PfadRechnungen�$ OneWay=�$	 Explicit=��� -   $ ButtonRECHNUNGEN��$��1��$	������ $��2��$��Ordner Textbausteine���� -   $ TextBoxTEXTBAUSTEINE��$��2������ $ PfadTextbausteine�$ OneWay=�$	 Explicit=��� -	   $ ButtonTEXTBAUSTEINE��$��2��$	������ $��3��$��Ordner Briefköpfe���� -
   $ TextBoxBRIEFKOPF��$��3������ $ PfadBriefkoepfe�$ OneWay=�$	 Explicit=��� -   $ ButtonBRIEFKOPF��$��3��$	������ $��4��$��Ordner Word-Vorlagen���� -   $ TextBoxWORD��$��4������ $ PfadVorlagenWord�$ OneWay=�$	 Explicit=��� -   $ 
ButtonWORD��$��4��$	������ $��5��$��Ordner Excel-Vorlagen���� -   $ TextBoxEXCEL��$��5������ $ PfadVorlagenExcel�$ OneWay=�$	 Explicit=��� -   $ ButtonEXCEL��$��5��$	������ $��6��$��Ordner Andere-Vorlagen���� -   $ TextBoxANDERE��$��6������ $ PfadVorlagenAndere�$ OneWay=�$	 Explicit=��� -   $ ButtonAndere��$��6��$	������ $��7��$��Ordner Vollmachten���� -   $ TextBoxVollmachten��$��7������ $ PfadVorlagenVollmachten�$ OneWay=�$	 Explicit=��� -   $ ButtonVollmachten��$��7��$	������ $��8��$��Ordner Formulare���� -   $ TextBoxFormulare��$��8������ $ PfadVorlagenFormulare�$ OneWay=�$	 Explicit=��� -   $ ButtonFormulare��$��8��$	������ $��9��$��mehrere Benutzer Modus���� -    ��Name$ CheckBoxIsMultiUser��$��9�� d� 	IsChecked �� *IsMultiUser+$ OneWay=�$	 Explicit=�.��an/aus�� -    ��Name$ 	LabelUser��$��10��$��Benutzer (Verzeichnis)���� -   $ TextBoxUSER��$��10������ $ PfadBenutzer�$ OneWay=�$	 Explicit=��� -   $ 
ButtonUSER��$��10��$	������ -   $ LabelOverridesSettings��$��11��$��Benutzereinstellungen���� -   $# CheckBoxUserOverridesSettings��$��11�� �� *BenutzerUeberschreibtSettings+$ OneWay=�$	 Explicit=�.�� an (Benutzer) / aus (Standard)�� -   $ LabelFormatAktenzeichen��$��12��$��Aktenzeichen Format���� -    ��Name$  ComboBoxFORMATAKTENZEICHEN��$��12��.@��� $��YY-00���� $��YY-000���� $��YY-0000�� �� 
IsSelected . �� $��YY-00000���� $��YYYY-00���� $��YYYY-000���� $��	YYYY-0000���� $��
YYYY-00000���� $��00-YY���� $��000-YY���� $��0000-YY���� $��00000-YY���� $��00-YYYY���� $��000-YYYY���� $��	0000-YYYY���� $��
00000-YYYY���� $��00���� $	��000���� $
��0000���� $��00000���� -   $ LabelAutoSave��$��13��$��automatisch speichern���� -   $ CheckBoxAutoSave��$��13�� �� *
AutoSave+$ OneWay=�$	 Explicit=�.��an/aus�� -    $ ButtonSTANDARDWERTE002��$��1��$��14��$,��&Auf Voreinstellungen zurücksetzen ...��$��Stretch=����� " ��.���  � ��$
 Auto����  � ��$ 0,7,0,0q���  � ��$ Center=�� -!   $ GridPage002��$��1��$��0��$y�Hidden=�
 �� $% DictionarySettingsFormular.xaml?�%     ��  �� $
��Auto ��� $
��Auto �.+�,� $��0��$��0��.��/� �� $��0��$��1��$��Center=��� -"    ��Name$ HyperlinkLostaWebsite��.�https://www.lopsta.de�� $��1��$��1��
 ��%I   '��       �� " ��.���  � ��$ 5,0,0,0q���  � ��$	 180������ " ��.���  � ��$ 10q���  � ��$ Right=���  �@��Orientation$ 
Horizontal=�.+��� -#   $ ButtonOk�� �� 	IsDefault . $��Übernehmen.���� -$   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��