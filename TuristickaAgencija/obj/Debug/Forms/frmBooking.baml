   M S B A M L   `   `   `  ����M  ITuristickaAgencija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TuristickaAgencija.FormsTuristickaAgencija.Forms  5   	   )    #TuristickaAgencija.Forms.frmBooking   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TuristickaAgencija.Forms     5   	   -   5          �Name$  frmBooking1��5   	    � Title$ Add\Update Booking��5   	   $	��650��6$   $	��700��61   .��5	      � ��5
   
   �� 5       �� ImageSource$Q K/TuristickaAgencija;component/Graphics/blue_background_picture_2_169441.jpg��6   .+�5   
   �� -   5         ��Name$ lblEmployee��5      $��Emplyee:��6%   $
��Left=�68   $��	54,39,0,0q�6S   $	��Top=�6f   $	��250��6~   �� 5   
   -   5        $ lblCustomer��5      $��	Customer:��6%   $
��Left=�69   $��	54,86,0,0q�6T   $	��Top=�6g   $	��250��6   �� 5   
   -   5        $ lblNumberOfPassengers��5      $��Number of passengers:��6/   $
��Left=�6O   $��
54,138,0,0q�6j   $	��Top=�6~   $	��250��6�   �� 5   
   -   5        $ lblHotel��5      $��Hotel:��6"   $
��Left=�63   $��
54,190,0,0q�6N   $	��Top=�6b   $	��250��6z   �� 5   
   -   5        $ lblReservationDate��5      $��Reservation date:��6-   $
��Left=�6I   $��
54,272,0,0q�6d   $	��Top=�6x   $	��250��6�   �� 5   
   -   5        $ lblTransport��5      $��
Transport:��6&   $
��Left=�6;   $��
54,347,0,0q�6V   $	��Top=�6j   $	��250��6�   �� 5   
   -   5        $ lblTotalPrice��5      $��Total price:��6'   $
��Left=�6>   $��
54,420,0,0q�6Y   $	��Top=�6m   $	��250��6�   �� 5   
   -	   5         ��Name$ cbxEmployee��5       �� DisplayMemberPath$ Employee��6(    �� SelectedValuePath$ 
EmployeeID��6E   $
��Left=�6d   $��
392,39,0,0q�6   $	��Top=�6�   $	��250��6�   $��26��6�   �� 5   
   -
   5        $ cbxCustomer��5      $ Customer��6(   $ 
CustomerID��6E   $
��Left=�6d   $��
392,86,0,0q�6   $	��Top=�6�   $	��250��6�   $��26��6�   �� 5   
   -   5         ��Name$ txtNumberOfPassengers��5      $
��Left=�61   $��26��6L   $��392,138,0,0q�6X    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��250��6�   �� 5   
   -   5        $ cbxHotel��5      $ Hotel��6%   $ HotelID��6?   $
��Left=�6[   $��392,190,0,0q�6v   $	��Top=�6�   $	��250��6�   $��26��6�   �� 5   
   -   5        $ cbxTransport��5      $ Type of transport��6)   $ TransportID��6O   $
��Left=�6o   $��392,347,0,0q�6�   $	��Top=�6�   $	��250��6�   $��26��6�   �� 5   
   -   5        $ txtTotalPrice��5      $
��Left=�6)   $��26��6D   $��392,420,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��250��6�   �� 5   
   -   5        	 ��Name$	 btnSave��5      $
��Save��6"   $
��Left=�61   $��
54,540,0,0q�6L   $	��Top=�6`   $	��170��6x   $��30��6�   6�   �� 5   
   -   5        $	 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��472,540,0,0q�6P   $	��Top=�6e   $	��170��6}   $��30��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 
dpDatumRez��5       J� 	AllowDrop .    SelectedDateFormat$
 Long=�6:   $
��Left=�6T   $��392,272,0,0q�6o   $	��Top=�6�   $	��250��6�   $��26��6�   5      5      