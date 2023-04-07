// Program 3
// CIS 200-50
// Fall 2021
// Due: 11/15/2021
// By: 5342897

// File: ChooseAddressForm.cs
// This form allows the user to select an address from the
// list box and uses validation to ensure a selection is made.  

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class ChooseAddressForm : Form
    {
        public const int MIN_ADDRESSES = 1; // Minimum number of addresses needed

        private List<Address> addressList;  // List of addresses used to fill ListBox

        //Constructor
        //Precondtion:   at least one address exists to edit
        //Postcondition: the forms GUI is prepared to display
        public ChooseAddressForm(List<Address> addresses)
        {
            InitializeComponent();

            addressList = addresses;
        }

        //Load Event
        //Precondition:  GUI has been prepared by constructor 
        //Postcondition: the address list is used to populate the list box
        private void ChooseAddressForm_Load(object sender, EventArgs e)
        {
            foreach (Address a in addressList)
            {
                addressListBox.Items.Add(a.Name); //address added to list box
            }
        }

        //Cancel Button 
        //Precondition:  User pressed on cancelButton
        //Postcondition: Form closes
        private void CancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

        //Validating Event
        //Precondition:  focus shifting away from list box
        //Postcondition: if no item is selected, focus is locked and error appears
        private void AddressListBox_Validating(object sender, CancelEventArgs e)
        {
            if (addressListBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorIcon.SetError(addressListBox, "Select an address from the list!");
            }
        }

        //Validated Event
        //Precondition:  validating is successful 
        //Postcondition: error is cleared
        private void AddressListBox_Validated(object sender, EventArgs e)
        {
            errorIcon.SetError(sender as Control,"");
        }

        //Select Button Event
        //Precondition:  select button is clicked, validation is successful
        //Postcondition: OK is returned and dialog box closed
        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        //Selected Index Property
        internal int SelectedIndex
        {
            //Precondition:  a selection has been made
            //Postcondition: index of the selection is returned
            get
            {
                return addressListBox.SelectedIndex;
            }
        }
    }
}
