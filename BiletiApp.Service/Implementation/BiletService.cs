using BiletiApp.Domain.DomainModels;
using BiletiApp.Domain.DTO;
using BiletiApp.Domain.Relations;
using BiletiApp.Repository.Interface;
using BiletiApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiletiApp.Service.Implementation
{
    public class BiletService : IBiletService
    {
        private readonly IRepository<Bilet> _biletRepository;
        private readonly IRepository<BiletShoppingCart> _biletShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public BiletService(IRepository<Bilet> productRepository, IRepository<BiletShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _biletRepository = productRepository;
            _userRepository = userRepository;
            _biletShoppingCartRepository = productInShoppingCartRepository;
        }


        public bool AddToShoppingCart(DodadiVoKoshnichkaDTO item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCart = user.UserCart;

            if (item.SelektiranBiletId != null && userShoppingCart != null)
            {
                var product = this.DetaliZaBilet(item.SelektiranBiletId);
                //{896c1325-a1bb-4595-92d8-08da077402fc}

                if (product != null)
                {
                    BiletShoppingCart itemToAdd = new BiletShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Bilet = product,
                        BiletId = product.Id,
                        ShoppingCart = userShoppingCart,
                        ShoppingCartId = userShoppingCart.Id,
                        Quantity = item.Quantity
                    };

                    var existing = userShoppingCart.BiletiShoppingCarts.Where(z => z.ShoppingCartId == userShoppingCart.Id && z.BiletId == itemToAdd.BiletId).FirstOrDefault(); //potencijalni problemi

                    if (existing != null)
                    {
                        existing.Quantity += itemToAdd.Quantity;
                        this._biletShoppingCartRepository.Update(existing);

                    }
                    else
                    {
                        this._biletShoppingCartRepository.Insert(itemToAdd);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public void KreirajBilet(Bilet p)
        {
            this._biletRepository.Insert(p);
        }

        public void IzbrishiBilet(Guid id)
        {
            var product = this.DetaliZaBilet(id);
            this._biletRepository.Delete(product);
        }

        public List<Bilet> ListajBileti()
        {
            return this._biletRepository.GetAll().ToList();
        }

        public Bilet DetaliZaBilet(Guid? id)
        {
            return this._biletRepository.Get(id);
        }

        public DodadiVoKoshnichkaDTO GetShoppingCartInfo(Guid? id)
        {
            var bilet = this.DetaliZaBilet(id);
            DodadiVoKoshnichkaDTO model = new DodadiVoKoshnichkaDTO
            {
                SelektiranBilet = bilet,
                SelektiranBiletId = bilet.Id,
                Quantity = 1
            };

            return model;
        }

        public void AzhurirajBilet(Bilet p)
        {
            this._biletRepository.Update(p);
        }
    }
}
