   M S B A M L   `   `   `  ����C  ?Lab8_SQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Banking_AppBanking_App  5   	       Banking_App.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Banking_App     5   	     � Title$  
MainWindow��5   	   $��745.291��6   $��528.075��6-   .��5	      � $��0,0,0,-3q�6   $	��718��6   $��Bottom=�6'   .+�5
      �� -   5         ��Name$ saveNewButton��5
      $��Save New��6"   $
��Left=�65   $��435,143,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5      -   5        $ 
saveButton��5      $
��Save��6   $��260,143,190,0q�6.   $	��Top=�6E   6]   �� 5      -   5        $ deleteButton��5      $��Delete ��6!   $
��Left=�63   $��338,146,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5      -   5         ��Name$ displayListBox��5      $
��Left=�6$   $��95��6?   $��	18,21,0,0q�6K   $	��Top=�6^   $	��470��6v   6�   �� 5      -   5         ��Name$ balanceTextBox��5      $
��Left=�6$   $��23��6?   $��120,236,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5      -   5        $ accountNumberTextBox��5      $
��Left=�6*   $��23��6E   $��120,144,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   .��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.822Q�6   T� 5      5      .��5      5      �� 5      -   5        $ firstNameTextBox��5      $
��Left=�6&   $��23��6A   $��120,177,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��120��6�   �� 5      -   5        $ lastNameTextBox��5      $
��Left=�6%   $��23��6@   $��335,174,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��137��6�   �� 5      -	   5        $ emailTextBox��5      $
��Left=�6"   $��23��6=   $��307,203,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��165��6�   �� 5      -
   5        $ phoneTextBox��5      $
��Left=�6"   $��23��6=   $��120,208,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5      -   5         ��Name$ label��5   
   $��Account Number��6   $
��Left=�62   $��
10,143,0,0q�6M   $	��Top=�6a   $	��100��6y   �� 5      -   5        $ 
label_Copy��5   
   $��
First Name��6   $
��Left=�63   $��
10,174,0,0q�6N   $	��Top=�6b   $��78��6z   �� 5      -   5        $ label_Copy1��5   
   $��	Last Name��6   $
��Left=�63   $��260,171,0,0q�6N   $	��Top=�6c   $��70��6{   �� 5       -   5        $ label_Copy2��5    
   $��Email��6   $
��Left=�6/   $��260,205,0,0q�6J   $	��Top=�6_   $	��100��6w   �� 5!      -   5        $ label_Copy3��5!   
   $��Phone��6   $
��Left=�6/   $��
10,205,0,0q�6J   $	��Top=�6^   $	��100��6v   �� 5"      -   5        $ label_Copy5��5"   
   $��Balance��6   $
��Left=�61   $��
10,236,0,0q�6L   $	��Top=�6`   $��92��6x   �� 5#      -   5        $ listBox��5#      $
��Left=�6   $��
18,0,0,220q�68   $	��470��6L   $	��146��6X   $��Bottom=�6e   6�   �� 5$      -   5        $ DeleteTransactionButton��5$      $��Delete��6,   $
��Left=�6=   $��352,580,0,0q�6X   $	��Top=�6m   $��75��6�   $ 0.5,0.5&�6�   z�5%      V� 5&      .~�5'      �� �� 5(      �� 5)      $ 1.028Q�6   T� 5*      5+      5-      �� 5.      -   5        $ SaveTransactionButton��5.      $
��Save��6*   $
��Left=�69   $��352,534,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5/      -   5        $ NewTransactionButton��5/      $	��New��6)   $
��Left=�67   $��352,623,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 50      -   5        $ transactionNumberTextBox��50      $
��Left=�6.   $��23��6I   $��145,526,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��144��6�   �� 51      -   5        $ transactionDateTextBox��51      $
��Left=�6,   $��23��6G   $��145,574,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��144��6�   �� 52      -   5        $ amountTextBox��52      $
��Left=�6#   $��23��6>   $��145,624,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��144��6�   �� 53      -   5        $ transactionNumber��53   
   $��Transaction Number��6%   $
��Left=�6B   $��
23,526,0,0q�6]   $	��Top=�6q   �� 54      -   5        $ transactionDateLabel��54   
   $��Transaction Date��6(   $
��Left=�6C   $��
28,574,0,0q�6^   $	��Top=�6r   $	��117��6�   �� 55      -   5        $ amountLabel��55   
   $��Amount��6   $
��Left=�60   $��
23,624,0,0q�6K   $	��Top=�6_   $ -1.585,-0.512&�6w   $	��117��6�   �� 56      -   5        $ label1��56   
   $��Customer Transaction��6   $
��Left=�69   $��
28,326,0,0q�6T   $	��Top=�6h   �� 57      -   5        $ label2��57   
   $��Customer Accounts��6   $
��Left=�66   $��	19,-5,0,0q�6Q   $	��Top=�6d   �� 58      -   5        $ label3��58   
   $�� ��6   $
��Left=�6%   $��132,678,0,0q�6@   $	��Top=�6U   �� 59      -   5        $ errorTextBox��59      $
��Left=�6"   $��235,672,0,6q�6=   $
 Wrap=�6R   $	��248��6f   5;      5<      