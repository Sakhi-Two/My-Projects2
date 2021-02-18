using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BBTapes1.MyServiceReference;
using BBTapeService;

namespace BBTapes1
{
    public partial class EditAlbum : System.Web.UI.Page
    {
        BBTapesServiceClient BB = new BBTapesServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AlbumInfo edited = BB.GetAlbum(Convert.ToInt32(Request.QueryString["A"]));
                arID.Value = Convert.ToString(edited.artistID);
                aPrice.Value = Convert.ToString(edited.price);
            }
        }

        protected void BtEdit_Click(object sender, EventArgs e)
        {
                AlbumInfo edit = new AlbumInfo
                {
                    artistID = Convert.ToInt32(arID.Value),
                    price = Convert.ToDouble(aPrice.Value)
                };

            var edited = BB.EditAlbum(edit, Convert.ToInt32(Request.QueryString["A"]));
        }
    }
}