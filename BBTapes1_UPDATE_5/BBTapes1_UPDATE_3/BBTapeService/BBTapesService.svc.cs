using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BBTapeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : BBTapesService
    {
        BBTapesdbmlDataContext dataBase = new BBTapesdbmlDataContext();
        public bool AddAlbum(AlbumInfo album)
        {
            Album a = new Album
            {
                Artist_ID = album.artistID,
                AlbumName = album.AlbumName,
                Price = Math.Round((Convert.ToDecimal(album.price)), 2),
                ReleaseDate = album.releaseDate,
                Album_Image = album.Images
            };
            dataBase.Albums.InsertOnSubmit(a);
            try
            {
                dataBase.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public AlbumInfo GetAlbum(int ID)
        {
            var album = (from a in dataBase.Albums
                             where a.Album_ID.Equals(ID)
                             select a).FirstOrDefault();
            AlbumInfo al = new AlbumInfo
            {
                artistID= album.Artist_ID,
                AlbumName=album.AlbumName,
                price =Convert.ToDouble(album.Price),
                releaseDate= album.ReleaseDate,
                Images =album.Album_Image


            };

            return al;
        }

        public String getArtistName(int ArtistID)
        {
            var artist = (from a in dataBase.Artists
                          where a.Artist_ID.Equals(ArtistID)
                        select a).FirstOrDefault();
            if (artist != null)
            {
                return artist.Artist_StageName;
            }
            else
            {
                return "Artist does not exist";
            }
        }

        public UsersInfo getUsers(string username)
        {
            
            var user = (from u in dataBase.Users
                        where u.Username.Equals(username)
                        select u).FirstOrDefault();
            UsersInfo userInfo = new UsersInfo
            {
                userID=user.Id,
                username = user.Username,
                surname= user.Surname,
                UserType=user.UserType,
                email= user.Email,


            };
            return userInfo;
        }

        public int Login(string username, string password)
        {
            var login = (from u in dataBase.Users
                             where u.Username.Equals(username) && u.Password.Equals(Secrecy.HashPassword(password))
                             select u).FirstOrDefault();

            if(login != null)
            {
                return login.Id;
            }
            else
            {
                return 0;
            }

        }

        public int Register(UsersInfo user)
        {
            var u =new  User
            {
                Name=user.name,
                Surname= user.surname,
                Username=user.username,
                Email= user.email,
                Address=user.address,
                Contacts=user.contacts,
                Password=Secrecy.HashPassword(user.password),
                UserType =user.UserType
            };

            dataBase.Users.InsertOnSubmit(u);

            try
            {
                dataBase.SubmitChanges();
                return 1;
            }catch(Exception ex)
            {
                ex.GetBaseException();
                return 0;
            }
        }

        public bool Registered(string username, string password)
        {
            dynamic register = (from u in dataBase.Users
                             where u.Username.Equals(username) && u.Password.Equals(Secrecy.HashPassword(password))
                             select u).FirstOrDefault();
            if (register != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isAlbum(string albumName)
        {
            dynamic search = (from a in dataBase.Albums
                              where a.AlbumName.Equals(albumName)
                              select a).FirstOrDefault();
            if (search != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditAlbum(AlbumInfo album, int ID)
        {

            dynamic search = (from a in dataBase.Albums
                              where a.Album_ID.Equals(ID)
                              select a).FirstOrDefault();
            Album al = new Album
            {
                Artist_ID=album.artistID,
                AlbumName =album.AlbumName,
                Price=Math.Round((Convert.ToDecimal(album.price)),2),
                ReleaseDate=album.releaseDate,
                Album_Image=album.Images

            };

            try
            {
                dataBase.SubmitChanges();
                return true;

            }catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

       

        public List<ArtistInfo> getArtists(int ArtistType)
        {
            dynamic found = (from i in dataBase.Artists
                             where i.Artist_Type.Equals(ArtistType)
                             select i);

            List<ArtistInfo> artists = new List<ArtistInfo>();

            foreach (Artist i in found)
            {
                ArtistInfo al = new ArtistInfo
                {
                    artist_ID = i.Artist_ID,
                    artist_name = i.Artist_Name,
                    artist_DOB =Convert.ToDateTime(i.Artist_DateOfBirth),
                    artist_SN = i.Artist_StageName,
                    artist_POB = i.Artist_PlaceOfBirth,
                    artist_image = i.Artist_Image,
                    artist_type = Convert.ToInt32(i.Artist_Type)
                };

                artists.Add(al);
            }

            return artists;
        }


        public List<AlbumInfo> GetArtistAlbum(int ArtistID)
        {

            dynamic found = (from a in dataBase.Albums
                             where a.Artist_ID.Equals(ArtistID)
                             
                             select a);

            List<AlbumInfo> list = new List<AlbumInfo>();
            foreach(Album a in found)
            {
                AlbumInfo al = new AlbumInfo
                {
                    AlbumID=a.Album_ID,
                    artistID = a.Artist_ID,
                    AlbumName = a.AlbumName,
                    price = Convert.ToDouble(Math.Round(a.Price, 2)),
                    releaseDate = a.ReleaseDate,
                    Images = a.Album_Image
                    
                };
                list.Add(al);
            }
            return list;
        }

        public bool AddToCart(CartInfo cart)
        {

            CartItem items = new CartItem
            {
                Id = cart.userID,
                Album_ID = cart.albumID
               // Quantity = cart.Quantity
            };
            dataBase.CartItems.InsertOnSubmit(items);
            try
            {
                dataBase.SubmitChanges();
                return true;
            }catch(Exception e)
            {
                e.GetBaseException();
                return false;

            }

            
        }

        public List<int> getCartItems(int userID)
        {
            dynamic found = (from a in dataBase.CartItems
                             where a.Id.Equals(userID)
                             select a);
            List<int> list = new List<int>();
            if (found != null)
            {
                foreach(CartItem a in found)
                {
                    list.Add(a.Album_ID);

                }
            }
           
            return list;
        }

        public bool DeleteAlbum(int ID)
        {
            bool del = false;
            dynamic found = (from i in dataBase.Albums
                             where i.Album_ID == ID
                             select i).FirstOrDefault();
            if (found != null)
            {
                dataBase.Albums.DeleteOnSubmit(found);
                del = true;
            }

            try
            {
                dataBase.SubmitChanges();
                return del;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return del;
            }
        }

        public bool NewAlbum(string Name)
        {
            dynamic album = (from a in dataBase.Albums
                             where a.Album_ID.Equals(Name)
                             select a).FirstOrDefault();

            if (album == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SearchAlbum(int ID)
        {
            dynamic found = (from f in dataBase.Albums
                             where f.Album_ID.Equals(ID)
                             select f).FirstOrDefault();

            if (found != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
