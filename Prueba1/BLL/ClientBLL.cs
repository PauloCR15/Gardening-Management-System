// BLL/ClientBLL.cs
using Prueba1.DAL;
using Models;

namespace Prueba1.BLL
{
    public class ClientBLL
    {
        private readonly ClientDataAccess _dataAccess;

        // Inyección de dependencias
        public ClientBLL(ClientDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Client> GetAllClients()
        {

            return _dataAccess.GetAllClients();
        }

        public Client? GetClientById(int id)
        {
            return _dataAccess.GetClientById(id);
        }

        public void AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "El cliente no puede ser nulo.");
            }


            var existingClient = _dataAccess.GetClientById(client.ClientID);
            if (existingClient != null)
            {
                throw new InvalidOperationException("Ya existe un cliente registrado con esa identificación.");
            }


            try
            {
                _dataAccess.AddClient(client);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error al intentar agregar el cliente.", ex);
            }
        }

        public void RemoveClient(int id)
        {
            try
            {
                _dataAccess.DeleteClient(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar el cliente.", ex);
            }
        }
        public void UptadeClient(int id, Client client)
        {
            var exists = _dataAccess.GetClientById(id);
            if (exists == null)
            {
                throw new InvalidOperationException("No existe un cliente registrado con esa identificación.");
            }
            try
            {
                _dataAccess.UpdateClient(id, client);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar actualizar el cliente", ex);
            }
        }
        public bool checkID(int id)
        {
            return _dataAccess.checkID(id);
        }
    }
}
