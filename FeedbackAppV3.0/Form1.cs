using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using static FeedbackAppV3._0.Crypto;

namespace FeedbackAppV3._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestEncryption_Click(object sender, EventArgs e)
        {
            var original = "Here is some data to encrypt";

            using (var myRijndael = new RijndaelManaged())
            {

                myRijndael.GenerateKey();
                myRijndael.GenerateIV();
                // Encrypt the message
                var encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);
                // Decrypt the message
                var roundTrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);
                // Show the process
                MessageBox.Show(@"Original: " + original);
                var message = "";
                var keyMessage = "";
                var IVMessage = "";
                foreach (var character in encrypted)
                {
                    message += character;
                }

                foreach (var keyPart in myRijndael.Key)
                {
                    keyMessage += keyPart;
                }

                foreach (var IVPart in myRijndael.IV)
                {
                    IVMessage += IVPart;
                }

                MessageBox.Show(@"Key: " + keyMessage);
                MessageBox.Show(@"IV: " + IVMessage);
                MessageBox.Show(@"Encrypted Message: " + message);
                MessageBox.Show(@"Round Trip: " + roundTrip);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
