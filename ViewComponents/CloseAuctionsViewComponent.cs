using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ISProject.Data;
using ISProject.Models;
using ISProject.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;




namespace ISProject.ViewComponents
{
    public class CloseAuctionsViewComponent : ViewComponent
    {
        ApplicationDbContext _db;


        public CloseAuctionsViewComponent(ApplicationDbContext db)
        {
            _db = db;      
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var now = DateTime.Now;

            var auctions = await _db.AuctionHeader
                            .Where(a=> (!a.Seen) && (DateTime.Compare(now,a.EndDate) >=0) )
                            .Include(a=>a.User)
                            .ToListAsync();
            
            foreach(var au in auctions)
                Close(au);

            return await Task.FromResult<IViewComponentResult>(Content(string.Empty));          
        }


        private async void Close(AuctionHeader auction)
        {
            var winner = await _db.AuctionUser.FirstOrDefaultAsync(u => u.AuctionId == auction.Id && u.LastPriceOffered == auction.CurrentPrice);

            if(winner == null)
            {
                var aproducts = await _db.AuctionProduct.Where(p => p.AuctionId == auction.Id).ToListAsync();

                foreach(AuctionProduct ap in aproducts)
                {
                    ProductSale psale = await _db.ProductSale.Where(ps => ps.ProductId == ap.ProductId && ps.SellerId == auction.SellerId).FirstAsync();

                    psale.Units += ap.Quantity;
                    _db.ProductSale.Update(psale);
                    // _db.AuctionProduct.Remove(ap);
                }

                await NotiApi.SendNotiAuction(_db,"Your auction was succefully ignored", auction.SellerId, auction.Id); 
                auction.Seen = true;
                _db.AuctionHeader.Update(auction);
            }
            else
            {
                //winner
                await NotiApi.SendNotiAuction(_db,"Congrats! You win the auction " + auction.Id.ToString() + ".", winner.UserId, auction.Id); 
                await NotiApi.SendNotiAuction(_db,"Your auction was succefully closed", auction.SellerId, auction.Id);
                auction.Seen = true;
                _db.AuctionHeader.Update(auction);
            }
            
            // _db.AuctionHeader.Remove(auction);
            _db.SaveChanges();
        }

    }

    
}