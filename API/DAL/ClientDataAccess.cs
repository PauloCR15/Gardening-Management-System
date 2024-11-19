// DAL/ClientDataAccess.cs
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Prueba1.DAL
{
    public class ClientDataAccess
    {
        private readonly DBContext _dbContext;

        public ClientDataAccess(DBContext context)
        {
            _dbContext = context;
        }

        public List<Client> GetAllClients()
        {
            return _dbContext.Clients.ToList();
        }

        public Client? GetClientById(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.ClientID == id);
        }

        public void AddClient(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }
        public void DeleteClient(int id)
        {
            var client = _dbContext.Clients.Find(id);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("No existe un cliente con id" + id);
            }
        }
        public void UpdateClient(int id, Client clientModified)
        {
            var client = _dbContext.Clients.Find(id);
            if (client != null)
            {
                client.ClientFullName = clientModified.ClientFullName;
                client.Province = clientModified.Province;
                client.Canton = clientModified.Canton;
                client.District = clientModified.District;
                client.ClientFullDirection = clientModified.ClientFullDirection;
                client.SummerMowingPreferenceID = clientModified.SummerMowingPreferenceID;
                client.WinterMowingPreferenceID = clientModified.WinterMowingPreferenceID;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Client not found");
            }
        }
        public bool checkID(int id)
        {
            bool exists = false;
            var existingClient = _dbContext.Clients.Find(id);
            if (existingClient != null)
            {
                exists = true;
            }
            return exists;
        }

    }
}
