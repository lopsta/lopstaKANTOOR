   M S B A M L   `   `   `  ���� [  WlopstaControlAdressenVerzeichnis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:lopstaControlAdressenVerzeichnis lopstaControlAdressenVerzeichnis  E    ?lopstaControlAdressenVerzeichnis.DialogWindowAdresseHinzufuegen   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @local.clr-namespace:lopstaControlAdressenVerzeichnis       � Title$$  DialogWindowAdresseHinzufuegen��$	��750��$	��550�� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � SizeToContent$ Height=� � Topmost . .���  � 	Resources ��%    ����  �� 
TargetType" �.���  �� Property � �� �� Value$ 10q�	 � ColumnDefinitions	 �� 
 � RowDefinitions
 �� $	��456 ��� $��44 �.+��� ���� " �� ��%    .@��� -    ��Name$ TabItemJUSTIZADRESSEN��$��Justizadresse��.��G   AlopstaControlAdressenVerzeichnis.UserControlJustizadressenAuswahl  -     Name$$ UserControlSelectJUSTIZADRESSE���� -   $ TabItemANDERE��$��Andere��.��� ���� " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q�	 �� $��1* �$	��130��$	��180���� $��2* �
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Anrede���� -    ��Name$ TextBoxAllgemeinANREDE��$��0������  �� Path$ Anrede��� $��1��$
��Name���� -   $ TextBoxAllgemeinNAME��$��1������ $
 Name��� $��2��$��Vorname���� -   $ TextBoxAllgemeinVORNAME��$��2���� $��3��$��Titel���� -   $ TextBoxAllgemeinTITEL��$��3���� -   $ TabItemPOLIZEI��$��Polizei��.��� ���� " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q�	 �� $	��83* �$	��130��$	��180���� $��7* ��� $
��269* �
 �� $
��Auto �.+��� $��Bezeichnung��$��2��$��0,2,0,3q��� -	   $ TextBoxPolizeiNAME��$��2��$��0,2,2,3q����� $
 Name� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL��� -
   $ TabItemMANDANT��$��
Mandant*in��.��� ���� " � ��%  '��       '�� l     '��     '�� �    �� " ��.���  � ��$ 26����  � ��$ 0����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 0,2,2,2q���  � ��$ 2,0,2,0q���  � ��$ 1����  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 26����  � ��$ 26����  � ��$ 2����  � ��$ Center=���  � ��$ Segoe MDL2 Assets)���  � ��$ 18(��� " ��.���  � ��$ 1����  � ��$ 10q�	 �� $��1* �$	��130��$	��180���� $��2* �
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Anrede���� -   $ TextBoxMandantANREDE��$��0������ $ Anrede��� $��1��$
��Name���� -   $ TextBoxMandantNAME��$��1������ $
 Name� �� $ FindAncestor=�$ WindowL��� $��2��$��Vorname���� -   $ TextBoxMandantVORNAME��$��2���� $��3��$��Titel���� -   $ TextBoxMandantTITEL��$��3���� $��0��$��1�� ��%I   '��       �� " ��.���  � ��$ 5,0,0,0q���  � ��$	 180������ " ��.���  � ��$ 10q���  � ��$ Right=���  �@��Orientation$ 
Horizontal=�.+��� -    ��Name$ ButtonOk�� �� 	IsDefault . $��Adresse hinzufügen.���� -   $ ButtonCancel�� �� IsCancel . $��
Abbrechen.��