using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AtEaseWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AtEaseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AtEaseService.svc or AtEaseService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class AtEaseService : IAtEaseService
    {
        AteaseDataDataContext db = new AteaseDataDataContext();

        //*******************PLEASE DO NOT PUT FUNCTI//Student loginONS RANDOMLY, CHECK THE COMMENTS******************\\


        //******Student Functions here********\\
        //Registers Student to system 
        public bool RegisterStudent(StudentClass s)
        {
            var newStudent = new Student
            {
                Stu_Num = s.stuNum,
                Stu_Name = s.name,
                Stu_Surname = s.surname,
                Stu_Email = s.email,
                Stu_Contact = s.contact,
                Stu_Degree = s.degree,
                Stu_Password = Secrecy.HashPassword(s.password),
                IsActive = 1
            };
            db.Students.InsertOnSubmit(newStudent);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        //Checks if student using email is registered or exists
        public bool IsStuRegistered(String email)
        {
            dynamic reg = (from r in db.Students
                           where r.Stu_Email.Equals(email)
                           select r).FirstOrDefault();
            if (reg == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int StudentLogin(string Email, string Password)
        {
            var stuLogin = (from u in db.Students
                            where u.Stu_Email.Equals(Email) && u.Stu_Password.Equals(Secrecy.HashPassword(Password))
                            select u).FirstOrDefault();

            if (stuLogin != null)
            {
                if (stuLogin.IsActive == 0)
                    return 1;
                else
                    return 2;
            }
            else
            {
                return 0;
            }
        }
        
        //Check if student is active first.
        public bool checkStudentActive(string email)
        {
            var stuActive = (from a in db.Students
                        where a.IsActive == 0 && a.Stu_Email.Equals(email)
                        select a).FirstOrDefault();

            if (stuActive.IsActive == 0)
                return false;
            else
                return true;
        }

        public bool SearchBook(string SearchValue) 
        {
            dynamic got = (from g in db.Books
                           where g.ISBN.Equals(SearchValue) || g.Book_Name.Equals(SearchValue) || g.Book_Author.Equals(SearchValue)
                           select g).FirstOrDefault();
            if (got != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public BookClass GetBook(string book)
        {
            dynamic Thebook = (from g in db.Books
                               where g.ISBN.Equals(book) || g.Book_Name.Equals(book) || g.Book_Author.Equals(book) 
                               select g).FirstOrDefault();
            if (Thebook != null)
            {


                BookClass bk = new BookClass
                {
                    isbn = Thebook.ISBN,
                    name = Thebook.Book_Name,
                    author = Thebook.Book_Author,
                    edition = Thebook.Book_Edition,
                    image = Thebook.Image,
                };
                return bk;
            }
            else
                return null;

        }

        public List<BookClass> GetHomeBooks()
        {
            dynamic locate = (from m in db.Books
                              select m);

            List<BookClass> booklist = new List<BookClass>();
            int counter = 0;
            foreach (Book m in locate)
            {
                if (counter < 8)
                {
                    BookClass man = new BookClass
                    {
                        isbn = m.ISBN,
                        name = m.Book_Name,
                        edition = m.Book_Edition,
                        author = m.Book_Author,
                        image = m.Image,
                    };
                    booklist.Add(man);
                    counter++;
                }
            }
            return booklist;
        }
        public List<ProductClass> GetProductMerchants(string isbn)
        {
            dynamic locate = (from m in db.Products
                              where m.ISBN.Equals(isbn)
                              select m);

            List<ProductClass> merchants = new List<ProductClass>();

            foreach (Product mer in locate)
            {
                ProductClass mc = new ProductClass
                {
                    prodID = mer.Product_ID,
                    isbn = mer.ISBN,
                    merchID = Convert.ToInt32(mer.Merchant_ID),
                    price = Convert.ToInt32(mer.Price),
                    image = mer.Image
                };
                merchants.Add(mc);
            }
            return merchants;
        }

        public bool addtoQuote(QuotationClass Q)
        {
            Quotation info = new Quotation
            {
             //   Quote_ID = Q.quoteID,
                Stu_Num = Q.studentnum,
                ISBN = Q.isbn,
                Date = Q.date,
                Price = Q.price,
                Merchant_ID = Q.merchID,
            };
            db.Quotations.InsertOnSubmit(info);
            try
            {
              
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }

        }

        public List<QuotationClass> getQuoteInfo(string number)
        {
            dynamic got = (from q in db.Quotations
                           where q.Stu_Num.Equals(number)
                           select q);
            List<QuotationClass> quote = new List<QuotationClass>();

            foreach (Quotation q in got)
            {
                QuotationClass qt = new QuotationClass
                {
                    quoteID = q.Quote_ID,
                    studentnum = q.Stu_Num,
                    date = q.Date,
                    isbn = q.ISBN,
                    merchID = q.Merchant_ID,
                    price = Convert.ToInt32(q.Price)
                };
                quote.Add(qt);
                
            }
            return quote;
        }
        public string getStuNumber(string email)
        {
            var student = (from s in db.Students
                           where s.Stu_Email.Equals(email)
                           select s).FirstOrDefault();
            if (student != null)
            {
                return student.Stu_Num;
            }
            else
            {
                return "";
            }
        }

        public bool setIsRated(string stuNum,int merchId,int val)
        {
            var feed = (from s in db.Feedbacks
                           where s.Stu_Num.Equals(stuNum) && s.Merchant_ID.Equals(merchId)
                           select s).FirstOrDefault();
            if(feed != null)
            {
                try
                {
                    feed.IsRated = val ;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return false;
                }

            }
            return false;
        }
        //******Merchant Functions here********\\

        //Registers user as a merchant


        public bool RegisterMerchant(MerchantClass m)
        {
            var NewMerchant = new Merchant
            {
                Merch_Name = m.name,
                Merch_Email = m.email,
                Merch_Contact = m.contact,
                Merch_Password = Secrecy.HashPassword(m.password),
                IsActive = 1,
            };
            db.Merchants.InsertOnSubmit(NewMerchant);

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        //Checks if merchant email is already registered or exists
        public bool IsMerchRegistered(String email)
        {
            dynamic reg = (from r in db.Merchants
                           where r.Merch_Email.Equals(email)
                           select r).FirstOrDefault();
            if (reg == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        //Merchant rating
        public int GetMerchRating(int MerchID)
        {
            int total = 0;
            int counter = 0;
            double avgRating = 0.0;
            dynamic got = (from m in db.Feedbacks
                           where m.Merchant_ID.Equals(MerchID)
                           select m);

            if(got != null)
            {
                foreach(Feedback r in got) ///////////Possible Error
                {
                    total += r.Rating ?? default(int);
                    counter++;
                }
                if (counter == 0)
                {
                    avgRating = total / 1;
                }
                else
                {
                    avgRating = total / counter;
                }
                
                return Convert.ToInt32(Math.Round(avgRating, 0));
            }
            else
            {
                return 0;
            }

        }

        //Merchant login
        public int MerchantLogin(string Email, string Password)
        {
            var merchLogin = (from m in db.Merchants
                              where m.Merch_Email.Equals(Email) && m.Merch_Password.Equals(Password)
                              select m).FirstOrDefault();

            if(merchLogin != null)
            {
                if (merchLogin.IsActive == 0)
                    return 1;
                else
                    return 2;
            }
            else
            {
                return 0;
            }
        }

        //check Merchant is active
        public bool checkMerchantActive(string email)
        {
            var merchActive = (from a in db.Merchants
                        where a.IsActive == 0 && a.Merch_Email.Equals(email)
                        select a).FirstOrDefault();

            if (merchActive.IsActive == 0)
            {
                return false;
            }
            else
            {
                return true;
            }        
        }
        public List<MerchantClass> GetAllMerchants()
        {
            dynamic locate = (from m in db.Merchants
                              select m);

            List<MerchantClass> merchants = new List<MerchantClass>();

            foreach (Merchant mer in locate)
            {
                MerchantClass mc = new MerchantClass
                {
                    merchID = mer.Merchant_ID,
                    name = mer.Merch_Name,
                    email = mer.Merch_Email,
                    contact = mer.Merch_Contact,
                    password = mer.Merch_Password,
                    image = mer.Merch_Image,
                    isactive = Convert.ToInt32(mer.IsActive),
                    strikes = Convert.ToInt32(mer.Merch_Strikes)
                };
                merchants.Add(mc);
            }

            return merchants;
        }


        public MerchantClass GetMerchant(int merchid)
        {
            dynamic mer = (from m in db.Merchants
                           where m.Merchant_ID.Equals(merchid)
                           select m).FirstOrDefault();

            if (mer != null)
            {
                MerchantClass mc = new MerchantClass
                {
                    merchID = mer.Merchant_ID,
                    name = mer.Merch_Name,
                    email = mer.Merch_Email,
                    contact = mer.Merch_Contact,
                    password = mer.Merch_Password,
                    image = mer.Merch_Image,
                    isactive = Convert.ToInt32(mer.IsActive),
                    strikes = Convert.ToInt32(mer.Merch_Strikes)

                };


                return mc;
            }
            else
                return null;
        }

        public ProductClass GetMerchProduct(string isbn, string merchID)
        {
            dynamic mer = (from m in db.Products
                              where m.ISBN.Equals(isbn) && m.Merchant_ID.Equals(merchID)
                              select m).FirstOrDefault();

            if(mer!= null)
            {
                ProductClass mc = new ProductClass
                {
                    prodID = mer.Product_ID,
                    isbn = mer.ISBN,
                    merchID = Convert.ToInt32(mer.Merchant_ID),
                    price = Convert.ToInt32(mer.Price),
                    image = mer.Image
                };
                return mc;
            }

            return null;

        }

        public int GetMerchID(string Email)
        {
            var merchant = (from m in db.Merchants
                            where m.Merch_Email.Equals(Email)
                            select m).FirstOrDefault();
            if (merchant != null)
            {
                return merchant.Merchant_ID;
            }
            else
            {
                return 0;
            }
        }

        public List<ProductClass> AllMerchProducts(int MerchID)
        {
            dynamic locate = (from m in db.Products
                              where m.Merchant_ID.Equals(MerchID)
                              select m);

            List<ProductClass> books = new List<ProductClass>();

            foreach (Product mer in locate)
            {
                ProductClass mc = new ProductClass
                {
                    merchID = mer.Merchant_ID ?? default(int),
                    image = mer.Image,
                    reviews = mer.Product_Reviews,
                    isbn = mer.ISBN,
                    price = Convert.ToInt32(mer.Price),
                    rating = Convert.ToInt32(mer.Product_Rating),

                };
                books.Add(mc);
            }
            return books;

        }

        public bool EditMerchant(MerchantClass m, string email)
        {
            var TempMerchant = (from us in db.Merchants
                                where us.Merch_Email.Equals(email)
                                select us).FirstOrDefault();

            TempMerchant.Merch_Name = m.name;
            TempMerchant.Merch_Email = m.email;
            TempMerchant.Merch_Contact = m.contact;
            TempMerchant.Merch_Password = Secrecy.HashPassword(m.password);
            TempMerchant.Merch_Image = "\\img\\merchants\\" + m.image;
            TempMerchant.IsActive = 1;

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (IndexOutOfRangeException ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public bool AddMerchProduct(ProductClass mbc)
        {
            Product mb = new Product
            {
                ISBN = mbc.isbn,
                Merchant_ID = mbc.merchID,
                Price = mbc.price,
                Image = mbc.image,
            };
            db.Products.InsertOnSubmit(mb);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public bool IsNewMerchBook(string isbn, int merchID)
        {
            dynamic book = (from mb in db.Products
                            where mb.ISBN.Equals(isbn) && mb.Merchant_ID.Equals(merchID)
                            select mb).FirstOrDefault();

            if (book == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool removeMerchProduct(string isbn, int merchID)
        {
            bool removed = false;
            dynamic got = (from mb in db.Products
                           where mb.ISBN.Equals(isbn) && mb.Merchant_ID.Equals(merchID)
                           select mb).FirstOrDefault();
            if (got != null)
            {
                db.Products.DeleteOnSubmit(got);
                removed = true;
            }

            try
            {
                db.SubmitChanges();
                return removed;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return removed;
            }
        }

        // Remove merch in products
        public bool removeOwnerProducts(int merchID)
        {
            bool removed = false;
            dynamic got = (from mb in db.Products
                           where mb.Merchant_ID.Equals(merchID)
                           select mb).FirstOrDefault();
            if (got != null)
            {
                db.Products.DeleteOnSubmit(got);
                removed = true;
            }

            try
            {
                db.SubmitChanges();
                return removed;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return removed;
            }
        }

        public bool removefromFeed(int merchID)
        {
            bool removed = false;
            dynamic got = (from mb in db.Feedbacks
                           where mb.Merchant_ID.Equals(merchID)
                           select mb).FirstOrDefault();
            if (got != null)
            {
                db.Feedbacks.DeleteOnSubmit(got);
                removed = true;
            }

            try
            {
                db.SubmitChanges();
                return removed;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return removed;
            }
        }

        public bool SetMerchPrice(int price, string isbn, int merchID)
        {
            dynamic got = (from mb in db.Products
                           where mb.ISBN.Equals(isbn) && mb.Merchant_ID.Equals(merchID)
                           select mb).FirstOrDefault();

            got.Price = price;
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (IndexOutOfRangeException ex)
            {
                ex.GetBaseException();

                return false;
            }

        }

        public string getISBN(string name)
        {
            dynamic book = (from mb in db.Books
                            where mb.Book_Name.Equals(name)
                            select mb).FirstOrDefault();

            if(book != null)
            {
                return book.ISBN;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetMerchReviews(int merchID)
        {
            dynamic got = (from mr in db.Feedbacks
                           where mr.Merchant_ID.Equals(merchID)
                           select mr);
            List<string> theReviews = new List<string>();
            if (got != null)
            {
                foreach(Feedback r in got)
                {
                    theReviews.Add(r.Reviews);
                }
                return theReviews;
            }
            else
            {
                return null;
            }
        }

        public int GetIsRated(int merchID,string stuNum)
        {
            dynamic got = (from mr in db.Feedbacks
                           where mr.Stu_Num.Equals(stuNum) && mr.Merchant_ID.Equals(merchID)
                           select mr).FirstOrDefault();

            if(got != null)
            {
                return got.IsRated;
            }
            else
            {
                return -1;
            }

        }

        public bool removeMerchant(int merchID)
        {
            bool removed = false;
            dynamic got = (from mb in db.Merchants
                           where mb.Merchant_ID.Equals(merchID)
                           select mb).FirstOrDefault();
            if (got != null)
            {
                
                db.Merchants.DeleteOnSubmit(got);
                removed = true;
                try
                {
                    db.SubmitChanges();
                    return removed;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return removed;
                }
            }

            return false;
        }
        //******Manager Functions here********\\

        //Manager login
        public int ManagerLogin(string Email, string Password)
        {
            var manLogin = (from u in db.Managers
                        where u.Man_Email.Equals(Email) &&
                        u.Man_Password.Equals(Password)
                        select u).FirstOrDefault();

            if (manLogin != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

       public bool removeFromQuote(string isbn, int merchID)
        {
            bool removed = false;
            dynamic got = (from mb in db.Quotations
                           where mb.ISBN.Equals(isbn) && mb.Merchant_ID.Equals(merchID)
                           select mb).FirstOrDefault();
            if (got != null)
            {
                db.Quotations.DeleteOnSubmit(got);
                removed = true;
            }

            try
            {
                db.SubmitChanges();
                return removed;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return removed;
            }
        }

        public bool setRating(int rating, string stuNum, int merch)
        {
            dynamic found = (from f in db.Feedbacks
                             where stuNum == f.Stu_Num && merch == f.Merchant_ID
                             select f).FirstOrDefault();

            if(found != null)
            {
                found.Rating = rating;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (IndexOutOfRangeException ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool setReview(string rev, string stuNum, int merch)
        {
            dynamic found = (from f in db.Feedbacks
                             where stuNum == f.Stu_Num && merch == f.Merchant_ID
                             select f).FirstOrDefault();

            if (found != null)
            {
                found.Reviews = rev;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (IndexOutOfRangeException ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<FeedbackClass> getAllFeedback(string stuNum)
        {
            dynamic got = (from f in db.Feedbacks
                           where stuNum == f.Stu_Num
                           select f);
            
                List<FeedbackClass> fbc = new List<FeedbackClass>();
                foreach(Feedback f in got)
                {
                    FeedbackClass fc = new FeedbackClass
                    {
                        merchID = Convert.ToInt32(f.Merchant_ID),
                        rating = Convert.ToInt32(f.Rating),
                        review = f.Reviews,
                        stuNum = f.Stu_Num
                    };
                    
                    fbc.Add(fc);
                }
                return fbc;
        }

        public bool setFeedback(FeedbackClass fb)
        {
           var NewFeed = new Feedback
            {
                feed_ID = fb.feedID,
                Stu_Num = fb.stuNum,
                Merchant_ID = fb.merchID,
                Rating = fb.rating,
                Reviews = fb.review,
                IsRated = fb.isRated
            };
            db.Feedbacks.InsertOnSubmit(NewFeed);

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public bool reportMerchant(int merID)
        {
            dynamic found = (from f in db.Merchants
                             where merID == f.Merchant_ID
                             select f).FirstOrDefault();
            if (found != null)
            {
                found.Merch_Strikes = found.Merch_Strikes + 1;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
