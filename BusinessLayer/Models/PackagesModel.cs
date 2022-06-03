using System;
using DataAccessLayer.Entities;
using BusinessLayer.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.InterfaceRepositories;
using BusinessLayer.Cache;

namespace BusinessLayer.Models
{
    public class PackagesModel
    {
        private int _idPackages;
        private string _name;
        private int _numberSessions;
        private int _availableDays;
        private double _price;

        public int IdPackages { get => _idPackages; set => _idPackages = value; }
        public string Name { get => _name; set => _name = value.Trim(); }
        public int NumberSessions { get => _numberSessions; set => _numberSessions = value; }
        public int AvailableDays { get => _availableDays; set => _availableDays = value; }
        public double Price { get => _price; set => _price = value; }

        private IPackagesRepository repository;
        public Operation Operation { get; set; }

        public PackagesModel()
        {
            repository = new PackagesRepository();
        }

        public PackagesModel(IPackagesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AcctionResult> SaveChanges()
        {
            try
            {
                string resultMsg;

                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(GetDataEntity());
                        resultMsg = "Paquete de suscripción cargado correctamente... !";
                        break;

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(GetDataEntity());
                        resultMsg = "Paquete de suscripción modificado correctamente... !";
                        break;

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdPackages);
                        resultMsg = "Paquete de suscripción eliminado correctamente... !";
                        break;

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }

                PackagesCache.GetInstance().Resource = await GetAll();

                return new AcctionResult(true, resultMsg);
            }
            catch (Exception ex)
            {
                return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<PackagesModel>> GetAll()
        {
            var dataModel = await repository.GetAll();

            var list = new List<PackagesModel>();

            foreach (Packages item in dataModel)
            {
                list.Add(new PackagesModel
                {
                    IdPackages = item.IdPackages,
                    Name = item.Name,
                    NumberSessions = item.NumberSessions,
                    AvailableDays = item.AvailableDays,
                    Price = item.Price,
                });
            }

            return list;
        }

        private Packages GetDataEntity()
        {
            return new Packages()
            {
                IdPackages = this.IdPackages,
                Name = this.Name,
                NumberSessions = this.NumberSessions,
                AvailableDays = this.AvailableDays,
                Price = this.Price,
            };
        }

        private void ValidateInsert()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del paquete de suscripción... !");

            if (NumberSessions <= 0)
                throw new ArgumentException("El numero de sesiones debe ser mayor a 0... !");

            if (AvailableDays <= 0)
                throw new ArgumentException("El numero de dias debe ser mayor a 0... !");

            if (Price <= 0)
                throw new ArgumentException("El precio debe ser mayor a $ 0.00... !");

            IdPackages = -1;
        }

        private void ValidateUpdate()
        {
            if (IdPackages < 1)
                throw new ArgumentException("No se selecciono ningun paquete de suscripción para modificar... !");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del paquete de suscripción... !");

            if (NumberSessions <= 0)
                throw new ArgumentException("El numero de sesiones debe ser mayor a 0... !");

            if (AvailableDays <= 0)
                throw new ArgumentException("El numero de dias debe ser mayor a 0... !");

            if (Price <= 0)
                throw new ArgumentException("El precio debe ser mayor a $ 0.00... !");

        }

        private void ValidateDelete()
        {
            if (IdPackages < 1)
                throw new ArgumentException("No se selecciono ningun paquete de suscripción para eliminar... !");
        }
    }
}
