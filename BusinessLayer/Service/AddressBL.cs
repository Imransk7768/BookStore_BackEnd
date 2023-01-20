using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRL iaddressRL;
        public AddressBL(IAddressRL iaddressRL)
        {
            this.iaddressRL = iaddressRL;
        }
        public string AddAddress(AddressModel addressModel, int userId)
        {
            try
            {
                return this.iaddressRL.AddAddress(addressModel, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AddressModel UpdateAddress(AddressModel addressModel, int addressId, int userId)
        {
            try
            {
                return this.iaddressRL.UpdateAddress(addressModel, addressId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteAddress(int addressId, int userId)
        {
            try
            {
                return this.iaddressRL.DeleteAddress(addressId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AddressModel> GetAllAddresses(int userId)
        {
            try
            {
                return this.iaddressRL.GetAllAddresses(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

