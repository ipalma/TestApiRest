using System;
using Repository.Interfaces;
using Repository.Implements;
using Models;
using TestApiRest.ViewModels;
using Unity;
using System.Data.Entity;

namespace TestApiRest
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<DbContext, AdventureWorksEntities>();
            container.RegisterType<IRepository<Address, AddressViewModel>, Repository<Address, AddressViewModel>>();
            container.RegisterType<IRepository<Customer, CustomerViewModel>, Repository<Customer, CustomerViewModel>>();
            container.RegisterType<IRepository<CustomerAddress,CustomerAddressViewModel>, Repository<CustomerAddress, CustomerAddressViewModel>>();
            container.RegisterType<IRepository<Product,ProductViewModel>, Repository<Product,ProductViewModel>>();
            container.RegisterType<IRepository<ProductCategory,ProductCategoryViewModel>, Repository<ProductCategory, ProductCategoryViewModel>>();
            container.RegisterType<IRepository<ProductDescription,ProductDescriptionViewModel>, Repository<ProductDescription,ProductDescriptionViewModel>>();
            container.RegisterType<IRepository<ProductModel, ProductModelViewModel>, Repository<ProductModel,ProductModelViewModel>>();
            container.RegisterType<IRepository<ProductModelProductDescription,ProductModelProductDescriptionViewModel>, Repository<ProductModelProductDescription, ProductModelProductDescriptionViewModel>>();
            container.RegisterType<IRepository<SalesOrderDetail,SalesOrderDetailViewModel>, Repository<SalesOrderDetail,SalesOrderDetailViewModel>>(); 
            container.RegisterType<IRepository<SalesOrderHeader,SalesOrderHeaderViewModel>, Repository<SalesOrderHeader,SalesOrderHeaderViewModel>>();
        }
    }
}