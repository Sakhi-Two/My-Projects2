using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BBTapeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface BBTapesService
    {
        [OperationContract]
        int Register(UsersInfo user);

        [OperationContract]
        bool Registered(string username, string password);


        [OperationContract]
        int Login(string username,string password);
        [OperationContract]
        bool EditAlbum(AlbumInfo album,int ID);
        [OperationContract]
        bool AddAlbum(AlbumInfo album);

        [OperationContract]
        AlbumInfo GetAlbum(int ID);
        [OperationContract]
        UsersInfo getUsers(string username);

        [OperationContract]
        bool isAlbum(string albumName);
        [OperationContract]
        List<ArtistInfo> getArtists(int ArtistType);
        [OperationContract]
        List<AlbumInfo> GetArtistAlbum(int ArtistID);
        [OperationContract]
        bool AddToCart(CartInfo cart);
        
        [OperationContract]
        String getArtistName(int ArtistID);
        [OperationContract]
        List<int> getCartItems(int userID);

        [OperationContract]
        bool NewAlbum(string Name);

        [OperationContract]
        bool SearchAlbum(int ID);
        [OperationContract]
        bool DeleteAlbum(int ID);


    }
}
