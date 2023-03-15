using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {

        public BookstoreContext context;

        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkouts => context.Checkout.Include(x => x.Lines).ThenInclude(x => x.Book);


        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if (checkout.CheckoutId == 0)
            {
                context.Checkout.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
