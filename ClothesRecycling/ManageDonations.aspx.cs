using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClothesRecycling
{
    public partial class ManageDonations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

            }
        }

        protected void BindGrid()
        {
            try
            {
                BLL objBLL = new BLL();
                DataSet dsDonationsData = new DataSet();

                dsDonationsData = objBLL.GetDonationsDataBLL();

                gvManageDonations.DataSource = dsDonationsData;
                gvManageDonations.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void gvManageDonations_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int output = 0;
            BLL objBLL = new BLL();
            GridViewRow row = gvManageDonations.Rows[e.RowIndex];
            Label lblDonationId = row.FindControl("lblDonationID") as Label;
            DropDownList ddlStatus = row.FindControl("ddlStatus") as DropDownList;
            DropDownList ddlRecipient = row.FindControl("ddlRecipient") as DropDownList;
            string[] strArrUpdate = new string[4];

            strArrUpdate[0] = ddlRecipient.SelectedValue;
            strArrUpdate[1] = ddlStatus.SelectedValue;
            strArrUpdate[2] = ddlRecipient.SelectedItem.Text;
            strArrUpdate[3] = lblDonationId.Text;

            output = objBLL.AllocateRecipientBLL(strArrUpdate);
            if (output > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "updatedonation", "alert('Record update successfully');", true);

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('Error Occurred');", true);
            }

            gvManageDonations.EditIndex = -1;
            BindGrid();

        }

        protected void gvManageDonations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int output = 0;
            GridViewRow row = gvManageDonations.Rows[e.RowIndex];
            Label lblDonationId = (Label)row.FindControl("lblDonationId");

            string DonationID = (lblDonationId != null && lblDonationId.Text != null && !string.IsNullOrEmpty(lblDonationId.Text)) ? lblDonationId.Text.Trim() : string.Empty;

            BLL objBLL = new BLL();
            output = objBLL.DeleteDonationBLL(DonationID);

            if (output > 0)
                ClientScript.RegisterStartupScript(this.GetType(), "deleteDonations", "alert('Record Deleted Successfully')", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "deleteDonations", "alert('Error occurred')", true);

            BindGrid();

        }

        protected void gvManageDonations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvManageDonations.EditIndex = -1;
            BindGrid();
        }

        protected void gvManageDonations_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvManageDonations.EditIndex = e.NewEditIndex;
            BindGrid();
        }
    }

}