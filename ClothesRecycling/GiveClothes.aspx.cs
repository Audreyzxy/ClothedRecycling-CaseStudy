using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;
using System;
using RestSharp;
using RestSharp.Authenticators;

namespace ClothesRecycling
{
    public partial class GiveClothes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL objBll = new BLL();
            int output = 0;
            Donation objDonation = new Donation();
            objDonation.Name = txtName.Value;
            objDonation.UserEmail = txtEmail.Value;
            objDonation.Address = txtAddress.Value;

            // directly accessing the masterpage property LoggedInUserEmail to fill UserEmail object
            //objDonation.UserEmail = this.Master.LoggedInUserEmail;

            // pipe separation if both checkboxes checked
            if (chkReusable.Checked && chkNonReusable.Checked && chkNewClothes.Checked)
                objDonation.DonationType = chkReusable.Value + "|" + chkNonReusable.Value + "|" + chkNewClothes.Value;
            else if (chkReusable.Checked && chkNonReusable.Checked)
                objDonation.DonationType = chkReusable.Value + "|" + chkNonReusable.Value;
            else if (chkReusable.Checked && chkNewClothes.Checked)
                objDonation.DonationType = chkReusable.Value + "|" + chkNewClothes.Value;
            else if (chkNonReusable.Checked && chkNewClothes.Checked)
                objDonation.DonationType = chkNonReusable.Value + "|" + chkNewClothes.Value;
            else if (chkReusable.Checked)
                objDonation.DonationType = chkReusable.Value;
            else if (chkNonReusable.Checked)
                objDonation.DonationType = chkNonReusable.Value;
            else if (chkNewClothes.Checked)
                objDonation.DonationType = chkNewClothes.Value;

            objDonation.PickUpDate = dtPickupDate.Value;

            objDonation.Status = "New Request";

            output = objBll.GiveDonationBLL(objDonation);

            //If a row is affected then ie. Success condition will open a alert box for success else alert for error will be opened.
            if (output > 0)
            {
                SendThankYouNote(objDonation); // Calling SendThankYouNote function to send Thank you email to the person who donated  the clothes.
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Donation Submitted Successfully');window.location.href = 'GiveClothes.aspx';", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Error occurred');window.location.href = 'GiveClothes.aspx';", true);

            //ClientScript.RegisterStartupScript is used to call javascript function from the code behind side of the pages.
        }
        public static void SendThankYouNote(Donation objDonation)
        {
            try
            {
                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator = new HttpBasicAuthenticator("api", "key-3c546e44b01f7cd54c007e87d917eff7");// Replace with your api key
                RestRequest request = new RestRequest();
                request.AddParameter("domain",
                                    "sandbox27893ec53d79435381facd957b037788.mailgun.org", ParameterType.UrlSegment);//replace with your sandbox id
                request.Resource = "{domain}/messages";
                request.AddParameter("from", "Admin Recycling Clothes <postmaster@sandbox27893ec53d79435381facd957b037788.mailgun.org>");//default smtp login from sandbox  domain details.
                request.AddParameter("to", objDonation.Name + " <" + objDonation.UserEmail + ">");//send email to the person who submitted
                request.AddParameter("subject", "Thank You " + objDonation.Name);
                request.AddParameter("html", "<html><p>Thank you for Donating Clothes. You truly have made a difference.<br/><br/> Warm Regards,<br/> Admin Clothes Recycling</p></html>");// Br tag to break the line when needed.
                request.Method = Method.POST;
                IRestResponse resp = client.Execute(request);// Execute method sends email notification.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}