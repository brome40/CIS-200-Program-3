// Program 3
// CIS 200-50
// Fall 2021
// Due: 11/15/2021
// By: 5342897

// File: Prog2Form.cs
// This class creates the main GUI for Program 3. It provides a
// File menu with About, Exit, Open, and Save As items, an Insert menu with Address and
// Letter items, and a Report menu with List Addresses and List Parcels
// items.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv; //the UserParcelView instance
        private BinaryFormatter formatter = new BinaryFormatter(); //the object for serializing in binary format
        private FileStream output; //stream to write to output file 
        private BinaryFormatter fileReader = new BinaryFormatter(); //reads from serialized file
        private FileStream input; //stream from opened file

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Program 3{NL}By: 5342897{NL}CIS 200{NL}Fall 2021",
                "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted
                }
               else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This report is generated without using a StringBuilder, just to show an
            // alternative approach more like what most students will have done
            // Method AppendText is equivalent to using .Text +=

            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            reportTxt.Clear(); // Clear the textbox
            reportTxt.AppendText("Parcels:");
            reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            reportTxt.AppendText(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                reportTxt.AppendText(p.ToString());
                reportTxt.AppendText(NL);
                reportTxt.AppendText("------------------------------");
                reportTxt.AppendText(NL);
                totalCost += p.CalcCost();
            }

            reportTxt.AppendText(NL);
            reportTxt.AppendText($"Total Cost: {totalCost:C}");

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        //Open Menu Item 
        //Precondition: open menu button is clicked
        //Postcondition: upv instance is loaded from serialized file
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; //result of open dialog box
            string fileName;     //string containing file name

            using (OpenFileDialog fileSelecter = new OpenFileDialog()) 
            {
                result = fileSelecter.ShowDialog(); //receive result of dialog box
                fileName = fileSelecter.FileName;   //name of file selected in dialog box
            }

            if (result == DialogResult.OK)
            {
                try
                {
                    input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    upv = (UserParcelView) fileReader.Deserialize(input);
                }
                catch (IOException)                   //catch error opening selected file
                {
                    MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SerializationException)        //catch serialization error
                {
                    input.Close(); //close stream
                    MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Save As Menu Item
        //Precondition: save as menu button is clicked
        //Postcondition: upv instance is serialized to .dat file
        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; //result of save dialog box 
            string fileName;     //string containing the file name

            using (SaveFileDialog fileSelecter = new SaveFileDialog()) 
            {
                fileSelecter.CheckFileExists = false; //allows users to create new file 
                result = fileSelecter.ShowDialog();   //receive result of dialog box
                fileName = fileSelecter.FileName;     //name of file selected in dialog box
            }
            
            if (result == DialogResult.OK)
            {
                try
                {
                    output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    formatter.Serialize(output, upv); //serialize the upv object 
                }
                catch (IOException)                   //catch error opening selected file
                {
                    MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SerializationException)        //catch serialization error
                {
                    MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Edit Address Menu Item
        //Precondition: edit address menu item is clicked
        //Postcondition: a dialog box is opened to let the user select an address,
        //               then another dialog box is opened allowing them to edit the properties
        //               of that address. These changes are made to the original address object within the upv.
        private void EditAddressMenuItem_Click(object sender, EventArgs e)
        {
            ChooseAddressForm chooseAddressForm; //the choose form dialog box 
            DialogResult result;               //the result of the dialog box

            if (upv.AddressCount < ChooseAddressForm.MIN_ADDRESSES) // Make sure addresses exist
            {
                MessageBox.Show("Need at least " + ChooseAddressForm.MIN_ADDRESSES + " address to edit.",
                    "Addresses Error");
                return; // Exit now since there are no existing addresses to edit
            }

            chooseAddressForm = new ChooseAddressForm(upv.AddressList); //pass the address list to the form 
            result = chooseAddressForm.ShowDialog();                    //dialog box opens and waits for result

            if (result == DialogResult.OK) //choose address form returns OK
            {
                Address selectedAddress = upv.AddressAt(chooseAddressForm.SelectedIndex); //selected address to edit 
                
                //Create Address Form and fill fields with selected address properties
                AddressForm addressForm = new AddressForm();
                addressForm.AddressName = selectedAddress.Name;
                addressForm.Address1 = selectedAddress.Address1;
                addressForm.Address2 = selectedAddress.Address2;
                addressForm.City = selectedAddress.City;
                addressForm.State = selectedAddress.State;
                addressForm.ZipText = selectedAddress.Zip.ToString();

                result = addressForm.ShowDialog(); //address form dialog box appears

                if (result == DialogResult.OK) //address form returns OK
                {
                    //updated values are assigned to the original address object
                    selectedAddress.Name = addressForm.AddressName;
                    selectedAddress.Address1 = addressForm.Address1;
                    selectedAddress.Address2 = addressForm.Address2;
                    selectedAddress.City = addressForm.City;
                    selectedAddress.State = addressForm.State;
                    selectedAddress.Zip = int.Parse(addressForm.ZipText);
                }
            }
        }
    }
}