using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AtEaseWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAtEaseService" in both code and config file together.
    [ServiceContract]
    public interface IAtEaseService
    {

        //Register student
        [OperationContract]
        bool RegisterStudent(StudentClass s);
        //Checks if the student email is registered
        [OperationContract]
        bool IsStuRegistered(String Email);

        //Register merchant
        [OperationContract]
        bool RegisterMerchant(MerchantClass s);
        //checks if the merchant email is registered
        [OperationContract]
        bool IsMerchRegistered(String Email);

        //*******************PLEASE DO NOT PUT FUNCTIONS RANDOMLY, CHECK THE COMMENTS******************\\

        //Student Functions here.\\
        [OperationContract]
        int StudentLogin(string Email, string Password);

        [OperationContract]
        bool checkStudentActive(string email);

        [OperationContract]
        List<BookClass> GetHomeBooks();

        //Merchant Functions Here.\\
        [OperationContract]
        int MerchantLogin(string Email, string Password);

        [OperationContract]
        bool checkMerchantActive(string email);

        //Manager Functions Here.\\
        [OperationContract]
        int ManagerLogin(string Email, string Password);
        //
        [OperationContract]
        bool SearchBook(string SearchValue);
        //
        [OperationContract]
        BookClass GetBook(string book);
        //
        [OperationContract]
        List<ProductClass> GetProductMerchants(string isbn);
        //
        [OperationContract]
        MerchantClass GetMerchant(int merchid);
        //
        [OperationContract]
        ProductClass GetMerchProduct(string isbn, string merchID);

        [OperationContract]
        bool addtoQuote(QuotationClass Q);

        [OperationContract]
        string getStuNumber(string email);

        [OperationContract]
        List<QuotationClass> getQuoteInfo(string number);
        [OperationContract]
        bool removeFromQuote(string isbn, int merchID);
        [OperationContract]
        int GetMerchRating(int MerchID);
        [OperationContract]
        int GetMerchID(string Email);
        [OperationContract]
        List<ProductClass> AllMerchProducts(int MerchID);
        [OperationContract]
        bool EditMerchant(MerchantClass m, string email);
        [OperationContract]
        bool AddMerchProduct(ProductClass mbc);
        [OperationContract]
        bool IsNewMerchBook(string isbn, int merchID);

        [OperationContract]
        List<MerchantClass> GetAllMerchants();

        [OperationContract]
        bool removeMerchProduct(string isbn, int merchID);

        [OperationContract]
        bool SetMerchPrice(int price, string name, int merchID);
        [OperationContract]
        string getISBN(string name);
        [OperationContract]
        List<string> GetMerchReviews(int merchID);

        [OperationContract]
        bool setRating(int rating, string stuNum, int merch);

        [OperationContract]
        bool setReview(string rev, string stuNum, int merch);

        [OperationContract]
        bool setFeedback(FeedbackClass fb);

        [OperationContract]
        List<FeedbackClass> getAllFeedback(string stuNum);
        [OperationContract]
        bool setIsRated(string stuNummber, int merchId,int val);

        [OperationContract]
        int GetIsRated(int merchID, string stuNum);

        [OperationContract]
        bool reportMerchant(int merID);
        [OperationContract]
        bool removeMerchant(int merchID);
        [OperationContract]
        bool removeOwnerProducts(int merchID);
        [OperationContract]
        bool removefromFeed(int merchID);
    }

}
