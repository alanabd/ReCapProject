using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarServices>().SingleInstance();//burada sistem eğer IProductService isterse ProductManager ver demek istriyoruz
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();//burada sistem eğer IProductService isterse ProductManager ver demek istriyoruz
        }
    }
}
