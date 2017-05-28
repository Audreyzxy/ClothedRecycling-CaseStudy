using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLL
    {
        public BLL()
        {
        }


        public int AllocateRecipientBLL(string[] strArrUpdate)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.AllocateRecipientDAL(strArrUpdate);
            return output;
        }
        public int SignUpBLL(UserMaster objUserMaster)
        {
            int output;
            DAL objDal = new DAL();
            output = objDal.SignUpDAL(objUserMaster);

            return output;
        }

        public UserMaster SignInBLL(UserMaster objUserMaster)
        {
            UserMaster objUser = new UserMaster();
            DAL objDal = new DAL();
            objUser = objDal.SignInDAL(objUserMaster);

            return objUser;
        }

        public int GiveDonationBLL(Donation objDonation)
        {
            DAL objDal = new DAL();
            int output;
            output = objDal.GiveDonationDAL(objDonation);

            return output;

        }

        public int RegisterRecepientBLL(Recipient objRecipient)
        {
            DAL objDal = new DAL();
            int output;
            output = objDal.RegisterRecipientDAL(objRecipient);
            return output;
        }


        public DataSet GetDonationsDataBLL()
        {
            DataSet dsDonationsData = new DataSet();
            DAL objDal = new DAL();

            dsDonationsData = objDal.GetDonationsDataDAL();// call GetDonationsDataDAL method of DAL

            return dsDonationsData;
        }


        public int DeleteDonationBLL(string DonationID)
        {
            int output;
            DAL objDal = new DAL();

            output = objDal.DeleteDonationDAL(DonationID);// call DeleteDonationDAL method of DAL
            return output;
        }

        public List<ChartData> GetDataAnalyticsBLL()
        {
            List<ChartData> output;
            DAL objDal = new DAL();

            output = objDal.GetDataAnalyticsDAL();// call DeleteDonationDAL method of DAL
            return output;

        }


    }
}
